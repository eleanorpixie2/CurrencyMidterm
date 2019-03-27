using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CurrencyMidTerm.ViewModels
{
    class RepoWPF:INotifyPropertyChanged
    {
        //repo object
        public CurrencyRepo repo;
        //commands
        public ICommand Load { get; set; }
        public ICommand NewRepo { get; set; }
        public ICommand Save { get; set; }
        public ICommand Add { get; set; }

        //intialize 
        public RepoWPF(CurrencyRepo change)
        {
            //repo object
            repo = change;
            ObservableCollection<ICoin> temp = new ObservableCollection<ICoin>()
            {
                new Penny(),
                new Nickel(),
                new Dime(),
                new Quarter(),
                new HalfDollar(),
                new DollarCoin()
            };

            TypesOfCoin = temp;

            SelectedCoin = temp[0];

             //Commands
            Load = new WPFRepoCommand(ExecuteCommandLoad, CanExecuteCommand);
            NewRepo = new WPFRepoCommand(ExecuteCommandNewRepo, CanExecuteCommand);
            Save = new WPFRepoCommand(ExecuteCommandSave, CanExecuteCommand);
            Add = new WPFRepoCommand(ExecuteCommandAdd, CanExecuteCommand);
            //set the default value for the number of coins to add
            NumberCoinsToAdd = 1;
        }
        //Can execute a command
        private bool CanExecuteCommand(object parameter)
        {
            //makes sure the command can execute
            return true;
        }

        //load a repo
        private void ExecuteCommandLoad(object parameter)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"...\Repo.txt", FileMode.Open, FileAccess.Read);
            repo = (CurrencyRepo)formatter.Deserialize(stream);
            stream.Close();
            repo.ReduceCoins();
            RaisePropertyChanged("TotalAmount");
        }

        //Create a new repo
        private void ExecuteCommandNewRepo(object parameter)
        {
            repo = new CurrencyRepo();
            RaisePropertyChanged("TotalAmount");
        }

        //save the repo
        private void ExecuteCommandSave(object parameter)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"...\Repo.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, repo);
            stream.Close(); 
        }

        //Add a coin to the repo
        private void ExecuteCommandAdd(object parameter)
        {
            for(int i=0;i<NumberCoinsToAdd;i++)
            {
                repo.AddCoin(SelectedCoin);
            }
            NumberCoinsToAdd = 1;
            RaisePropertyChanged("TotalAmount");
        }

        //Total dollar amount
        public double TotalAmount
        {   get
            {
                return repo.TotalValue();
            }
        }

        //Number of a coin to add to the repo
        private int _coinsToAdd = 1;
        public int NumberCoinsToAdd
        {
            get
            {
                return _coinsToAdd;
            }
            set
            {
                if (_coinsToAdd != value)
                {
                    _coinsToAdd = value;
                    RaisePropertyChanged("NumberCoinsToAdd");
                }
            }
        }

        //Coins that can be added to the repo
        public ObservableCollection<ICoin> TypesOfCoin
        {
            get;
            set;
        }

        //The selected coin
        public ICoin SelectedCoin
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

    public class WPFRepoCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public WPFRepoCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
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
}
