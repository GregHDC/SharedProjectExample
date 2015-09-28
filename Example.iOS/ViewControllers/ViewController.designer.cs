// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Template.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PostalButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel WeatherInfoLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (PostalButton != null) {
				PostalButton.Dispose ();
				PostalButton = null;
			}
			if (WeatherInfoLabel != null) {
				WeatherInfoLabel.Dispose ();
				WeatherInfoLabel = null;
			}
		}
	}
}
