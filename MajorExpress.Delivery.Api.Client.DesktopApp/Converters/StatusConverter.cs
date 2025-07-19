namespace MajorExpress.Delivery.Api.Client.DesktopApp.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    ///     Конвертер статусов
    /// </summary>
    class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not byte statusValue) return "Неизвестный";
            return statusValue switch
            {
                1 => "Новая",
                2 => "Передано на выполнение",
                3 => "Выполнено",
                4 => "Отменена",
                _ => "Неизвестный"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
