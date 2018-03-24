using Foundation;
using UIKit;
using Xamarin.Forms;

namespace UniHub.iOS
{
    [Register("UIApplicationMain")]
    class UIApplicationMain : UIApplication
    {
        public UIApplicationMain()
        {
        }

        public override bool OpenUrl(NSUrl nsUrl)
        {
            string url = nsUrl.ToString();
            if (url.Contains("unihub://login"))
            {
                MessagingCenter.Send(url, "OAuthUrl");
                return true;
            }
            return false;
        }
    }
}