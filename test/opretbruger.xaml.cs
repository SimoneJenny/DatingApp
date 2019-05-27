using System;
using System.Windows;
using System.Data.SqlClient;
using static test.Databaseconnection;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;
using test.Primary_funkions;

namespace test
{
    /// <summary>
    /// Interaction logic for opretbruger.xaml
    /// </summary>
    public partial class opretbruger : Window
    {
        public opretbruger(int userID)
        {
            currentUserID = userID;
            InitializeComponent();
            locationToAvatarDirectory = @"..\..\billede\ProfilBilleder\";
            avatarFilename = currentUserID.ToString() + "_Avatar.png";
            MessageBox.Show(currentUserID.ToString());
        }

        private string locationToAvatarDirectory = "";
        private string avatarFilename = "";
        private int currentUserID = 0;


        public void gembruger(object sender, RoutedEventArgs e)
        {
            if (txtsex.Text.Trim() != "" && txtnavn.Text.Trim() != "" &&
                txtalder.Text.Trim() != "" && txtby.Text.Trim() != "" &&
                txtommig.Text.Trim() != "" && txtinter.Text.Trim() != "")
            {
                try
                {
                    //string searchQuery = "INSERT INTO UserProfile(sex,fullname, alder, [by], hvemerjeg, jegsoger, interesser) VALUES (@sex,@fullname, @alder, @by, @hvemerjeg, @jegsoger, @interesser)";
                    SaveImageToDB();
                    string searchQuery = "INSERT INTO userProfile " +
                        "(sex, fullName, age, city, aboutMe, lookingFor, avatar, userID) " +
                        "VALUES(@sex, @fullname, @age, @city, @aboutMe, @lookingFor, @avatar, @userID)";
                    using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                    {
                        SqlCommand command = new SqlCommand(searchQuery, con);
                        command.Connection.Open();
                        command.Parameters.AddWithValue("@sex", txtsex.Text.Trim());
                        command.Parameters.AddWithValue("@fullname", txtnavn.Text.Trim());
                        command.Parameters.AddWithValue("@age",txtalder.Text.Trim());
                        command.Parameters.AddWithValue("@city", txtby.Text.Trim());
                        command.Parameters.AddWithValue("@aboutMe", txtommig.Text.Trim());
                        command.Parameters.AddWithValue("@lookingFor", txtinter.Text.Trim());
                        // GET BACK 
                        command.Parameters.AddWithValue("@avatar", avatarFilename);
                        command.Parameters.AddWithValue("@userID", currentUserID.ToString());
                        command.ExecuteNonQuery();
                        command.Connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void UploadLocallyStoredImage(object sender, RoutedEventArgs e)
        {
            // Should work, doesn't save.
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) {
                string filename = dlg.FileName;
                ImgAvatar.Source = new BitmapImage(new Uri(filename));
            }
        }

        public void LinkToImage()
        {
            if (txtAvatar.Text.Trim() != "") {
                try {
                    ImgAvatar.Source = new BitmapImage(new Uri(txtAvatar.Text.Trim()));
                }
                catch (Exception) {
                    MessageBox.Show("invalid file");
                }
            }
            else {
            }
        }

        public void SaveImageToDB()
        {
            // TODO: GEM BILLEDE FRA SØGTE PROFIL HVIS MANGLER
            // C:\Users\tec\source\repos\TestMedDataBinding\wpf\test\billede\ProfilBilleder
            //string filePathOnly = @"..\..\billede\ProfilBilleder\";
            //string nameForCurrentUserAvatar = filePathOnly + currentUserID.ToString() + "_ProfilePic.png";
            //currentUserAvatar = nameForCurrentUserAvatar;
            // fungere også med andre filtyper end png
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)ImgAvatar.Source));
            // TODO TRY CATCH
            using (FileStream fs = new FileStream(locationToAvatarDirectory + avatarFilename, FileMode.Create))
            {
                // ..\..\billede\ProfilBilleder\
                encoder.Save(fs);
                locationToAvatarDirectory = locationToAvatarDirectory.Substring(5) + avatarFilename;
                txtAvatar.Text = locationToAvatarDirectory;
            }
        }
    }

}