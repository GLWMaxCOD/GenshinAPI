using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CsharpAssignment_ToolDev.View.Converters
{
    public class CharacterToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string characterName)
            {
                string[] urls = GetCharacterImageUrls(characterName);
                return GetFirstAvailableImage(urls);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetFirstAvailableUrlAsync(string[] urls)
        {
            using HttpClient client = new HttpClient();
            foreach (string url in urls)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        return url;
                    }
                }
                catch
                {
                    // Ignore exceptions and try next URL
                }
            }
            // Return a default image URL if none of the URLs are valid
            return "https://static.wikia.nocookie.net/p__/images/e/ed/Dainsleif_Infobox.png/revision/latest?cb=20230823170835&path-prefix=protagonist";
        }

        private BitmapImage GetFirstAvailableImage(string[] urls)
        {
            string imageUrl = null;
            var dispatcher = Dispatcher.CurrentDispatcher;
            var task = Task.Run(async () =>
            {
                imageUrl = await GetFirstAvailableUrlAsync(urls);
            });
            task.Wait();

            return dispatcher.Invoke(() =>
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(imageUrl, UriKind.Absolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bitmapImage.EndInit();
                return bitmapImage;
            });
        }

        private string[] GetCharacterImageUrls(string characterName)
        {
            string characterNameFormatted = characterName.ToLower().Replace(" ", "-");
            string[] urls = new[]
            {
                $"https://genshin.jmp.blue/characters/{characterNameFormatted}/gacha-splash.png",
                $"https://genshin.jmp.blue/characters/{characterNameFormatted}/portrait.png",
                $"https://genshin.jmp.blue/characters/{characterNameFormatted}/gacha-card.png"
            };

            switch (characterName.ToLower())
            {
                case "raiden shogun":
                    urls = new[]
                    {
                        "https://genshin.jmp.blue/characters/raiden/gacha-splash.png",
                        "https://genshin.jmp.blue/characters/raiden/portrait.png",
                        "https://genshin.jmp.blue/characters/raiden/gacha-card.png"
                    };
                    break;
                case "kujou sara":
                    urls = new[]
                    {
                        "https://genshin.jmp.blue/characters/sara/gacha-splash.png",
                        "https://genshin.jmp.blue/characters/sara/portrait.png",
                        "https://genshin.jmp.blue/characters/sara/gacha-card.png"
                    };
                    break;
                case "sangonomiya kokomi":
                    urls = new[]
                    {
                        "https://genshin.jmp.blue/characters/kokomi/gacha-splash.png",
                        "https://genshin.jmp.blue/characters/kokomi/portrait.png",
                        "https://genshin.jmp.blue/characters/kokomi/gacha-card.png"
                    };
                    break;
                case "kamisato ayato":
                    urls = new[]
                    {
                        "https://genshin.jmp.blue/characters/ayato/gacha-splash.png",
                        "https://genshin.jmp.blue/characters/ayato/portrait.png",
                        "https://genshin.jmp.blue/characters/ayato/gacha-card.png"
                    };
                    break;
                case "kamisato ayaka":
                    urls = new[]
                    {
                        "https://genshin.jmp.blue/characters/ayaka/gacha-splash.png",
                        "https://genshin.jmp.blue/characters/ayaka/portrait.png",
                        "https://genshin.jmp.blue/characters/ayaka/gacha-card.png"
                    };
                    break;
                case "kaedehara kazuha":
                    urls = new[]
                    {
                        "https://genshin.jmp.blue/characters/kazuha/gacha-splash.png",
                        "https://genshin.jmp.blue/characters/kazuha/portrait.png",
                        "https://genshin.jmp.blue/characters/kazuha/gacha-card.png"
                    };
                    break;
                // Add more cases as needed
                default:
                    break;
            }

            return urls;
        }
    }
}