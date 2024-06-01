using System;
using System.Globalization;
using System.Net.Http;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CsharpAssignment_ToolDev.View.Converters
{
    public class CharacterToIconConverter : IValueConverter
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly string DefaultUrl = "https://static.wikia.nocookie.net/p__/images/e/ed/Dainsleif_Infobox.png/revision/latest?cb=20230823170835&path-prefix=protagonist";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string characterName)
            {
                string url = GetCharacterImageUrl(characterName);

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(url, UriKind.Absolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmapImage.EndInit();

                bitmapImage.DownloadFailed += (s, e) =>
                {
                    // Load the fallback image if the primary image fails to load
                    var fallbackImage = new BitmapImage();
                    fallbackImage.BeginInit();
                    fallbackImage.UriSource = new Uri(DefaultUrl, UriKind.Absolute);
                    fallbackImage.CacheOption = BitmapCacheOption.OnLoad;
                    fallbackImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    fallbackImage.EndInit();
                    bitmapImage = fallbackImage;
                };

                return bitmapImage;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetCharacterImageUrl(string characterName)
        {
            string characterNameFormatted = characterName.ToLower().Replace(" ", "-");
            string url = $"https://genshin.jmp.blue/characters/{characterNameFormatted}/icon-big.png";

            switch (characterName.ToLower())
            {
                case "raiden shogun":
                    url = "https://genshin.jmp.blue/characters/raiden/icon-big.png";
                    break;
                case "kujou sara":
                    url = "https://genshin.jmp.blue/characters/sara/icon-big.png";
                    break;
                case "sangonomiya kokomi":
                    url = "https://genshin.jmp.blue/characters/kokomi/icon-big.png";
                    break;
                case "kamisato ayato":
                    url = "https://genshin.jmp.blue/characters/ayato/icon-big.png";
                    break;
                case "kamisato ayaka":
                    url = "https://genshin.jmp.blue/characters/ayaka/icon-big.png";
                    break;
                case "kaedehara kazuha":
                    url = "https://genshin.jmp.blue/characters/kazuha/icon-big.png";
                    break;
                // Add more cases as needed
                default:
                    break;
            }

            return url;
        }
    }
}