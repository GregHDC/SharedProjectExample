using System;
using System.Threading.Tasks;
using Example.Shared.DAL;
using Example.Shared.Entities;

/* A facade for providing weather information. 
 * The current example demonstrates web service and database functions.
 */

namespace Example.Shared.BL.Managers
{
	public class WeatherManager
	{
		static WeatherManager ()
		{
		}

		public async Task<Weather> GetUpdatedWeather (string uri)
		{
			var service = new WeatherService ();
			var response = await service.FetchWeatherAsync (uri);
			// save to the db as well
			TemplateRepository.Save (response);
			return response;
		}

		public static Weather GetCachedLatestWeather ()
		{
			return TemplateRepository.GetLatestWeather ();
		}

		public static int Save (Weather item)
		{
			return TemplateRepository.Save (item);
		}

		public static int Delete (int id)
		{
			return TemplateRepository.Delete (id);
		}
		
	}
}