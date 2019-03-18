using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    public interface ICurrency
    {
        double MonetaryValue { get; set; }
        string Name { get; }

        string About();
    }
}
