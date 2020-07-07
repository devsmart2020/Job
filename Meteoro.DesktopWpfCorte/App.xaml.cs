using Meteoro.DesktopWpfCorte.Views;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Meteoro.DesktopWpfCorte
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var splashScreen = new Splash();
            MainWindow = splashScreen;
            splashScreen.Show();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);

                Dispatcher.Invoke(() =>
                {
                    var login = new Login();
                    MainWindow = login;
                    login.Show();
                    splashScreen.Close();
                });
            });
        }

    }
}
