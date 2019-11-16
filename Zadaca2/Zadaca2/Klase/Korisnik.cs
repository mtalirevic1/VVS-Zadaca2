using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca2a.Klase
{
    public class Korisnik
    {
        String _id; // Korisnikov ID.
        String _ime;  // Korisnikovo ime.
        String _prezime; // Korisnikovo prezime.
        String _brojTelefona; // Korisnikov broj telefona.
        DateTime _datumRodenja; // Korisnikov datum rođenja.
        Kartica _korisnickiRacun; // Korisnikov račun odakle se skida novac.

        #region KONSTRUKTORI
        public Korisnik() { }
        public Korisnik(string ime, string prezime, string brojTelefona, DateTime datumRodenja, String brojKreditneKartice, Double stanje)
        {
            Id = Guid.NewGuid().ToString();
            Ime = ime;
            Prezime = prezime;
            BrojTelefona = brojTelefona;
            DatumRodenja = datumRodenja;
            KorisnickiRacun = new Kartica(brojKreditneKartice, stanje);
        }
        #endregion
        #region PROPERTIES
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Ime
        {
            get
            {
                return _ime;
            }

            set
            {
                _ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return _prezime;
            }

            set
            {
                _prezime = value;
            }
        }

        public string BrojTelefona
        {
            get
            {
                return _brojTelefona;
            }

            set
            {
                _brojTelefona = value;
            }
        }

        public DateTime DatumRodenja
        {
            get
            {
                return _datumRodenja;
            }

            set
            {
                _datumRodenja = value;
            }
        }

        public Kartica KorisnickiRacun
        {
            get
            {
                return _korisnickiRacun;
            }

            set
            {
                _korisnickiRacun = value;
            }
        }
        #endregion
    }
}
