using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix
{
    public partial class MainPage4CustPortal : System.Web.UI.Page
    {
        DataAccess.Masters.MasterCustomer cusobj = new DataAccess.Masters.MasterCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccess.Masters.MasterCustomer cusobj = new DataAccess.Masters.MasterCustomer();


            //Schedule Login
            if (Request.QueryString.ToString().Contains("username"))
            {
                Session["username"] = Request.QueryString["username"];
            }
            if (Request.QueryString.ToString().Contains("LoginDivisionName"))
            {
                Session["LoginDivisionName"] = Request.QueryString["LoginDivisionName"];
            }
            if (Request.QueryString.ToString().Contains("webgroupid"))
            {
                Session["webgroupid"] = Request.QueryString["webgroupid"];
            }

            if (Request.QueryString.ToString().Contains("Password_cs"))
            {
                Session["Password_cs"] = Request.QueryString["Password_cs"];
            }


            if (Request.QueryString.ToString().Contains("LoginDivisionId"))
            {
                Session["LoginDivisionId"] = Request.QueryString["LoginDivisionId"];
            }
            if (Request.QueryString.ToString().Contains("uid"))
            {
                Session["webgroupid"] = Request.QueryString["uid"];
            }



            if (Session["username"] != null)
            {
                div_user.InnerText = Session["username"].ToString();
            }

            if (Session["LoginDivisionName"] != null)
            {
                lblcompany.Text = Session["LoginDivisionName"].ToString();
            }

            
            DataAccess.Masters.MasterDivision masterObj = new DataAccess.Masters.MasterDivision();
            DataTable dtlogo = masterObj.Getlogo(Convert.ToInt32(Session["LoginDivisionId"]));
            if (dtlogo.Rows.Count > 0)
            {
                byte[] logoimageBytes = ((byte[])dtlogo.Rows[0]["dlogo"]);
                string base64String = Convert.ToBase64String(logoimageBytes);
                img_Logo.ImageUrl = "data:image/png;base64," + base64String;
            }
            string str = Request.QueryString["uid"].ToString();
            Session["str"] = str.ToString();
            DataTable dt = new DataTable();

            dt = cusobj.RetrieveCustGroupDetails((Session["webcuspanid"].ToString()));
            if (dt.Rows.Count > 0)
            {
                div_name.InnerText = dt.Rows[0][0].ToString();
               // Session["Groupname"] = dt.Rows[0][0].ToString();
            }

        }
        protected void lnkhome_Click(object sender, EventArgs e)
        {
            //  Response.Redirect("MainPage.aspx?lgs='1'&uid=" + Session["webgroupid"].ToString());
            frmContent.Attributes["src"] = "Default.aspx?lgs='1'&uid=" + Session["webgroupid"].ToString();
            //frmContent.Attributes["src"] = "Default.aspx";
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            if (Session["Password_cs"] != null && Session["username"] != null)
            {
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else
            {
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("UserLogin.aspx");
            }
        }

        protected void lnkchange_Click(object sender, EventArgs e)
        {
            this.popupChangePassword.Show();
            txtcustomername.Text = "";
            if (Session["username"] != null)
            {
                txtcustomername.Text = Session["username"].ToString();
            }
            txtoldpassword.Text = "";
            txtnewpassword.Text = "";
            txtoldpassword.Focus();
        }

        protected void txtoldpassword_TextChanged(object sender, EventArgs e)
        {
          //  int WebgroupId = Convert.ToInt32(Session["webgroupid"]);
          ////  DataTable dt = cusobj.OldpwdAlreadyVerify(WebgroupId, txtcustomername.Text, txtoldpassword.Text);
          //  if (dt.Rows.Count > 0)
          //  {
          //      txtnewpassword.Focus();
          //      this.popupChangePassword.Show();
          //  }
          //  else
          //  {
          //      ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Given old password doesn''t match');", true);
          //      txtoldpassword.Text = "";
          //      txtoldpassword.Focus();
          //      this.popupChangePassword.Show();
          //      return;
          //  }
        }

        protected void btnchangepwd_Click(object sender, EventArgs e)
        {
            int WebgroupId = Convert.ToInt32(Session["webgroupid"]);
            if (txtcustomername.Text == "" || WebgroupId == 0 || WebgroupId.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Somthing missing Contact Admin');", true);
                this.popupChangePassword.Show();
                return;
            }
            else if (txtoldpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Enter OldPassword');", true);
                this.popupChangePassword.Show();
                txtoldpassword.Focus();
                return;
            }
            else if (txtnewpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('Enter NewPassword');", true);
                this.popupChangePassword.Show();
                txtnewpassword.Focus();
                return;
            }
            else
            {
                //string Result = cusobj.ChangePassword(WebgroupId, txtcustomername.Text, txtoldpassword.Text, txtnewpassword.Text);
                //if (Result == "Password has been Changed")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('" + Result + "');", true);
                //    Clear();
                //    return;
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Mainpage", "alertify.alert('" + Result + "');", true);
                //    return;
                //}
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtoldpassword.Focus();
            txtoldpassword.Text = "";
            txtnewpassword.Text = "";
        }
    }
}