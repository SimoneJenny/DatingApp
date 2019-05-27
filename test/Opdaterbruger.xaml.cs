using System.Windows;
using System.Data.SqlClient;
using static test.Databaseconnection;
using System;

namespace test
{
    /// <summary>
    /// Interaction logic for Opdaterbruger.xaml
    /// </summary>
    public partial class Opdaterbruger : Window
    {
        public Opdaterbruger(int userID)
        {
            currentUserID = userID;
            InitializeComponent();
            MessageBox.Show(userID.ToString());
        }

        private int currentUserID = 0;
    
        private void updateuser(object sender, RoutedEventArgs e)
        {
            string searchQuery = "UPDATE userProfile SET ";
            string searchQueryEnding = $" WHERE userID={currentUserID}";
            int numberOfChanges = CountChangesToAccount();

            if (txtFullName.Text.Trim() != "")
            {
                searchQuery += $"fullName='{txtFullName.Text.Trim()}'";
                if (numberOfChanges != 1)
                {
                    searchQuery += ", ";
                    numberOfChanges -= 1;
                }
            }
            if (txtSex.Text.Trim() != "")
            {
                searchQuery += $"sex='{txtSex.Text.Trim()}'";
                if (numberOfChanges != 1)
                {
                    searchQuery += ", ";
                    numberOfChanges -= 1;
                }
            }
            if (txtAge.Text.Trim() != "")
            {
                searchQuery += $"age={txtAge.Text.Trim()}";
                if (numberOfChanges != 1)
                {
                    searchQuery += ", ";
                    numberOfChanges -= 1;
                }
            }
            if (txtCity.Text.Trim() != "")
            {
                searchQuery += $"city='{txtCity.Text.Trim()}'";
                if (numberOfChanges != 1)
                {
                    searchQuery += ", ";
                    numberOfChanges -= 1;
                }
            }
            if (txtAboutMe.Text.Trim() != "")
            {
                searchQuery += $"aboutMe='{txtAboutMe.Text.Trim()}'";
                if (numberOfChanges != 1)
                {
                    searchQuery += ", ";
                    numberOfChanges -= 1;
                }
            }
            if (txtlookingFor.Text.Trim() != "")
            {
                searchQuery += $"lookingFor='{txtlookingFor.Text.Trim()}'";
                if (numberOfChanges != 1)
                {
                    searchQuery += ", ";
                    numberOfChanges -= 1;
                }
            }
            if (txtAvatar.Text.Trim() != "")
            {
                searchQuery += $"avatar='{txtAvatar.Text.Trim()}'";
                if (numberOfChanges != 1)
                {
                    searchQuery += ", ";
                    numberOfChanges -= 1;
                }
            }


            searchQuery += searchQueryEnding;
            try
            {
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    SqlCommand adapter = new SqlCommand(searchQuery, con);
                    adapter.Connection.Open();
                    adapter.ExecuteNonQuery();
                    adapter.Connection.Close();
                    MessageBox.Show("Success!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("fejl" + e);
            }
            
        }


        private int CountChangesToAccount()
        {
            int countingChanges = 0;

            if (!txtFullName.Text.Trim().Equals(""))
                countingChanges++;
            if (!txtAge.Text.Trim().Equals(""))
                countingChanges++;
            if (!txtSex.Text.Trim().Equals(""))
                countingChanges++;
            if (!txtCity.Text.Trim().Equals(""))
                countingChanges++;
            if (!txtAboutMe.Text.Trim().Equals(""))
                countingChanges++;
            if (!txtlookingFor.Text.Trim().Equals(""))
                countingChanges++;
            if (!txtAvatar.Text.Trim().Equals(""))
                countingChanges++;

            return countingChanges;
        }
       
    }
}
