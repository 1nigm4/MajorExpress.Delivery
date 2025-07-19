using System.Windows;
using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Registry;
using MajorExpress.Delivery.Api.Client.DesktopApp.Views.Windows;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Fields
{
    /// <summary>
    /// Логика взаимодействия для RegistryField.xaml
    /// </summary>
    public partial class RegistryField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
           Field.LabelTextProperty.AddOwner(typeof(RegistryField),
               new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(object), typeof(RegistryField));

        public static readonly DependencyProperty ModelValueProperty =
            DependencyProperty.Register("ModelValue", typeof(object), typeof(RegistryField));

        public static readonly DependencyProperty RegistryProperty =
            DependencyProperty.Register("Registry", typeof(UserControl), typeof(RegistryField));

        public RegistryField()
        {
            InitializeComponent();
        }

        public string DisplayValue
        {
            get => (string)GetValue(DisplayValueProperty);
            set => SetValue(DisplayValueProperty, value);
        }

        public object ModelValue
        {
            get => GetValue(ModelValueProperty);
            set => SetValue(ModelValueProperty, value);
        }

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public UserControl Registry
        {
            get => (UserControl)GetValue(RegistryProperty);
            set => SetValue(RegistryProperty, value);
        }

        private void OpenRegistry(object sender, RoutedEventArgs e)
        {
            var registry = new RegistryWindow(this.Registry);
            registry.ShowDialog();
            this.ModelValue = (this.Registry.DataContext as EntityRegistryViewModel)?.SelectedEntity ?? this.ModelValue;
        }
    }
}
