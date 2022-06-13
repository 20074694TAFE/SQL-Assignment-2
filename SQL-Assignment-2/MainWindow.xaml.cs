using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQL_Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> sexList = new List<string> {"", "Male", "Female"};
        Database database = new Database();
        public MainWindow()
        {
            InitializeComponent();
            SearchComboboxSex.ItemsSource = sexList;
            NewComboboxSex.ItemsSource = sexList;
            SearchComboboxSex.SelectedItem = sexList[0];
            NewComboboxSex.SelectedItem = sexList[0];
            ResetEmployeeData();
            ResetSalesData();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Employee_data> employees = database.FetchEmployeeData();
            try
            {
                if(SearchTextboxEmployeeId.Text != "")
                {
                    employees = database.SearchEmployeeEmpId(employees, 
                        Int32.Parse(SearchTextboxEmployeeId.Text));
                }
                if(SearchTextboxFirstName.Text != "")
                {
                    employees = database.SearchEmployeeFirstName(employees, SearchTextboxFirstName.Text);
                }
                if(SearchTextboxLastName.Text != "")
                {
                    employees= database.SearchEmployeeLastName(employees,SearchTextboxLastName.Text);
                }
                if(SearchTextboxBirthday.Text != "")
                {
                    employees = database.SearchBirthDay(employees,SearchTextboxBirthday.Text);
                }
                if(SearchComboboxSex.SelectedIndex != 0)
                {
                    switch (SearchComboboxSex.SelectedIndex)
                    {
                        case 1:
                            employees = database.SearchEmployeeSex(employees, 'M');
                            break; 
                        case 2:
                            employees = database.SearchEmployeeSex(employees, 'F');
                            break;
                        default:
                            break;
                    }
                }
                if(SearchTextboxSalaryMin.Text != "" || SearchTextboxSalaryMax.Text != "")
                {
                    employees = database.SearchEmployeeSalary(employees, 
                        SearchTextboxSalaryMin.Text == "" ? 0 : Int32.Parse(SearchTextboxSalaryMin.Text), 
                        SearchTextboxSalaryMax.Text == "" ? Int32.MaxValue : Int32.Parse(SearchTextboxSalaryMax.Text));
                }
                if(SearchTextboxSupervisorId.Text != "")
                {
                    employees = database.SearchEmployeeSupervisorId(employees, 
                        Int32.Parse(SearchTextboxSupervisorId.Text));
                }
                if(SearchTextboxBranchId.Text != "")
                {
                    employees = database.SearchEmployeeBranchId(employees, 
                        Int32.Parse(SearchTextboxBranchId.Text));
                }
                ListBoxEmployees.ItemsSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ClearSearchEmployee();
        }
        private void ClearSearchEmployee()
        {
            SearchComboboxSex.SelectedItem = sexList[0];
            SearchTextboxEmployeeId.Text = "";
            SearchTextboxFirstName.Text = "";
            SearchTextboxLastName.Text = "";
            SearchTextboxBirthday.Text = "";
            SearchTextboxSalaryMin.Text = "";
            SearchTextboxSalaryMax.Text = "";
            SearchTextboxSupervisorId.Text = "";
            SearchTextboxBranchId.Text = "";
            ResetEmployeeData();
            ResetSalesData();
        }

        private void ClearNewEmployee()
        {
            NewComboboxSex.SelectedItem = sexList[0];
            NewTextboxEmployeeId.Text = "";
            NewTextboxFirstName.Text = "";
            NewTextboxLastName.Text = "";
            NewTextboxBirthday.Text = "";
            NewTextboxSalary.Text = "";
            NewTextboxSupervisorId.Text = "";
            NewTextboxBranchId.Text = "";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearNewEmployee();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                char sex;
                switch (NewComboboxSex.SelectedIndex)
                {
                    case 1:
                        sex = 'M';
                        break;
                    case 2:
                        sex = 'F';
                        break;
                    default:
                        throw new Exception("Please select a sex from the dropdown menu.");
                }
                Employee_data employee = new Employee_data(
                    Int32.Parse(NewTextboxEmployeeId.Text),
                    NewTextboxFirstName.Text,
                    NewTextboxLastName.Text,
                    NewTextboxBirthday.Text,
                    sex,
                    Int32.Parse(NewTextboxSalary.Text),
                    Int32.Parse(NewTextboxSupervisorId.Text),
                    Int32.Parse(NewTextboxBranchId.Text));
                database.InsertEmployeeData(employee);
                MessageBox.Show("Successfully created an employee");
                ClearNewEmployee();
                ClearSearchEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ListBoxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBoxEmployees.SelectedItem != null && ListBoxEmployees.SelectedItem is Employee_data)
            {
                Employee_data employee_data = (Employee_data)ListBoxEmployees.SelectedItem;
                SearchTextboxEmployeeId.Text = employee_data.Emp_id.ToString();
                SearchTextboxFirstName.Text = employee_data.First_name;
                SearchTextboxLastName.Text = employee_data.Last_name;
                SearchTextboxBirthday.Text = employee_data.Birth_day;
                SearchTextboxSalaryMin.Text = employee_data.Salary.ToString();
                SearchTextboxSalaryMax.Text = employee_data.Salary.ToString();
                SearchTextboxSupervisorId.Text = employee_data.Supervisor_id.ToString();
                SearchTextboxBranchId.Text = employee_data.Branch_id.ToString();
                switch (employee_data.Sex)
                {
                    case 'M':
                        SearchComboboxSex.SelectedIndex = 1;
                        break;
                    case 'F':
                        SearchComboboxSex.SelectedIndex = 2;
                        break;
                    default:
                        SearchComboboxSex.SelectedIndex = 0;
                        break;
                }
                ListBoxSales.ItemsSource = database.ListEmployeeSales(employee_data);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ResetEmployeeData();
            ResetSalesData();
        }

        private void ResetEmployeeData()
        {
            ListBoxEmployees.ItemsSource = database.FetchEmployeeData();
        }

        private void ResetSalesData()
        {
            ListBoxSales.ItemsSource = database.FetchWorksData();
        }
    }
}
