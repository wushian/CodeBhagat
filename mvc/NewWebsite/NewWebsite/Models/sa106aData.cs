/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: ASP.NET MVC Model Entity class for sa106a
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
	public class sa106aData
	{
		protected Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();
		
		#region Constructor
		public sa106aData() { }
		
		public sa106aData(string gkey,decimal serialno,string sa106gkey,string ba101gkey,string ba110gkey,string ba113gkey,string mr200gkey,string mr200agkey,string ba120gkey,string ba121gkey,string ba106gkey,DateTime shipmentdate,DateTime canceldate,string cancelreason,string activityid,string activityname,decimal quantity,decimal nodisprice,decimal noamount,decimal disprice,decimal cancelqty,decimal cancelamt,decimal outquantity,decimal retquantity,string prepono,string mr210gkey,string mr210agkey,string remark,DateTime replication_create,DateTime replication_update,decimal inventoryqty,decimal outstockqty,decimal tstdqty,string ba126gkey,string webgkey,decimal canadaamt,string ba117gkey)
		{
		this.gkey = gkey;
			this.serialno = serialno;
			this.sa106gkey = sa106gkey;
			this.ba101gkey = ba101gkey;
			this.ba110gkey = ba110gkey;
			this.ba113gkey = ba113gkey;
			this.mr200gkey = mr200gkey;
			this.mr200agkey = mr200agkey;
			this.ba120gkey = ba120gkey;
			this.ba121gkey = ba121gkey;
			this.ba106gkey = ba106gkey;
			this.shipmentdate = shipmentdate;
			this.canceldate = canceldate;
			this.cancelreason = cancelreason;
			this.activityid = activityid;
			this.activityname = activityname;
			this.quantity = quantity;
			this.nodisprice = nodisprice;
			this.noamount = noamount;
			this.disprice = disprice;
			this.cancelqty = cancelqty;
			this.cancelamt = cancelamt;
			this.outquantity = outquantity;
			this.retquantity = retquantity;
			this.prepono = prepono;
			this.mr210gkey = mr210gkey;
			this.mr210agkey = mr210agkey;
			this.remark = remark;
			this.replication_create = replication_create;
			this.replication_update = replication_update;
			this.inventoryQty = inventoryqty;
			this.outstockQty = outstockqty;
			this.tstdqty = tstdqty;
			this.ba126gkey = ba126gkey;
			this.webgkey = webgkey;
			this.canadaamt = canadaamt;
			this.ba117gkey = ba117gkey;

		}

		public sa106aData(IDataReader objReader)
		{

			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			if (!DBNull.Value.Equals(objReader["serialno"]))
				m_serialno = decimal.Parse(objReader["serialno"].ToString());
			m_sa106gkey = (string) (DBNull.Value.Equals(objReader["sa106gkey"]) ? string.Empty : objReader["sa106gkey"]);
			m_ba101gkey = (string) (DBNull.Value.Equals(objReader["ba101gkey"]) ? string.Empty : objReader["ba101gkey"]);
			m_ba110gkey = (string) (DBNull.Value.Equals(objReader["ba110gkey"]) ? string.Empty : objReader["ba110gkey"]);
			m_ba113gkey = (string) (DBNull.Value.Equals(objReader["ba113gkey"]) ? string.Empty : objReader["ba113gkey"]);
			m_mr200gkey = (string) (DBNull.Value.Equals(objReader["mr200gkey"]) ? string.Empty : objReader["mr200gkey"]);
			m_mr200agkey = (string) (DBNull.Value.Equals(objReader["mr200agkey"]) ? string.Empty : objReader["mr200agkey"]);
			m_ba120gkey = (string) (DBNull.Value.Equals(objReader["ba120gkey"]) ? string.Empty : objReader["ba120gkey"]);
			m_ba121gkey = (string) (DBNull.Value.Equals(objReader["ba121gkey"]) ? string.Empty : objReader["ba121gkey"]);
			m_ba106gkey = (string) (DBNull.Value.Equals(objReader["ba106gkey"]) ? string.Empty : objReader["ba106gkey"]);
			if (!DBNull.Value.Equals(objReader["shipmentdate"]))
				m_shipmentdate = DateTime.Parse(objReader["shipmentdate"].ToString());
			if (!DBNull.Value.Equals(objReader["canceldate"]))
				m_canceldate = DateTime.Parse(objReader["canceldate"].ToString());
			m_cancelreason = (string) (DBNull.Value.Equals(objReader["cancelreason"]) ? string.Empty : objReader["cancelreason"]);
			m_activityid = (string) (DBNull.Value.Equals(objReader["activityid"]) ? string.Empty : objReader["activityid"]);
			m_activityname = (string) (DBNull.Value.Equals(objReader["activityname"]) ? string.Empty : objReader["activityname"]);
			if (!DBNull.Value.Equals(objReader["quantity"]))
				m_quantity = decimal.Parse(objReader["quantity"].ToString());
			if (!DBNull.Value.Equals(objReader["nodisprice"]))
				m_nodisprice = decimal.Parse(objReader["nodisprice"].ToString());
			if (!DBNull.Value.Equals(objReader["noamount"]))
				m_noamount = decimal.Parse(objReader["noamount"].ToString());
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
			m_mr210gkey = (string) (DBNull.Value.Equals(objReader["mr210gkey"]) ? string.Empty : objReader["mr210gkey"]);
			m_mr210agkey = (string) (DBNull.Value.Equals(objReader["mr210agkey"]) ? string.Empty : objReader["mr210agkey"]);
			m_remark = (string) (DBNull.Value.Equals(objReader["remark"]) ? string.Empty : objReader["remark"]);
			if (!DBNull.Value.Equals(objReader["replication_create"]))
				m_replication_create = DateTime.Parse(objReader["replication_create"].ToString());
			if (!DBNull.Value.Equals(objReader["replication_update"]))
				m_replication_update = DateTime.Parse(objReader["replication_update"].ToString());
			if (!DBNull.Value.Equals(objReader["inventoryQty"]))
				m_inventoryQty = decimal.Parse(objReader["inventoryQty"].ToString());
			if (!DBNull.Value.Equals(objReader["outstockQty"]))
				m_outstockQty = decimal.Parse(objReader["outstockQty"].ToString());
			if (!DBNull.Value.Equals(objReader["tstdqty"]))
				m_tstdqty = decimal.Parse(objReader["tstdqty"].ToString());
			m_ba126gkey = (string) (DBNull.Value.Equals(objReader["ba126gkey"]) ? string.Empty : objReader["ba126gkey"]);
			m_webgkey = (string) (DBNull.Value.Equals(objReader["webgkey"]) ? string.Empty : objReader["webgkey"]);
			if (!DBNull.Value.Equals(objReader["canadaamt"]))
				m_canadaamt = decimal.Parse(objReader["canadaamt"].ToString());
			m_ba117gkey = (string) (DBNull.Value.Equals(objReader["ba117gkey"]) ? string.Empty : objReader["ba117gkey"]);
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
		
		private string m_ba101gkey = string.Empty; 
		[StringLength(20)]
		public string ba101gkey
		{
			get { return m_ba101gkey;}
			set
			{
				m_ba101gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba110gkey = string.Empty; 
		[StringLength(20)]
		public string ba110gkey
		{
			get { return m_ba110gkey;}
			set
			{
				m_ba110gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba113gkey = string.Empty; 
		[StringLength(20)]
		public string ba113gkey
		{
			get { return m_ba113gkey;}
			set
			{
				m_ba113gkey = (value == null? string.Empty : value);
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
		
		private string m_ba120gkey = string.Empty; 
		[StringLength(20)]
		public string ba120gkey
		{
			get { return m_ba120gkey;}
			set
			{
				m_ba120gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba121gkey = string.Empty; 
		[StringLength(20)]
		public string ba121gkey
		{
			get { return m_ba121gkey;}
			set
			{
				m_ba121gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba106gkey = string.Empty; 
		[StringLength(20)]
		public string ba106gkey
		{
			get { return m_ba106gkey;}
			set
			{
				m_ba106gkey = (value == null? string.Empty : value);
			}
		}
		
		private DateTime? m_shipmentdate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? shipmentdate
		{
			get { return m_shipmentdate;}
			set
			{
				m_shipmentdate = value;
			}
		}
		
		private DateTime? m_canceldate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? canceldate
		{
			get { return m_canceldate;}
			set
			{
				m_canceldate = value;
			}
		}
		
		private string m_cancelreason = string.Empty; 
		[StringLength(300)]
		public string cancelreason
		{
			get { return m_cancelreason;}
			set
			{
				m_cancelreason = (value == null? string.Empty : value);
			}
		}
		
		private string m_activityid = string.Empty; 
		[StringLength(300)]
		public string activityid
		{
			get { return m_activityid;}
			set
			{
				m_activityid = (value == null? string.Empty : value);
			}
		}
		
		private string m_activityname = string.Empty; 
		[StringLength(300)]
		public string activityname
		{
			get { return m_activityname;}
			set
			{
				m_activityname = (value == null? string.Empty : value);
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
		
		private decimal m_noamount = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Noamount must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal noamount
		{
			get { return m_noamount;}
			set
			{
				m_noamount = value;
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
		
		private string m_mr210gkey = string.Empty; 
		[StringLength(20)]
		public string mr210gkey
		{
			get { return m_mr210gkey;}
			set
			{
				m_mr210gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_mr210agkey = string.Empty; 
		[StringLength(20)]
		public string mr210agkey
		{
			get { return m_mr210agkey;}
			set
			{
				m_mr210agkey = (value == null? string.Empty : value);
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
		
		private decimal m_inventoryQty = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Inventoryqty must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal inventoryQty
		{
			get { return m_inventoryQty;}
			set
			{
				m_inventoryQty = value;
			}
		}
		
		private decimal m_outstockQty = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Outstockqty must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal outstockQty
		{
			get { return m_outstockQty;}
			set
			{
				m_outstockQty = value;
			}
		}
		
		private decimal m_tstdqty = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Tstdqty must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal tstdqty
		{
			get { return m_tstdqty;}
			set
			{
				m_tstdqty = value;
			}
		}
		
		private string m_ba126gkey = string.Empty; 
		[StringLength(20)]
		public string ba126gkey
		{
			get { return m_ba126gkey;}
			set
			{
				m_ba126gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_webgkey = string.Empty; 
		[StringLength(20)]
		public string webgkey
		{
			get { return m_webgkey;}
			set
			{
				m_webgkey = (value == null? string.Empty : value);
			}
		}
		
		private decimal m_canadaamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Canadaamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal canadaamt
		{
			get { return m_canadaamt;}
			set
			{
				m_canadaamt = value;
			}
		}
		
		private string m_ba117gkey = string.Empty; 
		[StringLength(20)]
		public string ba117gkey
		{
			get { return m_ba117gkey;}
			set
			{
				m_ba117gkey = (value == null? string.Empty : value);
			}
		}
		
		#endregion
		
		#region Lookup Objects
		
		#endregion
		
		#region Child Objects
		
		#endregion
	}
}