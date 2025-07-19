namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry
{
    using System.Windows.Controls;
    using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry;

    /// <summary>
    /// Логика взаимодействия для OrderRegistry.xaml
    /// </summary>
    public partial class OrderRegistry : UserControl
    {
        public OrderRegistry()
        {
            InitializeComponent();
        }

        public OrderRegistry(OrderRegistryViewModel viewModel) : this()
        {
            this.DataContext = viewModel;
        }
    }
}
