using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    //repo interface
    public interface ICurrencyRepo
    {
        //list of coins
        List<ICoin> Coins { get; set; }

        //return string about the repo
        string About();

        //add a coin to the repo
        void AddCoin(ICoin c);

        //get the amount of coins in the repo
        int GetCoinCount();

        //Make change from the repo, based on a amount
        ICurrencyRepo MakeChange(double Amount);

        //Make change from the repo, based on the amount need and the amount given
        ICurrencyRepo MakeChange(double AmountTendered, double TotalCost);

        //remove a coin from the repo
        ICoin RemoveCoin(ICoin c);

        //calculate the total value of the coins in the repo
        double TotalValue();
    }
}
