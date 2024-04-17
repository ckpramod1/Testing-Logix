using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class ELEncashed : System.Web.UI.Page
    {
        DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        Boolean blnErr;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
            }
            try
            {
                if (!IsPostBack)
                {
                    btn_save.Enabled = false;
                    btn_save.ForeColor = System.Drawing.Color.Gray;
                   
                    txt_claimedon.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
                    txt_settledon.Text = txt_claimedon.Text;
                    hid_date.Value = txt_settledon.Text;
                    string str_CtrlLists, str_MsgLists, str_DataType;
                    txt_Empcode.Focus();
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    str_CtrlLists = "txt_Empcode~txt_Encash~txt_amount";
                    str_MsgLists = "EmpCode~Encashed Days~Amount";
                    str_DataType = "String~Double~Double";
                    // btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_claimedon~txt_settledon','Claimed On Date Should be Lessthan Settled On Date');");
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                }
                //txt_Empcode.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_Encash.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_amount.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Weights')");
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
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.SelForPermission(txt_Empcode.Text);
                if (obj_dt.Rows.Count > 0)
                {
                    DataAccess.Payroll.Details obj_da_Payroll = new DataAccess.Payroll.Details();
                    DataAccess.HR.Attendance obj_da_Attendance = new DataAccess.HR.Attendance();
                    hid_empid.Value = obj_dt.Rows[0][0].ToString();
                    int int_Empid = int.Parse(obj_dt.Rows[0][0].ToString());
                    obj_dt = obj_da_Payroll.GetEmpDetails(int_Empid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_EmpName.Text = obj_dt.Rows[0][0].ToString();
                        txt_dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                        txt_designation.Text = obj_dt.Rows[0]["designame"].ToString();
                        txt_location.Text = obj_dt.Rows[0]["portname"].ToString();
                        txt_division.Text = obj_dt.Rows[0]["divisionname"].ToString();
                        btn_save.Enabled = true;
                        btn_save.ForeColor = System.Drawing.Color.White;
                    }
                    //  btn_save.Enabled = true;

                    obj_dt = obj_da_Attendance.SelEmpClaimDtls(int_Empid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_amount.Text = string.Format("{0:0.0}", obj_dt.Rows[0]["amount"]);
                        txt_claimedon.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["claimedon"].ToString());
                        txt_settledon.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["seton"].ToString());
                    }

                    obj_dt = obj_da_Attendance.SelEmpLevBalance(int_Empid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_CL.Text = obj_dt.Rows[0][2].ToString();
                        txt_SL.Text = obj_dt.Rows[0][3].ToString();
                        txt_EL.Text = obj_dt.Rows[0][4].ToString();
                        if (!DBNull.Value.Equals(obj_dt.Rows[0][8]))
                        {
                            txt_Encash.Text = obj_dt.Rows[0][8].ToString();
                            //btn_save.Enabled = true;
                            //btn_save.ForeColor = System.Drawing.Color.White;
                            //btn_save.Text = "Update";
                            btn_save.ToolTip = "Update";
                            btn_save1.Attributes["class"] = "btn btn-update1";
                        }
                        if (!DBNull.Value.Equals(obj_dt.Rows[0][9]))
                        {
                            txt_claimedon.Text = Utility.fn_ConvertDate(obj_dt.Rows[0][9].ToString());

                        }
                        else
                        {
                            txt_claimedon.Text = hid_date.Value.ToString();
                        }
                    }
                    else
                    {
                        txt_CL.Text = "";
                        txt_SL.Text = "";
                        txt_EL.Text = "";
                        txt_Encash.Text = "";
                        txt_claimedon.Text = hid_date.Value.ToString();
                        //btn_save.Enabled = true;
                        //btn_save.ForeColor = System.Drawing.Color.White;
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
                if (txt_Empcode.Text.TrimEnd().Length > 0)
                {
                    Fn_GetDetail();
                    txt_Encash.Focus();
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_Encash.Focus();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_EmpName.Text.Trim() == "" && txt_Encash.Text.Trim() == "")
                {
                    return;
                }
                DataAccess.HR.Attendance obj_da_Attendance = new DataAccess.HR.Attendance();
                DateTime dt_claim, dt_settled;
                dt_claim = DateTime.Parse(Utility.fn_ConvertDate(txt_claimedon.Text));
                dt_settled = DateTime.Parse(Utility.fn_ConvertDate(txt_settledon.Text));

                if (btn_save.ToolTip == "Save")
                {
                    obj_da_Attendance.UpdEmpEL(int.Parse(hid_empid.Value.ToString()), double.Parse(txt_Encash.Text), dt_claim);
                    obj_da_Employee.InsUpd4CmnClimDtls(txt_Empcode.Text, "LC", dt_claim, dt_settled, double.Parse(txt_amount.Text), 'Y');
                    obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 426, 1, Convert.ToInt32(Session["LoginBranchid"]), "" + txt_Empcode.Text + " / S");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                    //btn_save.Text = "Update";
                    btn_save.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                }
                else if (btn_save.ToolTip == "Update")
                {
                    checkdata();
                    if (blnErr == true)
                    {
                        blnErr = false;
                        return;
                    }


                    obj_da_Attendance.UpdEmpEL(int.Parse(hid_empid.Value.ToString()), double.Parse(txt_Encash.Text), dt_claim);
                    obj_da_Employee.InsUpd4CmnClimDtls(txt_Empcode.Text, "LC", dt_claim, dt_settled, double.Parse(txt_amount.Text), 'Y');
                    obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 426, 2, Convert.ToInt32(Session["LoginBranchid"]), "" + txt_Empcode.Text + " / U");
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);

                }
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
        private void Fn_Clear()
        {
            txt_Empcode.Focus();
            txt_Empcode.Text = "";
            txt_EmpName.Text = "";
            txt_location.Text = "";
            txt_division.Text = "";
            txt_dept.Text = "";
            txt_designation.Text = "";
            txt_CL.Text = "";
            txt_EL.Text = "";
            txt_SL.Text = "";
            txt_Encash.Text = "";
            txt_amount.Text = "";
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_save.Enabled = false;
            btn_save.ForeColor = System.Drawing.Color.Gray;

            txt_claimedon.Text = hid_date.Value.ToString();
            txt_settledon.Text = hid_date.Value.ToString();
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";

        }
        public void checkdata()
        {
            if (txt_Encash.Text == "")
            {
                blnErr = true;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('No of Day's Enchansed Can't be blank');", true);
                txt_Encash.Focus();
                return;
            }
            if (txt_amount.Text == "")
            {
                blnErr = true;
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Amount Can't be blank');", true);
                txt_amount.Focus();
                return;
            }

            DateTime fromdate, Todate;
            fromdate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_claimedon.Text));
            Todate = Convert.ToDateTime(Utility.fn_ConvertDate(txt_settledon.Text));

            if (fromdate >= Todate)
            {
                if (fromdate == Todate)
                {

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Claimed On Date Should be Lessthan Settled On Date');", true);
                    txt_claimedon.Focus();
                    blnErr = true;
                    return;
                }
            }

        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
            }
            else
            {
                this.Response.End();
            }

        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try
            {

                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                Str_RptName = "HREmpELList.rpt";
                if (txt_Empcode.Text.Trim().Length > 0)
                {
                    Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}=" + hid_empid.Value.ToString() + " and {EmpLeaveDetails.elclaimed}<>0 and not isnull({EmpLeaveDetails.elclaimed})";
                }
                else
                {
                    Str_sf = "{MasterEmployee.rol}=0 and {EmpLeaveDetails.elclaimed}<>0 and not isnull({EmpLeaveDetails.elclaimed})";
                }
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 426, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txt_Encash_TextChanged(object sender, EventArgs e)
        {
            if (txt_Encash.Text != "" )
            {
                if (int.Parse(txt_Encash.Text) > 45)
                {
                    ScriptManager.RegisterStartupScript(txt_Encash, typeof(TextBox), "HRM", "alertify.alert('Maximum 45 Days Only Allowed');", true);
                    txt_Encash.Focus();
                    txt_Encash.Text = "";
                    return;
                }
                else
                {

                }
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 426, "Job", "", "", Session["StrTranType"].ToString());

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