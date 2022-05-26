using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<Employee_data> list = new List<Employee_data>();
            string query = "SELECT * FROM employee_table";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader reader;
            OpenConnection();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Employee_data data = new Employee_data(
                    Convert.ToInt32(reader["emp_id"]), 
                    Convert.ToString(reader["first_name"]),
                    Convert.ToString(reader["last_name"]),
                    Convert.ToString(reader["birth_day"]),
                    Convert.ToChar(reader["sex"]),
                    Convert.ToInt32(reader["salary"]),
                    Convert.ToInt32(reader["supervisor_id"]),
                    Convert.ToInt32(reader["branch_id"]));
                list.Add(data);
            }
            return list.AsEnumerable<Employee_data>();
        }

        public IEnumerable<Works_data> FetchWorksData()
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
                    Convert.ToInt32(reader["emp_id"]),
                    Convert.ToString(reader["client_name"]),
                    Convert.ToInt32(reader["total_sales"]));
                list.Add(data);
            }
            return list.AsEnumerable<Works_data>();
        }

        //TODO
        public void InsertEmployeeData(Employee_data data)
        {
            string query = $"INSERT INTO employee_table VALUES ( {data.emp_id}, {data.first_name}, {data.last_name}, {data.birth_day}, {data.sex}, {data.salary}, {data.supervisor_id}, {data.salary});";
        }

        //TODO
        public void InsertWorksData(Works_data data)
        {
            string query = $"INSERT INTO works_table VALUES ( {data.emp_id}, {data.client_name}, {data.total_sales});";

        }

        public IEnumerable<Employee_data> SearchEmployeeEmpId(IEnumerable<Employee_data> table, int num)
        {
            return table.Where(s => s.emp_id == num);
        }

        public IEnumerable<Employee_data> SearchEmployeeFirstName(IEnumerable<Employee_data> table, string str)
        {
            return table.Where(s => s.first_name == str);
        }

        public IEnumerable<Employee_data> SearchEmployeeLastName(IEnumerable<Employee_data> table, string str)
        {
            return table.Where(s => s.last_name == str);
        }

        //TODO
        public IEnumerable<Employee_data> SearchBirthDay(IEnumerable<Employee_data> employee_table, string str)
        {
            return employee_table.Where(s => s.birth_day == str);
        }

        public IEnumerable<Employee_data> SearchEmployeeSex(IEnumerable<Employee_data> table, char c)
        {
            return table.Where(s => s.sex == c);
        }

        public IEnumerable<Employee_data> SearchEmployeeSalary(IEnumerable<Employee_data> table, int min = 0, int max = int.MaxValue)
        {
            return table.Where(s => s.salary >= min && s.salary <= max);
        }

        public IEnumerable<Employee_data> SearchEmployeeSupervisorId(IEnumerable<Employee_data> table, int num)
        {
            return table.Where(s => s.supervisor_id == num);
        }

        public IEnumerable<Employee_data> SearchEmployeeBranchId(IEnumerable<Employee_data> table, int num)
        {
            return table.Where(s => s.branch_id == num);
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

    }
}
