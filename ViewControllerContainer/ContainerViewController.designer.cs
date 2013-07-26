// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ViewControllerContainer
{
	[Register ("ContainerViewController")]
	partial class ContainerViewController
	{
		[Outlet]
		MonoTouch.UIKit.UISegmentedControl ChooseVCUISegementedControl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView ContainerView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ChooseVCUISegementedControl != null) {
				ChooseVCUISegementedControl.Dispose ();
				ChooseVCUISegementedControl = null;
			}

			if (ContainerView != null) {
				ContainerView.Dispose ();
				ContainerView = null;
			}
		}
	}
}
