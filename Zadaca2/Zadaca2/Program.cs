using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadaca2a.Klase;

namespace Zadaca2
{
    class Program
    {
        static void Main(string[] args)
        {
            Kartica k = new Kartica("4012888888881881", 1000);
            Console.WriteLine(k.validirajBrojkartice("fdaklj"));

        }
    }
}
