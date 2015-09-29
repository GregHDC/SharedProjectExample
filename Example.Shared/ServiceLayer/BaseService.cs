using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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


namespace Example.Shared
{
	public class BaseService
	{
		public BaseService ()
		{
		}

		/// <summary>
		/// A GET request and return the json. 
		/// Further implementation to consider:
		/// 	- If the response is always the same format, you could pass in a generics, e.g. Task<T> instead of Task<JsonValue>
		/// </summary>
		/// <returns>The request.</returns>
		/// <param name="uri">URI.</param>
		/// <param name="data">Data.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public async Task<string> GetRequest<T> (string uri, string data)
		{
			var request = (HttpWebRequest)WebRequest.Create (uri);
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ()) {
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream ()) {

					var reader = new StreamReader (stream, System.Text.Encoding.Default);
					string responseString = await reader.ReadToEndAsync ();

					if (responseString != null && responseString.Length > 0) {
						return responseString;

					}// Use this stream to build a JSON document object:
//					JsonValue jsonDoc = await Task.Run (() => JsonObject.Load (stream));
//					Console.Out.WriteLine ("Response: {0}", jsonDoc.ToString ());


//					return jsonDoc;
				}
			}
			return null;
		}
	}
}

