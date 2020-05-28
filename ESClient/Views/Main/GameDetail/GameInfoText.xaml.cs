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
    /// GameInfoText.xaml の相互作用ロジック
    /// </summary>
    public partial class GameInfoText : UserControl
    {
        /// <summary>
        /// 文字列の依存関係プロパティ
        /// </summary>
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                "Label",                               // プロパティ名
                typeof(string),                         // プロパティの型
                typeof(GameInfoText),              // プロパティを所有する型＝このクラスの名前
                new PropertyMetadata(string.Empty));    // 初期値

        /// <summary>
        /// 文字列の依存関係プロパティ
        /// </summary>
        public string Naiyou
        {
            get { return (string)GetValue(NaiyouProperty); }
            set { SetValue(NaiyouProperty, value); }
        }
        public static readonly DependencyProperty NaiyouProperty =
            DependencyProperty.Register(
                "Naiyou",                               // プロパティ名
                typeof(string),                         // プロパティの型
                typeof(GameInfoText),              // プロパティを所有する型＝このクラスの名前
                new PropertyMetadata(string.Empty));    // 初期値

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameInfoText()
        {
            InitializeComponent();
        }
    }
}
