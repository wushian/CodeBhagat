/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: This is class contains methods to perform Data Access Layer operations 
 * Dependency	: This class refers sa106aData Entity class
 * Instructions	: You may modify code inside code generation template and re-generate the code.
 * ------------------------------------------------------------
*/

#region Using Statements	
using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
#endregion

namespace NewWebsite.Models
{
	/// <summary>
	/// Summary description for sa106a.
	/// </summary>
    public class sa106a
    {
        //private static string connectionString = ConfigurationManager.ConnectionStrings["defaultDatabase"].ConnectionString;
		private static string connectionString
		{
			get 
			{
				return ConfigurationManager.ConnectionStrings["defaultDatabase"].ConnectionString;
			}
		}
		
		#region Constants
		private const string SP_GET_ALL = "SELECT  gkey, serialno, sa106gkey, ba101gkey, ba110gkey, ba113gkey, mr200gkey, mr200agkey, ba120gkey, ba121gkey, ba106gkey, shipmentdate, canceldate, cancelreason, activityid, activityname, quantity, nodisprice, noamount, disprice, cancelqty, cancelamt, outquantity, retquantity, prepono, mr210gkey, mr210agkey, remark, replication_create, replication_update, inventoryQty, outstockQty, tstdqty, ba126gkey, webgkey, canadaamt, ba117gkey FROM dbo.sa106a WITH (NOLOCK)";
		private const string SP_GET_FILTER = "SELECT  gkey, serialno, sa106gkey, ba101gkey, ba110gkey, ba113gkey, mr200gkey, mr200agkey, ba120gkey, ba121gkey, ba106gkey, shipmentdate, canceldate, cancelreason, activityid, activityname, quantity, nodisprice, noamount, disprice, cancelqty, cancelamt, outquantity, retquantity, prepono, mr210gkey, mr210agkey, remark, replication_create, replication_update, inventoryQty, outstockQty, tstdqty, ba126gkey, webgkey, canadaamt, ba117gkey FROM dbo.sa106a WITH (NOLOCK) {0}";
		private const string SP_GET_BYPAGE = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS rownumber, * FROM dbo.sa106a {1}) AS tblOutput WHERE rownumber BETWEEN {2} AND {3} SELECT COUNT(*) FROM dbo.sa106a WITH (NOLOCK) {4}";
		private const string SP_GET_BYID = "SELECT  gkey, serialno, sa106gkey, ba101gkey, ba110gkey, ba113gkey, mr200gkey, mr200agkey, ba120gkey, ba121gkey, ba106gkey, shipmentdate, canceldate, cancelreason, activityid, activityname, quantity, nodisprice, noamount, disprice, cancelqty, cancelamt, outquantity, retquantity, prepono, mr210gkey, mr210agkey, remark, replication_create, replication_update, inventoryQty, outstockQty, tstdqty, ba126gkey, webgkey, canadaamt, ba117gkey FROM dbo.sa106a WITH (NOLOCK) WHERE gkey = @ref_id";
		private const string SP_ADD = "INSERT INTO dbo.sa106a ( gkey, serialno, sa106gkey, ba101gkey, ba110gkey, ba113gkey, mr200gkey, mr200agkey, ba120gkey, ba121gkey, ba106gkey, shipmentdate, canceldate, cancelreason, activityid, activityname, quantity, nodisprice, noamount, disprice, cancelqty, cancelamt, outquantity, retquantity, prepono, mr210gkey, mr210agkey, remark, replication_create, replication_update, inventoryQty, outstockQty, tstdqty, ba126gkey, webgkey, canadaamt, ba117gkey) VALUES ( @gkey, @serialno, @sa106gkey, @ba101gkey, @ba110gkey, @ba113gkey, @mr200gkey, @mr200agkey, @ba120gkey, @ba121gkey, @ba106gkey, @shipmentdate, @canceldate, @cancelreason, @activityid, @activityname, @quantity, @nodisprice, @noamount, @disprice, @cancelqty, @cancelamt, @outquantity, @retquantity, @prepono, @mr210gkey, @mr210agkey, @remark, @replication_create, @replication_update, @inventoryQty, @outstockQty, @tstdqty, @ba126gkey, @webgkey, @canadaamt, @ba117gkey) ";
		private const string SP_ADD1 = "INSERT INTO dbo.sa106a ( gkey, serialno, sa106gkey, ba101gkey, ba110gkey, ba113gkey, mr200gkey, mr200agkey, ba120gkey, ba121gkey, ba106gkey, shipmentdate, canceldate, cancelreason, activityid, activityname, quantity, nodisprice, noamount, disprice, cancelqty, cancelamt, outquantity, retquantity, prepono, mr210gkey, mr210agkey, remark, replication_create, replication_update, inventoryQty, outstockQty, tstdqty, ba126gkey, webgkey, canadaamt, ba117gkey) VALUES ( @gkey, @serialno, @sa106gkey, @ba101gkey, @ba110gkey, @ba113gkey, @mr200gkey, @mr200agkey, @ba120gkey, @ba121gkey, @ba106gkey, @shipmentdate, @canceldate, @cancelreason, @activityid, @activityname, @quantity, @nodisprice, @noamount, @disprice, @cancelqty, @cancelamt, @outquantity, @retquantity, @prepono, @mr210gkey, @mr210agkey, @remark, @replication_create, @replication_update, @inventoryQty, @outstockQty, @tstdqty, @ba126gkey, @webgkey, @canadaamt, @ba117gkey) SELECT @gkey = @@IDENTITY";
		private const string SP_UPDATE = "UPDATE dbo.sa106a SET serialno = @serialno, sa106gkey = @sa106gkey, ba101gkey = @ba101gkey, ba110gkey = @ba110gkey, ba113gkey = @ba113gkey, mr200gkey = @mr200gkey, mr200agkey = @mr200agkey, ba120gkey = @ba120gkey, ba121gkey = @ba121gkey, ba106gkey = @ba106gkey, shipmentdate = @shipmentdate, canceldate = @canceldate, cancelreason = @cancelreason, activityid = @activityid, activityname = @activityname, quantity = @quantity, nodisprice = @nodisprice, noamount = @noamount, disprice = @disprice, cancelqty = @cancelqty, cancelamt = @cancelamt, outquantity = @outquantity, retquantity = @retquantity, prepono = @prepono, mr210gkey = @mr210gkey, mr210agkey = @mr210agkey, remark = @remark, replication_create = @replication_create, replication_update = @replication_update, inventoryQty = @inventoryQty, outstockQty = @outstockQty, tstdqty = @tstdqty, ba126gkey = @ba126gkey, webgkey = @webgkey, canadaamt = @canadaamt, ba117gkey = @ba117gkey WHERE gkey = @gkey";
		private const string SP_DELETE = "DELETE FROM dbo.sa106a WHERE gkey=@ref_id";
		private const string SP_DELETE_FILTER = "DELETE FROM dbo.sa106a {0}";
		private const string SP_GET_LOOKUP = "SELECT gkey, sa106gkey FROM dbo.sa106a WITH (NOLOCK)";
		#endregion
		
		#region sa106a - Constructor
		private sa106a()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
        
		#region sa106a - List sa106a
		/// <summary>
		/// The purpose of this method is to get all sa106a data.
		/// </summary>
		/// <returns>DataSet object</returns>
		public static DataSet GetData()
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlDataAdapter da = new SqlDataAdapter())
					{
						using (SqlCommand cmd = new SqlCommand(SP_GET_ALL, cn))
						{
							cmd.CommandType = CommandType.Text;
							DataSet ds = new DataSet();

							da.SelectCommand = cmd;
							da.Fill(ds);
							return ds;
						}
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
		}
		#endregion
        
		#region sa106a - List sa106a by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all sa106a data based on the Filter Expression criteria.
		/// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
		/// For example, filterExpression - Where condition to be passed in SQL statement.
		/// </param>
		/// <returns>DataSet object</returns>
		public static DataSet GetData(string filterExpression)
		{
			try
			{
				//if (SecurityHelper.CheckForSQLInjection(filterExpression)) 
				//    throw new Exception("Dangerous Input! Possibly SQL Injection Attack!!!");
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlDataAdapter da = new SqlDataAdapter())
					{
						filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression);
						string strSQL = string.Format(SP_GET_FILTER, filterExpression);
						using (SqlCommand cmd = new SqlCommand(strSQL, cn))
						{
							cmd.CommandType = CommandType.Text;
							DataSet ds = new DataSet();
							da.SelectCommand = cmd;
							da.Fill(ds);
							return ds;
						}
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
		}
		#endregion
        
		#region sa106a - List sa106a by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all sa106a data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>DataSet object</returns>
        public static DataSet GetData(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlDataAdapter da = new SqlDataAdapter())
					{
						filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression);
						//if (SecurityHelper.CheckForSQLInjection(filterExpression)) 
						//    throw new Exception("Dangerous Input! Possibly SQL Injection Attack!!!");
						int lbound = ((pageIndex - 1) * pageSize) +1;
						int ubound = lbound + pageSize - 1;
						string strSQL = string.Format(SP_GET_BYPAGE, sortExpression, filterExpression, lbound, ubound, filterExpression);
						using (SqlCommand cmd = new SqlCommand(strSQL, cn))
						{
							cmd.CommandType = CommandType.Text;
							DataSet ds = new DataSet();
							da.SelectCommand = cmd;
							da.Fill(ds);
							rowsCount = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
							return ds;
						}
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
		#endregion
        
        #region sa106a - Get Details for an sa106a record
        /// <summary>
		/// The purpose of this method is to get the data based on specified primary key value
		/// </summary>
		/// <param name="sRefID">Primary key value</param>
		/// <returns></returns>
		public static DataSet GetDetails(string sRefID)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlDataAdapter da = new SqlDataAdapter())
					{
						string strSQL = string.Format(SP_GET_BYID, sRefID);
						using (SqlCommand cmd = new SqlCommand(strSQL, cn))
						{
							cmd.CommandType = CommandType.Text;
							cmd.Parameters.AddWithValue("@ref_id", sRefID);
							DataSet ds = new DataSet();
							da.SelectCommand = cmd;
							da.Fill(ds);
							return ds;
						}
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
		}
		#endregion
        //[GET_VALUEBYID_METHOD]
        
        #region sa106a - Get Lookup Data
        /// <summary>
        /// The purpose of this method is to get the lookup data
        /// </summary>
        /// <returns>returns Lookup Data as DataSet</returns>
        public static DataSet GetLookup()
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlDataAdapter da = new SqlDataAdapter())
					{
						using (SqlCommand cmd = new SqlCommand(SP_GET_LOOKUP, cn))
						{
							cmd.CommandType = CommandType.Text;
							DataSet ds = new DataSet();

							da.SelectCommand = cmd;
							da.Fill(ds);
							return ds;
						}
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
		
        
		#region sa106a - Add Record
        /// <summary>
        /// Creates a new sa106a row.
        /// </summary>
        public static string Add( string gkey, decimal serialno, string sa106gkey, string ba101gkey, string ba110gkey, string ba113gkey, string mr200gkey, string mr200agkey, string ba120gkey, string ba121gkey, string ba106gkey, DateTime shipmentdate, DateTime canceldate, string cancelreason, string activityid, string activityname, decimal quantity, decimal nodisprice, decimal noamount, decimal disprice, decimal cancelqty, decimal cancelamt, decimal outquantity, decimal retquantity, string prepono, string mr210gkey, string mr210agkey, string remark, DateTime replication_create, DateTime replication_update, decimal inventoryQty, decimal outstockQty, decimal tstdqty, string ba126gkey, string webgkey, decimal canadaamt, string ba117gkey)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_ADD, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", gkey);
						cmd.Parameters.AddWithValue("@serialno", serialno);
						cmd.Parameters.AddWithValue("@sa106gkey", sa106gkey);
						cmd.Parameters.AddWithValue("@ba101gkey", ba101gkey);
						cmd.Parameters.AddWithValue("@ba110gkey", ba110gkey);
						cmd.Parameters.AddWithValue("@ba113gkey", ba113gkey);
						cmd.Parameters.AddWithValue("@mr200gkey", mr200gkey);
						cmd.Parameters.AddWithValue("@mr200agkey", mr200agkey);
						cmd.Parameters.AddWithValue("@ba120gkey", ba120gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", ba121gkey);
						cmd.Parameters.AddWithValue("@ba106gkey", ba106gkey);
						cmd.Parameters.AddWithValue("@shipmentdate", shipmentdate);
						cmd.Parameters.AddWithValue("@canceldate", canceldate);
						cmd.Parameters.AddWithValue("@cancelreason", cancelreason);
						cmd.Parameters.AddWithValue("@activityid", activityid);
						cmd.Parameters.AddWithValue("@activityname", activityname);
						cmd.Parameters.AddWithValue("@quantity", quantity);
						cmd.Parameters.AddWithValue("@nodisprice", nodisprice);
						cmd.Parameters.AddWithValue("@noamount", noamount);
						cmd.Parameters.AddWithValue("@disprice", disprice);
						cmd.Parameters.AddWithValue("@cancelqty", cancelqty);
						cmd.Parameters.AddWithValue("@cancelamt", cancelamt);
						cmd.Parameters.AddWithValue("@outquantity", outquantity);
						cmd.Parameters.AddWithValue("@retquantity", retquantity);
						cmd.Parameters.AddWithValue("@prepono", prepono);
						cmd.Parameters.AddWithValue("@mr210gkey", mr210gkey);
						cmd.Parameters.AddWithValue("@mr210agkey", mr210agkey);
						cmd.Parameters.AddWithValue("@remark", remark);
						cmd.Parameters.AddWithValue("@replication_create", replication_create);
						cmd.Parameters.AddWithValue("@replication_update", replication_update);
						cmd.Parameters.AddWithValue("@inventoryQty", inventoryQty);
						cmd.Parameters.AddWithValue("@outstockQty", outstockQty);
						cmd.Parameters.AddWithValue("@tstdqty", tstdqty);
						cmd.Parameters.AddWithValue("@ba126gkey", ba126gkey);
						cmd.Parameters.AddWithValue("@webgkey", webgkey);
						cmd.Parameters.AddWithValue("@canadaamt", canadaamt);
						cmd.Parameters.AddWithValue("@ba117gkey", ba117gkey);
						cn.Open();
						int rowsAffected = cmd.ExecuteNonQuery();
						return (string)cmd.Parameters["@gkey"].Value;
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
        
		#region sa106a - Update Record
        /// <summary>
        /// Updates a sa106a
        /// </summary>
        public static bool Update( string gkey, decimal serialno, string sa106gkey, string ba101gkey, string ba110gkey, string ba113gkey, string mr200gkey, string mr200agkey, string ba120gkey, string ba121gkey, string ba106gkey, DateTime shipmentdate, DateTime canceldate, string cancelreason, string activityid, string activityname, decimal quantity, decimal nodisprice, decimal noamount, decimal disprice, decimal cancelqty, decimal cancelamt, decimal outquantity, decimal retquantity, string prepono, string mr210gkey, string mr210agkey, string remark, DateTime replication_create, DateTime replication_update, decimal inventoryQty, decimal outstockQty, decimal tstdqty, string ba126gkey, string webgkey, decimal canadaamt, string ba117gkey)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_UPDATE, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", gkey);
						cmd.Parameters.AddWithValue("@serialno", serialno);
						cmd.Parameters.AddWithValue("@sa106gkey", sa106gkey);
						cmd.Parameters.AddWithValue("@ba101gkey", ba101gkey);
						cmd.Parameters.AddWithValue("@ba110gkey", ba110gkey);
						cmd.Parameters.AddWithValue("@ba113gkey", ba113gkey);
						cmd.Parameters.AddWithValue("@mr200gkey", mr200gkey);
						cmd.Parameters.AddWithValue("@mr200agkey", mr200agkey);
						cmd.Parameters.AddWithValue("@ba120gkey", ba120gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", ba121gkey);
						cmd.Parameters.AddWithValue("@ba106gkey", ba106gkey);
						cmd.Parameters.AddWithValue("@shipmentdate", shipmentdate);
						cmd.Parameters.AddWithValue("@canceldate", canceldate);
						cmd.Parameters.AddWithValue("@cancelreason", cancelreason);
						cmd.Parameters.AddWithValue("@activityid", activityid);
						cmd.Parameters.AddWithValue("@activityname", activityname);
						cmd.Parameters.AddWithValue("@quantity", quantity);
						cmd.Parameters.AddWithValue("@nodisprice", nodisprice);
						cmd.Parameters.AddWithValue("@noamount", noamount);
						cmd.Parameters.AddWithValue("@disprice", disprice);
						cmd.Parameters.AddWithValue("@cancelqty", cancelqty);
						cmd.Parameters.AddWithValue("@cancelamt", cancelamt);
						cmd.Parameters.AddWithValue("@outquantity", outquantity);
						cmd.Parameters.AddWithValue("@retquantity", retquantity);
						cmd.Parameters.AddWithValue("@prepono", prepono);
						cmd.Parameters.AddWithValue("@mr210gkey", mr210gkey);
						cmd.Parameters.AddWithValue("@mr210agkey", mr210agkey);
						cmd.Parameters.AddWithValue("@remark", remark);
						cmd.Parameters.AddWithValue("@replication_create", replication_create);
						cmd.Parameters.AddWithValue("@replication_update", replication_update);
						cmd.Parameters.AddWithValue("@inventoryQty", inventoryQty);
						cmd.Parameters.AddWithValue("@outstockQty", outstockQty);
						cmd.Parameters.AddWithValue("@tstdqty", tstdqty);
						cmd.Parameters.AddWithValue("@ba126gkey", ba126gkey);
						cmd.Parameters.AddWithValue("@webgkey", webgkey);
						cmd.Parameters.AddWithValue("@canadaamt", canadaamt);
						cmd.Parameters.AddWithValue("@ba117gkey", ba117gkey);
						cn.Open();
						int rowsAffected = cmd.ExecuteNonQuery();
						return (rowsAffected == 1);
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
        
        #region sa106a - Delete Record
        /// <summary>
        /// The purpose of this method is to delete the record based on specified primary key value
        /// </summary>
        /// <param name="sRefID">Primary key value</param>
        /// <returns></returns>
        public static bool Delete(string sRefID)
        {
			try
			{
				bool bDeleted = false;
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_DELETE, cn))
					{
						cmd.CommandType = CommandType.Text;
						//cmd.Parameters.Add("@gkey", SqlDbType.string).Value = sRefID;
						cmd.Parameters.AddWithValue("@ref_id", sRefID);
						cn.Open();
						int rowsAffected = cmd.ExecuteNonQuery();
						bDeleted = (rowsAffected == 1);
					}
				}
				return bDeleted;
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
        
        #region sa106a - Delete Records
        /// <summary>
        /// The purpose of this method is to delete all sa106a data based on the Filter Expression criteria.
        /// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
		/// For example, filterExpression - Where condition to be passed in SQL statement.
		/// </param>
        /// <returns>Returns the number of rows deleted</returns>
        public static int DeleteFilter(string filterExpression)
        {
			try
			{
				int rowsAffected = 0;
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression);
					string strSQL = string.Format(SP_DELETE_FILTER, filterExpression);
					using (SqlCommand cmd = new SqlCommand(strSQL, cn))
					{
						cmd.CommandType = CommandType.Text;
						cn.Open();
						rowsAffected = cmd.ExecuteNonQuery();
					}
				}
				return rowsAffected;
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
        
        #region sa106a - Get List of sa106aData objects
        /// <summary>
        /// Returns a collection with all the sa106aData
        /// </summary>
		/// <returns>List of sa106aData object</returns>
        public static List<sa106aData> GetList()
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_GET_ALL, cn))
					{
						cmd.CommandType = CommandType.Text;
						cn.Open();
						IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

						List<sa106aData> objList = new List<sa106aData>();
						while (reader.Read())
						{
							//objList.Add(new sa106aData(
							//	 (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["ba101gkey"], (string) reader["ba110gkey"], (string) reader["ba113gkey"], (string) reader["mr200gkey"], (string) reader["mr200agkey"], (string) reader["ba120gkey"], (string) reader["ba121gkey"], (string) reader["ba106gkey"], (DateTime) reader["shipmentdate"], (DateTime) reader["canceldate"], (string) reader["cancelreason"], (string) reader["activityid"], (string) reader["activityname"], (decimal) reader["quantity"], (decimal) reader["nodisprice"], (decimal) reader["noamount"], (decimal) reader["disprice"], (decimal) reader["cancelqty"], (decimal) reader["cancelamt"], (decimal) reader["outquantity"], (decimal) reader["retquantity"], (string) reader["prepono"], (string) reader["mr210gkey"], (string) reader["mr210agkey"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["inventoryQty"], (decimal) reader["outstockQty"], (decimal) reader["tstdqty"], (string) reader["ba126gkey"], (string) reader["webgkey"], (decimal) reader["canadaamt"], (string) reader["ba117gkey"]));
							objList.Add(new sa106aData(reader)); // Use this to avoid null issues
						}
						return objList;    
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
        
		
		#region sa106a - List sa106a by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all sa106a data based on the Filter Expression criteria.
		/// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
		/// For example, filterExpression - Where condition to be passed in SQL statement.
		/// </param>
		/// <returns>List of sa106aData object</returns>
		public static List<sa106aData> GetList(string filterExpression)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression.Trim());
					//if (SecurityHelper.CheckForSQLInjection(filterExpression)) 
					//    throw new Exception("Dangerous Input! Possibly SQL Injection Attack!!!");
					string strSQL = string.Format(SP_GET_FILTER, filterExpression);
					using (SqlCommand cmd = new SqlCommand(strSQL, cn))
					{
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@where_clause", filterExpression);
						cn.Open();
						IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

						List<sa106aData> objList = new List<sa106aData>();
						while (reader.Read())
						{
							//objList.Add(new sa106aData(
							//	 (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["ba101gkey"], (string) reader["ba110gkey"], (string) reader["ba113gkey"], (string) reader["mr200gkey"], (string) reader["mr200agkey"], (string) reader["ba120gkey"], (string) reader["ba121gkey"], (string) reader["ba106gkey"], (DateTime) reader["shipmentdate"], (DateTime) reader["canceldate"], (string) reader["cancelreason"], (string) reader["activityid"], (string) reader["activityname"], (decimal) reader["quantity"], (decimal) reader["nodisprice"], (decimal) reader["noamount"], (decimal) reader["disprice"], (decimal) reader["cancelqty"], (decimal) reader["cancelamt"], (decimal) reader["outquantity"], (decimal) reader["retquantity"], (string) reader["prepono"], (string) reader["mr210gkey"], (string) reader["mr210agkey"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["inventoryQty"], (decimal) reader["outstockQty"], (decimal) reader["tstdqty"], (string) reader["ba126gkey"], (string) reader["webgkey"], (decimal) reader["canadaamt"], (string) reader["ba117gkey"]));
							objList.Add(new sa106aData(reader)); // Use this to avoid null issues
						}
						return objList;    
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
		}
		#endregion
		
        #region sa106a - List sa106a by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all sa106a data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>List of sa106aData object</returns>
        public static List<sa106aData> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression.Trim());
					//if (SecurityHelper.CheckForSQLInjection(filterExpression)) 
					//    throw new Exception("Dangerous Input! Possibly SQL Injection Attack!!!");
					int lbound = ((pageIndex - 1) * pageSize) + 1;
					int ubound = lbound + pageSize - 1;
					string strSQL = string.Format(SP_GET_BYPAGE, sortExpression, filterExpression, lbound, ubound, filterExpression);
					using (SqlCommand cmd = new SqlCommand(strSQL, cn))
					{
						cmd.CommandType = CommandType.Text;
						cn.Open();
						IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

						List<sa106aData> objList = new List<sa106aData>();
						while (reader.Read())
						{
							//objList.Add(new sa106aData(
							//         (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["ba101gkey"], (string) reader["ba110gkey"], (string) reader["ba113gkey"], (string) reader["mr200gkey"], (string) reader["mr200agkey"], (string) reader["ba120gkey"], (string) reader["ba121gkey"], (string) reader["ba106gkey"], (DateTime) reader["shipmentdate"], (DateTime) reader["canceldate"], (string) reader["cancelreason"], (string) reader["activityid"], (string) reader["activityname"], (decimal) reader["quantity"], (decimal) reader["nodisprice"], (decimal) reader["noamount"], (decimal) reader["disprice"], (decimal) reader["cancelqty"], (decimal) reader["cancelamt"], (decimal) reader["outquantity"], (decimal) reader["retquantity"], (string) reader["prepono"], (string) reader["mr210gkey"], (string) reader["mr210agkey"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["inventoryQty"], (decimal) reader["outstockQty"], (decimal) reader["tstdqty"], (string) reader["ba126gkey"], (string) reader["webgkey"], (decimal) reader["canadaamt"], (string) reader["ba117gkey"]));
							objList.Add(new sa106aData(reader)); // Use this to avoid null issues
						}
						reader.NextResult();
						reader.Read();
						rowsCount = Convert.ToInt32(reader[0]);
						reader.Close();

						return objList;
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
        
        
		#region sa106a - Get Details by ID
        /// <summary>
        /// Returns an existing sa106aData object with the specified ID 
        /// </summary>
        public static sa106aData GetDetailsByID(string sRefID)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					SqlCommand cmd = new SqlCommand(SP_GET_BYID, cn);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@ref_id", sRefID);
					cn.Open();
                
					IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
					if (reader.Read())
					{
						// return new sa106aData(
						//	 (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["ba101gkey"], (string) reader["ba110gkey"], (string) reader["ba113gkey"], (string) reader["mr200gkey"], (string) reader["mr200agkey"], (string) reader["ba120gkey"], (string) reader["ba121gkey"], (string) reader["ba106gkey"], (DateTime) reader["shipmentdate"], (DateTime) reader["canceldate"], (string) reader["cancelreason"], (string) reader["activityid"], (string) reader["activityname"], (decimal) reader["quantity"], (decimal) reader["nodisprice"], (decimal) reader["noamount"], (decimal) reader["disprice"], (decimal) reader["cancelqty"], (decimal) reader["cancelamt"], (decimal) reader["outquantity"], (decimal) reader["retquantity"], (string) reader["prepono"], (string) reader["mr210gkey"], (string) reader["mr210agkey"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["inventoryQty"], (decimal) reader["outstockQty"], (decimal) reader["tstdqty"], (string) reader["ba126gkey"], (string) reader["webgkey"], (decimal) reader["canadaamt"], (string) reader["ba117gkey"]);
						return new sa106aData(reader); // Use this to avoid null issues
					}
					else
						return null;
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
		#endregion
        
		#region sa106a - Add Record
        /// <summary>
        /// Creates a new sa106a
        /// </summary>
        public static string Add(sa106aData objsa106a)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_ADD, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objsa106a.gkey);
						cmd.Parameters.AddWithValue("@serialno", objsa106a.serialno);
						cmd.Parameters.AddWithValue("@sa106gkey", objsa106a.sa106gkey);
						cmd.Parameters.AddWithValue("@ba101gkey", objsa106a.ba101gkey);
						cmd.Parameters.AddWithValue("@ba110gkey", objsa106a.ba110gkey);
						cmd.Parameters.AddWithValue("@ba113gkey", objsa106a.ba113gkey);
						cmd.Parameters.AddWithValue("@mr200gkey", objsa106a.mr200gkey);
						cmd.Parameters.AddWithValue("@mr200agkey", objsa106a.mr200agkey);
						cmd.Parameters.AddWithValue("@ba120gkey", objsa106a.ba120gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", objsa106a.ba121gkey);
						cmd.Parameters.AddWithValue("@ba106gkey", objsa106a.ba106gkey);
						cmd.Parameters.AddWithValue("@shipmentdate", objsa106a.shipmentdate);
						cmd.Parameters.AddWithValue("@canceldate", objsa106a.canceldate);
						cmd.Parameters.AddWithValue("@cancelreason", objsa106a.cancelreason);
						cmd.Parameters.AddWithValue("@activityid", objsa106a.activityid);
						cmd.Parameters.AddWithValue("@activityname", objsa106a.activityname);
						cmd.Parameters.AddWithValue("@quantity", objsa106a.quantity);
						cmd.Parameters.AddWithValue("@nodisprice", objsa106a.nodisprice);
						cmd.Parameters.AddWithValue("@noamount", objsa106a.noamount);
						cmd.Parameters.AddWithValue("@disprice", objsa106a.disprice);
						cmd.Parameters.AddWithValue("@cancelqty", objsa106a.cancelqty);
						cmd.Parameters.AddWithValue("@cancelamt", objsa106a.cancelamt);
						cmd.Parameters.AddWithValue("@outquantity", objsa106a.outquantity);
						cmd.Parameters.AddWithValue("@retquantity", objsa106a.retquantity);
						cmd.Parameters.AddWithValue("@prepono", objsa106a.prepono);
						cmd.Parameters.AddWithValue("@mr210gkey", objsa106a.mr210gkey);
						cmd.Parameters.AddWithValue("@mr210agkey", objsa106a.mr210agkey);
						cmd.Parameters.AddWithValue("@remark", objsa106a.remark);
						cmd.Parameters.AddWithValue("@replication_create", objsa106a.replication_create);
						cmd.Parameters.AddWithValue("@replication_update", objsa106a.replication_update);
						cmd.Parameters.AddWithValue("@inventoryQty", objsa106a.inventoryQty);
						cmd.Parameters.AddWithValue("@outstockQty", objsa106a.outstockQty);
						cmd.Parameters.AddWithValue("@tstdqty", objsa106a.tstdqty);
						cmd.Parameters.AddWithValue("@ba126gkey", objsa106a.ba126gkey);
						cmd.Parameters.AddWithValue("@webgkey", objsa106a.webgkey);
						cmd.Parameters.AddWithValue("@canadaamt", objsa106a.canadaamt);
						cmd.Parameters.AddWithValue("@ba117gkey", objsa106a.ba117gkey);
						cn.Open();
						int rowsAffected = cmd.ExecuteNonQuery();
						return (string)cmd.Parameters["@gkey"].Value;
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
        }
        #endregion
        
		#region sa106a - Update Record
		/// <summary>
		/// Updates a sa106a
		/// </summary>
		public static bool Update(sa106aData objsa106a)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_UPDATE, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objsa106a.gkey);
						cmd.Parameters.AddWithValue("@serialno", objsa106a.serialno);
						cmd.Parameters.AddWithValue("@sa106gkey", objsa106a.sa106gkey);
						cmd.Parameters.AddWithValue("@ba101gkey", objsa106a.ba101gkey);
						cmd.Parameters.AddWithValue("@ba110gkey", objsa106a.ba110gkey);
						cmd.Parameters.AddWithValue("@ba113gkey", objsa106a.ba113gkey);
						cmd.Parameters.AddWithValue("@mr200gkey", objsa106a.mr200gkey);
						cmd.Parameters.AddWithValue("@mr200agkey", objsa106a.mr200agkey);
						cmd.Parameters.AddWithValue("@ba120gkey", objsa106a.ba120gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", objsa106a.ba121gkey);
						cmd.Parameters.AddWithValue("@ba106gkey", objsa106a.ba106gkey);
						cmd.Parameters.AddWithValue("@shipmentdate", objsa106a.shipmentdate);
						cmd.Parameters.AddWithValue("@canceldate", objsa106a.canceldate);
						cmd.Parameters.AddWithValue("@cancelreason", objsa106a.cancelreason);
						cmd.Parameters.AddWithValue("@activityid", objsa106a.activityid);
						cmd.Parameters.AddWithValue("@activityname", objsa106a.activityname);
						cmd.Parameters.AddWithValue("@quantity", objsa106a.quantity);
						cmd.Parameters.AddWithValue("@nodisprice", objsa106a.nodisprice);
						cmd.Parameters.AddWithValue("@noamount", objsa106a.noamount);
						cmd.Parameters.AddWithValue("@disprice", objsa106a.disprice);
						cmd.Parameters.AddWithValue("@cancelqty", objsa106a.cancelqty);
						cmd.Parameters.AddWithValue("@cancelamt", objsa106a.cancelamt);
						cmd.Parameters.AddWithValue("@outquantity", objsa106a.outquantity);
						cmd.Parameters.AddWithValue("@retquantity", objsa106a.retquantity);
						cmd.Parameters.AddWithValue("@prepono", objsa106a.prepono);
						cmd.Parameters.AddWithValue("@mr210gkey", objsa106a.mr210gkey);
						cmd.Parameters.AddWithValue("@mr210agkey", objsa106a.mr210agkey);
						cmd.Parameters.AddWithValue("@remark", objsa106a.remark);
						cmd.Parameters.AddWithValue("@replication_create", objsa106a.replication_create);
						cmd.Parameters.AddWithValue("@replication_update", objsa106a.replication_update);
						cmd.Parameters.AddWithValue("@inventoryQty", objsa106a.inventoryQty);
						cmd.Parameters.AddWithValue("@outstockQty", objsa106a.outstockQty);
						cmd.Parameters.AddWithValue("@tstdqty", objsa106a.tstdqty);
						cmd.Parameters.AddWithValue("@ba126gkey", objsa106a.ba126gkey);
						cmd.Parameters.AddWithValue("@webgkey", objsa106a.webgkey);
						cmd.Parameters.AddWithValue("@canadaamt", objsa106a.canadaamt);
						cmd.Parameters.AddWithValue("@ba117gkey", objsa106a.ba117gkey);
						cn.Open();
						int rowsAffected = cmd.ExecuteNonQuery();
						return (rowsAffected == 1);
					}
				}
			}
			catch(Exception ex)
			{
				// Put your code for Execption Handling here
				// 1. Log the error
				// 2. Handle or Throw Exception
				// Note: You may modify code generation template by editing ExceptionHandler CodeBlock
				throw ex;
			}
		}
		#endregion
    }
}
  