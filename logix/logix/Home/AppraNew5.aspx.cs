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
    public partial class AppraNew5 : System.Web.UI.Page
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
        double totappkpi = 0;
        double totappcomp = 0;
        string sendqry;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnprevious1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsubmit);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel); 
           // Counter.HitCounter(); 

            if (!IsPostBack)
            {                
                employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
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
                    txtappkpi.Text = dskpi.Tables[0].Rows[0]["appkpi"].ToString();
                    totappkpi = Convert.ToDouble(dskpi.Tables[0].Rows[0]["appkpi"].ToString());
                    txtappremarks.Text = dskpi.Tables[0].Rows[0]["appremarks"].ToString();
                }
                if (dskpi.Tables[1].Rows.Count > 0)
                {
                    txtselfcomp.Text = dskpi.Tables[1].Rows[0]["selfcomp"].ToString();
                    totselfcomp = Convert.ToDouble(dskpi.Tables[1].Rows[0]["selfcomp"].ToString());
                    txtappcomp.Text = dskpi.Tables[1].Rows[0]["appcomp1"].ToString();
                    totappcomp = Convert.ToDouble(dskpi.Tables[1].Rows[0]["appcomp1"].ToString());
                }
                totself.Text = (totselfkpi + totselfcomp).ToString();
                totalapp.Text = (totappkpi + totappcomp).ToString();

                if (Convert.ToDouble(totalapp.Text) >= 0)
                {
                    lblkeylabel.Visible = true;
                    lblkeyvalue.Visible = true;
                    if (Convert.ToDouble(totalapp.Text) < 60)
                    {
                        lblkeyvalue.Text = "Needs Improvement";
                        lblkeyvalue.ToolTip = "Performance is inconsistent.Meets requirements of the job occasionally. Supervision and Training is required for most problem area. Performance needs to be reviewed, may need to be replaced.";
                    }
                    else if (Convert.ToDouble(totalapp.Text) >= 60 && Convert.ToDouble(totalapp.Text) < 80)
                    {
                        lblkeyvalue.Text = "Good";
                        lblkeyvalue.ToolTip = "Performance is consistent. Clearly meets essential requirements of job . Performance should be 75% on prescribed matrix level";
                    }
                    else if (Convert.ToDouble(totalapp.Text) >= 80 && Convert.ToDouble(totalapp.Text) <= 90)
                    {
                        lblkeyvalue.Text = "Very Good";
                        lblkeyvalue.ToolTip = "Performance is consistent and exceeds expectations in all situations . Performance should be 80% to 100% on prescribed matrix level.";
                    }
                    else
                    {
                        lblkeyvalue.Text = "Outstanding";
                        lblkeyvalue.ToolTip = "Performance is exceptional and far exceeds expectations . Consistently demonstrates excellent standards in all job requirements. Performance should be 30% above prescribed matrix level.";
                    }
                }

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
            //if (txtappkpi.Text == "" && txtappcomp.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Complete the Rating and then Submit');", true);
            //    return;
            //}
            //else
            //{
            employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            da_obj_Employee.InsKpiAppraiserSubmittedon(employeeid, year,txtappremarks.Text);
            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Appraisal Details Saved');", true);
            sendLCMail();
           // MasterPage master = (MasterPage)(this.Master);
            Response.Redirect("../Home/AppraiserPage.aspx");
            //ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "fn_test();", true);

            //Session["submit"] = "Home";
            ////logix.FormMain form = new FormMain();
            ////form.Page_Load(sender,e);

            //// ifrmaster.Attributes["src"] = "MainModuleNew.aspx";

            //   // Response.Redirect("../MainModuleNew.aspx");
            //    //Response.Redirect("../FormMain.aspx");
            //    //string apprise = "apprise";
            //    //Session["apprise"] = "";
            ////Response.Redirect("../Home/AppraiserPage.aspx");
            ////}

            ////Response.Redirect("../Appraisal/formappraiser.aspx");

            ////Response.Write("../FormMain.aspx"); // redirect on itself
            ////Response.Write("<br /> Counter =" + Counter.GetCounter());
            ////Response.Redirect(Request.RawUrl);

            ////Page.Redirect("../FormMain.aspx", false);
            ////Refresh();
            //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "getData();", true);
            //Server.Transfer("../FormMain.aspx", true);
            ////Response.Redirect("../FormMain.aspx");
        }

        protected void btnprevious1_Click(object sender, EventArgs e)
        {

            if (txtgrade.Text.Substring(0, 1).ToString() == "M")
            {
                Response.Redirect("AppPage4A.aspx");
            }
            else
            {
                Response.Redirect("Appraiser6.aspx");
            }


            //if (Session["appraisal"] != null)
            //{
            //    if (Session["appraisal"].ToString() == "appraisal")   
            //    {
            //        Response.Redirect("Appraiser6.aspx");
            //    }

            //    else
            //    {
            //        Response.Redirect("AppPage4A.aspx");
            //    }
            //}
        }



        protected void btncancel_Click(object sender, EventArgs e)
        {

        }

        public void sendLCMail()
        {
            DataSet obj_dt = new DataSet();
            string Appmailid = "";
            string empid = "";
            employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
            obj_dt = da_obj_Employee.GetEmpAppraiserDtlsforMail(employeeid);
            if (obj_dt.Tables[0].Rows.Count > 0)
            {
                if (obj_dt.Tables[1].Rows.Count > 0)
                {
                    if (obj_dt.Tables[2].Rows.Count > 0)
                    {
                        Appmailid = obj_dt.Tables[0].Rows[0]["offmailid"].ToString();
                        empid = obj_dt.Tables[2].Rows[0]["offmailid"].ToString();
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear " + obj_dt.Tables[2].Rows[0]["EmployeeName"].ToString() + ",</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> " + obj_dt.Tables[0].Rows[0]["AppraisalBy"].ToString() + " has completed your appraisal . Your requested to confirm the same through    . </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> Auto Generated Mail.   </FONT></td></tr></table><br>";
                        Utility.SendMail(Appmailid, empid, "Appraisal - 2017-2018", sendqry, "", Session["usermailpwd"].ToString(), "", "");
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
            employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());

            str_RptName = "RptKpiWoRec.rpt";
            str_sf = "{HRKPI.empid}=" + employeeid + " and {HRKPI.KPIYear}= " + year;
            str_sp = "";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Appraisal Details", str_Script, true);
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }

        //public virtual void Refresh();
    }

}