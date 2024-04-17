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
    public partial class Appraiser1 : System.Web.UI.Page
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
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsave);
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
            for (int i = 0; i < grd_user.Rows.Count; i++)
            {
                TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtapprating");
                //string selfrating = grd_user.Rows[i].Cells[3].Text.ToString();
                if (textself.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Appraiser Ratings could not be empty');", true);
                    grd_user.Rows[i].Cells[3].Focus();
                    return;
                }
            }

            for (int i = 0; i < grd_user.Rows.Count; i++)
            {
                Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
                TextBox textapp = (TextBox)grd_user.Rows[i].FindControl("txtapprating");
                int weigtage = Convert.ToInt32(lblweightage.Text);
                int intselfrating = Convert.ToInt32(textapp.Text);

                if (weigtage < intselfrating)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Appraiser Ratings must be Less than Weightage Points');", true);
                    //grd_user.Rows[i].Cells[3].Focus();
                    return;
                }
            }

            for (int i = 0; i < grd_user.Rows.Count; i++)
            {
                Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
                Label lblkpiid = (Label)grd_user.Rows[i].FindControl("lblkpiid");
                TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtapprating");
                employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
                year = Convert.ToInt32(DateTime.Now.Year.ToString());

                da_obj_Employee.UPDKpiforAppraiser(employeeid, year, Convert.ToInt32(textself.Text), Convert.ToInt32(lblkpiid.Text));
            }
            ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Rating Details Saved');", true);

            Response.Redirect("Appraiser2.aspx");
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppraiserPage.aspx");
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_user.Rows.Count; i++)
            {
                TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtapprating");
                //string selfrating = grd_user.Rows[i].Cells[3].Text.ToString();
                if (textself.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Appraiser Ratings could not be empty');", true);
                    grd_user.Rows[i].Cells[3].Focus();
                    return;
                }
            }

            for (int i = 0; i < grd_user.Rows.Count; i++)
            {
                Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
                TextBox textapp = (TextBox)grd_user.Rows[i].FindControl("txtapprating");
                int weigtage = Convert.ToInt32(lblweightage.Text);
                int intselfrating = Convert.ToInt32(textapp.Text);

                if (weigtage < intselfrating)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Appraiser Ratings must be Less than Weightage Points');", true);
                    //grd_user.Rows[i].Cells[3].Focus();
                    return;
                }
            }

            for (int i = 0; i < grd_user.Rows.Count; i++)
            {
                Label lblweightage = (Label)grd_user.Rows[i].FindControl("lblweightage");
                Label lblkpiid = (Label)grd_user.Rows[i].FindControl("lblkpiid");
                TextBox textself = (TextBox)grd_user.Rows[i].FindControl("txtapprating");
                employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
                year = Convert.ToInt32(DateTime.Now.Year.ToString());

                da_obj_Employee.UPDKpiforAppraiser(employeeid, year, Convert.ToInt32(textself.Text), Convert.ToInt32(lblkpiid.Text));
            }
            ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "HRM", "alertify.alert('Ratings have been Saved , Go to Next Tab');", true);
        }
    }
}