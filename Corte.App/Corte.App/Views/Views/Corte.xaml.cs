
using Meteoro.ViewModels.ViewModel.Corte;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Corte.App.Views.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Corte : ContentPage
    {
        private readonly AseguradorEmpleadoVm _aseguradorEmpleadoVm;
        public Corte()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk3MjE0QDMxMzgyZTMyMmUzMFVxZ0xhK09VbVcxS3Q5a2QzTnNwSGVBajF5ekNnTkwyV1M4OUJicUppV2s9");
            InitializeComponent();
            _aseguradorEmpleadoVm = new AseguradorEmpleadoVm();
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }

        private void listViewCosechadores_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            BindingContext = _aseguradorEmpleadoVm;
            _aseguradorEmpleadoVm.SelectedEmpleadoAseg = e.ItemData;
        }
    }
}