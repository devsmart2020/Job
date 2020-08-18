using Corte.App.Views.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Corte.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.Views.Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
