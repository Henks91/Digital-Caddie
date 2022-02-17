using System;
using System.IO;

namespace Digital_Caddie
{
    class Program
    {
        static Bag[] bagRegister = new Bag[0];

        static void Main(string[] args)
        {
            Huvudmeny();
            SkrivUtBaglista();


        }
        static void Huvudmeny()
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

                }
                else if (användarInput == "2")
                {
                    Console.WriteLine("Dags att skapa ny bag, kör hårt!");
                    Skapabag();
                    //Läggtillklubbor();
                }

                else if (användarInput == "3")
                {
                    Console.WriteLine("Mina bags");

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


            static void Skapabag()
            {
                Console.WriteLine("Döp din bag: ");
                string namn = Console.ReadLine();
                Bag[] bagRegister = new Bag[0];
                Console.WriteLine("Hur många klubbor vill du lägga till i bagen?: \n");
                int antalKlubbor = int.Parse(Console.ReadLine());
                for (int b = 0; b < antalKlubbor; b++)  //while loop för att promta användaren att skapa bag om listan är tom?
                {
                    bagRegister[b] = Läggtillklubbor();
                }
            }

            //Behöver nedan metod bakas in i ovan metod istället? 
            static Bag Läggtillklubbor() //Prompta användaren till att skapa en ny bag med klubbor.  
            {
                Bag ny = new Bag();
                Console.WriteLine("Namge denna klubban: \n");
                ny.klubba[0].klubbNamn = Console.ReadLine();  //fel här när man ska lägga till input till array
                Console.WriteLine("Ange max längd du slår med denna klubban: \n");
                ny.klubba[0].maxLängd = int.Parse(Console.ReadLine());
                Console.WriteLine("Ange minimum längd du slår med denna klubban: \n");
                ny.klubba[0].minLängd = int.Parse(Console.ReadLine());
                return ny;
            }
        }


        public static void UtökaBagRegister(Bag[] lista, Bag ny)
        {
            Bag[] nyLista = new Bag[lista.Length + 1];
            for (int i = 0; i < lista.Length; i++)
                nyLista[i] = lista[i];
            nyLista[lista.Length] = ny;


        }
        public static uint ReadUInt(string label)
        {
            Console.WriteLine(label);
            uint tal;
            while (!uint.TryParse(Console.ReadLine(), out tal))
            {
                Console.WriteLine("Måste vara ett possitivt tal! ");
                Console.WriteLine(label);
            }
            return tal;
        }

        public static void SkrivUtBaglista()
        {
            Console.WriteLine("Utskrift av bagregister: \n");
            for (int i = 0; i < bagRegister.Length; i++) //loopa igenom bagregistret
            {
                Console.WriteLine(bagRegister.Length);
                Console.WriteLine("\n#" + i + "Bagnamn: " + bagRegister[i].namn);
                Console.WriteLine("Klubbor i baggen: ");

                /*for (int k = 0; k < bagRegister.Length; k++)
                {
                    Console.WriteLine("Klubba: " + bagRegister[i].klubbNamn + "denna klubbar går mellan " + bagRegister[i].minLängd + "-" + bagRegister[i].maxLängd + " m");
                }*/
                /*foreach (string klubba in bagRegister[i].klubbNamn)
                {
                    Console.WriteLine(klubba );
                }*/
            }

        }
    }
}

    
    

