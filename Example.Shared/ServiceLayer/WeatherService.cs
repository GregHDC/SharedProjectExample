using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Example.Shared.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Example.Shared
{
	public class WeatherService: BaseService
	{
		public WeatherService ()
		{
		}

		// Gets weather data from the passed URL.
		public async Task<Weather> FetchWeatherAsync (string uri)
		{
			var response = await GetRequest<Weather> (uri, null);

			var weatherNode = JObject.Parse (response).SelectToken ("weatherObservation").ToString ();
			var result = JsonConvert.DeserializeObject<Weather> (weatherNode);
			return result;
		}
	}
}

