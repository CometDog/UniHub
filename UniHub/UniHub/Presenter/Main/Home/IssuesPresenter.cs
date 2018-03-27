using Octokit;
using System;
using System.Collections.Generic;
using UniHub.Views.Main.Home;

namespace UniHub.Presenter.Main.Home
{
    internal class IssuesPresenter
    {
        private readonly IssuesView _view;

        internal IssuesPresenter(IssuesView view)
        {
            _view = view;
        }

        internal async void RetrieveIssues()
        {
            try
            {
                var issuesClient = SessionManager.Client.Issue;
                var issues = await issuesClient.GetAllForCurrent() as List<Issue>;
                _view.IssueRetrievelSuccessful(issues);
            }
            catch (Exception)
            {
                _view.IssueRetrievalFailed();
            }
        }
    }
}