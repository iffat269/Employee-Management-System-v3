using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public interface IPerformanceReview
    {
        int AddPerformanceReview(PerformanceReview performanceReview);  // Add employee, return ID
        bool UpdatePerformanceReview(PerformanceReview performanceReview);  // Update employee, return success or failure
        bool DeletPerformanceReview(int id);  // Delete employee by ID, return success or failure
        public List<PerformanceReview> GetAllPerformanceReview();
        public List<PerformanceReviewDTO> GetPagedPerformanceReview(int page, int pageSize);
        public List<PerformanceReviewDTO> GetAllPerformanceReviewInformation();

        public List<AveragePerformanceScoreDTO> GetAveragePerformanceScores();

        public List<AveragePerformanceScoreDTO> GetPagedAveragePerformanceScores(int page, int pageSize);
        PerformanceReview GetPerformanceReviewById(int id); // Get department by ID
    }
}
