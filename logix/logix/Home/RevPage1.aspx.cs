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
    public partial class RevPage1 : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataSet dscomp = new DataSet();
        DataTable dtkpi = new DataTable();
        int year;
        int agree;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnnext);
            if (!IsPostBack)
            {
                if (Session["RevEmpid"] != null)
                {
                    employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
                    if (Request.QueryString.ToString().Contains("year"))
                    {
                    year = Convert.ToInt32(Request.QueryString["year"].ToString());
                    }
                    else

                    {
                        if (Session["Ayear"] != null)
                        {
                            year = Convert.ToInt32(Session["Ayear"].ToString());
                        }
                        else
                        {
                            year = 0;
                        }
                    }
                }
                   
                else
                {
                    if (Request.QueryString.ToString().Contains("typeempid"))
                   {
                       employeeid = Convert.ToInt32(Request.QueryString["typeempid"].ToString());
                       year = Convert.ToInt32(Request.QueryString["year"].ToString());
                       Session["RevEmpid"] = employeeid;
                   }
                   
                }
                dtcom = da_obj_Employee.GetEmpidAppraisalCom(employeeid);
               // year = Convert.ToInt32(DateTime.Now.Year.ToString());
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


                dscomp = da_obj_Employee.GetEmpidKPIForAppraise(employeeid,year);
                if (dscomp.Tables[0].Rows.Count > 0)
                {
                    grd_user.DataSource = dscomp.Tables[0];
                    grd_user.DataBind();
                }
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            Response.Redirect("RevPage2.aspx");
        }
    }
}