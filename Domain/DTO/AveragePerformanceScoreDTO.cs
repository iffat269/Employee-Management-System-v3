using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AveragePerformanceScoreDTO
    {
        public int DepartmentId { get; set; } // Department ID
        public string DepartmentName { get; set; } // Department Name
        public decimal AveragePerformanceScore { get; set; } // Average Performance Score
    }
}
