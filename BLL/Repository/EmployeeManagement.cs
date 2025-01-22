using System;
using Npgsql;  
using System.Collections.Generic;
using EmployeeManagement.Repository;

public class EmployeeDetails:IEmployeeRepository
{
    private IDALBase _iDALBase;
    public EmployeeDetails(IDALBase iDALBase)
    {
        _iDALBase=iDALBase;
    }
    public static int Welcome()
    {
        System.Console.WriteLine("\n------WELCOME TO THE EMPLOYEE MANAGEMENT SYSTEM------");
        System.Console.WriteLine("***CHOOSE ONE OF THE GIVEN ACTIONS***");
        System.Console.WriteLine("1.CREATE");
        System.Console.WriteLine("2.DISPLAY");
        System.Console.WriteLine("3.UPDATE");
        System.Console.WriteLine("4.DELETE");
        System.Console.WriteLine("5.EXIT");
        System.Console.Write("ENTER THE ACTION NEED TO BE DONE : ");
        return int.Parse(Console.ReadLine());
    }
    public void AddEmployee(Employee employee)
    {
    bool addEmployee = true;
    while (addEmployee)
    {
        System.Console.WriteLine("  ");
        System.Console.WriteLine("***TO ADD AN EMPLOYEE PLEASE FILL THE DETAILS BELOW***");
        System.Console.Write("ENTER THE NAME OF EMPLOYEE : ");
        employee.EmployeeName = Console.ReadLine();  
        try
        {
            System.Console.Write("ENTER THE AGE OF EMPLOYEE (AGE > 20 AND AGE < 60) : ");
            employee.EmployeeAge = int.Parse(Console.ReadLine());
            System.Console.Write("ENTER THE LOCATION OF EMPLOYEE : ");
            employee.EmployeeLocation = Console.ReadLine();
            System.Console.Write("ENTER THE DATE OF BIRTH OF EMPLOYEE (YYYY-MM-DD) : ");
            employee.EmployeeDateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Choose Department from the following:");
            _iDALBase.DisplayAllDepartments();
            Console.Write("ENTER THE DEPARTMENT ID FOR THE EMPLOYEE : ");
            employee.DepartmentId = int.Parse(Console.ReadLine()); 
            _iDALBase.AddEmp(employee);
            Console.Write("\n DO YOU WANT TO ADD ANOTHER EMPLOYEE? (YES/NO) : ");
            var addAnotherEmployee = Console.ReadLine()?.ToLower();
            switch (addAnotherEmployee)
            {
                case "yes":
                    addEmployee = true;
                    break;
                case "no":
                    addEmployee = false;
                    break;
                default:
                    Console.WriteLine("INVALID INPUT.PLEASE ENTER 'YES' or 'NO'.");
                    break;
            }
        }
        catch (FormatException)
        {
            System.Console.WriteLine("INVALID INPUT PLEASE ENSURE THE DATA YOU HAVE ENTERED");
        }
    }
    }
    public void DisplayAll()
    {
        System.Console.WriteLine("***EMPLOYEE TABLE LIST***");
        System.Console.WriteLine("--------------------------");
        _iDALBase.DisplayAllEmp();
    }
   public void UpdateEmployeeDetails(int employeeId, Employee updatedEmployee)
    {
        Console.WriteLine("***TO UPDATE THE PARTICULAR EMPLOYEE DETAIL PLEASE FILL THE DETAILS GIVEN BELOW***");
        Console.WriteLine("------YOU CAN UPDATE THE DATA NOW------");
        Console.Write("ENTER THE UPDATED NAME : ");
        updatedEmployee.EmployeeName = Console.ReadLine();
        Console.Write("ENTER THE UPDATED AGE : ");
        updatedEmployee.EmployeeAge = int.Parse(Console.ReadLine());
        Console.Write("ENTER THE UPDATED LOCATION : ");
        updatedEmployee.EmployeeLocation = Console.ReadLine();
        Console.Write("ENTER THE UPDATED DATE OF BIRTH (YYYY-MM-DD) : ");
        updatedEmployee.EmployeeDateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Choose Department from the following:");
        _iDALBase.DisplayAllDepartments(); 
        Console.Write("ENTER THE UPDATED DEPARTMENT ID FOR THE EMPLOYEE : ");
        updatedEmployee.DepartmentId = int.Parse(Console.ReadLine());
        _iDALBase.UpdateEmp(employeeId,updatedEmployee); 
    }
    public void RemoveEmployee(int employeeId)
    {
       _iDALBase.RemoveEmp(employeeId); 
    }

    public void DisplayEmployeeDetails(Employee employee)
    {
        System.Console.WriteLine("-----EMPLOYEE DETAILS-----");
        System.Console.WriteLine($"NAME: {employee.EmployeeName}");
        System.Console.WriteLine($"AGE: {employee.EmployeeAge}");
        System.Console.WriteLine($"ID: {employee.EmployeeId}");
        System.Console.WriteLine($"LOCATION: {employee.EmployeeLocation}");
        System.Console.WriteLine($"DATE OF BIRTH: {employee.EmployeeDateOfBirth.ToShortDateString()}");
        System.Console.WriteLine($"DEPARTMENT:{employee.DepartmentName}");
    }

    
}
