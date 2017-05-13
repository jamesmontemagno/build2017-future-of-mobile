using UIKit;

namespace MasterDetailDemo
{
	class DetailViewController : UIViewController
	{		
		public UIColor Color
		{
			get
			{
				return View.BackgroundColor;
			}
			set
			{
				View.BackgroundColor = value;
			}
		}

		public DetailViewController ()
		{
			Title = "Color Preview";
		}
	}
}
