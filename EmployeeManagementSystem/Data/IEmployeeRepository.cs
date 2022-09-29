﻿using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetAllEmployee();
    }
}
