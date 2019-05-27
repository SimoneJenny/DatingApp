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
using System.Data;
using System.Data.SqlClient;
using static test.Databaseconnection;

namespace test
{
    /// <summary>
    /// Interaction logic for sletbruger.xaml
    /// </summary>
    public partial class sletbruger : Window
    {
        public sletbruger()
        {
            InitializeComponent();
        }

        private void slet(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    con.Open();
                    string DB = "UPDATE userAccount SET deleted='1' WHERE password=@password AND Email=@email";
                    //VI updater så brugere altid kan komme tilbage - se under deleted  = true i DB
                    SqlCommand command = new SqlCommand(DB, con);
                    command.Parameters.AddWithValue("@password", txtpassword.Text);
                    command.Parameters.AddWithValue("@email", txtemail.Text);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("fejl opstået: " + ex);
            }
            
        }
}  }
