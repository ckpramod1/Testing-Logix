using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public CustomerDataAccess.RegCustomer cusobj = new CustomerDataAccess.RegCustomer();
        public static string password;
        DataTable Dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            
            Dt = cusobj.SelCusLoginDet(Session["username"].ToString());
            if (Dt.Rows.Count > 0)
            {
                txtUserName.Text = Dt.Rows[0]["username"].ToString();
                password = Dt.Rows[0]["pwd"].ToString();
            }
            //if (!IsPostBack)
            //    logixCS.SetFocus(this.Page, txtPassword);
        }


        protected void BtnChange_Click(object sender, EventArgs e)
        {
            //Dt = cusobj.SelCusLoginDet(Session["username"].ToString());
            //if (Dt.Rows.Count > 0)
            //{
            //    txtUserName.Text = Dt.Rows[0]["username"].ToString();
            //    password = Dt.Rows[0]["pwd"].ToString();
            //}
            if (password == txtPassword.Text)
            {
                if (txtNewpwd.Text == txtConfpwd.Text)
                {
                    cusobj.InsWebCustLogDtl(int.Parse(Session["webgroupid"].ToString()), CustomerDataAccess.RegCustomer.EventType.ChangePassword, DateTime.Now, txtConfpwd.Text);
                    cusobj.UpdCusPassword(txtUserName.Text, txtConfpwd.Text);
                    LBLStatus.Text = "Changed";
                }
                else
                    LBLStatus.Text = "New and Confirm Password's are Incorrect";
            }
            else
                LBLStatus.Text = "Password's are Incorrect";

           // logixCS.SetFocus(this.Page, txtPassword);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (BtnCancel.Text == "Cancel")
            {
                txtUserName.Text = Session["username"].ToString();
                txtPassword.Text = "";
                txtNewpwd.Text = "";
                txtConfpwd.Text = "";
                LBLStatus.Text = "";
               // logixCS.SetFocus(this.Page, txtPassword);
                BtnCancel.Text = "Back";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}