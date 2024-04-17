using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logix;
using System.Data;

namespace logix.Home
{
    public partial class AppPage5 : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        DataSet dskpi = new DataSet();
        int year = 0;
        double totselfkpi = 0;
        double totselfcomp = 0;
        string sendqry;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnprevious1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsubmit);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            if (!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                dtcom = da_obj_Employee.GetEmpidAppraisalCom(employeeid);
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                if (dtcom.Rows.Count > 0)
                {
                    txtempcode.Text = dtcom.Rows[0]["UserName"].ToString();
                    txtempname.Text = dtcom.Rows[0]["empname"].ToString();
                    txtdept.Text = dtcom.Rows[0]["deptname"].ToString();
                    txtdesig.Text = dtcom.Rows[0]["designame"].ToString();
                    txtlocation.Text = dtcom.Rows[0]["shortname"].ToString();
                    txtgrossmon.Text = string.Format("{0:#,##0.00}", dtcom.Rows[0]["MonthlyGross"]);
                    txtgrade.Text = dtcom.Rows[0]["grade"].ToString();
                    txtdoj.Text = dtcom.Rows[0]["doj"].ToString();
                    txtdoc.Text = dtcom.Rows[0]["doc"].ToString();
                    txtctcann.Text = string.Format("{0:#,##0.00}", dtcom.Rows[0]["AnnualCTC"]);
                    txtctcmon.Text = string.Format("{0:#,##0.00}", dtcom.Rows[0]["MonthlyCTC"]);
                }

                dskpi = da_obj_Employee.GetKPITotalRating(employeeid, year);
                if (dskpi.Tables[0].Rows.Count > 0)
                {
                    txtselfkpi.Text = dskpi.Tables[0].Rows[0]["selfkpi"].ToString();
                    totselfkpi = Convert.ToDouble(dskpi.Tables[0].Rows[0]["selfkpi"].ToString());
                }
                if (dskpi.Tables[1].Rows.Count > 0)
                {
                    txtselfcomp.Text = dskpi.Tables[1].Rows[0]["selfcomp"].ToString();
                    totselfcomp = Convert.ToDouble(dskpi.Tables[1].Rows[0]["selfcomp"].ToString());
                }
                totself.Text = (totselfkpi + totselfcomp).ToString();

                if (Convert.ToDouble(totself.Text) >= 0)
                {
                    lblkeyappraisee.Visible = true;
                    lblkeyappraisee.Visible = true;
                    if (Convert.ToDouble(totself.Text) < 60)
                    {
                        lblkeyappraisee.Text = "Needs Improvement";
                        lblkeyappraisee.ToolTip = "Performance is inconsistent.Meets requirements of the job occasionally. Supervision and Training is required for most problem area. Performance needs to be reviewed, may need to be replaced.";
                    }
                    else if (Convert.ToDouble(totself.Text) >= 60 && Convert.ToDouble(totself.Text) < 80)
                    {
                        lblkeyappraisee.Text = "Good";
                        lblkeyappraisee.ToolTip = "Performance is consistent. Clearly meets essential requirements of job . Performance should be 75% on prescribed matrix level";
                    }
                    else if (Convert.ToDouble(totself.Text) >= 80 && Convert.ToDouble(totself.Text) <= 90)
                    {
                        lblkeyappraisee.Text = "Very Good";
                        lblkeyappraisee.ToolTip = "Performance is consistent and exceeds expectations in all situations . Performance should be 80% to 100% on prescribed matrix level.";
                    }
                    else
                    {
                        lblkeyappraisee.Text = "Outstanding";
                        lblkeyappraisee.ToolTip = "Performance is exceptional and far exceeds expectations . Consistently demonstrates excellent standards in all job requirements. Performance should be 30% above prescribed matrix level.";
                    }
                }

            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtselfkpi.Text == "" && txtselfcomp.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Complete the Rating and then Submit');", true);
                return;
            }
            else
            {
                employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                da_obj_Employee.InsKpiEmpSubmit(employeeid, year);
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Employee Appraisal Submitted Successfully');", true);
                sendLCMail();
                //Response.Redirect("../Home/Profile.aspx");
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnprevious1_Click(object sender, EventArgs e)
        {
            if (txtgrade.Text.Substring(0, 1).ToString() == "M")
            {
                Response.Redirect("Apppage4.aspx");
            }
            else
            {
                Response.Redirect("Apppage3.aspx");
            }
        }

        public void sendLCMail()
        {
            DataSet obj_dt = new DataSet();
            string Appmailid = "";
            string empid = "";
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            obj_dt = da_obj_Employee.GetEmpAppraiserDtlsforMail(employeeid);
            if (obj_dt.Tables[0].Rows.Count > 0)
            {
                if (obj_dt.Tables[1].Rows.Count > 0)
                {
                    if (obj_dt.Tables[2].Rows.Count > 0)
                    {
                        Appmailid = obj_dt.Tables[0].Rows[0]["offmailid"].ToString();
                        empid = obj_dt.Tables[2].Rows[0]["offmailid"].ToString();
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear " + obj_dt.Tables[0].Rows[0]["AppraisalBy"].ToString() + ",</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> " + obj_dt.Tables[2].Rows[0]["EmployeeName"].ToString() + " has completed the appraisal.You can initiate the appraisal process through Software.</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> Auto Generated Mail.   </FONT></td></tr></table><br>";
                        Utility.SendMail(empid, Appmailid, "Appraisal - 2017-2018", sendqry, "", Session["usermailpwd"].ToString(), "VS@copperhawk.tech", "");
                    }
                }
            }
         
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString()) - 1;

            str_RptName = "RptKpiWoRec.rpt";
            str_sf = "{HRKPI.empid}=" + employeeid + " and {HRKPI.KPIYear}= " + year ;
            str_sp = "";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Appraisal Details", str_Script, true);
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }
    }


}
