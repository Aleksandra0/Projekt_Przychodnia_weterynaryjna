using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    class Lekarz : Osoba
    {
        private string numer_telefonu;
        private string email;
        private string specjalizacja;
        private string tytuly;
        private int staz_pracy;
        private List<Pacjent> pacjenci;

        public string Numer_telefonu { get => numer_telefonu; set => numer_telefonu = value; }
        public string Email { get => email; set => email = value; }
        public string Specjalizacja { get => specjalizacja; set => specjalizacja = value; }
        public string Tytuly { get => tytuly; set => tytuly = value; }
        public int Staz_pracy { get => staz_pracy; set => staz_pracy = value; }
        public List<Pacjent> Pacjenci { get => pacjenci; set => pacjenci = value; }

        public Lekarz(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string specjalizacja, string tytuly, int staz_pracy, string pacjenci) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.specjalizacja = specjalizacja;
            this.tytuly = tytuly;
            this.staz_pracy = staz_pracy;
            Pacjenci = new List<Pacjent>();
        }

        public Lekarz(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string specjalizacja, string tytuly, int staz_pracy, string pacjenci) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.specjalizacja = specjalizacja;
            this.tytuly = tytuly;
            this.staz_pracy = staz_pracy;
            Pacjenci = new List<Pacjent>();
        }

        public void DodajPacjenta(Pacjent zwierze)
        {
            this.pacjenci.Add(zwierze);
        }


        public override string ToString()
        {
            StringBuilder stringBuilder1 = new StringBuilder("\nZwierzeta: \n");
            foreach (Pacjent zwierze in Pacjenci)
            {
                stringBuilder1.AppendLine(zwierze.Imie + ": " + zwierze.Gatunek);
            }
            return this.tytuly + " " + base.ToString() + " " + this.numer_telefonu + " " + this.email + " " + this.specjalizacja + " " + this.staz_pracy + " " + stringBuilder1.ToString();
        }



    }
}
