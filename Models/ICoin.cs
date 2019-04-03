using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    //coin interface
    public interface ICoin:ICurrency
    {
        //return the year
        int Year { get; }
    }
}
