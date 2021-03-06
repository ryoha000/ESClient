﻿using ESClient.ViewModels.Main.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESClient.Views.Main.Home
{
    /// <summary>
    /// Home.xaml の相互作用ロジック
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel();
        }
    }
}
