using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp
{
    
    public class Menu
    {
        //private int id { get; set; }
        public Menu()
        {

           // COlogin login = new COlogin();
            do
            //while (login.userLogggedin() == false)
               // {
               // login.userLogin(); 
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("            VELKOMMEN TIL DATEME.com                  ");
                Console.WriteLine("         Du har nu følgende muligheder:               ");
                Console.WriteLine("        HUSK: at oprette en konto før bruger!         ");
                Console.WriteLine("                                                      ");
                Console.WriteLine("                                                      ");
                Console.WriteLine("For at oprette konto                        Tryk o    ");
                Console.WriteLine("For at oprette bruger fra konto             Tryk x    ");
                Console.WriteLine("For at slette konto                         Tryk d    ");
                Console.WriteLine("Søg person                                  Tryk s    ");
                Console.WriteLine("Tjek for match                              Tryk m    ");
                Console.WriteLine("update user                                 Tryk u    ");
                Console.WriteLine("------------------------------------------------------");

                char t = Convert.ToChar(Console.ReadLine());
                switch (t)
                {                  
                    case 'o':
                        COopretfunktion opretkonto = new COopretfunktion();
                        opretkonto.opretkonto();
                        break;
                    case 'd':
                        Deletemedlem medlem = new Deletemedlem();
                        medlem.deletemedlemmer();
                        break;
                    case 's':
                        Like.liked();
                        break;
                    case 'x':
                        COopretfunktion opret = new COopretfunktion();
                        opret.opretbruger();
                        break;
                    case 'm':
                        Match.match();
                        skriv.skrivtiletmedlem();
                        break;
                    case 'u':
                        Update update = new Update();
                        update.Updatemedlem();
                        break;
                } 
            }while (true) ;
        }

    }
}
