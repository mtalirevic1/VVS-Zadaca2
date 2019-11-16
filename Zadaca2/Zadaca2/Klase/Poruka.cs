using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca2a.Izuzeci;

namespace Zadaca2a.Klase
{
    public class Poruka
    {
        String _tekstPoruke;
        DateTime _datumSlanja;
        Korisnik _posiljaoc;
        Int32 _prioritet;
        List<Korisnik> _primaoci;

        #region KONSTRUKTORI
        public Poruka() { }
        public Poruka(string tekstPoruke, DateTime datumSlanja, Korisnik posiljaoc, List<Korisnik> primaoci)
        {
            TekstPoruke = tekstPoruke;
            DatumSlanja = datumSlanja;
            Posiljaoc = posiljaoc;
            Primaoci = primaoci;
            Prioritet = 1;
        }
        #endregion
        #region PROPERTIES
        public string TekstPoruke
        {
            get
            {
                return _tekstPoruke;
            }

            set
            {
                if (value.Length > 30)
                    throw new MessageTooLongException("Poruka koja se šalje je preduga.");

                _tekstPoruke = value;
            }
        }

        public DateTime DatumSlanja
        {
            get
            {
                return _datumSlanja;
            }

            set
            {
                _datumSlanja = value;
            }
        }

        public Korisnik Posiljaoc
        {
            get
            {
                return _posiljaoc;
            }

            set
            {
                _posiljaoc = value;
            }
        }

        public List<Korisnik> Primaoci
        {
            get
            {
                return _primaoci;
            }

            set
            {
                _primaoci = value;
            }
        }

        public int Prioritet
        {
            get
            {
                return _prioritet;
            }

            set
            {
                if (value < 1 || value > 10)
                    throw new Exception("Uneseni prioritet nije validan.");

                _prioritet = value;
            }
        }
        #endregion
    }
}
