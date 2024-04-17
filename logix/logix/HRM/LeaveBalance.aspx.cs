using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace logix.HRM
{
    public partial class LeaveBalance : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            try { 
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, null,null);
            }

            if (!IsPostBack)
            {
              
                btn_save.Enabled = false;
                txt_Empcode.Focus();
                lbl_Title.Text = "LEAVE BALANCE AS on " + "01-Jan-" + obj_da_log.GetDate().Year.ToString();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Empcode~txt_CL~txt_SL~txt_EL";
                str_MsgLists = "EmpCode~CL~SL~EL";
                str_DataType = "String~Double~Double~Double";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
            }
            txt_CL.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_CL')");
            txt_SL.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_SL')");
            txt_EL.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_EL')");
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
            obj_dt = obj_da_Employee.SelForPermission(txt_Empcode.Text);
            if (obj_dt.Rows.Count > 0)
            {
                DataAccess.Payroll.Details obj_da_Payroll = new DataAccess.Payroll.Details();
                DataAccess.HR.Attendance obj_da_Attendance = new DataAccess.HR.Attendance();
                hid_Empid.Value = obj_dt.Rows[0][0].ToString();
                int int_Empid = int.Parse(obj_dt.Rows[0][0].ToString());
                obj_dt = obj_da_Payroll.GetEmpDetails(int_Empid);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_EmpName.Text = obj_dt.Rows[0][0].ToString();
                    txt_dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                    txt_designation.Text = obj_dt.Rows[0]["designame"].ToString();
                    txt_location.Text = obj_dt.Rows[0]["portname"].ToString();
                    txt_division.Text = obj_dt.Rows[0]["divisionname"].ToString();
                }
                obj_dt = obj_da_Attendance.SelEmpLevBalance(int_Empid);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_CL.Text = obj_dt.Rows[0][2].ToString();
                    txt_SL.Text = obj_dt.Rows[0][3].ToString();
                    txt_EL.Text = obj_dt.Rows[0][4].ToString();
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    btn_save.Enabled = true;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Balance Details Already Exists');", true);
                }
                else
                {
                    txt_CL.Text ="";
                    txt_SL.Text = "";
                    txt_EL.Text = "";
                    btn_save.Enabled = true;
                }
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Correct Employee Code');", true);
                Fn_Clear();
            }
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

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Empcode.Text.ToString().TrimEnd().Length > 0)
                {
                    Fn_GetDetail();
                  
                   
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_CL.Focus();
        }
        private void Fn_Clear()
        {
            txt_Empcode.Text = "";
            txt_EmpName.Text = "";
            txt_location.Text = "";
            txt_division.Text = "";
            txt_dept.Text = "";
            txt_designation.Text = "";
            txt_CL.Text = "";
            txt_SL.Text = "";
            txt_EL.Text = "";
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
           
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try { 
            DataAccess.HR.Attendance obj_da_Attendance = new DataAccess.HR.Attendance();
            if (btn_save.ToolTip == "Save")
            {
                obj_da_Attendance.InsEmpLevBalance(int.Parse(hid_Empid.Value.ToString()), double.Parse(txt_CL.Text), double.Parse(txt_SL.Text), double.Parse(txt_EL.Text));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 298, 1, int.Parse(Session["LoginBranchid"].ToString()), "" + txt_Empcode.Text + " /Save");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_save.ToolTip == "Update")
            {
                obj_da_Attendance.UpdEmpLevBalance(int.Parse(hid_Empid.Value.ToString()), double.Parse(txt_CL.Text), double.Parse(txt_SL.Text), double.Parse(txt_EL.Text));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 298, 2, int.Parse(Session["LoginBranchid"].ToString()), "" + txt_Empcode.Text + " /Upd");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
            Fn_Clear();
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip=="Cancel")
            {
                Fn_Clear();
                txt_Empcode.Focus();
            }
            else
            {
                this.Response.End();
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 298, "Job", "", "", Session["StrTranType"].ToString());

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