using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    public class Quarter : USCoin
    {
        public Quarter():base()
        {
            MonetaryValue = .25;
            Name = "Quarter";
        }

        public Quarter(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .25;
            Name = "Quarter";
        }
    }
}
