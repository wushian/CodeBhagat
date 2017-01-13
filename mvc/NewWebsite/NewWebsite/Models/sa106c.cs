/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: This is class contains methods to perform Data Access Layer operations 
 * Dependency	: This class refers sa106cData Entity class
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
	/// Summary description for sa106c.
	/// </summary>
    public class sa106c
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
		private const string SP_GET_ALL = "SELECT  gkey, serialno, sa106gkey, receiving, mobilephone, ba098gkey, ba097gkey, ba096gkey, recaddress, remark, replication_create, replication_update FROM dbo.sa106c WITH (NOLOCK)";
		private const string SP_GET_FILTER = "SELECT  gkey, serialno, sa106gkey, receiving, mobilephone, ba098gkey, ba097gkey, ba096gkey, recaddress, remark, replication_create, replication_update FROM dbo.sa106c WITH (NOLOCK) {0}";
		private const string SP_GET_BYPAGE = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS rownumber, * FROM dbo.sa106c {1}) AS tblOutput WHERE rownumber BETWEEN {2} AND {3} SELECT COUNT(*) FROM dbo.sa106c WITH (NOLOCK) {4}";
		private const string SP_GET_BYID = "SELECT  gkey, serialno, sa106gkey, receiving, mobilephone, ba098gkey, ba097gkey, ba096gkey, recaddress, remark, replication_create, replication_update FROM dbo.sa106c WITH (NOLOCK) WHERE gkey = @ref_id";
		private const string SP_ADD = "INSERT INTO dbo.sa106c ( gkey, serialno, sa106gkey, receiving, mobilephone, ba098gkey, ba097gkey, ba096gkey, recaddress, remark, replication_create, replication_update) VALUES ( @gkey, @serialno, @sa106gkey, @receiving, @mobilephone, @ba098gkey, @ba097gkey, @ba096gkey, @recaddress, @remark, @replication_create, @replication_update) ";
		private const string SP_ADD1 = "INSERT INTO dbo.sa106c ( gkey, serialno, sa106gkey, receiving, mobilephone, ba098gkey, ba097gkey, ba096gkey, recaddress, remark, replication_create, replication_update) VALUES ( @gkey, @serialno, @sa106gkey, @receiving, @mobilephone, @ba098gkey, @ba097gkey, @ba096gkey, @recaddress, @remark, @replication_create, @replication_update) SELECT @gkey = @@IDENTITY";
		private const string SP_UPDATE = "UPDATE dbo.sa106c SET serialno = @serialno, sa106gkey = @sa106gkey, receiving = @receiving, mobilephone = @mobilephone, ba098gkey = @ba098gkey, ba097gkey = @ba097gkey, ba096gkey = @ba096gkey, recaddress = @recaddress, remark = @remark, replication_create = @replication_create, replication_update = @replication_update WHERE gkey = @gkey";
		private const string SP_DELETE = "DELETE FROM dbo.sa106c WHERE gkey=@ref_id";
		private const string SP_DELETE_FILTER = "DELETE FROM dbo.sa106c {0}";
		private const string SP_GET_LOOKUP = "SELECT gkey, sa106gkey FROM dbo.sa106c WITH (NOLOCK)";
		#endregion
		
		#region sa106c - Constructor
		private sa106c()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
        
		#region sa106c - List sa106c
		/// <summary>
		/// The purpose of this method is to get all sa106c data.
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
        
		#region sa106c - List sa106c by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all sa106c data based on the Filter Expression criteria.
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
        
		#region sa106c - List sa106c by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all sa106c data based on filterExpression, sortExpression, pageIndex and pageSize parameters
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
        
        #region sa106c - Get Details for an sa106c record
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
        
        #region sa106c - Get Lookup Data
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
		
        
		#region sa106c - Add Record
        /// <summary>
        /// Creates a new sa106c row.
        /// </summary>
        public static string Add( string gkey, decimal serialno, string sa106gkey, string receiving, string mobilephone, string ba098gkey, string ba097gkey, string ba096gkey, string recaddress, string remark, DateTime replication_create, DateTime replication_update)
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
						cmd.Parameters.AddWithValue("@receiving", receiving);
						cmd.Parameters.AddWithValue("@mobilephone", mobilephone);
						cmd.Parameters.AddWithValue("@ba098gkey", ba098gkey);
						cmd.Parameters.AddWithValue("@ba097gkey", ba097gkey);
						cmd.Parameters.AddWithValue("@ba096gkey", ba096gkey);
						cmd.Parameters.AddWithValue("@recaddress", recaddress);
						cmd.Parameters.AddWithValue("@remark", remark);
						cmd.Parameters.AddWithValue("@replication_create", replication_create);
						cmd.Parameters.AddWithValue("@replication_update", replication_update);
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
        
		#region sa106c - Update Record
        /// <summary>
        /// Updates a sa106c
        /// </summary>
        public static bool Update( string gkey, decimal serialno, string sa106gkey, string receiving, string mobilephone, string ba098gkey, string ba097gkey, string ba096gkey, string recaddress, string remark, DateTime replication_create, DateTime replication_update)
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
						cmd.Parameters.AddWithValue("@receiving", receiving);
						cmd.Parameters.AddWithValue("@mobilephone", mobilephone);
						cmd.Parameters.AddWithValue("@ba098gkey", ba098gkey);
						cmd.Parameters.AddWithValue("@ba097gkey", ba097gkey);
						cmd.Parameters.AddWithValue("@ba096gkey", ba096gkey);
						cmd.Parameters.AddWithValue("@recaddress", recaddress);
						cmd.Parameters.AddWithValue("@remark", remark);
						cmd.Parameters.AddWithValue("@replication_create", replication_create);
						cmd.Parameters.AddWithValue("@replication_update", replication_update);
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
        
        #region sa106c - Delete Record
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
        
        #region sa106c - Delete Records
        /// <summary>
        /// The purpose of this method is to delete all sa106c data based on the Filter Expression criteria.
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
        
        #region sa106c - Get List of sa106cData objects
        /// <summary>
        /// Returns a collection with all the sa106cData
        /// </summary>
		/// <returns>List of sa106cData object</returns>
        public static List<sa106cData> GetList()
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

						List<sa106cData> objList = new List<sa106cData>();
						while (reader.Read())
						{
							//objList.Add(new sa106cData(
							//	 (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["receiving"], (string) reader["mobilephone"], (string) reader["ba098gkey"], (string) reader["ba097gkey"], (string) reader["ba096gkey"], (string) reader["recaddress"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"]));
							objList.Add(new sa106cData(reader)); // Use this to avoid null issues
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
        
		
		#region sa106c - List sa106c by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all sa106c data based on the Filter Expression criteria.
		/// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
		/// For example, filterExpression - Where condition to be passed in SQL statement.
		/// </param>
		/// <returns>List of sa106cData object</returns>
		public static List<sa106cData> GetList(string filterExpression)
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

						List<sa106cData> objList = new List<sa106cData>();
						while (reader.Read())
						{
							//objList.Add(new sa106cData(
							//	 (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["receiving"], (string) reader["mobilephone"], (string) reader["ba098gkey"], (string) reader["ba097gkey"], (string) reader["ba096gkey"], (string) reader["recaddress"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"]));
							objList.Add(new sa106cData(reader)); // Use this to avoid null issues
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
		
        #region sa106c - List sa106c by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all sa106c data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>List of sa106cData object</returns>
        public static List<sa106cData> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
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

						List<sa106cData> objList = new List<sa106cData>();
						while (reader.Read())
						{
							//objList.Add(new sa106cData(
							//         (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["receiving"], (string) reader["mobilephone"], (string) reader["ba098gkey"], (string) reader["ba097gkey"], (string) reader["ba096gkey"], (string) reader["recaddress"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"]));
							objList.Add(new sa106cData(reader)); // Use this to avoid null issues
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
        
        
		#region sa106c - Get Details by ID
        /// <summary>
        /// Returns an existing sa106cData object with the specified ID 
        /// </summary>
        public static sa106cData GetDetailsByID(string sRefID)
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
						// return new sa106cData(
						//	 (string) reader["gkey"], (decimal) reader["serialno"], (string) reader["sa106gkey"], (string) reader["receiving"], (string) reader["mobilephone"], (string) reader["ba098gkey"], (string) reader["ba097gkey"], (string) reader["ba096gkey"], (string) reader["recaddress"], (string) reader["remark"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"]);
						return new sa106cData(reader); // Use this to avoid null issues
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
        
		#region sa106c - Add Record
        /// <summary>
        /// Creates a new sa106c
        /// </summary>
        public static string Add(sa106cData objsa106c)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_ADD, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objsa106c.gkey);
						cmd.Parameters.AddWithValue("@serialno", objsa106c.serialno);
						cmd.Parameters.AddWithValue("@sa106gkey", objsa106c.sa106gkey);
						cmd.Parameters.AddWithValue("@receiving", objsa106c.receiving);
						cmd.Parameters.AddWithValue("@mobilephone", objsa106c.mobilephone);
						cmd.Parameters.AddWithValue("@ba098gkey", objsa106c.ba098gkey);
						cmd.Parameters.AddWithValue("@ba097gkey", objsa106c.ba097gkey);
						cmd.Parameters.AddWithValue("@ba096gkey", objsa106c.ba096gkey);
						cmd.Parameters.AddWithValue("@recaddress", objsa106c.recaddress);
						cmd.Parameters.AddWithValue("@remark", objsa106c.remark);
						cmd.Parameters.AddWithValue("@replication_create", objsa106c.replication_create);
						cmd.Parameters.AddWithValue("@replication_update", objsa106c.replication_update);
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
        
		#region sa106c - Update Record
		/// <summary>
		/// Updates a sa106c
		/// </summary>
		public static bool Update(sa106cData objsa106c)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_UPDATE, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objsa106c.gkey);
						cmd.Parameters.AddWithValue("@serialno", objsa106c.serialno);
						cmd.Parameters.AddWithValue("@sa106gkey", objsa106c.sa106gkey);
						cmd.Parameters.AddWithValue("@receiving", objsa106c.receiving);
						cmd.Parameters.AddWithValue("@mobilephone", objsa106c.mobilephone);
						cmd.Parameters.AddWithValue("@ba098gkey", objsa106c.ba098gkey);
						cmd.Parameters.AddWithValue("@ba097gkey", objsa106c.ba097gkey);
						cmd.Parameters.AddWithValue("@ba096gkey", objsa106c.ba096gkey);
						cmd.Parameters.AddWithValue("@recaddress", objsa106c.recaddress);
						cmd.Parameters.AddWithValue("@remark", objsa106c.remark);
						cmd.Parameters.AddWithValue("@replication_create", objsa106c.replication_create);
						cmd.Parameters.AddWithValue("@replication_update", objsa106c.replication_update);
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
  