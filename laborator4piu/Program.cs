using System;
using System.Configuration;
using gestionareLoc;
using NivelStocareDate;

namespace lab3piu
{
    class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareLoc_FisierText adminLocuri = new AdministrareLoc_FisierText(numeFisier);
            LocDeJoaca locNou = new LocDeJoaca();
            int nrLocuri = 0;

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii loc de joaca de la tastatura");
                Console.WriteLine("I. Afisarea informatiilor despre ultimul loc introdus");
                Console.WriteLine("A. Afisare locuri din fisier");
                Console.WriteLine("S. Salvare loc in fisier");
                Console.WriteLine("R. Cautare loc dupa criteriu");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        locNou = CitireLocTastatura();

                        break;
                    case "I":
                        AfisareLocDeJoaca(locNou);

                        break;
                    case "A":
                        LocDeJoaca[] locuridejoaca = adminLocuri.GetLocuri(out nrLocuri);
                        AfisareLocuri(locuridejoaca, nrLocuri);

                        break;
                    case "S":
                        int nrLoc = ++nrLocuri;
                        locNou.nrLoc = nrLoc;
                        adminLocuri.AddLoc(locNou);

                        break;
                    case "R":
                        CautareLocuriDeJoaca(adminLocuri);
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");
            Console.ReadLine();

        }
        public static void AfisareLocuri(LocDeJoaca[] locuridejoaca, int nrLocuri)
        {
            Console.WriteLine("Locurile de joaca sunt:");
            for (int contor = 0; contor < nrLocuri; contor++)
            {
                string infoLocuri = locuridejoaca[contor].Info();
                Console.WriteLine(infoLocuri);
            }
        }
        public static LocDeJoaca CitireLocTastatura()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti adresa");
            string adresa = Console.ReadLine();

            LocDeJoaca locdejoaca = new LocDeJoaca( 0, nume, adresa);

            return locdejoaca;
        }
        public static void AfisareLocDeJoaca(LocDeJoaca locdejoaca)
        {
            string infoLoc = string.Format("Locul de joaca {0}: {1} are adresa {2}",
                    locdejoaca.nrLoc,
                    locdejoaca.Nume ?? " NECUNOSCUT ",
                    locdejoaca.Adresa ?? " NECUNOSCUT ");

            Console.WriteLine(infoLoc);
        }
        public static void CautareLocuriDeJoaca(AdministrareLoc_FisierText adminLocuri)
        {
            Console.WriteLine("Introduceti numele locului de joaca:");
            string numeCautat = Console.ReadLine();

            LocDeJoaca[] locuriGasite = adminLocuri.CautaLocuri(numeCautat);
            int nrLocuriGasite = locuriGasite.Length;

            if (nrLocuriGasite > 0)
            {
                Console.WriteLine($"Au fost gssite {nrLocuriGasite} locuri de joaca care corespund criteriilor:");
                AfisareLocuri(locuriGasite, nrLocuriGasite);
            }
            else
            {
                Console.WriteLine("Nu au fost gasite locuri de joaca care să corespunda criteriilor.");
            }
        }
       
    }
}