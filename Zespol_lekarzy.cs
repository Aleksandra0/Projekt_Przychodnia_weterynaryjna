using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    class Zespol_lekarzy 
    {
        private Lekarz lekarz;
        private List<Lekarz> lekarze;

        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        public List<Lekarz> Lekarze { get => lekarze; set => lekarze = value; }


        public Zespol_lekarzy()
        {
            Lekarze = new List<Lekarz>();
            this.Lekarz = null;
        }

        public Zespol_lekarzy(Lekarz lekarz)
        {
            Lekarze = new List<Lekarz>();
            this.lekarz = new Lekarz();
        }

        public void Dodaj_lekarza(Lekarz l)
        {
            this.lekarze.Add(l);
        }

        public void Usunlekarza(string PESEL)
        {
            for (int i = 0; i < lekarze.Count; i++)
            {
                if (Lekarze[i].Pesel == PESEL)
                {
                    Lekarze.Remove(Lekarze[i]);
                    return;
                }
            }
        }

        public void Wyczysc_liste()
        {
            this.lekarze.Clear();
        }

        public void SortujPoPESEL()
        {
            Lekarze.Sort(new peselComparator());
        }
            
        public void Sortuj()
        {
           Lekarze.Sort();
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in Lekarze)
            {
                builder.Append(item).AppendLine();
            }
            return builder.ToString();
        }
    }
}
