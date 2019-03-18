using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    public class Dime : USCoin
    {
        public Dime():base()
        {
            MonetaryValue = .1;
            Name = "Dime";
        }

        public Dime(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .1;
            Name = "Dime";
        }
    }
}
