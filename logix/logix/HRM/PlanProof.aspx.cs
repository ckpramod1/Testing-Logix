using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class PlanProof : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        public static int int_bid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fn_LoadDivision();
                Fn_LoadYear();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Gross";
                str_MsgLists = "Gross";
                str_DataType = "Double";
                btn_View.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
            }
        }
        public void Fn_LoadDivision()
        {
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDivisionhrm("M");
            ddl_company.DataSource = obj_dt;
            ddl_company.DataTextField = "divisionname";
            ddl_company.DataValueField = "divisionid";
            ddl_company.DataBind();
        }
        public void Fn_LoadBranch()
        {
            ddl_branch.Items.Clear();
            ddl_branch.Items.Add("ALL");
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.selBranchList(ddl_company.SelectedItem.Text);
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "branchname";
            ddl_branch.DataBind();
        }

        protected void ddl_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_company.SelectedItem.Text == "ALL")
            {
                ddl_branch.Enabled = false;
            }
            else
            {
                ddl_branch.Enabled = true;
                Fn_LoadBranch();
            }
        }
        private void Fn_LoadYear()
        {
            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            for (int i = 2008; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            if (ddl_company.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Select a Company');", true);
                return;
            }
            if (ddl_company.SelectedItem.Text != "ALL" && ddl_branch.SelectedItem.Text=="")
            {
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Select Branch');", true);
                return;
            }

            DataAccess.PAYROLL.RentDetailss obj_da_Rentdetail = new DataAccess.PAYROLL.RentDetailss();
            DataTable obj_dt=new DataTable();

            DateTime Dt_Date = obj_da_Log.GetDate();

            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            if (ddl_company.SelectedItem.Text != "ALL")
            {
                Str_sf = Str_sf + "{MasterEmployee.rol}=0 and {Masterbranch.divisionid}=" + ddl_company.SelectedValue.ToString();
            }
            if (ddl_branch.SelectedItem.Text != "ALL")
            {
                Str_sf = Str_sf + " and {Masterbranch.portid}=" + int_bid;
            }
            int int_month = 0,int_year=0;
            int_year = int.Parse(ddl_Year.SelectedValue.ToString());

            if (int_year == Dt_Date.Year)
            {
                int_month = Dt_Date.Month;
            }
            else if (int_year == Dt_Date.AddYears(-1).Year)
            {
                int_month = 3;
            }
            Str_sf = Str_sf + " and {HRSalaryDetails.basic}@{HRSalaryDetails.hra}@{HRSalaryDetails.sallowence}@{HRSalaryDetails.conveyance}@{HRSalaryDetails.others}@{HRSalaryDetails.medical}>" + txt_Gross.Text;
            Str_sf = Str_sf + " and Date (" + ddl_Year.SelectedValue.ToString() + ", " + int_month + ", 5) in {HRSalaryDetails.sfrom}  to  Date ({HRSalaryDetails.sto})";


            if (Rbt_House_Proof.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptHRProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {HRRentDetails.rp}>0 and {HRRentDetails.arp}>0 and {HRRentDetails.fy}=" +int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_House_Unproof.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptHRProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {HRRentDetails.rp}>0 and  {HRRentDetails.arp}=0 and {HRRentDetails.fy}="+int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_House_NotDeclared.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptHRProofNotDec.rpt";
                Str_sp = "nil=true";
                Str_sf = Str_sf + "and {HRRentDetails.rp}=0  and  {HRRentDetails.ataxrepat}=0  and  {HRRentDetails.arp}=0 and {HRRentDetails.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Medical_Proof.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptMCProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {hrmedicalamtrecvd.amount}>0  and  {hrmedicalamtrecvd.TarAmt}>0 and  {hrmedicalamtrecvd.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Medical_Unproof.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptMCProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {hrmedicalamtrecvd.amount}=0 and  {hrmedicalamtrecvd.TarAmt}>0 and  {hrmedicalamtrecvd.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Medical_NotDeclared.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptMCProofNotDec.rpt";
                Str_sp = "nil=true";
                Str_sf = Str_sf + "and {hrmedicalamtrecvd.amount}=0  and  {hrmedicalamtrecvd.TarAmt}=0 and  {hrmedicalamtrecvd.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Invest_Proof.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptInvAppProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {HREmpInvestDetails.investamt}>0 and {HREmpInvestDetails.investplan}<>\"PF\"  and  {HREmpInvestDetails.recvamt}>0 and  {HREmpInvestDetails.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Invest_Unproof.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptInvAppProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {HREmpInvestDetails.investplan}<>\"PF\"  and  {HREmpInvestDetails.recvamt}=0 and  {HREmpInvestDetails.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Invest_NotDeclared.Checked == true)
            {
                Str_RptName = "/Payroll/" + "rptInvAppProofNotDec.rpt";
                Str_sp = "nil=true";
                Str_sf = Str_sf + "and {HREmpInvestDetails.investamt}=0 and  {HREmpInvestDetails.investplan}=\"PF\" and  {HREmpInvestDetails.recvamt}=0 and  {HREmpInvestDetails.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Plan_Proof.Checked == true)
            {
                obj_dt = obj_da_Rentdetail.GetTempInsPlanApp(int_year);
                Str_RptName = "/Payroll/" + "rptAllProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {TempAllProof.MedRcvAmt}>0  and  {TempAllProof.MedTarAmt}>0 and  {TempAllProof.HusRntRcvAmt}>0 and  {TempAllProof.HusRntActAmt}>0 and  {TempAllProof.HusRntExmpAmt}>0 and  {TempAllProof.InvDtlInvAmt}>0 and  {TempAllProof.InvDtlRcvAmt}>0  and  {TempAllProof.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Plan_Unproof.Checked == true)
            {
                obj_dt = obj_da_Rentdetail.GetTempInsPlanApp(int_year);
                Str_RptName = "/Payroll/" + "rptAllProofRcv.rpt";
                Str_sp = "nil=false";
                Str_sf = Str_sf + "and {TempAllProof.MedRcvAmt}=0  and  {TempAllProof.MedTarAmt}=0 and  {TempAllProof.HusRntRcvAmt}=0 and  {TempAllProof.HusRntActAmt}=0 and  {TempAllProof.HusRntExmpAmt}=0 and  {TempAllProof.InvDtlInvAmt}=0 and  {TempAllProof.InvDtlRcvAmt}=0 and  {TempAllProof.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else if (Rbt_Plan_NotDeclared.Checked == true)
            {
                obj_dt = obj_da_Rentdetail.GetTempInsPlanApp(int_year);
                Str_RptName = "/Payroll/" + "rptAllProofNotDec.rpt";
                Str_sp = "nil=true";
                Str_sf = Str_sf + "and {TempAllProof.MedRcvAmt}=0  and  {TempAllProof.MedTarAmt}=0 and  {TempAllProof.HusRntRcvAmt}=0 and  {TempAllProof.HusRntActAmt}=0 and  {TempAllProof.HusRntExmpAmt}=0 and  {TempAllProof.InvDtlInvAmt}=0 and  {TempAllProof.InvDtlRcvAmt}=0 and  {TempAllProof.fy}=" + int_year;
                Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                Session["str_sfs"] = Str_sf;
                Session["str_sp"] = Str_sp;
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Choose Any One Option');", true);
            }
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            int_bid = obj_da_Port.GetNPortid(ddl_branch.SelectedItem.Text);
        }

    }
}