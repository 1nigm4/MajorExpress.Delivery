using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry;
using MajorExpress.Delivery.Api.Client.DesktopApp.Views.Windows;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry
{
    /// <summary>
    /// Логика взаимодействия для CargoRegistry.xaml
    /// </summary>
    public partial class CargoRegistry : UserControl
    {
        public CargoRegistry()
        {
            InitializeComponent();
        }

        public CargoRegistry(CargoRegistryViewModel viewModel) : this()
        {
            this.DataContext = viewModel;
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not TextBlock) return;

            if (this.DataContext is EntityRegistryViewModel viewModel)
            {
                if (viewModel.SelectionEntity != null)
                {
                    viewModel.SelectedEntity = viewModel.SelectionEntity;
                    if (this.Parent is RegistryWindow registryWindow)
                    {
                        registryWindow.Close();
                    }
                }
            }
        }
    }
}
