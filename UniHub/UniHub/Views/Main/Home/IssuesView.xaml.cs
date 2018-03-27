using Octokit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UniHub.Presenter.Main.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Main.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    partial class IssuesView : TabbedPage
    {
        private readonly IssuesPresenter _presenter;

        public IssuesView()
        {
            _presenter = new IssuesPresenter(this);
            Issues = new ObservableCollection<Issue>();

            InitializeComponent();

            CreatedListView.ItemsSource = Issues;

            _presenter.RetrieveIssues();
        }

        private ObservableCollection<Issue> Issues { get; set; }

        internal void IssueRetrievelSuccessful(List<Issue> issues)
        {
            AddIssuesToView(issues);
        }

        private void AddIssuesToView(List<Issue> issues)
        {
            foreach (var issue in issues)
            {
                Issues.Add(issue);
            }
            ViewLoadingStopped(true);
        }

        internal void IssueRetrievalFailed()
        {
            ViewLoadingStopped(false);
        }

        private void ReloadButtonPressed(object sender, ClickedEventArgs args)
        {
            ViewReloadingStarted();
            _presenter.RetrieveIssues();
        }

        private void ViewLoadingStopped(bool successful)
        {
            CreatedActivityIndicator.IsVisible = false;
            CreatedListView.IsVisible = successful;
            NoIssuesLayout.IsVisible = !successful;
        }

        private void ViewReloadingStarted()
        {
            ReloadButton.IsVisible = false;
            ReloadActivityIndicator.IsVisible = true;
        }

        private void ViewReloadingStopped()
        {
            ReloadButton.IsVisible = true;
            ReloadActivityIndicator.IsVisible = false;
        }
    }
}