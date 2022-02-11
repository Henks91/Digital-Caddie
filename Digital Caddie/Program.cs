using System;

namespace Digital_Caddie
{
    class Program
    {
        static Bag[] bagRegister = new Bag[0];
        static void Main(string[] args)
        {
            Huvudmeny();


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
        }

        public static void LäggTillBag() //Prompta användaren till att skapa en ny bag.
        {
            Bag ny = new Bag();
            Console.WriteLine("Döp din bag: ");
            ny.namn = Console.ReadLine();
            uint antalKlubbor = ReadUInt("Hur många klubbor vill du lägga till i bagen?: ");
            ny.klubbNamn = new string[antalKlubbor];

            for (int i = 0; i < antalKlubbor; i++)
            {
                Console.WriteLine("#" + (i + 1) + "Namnge ny klubba: \n");
                ny.klubbNamn[i] = Console.ReadLine();
                Console.WriteLine("#" + (i + 1) + "Ange max längd som du slår med klubban: \n");
                ny.maxLängd[i] = int.Parse(Console.ReadLine());
                Console.WriteLine("#" + (i + 1) + "Ange minimum längd som du slår med klubban: \n");
                ny.minLängd[i] = int.Parse(Console.ReadLine());

            }
            bagRegister = UtökaBagRegister(bagRegister, ny); //Lägger till bag sist i bagregister.

        }
        public static Bag[] UtökaBagRegister(Bag[] lista, Bag ny)
        {
            Bag[] nyLista = new Bag[lista.Length + 1];
            for (int i = 0; i < lista.Length; i++)
                nyLista[i] = lista[i];
            nyLista[lista.Length] = ny;
            return nyLista;

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
            for (int i = 0; i < bagRegister.length; i++)
            {

            }

        }

    }
    
}
