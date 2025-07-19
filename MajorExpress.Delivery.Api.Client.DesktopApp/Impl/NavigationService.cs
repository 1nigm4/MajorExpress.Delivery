namespace MajorExpress.Delivery.Api.Client.DesktopApp.Impl
{
    using System.Windows;
    using System.Windows.Controls;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Interfaces;
    using MajorExpress.Delivery.Api.Client.DesktopApp.Views.Windows;
    using Microsoft.Extensions.DependencyInjection;
    
    class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private Window _currentWindow;


        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowWindow<T>() where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            _currentWindow = window;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        public void OpenEditor<TEditorControl>(Guid entityId) where TEditorControl : UserControl
        {
            var editorControl = _serviceProvider.GetRequiredService<TEditorControl>();
            var editor = new EditorWindow(editorControl, entityId);
            editor.Owner = _currentWindow;
            editor.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editor.ShowDialog();
        }
    }
}
