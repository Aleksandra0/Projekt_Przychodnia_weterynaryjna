using System;
using System.Collections.Generic;

namespace Projekt_Przychodnia_weterynaryjna
{
    class Program
    {
        static void Main()
        {

            Klient klient1 = new Klient("Jan", "Kowalski", "09.06.1989", "00389674590", Osoba.Plcie.M, "508974466", "jk@gmail.com", "Basztowa 42, Kraków", "Dużo zwierzy");
            Klient klient2 = new Klient("Janina", "Kowalska", "09.05.1992", "00389789590", Osoba.Plcie.K, "513574409", "janinak@gmail.com", "Basztowa 42, Kraków", "Dużo zwierzy");

            Lekarz lekarz1 = new Lekarz("Dawid", "Nowak", "09.12.1986", "00178956435", Osoba.Plcie.M, "509678999", "dn@interia.eu", "Koty", "dr. weterynarz", 8);
            Console.WriteLine(lekarz1.ToString());
            Lekarz lekarz2 = new Lekarz("Krzysztof", "Ambasada", "07.10.1983", "00178956732", Osoba.Plcie.M, "506925173", "kz@interia.eu", "Psy", "dr. weterynarz", 10);


            Pacjent pacjent1 = new Pacjent("Felicja", "01.12.2015", Zwierze.Plcie_zwierzat.samica, "kot", "dachowiec", "czarna", "duże oczy", 1, lekarz1, klient1);
            Pacjent pacjent2 = new Pacjent("Felix", "01.12.2015", Zwierze.Plcie_zwierzat.samiec, "kot", "dachowiec", "czarna", "duże oczy", 2, lekarz1, klient2);

            klient1.Dodaj_pacjenta(pacjent1);
            klient2.Dodaj_pacjenta(pacjent1);
            klient2.Dodaj_pacjenta(pacjent2);

            Console.WriteLine(lekarz1.ToString());
            Console.WriteLine(klient1.ToString());
            Console.WriteLine(klient2.ToString());
            Console.WriteLine(pacjent1.ToString());
            Console.WriteLine(pacjent2.ToString());

           lekarz1.ZapiszXML("Lekarz.xml");
           Lekarz L2 = Lekarz.OdczytajXML("Lekarz.xml");
           klient1.ZapiszXML("Klient.xml");
           Klient K2 = Klient.OdczytajXML("Klient.xml");
           pacjent1.ZapiszXML("Pacjent.xml");
           Pacjent P2 = Pacjent.OdczytajXML("Pacjent.xml");

            Console.WriteLine("---------------");
            //Test sortowania 
            Zespol_lekarzy z = new Zespol_lekarzy();
            z.Dodaj_lekarza(lekarz1);
            z.Dodaj_lekarza(lekarz2);
            Console.WriteLine(z);


            z.Sortuj();
            Console.WriteLine(z);
            z.SortujPoPESEL();
            Console.WriteLine(z);

            Console.WriteLine("---------------");

            Klient lista_zwierzat = new Klient();

            lista_zwierzat.Dodaj_pacjenta(pacjent1);
            lista_zwierzat.Dodaj_pacjenta(pacjent2);
            Console.WriteLine(lista_zwierzat.ToString2());

            lista_zwierzat.Sortuj();
            Console.WriteLine(lista_zwierzat.ToString2());

            lista_zwierzat.SortujPoId();
            Console.WriteLine(lista_zwierzat.ToString2());


            Console.WriteLine("----------------");
            //Test klonowania

            Lekarz l3 = lekarz1.Clone() as Lekarz;

            l3.Imie = "Marcin";
            Console.WriteLine(l3);
            Console.WriteLine(lekarz1);


            Klient k3 = klient1.Clone() as Klient;
            
            k3.Imie = "Damian";
            Console.WriteLine(k3);
            Console.WriteLine(klient1);


            Pacjent p3 = pacjent1.Clone() as Pacjent;

            p3.Imie = "Zygi";
            Console.WriteLine(p3);
            Console.WriteLine(pacjent1);
        }
    }
}
