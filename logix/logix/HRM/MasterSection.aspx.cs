using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class MasterSection : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.PAYROLL.MasterSection obj_da_Section = new DataAccess.PAYROLL.MasterSection();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_View, btn_delete);
            }
            if (!IsPostBack)
            {
               // btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txt_Seccode.Focus();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Seccode~txt_Limit~txt_Name";
                str_MsgLists = "Section Code~Max Limit Amount~Section Name";
                str_DataType = "String~Double~String";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
            }
            txt_Limit.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'amount')");
        }
        private void Fn_GetDetail()
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Section.getsectiondtls(Fn_GetSectionid());
            if (obj_dt.Rows.Count > 0)
            {
                txt_Limit.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["maxlimit"]);
                txt_Name.Text = obj_dt.Rows[0]["secname"].ToString();

               // btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";

                btn_delete.Enabled = true;
            }
            else
            {
                txt_Name.Text = "";
                txt_Limit.Text = "";
            }
        }

        protected void txt_Seccode_TextChanged(object sender, EventArgs e)
        {
            if (txt_Seccode.Text.TrimEnd().Length > 0)
            {
                Fn_GetDetail();
            }
            //btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.ToolTip == "Save")
            {
                obj_da_Section.InsertMasterSection(txt_Seccode.Text, txt_Name.Text, double.Parse(txt_Limit.Text));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 807, 1, int.Parse(Session["LoginBranchid"].ToString()), "0/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                Fn_Clear();
            }
            else if (btn_save.ToolTip == "Update")
            {
                int int_Secid = Fn_GetSectionid();
                obj_da_Section.UpdMasterSection(txt_Seccode.Text, txt_Name.Text, double.Parse(txt_Limit.Text), int_Secid);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 807, 2, int.Parse(Session["LoginBranchid"].ToString()), int_Secid + "/U");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                Fn_Clear();
            }
           // btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        private void Fn_Clear()
        {
            txt_Seccode.Text = "";
            txt_Name.Text = "";
            txt_Limit.Text = "";
         //   btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_delete.Enabled = false;
           
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_Seccode.Text.TrimEnd().Length > 0)
            {
                int int_Secid = Fn_GetSectionid();
                obj_da_Section.DelMasterSection(int_Secid);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 807, 4, int.Parse(Session["LoginBranchid"].ToString()), int_Secid + "/D");
                ScriptManager.RegisterStartupScript(btn_delete, typeof(Button), "HRM", "alertify.alert('Details Deleted');", true);
                Fn_Clear();
             //   btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_Seccode.Focus();
                Fn_Clear();
               // btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
        }
        private int Fn_GetSectionid()
        {
            int int_Sectionid = 0;
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Section.getSecid(txt_Seccode.Text);
            if (obj_dt.Rows.Count > 0)
            {
                int_Sectionid = int.Parse(obj_dt.Rows[0]["secid"].ToString());
            }
            return int_Sectionid;
            
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Str_RptName = "/Payroll/" + "RptMastersection.rpt";
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
            Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 807, "Job", "", "", Session["StrTranType"].ToString());

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }   

    }
}
