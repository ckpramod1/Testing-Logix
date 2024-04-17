using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Web.Services;

namespace logix.HRM
{
    public partial class Packages : System.Web.UI.Page
    {
        DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        Double coldamt;
        int indexValue;
        int i;
        double totloan, monamt, totamt;
        double instamt;
        DateTime LoanMon, Currmon;
        //int mon;
        int laonyear, curryear, yr;
        Decimal Grdtot;
        public static int int_bid, int_Empid;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Request.QueryString.ToString().Contains("type"))
            {
                string str_Uiid = "";
                //str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_save, btn_view, btn_delete);
            }
            try
            {
                txt_totalsalary.Attributes.Add("readonly", "readonly");
                txt_from.Attributes.Add("readonly", "readonly");
                txt_to.Attributes.Add("readonly", "readonly");
                txt_effectivefrom.Attributes.Add("readonly", "readonly");
                txt_arreartaken.Attributes.Add("readonly", "readonly");
                txt_ComEmpCode.Attributes.Add("readonly", "readonly");
                txt_ConEmpCode.Attributes.Add("readonly", "readonly");
                txt_AllowEmpcode.Attributes.Add("readonly", "readonly");
                txt_ComTotal.Attributes.Add("readonly", "readonly");
                txt_AllowAmount.Attributes.Add("readonly", "readonly");
                txt_AllowAmount.Attributes.Add("readonly", "readonly");
                if (!IsPostBack)
                {
                    int_bid = int.Parse(Session["LoginBranchid"].ToString());
                    int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                    lnk_salary_Click(sender, e);
                    Fn_Clear_TxtDate();
                    txt_empcode.Focus();
                    Grd_Package.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Package.DataBind();
                   // btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    Grd_Compensation.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Compensation.DataBind();

                    Grd_Contribution.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Contribution.DataBind();

                    Grd_Allowance.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Allowance.DataBind();

                    Grd_Loan.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Loan.DataBind();

                    txt_basic.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_basic');");
                    txt_hra.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_hra');");
                    txt_loyality.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_loyality');");
                    txt_lunchallow.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_lunchallow');");
                    txt_conveyance.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_conveyance');");
                    txt_entertain.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_entertain');");
                    txt_otherallow.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_otherallow');");
                    txt_others.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_others');");
                    txt_driverallow.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_driverallow');");
                    txt_medical.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_medical');");
                    //  txt_loanamount.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_loanamount');");
                    //  txt_Tenure.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_loanamount');");
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    //  txt_takenon.Text = string.Format("{0:dd/MM/yyyy}", obj_da_Log.GetDate());
                    string str_CtrlLists, str_MsgLists, str_DataType;
                    str_CtrlLists = "txt_empcode~txt_basic~txt_hra~txt_otherallow";
                    str_MsgLists = "EmpCode~Basic~HRA~OtherAllowances";
                    str_DataType = "String~String~String~String";
                    btn_save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                    str_CtrlLists = "txt_empcode~txt_loanamount~txt_Tenure~txt_loanamount~txt_Tenure";
                    str_MsgLists = "EmpCode~LoanAmount~Tenure~LoanAmount~Tenure";
                    str_DataType = "String~String~String~Double~Integer";
                    btn_loanSave.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && IsDate('txt_takenon');");
                    btn_delete.Attributes.Add("OnClick", "return confirm('Do U Want Delete');");
                    btn_loanDelete.Attributes.Add("OnClick", "return confirm('Do U Want Delete');");
                    Chk_Arrear.Checked = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            txt_Allowfrom.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Allowfrom');");
            txt_Allowto.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Allowto');");
            txt_petrol.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_petrol');");
            txt_datacard.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_datacard');");
            txt_driverwage.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_driverwage');");
            txt_Allowmobile.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_entertain');");
            txt_phonesres.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_phonesres');");
            txt_vma.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_vma');");
            txt_Allowothers.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_driverallow');");
            txt_car.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_car');");
            txt_AllowAmount.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_AllowAmount');");
            Txt_AllowTotal.Attributes.Add("OnKeyUp", "return IsDoubleCheck('Txt_AllowTotal');");

            txt_loanamount.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_loanamount');");
            txt_Tenure.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Tenure');");
        }
        private void Fn_TabClick(System.Web.UI.HtmlControls.HtmlGenericControl Str_Ctrl, Panel Str_Pln)
        {
            try
            {


                List<System.Web.UI.HtmlControls.HtmlGenericControl> Str_lst = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();
                List<Panel> Str_Plnlst = new List<Panel>();
                Str_lst.Add(div_salary);
                Str_lst.Add(div_compensation);
                Str_lst.Add(div_contribution);
                Str_lst.Add(div_allowance);
                Str_lst.Add(div_loan);
                Str_Plnlst.Add(Pln_salary);
                Str_Plnlst.Add(pln_compensation);
                Str_Plnlst.Add(Pln_contribution);
                Str_Plnlst.Add(Pln_allowance);
                Str_Plnlst.Add(Pln_loan);
                Str_Ctrl.Attributes["class"] = "div_TabClick";
                Str_Pln.Visible = true;
                Str_lst.Remove(Str_Ctrl);
                Str_Plnlst.Remove(Str_Pln);
                for (int i = 0; i <= Str_lst.Count - 1; i++)
                {
                    Str_lst[i].Attributes["class"] = "div_Tab";
                }
                for (int i = 0; i <= Str_Plnlst.Count - 1; i++)
                {
                    Str_Plnlst[i].Visible = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_salary_Click(object sender, EventArgs e)
        {
            try
            {

                Fn_TabClick(div_salary, Pln_salary);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_compensation_Click(object sender, EventArgs e)
        {
            try
            {

                Fn_TabClick(div_compensation, pln_compensation);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_contribution_Click(object sender, EventArgs e)
        {
            try
            {
                Fn_TabClick(div_contribution, Pln_contribution);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_allowance_Click(object sender, EventArgs e)
        {
            try
            {
                txt_petrol.Focus();
                Fn_TabClick(div_allowance, Pln_allowance);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_loan_Click(object sender, EventArgs e)
        {
            try
            {

                Fn_TabClick(div_loan, Pln_loan);
                txt_loanamount.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_empcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_empcode.Text.Trim().Length > 0)
                {
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_Employee.selEmpDetails(txt_empcode.Text, "PER");
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_ComEmpCode.Text = txt_empcode.Text;
                        txt_ConEmpCode.Text = txt_empcode.Text;
                        txt_AllowEmpcode.Text = txt_empcode.Text;
                        txt_LoanEmpcode.Text = txt_empcode.Text;
                        txt_Empname.Text = obj_dt.Rows[0][2].ToString();
                        txt_ComEmpName.Text = txt_Empname.Text;
                        txt_ConEmpname.Text = txt_Empname.Text;
                        txt_AllowEmpname.Text = txt_Empname.Text;
                        txt_LoanEmpName.Text = txt_Empname.Text;
                        Fn_GrdSalaryDetail();
                        Fn_GrdCompDetail();
                        Fn_GrdContDetail();
                        Fn_GrdAllowanceDetail();
                        Fn_GrdLoanDetail();
                      //  btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";

                        btn_save.Enabled = true;
                        btn_view.Enabled = true;
                        txt_basic.Focus();
                        DataTable obj_dtNew = new DataTable();
                        obj_dtNew = obj_da_Employee.getgradedtls4salary(txt_empcode.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)));
                        if (obj_dtNew.Rows.Count > 0)
                        {
                            txt_entertain.Text = string.Format("{0:0.00}", obj_dtNew.Rows[0]["ea"]);
                            txt_driverallow.Text = string.Format("{0:0.00}", obj_dtNew.Rows[0]["driverall"]);
                            txt_ComMedical.Text = string.Format("{0:0.00}", obj_dtNew.Rows[0]["medical"]);
                        }
                        else
                        {
                            txt_entertain.Text = "0";
                            txt_driverallow.Text = "0";
                            txt_ComMedical.Text = "0";
                        }
                        totalsal();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Enter Valied Emp Code');", true);
                        txt_empcode.Focus();
                        txt_empcode.Text = "";
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
        private void Fn_GrdSalaryDetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.selEmpDetails(txt_empcode.Text, "SAL");
                Grd_Package.DataSource = obj_dt;
                Grd_Package.DataBind();
               // btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_GrdCompDetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.selEmpDetails(txt_empcode.Text, "COM");
                Grd_Compensation.DataSource = obj_dt;
                Grd_Compensation.DataBind();
               // btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }


            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_GrdContDetail()
        {
            try
            {

                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.selEmpDetails(txt_empcode.Text, "CON");
                Grd_Contribution.DataSource = obj_dt;
                Grd_Contribution.DataBind();
            //    btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_GrdAllowanceDetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.selEmpDetails(txt_empcode.Text, "ALL");
                Grd_Allowance.DataSource = obj_dt;
                Grd_Allowance.DataBind();
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
        private void Fn_GrdLoanDetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Employee.selEmpDetails(txt_empcode.Text, "LAD");
                Grd_Loan.DataSource = obj_dt;
                Grd_Loan.DataBind();
              //  btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //[WebMethod]
        public static string GetTotal(string Prefix)
        {

            string[] Str_Value = Prefix.Split(',');
            string str_Total = "";

            if (str_Total != "")
            {
                str_Total = "0";
            }
            for (int i = 0; i <= Str_Value.Length - 1; i++)
            {

                if (Str_Value[i].ToString().TrimEnd().Length == 0)
                {
                    Str_Value[i] = "0";
                }
            }
            double Total = 0;
            for (int i = 0; i <= Str_Value.Length - 1; i++)
            {
                Total = Total + double.Parse(Str_Value[i].ToString());
            }
            str_Total = string.Format("{0:0.##}", Total);
            return str_Total;
        }

        protected void Grd_Package_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                indexValue = Grd_Package.SelectedRow.RowIndex;
                int index = indexValue;
                txt_basic.Text = Grd_Package.Rows[index].Cells[2].Text.ToString().Replace(",", "");
                txt_hra.Text = Grd_Package.Rows[index].Cells[3].Text.ToString().Replace(",", "");
                txt_loyality.Text = Grd_Package.Rows[index].Cells[7].Text.ToString().Replace(",", "");
                txt_lunchallow.Text = Grd_Package.Rows[index].Cells[5].Text.ToString().Replace(",", "");
                txt_conveyance.Text = Grd_Package.Rows[index].Cells[6].Text.ToString().Replace(",", "");
                txt_entertain.Text = Grd_Package.Rows[index].Cells[8].Text.ToString().Replace(",", "");
                txt_otherallow.Text = Grd_Package.Rows[index].Cells[4].Text.ToString().Replace(",", "");
                txt_driverallow.Text = Grd_Package.Rows[index].Cells[9].Text.ToString().Replace(",", "");
                txt_others.Text = Grd_Package.Rows[index].Cells[10].Text.ToString().Replace(",", "");
                txt_medical.Text = Grd_Package.Rows[index].Cells[11].Text.ToString().Replace(",", "");
                txt_totalsalary.Text = (double.Parse(txt_basic.Text) + double.Parse(txt_hra.Text) + double.Parse(txt_loyality.Text) + double.Parse(txt_lunchallow.Text) + double.Parse(txt_conveyance.Text) +
                double.Parse(txt_entertain.Text) + double.Parse(txt_otherallow.Text) + double.Parse(txt_driverallow.Text) + double.Parse(txt_others.Text) + double.Parse(txt_medical.Text)).ToString();
                txt_from.Text = (Grd_Package.Rows[index].Cells[0].Text.ToString());
                txt_to.Text = (Grd_Package.Rows[index].Cells[1].Text.ToString());
                txt_effectivefrom.Text = (Grd_Package.Rows[index].Cells[12].Text.ToString());
                txt_arreartaken.Text = (Grd_Package.Rows[index].Cells[13].Text.ToString());
                Double pack = Convert.ToDouble(Grd_Package.Rows[index].Cells[14].Text.ToString());
                if (pack == 1)
                {
                    Chk_Arrear.Checked = true;
                }
                else
                {
                    Chk_Arrear.Checked = false;
                }

               // btn_save.Text = "Update";

                btn_save.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";


                btn_save.Enabled = true;
                btn_AllowanceSave.Enabled = true;
               // btn_AllowanceSave.Text = "Update";
                btn_AllowanceSave.ToolTip = "Update";
                btn_AllowanceSave1.Attributes["class"] = "btn btn-update1";

                btn_view.Enabled = false;
                btn_delete.Enabled = true;

                txt_from_TextChanged(sender, e);
                txt_to_TextChanged(sender, e);

                //btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

                grdcellcomp();
                grdcellcon();
                grdcellall();
                //DataTable obj_dt = new DataTable();
                //obj_dt = obj_da_Employee.getgradedtls4salary(txt_empcode.Text, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)));
                //if (obj_dt.Rows.Count > 0)
                //{
                //    txt_entertain.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["ea"]);
                //    txt_driverallow.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["driverall"]);
                //    txt_medical.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["medical"]);
                //}
                //else
                //{
                //    txt_entertain.Text = "0";
                //    txt_driverallow.Text = "0";
                //    txt_medical.Text = "0";
                //}
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdcellcon()
        {
            try
            {
                if (Grd_Contribution.Rows.Count > 0)
                {
                    int index = indexValue;
                    txt_pf.Text = Grd_Contribution.Rows[index].Cells[2].Text.ToString().Replace(",", "");
                    txt_esi.Text = Grd_Contribution.Rows[index].Cells[3].Text.ToString().Replace(",", "");
                    txt_ConFrom.Text = Grd_Contribution.Rows[index].Cells[0].Text;
                    txt_ConTo.Text = Grd_Contribution.Rows[index].Cells[1].Text;
                    //       BtnConSave.Text = "&Update"

                    //BtnConSave.Enabled = True
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdcellcomp()
        {
            try
            {
                if (Grd_Compensation.Rows.Count > 0)
                {
                    int index = indexValue;

                    txt_lta.Text = Grd_Compensation.Rows[index].Cells[2].Text.ToString().Replace(",", "");
                    txt_ComMedical.Text = Grd_Compensation.Rows[index].Cells[3].Text.ToString().Replace(",", "");
                    txt_bonus.Text = Grd_Compensation.Rows[index].Cells[4].Text.ToString().Replace(",", "");
                    txt_others.Text = Grd_Compensation.Rows[index].Cells[5].Text.ToString().Replace(",", "");
                    txt_from.Text = Grd_Compensation.Rows[index].Cells[0].Text;
                    txt_to.Text = Grd_Compensation.Rows[index].Cells[1].Text;


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdcellall()
        {
            try
            {
                if (Grd_Allowance.Rows.Count > 0)
                {
                    int index = indexValue;

                    txt_petrol.Text = Grd_Allowance.Rows[index].Cells[2].Text.ToString().Replace(",", "");
                    txt_datacard.Text = Grd_Allowance.Rows[index].Cells[5].Text.ToString().Replace(",", "");
                    txt_Allowmobile.Text = Grd_Allowance.Rows[index].Cells[3].Text.ToString().Replace(",", "");
                    txt_phonesres.Text = Grd_Allowance.Rows[index].Cells[4].Text.ToString().Replace(",", "");
                    txt_Allowothers.Text = Grd_Allowance.Rows[index].Cells[10].Text.ToString().Replace(",", "");
                    txt_Allowfrom.Text = Grd_Allowance.Rows[index].Cells[0].Text;
                    txt_Allowto.Text = Grd_Allowance.Rows[index].Cells[1].Text;
                    txt_vma.Text = Grd_Allowance.Rows[index].Cells[6].Text.ToString().Replace(",", "");
                    txt_driverwage.Text = Grd_Allowance.Rows[index].Cells[7].Text.ToString().Replace(",", "");
                    txt_car.Text = Grd_Allowance.Rows[index].Cells[8].Text.ToString().Replace(",", "");
                    txt_AllowAmount.Text = Grd_Allowance.Rows[index].Cells[9].Text.ToString().Replace(",", "");
                    coldamt = Convert.ToDouble(Grd_Allowance.Rows[index].Cells[10].Text.ToString().Replace(",", ""));
                    btn_loanSave.Text = "Update";
                    btn_loanSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_appointment_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_empcode.Text.Trim().Length > 0)
                {
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_Temp = "", Str_Empid = "";
                    Str_Empid = obj_da_Employee.GetEmpId(txt_empcode.Text).ToString();
                    Str_RptName = "HRAppointmentletter.rpt";
                    Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}=" + Str_Empid + " and year({HRSalaryDetails.sfrom})>=" + obj_da_Log.GetDate().AddYears(-1).Year + " and year({HRSalaryDetails.sto})<=" + obj_da_Log.GetDate().Year;
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    Str_RptName = "HRAppointmentletterCont.rpt";
                    Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}=" + Str_Empid;
                    Str_Temp = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    Str_Script = Str_Script + ";" + Str_Temp;
                    ScriptManager.RegisterStartupScript(btn_appointment, typeof(Button), "HRM", Str_Script, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_appointment, typeof(Button), "HRM", "alertify.alert('Enter the Employee Code')", true);
                }
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
                if (txt_empcode.Text.Trim().Length > 0)
                {
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "", Str_Empid = "";
                    Str_Empid = obj_da_Employee.GetEmpId(txt_empcode.Text).ToString();
                    Str_RptName = "HREmpPackage.rpt";
                    Str_sf = "{MasterEmployee.rol}=0 and {MasterEmployee.employeeid}=" + Str_Empid;
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                  //  Str_Script = "window.open('../Reportasp/employeepackagedetail.aspx?Str_Empid=" + Str_Empid + "&Empcode=" + txt_empcode.Text + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", Str_Script, true);
                    obj_da_Log.InsLogDetail(int_Empid, 173, 3, int_bid, "/V -Salary");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_view, typeof(Button), "HRM", "alertify.alert('Enter the Employee Code')", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Fn_Clear_Salary()
        {
            txt_basic.Text = "";
            txt_hra.Text = "";
            txt_loyality.Text = "";
            txt_lunchallow.Text = "";
            txt_conveyance.Text = "";
            txt_entertain.Text = "";
            txt_otherallow.Text = "";
            txt_others.Text = "";
            txt_driverallow.Text = "";
            txt_medical.Text = "";
            txt_totalsalary.Text = "";
            Chk_Arrear.Checked = false;

        }
        private void Fn_Clear_Compensation()
        {
            txt_lta.Text = "";
            txt_bonus.Text = "";
            txt_ComMedical.Text = "";
            txt_ComOthers.Text = "";
            // txt_ComLoyality.Text = "";
            txt_ComTotal.Text = "";
        }
        private void Fn_Clear_Contribution()
        {
            txt_pf.Text = "";
            txt_esi.Text = "";
            //  txt_ConTotal.Text = "";
        }
        private void Fn_Clear_Allowances()
        {
            txt_petrol.Text = "";
            txt_datacard.Text = "";
            //   txt_ConTotal.Text = "";
            txt_driverwage.Text = "";
            txt_Allowmobile.Text = "";
            txt_phonesres.Text = "";
            txt_vma.Text = "";
            txt_Allowothers.Text = "";
            txt_car.Text = "";
            txt_AllowAmount.Text = "";
            Txt_AllowTotal.Text = "";

        }
        private void Fn_Clear_TxtDate()
        {
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            txt_from.Text = "01" + "/04/" + Session["Vouyear"].ToString();
            txt_to.Text = "31" + "/03/" + (int.Parse(Session["Vouyear"].ToString()) + 1);
            txt_effectivefrom.Text = txt_from.Text;
            txt_arreartaken.Text = txt_from.Text;
            txt_ComFrom.Text = txt_from.Text;
            txt_ComTo.Text = txt_to.Text;
            txt_ConFrom.Text = txt_from.Text;
            txt_ConTo.Text = txt_to.Text;
            txt_Allowfrom.Text = txt_from.Text;
            txt_Allowto.Text = txt_to.Text;
            txt_takenon.Text = txt_from.Text;
        }
        private void Fn_Clear_Loan()
        {
            btn_loanSave.Text = "Save";
            txt_loanamount.Text = "";
            txt_Tenure.Text = "";
            txt_remark.Text = "";
            txt_loantotal.Text = "";
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            txt_takenon.Text = string.Format("{0:dd/MM/yyyy}", obj_da_Log.GetDate());
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear_TxtDate();
                Fn_Clear_Salary();
                Fn_Clear_Compensation();
                Fn_Clear_Contribution();
                Fn_Clear_Allowances();
                Fn_Clear_Loan();
                Fn_Clear_Grd();
                txt_empcode.Focus();
                btn_save.Enabled = false;
                btn_view.Enabled = false;
                btn_delete.Enabled = false;
                btn_loanDelete.Enabled = false;
              //  btn_save.Text = "Save";
                btn_save.ToolTip = "Save";
                btn_save1.Attributes["class"] = "btn ico-save";

                btn_AllowanceSave.Enabled = true;
               // btn_AllowanceSave.Text = "Save";
                btn_AllowanceSave.ToolTip = "Save";
                btn_AllowanceSave1.Attributes["class"] = "btn ico-save";

                Chk_Arrear.Checked = true;
               // btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                this.Response.End();
            }

        }
        private void Fn_Clear_Grd()
        {
            txt_empcode.Text = "";
            txt_Empname.Text = "";
            txt_ComEmpCode.Text = "";
            txt_ComEmpName.Text = "";
            txt_ConEmpCode.Text = "";
            txt_ConEmpname.Text = "";
            txt_AllowEmpcode.Text = "";
            txt_AllowEmpname.Text = "";
            txt_LoanEmpcode.Text = "";
            txt_LoanEmpName.Text = "";

            Grd_Package.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Package.DataBind();
            Grd_Compensation.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Compensation.DataBind();
            Grd_Contribution.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Contribution.DataBind();
            Grd_Allowance.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Allowance.DataBind();
            Grd_Loan.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Loan.DataBind();
        }
        protected void Grd_Loan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btn_loanSave.Text = "Update";
                txt_takenon.Enabled = false;
                btn_loanDelete.Enabled = true;
                txt_loanamount.Text = Grd_Loan.SelectedRow.Cells[0].Text.ToString().Replace(",", "");
                txt_Tenure.Text = Grd_Loan.SelectedRow.Cells[1].Text.ToString();
                txt_takenon.Text = Grd_Loan.SelectedRow.Cells[2].Text.ToString();
                txt_remark.Text = Grd_Loan.SelectedRow.Cells[3].Text.ToString().Replace("&nbsp;", "");
                txt_loanamount.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime Dt_From, Dt_To, Dt_Effet, Dt_Arrear;
                Dt_From = DateTime.Parse(Utility.fn_ConvertDate(txt_from.Text));
                Dt_To = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));
                Dt_Effet = DateTime.Parse(Utility.fn_ConvertDate(txt_effectivefrom.Text));
                Dt_Arrear = DateTime.Parse(Utility.fn_ConvertDate(txt_arreartaken.Text));
                TextBox[] Txt_list = { txt_basic, txt_hra, txt_loyality, txt_lunchallow, txt_conveyance, txt_entertain, txt_otherallow, txt_others, txt_driverallow, txt_medical };
                Fn_TxtValue(Txt_list);
                int int_ArrearChk = Chk_Arrear.Checked == true ? 1 : 0;
                int Total_Salary = Convert.ToInt32(txt_totalsalary.Text);
                if (Total_Salary < 10000)
                {
                    txt_esi.Text = ((Total_Salary * 3.5) / 100).ToString();
                }
                else
                {
                    txt_esi.Text = "";
                }
                txt_ComMedical.Text = obj_da_Employee.getMedicalamt(txt_empcode.Text, Dt_From).ToString();
                if (Dt_From < Dt_To)
                {
                    if (Dt_Effet > Dt_From)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Effective Date Should be Lessthan SalaryTo Date');", true);
                        return;
                    }
                    if (Dt_Arrear > Dt_To)
                    {
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('ArrearTakeon Date Should be Lessthan SalaryTo Date');", true);
                        return;
                    }
                    DataTable obj_dt = new DataTable();
                    if (btn_save.ToolTip == "Save")
                    {
                        obj_dt = obj_da_Employee.selEmployDetails(txt_empcode.Text, Dt_From, Dt_To);
                        if (obj_dt.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Already Data Exists for " + txt_from.Text + " To " + txt_to.Text + "');", true);
                            return;
                        }
                        obj_da_Employee.InsEmpSalary(txt_empcode.Text, double.Parse(txt_basic.Text), double.Parse(txt_hra.Text), double.Parse(txt_otherallow.Text), double.Parse(txt_lunchallow.Text), double.Parse(txt_conveyance.Text), double.Parse(txt_others.Text), Dt_From, Dt_To, double.Parse(txt_loyality.Text), double.Parse(txt_entertain.Text), double.Parse(txt_driverallow.Text), double.Parse(txt_medical.Text));
                        obj_da_Employee.UpdArrear(txt_empcode.Text, Dt_Effet, Dt_Arrear, int_ArrearChk);
                        obj_da_Log.InsLogDetail(int_Empid, 173, 1, int_bid, txt_empcode.Text + "/S -Salary");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Saved')", true);
                        Fn_ComSave();
                        Fn_ConSave();
                        Fn_AllowanceSave();
                        Fn_Clear_Salary();
                        Fn_Clear_Compensation();
                        Fn_Clear_Contribution();
                        Fn_Clear_Allowances();
                        Fn_Clear_Loan();

                        Fn_GrdSalaryDetail();

                        btn_AllowanceSave.Enabled = false;

                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        obj_da_Employee.UpdEmpSalary(txt_empcode.Text, double.Parse(txt_basic.Text), double.Parse(txt_hra.Text), double.Parse(txt_otherallow.Text), double.Parse(txt_lunchallow.Text), double.Parse(txt_conveyance.Text), double.Parse(txt_others.Text), Dt_From, Dt_To, double.Parse(txt_loyality.Text), double.Parse(txt_entertain.Text), double.Parse(txt_driverallow.Text), double.Parse(txt_medical.Text), Dt_Effet, Dt_Arrear, int_ArrearChk);
                        obj_da_Log.InsLogDetail(int_Empid, 173, 2, int_bid, txt_empcode.Text + "/U -Salary");
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated')", true);
                        Fn_ComSave();
                        Fn_ConSave();
                        Fn_AllowanceSave();
                        Fn_Clear_Salary();
                        Fn_Clear_Compensation();
                        Fn_Clear_Contribution();
                        Fn_Clear_Allowances();
                        Fn_Clear_Loan();
                        Fn_GrdSalaryDetail();
                    }
                    btn_save.Enabled = false;
                    btn_delete.Enabled = false;
                    btn_view.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('From Date Should be Le than To date')", true);
                }
               // btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_TxtValue(TextBox[] Txt_Ctrl)
        {
            for (int i = 0; i <= Txt_Ctrl.Length - 1; i++)
            {
                if (Txt_Ctrl[i].Text.Trim() == "")
                {
                    Txt_Ctrl[i].Text = "0";
                }
            }
        }
        private void Fn_ComSave()
        {
            try
            {
                if (txt_ComEmpCode.Text.Trim().Length > 0)
                {
                    TextBox[] Txt_list = { txt_lta, txt_bonus, txt_ComMedical, txt_ComOthers };
                    Fn_TxtValue(Txt_list);
                    if (btn_save.ToolTip == "Save")
                    {

                        obj_da_Employee.InsEmpAnualCompensation(txt_empcode.Text, double.Parse(txt_lta.Text), double.Parse(txt_ComMedical.Text), double.Parse(txt_bonus.Text), double.Parse(txt_ComOthers.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_ComFrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_ComTo.Text)));
                        obj_da_Log.InsLogDetail(int_Empid, 173, 1, int_bid, txt_empcode.Text + "/S - Compensation");
                        Fn_GrdCompDetail();

                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        obj_da_Employee.UpdEmpAnualCompensation(txt_empcode.Text, double.Parse(txt_lta.Text), double.Parse(txt_ComMedical.Text), double.Parse(txt_bonus.Text), double.Parse(txt_ComOthers.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_ComFrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_ComTo.Text)));
                        obj_da_Log.InsLogDetail(int_Empid, 173, 2, int_bid, txt_empcode.Text + "/U - Compensation");
                        Fn_GrdCompDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_ConSave()
        {
            try
            {
                if (txt_ConEmpCode.Text.Trim().Length > 0)
                {
                    TextBox[] Txt_list = { txt_pf, txt_esi };
                    Fn_TxtValue(Txt_list);
                    if (btn_save.ToolTip == "Save")
                    {

                        obj_da_Employee.InsEmpContribution(txt_empcode.Text, double.Parse(txt_pf.Text), double.Parse(txt_esi.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_ConFrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_ConTo.Text)));
                        obj_da_Log.InsLogDetail(int_Empid, 173, 1, int_bid, txt_empcode.Text + "/S - Contribution");
                        Fn_GrdContDetail();
                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        obj_da_Employee.UpdEmpContribution(txt_empcode.Text, double.Parse(txt_pf.Text), double.Parse(txt_esi.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_ConFrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_ConTo.Text)));
                        obj_da_Log.InsLogDetail(int_Empid, 173, 2, int_bid, txt_empcode.Text + "/U - Contribution");
                        Fn_GrdContDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_AllowanceSave()
        {
            try
            {
                if (txt_AllowEmpcode.Text.Trim().Length > 0)
                {
                    TextBox[] Txt_list = { txt_petrol, txt_Allowmobile, txt_phonesres, txt_datacard, txt_Allowothers, txt_vma, txt_driverwage, txt_car, txt_AllowAmount };
                    Fn_TxtValue(Txt_list);
                    if (btn_save.ToolTip == "Save")
                    {
                        obj_da_Employee.InsEmpAllowances(txt_empcode.Text, double.Parse(txt_petrol.Text), double.Parse(txt_Allowmobile.Text), double.Parse(txt_phonesres.Text), double.Parse(txt_datacard.Text), double.Parse(txt_Allowothers.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_Allowfrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_Allowto.Text)), double.Parse(txt_vma.Text), double.Parse(txt_driverwage.Text), double.Parse(txt_car.Text), double.Parse(txt_AllowAmount.Text));
                        obj_da_Log.InsLogDetail(int_Empid, 173, 1, int_bid, txt_empcode.Text + "/S - Allowances");
                        Fn_GrdAllowanceDetail();
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details saved')", true);
                    }
                    else if (btn_save.ToolTip == "Update")
                    {
                        obj_da_Employee.UpdEmpAllowances(txt_empcode.Text, double.Parse(txt_petrol.Text), double.Parse(txt_Allowmobile.Text), double.Parse(txt_phonesres.Text), double.Parse(txt_datacard.Text), double.Parse(txt_Allowothers.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_Allowfrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_Allowto.Text)), double.Parse(txt_vma.Text), double.Parse(txt_driverwage.Text), double.Parse(txt_car.Text), double.Parse(txt_AllowAmount.Text));
                        obj_da_Log.InsLogDetail(int_Empid, 173, 2, int_bid, txt_empcode.Text + "/U - Allowances");
                        Fn_GrdAllowanceDetail();
                        ScriptManager.RegisterStartupScript(btn_save, typeof(Button), "HRM", "alertify.alert('Details Updated')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                obj_da_Employee.DelEmpSalary(txt_empcode.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_from.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text)));
                obj_da_Log.InsLogDetail(int_Empid, 173, 4, int_bid, txt_empcode.Text + "/D - Salary");

                obj_da_Employee.DelEmpACompensation(txt_ComEmpCode.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_ComFrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_ComTo.Text)));
                obj_da_Log.InsLogDetail(int_Empid, 173, 4, int_bid, txt_empcode.Text + "/D - Compensation");

                obj_da_Employee.DelEmpACompensation(txt_ConEmpCode.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_ConFrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_ConTo.Text)));
                obj_da_Log.InsLogDetail(int_Empid, 173, 4, int_bid, txt_empcode.Text + "/D - Contribution");

                obj_da_Employee.DelEmpACompensation(txt_AllowEmpcode.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_Allowfrom.Text)), DateTime.Parse(Utility.fn_ConvertDate(txt_Allowto.Text)));
                obj_da_Log.InsLogDetail(int_Empid, 173, 4, int_bid, txt_empcode.Text + "/D - Allowances");


                Fn_GrdSalaryDetail();
                Fn_GrdAllowanceDetail();
                Fn_GrdCompDetail();
                Fn_GrdContDetail();

                Fn_Clear_Salary();
                Fn_Clear_Compensation();
                Fn_Clear_Contribution();
                Fn_Clear_Allowances();
                Fn_Clear_Loan();
                btn_delete.Enabled = false;
              //  btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_AllowanceSave_Click(object sender, EventArgs e)
        {
            try
            {
                Fn_AllowanceSave();
                txt_petrol.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void txt_from_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_TxtDateVal(txt_from.Text, txt_to.Text);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private void Fn_TxtDateVal(string Str_From, string str_To)
        {
            txt_ComFrom.Text = Str_From;
            txt_ComTo.Text = str_To;
            txt_ConFrom.Text = Str_From;
            txt_ConTo.Text = str_To;
            txt_Allowfrom.Text = Str_From;
            txt_Allowto.Text = str_To;
        }

        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_TxtDateVal(txt_from.Text, txt_to.Text);
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_loanSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_LoanEmpcode.Text.Trim().Length > 0)
                {

                    if (btn_loanSave.Text == "Save")
                    {
                        DataTable obj_dt = new DataTable();
                        obj_dt = obj_da_Employee.selEmpDetails(txt_LoanEmpcode.Text, "LAD");
                        var Lst_Loan = obj_dt.AsEnumerable().Where(row => row.Field<string>("takenon").Trim() == txt_takenon.Text.Trim()).ToList();
                        if (Lst_Loan.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_loanSave, typeof(Button), "HRM", "alertify.alert('Loan is already Provided in this Date,Pls Choose another Date')", true);
                            return;
                        }

                        obj_da_Employee.InsEmpLoansAdvance(txt_LoanEmpcode.Text, double.Parse(txt_loanamount.Text), int.Parse(txt_Tenure.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_takenon.Text)), txt_remark.Text);
                        obj_da_Log.InsLogDetail(int_Empid, 173, 1, int_bid, txt_empcode.Text + "/S - Loan&Advances");
                        ScriptManager.RegisterStartupScript(btn_loanSave, typeof(Button), "HRM", "alertify.alert('Details Saved...')", true);
                    }
                    else if (btn_loanSave.Text == "Update")
                    {
                        obj_da_Employee.UpdEmpLoansAdvance(txt_LoanEmpcode.Text, double.Parse(txt_loanamount.Text), int.Parse(txt_Tenure.Text), DateTime.Parse(Utility.fn_ConvertDate(txt_takenon.Text)), txt_remark.Text, cboxClose.Text);
                        obj_da_Log.InsLogDetail(int_Empid, 173, 2, int_bid, txt_empcode.Text + "/U - Loan&Advances");
                        ScriptManager.RegisterStartupScript(btn_loanSave, typeof(Button), "HRM", "alertify.alert('Details Updated...')", true);
                    }
                    Fn_Clear_Loan();
                    Fn_GrdLoanDetail();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_loanDelete_Click(object sender, EventArgs e)
        {
            try
            {
                obj_da_Employee.DelLoansAdvance(txt_LoanEmpcode.Text, DateTime.Parse(Utility.fn_ConvertDate(txt_takenon.Text)), txt_remark.Text);
                obj_da_Log.InsLogDetail(int_Empid, 173, 4, int_bid, txt_empcode.Text + "/D - Loan&Advances");

                Fn_Clear_Loan();
                Fn_GrdLoanDetail();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void btn_loanCancel_Click(object sender, EventArgs e)
        {
            Fn_Clear_Loan();
        }

        protected void txt_basic_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_lta.Text = double.Parse(txt_basic.Text).ToString();
            totalcomsalary();
            //btn_cancel.Text = "Cancel";

            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            txt_hra.Focus();
        }

        protected void txt_totalsalary_TextChanged(object sender, EventArgs e)
        {

        }


        protected void totalsal()
        {
            double amt = 0;
            if (txt_basic.Text == "")
            {
                txt_basic.Text = "0";
            }
            if (txt_hra.Text == "")
            {
                txt_hra.Text = "0";
            }
            if (txt_loyality.Text == "")
            {
                txt_loyality.Text = "0";
            }
            if (txt_lunchallow.Text == "")
            {
                txt_lunchallow.Text = "0";
            }
            if (txt_conveyance.Text == "")
            {
                txt_conveyance.Text = "0";
            }
            if (txt_entertain.Text == "")
            {
                txt_entertain.Text = "0";
            }
            if (txt_otherallow.Text == "")
            {
                txt_otherallow.Text = "0";
            }
            if (txt_driverallow.Text == "")
            {
                txt_driverallow.Text = "0";
            }
            if (txt_others.Text == "")
            {
                txt_others.Text = "0";
            }
            if (txt_medical.Text == "")
            {
                txt_medical.Text = "0";
            }
            amt = (double.Parse(txt_basic.Text) + double.Parse(txt_hra.Text) + double.Parse(txt_loyality.Text) + double.Parse(txt_lunchallow.Text) + double.Parse(txt_conveyance.Text) +
            double.Parse(txt_entertain.Text) + double.Parse(txt_otherallow.Text) + double.Parse(txt_driverallow.Text) + double.Parse(txt_others.Text) + double.Parse(txt_medical.Text));
            txt_totalsalary.Text = amt.ToString();

        }
        protected void totalcomsalary()
        {
            if (txt_lta.Text == "")
            {
                txt_lta.Text = "0";
            }
            if (txt_bonus.Text == "")
            {
                txt_bonus.Text = "0";
            }
            if (txt_ComMedical.Text == "")
            {
                txt_ComMedical.Text = "0";
            }
            if (txt_ComOthers.Text == "")
            {
                txt_ComOthers.Text = "0";
            }
            if (txt_comloyality.Text == "")
            {
                txt_comloyality.Text = "0";
            }

            txt_ComTotal.Text = (double.Parse(txt_lta.Text) + double.Parse(txt_bonus.Text) + double.Parse(txt_ComMedical.Text) + double.Parse(txt_ComOthers.Text) + double.Parse(txt_comloyality.Text)).ToString();
        }
        protected void totalalowsalary()
        {
            double value = 0;
            if (txt_petrol.Text == "")
            {
                txt_petrol.Text = "0";
            }
            if (txt_datacard.Text == "")
            {
                txt_datacard.Text = "0";
            }
            if (txt_driverwage.Text == "")
            {
                txt_driverwage.Text = "0";
            }
            if (txt_Allowmobile.Text == "")
            {
                txt_Allowmobile.Text = "0";
            }
            if (txt_phonesres.Text == "")
            {
                txt_phonesres.Text = "0";
            }
            if (txt_vma.Text == "")
            {
                txt_vma.Text = "0";
            }
            if (txt_Allowothers.Text == "")
            {
                txt_Allowothers.Text = "0";
            }

            value = Convert.ToDouble(double.Parse(txt_petrol.Text) + double.Parse(txt_datacard.Text) + double.Parse(txt_driverwage.Text) + double.Parse(txt_Allowmobile.Text) + double.Parse(txt_phonesres.Text) + double.Parse(txt_vma.Text) + double.Parse(txt_Allowothers.Text));
            Txt_AllowTotal.Text = value.ToString();
            btn_AllowanceSave.Enabled = true;
        }

        protected void txt_hra_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_loyality.Focus();
        }

        protected void txt_loyality_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_lunchallow.Focus();
        }

        protected void txt_lunchallow_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_conveyance.Focus();
        }

        protected void txt_conveyance_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_entertain.Focus();
        }

        protected void txt_entertain_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_otherallow.Focus();
        }

        protected void txt_otherallow_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_others.Focus();
        }

        protected void txt_others_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_driverallow.Focus();
        }

        protected void txt_driverallow_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_medical.Focus();
        }

        protected void txt_medical_TextChanged(object sender, EventArgs e)
        {
            totalsal();
            txt_medical.Focus();
        }

        protected void txt_lta_TextChanged(object sender, EventArgs e)
        {
            totalcomsalary();

        }

        protected void txt_bonus_TextChanged(object sender, EventArgs e)
        {
            totalcomsalary();
        }

        protected void txt_ComMedical_TextChanged(object sender, EventArgs e)
        {
            totalcomsalary();
        }

        protected void txt_ComOthers_TextChanged(object sender, EventArgs e)
        {
            totalcomsalary();

        }

        protected void txt_comloyality_TextChanged(object sender, EventArgs e)
        {
            totalcomsalary();
        }

        protected void txt_petrol_TextChanged(object sender, EventArgs e)
        {
            totalalowsalary();
            txt_datacard.Focus();
        }

        protected void txt_datacard_TextChanged(object sender, EventArgs e)
        {
            totalalowsalary();
            txt_driverwage.Focus();
        }

        protected void txt_driverwage_TextChanged(object sender, EventArgs e)
        {
            totalalowsalary();
            txt_Allowmobile.Focus();
        }

        protected void txt_Allowmobile_TextChanged(object sender, EventArgs e)
        {
            totalalowsalary();
            txt_phonesres.Focus();
        }

        protected void txt_phonesres_TextChanged(object sender, EventArgs e)
        {
            totalalowsalary();
            txt_vma.Focus();
        }

        protected void txt_vma_TextChanged(object sender, EventArgs e)
        {
            totalalowsalary();
            txt_Allowothers.Focus();
        }

        protected void txt_Allowothers_TextChanged(object sender, EventArgs e)
        {
            totalalowsalary();
        }

        protected void txt_car_TextChanged(object sender, EventArgs e)
        {

            if (txt_car.Text == "")
            {
                txt_car.Text = "0";
            }
            if (txt_car.Text == "0")
            {
                txt_AllowAmount.Text = "0";
            }
            if (txt_car.Text.ToString().Length <= 1600)
            {
                txt_AllowAmount.Text = "21600";
            }

            if (txt_car.Text.ToString().Length > 1600)
            {
                txt_AllowAmount.Text = "32200";
            }

            txt_AllowAmount.Text = "0";
        }

        protected void Txt_AllowTotal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_Tenure_TextChanged(object sender, EventArgs e)
        {
            if (txt_loanamount.Text == "")
            {
                txt_loanamount.Text = "0";
            }
            loalcal();
            txt_remark.Focus();
        }
        protected void loalcal()
        {
            DataAccess.HR.Employee PIObj = new DataAccess.HR.Employee();
            DataAccess.LogDetails logobj = new DataAccess.LogDetails();
            DataTable Dt;
            var month = "";
            if (txt_loanamount.Text != "")
            {
                month = 0.ToString();
                totloan = 0;
                Dt = PIObj.selEmpDetails(txt_empcode.Text, "LAD");
                if (Dt.Rows.Count > 0)
                {
                    for (i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        curryear = (logobj.GetDate()).Year;
                        laonyear = (Convert.ToDateTime(Utility.fn_ConvertDate(Dt.Rows[i]["takenon"].ToString()))).Year;
                        yr = curryear - laonyear;
                        LoanMon = Convert.ToDateTime(Utility.fn_ConvertDate(Dt.Rows[i]["takenon"].ToString()));
                        Currmon = logobj.GetDate().Date;

                        // DateTime start = new DateTime(2013, 1, 1);
                        //DateTime end = new DateTime(2014, 2, 1);
                        month = ((Currmon.Month + Currmon.Year * 12) - (LoanMon.Month + LoanMon.Year * 12)).ToString();
                        //if(LoanMon <= Currmon)
                        //{
                        //   mon =LoanMon.Month-Currmon.Month;
                        //}
                        //else
                        //{
                        //      mon =Currmon.Month-LoanMon.Month;
                        //}
                        if (Convert.ToInt32(month) > Convert.ToInt32(Dt.Rows[i]["tenure"].ToString()))
                        {
                            month = (Dt.Rows[i]["tenure"].ToString());
                        }
                        instamt = Convert.ToInt32(Dt.Rows[i]["loanamount"]) / Convert.ToInt32(Dt.Rows[i]["tenure"]);
                        monamt = Convert.ToInt32(month) * Convert.ToInt32(instamt);
                        totamt = Convert.ToInt32(Dt.Rows[i]["loanamount"]) - Convert.ToInt32(monamt);
                        totloan = totloan + totamt;
                    }
                    Grdtot = Convert.ToInt64(totloan);
                    curryear = (logobj.GetDate().Year);
                    //laonyear = (Convert.ToDateTime(txt_takenon.Text)).Month;
                    DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_takenon.Text));
                    laonyear = (date).Year;
                    yr = curryear - laonyear;
                    LoanMon = Convert.ToDateTime(Utility.fn_ConvertDate(txt_takenon.Text));
                    Currmon = logobj.GetDate();
                    // if( LoanMon <= Currmon)
                    // {
                    //     month = ((Currmon.Month + Currmon.Year * 12) - (LoanMon.Month + LoanMon.Year * 12)).ToString();
                    // }
                    //else
                    // {
                    //     month = ((Currmon.Month + Currmon.Year * 12) - (LoanMon.Month + LoanMon.Year * 12)).ToString();
                    // }
                    double amt1, amt2;
                    month = ((Currmon.Month + Currmon.Year * 12) - (LoanMon.Month + LoanMon.Year * 12)).ToString();
                    if (Convert.ToInt32(month) > Convert.ToDouble(txt_Tenure.Text))
                    {
                        month = (txt_Tenure.Text).ToString();
                    }
                    if (txt_Tenure.Text != "0")
                    {
                        amt1 = Convert.ToDouble(txt_loanamount.Text);
                        amt2 = Convert.ToDouble(txt_Tenure.Text);
                        instamt = amt1 / amt2;
                    }
                    monamt = Convert.ToDouble(month) * instamt;
                    totamt = Convert.ToDouble(txt_loanamount.Text) - (monamt);
                    txt_loantotal.Text = (Convert.ToDouble(totamt) + Convert.ToDouble(Grdtot)).ToString();
                }

            }
            else
            {
                curryear = (logobj.GetDate().Year);
                //laonyear = (Convert.ToDateTime(txt_takenon.Text).Year);
                DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txt_takenon.Text));
                laonyear = date.Year;
                yr = curryear - laonyear;
                LoanMon = Convert.ToDateTime(Utility.fn_ConvertDate(txt_takenon.Text));
                Currmon = logobj.GetDate();
                //if(LoanMon < Currmon)
                //{
                //    month = ((LoanMon.Month + LoanMon.Year * 12) - (Currmon.Month + Currmon.Year * 12)).ToString();
                //}
                //else
                //{
                //     month = ((LoanMon.Month + LoanMon.Year * 12) - (Currmon.Month + Currmon.Year * 12)).ToString();

                //}
                month = ((Currmon.Month + Currmon.Year * 12) - (LoanMon.Month + LoanMon.Year * 12)).ToString();
                if (Convert.ToInt32(month) > Convert.ToInt32(txt_Tenure.Text))
                {
                    month = Convert.ToInt32(txt_Tenure.Text).ToString();
                }
                if (txt_Tenure.Text != "0")
                {
                    instamt = Convert.ToDouble(txt_loanamount.Text) / Convert.ToDouble(txt_Tenure.Text);
                }

                monamt = Convert.ToInt32(month) * instamt;
                totamt = Convert.ToDouble(txt_loanamount.Text) - Convert.ToDouble(monamt);
                txt_loantotal.Text = totamt.ToString("#0.00");
            }


        }

        protected void Grd_Package_RowDataBound(object sender, GridViewRowEventArgs e)
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


                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Package, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Compensation_RowDataBound(object sender, GridViewRowEventArgs e)
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


                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Compensation, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void Grd_Contribution_RowDataBound(object sender, GridViewRowEventArgs e)
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


                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Contribution, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void cboxClose_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxClose.Checked == true)
            {
                cboxClose.Text = "OPEN";
            }
            else
            {
                cboxClose.Text = "CLOSE";
            }
        }

        protected void Grd_Loan_RowDataBound(object sender, GridViewRowEventArgs e)
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 173, "Job", "", "", Session["StrTranType"].ToString());

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


