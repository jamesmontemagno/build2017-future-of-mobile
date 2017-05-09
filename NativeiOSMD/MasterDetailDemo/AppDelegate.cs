using Foundation;
using UIKit;

namespace MasterDetailDemo
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			//
			// Construct the UI
			//
			Window = new UIWindow (UIScreen.MainScreen.Bounds);

			var split = new UISplitViewController ();

			var master = new MasterViewController ();
			var detail = new DetailViewController ();
			var detailNav = new UINavigationController (detail);

			split.ViewControllers = new[] {
				new UINavigationController (master),
				detailNav,
			};

			//
			// Hookup events
			//
			master.ColorChanged += (sender, newColor) =>
			{
				detail.Color = newColor;
				split.ShowDetailViewController (detailNav, this);
			};

			//
			// Display the app
			//
			Window.RootViewController = split;
			Window.MakeKeyAndVisible ();
			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
		}

		public override void DidEnterBackground (UIApplication application)
		{
		}

		public override void WillEnterForeground (UIApplication application)
		{
		}

		public override void OnActivated (UIApplication application)
		{
		}

		public override void WillTerminate (UIApplication application)
		{
		}
	}
}

