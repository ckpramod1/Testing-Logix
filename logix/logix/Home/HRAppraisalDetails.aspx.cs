using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logix.Home
{
    public partial class HRAppraisalDetails : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        int dib, year;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            if (!IsPostBack)
            {

                if (Request.QueryString.ToString().Contains("HRMAppraisal"))
                {

                    dib = Convert.ToInt32(Request.QueryString["HRMAppraisal"].ToString());
                    year = Convert.ToInt32(Request.QueryString["Year"].ToString());
                }

                PanelBranchWise.Visible = true;
                GridBranchWise.Visible = true;
                loadGetbranchwiseapprisal(dib, year);
            }
           // loadGetbranchwiseapprisal();
          
        }


        public void loadGetbranchwiseapprisal(int did, int year)
        {

            DataTable dt = new DataTable();
            dt = hrempobj.Getbranchwiseapprisal(did, year);
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "Total";
            dt.Rows[dt.Rows.Count - 1][1] = dt.Compute("sum(totemployee)", "");
            dt.Rows[dt.Rows.Count - 1][2] = dt.Compute("sum(self)", "");
            dt.Rows[dt.Rows.Count - 1][3] = dt.Compute("sum(Appraiser)", "");
            dt.Rows[dt.Rows.Count - 1][4] = dt.Compute("sum(Reviewer)", "");
            dt.Rows[dt.Rows.Count - 1][5] = dt.Compute("sum(COO)", "");

            PanelBranchWise.Visible = true;
            GridBranchWise.Visible = true;
            GridBranchWise.DataSource = dt;
            GridBranchWise.DataBind();


            if (GridBranchWise.Rows.Count > 0)
            {

                GridBranchWise.Rows[GridBranchWise.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.Blue;
                GridBranchWise.Rows[GridBranchWise.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Crimson;
                GridBranchWise.Rows[GridBranchWise.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Crimson;
                GridBranchWise.Rows[GridBranchWise.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Crimson;
                GridBranchWise.Rows[GridBranchWise.Rows.Count - 1].Cells[4].ForeColor = System.Drawing.Color.Crimson;
                GridBranchWise.Rows[GridBranchWise.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Crimson;
            }

            else
            {
                GridBranchWise.DataSource = new DataTable();
                GridBranchWise.DataBind();
            }
        }

        protected void GridBranchWise_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                } 
                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridBranchWise, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }

        protected void GridBranchWise_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtdpet = new DataTable();
          
            int bid = Convert.ToInt32(GridBranchWise.SelectedRow.Cells[6].Text.ToString());
            int year = Convert.ToInt32(GridBranchWise.SelectedRow.Cells[7].Text.ToString());
            dtdpet = hrempobj.Getdepartmentwiseapprisal(bid, year);
            dtdpet.Rows.Add();
            dtdpet.Rows[dtdpet.Rows.Count - 1][0] = "Total";
            dtdpet.Rows[dtdpet.Rows.Count - 1][1] = dtdpet.Compute("sum(totemployee)", "");
            dtdpet.Rows[dtdpet.Rows.Count - 1][2] = dtdpet.Compute("sum(self)", "");
            dtdpet.Rows[dtdpet.Rows.Count - 1][3] = dtdpet.Compute("sum(Appraiser)", "");
            dtdpet.Rows[dtdpet.Rows.Count - 1][4] = dtdpet.Compute("sum(Reviewer)", "");
            dtdpet.Rows[dtdpet.Rows.Count - 1][5] = dtdpet.Compute("sum(COO)", "");

            PanelBranchWise.Visible = false;
            GridBranchWise.Visible = false;
            PaneldepartWise.Visible = true;
            GrddepartWise.DataSource = dtdpet;
            GrddepartWise.DataBind();
            ViewState["dtdpet"] = dtdpet;

            if (GrddepartWise.Rows.Count > 0)
            {

                GrddepartWise.Rows[GrddepartWise.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.Blue;
                GrddepartWise.Rows[GrddepartWise.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Crimson;
                GrddepartWise.Rows[GrddepartWise.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Crimson;
                GrddepartWise.Rows[GrddepartWise.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Crimson;
                GrddepartWise.Rows[GrddepartWise.Rows.Count - 1].Cells[4].ForeColor = System.Drawing.Color.Crimson;
                GrddepartWise.Rows[GrddepartWise.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Crimson;
            }

            else
            {
                GrddepartWise.DataSource = new DataTable();
                GrddepartWise.DataBind();
            }
            ViewState["dtdpet"] = dtdpet;
        }

        protected void GrddepartWise_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrddepartWise, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void GrddepartWise_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtemp = new DataTable();
         //   int index = Convert.ToInt32(GrddepartWise.SelectedRow.RowIndex);
            int bid = Convert.ToInt32(GrddepartWise.SelectedRow.Cells[6].Text.ToString());//GrddepartWise.Rows[index].Cells[6].ToString());
            int did = Convert.ToInt32(GrddepartWise.SelectedRow.Cells[7].Text.ToString());
            int year = Convert.ToInt32(GrddepartWise.SelectedRow.Cells[8].Text.ToString());
            dtemp = hrempobj.Getemployeewiseapprisal(bid, did, year);
            PaneldepartWise.Visible = false;
            panelemployeewise.Visible = true;
            Grdemployeewise.DataSource = dtemp;
            Grdemployeewise.DataBind();
        }

        //protected void lnkbtn_Click(object sender, EventArgs e)
        //{
        //    //if (Request.QueryString.ToString().Contains("HRMAppraisal"))
        //    //{

        //    //    dib = Convert.ToInt32(Request.QueryString["HRMAppraisal"].ToString());
        //    //}

        //    loadGetbranchwiseapprisal(dib);
        //    PaneldepartWise.Visible = false;
        //    panelemployeewise.Visible = false;

        //}

        protected void lnk_back_Click(object sender, EventArgs e)
        {
            if (PanelBranchWise.Visible == true)
            {
                Response.Redirect("../Home/NewHroHome.aspx");

            }
            else if (PaneldepartWise.Visible == true)
            {
                PaneldepartWise.Visible = false;
                PanelBranchWise.Visible = true;
                if (Request.QueryString.ToString().Contains("HRMAppraisal"))
                {

                    dib = Convert.ToInt32(Request.QueryString["HRMAppraisal"].ToString());
                    year = Convert.ToInt32(Request.QueryString["Year"].ToString());
                }

               // PanelBranchWise.Visible = true;
                GridBranchWise.Visible = true;
                loadGetbranchwiseapprisal(dib,year);
            }
            else if (panelemployeewise.Visible == true)
            {
                PaneldepartWise.Visible = true;
                panelemployeewise.Visible = false;
                GrddepartWise.Visible = true;
                GrddepartWise.DataSource = (DataTable)ViewState["dtdpet"];
                GrddepartWise.DataBind();
               
            }

        }

        protected void Grdemployeewise_SelectedIndexChanged(object sender, EventArgs e)
        {
            int empid = Convert.ToInt32(Grdemployeewise.SelectedRow.Cells[7].Text.ToString());
            int year = Convert.ToInt32(Grdemployeewise.SelectedRow.Cells[8].Text.ToString());
            Session["RevEmpid"] = null;
            Session["HRAPPRA"] = "HRHOME";
            Response.Redirect("../Home/RevPage1.aspx?typeempid=" + empid + "&year=" + year);
        }

        protected void Grdemployeewise_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.Cells[0].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                }
                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grdemployeewise, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }
    }
}