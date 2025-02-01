namespace Domain
{
    public class DepartmentManagement
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int? ManagerID { get; set; }
        public Employee? Manager { get; set; }
        public decimal Budget { get; set; }
        public ICollection<Employee> Employees { get; set; }= new List<Employee>();
    }
}
