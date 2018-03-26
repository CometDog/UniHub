using UniHub.Resources.Strings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Main.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    partial class HomeView : TabbedPage
    {
        internal HomeView()
        {
            InitializeComponent();

            SetText();
        }

        private void SetText()
        {
            IssuesTab.Title = StringResources.HomeTabIssues;
            PullRequestsTab.Title = StringResources.HomeTabPullRequests;
        }
    }
}