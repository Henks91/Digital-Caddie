using System;

namespace Digital_Caddie
{

    class Program : Klubba 

    {

        
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Välkommen till Huvudmenyn, väl ett av nedan alternativ! \n Kom ihåg att skapa din bag innan du kan börja spela:)\n");
                Console.WriteLine("1. Spela Golf");
                Console.WriteLine("2. Skapa ny bag");
                Console.WriteLine("3. Mina bags");
                Console.WriteLine("4. Avsluta programmet");

                string användarInput = Console.ReadLine(); // in kontrollstrukturen från F3B - om användare mata in info annat än valen vi är ute efter

                if (användarInput == "1")
                {
                    Console.WriteLine("Dags att spela golf! \n Välj din bag för att komma igång.");

                    
                }
                else if (användarInput == "2")
                {
                    Console.WriteLine("Dags att skapa ny bag, kör hårt!");

                    SkapaNyBag.RegistreraNyBag();
                }
                else if (användarInput == "3")
                {
                    Console.WriteLine("Mina bags");
                    


                    //metod/funktion
                }
                else if (användarInput == "4")
                {
                    Console.WriteLine("Du har nu avslutat programmet, välkommen åter!");
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltligt val, välj mellan 1-4!");
                }
            }


        }

        private static void Nybag()
        {

        }

    
    }
}
