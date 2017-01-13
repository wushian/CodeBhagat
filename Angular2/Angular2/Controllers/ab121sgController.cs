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

    public class ab121sgController : ApiController
    {
		#region HTTP GET Methods - returns List<ab121sgData>
		// http://localhost:26198/api/ab121sg
		/// <summary>
		/// Returns list of all ab121sg Data
		/// </summary>
		[HttpGet]
		public List<Angular2.Models.ab121sgData> Getab121sg()
		{
			try
			{
				return Angular2.Models.ab121sg.GetList();
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab121sg records."
				};
				throw new HttpResponseException(resp);
			}
		}

		// http://localhost:26198/api/ab121sg?filterExpression="gkey=1"
		/// <summary>
		/// Returns list of all ab121sg Data based on specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpGet]
		public List<ab121sgData> Getab121sg(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (string.IsNullOrWhiteSpace(filterExpression))
					return Angular2.Models.ab121sg.GetList();
				else
					return Angular2.Models.ab121sg.GetList(filterExpression);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab121sg records."
				};
				throw new HttpResponseException(resp);
			}
		}

		/*
		// http://localhost:26198/api/ab121sg?filterExpression="gkey=1"&sortExpression="gkey"&pageIndex=1&pageSize=10&rowsCount=0
		public List<ab121sgData> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, int rowsCount)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
			
				return Angular2.Models.ab121sg.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab121sg records."
				};
				throw new HttpResponseException(resp);
			}
		}
		*/
		
		// http://localhost:26198/api/Products?filterExpression="ProductID=1"&sortExpression="ProductID"&pageIndex=1&pageSize=10
		/// <summary>
		/// Returns list of all ab121sg Data by Page based on specified filter criteria, sort expression, page number and page size
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		/// <param name="sortExpression">Order by field</param>
		/// <param name="pageIndex">Page number</param>
		/// <param name="pageSize">Number of records to retrieve per page</param>
		[HttpGet]
		public ab121sgDataByPage GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				sortExpression = (!string.IsNullOrWhiteSpace(sortExpression) ? sortExpression.Replace("\"", string.Empty) : string.Empty);
				int rowsCount = 0;
			
				List<ab121sgData> objab121sgData = Angular2.Models.ab121sg.GetList(filterExpression, sortExpression, pageIndex, pageSize, out rowsCount);
				return new ab121sgDataByPage(objab121sgData, rowsCount);
			}
			catch(Exception ex)
			{
				var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
				{
					Content = new StringContent(string.Format("{0}: {1}", ex.Source, ex.Message)),
					ReasonPhrase = "Error retrieving list of ab121sg records."
				};
				throw new HttpResponseException(resp);
			}
		}
		
		// http://localhost:26198/api/ab121sg/1
		/// <summary>
		/// Returns a ab121sg record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab121sg data</param>
		[HttpGet]
		public Angular2.Models.ab121sgData Getab121sgById(string id)
		{
			try
			{
				var item = Angular2.Models.ab121sg.GetDetailsByID(id);
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

		#region HTTP POST Method - Adds ab121sg data into database
		// http://localhost:26198/api/ab121sg
		/// <summary>
		/// Creates a new ab121sg entity
		/// </summary>
		/// <param name="objab121sg">ab121sgData object</param>
		[HttpPost]
		public HttpResponseMessage Postab121sg(ab121sgData objab121sg)
		{
			try
			{
				//JArray itemArray = item["ab121sgData"];
				//JObject jobj = itemArray[0] as JObject;
				//ab121sgData objab121sg = jobj.ToObject<ab121sgData>();
			
				var result = Angular2.Models.ab121sg.Add(objab121sg);
				objab121sg.gkey = result;
				var response = Request.CreateResponse<ab121sgData>(HttpStatusCode.Created, objab121sg);

				string uri = Url.Link("DefaultApi", new { id = objab121sg.gkey });
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

		#region HTTP PUT Method - Updates ab121sg data into database
		// http://localhost:26198/api/ab121sg
		/// <summary>
		/// Updates an existing ab121sg entity
		/// </summary>
		/// <param name="objab121sg">ab121sgData object</param>
		[HttpPut]
		public HttpResponseMessage Putab121sg(ab121sgData objab121sg)
		{
			try
			{
				//JArray itemArray = item["ab121sgData"];
				//JObject obj = itemArray[0] as JObject;
				//ab121sgData objab121sg = obj.ToObject<ab121sgData>();
				if (!Angular2.Models.ab121sg.Update(objab121sg))
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
		// Deletes ab121sg data for the specified ID
		// http://localhost:26198/api/ab121sg/1
		/// <summary>
		/// Deletes ab121sg record based on specified ID
		/// </summary>
		/// <param name="id">The ID of ab121sg data</param>
		[HttpDelete]
		public HttpResponseMessage Deleteab121sg(string id)
		{
			try
			{
				if (!Angular2.Models.ab121sg.Delete(id))
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

		// http://localhost:26198/api/ab121sg?filterExpression="gkey=1"
		/// <summary>
		/// Deletes ab121sg data based on the specified filter criteria
		/// </summary>
		/// <param name="filterExpression">Filter expression/criteria</param>
		[HttpDelete]
		public HttpResponseMessage DeleteFilter(string filterExpression)
		{
			try
			{
				filterExpression = (!string.IsNullOrWhiteSpace(filterExpression) ? filterExpression.Replace("\"", string.Empty) : string.Empty);
				if (Angular2.Models.ab121sg.DeleteFilter(filterExpression) > 0)
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
