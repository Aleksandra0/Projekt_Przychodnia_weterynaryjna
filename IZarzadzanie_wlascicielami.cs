using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    interface IZarzadzanie_wlascicielami
    {
        void Dodaj_wlasciciela(Klient k);
        void Usun_wlasciciela(string s);
        void Wyczysc_liste();
    }
}
