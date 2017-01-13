#region History
/************************CREATION HISTORY*****************************
 * Created By		: CodeBhagat v1.0
 * Created Date		: 2017/1/13
 * Purpose			: sa106 Listing
 * *******************************************************************
*/
#endregion

#region Using
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
#endregion

namespace NewWebsite
{
	/// <summary>
	/// Summary description for sa106.
	/// </summary>
    public partial class sa106Search : System.Web.UI.UserControl
    {
        public delegate void SearchEventHandler(object sender, System.EventArgs se);
        public event SearchEventHandler SearchEvent;

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //LoadData();
                }
            }
            catch (Exception objEx)
            {
            }
        }
        #endregion

        #region Page Property - FilterExpression
        public string FilterExpression
        {
            get
            {
                if (ViewState["FilterExpression"] == null)
                    return string.Empty;
                return Convert.ToString(ViewState["FilterExpression"]);
            }
            set
            {
                ViewState["FilterExpression"] = value;
            }
        }
        #endregion

        #region Page Button Events
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
					this.FilterExpression = string.Empty;
                    System.Text.StringBuilder sbFilterExpression = new System.Text.StringBuilder();
                    
                    
			if (txtgkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("gkey like '%{0}%' AND ", txtgkey.Text);
		
			if (txtorddate.Text != string.Empty)
			sbFilterExpression.AppendFormat("orddate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtorddate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtorddate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtmr200gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("mr200gkey like '%{0}%' AND ", txtmr200gkey.Text);
		
			if (txtissuedate.Text != string.Empty)
			sbFilterExpression.AppendFormat("issuedate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtissuedate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtissuedate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtpono.Text != string.Empty)
				sbFilterExpression.AppendFormat("pono like '%{0}%' AND ", txtpono.Text);
		
			if (txtsalesno.Text != string.Empty)
				sbFilterExpression.AppendFormat("salesno like '%{0}%' AND ", txtsalesno.Text);
		
			if (txtreturnno.Text != string.Empty)
				sbFilterExpression.AppendFormat("returnno like '%{0}%' AND ", txtreturnno.Text);
		
			if (txtreturndate.Text != string.Empty)
			sbFilterExpression.AppendFormat("returndate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtreturndate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtreturndate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtdeliveryno.Text != string.Empty)
				sbFilterExpression.AppendFormat("deliveryno like '%{0}%' AND ", txtdeliveryno.Text);
		
			if (txtrettype.Text != string.Empty)
				sbFilterExpression.AppendFormat("rettype like '%{0}%' AND ", txtrettype.Text);
		
			if (txtxtype.Text != string.Empty)
				sbFilterExpression.AppendFormat("xtype like '%{0}%' AND ", txtxtype.Text);
		
			if (txtba205gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba205gkey like '%{0}%' AND ", txtba205gkey.Text);
		
			if (txtpickupdate.Text != string.Empty)
			sbFilterExpression.AppendFormat("pickupdate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtpickupdate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtpickupdate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtcanceldate.Text != string.Empty)
			sbFilterExpression.AppendFormat("canceldate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtcanceldate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtcanceldate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtba100gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba100gkey like '%{0}%' AND ", txtba100gkey.Text);
		
			if (txtba102gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba102gkey like '%{0}%' AND ", txtba102gkey.Text);
		
			if (txtba103gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba103gkey like '%{0}%' AND ", txtba103gkey.Text);
		
			if (txtba119gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba119gkey like '%{0}%' AND ", txtba119gkey.Text);
		
			if (txtba118gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba118gkey like '%{0}%' AND ", txtba118gkey.Text);
		
			if (txtba121gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba121gkey like '%{0}%' AND ", txtba121gkey.Text);
		
			if (txtba104gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba104gkey like '%{0}%' AND ", txtba104gkey.Text);
		
			if (txtba209gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba209gkey like '%{0}%' AND ", txtba209gkey.Text);
		
			if (txtreturnamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("returnamt = {0} AND ", txtreturnamt.Text);
		
			if (txtcanadaamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("canadaamt = {0} AND ", txtcanadaamt.Text);
		
			if (txtfreightamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("freightamt = {0} AND ", txtfreightamt.Text);
		
			if (txtproceamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("proceamt = {0} AND ", txtproceamt.Text);
		
			if (txtinsuredamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("insuredamt = {0} AND ", txtinsuredamt.Text);
		
			if (txtpickupamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("pickupamt = {0} AND ", txtpickupamt.Text);
		
			if (txtdiscountamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("discountamt = {0} AND ", txtdiscountamt.Text);
		
			if (txtvouchersamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("vouchersamt = {0} AND ", txtvouchersamt.Text);
		
			if (txtreservatamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("reservatamt = {0} AND ", txtreservatamt.Text);
		
			if (txtactivityamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("activityamt = {0} AND ", txtactivityamt.Text);
		
			if (txttotalfreight.Text != string.Empty)
				sbFilterExpression.AppendFormat("totalfreight = {0} AND ", txttotalfreight.Text);
		
			if (txttotaltreatment.Text != string.Empty)
				sbFilterExpression.AppendFormat("totaltreatment = {0} AND ", txttotaltreatment.Text);
		
			if (txttotalinsurance.Text != string.Empty)
				sbFilterExpression.AppendFormat("totalinsurance = {0} AND ", txttotalinsurance.Text);
		
			if (txttotalamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("totalamt = {0} AND ", txttotalamt.Text);
		
			if (txtpairs.Text != string.Empty)
				sbFilterExpression.AppendFormat("pairs = {0} AND ", txtpairs.Text);
		
			if (txtremark.Text != string.Empty)
				sbFilterExpression.AppendFormat("remark like '%{0}%' AND ", txtremark.Text);
		
			if (txtba005gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba005gkey like '%{0}%' AND ", txtba005gkey.Text);
		
			if (txtmodifydate.Text != string.Empty)
			sbFilterExpression.AppendFormat("modifydate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtmodifydate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtmodifydate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtrevisedate.Text != string.Empty)
			sbFilterExpression.AppendFormat("revisedate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtrevisedate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtrevisedate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtapprove.Text != string.Empty)
				sbFilterExpression.AppendFormat("approve like '%{0}%' AND ", txtapprove.Text);
		
			if (txtaes101gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("aes101gkey like '%{0}%' AND ", txtaes101gkey.Text);
		
			if (txtses101gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ses101gkey like '%{0}%' AND ", txtses101gkey.Text);
		
			if (txtes101gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("es101gkey like '%{0}%' AND ", txtes101gkey.Text);
		
			if (txtreplication_create.Text != string.Empty)
			sbFilterExpression.AppendFormat("replication_create BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtreplication_create.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtreplication_create.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtreplication_update.Text != string.Empty)
			sbFilterExpression.AppendFormat("replication_update BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtreplication_update.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtreplication_update.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtrownum.Text != string.Empty)
				sbFilterExpression.AppendFormat("rownum = {0} AND ", txtrownum.Text);
		
			if (txtaddproceamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("addproceamt = {0} AND ", txtaddproceamt.Text);
		
			if (txtlossproceamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("lossproceamt = {0} AND ", txtlossproceamt.Text);
		
			if (txtvirementamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("virementamt = {0} AND ", txtvirementamt.Text);
		
			if (txtba040gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba040gkey like '%{0}%' AND ", txtba040gkey.Text);
		
			if (txtba040gkey1.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba040gkey1 like '%{0}%' AND ", txtba040gkey1.Text);
		
			if (txtreceivabledate.Text != string.Empty)
			sbFilterExpression.AppendFormat("receivabledate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtreceivabledate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtreceivabledate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtreceivableamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("receivableamt = {0} AND ", txtreceivableamt.Text);
		
			if (txtvirementdate.Text != string.Empty)
			sbFilterExpression.AppendFormat("virementdate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtvirementdate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtvirementdate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtsalesamt.Text != string.Empty)
				sbFilterExpression.AppendFormat("salesamt = {0} AND ", txtsalesamt.Text);
		
			if (txtcollchk.Text != string.Empty)
				sbFilterExpression.AppendFormat("collchk like '%{0}%' AND ", txtcollchk.Text);
		
			if (txtpayfreight.Text != string.Empty)
				sbFilterExpression.AppendFormat("payfreight = {0} AND ", txtpayfreight.Text);
		
			if (txtstrchk.Text != string.Empty)
				sbFilterExpression.AppendFormat("strchk like '%{0}%' AND ", txtstrchk.Text);
		
			if (txtnoamount.Text != string.Empty)
				sbFilterExpression.AppendFormat("noamount = {0} AND ", txtnoamount.Text);
		
			if (txttotalamount.Text != string.Empty)
				sbFilterExpression.AppendFormat("totalamount = {0} AND ", txttotalamount.Text);
		
			if (txtba101gkey.Text != string.Empty)
				sbFilterExpression.AppendFormat("ba101gkey like '%{0}%' AND ", txtba101gkey.Text);
		
			if (txtremittancedate.Text != string.Empty)
			sbFilterExpression.AppendFormat("remittancedate BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtremittancedate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtremittancedate.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
			if (txtremittancetime.Text != string.Empty)
			sbFilterExpression.AppendFormat("remittancetime BETWEEN '{0}' AND '{1}' AND ", Convert.ToDateTime(txtremittancetime.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(txtremittancetime.Text).AddDays(1).ToString("yyyy-MM-dd"));
		
                    if (sbFilterExpression.Length > 0)
                    {
	                    sbFilterExpression.Remove(sbFilterExpression.Length - 4, 4);
	                    //this.FilterExpression = "WHERE " + this.FilterExpression.Substring(0, this.FilterExpression.Length - 4);
						//sbFilterExpression.Insert(0, "WHERE ");
	                    this.FilterExpression = sbFilterExpression.ToString();
					}

                    if (SearchEvent != null)
                        SearchEvent(this, e);
                }
            }
            catch (Exception objEx)
            {
            }
        }
        
        protected void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all search text
			Control panelControl = this.UpdatePanel1.ContentTemplateContainer.FindControl("pnlSearch1");
			foreach (Control ctrl in panelControl.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txt = (TextBox)ctrl;
                    txt.Text = string.Empty;
                }
				else if (ctrl is DropDownList)
				{
					DropDownList ddl = (DropDownList)ctrl;
					ddl.SelectedIndex = 0;
				}
            }

            // Raise Search Event
            this.FilterExpression = string.Empty;
            if (SearchEvent != null)
                SearchEvent(this, e);
        }
        #endregion
    }
}
  