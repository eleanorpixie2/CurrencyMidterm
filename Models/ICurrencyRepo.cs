using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyMidTerm
{
    public interface ICurrencyRepo
    {
        List<ICoin> Coins { get; set; }

        string About();

        void AddCoin(ICoin c);

        int GetCoinCount();

        ICurrencyRepo MakeChange(double Amount);

        ICurrencyRepo MakeChange(double AmountTendered, double TotalCost);

        ICoin RemoveCoin(ICoin c);

        double TotalValue();
    }
}
