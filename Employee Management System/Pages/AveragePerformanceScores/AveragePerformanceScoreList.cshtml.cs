using Domain.DTO;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee_Management_System.Pages.AveragePerformanceScores
{
    public class AveragePerformanceScoreListModel : PageModel
    {
        private readonly IPerformanceReview _PerformanceReviewManager;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        private const int PageSize = 5;

        public List<AveragePerformanceScoreDTO> AveragePerformanceScores { get; set; }

        public AveragePerformanceScoreListModel(IPerformanceReview performanceReviewManager)
        {
            _PerformanceReviewManager = performanceReviewManager;
        }

        public void OnGet(int pageNumber = 0)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;

            // Replace this with actual logic for fetching the total count of average performance scores
            int totalScores = _PerformanceReviewManager.GetAveragePerformanceScores().Count;
            TotalPages = totalScores == 0 ? 1 : (int)Math.Ceiling(totalScores / (double)PageSize);

            // Ensure we don't go beyond total pages
            CurrentPage = Math.Max(1, Math.Min(pageNumber, TotalPages));

            // Fetch paged data
            AveragePerformanceScores = _PerformanceReviewManager.GetPagedAveragePerformanceScores(CurrentPage, PageSize);
        }
    }
}
