using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewWebsite.Models
{
    public static class SecurityHelper
    {
        public static bool CheckForSQLInjection(string userInput)
        {
			bool isSQLInjection = false;
			string[] sqlCheckList = { "--", ";--", ";", "/*","*/","@@","@","char","nchar","varchar","nvarchar","alter","begin",
									   "cast","create","cursor","declare","delete","drop","end","exec","execute",
									   "fetch","insert","kill","select","sys","sysobjects","syscolumns","table","update" };
			//string CheckString = userInput.Replace("'", "''");

			for (int i = 0; i <= sqlCheckList.Length - 1; i++)
			{
				if ((userInput.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
				{
					isSQLInjection = true;
				}
			}
			return isSQLInjection;
        }

		public static string ReplaceQuotes(string userInput)
		{
			return userInput.Replace("'", "''");
		}
    }
}