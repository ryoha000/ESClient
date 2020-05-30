using Prism.Commands;
using Prism.Mvvm;

namespace ESClient.ViewModels.Main.GameDetail
{
    public class GameDetailViewModel : BindableBase
    {
        public DelegateCommand GetGameInfo { get; private set; }
        public GameDetailViewModel()
        {
            GetGameInfo = new DelegateCommand(
                async () => { await Models.Main.GameDetail.GameDetailModel.GetGameInfo(1764); },
                () => true);
        }

    }
}
