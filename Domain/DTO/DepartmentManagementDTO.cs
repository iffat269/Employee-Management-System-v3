using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DepartmentManagementDTO
    {
        public int EmployeeId { get; set; } // Employee ID
        public string? EmployeeName { get; set; } // Employee Name
        public int? DepartmentId { get; set; } // Department ID
        public string? DepartmentName { get; set; } // Department Name
        public string? Position { get; set; } // Employee Position
        public string? Status { get; set; } // Employee Status
    }
}
