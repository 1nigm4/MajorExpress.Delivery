using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor
{
    /// <summary>
    /// Логика взаимодействия для UserEditor.xaml
    /// </summary>
    public partial class UserEditor : UserControl
    {
        public UserEditor()
        {
            InitializeComponent();
        }

        public UserEditor(UserEditorViewModel viewModel) : this()
        {
            this.DataContext = viewModel;
        }
    }
}
