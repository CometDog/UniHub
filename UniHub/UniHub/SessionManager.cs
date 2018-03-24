using Octokit;

namespace UniHub
{
    class SessionManager
    {
        internal static string AccessToken { get; set; }
        internal static GitHubClient Client { get; set; }
    }
}
