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
			var result = await manager.GetUpdatedWeather ("http://api.geonames.org/findNearByWeatherJSON?lat=-36.851193&lng=174.761510&username=demo");
			//			var result = await manager.GetUpdatedWeather (" http://www.mocky.io/v2/5609f41a95e00ca50798127d");
			if (result != null) {
				WeatherInfoLabel.Text = result.ToString ();
			} else {
				WeatherInfoLabel.Text = "Error";
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

