using System;
using System.Linq;
using Example.Shared.BL;
using System.Collections.Generic;
using Example.Shared.DL.SQLite;
using Example.Shared.BL.Contracts;

/// <summary>
/// Further implementation where required:
/// <para/>Seed database - Add a .sqlite seed database if there's pre-configured data the app needs to use. For example, reference data.
/// <para/>Database upgrade for new app versions, especially schema changes
/// </summary>
using Example.Shared.Entities;


namespace Example.Shared.DL
{
	/// <summary>
	/// SharedProjectExampleDatabase builds on SQLite.Net and represents a specific database, in our case, the SharedProjectExample DB.
	/// It contains methods for retrieval and persistance as well as db creation, all based on the 
	/// underlying ORM.
	/// </summary>
	public class TemplateDatabase : SQLiteConnection
	{
		static object locker = new object ();

		/// <summary>
		/// Initializes a new instance of the <see cref="SharedProjectExampley.DL.SharedProjectExampleDatabase"/> SharedProjectExampleDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public TemplateDatabase (string path) : base (path)
		{
			// create the tables
			CreateTable<Weather> ();
		}

		public IEnumerable<T> GetItems<T> () where T : IBusinessEntity, new()
		{
			lock (locker) {
				return (from i in Table<T> ()
				        select i).ToList ();
			}
		}

		public T GetItem<T> (int id) where T : IBusinessEntity, new()
		{
			lock (locker) {
				return	Table<T> ().Where (x => x.ID == id).FirstOrDefault ();
			}
		}

		public int SaveItem<T> (T item) where T : IBusinessEntity
		{
			lock (locker) {
				item.LastUpdatedAt = DateTime.Now;
				if (item.ID != 0) {

					Update (item);
					return item.ID;
				} else {
					return Insert (item);
				}
			}
		}

		public int DeleteItem<T> (int id) where T : IBusinessEntity, new()
		{
			lock (locker) {
				return Delete<T> (new T () { ID = id });
			}
		}
	}
}