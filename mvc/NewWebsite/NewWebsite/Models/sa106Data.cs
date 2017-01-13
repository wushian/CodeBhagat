/* ------------------------------------------------------------
 * Created By	: CodeBhagat v1.0
 * Created Date	: 2017/1/13
 * Purpose		: ASP.NET MVC Model Entity class for sa106
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
	public class sa106Data
	{
		protected Dictionary<string, string> ErrorDictionary = new Dictionary<string, string>();
		
		#region Constructor
		public sa106Data() { }
		
		public sa106Data(string gkey,DateTime orddate,string mr200gkey,DateTime issuedate,string pono,string salesno,string returnno,DateTime returndate,string deliveryno,string rettype,string xtype,string ba205gkey,DateTime pickupdate,DateTime canceldate,string ba100gkey,string ba102gkey,string ba103gkey,string ba119gkey,string ba118gkey,string ba121gkey,string ba104gkey,string ba209gkey,decimal returnamt,decimal canadaamt,decimal freightamt,decimal proceamt,decimal insuredamt,decimal pickupamt,decimal discountamt,decimal vouchersamt,decimal reservatamt,decimal activityamt,decimal totalfreight,decimal totaltreatment,decimal totalinsurance,decimal totalamt,decimal pairs,string remark,string ba005gkey,DateTime modifydate,DateTime revisedate,string approve,string aes101gkey,string ses101gkey,string es101gkey,DateTime replication_create,DateTime replication_update,decimal rownum,decimal addproceamt,decimal lossproceamt,decimal virementamt,string ba040gkey,string ba040gkey1,DateTime receivabledate,decimal receivableamt,DateTime virementdate,decimal salesamt,string collchk,decimal payfreight,string strchk,decimal noamount,decimal totalamount,string ba101gkey,DateTime remittancedate,DateTime remittancetime)
		{
		this.gkey = gkey;
			this.orddate = orddate;
			this.mr200gkey = mr200gkey;
			this.issuedate = issuedate;
			this.pono = pono;
			this.salesno = salesno;
			this.returnno = returnno;
			this.returndate = returndate;
			this.deliveryno = deliveryno;
			this.rettype = rettype;
			this.xtype = xtype;
			this.ba205gkey = ba205gkey;
			this.pickupdate = pickupdate;
			this.canceldate = canceldate;
			this.ba100gkey = ba100gkey;
			this.ba102gkey = ba102gkey;
			this.ba103gkey = ba103gkey;
			this.ba119gkey = ba119gkey;
			this.ba118gkey = ba118gkey;
			this.ba121gkey = ba121gkey;
			this.ba104gkey = ba104gkey;
			this.ba209gkey = ba209gkey;
			this.returnamt = returnamt;
			this.canadaamt = canadaamt;
			this.freightamt = freightamt;
			this.proceamt = proceamt;
			this.insuredamt = insuredamt;
			this.pickupamt = pickupamt;
			this.discountamt = discountamt;
			this.vouchersamt = vouchersamt;
			this.reservatamt = reservatamt;
			this.activityamt = activityamt;
			this.totalfreight = totalfreight;
			this.totaltreatment = totaltreatment;
			this.totalinsurance = totalinsurance;
			this.totalamt = totalamt;
			this.pairs = pairs;
			this.remark = remark;
			this.ba005gkey = ba005gkey;
			this.modifydate = modifydate;
			this.revisedate = revisedate;
			this.approve = approve;
			this.aes101gkey = aes101gkey;
			this.ses101gkey = ses101gkey;
			this.es101gkey = es101gkey;
			this.replication_create = replication_create;
			this.replication_update = replication_update;
			this.rownum = rownum;
			this.addproceamt = addproceamt;
			this.lossproceamt = lossproceamt;
			this.virementamt = virementamt;
			this.ba040gkey = ba040gkey;
			this.ba040gkey1 = ba040gkey1;
			this.receivabledate = receivabledate;
			this.receivableamt = receivableamt;
			this.virementdate = virementdate;
			this.salesamt = salesamt;
			this.collchk = collchk;
			this.payfreight = payfreight;
			this.strchk = strchk;
			this.noamount = noamount;
			this.totalamount = totalamount;
			this.ba101gkey = ba101gkey;
			this.remittancedate = remittancedate;
			this.remittancetime = remittancetime;

		}

		public sa106Data(IDataReader objReader)
		{

			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			if (!DBNull.Value.Equals(objReader["orddate"]))
				m_orddate = DateTime.Parse(objReader["orddate"].ToString());
			m_mr200gkey = (string) (DBNull.Value.Equals(objReader["mr200gkey"]) ? string.Empty : objReader["mr200gkey"]);
			if (!DBNull.Value.Equals(objReader["issuedate"]))
				m_issuedate = DateTime.Parse(objReader["issuedate"].ToString());
			m_pono = (string) (DBNull.Value.Equals(objReader["pono"]) ? string.Empty : objReader["pono"]);
			m_salesno = (string) (DBNull.Value.Equals(objReader["salesno"]) ? string.Empty : objReader["salesno"]);
			m_returnno = (string) (DBNull.Value.Equals(objReader["returnno"]) ? string.Empty : objReader["returnno"]);
			if (!DBNull.Value.Equals(objReader["returndate"]))
				m_returndate = DateTime.Parse(objReader["returndate"].ToString());
			m_deliveryno = (string) (DBNull.Value.Equals(objReader["deliveryno"]) ? string.Empty : objReader["deliveryno"]);
			m_rettype = (string) (DBNull.Value.Equals(objReader["rettype"]) ? string.Empty : objReader["rettype"]);
			m_xtype = (string) (DBNull.Value.Equals(objReader["xtype"]) ? string.Empty : objReader["xtype"]);
			m_ba205gkey = (string) (DBNull.Value.Equals(objReader["ba205gkey"]) ? string.Empty : objReader["ba205gkey"]);
			if (!DBNull.Value.Equals(objReader["pickupdate"]))
				m_pickupdate = DateTime.Parse(objReader["pickupdate"].ToString());
			if (!DBNull.Value.Equals(objReader["canceldate"]))
				m_canceldate = DateTime.Parse(objReader["canceldate"].ToString());
			m_ba100gkey = (string) (DBNull.Value.Equals(objReader["ba100gkey"]) ? string.Empty : objReader["ba100gkey"]);
			m_ba102gkey = (string) (DBNull.Value.Equals(objReader["ba102gkey"]) ? string.Empty : objReader["ba102gkey"]);
			m_ba103gkey = (string) (DBNull.Value.Equals(objReader["ba103gkey"]) ? string.Empty : objReader["ba103gkey"]);
			m_ba119gkey = (string) (DBNull.Value.Equals(objReader["ba119gkey"]) ? string.Empty : objReader["ba119gkey"]);
			m_ba118gkey = (string) (DBNull.Value.Equals(objReader["ba118gkey"]) ? string.Empty : objReader["ba118gkey"]);
			m_ba121gkey = (string) (DBNull.Value.Equals(objReader["ba121gkey"]) ? string.Empty : objReader["ba121gkey"]);
			m_ba104gkey = (string) (DBNull.Value.Equals(objReader["ba104gkey"]) ? string.Empty : objReader["ba104gkey"]);
			m_ba209gkey = (string) (DBNull.Value.Equals(objReader["ba209gkey"]) ? string.Empty : objReader["ba209gkey"]);
			if (!DBNull.Value.Equals(objReader["returnamt"]))
				m_returnamt = decimal.Parse(objReader["returnamt"].ToString());
			if (!DBNull.Value.Equals(objReader["canadaamt"]))
				m_canadaamt = decimal.Parse(objReader["canadaamt"].ToString());
			if (!DBNull.Value.Equals(objReader["freightamt"]))
				m_freightamt = decimal.Parse(objReader["freightamt"].ToString());
			if (!DBNull.Value.Equals(objReader["proceamt"]))
				m_proceamt = decimal.Parse(objReader["proceamt"].ToString());
			if (!DBNull.Value.Equals(objReader["insuredamt"]))
				m_insuredamt = decimal.Parse(objReader["insuredamt"].ToString());
			if (!DBNull.Value.Equals(objReader["pickupamt"]))
				m_pickupamt = decimal.Parse(objReader["pickupamt"].ToString());
			if (!DBNull.Value.Equals(objReader["discountamt"]))
				m_discountamt = decimal.Parse(objReader["discountamt"].ToString());
			if (!DBNull.Value.Equals(objReader["vouchersamt"]))
				m_vouchersamt = decimal.Parse(objReader["vouchersamt"].ToString());
			if (!DBNull.Value.Equals(objReader["reservatamt"]))
				m_reservatamt = decimal.Parse(objReader["reservatamt"].ToString());
			if (!DBNull.Value.Equals(objReader["activityamt"]))
				m_activityamt = decimal.Parse(objReader["activityamt"].ToString());
			if (!DBNull.Value.Equals(objReader["totalfreight"]))
				m_totalfreight = decimal.Parse(objReader["totalfreight"].ToString());
			if (!DBNull.Value.Equals(objReader["totaltreatment"]))
				m_totaltreatment = decimal.Parse(objReader["totaltreatment"].ToString());
			if (!DBNull.Value.Equals(objReader["totalinsurance"]))
				m_totalinsurance = decimal.Parse(objReader["totalinsurance"].ToString());
			if (!DBNull.Value.Equals(objReader["totalamt"]))
				m_totalamt = decimal.Parse(objReader["totalamt"].ToString());
			if (!DBNull.Value.Equals(objReader["pairs"]))
				m_pairs = decimal.Parse(objReader["pairs"].ToString());
			m_remark = (string) (DBNull.Value.Equals(objReader["remark"]) ? string.Empty : objReader["remark"]);
			m_ba005gkey = (string) (DBNull.Value.Equals(objReader["ba005gkey"]) ? string.Empty : objReader["ba005gkey"]);
			if (!DBNull.Value.Equals(objReader["modifydate"]))
				m_modifydate = DateTime.Parse(objReader["modifydate"].ToString());
			if (!DBNull.Value.Equals(objReader["revisedate"]))
				m_revisedate = DateTime.Parse(objReader["revisedate"].ToString());
			m_approve = (string) (DBNull.Value.Equals(objReader["approve"]) ? string.Empty : objReader["approve"]);
			m_aes101gkey = (string) (DBNull.Value.Equals(objReader["aes101gkey"]) ? string.Empty : objReader["aes101gkey"]);
			m_ses101gkey = (string) (DBNull.Value.Equals(objReader["ses101gkey"]) ? string.Empty : objReader["ses101gkey"]);
			m_es101gkey = (string) (DBNull.Value.Equals(objReader["es101gkey"]) ? string.Empty : objReader["es101gkey"]);
			if (!DBNull.Value.Equals(objReader["replication_create"]))
				m_replication_create = DateTime.Parse(objReader["replication_create"].ToString());
			if (!DBNull.Value.Equals(objReader["replication_update"]))
				m_replication_update = DateTime.Parse(objReader["replication_update"].ToString());
			if (!DBNull.Value.Equals(objReader["rownum"]))
				m_rownum = decimal.Parse(objReader["rownum"].ToString());
			if (!DBNull.Value.Equals(objReader["addproceamt"]))
				m_addproceamt = decimal.Parse(objReader["addproceamt"].ToString());
			if (!DBNull.Value.Equals(objReader["lossproceamt"]))
				m_lossproceamt = decimal.Parse(objReader["lossproceamt"].ToString());
			if (!DBNull.Value.Equals(objReader["virementamt"]))
				m_virementamt = decimal.Parse(objReader["virementamt"].ToString());
			m_ba040gkey = (string) (DBNull.Value.Equals(objReader["ba040gkey"]) ? string.Empty : objReader["ba040gkey"]);
			m_ba040gkey1 = (string) (DBNull.Value.Equals(objReader["ba040gkey1"]) ? string.Empty : objReader["ba040gkey1"]);
			if (!DBNull.Value.Equals(objReader["receivabledate"]))
				m_receivabledate = DateTime.Parse(objReader["receivabledate"].ToString());
			if (!DBNull.Value.Equals(objReader["receivableamt"]))
				m_receivableamt = decimal.Parse(objReader["receivableamt"].ToString());
			if (!DBNull.Value.Equals(objReader["virementdate"]))
				m_virementdate = DateTime.Parse(objReader["virementdate"].ToString());
			if (!DBNull.Value.Equals(objReader["salesamt"]))
				m_salesamt = decimal.Parse(objReader["salesamt"].ToString());
			m_collchk = (string) (DBNull.Value.Equals(objReader["collchk"]) ? string.Empty : objReader["collchk"]);
			if (!DBNull.Value.Equals(objReader["payfreight"]))
				m_payfreight = decimal.Parse(objReader["payfreight"].ToString());
			m_strchk = (string) (DBNull.Value.Equals(objReader["strchk"]) ? string.Empty : objReader["strchk"]);
			if (!DBNull.Value.Equals(objReader["noamount"]))
				m_noamount = decimal.Parse(objReader["noamount"].ToString());
			if (!DBNull.Value.Equals(objReader["totalamount"]))
				m_totalamount = decimal.Parse(objReader["totalamount"].ToString());
			m_ba101gkey = (string) (DBNull.Value.Equals(objReader["ba101gkey"]) ? string.Empty : objReader["ba101gkey"]);
			if (!DBNull.Value.Equals(objReader["remittancedate"]))
				m_remittancedate = DateTime.Parse(objReader["remittancedate"].ToString());
			if (!DBNull.Value.Equals(objReader["remittancetime"]))
				m_remittancetime = DateTime.Parse(objReader["remittancetime"].ToString());
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
		
		private DateTime? m_orddate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? orddate
		{
			get { return m_orddate;}
			set
			{
				m_orddate = value;
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
		
		private DateTime? m_issuedate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? issuedate
		{
			get { return m_issuedate;}
			set
			{
				m_issuedate = value;
			}
		}
		
		private string m_pono = string.Empty; 
		[StringLength(30)]
		public string pono
		{
			get { return m_pono;}
			set
			{
				m_pono = (value == null? string.Empty : value);
			}
		}
		
		private string m_salesno = string.Empty; 
		[StringLength(30)]
		public string salesno
		{
			get { return m_salesno;}
			set
			{
				m_salesno = (value == null? string.Empty : value);
			}
		}
		
		private string m_returnno = string.Empty; 
		[StringLength(30)]
		public string returnno
		{
			get { return m_returnno;}
			set
			{
				m_returnno = (value == null? string.Empty : value);
			}
		}
		
		private DateTime? m_returndate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? returndate
		{
			get { return m_returndate;}
			set
			{
				m_returndate = value;
			}
		}
		
		private string m_deliveryno = string.Empty; 
		[StringLength(30)]
		public string deliveryno
		{
			get { return m_deliveryno;}
			set
			{
				m_deliveryno = (value == null? string.Empty : value);
			}
		}
		
		private string m_rettype = string.Empty; 
		[StringLength(2)]
		public string rettype
		{
			get { return m_rettype;}
			set
			{
				m_rettype = (value == null? string.Empty : value);
			}
		}
		
		private string m_xtype = string.Empty; 
		[StringLength(2)]
		public string xtype
		{
			get { return m_xtype;}
			set
			{
				m_xtype = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba205gkey = string.Empty; 
		[StringLength(20)]
		public string ba205gkey
		{
			get { return m_ba205gkey;}
			set
			{
				m_ba205gkey = (value == null? string.Empty : value);
			}
		}
		
		private DateTime? m_pickupdate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? pickupdate
		{
			get { return m_pickupdate;}
			set
			{
				m_pickupdate = value;
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
		
		private string m_ba100gkey = string.Empty; 
		[StringLength(20)]
		public string ba100gkey
		{
			get { return m_ba100gkey;}
			set
			{
				m_ba100gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba102gkey = string.Empty; 
		[StringLength(20)]
		public string ba102gkey
		{
			get { return m_ba102gkey;}
			set
			{
				m_ba102gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba103gkey = string.Empty; 
		[StringLength(20)]
		public string ba103gkey
		{
			get { return m_ba103gkey;}
			set
			{
				m_ba103gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba119gkey = string.Empty; 
		[StringLength(20)]
		public string ba119gkey
		{
			get { return m_ba119gkey;}
			set
			{
				m_ba119gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba118gkey = string.Empty; 
		[StringLength(20)]
		public string ba118gkey
		{
			get { return m_ba118gkey;}
			set
			{
				m_ba118gkey = (value == null? string.Empty : value);
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
		
		private string m_ba104gkey = string.Empty; 
		[StringLength(20)]
		public string ba104gkey
		{
			get { return m_ba104gkey;}
			set
			{
				m_ba104gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba209gkey = string.Empty; 
		[StringLength(20)]
		public string ba209gkey
		{
			get { return m_ba209gkey;}
			set
			{
				m_ba209gkey = (value == null? string.Empty : value);
			}
		}
		
		private decimal m_returnamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Returnamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal returnamt
		{
			get { return m_returnamt;}
			set
			{
				m_returnamt = value;
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
		
		private decimal m_freightamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Freightamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal freightamt
		{
			get { return m_freightamt;}
			set
			{
				m_freightamt = value;
			}
		}
		
		private decimal m_proceamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Proceamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal proceamt
		{
			get { return m_proceamt;}
			set
			{
				m_proceamt = value;
			}
		}
		
		private decimal m_insuredamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Insuredamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal insuredamt
		{
			get { return m_insuredamt;}
			set
			{
				m_insuredamt = value;
			}
		}
		
		private decimal m_pickupamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Pickupamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal pickupamt
		{
			get { return m_pickupamt;}
			set
			{
				m_pickupamt = value;
			}
		}
		
		private decimal m_discountamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Discountamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal discountamt
		{
			get { return m_discountamt;}
			set
			{
				m_discountamt = value;
			}
		}
		
		private decimal m_vouchersamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Vouchersamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal vouchersamt
		{
			get { return m_vouchersamt;}
			set
			{
				m_vouchersamt = value;
			}
		}
		
		private decimal m_reservatamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Reservatamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal reservatamt
		{
			get { return m_reservatamt;}
			set
			{
				m_reservatamt = value;
			}
		}
		
		private decimal m_activityamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Activityamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal activityamt
		{
			get { return m_activityamt;}
			set
			{
				m_activityamt = value;
			}
		}
		
		private decimal m_totalfreight = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Totalfreight must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal totalfreight
		{
			get { return m_totalfreight;}
			set
			{
				m_totalfreight = value;
			}
		}
		
		private decimal m_totaltreatment = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Totaltreatment must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal totaltreatment
		{
			get { return m_totaltreatment;}
			set
			{
				m_totaltreatment = value;
			}
		}
		
		private decimal m_totalinsurance = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Totalinsurance must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal totalinsurance
		{
			get { return m_totalinsurance;}
			set
			{
				m_totalinsurance = value;
			}
		}
		
		private decimal m_totalamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Totalamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal totalamt
		{
			get { return m_totalamt;}
			set
			{
				m_totalamt = value;
			}
		}
		
		private decimal m_pairs = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Pairs must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal pairs
		{
			get { return m_pairs;}
			set
			{
				m_pairs = value;
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
		
		private string m_ba005gkey = string.Empty; 
		[StringLength(20)]
		public string ba005gkey
		{
			get { return m_ba005gkey;}
			set
			{
				m_ba005gkey = (value == null? string.Empty : value);
			}
		}
		
		private DateTime? m_modifydate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? modifydate
		{
			get { return m_modifydate;}
			set
			{
				m_modifydate = value;
			}
		}
		
		private DateTime? m_revisedate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? revisedate
		{
			get { return m_revisedate;}
			set
			{
				m_revisedate = value;
			}
		}
		
		private string m_approve = string.Empty; 
		[StringLength(1)]
		public string approve
		{
			get { return m_approve;}
			set
			{
				m_approve = (value == null? string.Empty : value);
			}
		}
		
		private string m_aes101gkey = string.Empty; 
		[StringLength(20)]
		public string aes101gkey
		{
			get { return m_aes101gkey;}
			set
			{
				m_aes101gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ses101gkey = string.Empty; 
		[StringLength(20)]
		public string ses101gkey
		{
			get { return m_ses101gkey;}
			set
			{
				m_ses101gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_es101gkey = string.Empty; 
		[StringLength(20)]
		public string es101gkey
		{
			get { return m_es101gkey;}
			set
			{
				m_es101gkey = (value == null? string.Empty : value);
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
		
		private decimal m_rownum = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Rownum must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal rownum
		{
			get { return m_rownum;}
			set
			{
				m_rownum = value;
			}
		}
		
		private decimal m_addproceamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Addproceamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal addproceamt
		{
			get { return m_addproceamt;}
			set
			{
				m_addproceamt = value;
			}
		}
		
		private decimal m_lossproceamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Lossproceamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal lossproceamt
		{
			get { return m_lossproceamt;}
			set
			{
				m_lossproceamt = value;
			}
		}
		
		private decimal m_virementamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Virementamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal virementamt
		{
			get { return m_virementamt;}
			set
			{
				m_virementamt = value;
			}
		}
		
		private string m_ba040gkey = string.Empty; 
		[StringLength(20)]
		public string ba040gkey
		{
			get { return m_ba040gkey;}
			set
			{
				m_ba040gkey = (value == null? string.Empty : value);
			}
		}
		
		private string m_ba040gkey1 = string.Empty; 
		[StringLength(20)]
		public string ba040gkey1
		{
			get { return m_ba040gkey1;}
			set
			{
				m_ba040gkey1 = (value == null? string.Empty : value);
			}
		}
		
		private DateTime? m_receivabledate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? receivabledate
		{
			get { return m_receivabledate;}
			set
			{
				m_receivabledate = value;
			}
		}
		
		private decimal m_receivableamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Receivableamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal receivableamt
		{
			get { return m_receivableamt;}
			set
			{
				m_receivableamt = value;
			}
		}
		
		private DateTime? m_virementdate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? virementdate
		{
			get { return m_virementdate;}
			set
			{
				m_virementdate = value;
			}
		}
		
		private decimal m_salesamt = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Salesamt must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal salesamt
		{
			get { return m_salesamt;}
			set
			{
				m_salesamt = value;
			}
		}
		
		private string m_collchk = string.Empty; 
		[StringLength(1)]
		public string collchk
		{
			get { return m_collchk;}
			set
			{
				m_collchk = (value == null? string.Empty : value);
			}
		}
		
		private decimal m_payfreight = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Payfreight must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal payfreight
		{
			get { return m_payfreight;}
			set
			{
				m_payfreight = value;
			}
		}
		
		private string m_strchk = string.Empty; 
		[StringLength(1)]
		public string strchk
		{
			get { return m_strchk;}
			set
			{
				m_strchk = (value == null? string.Empty : value);
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
		
		private decimal m_totalamount = 0; 
		[Range(typeof(decimal), "0", "1000", ErrorMessage="Totalamount must be between 0 and 1000")]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public decimal totalamount
		{
			get { return m_totalamount;}
			set
			{
				m_totalamount = value;
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
		
		private DateTime? m_remittancedate = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? remittancedate
		{
			get { return m_remittancedate;}
			set
			{
				m_remittancedate = value;
			}
		}
		
		private DateTime? m_remittancetime = null; 
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime? remittancetime
		{
			get { return m_remittancetime;}
			set
			{
				m_remittancetime = value;
			}
		}
		
		#endregion
		
		#region Lookup Objects
		
		#endregion
		
		#region Child Objects
		
		#endregion
	}
}