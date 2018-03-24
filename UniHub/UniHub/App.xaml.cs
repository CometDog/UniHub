using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace UniHub
{
<<<<<<< HEAD
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new UniHub.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
=======
    partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Page();
        }

        protected override void OnStart()
        {
            base.OnStart();
            if (SessionManager.AccessToken != null)
            {
                if (SessionManager.Client.Credentials == null)
                {
                    SessionManager.Client.Credentials = new Octokit.Credentials(SessionManager.AccessToken as string);
                }
                MainPage = new Main();
            }
            else
            {
                MainPage = new LoginView();
            }
        }
    }
>>>>>>> Better handled method and class access
}
