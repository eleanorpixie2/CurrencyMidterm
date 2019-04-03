using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class HalfDollar : USCoin
    {
        //constructor
        public HalfDollar():base()
        {
            //set the name and value of the half dollar
            MonetaryValue = .5;
            Name = "Half Dollar";
        }

        //overload constructor that sets the mint mark
        public HalfDollar(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .5;
            Name = "Half Dollar";
        }
    }
}
