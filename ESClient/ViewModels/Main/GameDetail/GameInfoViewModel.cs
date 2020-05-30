using Prism.Mvvm;

namespace ESClient.ViewModels.Main.GameDetail
{
    public class GameInfoViewModel : BindableBase
    {
        private string _gameId = "Prism Application";
        public string GameId
        {
            get { return _gameId; }
            set { SetProperty(ref _gameId, value); }
        }
    }
}
