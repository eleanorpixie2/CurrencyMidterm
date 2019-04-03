using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public abstract class USCoin:Coin
    {
        //MintMark for US coins
        public USCoinMintMark MintMark { get; set; }

        //Constructor that defaults the mint mark to D
        public USCoin():this(USCoinMintMark.D)
        {
            Year = System.DateTime.Now.Year;
        }

        //Constructor that sets the mint mark
        public USCoin(USCoinMintMark mark)
        {
            MintMark = mark;
        }
        //returns a string about the coin
        public override string About()
        {
            return "US "+Name +" is from "+ Year +". It is worth "+ String.Format("{0:C}", MonetaryValue) 
                +". It was made in "+GetMintNameFromMark(MintMark);
        }

        //Get the name of the mintmark
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
