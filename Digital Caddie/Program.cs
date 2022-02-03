using System;

namespace Digital_Caddie
{

    class Program : ClassKlubba
    {


        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Välkommen till Huvudmenyn, väl ett av nedan alternativ! \n Kom ihåg att skapa din bag innan du kan börja spela:)");
                Console.WriteLine("1. Spela Golf");
                Console.WriteLine("2. Skapa ny bag");
                Console.WriteLine("3. Mina bags");
                Console.WriteLine("4. Avsluta programmet");

                string användarInput = Console.ReadLine();

                if (användarInput == "1")
                {
                    Console.WriteLine("Dags att spela golf! \n Välj din bag för att komma igång.");
                    //kalla på funktion/metod
                }
                else if (användarInput == "2")
                {
                    Console.WriteLine("Dags att skapa ny bag, kör hårt!");

                    //static void Nybag()
                    {
                        //int distans;
                        //int antal;
                        //string[] Klubblista = new string [antal];
                        //int[] Längd = new int [antal];

                        //string typAvKlubba;

                        Console.WriteLine("Hur många klubbor vill du registrera? ");
                        int antal = int.Parse(Console.ReadLine());
                        string[] Klubblista = new string[antal];
                        int[] Längd = new int[antal];
                        for (int i = 0; i < antal; i++)
                        {

                            Console.WriteLine("Vad vill du namnge denna klubban? ");
                            Klubblista[i] = Console.ReadLine();

                            Console.WriteLine("Hur långt slår du med denna klubban? ");
                            Längd[i] = int.Parse(Console.ReadLine());

                        }
                        foreach (var iteam in Klubblista)
                        {
                            Console.WriteLine("Listan innehåller nu:", iteam);
                        }
                        foreach (var iteam in Längd)
                        {
                            Console.WriteLine("Listan innehåller nu:", iteam);
                        }
                    }


                }
                else if (användarInput == "3")
                {
                    Console.WriteLine("Mina bags");
                    Test();


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

