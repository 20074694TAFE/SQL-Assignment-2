using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Assignment_2
{
    class Employee_data
    {
        private int emp_id;
        private string first_name;
        private string last_name;
        private string birth_day;
        private char sex;
        private int salary;
        private int supervisor_id;
        private int branch_id;

        public int Emp_id { get => emp_id; set => emp_id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Birth_day { get => birth_day; set => birth_day = value; }
        public char Sex
        {
            get
            {
                return sex;
            }
            set
            {
                if(value == 'M' || value == 'F')
                {
                    sex = value;
                }
                else
                {
                    throw new Exception("Sex must be set to either 'M' or 'F'");
                }
            }
        }
        public int Salary { get => salary; set => salary = value; }
        public int Supervisor_id { get => supervisor_id; set => supervisor_id = value; }
        public int Branch_id { get => branch_id; set => branch_id = value; }

        public Employee_data(int emp_id, string first_name, string last_name, string birth_day, char sex, int salary, int supervisor_id, int branch_id)
        {
            Emp_id = emp_id;
            First_name = first_name;
            Last_name = last_name;
            Birth_day = birth_day;
            Sex = sex;
            Salary = salary;
            Supervisor_id = supervisor_id;
            Branch_id = branch_id;
        }

        
    }
}
