using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    public abstract class Zwierze
    {
        public enum Plcie_zwierzat { samiec, samica };

        private string imie;
        private DateTime data_urodzenia;
        private Plcie_zwierzat plec;
        private string gatunek;
        private string rasa;
        private string barwa;
        private string znaki_szczegolne;

        public string Imie { get => imie; set => imie = value; }
        public DateTime Data_urodzenia { get => data_urodzenia; set => data_urodzenia = value; }
        internal Plcie_zwierzat Plec { get => plec; set => plec = value; }
        public string Gatunek { get => gatunek; set => gatunek = value; }
        public string Rasa { get => rasa; set => rasa = value; }
        public string Barwa { get => barwa; set => barwa = value; }
        public string Znaki_szczegolne { get => znaki_szczegolne; set => znaki_szczegolne = value; }

        public Zwierze()
        {

        }
        public Zwierze(string imie, DateTime data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne)
        {
            this.Imie = imie;
            this.Data_urodzenia = data_urodzenia;
            this.Plec = plec;
            this.Gatunek = gatunek;
            this.Rasa = rasa;
            this.Barwa = barwa;
            this.Znaki_szczegolne = znaki_szczegolne;
        }

        public Zwierze(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne)
        {
            this.Imie = imie;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.Data_urodzenia);
            this.Plec = plec;
            this.Gatunek = gatunek;
            this.Rasa = rasa;
            this.Barwa = barwa;
            this.Znaki_szczegolne = znaki_szczegolne;
        }

        public int Wiek()
        {
            int wiek = 0;
            wiek = DateTime.Today.Year - this.Data_urodzenia.Year;
            if (DateTime.Today < this.Data_urodzenia.AddYears(wiek) && wiek != 0)
            {
                wiek--;
            }
            return wiek;
        }

        public override string ToString()
        {
            return this.Imie + " " + this.Data_urodzenia.ToString("dd-MM-yyyy") + " " + this.Plec + " " + this.Gatunek + " " + this.Rasa + " " + this.Barwa + " " + this.Znaki_szczegolne + ", Wiek: " + this.Wiek().ToString();
        }
    }
}
