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
                Console.WriteLine("3. Lista alla bags");
                Console.WriteLine("4. Sortera bagregister enligt bagnamn");
                Console.WriteLine("5. Sortera bagregister enligt klubbnamn");
                Console.WriteLine("6. Sortera bagregister enligt min längd");
                Console.WriteLine("7. Sortera bagregister enligt max längd");
                Console.WriteLine("0. Avsluta programmet");

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
                    Console.WriteLine("Lista bags");
                    SkrivUtBaglista(bagRegister);

                    while (true)
                    {
                        Console.WriteLine("\n31. Sök på bagnamn");
                        Console.WriteLine("32. Sök på klubba");
                        Console.WriteLine("33. Sök på Längd");
                        Console.WriteLine("34. Lägg till klubba");
                        Console.WriteLine("35. Ta bort Bag");
                        Console.WriteLine("0. Återgår till huvudmey\n");
                        string användarInput2 = Console.ReadLine();

                        if (användarInput2 == "31")
                        {
                            Console.WriteLine("Bagnamn enligt din sökning");
                            SökBag();

                        }
                        else if (användarInput2 == "34")
                        {
                            LäggTillKlubba();
                        }
                        else if (användarInput2 == "35")
                        {
                            RaderaBag();
                        }
                        else if (användarInput2 == "0")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltligt val, välj mellan 31-35!");
                        }
                    }
                    /*
                     * Skapa ny menyval för 
                     * 3.Lägg till klubba
                     * 4.Ta bort klubba
                     * 5.Sök på längd
                     * 6.Sök på bagnamn
                    */


                }
                else if (användarInput == "4")
                {
                    Console.WriteLine("Sorterar bagregister enligt bagnamn");
                    SortBagNamn(bagRegister);
                }
                else if (användarInput == "5")
                {
                    Console.WriteLine("Sorterar bagregister enligt klubbnamn");
                    SortKlubbNamn(bagRegister);
                }
                else if (användarInput == "6")
                {
                    Console.WriteLine("Sorterar bagregister enligt MIN längd");
                    SortMinLängd(bagRegister);
                }
                else if (användarInput == "7")
                {
                    Console.WriteLine("Sorterar bagregister enligt MAX längd");
                    SortMaxLängd(bagRegister);
                }
                else if (användarInput == "0")
                {
                    Console.WriteLine("Du har nu avslutat programmet, välkommen åter!");
                    SparaRegister();
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltligt val, välj mellan 0-7!");
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
            while ((rad = infil.ReadLine()) != null)
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
        public static void SortBagNamn(Bag[] bagRegister) //sorteringsmetod = exchange sort
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
            SkrivUtBaglista(bagRegister);
        }
        public static void SortKlubbNamn(Bag[] bagRegister) //sorteringsmetod = exchange sort
        {
            for (int i = 0; i < bagRegister.Length; i++)
            {
                int lägst = i;
                for (int k = i + 1; k < bagRegister.Length; k++)
                {
                    if (bagRegister[lägst].namnKlubba.CompareTo(bagRegister[k].namnKlubba) > 0)
                    {
                        lägst = k;
                    }
                }
                if (i < lägst)
                {
                    Swap(bagRegister, lägst, i);

                }
            }
            SkrivUtBaglista(bagRegister);
        }
        public static void SortMinLängd(Bag[] bagRegister) //sorteringsmetod = exchange sort
        {
            for (int i = 0; i < bagRegister.Length; i++)
            {
                int lägst = i;
                for (int k = i + 1; k < bagRegister.Length; k++)
                {
                    if (bagRegister[lägst].minLenght.CompareTo(bagRegister[k].minLenght) > 0)
                    {
                        lägst = k;
                    }
                }
                if (i < lägst)
                {
                    Swap(bagRegister, lägst, i);

                }
            }
            SkrivUtBaglista(bagRegister);
        }
        public static void SortMaxLängd(Bag[] bagRegister) //sorteringsmetod = exchange sort
        {
            for (int i = 0; i < bagRegister.Length; i++)
            {
                int lägst = i;
                for (int k = i + 1; k < bagRegister.Length; k++)
                {
                    if (bagRegister[lägst].maxLenght.CompareTo(bagRegister[k].maxLenght) < 0)
                    {
                        lägst = k;
                    }
                }
                if (i < lägst)
                {
                    Swap(bagRegister, lägst, i);

                }
            }
            SkrivUtBaglista(bagRegister);
        }
        public static void SökBag()
        {
            Console.WriteLine("Sök på bag: ");

            string sökord = Console.ReadLine();
            Bag[] bagträffar = HämtaBag(sökord);
            SkrivUtBaglista(bagträffar);
            /*
             * Behöver vi en metod som skriver ut "inga träffar" om vi inte får en träff i listan
            */
      
        }
        public static Bag[] SökningBag(string sökord)
        {
            Bag[] hittadeBags = new Bag[bagRegister.Length];
            int antalBags = 0;
            for (int i = 0; i < bagRegister.Length; i++)
            {
                
                if (bagRegister[i].bagNamn.ToLower().Contains(sökord.ToLower()))
                {
                    hittadeBags[antalBags++] = bagRegister[i];
                }
            }

            Bag[] hittadeBagsSkalad = new Bag[antalBags];
            for (int i = 0; i < antalBags; i++)
            {
                hittadeBagsSkalad[i] = hittadeBags[i];
            }
            return hittadeBagsSkalad;
        }
        public static Bag[] HämtaBag(string bagNamn)
        {
            
            Bag[] bagträffar = new Bag[0];
            for (int i = 0; i < bagRegister.Length; i++)
            {
                if (bagRegister[i].bagNamn.Equals(bagNamn))
                {
                    bagträffar = UtökaBagRegister(bagträffar, bagRegister[i]);
                }
            }
            return bagträffar;
        }
        public static void LäggTillKlubba()
        {
            Console.WriteLine("I vilken bag vill du lägga till klubban till? ");
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

        }
        public static void TaBortBag(Bag[] a)
        {
            for (int i = 0; i < bagRegister.Length; i++)
            {
                
                if (bagRegister[i] == a[i])
                {
                    MinskaBagRegister(i); //måste förvandla variabeln till en array
                    return;
                }
            }
        }
        public static void RaderaBag()
        {
            Console.WriteLine("Ange baggen du vill radera");
            string bag = Console.ReadLine();
            Bag[] a = SökningBag(bag);
                        
            if (a == null)
            {
                Console.WriteLine("Bagnamnet finns inte");
                return;
            }
            TaBortBag(a);
        }
        public static void MinskaBagRegister(int[] temp)
        {
            Bag[] tfl = new Bag[bagRegister.Length - 1];

            for (int i = 0; i < temp.Length; i++)
            {
                tfl[i] = bagRegister[i];
            }
            for (int i = temp.Length + 1; i < bagRegister.Length; i++)
            {
                tfl[i - 1] = bagRegister[i];
            }
            bagRegister = tfl;
        }
        
    }
}
    



    





    


