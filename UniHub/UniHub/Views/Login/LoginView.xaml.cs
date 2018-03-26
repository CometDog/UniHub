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

            MessagingCenter.Subscribe<string>(this, "OAuthUrl", (args) =>
            {
                _presenter.HandleOAuth(args);
            });
        }

        internal void OAuthSucceeded()
        {
            _navigator.ShowMainView();
            ViewLoadingStopped();
        }

        internal async void OAuthFailed()
        {
            await DisplayAlert(StringResources.Error, StringResources.UnknownError, StringResources.OK);
            ViewLoadingStopped();
        }

        private void OAuthButtonPressed(object sender, ClickedEventArgs args)
        {
            ViewLoadingStarted();
            _navigator.ShowOAuthLogin();
        }

        private void ViewLoadingStarted()
        {
            LoginTypeOAuthButton.IsVisible = false;
            LoginActivityIndicator.IsVisible = true;
        }

        private void ViewLoadingStopped()
        {
            LoginTypeOAuthButton.IsVisible = true;
            LoginActivityIndicator.IsVisible = false;
        }
    }
}