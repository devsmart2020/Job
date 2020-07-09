using Meteoro.ViewModels.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Meteoro.DesktopWpfCorte.Views
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        #region Members Variables     

        private MainDataContext _context = new MainDataContext();
        private EmpleadoVm _empleadoVm = new EmpleadoVm();
        #endregion

        public Main()
        {
            InitializeComponent();
            this.DataContext = _empleadoVm;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword;
                _empleadoVm.SecurePassword = ((dynamic)DataContext).SecurePassword;
            }
        }
    }
}
