using Domain;
using Domain.DTO;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<DepartmentManagement> Departments { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //One - to - Many: Department->Employees
            modelBuilder.Entity<Employee>()
           .HasOne(e => e.Department)  // An Employee belongs to one Department
           .WithMany(d => d.Employees) // A Department has many Employees
           .HasForeignKey(e => e.DepartmentId);

            // One-to-One: DepartmentManagement -> Manager (Employee)
            modelBuilder.Entity<DepartmentManagement>()
           .HasOne(d => d.Manager) // A Department has one Manager
           .WithMany() // A Manager can manage many Departments
           .HasForeignKey(d => d.ManagerID) // Foreign key in Department
           .OnDelete(DeleteBehavior.Restrict);

            //// One-to-Many: Employee -> Performance Reviews
            //modelBuilder.Entity<PerformanceReview>()
            //.HasOne(pr => pr.Employee) // A Performance Review belongs to one Employee
            //.WithMany(e => e.PerformanceReviews) // An Employee can have many Performance Reviews
            //.HasForeignKey(pr => pr.EmployeeId) // Foreign key in PerformanceReview
            //.OnDelete(DeleteBehavior.NoAction);//Cahnge to Casecade Later
            modelBuilder.Entity<PerformanceReview>()
            .HasOne(pr => pr.Employee) // A Performance Review belongs to one Employee
            .WithMany(e => e.PerformanceReviews) // An Employee can have many Performance Reviews
            .HasForeignKey(pr => pr.EmployeeId) // Foreign key in PerformanceReview
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DepartmentNameDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<EmployeeInformationDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<DepartmentManagementDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<PerformanceReviewDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<AveragePerformanceScoreDTO>().HasNoKey().ToView(null);
        }
    }
}
