using System;
using System.Windows;
using System.Data.SqlClient;
using static test.Databaseconnection;

namespace test
{
    /// <summary>
    /// Interaction logic for opretbrugerfirst.xaml
    /// </summary>
    public partial class opretbrugerfirst : Window
    {
        public opretbrugerfirst(int userID)
        {
            currentUserID = userID;
            InitializeComponent();
        }

        private int currentUserID = 0;

        public void gembruger(object sender, RoutedEventArgs e)
        {
            //DOOPRET opret = new DOOPRET();
            try
            {
                string DB = "INSERT INTO UserProfile(sex,fullname, alder, [by], hvemerjeg, jegsoger, interesser) VALUES (@sex,@fullname, @alder, @by, @hvemerjeg, @jegsoger, @interesser)";
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    SqlCommand command = new SqlCommand(DB, con);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@sex", txtsex.Text);
                    command.Parameters.AddWithValue("@fullname", txtnavn.Text);
                    command.Parameters.AddWithValue("@alder", txtalder.Text);
                    command.Parameters.AddWithValue("@by", txtby.Text);
                    command.Parameters.AddWithValue("@hvemerjeg", txtommig.Text);
                    command.Parameters.AddWithValue("@interesser", txtinter.Text);
                    command.Parameters.AddWithValue("@jegsoger", txtsog.Text);
                    //command.ExecuteScalar();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    }

