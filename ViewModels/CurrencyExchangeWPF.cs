using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        public ICommand Save { get; set; }

        public CurrencyExchangeWPF(CurrencyRepo change)
        {
            repo = change;
            GetChange = new WPFExchangeCommand(ExecuteCommandGetChange, CanExecuteCommandGetChange);
            Save = new WPFExchangeCommand(ExecuteCommandSave, CanExecuteCommandSave);
            if(repo.Coins.Count>0)
            {
                Amount = repo.TotalValue();
                RaisePropertyChanged("Amount");
                RaisePropertyChanged("Coins");
            }
        }

        private bool CanExecuteCommandGetChange(object parameter)
        {
            //makes sure the command can execute
            return true;
        }

        private void ExecuteCommandGetChange(object parameter)
        {
            CurrencyRepo tempRepo=(CurrencyRepo)CurrencyRepo.CreateChange(Amount);
            Coins = tempRepo.Coins;
            RaisePropertyChanged("Coins");
        }

        private bool CanExecuteCommandSave(object parameter)
        {
            //makes sure the command can execute
            return true;
        }

        private void ExecuteCommandSave(object parameter)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"...\Repo.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, repo);
            stream.Close();
        }

        public List<ICoin> Coins
        {
            get
            {
                return repo.Coins;
            }
            set
            {
                repo.Coins = value;
            }
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
