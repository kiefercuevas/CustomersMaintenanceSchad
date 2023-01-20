namespace CustomersMaintenanceSchad.Services.helpers
{
    public interface IMessageService
    {
        bool ShowConfirmationMessage(string message);
        void ShowErrorMessage(string message);
        void ShowMessage(string message, string messageTitle = "Información");
        void ShowWarningMessage(string message);
    }
}