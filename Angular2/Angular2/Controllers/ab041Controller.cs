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

    public class ab041Controller : ApiController
    {
		#region HTTP GET Methods - returns List<ab041Data>
		// http://localhost:26198/api/ab041
		/// <summary>
		/// Returns list of all ab041 Data
		/// </summary>
		[HttpGet]
		public List<Angular2.Models.ab041Data> Getab041()
		{
			try
			{
				return Angular2.Models.ab041.GetList();
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab041 records."
				};
				throw new HttpResponseException(resp);
			}
		}

		// http://localhost:26198/api/ab041?filterExpression="gkey=1"
		/// <summary>
		/// Returns list of all ab041 Data based on specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpGet]
		public List<ab041Data> Getab041(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (string.IsNullOrWhiteSpace(filterExpression))
					return Angular2.Models.ab041.GetList();
				else
					return Angular2.Models.ab041.GetList(filterExpression);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab041 records."
				};
				throw new HttpResponseException(resp);
			}
		}

		/*
		// http://localhost:26198/api/ab041?filterExpression="gkey=1"&sortExpression="gkey"&pageIndex=1&pageSize=10&rowsCount=0
		public List<ab041Data> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, int rowsCount)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
			
				return Angular2.Models.ab041.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab041 records."
				};
				throw new HttpResponseException(resp);
			}
		}
		*/
		
		// http://localhost:26198/api/Products?filterExpression="ProductID=1"&sortExpression="ProductID"&pageIndex=1&pageSize=10
		/// <summary>
		/// Returns list of all ab041 Data by Page based on specified filter criteria, sort expression, page number and page size
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		/// <param name="sortExpression">Order by field</param>
		/// <param name="pageIndex">Page number</param>
		/// <param name="pageSize">Number of records to retrieve per page</param>
		[HttpGet]
		public ab041DataByPage GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
				int rowsCount = 0;
			
				List<ab041Data> objab041Data = Angular2.Models.ab041.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
				return new ab041DataByPage(objab041Data, rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab041 records."
				};
				throw new HttpResponseException(resp);
			}
		}
		
		// http://localhost:26198/api/ab041/1
		/// <summary>
		/// Returns a ab041 record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab041 data</param>
		[HttpGet]
		public Angular2.Models.ab041Data Getab041ById(string id)
		{
			try
			{
				var item = Angular2.Models.ab041.GetDetailsByID(id);
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

		#region HTTP POST Method - Adds ab041 data into database
		// http://localhost:26198/api/ab041
		/// <summary>
		/// Creates a new ab041 entity
		/// </summary>
		/// <param name="objab041">ab041Data object</param>
		[HttpPost]
		public HttpResponseMessage Postab041(ab041Data objab041)
		{
			try
			{
				//JArray itemArray = item["ab041Data"];
				//JObject jobj = itemArray[0] as JObject;
				//ab041Data objab041 = jobj.ToObject<ab041Data>();
			
				var result = Angular2.Models.ab041.Add(objab041);
				objab041.gkey = result;
				var response = Request.CreateResponse<ab041Data>(HttpStatusCode.Created, objab041);

				string uri = Url.Link("DefaultApi", new { id = objab041.gkey });
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

		#region HTTP PUT Method - Updates ab041 data into database
		// http://localhost:26198/api/ab041
		/// <summary>
		/// Updates an existing ab041 entity
		/// </summary>
		/// <param name="objab041">ab041Data object</param>
		[HttpPut]
		public HttpResponseMessage Putab041(ab041Data objab041)
		{
			try
			{
				//JArray itemArray = item["ab041Data"];
				//JObject obj = itemArray[0] as JObject;
				//ab041Data objab041 = obj.ToObject<ab041Data>();
				if (!Angular2.Models.ab041.Update(objab041))
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
		// Deletes ab041 data for the specified ID
		// http://localhost:26198/api/ab041/1
		/// <summary>
		/// Deletes ab041 record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab041 data</param>
		[HttpDelete]
		public HttpResponseMessage Deleteab041(string id)
		{
			try
			{
				if (!Angular2.Models.ab041.Delete(id))
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

		// http://localhost:26198/api/ab041?filterExpression="gkey=1"
		/// <summary>
		/// Deletes ab041 data based on the specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpDelete]
		public HttpResponseMessage DeleteFilter(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (Angular2.Models.ab041.DeleteFilter(filterExpression) > 0)
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
