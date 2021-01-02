using System;

namespace Projekt_Przychodnia_weterynaryjna
{
    class Program
    {
        static void Main()
        {
            Klient klient1 = new Klient("Jan", "Kowalski", "09.06.2012", "00389674590", Osoba.Plcie.M, "508974466", "Dużo zwierzy");
            Console.WriteLine(klient1.ToString());
        }
    }
}
