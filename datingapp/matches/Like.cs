using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace datingapp
{
    public class Like
    {
        public static void liked()
        {
            COSOE.soge();
            string like;

            Console.WriteLine("Hvis interesse, tast ID for person:");
            like = Console.ReadLine();
            int migselv;
            Console.WriteLine("egen id:");
            migselv = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
            {
                con.Open();
                string DB = "INSERT INTO [dbo].[Match](senderId, receiver) VALUES (@senderid, @re)";
                SqlCommand command = new SqlCommand(DB, con);
                command.Parameters.AddWithValue("@senderid", migselv);
                command.Parameters.AddWithValue("@re", like);
                command.ExecuteScalar();
                command.Connection.Close();
            }    
            Console.WriteLine("Du har vist interesse for bruger ID {0}", like);
            Console.ReadLine();

        }       
    }
}    
       

   

