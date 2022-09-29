using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Provider
{
    public interface IEmployeeClient
    {
        List<EmployeeViewModel> GetEmployee();
    }
}
