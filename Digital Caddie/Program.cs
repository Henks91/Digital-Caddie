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
            ny.klubbor = new Klubbor[14];

            Console.WriteLine("Döp din bag: ");
            ny.namn = Console.ReadLine();
            uint antalKlubbor = ReadUInt("Hur många klubbor vill du lägga till i bagen?: ");

            for (int i = 0; i < antalKlubbor; i++)
            {

                ny.klubbor[i] = new Klubbor();

                //Får felmeddelande när attribut för klubbans namn,max och min längd ska lägga in i arrayn. Den vill inte köpa attributen.
                Console.WriteLine("#" + (i + 1) + "Namnge ny klubba: \n");
                ny.klubbor[i].klubbNamn = Console.ReadLine();


                Console.WriteLine("#" + (i + 1) + "Ange max längd som du slår med klubban: \n");
                ny.klubbor[i].maxLängd = int.Parse(Console.ReadLine());



                Console.WriteLine("#" + (i + 1) + "Ange minimum längd som du slår med klubban: \n");
                ny.klubbor[i].minLängd = int.Parse(Console.ReadLine());


            }
            bagRegister = UtökaBagRegister(bagRegister, ny); //Lägger till bag sist i bagregister.
            SkrivUtBaglista(bagRegister);

        }
        public static Bag[] UtökaBagRegister(Bag[] lista, Bag ny)
        {
            Bag[] nyLista = new Bag[lista.Length + 1];
            for (int i = 0; i < lista.Length; i++)
                nyLista[i] = lista[i];
            nyLista[lista.Length] = ny;
            return nyLista;

        }//ökar platsen för "BagRegister
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
        } // felsökningskod för endast possitiva tal

        public static void SkrivUtBaglista(Bag[] bagRegister)
        {
            Console.WriteLine("Utskrift av bagregister: \n");
            for (int i = 0; i < bagRegister.Length; i++) //loopa igenom bagregistret
            {
                Console.WriteLine(bagRegister.Length);
                Console.WriteLine("\n#" + i + "Bagnamn: " + bagRegister[i].namn); // skriver ut namnet på baggen


                Console.WriteLine("klubbor i baggen: ");
                for (int k = 0; k < bagRegister[i].klubbor.Length; k++) // loopa vi igenm "bagregistret med [i] samtidigt som vi inne i denna array looper igenom register "klubba" med [k]
                {
                    if (bagRegister[i].klubbor[k] == null)

                        break;
                    Console.Write(bagRegister[i].klubbor[k].klubbNamn + "\t slår du mellan ");
                    Console.Write(bagRegister[i].klubbor[k].minLängd + "-");
                    Console.Write(bagRegister[i].klubbor[k].maxLängd + " meter\n");

                }

            }


        } //skriver ut listan "bagRegister" med alla klubbor + klubbornas attribut

    }

}
