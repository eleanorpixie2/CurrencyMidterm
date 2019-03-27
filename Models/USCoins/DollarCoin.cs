using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class DollarCoin : USCoin
    {
        public DollarCoin():base()
        {
            MonetaryValue = 1;
            Name = "Dollar Coin";
        }

        public DollarCoin(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = 1;
            Name = "Dollar Coin";
        }
    }
}
