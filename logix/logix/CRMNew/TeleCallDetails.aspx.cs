using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.CRM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataAccess.CRMNew.MasterCustomerProspective objCust = new DataAccess.CRMNew.MasterCustomerProspective();
        
        int custid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if(!IsPostBack)
            {
              //custid = Convert.ToInt32(Request.QueryString["custid"]);
              //txtCustName.Text = objCust.GetCustomername(custid);
              btnCancel.Text = "Cancel";
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if(btnsave.Text=="Save")
            {
                custid = Convert.ToInt32(Request.QueryString["custid"]);
                objCust.CustTeleCast(custid, txtPretext.Text);               
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "TeleCallDetails", "alertify.alert('Details Saved...');", true);
                btnCancel.Text = "Cancel";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if( btnCancel.Text == "Cancel")
            {
                txtCustName.Text = "";
                txtPretext.Text = "";
                btnCancel.Text = "Back";
            }
            else
            {
                this.Response.End();
            }
        }
    }
}