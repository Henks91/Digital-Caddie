using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Digital_Caddie
{
    class Program
    {
        public static Bag[] bagRegister = new Bag[0];
        static void Main(string[] args)
        {
            LaddaRegister();
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
                    Sort(bagRegister);
                    SkrivUtBaglista(bagRegister);

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
            
            
            Console.WriteLine("Döp din bag: ");
            string bagnamn = Console.ReadLine();

            uint antalKlubbor = ReadUInt("Hur många klubbor vill du lägga till i bagen?: ");


            for (int i = 0; i < antalKlubbor; i++)
            {
                Bag klubba = new Bag();
                Console.WriteLine("Namnge ny klubba: \n");
                klubba.namnKlubba = Console.ReadLine();
                
                klubba.maxLenght = ReadUInt("Ange maxlängd som du slår med klubban: ");

                klubba.minLenght = ReadUInt("Ange minlängd som du slår med klubban: ");

                klubba.bagNamn = bagnamn;

                bagRegister = UtökaBagRegister(bagRegister, klubba);
            }
            //bagRegister = UtökaBagRegister(bagRegister, ba); //Lägger till bag sist i bagregister.
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
            Console.WriteLine("Bag\tKlubba\tminL\tmaxL");
            for (int i = 0; i < bagRegister.Length; i++)
            {
                SkrivUtBag(bagRegister[i]);
            }

        }
        public static void SkrivUtBag(Bag klubba) 
        {
            Console.WriteLine(klubba.bagNamn + "\t" + klubba.namnKlubba + "\t" + klubba.minLenght + "\t" + klubba.maxLenght);
        }
        
        //skriver ut listan "bagRegister" med alla klubbor + klubbornas attribut
        public static void LaddaRegister()
        {
            StreamReader infil = new StreamReader("Bagregister.txt");
            string rad;
            while ((rad = infil.ReadLine()) !=null)
            {
                //string line = infil.ReadLine();
                //if (line == null) //förhindrar att programmet läser tomma rader i all oändlighet.
                //break;
                
                string[] split = rad.Split('\t'); //Felet är att när vi laddar infil och splittar så laddas hela listan på en o samam gång, ska bara ladda fyra attribut åt gången från klass Bag

                Bag klubba = new Bag();
                klubba.bagNamn = split[0];
                klubba.namnKlubba = split[1];
                klubba.minLenght = uint.Parse(split[2]); 
                klubba.maxLenght = uint.Parse(split[3]);

                bagRegister = UtökaBagRegister(bagRegister, klubba);
            }
            infil.Close();
        } // Ladda ner TXT-filen 
        public static void SparaRegister()
        {
            StreamWriter utfil = new StreamWriter("Bagregister.txt", false);

            for (int i = 0; i < bagRegister.Length; i++)
            {
                Bag bag = bagRegister[i];
                utfil.Write("{0}\t{1}\t{2}\t{3}\n",
                bag.bagNamn,
                bag.namnKlubba, 
                bag.minLenght,
                bag.maxLenght);
            }
            utfil.Close();

        } // Spara till TXT-filen
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
        public static void Swap(Bag[] bagRegister, int a, int b)
        {
            Bag tfl = bagRegister[a];
            bagRegister[a] = bagRegister[b];
            bagRegister[b] = tfl;
        }
        public static void Sort(Bag[] bagRegister) //sorteringsmetod = exchange sort
        {
            for (int i = 0; i < bagRegister.Length; i++)
            {
                int lägst = i;
                for (int k = i + 1; k < bagRegister.Length; k++)
                {
                    if (bagRegister[lägst].bagNamn.CompareTo(bagRegister[k].bagNamn) > 0)
                    {
                        lägst = k;
                    }
                }
                if (i < lägst)
                {
                    Swap(bagRegister, lägst, i);
                    
                }
            }
        }

    }
}
    



    





    


