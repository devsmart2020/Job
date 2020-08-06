using Meteoro.ViewModels.ViewModel.Corte;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Corte.App.Views.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Corte : ContentPage
    {       
        public Corte()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk3MjE0QDMxMzgyZTMyMmUzMFVxZ0xhK09VbVcxS3Q5a2QzTnNwSGVBajF5ekNnTkwyV1M4OUJicUppV2s9");
            InitializeComponent();
        }
    }
}