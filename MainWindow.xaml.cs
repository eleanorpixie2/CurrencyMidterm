using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CurrencyMidTerm.ViewModels;

namespace CurrencyMidTerm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //loads the user control
        private void ChangeViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrencyExchangeWPF viewControl = new CurrencyExchangeWPF(new CurrencyRepo());

            this.DataContext = viewControl;
            CurrencyView.DataContext = viewControl;


        }
    }
}
