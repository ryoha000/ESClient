using Prism.Mvvm;

namespace ESClient.ViewModels.Main.Home
{
    class SaleInfoViewModel : BindableBase
    {
        private string _campaign = "キャンペーン名";
        public string Campaign
        {
            get { return _campaign; }
            set { SetProperty(ref _campaign, value); }
        }
    }
}
