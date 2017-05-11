using System.Collections.Generic;

using Xamarin.Forms;

namespace Forms
{
	public partial class App : Application
	{
		public static bool UseMockDataStore = true;
		public static string BackendUrl = "https://localhost:5000";

		public static IDictionary<string, string> LoginParameters => null;

		public App()
		{
			InitializeComponent();

			/*if (UseMockDataStore)
				DependencyService.Register<MockDataStore>();
			else
				DependencyService.Register<CloudDataStore>();*/

			SetMainPage();
		}

		public static void SetMainPage()
		{
			if (!UseMockDataStore && !Settings.IsLoggedIn)
			{
				Current.MainPage = new NavigationPage(new LoginPage())
				{
					BarBackgroundColor = (Color)Current.Resources["Primary"],
					BarTextColor = Color.White
				};
			}
			else
			{
				GoToMainPage();
			}
		}

		public static void GoToMainPage()
		{
           
            Current.MainPage = new TabbedPage
            {

                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OS == TargetPlatform.iOS ? "tab_feed.png" : null
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OS == TargetPlatform.iOS ? "tab_about.png" : null
                    },
                }
            };
            
           
		}
	}
}
