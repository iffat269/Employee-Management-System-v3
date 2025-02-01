using Domain;
using Domain.DTO;
using Manager;
using System.Diagnostics;

namespace Manager
{
    public class DepartmentManager : BaseManager<DepartmentManagement>, IDepartmentManager
    {
        public DepartmentManager(EMSDbContext context) : base(context) { }

        public int AddDepartment(DepartmentManagement department)
        {
            return AddUpdateEntity(department);
        }

        public bool DeleteDepartment(int id)
        {
            return Delete(id);
        }

        public List<DepartmentManagement> GetAllDepartment()
        {
            return GetAll();

        }

        public List<DepartmentNameDTO> GetAllDepartmentname()
        {
            try
            {
                // Call the generic GetListData method with the appropriate DTO type
                var departmentNames = GetListData<DepartmentNameDTO>("EXEC GetDepartmentNames");

                return departmentNames.ToList();  // Ensure you return a List
            }
            catch (Exception ex)
            {
                // Handle any errors here
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        public DepartmentManagement GetDepartmentById(int id)
        {
            return Find<DepartmentManagement>(id);
        }

        public bool UpdateDepartment(DepartmentManagement department)
        {
            return AddUpdateEntity(department) == 0 ? false : true;
            
        }
        public List<DepartmentManagementDTO> GetPagedDepartment(int page, int pageSize)
        {
            return GetAllDepartmentManagement()
                   .Skip((page - 1) * pageSize)  // Skip records for previous pages
                   .Take(pageSize)               // Take records for the current page
                   .ToList();
        }

        public List<DepartmentManagementDTO> GetAllDepartmentManagement()
        {

            try
            {
                // Call the generic GetListData method with the appropriate DTO type
                var departmentNames = GetListData<DepartmentManagementDTO>("EXEC GetDepartmentManagementDetails");

                return departmentNames.ToList();  // Ensure you return a List
            }
            catch (Exception ex)
            {
                // Handle any errors here
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
