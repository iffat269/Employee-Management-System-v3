
# Employee Management System

Here’s the **README** template based on your requirements. This **README** will contain:

1. **Setup Instructions**
2. **Project Overview and Features**
3. **Additional Notes and Optimizations**
4. **EDI List Features** (Employee List, Department Management, Performance Reviews, and Employee Deletion)
5. **Performance Optimization** using **Stored Procedures (SP)**

---

# Employee Management System

This is an **Employee Management System** built using **ASP.NET Core Razor Pages**, **Entity Framework Core**, and **SQL Server** for data persistence. The application allows the management of employee data, including **Employee CRUD operations**, **Department Management**, and **Performance Reviews**.

The architecture follows **Clean Architecture** principles and uses **Stored Procedures (SP)** for performance optimization, especially for large datasets.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Setup Instructions](#setup-instructions)
- [Project Overview and Features](#project-overview-and-features)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [Performance Optimization](#performance-optimization)

## Technologies Used

- **ASP.NET Core**: Web framework used to build the web application.
- **Entity Framework Core**: ORM used to interact with the SQL Server database.
- **SQL Server**: Used as the database for storing employee and department data.
- **Razor Pages**: Used for frontend view rendering and handling user input.
- **Bootstrap**: Used for styling and layout.
- **Stored Procedures (SP)**: Optimized for handling large datasets and performance-heavy queries.

## Setup Instructions

Follow these steps to set up and run the **Employee Management System** locally:

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/EmployeeManagementSystem.git
cd EmployeeManagementSystem
```

### 2. Install Dependencies

Ensure you have **.NET 6** or later installed on your machine. You can download it from the [official Microsoft site](https://dotnet.microsoft.com/download).

Run the following command to restore the NuGet packages:

```bash
dotnet restore
```

### 3. Set up the Database

- Create a database in SQL Server (e.g., `Employee_Management_System`).
- Configure the **`appsettings.json`** file with your database connection string. Example:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-6H5N4SN\\SQLEXPRESS;Database=Employee_Management_System;Trusted_Connection=True;"
}
```

### 4. Apply Migrations and run Store proecedure

Run the following command to apply the migrations and create the database schema:

```bash
dotnet ef database update
```
The MySQL stored procedures (SP) are included in the domain file and can be executed directly within Visual Studio using its built-in functionality

### 5. Run the Application

To run the application, use the following command:

```bash
dotnet run
```

After the application is running, you can access it at `https://localhost:5001` (or the port specified in your terminal).

## Project Overview and Features

This project includes the following key features:

### 1. **Employee Management**
   - **Add** new employees.
   - **Edit** employee details.
   - **Delete** employees.
   - **View** a list of all employees.
   - Employees are associated with **Departments** and **Performance Reviews**.

### 2. **Department Management**
   - Manage **Departments** in the organization.
   - View **Department** details.
   - Assign **employees** to departments.

### 3. **Performance Reviews**
   - Assign and view **Performance Reviews** for each employee.
   - **Rating system** for employees to track their performance.
   - View performance across **departments**.

### 4. **Employee Deletion**
   - **Delete** an employee.
   - Delete operations are optimized using **Stored Procedures**.

### 5. **Employee List**
   - View the list of employees with associated **Department** and **Performance Review**.

## Usage

Once the application is running, you can:

- **Add a new employee**: Go to the "Add Employee" page, fill in the details, and submit the form.
- **View all employees**: The "Employee List" page will show all employees along with their details and the department they belong to.
- **Edit an employee**: You can edit the details of any employee by clicking the "Edit" button next to their name.
- **Delete an employee**: You can delete an employee by clicking the "Delete" button next to their name.
- **Department Management**: You can manage the departments in the organization and assign employees to departments.

## Project Structure

Here’s an overview of the key folders and files:

```
/EmployeeManagementSystem
|-- /Pages
|   |-- /EmployeeCRUD
|       |-- EmployeeAdd.cshtml          # Add a new employee
|       |-- EmployeeList.cshtml         # View list of employees
|       |-- EmployeeDelete.cshtml       # Delete an employee
|   |-- /DepartmentManagement
|       |-- DepartmentAdd.cshtml        # Add a new department
|       |-- DepartmentList.cshtml       # View list of departments
|   |-- /PerformanceReviews
|       |-- PerformanceReviewAdd.cshtml # Add performance review
|       |-- PerformanceReviewList.cshtml # List performance reviews
|-- /Models
|   |-- Employee.cs                      # Employee model
|   |-- Department.cs                    # Department model
|   |-- PerformanceReview.cs             # Performance review model
|-- /Data
|   |-- EMSDbContext.cs                 # Entity Framework context
|-- /Managers
|   |-- EmployeeManager.cs               # Manager for employee CRUD operations
|   |-- DepartmentManager.cs             # Manager for department CRUD operations
|   |-- PerformanceReviewManager.cs      # Manager for performance review CRUD operations
|-- /wwwroot
|   |-- /css
|   |-- /js
|-- appsettings.json                     # Database connection settings
|-- Program.cs                           # Application startup and configuration
|-- README.md                           # Project documentation
```

### **Key Folders/Files**:
- **Pages**: Contains the Razor Pages for rendering views.
- **Models**: Contains the data models for **Employee**, **Department**, and **Performance Review**.
- **Managers**: Contains the logic for performing CRUD operations on employees, departments, and performance reviews.
- **Data**: Contains the **DbContext** used by Entity Framework Core.
- **wwwroot**: Contains static assets like CSS and JS files.

## Contributing

We welcome contributions! Here’s how you can contribute to this project:

1. **Fork the repository**: Click on the "Fork" button at the top right of this page to create a copy of the repository.
2. **Create a new branch**: Create a new branch for your changes.
3. **Make your changes**: Implement your changes and commit them with a clear message.
4. **Push your changes**: Push your changes to your forked repository.
5. **Create a pull request**: Open a pull request to merge your changes into the main repository.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Performance Optimization

To handle **large datasets** efficiently, we’ve implemented **Stored Procedures (SP)** to optimize performance in the following areas:

- **Employee Deletion**: Deleting large numbers of employees is handled by a stored procedure to avoid performance degradation.
- **Department List**: Loading department-related data is optimized with a stored procedure that fetches employee counts and department details efficiently.
- **Performance Reviews**: Fetching performance data for large organizations is optimized by running SPs to retrieve data in a single optimized query.

These stored procedures ensure faster performance, even with large data volumes.

---

Let me know if you need further changes or more details in this README! 😊
