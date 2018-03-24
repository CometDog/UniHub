﻿using Octokit;
using UniHub.Views.Login;

namespace UniHub.Presenter
{
    class LoginPresenter
    {
        private readonly LoginView _view;

        internal LoginPresenter(LoginView view)
        {
            _view = view;
        }

        internal async void HandleOAuth(string oAuthUrl)
        {
            var code = oAuthUrl.Replace("unihub://login?code=", "");
            var request = new OauthTokenRequest(Secret.clientId, Secret.clientSecret, code);

            var token = await SessionManager.Client.Oauth.CreateAccessToken(request);
            SessionManager.AccessToken = token.AccessToken;

            SessionManager.Client.Credentials = new Credentials(SessionManager.AccessToken as string);

            _view.OAuthAccepted();
        }
    }
}
