using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TesteDrive.Media;
using TesteDrive.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))] //Anotação para incluir a classe MainActivity como uma depência do XamarinForms e usar em outros projetos através do Get como na classe MasterViewModel
namespace TesteDrive.Droid
{
    [Activity(Label = "TesteDrive", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Obsolete]
        public void TirarFoto()
        {
            //Intent
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            //Activity
            var activity = Forms.Context as Activity;
            //var activity = Android.App.Application.Context as Activity;
            activity.StartActivityForResult(intent, 0);
        }
    }
}