/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: ASP.NET MVC Model Entity class for sa106b
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
	public class sa106bData
	{
		protected Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();
		
		#region Constructor
		public sa106bData() { }
		
		public sa106bData(string gkey,decimal serialno,string sa106gkey,string sa106agkey,string mr200gkey,string mr200agkey,decimal quantity,decimal nodisprice,decimal disprice,decimal cancelqty,decimal cancelamt,decimal outquantity,decimal retquantity,string prepono,string remark,DateTime replication_create,DateTime replication_update)
		{
		this.gkey = gkey;
			this.serialno = serialno;
			this.sa106gkey = sa106gkey;
			this.sa106agkey = sa106agkey;
			this.mr200gkey = mr200gkey;
			this.mr200agkey = mr200agkey;
			this.quantity = quantity;
			this.nodisprice = nodisprice;
			this.disprice = disprice;
			this.cancelqty = cancelqty;
			this.cancelamt = cancelamt;
			this.outquantity = outquantity;
			this.retquantity = retquantity;
			this.prepono = prepono;
			this.remark = remark;
			this.replication_create = replication_create;
			this.replication_update = replication_update;

		}

		public sa106bData(IDataReader objReader)
		{

			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			if (!DBNull.Value.Equals(objReader["serialno"]))
				m_serialno = decimal.Parse(objReader["serialno"].ToString());
			m_sa106gkey = (string) (DBNull.Value.Equals(objReader["sa106gkey"]) ? string.Empty : objReader["sa106gkey"]);
			m_sa106agkey = (string) (DBNull.Value.Equals(objReader["sa106agkey"]) ? string.Empty : objReader["sa106agkey"]);
			m_mr200gkey = (string) (DBNull.Value.Equals(objReader["mr200gkey"]) ? string.Empty : objReader["mr200gkey"]);
			m_mr200agkey = (string) (DBNull.Value.Equals(objReader["mr200agkey"]) ? string.Empty : objReader["mr200agkey"]);
			if (!DBNull.Value.Equals(objReader["quantity"]))
				m_quantity = decimal.Parse(objReader["quantity"].ToString());
			if (!DBNull.Value.Equals(objReader["nodisprice"]))
				m_nodisprice = decimal.Parse(objReader["nodisprice"].ToString());
			if (!DBNull.Value.Equals(objReader["disprice"]))
				m_disprice = decimal.Parse(objReader["disprice"].ToString());
			if (!DBNull.Value.Equals(objReader["cancelqty"]))
				m_cancelqty = decimal.Parse(objReader["cancelqty"].ToString());
			if (!DBNull.Value.Equals(objReader["cancelamt"]))
				m_cancelamt = decimal.Parse(objReader["cancelamt"].ToString());
			if (!DBNull.Value.Equals(objReader["outquantity"]))
				m_outquantity = decimal.Parse(objReader["outquantity"].ToString());
			if (!DBNull.Value.Equals(objReader["retquantity"]))
				m_retquantity = decimal.Parse(objReader["retquantity"].ToString());
			m_prepono = (string) (DBNull.Value.Equals(objReader["prepono"]) ? string.Empty : objReader["prepono"]);
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
		
		private string m_sa106agkey = string.Empty; 
		[StringLength(20)]
		public string sa106agkey
		{
			get { return m_sa106agkey;}
			set
			{
				m_sa106agkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_mr200gkey = string.Empty; 
		[StringLength(20)]
		public string mr200gkey
		{
			get { return m_mr200gkey;}
			set
			{
				m_mr200gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_mr200agkey = string.Empty; 
		[StringLength(20)]
		public string mr200agkey
		{
			get { return m_mr200agkey;}
			set
			{
				m_mr200agkey = (value == null? string.Empty : value);
			}
		}
		
		private decimal m_quantity = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Quantity must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal quantity
		{
			get { return m_quantity;}
			set
			{
				m_quantity = value;
			}
		}
		
		private decimal m_nodisprice = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Nodisprice must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal nodisprice
		{
			get { return m_nodisprice;}
			set
			{
				m_nodisprice = value;
			}
		}
		
		private decimal m_disprice = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Disprice must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal disprice
		{
			get { return m_disprice;}
			set
			{
				m_disprice = value;
			}
		}
		
		private decimal m_cancelqty = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Cancelqty must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal cancelqty
		{
			get { return m_cancelqty;}
			set
			{
				m_cancelqty = value;
			}
		}
		
		private decimal m_cancelamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Cancelamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal cancelamt
		{
			get { return m_cancelamt;}
			set
			{
				m_cancelamt = value;
			}
		}
		
		private decimal m_outquantity = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Outquantity must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal outquantity
		{
			get { return m_outquantity;}
			set
			{
				m_outquantity = value;
			}
		}
		
		private decimal m_retquantity = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Retquantity must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal retquantity
		{
			get { return m_retquantity;}
			set
			{
				m_retquantity = value;
			}
		}
		
		private string m_prepono = string.Empty; 
		[StringLength(30)]
		public string prepono
		{
			get { return m_prepono;}
			set
			{
				m_prepono = (value == null? string.Empty : value);
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