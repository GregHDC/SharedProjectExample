using System;
using System.Collections.Generic;
using System.IO;
using Example.Shared.BL;
using Example.Shared.DL;

/* 
 * Consider to separate to different data access classes if there are more database operations.
 * For example, WeatherDataService
 * 
 */
using Example.Shared.Entities;

namespace Example.Shared.DAL
{
	public class TemplateRepository
	{
		TemplateDatabase db = null;
		protected static string dbLocation;
		protected static TemplateRepository repo;

		static TemplateRepository ()
		{
			repo = new TemplateRepository ();
		}

		protected TemplateRepository ()
		{
			// set the db location
			dbLocation = DatabaseFilePath;
			
			// instantiate the database	
			db = new TemplateDatabase (dbLocation);
		}

		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "TemplateDB.db3";



#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);		

				return path;	
			}
		}

		public static Weather GetLatestWeather ()
		{
			return repo.db.GetLastItem<Weather> ();
		}

		public static int Save (Weather item)
		{
			return repo.db.SaveItem<Weather> (item);
		}

		public static int Delete (int id)
		{
			return repo.db.DeleteItem<Weather> (id);
		}
	}
}

