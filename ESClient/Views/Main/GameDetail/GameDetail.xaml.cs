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

namespace ESClient.Views.Main.GameDetail
{
    /// <summary>
    /// GameDetail.xaml の相互作用ロジック
    /// </summary>
    public partial class GameDetail : UserControl
    {
        public GameDetail()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Main.GameDetail.GameDetailViewModel();
        }
    }
}
