using System.Drawing;
using MonoTouch.UIKit;

namespace ViewControllerContainer
{
	public partial class ProgrammaticViewController : UIViewController
	{
		public ProgrammaticViewController () 
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			UILabel label = new UILabel (new RectangleF(0,0,320,40));
			label.Text = "ProgrammaticViewController";
			View.AddSubview (label);
		}
	}
}

