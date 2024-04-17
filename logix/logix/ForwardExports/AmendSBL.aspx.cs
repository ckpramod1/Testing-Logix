using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Drawing;
namespace logix.ForwardExports
{
    public partial class AmendSBL : System.Web.UI.Page
    {
        DataAccess.ForwardingExports.MateReceipt Amendobj = new DataAccess.ForwardingExports.MateReceipt();
        DataAccess.ForwardingExports.ShippingBill ShippingBillobj = new DataAccess.ForwardingExports.ShippingBill();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataTable dt = new DataTable();
       string  oldblno , newblno ;

       int int_divisionid;
       int int_branchid;
       int int_empid;
       string str_TranType;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }

            if(!IsPostBack )
            {
                try
                {
                    //Session["LoginDivisionId"] = 1;
                    //Session["LoginBranchid"] = 1;
                    int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    txtjob.Attributes.Add("onkeypress", "return numerical()");
                    string str_CtrlLists, str_MsgLists, str_DataType;
                    str_CtrlLists = "txtjob~ddlamendbl~txtamendbl";
                    str_MsgLists = "Job #~SBL #~Amend SBL #";
                    str_DataType = "String~DropDown~String";
                    btnamendbl.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "')");
                    ddlamendbl.Items.Clear();
                    ddlamendbl.Items.Add("SBL Number");
                    btnamendbl.Enabled = false;
                    btnamendbl.ForeColor = System.Drawing.Color.Gray;
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }

            else if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }

        }

        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;

        }

        protected void txtjob_TextChanged(object sender, EventArgs e)
        {
            try
            { 
            if(txtjob.Text !="")
            {
                ddlamendbl.Items.Clear();
                btnamendbl.Enabled = true;
                btnamendbl.ForeColor = System.Drawing.Color.White;
                dt = Amendobj.GetSBno4Amend(Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"]));
                if(dt.Rows.Count>0)
                {
                    if (ddlamendbl.SelectedIndex != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ddlamendbl.Items.Add(dt.Rows[i]["sbno"].ToString());
                        }
                    }
                    else
                    {
                        ddlamendbl.Items.Clear();
                        ddlamendbl.Items.Add("SBL Number");
                    }
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('JOB Number Not Availabe');", true);
                    txtjob.Text = "";
                    txtjob.Focus();
                    ddlamendbl.Items.Clear();
                    ddlamendbl.Items.Add("SBL Number");
                    return;
                }
                //btnCancel.Text = "Cancel";

                btnCancel.ToolTip = "Cancel";
                btnCancel1.Attributes["calss"] = "btn ico-cancel";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('JOB Number is Empty');", true);
                txtjob.Focus();
            }
           }
           catch (Exception ex)
            {
                string message = ex.Message.ToString();
               ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                txtjob.Text = "";
                ddlamendbl.Items.Clear();
                ddlamendbl.Items.Add("SBL Number");
                txtamendbl.Text = "";
               // btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";
                btnamendbl.Enabled = false;
                btnamendbl.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
               // this.Response.End();

                if (Session["StrTranType"].ToString() == "FE")
                {
                    // headerlable1.InnerText = "OceanExports";
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");

                }
            }
        }

        protected void btnamendbl_Click(object sender, EventArgs e)
        {
            try
            {
                checkdata();
                Amendobj.UpdAmendSBL(ddlamendbl.SelectedValue, txtamendbl.Text.ToUpper(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
                ScriptManager.RegisterStartupScript(btnamendbl, typeof(TextBox), "AmendSBL", "alertify.alert('Shipping Bill Changed to " + txtamendbl.Text + "');", true);
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1271, 1, Convert.ToInt32(Session["LoginBranchid"]), ddlamendbl.SelectedValue + "/" + txtamendbl.Text);
                txtamendbl.Text = "";
                ddlamendbl.Items.Clear();
                ddlamendbl.Items.Add("SBL Number");
                txtjob.Text = "";
                btnamendbl.Enabled = true;
                btnamendbl.ForeColor = System.Drawing.Color.White;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
               ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
               // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }


        }
        private void checkdata()
        {
            try
            {
                if (txtjob.Text == "" || txtjob.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(btnamendbl, typeof(TextBox), "AmendSBL", "alertify.alert('Enter a Valid Job #');", true);
                    txtjob.Focus();
                }
                if (ddlamendbl.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(btnamendbl, typeof(TextBox), "AmendSBL", "alertify.alert('Select Shipping Bill #');", true);
                    ddlamendbl.Focus();
                }
                if (txtamendbl.Text == "" || txtamendbl.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(btnamendbl, typeof(TextBox), "AmendSBL", "alertify.alert('Enter a Valid Shipping Bill #');", true);
                    txtamendbl.Focus();
                }
                if (ShippingBillobj.CheckShipBillNo(txtamendbl.Text, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"])) != 0)
                {
                    ScriptManager.RegisterStartupScript(btnamendbl, typeof(TextBox), "AmendSBL", "alertify.alert('Shipping Bill #:" + txtamendbl.Text + " Number Already Exists');", true);
                    txtjob.Focus();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
               // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('../Login.aspx','_top');", true);
            }

        }


        protected void logdetails_Click(object sender, EventArgs e)
        {
            try
            {
                loadgridlog();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            if (Session["StrTranType"] != null)
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1271, "job", txtjob.Text, txtjob.Text, Session["StrTranType"].ToString());
                }
                              
            }
            
            if (txtjob.Text != "")
            {
                JobInput.Text = txtjob.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }
    }
}