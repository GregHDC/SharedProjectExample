using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Json;

/* Further implementation where required: 
 * Catch and handle non-200 range responses, you may want to differentiate the handling depends on the status code. 
 * You may want to log the error accordingly, although the API should have done it as well.
 * For example:
 *  - 304 (no change), therefore, do not update the cached data.
 *  - 401 (unauthorised), request user to login, navigate to login screen from the front-end
 *  - 403 (forbidden), some reason to show why the user is forbidden
 *  - other 4XX 
 *  - 5XX
 * GZIP requests
 * Headers
 * 	- Authorisation - for example, inject bearer token for each requests
 *  - other headers
 * Timeout setting
 * Other types of requests such as POST or PUT etc.
 */
using Example.Shared.Entities;


namespace Example.Shared
{
	public class BaseService
	{
		public BaseService ()
		{
		}


		public async Task<JsonValue> GetRequest<T> (string uri, string data)
		{
			var request = (HttpWebRequest)WebRequest.Create (uri);
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ()) {
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ()) {
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
					Console.Out.WriteLine ("Response: {0}", jsonDoc.ToString ());


					return jsonDoc;
				}
			}
		}
	}
}

