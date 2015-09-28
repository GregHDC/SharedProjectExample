using System;
using System.Linq;
using Example.Shared.BL;
using System.Collections.Generic;
using Example.Shared.DL.SQLite;
using Example.Shared.BL.Contracts;

/* Further implementation where required: 
 * - Seed database
 * 	- Add a .sqlite seed database if there's pre-configured data the app needs to use. For example, reference data.
 * - Database upgrade for new app versions
 * 	- Schema change
 *  - Data migration or upgrade
 */
namespace Example.Shared.DL
{
	/// <summary>
	/// The app's database builds on SQLite.Net and represents a specific database.
	/// It contains methods for retrieval and persistance as well as db creation, all based on the 
	/// underlying ORM.
	/// </summary>
	public class TemplateDatabase : SQLiteConnection
	{
		static object locker = new object ();

		/// <summary>
		/// Initializes a new instance of the database. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public TemplateDatabase (string path) : base (path)
		{
			// create the tables
			CreateTable<SharedProjectExample> ();
		}

		public IEnumerable<T> GetItems<T> () where T : IBusinessEntity, new()
		{
			lock (locker) {
				return (from i in Table<T> ()
				        select i).ToList ();
			}
		}

		public T GetItem<T> (int id) where T : BL.Contracts.IBusinessEntity, new()
		{
			lock (locker) {
				return Table<T> ().FirstOrDefault (x => x.ID == id);
			}
		}

		public int SaveItem<T> (T item) where T : BL.Contracts.IBusinessEntity
		{
			lock (locker) {
				if (item.ID != 0) {
					Update (item);
					return item.ID;
				} else {
					return Insert (item);
				}
			}
		}

		public int DeleteItem<T> (int id) where T : BL.Contracts.IBusinessEntity, new()
		{
			lock (locker) {
				return Delete<T> (new T () { ID = id });
			}
		}
	}
}