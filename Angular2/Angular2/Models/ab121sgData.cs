using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Angular2.Models
{
	[DataContract]
	public class ab121sgData
	{
		#region Constructor
		public ab121sgData() { }
		
		public ab121sgData(string gkey,string ba015gkey,string ba005gkey)
		{
		this.gkey = gkey;
			this.ba015gkey = ba015gkey;
			this.ba005gkey = ba005gkey;

		}
		
		public ab121sgData(IDataReader objReader)
		{
			m_gkey = (string) (DBNull.Value.Equals(objReader["gkey"]) ? string.Empty : objReader["gkey"]);
			m_ba015gkey = (string) (DBNull.Value.Equals(objReader["ba015gkey"]) ? string.Empty : objReader["ba015gkey"]);
			m_ba005gkey = (string) (DBNull.Value.Equals(objReader["ba005gkey"]) ? string.Empty : objReader["ba005gkey"]);

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
		private string m_ba005gkey = string.Empty;
		[DataMember(IsRequired=true)]
		public string ba005gkey
		{
			get { return m_ba005gkey;}
			set { m_ba005gkey = value;}
		}
		#endregion
		
		#region Lookup Objects
		
		#endregion
		
		#region Child Objects
		
		#endregion
	}
	
	[DataContract]
	public class ab121sgDataByPage
	{
		public ab121sgDataByPage(List<ab121sgData> objab121sgData, int rowsCount) 
		{
			ab121sgData = objab121sgData;
			RowsCount = rowsCount;
		}

		[DataMember(Name ="ab121sgList", IsRequired = true)]
		public List<ab121sgData> ab121sgData = null;

		[DataMember(Name = "RowsCount", IsRequired = true)]
		public int RowsCount = 0;
	}
	
}