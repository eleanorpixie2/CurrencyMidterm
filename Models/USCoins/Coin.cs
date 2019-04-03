using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public abstract class Coin:ICoin
    {
        //value of the coin
        public double MonetaryValue { get; set; }
        //Name of the coin
        public string Name { get; set; }     
        //year the coin was made
        public int Year { get; set; }

        //return string about the coin
        public virtual string About()
        {
            string about=$"The name of the coin is {Name}. It is worth {MonetaryValue}. It was made in {Year}";
            return about;
        }

        //Constructor
        public Coin()
        {
            //Intial values
            Name = "Coin";
            Year = DateTime.Now.Year;
            MonetaryValue = 0;
        }
    }
}
 