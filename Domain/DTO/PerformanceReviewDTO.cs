using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PerformanceReviewDTO
    {
        public int PerformanceReviewId { get; set; } // PerformanceReview ID
        public string EmployeeName { get; set; } // Employee Name
        public int EmployeeId { get; set; } // Employee ID
        public int? ReviewScore { get; set; } // Review Score (nullable, as it's not always present)
        public string? ReviewNotes { get; set; } // Review Notes (nullable, as it's optional)
        public int DepartmentId { get; set; } // Department ID
        public string DepartmentName { get; set; } // Department Name
    }
}
