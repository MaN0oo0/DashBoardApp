using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalDAL.Extend;

namespace PortalPL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var data = userManager.Users;

            return View(data);
        }



        public async Task<IActionResult> Update(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Update(ApplicationUser model)
        {
            dynamic data = "";
        
         
            
            if (ModelState.IsValid)
            {

          
             data = await userManager.UpdateAsync(model);
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
        public async Task<IActionResult> Delete(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser model)
        {
            dynamic data = "";



            if (ModelState.IsValid)
            {


                data = await userManager.DeleteAsync(model);
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

    }
}
