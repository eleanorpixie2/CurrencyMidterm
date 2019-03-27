using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class HalfDollar : USCoin
    {
        public HalfDollar():base()
        {
            MonetaryValue = .5;
            Name = "Half Dollar";
        }

        public HalfDollar(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .5;
            Name = "Half Dollar";
        }
    }
}
