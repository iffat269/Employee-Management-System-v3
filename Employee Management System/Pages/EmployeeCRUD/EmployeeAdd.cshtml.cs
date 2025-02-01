using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain;

namespace Employee_Management_System.Pages.EmployeeCRUD
{
    public class EmployeeAddModel : PageModel
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;

        [BindProperty]
        public Employee NewEmployee { get; set; }
        public List<DepartmentManagement> Departments { get; set; }

        public EmployeeAddModel(IEmployeeManager employeeManager, IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }

        public void OnGet(int? id)
        {
            Departments = _departmentManager.GetAllDepartment();
            if (id.HasValue)
            {
                // Edit existing employee
                NewEmployee = _employeeManager.GetEmployeeById(id.Value);
            }
            else
            {
                // New employee
                NewEmployee = new Employee();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If model state is invalid, stay on the page.
            }

            if (NewEmployee.Id == 0)
            {
                // Add new employee
                int employeeId = _employeeManager.AddEmployee(NewEmployee);
                TempData["Message"] = $"Employee added with ID {employeeId}.";
            }
            else
            {
                // Update existing employee
                var a=_employeeManager.UpdateEmployee(NewEmployee);
                TempData["Message"] = $"Employee with ID {NewEmployee.Id} updated.";
            }

            return RedirectToPage("/EmployeeCRUD/EmployeeList");
        }
    }
}
