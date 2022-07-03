using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        [Route("~/api/Employee/GetData")]
        public async Task<IActionResult>GetData()
        {
            try
            {
                var data = await employee.GetAsync(x => x.IsActive == true && x.IsDeleted == false && x.ImageIsDeleted == false);
                var res = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        } 
        [HttpGet]
        [Route("~/api/Employee/CreateAsync")]
        public async Task<IActionResult> CreateAsync()
        {
            try
            {
                var data = await employee.GetAsync(x => x.IsActive == true && x.IsDeleted == false && x.ImageIsDeleted == false);
                var res = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
