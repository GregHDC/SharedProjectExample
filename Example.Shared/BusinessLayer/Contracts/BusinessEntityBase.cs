using System;
using Example.Shared.DL.SQLite;
using Example.Shared.BL.Contracts;

namespace Example.iOS.BL.Contracts
{
	/// <summary>
	/// Business entity base class. Provides the ID and last updated date time property
	/// Further implementations to consider: 
	/// 	- Create date time
	/// 	- Server date time vs device date time.
	/// </summary>
	public abstract class BusinessEntityBase: IBusinessEntity
	{
		public BusinessEntityBase ()
		{
		}

		/// <summary>
		/// Gets or sets the Database ID.
		/// </summary>
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the last updated date time, this will be generated from the device.
		/// </summary>
		/// <value>The last updated at.</value>
		public DateTime LastUpdatedAt { get; set; }
	}
}

