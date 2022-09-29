using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        [Route("getEmployee")]
       public IActionResult GetEmployees()
        {
            var employeeRepository = new EmployeeRepository();

            var employee = employeeRepository.GetAllEmployee();

            return Ok(employee);
        }
    }
}
