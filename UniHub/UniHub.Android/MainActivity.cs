using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace UniHub.Droid
{
    [Activity(Label = "UniHub", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(
        new[] { Android.Content.Intent.ActionView },
        Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
        DataScheme = "unihub",
        DataHost = "login"
    )]
    class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App());

            if (Intent.Action == Android.Content.Intent.ActionView)
            {
                MessagingCenter.Send(Intent.Data.ToString(), "OAuthUrl");
            }
        }
    }
}

