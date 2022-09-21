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


        public IActionResult GetEmployeeById(int id)
        {

            var employeeRepository = new EmployeeRepository();

            var employee = employeeRepository.GetEmployeeById(id);

            return View(employee);
        }

        public IActionResult InsertEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertEmployee(EmployeeViewModel employeeViewModel)
        {
            var employeeRepository = new EmployeeRepository();

            employeeRepository.InsertEmployee(employeeViewModel);

            return View();
        }




    }
}
