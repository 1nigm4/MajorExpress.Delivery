namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Registry
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry;

    /// <summary>
    /// Логика взаимодействия для EntityRegistry.xaml
    /// </summary>
    public partial class EntityRegistry : UserControl
    {
        public static readonly DependencyProperty DataViewProperty =
            DependencyProperty.Register("DataView", typeof(object), typeof(EntityRegistry));

        public EntityRegistry()
        {
            InitializeComponent();
        }

        public object DataView
        {
            get => GetValue(DataViewProperty);
            set => SetValue(DataViewProperty, value);
        }

        private async void Root_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            if (this.DataContext is EntityRegistryViewModel entityRegistryViewModel)
            {
                await entityRegistryViewModel.LoadStoreAsync();
            }
        }
    }
}
