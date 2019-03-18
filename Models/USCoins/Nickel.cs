using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    public class Nickel : USCoin
    {
        public Nickel():base()
        {
            MonetaryValue = .05;
            Name = "Nickel";
        }

        public Nickel(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .05;
            Name = "Nickel";
        }
    }
}
