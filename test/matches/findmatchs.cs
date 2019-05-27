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
   public class findmatchs
    {
        public static void find()
        {
            string DB = "SELECT receiver FROM [Match]";
            using (SqlConnection con = new SqlConnection(dbconnection.ConnectionDB()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(DB, con))
            {
                con.Open();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow medlem in dataTable.Rows)
                {
                    Console.WriteLine(medlem["receiver"].ToString());
                }
            }
        }
    }
}
