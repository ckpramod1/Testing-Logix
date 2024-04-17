using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

namespace logix.Home
{
    public partial class NewHroHome : System.Web.UI.Page
    {
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.Masters.MasterBranch objbranch = new DataAccess.Masters.MasterBranch();
        DataTable Dtbranch = new DataTable();
        DataTable dt = new DataTable();
        DataTable DTConf = new DataTable();
        DataAccess.HR.Employee objHrEmployee = new DataAccess.HR.Employee();
        DataAccess.HR.FrontPage HRFrontObj = new DataAccess.HR.FrontPage();
        DataAccess.Payroll.LWF objLfw = new DataAccess.Payroll.LWF();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        int fyear;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    fillyear();
                    loadDivisionConPro();
                   // detailEmp.Visible = false;
                    divBranch.Visible = true;
                    pnlBranchwise.Visible = false;
                   // grdBranchEmpDetails.Visible = false;
                   // Empdeatis.Visible = false;
                    divNew.Visible = true;
                   // pnlcustomerWisw.Visible = false;
                    GrdCustomerWise.Visible = false;
                    loadBirthDay();
                    Pending_Confirmation();
                    Kpi_Binding();
                    grdKpiDetails.Visible = true;
                    detailEmp.Visible = true;
                    pnlBranchwise.Visible = true;
                    grdBranchEmpDetails.Visible = true;
                    grdBranchEmpDetails.DataSource = Utility.Fn_GetEmptyDataTable();
                    grdBranchEmpDetails.DataBind();
                    pnlcustomerWisw.Visible = true;
                    Empdeatis.Visible = true;
                    GrdCustomerWise.Visible = true;
                    GrdCustomerWise.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdCustomerWise.DataBind();

                    

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
        }

        

        public void loadBirthDay()
        {
            Panelbdaylist.Visible = true;
            grdbdaylist.Visible = true;
            DataTable dt = new DataTable();
            dt = HRFrontObj.GetCurrMonthBirthdayNew();


            grdbdaylist.DataSource = dt;
            grdbdaylist.DataBind();

        }


        public void fillyear()

        {


        DateTime dt_Date1 = obj_da_Log.GetDate();
            DataTable dtable1 = new DataTable();
            dtable1.Columns.Add("FAYear");
            string str_dispyear = "";
            int k = 0;
            if (dt_Date1.Month < 4)
            {
                for (int i = 2016; i <= dt_Date1.Year - 1; i++)
                {
                    dtable1.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable1.Rows[k]["FAYear"] = str_dispyear;
                    k++;
                }
            }
            else
            {
                for (int i = 2016; i <= dt_Date1.Year; i++)
                {
                    dtable1.Rows.Add();
                    str_dispyear = Convert.ToString(i);
                    str_dispyear = str_dispyear.Substring(0, 4);
                    int dy = 0;
                    string dy1 = null;
                    dy1 = "";
                    dy = Convert.ToInt32(str_dispyear) + 1;
                    dy1 = Convert.ToString(dy);
                    str_dispyear = str_dispyear + "-" + dy1;
                    dtable1.Rows[k]["FAYear"] = str_dispyear;

                    k++;
                }
            }



            if ((obj_da_Log.GetDate().Month) < 4)
            {
                cmbYearkbi.DataSource = dtable1;
                cmbYearkbi.DataTextField = "FAYear";
                cmbYearkbi.DataBind();
            }
            else
            {
                cmbYearkbi.DataSource = dtable1;
                cmbYearkbi.DataTextField = "FAYear";
                cmbYearkbi.DataBind();
            }

            hidfyear.Value = cmbYearkbi.Text.Substring(0, 4);
    }
        public void Pending_Confirmation()
        {
            //try
            //{


                DTConf = HRFrontObj.GetCurrMonthConfirm();
                DataTable dtnew = new DataTable();
                dtnew.Columns.Add("Company");
                dtnew.Columns.Add("Branch");
                dtnew.Columns.Add("EMPNAME");
                dtnew.Columns.Add("(Confirm)");
                PendingEmp.Visible = true;
                pnlPendingCon.Visible = true;
                GridView1PendingConfirmation.Visible = true;

                for (int i = 0; i < DTConf.Rows.Count; i++)
                {
                    dtnew.Rows.Add();
                    dtnew.Rows[i]["Company"] = DTConf.Rows[i][2].ToString().Trim();


                    if (DTConf.Rows[i][3].ToString() == "CHENNAI")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-CHE";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "BANGALORE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-BLR";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "CALCUTTA")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-KOL";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "AHMEDABAD")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-AHD";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "COCHIN")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-COC";
                    }

                    else if (DTConf.Rows[i][3].ToString() == "COIMBATORE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-CBE";
                    }

                    else if (DTConf.Rows[i][3].ToString() == "CORPORATE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-CO";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "HYDERABAD")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-HYD";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "KARUR")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-KRR";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "LUDHIANA")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-LUD";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "MUMBAI")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-MUM";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "NEW DELHI")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-DEL";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "PUNE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-PUN";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "TIRUPUR")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-TPR";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "TRIVANDRUM")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-TVM";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "TUTICORIN")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-TUT";
                    }
                    else if (DTConf.Rows[i][3].ToString() == "VISHAKHAPATNAM")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-VIS";
                    }

                    else if (DTConf.Rows[i][3].ToString() == "WAREHOUSE")
                    {
                        dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim() + "-WH";
                    } 
                    // dtnew.Rows[i]["Branch"] = DTConf.Rows[i][5].ToString().Trim();
                    DateTime dtime = Convert.ToDateTime(DTConf.Rows[i][4].ToString());

                    DateTime dtimenew = Convert.ToDateTime(dtime.AddMonths(6).ToString());
                    dtnew.Rows[i]["EMPNAME"] = DTConf.Rows[i][0].ToString().Trim();
                    dtnew.Rows[i]["(Confirm)"] = Utility.fn_ConvertDate(dtimenew.ToString());

                }

                GridView1PendingConfirmation.DataSource = dtnew;
                GridView1PendingConfirmation.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    string message = ex.Message.ToString();
            //    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            //}
        }

        public void Kpi_Binding()
        {
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0;
            int sum1, sum2, sum3, sum4, sum5;
            DataTable dtKpi = new DataTable();
            fyear = Convert.ToInt32(hidfyear.Value);
            dtKpi = objLfw.GetKpiConfirmationDetailsNew(fyear);
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("divisionname");
            dtnew.Columns.Add("totemployee");
            dtnew.Columns.Add("Self");
            dtnew.Columns.Add("Appraiser");
            dtnew.Columns.Add("Reviewer");
            dtnew.Columns.Add("COO");
            dtnew.Columns.Add("divisionid");
            dtnew.Columns.Add("year");
            if (dtKpi.Rows.Count > 0)
            {

                for (int i = 0; i <= dtKpi.Rows.Count - 1; i++)
                {
                    dtnew.Rows.Add();
                    dtnew.Rows[i]["divisionname"] = dtKpi.Rows[i]["divisionname"].ToString();
                    dtnew.Rows[i]["totemployee"] = dtKpi.Rows[i]["totemployee"].ToString();
                    sum1 = Convert.ToInt32(dtKpi.Rows[i]["totemployee"].ToString());
                    dtnew.Rows[i]["Self"] = dtKpi.Rows[i]["Self"].ToString();
                    sum2 = Convert.ToInt32(dtKpi.Rows[i]["Self"].ToString());
                    dtnew.Rows[i]["Appraiser"] = dtKpi.Rows[i]["Appraiser"].ToString();
                    sum3 = Convert.ToInt32(dtKpi.Rows[i]["Appraiser"].ToString());
                    dtnew.Rows[i]["Reviewer"] = dtKpi.Rows[i]["Reviewer"].ToString();
                    sum4 = Convert.ToInt32(dtKpi.Rows[i]["Reviewer"].ToString());
                    dtnew.Rows[i]["COO"] = dtKpi.Rows[i]["COO"].ToString();
                    sum5 = Convert.ToInt32(dtKpi.Rows[i]["COO"].ToString());
                    dtnew.Rows[i]["divisionid"] = dtKpi.Rows[i]["divisionid"].ToString();
                    dtnew.Rows[i]["year"] = dtKpi.Rows[i]["year"].ToString();

                    count1 = count1 + sum1;
                    count2 = count2 + sum2;
                    count3 = count3 + sum3;
                    count4 = count4 + sum4;
                    count5 = count5 + sum5;
                }

                dtnew.Rows.Add();
                dtnew.Rows[dtnew.Rows.Count - 1][0] = "Total";
                dtnew.Rows[dtnew.Rows.Count - 1][1] = Convert.ToString(count1);
                dtnew.Rows[dtnew.Rows.Count - 1][2] = Convert.ToString(count2);
                dtnew.Rows[dtnew.Rows.Count - 1][3] = Convert.ToString(count3);
                dtnew.Rows[dtnew.Rows.Count - 1][4] = Convert.ToString(count4);
                dtnew.Rows[dtnew.Rows.Count - 1][5] = Convert.ToString(count5);

                grdKpiDetails.DataSource = dtnew;
                grdKpiDetails.DataBind();
            }
            if (grdKpiDetails.Rows.Count > 0)
            {

                grdKpiDetails.Rows[grdKpiDetails.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.Blue;
                grdKpiDetails.Rows[grdKpiDetails.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Crimson;
                grdKpiDetails.Rows[grdKpiDetails.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Crimson;
                grdKpiDetails.Rows[grdKpiDetails.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Crimson;
                grdKpiDetails.Rows[grdKpiDetails.Rows.Count - 1].Cells[4].ForeColor = System.Drawing.Color.Crimson;
                grdKpiDetails.Rows[grdKpiDetails.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Crimson;
            }

            else
            {
                grdKpiDetails.DataSource = new DataTable();
                grdKpiDetails.DataBind();
            }
        }



        public void loadDivisionConPro()
        {
            int sumcon = 0;
            int sumpro = 0;
            // dt = hrempobj.GetDivision("M");
            dt = hrempobj.GetDivisionhrm("HR");
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("Division");
            dtnew.Columns.Add("Confirm");
            dtnew.Columns.Add("Probation");
            dtnew.Columns.Add("divisionid");
            Paneldiv.Visible = true;
            Griddivconpro.Visible = true;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dtnew.Rows.Add();
                    dtnew.Rows[i]["Division"] = dt.Rows[i]["divsname"].ToString();
                    dtnew.Rows[i]["divisionid"] = dt.Rows[i]["divisionid"].ToString();
                    dtnew.Rows[i]["Confirm"] = Convert.ToString(HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["divisionname"].ToString()));
                    dtnew.Rows[i]["Probation"] = Convert.ToString(HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["divisionname"].ToString()));

                    sumcon = sumcon + HRFrontObj.GetDivisionNoofConfirmEmp(dt.Rows[i]["divisionname"].ToString());
                    sumpro = sumpro + HRFrontObj.GetDivisionNoofTemporaryEmp(dt.Rows[i]["divisionname"].ToString());
                }
                dtnew.Rows.Add();
                dtnew.Rows[dtnew.Rows.Count - 1][0] = "Total";
                dtnew.Rows[dtnew.Rows.Count - 1][1] = Convert.ToString(sumcon);
                dtnew.Rows[dtnew.Rows.Count - 1][2] = Convert.ToString(sumpro);
            }
            Griddivconpro.DataSource = dtnew;
            Griddivconpro.DataBind();
            if (Griddivconpro.Rows.Count > 0)
            {

                Griddivconpro.Rows[Griddivconpro.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.Blue;
                Griddivconpro.Rows[Griddivconpro.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Crimson;
                Griddivconpro.Rows[Griddivconpro.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Crimson;
                Griddivconpro.Rows[Griddivconpro.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Crimson;
            }
            else
            {
                Griddivconpro.DataSource = new DataTable();
                Griddivconpro.DataBind();
            }

        }

        protected void Griddivconpro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0;
            string divid;
            try
            {
                if (Griddivconpro.Rows.Count > 0)
                {
                    index = Griddivconpro.SelectedRow.RowIndex;
                    detailEmp.Visible = true;
                    divBranch.Visible = true;
                    pnlBranchwise.Visible = true;
                    grdBranchEmpDetails.Visible = true;
                    //Empdeatis.Visible = false;
                    //divNew.Visible = false;
                    //pnlcustomerWisw.Visible = false;
                    //GrdCustomerWise.Visible = false;
                    divid = Griddivconpro.Rows[index].Cells[1].Text;
                    Dtbranch = objbranch.GetBranchWiseConfirmation(Convert.ToInt32(divid));
                    DataTable dtnew = new DataTable();
                    dtnew.Columns.Add("branch");
                    dtnew.Columns.Add("confirm");
                    dtnew.Columns.Add("Probation");
                    dtnew.Columns.Add("branchid");

                    if (Dtbranch.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dtbranch.Rows.Count - 1; i++)
                        {
                            dtnew.Rows.Add();
                            dtnew.Rows[i]["branch"] = Dtbranch.Rows[i]["shortname"].ToString();
                            count1 += 1;
                            dtnew.Rows[i]["confirm"] = Dtbranch.Rows[i]["confirm"].ToString();
                            count2 += Convert.ToInt32(Dtbranch.Rows[i]["confirm"].ToString());
                            dtnew.Rows[i]["Probation"] = Dtbranch.Rows[i]["Probation"].ToString();
                            count3 += Convert.ToInt32(Dtbranch.Rows[i]["Probation"].ToString());
                            dtnew.Rows[i]["branchid"] = Dtbranch.Rows[i]["branchid"].ToString();
                        }
                        dtnew.Rows.Add();
                        dtnew.Rows[dtnew.Rows.Count - 1][0] = "Total -" + Convert.ToString(count1);
                        dtnew.Rows[dtnew.Rows.Count - 1][1] = Convert.ToString(count2);
                        dtnew.Rows[dtnew.Rows.Count - 1][2] = Convert.ToString(count3);
                        // dtnew.Rows[dtnew.Rows.Count - 1][3] = Convert.ToString(count3);

                        grdBranchEmpDetails.DataSource = dtnew;
                        grdBranchEmpDetails.DataBind();
                    }
                    if (grdBranchEmpDetails.Rows.Count > 0)
                    {

                        grdBranchEmpDetails.Rows[grdBranchEmpDetails.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.Blue;
                        grdBranchEmpDetails.Rows[grdBranchEmpDetails.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Crimson;
                        grdBranchEmpDetails.Rows[grdBranchEmpDetails.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Crimson;
                    }


                    else
                    {
                        grdBranchEmpDetails.DataSource = dtnew;
                        grdBranchEmpDetails.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //objHrEmployee
        protected void Griddivconpro_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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


                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    Label agent = (Label)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Division");

                    if (agent.Text != "Total")
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Griddivconpro, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdBranchEmpDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                    Label branch = (Label)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("branch");
                    if (branch.Text.Contains("Total"))
                    {
                    }
                    else
                    {
                        e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBranchEmpDetails, "Select$" + e.Row.RowIndex);
                        e.Row.Attributes["style"] = "cursor:pointer";
                    }
                    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBranchEmpDetails, "Select$" + e.Row.RowIndex);
                    //e.Row.Attributes["style"] = "cursor:pointer";

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdBranchEmpDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string branchid;
            try
            {
                if (grdBranchEmpDetails.Rows.Count > 0)
                {
                    Empdeatis.Visible = true;
                    divNew.Visible = true;
                    pnlcustomerWisw.Visible = true;
                    GrdCustomerWise.Visible = true;
                    index = grdBranchEmpDetails.SelectedRow.RowIndex;
                    branchid = grdBranchEmpDetails.Rows[index].Cells[3].Text;
                    DataTable Dttable = new DataTable();
                    Dttable = hrempobj.GetConfirmemempname(Convert.ToInt32(branchid));
                    DataTable dtnew = new DataTable();
                    dtnew.Columns.Add("SL #");
                    dtnew.Columns.Add("Empid");
                    dtnew.Columns.Add("Empname");
                    dtnew.Columns.Add("Department");
                    dtnew.Columns.Add("designation");
                    dtnew.Columns.Add("Status");
                    if (Dttable.Rows.Count > 0)
                    {
                        for (int i = 0; i <= Dttable.Rows.Count - 1; i++)
                        {
                            dtnew.Rows.Add();
                            dtnew.Rows[i]["Empid"] = Dttable.Rows[i]["Empid"].ToString();
                            dtnew.Rows[i]["Empname"] = Dttable.Rows[i]["Empname"].ToString();
                            dtnew.Rows[i]["Department"] = Dttable.Rows[i]["Department"].ToString();
                            dtnew.Rows[i]["designation"] = Dttable.Rows[i]["designation"].ToString();
                            dtnew.Rows[i]["Status"] = Dttable.Rows[i]["Status"].ToString();
                        }
                        GrdCustomerWise.DataSource = dtnew;
                        GrdCustomerWise.DataBind();
                    }
                    else
                    {
                        GrdCustomerWise.DataSource = dtnew;
                        GrdCustomerWise.DataBind();
                    }
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdKpiDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                Label divisionname = (Label)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("divisionname");
                if (divisionname.Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdKpiDetails, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdKpiDetails, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdKpiDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            int did = Convert.ToInt32(grdKpiDetails.SelectedRow.Cells[6].Text.ToString());

            int year = Convert.ToInt32(grdKpiDetails.SelectedRow.Cells[7].Text.ToString());
            Response.Redirect("../Home/HRAppraisalDetails.aspx?HRMAppraisal=" + did + "&Year="+year);
        }
        protected void cmbYearkbi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // fyear = cmbYearkbi.SelectedIndex;

            fyear = Convert.ToInt32(cmbYearkbi.SelectedItem.ToString().Substring(0, 4));
            hidfyear.Value = fyear.ToString();
            Kpi_Binding();
           
        }


    }
}