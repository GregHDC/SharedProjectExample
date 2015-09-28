using Example.Shared.BL.Contracts;
using Example.Shared.DL.SQLite;
using Newtonsoft.Json;

namespace Example.Shared.Entities
{
	/// <summary>
	/// Represents weather info.
	/// </summary>

	public class Weather : IBusinessEntity
	{
		public Weather ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[JsonProperty ("weatherCondition")]
		public string WeatherCondition { get; set; }

		[JsonProperty ("temperature")]
		public double Temperature { get; set; }

		[JsonProperty ("clouds")]
		public string Clouds { get; set; }
	}
}