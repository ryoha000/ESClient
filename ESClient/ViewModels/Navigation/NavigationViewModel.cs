using Prism.Mvvm;

namespace ESClient.ViewModels.Navigation
{
    public class NavigationViewModel : BindableBase
    {
        private string _title = "root side bar";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public NavigationViewModel()
        {

        }
    }
}
