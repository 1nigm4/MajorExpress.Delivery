namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Fields
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Логика взаимодействия для CardItem.xaml
    /// </summary>
    public partial class CardItem : UserControl
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(
                "Icon",
                typeof(string),
                typeof(CardItem),
                new PropertyMetadata("cargo"));

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register(
                "IconSize",
                typeof(int),
                typeof(CardItem),
                new PropertyMetadata(15));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(CardItem),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                "Color",
                typeof(Color),
                typeof(CardItem),
                new PropertyMetadata(ColorConverter.ConvertFromString("#FF9CA3AF")));

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register(
                "Fill",
                typeof(Color),
                typeof(CardItem),
                new PropertyMetadata(ColorConverter.ConvertFromString("#FF9CA3AF")));

        public CardItem()
        {
            InitializeComponent();
        }

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public int IconSize
        {
            get => (int)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public Color Fill
        {
            get => (Color)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }
    }
}
