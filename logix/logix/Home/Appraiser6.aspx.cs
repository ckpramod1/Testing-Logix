using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;

namespace logix.Home
{
    public partial class Appraiser6 : System.Web.UI.Page
    {
        DataAccess.HR.Appraisal obj_apr = new DataAccess.HR.Appraisal();
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        int year = 0;
        Boolean bol;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnnext);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnprevious);

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

                dtcompetencies = da_obj_Employee.GetAppraisarCommentspage(employeeid, year);
                if (dtcompetencies.Rows.Count > 0)
                {
                    txtstrength.Text = dtcompetencies.Rows[0]["Strenghth"].ToString();
                    txtimprovement.Text = dtcompetencies.Rows[0]["Improvement"].ToString();
                    txteffective.Text = dtcompetencies.Rows[0]["Effectiveness"].ToString();
                    txttrainneed.Text = dtcompetencies.Rows[0]["trainneed"].ToString();
                }

                Getdetails();
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            checkdata();
            if (bol == true)
            {
                bol = false;
                return;
            }

            employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            da_obj_Employee.InsAppraiserComments(employeeid, year, txtstrength.Text, txtimprovement.Text, "", txteffective.Text,"", 0, txttrainneed.Text);
            ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Appraiser Comments Saved');", true);
            //Response.Redirect("AppPage4A.aspx");  
            Response.Redirect("AppraNew5.aspx");
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            // Response.Redirect("Appraiser5.aspx");  
            Response.Redirect("AppPage4A.aspx");
        }

        protected void btncancelpage2_Click(object sender, EventArgs e)
        {

        }

        public void checkdata()
        {
            if (txtstrength.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Strength must not be empty');", true);
                txtstrength.Focus();
                bol = true;
                return;
            }

            //if (ddlyesNo.SelectedItem.Value == "1")
            //{
            //    if (txttrainneed.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill Training Need');", true);
            //        txttrainneed.Focus();
            //        bol = true;
            //        return;
            //    }
            //}
            if (txtimprovement.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill the answer in Improvement ');", true);
                txtimprovement.Focus();
                bol = true;
                return;
            }
            //if (txttraining.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill the answer Training ');", true);
            //    txttraining.Focus();
            //    bol = true;
            //    return;
            //}
            if (txteffective.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill the answer in Effectiveness');", true);
                txteffective.Focus();
                bol = true;
                return;
            }

            if (txttrainneed.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill the answer in Training Need');", true);
                txteffective.Focus();
                bol = true;
                return;
            }
            //if (txtgaps.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Kindly Fill the answer in Gaps');", true);
            //    txtgaps.Focus();
            //    bol = true;
            //    return;
            //}

        }

        private void Getdetails()
        {
            DataTable dtsub = new DataTable();
            DataTable dtims = new DataTable();



            //dtsub = obj_apr.getSubOrdinatesQuestions(employeeid, year);
            //dtims = obj_apr.getHRIMSperiorsQuestions(employeeid, year);
            dtsub = obj_apr.GetRatingCompetencies(employeeid, year);


            if (dtsub.Rows.Count > 0)
            {
                grdsub.DataSource = dtsub;
                grdsub.DataBind();

                for (int i = 0; i < grdsub.Rows.Count; i++)
                {
                    DropDownList drop = (DropDownList)grdsub.Rows[i].FindControl("ddlrating");
                    if (dtsub.Rows[i]["subrating"].ToString() == "1")
                    {
                        drop.SelectedIndex = 1;
                    }
                    else if (dtsub.Rows[i]["subrating"].ToString() == "2")
                    {
                        drop.SelectedIndex = 2;
                    }
                    else if (dtsub.Rows[i]["subrating"].ToString() == "3")
                    {
                        drop.SelectedIndex = 3;
                    }
                    else
                    {
                        drop.SelectedIndex = 0;
                    }
                }

                for (int i = 0; i < grdsub.Rows.Count; i++)
                {
                    DropDownList drop1 = (DropDownList)grdsub.Rows[i].FindControl("ddlIMPrating");
                    if (dtsub.Rows[i]["ImSuprating"].ToString() == "1")
                    {
                        drop1.SelectedIndex = 1;
                    }
                    else if (dtsub.Rows[i]["ImSuprating"].ToString() == "2")
                    {
                        drop1.SelectedIndex = 2;
                    }
                    else if (dtsub.Rows[i]["ImSuprating"].ToString() == "3")
                    {
                        drop1.SelectedIndex = 3;
                    }
                    else
                    {
                        drop1.SelectedIndex = 0;
                    }
                }

            }
            //if (dtims.Rows.Count > 0)
            //{
            //    grdims.DataSource = dtims;
            //    grdims.DataBind();
            //    for (int i = 0; i < grdims.Rows.Count; i++)
            //    {
            //        DropDownList drop = (DropDownList)grdims.Rows[i].FindControl("ddlrating1");
            //        if (dtims.Rows[i]["selfrating"].ToString() == "1")
            //        {
            //            drop.SelectedIndex = 1;
            //        }
            //        else if (dtims.Rows[i]["selfrating"].ToString() == "2")
            //        {
            //            drop.SelectedIndex = 2;
            //        }
            //        else if (dtims.Rows[i]["selfrating"].ToString() == "3")
            //        {
            //            drop.SelectedIndex = 3;
            //        }
            //        else
            //        {
            //            drop.SelectedIndex = 0;
            //        }
            //    }
            //}
        }

        protected void btncompare_Click(object sender, EventArgs e)
        {
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            DataTable dtcompare = new DataTable();
            dtcompare = da_obj_Employee.GetKPIComparision(employeeid);
            if (dtcompare.Rows.Count > 0)
            {
                grd_user.DataSource = dtcompare;
                grd_user.DataBind();
                mpthank.Show();
            }

        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            mpthank.Hide();
        }
    }
}