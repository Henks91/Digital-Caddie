using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    class ClassKlubba
    {


        public class KlubbInfo
        {
            
            public string typAvKlubba;
            public int längd;

        }

        public static void Test()
        {
            //Bag klubba = new Bag();
            
            KlubbInfo[] klubblista = new KlubbInfo[14];
            int antal = 0;
            //Console.WriteLine("Namge din Bag: ");
            //Bag namnbag = new Bag();
            //klubba.bagNamn = Console.ReadLine();
             
            Console.WriteLine("Hur många klubbor vill du registrera? ");
            antal = int.Parse(Console.ReadLine());
            KlubbInfo[] klubbantal = new KlubbInfo[antal];
            for (int i = 0; i < antal; i++)
            {
                KlubbInfo info = new KlubbInfo();
                

                Console.WriteLine("Vad är det för typ av klubba du vill lägga till, namge den valfritt! ");
                info.typAvKlubba = Console.ReadLine();
                Console.WriteLine("Hur långt slår du med denna klubban? ");
                info.längd = int.Parse(Console.ReadLine());


                //någonting som lägger till input i lista              

                klubblista[i] = info;
                
                //Console.WriteLine($"{info.längd} {info.typAvKlubba}");
            }

            
                for (int i = 0; i < antal; i++)
                {
                    
                    Console.WriteLine("Namn: " + klubblista[i].typAvKlubba + "\nDistans: "+ klubblista[i].längd,"\n");

                }

            
            
        }

        
    }
}
