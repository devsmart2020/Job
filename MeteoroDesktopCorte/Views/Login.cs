using Meteoro.ViewModels.ViewModel.Corte;
using System.Collections.Specialized;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeteoroDesktopCorte.Views
{
    public partial class FrmLogin : Form
    {
        #region Members Variables
        private readonly EmpleadoVm _empleadoVm;
        #endregion

        #region Constructor
        public FrmLogin()
        {
            Thread t = new Thread(new ThreadStart(Splash));
            t.Start();
            Thread.Sleep(3000);
            InitializeComponent();
            _empleadoVm = new EmpleadoVm();         
            t.Abort();
        }
        #endregion

        #region Private Methods
        private void Splash()
        {
            Application.Run(new FrmSplash());
        }
        private void Binding()
        {
            txtUser.DataBindings.Clear();
            txtUser.DataBindings.Add("Text", _empleadoVm, Name = "Codigo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtPass.DataBindings.Clear();
            txtPass.DataBindings.Add("Text", _empleadoVm, Name = "PassApp", false, DataSourceUpdateMode.OnPropertyChanged);

        }
        #endregion

        #region Events
        private void FrmLogin_Shown(object sender, System.EventArgs e)
        {
            Binding();
        }
        private async Task Login()
        {
            await Task.Run(() =>
            {
                _empleadoVm.LoginAppCommand.Execute(null);

            });
            if (_empleadoVm.IsLogued)
            {
                Application.Run(new FrmMain());
            }
        }
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private async void btnLogin_Click(object sender, System.EventArgs e)
        {
            await Login();
        }
    }
}
