using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Navigation;
using System.Printing;

namespace ESClient.ViewModels.Navigation
{
    public class GamesListItemViewModel : BindableBase
    {
        private string _gamePath = "game_name";
        public string GamePath
        {
            get { return _gamePath; }
            set { SetProperty(ref _gamePath, value); }
        }
        private System.Windows.Media.ImageSource _gameIcon = null;
        public System.Windows.Media.ImageSource GameIcon
        {
            get { return _gameIcon; }
            set { SetProperty(ref _gameIcon, value); }
        }
        public GamesListItemViewModel()
        {
            GameIcon = Models.Navigation.GameListItemModel.ShowIcon();
        }
    }
}
