using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Angular2.Models
{
	[DataContract]
	public class ab041Data
	{
		#region Constructor
		public ab041Data() { }
		
		public ab041Data(string gkey,string bbankno,decimal changedd,string bbankname,string ebbankname,string tel,string fax,string address)
		{
		this.gkey = gkey;
			this.bbankno = bbankno;
			this.changedd = changedd;
			this.bbankname = bbankname;
			this.ebbankname = ebbankname;
			this.tel = tel;
			this.fax = fax;
			this.address = address;

		}
		
		public ab041Data(IDataReader objReader)
		{
			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			m_bbankno = (string) (DBNull.Value.Equals(objReader["bbankno"]) ? string.Empty : objReader["bbankno"]);
			if (!DBNull.Value.Equals(objReader["changedd"]))
				m_changedd = decimal.Parse(objReader["changedd"].ToString());
			m_bbankname = (string) (DBNull.Value.Equals(objReader["bbankname"]) ? string.Empty : objReader["bbankname"]);
			m_ebbankname = (string) (DBNull.Value.Equals(objReader["ebbankname"]) ? string.Empty : objReader["ebbankname"]);
			m_tel = (string) (DBNull.Value.Equals(objReader["tel"]) ? string.Empty : objReader["tel"]);
			m_fax = (string) (DBNull.Value.Equals(objReader["fax"]) ? string.Empty : objReader["fax"]);
			m_address = (string) (DBNull.Value.Equals(objReader["address"]) ? string.Empty : objReader["address"]);

		}
		#endregion

		#region Properties
		
		private string m_gkey = string.Empty;
		[DataMember(IsRequired=true)]
		public string gkey
		{
			get { return m_gkey;}
			set { m_gkey = value;}
		}
		private string m_bbankno = string.Empty;
		[DataMember(IsRequired=true)]
		public string bbankno
		{
			get { return m_bbankno;}
			set { m_bbankno = value;}
		}
		private decimal m_changedd = 0;
		[DataMember(IsRequired=true)]
		public decimal changedd
		{
			get { return m_changedd;}
			set { m_changedd = value;}
		}
		private string m_bbankname = string.Empty;
		[DataMember(IsRequired=true)]
		public string bbankname
		{
			get { return m_bbankname;}
			set { m_bbankname = value;}
		}
		private string m_ebbankname = string.Empty;
		[DataMember(IsRequired=true)]
		public string ebbankname
		{
			get { return m_ebbankname;}
			set { m_ebbankname = value;}
		}
		private string m_tel = string.Empty;
		[DataMember(IsRequired=true)]
		public string tel
		{
			get { return m_tel;}
			set { m_tel = value;}
		}
		private string m_fax = string.Empty;
		[DataMember(IsRequired=true)]
		public string fax
		{
			get { return m_fax;}
			set { m_fax = value;}
		}
		private string m_address = string.Empty;
		[DataMember(IsRequired=true)]
		public string address
		{
			get { return m_address;}
			set { m_address = value;}
		}
		#endregion
		
		#region Lookup Objects
		
		#endregion
		
		#region Child Objects
		
		#endregion
	}
	
	[DataContract]
	public class ab041DataByPage
	{
		public ab041DataByPage(List<ab041Data> objab041Data, int rowsCount) 
		{
			ab041Data = objab041Data;
			RowsCount = rowsCount;
		}

		[DataMember(Name ="ab041List", IsRequired = true)]
		public List<ab041Data> ab041Data = null;

		[DataMember(Name = "RowsCount", IsRequired = true)]
		public int RowsCount = 0;
	}
	
}