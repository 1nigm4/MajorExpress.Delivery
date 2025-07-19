namespace MajorExpress.Delivery.Api.Client.DesktopApp.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    ///     Конвертер дат
    /// </summary>
    public class DateTimeConverter : IValueConverter
    {
        private static string _dateFormat = "dd.MM.yyyy HH:mm";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString(_dateFormat);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string dateString) return Binding.DoNothing;
            var converted = DateTime.TryParseExact(
                   dateString,
                   _dateFormat,
                   CultureInfo.InvariantCulture,
                   DateTimeStyles.AssumeUniversal,
                   out DateTime result);
            return converted ? result : Binding.DoNothing;
        }
    }
}
