using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class LateAttendance : System.Web.UI.Page
    {
        DataAccess.Payroll.LWF obj_da_LWF = new DataAccess.Payroll.LWF();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            try
            {
                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    string str_Uiid = "";
                    str_Uiid = Request.QueryString["UIID"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, null);
                }

                if (!IsPostBack)
                {
                   
                    ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
                    txt_year.Text = obj_da_Log.GetDate().Year.ToString();
                    txt_Empcode.Focus();
                    string str_CtrlLists, str_MsgLists, str_DataType;
                    str_CtrlLists = "txt_Empcode~ddl_Monrh~txt_year~txt_day~txt_remark";
                    str_MsgLists = "EmpCode~Month~Year~Deducted Day~Remark";
                    str_DataType = "String~DropDown~Integer~Integer~String";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    Grd_Late.DataSource = new DataTable();
                    Grd_Late.DataBind();
                    Session["Packages"] = lbl_Header.Text;
                }

                if (Session["empcode"]!=null)
                {
                    txt_Empcode.Text = Session["empcode"].ToString();
                    txt_Empcode_TextChanged(sender, e);
                    Session["empcode"] = null;
                }

                //txt_Empcode.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_day.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
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
                if (txt_Empcode.Text.TrimEnd().Length > 0)
                {
                    obj_dt = obj_da_LWF.Getemdtl(txt_Empcode.Text, int.Parse(txt_year.Text));
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_EmpName.Text = obj_dt.Rows[0]["empname"].ToString();
                        txt_doj.Text = obj_dt.Rows[0]["doj"].ToString();
                        txt_locatiom.Text = obj_dt.Rows[0]["portname"].ToString();
                        txt_dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                        txt_desg.Text = obj_dt.Rows[0]["designame"].ToString();
                        txt_CL.Text = DBNull.Value.Equals(obj_dt.Rows[0]["clbalance"]) ? "0" : obj_dt.Rows[0]["clbalance"].ToString();
                        txt_EL.Text = DBNull.Value.Equals(obj_dt.Rows[0]["elbalance"]) ? "0" : obj_dt.Rows[0]["elbalance"].ToString();
                        txt_SL.Text = DBNull.Value.Equals(obj_dt.Rows[0]["slbalance"]) ? "0" : obj_dt.Rows[0]["slbalance"].ToString();
                        Fn_FillGrid();
                        //btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter the Correct Employee Code');", true);
                        txt_Empcode.Text = "";
                        txt_Empcode.Focus();
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_FillGrid()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_LWF.GetOneEmpDtls(txt_Empcode.Text);
                Grd_Late.DataSource = obj_dt;
                Grd_Late.DataBind();
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            try { 
                
            if (txt_year.Text.TrimEnd().Length > 0)
            {
                Fn_GetDetail();
                txt_day.Focus();
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            else
            {
                ScriptManager.RegisterStartupScript(txt_Empcode, typeof(TextBox), "HRM", "alertify.alert('Please Enter the Year');", true);
                txt_year.Text = "";
                txt_year.Focus();
                return;
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try { 
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            if (double.Parse(txt_day.Text) > 31)
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Enter Correct Days for PerMonth');", true);
                txt_day.Focus();
                return;
            }
            if (btn_save.ToolTip == "Save")
            {
                obj_da_LWF.InsLwfDtls(txt_Empcode.Text, int.Parse(ddl_Monrh.SelectedItem.Value), int.Parse(txt_year.Text), int.Parse(txt_day.Text), txt_remark.Text);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 972, 1, int.Parse(Session["LoginBranchid"].ToString()), "/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
            }
            else if (btn_save.ToolTip == "Update")
            {
                obj_da_LWF.UpdLwfDls(int.Parse(hid_id.Value.ToString()), int.Parse(ddl_Monrh.SelectedItem.Value), int.Parse(txt_year.Text), int.Parse(txt_day.Text), txt_remark.Text);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 972, 2, int.Parse(Session["LoginBranchid"].ToString()), "/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
            }
            Fn_FillGrid();
            ClearNew();
           // Fn_Clear();
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

        public void ClearNew()
        {
            ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
            txt_year.Text = obj_da_Log.GetDate().Year.ToString();
            txt_day.Text = "";
            txt_remark.Text = "";
        }

        protected void Grd_Late_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 

            hid_id.Value = Grd_Late.SelectedDataKey.Values[1].ToString();
            if (hid_confirm.Value.ToString() == "N")
            {
                //btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                txt_year.Text = Grd_Late.SelectedRow.Cells[1].Text;
                txt_day.Text = Grd_Late.SelectedRow.Cells[2].Text;
                txt_remark.Text = Grd_Late.SelectedRow.Cells[3].Text;
                ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByText(Grd_Late.SelectedRow.Cells[0].Text.ToUpper().TrimEnd()));

            }
            else if (hid_confirm.Value.ToString() == "Y")
            {
                obj_da_LWF.DelDtls(int.Parse(Grd_Late.SelectedDataKey.Values[1].ToString()));
                Fn_FillGrid();
                txt_day.Text = "";
                txt_remark.Text = "";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Detail Deleted');", true);
                return;
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

        private void Fn_Clear()
        {
            txt_Empcode.Text = "";
            txt_EmpName.Text = "";
            txt_doj.Text = "";
            txt_locatiom.Text = "";
            txt_dept.Text = "";
            txt_desg.Text = "";
            txt_CL.Text = "";
            txt_EL.Text = "";
            txt_SL.Text = "";
            txt_day.Text = "";
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";

            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
            txt_year.Text = obj_da_Log.GetDate().Year.ToString();

            Grd_Late.DataSource = new DataTable();
            Grd_Late.DataBind();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_Empcode.Focus();
                txt_remark.Text = "";
                Fn_Clear();
                //btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }

        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            //Popup_Emp.Show();
            //iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx";
            Response.Redirect("EmployeeFind.aspx");
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try { 
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "Payroll" + "//rptHRLateAttn.rpt";
            if (txt_Empcode.Text.TrimEnd() == "")
            {
                Str_sp = "Frm=" + ddl_Monrh.SelectedItem.Text + "~to=" + txt_year.Text;
                Str_sf = "{lwfattn.month}=" + ddl_Monrh.SelectedValue.ToString() + " and {lwfattn.year}=" + txt_year.Text;
            }
            else
            {
                Str_sp = "Frm=" + ddl_Monrh.SelectedItem.Text + "~to=" + txt_year.Text;
                Str_sf = "{lwfattn.month}=" + ddl_Monrh.SelectedValue.ToString() + " and {lwfattn.year}=" + txt_year.Text + " and {lwfattn.empcode}=\"" + txt_Empcode.Text + "\"";
            }
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 972, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/View");   
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

        protected void Grd_Late_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Late, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 972, "Job", "", "", Session["StrTranType"].ToString());

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