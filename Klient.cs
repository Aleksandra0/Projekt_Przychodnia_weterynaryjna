using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    [Serializable]

    class peselComparator : Comparer<Klient>
    {
        public override int Compare(Klient x, Klient y)
        {
            return x.Pesel.CompareTo(y.Pesel);
        }
    }
    public class Klient : Osoba, IComparable<Klient>
    {
        private string numer_telefonu;
        private string email;
        private string adres;
        private List<Pacjent> zwierzeta;

        public string Numer_telefonu { get => numer_telefonu; set => numer_telefonu = value; }
        public string Email { get => email; set => email = value; }
        public string Adres { get => adres; set => adres = value; }
        public List<Pacjent> Zwierzeta { get => zwierzeta; set => zwierzeta = value; }

        public Klient(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string adres, string zwierzeta) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.adres = adres;
            Zwierzeta = new List<Pacjent>();
        }

        public Klient(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string adres, string zwierzeta) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.adres = adres;
            Zwierzeta = new List<Pacjent>();
        }

        public void DodajZwierze(Pacjent zwierze)
        {
            this.zwierzeta.Add(zwierze);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder1 = new StringBuilder("\nZwierzeta: \n");
            foreach (Pacjent zwierze in Zwierzeta)
            {
                stringBuilder1.AppendLine(zwierze.Imie + ": " + zwierze.Gatunek);
            }
            return base.ToString() + " " + this.numer_telefonu + " " + this.email + " " + this.adres + stringBuilder1.ToString();
        }


        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klient));
                serializer.Serialize(writer, this);
            }
        }

        public Klient OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klient));
                return serializer.Deserialize(reader) as Klient;
            }
        }

        public int CompareTo(Klient other)
        {
            if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);
            else
                return this.Imie.CompareTo(other.Imie);
        }

        /*public object Clone()
        {
            Klient klon = this.MemberwiseClone() as Klient;
            //klon.Kierownik = this.Kierownik.Clone() as KierownikZespolu;
            klon.zwierzeta = new List<Pacjent>();
            foreach (Pacjent pacjent in zwierzeta)
                klon.zwierzeta.Add(pacjent.Clone() as Klient);
            return klon;
        }*/
    }
}
