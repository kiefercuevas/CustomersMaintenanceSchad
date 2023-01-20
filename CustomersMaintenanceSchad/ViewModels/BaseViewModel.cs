namespace CustomersMaintenanceSchad.ViewModels
{
    public class BaseViewModel : ViewNofityObject
    {
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

    }

}
