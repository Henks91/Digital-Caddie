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
        /*public static void LaddaRegister()
        {
            StreamReader infil = new StreamReader("Bagregister.txt");
            string rad;
            while ((rad=infil.ReadLine()) !=null)
            {
                
                //Klubbor[] klubbor = new Klubbor[14];
                //Klubbor klubblista = new Klubbor();
                string[] fält = rad.Split('$');
                string namn = fält[0];
                string klubbNamn = fält[1];
                int minLängd = int.Parse(fält[2]);
                int maxLängd = int.Parse(fält[3]);
                string[] klubbLista = new Klubbor[14];

                Bag bag = new Bag();
                bag.namn = namn;
                bag.klubbor = klubbLista;
                bag.

                for (int i = 0; i < 14; i++)
                {
                    klubbLista[i] = fält[i + 4];
                }


              
                /*for (int i = 0; i < 14; i++)
                {
                    klubbor[i] = klubbor[i+1];
                }
                bag.klubbor = klubbor;
                
            }
        }*/
        public static void SparaRegister()
        {
            StreamWriter utfil = new StreamWriter("Bagregister.txt", false);
            
            for (int i = 0; i < bagRegister.Length; i++)
            {
                Bag bag = bagRegister[i];
                utfil.Write("{0}$", bag.namn);

                    for (int k = 0; k < bagRegister[i].klubbor.Length; k++)
                    {
                    if (bagRegister[i].klubbor[k] == null)

                        break;
                    utfil.Write("{0}:{1}-{2}$",
                        bag.klubbor[k].klubbNamn,
                        bag.klubbor[k].minLängd,
                        bag.klubbor[k].maxLängd);

                    }
                         
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
        public static void Sort (int[] bagRegister) // funktionen "Swap" kan ej hittas?
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
                    //Swap(bagRegister, minst, i);
                    Sort(bagRegister);
                }
            }
        }

    }
}
    



    





    


