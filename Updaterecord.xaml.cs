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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace AT3_Project
{
    /// <summary>
    /// Interaction logic for Updaterecord.xaml
    /// </summary>
    public partial class Updaterecord : Window
    {
        public Updaterecord()
        {
            InitializeComponent();
        }

        string dbconnectionString = "datasource=localhost; port=3306; username=root; password=''; database=jn_ictprg431_fix;";

        public void insertemployee()
        {
            MySqlConnection conn = new MySqlConnection(dbconnectionString);
            string sqlQuery = "UPDATE employees SET gross_salary = '" + SalaryTextBox.Text + "' WHERE employee_id = '" + EmployeeTextBox.Text + "';";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            try
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand(sqlQuery, conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Saved");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            insertemployee();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            SalaryTextBox.Clear();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
