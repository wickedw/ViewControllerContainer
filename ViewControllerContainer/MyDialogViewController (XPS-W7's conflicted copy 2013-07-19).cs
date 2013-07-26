using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace ViewControllerContainer
{
	public partial class MyDialogViewController : DialogViewController
	{
		public MyDialogViewController () : base (UITableViewStyle.Grouped, null)
		{
		    Root = new RootElement("DialogViewController")
		        {
		            new Section("")
		                {
		                    new StringElement("DialogViewController")
		                }
		        };
		}
	}
}
