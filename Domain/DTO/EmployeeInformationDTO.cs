using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EmployeeInformationDTO
    {
        public int Id { get; set; } // Employee ID
        public string? EmployeeName { get; set; } // Employee Name
        public int DepartmentId { get; set; } // Department ID
        public string? DepartmentName { get; set; } // Department Name
        public string? Position { get; set; } // Employee Position
        public string? Status { get; set; } // Employee Status
        public bool Deleted { get; set; } // Soft Delete Flag
    }
}
