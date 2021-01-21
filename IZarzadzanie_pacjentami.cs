using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    interface IZarzadzanie_pacjentami
    {
        void Dodaj_pacjenta(Pacjent p);
        void Usun_pacjenta(int id);
        void Wyczysc_liste();
    }
}
