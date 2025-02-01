using Domain;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee_Management_System.Pages.PerformanceReviews
{
    public class PerformanceReviewAddModel : PageModel
    {
        private readonly IPerformanceReview _PerformanceReviewManager;
        [BindProperty]
        public PerformanceReview PerformanceReview { get; set; }

        public PerformanceReviewAddModel(IPerformanceReview performanceReview)
        {
            _PerformanceReviewManager = performanceReview;
        }
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                // Edit existing employee
                PerformanceReview = _PerformanceReviewManager.GetPerformanceReviewById(id.Value);
            }
            else
            {
                // New employee
                PerformanceReview = new PerformanceReview();
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // Output all validation errors
                }
                return Page(); // If model state is invalid, stay on the page.
            }

            if (PerformanceReview.Id == 0)
            {
                // Add new employee
                int PerformanceReviewId = _PerformanceReviewManager.AddPerformanceReview(PerformanceReview);
                TempData["Message"] = $"Performance Review added with ID {PerformanceReviewId}.";
            }
            else
            {
                // Update existing employee
                var a = _PerformanceReviewManager.UpdatePerformanceReview(PerformanceReview);
                TempData["Message"] = $"Performance Review with ID {PerformanceReview.Id} updated.";
            }

            return RedirectToPage("/PerformanceReviews/PerformanceReviewList");
        }


    }
}
