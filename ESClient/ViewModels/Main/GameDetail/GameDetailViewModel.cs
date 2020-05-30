using ESClient.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Media.Imaging;

namespace ESClient.ViewModels.Main.GameDetail
{
    public class GameDetailViewModel : BindableBase
    {
        private BitmapImage _imageValue = null;
        public BitmapImage ImageValue
        {
            get { return _imageValue; }
            set { SetProperty(ref _imageValue, value); }
        }

        public DelegateCommand GetGameInfo { get; private set; }
        public GameDetailViewModel()
        {
            GetGameInfo = new DelegateCommand(
                async () => { 
                    Root.GameId = 1764;
                    await Models.Main.GameDetail.GameDetailModel.GetGameInfo(); 
                    ImageValue = Models.Root.Images[Root.GameId];
                },
                () => true);
            
        }

    }
}
