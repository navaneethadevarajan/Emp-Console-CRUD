using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IDepartmentRepository
    {
        void AddDepartment(Department department);
        void DisplayAllDepartments();
        void UpdateDepartmentDetails(int departmentId, Department updatedDepartment);
        void RemoveDepartment(int departmentId);


    }
}