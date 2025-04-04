using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoapp
{
    internal class Auto
    {
        private int sorszam;
        private string marka;
        private string modell;
        private int gyartasiEv;
        private string szin;
        private int eladottDarabSzam;
        private int atlagosEladasiAr;

        public int Sorszam { get => sorszam; set => sorszam = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Modell { get => modell; set => modell = value; }
        public int GyartasiEv { get => gyartasiEv; set => gyartasiEv = value; }
        public string Szin { get => szin; set => szin = value; }
        public int EladottDarabSzam { get => eladottDarabSzam; set => eladottDarabSzam = value; }
        public int AtlagosEladasiAr { get => atlagosEladasiAr; set => atlagosEladasiAr = value; }

        public Auto(string sor)
        {
            string[] tomb = sor.Split(';');

            this.Sorszam = int.Parse(tomb[0]);
            this.Marka = tomb[1];
            this.Modell = tomb[2];
            this.GyartasiEv = int.Parse(tomb[3]);
            this.Szin = tomb[4];
            this.EladottDarabSzam = int.Parse(tomb[5]);
            this.AtlagosEladasiAr = int.Parse(tomb[6]);
        }

        public static List<Auto> Beolvas(string fajlNev)
        {
            List<Auto> autok = new List<Auto>();
            string[] sorok = File.ReadAllLines(fajlNev);

            for (int i = 1; i < sorok.Length; i++)
            {
                autok.Add(new Auto(sorok[i]));
            }

            return autok;
        }
    }
}
