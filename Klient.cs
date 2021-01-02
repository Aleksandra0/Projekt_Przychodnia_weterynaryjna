using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    public class Klient : Osoba
    {
        private string numer_telefonu;
        private string email;
        private string adres;
        private string zwierzeta; //tymczasowo string - docelowo lista

        public string Numer_telefonu { get => numer_telefonu; set => numer_telefonu = value; }
        public string Email { get => email; set => email = value; }
        public string Adres { get => adres; set => adres = value; }
        public string Zwierzeta { get => zwierzeta; set => zwierzeta = value; }
       

        public Klient(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string adres, string zwierzeta) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.adres = adres;
            this.zwierzeta = zwierzeta;
        }

        public Klient(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string adres, string zwierzeta) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.adres = adres;
            this.zwierzeta = zwierzeta;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.numer_telefonu + " " + this.email + " " + this.adres + " " + this.zwierzeta;
        }


    }
}
