using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    public class SkapaNyBag
    {
        public string namnBag;
        public static SkapaNyBag[] bagLista = new SkapaNyBag[0];
        Klubba klubblista;
    
    
         //kanske skapa listan här ist...
         /// <summary>
         /// namnBag har hamnat i listaBag, nästa steg är att få in klubblista bag. Påkalla metod för klubblista.
         /// </summary>
        public static void RegistreraNyBag()
        {

            
            SkapaNyBag[] bag = new SkapaNyBag[bagLista.Length + 1]; // adderar en plats för en nya bag
            SkapaNyBag a = new SkapaNyBag();
            
            Console.WriteLine("Vad vill du att din bag ska heta?: ");
            string namn = Console.ReadLine();
            a.namnBag = namn;
            
             
            for (int i = 0; i < bagLista.Length; i++) // taget från Annas Wather kod där hon adderar en plats i listan för att skapa väder information
            {

                bag[i] = bagLista[i];

                break;
                
            }
            bag[bagLista.Length] = a;
            bagLista = bag;
            Klubba.LäggTillKlubbaTillKlubblista();
            
            foreach (SkapaNyBag namnBag in bag)
                {
                Console.WriteLine(namnBag);
                
                }
            //ClassKlubba.Test();
        }
    }
    
}
