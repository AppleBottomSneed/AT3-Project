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
    /// Interaction logic for Insertwindow.xaml
    /// </summary>
    public partial class Insertwindow : Window
    {
        public Insertwindow()
        {
            InitializeComponent();
        }

        string dbconnectionString = "datasource=localhost; port=3306; username=root; password=''; database=jn_ictprg431_fix;";

        public void insertemployee()
        {
            using (MySqlConnection conn = new MySqlConnection(dbconnectionString))
            {
                string sqlQuery = "INSERT INTO employees (given_name, family_name, date_of_birth, gender_identity, gross_salary, supervisor_id, branch_id) " +
                "VALUES (@GivenName, @FamilyName, @DateOfBirth, @GenderIdentity, @GrossSalary, @SupervisorId, @BranchId)";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, conn)) 
                {
                    //prepared statement
                    cmd.Parameters.AddWithValue("@GivenName", this.GivennameText.Text);
                    cmd.Parameters.AddWithValue("@FamilyName", this.FamilynameText.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", this.BirthdayText.Text);
                    cmd.Parameters.AddWithValue("@GenderIdentity", this.GenderText.Text);
                    cmd.Parameters.AddWithValue("@GrossSalary", this.GrossSalaryText.Text);
                    cmd.Parameters.AddWithValue("@SupervisorId", this.SupervisorIdText.Text);
                    cmd.Parameters.AddWithValue("@BranchId", this.BranchText.Text);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Added");
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    conn.Close();
                }
            }
            
        }
        public void cleardata()
        {
            /* IdText.Clear(); */
            GivennameText.Clear();
            FamilynameText.Clear();
            BirthdayText.Clear();
            GenderText.Clear();
            GrossSalaryText.Clear();
            SupervisorIdText.Clear();
            BranchText.Clear();
        }


        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            insertemployee();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            cleardata();        
        }
    }
}
