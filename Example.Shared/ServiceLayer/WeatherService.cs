using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Json;
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
		
			var rootNode = (JObject)JsonConvert.DeserializeObject (response.ToString ());
			var weather = rootNode.GetValue ("weatherObservation");
			var result = JsonConvert.DeserializeObject<Weather> (weather.ToString ());
			return result;
		}
	}
}

