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

namespace logix.HRM
{
    public partial class Apppage4 : System.Web.UI.Page
    {
        DataAccess.HR.Appraisal obj_apr = new DataAccess.HR.Appraisal();
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        int year = 0;

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

                Getdetails();
            }
        }

        private void Getdetails()
        {
            DataTable dtsub = new DataTable();
            DataTable dtims = new DataTable();



            dtsub = obj_apr.getSubOrdinatesQuestions(employeeid,year);
            dtims = obj_apr.getHRIMSperiorsQuestions(employeeid,year);

            if (dtsub.Rows.Count>0)
            {
                grdsub.DataSource = dtsub;
                grdsub.DataBind();

                for (int i = 0; i < grdsub.Rows.Count; i++)
                {
                    DropDownList drop = (DropDownList)grdsub.Rows[i].FindControl("ddlrating");
                    if (dtsub.Rows[i]["selfrating"].ToString() == "1")
                    {
                        drop.SelectedIndex = 1;
                    }
                    else if (dtsub.Rows[i]["selfrating"].ToString() == "2")
                    {
                        drop.SelectedIndex = 2;
                    }
                    else if (dtsub.Rows[i]["selfrating"].ToString() == "3")
                    {
                        drop.SelectedIndex = 3;
                    }
                    else
                    {
                        drop.SelectedIndex = 0;
                    }
                }
            }
            if (dtims.Rows.Count > 0)
            {
                grdims.DataSource = dtims;
                grdims.DataBind();
                for (int i = 0; i < grdims.Rows.Count; i++)
                {
                    DropDownList drop = (DropDownList)grdims.Rows[i].FindControl("ddlrating1");
                    if (dtims.Rows[i]["selfrating"].ToString() == "1")
                    {
                        drop.SelectedIndex = 1;
                    }
                    else if (dtims.Rows[i]["selfrating"].ToString() == "2")
                    {
                        drop.SelectedIndex = 2;
                    }
                    else if (dtims.Rows[i]["selfrating"].ToString() == "3")
                    {
                        drop.SelectedIndex = 3;
                    }
                    else
                    {
                        drop.SelectedIndex = 0;
                    }
                }
            }
        }

        protected void btn_instr_Click(object sender, EventArgs e)
        {
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppPage3.aspx");
        }

        protected void btnsavepage2_Click(object sender, EventArgs e)
        {
            int subrat = 0;
            int subims = 0;
            DataTable dtsub = new DataTable();
            DataTable dtims = new DataTable();
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());



            int selfrating = 0;
            int selfratrow = 0;
            int selfimrow = 0;
            int selfim = 0;
            if (grdsub.Rows.Count > 0)
            {
                selfratrow = grdsub.Rows.Count;
                for (int i = 0; i < grdsub.Rows.Count; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdsub.Rows[i].Cells[2].FindControl("ddlrating");
                    subrat = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());

                    if (subrat.ToString() == "0")
                    {
                        selfrating = selfrating + 0;
                    }
                    else
                    {
                        selfrating = selfrating + 1;
                    }
                }
            }
            if (grdims.Rows.Count > 0)
            {
                selfimrow = grdims.Rows.Count;
                for (int i = 0; i < grdims.Rows.Count; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdims.Rows[i].Cells[2].FindControl("ddlrating1");
                    subims = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());

                    if (subims.ToString() == "0")
                    {
                        selfim = selfim + 0;
                    }
                    else
                    {
                        selfim = selfim + 1;
                    }
                }
            }

            if (selfratrow == selfrating && selfim == selfimrow)
            {
                for (int i = 0; i <= grdsub.Rows.Count - 1; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdsub.Rows[i].Cells[2].FindControl("ddlrating");
                    Label lblqidsub = (Label)grdsub.Rows[i].Cells[3].FindControl("lblqid1");
                    subrat = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());
                    obj_apr.UpdSubOrdinatesQuestions(Convert.ToInt32(lblqidsub.Text.ToString()), subrat, employeeid, year);
                }

                for (int i = 0; i <= grdims.Rows.Count - 1; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdims.Rows[i].Cells[2].FindControl("ddlrating1");
                    Label lblqidIM = (Label)grdims.Rows[i].Cells[3].FindControl("lblqid");
                    subims = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());
                    obj_apr.UpdHRIMSperiorsQuestions(employeeid, year, Convert.ToInt32(lblqidIM.Text.ToString()), subims);
                }

                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Ratings have been Saved , Go to Next Tab');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Kindly save the ratings in this page');", true);
                return;
            }
        }

        protected void btncancelpage2_Click(object sender, EventArgs e)
        {

        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            int subrat = 0;
            int subims = 0;
            DataTable dtsub = new DataTable();
            DataTable dtims = new DataTable();
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());



            int selfrating = 0;
            int selfratrow = 0;
            int selfimrow = 0;
            int selfim = 0;
            if (grdsub.Rows.Count > 0)
            {
                selfratrow = grdsub.Rows.Count;
                for (int i = 0; i < grdsub.Rows.Count; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdsub.Rows[i].Cells[2].FindControl("ddlrating");
                    subrat = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());

                    if (subrat.ToString() == "0")
                    {
                        selfrating = selfrating + 0;
                    }
                    else
                    {
                        selfrating = selfrating + 1;
                    }
                }
            }
            if (grdims.Rows.Count > 0)
            {
                selfimrow = grdims.Rows.Count;
                for (int i = 0; i < grdims.Rows.Count; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdims.Rows[i].Cells[2].FindControl("ddlrating1");
                    subims = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());

                    if (subims.ToString() == "0")
                    {
                        selfim = selfim + 0;
                    }
                    else
                    {
                        selfim = selfim + 1;
                    }
                }
            }

            if (selfratrow == selfrating && selfim == selfimrow)
            {
                for (int i = 0; i <= grdsub.Rows.Count - 1; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdsub.Rows[i].Cells[2].FindControl("ddlrating");
                    Label lblqidsub = (Label)grdsub.Rows[i].Cells[3].FindControl("lblqid1");
                    subrat = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());
                    obj_apr.UpdSubOrdinatesQuestions(Convert.ToInt32(lblqidsub.Text.ToString()), subrat, employeeid, year);
                }

                for (int i = 0; i <= grdims.Rows.Count - 1; i++)
                {
                    DropDownList ddlsubrating = (DropDownList)grdims.Rows[i].Cells[2].FindControl("ddlrating1");
                    Label lblqidIM = (Label)grdims.Rows[i].Cells[3].FindControl("lblqid");
                    subims = Convert.ToInt32(ddlsubrating.SelectedItem.Value.ToString());
                    obj_apr.UpdHRIMSperiorsQuestions(employeeid, year, Convert.ToInt32(lblqidIM.Text.ToString()), subims);
                }

                ScriptManager.RegisterStartupScript(btnsavepage2, typeof(Button), "HRM", "alertify.alert('Rating Details Saved');", true);
                Response.Redirect("AppPage5.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Kindly save the ratings in this page');", true);
                return;
            }
            
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            mpthank.Hide();
        }

        protected void btncompare_Click(object sender, EventArgs e)
        {
            employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            DataTable dtcompare = new DataTable();
            dtcompare = da_obj_Employee.GetKPIComparision(employeeid);
            if(dtcompare.Rows.Count > 0 )
            {
                grd_user.DataSource = dtcompare;
                grd_user.DataBind();
                mpthank.Show();
            }
        }
    }
}