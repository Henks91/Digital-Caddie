using System;
using System.IO;
using System.Linq;

namespace Digital_Caddie
{
    class Program
    {
        public static Bag[] bagRegister = new Bag[0];
        static void Main(string[] args)
        {
            //LaddaRegister();
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
                    SparaRegister();
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

            
            Console.WriteLine("Döp din bag: ");
            ny.namn = Console.ReadLine();
            uint antalKlubbor = ReadUInt("Hur många klubbor vill du lägga till i bagen?: ");
            
            for (int i = 0; i < antalKlubbor; i++)
            {

                Console.WriteLine("Namnge ny klubba: \n");
                ny.namnKlubba = Console.ReadLine();

                ny.maxLenght = ReadUInt("Ange maxlängd som du slår med klubban: ");

                ny.minLenght = ReadUInt("Ange minlängd som du slår med klubban: ");

                bagRegister = UtökaBagRegister(bagRegister, ny);
            }
            //bagRegister = UtökaBagRegister(bagRegister, ny); //Lägger till bag sist i bagregister.
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

                Console.WriteLine("\n#" + i + "Bagnamn: " + bagRegister[i].namn); // skriver ut namnet på baggen

                Console.WriteLine("klubbor i baggen: ");
                for (int k = 0; k < bagRegister.Length; k++) // loopa vi igenm "bagregistret med [i] samtidigt som vi inne i denna array looper igenom register "klubba" med [k]
                {
                    Console.Write(bagRegister[i].namnKlubba + "\t slår du mellan ");
                    Console.Write(bagRegister[i].minLenght + "-");
                    Console.Write(bagRegister[i].maxLenght + " meter\n");
                }

            }



        } //skriver ut listan "bagRegister" med alla klubbor + klubbornas attribut
        public static void LaddaRegister()
        {
            StreamReader infil = new StreamReader("Bagregister.txt");
            
            while (true)
            {
                string line = infil.ReadLine();
                if (line == null) 
                break;

                string[] split = line.Split('\t');

                Bag bag = new Bag();
                bag.namn = split[0];
                bag.namnKlubba = split[1];
                bag.minLenght = uint.Parse(split[2]); // OBS!
                bag.maxLenght = uint.Parse(split[3]);

                bagRegister = UtökaBagRegister(bagRegister, bag);
            }
            infil.Close();
        }
        public static void SparaRegister()
        {
            StreamWriter utfil = new StreamWriter("Bagregister.txt", false);

            for (int i = 0; i < bagRegister.Length; i++)
            {
                Bag bag = bagRegister[i];
                utfil.Write("{0}\t{1}\t{2}\t{3}",
                bag.namn,
                bag.namnKlubba, 
                bag.minLenght,
                bag.minLenght);
            }
            utfil.Close();

        }
        /*public static void Sort (int[] bagRegister) //Bubblesort metoden (får inte den att funka
        {
            
            for (int i = 0; i < bagRegister.Length;  i++){
                int minst = i;

                for (int j = i + 1; j < bagRegister.Length; j++){
                    if (bagRegister[minst] > bagRegister[j]){
                        minst = j;
                    }

                    if (bagRegister[j] > bagRegister[j + 1])
                    {
                        temp = bagRegister[j + 1];
                        bagRegister[j + 1] = bagRegister[j];
                        bagRegister[j] = temp;
                    }
                }
            }
        }*/
        /*public static void Sort(Bag[] bagRegister) // funktionen "Swap" kan ej hittas?
        {
            for (int i = 0; i < bagRegister.Length; i++)
            {
                int minst = i;
                for (int j = i + 1; j < bagRegister.Length; j++)
                {
                    if (bagRegister[minst] > bagRegister[j])
                    {
                        minst = j;
                    }
                }
                if (i < minst)
                {
                    Swap(bagRegister, minst, i);
                    Sort(bagRegister);
                }
            }
        }*/

    }
}
    



    





    


