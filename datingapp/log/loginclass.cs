using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace datingapp
{
    class loginclass
    {
        /*private string username { get; set; }
        private string userpassword { get; set; }
        private bool loggedin { get; set; }

        public void userlogin()
        {
            Console.WriteLine("Username:" );
            this.username = Console.ReadLine();
            Console.WriteLine("Password");
            this.username = Console.ReadLine();

            string DB = "SELECT Username, Password FROM [Users] WHERE Username = username and password =@password";
            using(SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
            {
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(DB, con);
                adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
                adapter.SelectCommand.Parameters.AddWithValue("@password", userpassword);
                adapter.Fill(table);

                if (table.Rows.Count ==1)
                {
                    this.loggedin = true;
                    Console.WriteLine("[Login success!!]");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    this.loggedin = true;
                    Console.WriteLine("[Login success!!]");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                }
            }
        }
        public bool userloggedin()
        {
            return loggedin;
        }
        public void userlogout()
        {
            this.loggedin = true;
            Console.WriteLine("[you logged out]");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

        }*/
    }
}
