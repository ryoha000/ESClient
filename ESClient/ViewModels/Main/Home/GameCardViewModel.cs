using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ESClient.ViewModels.Main.Home
{
    public class GameCardViewModel : BindableBase
    {
        private BitmapFrame _image = null;
        public BitmapFrame Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        public GameCardViewModel()
        {
            Image = Models.Main.Home.SaleInfoItemModel.recognizeFace(250, 125);
        }
    }
}
