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
    public partial class AppPage1 : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        DataAccess.HR.Appraisal da_obj_app = new DataAccess.HR.Appraisal();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataSet dscomp = new DataSet();
        DataTable dtkpi = new DataTable();
        DataTable dtsub = new DataTable();
        int year;
        int agree;
        string sendqry;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnnext);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsave);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(Button2);
            if (!IsPostBack)
            {                
                //txtselfrating.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                dtcom = da_obj_Employee.GetEmpidAppraisalCom(employeeid);
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                if (dtcom.Rows.Count > 0)
                {
                    //Session["EMPCONFIRM"] = null;
                    
                    txtempcode.Text = dtcom.Rows[0]["UserName"].ToString();
                    txtempname.Text = dtcom.Rows[0]["empname"].ToString();
                    txtdept.Text = dtcom.Rows[0]["deptname"].ToString();
                    txtdesig.Text = dtcom.Rows[0]["designame"].ToString();
                    txtlocation.Text = dtcom.Rows[0]["shortname"].ToString();
                    txtgrossmon.Text = string.Format("{0:#,##0.00}", dtcom.Rows[0]["MonthlyGross"]); 
                    txtgrade.Text = dtcom.Rows[0]["grade"].ToString();
                    txtdoj.Text = dtcom.Rows[0]["doj"].ToString();
                    txtdoc.Text = dtcom.Rows[0]["doc"].ToString();
                    txtctcann.Text = string.Format("{0:#,##0.00}",dtcom.Rows[0]["AnnualCTC"]);
                    txtctcmon.Text = string.Format("{0:#,##0.00}",dtcom.Rows[0]["MonthlyCTC"]);
                }


                dscomp = da_obj_Employee.GetEmpidKPI(employeeid);
                if (dscomp.Tables[0].Rows.Count > 0)
                {
                    grd_user.DataSource = dscomp.Tables[0];
                    grd_user.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Insert KPI in the Profile Page');", true);
                    Response.Redirect("Profile.aspx");
                }

                if (dscomp.Tables[1].Rows.Count > 0)
                {
                    if (Convert.ToInt32(dscomp.Tables[1].Rows[0]["agree"].ToString()) == 1)
                    {
                        chkagree.Checked = true;
                    }
                    else
                    {
                        chkagree.Checked = false;
                    }
                }

                //dtsub = da_obj_Employee.GetKpiSubmittedDateDetails(employeeid);
                //if (Session["EMPCONFIRM"].ToString() == "1")
                //{
                    //if ((dtsub.Rows[0]["empconfirmedon"].ToString()))
                    if (Session["EMPCONFIRM"] != null)
                    {
                        btnconfirmedon.Enabled = true;
                        btnprint.Visible = true;
                        btnsave.Enabled = false;
                        btnnext.Enabled = false;
                        btncancel.Enabled = false;
                        //btnback.Enabled = false;
                    }
                    else
                    {
                        btnconfirmedon.Enabled = false;
                        btnprint.Visible = false;
                        btnsave.Enabled = true;
                        btnnext.Enabled = true;
                        btncancel.Enabled = true;
                    }
               //}
                
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //if (chkagree.Checked == true)
            //{
            //    agree = 1;
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Kindly Agree Terms and Conditions');", true);
            //    return;
            //}
          
            //for (int i = 0; i < grd_user.Rows.Count; i++)
            //{
            //    TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtselfrating");
            //    //string selfrating = grd_user.Rows[i].Cells[3].Text.ToString();
            //    if (textself.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Self Ratings could not be empty');", true);
            //        grd_user.Rows[i].Cells[3].Focus();
            //        return;
            //    }
            //}

            //for (int i = 0; i < grd_user.Rows.Count; i++)
            //{
            //    Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
            //    TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtselfrating");
            //    int weigtage = Convert.ToInt32(lblweightage.Text);
            //    int intselfrating = Convert.ToInt32(textself.Text);

            //    if ( weigtage < intselfrating )
            //    {
            //        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Self Ratings must be Less than Weightage Points');", true);
            //        grd_user.Rows[i].Cells[3].Focus();
            //        return;
            //    }
            //}

            //for (int i = 0; i < grd_user.Rows.Count; i++)
            //{
            //    Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
            //    Label lblkpiid = (Label)grd_user.Rows[i].FindControl("lblkpiid");
            //    TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtselfrating");
            //    employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            //    year = Convert.ToInt32(DateTime.Now.Year.ToString());

            //    da_obj_Employee.UPDKpiforEmployee(employeeid, year, Convert.ToInt32(textself.Text), Convert.ToInt32(lblkpiid.Text),agree);
            //}
            //ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Ratings have been Saved , Go to Next Tab');", true);
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (chkagree.Checked == true)
            {
                agree = 1;
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Kindly Agree that you have read the instructions');", true);
                return;

            }
            for (int i = 0; i < grd_user.Rows.Count; i++)
            {
                TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtselfrating");
                //string selfrating = grd_user.Rows[i].Cells[3].Text.ToString();
                if (textself.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Self Ratings could not be empty');", true);
                    grd_user.Rows[i].Cells[3].Focus();
                    return;
                }
            }

             //employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
             //dscomp = da_obj_Employee.GetEmpidKPI(employeeid);
             //if (dscomp.Tables[0].Rows.Count > 0)
             //{
                 
             //}
             //else
             //{
             //    ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Kindly save the ratings in this page');", true);
             //    return;
             //}

             for (int i = 0; i < grd_user.Rows.Count; i++)
             {
                 Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
                 TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtselfrating");
                 int weigtage = Convert.ToInt32(lblweightage.Text);
                 int intselfrating = Convert.ToInt32(textself.Text);

                 if (weigtage < intselfrating)
                 {
                     ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Self Ratings must be Less than Weightage Points');", true);
                     grd_user.Rows[i].Cells[3].Focus();
                     return;
                 }
             }

             for (int i = 0; i < grd_user.Rows.Count; i++)
             {
                 Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
                 Label lblkpiid = (Label)grd_user.Rows[i].FindControl("lblkpiid");
                 TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtselfrating");
                 employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                 year = Convert.ToInt32(DateTime.Now.Year.ToString());

                 da_obj_Employee.UPDKpiforEmployee(employeeid, year, Convert.ToInt32(textself.Text), Convert.ToInt32(lblkpiid.Text), agree);
             }
             ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Rating Details Saved');", true);
             Response.Redirect("../Home/AppPage2.aspx");

        }
        protected void btn_instr_Click(object sender, EventArgs e)
        {
            mpthank.Show();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/Profile.aspx");
        }

        protected void btnconfirmedon_Click(object sender, EventArgs e)
        {

            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            da_obj_Employee.InsEmpConfirm(employeeid);
            ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Appraisal Confirmed');", true);
            btnconfirmedon.Text = "Confirmed";
            btnconfirmedon.Enabled = false;
            sendConfirmMail();

        }

        public void sendConfirmMail()
        {
            DataSet obj_dt = new DataSet();
            string Appmailid = "";
            string empid = "";
            string reviewbymail = "";
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            obj_dt = da_obj_Employee.GetEmpAppraiserDtlsforMail(employeeid);
            if (obj_dt.Tables[0].Rows.Count > 0)
            {
                Appmailid = obj_dt.Tables[0].Rows[0]["offmailid"].ToString();
                empid = obj_dt.Tables[2].Rows[0]["offmailid"].ToString();
                reviewbymail = obj_dt.Tables[1].Rows[0]["offmailid"].ToString();
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2>Dear " + obj_dt.Tables[1].Rows[0]["Reviewedby"].ToString() + ",</FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> " + obj_dt.Tables[2].Rows[0]["Employeename"].ToString() + " has confirmed that the appraisal has completed. You can review the same through Software  </FONT></td></tr></table><br>";
                sendqry = sendqry + "<table width=100%><tr><td align=left><FONT FACE=sans-serif SIZE=2> Auto Generated Mail   </FONT></td></tr></table><br>";
            }
            Utility.SendMail(empid, reviewbymail, "Appraisal - 2017-2018", sendqry, "", Session["usermailpwd"].ToString(), "", "");
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            DataSet ds = new DataSet();
            int salaryday;
            int salarymonth;
            int salaryyear;
            int kpiyear;

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString()) - 1;
            ds = da_obj_app.GetEmpsalarydetails(employeeid);

            salaryday = Convert.ToInt32(ds.Tables[0].Rows[0]["Day"].ToString());
            salarymonth = Convert.ToInt32(ds.Tables[0].Rows[0]["month"].ToString());
            salaryyear = Convert.ToInt32(ds.Tables[0].Rows[0]["Year"].ToString());
            kpiyear = Convert.ToInt32(ds.Tables[1].Rows[0]["kpiyear"].ToString());

            str_RptName = "RptKpiWoRec.rpt";
            str_sf = "{HRKPI.empid}=" + employeeid + " and {HRKPI.KPIYear}= " + kpiyear + " and Day({HRSalaryDetails.sfrom})= " + salaryday + " and Month({HRSalaryDetails.sfrom})= " + salarymonth + " and Year({HRSalaryDetails.sfrom})= " + salaryyear;
            str_sp = "";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Appraisal Details", str_Script, true);
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }

       
    }
}