using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public class Quarter : USCoin
    {
        //Constructor
        public Quarter():base()
        {
            //set the value and name of the quarter
            MonetaryValue = .25;
            Name = "Quarter";
        }

        //overload constructor that sets the mint mark
        public Quarter(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .25;
            Name = "Quarter";
        }
    }
}
