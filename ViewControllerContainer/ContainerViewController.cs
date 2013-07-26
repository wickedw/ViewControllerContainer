using System.Drawing;
using MonoTouch.UIKit;

namespace ViewControllerContainer
{
    public partial class ContainerViewController : UIViewController
    {
        // Based on - http://developer.apple.com/library/ios/#featuredarticles/ViewControllerPGforiPhoneOS/CreatingCustomContainerViewControllers/CreatingCustomContainerViewControllers.html

        private readonly NibViewController nibViewController;
        private readonly ProgrammaticViewController programmaticViewController;
        private readonly MyDialogViewController myDialogViewController;
        private UIViewController currentViewController;
        private bool MidTransition = false;

        public ContainerViewController()
            : base("ContainerViewController", null)
        {
            nibViewController = new NibViewController();
            myDialogViewController = new MyDialogViewController();
            programmaticViewController = new ProgrammaticViewController();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            currentViewController = myDialogViewController;
            DisplayContentController(currentViewController);

            //SetUpNonAnimated();
            SetUpAnimated();
        }

        private void SetUpAnimated()
        {
            ChooseVCUISegementedControl.ValueChanged += (sender, args) =>
                {
                    UIViewController oldViewController = currentViewController;

                    switch (ChooseVCUISegementedControl.SelectedSegment)
                    {
                        case 0:
                            currentViewController = myDialogViewController;
                            break;
                        case 1:
                            currentViewController = nibViewController;
                            break;
                        case 2:
                            currentViewController = programmaticViewController;
                            break;
                    }

                    CycleFromViewControllerToViewController(oldViewController, currentViewController);
                };
        }

        private void SetUpNonAnimated()
        {
            ChooseVCUISegementedControl.ValueChanged += (sender, args) =>
                {
                    HideContentController(currentViewController);

                    switch (ChooseVCUISegementedControl.SelectedSegment)
                    {
                        case 0:
                            currentViewController = myDialogViewController;
                            break;
                        case 1:
                            currentViewController = nibViewController;
                            break;
                        case 2:
                            currentViewController = programmaticViewController;
                            break;
                    }

                    DisplayContentController(currentViewController);
                };
        }

        private void DisplayContentController(UIViewController content)
        {
            this.AddChildViewController(content);
            content.View.Frame = ContainerView.Frame;
            this.View.AddSubview(content.View);
            content.DidMoveToParentViewController(this);
        }

        private void HideContentController(UIViewController content)
        {
            content.WillMoveToParentViewController(null);
            content.View.RemoveFromSuperview();
            content.RemoveFromParentViewController();
        }

        private void CycleFromViewControllerToViewController(UIViewController oldController,
                                                             UIViewController newController)
        {
            if (!MidTransition)
            {
                MidTransition = true;

                oldController.WillMoveToParentViewController(null);
                this.AddChildViewController(newController);

                // Whether this is a good UI choice aside, Scroll next UIViewController in from Right (alter as required for other transitions)
                RectangleF newControllerStartFrame =
                    new RectangleF(ContainerView.Frame.Location.X + ContainerView.Frame.Size.Width,
                                   ContainerView.Frame.Location.Y, ContainerView.Frame.Size.Width,
                                   ContainerView.Frame.Size.Height);
                RectangleF oldControllerEndFrame =
                    new RectangleF(ContainerView.Frame.Location.X - ContainerView.Frame.Size.Width,
                                   ContainerView.Frame.Location.Y, ContainerView.Frame.Size.Width,
                                   ContainerView.Frame.Size.Height);

                newController.View.Frame = newControllerStartFrame;

                // If you try to start another Container change whilst previous one is in the middle of an animation, you will get an error, such as -
                //   Unbalanced calls to begin/end appearance transitions for <NibViewController: 0xd503cc0>.
                //   Unbalanced calls to begin/end appearance transitions for <ProgrammaticViewController: 0x14d58c30 ..
                // Tried disabling UISegementedControl click to stop this happening but was jarring, so went for MidTransition variable.
                // ChooseVCUISegementedControl.Enabled = false;

                Transition(oldController, newController, 0.25, /*UIViewAnimationOptions.TransitionFlipFromLeft*/ 0,
                           () =>
                               {
                                   newController.View.Frame = oldController.View.Frame;
                                   oldController.View.Frame = oldControllerEndFrame;
                               }, delegate(bool finished)
                                   {
                                       oldController.RemoveFromParentViewController();
                                       newController.DidMoveToParentViewController(this);

                                       //ChooseVCUISegementedControl.Enabled = true;
                                       MidTransition = false;
                                   });
            }
        }
    }
}

