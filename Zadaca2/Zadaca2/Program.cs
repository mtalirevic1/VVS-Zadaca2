using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca2a;
using Zadaca2a.Klase;

namespace Zadaca2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kartica k = new Kartica("4012888888881881", 1000);
            // Console.WriteLine(k.validirajBrojkartice("fdaklj"));
            Korisnik korisnik = new Korisnik("Matej", "Talirevic", "999999", new DateTime(1998, 2, 25), "0", 1000);
            Sekretarica sekretarica = new Sekretarica(korisnik);
            
            List<Poruka> poruke = new List<Poruka>();
            Poruka p1 = new Poruka("", new DateTime(2019, 10, 3), null, null);
            Poruka p2 = new Poruka("", new DateTime(2019, 10, 2), null, null);
            Poruka p3 = new Poruka("", new DateTime(2019, 10, 1), null, null);
            poruke.Add(p1);
            poruke.Add(p2);
            poruke.Add(p3);
            

        }
    }
}
