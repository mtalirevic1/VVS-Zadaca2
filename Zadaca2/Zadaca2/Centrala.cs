using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca2a.Klase;
using Zadaca2a.Izuzeci;

namespace Zadaca2a
{
    public class Centrala
    {
        String _naziv;
        List<Sekretarica> _sekretariceNaMrezi;
        
        #region KONSTRUKTORI
        public Centrala() { }
        public Centrala(String naziv)
        {
            Naziv = naziv;
            SekretariceNaMrezi = new List<Sekretarica>();
        }
        #endregion
        #region PROPERTIES
        public string Naziv
        {
            get
            {
                return _naziv;
            }

            set
            {
                _naziv = value;
            }
        }
        public List<Sekretarica> SekretariceNaMrezi
        {
            get
            {
                return _sekretariceNaMrezi;
            }

            set
            {
                _sekretariceNaMrezi = value;
            }
        }
        #endregion
        #region METODE
        public Boolean registrujSekretaricu(Sekretarica sek)
        {
            foreach (Sekretarica s in SekretariceNaMrezi)
                if (sek.Korisnik.Id.Equals(s.Korisnik.Id))
                    return false;

            SekretariceNaMrezi.Add(sek);
            return true;
        }
        public List<Korisnik> posaljiPoruku(Poruka p)
        {
            List<Korisnik> neuspjelaSlanja = new List<Korisnik>();
            Boolean poslao = false;

            foreach(Sekretarica s in SekretariceNaMrezi)
            {
                if (s.Korisnik.Id == p.Posiljaoc.Id)
                {
                    s.spremiPoslanuPoruku(p);
                }
            }

            foreach (Korisnik k in p.Primaoci)
            {
                foreach (Sekretarica s in SekretariceNaMrezi)
                {
                    if (s.Korisnik.Id == k.Id)
                    {
                        s.primiPoruku(p);
                        poslao = true;
                    }
                }

                if (!poslao)
                    neuspjelaSlanja.Add(k);

                poslao = false;
            }

            return neuspjelaSlanja;
        }
        #endregion
    }
}
