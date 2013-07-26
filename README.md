Basic Xamarin / Monotouch Custom ViewController Container Example
========================================================================================

Containers contents controlled via UISegmentedControl.

Based on - http://developer.apple.com/library/ios/#featuredarticles/ViewControllerPGforiPhoneOS/CreatingCustomContainerViewControllers/CreatingCustomContainerViewControllers.html

I got to a point within a project whereby I wanted to display 3 different "Screens" of information based on a user selection.  

The TabBarController was not appropriate as the GUI sat within a UINavigationController hierarchy.  Yet, the UISegmentedControl fitted the design well.

I already had my views fully coded as seperate ViewControllers (and not all using the same creation pattern, some used Monotouch Dialog, others Nib files, others Programmatic).

Therefore, I did not want to rewrite existing code to use a Single ViewController controlling multiple Views.

I also thought it was time I looked at "ViewController Containers" as they seemed an ideal fit for this scenario.

I have used 3 types of ViewController creation just to show how it fit my existing requirements.

The example shows how these containers allow seperation of code and flexible viewcontroller reuse within a project.

Hope this helps someone getting started with all this.

