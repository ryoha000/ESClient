using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// SaleInfo.xaml の相互作用ロジック
    /// </summary>
    public partial class SaleInfo : UserControl
    {
        public SaleInfo()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Main.Home.SaleInfoViewModel();
        }
    }
}
