using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static test.Databaseconnection;
using test.Primary_funkions;

namespace test
{
    public class COopretfunktion
    {
        DOOPRET opret = new DOOPRET();
        public void opretbruger()
        {
            skrivoplysningr();
            Indsaetbruger2DB();
        }

        public void Indsaetbruger2DB()
        {
            try
            {
                string DB = "INSERT INTO UserProfile(sex,fullname, alder, [by], hvemerjeg, jegsoger, interesser) VALUES (@sex,@fullname, @alder, @by, @hvemerjeg, @jegsoger, @interesser)";
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    SqlCommand command = new SqlCommand(DB, con);
                    /*command.Connection.Open();
                    command.Parameters.AddWithValue("@sex", opret.sex);
                    command.Parameters.AddWithValue("@fullname", opret.ditfuldenavn);
                    command.Parameters.AddWithValue("@alder", opret.alder);
                    command.Parameters.AddWithValue("@by", opret.by);
                    command.Parameters.AddWithValue("@hvemerjeg", opret.hvemerjeg);
                    command.Parameters.AddWithValue("@interesser", opret.interesser);
                    command.Parameters.AddWithValue("@jegsoger", opret.soger);
                    command.ExecuteScalar();
                    command.Connection.Close();*/
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Fejl opstået: " + " " + e.Message);
            }
        }
        public void skrivoplysningr()
        {
            /*Console.WriteLine("Du har valgt at oprette en brugerkonto");
            Console.WriteLine("                                      ");
            Console.WriteLine("Indtast dit navn:");
            opret.ditfuldenavn = Console.ReadLine();
            Console.WriteLine("vælg køn: kvinde = k og mand = m , i intetkøn");
            opret.sex = Console.ReadLine().ToLower();
            Console.WriteLine("Indtast Alder:");
            opret.alder = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast By");
            opret.by = Console.ReadLine();
            Console.WriteLine("Lav beskrivelse om dig selv: ");
            opret.hvemerjeg = Console.ReadLine();
            Console.WriteLine("Intast dine interesser: ");
            opret.interesser = Console.ReadLine();
            Console.WriteLine("Hvad søger du?");
            opret.soger = Console.ReadLine();*/
        }
        public void opretkonto()
        {
            //skrivoplysninger();
            Indsaetlogin2DB();
        }

        public void Indsaetlogin2DB()
        {
            try
            {
                string DB = "INSERT INTO [User](login, Email, password) VALUES (@Login, @Email, @Adgangskode)";
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                {
                    SqlCommand command = new SqlCommand(DB, con);
                    /*command.Connection.Open();
                    command.Parameters.AddWithValue("@Login", opret.login);
                    command.Parameters.AddWithValue("@Email", opret.email);
                    command.Parameters.AddWithValue("@Adgangskode", opret.adgangskode);*/

                    command.ExecuteScalar();
                    command.Connection.Close();
                }
                Console.WriteLine("                            ");
                Console.WriteLine(".......Konto oprettet og gemt");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Fejl opstået: " + e.Message);
            }
        }
        public void skrivoplysninger()
        {
            /*Console.WriteLine("Lav et unikt loginnavn: ");
            opret.login = Console.ReadLine();
            Console.WriteLine("Din Email: ");
            opret.email = Console.ReadLine();
            Console.WriteLine("Skriv din Adgangskode: ");
            opret.adgangskode = Console.ReadLine();*/
        }
    }
}
