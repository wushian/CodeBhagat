/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: This is class contains methods to perform Data Access Layer operations 
 * Dependency	: This class refers sa106Data Entity class
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
	/// Summary description for sa106.
	/// </summary>
    public class sa106
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
		private const string SP_GET_ALL = "SELECT  gkey, orddate, mr200gkey, issuedate, pono, salesno, returnno, returndate, deliveryno, rettype, xtype, ba205gkey, pickupdate, canceldate, ba100gkey, ba102gkey, ba103gkey, ba119gkey, ba118gkey, ba121gkey, ba104gkey, ba209gkey, returnamt, canadaamt, freightamt, proceamt, insuredamt, pickupamt, discountamt, vouchersamt, reservatamt, activityamt, totalfreight, totaltreatment, totalinsurance, totalamt, pairs, remark, ba005gkey, modifydate, revisedate, approve, aes101gkey, ses101gkey, es101gkey, replication_create, replication_update, rownum, addproceamt, lossproceamt, virementamt, ba040gkey, ba040gkey1, receivabledate, receivableamt, virementdate, salesamt, collchk, payfreight, strchk, noamount, totalamount, ba101gkey, remittancedate, remittancetime FROM dbo.sa106 WITH (NOLOCK)";
		private const string SP_GET_FILTER = "SELECT  gkey, orddate, mr200gkey, issuedate, pono, salesno, returnno, returndate, deliveryno, rettype, xtype, ba205gkey, pickupdate, canceldate, ba100gkey, ba102gkey, ba103gkey, ba119gkey, ba118gkey, ba121gkey, ba104gkey, ba209gkey, returnamt, canadaamt, freightamt, proceamt, insuredamt, pickupamt, discountamt, vouchersamt, reservatamt, activityamt, totalfreight, totaltreatment, totalinsurance, totalamt, pairs, remark, ba005gkey, modifydate, revisedate, approve, aes101gkey, ses101gkey, es101gkey, replication_create, replication_update, rownum, addproceamt, lossproceamt, virementamt, ba040gkey, ba040gkey1, receivabledate, receivableamt, virementdate, salesamt, collchk, payfreight, strchk, noamount, totalamount, ba101gkey, remittancedate, remittancetime FROM dbo.sa106 WITH (NOLOCK) {0}";
		private const string SP_GET_BYPAGE = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS rownumber, * FROM dbo.sa106 {1}) AS tblOutput WHERE rownumber BETWEEN {2} AND {3} SELECT COUNT(*) FROM dbo.sa106 WITH (NOLOCK) {4}";
		private const string SP_GET_BYID = "SELECT  gkey, orddate, mr200gkey, issuedate, pono, salesno, returnno, returndate, deliveryno, rettype, xtype, ba205gkey, pickupdate, canceldate, ba100gkey, ba102gkey, ba103gkey, ba119gkey, ba118gkey, ba121gkey, ba104gkey, ba209gkey, returnamt, canadaamt, freightamt, proceamt, insuredamt, pickupamt, discountamt, vouchersamt, reservatamt, activityamt, totalfreight, totaltreatment, totalinsurance, totalamt, pairs, remark, ba005gkey, modifydate, revisedate, approve, aes101gkey, ses101gkey, es101gkey, replication_create, replication_update, rownum, addproceamt, lossproceamt, virementamt, ba040gkey, ba040gkey1, receivabledate, receivableamt, virementdate, salesamt, collchk, payfreight, strchk, noamount, totalamount, ba101gkey, remittancedate, remittancetime FROM dbo.sa106 WITH (NOLOCK) WHERE gkey = @ref_id";
		private const string SP_ADD = "INSERT INTO dbo.sa106 ( gkey, orddate, mr200gkey, issuedate, pono, salesno, returnno, returndate, deliveryno, rettype, xtype, ba205gkey, pickupdate, canceldate, ba100gkey, ba102gkey, ba103gkey, ba119gkey, ba118gkey, ba121gkey, ba104gkey, ba209gkey, returnamt, canadaamt, freightamt, proceamt, insuredamt, pickupamt, discountamt, vouchersamt, reservatamt, activityamt, totalfreight, totaltreatment, totalinsurance, totalamt, pairs, remark, ba005gkey, modifydate, revisedate, approve, aes101gkey, ses101gkey, es101gkey, replication_create, replication_update, rownum, addproceamt, lossproceamt, virementamt, ba040gkey, ba040gkey1, receivabledate, receivableamt, virementdate, salesamt, collchk, payfreight, strchk, noamount, totalamount, ba101gkey, remittancedate, remittancetime) VALUES ( @gkey, @orddate, @mr200gkey, @issuedate, @pono, @salesno, @returnno, @returndate, @deliveryno, @rettype, @xtype, @ba205gkey, @pickupdate, @canceldate, @ba100gkey, @ba102gkey, @ba103gkey, @ba119gkey, @ba118gkey, @ba121gkey, @ba104gkey, @ba209gkey, @returnamt, @canadaamt, @freightamt, @proceamt, @insuredamt, @pickupamt, @discountamt, @vouchersamt, @reservatamt, @activityamt, @totalfreight, @totaltreatment, @totalinsurance, @totalamt, @pairs, @remark, @ba005gkey, @modifydate, @revisedate, @approve, @aes101gkey, @ses101gkey, @es101gkey, @replication_create, @replication_update, @rownum, @addproceamt, @lossproceamt, @virementamt, @ba040gkey, @ba040gkey1, @receivabledate, @receivableamt, @virementdate, @salesamt, @collchk, @payfreight, @strchk, @noamount, @totalamount, @ba101gkey, @remittancedate, @remittancetime) ";
		private const string SP_ADD1 = "INSERT INTO dbo.sa106 ( gkey, orddate, mr200gkey, issuedate, pono, salesno, returnno, returndate, deliveryno, rettype, xtype, ba205gkey, pickupdate, canceldate, ba100gkey, ba102gkey, ba103gkey, ba119gkey, ba118gkey, ba121gkey, ba104gkey, ba209gkey, returnamt, canadaamt, freightamt, proceamt, insuredamt, pickupamt, discountamt, vouchersamt, reservatamt, activityamt, totalfreight, totaltreatment, totalinsurance, totalamt, pairs, remark, ba005gkey, modifydate, revisedate, approve, aes101gkey, ses101gkey, es101gkey, replication_create, replication_update, rownum, addproceamt, lossproceamt, virementamt, ba040gkey, ba040gkey1, receivabledate, receivableamt, virementdate, salesamt, collchk, payfreight, strchk, noamount, totalamount, ba101gkey, remittancedate, remittancetime) VALUES ( @gkey, @orddate, @mr200gkey, @issuedate, @pono, @salesno, @returnno, @returndate, @deliveryno, @rettype, @xtype, @ba205gkey, @pickupdate, @canceldate, @ba100gkey, @ba102gkey, @ba103gkey, @ba119gkey, @ba118gkey, @ba121gkey, @ba104gkey, @ba209gkey, @returnamt, @canadaamt, @freightamt, @proceamt, @insuredamt, @pickupamt, @discountamt, @vouchersamt, @reservatamt, @activityamt, @totalfreight, @totaltreatment, @totalinsurance, @totalamt, @pairs, @remark, @ba005gkey, @modifydate, @revisedate, @approve, @aes101gkey, @ses101gkey, @es101gkey, @replication_create, @replication_update, @rownum, @addproceamt, @lossproceamt, @virementamt, @ba040gkey, @ba040gkey1, @receivabledate, @receivableamt, @virementdate, @salesamt, @collchk, @payfreight, @strchk, @noamount, @totalamount, @ba101gkey, @remittancedate, @remittancetime) SELECT @gkey = @@IDENTITY";
		private const string SP_UPDATE = "UPDATE dbo.sa106 SET orddate = @orddate, mr200gkey = @mr200gkey, issuedate = @issuedate, pono = @pono, salesno = @salesno, returnno = @returnno, returndate = @returndate, deliveryno = @deliveryno, rettype = @rettype, xtype = @xtype, ba205gkey = @ba205gkey, pickupdate = @pickupdate, canceldate = @canceldate, ba100gkey = @ba100gkey, ba102gkey = @ba102gkey, ba103gkey = @ba103gkey, ba119gkey = @ba119gkey, ba118gkey = @ba118gkey, ba121gkey = @ba121gkey, ba104gkey = @ba104gkey, ba209gkey = @ba209gkey, returnamt = @returnamt, canadaamt = @canadaamt, freightamt = @freightamt, proceamt = @proceamt, insuredamt = @insuredamt, pickupamt = @pickupamt, discountamt = @discountamt, vouchersamt = @vouchersamt, reservatamt = @reservatamt, activityamt = @activityamt, totalfreight = @totalfreight, totaltreatment = @totaltreatment, totalinsurance = @totalinsurance, totalamt = @totalamt, pairs = @pairs, remark = @remark, ba005gkey = @ba005gkey, modifydate = @modifydate, revisedate = @revisedate, approve = @approve, aes101gkey = @aes101gkey, ses101gkey = @ses101gkey, es101gkey = @es101gkey, replication_create = @replication_create, replication_update = @replication_update, rownum = @rownum, addproceamt = @addproceamt, lossproceamt = @lossproceamt, virementamt = @virementamt, ba040gkey = @ba040gkey, ba040gkey1 = @ba040gkey1, receivabledate = @receivabledate, receivableamt = @receivableamt, virementdate = @virementdate, salesamt = @salesamt, collchk = @collchk, payfreight = @payfreight, strchk = @strchk, noamount = @noamount, totalamount = @totalamount, ba101gkey = @ba101gkey, remittancedate = @remittancedate, remittancetime = @remittancetime WHERE gkey = @gkey";
		private const string SP_DELETE = "DELETE FROM dbo.sa106 WHERE gkey=@ref_id";
		private const string SP_DELETE_FILTER = "DELETE FROM dbo.sa106 {0}";
		private const string SP_GET_LOOKUP = "SELECT gkey, mr200gkey FROM dbo.sa106 WITH (NOLOCK)";
		#endregion
		
		#region sa106 - Constructor
		private sa106()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
        
		#region sa106 - List sa106
		/// <summary>
		/// The purpose of this method is to get all sa106 data.
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
        
		#region sa106 - List sa106 by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all sa106 data based on the Filter Expression criteria.
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
        
		#region sa106 - List sa106 by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all sa106 data based on filterExpression, sortExpression, pageIndex and pageSize parameters
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
        
        #region sa106 - Get Details for an sa106 record
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
        
        #region sa106 - Get Lookup Data
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
		
        
		#region sa106 - Add Record
        /// <summary>
        /// Creates a new sa106 row.
        /// </summary>
        public static string Add( string gkey, DateTime orddate, string mr200gkey, DateTime issuedate, string pono, string salesno, string returnno, DateTime returndate, string deliveryno, string rettype, string xtype, string ba205gkey, DateTime pickupdate, DateTime canceldate, string ba100gkey, string ba102gkey, string ba103gkey, string ba119gkey, string ba118gkey, string ba121gkey, string ba104gkey, string ba209gkey, decimal returnamt, decimal canadaamt, decimal freightamt, decimal proceamt, decimal insuredamt, decimal pickupamt, decimal discountamt, decimal vouchersamt, decimal reservatamt, decimal activityamt, decimal totalfreight, decimal totaltreatment, decimal totalinsurance, decimal totalamt, decimal pairs, string remark, string ba005gkey, DateTime modifydate, DateTime revisedate, string approve, string aes101gkey, string ses101gkey, string es101gkey, DateTime replication_create, DateTime replication_update, decimal rownum, decimal addproceamt, decimal lossproceamt, decimal virementamt, string ba040gkey, string ba040gkey1, DateTime receivabledate, decimal receivableamt, DateTime virementdate, decimal salesamt, string collchk, decimal payfreight, string strchk, decimal noamount, decimal totalamount, string ba101gkey, DateTime remittancedate, DateTime remittancetime)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_ADD, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", gkey);
						cmd.Parameters.AddWithValue("@orddate", orddate);
						cmd.Parameters.AddWithValue("@mr200gkey", mr200gkey);
						cmd.Parameters.AddWithValue("@issuedate", issuedate);
						cmd.Parameters.AddWithValue("@pono", pono);
						cmd.Parameters.AddWithValue("@salesno", salesno);
						cmd.Parameters.AddWithValue("@returnno", returnno);
						cmd.Parameters.AddWithValue("@returndate", returndate);
						cmd.Parameters.AddWithValue("@deliveryno", deliveryno);
						cmd.Parameters.AddWithValue("@rettype", rettype);
						cmd.Parameters.AddWithValue("@xtype", xtype);
						cmd.Parameters.AddWithValue("@ba205gkey", ba205gkey);
						cmd.Parameters.AddWithValue("@pickupdate", pickupdate);
						cmd.Parameters.AddWithValue("@canceldate", canceldate);
						cmd.Parameters.AddWithValue("@ba100gkey", ba100gkey);
						cmd.Parameters.AddWithValue("@ba102gkey", ba102gkey);
						cmd.Parameters.AddWithValue("@ba103gkey", ba103gkey);
						cmd.Parameters.AddWithValue("@ba119gkey", ba119gkey);
						cmd.Parameters.AddWithValue("@ba118gkey", ba118gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", ba121gkey);
						cmd.Parameters.AddWithValue("@ba104gkey", ba104gkey);
						cmd.Parameters.AddWithValue("@ba209gkey", ba209gkey);
						cmd.Parameters.AddWithValue("@returnamt", returnamt);
						cmd.Parameters.AddWithValue("@canadaamt", canadaamt);
						cmd.Parameters.AddWithValue("@freightamt", freightamt);
						cmd.Parameters.AddWithValue("@proceamt", proceamt);
						cmd.Parameters.AddWithValue("@insuredamt", insuredamt);
						cmd.Parameters.AddWithValue("@pickupamt", pickupamt);
						cmd.Parameters.AddWithValue("@discountamt", discountamt);
						cmd.Parameters.AddWithValue("@vouchersamt", vouchersamt);
						cmd.Parameters.AddWithValue("@reservatamt", reservatamt);
						cmd.Parameters.AddWithValue("@activityamt", activityamt);
						cmd.Parameters.AddWithValue("@totalfreight", totalfreight);
						cmd.Parameters.AddWithValue("@totaltreatment", totaltreatment);
						cmd.Parameters.AddWithValue("@totalinsurance", totalinsurance);
						cmd.Parameters.AddWithValue("@totalamt", totalamt);
						cmd.Parameters.AddWithValue("@pairs", pairs);
						cmd.Parameters.AddWithValue("@remark", remark);
						cmd.Parameters.AddWithValue("@ba005gkey", ba005gkey);
						cmd.Parameters.AddWithValue("@modifydate", modifydate);
						cmd.Parameters.AddWithValue("@revisedate", revisedate);
						cmd.Parameters.AddWithValue("@approve", approve);
						cmd.Parameters.AddWithValue("@aes101gkey", aes101gkey);
						cmd.Parameters.AddWithValue("@ses101gkey", ses101gkey);
						cmd.Parameters.AddWithValue("@es101gkey", es101gkey);
						cmd.Parameters.AddWithValue("@replication_create", replication_create);
						cmd.Parameters.AddWithValue("@replication_update", replication_update);
						cmd.Parameters.AddWithValue("@rownum", rownum);
						cmd.Parameters.AddWithValue("@addproceamt", addproceamt);
						cmd.Parameters.AddWithValue("@lossproceamt", lossproceamt);
						cmd.Parameters.AddWithValue("@virementamt", virementamt);
						cmd.Parameters.AddWithValue("@ba040gkey", ba040gkey);
						cmd.Parameters.AddWithValue("@ba040gkey1", ba040gkey1);
						cmd.Parameters.AddWithValue("@receivabledate", receivabledate);
						cmd.Parameters.AddWithValue("@receivableamt", receivableamt);
						cmd.Parameters.AddWithValue("@virementdate", virementdate);
						cmd.Parameters.AddWithValue("@salesamt", salesamt);
						cmd.Parameters.AddWithValue("@collchk", collchk);
						cmd.Parameters.AddWithValue("@payfreight", payfreight);
						cmd.Parameters.AddWithValue("@strchk", strchk);
						cmd.Parameters.AddWithValue("@noamount", noamount);
						cmd.Parameters.AddWithValue("@totalamount", totalamount);
						cmd.Parameters.AddWithValue("@ba101gkey", ba101gkey);
						cmd.Parameters.AddWithValue("@remittancedate", remittancedate);
						cmd.Parameters.AddWithValue("@remittancetime", remittancetime);
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
        
		#region sa106 - Update Record
        /// <summary>
        /// Updates a sa106
        /// </summary>
        public static bool Update( string gkey, DateTime orddate, string mr200gkey, DateTime issuedate, string pono, string salesno, string returnno, DateTime returndate, string deliveryno, string rettype, string xtype, string ba205gkey, DateTime pickupdate, DateTime canceldate, string ba100gkey, string ba102gkey, string ba103gkey, string ba119gkey, string ba118gkey, string ba121gkey, string ba104gkey, string ba209gkey, decimal returnamt, decimal canadaamt, decimal freightamt, decimal proceamt, decimal insuredamt, decimal pickupamt, decimal discountamt, decimal vouchersamt, decimal reservatamt, decimal activityamt, decimal totalfreight, decimal totaltreatment, decimal totalinsurance, decimal totalamt, decimal pairs, string remark, string ba005gkey, DateTime modifydate, DateTime revisedate, string approve, string aes101gkey, string ses101gkey, string es101gkey, DateTime replication_create, DateTime replication_update, decimal rownum, decimal addproceamt, decimal lossproceamt, decimal virementamt, string ba040gkey, string ba040gkey1, DateTime receivabledate, decimal receivableamt, DateTime virementdate, decimal salesamt, string collchk, decimal payfreight, string strchk, decimal noamount, decimal totalamount, string ba101gkey, DateTime remittancedate, DateTime remittancetime)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_UPDATE, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", gkey);
						cmd.Parameters.AddWithValue("@orddate", orddate);
						cmd.Parameters.AddWithValue("@mr200gkey", mr200gkey);
						cmd.Parameters.AddWithValue("@issuedate", issuedate);
						cmd.Parameters.AddWithValue("@pono", pono);
						cmd.Parameters.AddWithValue("@salesno", salesno);
						cmd.Parameters.AddWithValue("@returnno", returnno);
						cmd.Parameters.AddWithValue("@returndate", returndate);
						cmd.Parameters.AddWithValue("@deliveryno", deliveryno);
						cmd.Parameters.AddWithValue("@rettype", rettype);
						cmd.Parameters.AddWithValue("@xtype", xtype);
						cmd.Parameters.AddWithValue("@ba205gkey", ba205gkey);
						cmd.Parameters.AddWithValue("@pickupdate", pickupdate);
						cmd.Parameters.AddWithValue("@canceldate", canceldate);
						cmd.Parameters.AddWithValue("@ba100gkey", ba100gkey);
						cmd.Parameters.AddWithValue("@ba102gkey", ba102gkey);
						cmd.Parameters.AddWithValue("@ba103gkey", ba103gkey);
						cmd.Parameters.AddWithValue("@ba119gkey", ba119gkey);
						cmd.Parameters.AddWithValue("@ba118gkey", ba118gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", ba121gkey);
						cmd.Parameters.AddWithValue("@ba104gkey", ba104gkey);
						cmd.Parameters.AddWithValue("@ba209gkey", ba209gkey);
						cmd.Parameters.AddWithValue("@returnamt", returnamt);
						cmd.Parameters.AddWithValue("@canadaamt", canadaamt);
						cmd.Parameters.AddWithValue("@freightamt", freightamt);
						cmd.Parameters.AddWithValue("@proceamt", proceamt);
						cmd.Parameters.AddWithValue("@insuredamt", insuredamt);
						cmd.Parameters.AddWithValue("@pickupamt", pickupamt);
						cmd.Parameters.AddWithValue("@discountamt", discountamt);
						cmd.Parameters.AddWithValue("@vouchersamt", vouchersamt);
						cmd.Parameters.AddWithValue("@reservatamt", reservatamt);
						cmd.Parameters.AddWithValue("@activityamt", activityamt);
						cmd.Parameters.AddWithValue("@totalfreight", totalfreight);
						cmd.Parameters.AddWithValue("@totaltreatment", totaltreatment);
						cmd.Parameters.AddWithValue("@totalinsurance", totalinsurance);
						cmd.Parameters.AddWithValue("@totalamt", totalamt);
						cmd.Parameters.AddWithValue("@pairs", pairs);
						cmd.Parameters.AddWithValue("@remark", remark);
						cmd.Parameters.AddWithValue("@ba005gkey", ba005gkey);
						cmd.Parameters.AddWithValue("@modifydate", modifydate);
						cmd.Parameters.AddWithValue("@revisedate", revisedate);
						cmd.Parameters.AddWithValue("@approve", approve);
						cmd.Parameters.AddWithValue("@aes101gkey", aes101gkey);
						cmd.Parameters.AddWithValue("@ses101gkey", ses101gkey);
						cmd.Parameters.AddWithValue("@es101gkey", es101gkey);
						cmd.Parameters.AddWithValue("@replication_create", replication_create);
						cmd.Parameters.AddWithValue("@replication_update", replication_update);
						cmd.Parameters.AddWithValue("@rownum", rownum);
						cmd.Parameters.AddWithValue("@addproceamt", addproceamt);
						cmd.Parameters.AddWithValue("@lossproceamt", lossproceamt);
						cmd.Parameters.AddWithValue("@virementamt", virementamt);
						cmd.Parameters.AddWithValue("@ba040gkey", ba040gkey);
						cmd.Parameters.AddWithValue("@ba040gkey1", ba040gkey1);
						cmd.Parameters.AddWithValue("@receivabledate", receivabledate);
						cmd.Parameters.AddWithValue("@receivableamt", receivableamt);
						cmd.Parameters.AddWithValue("@virementdate", virementdate);
						cmd.Parameters.AddWithValue("@salesamt", salesamt);
						cmd.Parameters.AddWithValue("@collchk", collchk);
						cmd.Parameters.AddWithValue("@payfreight", payfreight);
						cmd.Parameters.AddWithValue("@strchk", strchk);
						cmd.Parameters.AddWithValue("@noamount", noamount);
						cmd.Parameters.AddWithValue("@totalamount", totalamount);
						cmd.Parameters.AddWithValue("@ba101gkey", ba101gkey);
						cmd.Parameters.AddWithValue("@remittancedate", remittancedate);
						cmd.Parameters.AddWithValue("@remittancetime", remittancetime);
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
        
        #region sa106 - Delete Record
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
        
        #region sa106 - Delete Records
        /// <summary>
        /// The purpose of this method is to delete all sa106 data based on the Filter Expression criteria.
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
        
        #region sa106 - Get List of sa106Data objects
        /// <summary>
        /// Returns a collection with all the sa106Data
        /// </summary>
		/// <returns>List of sa106Data object</returns>
        public static List<sa106Data> GetList()
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

						List<sa106Data> objList = new List<sa106Data>();
						while (reader.Read())
						{
							//objList.Add(new sa106Data(
							//	 (string) reader["gkey"], (DateTime) reader["orddate"], (string) reader["mr200gkey"], (DateTime) reader["issuedate"], (string) reader["pono"], (string) reader["salesno"], (string) reader["returnno"], (DateTime) reader["returndate"], (string) reader["deliveryno"], (string) reader["rettype"], (string) reader["xtype"], (string) reader["ba205gkey"], (DateTime) reader["pickupdate"], (DateTime) reader["canceldate"], (string) reader["ba100gkey"], (string) reader["ba102gkey"], (string) reader["ba103gkey"], (string) reader["ba119gkey"], (string) reader["ba118gkey"], (string) reader["ba121gkey"], (string) reader["ba104gkey"], (string) reader["ba209gkey"], (decimal) reader["returnamt"], (decimal) reader["canadaamt"], (decimal) reader["freightamt"], (decimal) reader["proceamt"], (decimal) reader["insuredamt"], (decimal) reader["pickupamt"], (decimal) reader["discountamt"], (decimal) reader["vouchersamt"], (decimal) reader["reservatamt"], (decimal) reader["activityamt"], (decimal) reader["totalfreight"], (decimal) reader["totaltreatment"], (decimal) reader["totalinsurance"], (decimal) reader["totalamt"], (decimal) reader["pairs"], (string) reader["remark"], (string) reader["ba005gkey"], (DateTime) reader["modifydate"], (DateTime) reader["revisedate"], (string) reader["approve"], (string) reader["aes101gkey"], (string) reader["ses101gkey"], (string) reader["es101gkey"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["rownum"], (decimal) reader["addproceamt"], (decimal) reader["lossproceamt"], (decimal) reader["virementamt"], (string) reader["ba040gkey"], (string) reader["ba040gkey1"], (DateTime) reader["receivabledate"], (decimal) reader["receivableamt"], (DateTime) reader["virementdate"], (decimal) reader["salesamt"], (string) reader["collchk"], (decimal) reader["payfreight"], (string) reader["strchk"], (decimal) reader["noamount"], (decimal) reader["totalamount"], (string) reader["ba101gkey"], (DateTime) reader["remittancedate"], (DateTime) reader["remittancetime"]));
							objList.Add(new sa106Data(reader)); // Use this to avoid null issues
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
        
		
		#region sa106 - List sa106 by Filter Expression
		/// <summary>
		/// The purpose of this method is to get all sa106 data based on the Filter Expression criteria.
		/// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
		/// For example, filterExpression - Where condition to be passed in SQL statement.
		/// </param>
		/// <returns>List of sa106Data object</returns>
		public static List<sa106Data> GetList(string filterExpression)
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

						List<sa106Data> objList = new List<sa106Data>();
						while (reader.Read())
						{
							//objList.Add(new sa106Data(
							//	 (string) reader["gkey"], (DateTime) reader["orddate"], (string) reader["mr200gkey"], (DateTime) reader["issuedate"], (string) reader["pono"], (string) reader["salesno"], (string) reader["returnno"], (DateTime) reader["returndate"], (string) reader["deliveryno"], (string) reader["rettype"], (string) reader["xtype"], (string) reader["ba205gkey"], (DateTime) reader["pickupdate"], (DateTime) reader["canceldate"], (string) reader["ba100gkey"], (string) reader["ba102gkey"], (string) reader["ba103gkey"], (string) reader["ba119gkey"], (string) reader["ba118gkey"], (string) reader["ba121gkey"], (string) reader["ba104gkey"], (string) reader["ba209gkey"], (decimal) reader["returnamt"], (decimal) reader["canadaamt"], (decimal) reader["freightamt"], (decimal) reader["proceamt"], (decimal) reader["insuredamt"], (decimal) reader["pickupamt"], (decimal) reader["discountamt"], (decimal) reader["vouchersamt"], (decimal) reader["reservatamt"], (decimal) reader["activityamt"], (decimal) reader["totalfreight"], (decimal) reader["totaltreatment"], (decimal) reader["totalinsurance"], (decimal) reader["totalamt"], (decimal) reader["pairs"], (string) reader["remark"], (string) reader["ba005gkey"], (DateTime) reader["modifydate"], (DateTime) reader["revisedate"], (string) reader["approve"], (string) reader["aes101gkey"], (string) reader["ses101gkey"], (string) reader["es101gkey"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["rownum"], (decimal) reader["addproceamt"], (decimal) reader["lossproceamt"], (decimal) reader["virementamt"], (string) reader["ba040gkey"], (string) reader["ba040gkey1"], (DateTime) reader["receivabledate"], (decimal) reader["receivableamt"], (DateTime) reader["virementdate"], (decimal) reader["salesamt"], (string) reader["collchk"], (decimal) reader["payfreight"], (string) reader["strchk"], (decimal) reader["noamount"], (decimal) reader["totalamount"], (string) reader["ba101gkey"], (DateTime) reader["remittancedate"], (DateTime) reader["remittancetime"]));
							objList.Add(new sa106Data(reader)); // Use this to avoid null issues
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
		
        #region sa106 - List sa106 by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all sa106 data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>List of sa106Data object</returns>
        public static List<sa106Data> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
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

						List<sa106Data> objList = new List<sa106Data>();
						while (reader.Read())
						{
							//objList.Add(new sa106Data(
							//         (string) reader["gkey"], (DateTime) reader["orddate"], (string) reader["mr200gkey"], (DateTime) reader["issuedate"], (string) reader["pono"], (string) reader["salesno"], (string) reader["returnno"], (DateTime) reader["returndate"], (string) reader["deliveryno"], (string) reader["rettype"], (string) reader["xtype"], (string) reader["ba205gkey"], (DateTime) reader["pickupdate"], (DateTime) reader["canceldate"], (string) reader["ba100gkey"], (string) reader["ba102gkey"], (string) reader["ba103gkey"], (string) reader["ba119gkey"], (string) reader["ba118gkey"], (string) reader["ba121gkey"], (string) reader["ba104gkey"], (string) reader["ba209gkey"], (decimal) reader["returnamt"], (decimal) reader["canadaamt"], (decimal) reader["freightamt"], (decimal) reader["proceamt"], (decimal) reader["insuredamt"], (decimal) reader["pickupamt"], (decimal) reader["discountamt"], (decimal) reader["vouchersamt"], (decimal) reader["reservatamt"], (decimal) reader["activityamt"], (decimal) reader["totalfreight"], (decimal) reader["totaltreatment"], (decimal) reader["totalinsurance"], (decimal) reader["totalamt"], (decimal) reader["pairs"], (string) reader["remark"], (string) reader["ba005gkey"], (DateTime) reader["modifydate"], (DateTime) reader["revisedate"], (string) reader["approve"], (string) reader["aes101gkey"], (string) reader["ses101gkey"], (string) reader["es101gkey"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["rownum"], (decimal) reader["addproceamt"], (decimal) reader["lossproceamt"], (decimal) reader["virementamt"], (string) reader["ba040gkey"], (string) reader["ba040gkey1"], (DateTime) reader["receivabledate"], (decimal) reader["receivableamt"], (DateTime) reader["virementdate"], (decimal) reader["salesamt"], (string) reader["collchk"], (decimal) reader["payfreight"], (string) reader["strchk"], (decimal) reader["noamount"], (decimal) reader["totalamount"], (string) reader["ba101gkey"], (DateTime) reader["remittancedate"], (DateTime) reader["remittancetime"]));
							objList.Add(new sa106Data(reader)); // Use this to avoid null issues
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
        
        
		#region sa106 - Get Details by ID
        /// <summary>
        /// Returns an existing sa106Data object with the specified ID 
        /// </summary>
        public static sa106Data GetDetailsByID(string sRefID)
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
						// return new sa106Data(
						//	 (string) reader["gkey"], (DateTime) reader["orddate"], (string) reader["mr200gkey"], (DateTime) reader["issuedate"], (string) reader["pono"], (string) reader["salesno"], (string) reader["returnno"], (DateTime) reader["returndate"], (string) reader["deliveryno"], (string) reader["rettype"], (string) reader["xtype"], (string) reader["ba205gkey"], (DateTime) reader["pickupdate"], (DateTime) reader["canceldate"], (string) reader["ba100gkey"], (string) reader["ba102gkey"], (string) reader["ba103gkey"], (string) reader["ba119gkey"], (string) reader["ba118gkey"], (string) reader["ba121gkey"], (string) reader["ba104gkey"], (string) reader["ba209gkey"], (decimal) reader["returnamt"], (decimal) reader["canadaamt"], (decimal) reader["freightamt"], (decimal) reader["proceamt"], (decimal) reader["insuredamt"], (decimal) reader["pickupamt"], (decimal) reader["discountamt"], (decimal) reader["vouchersamt"], (decimal) reader["reservatamt"], (decimal) reader["activityamt"], (decimal) reader["totalfreight"], (decimal) reader["totaltreatment"], (decimal) reader["totalinsurance"], (decimal) reader["totalamt"], (decimal) reader["pairs"], (string) reader["remark"], (string) reader["ba005gkey"], (DateTime) reader["modifydate"], (DateTime) reader["revisedate"], (string) reader["approve"], (string) reader["aes101gkey"], (string) reader["ses101gkey"], (string) reader["es101gkey"], (DateTime) reader["replication_create"], (DateTime) reader["replication_update"], (decimal) reader["rownum"], (decimal) reader["addproceamt"], (decimal) reader["lossproceamt"], (decimal) reader["virementamt"], (string) reader["ba040gkey"], (string) reader["ba040gkey1"], (DateTime) reader["receivabledate"], (decimal) reader["receivableamt"], (DateTime) reader["virementdate"], (decimal) reader["salesamt"], (string) reader["collchk"], (decimal) reader["payfreight"], (string) reader["strchk"], (decimal) reader["noamount"], (decimal) reader["totalamount"], (string) reader["ba101gkey"], (DateTime) reader["remittancedate"], (DateTime) reader["remittancetime"]);
						return new sa106Data(reader); // Use this to avoid null issues
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
        
		#region sa106 - Add Record
        /// <summary>
        /// Creates a new sa106
        /// </summary>
        public static string Add(sa106Data objsa106)
        {
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_ADD, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objsa106.gkey);
						cmd.Parameters.AddWithValue("@orddate", objsa106.orddate);
						cmd.Parameters.AddWithValue("@mr200gkey", objsa106.mr200gkey);
						cmd.Parameters.AddWithValue("@issuedate", objsa106.issuedate);
						cmd.Parameters.AddWithValue("@pono", objsa106.pono);
						cmd.Parameters.AddWithValue("@salesno", objsa106.salesno);
						cmd.Parameters.AddWithValue("@returnno", objsa106.returnno);
						cmd.Parameters.AddWithValue("@returndate", objsa106.returndate);
						cmd.Parameters.AddWithValue("@deliveryno", objsa106.deliveryno);
						cmd.Parameters.AddWithValue("@rettype", objsa106.rettype);
						cmd.Parameters.AddWithValue("@xtype", objsa106.xtype);
						cmd.Parameters.AddWithValue("@ba205gkey", objsa106.ba205gkey);
						cmd.Parameters.AddWithValue("@pickupdate", objsa106.pickupdate);
						cmd.Parameters.AddWithValue("@canceldate", objsa106.canceldate);
						cmd.Parameters.AddWithValue("@ba100gkey", objsa106.ba100gkey);
						cmd.Parameters.AddWithValue("@ba102gkey", objsa106.ba102gkey);
						cmd.Parameters.AddWithValue("@ba103gkey", objsa106.ba103gkey);
						cmd.Parameters.AddWithValue("@ba119gkey", objsa106.ba119gkey);
						cmd.Parameters.AddWithValue("@ba118gkey", objsa106.ba118gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", objsa106.ba121gkey);
						cmd.Parameters.AddWithValue("@ba104gkey", objsa106.ba104gkey);
						cmd.Parameters.AddWithValue("@ba209gkey", objsa106.ba209gkey);
						cmd.Parameters.AddWithValue("@returnamt", objsa106.returnamt);
						cmd.Parameters.AddWithValue("@canadaamt", objsa106.canadaamt);
						cmd.Parameters.AddWithValue("@freightamt", objsa106.freightamt);
						cmd.Parameters.AddWithValue("@proceamt", objsa106.proceamt);
						cmd.Parameters.AddWithValue("@insuredamt", objsa106.insuredamt);
						cmd.Parameters.AddWithValue("@pickupamt", objsa106.pickupamt);
						cmd.Parameters.AddWithValue("@discountamt", objsa106.discountamt);
						cmd.Parameters.AddWithValue("@vouchersamt", objsa106.vouchersamt);
						cmd.Parameters.AddWithValue("@reservatamt", objsa106.reservatamt);
						cmd.Parameters.AddWithValue("@activityamt", objsa106.activityamt);
						cmd.Parameters.AddWithValue("@totalfreight", objsa106.totalfreight);
						cmd.Parameters.AddWithValue("@totaltreatment", objsa106.totaltreatment);
						cmd.Parameters.AddWithValue("@totalinsurance", objsa106.totalinsurance);
						cmd.Parameters.AddWithValue("@totalamt", objsa106.totalamt);
						cmd.Parameters.AddWithValue("@pairs", objsa106.pairs);
						cmd.Parameters.AddWithValue("@remark", objsa106.remark);
						cmd.Parameters.AddWithValue("@ba005gkey", objsa106.ba005gkey);
						cmd.Parameters.AddWithValue("@modifydate", objsa106.modifydate);
						cmd.Parameters.AddWithValue("@revisedate", objsa106.revisedate);
						cmd.Parameters.AddWithValue("@approve", objsa106.approve);
						cmd.Parameters.AddWithValue("@aes101gkey", objsa106.aes101gkey);
						cmd.Parameters.AddWithValue("@ses101gkey", objsa106.ses101gkey);
						cmd.Parameters.AddWithValue("@es101gkey", objsa106.es101gkey);
						cmd.Parameters.AddWithValue("@replication_create", objsa106.replication_create);
						cmd.Parameters.AddWithValue("@replication_update", objsa106.replication_update);
						cmd.Parameters.AddWithValue("@rownum", objsa106.rownum);
						cmd.Parameters.AddWithValue("@addproceamt", objsa106.addproceamt);
						cmd.Parameters.AddWithValue("@lossproceamt", objsa106.lossproceamt);
						cmd.Parameters.AddWithValue("@virementamt", objsa106.virementamt);
						cmd.Parameters.AddWithValue("@ba040gkey", objsa106.ba040gkey);
						cmd.Parameters.AddWithValue("@ba040gkey1", objsa106.ba040gkey1);
						cmd.Parameters.AddWithValue("@receivabledate", objsa106.receivabledate);
						cmd.Parameters.AddWithValue("@receivableamt", objsa106.receivableamt);
						cmd.Parameters.AddWithValue("@virementdate", objsa106.virementdate);
						cmd.Parameters.AddWithValue("@salesamt", objsa106.salesamt);
						cmd.Parameters.AddWithValue("@collchk", objsa106.collchk);
						cmd.Parameters.AddWithValue("@payfreight", objsa106.payfreight);
						cmd.Parameters.AddWithValue("@strchk", objsa106.strchk);
						cmd.Parameters.AddWithValue("@noamount", objsa106.noamount);
						cmd.Parameters.AddWithValue("@totalamount", objsa106.totalamount);
						cmd.Parameters.AddWithValue("@ba101gkey", objsa106.ba101gkey);
						cmd.Parameters.AddWithValue("@remittancedate", objsa106.remittancedate);
						cmd.Parameters.AddWithValue("@remittancetime", objsa106.remittancetime);
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
        
		#region sa106 - Update Record
		/// <summary>
		/// Updates a sa106
		/// </summary>
		public static bool Update(sa106Data objsa106)
		{
			try
			{
				using (SqlConnection cn = new SqlConnection(connectionString))
				{
					using (SqlCommand cmd = new SqlCommand(SP_UPDATE, cn))
					{
						cmd.CommandType = CommandType.Text;
						
						cmd.Parameters.AddWithValue("@gkey", objsa106.gkey);
						cmd.Parameters.AddWithValue("@orddate", objsa106.orddate);
						cmd.Parameters.AddWithValue("@mr200gkey", objsa106.mr200gkey);
						cmd.Parameters.AddWithValue("@issuedate", objsa106.issuedate);
						cmd.Parameters.AddWithValue("@pono", objsa106.pono);
						cmd.Parameters.AddWithValue("@salesno", objsa106.salesno);
						cmd.Parameters.AddWithValue("@returnno", objsa106.returnno);
						cmd.Parameters.AddWithValue("@returndate", objsa106.returndate);
						cmd.Parameters.AddWithValue("@deliveryno", objsa106.deliveryno);
						cmd.Parameters.AddWithValue("@rettype", objsa106.rettype);
						cmd.Parameters.AddWithValue("@xtype", objsa106.xtype);
						cmd.Parameters.AddWithValue("@ba205gkey", objsa106.ba205gkey);
						cmd.Parameters.AddWithValue("@pickupdate", objsa106.pickupdate);
						cmd.Parameters.AddWithValue("@canceldate", objsa106.canceldate);
						cmd.Parameters.AddWithValue("@ba100gkey", objsa106.ba100gkey);
						cmd.Parameters.AddWithValue("@ba102gkey", objsa106.ba102gkey);
						cmd.Parameters.AddWithValue("@ba103gkey", objsa106.ba103gkey);
						cmd.Parameters.AddWithValue("@ba119gkey", objsa106.ba119gkey);
						cmd.Parameters.AddWithValue("@ba118gkey", objsa106.ba118gkey);
						cmd.Parameters.AddWithValue("@ba121gkey", objsa106.ba121gkey);
						cmd.Parameters.AddWithValue("@ba104gkey", objsa106.ba104gkey);
						cmd.Parameters.AddWithValue("@ba209gkey", objsa106.ba209gkey);
						cmd.Parameters.AddWithValue("@returnamt", objsa106.returnamt);
						cmd.Parameters.AddWithValue("@canadaamt", objsa106.canadaamt);
						cmd.Parameters.AddWithValue("@freightamt", objsa106.freightamt);
						cmd.Parameters.AddWithValue("@proceamt", objsa106.proceamt);
						cmd.Parameters.AddWithValue("@insuredamt", objsa106.insuredamt);
						cmd.Parameters.AddWithValue("@pickupamt", objsa106.pickupamt);
						cmd.Parameters.AddWithValue("@discountamt", objsa106.discountamt);
						cmd.Parameters.AddWithValue("@vouchersamt", objsa106.vouchersamt);
						cmd.Parameters.AddWithValue("@reservatamt", objsa106.reservatamt);
						cmd.Parameters.AddWithValue("@activityamt", objsa106.activityamt);
						cmd.Parameters.AddWithValue("@totalfreight", objsa106.totalfreight);
						cmd.Parameters.AddWithValue("@totaltreatment", objsa106.totaltreatment);
						cmd.Parameters.AddWithValue("@totalinsurance", objsa106.totalinsurance);
						cmd.Parameters.AddWithValue("@totalamt", objsa106.totalamt);
						cmd.Parameters.AddWithValue("@pairs", objsa106.pairs);
						cmd.Parameters.AddWithValue("@remark", objsa106.remark);
						cmd.Parameters.AddWithValue("@ba005gkey", objsa106.ba005gkey);
						cmd.Parameters.AddWithValue("@modifydate", objsa106.modifydate);
						cmd.Parameters.AddWithValue("@revisedate", objsa106.revisedate);
						cmd.Parameters.AddWithValue("@approve", objsa106.approve);
						cmd.Parameters.AddWithValue("@aes101gkey", objsa106.aes101gkey);
						cmd.Parameters.AddWithValue("@ses101gkey", objsa106.ses101gkey);
						cmd.Parameters.AddWithValue("@es101gkey", objsa106.es101gkey);
						cmd.Parameters.AddWithValue("@replication_create", objsa106.replication_create);
						cmd.Parameters.AddWithValue("@replication_update", objsa106.replication_update);
						cmd.Parameters.AddWithValue("@rownum", objsa106.rownum);
						cmd.Parameters.AddWithValue("@addproceamt", objsa106.addproceamt);
						cmd.Parameters.AddWithValue("@lossproceamt", objsa106.lossproceamt);
						cmd.Parameters.AddWithValue("@virementamt", objsa106.virementamt);
						cmd.Parameters.AddWithValue("@ba040gkey", objsa106.ba040gkey);
						cmd.Parameters.AddWithValue("@ba040gkey1", objsa106.ba040gkey1);
						cmd.Parameters.AddWithValue("@receivabledate", objsa106.receivabledate);
						cmd.Parameters.AddWithValue("@receivableamt", objsa106.receivableamt);
						cmd.Parameters.AddWithValue("@virementdate", objsa106.virementdate);
						cmd.Parameters.AddWithValue("@salesamt", objsa106.salesamt);
						cmd.Parameters.AddWithValue("@collchk", objsa106.collchk);
						cmd.Parameters.AddWithValue("@payfreight", objsa106.payfreight);
						cmd.Parameters.AddWithValue("@strchk", objsa106.strchk);
						cmd.Parameters.AddWithValue("@noamount", objsa106.noamount);
						cmd.Parameters.AddWithValue("@totalamount", objsa106.totalamount);
						cmd.Parameters.AddWithValue("@ba101gkey", objsa106.ba101gkey);
						cmd.Parameters.AddWithValue("@remittancedate", objsa106.remittancedate);
						cmd.Parameters.AddWithValue("@remittancetime", objsa106.remittancetime);
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
  