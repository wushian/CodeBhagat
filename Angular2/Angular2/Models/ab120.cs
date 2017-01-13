/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: This is class contains methods to perform Data Access Layer operations 
 * Dependency	: This class refers ab120Data Entity class
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

namespace Angular2.Models
{
	/// <summary>
	/// Summary description for ab120.
	/// </summary>
    public class ab120
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
		private const string SP_GET_ALL = "SELECT  gkey, ba015gkey, ba015gkey1, ac002gkey1, ac002gkey2, ac002gkey3, ac002gkey4, ab041gkey1, accountno1, ab041gkey2, accountno2, clsdd, mmend, chkdd, payee, bankinfo, swift FROM dbo.ab120 WITH (NOLOCK)";
		private const string SP_GET_FILTER = "SELECT  gkey, ba015gkey, ba015gkey1, ac002gkey1, ac002gkey2, ac002gkey3, ac002gkey4, ab041gkey1, accountno1, ab041gkey2, accountno2, clsdd, mmend, chkdd, payee, bankinfo, swift FROM dbo.ab120 WITH (NOLOCK) {0}";
		private const string SP_GET_BYPAGE = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS rownumber, * FROM dbo.ab120 {1}) AS tblOutput WHERE rownumber BETWEEN {2} AND {3} SELECT COUNT(*) FROM dbo.ab120 WITH (NOLOCK) {4}";
		private const string SP_GET_BYID = "SELECT  gkey, ba015gkey, ba015gkey1, ac002gkey1, ac002gkey2, ac002gkey3, ac002gkey4, ab041gkey1, accountno1, ab041gkey2, accountno2, clsdd, mmend, chkdd, payee, bankinfo, swift FROM dbo.ab120 WITH (NOLOCK) WHERE gkey = @ref_id";
		private const string SP_ADD = "INSERT INTO dbo.ab120 ( gkey, ba015gkey, ba015gkey1, ac002gkey1, ac002gkey2, ac002gkey3, ac002gkey4, ab041gkey1, accountno1, ab041gkey2, accountno2, clsdd, mmend, chkdd, payee, bankinfo, swift) VALUES ( @gkey, @ba015gkey, @ba015gkey1, @ac002gkey1, @ac002gkey2, @ac002gkey3, @ac002gkey4, @ab041gkey1, @accountno1, @ab041gkey2, @accountno2, @clsdd, @mmend, @chkdd, @payee, @bankinfo, @swift) ";
		private const string SP_ADD1 = "INSERT INTO dbo.ab120 ( gkey, ba015gkey, ba015gkey1, ac002gkey1, ac002gkey2, ac002gkey3, ac002gkey4, ab041gkey1, accountno1, ab041gkey2, accountno2, clsdd, mmend, chkdd, payee, bankinfo, swift) VALUES ( @gkey, @ba015gkey, @ba015gkey1, @ac002gkey1, @ac002gkey2, @ac002gkey3, @ac002gkey4, @ab041gkey1, @accountno1, @ab041gkey2, @accountno2, @clsdd, @mmend, @chkdd, @payee, @bankinfo, @swift) SELECT @gkey = @@IDENTITY";
		private const string SP_UPDATE = "UPDATE dbo.ab120 SET ba015gkey = @ba015gkey, ba015gkey1 = @ba015gkey1, ac002gkey1 = @ac002gkey1, ac002gkey2 = @ac002gkey2, ac002gkey3 = @ac002gkey3, ac002gkey4 = @ac002gkey4, ab041gkey1 = @ab041gkey1, accountno1 = @accountno1, ab041gkey2 = @ab041gkey2, accountno2 = @accountno2, clsdd = @clsdd, mmend = @mmend, chkdd = @chkdd, payee = @payee, bankinfo = @bankinfo, swift = @swift WHERE gkey = @gkey";
		private const string SP_DELETE = "DELETE FROM dbo.ab120 WHERE gkey=@ref_id";
		private const string SP_DELETE_FILTER = "DELETE FROM dbo.ab120 {0}";
		private const string SP_GET_LOOKUP = "SELECT gkey, ba015gkey FROM dbo.ab120 WITH (NOLOCK)";
		#endregion
		
		#region ab120 - Constructor
		private ab120()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
        
		#region ab120 - List ab120
		/// <summary>
		/// The purpose of this method is to get all ab120 data.
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
        
		#region ab120 - List ab120 by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all ab120 data based on the Filter Expression criteria.
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
        
		#region ab120 - List ab120 by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all ab120 data based on filterExpression, sortExpression, pageIndex and pageSize parameters
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
        
        #region ab120 - Get Details for an ab120 record
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
        
        #region ab120 - Get Lookup Data
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
		
        
		#region ab120 - Add Record
        /// <summary>
        /// Creates a new ab120 row.
        /// </summary>
        public static string Add( string gkey, string ba015gkey, string ba015gkey1, string ac002gkey1, string ac002gkey2, string ac002gkey3, string ac002gkey4, string ab041gkey1, string accountno1, string ab041gkey2, string accountno2, decimal clsdd, decimal mmend, decimal chkdd, string payee, string bankinfo, string swift)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_ADD, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", gkey);
						cmd.Parameters.AddWithValue("@ba015gkey", ba015gkey);
						cmd.Parameters.AddWithValue("@ba015gkey1", ba015gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey1", ac002gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey2", ac002gkey2);
						cmd.Parameters.AddWithValue("@ac002gkey3", ac002gkey3);
						cmd.Parameters.AddWithValue("@ac002gkey4", ac002gkey4);
						cmd.Parameters.AddWithValue("@ab041gkey1", ab041gkey1);
						cmd.Parameters.AddWithValue("@accountno1", accountno1);
						cmd.Parameters.AddWithValue("@ab041gkey2", ab041gkey2);
						cmd.Parameters.AddWithValue("@accountno2", accountno2);
						cmd.Parameters.AddWithValue("@clsdd", clsdd);
						cmd.Parameters.AddWithValue("@mmend", mmend);
						cmd.Parameters.AddWithValue("@chkdd", chkdd);
						cmd.Parameters.AddWithValue("@payee", payee);
						cmd.Parameters.AddWithValue("@bankinfo", bankinfo);
						cmd.Parameters.AddWithValue("@swift", swift);
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
        
		#region ab120 - Update Record
        /// <summary>
        /// Updates a ab120
        /// </summary>
        public static bool Update( string gkey, string ba015gkey, string ba015gkey1, string ac002gkey1, string ac002gkey2, string ac002gkey3, string ac002gkey4, string ab041gkey1, string accountno1, string ab041gkey2, string accountno2, decimal clsdd, decimal mmend, decimal chkdd, string payee, string bankinfo, string swift)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_UPDATE, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", gkey);
						cmd.Parameters.AddWithValue("@ba015gkey", ba015gkey);
						cmd.Parameters.AddWithValue("@ba015gkey1", ba015gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey1", ac002gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey2", ac002gkey2);
						cmd.Parameters.AddWithValue("@ac002gkey3", ac002gkey3);
						cmd.Parameters.AddWithValue("@ac002gkey4", ac002gkey4);
						cmd.Parameters.AddWithValue("@ab041gkey1", ab041gkey1);
						cmd.Parameters.AddWithValue("@accountno1", accountno1);
						cmd.Parameters.AddWithValue("@ab041gkey2", ab041gkey2);
						cmd.Parameters.AddWithValue("@accountno2", accountno2);
						cmd.Parameters.AddWithValue("@clsdd", clsdd);
						cmd.Parameters.AddWithValue("@mmend", mmend);
						cmd.Parameters.AddWithValue("@chkdd", chkdd);
						cmd.Parameters.AddWithValue("@payee", payee);
						cmd.Parameters.AddWithValue("@bankinfo", bankinfo);
						cmd.Parameters.AddWithValue("@swift", swift);
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
        
        #region ab120 - Delete Record
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
        
        #region ab120 - Delete Records
        /// <summary>
        /// The purpose of this method is to delete all ab120 data based on the Filter Expression criteria.
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
        
        #region ab120 - Get List of ab120Data objects
        /// <summary>
        /// Returns a collection with all the ab120Data
        /// </summary>
		/// <returns>List of ab120Data object</returns>
        public static List<ab120Data> GetList()
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

						List<ab120Data> objList = new List<ab120Data>();
						while (reader.Read())
						{
							//objList.Add(new ab120Data(
							//	 (string) reader["gkey"], (string) reader["ba015gkey"], (string) reader["ba015gkey1"], (string) reader["ac002gkey1"], (string) reader["ac002gkey2"], (string) reader["ac002gkey3"], (string) reader["ac002gkey4"], (string) reader["ab041gkey1"], (string) reader["accountno1"], (string) reader["ab041gkey2"], (string) reader["accountno2"], (decimal) reader["clsdd"], (decimal) reader["mmend"], (decimal) reader["chkdd"], (string) reader["payee"], (string) reader["bankinfo"], (string) reader["swift"]));
							objList.Add(new ab120Data(reader)); // Use this to avoid null issues
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
        
		
		#region ab120 - List ab120 by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all ab120 data based on the Filter Expression criteria.
		/// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
		/// For example, filterExpression - Where condition to be passed in SQL statement.
		/// </param>
		/// <returns>List of ab120Data object</returns>
		public static List<ab120Data> GetList(string filterExpression)
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

						List<ab120Data> objList = new List<ab120Data>();
						while (reader.Read())
						{
							//objList.Add(new ab120Data(
							//	 (string) reader["gkey"], (string) reader["ba015gkey"], (string) reader["ba015gkey1"], (string) reader["ac002gkey1"], (string) reader["ac002gkey2"], (string) reader["ac002gkey3"], (string) reader["ac002gkey4"], (string) reader["ab041gkey1"], (string) reader["accountno1"], (string) reader["ab041gkey2"], (string) reader["accountno2"], (decimal) reader["clsdd"], (decimal) reader["mmend"], (decimal) reader["chkdd"], (string) reader["payee"], (string) reader["bankinfo"], (string) reader["swift"]));
							objList.Add(new ab120Data(reader)); // Use this to avoid null issues
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
		
        #region ab120 - List ab120 by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all ab120 data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>List of ab120Data object</returns>
        public static List<ab120Data> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
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

						List<ab120Data> objList = new List<ab120Data>();
						while (reader.Read())
						{
							//objList.Add(new ab120Data(
							//         (string) reader["gkey"], (string) reader["ba015gkey"], (string) reader["ba015gkey1"], (string) reader["ac002gkey1"], (string) reader["ac002gkey2"], (string) reader["ac002gkey3"], (string) reader["ac002gkey4"], (string) reader["ab041gkey1"], (string) reader["accountno1"], (string) reader["ab041gkey2"], (string) reader["accountno2"], (decimal) reader["clsdd"], (decimal) reader["mmend"], (decimal) reader["chkdd"], (string) reader["payee"], (string) reader["bankinfo"], (string) reader["swift"]));
							objList.Add(new ab120Data(reader)); // Use this to avoid null issues
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
        
        
		#region ab120 - Get Details by ID
        /// <summary>
        /// Returns an existing ab120Data object with the specified ID 
        /// </summary>
        public static ab120Data GetDetailsByID(string sRefID)
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
						// return new ab120Data(
						//	 (string) reader["gkey"], (string) reader["ba015gkey"], (string) reader["ba015gkey1"], (string) reader["ac002gkey1"], (string) reader["ac002gkey2"], (string) reader["ac002gkey3"], (string) reader["ac002gkey4"], (string) reader["ab041gkey1"], (string) reader["accountno1"], (string) reader["ab041gkey2"], (string) reader["accountno2"], (decimal) reader["clsdd"], (decimal) reader["mmend"], (decimal) reader["chkdd"], (string) reader["payee"], (string) reader["bankinfo"], (string) reader["swift"]);
						return new ab120Data(reader); // Use this to avoid null issues
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
        
		#region ab120 - Add Record
        /// <summary>
        /// Creates a new ab120
        /// </summary>
        public static string Add(ab120Data objab120)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_ADD, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objab120.gkey);
						cmd.Parameters.AddWithValue("@ba015gkey", objab120.ba015gkey);
						cmd.Parameters.AddWithValue("@ba015gkey1", objab120.ba015gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey1", objab120.ac002gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey2", objab120.ac002gkey2);
						cmd.Parameters.AddWithValue("@ac002gkey3", objab120.ac002gkey3);
						cmd.Parameters.AddWithValue("@ac002gkey4", objab120.ac002gkey4);
						cmd.Parameters.AddWithValue("@ab041gkey1", objab120.ab041gkey1);
						cmd.Parameters.AddWithValue("@accountno1", objab120.accountno1);
						cmd.Parameters.AddWithValue("@ab041gkey2", objab120.ab041gkey2);
						cmd.Parameters.AddWithValue("@accountno2", objab120.accountno2);
						cmd.Parameters.AddWithValue("@clsdd", objab120.clsdd);
						cmd.Parameters.AddWithValue("@mmend", objab120.mmend);
						cmd.Parameters.AddWithValue("@chkdd", objab120.chkdd);
						cmd.Parameters.AddWithValue("@payee", objab120.payee);
						cmd.Parameters.AddWithValue("@bankinfo", objab120.bankinfo);
						cmd.Parameters.AddWithValue("@swift", objab120.swift);
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
        
		#region ab120 - Update Record
		/// <summary>
		/// Updates a ab120
		/// </summary>
		public static bool Update(ab120Data objab120)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_UPDATE, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objab120.gkey);
						cmd.Parameters.AddWithValue("@ba015gkey", objab120.ba015gkey);
						cmd.Parameters.AddWithValue("@ba015gkey1", objab120.ba015gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey1", objab120.ac002gkey1);
						cmd.Parameters.AddWithValue("@ac002gkey2", objab120.ac002gkey2);
						cmd.Parameters.AddWithValue("@ac002gkey3", objab120.ac002gkey3);
						cmd.Parameters.AddWithValue("@ac002gkey4", objab120.ac002gkey4);
						cmd.Parameters.AddWithValue("@ab041gkey1", objab120.ab041gkey1);
						cmd.Parameters.AddWithValue("@accountno1", objab120.accountno1);
						cmd.Parameters.AddWithValue("@ab041gkey2", objab120.ab041gkey2);
						cmd.Parameters.AddWithValue("@accountno2", objab120.accountno2);
						cmd.Parameters.AddWithValue("@clsdd", objab120.clsdd);
						cmd.Parameters.AddWithValue("@mmend", objab120.mmend);
						cmd.Parameters.AddWithValue("@chkdd", objab120.chkdd);
						cmd.Parameters.AddWithValue("@payee", objab120.payee);
						cmd.Parameters.AddWithValue("@bankinfo", objab120.bankinfo);
						cmd.Parameters.AddWithValue("@swift", objab120.swift);
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
  