namespace MajorExpress.Delivery.Api.Client.DesktopApp.Impl
{
    using System.Windows;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;

    public class NotificationService : INotificationService
    {
        public void Alert(string text, string? title = null)
        {
            MessageBox.Show(text, title);
        }
    }
}
