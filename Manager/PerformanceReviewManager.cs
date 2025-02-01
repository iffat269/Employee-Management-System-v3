using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using Manager;
using Microsoft.EntityFrameworkCore;

namespace Manager
{
    public class PerformanceReviewManager : BaseManager<PerformanceReview>, IPerformanceReview
    {
        public PerformanceReviewManager(EMSDbContext context) : base(context) {  }
        public int AddPerformanceReview(PerformanceReview performanceReview)
        {
            return AddUpdateEntity(performanceReview);
        }

        public bool DeletPerformanceReview(int id)
        {
            return Delete(id);
        }

        public List<PerformanceReview> GetAllPerformanceReview()
        {
            return GetAll();
        }

        public List<PerformanceReviewDTO> GetAllPerformanceReviewInformation()
        {
            var PerformanceReview = GetListData<PerformanceReviewDTO>("EXEC GetPerformanceReviewDetails");

            return PerformanceReview.ToList();
        }

        public List<PerformanceReviewDTO> GetPagedPerformanceReview(int page, int pageSize)
        {
            return GetAllPerformanceReviewInformation()
               .Skip((page - 1) * pageSize)  // Skip records for previous pages
               .Take(pageSize)               // Take records for the current page
               .ToList();
        }

        public PerformanceReview GetPerformanceReviewById(int id)

        {
           
            return Find<PerformanceReview>(id);

        }

        public bool UpdatePerformanceReview(PerformanceReview performanceReview)
        {
            return AddUpdateEntity(performanceReview) == 0 ? false : true;
        }

        public List<AveragePerformanceScoreDTO> GetAveragePerformanceScores()
        {
            var PerformanceReview = GetListData<AveragePerformanceScoreDTO>("EXEC GetAveragePerformanceScoreByDepartment");

            return PerformanceReview.ToList();
        }

        public List<AveragePerformanceScoreDTO> GetPagedAveragePerformanceScores(int page, int pageSize)
        {
            return GetAveragePerformanceScores()
               .Skip((page - 1) * pageSize)  // Skip records for previous pages
               .Take(pageSize)               // Take records for the current page
               .ToList();
        }
    }
}
