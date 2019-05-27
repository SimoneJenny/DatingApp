using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Databaseconnection
    {
        public class dbconnection
        {
            // HUSK AT ÆNDR
            private static readonly string _conJ = @"Data Source=SKAB1-PC-07\JOAKIMFKK;Initial Catalog=DatingDB;Integrated Security=True";
            private static readonly string _conS= @"Data Source=SKAB1-PC-11\SIMONE;Initial Catalog=DatingDB;Integrated Security=True";
            public static string ConnectionDB()
            {
                return _conS;

            }
            
        }
    }
}
