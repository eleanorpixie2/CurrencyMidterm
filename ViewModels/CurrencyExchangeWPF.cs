using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyMidTerm.ViewModels
{
    class CurrencyExchangeWPF : INotifyPropertyChanged
    {
        CurrencyRepo repo;

        public ICommand GetChange { get; set; }

        public CurrencyExchangeWPF(CurrencyRepo change)
        {
            repo = change;
            GetChange = new WPFExchangeCommand(ExecuteCommandGetChange, CanExecuteCommandGetChange);
        }

        private bool CanExecuteCommandGetChange(object parameter)
        {
            //makes sure the command can execute
            return true;
        }

        private void ExecuteCommandGetChange(object parameter)
        {
            CurrencyRepo tempRepo=(CurrencyRepo)CurrencyRepo.CreateChange(Amount);
            repo.Coins = tempRepo.Coins;
            List<string> tempStrings = new List<string>();
            foreach(ICoin c in repo.Coins)
            {
                tempStrings.Add(c.About());
            }
            Coins = tempStrings;
            RaisePropertyChanged("Coins");
        }

        public List<string> Coins
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;         
        }

        //Event management
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
public class WPFExchangeCommand : ICommand
{
    public delegate void ICommandOnExecute(object parameter);
    public delegate bool ICommandOnCanExecute(object parameter);

    private ICommandOnExecute _execute;
    private ICommandOnCanExecute _canExecute;

    public WPFExchangeCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
    {
        _execute = onExecuteMethod;
        _canExecute = onCanExecuteMethod;
    }

    #region ICommand Members

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute.Invoke(parameter);
    }

    public void Execute(object parameter)
    {
        _execute.Invoke(parameter);
    }

    #endregion
}
