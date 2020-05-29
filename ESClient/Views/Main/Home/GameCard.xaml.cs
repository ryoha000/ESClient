using ESClient.ViewModels.Main.Home;
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
    /// GameCard.xaml の相互作用ロジック
    /// </summary>
    public partial class GameCard : UserControl
    {
        /// <summary>
        /// BitmapFrameの依存関係プロパティ
        /// </summary>
        public BitmapFrame Image
        {
            get { return (BitmapFrame)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(
                "Image",                               // プロパティ名
                typeof(BitmapFrame),                         // プロパティの型
                typeof(GameCard),              // プロパティを所有する型＝このクラスの名前
                new PropertyMetadata(null));    // 初期値

        public string Text1
        {
            get { return (string)GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }
        public static readonly DependencyProperty Text1Property =
            DependencyProperty.Register(
                "Text1",                               // プロパティ名
                typeof(string),                         // プロパティの型
                typeof(GameCard),              // プロパティを所有する型＝このクラスの名前
                new PropertyMetadata(null));    // 初期値

        public string Text2
        {
            get { return (string)GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }
        public static readonly DependencyProperty Text2Property =
            DependencyProperty.Register(
                "Text2",                               // プロパティ名
                typeof(string),                         // プロパティの型
                typeof(GameCard),              // プロパティを所有する型＝このクラスの名前
                new PropertyMetadata(null));    // 初期値

        public GameCard()
        {
            InitializeComponent();
            this.DataContext = new GameCardViewModel();
        }
    }
}
