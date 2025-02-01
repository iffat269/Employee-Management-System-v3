using Domain;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee_Management_System.Pages.DepartmentManagements
{
    public class DepartmentManagementsAddModel : PageModel
    {
        private readonly IDepartmentManager _departmentManager;
        [BindProperty]
        public DepartmentManagement Department { get; set; }
        public DepartmentManagementsAddModel( IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        public void OnGet(int? id)
        {
           // Employee = _employee.GetAllDepartment();
            if (id.HasValue)
            {
                // Edit existing employee
                Department = _departmentManager.GetDepartmentById(id.Value);
            }
            else
            {
                // New employee
                Department = new DepartmentManagement();
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If model state is invalid, stay on the page.
            }

            if (Department.Id == 0)
            {
                // Add new employee
                int departmentId = _departmentManager.AddDepartment(Department);
                TempData["Message"] = $"Employee added with ID {departmentId}.";
            }
            else
            {
                // Update existing employee
                var a = _departmentManager.UpdateDepartment(Department);
                TempData["Message"] = $"Employee with ID {Department.Id} updated.";
            }

            return RedirectToPage("/DepartmentManagements/DepartmentManagementList");
        }
    }
}
