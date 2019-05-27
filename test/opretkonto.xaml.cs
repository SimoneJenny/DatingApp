using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using static test.Databaseconnection;
namespace test
{
    /// <summary>
    /// Interaction logic for opretkonto.xaml
    /// </summary>
    public partial class opretkonto : Window
    {
        public opretkonto()
        {
            userAccountUserId = GetIdInTotal() + 1;
            MessageBox.Show(userAccountUserId.ToString());
            InitializeComponent();
        }

        private int userAccountUserId = 0;

        private int GetIdInTotal()
        {
            using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
            {
                string searchQuery = "SELECT COUNT(*) FROM userAccount";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(searchQuery, dbconnection.ConnectionDB());
                sda.Fill(dt);
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
        }


        public void CreateUserAccount()
        {
            try
            {
                string insertQuery = "INSERT INTO userAccount (username, [password], email) VALUES (@Login, @Adgangskode, @Email)";
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    // TODO Tjek at username er unikt.
                    // TODO Double tjek for password?
                    // TODO Tjek at email er unikt?
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@Login", txtName.Text);
                    command.Parameters.AddWithValue("@Email", txtPassword.Text);
                    command.Parameters.AddWithValue("@Adgangskode", txtEmail.Text);
                    command.ExecuteScalar();
                    command.Connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void opretbruger(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Trim() != "" && txtPassword.Text.Trim() != "" && txtEmail.Text.Trim() != "")
            {
                CreateUserAccount();
                // +1 for at få den nye bruger.
                opretbruger opretbruger = new opretbruger(userAccountUserId);
                opretbruger.Show();
                this.Close();
            } else // TODO Gør error message mere specifikt.
            {
                MessageBox.Show("Missing info");
            }
        }
    }
}
