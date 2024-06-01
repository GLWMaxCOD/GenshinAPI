using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CsharpAssignment_ToolDev.Services
{
    public class NavigationService
    {
        private readonly Dictionary<string, Func<Page>> _pagesByKey;
        private Frame _mainFrame;

        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Func<Page>>();
        }

        public void Configure(string key, Func<Page> pageType)
        {
            if (!_pagesByKey.ContainsKey(key))
            {
                _pagesByKey.Add(key, pageType);
            }
        }

        public void SetMainFrame(Frame frame)
        {
            _mainFrame = frame;
        }

        public void NavigateTo(string key, object parameter = null)
        {
            if (_pagesByKey.TryGetValue(key, out var pageFactory))
            {
                var page = pageFactory();

                if (parameter != null && page.DataContext != null)
                {
                    page.DataContext = parameter;
                }

                _mainFrame.Navigate(page);
            }
        }

        public void GoBack()
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }
    }
}
