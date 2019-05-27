using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace datingapp
{
    public class skriv
    {
        public static void skrivtiletmedlem()
        {
            string skriv;
            int userid;
            string like;

            Console.WriteLine("Hvis interesse, tast ID for person:");
            like = Console.ReadLine();
            int migselv;
            Console.WriteLine("egen id:");
            migselv = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv besked");
            skriv = Console.ReadLine();

            Indsaet2DB(skriv, like, migselv);
        }

        private static void Indsaet2DB(string skriv, string like, int migselv)
        {
            using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
            {
                con.Open();
                string DBskriv = "INSERT INTO [dbo].[Message](senderId, receiver,MessageText) VALUES (@senderid, @re, @MessageText)";
                SqlCommand command = new SqlCommand(DBskriv, con);
                command.Parameters.AddWithValue("@senderid", migselv);
                command.Parameters.AddWithValue("@re", like);
                command.Parameters.AddWithValue("@MessageText", skriv);
                command.ExecuteScalar();
                command.Connection.Close();
            }
            Console.WriteLine("Du har skrevet til brugeren:  {0}", skriv);
            Console.ReadLine();
        }
    }
}
