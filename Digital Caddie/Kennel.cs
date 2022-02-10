using System;
using System.Collections.Generic;
using System.Text;

namespace Digital_Caddie
{
    class Kennel
    {
        public string namn; //(synlighetsmodifieraren public behovs for att kunna arbeta med variablerna i main-metoden/klassen Program) 
        public string adress; //enkel losning, skulle kunna delas upp i fler variabler: gatuadress, postnummer osv
        public string agare;

        //public string[] hundar;
        public Hund[] hundar; //men har vill antagligen att en hund ska kunna ha fler egna attribut, se klassen Hund
    }
}
