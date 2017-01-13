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

    public class ab110Controller : ApiController
    {
		#region HTTP GET Methods - returns List<ab110Data>
		// http://localhost:26198/api/ab110
		/// <summary>
		/// Returns list of all ab110 Data
		/// </summary>
		[HttpGet]
		public List<Angular2.Models.ab110Data> Getab110()
		{
			try
			{
				return Angular2.Models.ab110.GetList();
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab110 records."
				};
				throw new HttpResponseException(resp);
			}
		}

		// http://localhost:26198/api/ab110?filterExpression="gkey=1"
		/// <summary>
		/// Returns list of all ab110 Data based on specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpGet]
		public List<ab110Data> Getab110(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (string.IsNullOrWhiteSpace(filterExpression))
					return Angular2.Models.ab110.GetList();
				else
					return Angular2.Models.ab110.GetList(filterExpression);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab110 records."
				};
				throw new HttpResponseException(resp);
			}
		}

		/*
		// http://localhost:26198/api/ab110?filterExpression="gkey=1"&sortExpression="gkey"&pageIndex=1&pageSize=10&rowsCount=0
		public List<ab110Data> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, int rowsCount)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
			
				return Angular2.Models.ab110.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab110 records."
				};
				throw new HttpResponseException(resp);
			}
		}
		*/
		
		// http://localhost:26198/api/Products?filterExpression="ProductID=1"&sortExpression="ProductID"&pageIndex=1&pageSize=10
		/// <summary>
		/// Returns list of all ab110 Data by Page based on specified filter criteria, sort expression, page number and page size
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		/// <param name="sortExpression">Order by field</param>
		/// <param name="pageIndex">Page number</param>
		/// <param name="pageSize">Number of records to retrieve per page</param>
		[HttpGet]
		public ab110DataByPage GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
				int rowsCount = 0;
			
				List<ab110Data> objab110Data = Angular2.Models.ab110.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
				return new ab110DataByPage(objab110Data, rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab110 records."
				};
				throw new HttpResponseException(resp);
			}
		}
		
		// http://localhost:26198/api/ab110/1
		/// <summary>
		/// Returns a ab110 record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab110 data</param>
		[HttpGet]
		public Angular2.Models.ab110Data Getab110ById(string id)
		{
			try
			{
				var item = Angular2.Models.ab110.GetDetailsByID(id);
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

		#region HTTP POST Method - Adds ab110 data into database
		// http://localhost:26198/api/ab110
		/// <summary>
		/// Creates a new ab110 entity
		/// </summary>
		/// <param name="objab110">ab110Data object</param>
		[HttpPost]
		public HttpResponseMessage Postab110(ab110Data objab110)
		{
			try
			{
				//JArray itemArray = item["ab110Data"];
				//JObject jobj = itemArray[0] as JObject;
				//ab110Data objab110 = jobj.ToObject<ab110Data>();
			
				var result = Angular2.Models.ab110.Add(objab110);
				objab110.gkey = result;
				var response = Request.CreateResponse<ab110Data>(HttpStatusCode.Created, objab110);

				string uri = Url.Link("DefaultApi", new { id = objab110.gkey });
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

		#region HTTP PUT Method - Updates ab110 data into database
		// http://localhost:26198/api/ab110
		/// <summary>
		/// Updates an existing ab110 entity
		/// </summary>
		/// <param name="objab110">ab110Data object</param>
		[HttpPut]
		public HttpResponseMessage Putab110(ab110Data objab110)
		{
			try
			{
				//JArray itemArray = item["ab110Data"];
				//JObject obj = itemArray[0] as JObject;
				//ab110Data objab110 = obj.ToObject<ab110Data>();
				if (!Angular2.Models.ab110.Update(objab110))
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
		// Deletes ab110 data for the specified ID
		// http://localhost:26198/api/ab110/1
		/// <summary>
		/// Deletes ab110 record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab110 data</param>
		[HttpDelete]
		public HttpResponseMessage Deleteab110(string id)
		{
			try
			{
				if (!Angular2.Models.ab110.Delete(id))
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

		// http://localhost:26198/api/ab110?filterExpression="gkey=1"
		/// <summary>
		/// Deletes ab110 data based on the specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpDelete]
		public HttpResponseMessage DeleteFilter(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (Angular2.Models.ab110.DeleteFilter(filterExpression) > 0)
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
