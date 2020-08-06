using Meteoro.ViewModels.ViewModel.Corte;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Meteoro.DesktopWpfCorte.Views
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        #region Members Variables
        private EmpleadoVm _context = new EmpleadoVm();
        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
            this.DataContext = _context;

        }
        #endregion

        #region Private Methods

        #endregion

        #region Events
        private void frmLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
                _context.SecurePassword = ((dynamic)DataContext).SecurePassword;
            }
        }
        private void btnToMain_Click(object sender, RoutedEventArgs e)
        {
            if (_context.IsLogued)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(200);

                    Dispatcher.Invoke(() =>
                    {
                        var main = new Main();
                        Application.Current.MainWindow = main;
                        main.Show();
                        this.Close();
                    });
                });
            }
        }

        #endregion




    }
}
