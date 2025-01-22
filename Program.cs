using System;
using EmployeeManagement.Repository;

public class Program
{
    static void Main(string[] args)
    {
        DALBase iDALBase=new DALBase();
        IEmployeeRepository employeeRepository = new EmployeeDetails(iDALBase);
        IDepartmentRepository departmentRepository = new DepartmentManagement(iDALBase);
        EmployeeDetails employeeDetails = new EmployeeDetails(iDALBase);
        DepartmentManagement departmentManagement = new DepartmentManagement(iDALBase);
        bool keepRunning = true;
        while (keepRunning)
        {
            int action = EmployeeDetails.Welcome();
            switch (action)
            {
                case 1:
                    Console.WriteLine("Choose action: 1. Add Employee, 2. Add Department");
                    int addAction = int.Parse(Console.ReadLine());
                    if (addAction == 1)
                    {
                        Employee employee = new Employee();
                        employeeDetails.AddEmployee(employee);
                    }
                    else if (addAction == 2)
                    {
                        Department department = new Department();
                        departmentManagement.AddDepartment(department);
                    }
                    break;
                case 2:
                    Console.WriteLine("Choose action: 1. Display Employees, 2. Display Departments");
                    int displayAction = int.Parse(Console.ReadLine());
                    if (displayAction == 1)
                    {
                        employeeDetails.DisplayAll();
                    }
                    else if (displayAction == 2)
                    {
                        departmentManagement.DisplayAllDepartments();
                    }
                    break;
                case 3:
                    Console.WriteLine("Choose action: 1. Update Employee, 2. Update Department");
                    int updateAction = int.Parse(Console.ReadLine());

                    if (updateAction == 1)
                    {
                        Console.Write("Enter Employee ID to update: ");
                        int employeeId = int.Parse(Console.ReadLine());
                        Employee updatedEmployee = new Employee();
                        employeeDetails.UpdateEmployeeDetails(employeeId, updatedEmployee);
                    }
                    else if (updateAction == 2)
                    {
                        Console.Write("Enter Department ID to update: ");
                        int departmentId = int.Parse(Console.ReadLine());
                        Department updatedDepartment = new Department();
                        departmentManagement.UpdateDepartmentDetails(departmentId, updatedDepartment);
                    }
                    break;
                case 4:
                    Console.WriteLine("Choose action: 1. Remove Employee, 2. Remove Department");
                    int deleteAction = int.Parse(Console.ReadLine());

                    if (deleteAction == 1)
                    {
                        Console.Write("Enter Employee ID to remove: ");
                        int employeeIdToRemove = int.Parse(Console.ReadLine());
                        employeeDetails.RemoveEmployee(employeeIdToRemove);
                    }
                    else if (deleteAction == 2)
                    {
                        Console.Write("Enter Department ID to remove: ");
                        int departmentIdToRemove = int.Parse(Console.ReadLine());
                        departmentManagement.RemoveDepartment(departmentIdToRemove);
                    }
                    break;

                case 5:
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("INVALID ACTION. PLEASE CHOOSE AGAIN.");
                    break;
            }
        }
    }
}
