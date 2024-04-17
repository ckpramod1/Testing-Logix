using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;


namespace logix.HRM
{
    public partial class HRMMis : System.Web.UI.Page
    {
        string str_RptName = "";
        string str_sp = "";
        string str_sf = "";
        string str_Script = "";
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string submenuname;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if(!IsPostBack)
            {
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                UnChecked();
                //btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                div_Totxt.Enabled = false;
                txtFromdate.Enabled = false;
            }
            
        }

        protected void  UnChecked()
        {
            rbtnEList.Checked = false;
            rbtnEmp.Checked = false;
            rbtnCtc.Checked = false;
            chboxPackages.Checked = false;
            rbtnSalary.Checked = false;
            rbtnCompensation.Checked = false;
            rbtnContribution.Checked = false;
        }

        protected void EnablePackage()
        {
            rbtnSalary.Enabled = true;
            rbtnCompensation.Enabled = true;
            rbtnContribution.Enabled = true;
            rbtnAllowences.Enabled = true;
        }

        protected void DisablePackage()
        {
            rbtnSalary.Enabled = false;
            rbtnCompensation.Enabled = false;
            rbtnContribution.Enabled = false;
            rbtnAllowences.Enabled = false;
        }

        protected void PrintEmpLst()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Employee Details";
            str_RptName = "HREmpList.rpt";
            Session["str_sfs"] = "{MasterEmployee.rol}=0 and {MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "')";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
            //Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnEList.Checked = false;
        }

        protected void PrintPendingConfirmation()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Employee Details";
            str_RptName = "HREmpList.rpt";
            Session["str_sfs"] = "{MasterEmployee.rol}=0 and {MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "') and isnull({MasterEmployee.doc})";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
           // Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnEList.Checked = false;
        }

        protected void PrintSalary()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Employee Details";
            str_RptName = "HREmpSalDetails.rpt";
            Session["str_sfs"] = "{MasterEmployee.rol}=0 and {MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "')";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
            //Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnSalary.Checked = false;
            chboxPackages.Checked = false;
        }

        protected void PrintCompensation()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Employee Details";
            str_RptName = "HREmpComDetails.rpt";
            Session["str_sfs"] = "{MasterEmployee.rol}=0 and {MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "')";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
           // Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnCompensation.Checked = false;
            chboxPackages.Checked = false;
        }

        protected void PrintAllowances()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Employee Details";
            str_RptName = "HREmpAllDetails.rpt";
            Session["str_sfs"] = "{MasterEmployee.rol}=0 and {MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "')";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
           // Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnAllowences.Checked = false;
            chboxPackages.Checked = false;
        }

        protected void PrintContribution()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Employee Details";
            str_RptName = "HREmpConDetails.rpt";
            Session["str_sfs"] = "{MasterEmployee.rol}=0 and {MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "')";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
          //  Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnContribution.Checked = false;
            chboxPackages.Checked = false;
        }


        protected void PrintEmpNewLeft()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate( txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime( Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Employee Details";
            str_RptName = "HREmpList.rpt";
            Session["str_sfs"] = "{MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "') and {MasterEmployee.rol}=0";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
           // Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;

            str_sp = "Employee Details";
            str_RptName = "HREmpListLeft.rpt";
            Session["str_sfs"] = "{MasterEmployee.dol}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.dol}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "') and {MasterEmployee.rol}<>0";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
           // Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnEmp.Checked = false;
        }

        protected void PrintCTC()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "C T C";
            str_RptName = "HRCTC.rpt";
            Session["str_sfs"] = "{MasterEmployee.rol}=0 and {MasterEmployee.doj}>=date('" + date.Year + "," + date.Month + "," + date.Day + "') and {MasterEmployee.doj}<=date('" + dateTo.Year + "," + dateTo.Month + "," + dateTo.Day + "')";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
          //  Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnCtc.Checked = false;
        }

        protected void PrintLoyalty()
        {
            DateTime date = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            DateTime dateTo = Convert.ToDateTime(Utility.fn_ConvertDate(div_Totxt.Text));
            str_sp = "Loyalty";
            str_RptName = "HRLoyaltyReport.rpt";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "MIS", str_Script, true);
           // Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
            rbtnLoyality.Checked = false;
        }

        protected void chboxPackages_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxPackages.Checked==true)
            {
                rbtnEList.Checked = false;
                EnablePackage();
                rbtnPendingCon.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                rbtnEmp.Checked = false;
                rbtnCtc.Checked = false;
            }
            else
            {
                rbtnEList.Checked = false;
                DisablePackage();
                //btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            div_Totxt.Enabled = false;
            txtFromdate.Enabled = false;
        }

        protected void rbtnEmp_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEmp.Checked == true)
            {
                DisablePackage();
                chboxPackages.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }

            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnAllowences_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAllowences.Checked == true)
            {
                //chboxPackages.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnCompensation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCompensation.Checked == true)
            {
                //chboxPackages.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnContribution_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnContribution.Checked == true)
            {
               // chboxPackages.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnCtc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCtc.Checked == true)
            {
                DisablePackage();
                chboxPackages.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnEList_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEList.Checked == true)
            {
                DisablePackage();
                chboxPackages.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnSalary_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSalary.Checked == true)
            {
               // chboxPackages.Checked = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnPendingCon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPendingCon.Checked == true)
            {
                DisablePackage();
              chboxPackages.Checked = false;
              txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
              div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                txtFromdate.Enabled = true;
                div_Totxt.Enabled = true;
            }
            else
            {
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;

            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void rbtnLoyality_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnLoyality.Checked == true)
            {
                DisablePackage();
                txtFromdate.Enabled = false;
                div_Totxt.Enabled = false;
            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
           
            if (rbtnEList.Checked==true)
            {
                chboxPackages.Checked = false;
                PrintEmpLst();
           
            }
            else if (rbtnEmp.Checked == true)
            {
                  chboxPackages.Checked = false;
                  PrintEmpNewLeft();
            }

            else if (rbtnCtc.Checked == true)
            {
                 chboxPackages.Checked = false;
                 PrintCTC();
            }
            else if (rbtnPendingCon.Checked == true)
            {
                chboxPackages.Checked = false;
                PrintPendingConfirmation();
            }

            else if (rbtnLoyality.Checked == true)
            {
                chboxPackages.Checked = false;
                PrintLoyalty();
            }

            else if (chboxPackages.Checked == true)
            {

                if (rbtnSalary.Checked==true)
                {
                    PrintSalary();
                }
                else if (rbtnCompensation.Checked == true)
                {
                    PrintCompensation();
                }
                else if (rbtnContribution.Checked == true)
                {
                    PrintContribution();
                }
                else if (rbtnAllowences.Checked == true)
                {
                    PrintAllowances();
                }
            }
            Logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 171,3, int.Parse(Session["LoginBranchid"].ToString()), "View");
            txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
            div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if(btncancel.ToolTip=="Cancel")
            {
                //btncancel.Text = "Back";
                btncancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                div_Totxt.Enabled = false;
                txtFromdate.Enabled = false;
                txtFromdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                div_Totxt.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                UnChecked();
               
            }
            else
            {
                this.Response.End();
            }
        }

    }
}