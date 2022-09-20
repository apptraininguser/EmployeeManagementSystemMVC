using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult GetEmployee()
        {

            var employeeRepository = new EmployeeRepository();

            var employees = employeeRepository.GetAllEmployee();

            return View(employees);
        }
    }
}
