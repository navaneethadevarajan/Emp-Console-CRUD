using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IDALBase
    {
        void DisplayAllEmp();
        int AddEmp(Employee employee);
        int UpdateEmp(int employeeId, Employee updatedEmployee);
        int RemoveEmp(int employeeId);
        int AddDepartment(Department department);
        void DisplayAllDepartments();
        int UpdateDepartment(int departmentId, Department updatedDepartment);
        int RemoveDepartment(int departmentId);
        bool CheckIfDepartmentHasEmployees(int departmentId);


    }
}