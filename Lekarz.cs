using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    class peselComparator : Comparer<Lekarz>
    {
        public override int Compare(Lekarz x, Lekarz y)
        {
            return x.Pesel.CompareTo(y.Pesel);
        }
    }
    public class Lekarz : Osoba, IComparable<Lekarz>, ICloneable
    {
        private string numer_telefonu;
        private string email;
        private string specjalizacja;
        private string tytuly;
        private int staz_pracy;

        public string Numer_telefonu { get => numer_telefonu; set => numer_telefonu = value; }
        public string Email { get => email; set => email = value; }
        public string Specjalizacja { get => specjalizacja; set => specjalizacja = value; }
        public string Tytuly { get => tytuly; set => tytuly = value; }
        public int Staz_pracy { get => staz_pracy; set => staz_pracy = value; }

        public Lekarz()
        {
            this.numer_telefonu = null;
            this.email = null;
            this.specjalizacja = null;
            this.tytuly = null;
            this.staz_pracy = 0;
        }
        public Lekarz(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string specjalizacja, string tytuly, int staz_pracy) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.specjalizacja = specjalizacja;
            this.tytuly = tytuly;
            this.staz_pracy = staz_pracy;
        }

        public Lekarz(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string specjalizacja, string tytuly, int staz_pracy) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.specjalizacja = specjalizacja;
            this.tytuly = tytuly;
            this.staz_pracy = staz_pracy;
        }

        public override string ToString()
        {
            return this.tytuly + " " + this.Imie + " " + this.Nazwisko + "\nNumer telefonu: " + this.numer_telefonu + "\nEmail: " + this.email + "\nSpecjalizacja: " + this.specjalizacja + "\nStaż pracy: " + this.staz_pracy + "\n\n";
        }

        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lekarz));
                serializer.Serialize(writer, this);
            }
        }

        public static Lekarz OdczytajXML(string nazwa)
        {
            Lekarz wynik = null;
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lekarz));
                wynik =  serializer.Deserialize(reader) as Lekarz;
            }
            return wynik;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Lekarz other)
        {
            if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);
            else
                return this.Imie.CompareTo(other.Imie);
        }

    }
}
