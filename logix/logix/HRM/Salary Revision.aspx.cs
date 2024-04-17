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
namespace logix.HRM
{
    public partial class Salary_Revision : System.Web.UI.Page
    {
        DateTime dtget;
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Payroll.salaryRevison objSalRev = new DataAccess.Payroll.salaryRevison();
        DataAccess.HR.Employee PIObj = new DataAccess.HR.Employee();
        DataTable dtsal = new DataTable();
        DataTable dtIncAmt = new DataTable();
        DataTable Dt = new DataTable();
        DataTable dtgross = new DataTable();
        DateTime sfrom, sto, vFrom, vTo, vf, vt;
        string sdiv, sbranch, sgrade, code;
        int eid;
        int frm, todat, fryr, toyr, fixfrm, fixto, lfrmyr, ltoyr, diff;
        Boolean flag;
        double basic, hra, sall, lall, con, other, loyal, ea, drive, medical, pf, esi, lta, bonus;
        string Pgrade;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnCancel);
           // ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(grd);
            if (!IsPostBack)
            {
                cregrd();
                EmptyDataGrid();
                txtCompany.Focus();
               
            }
           

        }

        protected void cregrd()
        {
            DateTime logtime = logobj.GetDate();
            DateTime dtget;
            DateTime dtget1;
            int year = Convert.ToInt32(logtime.Year);
            if (logtime.Month < 4)
            {
               // txtfrom.Text = Convert.ToDateTime(Utility.fn_ConvertDate( "04/01/" + Convert.ToInt32(year - 1))).ToShortDateString();
                dtget1 = Convert.ToDateTime(("04/01/" + (year - 1)));
                txtfrom.Text = Utility.fn_ConvertDate(dtget1.ToShortDateString());
                dtget = Convert.ToDateTime( ( "03/31/" + (year)));
                txtTo.Text =Utility.fn_ConvertDate( dtget.ToShortDateString());
                //txtTo.Text = Convert.ToDateTime("03/31/" + Convert.ToInt32(year)).ToShortDateString();
            }
            else
            {
               // txtfrom.Text = Convert.ToDateTime(Utility.fn_ConvertDate("04/01/" + Convert.ToInt32(year))).ToShortDateString();
                dtget1 = Convert.ToDateTime(("04/01/" + (year)));
                txtfrom.Text = Utility.fn_ConvertDate(dtget1.ToShortDateString());
                dtget = Convert.ToDateTime(( "03/31/" + (year + 1)));
                txtTo.Text = Utility.fn_ConvertDate(dtget.ToShortDateString());

            }
            Session["from"] = txtfrom.Text;
            Session["txtTo"] = txtTo.Text;
        }

        protected void EmptyDataGrid()
        {
            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();
        }
        //,string Prefix1,string Prefix2
        [WebMethod]
        public static void GetCompanyName(string Prefix, string Prefix1, string Prefix2)
        {
            
            DataAccess.LogDetails logobj = new DataAccess.LogDetails();
            DataAccess.Payroll.salaryRevison objSalRev = new DataAccess.Payroll.salaryRevison();
            DataAccess.HR.Employee PIObj = new DataAccess.HR.Employee();
            string sdiv, sbranch, sgrade, code;
            DataTable dtIncAmt = new DataTable();
            DataTable dtsal = new DataTable();
            if (Prefix != "")
            {
                sdiv = Prefix.ToUpper();
            }
            else
            {
                sdiv = "ALL";
            }
            if (Prefix1 != "")
            {
                sbranch = Prefix1.ToUpper();
            }
            else
            {
                sbranch = "ALL";
            }
            if (Prefix2 != "")
            {
                sgrade = Prefix2.ToUpper();
            }
            else
            {
                sgrade = "ALL";
            }
            double temp;
            int eid;
            // GetEmpdetails4SalRev
            string  date=(HttpContext.Current.Session["from"]).ToString();
            DateTime dt = Convert.ToDateTime(Utility.fn_ConvertDate(date));
            dt = dt.AddDays(-30);
            dtsal = objSalRev.GetEmpdetails4SalRev(dt, sdiv, sbranch, sgrade);
            if (dtsal.Rows.Count > 0)
            {
                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add("employeeid");
                dtTemp.Columns.Add("empcode");
                dtTemp.Columns.Add("empname");
                dtTemp.Columns.Add("gross");
                dtTemp.Columns.Add("grade");
                dtTemp.Columns.Add("Proposed Grade");
                dtTemp.Columns.Add("incentive");
                dtTemp.Columns.Add("divisname");
                dtTemp.Columns.Add("branchname");
                DataRow dr = dtTemp.NewRow();
                for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
                {
                    dr = dtTemp.NewRow();
                    dtTemp.Rows.Add(dr);

                    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtsal.Rows[i]["Employeeid"].ToString();
                    eid = Convert.ToInt32(dtsal.Rows[i]["Employeeid"].ToString());
                    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = dtsal.Rows[i]["empcode"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][2] = dtsal.Rows[i]["empname"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][3] = dtsal.Rows[i]["gross"].ToString();
                    //dtTemp.Rows[dtTemp.Rows.Count - 1][4] = 
                    //  DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("pgrade");
                    dtTemp.Rows[dtTemp.Rows.Count - 1][4] = dtsal.Rows[i]["grade"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][7] = dtsal.Rows[i]["divsname"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][8] = dtsal.Rows[i]["portname"].ToString();

              

                }
                HttpContext.Current.Session["Date"] = dtTemp;
                HttpContext.Current.Session["Date1"] = dtsal;
            }
                
                //for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
                //{
                //    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtsal.Rows[i]["Employeeid"].ToString();
                //    eid = Convert.ToInt32(dtsal.Rows[i]["Employeeid"].ToString());
                //    dtIncAmt = objSalRev.GetIncentiveAmt(eid, Convert.ToDateTime(Utility.fn_ConvertDate(HttpContext.Current.Session["from"])), Convert.ToDateTime(Utility.fn_ConvertDate(HttpContext.Current.Session["txtTo"])));

                //    if (dtIncAmt.Rows.Count > 0)
                //    {

                //        if (string.IsNullOrEmpty(dtIncAmt.Rows[0][0].ToString()))
                //        {
                //            // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = "";
                //            ((TextBox)grd.Rows[i].Cells[6].FindControl("txtIncrement")).Text = "";
                //        }
                //        else
                //        {
                //            temp = Convert.ToDouble(dtIncAmt.Rows[0][0].ToString());
                //            // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = temp.ToString("#,0.00");
                //            ((TextBox)grd.Rows[i].Cells[6].FindControl("txtIncrement")).Text = temp.ToString("#,0.00");
                //        }
                //    }
                //    else
                //    {
                //        // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = "";
                //        ((TextBox)grd.Rows[i].FindControl("txtIncrement")).Text = "";
                //    }
                //}
                //for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
                //{
                //    Pgrade = dtsal.Rows[i]["grade"].ToString();
                //    if (Pgrade != "")
                //    {
                //        ((DropDownList)grd.Rows[i].FindControl("pgrade")).SelectedItem.Text = Pgrade;
                //    }
                //    else
                //    {
                //        ((DropDownList)grd.Rows[i].FindControl("pgrade")).SelectedIndex = 0;
                //    }
                //}

                //Dt = objSalRev.SelSalrev4chk();
                //if (Dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                //    {
                //        if (txtfrom.Text == Dt.Rows[i]["validfrom"].ToString() && (txtTo.Text == Dt.Rows[i]["validto"].ToString()))
                //        {
                //            btnSave.Text = "Update";
                //            txtfrom.Enabled = false;
                //            txtTo.Enabled = false;
                //            return;
                //        }
                //        else
                //        {
                //            btnSave.Text = "Save";
                //        }
                //    }
               // }

                //grd.DataSource = dtTemp;
                //grd.DataBind();
            
            
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            if(grd.Rows.Count!=0)
            {
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
            }
            double temp;
            string valuefrom, valueto;
            //DataTable dtsal = new DataTable();
            if (Session["Date1"]!=null)
            {
                dtsal = (DataTable)Session["Date1"];
            }
            

            if (dtsal.Rows.Count == 0 )
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Data Not Found');", true);
                txtCompany.Focus();
                return;
            }
            DataTable dtTemp = new DataTable();
            if (Session["Date"]!=null)
            {
                dtTemp = (DataTable)Session["Date"];
            }
          
            grd.DataSource = dtTemp;
            grd.DataBind();
            valuefrom = Session["from"].ToString();
            valueto = Session["txtTo"].ToString();
            for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
            {

                dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtsal.Rows[i]["Employeeid"].ToString();
                eid = Convert.ToInt32(dtsal.Rows[i]["Employeeid"].ToString());
                dtIncAmt = objSalRev.GetIncentiveAmt(eid, Convert.ToDateTime(Utility.fn_ConvertDate( valuefrom)), Convert.ToDateTime(Utility.fn_ConvertDate( valueto)));

                if (dtIncAmt.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtIncAmt.Rows[0][0].ToString()))
                    {
                        // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = "";
                        ((TextBox)grd.Rows[i].Cells[6].FindControl("txtIncrement")).Text = "";
                    }
                    else
                    {
                        temp = Convert.ToDouble(dtIncAmt.Rows[0][0].ToString());
                        // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = temp.ToString("#,0.00");
                        ((TextBox)grd.Rows[i].Cells[6].FindControl("txtIncrement")).Text = temp.ToString("#,0.00");
                    }
                }
                else
                {
                    // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = "";
                    ((TextBox)grd.Rows[i].FindControl("txtIncrement")).Text = "";
                }
            }
            for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
            {
                Pgrade = dtsal.Rows[i]["grade"].ToString();
                if (Pgrade != "")
                {
                    ((DropDownList)grd.Rows[i].FindControl("pgrade")).SelectedItem.Text = Pgrade;
                }
                else
                {
                    ((DropDownList)grd.Rows[i].FindControl("pgrade")).SelectedIndex = 0;
                }
            }

            Dt = objSalRev.SelSalrev4chk();
            if (Dt.Rows.Count > 0)
            {
                DateTime from = Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text));
               //string date1 = from.ToShortDateString();
                DateTime to = Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text));
               // string date2 = to.ToShortDateString();
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    DateTime Newdate = Convert.ToDateTime(Utility.fn_ConvertDate( Dt.Rows[i]["validfrom"].ToString()));
                    DateTime Newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(Dt.Rows[i]["validto"].ToString()));
                    if (from == Newdate && to == Newdate1)
                    {
                       // btnSave.Text = "Update";

                        btnSave.ToolTip = "Update";
                        btnSave1.Attributes["class"] = "btn btn-update1";
                        txtfrom.Enabled = false;
                        txtTo.Enabled = false;
                        return;
                    }
                    else
                    {
                     //   btnSave.Text = "Save";
                        btnSave.ToolTip = "Save";
                        btnSave1.Attributes["class"] = "btn ico-save";
                    }
                }
            }

                //grd.DataSource = dtTemp;
                //grd.DataBind();
            
        }

        protected void Fill_grid()
        {
            if (txtCompany.Text != "")
            {
                sdiv = txtCompany.Text.ToUpper();
            }
            else
            {
                sdiv = "ALL";
            }
            if (txtBranch.Text != "")
            {
                sbranch = txtBranch.Text.ToUpper();
            }
            else
            {
                sbranch = "ALL";
            }
            if (txtGrade.Text != "")
            {
                sgrade = txtGrade.Text.ToUpper();
            }
            else
            {
                sgrade = "ALL";
            }
            double temp;
            // GetEmpdetails4SalRev
            DateTime dt = Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text));
            dt = dt.AddDays(-30);
            dtsal = objSalRev.GetEmpdetails4SalRev(dt, sdiv, sbranch, sgrade);
            if (dtsal.Rows.Count > 0)
            {
                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add("employeeid");
                dtTemp.Columns.Add("empcode");
                dtTemp.Columns.Add("empname");
                dtTemp.Columns.Add("gross");
                dtTemp.Columns.Add("grade");
                dtTemp.Columns.Add("Proposed Grade");
                dtTemp.Columns.Add("incentive");
                dtTemp.Columns.Add("divisname");
                dtTemp.Columns.Add("branchname");
                DataRow dr = dtTemp.NewRow();
                for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
                {
                    dr = dtTemp.NewRow();
                    dtTemp.Rows.Add(dr);

                    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtsal.Rows[i]["Employeeid"].ToString();
                    eid = Convert.ToInt32(dtsal.Rows[i]["Employeeid"].ToString());
                    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = dtsal.Rows[i]["empcode"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][2] = dtsal.Rows[i]["empname"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][3] = dtsal.Rows[i]["gross"].ToString();
                    //dtTemp.Rows[dtTemp.Rows.Count - 1][4] = 
                    //  DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("pgrade");
                    dtTemp.Rows[dtTemp.Rows.Count - 1][4] = dtsal.Rows[i]["grade"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][7] = dtsal.Rows[i]["divsname"].ToString();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][8] = dtsal.Rows[i]["portname"].ToString();

                }
                grd.DataSource = dtTemp;
                grd.DataBind();

                for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
                {
                    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtsal.Rows[i]["Employeeid"].ToString();
                    eid = Convert.ToInt32(dtsal.Rows[i]["Employeeid"].ToString());
                    dtIncAmt = objSalRev.GetIncentiveAmt(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)));

                    if (dtIncAmt.Rows.Count > 0)
                    {

                        if (string.IsNullOrEmpty(dtIncAmt.Rows[0][0].ToString()))
                        {
                            // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = "";
                            ((TextBox)grd.Rows[i].Cells[6].FindControl("txtIncrement")).Text = "";
                        }
                        else
                        {
                            temp = Convert.ToDouble(dtIncAmt.Rows[0][0].ToString());
                            // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = temp.ToString("#,0.00");
                            ((TextBox)grd.Rows[i].Cells[6].FindControl("txtIncrement")).Text = temp.ToString("#,0.00");
                        }
                    }
                    else
                    {
                        // dtTemp.Rows[dtTemp.Rows.Count - 1][6] = "";
                        ((TextBox)grd.Rows[i].FindControl("txtIncrement")).Text = "";
                    }
                }
                for (int i = 0; i <= dtsal.Rows.Count - 1; i++)
                {
                    Pgrade = dtsal.Rows[i]["grade"].ToString();
                    if (Pgrade != "")
                    {
                        ((DropDownList)grd.Rows[i].FindControl("pgrade")).SelectedItem.Text = Pgrade;
                    }
                    else
                    {
                        ((DropDownList)grd.Rows[i].FindControl("pgrade")).SelectedIndex = 0;
                    }
                }

                Dt = objSalRev.SelSalrev4chk();
                if (Dt.Rows.Count > 0)
                {
                    DateTime from = Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text));
                    //string date1 = from.ToShortDateString();
                    DateTime to = Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text));
                    // string date2 = to.ToShortDateString();
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        DateTime Newdate = Convert.ToDateTime(Utility.fn_ConvertDate(Dt.Rows[i]["validfrom"].ToString()));
                        DateTime Newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(Dt.Rows[i]["validto"].ToString()));
                        if (from == Newdate && to == Newdate1)
                        {
                         //   btnSave.Text = "Update";

                            btnSave.ToolTip = "Update";
                            btnSave1.Attributes["class"] = "btn btn-update1";
                            txtfrom.Enabled = false;
                            txtTo.Enabled = false;
                            return;
                        }
                        else
                        {
                           // btnSave.Text = "Save";
                            btnSave.ToolTip = "Save";
                            btnSave1.Attributes["class"] = "btn ico-save";
                        }
                    }
                }

                //grd.DataSource = dtTemp;
                //grd.DataBind();
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            Fill_grid();
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            Fill_grid();
        }

        //protected void txtCompany_TextChanged(object sender, EventArgs e)
        //{
        //    EmptyDataGrid();
        //    Fill_grid();
        //}

        //protected void txtBranch_TextChanged(object sender, EventArgs e)
        //{
        //    EmptyDataGrid();
        //    Fill_grid();
        //}

        //protected void txtGrade_TextChanged(object sender, EventArgs e)
        //{
        //    EmptyDataGrid();
        //    Fill_grid();
        //}

        protected void valid()
        {
            try
            {
                vFrom = Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text));
                vTo = Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text));
                Dt = objSalRev.SelSalrev4chk();
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        vf = Convert.ToDateTime(Dt.Rows[i]["validfrom"]);
                        vt = Convert.ToDateTime(Dt.Rows[i]["validto"]);

                        if (((vFrom >= vf && vFrom <= vt) || (vTo >= vf && vTo <= vt) || (vf >= vFrom && vf <= vTo) || (vt >= vFrom && vt <= vTo)))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void getmonth()
        {
            DateTime log = Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)); 
            frm = log.Month;
            // todat = Convert.ToInt32(log.Month.ToString(Utility.fn_ConvertDate(txtTo.Text)));
            DateTime log1 = Convert.ToDateTime( Utility.fn_ConvertDate( txtTo.Text));
            todat = log1.Month;
            int year = Convert.ToInt32(log.Year);
            // Convert.ToInt32(year.ToString((txtfrom.Text)));
            fryr = Convert.ToInt32(log.Year);
            toyr = Convert.ToInt32(log1.Year);
            fixfrm = 4;
            fixto = 3;
            lfrmyr = Convert.ToInt32(log.Year);
            ltoyr = Convert.ToInt32(log.Year) + 1;
            diff = toyr - fryr;
        }

        protected void InsPack()
        {
            dtgross = objSalRev.SelSal4gross(Convert.ToDateTime( Utility.fn_ConvertDate( txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)));
            for (int i = 0; i <= dtgross.Rows.Count - 1; i++)
            {
                code = dtgross.Rows[i]["empcode"].ToString();
                basic = Convert.ToDouble(dtgross.Rows[i]["Basic"].ToString());
                hra = Convert.ToDouble(dtgross.Rows[i]["HRA"].ToString());
                sall = Convert.ToDouble(dtgross.Rows[i]["sallowence"].ToString());
                lall = Convert.ToDouble(dtgross.Rows[i]["lallowence"].ToString());
                con = Convert.ToDouble(dtgross.Rows[i]["conv"].ToString());
                other = Convert.ToDouble(dtgross.Rows[i]["others"].ToString());
                sfrom = Convert.ToDateTime(Utility.fn_ConvertDate(dtgross.Rows[i]["salfrom"].ToString()));
                sto = Convert.ToDateTime(Utility.fn_ConvertDate( dtgross.Rows[i]["salto"].ToString()));
                loyal = Convert.ToDouble(dtgross.Rows[i]["loyal"].ToString());
                ea = Convert.ToDouble(dtgross.Rows[i]["ea"].ToString());
                drive = Convert.ToDouble(dtgross.Rows[i]["driverall"].ToString());
                medical = Convert.ToDouble(dtgross.Rows[i]["medical"].ToString());

                pf = (basic * 12) / 100;
                if (basic < 10000)
                {
                    esi = (basic * 3.5) / 100;
                }
                else
                {
                    esi = 0;
                }
                lta = basic;
                bonus = 0;

                if (btnSave.ToolTip == "Save")
                {
                    PIObj.InsEmpSalary(code, basic, hra, sall, lall, con, other, sfrom, sto, loyal, ea, drive, medical);
                    PIObj.UpdArrear(code, sfrom, sfrom, 1);
                    PIObj.InsEmpAnualCompensation(code, lta, medical, bonus, 0, sfrom, sto);
                    PIObj.InsEmpContribution(code, esi, pf, sfrom, sto);
                    PIObj.InsEmpAllowances(code, 0, 0, 0, 0, 0, sfrom, sto, 0, 0, 0, 0);
                }

                else
                {
                    objSalRev.UpdEmpSalary4Inc(code, basic, hra, sall, lall, con, other, sfrom, sto, loyal, ea, drive, medical);
                    PIObj.UpdEmpAnualCompensation(code, lta, medical, bonus, 0, sfrom, sto);
                    PIObj.UpdEmpContribution(code, esi, pf, sfrom, sto);
                    PIObj.UpdEmpAllowances(code, 0, 0, 0, 0, 0, sfrom, sto, 0, 0, 0, 0);
                }
            }

        }

        protected void Clear()
        {
            cregrd();
            EmptyDataGrid();
            txtCompany.Text = "";
            txtBranch.Text = "";
            txtGrade.Text = "";
            //btnSave.Text = "Save";
            btnSave.ToolTip = "Save";
            btnSave1.Attributes["class"] = "btn ico-save";
            txtfrom.Enabled = true;
            txtTo.Enabled = true;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.ToolTip == "Cancel")
            {
                Clear();
               // btnCancel.Text = "Back";

                btnCancel.ToolTip = "Back";
                btnCancel1.Attributes["class"] = "btn ico-back";

                txtCompany.Focus(); 
            }
            else
            {
                this.Response.End();
            }

        }
        protected void btn_yes_Click(object sender, EventArgs e)
        {
            if (btnSave.ToolTip == "Save")
            {
                valid();
                if (flag == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Same Details Already Found.Not Able to Inserted');", true);
                    Clear();
                }

                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    eid = Convert.ToInt32(grd.Rows[i].Cells[0].Text);
                    objSalRev.DelSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)));
                    DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("pgrade");
                     TextBox txt = (TextBox)grd.Rows[i].FindControl("txtIncrement");
                    if (txt.Text != "")
                    {
                        objSalRev.InsSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)), ddl.Text, Convert.ToDecimal (txt.Text));
                    }
                }
                InsPack();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Saved');", true);
                Clear();
            }
            else
            {
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    eid = Convert.ToInt32(grd.Rows[i].Cells[0].Text);
                    objSalRev.DelSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)));
                     DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("pgrade");
                                TextBox txt = (TextBox)grd.Rows[i].FindControl("txtIncrement");
                                if (txt.Text != "")
                    {
                        objSalRev.InsSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)), ddl.Text, Convert.ToDecimal (txt.Text));
                    }
                }
                InsPack();
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Updated');", true);
                txtfrom.Enabled = true;
                txtTo.Enabled = true;
                Clear();
            }
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(Utility.fn_ConvertDate( txtfrom.Text)) < Convert.ToDateTime(Utility.fn_ConvertDate( txtTo.Text)))
            {

                flag = false;
                getmonth();
                if (diff == 1)
                {
                    if ((frm == fixfrm) && (todat == fixto))
                    {
                        if (btnSave.ToolTip == "Save")
                        {
                            valid();
                            if (flag == true)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Same Details Already Found.Not Able to Inserted');", true);
                                Clear();
                            }

                            for (int i = 0; i <= grd.Rows.Count - 1; i++)
                            {
                                eid = Convert.ToInt32(grd.Rows[i].Cells[0].Text);
                                objSalRev.DelSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)));
                                DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("pgrade");
                                TextBox txt = (TextBox)grd.Rows[i].FindControl("txtIncrement");
                                if (txt.Text != "")
                                {
                                    objSalRev.InsSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)), ddl.Text, Convert.ToDecimal(txt.Text));
                                }
                            }
                            InsPack();
                            logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 973, 1, int.Parse(Session["LoginBranchid"].ToString()), eid + "/S");
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Saved');", true);
                            Clear();
                        }

                        else
                        {
                            for (int i = 0; i <= grd.Rows.Count - 1; i++)
                            {
                                eid = Convert.ToInt32(grd.Rows[i].Cells[0].Text);
                                objSalRev.DelSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)));
                                DropDownList ddl = (DropDownList)grd.Rows[i].FindControl("pgrade");
                                TextBox txt = (TextBox)grd.Rows[i].FindControl("txtIncrement");
                                if (txt.Text != "")
                                {
                                    objSalRev.InsSalRevDtls(eid, Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)), ddl.Text, Convert.ToDecimal(txt.Text));
                                }
                            }
                            InsPack();
                            logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 973, 2, int.Parse(Session["LoginBranchid"].ToString()), eid + "/U");
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Updated');", true);
                            txtfrom.Enabled = true;
                            txtTo.Enabled = true;
                            Clear();
                        }
                    }
                    else
                    {
                        this.PopUpService.Show();
                    }
                }
                else if (diff == 0)
                {
                    this.PopUpService.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert(Date Difference should be Maximum one year');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert(To Date Must be Greater Than From Date');", true);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            DateTime log = Convert.ToDateTime(Utility.fn_ConvertDate(txtfrom.Text));
            DateTime log1= Convert.ToDateTime(Utility.fn_ConvertDate(txtTo.Text)); 
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Str_RptName = "Payroll" + "//rptHRSalrivision.rpt";

            Str_sp = "Frm=" + txtfrom.Text + "~to=" + txtTo.Text;
            Session["str_sfs"] = " {HRSalaryRevision.salfrom}>=date('" + log.Year + "," + log.Month + "," + log.Day + "') and {HRSalaryRevision.salto}<=date('" + log1.Year + "," + log1.Month + "," + log1.Day + "')";
          
               
          
            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            logobj.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 973, 3, int.Parse(Session["LoginBranchid"].ToString()),"View");
            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "HRM", Str_Script, true);
            //Session["str_sfs"] = Str_sf;
            Session["str_sp"] = Str_sp;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
          
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
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



                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void logdetails_Click(object sender, EventArgs e)
        {
            try
            {
                loadgridlog();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel1.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 973, "Job", "", "", Session["StrTranType"].ToString());

            //if (txt_jobno.Text != "")
            //{
            //    JobInput.Text = txt_jobno.Text;
            //}

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


    }
}