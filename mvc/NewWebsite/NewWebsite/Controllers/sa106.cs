using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewWebsite.Models;

namespace NewWebsite.Models
{
    public class sa106Repository : Isa106Repository
    {

        #region Isa106Repository Members
		public bool Create(sa106Data objsa106)
        {
            try
            {
                NewWebsite.Models.sa106.Add(objsa106);
                return true;
            }
            catch { return false; }
        }

		public sa106Data Details(int gkey)
        {
            try
            {
                return NewWebsite.Models.sa106.GetDetailsByID(gkey);
            }
            catch { return null; }
        }

		public bool Edit(sa106Data objsa106)
        {
            try
            {
				//var entity = Details(product.ProductID);
				//entity.ProductName = product.ProductName;
				//entity.UnitPrice = product.UnitPrice;
                // other properties
				NewWebsite.Models.sa106.Update(objsa106);
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int gkey)
        {
            try
            {
                NewWebsite.Models.sa106.Delete(gkey.ToString());
                return true;
            }
            catch { return false; }
        }

		public IQueryable<sa106Data> Index()
        {
            try
            {
                return NewWebsite.Models.sa106.GetList().AsQueryable();
            }
            catch { return null; }
        }
        #endregion
    }

    public interface Isa106Repository
    {
        bool Create(sa106Data objsa106);
		sa106Data Details(int gkey);
		bool Edit(sa106Data objsa106);
        bool Delete(int gkey);
		IQueryable<sa106Data> Index();
		IQueryable<sa106Data> Index(int gkey);
    }
}
