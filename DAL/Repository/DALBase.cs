using ConsoleTables;
using EmployeeManagement.Repository;
using Npgsql;

public class DALBase:IDALBase
{

     private string connectionString = "Host=localhost;Username=postgres;Password=root;Database=EMSA";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
    public int AddEmp(Employee employee)
    {
        using (var con = GetConnection())
        {
            NpgsqlCommand cm = new NpgsqlCommand("CALL AddEmployee(@EmployeeName::VARCHAR, @EmployeeAge::INTEGER, @EmployeeLocation::VARCHAR, @EmployeeDateOfBirth::DATE, @DepartmentId::INTEGER)", con);
            cm.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@EmployeeAge", employee.EmployeeAge);
            cm.Parameters.AddWithValue("@EmployeeLocation", employee.EmployeeLocation ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@EmployeeDateOfBirth", employee.EmployeeDateOfBirth.Date);
            cm.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            con.Open();
            int rowsAffected=cm.ExecuteNonQuery();
            return rowsAffected;                
        }
    }
    public int UpdateEmp(int employeeId, Employee updatedEmployee)
    {
        using (var con = GetConnection())
        {
            NpgsqlCommand cm = new NpgsqlCommand("CALL UpdateEmployee(@EmployeeId::INTEGER, @EmployeeName::VARCHAR, @EmployeeAge::INTEGER, @EmployeeLocation::VARCHAR, @EmployeeDateOfBirth::DATE, @DepartmentId::INTEGER)", con);
            cm.Parameters.AddWithValue("@EmployeeId", employeeId);
            cm.Parameters.AddWithValue("@EmployeeName", updatedEmployee.EmployeeName);
            cm.Parameters.AddWithValue("@EmployeeAge", updatedEmployee.EmployeeAge);
            cm.Parameters.AddWithValue("@EmployeeLocation", updatedEmployee.EmployeeLocation);
            cm.Parameters.AddWithValue("@EmployeeDateOfBirth", updatedEmployee.EmployeeDateOfBirth.Date);
            cm.Parameters.AddWithValue("@DepartmentId", updatedEmployee.DepartmentId);
            con.Open();
            int rowsAffected=cm.ExecuteNonQuery();
            return rowsAffected;
        }
    }
    public int RemoveEmp(int employeeId)
    {
        using (var con = GetConnection())
        {
            NpgsqlCommand cm = new NpgsqlCommand("CALL DeleteEmployee(@EmployeeId)", con);
            cm.Parameters.AddWithValue("@EmployeeId", employeeId);
            con.Open();
            int rowsAffected=cm.ExecuteNonQuery();
            return rowsAffected;
        }
    }
    public void DisplayAllEmp()
    {
        var table = new ConsoleTable("EmployeeId", "EmployeeName", "EmployeeAge", "EmployeeLocation", "EmployeeDateOfBirth", "DepartmentName");
        
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();  
            var sqlQuery = @"
                SELECT e.EmployeeId, 
                    e.EmployeeName, 
                    e.EmployeeAge, 
                    e.EmployeeLocation, 
                    e.EmployeeDateOfBirth, 
                    d.DepartmentName
                FROM Employee e
                JOIN Department d ON e.DepartmentId = d.DepartmentId
                ORDER BY e.EmployeeId ASC";   
            using (var command = new NpgsqlCommand(sqlQuery, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        table.AddRow(reader["EmployeeId"], 
                                    reader["EmployeeName"], 
                                    reader["EmployeeAge"], 
                                    reader["EmployeeLocation"], 
                                    reader["EmployeeDateOfBirth"], 
                                    reader["DepartmentName"]);
                    }
                }
            }
        }

        table.Write(Format.Alternative);
    }
    public int AddDepartment(Department department)
    {
        using (var con = GetConnection())
        {
            NpgsqlCommand cm = new NpgsqlCommand("CALL AddDepartment(@DepartmentName)", con);
            cm.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            con.Open();
            int rowsAffected=cm.ExecuteNonQuery();
            return rowsAffected;
        }
    }
    public void DisplayAllDepartments()
    {
        var table = new ConsoleTable("DepartmentID", "DepartmentName");

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            
            string query = "SELECT * FROM GetAllDepartments() ORDER BY DepartmentID ASC";  

            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        table.AddRow(reader["DepartmentID"], reader["DepartmentName"]);
                    }
                }
            }
        }

        table.Write(Format.Alternative);
    }
    public int UpdateDepartment(int departmentId, Department updatedDepartment)
    {
        using (var con = GetConnection())
        {
            NpgsqlCommand cm = new NpgsqlCommand("CALL UpdateDepartment(@DepartmentID, @DepartmentName)",con);
            cm.Parameters.AddWithValue("@DepartmentID", departmentId);
            cm.Parameters.AddWithValue("@DepartmentName", updatedDepartment.DepartmentName);
            con.Open();
            int rowsAffected=cm.ExecuteNonQuery();
            return rowsAffected;
        }
    }
    public int RemoveDepartment(int departmentId)
    {
        using (var con = GetConnection())
        {
            NpgsqlCommand cm = new NpgsqlCommand("CALL DeleteDepartment(@DepartmentID)",con);
            cm.Parameters.AddWithValue("@DepartmentID", departmentId);
            con.Open();
            int rowsAffected=cm.ExecuteNonQuery();
            return rowsAffected;
        }
    }
    public bool CheckIfDepartmentHasEmployees(int departmentId)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("SELECT COUNT(*) FROM Employee WHERE DepartmentId = @DepartmentId", connection))
            {
                command.Parameters.AddWithValue("@DepartmentId", departmentId);
                int employeeCount = Convert.ToInt32(command.ExecuteScalar());
                return employeeCount > 0;  
            }
        }
    }

}