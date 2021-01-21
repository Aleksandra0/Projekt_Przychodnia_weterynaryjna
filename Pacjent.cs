using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    public class Pacjent : Zwierze, IZarzadzanie_wlascicielami
    {
        private int id;
        private List<Przebyte_choroby> przebyte_choroby;
        private List<Szczepienia> szczepienia;
        private List<Klient> wlasciciele;
        private Lekarz lekarz;

        public int Id { get => id; set => id = value; }
        public List<Klient> Wlasciciele { get => wlasciciele; set => wlasciciele = value; }
        public List<Przebyte_choroby> Przebyte_choroby { get => przebyte_choroby; set => przebyte_choroby = value; }
        public List<Szczepienia> Szczepienia { get => szczepienia; set => szczepienia = value; }
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }

        public Pacjent(string imie, DateTime data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Wlasciciele = new List<Klient>();
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
        }

        public Pacjent(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Wlasciciele = new List<Klient>();
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("\nWlasciciele: \n");
            foreach (Klient wlasciciel in Wlasciciele)
            {
                stringBuilder.AppendLine(wlasciciel.Imie + " " + wlasciciel.Nazwisko);
            }
            return this.Id + " " + base.ToString() + " " + stringBuilder.ToString();
        }

        public void Dodaj_wlasciciela(Klient wlasciciel)
        {
            this.wlasciciele.Add(wlasciciel);
        }

        public void Usun_wlasciciela(string pesel)
        {
            foreach (Klient w in this.wlasciciele)
            {
                if (w.Pesel == pesel)
                {
                    wlasciciele.Remove(w);
                    break;
                }
            }
        }

        public void Wyczysc_liste()
        {
            this.wlasciciele.Clear();
        }
    }
}
