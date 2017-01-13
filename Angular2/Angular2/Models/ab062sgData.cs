using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Angular2.Models
{
	[DataContract]
	public class ab062sgData
	{
		#region Constructor
		public ab062sgData() { }
		
		public ab062sgData(string gkey,string ba060gkey,decimal rate,string ym)
		{
		this.gkey = gkey;
			this.ba060gkey = ba060gkey;
			this.rate = rate;
			this.ym = ym;

		}
		
		public ab062sgData(IDataReader objReader)
		{
			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			m_ba060gkey = (string) (DBNull.Value.Equals(objReader["ba060gkey"]) ? string.Empty : objReader["ba060gkey"]);
			if (!DBNull.Value.Equals(objReader["rate"]))
				m_rate = decimal.Parse(objReader["rate"].ToString());
			m_ym = (string) (DBNull.Value.Equals(objReader["ym"]) ? string.Empty : objReader["ym"]);

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
		private string m_ba060gkey = string.Empty;
		[DataMember(IsRequired=true)]
		public string ba060gkey
		{
			get { return m_ba060gkey;}
			set { m_ba060gkey = value;}
		}
		private decimal m_rate = 0;
		[DataMember(IsRequired=true)]
		public decimal rate
		{
			get { return m_rate;}
			set { m_rate = value;}
		}
		private string m_ym = string.Empty;
		[DataMember(IsRequired=true)]
		public string ym
		{
			get { return m_ym;}
			set { m_ym = value;}
		}
		#endregion
		
		#region Lookup Objects
		
		#endregion
		
		#region Child Objects
		
		#endregion
	}
	
	[DataContract]
	public class ab062sgDataByPage
	{
		public ab062sgDataByPage(List<ab062sgData> objab062sgData, int rowsCount) 
		{
			ab062sgData = objab062sgData;
			RowsCount = rowsCount;
		}

		[DataMember(Name ="ab062sgList", IsRequired = true)]
		public List<ab062sgData> ab062sgData = null;

		[DataMember(Name = "RowsCount", IsRequired = true)]
		public int RowsCount = 0;
	}
	
}