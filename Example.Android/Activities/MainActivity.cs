using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Example.Shared.BL.Managers;

namespace Example.Android
{
	[Activity (Label = "Example.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.weatherButton);
			button.Click += (sender, args) => {
				ShowWeather ();
			};
		}

		private async void ShowWeather ()
		{
			var manager = new WeatherManager ();
			var result = await manager.GetUpdatedWeather ("http://api.geonames.org/findNearByWeatherJSON?lat=-36.851193&lng=174.761510&username=demo");
			//			var result = await manager.GetUpdatedWeather (" http://www.mocky.io/v2/5609f41a95e00ca50798127d");
			TextView weatherTextView = FindViewById<TextView> (Resource.Id.weatherTextView);

			weatherTextView.Text = result.ToString ();
		}

	}
}


