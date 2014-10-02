using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public struct GuessedNumber
    {
        //innehåller en gissnings värde
        public int? Number;
        //innehåller om det var högt lågt osv.. från enum
        public Outcome Outcome;
    }
}