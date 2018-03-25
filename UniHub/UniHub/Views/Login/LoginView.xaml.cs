using UniHub.Navigators.Login;
using UniHub.Presenter.Login;
using UniHub.Resources.Strings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    partial class LoginView : ContentPage
    {
        private readonly LoginPresenter _presenter;
        private readonly LoginNavigator _navigator;

        internal LoginView()
        {
            _presenter = new LoginPresenter(this);
            _navigator = new LoginNavigator();

            InitializeComponent();

            SetText();

            MessagingCenter.Subscribe<string>(this, "OAuthUrl", (args) =>
            {
                _presenter.HandleOAuth(args);
            });
        }

        internal void OAuthAccepted()
        {
            _navigator.ShowMainView();
        }

        private void SetText()
        {
            LoginPromptLabel.Text = StringResources.LoginPrompt;
            LoginTypePromptLabel.Text = StringResources.LoginTypePrompt;
            LoginTypeOAuthButton.Text = StringResources.LoginTypeOAuth;
        }

        private void OAuthButtonPressed(object sender, ClickedEventArgs args)
        {
            _navigator.ShowOAuthLogin();
        }
    }
}