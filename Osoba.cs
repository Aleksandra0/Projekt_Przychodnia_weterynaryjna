using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    public abstract class Osoba : IEquatable<Osoba>
    {
        public enum Plcie { K, M, I } //I - other (inna)

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
            this.imie = null;
            this.nazwisko = null;
            this.data_urodzenia = DateTime.Today;
            this.pesel = null;
            this.plec = Plcie.K;
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
            return this.imie + " " + this.Nazwisko + "\n\nData urodzenia: " + this.Data_urodzenia.ToString("dd-MM-yyyy") + "\n\nPesel: " + this.pesel + "\n\n";
        }

        public bool Equals(Osoba other)
        {
            return this.pesel == other.pesel;
        }
    }
}
