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
    public partial class RevPage2 : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
                dtcom = da_obj_Employee.GetEmpidAppraisalCom(employeeid);
               // year = Convert.ToInt32(DateTime.Now.Year.ToString());
                if (Session["Ayear"] != null)
                {
                    year = Convert.ToInt32(Session["Ayear"].ToString());
                }
                else
                {
                    year = 0;
                }
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

                dtcompetencies = da_obj_Employee.GetAppraiseridMasterCompeten(employeeid, year);
                if (dtcompetencies.Rows.Count > 0)
                {
                    gvcomp.DataSource = dtcompetencies;
                    gvcomp.DataBind();
                    //for (int i = 0; i < gvcomp.Rows.Count; i++)
                    //{
                    //    DropDownList drop = (DropDownList)gvcomp.Rows[i].FindControl("ddlself");
                    //    if (dtcompetencies.Rows[i]["appraiser1"].ToString() == "Average")
                    //    {
                    //        drop.SelectedIndex = 1;
                    //    }
                    //    else if (dtcompetencies.Rows[i]["appraiser1"].ToString() == "Above Average")
                    //    {
                    //        drop.SelectedIndex = 2;
                    //    }
                    //    else if (dtcompetencies.Rows[i]["appraiser1"].ToString() == "Good")
                    //    {
                    //        drop.SelectedIndex = 3;
                    //    }
                    //    else if (dtcompetencies.Rows[i]["appraiser1"].ToString() == "Very Good")
                    //    {
                    //        drop.SelectedIndex = 4;
                    //    }
                    //    else if (dtcompetencies.Rows[i]["appraiser1"].ToString() == "Excellent")
                    //    {
                    //        drop.SelectedIndex = 5;
                    //    }
                    //    else
                    //    {
                    //        drop.SelectedIndex = 0;
                    //    }
                    //}
                }

                for (int i = 0; i < gvcomp.Rows.Count; i++)
                {

                }
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            Response.Redirect("RevPage3.aspx");
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("RevPage1.aspx");
        }
    }
}