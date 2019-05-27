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
    public class Update
    {
        public void Updatemedlem()
        {
            DOupdate update = new DOupdate();
            int userID;
            Console.WriteLine("Indtast Din brugerprofil ID: ");
            userID = Convert.ToInt32(Console.ReadLine());
            bool loop = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Vil du ændre dit navn?       Tast 1");
                Console.WriteLine("Vil du ændre alder?          Tast 2");
                Console.WriteLine("vil du ændre by?             Tast 3");
                Console.WriteLine("Vil du ændre information?    Tast 4");
                Console.WriteLine("vil du ændre hvad du søger?  Tast 5");
                Console.WriteLine("Vil du ændre interesser?     Tast 6 ");
                Console.WriteLine("vil du ændre køn:            Tast 7 ");

                Console.WriteLine("gå tilbage  Q");
                char switchs = Convert.ToChar(Console.ReadLine().ToLower());
                switch (switchs)
                {
                    case '1':
                        Console.WriteLine("Indtast navn: ");
                        update.ditfuldenavn = Console.ReadLine();
                        break;
                    case '2':
                        Console.WriteLine("Indtast alder: ");
                        update.alder = Convert.ToInt32(Console.ReadLine());
                        break;
                    case '3':
                        Console.WriteLine("Indtast by: ");
                        update.by = Console.ReadLine();
                        break;
                    case '4':
                        Console.WriteLine("Indtast information om dig: ");
                        update.hvemerjeg = Console.ReadLine();
                        break;
                    case '5':
                        Console.WriteLine("Indtast hvad du søger: ");
                        update.soger = Console.ReadLine();
                        break;
                    case '6':
                        Console.WriteLine("hvilken interesser?");
                        update.interesse = Console.ReadLine();
                        break;
                    case '7':
                        Console.WriteLine("vælg køn: ");
                        update.kon = Console.ReadLine();
                        break;
                    case 'q':
                        loop = false;
                        break;
                }

            } while (loop == true);
            Updatestring(update, userID);
        }

        public static void Updatestring(DOupdate update, int userID)
        {
            try
            {
                String updatestreng = "UPDATE UserProfile SET fullname = @fullname, sex = @kon, alder = @alder, [by] = @city, hvemerjeg = @hvemerjeg, jegsoger = @jegsoger, interesser = @interesser WHERE userProfileId = @user";
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    SqlCommand adapter = new SqlCommand(updatestreng, con);
                    adapter.Connection.Open();
                    adapter.Parameters.AddWithValue("@user", userID);
                    adapter.Parameters.AddWithValue("@fullname", update.ditfuldenavn);
                    adapter.Parameters.AddWithValue("@kon", update.kon);
                    adapter.Parameters.AddWithValue("@alder", update.alder);
                    adapter.Parameters.AddWithValue("@city", update.by);
                    adapter.Parameters.AddWithValue("@hvemerjeg", update.hvemerjeg);
                    adapter.Parameters.AddWithValue("@jegsoger", update.hvemerjeg);
                    adapter.Parameters.AddWithValue("@interesser", update.interesse);

                    adapter.ExecuteNonQuery();
                    adapter.Connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("fejl opstået" + " " + e.Message);
            }

        }
    }
}
