using Domain;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Employee_Management_System.Pages.EmployeeCRUD
{
    public class EmployeeDeleteInformationModel : PageModel
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;
        public EmployeeDeleteInformationModel(IEmployeeManager employeeManager, IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }
      
        public Employee NewEmployee { get; set; }
        public void OnGet(int? EmployeeId)
        {
            NewEmployee = _employeeManager.GetEmployeeById(EmployeeId.Value);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If model state is invalid, stay on the page.
            }

            
                NewEmployee.Deleted = true;
                // Update existing employee
                var a = _employeeManager.UpdateEmployee(NewEmployee);
                TempData["Message"] = $"Employee with ID {NewEmployee.Id} Deleted.";
           

            return RedirectToPage("/EmployeeCRUD/EmployeeList");
        }
    }
}
