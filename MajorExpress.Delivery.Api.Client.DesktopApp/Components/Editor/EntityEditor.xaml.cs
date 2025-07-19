using System.Windows;
using System.Windows.Controls;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Editor
{
    /// <summary>
    /// Логика взаимодействия для EntityEditor.xaml
    /// </summary>
    public partial class EntityEditor : UserControl
    {
        public static readonly DependencyProperty DataViewProperty =
            DependencyProperty.Register("DataView", typeof(object), typeof(EntityEditor));

        public static readonly DependencyProperty BottomPanelProperty =
            DependencyProperty.Register("BottomPanel", typeof(object), typeof(EntityEditor));

        public EntityEditor()
        {
            InitializeComponent();
        }

        public object DataView
        {
            get => GetValue(DataViewProperty);
            set => SetValue(DataViewProperty, value);
        }

        public object BottomPanel
        {
            get => GetValue(BottomPanelProperty);
            set => SetValue(BottomPanelProperty, value);
        }
    }
}
