using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class IncentiveDetails : System.Web.UI.Page
    {
        DataAccess.PAYROLL.IncentiveDetails obj_da_Incentive = new DataAccess.PAYROLL.IncentiveDetails();
        DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
        bool boool;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                txt_date.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
                txt_Empcode.Focus();
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //string str_CtrlLists, str_MsgLists, str_DataType;
                //str_CtrlLists = "txt_Empcode~txt_tds~txt_tdsAmount";
                //str_MsgLists = "Empcode~Incentive Amount~TDS %";
                //str_DataType = "String~Double~Double";
                //btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_date');");
                Grd_Incentive.DataSource = new DataTable();
                Grd_Incentive.DataBind();
                btn_Get.Attributes.Add("onclick", "return IsDate('txt_date');");
                txt_Amount.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Amount');");
                txt_tds.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_tds');");
                Session["Packages"] = lbl_Header.Text;
            }
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Incentive.GetHRincentivedtls(0, DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)));
            if (txt_Empcode.Text.TrimEnd().Length == 0)
            {
                if (obj_dt.Rows.Count > 0)
                {
                    Grd_Incentive.DataSource = obj_dt;
                    Grd_Incentive.DataBind();
                }
                else
                {
                    Grd_Incentive.DataSource = new DataTable();
                    Grd_Incentive.DataBind();
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(Button), "HRM", "alertify.alert('No Records For This Month');", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(Button), "HRM", "alertify.alert('Do You Want Get Details For All Employee Then\\nClear Employee Code');", true);
            }
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {

            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Incentive.Getempdtls(txt_Empcode.Text);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_company.Text = obj_dt.Rows[0]["divsname"].ToString() + "," + obj_dt.Rows[0]["portname"].ToString();
                    txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                    txt_designation.Text = obj_dt.Rows[0]["designame"].ToString();
                    txt_department.Text = obj_dt.Rows[0]["deptname"].ToString();
                    txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                    hid_Empid.Value = obj_dt.Rows[0]["employeeid"].ToString();
                    obj_dt = obj_da_Incentive.GetHRincentivedtls(int.Parse(hid_Empid.Value.ToString()), DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)));
                    Grd_Incentive.DataSource = obj_dt;
                    Grd_Incentive.DataBind();
                    txt_Amount.Focus();
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    Fn_Clear();
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(Button), "HRM", "alertify.alert('Enter Correct Emp Code');", true);
                }

            }
        }

        private void Fn_Clear()
        {
            txt_Empcode.Text = "";
            txt_Name.Text = "";
            txt_company.Text = "";
            txt_Grade.Text = "";
            txt_designation.Text = "";
            txt_department.Text = "";
            txt_Amount.Text = "";
            txt_tds.Text = "";
            txt_tdsAmount.Text = "";
            txt_NetAmount.Text = "";
            //Grd_Incentive.DataSource = new DataTable();
            //Grd_Incentive.DataBind();

            //btn_save.Text = "Save";
            btn_save.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            btn_save.Enabled = true;
            btn_Delete.Enabled = false;
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";

            txt_date.Text = Utility.fn_ConvertDate(obj_da_log.GetDate().ToShortDateString());
        }

        protected void Grd_Incentive_SelectedIndexChanged(object sender, EventArgs e)
        {
            hid_Incentiveid.Value = Grd_Incentive.SelectedDataKey.Values[0].ToString();
            txt_Empcode.Text = Grd_Incentive.SelectedRow.Cells[0].Text;
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Incentive.Getempdtls(txt_Empcode.Text);
            if (obj_dt.Rows.Count > 0)
            {
                txt_company.Text = obj_dt.Rows[0]["divsname"].ToString() + "," + obj_dt.Rows[0]["portname"].ToString();
                txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                txt_designation.Text = obj_dt.Rows[0]["designame"].ToString();
                txt_department.Text = obj_dt.Rows[0]["deptname"].ToString();
                txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                hid_Empid.Value = obj_dt.Rows[0]["employeeid"].ToString();
            }
            txt_Amount.Text = Grd_Incentive.SelectedRow.Cells[6].Text.ToString().Replace(",", "");
            txt_tds.Text = Grd_Incentive.SelectedRow.Cells[7].Text;
            txt_tdsAmount.Text = Grd_Incentive.SelectedRow.Cells[8].Text.ToString().Replace(",", "");
            txt_NetAmount.Text = Grd_Incentive.SelectedRow.Cells[9].Text.ToString().Replace(",", "");
            txt_date.Text = Grd_Incentive.SelectedRow.Cells[1].Text.ToString();
            //btn_save.Text = "Update";
            btn_save.ToolTip = "Update";
            btn_save1.Attributes["class"] = "btn btn-update1";
            btn_save.Enabled = true;
            btn_Delete.Enabled = true;
        }

        public void check_Data()
        {
            if (txt_Empcode.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Please Enter the Employee Code');", true);
                txt_Empcode.Focus();
                boool = true;
                return;
            }

            if (txt_Amount.Text.Trim()=="")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Please Enter the Incentive');", true);
                txt_Amount.Focus();
                boool = true;
                return;
            }

            if (txt_tds.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Please Enter the TDS %');", true);
                txt_tds.Focus();
                boool = true;
                return;
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            check_Data();
            if (boool==true)
            {
                boool = false;
                return;
            }
            DateTime dt_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
            if (btn_save.ToolTip == "Save")
            {
                obj_da_Incentive.InsHRIncentiveDtls(int.Parse(hid_Empid.Value.ToString()), decimal.Parse(txt_tds.Text), double.Parse(txt_tdsAmount.Text), double.Parse(txt_Amount.Text), dt_date);
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 799, 1, int.Parse(Session["LoginBranchid"].ToString()), hid_Empid.Value.ToString() + "/S");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved');", true);
                Fn_Clear();
                Data_Bind();

            }
            else if (btn_save.ToolTip == "Update")
            {
                obj_da_Incentive.UpdHRIncentivedtls(int.Parse(hid_Empid.Value.ToString()), int.Parse(hid_Incentiveid.Value.ToString()), dt_date, decimal.Parse(txt_tds.Text), double.Parse(txt_tdsAmount.Text), double.Parse(txt_Amount.Text));
                obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 799, 2, int.Parse(Session["LoginBranchid"].ToString()), hid_Empid.Value.ToString() + "/U");
                ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated');", true);
                Fn_Clear();
                Data_Bind();
            }
        }

        public void Data_Bind()
        {
            DataTable obj_dt = new DataTable();
           
            obj_dt = obj_da_Incentive.GetHRincentivedtls(int.Parse(hid_Empid.Value.ToString()), DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text)));

            if (obj_dt.Rows.Count>0)
            {
                Grd_Incentive.DataSource = obj_dt;
                Grd_Incentive.DataBind();
            }
            else
            {

            }
           
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip=="Cancel")
          {
            Fn_Clear();
            Grd_Incentive.DataSource = new DataTable();
            Grd_Incentive.DataBind();
            txt_Empcode.Focus();
          }
          else
          {
              this.Response.End();
          }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            obj_da_Incentive.DElHRIncentivedtls(int.Parse(hid_Incentiveid.Value.ToString()));
            obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 799, 4, int.Parse(Session["LoginBranchid"].ToString()), hid_Empid.Value.ToString() + "/D");
            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Deleted');", true);
            Fn_Clear();
            Data_Bind();
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DateTime dt_date = DateTime.Parse(Utility.fn_ConvertDate(txt_date.Text));
            Str_RptName = "/Payroll/" + "rptHRIncentive.rpt";
            Str_sp = "date=" + txt_date.Text;
            if (txt_Empcode.Text.TrimEnd().Length == 0)
            {
                Str_sf = "month( {HRIncentiveDetails.date})=" + dt_date.Month + " and year( {HRIncentiveDetails.date})=" + dt_date.Year;
            }
            else
            {
                Session["str_sfs"] = "{HRIncentiveDetails.empid}=" + Convert.ToInt32(hid_Empid.Value) + " and month( {HRIncentiveDetails.date})=" + dt_date.Month + " and year( {HRIncentiveDetails.date})=" + dt_date.Year;
            }
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 799, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
            ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
            //Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
        }

        protected void txt_tds_TextChanged(object sender, EventArgs e)
        {
            double Amount = txt_Amount.Text.TrimEnd().Length == 0 ? 0 : double.Parse(txt_Amount.Text);
            double TDS = txt_tds.Text.TrimEnd().Length == 0 ? 0 : double.Parse(txt_tds.Text);
            double TDSAmount = ((Amount / 100) * TDS);
            txt_tdsAmount.Text = string.Format("{0:0.00}", TDSAmount);
            txt_NetAmount.Text = (Amount + TDSAmount).ToString();
        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            //Popup_Emp.Show();
            //iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx";
            Response.Redirect("../HRM/EmployeeFind.aspx");
        }

        protected void Grd_Incentive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Incentive, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Incentive_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_Incentive.PageIndex = e.NewPageIndex;
               btn_Get_Click(sender,e);
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 799, "Job", "", "", Session["StrTranType"].ToString());

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