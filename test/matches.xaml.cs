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
using System.Configuration;
using test.Primary_funkions; //pga. mappestruktur

namespace test
{
    /// <summary>
    /// Interaction logic for matches.xaml
    /// </summary>
    public partial class matches : Window
    {
        public matches(int currentUserID, string YourUserName)
        {
            this.currentUserID = currentUserID;
            yourUserName = YourUserName;
            InitializeComponent();
            BindDataGrid();
        }
        // HUSK AT ÆNDR
        // receiverI
        private int receiverID = 0;
        private int currentUserID = 0;
        private string yourUserName = "";
        private string theirUserName = "";


        //system .configuration
        DOOPRET op = new DOOPRET();
        public void BindDataGrid()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    sqlCon.Open();

                    string searchQuery = $"SELECT fullName, sex, city, userID FROM userProfile, match where userProfile.userID=senderID AND isMatch=1 AND receiverID={currentUserID.ToString()}";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(searchQuery, sqlCon);
                    sda.Fill(dt);
                    DataTable dt1 = new DataTable();

                    dt.Columns.Add(new DataColumn("isRead", typeof(string)));

                    // Checker hvis ulæst besked.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        receiverID = (int)dt.Rows[0]["userID"];
                        string countQuery = $"SELECT COUNT(isRead) as isRead FROM directMessages WHERE senderID={dt.Rows[i]["userID"].ToString()} AND receiverID={currentUserID} AND isRead=0";
                        SqlDataAdapter sda1 = new SqlDataAdapter(countQuery, sqlCon);
                        sda1.Fill(dt1);
                        if ((int)dt1.Rows[i]["isRead"] >= 1)
                        {
                            dt.Rows[i]["isRead"] = "!";
                        }
                        else
                        {
                            dt.Rows[i]["isRead"] = ":(";
                        }

                    }

                    g1.ItemsSource = dt.DefaultView;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Fejl opstået" + ex);
            }
        }

        private void GetSelectedRowCellValue(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = g1.SelectedItem as DataRowView;
            if (row == null)
            {
                g1.SelectedItem = null;
                receiverID = 0;
            }
            else
            {
                receiverID = Convert.ToInt32(row.Row.ItemArray[3].ToString());
                MessageBox.Show(receiverID.ToString());
                theirUserName = row.Row.ItemArray[0].ToString();
            }

        }

        public void SelectButton_Click(object sender, RoutedEventArgs e, matches ay) { }
        public void SelectButton_Click(object sender, RoutedEventArgs e) { }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChatLog chatLog = new ChatLog(currentUserID, receiverID, yourUserName, theirUserName);
            chatLog.ShowDialog();
            BindDataGrid();
        }

    }
}