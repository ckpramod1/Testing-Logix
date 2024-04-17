using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logix;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Text;

namespace logix.Home
{
    public partial class CooEmpList : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        public int year;
        public int branchid;
        public int divisionid;
        public int deptid;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_view);
            if(!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                year = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
                dtcom = da_obj_Employee.GetDivisionForCOO(year);
                if (dtcom.Rows.Count > 0)
                {
                    gvdivision.DataSource = dtcom;
                    gvdivision.DataBind();
                    
                }
                Session["COOPAGE"] = "YES";
            }
        }

        protected void gvdivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (gvdivision.Rows.Count > 0)
                {
                    Panel3.Visible = true;
                    divisionid = Convert.ToInt32(gvdivision.SelectedDataKey.Values[0].ToString());
                    Session["CODIVISIONID"] = divisionid;
                    year = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
                    dtcompetencies = da_obj_Employee.GetBranchForCOO(divisionid,year);
                    if (dtcompetencies.Rows.Count > 0)
                    {
                        gvbranch.DataSource = dtcompetencies;
                        gvbranch.DataBind();
                    }
                    //Session["APPEmpid"] = divisionid;
                    //Response.Redirect("Appraiser1.aspx");
                }
            }
            catch
            {

            }
        }

        protected void gvdivision_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvdivision, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
                if (gvbranch.Rows.Count > 0)
                {
                    Panel4.Visible = true;
                    branchid = Convert.ToInt32(gvbranch.SelectedDataKey.Values[0].ToString());
                    Session["COBRANCHID"] = branchid;
                    year = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
                    dtcompetencies = da_obj_Employee.GetDeptForCOO(branchid,year);
                    if (dtcompetencies.Rows.Count > 0)
                    {
                        gvdept.DataSource = dtcompetencies;
                        gvdept.DataBind();
                    }
                    //Session["APPEmpid"] = divisionid;
                    //Response.Redirect("Appraiser1.aspx");
                }
            }
            catch
            {

            }
        }

        protected void gvbranch_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvbranch, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (gvbranch.Rows.Count > 0)
                {
                    Panel1.Visible = true;
                    deptid = Convert.ToInt32(gvdept.SelectedDataKey.Values[0].ToString());
                    Session["CODEPTID"] = deptid;
                    year = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
                    dtkpi = da_obj_Employee.GetEmplistForCOOFromDeptbranch(deptid,Convert.ToInt32(Session["COBRANCHID"].ToString()),year);
                    if (dtkpi.Rows.Count > 0)
                    {
                        gvcomp.DataSource = dtkpi;
                        gvcomp.DataBind();
                    }
                    //Session["APPEmpid"] = divisionid;
                    //Response.Redirect("Appraiser1.aspx");
                }
            }
            catch
            {

            }
        }

        protected void gvdept_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvdept, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
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
                    Session["Ayear"] = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
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

        protected void btn_view_Click(object sender, EventArgs e)
        {
            ExportToExcelNew();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        private void ExportToExcelNew()
        {
            DataTable dt_check = ViewState["grdsalexp2exc"] as DataTable;
            if (grdsal.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=AppraisedReport.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Panel5.Visible = false;
            Panel2.Visible = true;
            btn_view.Visible = false;
            btnCancel.Visible = false;
            year = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
            dtcom = da_obj_Employee.GetDivisionForCOO(year);
            if (dtcom.Rows.Count > 0)
            {
                gvdivision.DataSource = dtcom;
                gvdivision.DataBind();
            }
        }

        protected void lnkempapplist_Click(object sender, EventArgs e)
        {
            year = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
            DataTable dtsal = new DataTable("Employee details");
            dtsal = da_obj_Employee.GetSalaryQryforCoo("M", year);
            if (dtsal.Rows.Count > 0)
            {
                grdsal.Visible = true;
                Panel5.Visible = true;
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                btn_view.Visible = true;
                btnCancel.Visible = true;
                grdsal.DataSource = dtsal;
                grdsal.DataBind();
            }

            ViewState["grdsalexp2exc"] = dtsal;
        }

        protected void ddl_AYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = Convert.ToInt32(ddl_AYear.SelectedItem.Text.Substring(0, 4).ToString());
            dtcom = da_obj_Employee.GetDivisionForCOO(year);
            if (dtcom.Rows.Count > 0)
            {
                gvdivision.DataSource = dtcom;
                gvdivision.DataBind();
                //gvbranch.Visible = false;
                //gvdept.Visible = false;
                //gvcomp.Visible = false;
            }
            


        }
    }
}