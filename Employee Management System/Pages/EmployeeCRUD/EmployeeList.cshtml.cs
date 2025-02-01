using Domain;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace Employee_Management_System.Pages.EmployeeCRUD
{
    public class EmployeeListModel : PageModel
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;

        //[BindProperties]
        //public List<Employee> Employees { get; set; }
        public List<EmployeeInformationDTO> Employees { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        private const int PageSize = 5;

        public EmployeeListModel(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
           
        }

        //public void OnGet()
        //{
        //    Employees = _employeeManager.GetAllEmployee();

        //}
        public async Task OnGet(int pageNumber  )
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            // Get the total number of employees
            int totalEmployees = _employeeManager.GetAllEmployeeInformation().Count();
            

            // Calculate the total number of pages
            TotalPages = totalEmployees == 0 ? 1 : (int)Math.Ceiling(totalEmployees/ (double)PageSize);

            // Ensure the current page is within valid range
            CurrentPage = Math.Max(1, Math.Min(pageNumber, TotalPages));

            // Retrieve employees for the current page
            Employees = _employeeManager.GetPagedEmployees(CurrentPage, PageSize);
        }
    }
}

