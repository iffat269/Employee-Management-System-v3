using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        [Range(1, 10, ErrorMessage = "Review score must be between 1 and 10.")]
        public int? ReviewScore { get; set; } // Numeric value between 1-10

        public string? ReviewNotes { get; set; }= default(string?);
        public int EmployeeId { get; set; } // Foreign key to Employee

        // Navigation property to Employee
        public Employee? Employee { get; set; }
    }
}
