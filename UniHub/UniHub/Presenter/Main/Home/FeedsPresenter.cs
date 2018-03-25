using Octokit;
using UniHub.Views.Main.Home;

namespace UniHub.Presenter.Main.Home
{
    class FeedsPresenter
    {
        private readonly FeedsView _view;

        internal FeedsPresenter(FeedsView view)
        {
            _view = view;
        }

        internal async void RetrieveFeeds()
        {
            FeedsClient client = new FeedsClient(new ApiConnection(SessionManager.Client.Connection));
            Feed feed = await client.GetFeeds();

            _view.AddFeeds(feed);
        }
    }
}
