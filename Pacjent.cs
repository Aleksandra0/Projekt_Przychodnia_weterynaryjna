using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    class idComparator : Comparer<Pacjent>
     {
         public override int Compare(Pacjent x, Pacjent y)
         {
             return x.Id.ToString().CompareTo(y.Id.ToString());
         }
     }
    public class Pacjent : Zwierze, ICloneable, IComparable<Pacjent>
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public object ClonePacjent()
        {
            Pacjent klon = this.MemberwiseClone() as Pacjent;
            
            klon.lekarz = this.lekarz.Clone() as Lekarz;
            klon.wlasciciel = this.wlasciciel.Clone() as Klient;
            
            klon.przebyte_choroby = new List<Przebyte_choroby>();
            foreach (Przebyte_choroby choroba in przebyte_choroby)
                klon.Przebyte_choroby.Add(choroba.Clone() as Przebyte_choroby);

            klon.szczepienia = new List<Szczepienia>();
            foreach (Szczepienia szczepienie in szczepienia)
                klon.Szczepienia.Add(szczepienie.Clone() as Szczepienia);
            return klon;
        }

        public int CompareTo(Pacjent other)
        {
            return this.Imie.CompareTo(other.Imie);
        }

    }
}
