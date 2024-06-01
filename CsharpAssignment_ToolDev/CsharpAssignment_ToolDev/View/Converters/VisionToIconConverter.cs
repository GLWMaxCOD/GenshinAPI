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
    public class VisionToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetElement, object parameter, CultureInfo culture)
        {
            if (value is string characterVision)
            {
                string imagePath = null;

                switch (characterVision.ToLower())
                {
                    case "pyro":
                        imagePath = "pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/Element_Icons/pyro.png";
                        break;
                    case "geo":
                        imagePath = "pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/Element_Icons/geo.png";
                        break;
                    case "hydro":
                        imagePath = "pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/Element_Icons/hydro.png";
                        break;
                    case "cryo":
                        imagePath = "pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/Element_Icons/cryo.png";
                        break;
                    case "anemo":
                        imagePath = "pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/Element_Icons/anemo.png";
                        break;
                    case "dendro":
                        imagePath = "pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/Element_Icons/dendro.png";
                        break;
                    case "electro":
                        imagePath = "pack://application:,,,/CsharpAssignment_ToolDev;component/Resources/Element_Icons/electro.png";
                        break;
                    // Add cases for other elements in the future
                    default:
                        imagePath = "https://preview.redd.it/dbycshw2uiw51.png?auto=webp&s=ada830d86f4b7a6bf3007162786c497ea1d7f9df";
                        break;
                }

                try
                {
                    return new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                }
                catch (Exception ex)
                {
                    // Optionally (file not found)
                    Console.WriteLine($"Error loading image for element '{characterVision}': {ex.Message}");
                    return new BitmapImage(new Uri("https://preview.redd.it/dbycshw2uiw51.png?auto=webp&s=ada830d86f4b7a6bf3007162786c497ea1d7f9df"));
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetElement, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
