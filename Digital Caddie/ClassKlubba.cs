using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    class ClassKlubba
    {


        public class Klubba
        {
            public string typAvKlubba;
            public int längd;

        }

        public static void Test()
        {
            Klubba klubba = new Klubba();
            Klubba[,] klubblista = new Klubba[2,14];
            int antal = 0;
            Console.WriteLine("Hur många klubbor vill du registrera? ");
            antal = int.Parse(Console.ReadLine());
            Klubba[] klubbantal = new Klubba[antal];
            for (int i = 0; i < antal; i++)
            {
                Klubba info = new Klubba();
                Console.WriteLine("Vad är det för typ av klubba du vill lägga till, namge den valfritt! ");
                info.typAvKlubba = Console.ReadLine();
                Console.WriteLine("Hur långt slår du med denna klubban? ");
                info.längd = int.Parse(Console.ReadLine());


                //någonting som lägger till input i lista              

                klubblista[2,14] = info;
                //Console.WriteLine($"{info.längd} {info.typAvKlubba}");


                for (int i = 0; i <= antal; i++)
                {
                    klubblista[2,14] = i;

                    Console.WriteLine("Längd: {0}, {1}");

                }
            }
        }
    }
}
