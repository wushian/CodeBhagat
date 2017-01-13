using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Angular2.Models
{
	[DataContract]
	public class ab120Data
	{
		#region Constructor
		public ab120Data() { }
		
		public ab120Data(string gkey,string ba015gkey,string ba015gkey1,string ac002gkey1,string ac002gkey2,string ac002gkey3,string ac002gkey4,string ab041gkey1,string accountno1,string ab041gkey2,string accountno2,decimal clsdd,decimal mmend,decimal chkdd,string payee,string bankinfo,string swift)
		{
		this.gkey = gkey;
			this.ba015gkey = ba015gkey;
			this.ba015gkey1 = ba015gkey1;
			this.ac002gkey1 = ac002gkey1;
			this.ac002gkey2 = ac002gkey2;
			this.ac002gkey3 = ac002gkey3;
			this.ac002gkey4 = ac002gkey4;
			this.ab041gkey1 = ab041gkey1;
			this.accountno1 = accountno1;
			this.ab041gkey2 = ab041gkey2;
			this.accountno2 = accountno2;
			this.clsdd = clsdd;
			this.mmend = mmend;
			this.chkdd = chkdd;
			this.payee = payee;
			this.bankinfo = bankinfo;
			this.swift = swift;

		}
		
		public ab120Data(IDataReader objReader)
		{
			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			m_ba015gkey = (string) (DBNull.Value.Equals(objReader["ba015gkey"]) ? string.Empty : objReader["ba015gkey"]);
			m_ba015gkey1 = (string) (DBNull.Value.Equals(objReader["ba015gkey1"]) ? string.Empty : objReader["ba015gkey1"]);
			m_ac002gkey1 = (string) (DBNull.Value.Equals(objReader["ac002gkey1"]) ? string.Empty : objReader["ac002gkey1"]);
			m_ac002gkey2 = (string) (DBNull.Value.Equals(objReader["ac002gkey2"]) ? string.Empty : objReader["ac002gkey2"]);
			m_ac002gkey3 = (string) (DBNull.Value.Equals(objReader["ac002gkey3"]) ? string.Empty : objReader["ac002gkey3"]);
			m_ac002gkey4 = (string) (DBNull.Value.Equals(objReader["ac002gkey4"]) ? string.Empty : objReader["ac002gkey4"]);
			m_ab041gkey1 = (string) (DBNull.Value.Equals(objReader["ab041gkey1"]) ? string.Empty : objReader["ab041gkey1"]);
			m_accountno1 = (string) (DBNull.Value.Equals(objReader["accountno1"]) ? string.Empty : objReader["accountno1"]);
			m_ab041gkey2 = (string) (DBNull.Value.Equals(objReader["ab041gkey2"]) ? string.Empty : objReader["ab041gkey2"]);
			m_accountno2 = (string) (DBNull.Value.Equals(objReader["accountno2"]) ? string.Empty : objReader["accountno2"]);
			if (!DBNull.Value.Equals(objReader["clsdd"]))
				m_clsdd = decimal.Parse(objReader["clsdd"].ToString());
			if (!DBNull.Value.Equals(objReader["mmend"]))
				m_mmend = decimal.Parse(objReader["mmend"].ToString());
			if (!DBNull.Value.Equals(objReader["chkdd"]))
				m_chkdd = decimal.Parse(objReader["chkdd"].ToString());
			m_payee = (string) (DBNull.Value.Equals(objReader["payee"]) ? string.Empty : objReader["payee"]);
			m_bankinfo = (string) (DBNull.Value.Equals(objReader["bankinfo"]) ? string.Empty : objReader["bankinfo"]);
			m_swift = (string) (DBNull.Value.Equals(objReader["swift"]) ? string.Empty : objReader["swift"]);

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
		private string m_ba015gkey = string.Empty;
		[DataMember(IsRequired=true)]
		public string ba015gkey
		{
			get { return m_ba015gkey;}
			set { m_ba015gkey = value;}
		}
		private string m_ba015gkey1 = string.Empty;
		[DataMember(IsRequired=true)]
		public string ba015gkey1
		{
			get { return m_ba015gkey1;}
			set { m_ba015gkey1 = value;}
		}
		private string m_ac002gkey1 = string.Empty;
		[DataMember(IsRequired=true)]
		public string ac002gkey1
		{
			get { return m_ac002gkey1;}
			set { m_ac002gkey1 = value;}
		}
		private string m_ac002gkey2 = string.Empty;
		[DataMember(IsRequired=true)]
		public string ac002gkey2
		{
			get { return m_ac002gkey2;}
			set { m_ac002gkey2 = value;}
		}
		private string m_ac002gkey3 = string.Empty;
		[DataMember(IsRequired=true)]
		public string ac002gkey3
		{
			get { return m_ac002gkey3;}
			set { m_ac002gkey3 = value;}
		}
		private string m_ac002gkey4 = string.Empty;
		[DataMember(IsRequired=true)]
		public string ac002gkey4
		{
			get { return m_ac002gkey4;}
			set { m_ac002gkey4 = value;}
		}
		private string m_ab041gkey1 = string.Empty;
		[DataMember(IsRequired=true)]
		public string ab041gkey1
		{
			get { return m_ab041gkey1;}
			set { m_ab041gkey1 = value;}
		}
		private string m_accountno1 = string.Empty;
		[DataMember(IsRequired=true)]
		public string accountno1
		{
			get { return m_accountno1;}
			set { m_accountno1 = value;}
		}
		private string m_ab041gkey2 = string.Empty;
		[DataMember(IsRequired=true)]
		public string ab041gkey2
		{
			get { return m_ab041gkey2;}
			set { m_ab041gkey2 = value;}
		}
		private string m_accountno2 = string.Empty;
		[DataMember(IsRequired=true)]
		public string accountno2
		{
			get { return m_accountno2;}
			set { m_accountno2 = value;}
		}
		private decimal m_clsdd = 0;
		[DataMember(IsRequired=true)]
		public decimal clsdd
		{
			get { return m_clsdd;}
			set { m_clsdd = value;}
		}
		private decimal m_mmend = 0;
		[DataMember(IsRequired=true)]
		public decimal mmend
		{
			get { return m_mmend;}
			set { m_mmend = value;}
		}
		private decimal m_chkdd = 0;
		[DataMember(IsRequired=true)]
		public decimal chkdd
		{
			get { return m_chkdd;}
			set { m_chkdd = value;}
		}
		private string m_payee = string.Empty;
		[DataMember(IsRequired=true)]
		public string payee
		{
			get { return m_payee;}
			set { m_payee = value;}
		}
		private string m_bankinfo = string.Empty;
		[DataMember(IsRequired=true)]
		public string bankinfo
		{
			get { return m_bankinfo;}
			set { m_bankinfo = value;}
		}
		private string m_swift = string.Empty;
		[DataMember(IsRequired=true)]
		public string swift
		{
			get { return m_swift;}
			set { m_swift = value;}
		}
		#endregion
		
		#region Lookup Objects
		
		#endregion
		
		#region Child Objects
		
		#endregion
	}
	
	[DataContract]
	public class ab120DataByPage
	{
		public ab120DataByPage(List<ab120Data> objab120Data, int rowsCount) 
		{
			ab120Data = objab120Data;
			RowsCount = rowsCount;
		}

		[DataMember(Name ="ab120List", IsRequired = true)]
		public List<ab120Data> ab120Data = null;

		[DataMember(Name = "RowsCount", IsRequired = true)]
		public int RowsCount = 0;
	}
	
}