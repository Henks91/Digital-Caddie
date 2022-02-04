using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    public class Addera
    {
        static Klubblist[] klubbRegister = new Klubblist[14];
        public static Bag[] BagRegister = new Bag[5];
        public static void LäggTillKlubba() {
            Klubblist[] klubblist = new Klubblist[14];
            Klubblist klubblist1 = new Klubblist();
            Console.WriteLine("Vilken klubba vill du lägga till? ");
            klubblist1.namnKlubba = Console.ReadLine();
            Console.WriteLine("Ange din längdintervall du slår med klubban minumum och maximum ");
            Console.WriteLine("Minimum: ");
            klubblist1.minLenght = int.Parse(Console.ReadLine());
            Console.WriteLine("Maximum: ");
            klubblist1.maxLenght = int.Parse(Console.ReadLine());

            klubblist[0] = klubblist1;

            
        }
        public static void LäggTillBag()
        {
            Bag[] bag = new Bag[5];
            Bag bag1 = new Bag();
            Console.WriteLine("Vad vill du att din bag ska heta?");
            bag1.namnBag = Console.ReadLine();
            bag[0] = bag1;
            LäggTillKlubba();
        }
        public static void RegistreraTest()
        {
            Kennel a = new Kennel(); //skapa ett kennelobjekt, i temporara variabeln "a"
            Hund A = new Hund();
            a.namn = "Ringgirdens taxar";
            a.adress = "Kriksvangen 4";
            a.agare = "Hanna Persson";
            a.hundar = new string[3]; //skapa kennelns hundlista (godtycklig langd 2 tillsvidare)
            a.hundar[0] = "Maja";
            a.hundar[1] = "Brutus";
            a.hundar[2] = "Pudel";
            kennelRegister[0] = a; //lagg till kenneln i register-listan, pi forsta platsen 

            Kennel b = new Kennel();
            b.namn = "Hagalunds hundar";
            b.adress = "Svegvagen 8";
            b.agare = "Annette Ahl";

            b.hundar = new string[2];
            b.hundar[0] = "Jack";
            b.hundar[1] = "Sack";
            kennelRegister[1] = b;

            Kennel c = new Kennel();
            c.namn = "Brukshundsuppfodaren";
            c.adress = "Skogsvagen 13";
            c.agare = "Jonas Herksson";

            c.hundar = new string[2];
            c.hundar[0] = "Findus";
            c.hundar[1] = "Felix";
            kennelRegister[2] = c;

            Console.Write("Utskrift av kennelRegister:");
            for (int i = 0; i < kennelRegister.Length; i++) //loopa igenom hela registret                                                                 
            {
                Console.WriteLine(i + " Namn: " + kennelRegister[i].namn + "\nAdress: " +
                    kennelRegister[i].adress + "\nAgare: " + kennelRegister[i].agare);
                Console.Write("Hundar: ");
                foreach (string hund in kennelRegister[i].hundar) //loopa igenom kennelns hundlista 


                    Console.Write(hund + ", ");
            }
    }
    
    

    }

}
