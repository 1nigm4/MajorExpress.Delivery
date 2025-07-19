using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor
{
    /// <summary>
    /// Логика взаимодействия для OrderEditor.xaml
    /// </summary>
    public partial class OrderEditor : UserControl
    {
        public OrderEditor()
        {
            InitializeComponent();
        }

        public OrderEditor(OrderEditorViewModel viewModel) : this()
        {
            this.DataContext = viewModel;
        }
    }
}
