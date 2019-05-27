using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp
{
    public class Returninfo
    {
        
        public static void returninfo() //biver ikke brugt
        {
            DOOPRET returninfo = new DOOPRET();
            Console.WriteLine("Du har rettet følgende:" + returninfo.sex + returninfo.ditfuldenavn + "," + returninfo.alder + ","
                 + returninfo.by + "," + returninfo.hvemerjeg + "," + returninfo.soger + "," + returninfo.interesser);
        }
    }
}
