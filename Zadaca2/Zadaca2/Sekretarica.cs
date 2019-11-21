using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca2a.Klase;
using Zadaca2a.Izuzeci;

namespace Zadaca2a
{
    public class Sekretarica
    {
        const Double POPUST_NA_KOLIICNU_20 = 0.05; // Popust na kolicinu iznad 20 poruka.
        const Double POPUST_NA_KOLIICNU_50 = 0.1; // Popust na kolicinu iznad 50 poruka.
        const Double CIJENA_KAPACITETA = 1.55; // Cijena jednog dodatnog mjesta kapaciteta.
        Int32 KAPACITET = 2; // Trenutni kapacitet Sekretarice.

        Korisnik _korisnik; // Vlasnik sekretarice.
        List<Poruka> _pristiglePoruke; // Sanduče ulaznih poruka.
        List<Poruka> _poslanePoruke; // Sanduče poslanih poruka.
        List<Poruka> _arhiviranePoruke; // Sanduče arhiviranih poruka.

        String _algoritam; // Algoritam po kome će se poruke izbacivati u Inboxu i Outboxu. Arhiva je neograničena.

        #region KONSTRUKTORI

        public Sekretarica(Korisnik k)
        {
            Korisnik = k;
            PristiglePoruke = new List<Poruka>();
            PoslanePoruke = new List<Poruka>();
            ArhiviranePoruke = new List<Poruka>();
            Algoritam = "FIFO";
        }

        #endregion

        #region PROPERTIES

        public Korisnik Korisnik
        {
            get { return _korisnik; }

            set { _korisnik = value; }
        }

        public List<Poruka> PristiglePoruke
        {
            get { return _pristiglePoruke; }

            set { _pristiglePoruke = value; }
        }

        public List<Poruka> PoslanePoruke
        {
            get { return _poslanePoruke; }

            set { _poslanePoruke = value; }
        }

        public List<Poruka> ArhiviranePoruke
        {
            get { return _arhiviranePoruke; }

            set { _arhiviranePoruke = value; }
        }

        public string Algoritam
        {
            get { return _algoritam; }

            set { _algoritam = value; }
        }

        #endregion

        #region METODE

        public String povecajKapacitet(Int32 dodatniKapacitet)
        {
            Double iznos = 0;

            if (dodatniKapacitet < 20)
                iznos = dodatniKapacitet * CIJENA_KAPACITETA;
            else if (dodatniKapacitet >= 20 && dodatniKapacitet < 50)
                iznos = (dodatniKapacitet * CIJENA_KAPACITETA) * (1 - POPUST_NA_KOLIICNU_20);
            else
                iznos = (dodatniKapacitet * CIJENA_KAPACITETA) * (1 - POPUST_NA_KOLIICNU_50);

            Korisnik.KorisnickiRacun.naplati(iznos);

            String s = "Kapacitet uspješno povećan sa " + Convert.ToString(KAPACITET);
            KAPACITET = KAPACITET + dodatniKapacitet;
            return s + " na " + Convert.ToString(KAPACITET) + " poruka, a to vas je koštalo =" +
                   Convert.ToString(iznos) + " KM.";
        }

        public Boolean primiPoruku(Poruka poruka)
        {
            if (PristiglePoruke.Count == KAPACITET)
            {
                if (Algoritam.Equals("FIFO"))
                    PristiglePoruke.RemoveAt(FIFO(PristiglePoruke));
                else if (Algoritam.Equals("LIFO"))
                    PristiglePoruke.RemoveAt(LIFO(PristiglePoruke));
                else if (Algoritam.Equals("PA"))
                    PristiglePoruke.RemoveAt(PrioritetniAlgoritam(PristiglePoruke));
                else
                    throw new AlgorithmNotValidException("Nemoguće poslati poruku. Nepoznate postavke algoritma.");
            }

            PristiglePoruke.Add(poruka);
            return true;
        }

        public Boolean spremiPoslanuPoruku(Poruka poruka)
        {
            if (PoslanePoruke.Count == KAPACITET)
            {
                if (Algoritam.Equals("FIFO"))
                    PoslanePoruke.RemoveAt(FIFO(PoslanePoruke));
                else if (Algoritam.Equals("LIFO"))
                    PoslanePoruke.RemoveAt(LIFO(PoslanePoruke));
                else if (Algoritam.Equals("PA"))
                    PoslanePoruke.RemoveAt(PrioritetniAlgoritam(PoslanePoruke));
                else
                    throw new AlgorithmNotValidException(
                        "Nemoguće spremiti poslanu poruku. Nepoznate postavke algoritma.");
            }

            PoslanePoruke.Add(poruka);
            return true;
        }

        public void arhivirajPoruke(List<Int32> indeksi, String tip)
        {
            if (tip.Equals("Pristigle Poruke"))
            {
                foreach (Int32 i in indeksi)
                {
                    ArhiviranePoruke.Add(PristiglePoruke[i]);
                    PristiglePoruke.RemoveAt(i);
                }
            }
            else if (tip.Equals("Poslane Poruke"))
            {
                foreach (Int32 i in indeksi)
                {
                    ArhiviranePoruke.Add(PoslanePoruke[i]);
                    PoslanePoruke.RemoveAt(i);
                }
            }
            else
                throw new Exception("Nepoznat tip.");
        }

        #endregion

        #region ALGORITAM_METODE

        private Int32 FIFO(List<Poruka> por)
        {
            DateTime max = DateTime.Now;
            Int32 izbaci = 0;

            for (int i = 0; i < por.Count; i++)
            {
                if (DateTime.Compare(por[i].DatumSlanja, max) < 0)
                {
                    max = por[i].DatumSlanja;
                    izbaci = i;
                }
            }

            return izbaci;
        }

        private Int32 LIFO(List<Poruka> por)
        {
            DateTime min = DateTime.Parse("01.01.1900");
            Int32 izbaci = 0;

            for (int i = 0; i < por.Count; i++)
            {
                if (DateTime.Compare(por[i].DatumSlanja, min) > 0)
                {
                    min = por[i].DatumSlanja;
                    izbaci = i;
                }
            }

            return izbaci;
        }
        
        
        private Int32 PrioritetniAlgoritam(List<Poruka> por)
        {
            Int32 izbaci = 0;
            // if (por == null || por.Count == 0) throw new Exception("Niz je prazan");
            // if (por.Count == 1) return 0;
            int najveciPrioritet = por[0].Prioritet;
            for (int i = 1; i < por.Count; i++)
            {
                if (por[i].Prioritet < najveciPrioritet)
                {
                    najveciPrioritet = por[i].Prioritet;
                    izbaci = i;
                }
            }

            return izbaci;
        }

        #endregion
    }
}