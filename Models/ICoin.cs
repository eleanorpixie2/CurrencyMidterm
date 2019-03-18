using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    public interface ICoin:ICurrency
    {
        int Year { get; }
    }
}
