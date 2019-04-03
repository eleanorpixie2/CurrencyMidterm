using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class Nickel : USCoin
    {
        //constructor
        public Nickel():base()
        {
            //sets the value and name of the nickel
            MonetaryValue = .05;
            Name = "Nickel";
        }

        //overload constructor that sets the mint mark
        public Nickel(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .05;
            Name = "Nickel";
        }
    }
}
