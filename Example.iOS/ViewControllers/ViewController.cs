using System;

using UIKit;
using Example.Shared.BL.Managers;

namespace Template.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// button tap, you can add the event here or in the storyboard
			PostalButton.TouchUpInside += (sender, e) => {
				ShowWeather ();
			};
		}

		private async void ShowWeather ()
		{
			var manager = new WeatherManager ();
//			var result = await manager.GetUpdatedWeather ("http://api.geonames.org/findNearByWeatherJSON?lat=43&lng=-2&username=demo");
			var result = await manager.GetUpdatedWeather ("http://www.mocky.io/v2/5608b9f09665b9ad1169bafa");
			WeatherInfoLabel.Text = result.WeatherCondition;

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

