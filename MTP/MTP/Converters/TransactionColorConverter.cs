using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MTP.Converters
{
    public class TransactionColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
                return ((bool)value? "Green":"Red");
            else if(value is float)
                return ((float)value >= 0 ? "Green" : "Red");
            else if (value is Int32)
                return ((Int32)value > 0 ? "Green" :((Int32)value < 0 ? "Red" : "Black"));
            return "Black";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
