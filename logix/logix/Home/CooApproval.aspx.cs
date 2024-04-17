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
    public partial class CooApproval : System.Web.UI.Page
    {
        DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();
        int employeeid = 0;
        DataTable dtcom = new DataTable();
        DataTable dtcompetencies = new DataTable();
        DataTable dtkpi = new DataTable();
        DataSet dskpi = new DataSet();
        int year = 0;
        double totselfkpi = 0;
        double totselfcomp = 0;
        double totappkpi = 0;
        double totappcomp = 0;
        Boolean bol;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnprevious1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnsubmit);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            if (!IsPostBack)
            {
                employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
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

                if (Session["HRAPPRA"] != null)
                {
                    if (Session["HRAPPRA"].ToString() == "HRHOME")
                    {
                        btnsubmit.Enabled = false;
                        btnhome.Enabled = true;
                    }
                }
                else
                {
                    btnsubmit.Enabled = true;
                    btnhome.Enabled = false;
                }

                Fn_LoadDesignation();
                Fn_Loadgrade();

                dskpi = da_obj_Employee.GetKPITotalRating(employeeid, year);
                if (dskpi.Tables[0].Rows.Count > 0)
                {
                    txtselfkpi.Text = dskpi.Tables[0].Rows[0]["selfkpi"].ToString();
                    totselfkpi = Convert.ToDouble(dskpi.Tables[0].Rows[0]["selfkpi"].ToString());
                    txtappkpi.Text = dskpi.Tables[0].Rows[0]["appkpi"].ToString();
                    totappkpi = Convert.ToDouble(dskpi.Tables[0].Rows[0]["appkpi"].ToString());
                    txtappremarks.Text = dskpi.Tables[0].Rows[0]["appremarks"].ToString();
                }
                if (dskpi.Tables[1].Rows.Count > 0)
                {
                    txtselfcomp.Text = dskpi.Tables[1].Rows[0]["selfcomp"].ToString();
                    totselfcomp = Convert.ToDouble(dskpi.Tables[1].Rows[0]["selfcomp"].ToString());
                    txtappcomp.Text = dskpi.Tables[1].Rows[0]["appcomp1"].ToString();
                    totappcomp = Convert.ToDouble(dskpi.Tables[1].Rows[0]["appcomp1"].ToString());
                }
                totself.Text = (totselfkpi + totselfcomp).ToString();
                totalapp.Text = (totappkpi + totappcomp).ToString();

                if (dskpi.Tables[2].Rows.Count > 0)
                {
                    if (dskpi.Tables[2].Rows[0]["SalRevAmt"].ToString() == "")
                    {
                        Label9.Enabled = false;
                        txtsalrev.Enabled = false;
                        ddlsal.SelectedIndex = 1;

                    }
                    else
                    {
                      //  Label9.Enabled = true;
                      //  txtsalrev.Enabled = true;
                       // ddlmode.Enabled = true;
                        ddlmode.SelectedIndex = Convert.ToInt32(dskpi.Tables[2].Rows[0]["revsalmode"].ToString());
                        txtsalrev.Text = string.Format("{0:#,##0.00}",dskpi.Tables[2].Rows[0]["SalRevAmt"]);
                        ddlsal.SelectedIndex = 2;
                    }

                    txtspecialremarks.Text = dskpi.Tables[2].Rows[0]["spremarks"].ToString();

                    if (dskpi.Tables[2].Rows[0]["regrade"].ToString() == "2")
                    {
                        //Label15.Enabled = true;
                        //ddlgrade.Enabled = true;
                        ddlgrade.SelectedItem.Text = dskpi.Tables[2].Rows[0]["Grade"].ToString();
                        ddlgradestatus.SelectedIndex = 2;
                    }
                    else
                    {
                        Label15.Enabled = false;
                        ddlgrade.Enabled = false;
                        ddlgradestatus.SelectedIndex = 1;
                    }
                    if (dskpi.Tables[2].Rows[0]["redesig"].ToString() == "2")
                    {
                        ddldesignation.Visible = true;
                        ddlredesig.Visible = false;
                        ddldesignation.SelectedItem.Text = dskpi.Tables[2].Rows[0]["designame"].ToString();
                    }
                    else
                    {
                        ddldesignation.Visible = false;
                        ddlredesig.Visible = true;
                        ddlredesig.SelectedIndex = 1;
                    }
                  

                }

                if (dskpi.Tables[3].Rows.Count > 0)
                {
                    if (dskpi.Tables[3].Rows[0]["CoSalRevAmt"].ToString() == "")
                    {
                        txtcoosalary.Enabled = false;
                        ddlcoosalary.SelectedIndex = 1;
                    }
                    else
                    {
                        txtcoosalary.Enabled = true;
                        ddlcoomode.Enabled = true;
                        ddlcoomode.SelectedIndex = Convert.ToInt32(dskpi.Tables[3].Rows[0]["coosalmode"].ToString());
                        txtcoosalary.Text = string.Format("{0:#,##0.00}",dskpi.Tables[3].Rows[0]["CoSalRevAmt"]);
                        ddlcoosalary.SelectedIndex = 2;
                    }

                    txtcoospremarks.Text = dskpi.Tables[3].Rows[0]["Cospremarks"].ToString();

                    if (dskpi.Tables[3].Rows[0]["CoRegrade"].ToString() == "2")
                    {
                        ddlcoograde.SelectedItem.Text = dskpi.Tables[3].Rows[0]["CoGrade"].ToString();
                        ddlcooregrade.SelectedIndex = 2;
                        ddlcooregrade.Enabled = true;
                        ddlcoograde.Enabled = true;
                    }
                    else
                    {
                        ddlcoograde.Enabled = false;
                        ddlcooregrade.SelectedIndex = 1;
                    }

                    if (dskpi.Tables[3].Rows[0]["CoRedesig"].ToString() == "2")
                    {
                        ddlcoodesig.SelectedItem.Text = dskpi.Tables[3].Rows[0]["designame"].ToString();
                        ddlcoodesig.Enabled = true;
                        ddlcooredesig.SelectedIndex = 2;
                        ddlcooredesig.Enabled = true;
                    }
                    else
                    {
                        ddlcoodesig.Enabled = false;
                        ddlcooredesig.SelectedIndex = 1;
                    }


                  

                }


                if (Convert.ToDouble(totalapp.Text) >= 0)
                {
                    lblkeylabel.Visible = true;
                    lblkeyvalue.Visible = true;
                    if (Convert.ToDouble(totalapp.Text) < 60)
                    {
                        lblkeyvalue.Text = "Needs Improvement";
                        lblkeyvalue.ToolTip = "Performance is inconsistent.Meets requirements of the job occasionally. Supervision and Training is required for most problem area. Performance needs to be reviewed, may need to be replaced.";
                    }
                    else if (Convert.ToDouble(totalapp.Text) >= 60 && Convert.ToDouble(totalapp.Text) < 80)
                    {
                        lblkeyvalue.Text = "Good";
                        lblkeyvalue.ToolTip = "Performance is consistent. Clearly meets essential requirements of job . Performance should be 75% on prescribed matrix level";
                    }
                    else if (Convert.ToDouble(totalapp.Text) >= 80 && Convert.ToDouble(totalapp.Text) <= 90)
                    {
                        lblkeyvalue.Text = "Very Good";
                        lblkeyvalue.ToolTip = "Performance is consistent and exceeds expectations in all situations . Performance should be 80% to 100% on prescribed matrix level.";
                    }
                    else
                    {
                        lblkeyvalue.Text = "Outstanding";
                        lblkeyvalue.ToolTip = "Performance is exceptional and far exceeds expectations . Consistently demonstrates excellent standards in all job requirements. Performance should be 30% above prescribed matrix level.";
                    }
                }

                if (Convert.ToDouble(totself.Text) >= 0)
                {
                    lblkeyappraisee.Visible = true;
                    lblkeyappraisee.Visible = true;
                    if (Convert.ToDouble(totself.Text) < 60)
                    {
                        lblkeyappraisee.Text = "Needs Improvement";
                        lblkeyappraisee.ToolTip = "Performance is inconsistent.Meets requirements of the job occasionally. Supervision and Training is required for most problem area. Performance needs to be reviewed, may need to be replaced.";
                    }
                    else if (Convert.ToDouble(totself.Text) >= 60 && Convert.ToDouble(totself.Text) < 80)
                    {
                        lblkeyappraisee.Text = "Good";
                        lblkeyappraisee.ToolTip = "Performance is consistent. Clearly meets essential requirements of job . Performance should be 75% on prescribed matrix level";
                    }
                    else if (Convert.ToDouble(totself.Text) >= 80 && Convert.ToDouble(totself.Text) <= 90)
                    {
                        lblkeyappraisee.Text = "Very Good";
                        lblkeyappraisee.ToolTip = "Performance is consistent and exceeds expectations in all situations . Performance should be 80% to 100% on prescribed matrix level.";
                    }
                    else
                    {
                        lblkeyappraisee.Text = "Outstanding";
                        lblkeyappraisee.ToolTip = "Performance is exceptional and far exceeds expectations . Consistently demonstrates excellent standards in all job requirements. Performance should be 30% above prescribed matrix level.";
                    }
                }


            }
        }

        private void Fn_LoadDesignation()
        {
            DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_HrEmp.GetDesign();
            ddldesignation.DataSource = obj_dt;
            ddldesignation.DataTextField = "designame";
            ddldesignation.DataBind();
            ddlcoodesig.DataSource = obj_dt;
            ddlcoodesig.DataTextField = "designame";
            ddlcoodesig.DataBind();
        }

        private void Fn_Loadgrade()
        {
            //DataAccess.Masters.MasterEmployee da_obj_HrEmp = new DataAccess.Masters.MasterEmployee();
            DataTable obj_dt = new DataTable();
            obj_dt = da_obj_Employee.GetGradeForKPI();
            ddlgrade.DataSource = obj_dt;
            ddlgrade.DataTextField = "grade";
            ddlgrade.DataBind();
            ddlcoograde.DataSource = obj_dt;
            ddlcoograde.DataTextField = "grade";
            ddlcoograde.DataBind();
        }

        protected void btnprevious1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RevPage4A.aspx");
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int intDesigID = 0;
            Double persal = 0;
            DateTime sfrom = Convert.ToDateTime(Utility.fn_ConvertDate("04/01/2017").ToString());
            DateTime sto = Convert.ToDateTime(Utility.fn_ConvertDate("31/03/2018").ToString());
            Double revisegross;
            string witharrear = "";
            DataTable dtrev = new DataTable();
            DataTable dtcur = new DataTable();
            if (txtappkpi.Text == "" && txtappcomp.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Complete the Rating and then Submit');", true);
                return;
            }
            else
            {
                checkdata();
                if (bol == true)
                {
                    bol = false;
                    return;
                }
                employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
                year = Convert.ToInt32(DateTime.Now.Year.ToString());
                intDesigID = empObj.GetDesgnid(ddlcoodesig.SelectedItem.Text);
               
                if (ddlcoomode.SelectedIndex == 1)
                {
                    persal = Convert.ToDouble(txtgrossmon.Text) + (Convert.ToDouble(txtgrossmon.Text) * (Convert.ToDouble(txtcoosalary.Text) / 100 ));
                    revisegross = persal;
                }
                else if (ddlcoomode.SelectedIndex == 2)
                {
                    revisegross = Convert.ToDouble(txtgrossmon.Text) + Convert.ToDouble(txtcoosalary.Text);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Kindly Select Salary Mode');", true);
                    return;
                }
              
                if(ddlcooregrade.SelectedIndex == 1)
                {
                    dtrev = da_obj_Employee.GetRevisedSalary(employeeid, txtgrade.Text.ToString(), revisegross, sfrom, sto, witharrear, sfrom, sfrom);
                }
                else if (ddlcooregrade.SelectedIndex == 2)
                {
                    dtrev = da_obj_Employee.GetRevisedSalary(employeeid, ddlcoograde.SelectedItem.Value.ToString(), revisegross, sfrom, sto, witharrear, sfrom, sfrom);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Kindly Choose Grade');", true);
                    return;
                }
                

                grd_user.DataSource = dtrev;
                grd_user.DataBind();


                mpthank.Show();
              
            }
        }

        public void bindsalary()
        {

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }

        protected void ddlcooregrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcooregrade.SelectedItem.Value == "2")
            {
                 ddlcoograde.Enabled = true;
            }
            else
            {
                ddlcoograde.Enabled = false;
            }
        }

        protected void ddlsal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlsal.SelectedItem.Value == "2")
            //{
            //    Label9.Enabled = true;
            //    txtsalrev.Enabled = true;
            //}
            //else
            //{
            //    Label9.Enabled = false;
            //    txtsalrev.Enabled = false;
            //}
        }

        protected void ddlcoosalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcoosalary.SelectedItem.Value == "2")
            {
                ddlcoomode.Enabled = true;
                txtcoosalary.Enabled = true;
                txtcoosalary.Focus();
            }
            else
            {
                txtcoosalary.Enabled = false;
                ddlcoomode.Enabled = false;
            }
        }

        protected void ddlgradestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlgradestatus.SelectedItem.Value == "2")
            //{
            //    Label15.Enabled = true;
            //    ddlgrade.Enabled = true;
            //}
            //else
            //{
            //    Label15.Enabled = false;
            //    ddlgrade.Enabled = false;
            //}
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());

            str_RptName = "RptKpiWithRec.rpt";
            str_sf = "{HRKPI.empid}=" + employeeid + " and {HRKPI.KPIYear}= " + year;
            str_sp = "";
            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Appraisal Details", str_Script, true);
            Session["str_sfs"] = str_sf;
            Session["str_sp"] = str_sp;
        }

        protected void ddlcooredesig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcooredesig.SelectedItem.Value == "2")
            {
                ddlcoodesig.Enabled = true;
            }
            else
            {
                ddlcoodesig.Enabled = false;
            }
        }

        public void checkdata()
        {

            if (ddlcoosalary.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Kindly Select anyone in Salary Changes');", true);
                ddlcoosalary.Focus();
                bol = true;
                return;
            }
            if (ddlcoosalary.SelectedItem.Value == "2")
            {
                if (ddlcoomode.SelectedItem.Value != "0")
                {
                    if (ddlcoomode.SelectedItem.Value == "1")
                    {
                        if (txtcoosalary.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Enter Salary Amount');", true);
                            txtcoosalary.Focus();
                            bol = true;
                            return;
                        }
                        else if (Convert.ToDouble(txtcoosalary.Text) > 100)
                        {
                            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Salary Percentage must be less than 100');", true);
                            txtcoosalary.Focus();
                            bol = true;
                            return;
                        }
                    }
                    else
                    {
                        if (txtcoosalary.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Enter Salary Amount');", true);
                            txtcoosalary.Focus();
                            bol = true;
                            return;
                        }
                    }

                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select Mode of Salary');", true);
                //    txtsalrev.Focus();
                //    bol = true;
                //    return;
                //}
               
            }

            if (ddlcooredesig.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one in Re-Designation Status');", true);
                ddlcooredesig.Focus();
                bol = true;
                return;
            }

            if (ddlcooredesig.SelectedItem.Value == "2")
            {
                if (ddlcoodesig.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one in Re-Designation');", true);
                    ddlcoodesig.Focus();
                    bol = true;
                    return;
                }
            }

            if (ddlcooregrade.SelectedItem.Value == "0")
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one Grade Status');", true);
                ddlcooregrade.Focus();
                bol = true;
                return;
            }

            if (ddlcooregrade.SelectedItem.Value == "2")
            {
                if (ddlcoograde.SelectedIndex == -1)
                {
                    ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Select any one in Grade');", true);
                    ddlcoograde.Focus();
                    bol = true;
                    return;
                }
            }


        }

        protected void grd_user_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string hexfore = "#ffffff";
            string hex = "#2b4e86";
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    //HeaderGridRow.BorderColor = System.Drawing.Color.Chocolate;
                    HeaderGridRow.Font.Bold = true;

                    //HeaderGridRow.CssClass = "clsgridback";
                    TableCell HeaderCell = new TableCell();
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Salary Break-Up";
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Size = 10;
                    // HeaderCell.BorderColor = System.Drawing.Color.Black;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);

                   // HeaderGridRow.CssClass = "clsgridback";

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Current Salary";
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Size = 10;
                    // HeaderCell.BorderColor = System.Drawing.Color.Black;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.ColumnSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);

                   // HeaderGridRow.CssClass = "clsgridback";

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Revised Salary";
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Size = 10;
                    // HeaderCell.BorderColor = System.Drawing.Color.Black;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.ColumnSpan = 2;
                    HeaderGridRow.Cells.Add(HeaderCell);

                    grd_user.Controls[0].Controls.AddAt(0, HeaderGridRow);

                    GridView HeaderGrid3 = (GridView)sender;
                    GridViewRow HeaderGridRow3 = new GridViewRow(2, 0, DataControlRowType.Header, DataControlRowState.Insert);
                  //  HeaderGridRow3.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderGridRow3.Font.Bold = true;
                    HeaderGridRow3.CssClass = "clsgridback";
                    //HeaderGridRow3.ForeColor = System.Drawing.Color.White;

                    TableCell HeaderCell33 = new TableCell();
                    HeaderCell33.Text = "Particulars";
                    HeaderCell33.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell33.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell33.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.Font.Size = 10;
                    HeaderGridRow3.Cells.Add(HeaderCell33);

                    HeaderCell33 = new TableCell();
                    HeaderCell33.Text = "Monthly";
                    HeaderCell33.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell33.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell33.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.Font.Size = 10;
                    HeaderGridRow3.Cells.Add(HeaderCell33);

                    HeaderCell33 = new TableCell();
                    HeaderCell33.Text = "Annual";
                    HeaderCell33.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell33.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell33.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.Font.Size = 10;
                    HeaderGridRow3.Cells.Add(HeaderCell33);

                    HeaderCell33 = new TableCell();
                    HeaderCell33.Text = "Monthly";
                    HeaderCell33.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell33.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell33.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.Font.Size = 10;
                    HeaderGridRow3.Cells.Add(HeaderCell33);

                    HeaderCell33 = new TableCell();
                    HeaderCell33.Text = "Annual";
                    HeaderCell33.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell33.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell33.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell33.Font.Size = 10;
                    HeaderGridRow3.Cells.Add(HeaderCell33);
                                       
                    grd_user.Controls[0].Controls.AddAt(1, HeaderGridRow3);


                }
            }
            catch
            {

            }
        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            mpthank.Hide();
        }

        protected void grd_user_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    Label lbldistrict = e.Row.FindControl("lblsno") as Label;

                    if (lbldistrict.Text == "Monthly Gross" || lbldistrict.Text == "Annual Components" || lbldistrict.Text == "Total" || lbldistrict.Text == "ANNUAL CTC" || lbldistrict.Text == "MONTHLY CTC")
                    {
                        for (int j = 0; j <=4; j++)
                        {
                            e.Row.Cells[j].Font.Bold = true;
                            e.Row.Cells[j].ForeColor = System.Drawing.Color.Black;
                        }
                        
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime sfrom = Convert.ToDateTime(Utility.fn_ConvertDate("01/05/2017").ToString());
            DateTime sto = Convert.ToDateTime(Utility.fn_ConvertDate("31/03/2018").ToString());
            int intDesigID = 0;
            Double revisegross;
            string witharrear = "";
            Double persal = 0;
            Double appamt = 0;
            employeeid = Convert.ToInt32(Session["RevEmpid"].ToString());
            year = Convert.ToInt32(DateTime.Now.Year.ToString());
            intDesigID = empObj.GetDesgnid(ddlcoodesig.SelectedItem.Text); 

            if (ddlcoomode.SelectedIndex == 1)
            {
                persal = Convert.ToDouble(txtgrossmon.Text) + (Convert.ToDouble(txtgrossmon.Text) * (Convert.ToDouble(txtcoosalary.Text) / 100) );
                appamt = (Convert.ToDouble(txtgrossmon.Text) * (Convert.ToDouble(txtcoosalary.Text) / 100));
                revisegross = persal;
            }
            else if (ddlcoomode.SelectedIndex == 2)
            {
                revisegross = Convert.ToDouble(txtgrossmon.Text) + Convert.ToDouble(txtcoosalary.Text);
                appamt = Convert.ToDouble(txtcoosalary.Text);
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert('Kindly Select Salary Mode');", true);
                return;
            }


            da_obj_Employee.InsKpiCOOSubmit(employeeid, year, Convert.ToInt32(ddlcoosalary.SelectedItem.Value.ToString()), Convert.ToDouble(txtcoosalary.Text), Convert.ToInt32(ddlcooredesig.SelectedItem.Value), intDesigID, Convert.ToInt32(ddlcooregrade.SelectedItem.Value.ToString()), ddlcoograde.SelectedItem.Value.ToString(), txtcoospremarks.Text, Convert.ToInt32(ddlcoomode.SelectedItem.Value.ToString()), appamt);
            if (ddlcooregrade.SelectedIndex == 1)
            {
                da_obj_Employee.InsSalaryCalculation(employeeid, txtgrade.Text.ToString(), revisegross, sfrom, sto, witharrear, sfrom, sfrom);
            }
            else if(ddlcooregrade.SelectedIndex == 2)
            {
                da_obj_Employee.InsSalaryCalculation(employeeid, ddlcoograde.SelectedItem.Value.ToString(), revisegross, sfrom, sto, witharrear, sfrom, sfrom);
            }
            
            ScriptManager.RegisterStartupScript(btnsubmit, typeof(Button), "HRM", "alertify.alert(' Appraisal Approved');", true);
            Response.Redirect("../Home/CooEmpList.aspx");
        }

        protected void btnhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/NewHroHome.aspx");
        }
    }
}