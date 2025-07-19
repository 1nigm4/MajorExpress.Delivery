namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Fields
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Логика взаимодействия для TextField.xaml
    /// </summary>
    public partial class TextField : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
            Field.LabelTextProperty.AddOwner(typeof(TextField),
                new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(TextField),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty InputPaddingProperty =
            DependencyProperty.Register(
                "InputPadding",
                typeof(Thickness),
                typeof(TextField),
                new PropertyMetadata(new Thickness(5, 0, 5, 2)));

        public static readonly DependencyProperty IsReadonlyProperty =
            DependencyProperty.Register(
                "Readonly",
                typeof(bool),
                typeof(TextField));

        public TextField()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Thickness InputPadding
        {
            get => (Thickness)GetValue(InputPaddingProperty);
            set => SetValue(InputPaddingProperty, value);
        }

        public bool IsReadonly
        {
            get => (bool)GetValue(IsReadonlyProperty);
            set => SetValue(IsReadonlyProperty, value);
        }
    }
}
