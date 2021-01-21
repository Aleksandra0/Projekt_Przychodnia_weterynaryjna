using System;

namespace Projekt_Przychodnia_weterynaryjna
{
    class Program
    {
        static void Main()
        {

            Klient klient1 = new Klient("Jan", "Kowalski", "09.06.1989", "00389674590", Osoba.Plcie.M, "508974466", "jk@gmail.com", "Basztowa 42, Kraków", "Dużo zwierzy");
            Klient klient2 = new Klient("Janina", "Kowalska", "09.05.1992", "00389789590", Osoba.Plcie.K, "513574409", "janinak@gmail.com", "Basztowa 42, Kraków", "Dużo zwierzy");

            Lekarz lekarz1 = new Lekarz("Dawid", "Nowak", "09.12.1986", "00178956435", Osoba.Plcie.M, "509678999", "dn@interia.eu", "Koty", "dr. weterynarz", 8, "Zwierza jak jeża");
            Console.WriteLine(lekarz1.ToString());

            Pacjent pacjent1 = new Pacjent("Felicja", "01.12.2015", Zwierze.Plcie_zwierzat.samica, "kot", "dachowiec", "czarna", "duże oczy", 1);
            Pacjent pacjent2 = new Pacjent("Felix", "01.12.2015", Zwierze.Plcie_zwierzat.samiec, "kot", "dachowiec", "czarna", "duże oczy", 2);
            pacjent1.DodajWlasciciela(klient1);
            pacjent1.DodajWlasciciela(klient2);
            pacjent2.DodajWlasciciela(klient2);

            klient1.DodajZwierze(pacjent1);
            klient2.DodajZwierze(pacjent1);
            klient2.DodajZwierze(pacjent2);

            lekarz1.DodajPacjenta(pacjent1);
            lekarz1.DodajPacjenta(pacjent2);

            Console.WriteLine(lekarz1.ToString());
            Console.WriteLine(klient1.ToString());
            Console.WriteLine(klient2.ToString());
            Console.WriteLine(pacjent1.ToString());
            Console.WriteLine(pacjent2.ToString());

            /*lekarz1.ZapiszXML("Lekarz.xml");
            Lekarz L2 = Lekarz.OdczytajXML("Lekarz.xml");

            klient1.ZapiszXML("Klient.xml");
            Klient K2 = Klient.OdczytajXML("Klient.xml");

            pacjent1.ZapiszXML("Klient.xml");
            Pacjent P2 = Pacjent.OdczytajXML("Klient.xml");*/


        }
    }
}
