using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor
{
    /// <summary>
    /// Логика взаимодействия для UserEditor.xaml
    /// </summary>
    public partial class CourierEditor : UserControl
    {
        public CourierEditor()
        {
            InitializeComponent();
        }

        public CourierEditor(CourierEditorViewModel viewModel) : this()
        {
            this.DataContext = viewModel;
        }
    }
}
