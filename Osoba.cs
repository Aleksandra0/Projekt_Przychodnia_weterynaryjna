using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    abstract class Osoba
    {
        public enum Plcie { K, M, I } //I - other

        private string imie;
        private string nazwisko;
        private DateTime data_urodzenia;
        private string pesel;
        private Plcie plec;
        

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime Data_urodzenia { get => data_urodzenia; set => data_urodzenia = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public Plcie Plec { get => plec; set => plec = value; }

        public Osoba()
        {

        }

        public Osoba(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.data_urodzenia = data_urodzenia;
            this.pesel = pesel;
            this.plec = plec;
        }

        public Osoba(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_urodzenia);
            this.pesel = pesel;
            this.plec = plec;
        }

        public override string ToString()
        {
            return this.imie + " " + this.Nazwisko + " " + this.Data_urodzenia.ToString("dd-MM-yyyy") + " " + this.pesel + " " + this.plec + " ";
        }



    }
}
