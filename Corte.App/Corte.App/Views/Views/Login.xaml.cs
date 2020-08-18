
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Corte.App.Views.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk3MjE0QDMxMzgyZTMyMmUzMFVxZ0xhK09VbVcxS3Q5a2QzTnNwSGVBajF5ekNnTkwyV1M4OUJicUppV2s9");
            InitializeComponent();
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chklogin.IsChecked)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Corte());
            }
        }
    }
}