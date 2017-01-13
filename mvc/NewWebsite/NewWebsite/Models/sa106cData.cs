/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: ASP.NET MVC Model Entity class for sa106c
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
	public class sa106cData
	{
		protected Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();
		
		#region Constructor
		public sa106cData() { }
		
		public sa106cData(string gkey,decimal serialno,string sa106gkey,string receiving,string mobilephone,string ba098gkey,string ba097gkey,string ba096gkey,string recaddress,string remark,DateTime replication_create,DateTime replication_update)
		{
		this.gkey = gkey;
			this.serialno = serialno;
			this.sa106gkey = sa106gkey;
			this.receiving = receiving;
			this.mobilephone = mobilephone;
			this.ba098gkey = ba098gkey;
			this.ba097gkey = ba097gkey;
			this.ba096gkey = ba096gkey;
			this.recaddress = recaddress;
			this.remark = remark;
			this.replication_create = replication_create;
			this.replication_update = replication_update;

		}

		public sa106cData(IDataReader objReader)
		{

			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			if (!DBNull.Value.Equals(objReader["serialno"]))
				m_serialno = decimal.Parse(objReader["serialno"].ToString());
			m_sa106gkey = (string) (DBNull.Value.Equals(objReader["sa106gkey"]) ? string.Empty : objReader["sa106gkey"]);
			m_receiving = (string) (DBNull.Value.Equals(objReader["receiving"]) ? string.Empty : objReader["receiving"]);
			m_mobilephone = (string) (DBNull.Value.Equals(objReader["mobilephone"]) ? string.Empty : objReader["mobilephone"]);
			m_ba098gkey = (string) (DBNull.Value.Equals(objReader["ba098gkey"]) ? string.Empty : objReader["ba098gkey"]);
			m_ba097gkey = (string) (DBNull.Value.Equals(objReader["ba097gkey"]) ? string.Empty : objReader["ba097gkey"]);
			m_ba096gkey = (string) (DBNull.Value.Equals(objReader["ba096gkey"]) ? string.Empty : objReader["ba096gkey"]);
			m_recaddress = (string) (DBNull.Value.Equals(objReader["recaddress"]) ? string.Empty : objReader["recaddress"]);
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
		
		private string m_receiving = string.Empty; 
		[StringLength(40)]
		public string receiving
		{
			get { return m_receiving;}
			set
			{
				m_receiving = (value == null? string.Empty : value);
			}
		}
		
		private string m_mobilephone = string.Empty; 
		[StringLength(40)]
		public string mobilephone
		{
			get { return m_mobilephone;}
			set
			{
				m_mobilephone = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba098gkey = string.Empty; 
		[StringLength(20)]
		public string ba098gkey
		{
			get { return m_ba098gkey;}
			set
			{
				m_ba098gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba097gkey = string.Empty; 
		[StringLength(20)]
		public string ba097gkey
		{
			get { return m_ba097gkey;}
			set
			{
				m_ba097gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba096gkey = string.Empty; 
		[StringLength(20)]
		public string ba096gkey
		{
			get { return m_ba096gkey;}
			set
			{
				m_ba096gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_recaddress = string.Empty; 
		[StringLength(400)]
		public string recaddress
		{
			get { return m_recaddress;}
			set
			{
				m_recaddress = (value == null? string.Empty : value);
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