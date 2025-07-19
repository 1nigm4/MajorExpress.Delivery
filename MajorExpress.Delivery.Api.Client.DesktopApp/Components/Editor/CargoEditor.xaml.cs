using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor
{
    /// <summary>
    /// Логика взаимодействия для CargoEditor.xaml
    /// </summary>
    public partial class CargoEditor : UserControl
    {
        public CargoEditor()
        {
            InitializeComponent();
        }

        public CargoEditor(CargoEditorViewModel viewModel) : this()
        {
            this.DataContext = viewModel;
        }
    }
}
