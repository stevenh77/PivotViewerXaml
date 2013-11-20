using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PivotViewerXaml
{
    public class CurrencyCodeToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "usd":
                    return new SolidColorBrush(new Color() { R = 99, G = 173, B = 194, A = 255 });
                case "chf":
                    return new SolidColorBrush(new Color() { R = 91, G = 166, B = 91, A = 255 });
                case "eur":
                    return new SolidColorBrush(new Color() { R = 244, G = 171, B = 69, A = 255 });
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
