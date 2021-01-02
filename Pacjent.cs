using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    public class Pacjent : Zwierze
    {
        private int id;
        /* private string przebyte_choroby; //???
        private string przyjmowane_leki; //??? 
        private string szczepienia //??? */
        private List<Klient> wlasciciele;

        public int Id { get => id; set => id = value; }
        public List<Klient> Wlasciciele { get => wlasciciele; set => wlasciciele = value; }

        public Pacjent(string imie, DateTime data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Wlasciciele = new List<Klient>();
        }

        public Pacjent(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Wlasciciele = new List<Klient>();
        }

        public void DodajWlasciciela(Klient wlasciciel)
        {
            this.wlasciciele.Add(wlasciciel);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("\nWlasciciele: \n");
            foreach (Klient wlasciciel in Wlasciciele)
            {
                stringBuilder.AppendLine(wlasciciel.Imie = wlasciciel.Nazwisko);
            }
            return this.Id + " " + base.ToString() + " " + stringBuilder.ToString();
        }


    }
}
