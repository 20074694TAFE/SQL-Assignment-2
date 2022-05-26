using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Assignment_2
{
    class Employee_data
    {
        public int emp_id;
        public string first_name;
        public string last_name;
        public string birth_day;
        public char sex;
        public int salary;
        public int supervisor_id;
        public int branch_id;

        public Employee_data(int emp_id, string first_name, string last_name, string birth_day, char sex, int salary, int supervisor_id, int branch_id)
        {
            this.emp_id = emp_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.birth_day = birth_day;
            this.sex = sex;
            this.salary = salary;
            this.supervisor_id = supervisor_id;
            this.branch_id = branch_id;
        }
    }
}
