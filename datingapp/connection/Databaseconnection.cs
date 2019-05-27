using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp
{
    public class dbconnection
    {
        private static readonly string _con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=simone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string ConnectionDB()
        {
            return _con;
            
        }     
    }
}
