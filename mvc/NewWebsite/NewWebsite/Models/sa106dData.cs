/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: ASP.NET MVC Model Entity class for sa106d
 * ------------------------------------------------------------
*/

using System;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace NewWebsite.Models
{
	public class sa106dData
	{
		protected Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();
		
		#region Constructor
		public sa106dData() { }
		
		public sa106dData(string gkey,decimal serialno,string sa106gkey,string ba212gkey,decimal agument,decimal amount,string remark,DateTime replication_create,DateTime replication_update)
		{
		this.gkey = gkey;
			this.serialno = serialno;
			this.sa106gkey = sa106gkey;
			this.ba212gkey = ba212gkey;
			this.agument = agument;
			this.amount = amount;
			this.remark = remark;
			this.replication_create = replication_create;
			this.replication_update = replication_update;

		}

		public sa106dData(IDataReader objReader)
		{

			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			if (!DBNull.Value.Equals(objReader["serialno"]))
				m_serialno = decimal.Parse(objReader["serialno"].ToString());
			m_sa106gkey = (string) (DBNull.Value.Equals(objReader["sa106gkey"]) ? string.Empty : objReader["sa106gkey"]);
			m_ba212gkey = (string) (DBNull.Value.Equals(objReader["ba212gkey"]) ? string.Empty : objReader["ba212gkey"]);
			if (!DBNull.Value.Equals(objReader["agument"]))
				m_agument = decimal.Parse(objReader["agument"].ToString());
			if (!DBNull.Value.Equals(objReader["amount"]))
				m_amount = decimal.Parse(objReader["amount"].ToString());
			m_remark = (string) (DBNull.Value.Equals(objReader["remark"]) ? string.Empty : objReader["remark"]);
			if (!DBNull.Value.Equals(objReader["replication_create"]))
				m_replication_create = DateTime.Parse(objReader["replication_create"].ToString());
			if (!DBNull.Value.Equals(objReader["replication_update"]))
				m_replication_update = DateTime.Parse(objReader["replication_update"].ToString());
		}
		#endregion

		#region Properties
		
		private string m_gkey = string.Empty; 
		[Required(ErrorMessage = "Gkey is Required.")]
		[StringLength(20)]
		public string gkey
		{
			get { return m_gkey;}
			set
			{
				m_gkey = (value == null? string.Empty : value);
			}
		}
		
		private decimal m_serialno = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Serialno must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal serialno
		{
			get { return m_serialno;}
			set
			{
				m_serialno = value;
			}
		}
		
		private string m_sa106gkey = string.Empty; 
		[StringLength(20)]
		public string sa106gkey
		{
			get { return m_sa106gkey;}
			set
			{
				m_sa106gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba212gkey = string.Empty; 
		[StringLength(20)]
		public string ba212gkey
		{
			get { return m_ba212gkey;}
			set
			{
				m_ba212gkey = (value == null? string.Empty : value);
			}
		}
		
		private decimal m_agument = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Agument must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal agument
		{
			get { return m_agument;}
			set
			{
				m_agument = value;
			}
		}
		
		private decimal m_amount = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Amount must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal amount
		{
			get { return m_amount;}
			set
			{
				m_amount = value;
			}
		}
		
		private string m_remark = string.Empty; 
		[StringLength(300)]
		public string remark
		{
			get { return m_remark;}
			set
			{
				m_remark = (value == null? string.Empty : value);
			}
		}
		
		private DateTime? m_replication_create = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? replication_create
		{
			get { return m_replication_create;}
			set
			{
				m_replication_create = value;
			}
		}
		
		private DateTime? m_replication_update = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? replication_update
		{
			get { return m_replication_update;}
			set
			{
				m_replication_update = value;
			}
		}
		
		#endregion
		
		#region Lookup Objects
		
		#endregion
		
		#region Child Objects
		
		#endregion
	}
}