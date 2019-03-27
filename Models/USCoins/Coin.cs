using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    [Serializable]
    public abstract class Coin:ICoin
    {
        public double MonetaryValue { get; set; }
        public string Name { get; set; }     
        public int Year { get; set; }

        public virtual string About()
        {
            return "";
        }

        public Coin()
        {
            Name = "Coin";
            Year = DateTime.Now.Year;
            MonetaryValue = 0;
        }
    }
}
 