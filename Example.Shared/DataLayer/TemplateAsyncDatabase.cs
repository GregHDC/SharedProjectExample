using System;
using System.Linq;
using Example.Shared.BL;
using System.Collections.Generic;
using Example.Shared.DL.SQLite;
using Example.Shared.BL.Contracts;
using Example.Shared.Entities;
using System.Threading.Tasks;

/// <summary>
/// Further implementation where required:
/// <para/>Seed database - Add a .sqlite seed database if there's pre-configured data the app needs to use. For example, reference data.
/// <para/>Database upgrade for new app versions, especially schema changes
/// </summary>

namespace Example.Shared.DL
{
	/// <summary>
	/// SharedProjectExampleDatabase builds on SQLite.Net and represents a specific database, in our case, the SharedProjectExample DB.
	/// It contains methods for retrieval and persistance as well as db creation, all based on the 
	/// underlying ORM.
	/// </summary>
	public class TemplateAsyncDatabase : SQLiteAsyncConnection
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="SharedProjectExampley.DL.SharedProjectExampleDatabase"/> SharedProjectExampleDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public TemplateAsyncDatabase (string path) : base (path)
		{
			// create the tables
			CreateTableAsync<Weather> ();
		}

		public async Task<IEnumerable<T>> GetItems<T> () where T : IBusinessEntity, new()
		{
			return await this.Table<T> ().ToListAsync ();
		}

		public async Task<T> GetItem<T> (int id) where T : IBusinessEntity, new()
		{
			return await Table<T> ().Where (x => x.ID == id).FirstOrDefaultAsync ();
		}

		public async Task<int> SaveItem<T> (T item) where T : IBusinessEntity
		{
			item.LastUpdatedAt = DateTime.Now;
			if (item.ID != 0) {

				await UpdateAsync (item);
				return item.ID;
			} else {
				return await InsertAsync (item);
			}
		}

		public async Task<int> DeleteItem<T> (T item) where T : IBusinessEntity, new()
		{
			return await this.DeleteAsync (item);
		}
	}
}