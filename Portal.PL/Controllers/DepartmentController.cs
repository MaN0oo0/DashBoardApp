using Microsoft.AspNetCore.Mvc;
using PortalBL.Interface;
using PortalBL.Models;
using PortalBL.Reposatroy;

namespace PortalPL.Controllers
{
    public class DepartmentController : Controller
    {
        //  private readonly DepartmentRep depart; ====> tightly coupled 
        private readonly IDepartment depart;//======> Loosly coupled 

        public DepartmentController(IDepartment depart)
        {
            this.depart = depart;
        }


        // public DepartmentController()
        // {
        //depart = new DepartmentRep();
        // }


        //  DepartmentRep depart = new DepartmentRep();
        public async Task<IActionResult> Index()
        {
         var data = await depart.GetData();
            return View(data);
        }
        [HttpGet]
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

        public async Task<IActionResult> Details(int id)
        {
           var data=await depart.GetDataById(id);

            return View(data);
            
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data= await depart.GetDataById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await depart.UpdateAsync(model);
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await depart.GetDataById(id);
            return View(data);

        }

        [HttpPost]
      [ActionName("Delete")]
        public async Task<IActionResult> _Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await depart.DeleteAsync(id);
                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }
            //ModelState.Clear();
            return View();
        }
    }
}
