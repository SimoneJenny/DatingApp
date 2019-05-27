﻿using System;
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
using test.Primary_funkions;

namespace test
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

        private void opretkontoo(object sender, RoutedEventArgs e)
        {
            opretkonto opretk = new test.opretkonto();
            opretk.Show();
            this.Close();
        }

        private void Loginuser(object sender, RoutedEventArgs e)
        {
            vmOpret.Loginuser(); //den kan finde  loginuser via bindings. den kan findes i DOOPRET          
        }
    }
}
