using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ContainerSchubse
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(double))
                return null;
            else
                return ((double)value).ToString("n2");
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return null;
                else
                    return Double.Parse(((string)value).Replace('.', ','));
            }
            catch(FormatException)
            {
                return 0;
            }
        }
    }
}
