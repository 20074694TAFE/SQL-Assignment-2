using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Assignment_2
{
    class Works_data
    {
        public int emp_id;
        public string client_name;
        public int total_sales;

        public Works_data(int emp_id, string client_name, int total_sales)
        {
            this.emp_id = emp_id;
            this.client_name = client_name;
            this.total_sales = total_sales;
        }
    }
}
