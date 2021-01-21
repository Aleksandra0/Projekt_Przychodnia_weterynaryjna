using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    [Serializable]
    /*class idComparator : Comparer<Pacjent>
    {
        public override int Compare(Pacjent x, Pacjent y)
        {
            return x.id.CompareTo(y.id);
        }
    }*/
    public class Pacjent : Zwierze//, ICloneable, IComparable<Pacjent>
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

        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pacjent));
                serializer.Serialize(writer, this);
            }
        }

        public Pacjent OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pacjent));
                return serializer.Deserialize(reader) as Pacjent;
            }
        }
        public void SortujPoPESEL()
        {
            wlasciciele.Sort(new peselComparator());
        }

        public void Sortuj()
        {
            wlasciciele.Sort();
        }

        /*public object Clone()
        {
            Pacjent klon = this.MemberwiseClone() as Pacjent;
            //klon.Kierownik = this.Kierownik.Clone() as KierownikZespolu;
            klon.wlasciciele = new List<Klient>();
            foreach (Klient wlasciciel in wlasciciele)
                klon.wlasciciele.Add(wlasciciel.Clone() as Klient);
            return klon;
        }*/

        /*public Pacjent DeepClone()
        {
            //BinaryFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(nazwa, FileMode.Create);
            //formatter.Serialize(stream, this);
            //stream.Close();

            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream) as Pacjent;
            }
        }*/
    }
}
