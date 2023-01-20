using System.Windows;

namespace CustomersMaintenanceSchad.Services.helpers
{
    public class MessageService : IMessageService
    {
        public void ShowMessage(string message, string messageTitle = "Información")
        {
            _ = MessageBox.Show(message, messageTitle, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool ShowConfirmationMessage(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public void ShowWarningMessage(string message)
        {
            _ = MessageBox.Show(message, "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowErrorMessage(string message)
        {
            _ = MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
