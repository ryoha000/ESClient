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
    /// GameInfo.xaml の相互作用ロジック
    /// </summary>
    public partial class GameInfo : UserControl
    {
        public uint GameId
        {
            get { return (uint)GetValue(GameIdProperty); }
            set { SetValue(GameIdProperty, value); }
        }
        public static readonly DependencyProperty GameIdProperty =
            DependencyProperty.Register(
                "GameId",
                typeof(uint),
                typeof(GameInfo),
                new PropertyMetadata((uint)0));
        public GameInfo()
        {
            InitializeComponent();
        }
    }
}
