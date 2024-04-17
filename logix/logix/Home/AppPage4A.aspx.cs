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
    public partial class AppPage4A : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        DataAccess.HR.Appraisal da_obj_App = new DataAccess.HR.Appraisal();
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

        public void checkdata()
        {
            int totfunc = 0;
            int totpers = 0;
            int totMan = 0;
            if(chkagree.Checked == false)
            {
                if (grdall.Rows.Count > 0)
                {
                    for (int i = 0; i < grdall.Rows.Count; i++)
                    {
                        TextBox textfunc = (TextBox)grdall.Rows[i].FindControl("txtcompetency");
                        //string selfrating = grd_user.Rows[i].Cells[3].Text.ToString();
                        if (textfunc.Text == "")
                        {
                            totfunc = totfunc + 1;
                        }
                    }
                    if (grdall.Rows.Count == totfunc)
                    {
                        ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Enter atleast one Gaps in Competencies');", true);
                        bol = true;
                        return;
                    }
                }
            }
                       
            //if(grdpers.Rows.Count > 0)
            //{
            //    for (int i = 0; i < grdpers.Rows.Count; i++)
            //    {
            //        TextBox textpers = (TextBox)grdpers.Rows[i].FindControl("txtpersonal");
            //        //string selfrating = grd_user.Rows[i].Cells[3].Text.ToString();
            //        if (textpers.Text == "")
            //        {
            //            totpers = totpers + 1;
            //        }

            //    }
            //    if (grdpers.Rows.Count == totpers)
            //    {
            //        ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Enter atleast one Gaps in Personal Competencies');", true);
            //        bol = true;
            //        return;
            //    }
            //}


            //if (grdMan.Rows.Count > 0)
            //{
            //    for (int i = 0; i < grdMan.Rows.Count; i++)
            //    {
            //        TextBox textman = (TextBox)grdMan.Rows[i].FindControl("txtmangerial");
            //        //string selfrating = grd_user.Rows[i].Cells[3].Text.ToString();
            //        if (textman.Text == "")
            //        {
            //            totMan = totMan + 1;
            //        }
            //    }

            //    if (grdMan.Rows.Count == totMan)
            //    {
            //        ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Enter atleast one Gaps in Managerial Competencies');", true);
            //        bol = true;
            //        return;
            //    }
            //}
            
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
                        dr["compid"] =Convert.ToInt32(ds.Tables[0].Rows[i]["compid"].ToString());
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

               if(ds.Tables[3].Rows.Count == 0 )
               {
                   chkagree.Checked = true;
                   grdall.Enabled = false;
               }
               else
               {
                   chkagree.Checked = false;
                   grdall.Enabled = true;
               }
            }
        }


        protected void btnnext_Click(object sender, EventArgs e)
        {
            employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            checkdata();
            if (bol == true)
            {
                bol = false;
                return;
            }

            if(chkagree.Checked == false)
            {
               int Compid = 0;
                foreach (GridViewRow row in grdall.Rows)
                {
                    if (grdall.DataKeys[row.RowIndex].Value.ToString() != "")
                    {
                        TextBox textpers = (TextBox)grdall.Rows[row.RowIndex].FindControl("txtcompetency");
                        Compid = int.Parse(grdall.DataKeys[row.RowIndex].Value.ToString());
                        if (textpers.Text != "")
                        {
                            da_obj_App.InsGapsCompetency(employeeid, Compid, textpers.Text, year,"I");
                        }
                    }
                }
            }
            else
            {
                foreach (GridViewRow row in grdall.Rows)
                {
                    TextBox textpers = (TextBox)grdall.Rows[row.RowIndex].FindControl("txtcompetency");
                    if (textpers.Text != "")
                    {
                        ScriptManager.RegisterStartupScript(btnnext, typeof(Button), "HRM", "alertify.alert('Please Clear all the Gaps Details to Proceed with No Gaps in Competency');", true);
                        chkagree.Checked = false;
                        grdall.Enabled = true;
                        //chkagree.Focus();
                        return;
                    }
                }
                da_obj_App.InsGapsCompetency(employeeid, 0, "", year, "D");
            }

            //Response.Redirect("AppraNew5.aspx");
           // Response.Redirect("Appraiser6.aspx");
            if (txtgrade.Text.Substring(0, 1).ToString() == "M")
            {
                Response.Redirect("AppraNew5.aspx");
            }
            else
            {
                Response.Redirect("Appraiser6.aspx");
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            if (txtgrade.Text.Substring(0, 1).ToString() == "M")
            {
                Response.Redirect("Appraiser4.aspx");
            }
            else
            {
                Response.Redirect("Appraiser3.aspx");
            }
        }

        protected void ddlyesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlyesNo.SelectedItem.Value == "1")
            {
                txttrainneed.Enabled = true;
                txttrainneed.Focus();
            }
            else
            {
                txttrainneed.Enabled = false;
            }
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

        protected void chkagree_CheckedChanged(object sender, EventArgs e)
        {
            if (chkagree.Checked == true)
            {
                grdall.Enabled = false;
            }
            else
            {
                grdall.Enabled = true;
            }
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    //  employeeid = Convert.ToInt32(Session["APPEmpid"].ToString());
        //    //  ds = da_obj_Employee.GetFunctionCompetencies(employeeid);
        //    //  DataTable dttemp = new DataTable();
        //    //  dttemp.Columns.Add("Functional");
        //    //  dttemp.Columns.Add("Personal");
        //    //  dttemp.Columns.Add("Managerial");
        //    //if(ds.Tables.Count > 0 )
        //    //{
        //    //    if(ds.Tables[0].Rows.Count > ds.Tables[1].Rows.Count)
        //    //    {
        //    //        if(ds.Tables[0].Rows.Count > ds.Tables[2].Rows.Count)
        //    //        {
        //    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //            {
        //    //                dttemp.Rows.Add();
        //    //                dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
        //    //            }
        //    //            if (ds.Tables[1].Rows.Count > ds.Tables[2].Rows.Count)
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
        //    //                }
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
        //    //            {
        //    //                dttemp.Rows.Add();
        //    //                dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
        //    //            }
        //    //            if (ds.Tables[0].Rows.Count > ds.Tables[1].Rows.Count)
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        if (ds.Tables[1].Rows.Count > ds.Tables[2].Rows.Count)
        //    //        {
        //    //            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    //            {
        //    //                dttemp.Rows.Add();
        //    //                dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
        //    //            }
        //    //            if (ds.Tables[0].Rows.Count > ds.Tables[2].Rows.Count)
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
        //    //                }
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
        //    //            {
        //    //                dttemp.Rows.Add();
        //    //                dttemp.Rows[i]["Managerial"] = ds.Tables[2].Rows[i]["Managerial"].ToString();
        //    //            }
        //    //            if (ds.Tables[0].Rows.Count > ds.Tables[1].Rows.Count)
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Personal"] = ds.Tables[1].Rows[i]["Personal"].ToString();
        //    //                }
        //    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //                {
        //    //                    //dttemp.Rows.Add();
        //    //                    dttemp.Rows[i]["Functional"] = ds.Tables[0].Rows[i]["Functional"].ToString();
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    //grd_user.DataSource = dttemp;
        //    //grd_user.DataBind();
        //    //txtpopgaps.Focus();
        //   // mpthank.Show();
        //}

        //protected void btnclose_Click(object sender, EventArgs e)
        //{
        //  //  txtgaps.Text = txtpopgaps.Text;
        //    //mpthank.Hide();
        //}
    }
}