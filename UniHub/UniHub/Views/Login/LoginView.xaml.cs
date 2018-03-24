using UniHub.Navigators.Login;
using UniHub.Presenter;
using UniHub.Resources.Strings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        private readonly LoginPresenter _presenter;
        private readonly LoginNavigator _navigator;

        public LoginView()
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

        private void SetText()
        {
            LoginPromptLabel.Text = StringResources.LoginPrompt;
            LoginTypePromptLabel.Text = StringResources.LoginTypePrompt;
            LoginTypeOAuthLabel.Text = StringResources.LoginTypeOAuth;
        }

        private void OAuthButtonPressed(object sender, ClickedEventArgs args)
        {
            _navigator.ShowOAuthLogin();
        }
    }
}