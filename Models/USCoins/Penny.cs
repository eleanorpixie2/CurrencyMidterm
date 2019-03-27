using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class Penny:USCoin
    {
        public Penny():base()
        {
            MonetaryValue = .01;
            Name = "Penny";
        }

        public Penny(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .01;
            Name = "Penny";
        }
    }
}
