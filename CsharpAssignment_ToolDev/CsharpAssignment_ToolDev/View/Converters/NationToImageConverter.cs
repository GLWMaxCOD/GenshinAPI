using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CsharpAssignment_ToolDev.View.Converters
{
    public class NationToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetNation, object parameter, CultureInfo culture)
        {
            if (value is string characterNation)
            {
                try
                {
                    // Display nation based on their given nation
                    string imagePath = $"pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/NationBg/{characterNation.ToLower()}.jpg";
                    return new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                }
                catch (Exception)
                {
                    // If no matching nation has been found
                    return new BitmapImage(new Uri("https://64.media.tumblr.com/541cea989597c63e2c2f3cbe6407ad81/99f4db314f890b32-a5/s1280x1920/991ec500a7627a05af9b02148f0419a10b64fa11.png"));
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetNation, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
