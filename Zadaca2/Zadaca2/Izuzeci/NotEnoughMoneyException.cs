using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca2a.Izuzeci
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string p)
            : base(p)
        {

        }
    }
}
