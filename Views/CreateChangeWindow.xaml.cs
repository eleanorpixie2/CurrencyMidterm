﻿using CurrencyMidTerm.ViewModels;
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
using System.Windows.Shapes;

namespace CurrencyMidTerm
{
    /// <summary>
    /// Interaction logic for CreateChangeWindow.xaml
    /// </summary>
    public partial class CreateChangeWindow : Window
    {
        CurrencyRepo change;
        public CreateChangeWindow(CurrencyRepo repo)
        {
            change = repo;
            InitializeComponent();
        }

        //loads the user control
        private void ChangeViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrencyExchangeWPF viewControl = new CurrencyExchangeWPF(change);

            this.DataContext = viewControl;
            CurrencyView.DataContext = viewControl;


        }
    }
}
