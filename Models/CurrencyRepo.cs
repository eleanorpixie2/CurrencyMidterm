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
        //List of coins that belong to the current repo
       public List<ICoin> Coins { get; set; }
        //constructor
        public CurrencyRepo()
        {
            //intialize the list
            Coins = new List<ICoin>();
        }

        //returns a string about the repo
       public string About()
        {
            return "US Currency Repo";
        }

        //Adds a coin to the list
        public void AddCoin(ICoin c)
        {
            if (c != null)
                Coins.Add(c);
        }

        //Creates a new repo with a list of coins that
        //equal the amount passed in
        public static ICurrencyRepo CreateChange(double Amount)
        {
            //Create a temporary repo
            CurrencyRepo temp = new CurrencyRepo();
            //While the amount is above zero add coins
            while(Amount>0)
            {
                //round to 2 decimal places to avoid decimal place error
                Amount = Math.Round(Amount, 2);
                //if amount is greater than 1, add a dollar coin
                if (Amount >= 1)
                {
                    DollarCoin dollar = new DollarCoin();
                    temp.AddCoin(dollar);
                    Amount--;
                }
                //if amount is less than a dollar but greater than .5 then add a half dollar
                else if (Amount >= .5)
                {
                    HalfDollar dollar = new HalfDollar();
                    temp.AddCoin(dollar);
                    Amount -= .5;
                }
                //if the amount is greater than or equal to .25 and less than above then add a quarter
                else if (Amount >= .25)
                {
                    Quarter quater = new Quarter();
                    temp.AddCoin(quater);
                    Amount -= .25;
                }
                //if the amount is greater than or equal to .1 and less than above then add a dime
                else if (Amount >= .1)
                {
                    Dime dime = new Dime();
                    temp.AddCoin(dime);
                    Amount -= .1;
                }
                //if the amount is greater than or equal to .05 and less than above then add a nickel
                else if (Amount >= .05)
                {
                    Nickel nickel = new Nickel();
                    temp.AddCoin(nickel);
                    Amount -= .05;
                }
                //if the amount is greater than or equal to .01 and less than above then add a penny
                else if (Amount >= .01)
                {
                    Penny penny = new Penny();
                    temp.AddCoin(penny);
                    Amount -= .01;
                }
                
            }
            //return the temporary repo
            return temp;
        }

        //return a new repo with a list of coins that equal the amount of change required
        public static ICurrencyRepo CreateChange(double AmountTendered,double TotalCost)
        {
            //Get the amount of change needed
            double change = Math.Round((AmountTendered - TotalCost),2);
            //Create a temporary repo
            CurrencyRepo temp;
            //If change is needed then call the other create change method 
            //and pass in the amount of change needed
            if (change > 0)
            {
                temp = (CurrencyRepo)CreateChange(change);
            }
            //otherwise return a empty repo
            else
            {
                temp = new CurrencyRepo();
            }
            return temp;
        }

        //return the number of coins in the list
        public int GetCoinCount()
        {
            return Coins.Count;
        }

        //return a repo of change based on the amount of coins currently in this repo
        public ICurrencyRepo MakeChange(double Amount)
        {
            //create temporary repo
            CurrencyRepo temp = new CurrencyRepo();
            //while the amount is greater than 0, add coins
            while (Amount > 0)
            {
                Amount = Math.Round(Amount, 2);
                //If the amount is greater than or equal to 1 and the current repo has a dollar coin, 
                //add the dollar coin to the new repo and remove it from the current repo
                if (Amount >= 1 
                    && Coins.Exists(x=>x.MonetaryValue==1))
                {
                    DollarCoin dollar = new DollarCoin();
                    temp.AddCoin(dollar);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == 1));
                    Amount--;
                }
                //If the amount is greater than or equal to .5 and the current repo has a half dollar, 
                //add the half dollar to the new repo and remove it from the current repo
                else if (Amount >= .5 
                    && Coins.Exists(x => x.MonetaryValue == .5))
                {
                    HalfDollar dollar = new HalfDollar();
                    temp.AddCoin(dollar);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .5));
                    Amount -= .5;
                }
                //If the amount is greater than or equal to .25 and the current repo has a quarter, 
                //add the quarter to the new repo and remove it from the current repo
                else if (Amount >= .25 
                    && Coins.Exists(x => x.MonetaryValue == .25))
                {
                    Quarter quater = new Quarter();
                    temp.AddCoin(quater);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .25));
                    Amount -= .25;
                }
                //If the amount is greater than or equal to .1 and the current repo has a dime, 
                //add the dime to the new repo and remove it from the current repo
                else if (Amount >= .1 
                    && Coins.Exists(x => x.MonetaryValue == .1))
                {
                    Dime dime = new Dime();
                    temp.AddCoin(dime);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .1));
                    Amount -= .1;
                }
                //If the amount is greater than or equal to .05 and the current repo has a nickel, 
                //add the nickel to the new repo and remove it from the current repo
                else if (Amount >= .05 
                    && Coins.Exists(x => x.MonetaryValue == .05))
                {
                    Nickel nickel = new Nickel();
                    temp.AddCoin(nickel);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .05));
                    Amount -= .05;
                }
                //If the amount is greater than or equal to .01 and the current repo has a penny, 
                //add the penny to the new repo and remove it from the current repo
                else if (Amount >= .01 
                    && Coins.Exists(x => x.MonetaryValue == .01))
                {
                    Penny penny = new Penny();
                    temp.AddCoin(penny);
                    RemoveCoin(Coins.Find(x => x.MonetaryValue == .01));
                    Amount -= .01;
                }
                //If there aren't enough coins then zero out the amount to break the loop
                else if(this.TotalValue()>Amount)
                {
                    Amount = 0;
                }
                
            }

            return temp;
        }

        //return a new repo
        public ICurrencyRepo MakeChange(double AmountTendered,double TotalCost)
        {
            //calculate the change needed
            double change = Math.Round((AmountTendered - TotalCost), 2);
            //create a temporary repo to return
            CurrencyRepo temp;
            //if there is change needed to be returned then call the other make change method
            if (change > 0)
            {
                temp = (CurrencyRepo)MakeChange(change);
            }
            //otherwise return a empty repo
            else
            {
                temp = new CurrencyRepo();
            }
            return temp;
        }

        //reduce the amount of coins in the repo
        public void ReduceCoins()
        {
            //Calculate the total amount of coins in the repo
            double Amount = TotalValue();
            //empty the list
            Coins = new List<ICoin>();
            //While the amount is greater than zero add coins
            while (Amount > 0)
            {
                //round the amount to 2 decimal places to avoid decimal errors
                Amount = Math.Round(Amount, 2);
                //add a dollar coin if possible
                if (Amount >= 1)
                {
                    DollarCoin dollar = new DollarCoin();
                    AddCoin(dollar);
                    Amount--;
                }
                //add a half dollar if possible
                else if (Amount >= .5)
                {
                    HalfDollar dollar = new HalfDollar();
                    AddCoin(dollar);
                    Amount -= .5;
                }
                //add a quarter if possible
                else if (Amount >= .25)
                {
                    Quarter quater = new Quarter();
                    AddCoin(quater);
                    Amount -= .25;
                }
                //add a dime if possible
                else if (Amount >= .1)
                {
                    Dime dime = new Dime();
                    AddCoin(dime);
                    Amount -= .1;
                }
                //add a nickel if possible
                else if (Amount >= .05)
                {
                    Nickel nickel = new Nickel();
                    AddCoin(nickel);
                    Amount -= .05;
                }
                //add a penny if possible
                else if (Amount >= .01)
                {
                    Penny penny = new Penny();
                    AddCoin(penny);
                    Amount -= .01;
                }
                
            }
        }

        //remove a coin from the list and then return it
        public ICoin RemoveCoin(ICoin c)
        {
            ICoin removed = Coins.Find(x=>x==c);
            Coins.Remove(c);
            return removed;
        }

        //calculatet the total value of the coins in the repo
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
