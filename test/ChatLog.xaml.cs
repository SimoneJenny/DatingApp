using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using static test.Databaseconnection;


namespace test
{
    /// <summary>
    /// Interaction logic for ChatLog.xaml
    /// </summary>
    public partial class ChatLog : Window
    {

        // Constructor
        public ChatLog(int CurrentUserID, int CurrentChatterID, string YourUserName, string TheirUserName)
        {
            currentUserID = CurrentUserID;
            currentChatterID = CurrentChatterID;
            yourUserName = YourUserName;
            theirUserName = TheirUserName;
            InitializeComponent();
            BindMessagesToTextBox();
            chatBox.ScrollToEnd();
            IsReadUpdate();
        }

        // Fields
        private int currentUserID = 0;
        private int currentChatterID = 0;
        private string yourUserName = "";
        private string theirUserName = "";

        // Load chat-beskeder
        private void BindMessagesToTextBox()
        {
            chatBox.Document.Blocks.Clear();
            string searchQuery = $"SELECT senderID, messagetext FROM directMessages WHERE receiverID={currentUserID} "
                + $"AND senderID={currentChatterID} OR senderID={currentUserID} AND receiverID={currentChatterID}";
            using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(searchQuery, sqlCon);
                sda.Fill(dt);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string senderName = "";
                    if (dt.Rows[i]["senderID"].ToString() == currentUserID.ToString())
                    {
                        senderName = yourUserName;
                    }
                    else
                    {
                        senderName = theirUserName;
                    }
                    string sender = dt.Rows[i]["senderID"].ToString();
                    string textMessage = dt.Rows[i]["messagetext"].ToString();
                    chatBox.AppendText(senderName + ": ");
                    chatBox.AppendText(textMessage + "\n");

                }
            }
            chatBox.ScrollToEnd();
        }

        public void SendMessage(object sender, RoutedEventArgs e)
        {
            if (txtMessage.Text.Trim() != "")
            {
                using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    sqlCon.Open();
                    string message = txtMessage.Text.Trim();
                    string sqlQuery = $"INSERT INTO directMessages (senderID, receiverID,messageText) VALUES ({currentUserID}, {currentChatterID}, '{message}')";
                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                txtMessage.Text = "";
                MessageBox.Show("Beskeden er sendt.");
                BindMessagesToTextBox();
            }
            else
            {
                MessageBox.Show("ingen text.");
            }
        }

        private void IsReadUpdate()
        {
            string updateQuery = $"UPDATE directMessages SET isRead=1 WHERE   senderID={currentChatterID} AND receiverID={currentUserID} ";
            using (SqlConnection sqlCon = new SqlConnection(dbconnection.ConnectionDB()))
            {
                //SqlDataAdapter sda = new SqlDataAdapter(updateQuery, sqlCon);
                SqlCommand cmd = new SqlCommand(updateQuery, sqlCon);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

        }
    }
}
