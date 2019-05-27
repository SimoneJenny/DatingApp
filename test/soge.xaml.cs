using System.Windows;
using System.Data;
using System.Data.SqlClient;
using static test.Databaseconnection;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using test.Primary_funkions;

namespace test
{
    /// <summary>
    /// Interaction logic for soge.xaml
    /// </summary>
    public partial class soge : Window
    {
        public soge(int receivedUserID)
        {
            InitializeComponent();         
            currentUserID = receivedUserID;
            BindDataGrid();
        }

        private int maxAndMinAgeDifferenceInSearch = 5;
        private int currentUserID = 0;
        private int likedPersonUserID = 0;

        DOOPRET op = new DOOPRET();
        public void BindDataGrid()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    sqlCon.Open();
                    string searchQuery = $"SELECT p.fullName,p.sex,age,p.city,p.aboutMe,lookingFor,p.userID, avatar FROM userAccount as a, userProfile as p WHERE a.userID = p.userID and deleted IS NULL AND NOT p.userID ={ currentUserID.ToString()}";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(searchQuery, sqlCon);
                    sda.Fill(dt);
                    g1.ItemsSource = dt.DefaultView;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Fejl opstået" + ex);
            }
        }

        private void likebutton(object sender, RoutedEventArgs e) {
            if (likedPersonUserID > 0)
            {
                string sqlQuery = $"INSERT INTO match (senderID,receiverID) VALUES ({currentUserID}, {likedPersonUserID})";

                using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                if (CheckIfMatch())
                {
                    ChangeMatchStatus();
                } 
                else
                {
                    MessageBox.Show("Du har liket en bruger som ikke kan lide dig du er en taber du bliver aldrig til noget :)");
                }
                MessageBox.Show(currentUserID.ToString() + " har liket " + likedPersonUserID.ToString());
            }
            else
            {
                //MessageBox.Show("nope.");
            }
        }

        private void ChangeMatchStatus()
        {
            using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
            {
                sqlCon.Open();
                string changeCurrentUserStatus = $"UPDATE match SET isMatch=1 where senderID={currentUserID} AND receiverID={likedPersonUserID}";
                string changeLikedUserStatus = $"UPDATE match SET isMatch=1 where senderID={likedPersonUserID} AND receiverID={currentUserID}";
                SqlCommand cmdCurrentUser = new SqlCommand(changeCurrentUserStatus,sqlCon);
                SqlCommand cmdLikedUser = new SqlCommand(changeLikedUserStatus,sqlCon);
                cmdCurrentUser.ExecuteNonQuery();
                cmdLikedUser.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        private bool CheckIfMatch()
        {
            string searchQuery = $"SELECT * FROM match where senderID={likedPersonUserID} AND receiverID={currentUserID}";
            using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB())) {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(searchQuery, sqlCon);
                sda.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                return false;
            }
        }
      

        public void sogemedlemmer(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    sqlCon.Open();
                    //string searchQuery = $"SELECT fullname, sex, city, age, aboutMe, lookingFor FROM userProfile WHERE sex='{txtSex.Text}'";
                    //string searchQuery = $"SELECT * FROM userProfile WHERE sex='{txtSex.Text}'";
                    int minAge = 0, maxAge = 100, userSearchAge = 0;
                    if (txtAge.Text.Trim() != "")
                    {
                        userSearchAge = Convert.ToInt32(txtAge.Text.Trim());
                        minAge = userSearchAge - maxAndMinAgeDifferenceInSearch; maxAge = userSearchAge + maxAndMinAgeDifferenceInSearch;
                    } else
                    {
                        minAge = 0; maxAge = 100;
                    }
                    // TODO DET ER GRIMT AT KIGGE PÅ TODO
                    //SELECT p.fullName,p.sex,p.city,p.aboutMe,lookingFor,p.userID, avatar FROM userAccount as a, userProfile as p
                    string searchQuery = $"SELECT fullName, sex, city, age, aboutMe, lookingFor, p.userID, avatar From userProfile as p, userAccount as a WHERE age BETWEEN {minAge} AND {maxAge}"
                        + $"AND sex LIKE '%{txtSex.Text.Trim()}%' AND NOT p.userID={currentUserID.ToString()} AND a.userID=p.userID AND deleted IS NULL";

                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(searchQuery, sqlCon);
                    sda.Fill(dt);
                    g1.ItemsSource = dt.DefaultView;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Fejl opstået" + ex);
            }
        }
        public void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView um = (DataRowView)g1.SelectedItem;
            var selectrow = new DOOPRET()
            {
                Id = um[0].ToString(),
                Ditfuldenavn = um[1].ToString(),
                Alder = (int)um[2],
                By = um[3].ToString(),
                Hvemerjeg = um[4].ToString(),
                Interesser = um[5].ToString(),
                Soger = um[6].ToString()
            };
        }

        // Få info omkring valgt bruger
        private void GetSelectedRowCellValue()
        {
            DataRowView row = g1.SelectedItem as DataRowView;
            if (row == null)
            {
                g1.SelectedItem = null;
                likedPersonUserID = 0;
            } else
            {
                likedPersonUserID = Convert.ToInt32(row.Row.ItemArray[6].ToString());
                GetSelectedUserProfile(row);
            }

        }

        // Fejlsikret fra kaldt metode TODO FIKS
        private void GetSelectedUserProfile(DataRowView row)
        {
            string filepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string filepathtoimages = @"billede\ProfilBilleder\";
            int index = filepath.LastIndexOf(@"\bin\") + 1;
            filepath = filepath.Substring(0, index) + filepathtoimages + row.Row.ItemArray[7].ToString();
            imgAvatar.Source = new BitmapImage(new Uri(filepath));
        }

        // KUN TAL I TEKSTBOX
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void G1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetSelectedRowCellValue();
        }
    }
}
