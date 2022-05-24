using Microsoft.AspNetCore.Mvc;
using PortalBL.Models;
using PortalBL.Reposatroy;

namespace PortalPL.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRep depart = new DepartmentRep();
        
        public async Task<IActionResult> Index()
        {
         var data = await depart.GetData();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                await depart.CreateAsync(model);
                 return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return View(model);
        }
    }
}
