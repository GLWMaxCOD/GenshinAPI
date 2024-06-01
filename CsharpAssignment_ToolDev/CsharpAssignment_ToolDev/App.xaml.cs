using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using CsharpAssignment_ToolDev.View;
using CsharpAssignment_ToolDev.Services;

namespace CsharpAssignment_ToolDev
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Services.NavigationService NavigationService { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            NavigationService = new Services.NavigationService();

            NavigationService.Configure("OverviewPage", () => new OverviewPageCharacters());
            NavigationService.Configure("DetailPage", () => new DetailPageCharacter());

            var mainWindow = new MainWindow();
            NavigationService.SetMainFrame(mainWindow.MainFrame);
            mainWindow.Show();

            NavigationService.NavigateTo("OverviewPage");
        }
    }
}
