using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace logix.HRM
{
    public partial class StatutoryReport : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.PayrollProcess payobj = new DataAccess.PayrollProcess();
        DataAccess.Payroll.SatuatoryReport payprocobj = new DataAccess.Payroll.SatuatoryReport();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Clear);
           
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            
            if (!IsPostBack)
            {
                Fn_LoadYear();
                Fn_LoadDivision();
                LoadMonths();
                //Selected_month();
                //Selected_ToMonth();
                Fn_DisableTxt(false, false);
              //  btn_Clear.Text = "Cancel";

                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-cancel";
            }
           
        }
        protected void LoadMonths()
        {
            for (int i = 1; i <= 12;i++ )
            {
                ddl_From.Items.Add(Convert.ToDateTime(i.ToString() + "/1/2010").ToString("MMMM"));
                ddl_To.Items.Add(Convert.ToDateTime(i.ToString() + "/1/2010").ToString("MMMM"));
            }

            int d = ((obj_da_Log.GetDate()).Month);
             ddl_From.Text = Convert.ToDateTime(d.ToString() + "/1/2010").ToString("MMMM");
             ddl_To.Text = Convert.ToDateTime(d.ToString() + "/1/2010").ToString("MMMM");
        }

        protected void Selected_month()
        {
            if (ddl_From.SelectedItem.Text == "January")
            {
                ddl_From.SelectedValue = "1";
            }
            else if (ddl_From.SelectedItem.Text == "February")
            {
                ddl_From.SelectedValue = "2";
            }
            else if (ddl_From.SelectedItem.Text == "March")
            {
                ddl_From.SelectedValue = "3";
            }
            else if (ddl_From.SelectedItem.Text == "April")
            {
                ddl_From.SelectedValue = "4";
            }
            else if (ddl_From.SelectedItem.Text == "May")
            {
                ddl_From.SelectedValue = "5";
            }
            else if (ddl_From.SelectedItem.Text == "June")
            {
                ddl_From.SelectedValue = "6";
            }
            else if (ddl_From.SelectedItem.Text == "July")
            {
                ddl_From.SelectedValue = "7";
            }
            else if (ddl_From.SelectedItem.Text == "August")
            {
                ddl_From.SelectedValue = "8";
            }
            else if (ddl_From.SelectedItem.Text == "September")
            {
                ddl_From.SelectedValue = "9";
            }
            else if (ddl_From.SelectedItem.Text == "October")
            {
                ddl_From.SelectedValue = "10";
            }
            else if (ddl_From.SelectedItem.Text == "November")
            {
                ddl_From.SelectedValue = "11";
            }
            else if (ddl_From.SelectedItem.Text == "December")
            {
                ddl_From.SelectedValue = "12";
            }
        }


        protected void Selected_ToMonth()
        {
            if (ddl_To.SelectedItem.Text == "January")
            {
                ddl_To.SelectedValue = "1";
            }
            else if (ddl_To.SelectedItem.Text == "February")
            {
                ddl_To.SelectedValue = "2";
            }
            else if (ddl_To.SelectedItem.Text == "March")
            {
                ddl_To.SelectedValue = "3";
            }
            else if (ddl_To.SelectedItem.Text == "April")
            {
                ddl_To.SelectedValue = "4";
            }
            else if (ddl_To.SelectedItem.Text == "May")
            {
                ddl_To.SelectedValue = "5";
            }
            else if (ddl_To.SelectedItem.Text == "June")
            {
                ddl_To.SelectedValue = "6";
            }
            else if (ddl_To.SelectedItem.Text == "July")
            {
                ddl_To.SelectedValue = "7";
            }
            else if (ddl_To.SelectedItem.Text == "August")
            {
                ddl_To.SelectedValue = "8";
            }
            else if (ddl_To.SelectedItem.Text == "September")
            {
                ddl_To.SelectedValue = "9";
            }
            else if (ddl_From.SelectedItem.Text == "October")
            {
                ddl_To.SelectedValue = "10";
            }
            else if (ddl_To.SelectedItem.Text == "November")
            {
                ddl_To.SelectedValue = "11";
            }
            else if (ddl_To.SelectedItem.Text == "December")
            {
                ddl_To.SelectedValue = "12";
            }
        }

        private void Fn_LoadYear()
        {
            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_FYyear.Items.Clear();
            ddl_FYyear.Items.Add("");
            for (int i = 2008; i <= Dt_Date.Year; i++)
            {
                ddl_FYyear.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_FYyear.SelectedIndex = ddl_FYyear.Items.IndexOf(ddl_FYyear.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_FYyear.SelectedIndex = ddl_FYyear.Items.IndexOf(ddl_FYyear.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
          //  btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }
        public void Fn_LoadDivision()
        {
            ddl_company.Items.Clear();
            ddl_company.Items.Add("");
            DataAccess.HR.Employee da_obj_HrEmp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDivisionhrm("HR");
            ddl_company.DataSource = obj_dt;
            ddl_company.DataTextField = "divisionname";
            ddl_company.DataValueField = "divisionid";
            ddl_company.DataBind();
        }
        protected void Rbt_Bonus_CheckedChanged(object sender, EventArgs e)
        {
            Fn_DisableTxt(false, true,false);
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }
        public void Fn_DisableTxt(bool To, bool Bonus,bool From=true)
        {
            ddl_To.Enabled = To;
            ddl_To.SelectedIndex = 1;
            txt_To.Enabled = To;
            lbl_FYyear.Visible = Bonus;
            ddl_FYyear.Visible = Bonus;
            ddl_From.Enabled = From;
            txt_From.Enabled = From;
        }

        protected void Rbt_Attendance_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Attendance.Checked == true)
            {
                Fn_DisableTxt(false, false);
               // btn_Clear.Text = "Cancel";

                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void Rbt_CTC_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_CTC.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_SalarySummary_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_SalarySummary.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
        }

        protected void Rbt_SalarySheet_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_SalarySheet.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
           // btn_Clear.Text = "Cancel";


            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_LoPDays_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_LoPDays.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
            ///btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }


        protected void Rbt_ESIC_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_ESIC.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
          //  btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form3_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form3.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
          //  btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form5_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form5.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form7_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form7.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
           /// btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Challan12_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Challan12.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
            //btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Monthly_PF_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Monthly_PF.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_NewMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_NewMonthly.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form3A_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form3A.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
          //  btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form5_PF_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form5_PF.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
          //  btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form6A_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form6A.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
          //  btn_Clear.Text = "Cancel";
            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form9_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form9.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form10_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form10.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
         //   btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Form12A_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form12A.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_EPF_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_EPF.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Deduction_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Deduction.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
          //  btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_PT_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_PT.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
            //btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Rbt_Monthly_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Monthly.Checked == true)
            {
                Fn_DisableTxt(false, false);
            }
           // btn_Clear.Text = "Cancel";

            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            DateTime dtfroms;
            DateTime dttos;
            //Selected_month();
            //Selected_ToMonth();
            if (Fn_Check())

            {

                DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
                string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                if (Rbt_Attendance.Checked == true)
                {
                    Str_RptName = "/Payroll/" +"rptHRAttendance.rpt";
                    Session["str_sp"] = "Date=" + ddl_From.SelectedItem.Text + "'" + txt_From.Text;
                    Str_sf = "Month({HRAttendance.attdate})=" +ddl_From.SelectedIndex + "and Year({HRAttendance.attdate})=" + txt_From.Text + "and {MasterEmployee.division}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    //Session["str_sp"] = Str_sp;
                }
                else if (Rbt_CTC.Checked == true)
                {
                    Str_RptName = "/Payroll/" +"rptHRCtcMuster.rpt";
                    Str_sp = "Month=" + ddl_From.SelectedItem.Text;
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_SalarySummary.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRSalaryMuster.rpt";
                    Str_sp = "Month=" + ddl_From.SelectedItem.Text + "~From=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text + "~To=" + ddl_To.SelectedItem.Text + "\"" + txt_To.Text;
                    Str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_From.Text + "," +ddl_From.SelectedIndex + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <= Date(" + txt_To.Text + "," + ddl_To.SelectedIndex + ",01)" + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_SalarySheet.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRSalarySheet.rpt";
                    Str_sp = "date=" + ddl_From.SelectedItem.Text + "," + txt_From.Text;
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_LoPDays.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRLopday.rpt";
                    Str_sp = "";
                    Str_sf = "";
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Monthly.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHREsiStatement.rpt";
                    Str_sp = "";
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_ESIC.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptEsic.rpt";
                    Str_sp = "TittleFrm=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text + "~TittleTo=" + ddl_To.SelectedItem.Text + "\"" + txt_To.Text;
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form3.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHResiform3.rpt";
                    Str_sp = "";
                    Str_sf = "{MasterDivision.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form5.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHREsicForm5.rpt";
                    Str_sp = "TittleFrm=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text + "~TittleTo=" + ddl_To.SelectedItem.Text + "\"" + txt_To.Text;
                    Str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_From.Text + "," +ddl_From.SelectedIndex + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <= Date(" + txt_To.Text + "," + ddl_To.SelectedIndex + ",01)" + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form7.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptEsiForm7.rpt";
                    Str_sp = "";
                    Str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_From.Text + "," +ddl_From.SelectedIndex + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <= Date(" + txt_To.Text + "," + ddl_To.SelectedIndex + ",01)" + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Challan12.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHResichalln.rpt";
                    Str_sp = "date=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text;
                    Str_sf = "{HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Monthly_PF.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRpfstamnt.rpt";
                    Str_sp = "date=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text;
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_NewMonthly.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRPFMonthlyNew.rpt";
                    Session["str_sp"] = "TittleFrm=" + ddl_From.SelectedItem.Text + "'" + txt_From.Text;
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    //Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form3A.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRForm3A.rpt";
                    Str_sp = "Title From=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text + "~TittleTo=" + ddl_To.SelectedItem.Text + "\"" + txt_To.Text;
                    Str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_From.Text + "," +ddl_From.SelectedIndex + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <= Date(" + txt_To.Text + "," + ddl_To.SelectedIndex + ",01)" + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form5_PF.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRform5.rpt";
                    Str_sp = "date=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text;
                    Str_sf = "year({MasterEmployee.doj})=" + txt_From.Text + "and month({MasterEmployee.doj})=" +ddl_From.SelectedIndex + "and {MasterEmployee.division}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form6A.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRForm6A.rpt";
                    Str_sp = "Title From=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text + "~TittleTo=" + ddl_To.SelectedItem.Text + "\"" + txt_To.Text;
                    Str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_From.Text + "," +ddl_From.SelectedIndex + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <= Date(" + txt_To.Text + "," + ddl_To.SelectedIndex + ",01)" + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form9.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRForm9.rpt";
                    Str_sp = "FromYear=" + txt_From.Text + "~ToYear=" + txt_To.Text + "~FromMonth=" + ddl_From.SelectedItem.Text + "~ToMonth=" + ddl_To.SelectedItem.Text + "~Division=" + Session["LoginDivisionName"].ToString();
                    Str_sf = "year({MasterEmployee.dol})=" + txt_From.Text + "and month({MasterEmployee.dol})>=" +ddl_From.SelectedIndex + " and year({MasterEmployee.dol})=" + txt_To.Text + "and month({MasterEmployee.dol})<=" + ddl_To.SelectedIndex + "and {Masterdivision.Divisionid}=" + Session["LoginDivisionId"].ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form10.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRform10.rpt";
                    Str_sp = "dol=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text;
                    Str_sf = "year({MasterEmployee.dol})=" + txt_From.Text + "and month({MasterEmployee.dol})=" +ddl_From.SelectedIndex + "and {MasterEmployee.division}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form12A.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRFrom12A.rpt";
                    Str_sp = "date=" + ddl_From.SelectedItem.Text + "~year=" + txt_From.Text + "~month=" +ddl_From.SelectedIndex;
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_EPF.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRPFundOrg.rpt";
                    Str_sp = "date=" + "01/" +ddl_From.SelectedIndex + "/" + txt_From.Text + "~sysdate=" + obj_da_Log.GetDate().ToShortDateString();
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;


                    obj_da_Detail.GetReportDet12A(ddl_From.SelectedIndex, int.Parse(txt_From.Text), int.Parse(ddl_company.SelectedValue.ToString()));
                }
                else if (Rbt_Deduction.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRPfdedstatement.rpt";
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_Detail.getlmonthemp(ddl_From.SelectedIndex, int.Parse(txt_From.Text));
                    Str_sp = "Title=" + ddl_From.SelectedItem.Text + "\"" + txt_From.Text + "~lmonth=" + obj_dt.Rows[0]["lastmonth"].ToString() + "~add=" + obj_dt.Rows[0]["addition"].ToString() + "~sub=" + obj_dt.Rows[0]["deletion"].ToString();
                    Str_sf = "{HRPayroll.paymonth}=" +ddl_From.SelectedIndex + "and {HRPayroll.payyear}=" + txt_From.Text + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_PT.Checked == true)
                {
                    Str_RptName = "/Payroll/" + "rptHRPT.rpt";
                    Str_sp = "";
                    Str_sf = "Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + txt_From.Text + "," +ddl_From.SelectedIndex + ",01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <= Date(" + txt_To.Text + "," + ddl_To.SelectedIndex + ",01)" + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString();
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Bonus.Checked == true)
                {
                    string[] str_temp = ddl_FYyear.SelectedItem.Text.ToString().Split('-');
                    Str_RptName = "/Payroll/" + "rptHRBonus.rpt";
                    Str_sp = "";
                    Str_sf = "{HRBonusDetails.fnlyear}=" + str_temp[0] + "and {HRPayroll.divisionid}=" + ddl_company.SelectedValue.ToString() + " and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) >= Date(" + str_temp[0] + ",4,01) and Date({HRPayroll.payyear},{HRPayroll.paymonth},1) <= Date(" + (int.Parse(str_temp[1]) + 1) + ",03,31)";
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form16.Checked == true)
                {
                    int divid = Convert.ToInt32(Session["LoginDivisionId"]);
                    dtfroms = Convert.ToDateTime( (ddl_From.SelectedIndex) + "/01/" + (txt_From.Text));
                    dttos = Convert.ToDateTime( (ddl_To.SelectedIndex) +"/30/" + (txt_To.Text));
                    dt = payobj.GetTmpForm16WithIT(divid, dtfroms, dttos);
                  
                    if (divid == 1)
                    {
                    Str_RptName = "/Payroll/" + "Form16AnexureA1.rpt";
                    }
                    else
                    {
                     Str_RptName = "/Payroll/" + "Form16AnexureA1SYN.rpt"; 
                        
                    }

                    Str_sp = "fyyear=" + txt_From.Text;
                    Str_sf = "{tmpform16.rownumber}= C and {tmpform16.divisionid}=" + divid;
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = "{tmpform16.rownumber}= 'C' and {tmpform16.divisionid}=" + divid;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_Form16nonit.Checked == true)
                {
                    int divid = Convert.ToInt32(Session["LoginDivisionId"]);
                    dtfroms = Convert.ToDateTime((ddl_From.SelectedIndex) + "/01/" + (txt_From.Text));
                    dttos = Convert.ToDateTime((ddl_To.SelectedIndex) + "/30/" + (txt_To.Text));
                    dt = payobj.GetTmpForm16NTWithNonIT(divid, dtfroms, dttos);

                    if (divid == 1 ||divid == 7 || divid == 6)
                    {
                        Str_RptName = "/Payroll/" + "Form16AnexureA1NonIT.rpt";
                    }
                    else
                    {
                        Str_RptName = "/Payroll/" + "Form16AnexureA1NonITSYN.rpt";

                    }

                    Str_sp = "fyyear=" + txt_From.Text;
                    Str_sf = "{tmpform16.divisionid}=" + divid;
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = "{tmpform16.divisionid}=" + divid;
                    Session["str_sp"] = Str_sp;
                }
                else if (Rbt_24Q.Checked == true)
                {
                    int divid = Convert.ToInt32(Session["LoginDivisionId"]);
                    //dtfroms = Convert.ToDateTime((ddl_From.SelectedIndex) + "/01/" + (txt_From.Text));
                    //dttos = Convert.ToDateTime((ddl_To.SelectedIndex) + "/30/" + (txt_To.Text));
                    dt = payprocobj.GetSalaryslip();

                    Str_RptName = "/Payroll/" + "SalaryList24Q.rpt";
                    Str_sp = "";
                    Str_sf = "{tmpformsalaryslip.divisionid}=" + divid;
                    Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1131, 3, int.Parse(Session["LoginBranchid"].ToString()), "View");
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
                    Session["str_sfs"] = Str_sf;
                    Session["str_sp"] = Str_sp;
                }

                else
                {
                    ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Please Select Atleast One Report');", true);
                }
            }
          //  btn_Clear.Text = "Cancel";


            btn_Clear.ToolTip = "Cancel";
            btn_Clear1.Attributes["class"] = "btn ico-cancel";
        }

        private bool Fn_Check()
        {
            //Selected_month();
            //Selected_ToMonth();
            bool Check = true;
            if (ddl_company.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Please Select Company')", true);
                return Check = false;
            }
            else if (ddl_From.SelectedIndex == 0 && ddl_From.Enabled == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Please Select From Month')", true);
                return Check = false;
            }
            else if (txt_From.Enabled == true && txt_From.Text.TrimEnd().Length < 4)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Please Select From Year')", true);
                return Check = false;
            }
            else if (ddl_To.Enabled == true && ddl_To.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Please Select To Month')", true);
                return Check = false;
            }
            else if (txt_To.Enabled == true && txt_To.Text.TrimEnd().Length < 4)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Please Select To Year')", true);
                return Check = false;
            }

            if (ddl_To.Enabled == true && txt_To.Enabled == true)
            {
                DateTime Dt_From, Dt_To;
                Dt_From = DateTime.Parse(ddl_From.SelectedIndex + "/01/" + txt_From.Text);
                Dt_To = DateTime.Parse(ddl_To.SelectedIndex + "/01/" + txt_To.Text);
                if (Dt_To < Dt_From)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('From Month is equal or Greaterthan to TO Month')", true);
                    return Check = false;
                }
            }
            return Check;
        }

        protected void Checked_false()
        {
            Rbt_Attendance.Checked = false;
            Rbt_CTC.Checked = false;
            Rbt_SalarySummary.Checked = false;
            Rbt_SalarySheet.Checked = false;
            Rbt_LoPDays.Checked = false;
            Rbt_Monthly.Checked = false;
            Rbt_ESIC.Checked = false;
            Rbt_Form3.Checked = false;
            Rbt_Form5.Checked = false;
            Rbt_Form7.Checked = false;
            Rbt_Challan12.Checked = false;

            Rbt_Monthly_PF.Checked = false;
            Rbt_Form10.Checked = false;
            Rbt_NewMonthly.Checked = false;
            Rbt_Form12A.Checked = false;

            Rbt_Form3A.Checked = false;
            Rbt_EPF.Checked = false;
            Rbt_Form5_PF.Checked = false;
            Rbt_Deduction.Checked = false;

            Rbt_Form6A.Checked = false;
            Rbt_Form9.Checked = false;
            Rbt_PT.Checked = false;
            Rbt_Form16.Checked = false;

            Rbt_Form16nonit.Checked = false;
            Rbt_24Q.Checked = false;
            Rbt_Bonus.Checked = false;
           

        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (btn_Clear.ToolTip == "Cancel")
            {
              //  btn_Clear.Text = "Back";


                btn_Clear.ToolTip = "Back";
                btn_Clear1.Attributes["class"] = "btn ico-back";
                txt_From.Text = "";
                txt_To.Text = "";
                ddl_company.SelectedIndex = 0;
                ddl_From.SelectedIndex = 0;
                ddl_To.SelectedIndex = 0;
                Checked_false();
            }
            else
            {
                this.Response.End();
            }
        }

        protected void Rbt_Form16_CheckedChanged(object sender, EventArgs e)
        {
        //     If rdbform16.Checked = True Then
        //    cmbToMonth.Enabled = True
        //    txtToYear.Enabled = True
        //    txtBonus.Visible = False
        //    cmbYear.Visible = False
        //    Label6.Visible = False
        //    btnexcel.Visible = False
        //End If

               //if(Rbt_Form16.Checked==true)
               //{
               //    ddl_From.Enabled = true;
               //    txt_To.Enabled = true;
               //    ddl_FYyear.Visible = false;
                   
               //}
            if (Rbt_Form16.Checked == true)
            {
                Fn_DisableTxt(true, false);
            }
        }

        protected void Rbt_Form16nonit_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_Form16nonit.Checked == true)
            {
                Fn_DisableTxt(true, false);
               // btn_Clear.Text = "Cancel";


                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-cancel";
            }
        }

        protected void Rbt_24Q_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbt_24Q.Checked == true)
            {
                Fn_DisableTxt(true, false);
              //  btn_Clear.Text = "Cancel";

                btn_Clear.ToolTip = "Cancel";
                btn_Clear1.Attributes["class"] = "btn ico-cancel";
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
            PanelLog1.Visible = true;
            GridViewlog.Visible = true;
            Panel3.Visible = true;

            DataTable obj_dtlogdetails = new DataTable();

            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1131, "", "", "", ""); 
            //if (txt_customer.Text != "")
            //{
            //    JobInput.Text = txt_customer.Text;


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