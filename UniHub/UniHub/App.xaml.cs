using UniHub.Views.Login;
using UniHub.Views.Main;
using Xamarin.Forms;

namespace UniHub
{
    partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Page();
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (SessionManager.AccessToken != null)
            {
                if (SessionManager.Client.Credentials == null)
                {
                    SessionManager.Client.Credentials = new Octokit.Credentials(SessionManager.AccessToken as string);
                }
                MainPage = new Main();
            }
            else
            {
                MainPage = new LoginView();
            }
        }
    }
}
