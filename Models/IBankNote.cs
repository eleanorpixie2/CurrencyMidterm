using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    public interface IBankNote:ICurrency
    {
        int Year { get; }
    }
}
