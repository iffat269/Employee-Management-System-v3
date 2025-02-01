namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Position { get; set; }
        public DateTime JoiningDate { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentManagement? Department { get; set; }
        public bool? Status { get; set; }
        public bool Deleted { get; set; }

        public ICollection<PerformanceReview> PerformanceReviews { get; set; } = new List<PerformanceReview>();
    }
    public enum StatusEnum
    {
        Available = 0,
        Unavailable = 1
    }
}
