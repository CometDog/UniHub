using UniHub.Views.Login;

namespace UniHub.Presenter
{
    class LoginPresenter
    {
        private readonly LoginView _view;

        public LoginPresenter(LoginView view)
        {
            _view = view;
        }

        public void HandleOAuth(string oAuthUrl)
        {

        }
    }
}
