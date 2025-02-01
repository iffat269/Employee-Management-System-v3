using Domain;
using Domain.DTO;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee_Management_System.Pages.PerformanceReviews
{
    public class PerformanceReviewListModel : PageModel
    {
        private readonly IPerformanceReview _PerformanceReviewManager;
        private readonly IEmployeeManager _EmployeeManager;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        private const int PageSize = 5;

        public List<PerformanceReviewDTO> PerformanceReviews { get; set; }
        public PerformanceReviewListModel(IPerformanceReview performanceReviewManager)
        {
            _PerformanceReviewManager = performanceReviewManager;

        }

        public async Task OnGet(int pageNumber=0)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            int totalDepartMent = _PerformanceReviewManager.GetAllPerformanceReview().Count();
            TotalPages = totalDepartMent == 0 ? 1 : (int)Math.Ceiling(totalDepartMent / (double)PageSize);
            CurrentPage = Math.Max(1, Math.Min(pageNumber, TotalPages));
            PerformanceReviews = _PerformanceReviewManager.GetPagedPerformanceReview(CurrentPage, PageSize);
        }
    }
}
