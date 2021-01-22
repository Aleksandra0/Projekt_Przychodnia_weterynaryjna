using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    public class Klient : Osoba, IZarzadzanie_pacjentami, ICloneable
    {
        private string numer_telefonu;
        private string email;
        private string adres;
        private List<Pacjent> zwierzeta;

        public string Numer_telefonu { get => numer_telefonu; set => numer_telefonu = value; }
        public string Email { get => email; set => email = value; }
        public string Adres { get => adres; set => adres = value; }
        public List<Pacjent> Zwierzeta { get => zwierzeta; set => zwierzeta = value; }
        public Klient()
        {
            this.numer_telefonu = null;
            this.email = null;
            this.adres = null;
            Zwierzeta = new List<Pacjent>();
        }
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

        public override string ToString()
        {
            return base.ToString() + "Numer telefonu: " + this.numer_telefonu + "\n\nEmail: " + this.email + "\n\nAdres: " + this.adres;
        }

        public string ToString2()
        {
            StringBuilder stringBuilder1 = new StringBuilder("\nPupile: \n");
            foreach (Pacjent zwierze in Zwierzeta)
            {
                stringBuilder1.AppendLine(zwierze.Imie + "(id: " + zwierze.Id + ")\nData urodzenia: " + zwierze.Data_urodzenia + "\n" + zwierze.Gatunek + ", rasa: " + zwierze.Rasa + ", barwa: " + zwierze.Barwa + "\nZnaki szczególne: " + zwierze.Znaki_szczegolne + "\n");
            }
            return stringBuilder1.ToString();
        }


        public void Dodaj_pacjenta(Pacjent p)
        {
            this.zwierzeta.Add(p);
        }

        public void Usun_pacjenta(int id)
        {
            foreach (Pacjent p in this.zwierzeta)
            {
                if (p.Id == id)
                {
                    zwierzeta.Remove(p);
                    break;
                }
            }
        }

        public void Wyczysc_liste()
        {
            this.zwierzeta.Clear();
        }

        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klient));
                serializer.Serialize(writer, this);
            }
        }

        public static Klient OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klient));
                return serializer.Deserialize(reader) as Klient;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public object CloneKlient()
        {
            Klient klon = this.MemberwiseClone() as Klient;
            klon.Zwierzeta = new List<Pacjent>();
            foreach (Pacjent pacjent in Zwierzeta)
                klon.Zwierzeta.Add(pacjent.Clone() as Pacjent);
            return klon;
        }


        public void Sortuj()
        {
            zwierzeta.Sort();
        }

        public void SortujPoId()
        {
            Zwierzeta.Sort(new idComparator());
        }
    }
}

