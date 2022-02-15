using System;

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
                Console.WriteLine("\nVälkommen till Huvudmenyn, väl ett av nedan alternativ! \n Kom ihåg att skapa din bag innan du kan börja spela:)");
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
                    LäggTillBag();


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

        public static void LäggTillBag() //Prompta användaren till att skapa en ny bag med klubbor.
        {
            Bag ny = new Bag();
            ny.klubba = new Klubba[14];
            
            Console.WriteLine("Döp din bag: ");
            ny.namn = Console.ReadLine();
            uint antalKlubbor = ReadUInt("Hur många klubbor vill du lägga till i bagen?: ");

            for (int i = 0; i < antalKlubbor; i++)
            {
                Console.WriteLine("#" + (i + 1) + "Namnge ny klubba: \n");
                ny.klubba[i].klubbNamn = (Console.ReadLine());


                Console.WriteLine("#" + (i + 1) + "Ange max längd som du slår med klubban: \n"); //Får felmeddelande när attribut för klubbans max och min längd ska lägga in i arrayn
                ny.klubba[i].maxLängd = int.Parse(Console.ReadLine());



                Console.WriteLine("#" + (i + 1) + "Ange minimum längd som du slår med klubban: \n");
                ny.klubba[i].minLängd = int.Parse(Console.ReadLine());


            }
            bagRegister = UtökaBagRegister(bagRegister, ny); //Lägger till bag sist i bagregister.
            SkrivUtBaglista();
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
            for (int i = 0; i < bagRegister.Length; i++) //loopa igenom bagregistret
            {
                Console.WriteLine(bagRegister.Length);
                Console.WriteLine("\n#" + i + "Bagnamn: " + bagRegister[i].namn);
                Console.WriteLine("Klubbor i baggen: " + bagRegister[i].klubba);

                /*for (int k = 0; k < bagRegister.Length; k++)
                {
                    Console.WriteLine("Klubba: " + bagRegister[i].klubbNamn + "denna klubbar går mellan " + bagRegister[i].minLängd + "-" + bagRegister[i].maxLängd + " m");
                }*/
                
                /*foreach (string klubba in bagRegister[i].klubbNamn)
                {
                    
                    Console.Write(klubba + "\t\t");
                }
                Console.Write("\nmin:");
                foreach (int minLängd in bagRegister[i].minLängd)
                {
                    Console.Write(minLängd + "\t\t");
                }
                Console.Write("\nmax:{0,3} ");
                foreach (int maxLängd in bagRegister[i].maxLängd)
                {
                    Console.Write(maxLängd + "\t\t");
                }*/
            }
        }

    }
    
}
