using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalBL.Helpers;
using PortalBL.Interface;
using PortalBL.Models;
using PortalDAL.Entity;

namespace PortalAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        private readonly IMapper mapper;

        public EmployeeController(IEmployee employee,IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }

        //[HttpGet]
        //[Route("~/api/Employee/GetData")]
        //public string[] GetData()
        //{
        //    string[] data = new string[3] {"Mohamed","Ahmed","Orban"};
        //    return data;
        //}     
        //[HttpGet]
        //[Route("~/api/Employee/GetNames")]
        //public string[] GetNames()
        //{
        //    string[] data = new string[3] {"Omer","Tarek","fasd"};
        //    return data;
        //}

        [HttpGet]
        [Route("~/api/Employee/GetData")]
        public async Task<IActionResult> GetData()
        {

            try
            {
                var data = await employee.GetAsync();
                var res = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>()
                {
                    Code = 200,
                    Stauts = "Ok",
                    Message = "Data Found",
                    Data = res
                }) ;
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {
                    Code=404,
                    Stauts="Not Found",
                    Message="Data Not Found",
                    Data=ex.Message
                });
            }
           
        }

        [HttpGet]
        [Route("~/api/Employee/GetById/{id}")]
      public async Task<IActionResult> GetById(int id)
        {
            var data = await employee.GetByIdAsync(x=>x.IsDeleted==false&&x.IsActive==true&&x.Id==id);
            var res = mapper.Map<EmployeeVM>(data);
           
            return Ok(new ApiResponse<EmployeeVM>()
            {
                Code = 200,
                Stauts = "Ok",
                Message = "Data Found",
                Data = res
            });
        }

        [HttpPost]
      [Route("~/api/Employee/PostEmployee")]

      public async Task<IActionResult> PostEmployee(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Employee>(model);
                     var res= await employee.CreateAsync(data);
                    return Ok(new ApiResponse<Employee>
                    {
                        Code=201,
                        Stauts="Data Created",
                        Message="Data Saved",
                        Data=res
                    });
       

                }
                else
                {

                    return BadRequest(new ApiResponse<string>
                    {
                        Code = 501,
                        Stauts = "Data Not Created",
                        Message = "Data Not Saved",

                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse<string>
                {
                    Code = 501,
                    Stauts = "Data Not Created",
                    Message = "Data Not Saved",
                    Data = ex.Message
                });

            }
        }

        [HttpPut]
        [Route("~/api/Employee/PutEmployee")]
        public async Task<IActionResult> Update(EmployeeVM model)
        {


            try
            {

            
            if (ModelState.IsValid)
            {

                var result = mapper.Map<Employee>(model);
                await employee.UpdateAsync(result);


                return Ok(new ApiResponse<string>
                {
                    Code = 200,
                    Stauts = " Updated",
                    Message = "Data Updated",
                    Data="No Data Returend"

                });
            }
 
                return BadRequest(new ApiResponse<string>
                {
                    Code = 501,
                    Stauts = " Not Updated",
                    Message = "Data Not Updated",

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Code = 501,
                    Stauts = " Not Updated",
                    Message = "Data Not Updated",
                    Data=ex.Message
                });
            }
        }



        [HttpDelete]
        [Route("~/api/Employee/DeleteEmployee")]
        public async Task<IActionResult>DeleteEmployee(EmployeeVM model)
        {
            try
            {
           
              var res= mapper.Map<Employee>(model);
                await employee.DeleteAsync(res);
                return Ok(new ApiResponse<string>
                {
                    Code=200,
                    Stauts="Deleted",
                    Message="Data Deleted",
                    Data="No Returend data"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Code = 500,
                    Stauts = " Not Deleted",
                    Message = "Data Not Deleted",
                    Data = ex.Message
                });
            }

        }

    }
}
