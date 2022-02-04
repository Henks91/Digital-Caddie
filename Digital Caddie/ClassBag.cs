using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    public class ClassBag
    {
        public string namnBag;

        ClassKlubba klubblista;
    
    
         //kanske skapa listan här ist...
        public static void TestT()
        {

            //int antalBag = 0;
            
            ClassBag[] baglista = new ClassBag[5];
            ClassBag klubba = new ClassBag();

            Console.WriteLine("Vad vill du att denna bagen ska heta? ");
            klubba.namnBag = Console.ReadLine();
            //Console.WriteLine("Hur många bags vill du skapa? ");
            //antalBag = int.Parse(Console.ReadLine());
            //Console.WriteLine("Vad vill du att denna bagen ska heta? ");
            //string namnBag = Console.ReadLine();

            for (int b = 0; b <= 1; b++)
            {


                baglista[b] = klubba;

                ClassKlubba.Test();
                break;

            }      
            
            Console.WriteLine(klubba.namnBag);
              foreach (ClassBag m in baglista)
                {  
                Console.WriteLine(m);
                break;
                }
            //ClassKlubba.Test();
        }
    }
    
}
