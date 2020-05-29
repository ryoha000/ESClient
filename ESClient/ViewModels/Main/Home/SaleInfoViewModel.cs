using Prism.Commands;
using Prism.Mvvm;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace ESClient.ViewModels.Main.Home
{
    public class SaleInfoViewModel : BindableBase
    {
        private string _campaign = "キャンペーン名";
        public string Campaign
        {
            get { return _campaign; }
            set { SetProperty(ref _campaign, value); }
        }
    }
}
