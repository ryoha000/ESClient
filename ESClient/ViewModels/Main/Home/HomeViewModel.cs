using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESClient.ViewModels.Main.Home
{
    public class HomeViewModel : BindableBase
    {
        public DelegateCommand TestButton { get; private set; }

        private async Task testButton()
        {
            var doc = await Models.Root.GetHTMLDocument("/");

            // HTMLからtitleタグの値(サイトのタイトルとして表示される部分)を取得する
            var title = doc.Title;

            System.Diagnostics.Debug.WriteLine(title);
            System.Diagnostics.Debug.WriteLine("test button");
        }

        public HomeViewModel()
        {
            TestButton = new DelegateCommand(
               async () => { await testButton(); },
                () => true);
        }
    }
}
