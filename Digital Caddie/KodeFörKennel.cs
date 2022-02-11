using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    class KodeFörKennel
    {
         do
            {
            LäggTillKennel();
        Console.WriteLine("\nVill du lägga till en Kennel till? (j/n): ");
            } while (Console.ReadLine() != "n");

            SkrivUtRegister();
    Console.WriteLine("\n\nProgrammet avslutas");
    }
    static void LäggTillKennel() //låt anvädaren mata in infon för skapa en kennel
    {
    Kennel ny = new Kennel(); //Skapa ett kennelobjekt, i temporär variabel "ny"
    Console.WriteLine("Ny kennels namn:");
    ny.namn = Console.ReadLine();
    Console.WriteLine("Ny kennels adress:");
    ny.adress = Console.ReadLine();
    Console.WriteLine("Ny kennels ägare:");
    ny.agare = Console.ReadLine();

    uint antalHundar = ReadUInt("Hur många hundar ska läggas till i kenneln: ");
    ny.hundar = new string[antalHundar];
    for (int i = 0; i < antalHundar; i++)
    {
        Console.WriteLine("#" + (i + 1) + " ny hunds namn:");
        ny.hundar[i] = Console.ReadLine();
    }
    kennelRegister = UtökaArray(kennelRegister, ny); //lägg till kenneln sist i kennelnrigistret
    }

//Skriva ut registret i konsollen
    public static void SkrivUtRegister()
    {
    Console.WriteLine("Utskrift av kennelRegister: ");
    for (int i = 0; i < kennelRegister.Length; i++) //loopa igenom hela registret
    {
        Console.WriteLine("\n\n#" + i + "Namn: " + kennelRegister[i].namn + "\nAdress: " +
        kennelRegister[i].adress + "\nÄgare: " + kennelRegister[i].agare);
        Console.WriteLine("Hundar: ");
        foreach (string hund in kennelRegister[i].hundar) //loopa igenom kennelns hundlista
            Console.WriteLine(hund + ", ");

    }

    }
//Metod för utökning av vektor, "standardalgoritm"
public static Kennel[] UtökaArray(Kennel[] vektor, Kennel nytt)
{
    Kennel[] nyVektor = new Kennel[vektor.Length + 1];
    for (int i = 0; i < vektor.Length; i++)
        nyVektor[i] = vektor[i];
    nyVektor[vektor.Length] = nytt;
    return nyVektor;

}
//Metod för inläsning av positiv heltal med felhantering
public static uint ReadUInt(string label) //Tar ej negativa tal
{
    Console.WriteLine(label);
    uint tal;
    while (!uint.TryParse(Console.ReadLine(), out tal))
    {
        Console.WriteLine("Måste vara ett possitivt tal");
        Console.WriteLine(label);
    }
    return tal;
}   
}
