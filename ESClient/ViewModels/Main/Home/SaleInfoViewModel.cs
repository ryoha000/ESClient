using Prism.Commands;
using Prism.Mvvm;
using System.Drawing;
using System.Windows.Media.Imaging;

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

        private BitmapFrame _faceImage = null;
        public BitmapFrame FaceImage
        {
            get { return _faceImage; }
            set { SetProperty(ref _faceImage, value); }
        }
        public DelegateCommand recognizeFace { get; private set; }
        public SaleInfoViewModel()
        {
            recognizeFace = new DelegateCommand(
                () => { FaceImage = Models.Main.Home.SaleInfoItemModel.recognizeFace(); },
                () => true);
        }
    }
}
