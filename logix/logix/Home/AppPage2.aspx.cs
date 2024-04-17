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
    public partial class AppPage2 : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        int year;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnnext);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnprevious);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsavepage2);

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

                dtcompetencies = da_obj_Employee.GetEmpidMasterCompeten(employeeid);
                if (dtcompetencies.Rows.Count > 0)
                {
                    //DataTable dt_temp = new DataTable();
                    //dt_temp.Columns.Add("S.NO");
                    //dt_temp.Columns.Add("Details");
                    //dt_temp.Columns.Add("selfrating");
                    //dt_temp.Columns.Add("selfremarks");
                    //dt_temp.Columns.Add("qid");
                    ////DataRow dr = new DataRow();
                    //for (int i = 0; i < dtcompetencies.Rows.Count; i++)
                    //{
                    //    dt_temp.Rows.Add();
                    //    dt_temp.Rows[i][0] = i+1;
                    //    dt_temp.Rows[i][1] = dtcompetencies.Rows[i]["Details"].ToString();
                    //    dt_temp.Rows[i][2] = "";
                    //    dt_temp.Rows[i][3] = dtcompetencies.Rows[i]["selfremarks"].ToString();
                    //    dt_temp.Rows[i][4] = dtcompetencies.Rows[i]["qid"].ToString();
                    //}
                    gvcomp.DataSource = dtcompetencies;
                    gvcomp.DataBind();
                    for (int i = 0; i < gvcomp.Rows.Count; i++)
                    {
                        DropDownList drop = (DropDownList)gvcomp.Rows[i].FindControl("ddlself");
                        if (dtcompetencies.Rows[i]["selfrating"].ToString() == "Average")
                        {
                            drop.SelectedIndex = 1;
                        }
                        else if (dtcompetencies.Rows[i]["selfrating"].ToString() == "Above Average")
                        {
                            drop.SelectedIndex = 2;
                        }
                        else if (dtcompetencies.Rows[i]["selfrating"].ToString() == "Good")
                        {
                            drop.SelectedIndex = 3;
                        }
                        else if (dtcompetencies.Rows[i]["selfrating"].ToString() == "Very Good")
                        {
                            drop.SelectedIndex = 4;
                        }
                        else if (dtcompetencies.Rows[i]["selfrating"].ToString() == "Excellent")
                        {
                            drop.SelectedIndex = 5;
                        }else
                        {
                            drop.SelectedIndex = 0;
                        }
                    }
                }

                for (int i = 0; i < gvcomp.Rows.Count; i++)
                {
                    
                }
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/AppPage1.aspx");
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            //int selfrating = 0;

            //dtcompetencies = da_obj_Employee.GetEmpidMasterCompeten(employeeid);
            //for (int i = 0; i < dtcompetencies.Rows.Count; i++)
            //{
            //    if (dtcompetencies.Rows[0]["selfrating"].ToString() == "")
            //    {
            //        selfrating = selfrating + 0;
            //    }
            //    else
            //    {
            //        selfrating = selfrating + 1;
            //    }
            //}
            //if (selfrating == 10)
            //{
                for (int i = 0; i < gvcomp.Rows.Count; i++)
                {
                    DropDownList ddlselfrating = (DropDownList)gvcomp.Rows[i].FindControl("ddlself");

                    if (ddlselfrating.SelectedItem.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Select any one in Self Ratings');", true);
                        //gvcomp.Rows[i].Cells[2].Focus();
                        return;
                    }
                }

                for (int i = 0; i < gvcomp.Rows.Count; i++)
                {
                    //TextBox textself = (TextBox)gvcomp.Rows[i].FindControl("txtcompweight");
                    Label lblqid = (Label)gvcomp.Rows[i].FindControl("lbldetails1");
                    TextBox textselfremarks = (TextBox)gvcomp.Rows[i].FindControl("txtcomremarks");
                    DropDownList ddlselfrating = (DropDownList)gvcomp.Rows[i].FindControl("ddlself");

                    da_obj_Employee.InsKpiCompforEmployee(employeeid, year, Convert.ToInt32(ddlselfrating.SelectedItem.Value), Convert.ToInt32(lblqid.Text), textselfremarks.Text);
                }
                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Rating Details Saved');", true);

                Response.Redirect("../Home/AppPage3.aspx");
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Kindly save the ratings in this page');", true);
            //    return;
            //}
        }
        protected void btn_instr_Click(object sender, EventArgs e)
        {
            mpthank.Show();
        }

        protected void btnsavepage2_Click(object sender, EventArgs e)
        {
            //employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            //year = Convert.ToInt32(DateTime.Now.Year.ToString());
            //double inttotal = 0;

            //for (int i = 0; i < gvcomp.Rows.Count; i++)
            //{
            //    TextBox textself = (TextBox)gvcomp.Rows[i].FindControl("txtcompweight");
            //    inttotal = inttotal + Convert.ToDouble(textself.Text);
            //}

            //if (inttotal > 30 )
            //{
            //    ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Total Self ratings are exceed than Total Weightage Point');", true);
            //    return;
            //}


           

        }
    }
}