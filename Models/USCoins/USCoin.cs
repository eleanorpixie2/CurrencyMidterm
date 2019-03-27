using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public abstract class USCoin:Coin
    {
        public USCoinMintMark MintMark { get; set; }


        public USCoin():this(USCoinMintMark.D)
        {
            Year = System.DateTime.Now.Year;
        }

        public USCoin(USCoinMintMark mark)
        {
            MintMark = mark;
        }
        public override string About()
        {
            return "US "+Name +" is from "+ Year +". It is worth "+ String.Format("{0:C}", MonetaryValue) 
                +". It was made in "+GetMintNameFromMark(MintMark);
        }

        public static string GetMintNameFromMark(USCoinMintMark mark)
        {
            switch(mark.ToString())
            {
                case "D":
                    return "Denver";
                case "P":
                    return "Philadelphia";
                case "S":
                    return "San Francisco";
                case "W":
                    return "West Point";
                default:
                    return "Denver";

            }
        }
    }
}
