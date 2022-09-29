using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi
{
    public class EmployeeRepository
    {

        private SqlConnection _sqlConnection;

        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection("data source= (localdb)\\mssqllocaldb; database= Training2022Db;");
        }

        public List<EmployeeViewModel> GetAllEmployee()
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "select * from Employee",
                    _sqlConnection);

                var sqlDataReader = sqlCommand.ExecuteReader();

                var listOfEmployee = new List<EmployeeViewModel>();

                while (sqlDataReader.Read())
                {
                    listOfEmployee.Add(new EmployeeViewModel()
                    {
                        Id = (int)sqlDataReader["Id"],
                        Name = (string)sqlDataReader["Name"],
                        Age = (int)sqlDataReader["Age"],
                        Salary = (int)sqlDataReader["Salary"],
                        CreationDate = (DateTime)sqlDataReader["CreationDate"]
                    });
                }
                return listOfEmployee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public EmployeeViewModel GetEmployeeById(int employeeId)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "select * from Employee where Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employeeId);

                var sqlDataReader = sqlCommand.ExecuteReader();

                var employee = new EmployeeViewModel();

                while (sqlDataReader.Read())
                {
                    employee.Id = (int)sqlDataReader["Id"];
                    employee.Name = (string)sqlDataReader["Name"];
                    employee.Age = (int)sqlDataReader["Age"];
                    employee.Salary = (int)sqlDataReader["Salary"];
                }

                return employee;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool InsertEmployee(EmployeeViewModel employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "INSERT INTO Employee(Name, Age, Salary, CreationDate) VALUES (@name, @age, @salary, @creationDate)", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("creationDate", DateTime.Now);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool UpdateEmployee(EmployeeViewModel employee, int id)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "Update Employee set Name = @name, ModificationDate = @modification where Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employee.Id);
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("modification", DateTime.Now);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "delete from Employee where Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employeeId);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}

