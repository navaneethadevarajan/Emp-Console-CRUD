using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(Employee employee);
        void DisplayAll();  
        void UpdateEmployeeDetails(int employeeId, Employee updatedEmployee);
        void RemoveEmployee(int employeeId);
    }
}