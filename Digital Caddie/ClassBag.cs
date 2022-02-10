using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    public class ClassBag
    {
        public string namnBag;
        public static ClassBag[] bagLista = new ClassBag[0];
        ClassKlubba klubblista;
    
    
         //kanske skapa listan här ist...
        public static void TestT()
        {

            //int antalBag = 0;
            
            ClassBag[] bag = new ClassBag[bagLista.Length + 1]; // adderar en plats för en nya bag
            ClassBag klubba = new ClassBag();

            Console.WriteLine("Vad vill du att din bag ska heta?: ");
            klubba.namnBag = Console.ReadLine();
            //Console.WriteLine("Hur många bags vill du skapa? ");
            //antalBag = int.Parse(Console.ReadLine());
            //Console.WriteLine("Vad vill du att denna bagen ska heta? ");
            //string namnBag = Console.ReadLine();

            for (int i = 0; i < bagLista.Length; i++) // taget från Annas Wather kod där hon adderar en plats i listan för att skapa väder information
            {


                bag[i] = bagLista[i];

                ClassKlubba.Test();
                break;

            }      
            
            Console.WriteLine(klubba.namnBag);
              foreach (ClassBag m in bag)
                {  
                Console.WriteLine(m);
                break;
                }
            //ClassKlubba.Test();
        }
    }
    
}
