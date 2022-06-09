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
        public MainWindow()
        {
            InitializeComponent();
            SearchComboboxSex.ItemsSource = sexList;
            NewComboboxSex.ItemsSource = sexList;
            SearchComboboxSex.SelectedItem = sexList[0];
            NewComboboxSex.SelectedItem = sexList[0];
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Employee_data> employees = null;
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
            SearchTextboxSalary.Text = "";
            SearchTextboxSupervisorId.Text = "";
            SearchTextboxBranchId.Text = "";
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

        }
    }
}
