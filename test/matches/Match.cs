using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static test.Databaseconnection;

namespace test
{
    public class Match
    {
        public static void match()
        {
            int userID = Indtastadgang();
            SELECTstatement(userID);
            findmatchs.find();
        }

        private static int Indtastadgang()
        {
            int userID;
            Console.WriteLine("Indtast Din brugerprofil ID: ");
            userID = Convert.ToInt32(Console.ReadLine());
            return userID;
        }

        public static void SELECTstatement(int userID)
        {
            string DB = "SELECT senderId, receiver FROM [Match] WHERE senderId = @user OR receiver = @user AND senderId != receiver";
            using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(DB, con))
            {
                con.Open();
                adapter.SelectCommand.Parameters.AddWithValue("@user", userID);
                SqlCommand command = new SqlCommand(DB, con);
                command.Parameters.AddWithValue("@user", userID);
                command.ExecuteScalar();
                command.Connection.Close();
            }
        }
    }
}
