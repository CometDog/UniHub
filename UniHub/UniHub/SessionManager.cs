using Octokit;

namespace UniHub
{
    internal class SessionManager
    {
        private static readonly string ACCESS_TOKEN = "ACCESS_TOKEN";

        internal static string AccessToken
        {
            get
            {
                if (!Xamarin.Forms.Application.Current.Properties.ContainsKey(ACCESS_TOKEN))
                {
                    return null;
                }
                return Xamarin.Forms.Application.Current.Properties[ACCESS_TOKEN] as string;
            }

            set
            {
                if (Xamarin.Forms.Application.Current.Properties.ContainsKey(ACCESS_TOKEN))
                {
                    Xamarin.Forms.Application.Current.Properties.Remove(ACCESS_TOKEN);
                }
                Xamarin.Forms.Application.Current.Properties.Add(ACCESS_TOKEN, value as string);
            }
        }

        internal static GitHubClient Client { get; set; }
    }
}