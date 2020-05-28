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
    /// Link.xaml の相互作用ロジック
    /// </summary>
    public partial class Link : UserControl
    {
        /// <summary>
        /// 文字列の依存関係プロパティ
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",                               // プロパティ名
                typeof(string),                         // プロパティの型
                typeof(Link),              // プロパティを所有する型＝このクラスの名前
                new PropertyMetadata(string.Empty));    // 初期値
        public Link()
        {
            InitializeComponent();
        }
    }
}
