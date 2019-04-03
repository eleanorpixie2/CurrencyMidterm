using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class Penny:USCoin
    {
        //constructor
        public Penny():base()
        {
            //set the value and name of the penny
            MonetaryValue = .01;
            Name = "Penny";
        }

        //overload constructor that sets the mint mark
        public Penny(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .01;
            Name = "Penny";
        }
    }
}
