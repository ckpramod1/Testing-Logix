using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class GradeDetails : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.PAYROLL.MasterSection obj_da_Section = new DataAccess.PAYROLL.MasterSection();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            try { 
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view,null);
            }
            if (!IsPostBack)
            {
                //txt_From.Text = "01/04/" + obj_da_Log.GetDate().AddYears(-1).Year.ToString();
               // txt_to.Text = "31/03/" + obj_da_Log.GetDate().Year.ToString(); ;
                cregrd();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_GradeName~txt_medical~txt_driverwages~txt_entertain";
                str_MsgLists = "GradeName~Medical~Driver Allowance~EA";
                str_DataType = "String~Double~Double~Double";
                btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_From~txt_to','Valid From Date Should be Lessthan Valid To Date');");
                txt_GradeName.Focus();
                Grd_Grade.DataSource = new DataTable();
                Grd_Grade.DataBind();
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_medical.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_medical')");
            txt_driverwages.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_driverwages')");
            txt_entertain.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'txt_entertain')");
        }


        protected void cregrd()
        {
            DateTime dtget1;
            DateTime logtime = obj_da_Log.GetDate();
            DateTime dtget;
            int year = Convert.ToInt32(logtime.Year);
            if (logtime.Month < 4)
            {
                dtget1 = Convert.ToDateTime(("04/01/" + (year - 1)));
                txt_From.Text = Utility.fn_ConvertDate(dtget1.ToShortDateString());
                dtget = Convert.ToDateTime("03/31/" + (year));
                txt_to.Text =Utility.fn_ConvertDate( dtget.ToShortDateString());
            }
            else
            {
                dtget1 = Convert.ToDateTime(("04/01/" + (year)));
                txt_From.Text = Utility.fn_ConvertDate(dtget1.ToShortDateString());
                dtget = Convert.ToDateTime(("03/31/" + (year + 1)));
                txt_to.Text =Utility.fn_ConvertDate( dtget.ToShortDateString());

            }
        }
        protected void txt_GradeName_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (txt_GradeName.Text.TrimEnd().Length > 0)
            {
                if (hid.Value.ToString() == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter Correct Grade');", true);
                    txt_GradeName.Text = "";
                    txt_GradeName.Focus();
                    return;
                }
                Fn_Getdetail();
                txt_medical.Focus();
                //btn_cancel.Text="Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }
        private void Fn_Getdetail()
        {
            try { 
            DataTable obj_dt = new DataTable();

            obj_dt = obj_da_Section.GradeSelDtls1(txt_GradeName.Text.TrimEnd());
            if (obj_dt.Rows.Count > 0)
            {
                Grd_Grade.DataSource = obj_dt;
                Grd_Grade.DataBind();
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }

        private void Fn_TxtEnable(bool Enable)
        {
            txt_GradeName.Enabled = Enable;
            txt_From.Enabled = Enable;
            txt_to.Enabled = Enable;
        }

        protected void Grd_Grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            hid_Gid.Value = Grd_Grade.SelectedDataKey.Values[0].ToString();
            if (hid_confirm.Value.ToString() == "N")
            {
                //btn_save.Text = "Update";
                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                txt_From.Text = Grd_Grade.SelectedRow.Cells[0].Text;
                txt_to.Text = Grd_Grade.SelectedRow.Cells[1].Text;
                txt_medical.Text = Grd_Grade.SelectedRow.Cells[2].Text;
                txt_driverwages.Text = Grd_Grade.SelectedRow.Cells[3].Text;
                txt_entertain.Text = Grd_Grade.SelectedRow.Cells[4].Text;
                Fn_TxtEnable(false);
            }
            else if (hid_confirm.Value.ToString() == "Y")
            {
                obj_da_Section.GradeDelDtls(int.Parse(Grd_Grade.SelectedDataKey.Values[0].ToString()));
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 974, 4, int.Parse(Session["LoginBranchid"].ToString()), txt_From.Text + "/" + txt_to.Text + "/D");
                Fn_Clear();
                Fn_Getdetail();
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
            txt_medical.Text = "";
            txt_driverwages.Text = "";
            txt_entertain.Text = "";
            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            txt_From.Text = "01/04/" + obj_da_Log.GetDate().AddYears(-1).Year.ToString();
            txt_to.Text = "31/03/" + obj_da_Log.GetDate().Year.ToString(); ;
            Fn_TxtEnable(true);
            Grd_Grade.DataSource = new DataTable();
            Grd_Grade.DataBind();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if(btn_cancel.ToolTip=="Cancel")
            {
            txt_GradeName.Focus();
            txt_GradeName.Text = "";
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

        protected void btn_view_Click(object sender, EventArgs e)
        {
            try { 
            DateTime dt_from, dt_to;
            dt_from = DateTime.Parse(Utility.fn_ConvertDate(txt_From.Text));
            dt_to = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "Payroll" + "//rptHRGradeDtls.rpt";
            Session["str_sp"] = "Frm=" + txt_From.Text + "~to=" + txt_to.Text;
            Session["str_sfs"] = " {GradeDetail.efrom}>=date('" + dt_from.Year + "," + dt_from.Month + "," + dt_from.Day + "') and {GradeDetail.eto}<=date('" + dt_to.Year + "," + dt_to.Month + "," + dt_to.Day + "')";
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 974, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
                ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
            //Session["str_sfs"] = Str_sf;
            //Session["str_sp"] = Str_sp;
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }       
        }
        protected void Empty_check()
        {
            if (txt_GradeName.Text.Trim() == "")
            {

                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Enter the Grade Name');", true);
                txt_GradeName.Text = "";
                txt_GradeName.Focus();
            }
            if(txt_medical.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Enter the Medical');", true);
                txt_medical.Focus();
                txt_medical.Text = "";
            }
            if (txt_entertain.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Enter the EA');", true);
                txt_entertain.Focus();
                txt_entertain.Text = "";
            }
            if (txt_driverwages.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Enter the Driver Allowance');", true);
                txt_driverwages.Focus();
                txt_driverwages.Text = "";
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            { 
            DataTable obj_dt = new DataTable();
            DateTime dt_From, dt_To;
            Empty_check();
            dt_From = DateTime.Parse(Utility.fn_ConvertDate(txt_From.Text));
            dt_To = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));
            if (dt_From.Year == dt_To.AddYears(-1).Year)
            {
                if (dt_From.Month == 4 && dt_To.Month == 3)
                {
                    if (btn_save.ToolTip == "Save")
                    {
                        obj_dt = obj_da_Section.GradeInsDtls(txt_GradeName.Text, double.Parse(txt_entertain.Text), double.Parse(txt_driverwages.Text), dt_From, dt_To, double.Parse(txt_medical.Text));
                        if (obj_dt.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Already Data Existed');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 974, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_From.Text + "/" + txt_to.Text + "/S");
                           Fn_Clear();
                            Fn_Getdetail();
                        }

                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        obj_da_Section.GradeUpdDtls(int.Parse(hid_Gid.Value.ToString()), double.Parse(txt_entertain.Text), double.Parse(txt_driverwages.Text), dt_From, dt_To, double.Parse(txt_medical.Text));
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 974, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_From.Text + "/" + txt_to.Text + "/U");
                        Fn_Clear();
                        Fn_Getdetail(); ;
                    }
                }
                else
                {
                    Confirmdialog.Show();
                }
            }
            else
            {
                Confirmdialog.Show();
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

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try { 
            DateTime dt_From, dt_To;
            dt_From = DateTime.Parse(Utility.fn_ConvertDate(txt_From.Text));
            dt_To = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));
            DataTable obj_dt = new DataTable();
            if (btn_save.ToolTip == "Save")
            {
                obj_dt = obj_da_Section.GradeInsDtls(txt_GradeName.Text, double.Parse(txt_entertain.Text), double.Parse(txt_driverwages.Text), dt_From, dt_To, double.Parse(txt_medical.Text));
                if (obj_dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Already Data Existed');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 974, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_From.Text + "/" + txt_to.Text + "/S");
                    Fn_Clear();
                }
            }
            else if (btn_save.ToolTip == "Update")
            {
                obj_da_Section.GradeUpdDtls(int.Parse(hid_Gid.Value.ToString()), double.Parse(txt_entertain.Text), double.Parse(txt_driverwages.Text), dt_From, dt_To, double.Parse(txt_medical.Text));
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 974, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_From.Text + "/" + txt_to.Text + "/U");
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

        protected void btnNo_Click(object sender, EventArgs e)
        {
            try { 
            Confirmdialog.Hide();
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

        protected void Grd_Grade_RowDataBound(object sender, GridViewRowEventArgs e)
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

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Grade, "Select$" + e.Row.RowIndex);
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 974, "Job", "", "", Session["StrTranType"].ToString());

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