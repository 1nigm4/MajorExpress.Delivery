using System.Windows;
using System.Windows.Controls;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Fields
{
    /// <summary>
    /// Логика взаимодействия для DateField.xaml
    /// </summary>
    public partial class DateField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
           Field.LabelTextProperty.AddOwner(typeof(DateField),
               new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(DateTime),
                typeof(DateField),
                new FrameworkPropertyMetadata(DateTime.UtcNow, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public DateField()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public DateTime Text
        {
            get => (DateTime)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}
