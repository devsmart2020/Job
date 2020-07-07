using System.Windows;
using System.Windows.Input;

namespace Meteoro.DesktopWpfCorte.Views
{
    /// <summary>
    /// Lógica de interacción para Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        #region Members Variables

        #endregion

        #region Constructor
        public Splash()
        {
            InitializeComponent();
           
        }
        #endregion     

        #region Events
        private void frmSplash_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        #endregion





    }
}
