using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CsharpAssignment_ToolDev.View.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isUsingLocalData = (bool)value;
            string mode = parameter as string;

            if (mode == "Local")
            {
                return isUsingLocalData ? new SolidColorBrush(Color.FromArgb(128, 0, 255, 0)) : new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));
            }
            else if (mode == "Online")
            {
                return !isUsingLocalData ? new SolidColorBrush(Color.FromArgb(128, 0, 255, 0)) : new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
