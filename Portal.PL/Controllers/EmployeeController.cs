using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalBL.Interface;
using PortalBL.Models;
using PortalDAL.Entity;

namespace PortalPL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Prop

        private readonly IEmployee employee;
        private readonly IMapper mapper;
        private readonly IDepartment department;
        private readonly ICity city;
        private readonly IDistric distric;

   
        #endregion


        #region Ctor

        public EmployeeController(IEmployee employee, IMapper mapper, IDepartment department, ICity city, IDistric distric)
        {
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
            this.city = city;
            this.distric = distric; 
        }

        #endregion


        #region Actions

        public async Task<IActionResult> Index(string SearchValue)
        {

            if (SearchValue != null)
            {

                // Search
              
                var data = await employee.SearchAsync(x => x.Name.Contains(SearchValue)
                                                        && x.IsActive == true
                                                        && x.IsDeleted == false
                                                        || x.Salary.ToString() == SearchValue
                                                        || x.Id.ToString() == SearchValue
                                                        ||x.Department.Name==SearchValue
                                                        );

                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }
            else
            {
                // Without Search
                var data = await employee.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await employee.GetByIdAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            var Dpt = await department.GetData();
            ViewBag.DepartmentList = new SelectList(Dpt, "Id", "Name", data.DepartmentId);

            return View(result);
        }


        public async Task<IActionResult> Create()
        {

            var data = await department.GetData();
            ViewBag.DepartmentList = new SelectList(data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Employee>(model);
                    await employee.CreateAsync(data);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            //ModelState.Clear();
            var Dpt = await department.GetData();
            ViewBag.DepartmentList = new SelectList(Dpt, "Id", "Name", model.DepartmentId);
            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await employee.GetByIdAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            var Dpt = await department.GetData();
            ViewBag.DepartmentList = new SelectList(Dpt, "Id", "Name", data.DepartmentId);

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    await employee.UpdateAsync(data);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            //ModelState.Clear();
            var Dpt = await department.GetData();
            ViewBag.DepartmentList = new SelectList(Dpt, "Id", "Name", model.DepartmentId);

            return View(model);

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await employee.GetByIdAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            var result = mapper.Map<EmployeeVM>(data);
            var Dpt = await department.GetData();
            ViewBag.DepartmentList = new SelectList(Dpt, "Id", "Name", data.DepartmentId);

            return View(result);
        }


        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await employee.DeleteAsync(id);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            //ModelState.Clear();
            var Dpt = await department.GetData();
            ViewBag.DepartmentList = new SelectList(Dpt, "Id", "Name");
            return View();

        }

        #endregion



        #region Ajax Call
        [HttpPost]
        public async Task<JsonResult> GetCityByIdCountry(int CuntId)
        {
            var Data = await city.GetAsync(x => x.CountryId == CuntId);
            var res =mapper.Map<IEnumerable<CityVM>>(Data);
            return Json(res);
        }
       
        [HttpPost]

        public async Task<JsonResult> GetDistricByIdCity(int CityId)
        {
            var Data = await distric.GetAsync(x => x.CityId == CityId);
            var res =mapper.Map<IEnumerable<DistricVM>>(Data);
            return Json(res);
        }
        #endregion

    }
}
