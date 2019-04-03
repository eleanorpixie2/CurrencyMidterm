using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class DollarCoin : USCoin
    {
        //Constructor
        public DollarCoin():base()
        {
            //set the name and value of the dollar coin
            MonetaryValue = 1;
            Name = "Dollar Coin";
        }

        //overload constructor that sets the mint mark
        public DollarCoin(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = 1;
            Name = "Dollar Coin";
        }
    }
}
