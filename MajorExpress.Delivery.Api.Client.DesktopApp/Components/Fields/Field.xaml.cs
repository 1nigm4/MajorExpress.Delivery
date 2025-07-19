using System.Windows;
using System.Windows.Controls;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Fields
{
    /// <summary>
    /// Логика взаимодействия для Field.xaml
    /// </summary>
    public partial class Field : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(Field),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SlotProperty =
            DependencyProperty.Register("Slot", typeof(object), typeof(Field));

        public Field()
        {
            InitializeComponent();
        }

        public Visibility LabelVisibility => string.IsNullOrWhiteSpace(this.LabelText) ? Visibility.Collapsed : Visibility.Visible;

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public object Slot
        {
            get => GetValue(SlotProperty);
            set => SetValue(SlotProperty, value);
        }
    }
}
