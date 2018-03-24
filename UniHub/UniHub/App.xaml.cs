using Octokit;
using UniHub.Views.Login;
using UniHub.Views.Main;

namespace UniHub
{
    partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Xamarin.Forms.Page();
        }

        protected override void OnStart()
        {
            base.OnStart();
            CreateClient();
            if (SessionManager.AccessToken != null)
            {
                if (SessionManager.Client == null)
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

        internal void CreateClient()
        {
            SessionManager.Client = new GitHubClient(new ProductHeaderValue("UniHub"));
        }
    }
}
