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
    public partial class RevCompleteList : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                dscomp = da_obj_Employee.GetEmplistforCompleteReviewer(employeeid);
                if (dscomp.Tables[0].Rows.Count > 0)
                {
                    gvcomp.DataSource = dscomp.Tables[0];
                    gvcomp.DataBind();
                }
            }
        }

        protected void gvcomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int emplid;
                if (gvcomp.Rows.Count > 0)
                {
                    emplid = Convert.ToInt32(gvcomp.SelectedDataKey.Values[0].ToString());
                    Session["RevEmpid"] = emplid;
                    Session["COOPAGE"] = "NO";
                    Response.Redirect("RevPage1.aspx");
                }
            }
            catch
            {

            }
        }

        protected void gvcomp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvcomp, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
    }
}