using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class Confirmation : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view,null);
            }
            try 
            { 
            if (!IsPostBack)
            {
                txt_Empcode.Focus();
                DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
                txt_doj.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
                btn_save.Attributes.Add("onclick", "return IsDate('txt_doj');");
                btn_save.Enabled = false;
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        private void Fn_GetDetail()
        {
            try
            {
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Employee.GetDOCDetail(txt_Empcode.Text);
            if (obj_dt.Rows.Count > 0)
            {
                txt_EmpName.Text = obj_dt.Rows[0][1].ToString();
                txt_dept.Text = obj_dt.Rows[0][3].ToString();
                txt_designation.Text = obj_dt.Rows[0][4].ToString();
                txt_location.Text = obj_dt.Rows[0][5].ToString();
                txt_division.Text = obj_dt.Rows[0][6].ToString();
                hid_Empid.Value = obj_dt.Rows[0][2].ToString();
                if (obj_dt.Rows[0][0].ToString().TrimEnd().Length > 0)
                {
                    txt_doj.Text = Utility.fn_ConvertDate(obj_dt.Rows[0][0].ToString());
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                }
                txt_doj.Enabled = true;
                btn_save.Enabled = true;
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Correct Employee Code');", true);
                Fn_Clear();
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            if (txt_Empcode.Text.ToString().TrimEnd().Length > 0)
            {
                Fn_GetDetail();
            }
        }
        private void Fn_Clear()
        {
            txt_Empcode.Text = "";
            txt_EmpName.Text = "";
            txt_location.Text = "";
            txt_division.Text = "";
            txt_dept.Text = "";
            txt_designation.Text = "";
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            txt_doj.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
            txt_doj.Enabled = false;
            btn_save.Enabled = false;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if(btn_cancel.ToolTip=="Cancel")
            {
                 Fn_Clear();
                 txt_Empcode.Focus();
                 //btn_cancel.ToolTip = "Back";
                 btn_cancel.ToolTip = "Back";
                 btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }
           
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
            DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
           
            obj_da_Employee.UpdDOC(txt_Empcode.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_doj.Text)));
            obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 174, 1, int.Parse(Session["LoginBranchid"].ToString()), "/ S");
            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Detail Saved');", true);
            Fn_Clear();
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (txt_Empcode.Text.Trim().Length > 0)
            {
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                Str_RptName = "HRConfimation.rpt";
                Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}=" + hid_Empid.Value.ToString();
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 174, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
                Session["str_sp"] = Str_sp;
                Session["str_sfs"] = Str_sf;
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 174, "Job", "", "", Session["StrTranType"].ToString());

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