using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services.Description;


namespace logix.HRM
{
    public partial class Relieving : System.Web.UI.Page
    {

        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "GenerateLabelAfter();", true);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_log.GetDataBase(Ccode);
                obj_da_Employee.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               
            }

            try
            {
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, null,null);
            }
            if (!IsPostBack)
            {
                //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
                txt_dol.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
                hid_date.Value = txt_dol.Text;
                txt_Empcode.Focus();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Empcode~ddl_reason";
                str_MsgLists = "EmpCode~Reason";
                str_DataType = "String~DropDown";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_dol');");
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
            //DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Employee.GetEmp4Rel(txt_Empcode.Text);
            if (obj_dt.Rows.Count > 0)
            {
                txt_EmpName.Text = obj_dt.Rows[0][1].ToString();
                txt_dept.Text = obj_dt.Rows[0][2].ToString();
                txt_designation.Text = obj_dt.Rows[0][3].ToString();
                txt_location.Text = obj_dt.Rows[0][4].ToString();
                txt_division.Text = obj_dt.Rows[0][5].ToString();

                obj_dt = obj_da_Employee.GetROLDetail(txt_Empcode.Text);
                if (obj_dt.Rows.Count > 0)
                {
                    ddl_reason.SelectedValue = obj_dt.Rows[0][1].ToString();
                    if (obj_dt.Rows[0][0].ToString().Trim().Length > 0)
                    {
                        txt_dol.Text = Utility.fn_ConvertDate(obj_dt.Rows[0][0].ToString());
                         btn_save.Text = "Update";

                        btn_save.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn ico-update";
                    }
                    else
                    {
                        txt_dol.Text = hid_date.Value.ToString();
                    }
                   
                }
                btn_save.Enabled = true;
                txt_dol.Enabled = true;
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
           btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        private void Fn_Clear()
        {
            txt_Empcode.Text = "";
            txt_EmpName.Text = "";
            txt_location.Text = "";
            txt_division.Text = "";
            txt_dept.Text = "";
            txt_designation.Text = "";

            btn_save.Text = "Save";

            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

            txt_dol.Text = hid_date.Value.ToString();
            txt_dol.Enabled = true;
            ddl_reason.SelectedIndex = 0;
            btn_save.Enabled = false;
            btn_cancel.Text = "Back";

            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
           // txt_dol.Enabled = false;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if(btn_cancel.ToolTip=="Cancel")

            {
                Fn_Clear();
                txt_Empcode.Focus();
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
            //DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
            //DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();

            DateTime dt_DOL = DateTime.Parse(Utility.fn_ConvertDate(txt_dol.Text));
            if (btn_save.ToolTip == "Save")
            {
                obj_da_Employee.UpdReleave(txt_Empcode.Text, dt_DOL, int.Parse(ddl_reason.SelectedValue.ToString()));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 175, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text+"-"+txt_dol.Text+"/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_save.ToolTip == "Update")
            {
                obj_da_Employee.UpdReleave(txt_Empcode.Text, dt_DOL, int.Parse(ddl_reason.SelectedValue.ToString()));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 175, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "-" + txt_dol.Text + "/U");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
            Fn_Clear();
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
                //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 175, "Job", "", "", Session["StrTranType"].ToString());

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