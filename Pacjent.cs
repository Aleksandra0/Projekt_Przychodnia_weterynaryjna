using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
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
        private List<Przebyte_choroby> przebyte_choroby;
        private List<Szczepienia> szczepienia;
        private Klient wlasciciel;
        private Lekarz lekarz;

        public int Id { get => id; set => id = value; }
        public List<Przebyte_choroby> Przebyte_choroby { get => przebyte_choroby; set => przebyte_choroby = value; }
        public List<Szczepienia> Szczepienia { get => szczepienia; set => szczepienia = value; }
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        public Klient Wlasciciel { get => wlasciciel; set => wlasciciel = value; }

        public Pacjent()
        {
            this.Id = 0;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.wlasciciel = null;
            this.Lekarz = null;
        }
        public Pacjent(string imie, DateTime data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, Lekarz lekarz, Klient wlasciciel) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.lekarz = new Lekarz();
            this.wlasciciel = new Klient();
        }

        public Pacjent(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, Lekarz lekarz, Klient wlasciciel) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.lekarz = new Lekarz();
            this.wlasciciel = new Klient();
        }

        public Pacjent(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, Klient wlasciciel) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.wlasciciel = new Klient();
        }

        public override string ToString()
        {
            return this.Id + " " + base.ToString();
        }

        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pacjent));
                serializer.Serialize(writer, this);
            }
        }

        public static Pacjent OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pacjent));
                return serializer.Deserialize(reader) as Pacjent;
            }
        }
        /*public void SortujPoPESEL()
        {
            wlasciciele.Sort(new peselComparator());
        }

        public void Sortuj()
        {
            wlasciciele.Sort();
        }*/

        public object Clone()
        {
            Pacjent klon = this.MemberwiseClone() as Pacjent;
            return klon;
        }

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
