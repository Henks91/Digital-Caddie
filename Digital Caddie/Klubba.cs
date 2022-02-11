using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    class Klubba
    {
    
        public string typAvKlubba;
        public int maxLängd;
        public int minLängd;
        
       
        public static void LäggTillKlubbaTillKlubblista()
        {
            
            Klubba[] klubblista = new Klubba[14];
            int antal = 0;
            
            Console.WriteLine("Hur många klubbor vill du registrera? ");
            antal = int.Parse(Console.ReadLine());
            for (int i = 0; i < antal; i++)
            {
                Klubba infoKlubba = new Klubba();
                

                Console.WriteLine("Vad är det för typ av klubba du vill lägga till, namge den valfritt! ");
                infoKlubba.typAvKlubba = Console.ReadLine(); //lägg in kontrollstrukturen från F3B - om användare mata in info annat än valen vi är ute efter
                Console.WriteLine("Skriv in max längd du slår med denna klubba: ");
                infoKlubba.maxLängd = int.Parse(Console.ReadLine()); //lägg in kontrollstrukturen från F3B - om användare mata in info annat än valen vi är ute efter
                Console.WriteLine("Skriv in minimum längd du slår med denna klubba: ");
                infoKlubba.minLängd = int.Parse(Console.ReadLine());

                //någonting som lägger till input i lista              

                klubblista[i] = infoKlubba;
                
            }

            
                for (int i = 0; i < antal; i++)
                {
                    
                Console.WriteLine("Namn: " + klubblista[i].typAvKlubba + "\nMax längd: "+ klubblista[i].maxLängd + "\nMinimum Längd: " + klubblista[i].minLängd + "\n");

                }

            
            
        }

        
    }
}
