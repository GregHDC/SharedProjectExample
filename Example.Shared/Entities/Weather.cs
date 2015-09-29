using Example.Shared.BL.Contracts;
using Example.Shared.DL.SQLite;
using Newtonsoft.Json;
using Example.iOS.BL.Contracts;

namespace Example.Shared.Entities
{
	/// <summary>
	/// Represents weather info.
	/// </summary>

	public class Weather : BusinessEntityBase
	{
		public Weather ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[JsonProperty ("temperature")]
		public double Temperature { get; set; }

		[JsonProperty ("clouds")]
		public string Clouds { get; set; }

		[JsonProperty ("lat")]
		public double Latitude { get; set; }

		[JsonProperty ("lng")] 
		public double Longitude { get; set; }

		public override string ToString ()
		{
			return string.Format ("[Weather: ID={0}, Temperature={1}, Clouds={2}, Latitude={3}, Longitude={4}]", ID, Temperature, Clouds, Latitude, Longitude);
		}
	}
}