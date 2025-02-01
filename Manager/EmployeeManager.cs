using Domain;
using Manager;

public class EmployeeManager : BaseManager<Employee>, IEmployeeManager
{
    public EmployeeManager(EMSDbContext context) : base(context) { }

    public int AddEmployee(Employee employee)
    {
        return AddUpdateEntity(employee);  // No need to write 'base'
    }

    public bool UpdateEmployee(Employee employee)
    {
        return AddUpdateEntity(employee)==0? false : true;  // No need to write 'base'
    }

    public bool DeleteEmployee(int id)
    {
        return Delete(id);  // No need to write 'base'
    }

    public List<Employee> GetAllEmployee()
    {
        return GetAll();  // No need to write 'base'
    }
    public List<EmployeeInformationDTO> GetAllEmployeeInformation()
    {
        var EmployeeInformation = GetListData<EmployeeInformationDTO>("EXEC GetEmployeeDetails");

        return EmployeeInformation.ToList();
    }
    public List<EmployeeInformationDTO> GetPagedEmployees(int page, int pageSize)
    {
        return GetAllEmployeeInformation()
               .Skip((page - 1) * pageSize)  // Skip records for previous pages
               .Take(pageSize)               // Take records for the current page
               .ToList();
    }

    public Employee GetEmployeeById(int id)
    {
        return Find<Employee>(id);
    }


    // Directly call inherited methods (no need for 'base')

}
