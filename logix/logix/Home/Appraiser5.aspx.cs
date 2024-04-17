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
    public partial class Appraiser5 : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();
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
        Boolean bol;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnprevious1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsubmit);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            if (!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
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

                Fn_LoadDesignation();
                Fn_Loadgrade();

               
                    ddldesignation.SelectedValue = dtcom.Rows[0]["designame"].ToString();
               
               
                   ddlgrade.SelectedValue = dtcom.Rows[0]["grade"].ToString();
              
               

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
                

                if(dskpi.Tables[2].Rows.Count > 0)
                {
                    if (dskpi.Tables[2].Rows[0]["SalRevAmt"].ToString() == "")
                    {
                        Label9.Enabled = false;
                        txtsalrev.Enabled = false;
                        ddlsal.SelectedIndex = 1;
                    }
                    else
                    {
                        Label9.Enabled = true;
                        ddlmode.Enabled = true;
                        ddlmode.SelectedIndex = Convert.ToInt32(dskpi.Tables[2].Rows[0]["revsalmode"].ToString());
                        txtsalrev.Enabled = true;
                        txtsalrev.Text = string.Format("{0:#,##0.00}",dskpi.Tables[2].Rows[0]["SalRevAmt"]);
                        ddlsal.SelectedIndex = 2;
                    }
                    
                    txtspecialremarks.Text = dskpi.Tables[2].Rows[0]["spremarks"].ToString();

                    if (dskpi.Tables[2].Rows[0]["regrade"].ToString() == "2")
                    {
                        Label15.Enabled = true;
                        ddlgrade.Enabled = true;
                        ddlgrade.SelectedItem.Text = dskpi.Tables[2].Rows[0]["Grade"].ToString();
                        ddlgradestatus.SelectedIndex = 2;
                    }
                    else
                    {
                        Label15.Enabled = false;
                        ddlgrade.Enabled = false;
                        ddlgradestatus.SelectedIndex = 1;
                        ddlgrade.SelectedItem.Text = txtgrade.Text;
                    }
                    if (dskpi.Tables[2].Rows[0]["redesig"].ToString() == "2")
                    {
                        Label11.Enabled = true;
                        ddldesignation.Enabled = true;
                        ddldesignation.SelectedItem.Text = dskpi.Tables[2].Rows[0]["designame"].ToString();
                        ddlredesig.SelectedIndex = 2;
                    }
                    else
                    {
                        Label11.Enabled = false;
                        ddldesignation.Enabled = false;
                        ddlredesig.SelectedIndex = 1;
                        ddldesignation.SelectedItem.Text = txtdesig.Text;
                    }
                    
                }

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

        protected void btnprevious1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RevPage4A.aspx");
        }

        public void checkdata()
        {

            if (ddlsal.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Kindly Select anyone in Salary Changes');", true);
                ddlsal.Focus();
                bol = true;
                return;
            }
            if (ddlsal.SelectedItem.Value == "2")
            {
                if(ddlmode.SelectedItem.Value != "0")
                {
                    if(ddlmode.SelectedItem.Value == "1")
                    {
                        if (txtsalrev.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Enter Salary Amount');", true);
                            txtsalrev.Focus();
                            bol = true;
                            return;
                        }
                        else if (Convert.ToDouble(txtsalrev.Text) > 100)
                        {
                            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Salary Percentage must be less than 100');", true);
                            txtsalrev.Focus();
                            bol = true;
                            return;
                        }
                    }
                    else
                    {
                        if (txtsalrev.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Enter Salary Amount');", true);
                            txtsalrev.Focus();
                            bol = true;
                            return;
                        }
                    }
                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select Mode of Salary');", true);
                    txtsalrev.Focus();
                    bol = true;
                    return;
                }
               
            }

            if (ddlredesig.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one in Re-Designation Status');", true);
                ddlredesig.Focus();
                bol = true;
                return;
            }

            if (ddlredesig.SelectedItem.Value == "2")
            {
                if (ddldesignation.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one in Re-Designation');", true);
                    ddldesignation.Focus();
                    bol = true;
                    return;
                }
            }

            if (ddlgradestatus.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one Grade Status');", true);
                ddlgradestatus.Focus();
                bol = true;
                return;
            }

            if (ddlgradestatus.SelectedItem.Value == "2")
            {
                if (ddlgrade.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one in Grade');", true);
                    ddlgrade.Focus();
                    bol = true;
                    return;
                }
            }


        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int intDesigID = 0;
            if (txtappkpi.Text == "" && txtappcomp.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Complete the Rating and then Submit');", true);
                return;
            }
            else
            {
                checkdata();
                if (bol == true)
                {
                    bol = false;
                    return;
                }
                employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                intDesigID = empObj.GetDesgnid(ddldesignation.SelectedItem.Text);
                da_obj_Employee.InsKpiAppraiserSubmit(employeeid, year, Convert.ToInt32(ddlsal.SelectedItem.Value.ToString()), Convert.ToDouble(txtsalrev.Text), Convert.ToInt32(ddlredesig.SelectedItem.Value.ToString()), intDesigID, Convert.ToInt32(ddlgradestatus.SelectedItem.Value.ToString()), ddlgrade.SelectedItem.Value.ToString(), txtspecialremarks.Text,Convert.ToInt32(ddlmode.SelectedItem.Value.ToString()));
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert(' Appraisal Details Saved');", true);
                sendLCMail();
               // Response.Redirect("../Home/Profile.aspx");
                if (Session["REV"] != null)
                {
                    if (Session["REV"].ToString() == "Y")
                    {
                        Response.Redirect("../Home/ReviewerPage.aspx");
                    }
                    else if (Session["REV"].ToString() == "N")
                    {
                        Response.Redirect("../Home/RevCompleteList.aspx");
                    }
                }
            }
        }

        private void Fn_LoadDesignation()
        {
            DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDesign();
            ddldesignation.DataSource = obj_dt;
            ddldesignation.DataTextField = "designame";
            ddldesignation.DataBind();
        }

        private void Fn_Loadgrade()
        {
            //DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_Employee.GetGradeForKPI();
            ddlgrade.DataSource = obj_dt;
            ddlgrade.DataTextField = "grade";
            ddlgrade.DataBind();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }

        protected void ddlsal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlsal.SelectedItem.Value == "2")
            {
                Label9.Enabled = true;
                ddlmode.Enabled = true;
                txtsalrev.Enabled = true;
                txtsalrev.Focus();
            }
            else
            {
                Label9.Enabled = false;
                ddlmode.Enabled = false;
                txtsalrev.Enabled = false;
                txtsalrev.Text = "0";
            }
        }

        protected void ddlgradestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlgradestatus.SelectedItem.Value == "2")
            {
                Label15.Enabled = true;
                ddlgrade.Enabled = true;
                ddlgrade.Focus();
            }
            else
            {
                Label15.Enabled = false;
                ddlgrade.Enabled = false;
            }
        }

        public void sendLCMail()
        {
            DataSet obj_dt = new DataSet();
            string Appmailid = "";
            string empid = "";
            string reviewmailid = "";
            employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
            obj_dt = da_obj_Employee.GetEmpAppraiserDtlsforMail(employeeid);
            if (obj_dt.Tables[0].Rows.Count > 0)
            {
                if (obj_dt.Tables[1].Rows.Count > 0)
                {
                    if (obj_dt.Tables[2].Rows.Count > 0)
                    {
                        Appmailid = obj_dt.Tables[0].Rows[0]["offmailid"].ToString();
                        empid = obj_dt.Tables[2].Rows[0]["offmailid"].ToString();
                        reviewmailid = obj_dt.Tables[1].Rows[0]["offmailid"].ToString();
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear Ms.Suma ,</FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> " + obj_dt.Tables[2].Rows[0]["Employeename"].ToString() + " has reviewed by " + obj_dt.Tables[0].Rows[0]["Appraisalby"].ToString() + " . </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> You can Proceed Further </FONT></td></tr></table><br>";
                        sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> Auto Generated Mail.   </FONT></td></tr></table><br>";
                        Utility.SendMail(reviewmailid, "", "Appraisal - 2017-2018", sendqry, "", Session["usermailpwd"].ToString(), "", "");
                    }
                }
            }
           
        }

        protected void ddlredesig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlredesig.SelectedItem.Value == "2")
            {
                ddldesignation.Enabled = true;
            }
            else
            {
                ddldesignation.Enabled = false;
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
            employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString()) - 1;

            str_RptName = "RptKpiWithRec.rpt";
            str_sf = "{HRKPI.empid}=" + employeeid + " and {HRKPI.KPIYear}= " + year;
            str_sp = "";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Appraisal Details", str_Script, true);
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }

    }
}