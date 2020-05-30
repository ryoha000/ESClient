using Prism.Mvvm;

namespace ESClient.ViewModels.Main.GameDetail
{
    public class LineViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}