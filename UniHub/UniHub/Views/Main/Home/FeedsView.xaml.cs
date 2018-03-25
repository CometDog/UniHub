using Octokit;
using System.Collections.ObjectModel;
using UniHub.Presenter.Main.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniHub.Views.Main.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedsView : ContentView
    {
        private readonly FeedsPresenter _presenter;

        public FeedsView()
        {
            _presenter = new FeedsPresenter(this);

            InitializeComponent();

            FeedLinksCollection = new ObservableCollection<Feed>();
            FeedsListView.ItemsSource = FeedLinksCollection;

            _presenter.RetrieveFeeds();
        }

        private ObservableCollection<Feed> FeedLinksCollection { get; }

        internal void AddFeeds(Feed feed)
        {
            FeedLinksCollection.Add(feed);
        }
    }
}