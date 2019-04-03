using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    //currency interface
    public interface ICurrency
    {
        //value of the currency
        double MonetaryValue { get; set; }
        //return the name of the currency
        string Name { get; }
        //return an about string for the currency
        string About();
    }
}
