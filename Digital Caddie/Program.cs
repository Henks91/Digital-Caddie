using System;
using System.IO;

namespace Digital_Caddie
{
    class Program
    {
        public static Bag[] bagRegister = new Bag[0];
        static void Main(string[] args)
        {
            LaddaRegister();
            Huvudmeny();
            SparaRegister();

        }

        /// <summary>
        /// Menylista med felmeddelanden om input inte är = ett menyval.
        /// </summary>
        static void Huvudmeny()
        {

            while (true)
            {
                Console.WriteLine("\nVälkommen till Huvudmenyn, väl ett av nedan alternativ! \n Kom ihåg att skapa din bag innan du kan börja spela:)");
                Console.WriteLine("1. Skapa ny bag");
                Console.WriteLine("2. Lista alla bags");
                Console.WriteLine("3. Sortera bagregister enligt bagnamn");
                Console.WriteLine("4. Sortera bagregister enligt klubbnamn");
                Console.WriteLine("5. Sortera bagregister enligt min längd");
                Console.WriteLine("6. Sortera bagregister enligt max längd");
                Console.WriteLine("0. Avsluta programmet");

                string användarInput = Console.ReadLine();

                if (användarInput == "1")
                {
                    Console.WriteLine("Dags att skapa ny bag, kör hårt!");
                    LäggTillBag();
                }
                else if (användarInput == "2")
                {
                    Console.WriteLine("Lista bags");
                    SkrivUtBaglista(bagRegister);

                    while (true)
                    {
                        Console.WriteLine("\n21. Sök på bagnamn");
                        Console.WriteLine("22. Lägg till klubba");
                        Console.WriteLine("23. Ta bort Bag");
                        Console.WriteLine("0. Återgår till huvudmey\n");
                        string användarInput2 = Console.ReadLine();

                        if (användarInput2 == "21")
                        {
                            Console.WriteLine("Bagnamn enligt din sökning");
                            SökBag();

                        }
                        else if (användarInput2 == "22")
                        {
                            LäggTillKlubba();
                        }
                        else if (användarInput2 == "23")
                        {
                            RaderaBag();
                        }
                        else if (användarInput2 == "0")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltligt val, välj mellan 21-23!");
                        }
                    }
                }
                else if (användarInput == "3")
                {
                    Console.WriteLine("Sorterar bagregister enligt bagnamn");
                    SortBagNamn(bagRegister);
                }
                else if (användarInput == "4")
                {
                    Console.WriteLine("Sorterar bagregister enligt klubbnamn");
                    SortKlubbNamn(bagRegister);
                }
                else if (användarInput == "5")
                {
                    Console.WriteLine("Sorterar bagregister enligt MIN längd");
                    SortMinLängd(bagRegister);
                }
                else if (användarInput == "6")
                {
                    Console.WriteLine("Sorterar bagregister enligt MAX längd");
                    SortMaxLängd(bagRegister);
                }
                else if (användarInput == "0")
                {
                    Console.WriteLine("Du har nu avslutat programmet, välkommen åter!");
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltligt val, välj mellan 0-6!");
                }
            }
        }
        /// <summary>
        /// Prompta användaren till att skapa en ny bag med klubbor.
        /// Prompta användaren på värden för alla attributer.
        /// </summary>
        public static void LäggTillBag()
        {


            Console.WriteLine("Döp din bag: ");
            string bagnamn = Console.ReadLine();

            uint antalKlubbor = FelsökningFörEndastPossitivaTal("Hur många klubbor vill du lägga till i bagen?: ");


            for (int i = 0; i < antalKlubbor; i++)
            {
                Bag klubba = new Bag();
                Console.WriteLine("Namnge ny klubba: \n");
                klubba.namnKlubba = Console.ReadLine();

                klubba.maxLenght = FelsökningFörEndastPossitivaTal("Ange maxlängd som du slår med klubban: ");

                klubba.minLenght = FelsökningFörEndastPossitivaTal("Ange minlängd som du slår med klubban: ");

                klubba.bagNamn = bagnamn;

                bagRegister = UtökaBagRegister(bagRegister, klubba);
            }
            SkrivUtBaglista(bagRegister);
        }
        /// <summary>
        /// Här uttökas platsen i både array "bagRegister" och den tillfälliga array "bagträffar" som skapas vid sökning av bag.
        /// Vi skapar en ny array med X antal platser som vi promptar metoden med.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="ny"></param>
        /// <returns></returns>
        public static Bag[] UtökaBagRegister(Bag[] lista, Bag ny)
        {
            Bag[] nyLista = new Bag[lista.Length + 1];
            for (int i = 0; i < lista.Length; i++)
                nyLista[i] = lista[i];
            nyLista[lista.Length] = ny;
            return nyLista;

        }//ökar platsen för "BagRegister
        /// <summary>
        /// Här felsöks input från användaren när siffror ska matas in och skickar ett felmeddelande om input inte är ett possitivt tal.
        /// </summary>
        /// <param name="titel"></param>
        /// <returns></returns>
        public static uint FelsökningFörEndastPossitivaTal(string titel)
        {
            Console.WriteLine(titel);
            uint tal;
            while (!uint.TryParse(Console.ReadLine(), out tal))
            {
                Console.WriteLine("Måste vara ett possitivt tal! ");
                Console.WriteLine(titel);
            }

            return tal;
        }
        /// <summary>
        /// Listrubriker för utskrift av "bagRegister".
        /// Itererar hela längden av "bagRegister".
        /// </summary>
        /// <param name="bagRegister"></param>
        public static void SkrivUtBaglista(Bag[] bagRegister)
        {
            Console.WriteLine("Bag\tKlubba\tminL\tmaxL");
            for (int i = 0; i < bagRegister.Length; i++)
            {
                SkrivUtBag(bagRegister[i]);
            }

        }
        /// <summary>
        /// Skriver ut befintlig array "bagRregister" med alla olika attributer.
        /// </summary>
        /// <param name="klubba"></param>
        public static void SkrivUtBag(Bag klubba)
        {
            Console.WriteLine(klubba.bagNamn + "\t" + klubba.namnKlubba + "\t" + klubba.minLenght + "\t" + klubba.maxLenght);
        }

        /// <summary>
        /// skriver ut listan "bagRegister" med alla klubbor + klubbornas attribut
        /// </summary>
        public static void LaddaRegister()
        {
            StreamReader infil = new StreamReader("Bagregister.txt");
            string rad;
            while ((rad = infil.ReadLine()) != null)
            {
                string[] split = rad.Split('\t'); //Felet är att när vi laddar infil och splittar så laddas hela listan på en o samam gång, ska bara ladda fyra attribut åt gången från klass Bag
                Bag klubba = new Bag();
                klubba.bagNamn = split[0];
                klubba.namnKlubba = split[1];
                klubba.minLenght = uint.Parse(split[2]);
                klubba.maxLenght = uint.Parse(split[3]);

                bagRegister = UtökaBagRegister(bagRegister, klubba);
            }
            infil.Close();
        }
        /// <summary>
        /// Sparar ner den nya array "bagRegister" som har skapats till "Bagregister.txt" i rätt 
        /// ordning för att kunna ladda upp i "LaddaRegister" igen när nästa program körs.
        /// </summary>
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

        }
        /// <summary>
        /// Stöttningsmetod för att exchangesort ska fungera
        /// </summary>
        /// <param name="bagRegister"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
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
        /// <summary>
        /// Promptar användaren på en inout som blir "sökord".
        /// Loopar igenom bagRegister.bagNamn på "sökord" och om träff hittas påkallas "UttökaBagRegister" 
        /// metod som adderar array bagträffar med antalet träffar av sökord.
        /// Felmeddelande om "sökord" inte finns i array "bagRegister.bagNamn".
        /// </summary>
        public static void SökBag()
        {
            Console.WriteLine("Sök på bag: ");
            string sökord;
            sökord = Console.ReadLine();
            Bag[] bagträffar = new Bag[0];
            bool innehåller = false;
            for (int i = 0; i < bagRegister.Length; i++)
            {
                if (bagRegister[i].bagNamn.ToLower().Contains(sökord.ToLower()))
                {
                    bagträffar = UtökaBagRegister(bagträffar, bagRegister[i]);
                    innehåller = true;
                }
            }
            if (innehåller == true)
            {
                SkrivUtBaglista(bagträffar);
            }
            else
            {
                Console.WriteLine("Din sökning gav ingen träff");
            }

        }
        /// <summary>
        /// Den här funktion söker fram en bag som användaren promtar.
        /// Om träff, returnera sökord och hoppa ur metod.
        /// Om ingen, träff returnera null.
        /// </summary>
        /// <param name="sökord"></param>
        /// <returns></returns>
        public static Bag SökningBag(string sökord)
        {

            for (int i = 0; i < bagRegister.Length; i++)
            {

                if (bagRegister[i].bagNamn.ToLower().Contains(sökord.ToLower()))
                {
                    return bagRegister[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Här adderar vi så många klubbor användaren vill till valfri bag.
        /// Namnger klubbor och anger längder för klubborna.
        /// </summary>
        public static void LäggTillKlubba()
        {
            Console.WriteLine("I vilken bag vill du lägga till klubban till? ");
            string bagnamn = Console.ReadLine();

            uint antalKlubbor = FelsökningFörEndastPossitivaTal("Hur många klubbor vill du lägga till i bagen?: ");


            for (int i = 0; i < antalKlubbor; i++)
            {
                Bag klubba = new Bag();
                Console.WriteLine("Namnge ny klubba: \n");
                klubba.namnKlubba = Console.ReadLine();

                klubba.maxLenght = FelsökningFörEndastPossitivaTal("Ange maxlängd som du slår med klubban: ");

                klubba.minLenght = FelsökningFörEndastPossitivaTal("Ange minlängd som du slår med klubban: ");

                klubba.bagNamn = bagnamn;

                bagRegister = UtökaBagRegister(bagRegister, klubba);
            }

        }
        /// <summary>
        /// Input från "RaderaBag" söker igenom bagRegister array och om träff så påkallas metod "MinskaBagRegister"
        /// </summary>
        /// <param name="a"></param>
        public static void TaBortBag(Bag a)
        {
            for (int i = 0; i < bagRegister.Length; i++)
            {

                if (bagRegister[i] == a)
                {
                    MinskaBagRegister(i);
                    return;
                }
            }
        }
        /// <summary>
        /// Här frågas användaren om vilken bag som ska raderas från array bagRegister.
        /// Input från användaren skickas till "TaBortBag" metod 
        /// </summary>
        public static void RaderaBag()
        {
            Console.WriteLine("Ange baggen du vill radera");
            string bag = Console.ReadLine();
            Bag a = SökningBag(bag);

            if (a == null)
            {
                Console.WriteLine("Bagnamnet finns inte");
                return;
            }
            TaBortBag(a);
        }
        /// <summary>
        /// Här söks array bagRegister igenom i iterationer med inehållande input från "RaderaBag" och tar reda på indexposition i bagRegister. 
        /// Skapar ny array utan indexpositionen från föregående iteration av användarens input.
        /// </summary>
        /// <param name="temp"></param>
        public static void MinskaBagRegister(int temp)
        {
            Bag[] tfl = new Bag[bagRegister.Length - 1];

            for (int i = 0; i < temp; i++)
            {
                tfl[i] = bagRegister[i];
            }
            for (int i = temp + 1; i < bagRegister.Length; i++)
            {
                tfl[i - 1] = bagRegister[i];
            }
            bagRegister = tfl;
        }

    }
}













