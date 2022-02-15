using System;


namespace Digital_Caddie
{
    class Program
    {
        static void Main(string[] args)
        {
            Huvudmeny();
            SkrivUtBaglista(bagRegister);

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

        public static void LäggTillBag() //Prompta användaren till att skapa en ny bag med klubbor.
        {
            Bag ny = new Bag();
            Console.WriteLine("Döp din bag: ");
            ny.namn = Console.ReadLine();
            Console.WriteLine("Hur många klubbor vill du lägga till i bagen?: ");
                ny.klubbNamn = Console.ReadLine();
            ny.maxLängd = new int[antalKlubbor];
            ny.minLängd = new int[antalKlubbor];
            for (int i = 0; i < antalKlubbor; i++)
            {
                Console.WriteLine("#" + (i + 1) + "Namnge ny klubba: \n");
                ny.klubbNamn[i] = Console.ReadLine();

                
                Console.WriteLine("#" + (i + 1) + "Ange max längd som du slår med klubban: \n"); //Får felmeddelande när attribut för klubbans max och min längd ska lägga in i arrayn
                ny.maxLängd[i] = int.Parse(Console.ReadLine());
                
                
                
                Console.WriteLine("#" + (i + 1) + "Ange minimum längd som du slår med klubban: \n");
                ny.minLängd[i] = int.Parse(Console.ReadLine());
                

            }
            bagRegister = UtökaBagRegister(bagRegister, ny); //Lägger till bag sist i bagregister.
            SkrivUtBaglista(bagRegister);
        }
        public static Bag[] UtökaBagRegister(Bag[] lista, Bag ny)
        {

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

        public static void SkrivUtBaglista(Bag[] bagRegister)
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
                foreach (string klubba in bagRegister[i].klubbNamn)
                {
                    Console.WriteLine(klubba );
                }
            }
        }
    }
}
