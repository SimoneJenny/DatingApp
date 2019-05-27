using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace datingapp
{
    public class COSOE
    {
        public string kon { set; get; }
        public static void soge()
        {
            DOdelete ny = new DOdelete();

            string search;
            Console.WriteLine("Vælg køn: m for mand og k for kvinde og i for nævn ikke");
            Console.WriteLine("                                                   ");
            search = Console.ReadLine();
            {
                string findkon = "SELECT * FROM UserProfile WHERE sex LIKE @s";
                using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
                using (SqlDataAdapter adapter = new SqlDataAdapter(findkon, con))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@s", search);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);                
                    foreach (DataRow medlem in dataTable.Rows)
                    {
                        Console.Write("Userprofile ID:                   " );
                        Console.WriteLine(medlem["userProfileId"].ToString());
                        Console.Write("køn:                              "  );
                        Console.WriteLine(medlem["sex"].ToString());
                        Console.Write("Navn:                             ");
                        Console.WriteLine(medlem["fullname"].ToString());
                        Console.Write("Alder:                            " );
                        Console.WriteLine(medlem["alder"].ToString());
                        Console.Write("By:                               ");
                        Console.WriteLine(medlem["by"].ToString());
                        Console.Write("Om person:                        " );
                        Console.WriteLine(medlem["hvemerjeg"].ToString());
                        Console.Write("Søger:                            ");
                        Console.WriteLine(medlem["jegsoger"].ToString());
                        Console.Write("Interesse:                        ");
                        Console.WriteLine(medlem["Interesser"].ToString());
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine("                                 ");
                    }                  
                }
            } 
            
        }
       
}   }    
