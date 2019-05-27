using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace datingapp
{
    public class Deletemedlem
    {

        DOdelete delete = new DOdelete();
        public void deletemedlemmer()
        {
            Indsaet();
            Deleteuser();
        }

        private void Deleteuser()
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
            {
                con.Open();
                string DB = "UPDATE [User] SET deleted = '1' WHERE password = @password and Email = @email";
                //VI updater så brugere altid kan komme tilbage - se under deleted  = true i DB
                SqlCommand command = new SqlCommand(DB, con);
                command.Parameters.AddWithValue("@password", delete.adgangskode);
                command.Parameters.AddWithValue("@email", delete.email);

                //vil du slette?
                Console.WriteLine("For at slette tryk j, fortyder du? tryk n");
                string valg = Console.ReadLine().ToUpper();
                if (valg == "N")
                {
                }
                if (valg == "J")
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        private void Indsaet()
        {
            Console.WriteLine("Du har tastet delete, du skal nu: ");
            Console.WriteLine("Indtast password");
            delete.adgangskode = Console.ReadLine();
            Console.WriteLine("Indtast email");
            delete.email = Console.ReadLine();
        }
            
}   }    
        

