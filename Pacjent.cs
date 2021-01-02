using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    public class Pacjent : Zwierze
    {
        private int id;
        /* private string przebyte_choroby; //???
        private string przyjmowane_leki; //??? */
        private string wlasciciele; //docelowo lista

        public int Id { get => id; set => id = value; }
        public string Wlasciciele { get => wlasciciele; set => wlasciciele = value; }

        public Pacjent(string imie, DateTime data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, string wlasciciele) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            this.Wlasciciele = wlasciciele;
        }

        public Pacjent(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, string wlasciciele) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            this.Wlasciciele = wlasciciele;
        }

        public override string ToString()
        {
            return this.Id + " " + base.ToString() + " " + this.Wlasciciele;
        }
    }
}
