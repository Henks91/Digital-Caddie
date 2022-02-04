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
            Bag a = new Bag(); //skapa ett kennelobjekt, i temporara variabeln "a"
            a.namn = "Ringgirdens taxar";
            a.adress = "Kriksvangen 4";
            a.agare = "Hanna Persson";
            a.hundar = new string[2]; //skapa kennelns hundlista (godtycklig langd 2 tillsvidare) 
            a.hundar[0] = "Maja";
            a.hundar[1] = "Brutus";
            BagRegister[0] = a; //lagg till kenneln i register-listan, pi forsta platsen
        }
    }
    
    

    }

}
