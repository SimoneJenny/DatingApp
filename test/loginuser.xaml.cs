using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static test.Databaseconnection;

namespace test
{
    /// <summary>
    /// Interaction logic for loginuser.xaml
    /// </summary>
    public partial class loginuser : Window
    {
        public loginuser(string receivedUserID)
        {
            currentUserID = Convert.ToInt32(receivedUserID);
            InitializeComponent();
            BindUserInfo();
        }

        private string yourFullName = "";
        private int currentUserID = 0;
        private string avatarName = "";

        private void BindUserInfo()
        {
            using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
            {
                string searchQueryAccount = $"SELECT * FROM userAccount WHERE userID={currentUserID.ToString()}";
                string searchQueryProfile = $"SELECT * FROM userProfile WHERE userID={currentUserID}";
                DataTable dtAccount = new DataTable();
                SqlDataAdapter sdaAccount = new SqlDataAdapter(searchQueryAccount, sqlCon);
                sdaAccount.Fill(dtAccount);
                DataTable dtProfile = new DataTable();
                SqlDataAdapter sdaProfile = new SqlDataAdapter(searchQueryProfile, sqlCon);
                sdaProfile.Fill(dtProfile);
                txtUsername.Content = dtAccount.Rows[0]["username"].ToString();
                txtFullName.Content = dtProfile.Rows[0]["fullName"].ToString();
                yourFullName = dtProfile.Rows[0]["fullName"].ToString();
                FlowDocument fDoc = new FlowDocument();
                fDoc.Blocks.Add(new Paragraph(new Run(dtProfile.Rows[0]["aboutMe"].ToString())));
                avatarName = dtProfile.Rows[0]["avatar"].ToString();

                txtAboutMe.Document = fDoc;

                string fileName = dtProfile.Rows[0]["avatar"].ToString().Trim();
                try
                {
                    imgAvatar.Source = new BitmapImage(new Uri(GetFilePath()));
                }
                catch
                {
                    imgAvatar.Source = new BitmapImage(new Uri(@"billede/ProfilBilleder/defaultCowboy.png", UriKind.Relative));
                }
            }
        }

        private string GetFilePath()
        {
            string filepath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string filepathtoimages = @"billede\ProfilBilleder\";
            int index = filepath.LastIndexOf(@"\bin\") + 1;
            return filepath.Substring(0, index) + filepathtoimages + avatarName;
        }


        public void opdater(object sender, RoutedEventArgs e)
        {
            Opdaterbruger up = new Opdaterbruger(currentUserID);
            up.Show();
            this.Close();
        }

        public void soge(object sender, RoutedEventArgs e)
        {
            soge up = new soge(currentUserID);
            up.Show();
            this.Close();
        }

        private void slet(object sender, RoutedEventArgs e)
        {
            sletbruger slet = new sletbruger();
            slet.Show();
            this.Close();
        }

        public void matches(object sender, RoutedEventArgs e)
        {
            matches mat = new matches(currentUserID, yourFullName);
            mat.Show();
            this.Close();
        }
    }
}
