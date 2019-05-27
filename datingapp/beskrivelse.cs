using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp
{
    public class beskrivelse
    {
       
        public static void indsaetfeler()
        {
            string kon;
            Console.WriteLine("Køn: ");
            kon =Console.ReadLine();
            Console.WriteLine("alder:");
            int alder;
            alder = Convert.ToInt32(Console.ReadLine());
            string jegsoger;
            Console.WriteLine("jeg søger: ");
            jegsoger = Console.ReadLine();
            string interesser;
            Console.WriteLine("Mine interesser:");
            interesser = Console.ReadLine();
        }

    }
}
