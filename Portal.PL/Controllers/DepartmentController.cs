using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalBL.Interface;
using PortalBL.Models;
using PortalBL.Reposatroy;
using PortalDAL.Entity;

namespace PortalPL.Controllers
{
    public class DepartmentController : Controller
    {
        // private readonly DepartmentRep depart;// ====> tightly coupled 
       private readonly IDepartment depart;//======> Loosly coupled 
        private readonly IMapper mapper;

        public DepartmentController(IDepartment depart,IMapper mapper)
        {
            this.depart = depart;
            this.mapper = mapper;
        }


        // public DepartmentController()
        // {
        //depart = new DepartmentRep();
        // }


        //  DepartmentRep depart = new DepartmentRep();
        public async Task<IActionResult> Index()
        {
         var data = await depart.GetData();
          var res = mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(res);
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
                    var res= mapper.Map<Department>(model);
                 await depart.CreateAsync(res);
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
            var res=mapper.Map<DepartmentVM>(data);
            return View(res);
            
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data= await depart.GetDataById(id);
            var res = mapper.Map<DepartmentVM>(data);

            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res =mapper.Map<Department>(model);
                    await depart.UpdateAsync(res);
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
            var res = mapper.Map<DepartmentVM>(data);
            return View(res);

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
