using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TesteDrive.Views;

namespace TesteDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin", (usuario) =>
            {
                MainPage = new NavigationPage(new ListagemView());
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
