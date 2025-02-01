using Domain;
using Domain.DTO;
using System.Collections.Generic;

namespace Manager
{
    public interface IDepartmentManager
    {
        List<DepartmentManagement> GetAllDepartment();  // Get all departments
        List<DepartmentNameDTO> GetAllDepartmentname();  // Get all departments
        List<DepartmentManagementDTO> GetAllDepartmentManagement();  // Get all departments
        DepartmentManagement GetDepartmentById(int id); // Get department by ID
        int AddDepartment(DepartmentManagement department); // Add a new department
        bool UpdateDepartment(DepartmentManagement department); // Update a department
        bool DeleteDepartment(int id); // Delete a department
        public List<DepartmentManagementDTO> GetPagedDepartment(int page, int pageSize);


       // List<DepartmentNames> GetAllDepartments();
    }
}