using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NewWebsite.Models
{
	// Client for Web API or WCF REST Service
	public class sa106ApiClient
	{
		// Retrieves list of sa106 records
		// List<sa106Data> objOrdersData = sa106ApiClient.GetList<sa106Data>(url)
		public static List<T> GetList<T>(string url)
		{
			// http://localhost:26198/api/sa106
			// http://localhost:26198/api/sa106?filterExpression="gkey=1"
			// http://localhost:26198/api/sa106?filterExpression="gkey=1"&sortExpression="gkey"&pageIndex=1&pageSize=10&rowsCount=0
		
			string jsonData = string.Empty;
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
			req.Method = "GET";
			req.ContentType = "application/json";

			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				using (Stream respStream = resp.GetResponseStream())
				{
					if (respStream != null)
					{
						jsonData = new StreamReader(respStream).ReadToEnd();
					}
				}
			}
			List<T> objData = JsonConvert.DeserializeObject<List<T>>(jsonData);
			return objData;
		}

		// Retrieves single record for sa106
		// sa106Data objOrdersData = sa106ApiClient.GetItem<sa106Data>(url)
		public static T GetItem<T>(string url)
		{
			// http://localhost:26198/api/sa106/1
			string jsonData = string.Empty;
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
			req.Method = "GET";
			req.ContentType = "application/json";

			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				using (Stream respStream = resp.GetResponseStream())
				{
					if (respStream != null)
					{
						jsonData = new StreamReader(respStream).ReadToEnd();
					}
				}
			}
			T objData = JsonConvert.DeserializeObject<T>(jsonData);
			return objData;
		}
		
		#region DELETE Methods
		// Deletes sa106 data for the specified ID
		// bool success = sa106ApiClient.Delete(id)
		public static bool Deletesa106(string id)
		{
			string url = "http://localhost:26198/api/sa106/" + id;
			string jsonData = string.Empty;
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
			req.Method = "DELETE";
			req.ContentType = "application/json";
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				return (resp.StatusCode == HttpStatusCode.OK);
			}
		}

		// Deletes sa106 data based on the specified filter criteria
		// bool success = sa106ApiClient.Deletesa106By(filterExpression)
		public static bool Deletesa106By(string filterExpression)
		{
			string url = "http://localhost:26198/api/sa106?filterExpression=" + filterExpression;
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
			req.Method = "DELETE";
			req.ContentType = "application/json";
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				return (resp.StatusCode == HttpStatusCode.OK);
			}
		}
		#endregion
		
	}
}
