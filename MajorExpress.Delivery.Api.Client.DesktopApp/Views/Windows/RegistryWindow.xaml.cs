using System.Windows;
using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistryWindow.xaml
    /// </summary>
    public partial class RegistryWindow : Window
    {
        private readonly UserControl entityRegistry;

        public RegistryWindow()
        {
            InitializeComponent();
        }

        public RegistryWindow(UserControl entityRegistry) : this()
        {
            this.entityRegistry = entityRegistry;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddChild(this.entityRegistry);
            if (entityRegistry.DataContext is EntityRegistryViewModel entityRegistryViewModel)
            {
                this.Title = entityRegistryViewModel.RegistryTitle;
            }

            base.OnActivated(e);
        }
    }
}
