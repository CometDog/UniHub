using Octokit;
using UniHub.Views.Main;
using Xamarin.Forms;

namespace UniHub.Navigators.Login
{
    class LoginNavigator
    {
        internal void ShowMainView()
        {
            Xamarin.Forms.Application.Current.MainPage = new Main();
        }

        internal void ShowOAuthLogin()
        {
            SessionManager.Client = new GitHubClient(new ProductHeaderValue("UniHub"));
            var request = new OauthLoginRequest(Secret.clientId)
            {
                Scopes = { "user", "notifications" }
            };

            Device.OpenUri(SessionManager.Client.Oauth.GetGitHubLoginUrl(request));
        }
    }
}
