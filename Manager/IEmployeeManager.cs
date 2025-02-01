using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public interface IEmployeeManager
    {
        int AddEmployee(Employee employee);  // Add employee, return ID
        bool UpdateEmployee(Employee employee);  // Update employee, return success or failure
        bool DeleteEmployee(int id);  // Delete employee by ID, return success or failure
        public List<Employee> GetAllEmployee();
        public List<EmployeeInformationDTO> GetPagedEmployees(int page, int pageSize);
        public List<EmployeeInformationDTO> GetAllEmployeeInformation();
        Employee GetEmployeeById(int id); // Get department by ID
    }
}
