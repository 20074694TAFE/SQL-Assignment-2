using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace SQL_Assignment_2
{
    class Database
    {

        private string dbName;
        private string dbUser;
        private string dbPassword;
        private int dbPort;
        private string dbServer;

        //private string dbConnectionString = "";
        internal MySqlConnection conn;

        //IEnumerable
        IEnumerable<Employee_data> employee_table;

        IEnumerable<Works_data> works_table;


        public Database()
        {
            dbName = "ME_company_db";
            dbUser = "ME_company_db";
            dbPassword = "Password1";
            dbPort = 3306;
            dbServer = "localhost";

            string dbConnectionString = $"server={dbServer}; user={dbUser}; database={dbName}; port={dbPort}; password={dbPassword}";
            conn = new MySqlConnection(dbConnectionString);
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public IEnumerable<Employee_data> FetchEmployeeData()
        {
            try
            {
                List<Employee_data> list = new List<Employee_data>();
                string query = "SELECT * FROM employee_table";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                OpenConnection();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee_data data = new Employee_data(
                        reader[0] == DBNull.Value ? -1 : Convert.ToInt32(reader[0]),
                        reader[1] == DBNull.Value ? "Null" : Convert.ToString(reader[1]),
                        reader[2] == DBNull.Value ? "Null" : Convert.ToString(reader[2]),
                        reader[3] == DBNull.Value ? "Null" : Convert.ToString(reader[3]),
                        reader[4] == DBNull.Value ? 'N' : Convert.ToChar(reader[4]),
                        reader[5] == DBNull.Value ? -1 : Convert.ToInt32(reader[5]),
                        reader[6] == DBNull.Value ? -1 : Convert.ToInt32(reader[6]),
                        reader[7] == DBNull.Value ? -1 : Convert.ToInt32(reader[7]));
                    list.Add(data);
                }
                CloseConnection();
                return list.AsEnumerable<Employee_data>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public IEnumerable<Works_data> FetchWorksData()
        {
            try
            {
                List<Works_data> list = new List<Works_data>();
                string query = "SELECT * FROM works_table";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader;
                OpenConnection();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Works_data data = new Works_data(
                        reader[0] == DBNull.Value ? -1 : Convert.ToInt32(reader[0]),
                        reader[1] == DBNull.Value ? "Null" : Convert.ToString(reader[1]),
                        reader[2] == DBNull.Value ? -1 : Convert.ToInt32(reader[2]));
                    list.Add(data);
                }
                CloseConnection();
                return list.AsEnumerable<Works_data>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }

        //TODO
        public void InsertEmployeeData(Employee_data data)
        {
            string query = $"INSERT INTO employee_table VALUES ( {data.Emp_id}, {data.First_name}, {data.Last_name}, {data.Birth_day}, {data.Sex}, {data.Salary}, {data.Supervisor_id}, {data.Salary});";
            FetchEmployeeData();
        }

        //TODO
        public void InsertWorksData(Works_data data)
        {
            string query = $"INSERT INTO works_table VALUES ( {data.emp_id}, {data.client_name}, {data.total_sales});";
            FetchWorksData();
        }

        public IEnumerable<Employee_data> SearchEmployeeEmpId(IEnumerable<Employee_data> table, int num)
        {
            return table.Where(s => s.Emp_id == num);
        }

        public IEnumerable<Employee_data> SearchEmployeeFirstName(IEnumerable<Employee_data> table, string str)
        {
            return table.Where(s => s.First_name.ToLower() == str.ToLower());
        }

        public IEnumerable<Employee_data> SearchEmployeeLastName(IEnumerable<Employee_data> table, string str)
        {
            return table.Where(s => s.Last_name.ToLower() == str.ToLower());
        }

        
        public IEnumerable<Employee_data> SearchBirthDay(IEnumerable<Employee_data> employee_table, string str)
        {
            return employee_table.Where(s => s.Birth_day == str);
        }

        public IEnumerable<Employee_data> SearchEmployeeSex(IEnumerable<Employee_data> table, char c)
        {
            return table.Where(s => s.Sex == c);
        }

        public IEnumerable<Employee_data> SearchEmployeeSalary(IEnumerable<Employee_data> table, int min = 0, int max = int.MaxValue)
        {
            return table.Where(s => s.Salary >= min && s.Salary <= max);
        }

        public IEnumerable<Employee_data> SearchEmployeeSupervisorId(IEnumerable<Employee_data> table, int num)
        {
            return table.Where(s => s.Supervisor_id == num);
        }

        public IEnumerable<Employee_data> SearchEmployeeBranchId(IEnumerable<Employee_data> table, int num)
        {
            return table.Where(s => s.Branch_id == num);
        }

        public IEnumerable<Works_data> SearchWorksEmpId(IEnumerable<Works_data> table, int num)
        {
            return table.Where(s => s.emp_id == num);
        }

        public IEnumerable<Works_data> SearchWorksClientName(IEnumerable<Works_data> table, string str)
        {
            return table.Where(s => s.client_name == str);
        }

        public IEnumerable<Works_data> SearchWorksTotalSales(IEnumerable<Works_data> table, int min = 0, int max = int.MaxValue)
        {
            return table.Where(s => s.total_sales >= min && s.total_sales <= max);
        }

        public IEnumerable<Works_data> ListEmployeeSales(Employee_data employee)
        {
            List<Works_data> works = FetchWorksData().ToList();
            var list = works.Where(data => data.emp_id == employee.Emp_id);
            return list;
        }

    }
}
