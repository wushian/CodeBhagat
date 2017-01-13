#region History
/* -------------------------------------------------------------------
 * Created By		: CodeBhagat v1.0
 * Created Date		: 2017/1/13
 * Purpose			: This is a Web API Controller class that contains methods to perform Data Layer operations 
 * -------------------------------------------------------------------
*/
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;
using Angular2.Models;
using Newtonsoft.Json.Linq;	// Add JSON.NET Library
using Newtonsoft.Json;		// Add JSON.NET Library
#endregion

namespace Angular2.Models.Controllers
{

    public class ab120Controller : ApiController
    {
		#region HTTP GET Methods - returns List<ab120Data>
		// http://localhost:26198/api/ab120
		/// <summary>
		/// Returns list of all ab120 Data
		/// </summary>
		[HttpGet]
		public List<Angular2.Models.ab120Data> Getab120()
		{
			try
			{
				return Angular2.Models.ab120.GetList();
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab120 records."
				};
				throw new HttpResponseException(resp);
			}
		}

		// http://localhost:26198/api/ab120?filterExpression="gkey=1"
		/// <summary>
		/// Returns list of all ab120 Data based on specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpGet]
		public List<ab120Data> Getab120(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (string.IsNullOrWhiteSpace(filterExpression))
					return Angular2.Models.ab120.GetList();
				else
					return Angular2.Models.ab120.GetList(filterExpression);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab120 records."
				};
				throw new HttpResponseException(resp);
			}
		}

		/*
		// http://localhost:26198/api/ab120?filterExpression="gkey=1"&sortExpression="gkey"&pageIndex=1&pageSize=10&rowsCount=0
		public List<ab120Data> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, int rowsCount)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
			
				return Angular2.Models.ab120.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab120 records."
				};
				throw new HttpResponseException(resp);
			}
		}
		*/
		
		// http://localhost:26198/api/Products?filterExpression="ProductID=1"&sortExpression="ProductID"&pageIndex=1&pageSize=10
		/// <summary>
		/// Returns list of all ab120 Data by Page based on specified filter criteria, sort expression, page number and page size
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		/// <param name="sortExpression">Order by field</param>
		/// <param name="pageIndex">Page number</param>
		/// <param name="pageSize">Number of records to retrieve per page</param>
		[HttpGet]
		public ab120DataByPage GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
				int rowsCount = 0;
			
				List<ab120Data> objab120Data = Angular2.Models.ab120.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
				return new ab120DataByPage(objab120Data, rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab120 records."
				};
				throw new HttpResponseException(resp);
			}
		}
		
		// http://localhost:26198/api/ab120/1
		/// <summary>
		/// Returns a ab120 record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab120 data</param>
		[HttpGet]
		public Angular2.Models.ab120Data Getab120ById(string id)
		{
			try
			{
				var item = Angular2.Models.ab120.GetDetailsByID(id);
				if (item == null)
				{
					throw new HttpResponseException(HttpStatusCode.NotFound);
				}
				return item;
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving record for the specified id."
				};
				throw new HttpResponseException(resp);
			}
		}
		#endregion

		#region HTTP POST Method - Adds ab120 data into database
		// http://localhost:26198/api/ab120
		/// <summary>
		/// Creates a new ab120 entity
		/// </summary>
		/// <param name="objab120">ab120Data object</param>
		[HttpPost]
		public HttpResponseMessage Postab120(ab120Data objab120)
		{
			try
			{
				//JArray itemArray = item["ab120Data"];
				//JObject jobj = itemArray[0] as JObject;
				//ab120Data objab120 = jobj.ToObject<ab120Data>();
			
				var result = Angular2.Models.ab120.Add(objab120);
				objab120.gkey = result;
				var response = Request.CreateResponse<ab120Data>(HttpStatusCode.Created, objab120);

				string uri = Url.Link("DefaultApi", new { id = objab120.gkey });
				response.Headers.Location = new Uri(uri);
				return response;
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error saving data!"
				};
				return resp;
			}
		}
		#endregion

		#region HTTP PUT Method - Updates ab120 data into database
		// http://localhost:26198/api/ab120
		/// <summary>
		/// Updates an existing ab120 entity
		/// </summary>
		/// <param name="objab120">ab120Data object</param>
		[HttpPut]
		public HttpResponseMessage Putab120(ab120Data objab120)
		{
			try
			{
				//JArray itemArray = item["ab120Data"];
				//JObject obj = itemArray[0] as JObject;
				//ab120Data objab120 = obj.ToObject<ab120Data>();
				if (!Angular2.Models.ab120.Update(objab120))
					throw new HttpResponseException(HttpStatusCode.NotFound);
				else
					return new HttpResponseMessage(HttpStatusCode.OK);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error saving data!"
				};
				return resp;
			}
		}
		#endregion

		#region HTTP DELETE Methods
		// Deletes ab120 data for the specified ID
		// http://localhost:26198/api/ab120/1
		/// <summary>
		/// Deletes ab120 record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab120 data</param>
		[HttpDelete]
		public HttpResponseMessage Deleteab120(string id)
		{
			try
			{
				if (!Angular2.Models.ab120.Delete(id))
					throw new HttpResponseException(HttpStatusCode.NotFound);
				else
					return new HttpResponseMessage(HttpStatusCode.OK);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error deleteing record with specified id."
				};
				return resp;
			}
		}

		// http://localhost:26198/api/ab120?filterExpression="gkey=1"
		/// <summary>
		/// Deletes ab120 data based on the specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpDelete]
		public HttpResponseMessage DeleteFilter(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (Angular2.Models.ab120.DeleteFilter(filterExpression) > 0)
					throw new HttpResponseException(HttpStatusCode.NotFound);
				else
					return new HttpResponseMessage(HttpStatusCode.OK);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error deleteing record(s) with specified list of ids."
				};
				throw new HttpResponseException(resp);
			}
		}
		#endregion
    }
}
