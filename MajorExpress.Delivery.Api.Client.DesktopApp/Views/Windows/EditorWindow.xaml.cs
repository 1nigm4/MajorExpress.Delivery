using System.Windows;
using System.Windows.Controls;
using MajorExpress.Delivery.Api.Client.DesktopApp.ViewModels.Editor;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        private readonly UserControl _editorControl;
        private readonly Guid _entityId;

        public EditorWindow(UserControl editorControl, Guid entityId)
        {
            _editorControl = editorControl;
            _entityId = entityId;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddChild(_editorControl);
            if (_editorControl.DataContext is EntityEditorViewModel entityEditorViewModel)
            {
                this.Title = entityEditorViewModel.EditorTitle;
                entityEditorViewModel.LoadAsync(_entityId);
            }
        }
    }
}
