using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace MasterDetailDemo
{
	class MasterViewController : UITableViewController
	{
		public event EventHandler<UIColor> ColorChanged;

		readonly List<UIColor> colors = new List<UIColor> ();

		readonly Random rand = new Random ();

		public MasterViewController ()
		{
			Title = "Colors";

			NavigationItem.RightBarButtonItem =
				new UIBarButtonItem(UIBarButtonSystemItem.Add, HandleAdd);
		}

		void HandleAdd (object sender, EventArgs e)
		{
			//
			// Create new data
			//
			var newColor = UIColor.FromRGB (
				(nfloat)rand.NextDouble (),
				(nfloat)rand.NextDouble (),
				(nfloat)rand.NextDouble ());

			//
			// Remember it
			//
			colors.Insert (0, newColor);

			//
			// Update the UI
			//
			TableView.InsertRows (
				new[] { NSIndexPath.FromRowSection(0, 0) },
				UITableViewRowAnimation.Top);
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return colors.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("Color");

			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, "Color");
			}

			cell.TextLabel.Text = colors[indexPath.Row].ToString ();

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			base.RowSelected (tableView, indexPath);

			tableView.DeselectRow (indexPath, true);

			ColorChanged?.Invoke (this, colors[indexPath.Row]);
		}
	}
}
