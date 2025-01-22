using System;
using Npgsql;
using System.Collections.Generic;
using EmployeeManagement.Repository;
public class DepartmentManagement:IDepartmentRepository
{
    private IDALBase _iDALBase;
    public DepartmentManagement(IDALBase iDALBase)
    {
        _iDALBase=iDALBase;
    }
   public void AddDepartment(Department department)
    {
        bool addDepartment = true;  
        do
        {
            Console.WriteLine("***TO ADD A DEPARTMENT PLEASE FILL THE DETAILS BELOW***");
            Console.Write("ENTER THE NAME OF DEPARTMENT: ");
            department.DepartmentName = Console.ReadLine();
            _iDALBase.AddDepartment(department);
            Console.Write("\nDO YOU WANT TO ADD ANOTHER DEPARTMENT? (YES/NO): ");
            var addAnotherDepartment = Console.ReadLine()?.ToLower();
            switch (addAnotherDepartment)
            {
                case "yes":
                    addDepartment = true; 
                    break;
                case "no":
                    addDepartment = false;  
                    Console.WriteLine("Exiting the department adding process.\n");
                    break;
                default:
                    Console.WriteLine("INVALID INPUT. PLEASE ENTER 'YES' or 'NO'.\n");
                    break;
            }

        } while (addDepartment);  
    }
    public void DisplayAllDepartments()
    {
        Console.WriteLine("***DEPARTMENT TABLE LIST***");
        Console.WriteLine("---------------------------\n");
        _iDALBase.DisplayAllDepartments();
    }
    public void UpdateDepartmentDetails(int departmentId, Department updatedDepartment)
    {
        Console.WriteLine("***TO UPDATE THE PARTICULAR DEPARTMENT DETAIL PLEASE FILL THE DETAILS BELOW***");
       // Console.WriteLine("-----------------------------------------------------------------------------------\n");
        Console.WriteLine("------YOU CAN UPDATE THE DEPARTMENT DATA NOW------\n");
        Console.Write("ENTER THE UPDATED DEPARTMENT NAME : ");
        updatedDepartment.DepartmentName = Console.ReadLine();
        _iDALBase.UpdateDepartment(departmentId,updatedDepartment);
    }
    public void RemoveDepartment(int departmentId)
    {
        bool hasEmployees=_iDALBase.CheckIfDepartmentHasEmployees(departmentId);
        if (hasEmployees)
        {
            Console.WriteLine($"DEPARTMENT WITH ID {departmentId} CANNOT BE REMOVED BECAUSE IT HAS EMPLOYEES ASSOCIATED WITH IT.");
            Console.WriteLine("PLEASE REASSIGN EMPLOYEES TO ANOTHER DEPARTMENT BEFORE REMOVING THIS DEPARTMENT.");
        }
        else
        {
            _iDALBase.RemoveDepartment(departmentId);
        }
    }
    public void DisplayDepartmentDetails(Department department)
    {
        Console.WriteLine("-----DEPARTMENT DETAILS-----");
        Console.WriteLine($"NAME: {department.DepartmentName}");
        Console.WriteLine($"ID: {department.DepartmentID}");
    }
}
