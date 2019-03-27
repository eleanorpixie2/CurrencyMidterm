using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CurrencyMidTerm
{
    [Serializable]
    public class CurrencyRepo:ICurrencyRepo
    {
       public List<ICoin> Coins { get; set; }
        public CurrencyRepo()
        {
            Coins = new List<ICoin>();
        }

       public string About()
        {
            return "General Currency Repo";
        }

        public void AddCoin(ICoin c)
        {
            if (c != null)
                Coins.Add(c);
        }

        public static ICurrencyRepo CreateChange(double Amount)
        {
            CurrencyRepo temp = new CurrencyRepo();
            while(Amount>0)
            {
                Amount = Math.Round(Amount, 2);
                if (Amount >= 1)
                {
                    DollarCoin dollar = new DollarCoin();
                    temp.AddCoin(dollar);
                    Amount--;
                }
                else if (Amount >= .5)
                {
                    HalfDollar dollar = new HalfDollar();
                    temp.AddCoin(dollar);
                    Amount -= .5;
                }
                else if (Amount >= .25)
                {
                    Quarter quater = new Quarter();
                    temp.AddCoin(quater);
                    Amount -= .25;
                }
                else if (Amount >= .1)
                {
                    Dime dime = new Dime();
                    temp.AddCoin(dime);
                    Amount -= .1;
                }
                else if (Amount >= .05)
                {
                    Nickel nickel = new Nickel();
                    temp.AddCoin(nickel);
                    Amount -= .05;
                }
                else if (Amount >= .01)
                {
                    Penny penny = new Penny();
                    temp.AddCoin(penny);
                    Amount -= .01;
                }
                
            }
            return temp;
        }

        public static ICurrencyRepo CreateChange(double AmountTendered,double TotalCost)
        {
            double change = Math.Round((AmountTendered - TotalCost),2);
            CurrencyRepo temp;
            if (change > 0)
            {
                temp = (CurrencyRepo)CreateChange(change);
            }
            else
            {
                temp = new CurrencyRepo();
            }
            return temp;
        }

        public int GetCoinCount()
        {
            return Coins.Count;
        }

        public ICurrencyRepo MakeChange(double Amount)
        {
            CurrencyRepo temp = new CurrencyRepo();
            while (Amount > 0)
            {
                if (Amount >= 1 
                    && Coins.Exists(x=>x.MonetaryValue==1))
                {
                    DollarCoin dollar = new DollarCoin();
                    temp.AddCoin(dollar);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == 1));
                    Amount--;
                }
                else if (Amount >= .5 
                    && Coins.Exists(x => x.MonetaryValue == .5))
                {
                    HalfDollar dollar = new HalfDollar();
                    temp.AddCoin(dollar);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .5));
                    Amount -= .5;
                }
                else if (Amount >= .25 
                    && Coins.Exists(x => x.MonetaryValue == .25))
                {
                    Quarter quater = new Quarter();
                    temp.AddCoin(quater);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .25));
                    Amount -= .25;
                }
                else if (Amount >= .1 
                    && Coins.Exists(x => x.MonetaryValue == .1))
                {
                    Dime dime = new Dime();
                    temp.AddCoin(dime);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .1));
                    Amount -= .1;
                }
                else if (Amount >= .05 
                    && Coins.Exists(x => x.MonetaryValue == .05))
                {
                    Nickel nickel = new Nickel();
                    temp.AddCoin(nickel);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .05));
                    Amount -= .05;
                }
                else if (Amount >= .01 
                    && Coins.Exists(x => x.MonetaryValue == .01))
                {
                    Penny penny = new Penny();
                    temp.AddCoin(penny);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .01));
                    Amount -= .01;
                }
                else if(this.TotalValue()>Amount)
                {
                    Amount = 0;
                }
                else
                {
                    Amount = Math.Round(Amount, 2);
                }
            }

            return temp;
        }

        public ICurrencyRepo MakeChange(double AmountTendered,double TotalCost)
        {
            double change = Math.Round((AmountTendered - TotalCost), 2);
            CurrencyRepo temp;
            if (change > 0)
            {
                temp = (CurrencyRepo)MakeChange(change);
            }
            else
            {
                temp = new CurrencyRepo();
            }
            return temp;
        }

        public void ReduceCoins()
        {
            double Amount = TotalValue();
            Coins = new List<ICoin>();
            while (Amount > 0)
            {
                Amount = Math.Round(Amount, 2);
                if (Amount >= 1)
                {
                    DollarCoin dollar = new DollarCoin();
                    AddCoin(dollar);
                    Amount--;
                }
                else if (Amount >= .5)
                {
                    HalfDollar dollar = new HalfDollar();
                    AddCoin(dollar);
                    Amount -= .5;
                }
                else if (Amount >= .25)
                {
                    Quarter quater = new Quarter();
                    AddCoin(quater);
                    Amount -= .25;
                }
                else if (Amount >= .1)
                {
                    Dime dime = new Dime();
                    AddCoin(dime);
                    Amount -= .1;
                }
                else if (Amount >= .05)
                {
                    Nickel nickel = new Nickel();
                    AddCoin(nickel);
                    Amount -= .05;
                }
                else if (Amount >= .01)
                {
                    Penny penny = new Penny();
                    AddCoin(penny);
                    Amount -= .01;
                }
                
            }
        }

        public ICoin RemoveCoin(ICoin c)
        {
            ICoin removed = Coins.Find(x=>x==c);
            Coins.Remove(c);
            return removed;
        }

        public double TotalValue()
        {
            double total=0;
            foreach(ICoin c in Coins)
            {
                total += c.MonetaryValue;
            }
            return total;
        }

    }
}
