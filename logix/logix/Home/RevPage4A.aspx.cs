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
    public partial class RevPage4A : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        int year = 0;
        Boolean bol;
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                //dtcompetencies = da_obj_Employee.GetAppraisarCommentspage(employeeid, year);
                //if (dtcompetencies.Rows.Count > 0)
                //{
                //    txtstrength.Text = dtcompetencies.Rows[0]["Strenghth"].ToString();
                //    txtimprovement.Text = dtcompetencies.Rows[0]["Improvement"].ToString();
                //    txttraining.Text = dtcompetencies.Rows[0]["Training"].ToString();
                //    txteffective.Text = dtcompetencies.Rows[0]["Effectiveness"].ToString();
                //    txtgaps.Text = dtcompetencies.Rows[0]["Gaps"].ToString();
                //    ddlyesNo.SelectedValue = dtcompetencies.Rows[0]["train"].ToString();
                //    txttrainneed.Text = dtcompetencies.Rows[0]["trainneed"].ToString();
                //}
                Getdetails();
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            if (Session["HRAPPRA"] != null)
            {
                if (Session["HRAPPRA"].ToString() == "HRHOME")
                {
                    Response.Redirect("CooApproval.aspx");
                }

            }
            else
            {
                if (Session["COOPAGE"].ToString() == "YES")
                {
                    Response.Redirect("CooApproval.aspx");
                }
                else
                {
                    Response.Redirect("Appraiser5.aspx");
                }
            }
            
           
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            if (txtgrade.Text.Substring(0, 1).ToString() == "M")
            {
                Response.Redirect("Revpage4.aspx");
            }
            else
            {
                Response.Redirect("Revpage6.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
            //ds = da_obj_Employee.GetFunctionCompetencies(employeeid);
            //DataTable dttemp = new DataTable();
            //dttemp.Columns.Add("Functional");
            //dttemp.Columns.Add("Personal");
            //dttemp.Columns.Add("Managerial");
            //if (ds.Tables.Count > 0)
            //{
            //    if (ds.Tables[0].Rows.Count > ds.Tables[1].Rows.Count)
            //    {
            //        if (ds.Tables[0].Rows.Count > ds.Tables[2].Rows.Count)
            //        {
            //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //            {
            //                dttemp.Rows.Add();
            //                dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
            //            }
            //            if (ds.Tables[1].Rows.Count > ds.Tables[2].Rows.Count)
            //            {
            //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
            //                }
            //            }
            //            else
            //            {
            //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
            //                }
            //            }
            //        }
            //        else
            //        {
            //            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            //            {
            //                dttemp.Rows.Add();
            //                dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
            //            }
            //            if (ds.Tables[0].Rows.Count > ds.Tables[1].Rows.Count)
            //            {
            //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
            //                }
            //            }
            //            else
            //            {
            //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (ds.Tables[1].Rows.Count > ds.Tables[2].Rows.Count)
            //        {
            //            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //            {
            //                dttemp.Rows.Add();
            //                dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
            //            }
            //            if (ds.Tables[0].Rows.Count > ds.Tables[2].Rows.Count)
            //            {
            //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
            //                }
            //            }
            //            else
            //            {
            //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
            //                }
            //            }
            //        }
            //        else
            //        {
            //            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
            //            {
            //                dttemp.Rows.Add();
            //                dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
            //            }
            //            if (ds.Tables[0].Rows.Count > ds.Tables[1].Rows.Count)
            //            {
            //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
            //                }
            //            }
            //            else
            //            {
            //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
            //                }
            //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //                {
            //                    //dttemp.Rows.Add();
            //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
            //                }
            //            }
            //        }
            //    }
            //}
            //grd_user.DataSource = dttemp;
            //grd_user.DataBind();
            ////txtpopgaps.Focus();
            //mpthank.Show();
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            txtgaps.Text = txtpopgaps.Text;
            mpthank.Hide();
        }

        protected void grdall_RowDataBound(object sender, GridViewRowEventArgs e)
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
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[0].Text == "Functional Competencies" || e.Row.Cells[0].Text == "Personal Competencies" || e.Row.Cells[0].Text == "Managerial Competencies")
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Maroon;
                        e.Row.Cells[0].Font.Size = 10;
                        e.Row.Cells[0].Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.LightGray;
                        e.Row.Cells[1].BackColor = System.Drawing.Color.LightGray;
                        e.Row.Cells[1].BorderStyle = 0;
                        e.Row.Cells[1].Visible = false;
                    }
                }
            }
        }

        public void Getdetails()
        {
            ds = da_obj_Employee.GetFunctionCompetencies(employeeid);
            DataTable dttemp = new DataTable();
            dttemp.Columns.Add("Competency");
            dttemp.Columns.Add("gaps");
            dttemp.Columns.Add("compid");
            DataRow dr = dttemp.NewRow();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dr = dttemp.NewRow();
                    dr["Competency"] = "Functional Competencies";
                    dr["gaps"] = "";
                    dr["compid"] = "";
                    dttemp.Rows.Add(dr);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dr = dttemp.NewRow();
                        dr["Competency"] = ds.Tables[0].Rows[i]["Competency"].ToString();
                        dr["gaps"] = ds.Tables[0].Rows[i]["gaps"].ToString();
                        dr["compid"] = Convert.ToInt32(ds.Tables[0].Rows[i]["compid"].ToString());
                        dttemp.Rows.Add(dr);
                    }
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dr = dttemp.NewRow();
                    dr["Competency"] = "Personal Competencies";
                    dr["gaps"] = "";
                    dr["compid"] = "";
                    dttemp.Rows.Add(dr);
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        dr = dttemp.NewRow();
                        dr["Competency"] = ds.Tables[1].Rows[i]["Competency"].ToString();
                        dr["gaps"] = ds.Tables[1].Rows[i]["gaps"].ToString();
                        dr["compid"] = Convert.ToInt32(ds.Tables[1].Rows[i]["compid"].ToString());
                        dttemp.Rows.Add(dr);
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    dr = dttemp.NewRow();
                    dr["Competency"] = "Managerial Competencies";
                    dr["gaps"] = "";
                    dr["compid"] = "";
                    dttemp.Rows.Add(dr);
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        dr = dttemp.NewRow();
                        dr["Competency"] = ds.Tables[2].Rows[i]["Competency"].ToString();
                        dr["gaps"] = ds.Tables[2].Rows[i]["gaps"].ToString();
                        dr["compid"] = Convert.ToInt32(ds.Tables[2].Rows[i]["compid"].ToString());
                        dttemp.Rows.Add(dr);
                    }
                }

                grdall.DataSource = dttemp;
                grdall.DataBind();
                foreach (GridViewRow row in grdall.Rows)
                {
                    TextBox textpers = (TextBox)grdall.Rows[row.RowIndex].FindControl("txtcompetency");
                    textpers.Text = dttemp.Rows[row.RowIndex]["gaps"].ToString();
                }
               
            }
        }
    }
}