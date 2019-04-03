using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable] 
    public class Dime : USCoin
    {
        //Constructor
        public Dime():base()
        {
            //set value and name of the US dime
            MonetaryValue = .1;
            Name = "Dime";
        }

        //Overload constructor, sets the mint mark
        public Dime(USCoinMintMark mark):base(mark:mark)
        {
            MonetaryValue = .1;
            Name = "Dime";
        }
    }
}
