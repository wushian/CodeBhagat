#region Using Statements
using System;
using System.Collections.Generic;
using System.Data;
#endregion

namespace CodeBhagat.Business
{
	public interface Isa106
	{
		// Methods to Get Data in List<sa106Data> object
		List<sa106Data> GetList();
		List<sa106Data> GetList(string filterExpression);
		List<sa106Data> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount);
		sa106Data GetDetailsByID(string sRefID);

		// Methods to Add/Edit/Delete
		string Add(sa106Data objsa106);
		bool Update(sa106Data objsa106);
		bool Delete(string sRefID);
		int DeleteFilter(string filterExpression);

		// Methods to Get Data in DataSet
		DataSet GetData();
		DataSet GetData(string filterExpression);
		DataSet GetData(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount);
		DataSet GetDetails(sRefID As String);
		DataSet GetLookup();
	}
}