using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MajorExpress.Delivery.Api.Client.DesktopApp.Components.Fields
{
    /// <summary>
    /// Логика взаимодействия для SearchField.xaml
    /// </summary>
    public partial class SearchField : UserControl
    {
        public static readonly DependencyProperty TextProperty =
            TextField.TextProperty.AddOwner(typeof(SearchField),
                new FrameworkPropertyMetadata(string.Empty));

        public SearchField()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}
