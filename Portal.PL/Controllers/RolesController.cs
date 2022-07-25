using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalBL.Models;
using PortalDAL.Extend;

namespace PortalPL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        #region GetData
        public IActionResult Index()
        {
            var data = roleManager.Roles;
            return View(data);
        }

        #endregion


        #region CreateData

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole Model)
        {
            var data = await roleManager.CreateAsync(Model);
            if (data.Succeeded)
            {
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in data.Errors)
                {
                    ModelState.AddModelError($"{item.Code}", item.Description);
                }
            }
            return View();
        }
        #endregion


        #region UpdateData

        public async Task<IActionResult> Update(string id)
        {
            var data = await roleManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole model)
        {
            dynamic data = "";



            if (ModelState.IsValid)
            {


                data = await roleManager.UpdateAsync(model);
                if (data.Succeeded)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    foreach (var item in data.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            else
            {

                foreach (var item in data.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(data);
        }

        #endregion


        #region DeleteData


        public async Task<IActionResult> Delete(string id)
        {
            var data = await roleManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole model)
        {
            dynamic data = "";

            if (ModelState.IsValid)
            {


                data = await roleManager.DeleteAsync(model);
                if (data.Succeeded)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    foreach (var item in data.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            else
            {

                foreach (var item in data.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(data);
        }
        #endregion


        #region AddOrRemoveUsers
        public async  Task<IActionResult> AddOrRemoveUsers(string RoleId)
        {

            ViewBag.roleId = RoleId;

            var role = await roleManager.FindByIdAsync(RoleId);

            var model = new List<UserInRoleVM>();

            foreach (var user in userManager.Users)
            {
                var userInRole = new UserInRoleVM()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userInRole.IsSelected = true;
                }
                else
                {
                    userInRole.IsSelected = false;
                }

                model.Add(userInRole);
            }

            return View(model);
        }



        [HttpPost]

        public async Task<IActionResult> AddOrRemoveUsers(List<UserInRoleVM> model, string RoleId)
        {

            var role = await roleManager.FindByIdAsync(RoleId);

            for (int i = 0; i < model.Count; i++)
            {

                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {

                    result = await userManager.AddToRoleAsync(user, role.Name);

                }
                else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (i < model.Count)
                    continue;
            }

            return RedirectToAction("index", new { id = RoleId });
        }

        #endregion



    }
}
