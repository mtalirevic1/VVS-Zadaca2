using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca2a.Izuzeci;
using System.Text.RegularExpressions;

namespace Zadaca2a.Klase
{
    public class Kartica
    {
        String _brojKreditneKartice;
        // Validacija je stroga. Primjeri:
        // 1. 4012888888881881
        // 2. 4024007195736334
        // 3. 5560527397859946
        // 4. 6011816573426759
        // 5. 372948467675716
        Double _stanje;

        #region KONSTRUKTORI
        public Kartica() { }
        public Kartica(String brojKreditneKartice, Double stanje)
        {
            BrojKreditneKartice = brojKreditneKartice;
            Stanje = stanje;
        }
        #endregion
        #region PROPERTIES
        public String BrojKreditneKartice
        {
            get
            {
                return _brojKreditneKartice;
            }

            set
            {
                if (validirajBrojkartice(value))
                    _brojKreditneKartice = value;
                else
                    throw new CreditCardNotValidException("Broj kreditne kartice nije ispravan.");
            }
        }

        public Double Stanje
        {
            get
            {
                return _stanje;
            }

            set
            {
                if(value < 0)
                    throw new CreditCardNotValidException("Uneseno stanje na kartici nije ispravno.");

                _stanje = value;
            }
        }
        #endregion
        #region METODE
        public Boolean validirajBrojkartice(String broj)
        {
            if (string.IsNullOrEmpty(broj) && !broj.All(char.IsDigit)) 
              return false;
           
               

            int sumaCifara = broj.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);

            return sumaCifara % 10 == 0;
        }

        public static bool validirajSlova(string param)
        {
            Regex regex = new Regex("^[a-zA-Z]*$");
            if (regex.IsMatch(param))
            {
                return true;
            }
            return false;
        }

        public Boolean naplati(Double iznos)
        {
            if (Stanje < iznos)
                throw new NotEnoughMoneyException("Na računu nema dovoljno sredstava.");
            else
            {
                Stanje = Stanje - iznos;
                return true;
            }
        }
        #endregion
    }
}
