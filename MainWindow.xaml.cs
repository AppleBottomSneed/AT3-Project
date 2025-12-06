using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
using MySql.Data.MySqlClient;

namespace AT3_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Define Connection Details
        private string dbName = "jn_ictprg431_fix";
        private string dbUser = "root";
        private string dbPassword = "";
        private int dbPort = 3306;
        private string dbServer = "localhost";
        // Connection String and MySQL Connection
        private string dbConnectionString = "";
        private MySqlConnection conn;


        public MainWindow()
        {
            InitializeComponent();
            dbConnectionString = $"server={dbServer}; user={dbUser}; database={dbName}; port={dbPort}; password={dbPassword}";
            conn = new MySqlConnection(dbConnectionString);
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM employees;";

            try
            {
                DataTable dataTable = new DataTable();

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                dataTable.Load(rdr);

                EmployeeDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM employees " + "WHERE given_name LIKE @Search OR family_name LIKE @Search;";
            try
            {
                DataTable dataTable = new DataTable();
               
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                //prepared statement
                cmd.Parameters.AddWithValue("@Search", "%" + SearchTextBox.Text + "%");
                MySqlDataReader rdr = cmd.ExecuteReader();
                
                dataTable.Load(rdr);

                EmployeeDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        private void BranchDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedBranch = ((ComboBoxItem)BranchDropDown.SelectedItem).Content.ToString();
            string sqlQuery;
            if (selectedBranch == "All Branches")
            {
                sqlQuery = "SELECT * FROM employees;";
            }
            else
            {
                sqlQuery = "SELECT * FROM employees WHERE branch_id = @BranchId;";
            }

            try
            {
                DataTable dataTable = new DataTable();
                conn = new MySqlConnection(dbConnectionString); //Needed to initialise conn
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                //prepared statement - called when used
                if (selectedBranch != "All Branches")
                {
                    cmd.Parameters.AddWithValue("@BranchId", selectedBranch);
                }
                MySqlDataReader rdr = cmd.ExecuteReader();

                dataTable.Load(rdr);

                EmployeeDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        private void SalaryButton_Checked(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "SELECT * FROM employees WHERE gross_salary > @SalaryFilter;";

            try
            {
                DataTable dataTable = new DataTable();

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);

                cmd.Parameters.AddWithValue("@SalaryFilter", 70000);

                MySqlDataReader rdr = cmd.ExecuteReader();

                dataTable.Load(rdr);

                EmployeeDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();


        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            Updaterecord ob = new Updaterecord();
            ob.ShowDialog();
            
        }


        private void NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            Insertwindow op1 = new Insertwindow();
            op1.ShowDialog();

        } 

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "DELETE FROM employees WHERE employee_id = '" + SearchTextBox.Text + "';";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
