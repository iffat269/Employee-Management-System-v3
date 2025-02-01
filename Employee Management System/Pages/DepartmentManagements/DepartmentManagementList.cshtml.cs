using Domain;
using Domain.DTO;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee_Management_System.Pages.DepartmentManagements
{
    public class DepartmentManagementListModel : PageModel
    {
        private readonly IDepartmentManager _departmentManager;
        private readonly IEmployeeManager _EmployeeManager;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        private const int PageSize = 5;

        public List<DepartmentManagementDTO> DepartmentManagement { get; set; }
        public DepartmentManagementListModel(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;

        }
        public async Task OnGet(int pageNumber)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            int totalDepartMent = _departmentManager.GetAllDepartmentname().Count();
            TotalPages = totalDepartMent == 0 ? 1 : (int)Math.Ceiling(totalDepartMent / (double)PageSize);
            CurrentPage = Math.Max(1, Math.Min(pageNumber, TotalPages));
            DepartmentManagement = _departmentManager.GetPagedDepartment(CurrentPage, PageSize);
        }


    }
}

