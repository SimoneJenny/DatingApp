using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp
{
    public class DOupdate
    {
        public string adgangskode { set; get; }
        public string email { set; get; }
        public string id { set; get; }
        public string hvemerjeg { get; set; } = "Ikke nævnt";
        public string ditfuldenavn { get; set; } = "Ikke nævnt";
        public int alder { get; set; } = 18; //grænse for app
        public string by { get; set; } = "Ikke nævnt";
        public string soger { get; set; } = "Ikke nævnt";
        public string interesse { get; set; } = "Ikke nævnt";
        public string kon { get; set; } = "I";
        public int modtager { get; set; }
        public int sender { get; set; }
        public string read { get; set; }
    }
}
