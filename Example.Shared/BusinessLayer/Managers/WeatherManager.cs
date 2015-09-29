using System;
using System.Threading.Tasks;
using Example.Shared.DAL;

/* A facade for providing weather information. 
 * The current example demonstrates web service and database functions.
 */
using Example.Shared.BL.Models;

namespace Example.Shared.BL.Managers
{
	public class WeatherManager
	{
		static WeatherManager ()
		{
		}

		/// <summary>
		/// Gets the updated weather and store it as a new record in the database
		/// Further implementation to consdier:
		/// 	- Depends on the scenario, you could choose async or sync database save
		/// 	- Check last updated date time, prior to web service calls.
		/// </summary>
		/// <returns>The updated weather.</returns>
		/// <param name="uri">URI.</param>
		public async Task<Weather> GetUpdatedWeather (string uri)
		{
			var service = new WeatherService ();
			var response = await service.FetchWeatherAsync (uri);

//			// You could choose to save async as well, and return the response object directly to the front-end
			var savedId = Save (response);
			return response;
		}

		#region Sync database operation examples

		public static Weather GetWeather (int id)
		{
			return TemplateRepository.GetWeather (id);
		}

		public static int Save (Weather item)
		{
			return TemplateRepository.Save (item);
		}

		public static int Delete (int id)
		{
			return TemplateRepository.Delete (id);
		}

		#endregion

		#region Async database operation examples

		/// <summary>
		/// Saves an weather item async.
		/// </summary>
		/// <returns>The async result ID</returns>
		/// <param name="item">Item.</param>
		public static async Task<int> SaveAsync (Weather item)
		{
			return await TemplateAsyncRepository.Save (item);
		}

		#endregion

	}
}