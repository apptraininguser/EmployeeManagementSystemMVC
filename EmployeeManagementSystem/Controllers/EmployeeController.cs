using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{

    public class EmployeeController : Controller
    {


        private readonly IEmployeeRepository _employeeRepository;

        private readonly IEmployeeClient _employeeClient;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeClient employeeClient)
        {
            _employeeRepository = employeeRepository;
            _employeeClient = employeeClient;
        }

        [Route("get-employees")]
        public IActionResult GetEmployee()   
        {

            //var employeeRepository = new EmployeeRepository();

            //var employees = _employeeRepository.GetAllEmployee();

            var employees = _employeeClient.GetEmployee();

            return View(employees);
        }

        [Route("get-employee/{studentId}")]
        public IActionResult GetEmployeeById(int studentId)
        {

            var employeeRepository = new EmployeeRepository();

            var employee = employeeRepository.GetEmployeeById(studentId);

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


        public IActionResult EditEmployee(int id)
        {
            var employeeRepository = new EmployeeRepository();

            var employee = employeeRepository.GetEmployeeById(id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(EmployeeViewModel employee, int id)
        {

            var employeeRepository = new EmployeeRepository();

            employeeRepository.UpdateEmployee(employee,id);

            return View();

        }

        public IActionResult DeleteEmployee(int? id)
        {
            var employeeRepository = new EmployeeRepository();

            var employee = employeeRepository.GetEmployeeById(id.Value);

            return View(employee);

        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            var employeeRepository = new EmployeeRepository();

            employeeRepository.DeleteEmployee(id);

            return RedirectToAction("GetEmployee", "Employee");
        } 
        
        public IActionResult EmployeeIntroduction()
        {
            return View();
        }


    }

    
}
