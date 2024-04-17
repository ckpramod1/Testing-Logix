using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace logix.HRM
{
    public partial class CTC : System.Web.UI.Page
    {
        DataAccess.Payroll.CTC obj_da_CTC = new DataAccess.Payroll.CTC();
        public static int int_Divisionid, int_Branchid, int_Deptid, int_Empid;
        public static DateTime dt;
        int intDiv, intBranch, intDept;
        DataTable dtDivsn = new DataTable();
        DataTable dtBranch = new DataTable();
        DataTable dtEmp = new DataTable();
        DateTime fromdate;
        DateTime toDate;
        DateTime dtdate;
        DataTable dtDept = new DataTable();
        string strVal;
        string strDiv, strBranch, strDept, strGet;
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

        protected void Page_Load(object sender, EventArgs e)
        {
            //strVal = "Tr";
            //strGet = "Get";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            try { 
            if (!IsPostBack)
            {
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "ddl_Monrh~txt_year~txt_year";
                str_MsgLists = "Month~Year~Year";
                str_DataType = "DropDown~String~Integer";
                btn_Month.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                btn_Earned.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                
                txt_year.Text = obj_da_Log.GetDate().Year.ToString();
                ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()).Selected = true;
                txtFromdate.Enabled = true;
                txtToDate.Enabled = true;
                ddlMonthYarn.Enabled = true;
                ddl_Monrh.Enabled = true;
                txt_year.Enabled = true;
                btn_Month.Enabled = true;
                btn_Earned.Enabled = true;
                btnGet.Enabled = true;
                Fn_ClearGrd();
                hid_from.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                hid_to.Value=Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                txtFromdate.Text = hid_from.Value;
                txtToDate.Text = hid_to.Value;
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void btn_Month_Click(object sender, EventArgs e)
        {
            try
            {
                txtFromdate.Enabled = false;
                txtToDate.Enabled = false;
                ddlMonthYarn.Enabled = false;
                ddl_Monrh.Enabled = true;
                txt_year.Enabled = true;
                btn_Month.Enabled = true;
                btn_Earned.Enabled = true;
                btnGet.Enabled = false;
                intDiv = 0;
                intBranch = 0;
                intDept = 0;
                Fn_ClearGrd();
                strGet = "Month";
                hid_strGet.Value = strGet;
                lbl_company.Text = "Company Wise - Month";
                dtdate = Convert.ToDateTime((ddl_Monrh.SelectedIndex).ToString() + "/1/" + txt_year.Text);
                dtdate = dtdate.AddMonths(1).AddDays(-1);
                hid_date.Value = dtdate.ToString();
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
                toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
                dtDivsn = obj_da_CTC.GetCTCDtls("DIV", intDiv, intBranch, intDept, dtdate);


                if (dtDivsn.Rows.Count > 0)
                {
                    getDetails();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Earned, typeof(Button), "HRM", "alertify.alert('Payroll not Generated for this Month');", true);
                    return;
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void btn_Earned_Click(object sender, EventArgs e)
        {
            try { 
            txtFromdate.Enabled = false;
            txtToDate.Enabled = false;
            ddlMonthYarn.Enabled = false;
            ddl_Monrh.Enabled = true;
            txt_year.Enabled = true;
            btn_Month.Enabled = true;
            btn_Earned.Enabled = true;
            btnGet.Enabled = false;

            intDiv = 0;
            intBranch = 0;
            intDept = 0;
            Fn_ClearGrd(); 
            strGet = "Earn";
            hid_strGet.Value = strGet;

            lbl_company.Text = "Company Wise - Earned";
             dtdate = Convert.ToDateTime((ddl_Monrh.SelectedIndex  ).ToString() + "/1/" + txt_year.Text);
             dtdate = dtdate.AddMonths(1).AddDays(-1);
             hid_date.Value = dtdate.ToString();
            fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
            toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
            dtDivsn = obj_da_CTC.GetCTCDtls4earn("DIV", intDiv, intBranch, intDept, dtdate);
            

            if (dtDivsn.Rows.Count > 0)
            {
                getDetails();
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Earned, typeof(Button), "HRM", "alertify.alert('Payroll not Generated for this Month');", true);
            }
            //Fn_ClearGrd();
            //hid.Value = "Earned";
            //dt = DateTime.Parse(ddl_Monrh.SelectedValue.ToString() + "/01/" + txt_year.Text);
            //dt.AddMonths(1).AddDays(-1);
            //Fn_GetId();
            //DataTable obj_dt = new DataTable();
            //obj_dt = obj_da_CTC.GetCTCDtls4earn("DIV", int_Divisionid, int_Branchid, int_Deptid, dt);
            //obj_dt.Columns.Add("ctcannum", typeof(string));
            //foreach (DataRow dr in obj_dt.Rows)
            //{
            //    dr["ctcannum"] = string.Format("{0:0.00}", (double.Parse(dr["ctcmonth"].ToString()) * 12));
            //    dr["ctcmonth"] = string.Format("{0:0.00}", dr["ctcmonth"]);
            //}
            //if (obj_dt.Rows.Count > 0)
            //{
            //    Grd_Company.DataSource = obj_dt;
            //    Grd_Company.DataBind();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(btn_Earned, typeof(Button), "HRM", "alertify.alert('Payroll not Generated for this Month');", true);
            //}
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }
        private void Fn_GetId()
        {
            try
            {
            int_Divisionid = hid_divid.Value.ToString().Length == 0 ? 0 : int.Parse(hid_divid.Value.ToString());
            int_Branchid = hid_bid.Value.ToString().Length == 0 ? 0 : int.Parse(hid_bid.Value.ToString());
            int_Deptid = hid_deptid.Value.ToString().Length == 0 ? 0 : int.Parse(hid_deptid.Value.ToString());
            int_Empid = hid_empid.Value.ToString().Length == 0 ? 0 : int.Parse(hid_empid.Value.ToString());
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void Grd_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
            toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
            int index = Grd_Company.SelectedRow.RowIndex;
            if (Grd_Company.Rows.Count > 0)
            {
                lbl_department.Text = "Department Wise";
                lbl_employee.Text = "Employee Wise";
                intDiv = Convert.ToInt32(Grd_Company.DataKeys[index]["divisionid"]);
                hid_divid.Value = intDiv.ToString();
                for (int i = 0; i <= Grd_Department.Rows.Count - 1; i++)
                {
                    Grd_Department.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Department.DataBind();
                }

                for (int i = 0; i <= Grd_Employee.Rows.Count - 1; i++)
                {
                    Grd_Employee.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Employee.DataBind();
                }

                for (int i = 0; i <= Grd_branch.Rows.Count - 1; i++)
                {
                    Grd_branch.DataSource = Utility.Fn_GetEmptyDataTable();
                    
                    Grd_branch.DataBind();
                }

                if (hid_strGet.Value == "Month")
                {
                    dtBranch = obj_da_CTC.GetCTCDtls("BRANCH", intDiv, intBranch, intDept, Convert.ToDateTime((hid_date.Value)));
                }
                else if (hid_strGet.Value == "Earn")
                {
                    dtBranch = obj_da_CTC.GetCTCDtls4earn("BRANCH", intDiv, intBranch, intDept, Convert.ToDateTime((hid_date.Value)));
                }

                else if (hid_strGet.Value == "Get" && ddlMonthYarn.Text == "Month")
                {
                    dtBranch = obj_da_CTC.GetCTCDtls4FromTo("BRANCH", intDiv, intBranch, intDept, fromdate, toDate);
                }
                else if (hid_strGet.Value == "Get" && ddlMonthYarn.Text == "Earned")
                {
                    fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
                    toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
                    dtBranch = obj_da_CTC.GetCTCDtls4earnFromTo("BRANCH", intDiv, intBranch, intDept, fromdate, toDate);
                }

                if (dtBranch.Rows.Count > 0)
                {
                   
                    strDiv = Grd_Company.Rows[index].Cells[0].Text.ToString();
                    hid_strdiv.Value = strDiv;
                    lbl_branch.Text = strDiv;
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("branchid");
                    dtTemp.Columns.Add("portname");
                    dtTemp.Columns.Add("noofemp");
                    dtTemp.Columns.Add("ctcmonth");
                    dtTemp.Columns.Add("ctcannum");
                    DataRow dr = dtTemp.NewRow();
                    double ctc, ctcann;
                    for (int i = 0; i <= dtBranch.Rows.Count - 1; i++)
                    {
                        dr = dtTemp.NewRow();
                        dtTemp.Rows.Add(dr);

                        dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtBranch.Rows[i]["portid"].ToString();
                        dtTemp.Rows[dtTemp.Rows.Count - 1][1] = dtBranch.Rows[i]["portname"].ToString().Trim();
                        dtTemp.Rows[dtTemp.Rows.Count - 1][2] = dtBranch.Rows[i]["noofemp"].ToString();
                        ctc = Convert.ToDouble(dtBranch.Rows[i]["ctcmonth"].ToString());
                        dtTemp.Rows[dtTemp.Rows.Count - 1][3] = ctc.ToString("0.00");
                        ctcann = Convert.ToDouble(dtBranch.Rows[i]["ctcmonth"].ToString()) * 12;
                        dtTemp.Rows[dtTemp.Rows.Count - 1][4] = ctcann.ToString("0.00"); ;
                    }
                    Grd_branch.DataSource = dtTemp;
                    Grd_branch.DataBind();
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel"; 
                    btn_cancel2.Attributes["class"] = "btn ico-cancel";
                }
            }



            //lbl_branch.Text = Grd_Company.SelectedDataKey.Values[1].ToString();
            //hid_divid.Value = Grd_Company.SelectedDataKey.Values[0].ToString();

            //Fn_GetId();
            //DataTable obj_dt = new DataTable();
            //if (hid.Value.ToString() == "Month")
            //{
            //    obj_dt = obj_da_CTC.GetCTCDtls("BRANCH", int_Divisionid, int_Branchid, int_Deptid, dt);
            //}
            //else if (hid.Value.ToString() == "Earned")
            //{
            //    obj_dt = obj_da_CTC.GetCTCDtls4earn("BRANCH", int_Divisionid, int_Branchid, int_Deptid, dt);
            //}
            //obj_dt.Columns.Add("ctcannum", typeof(string));
            //foreach (DataRow dr in obj_dt.Rows)
            //{
            //    dr["ctcannum"] = string.Format("{0:0.00}", (double.Parse(dr["ctcmonth"].ToString()) * 12));
            //    dr["ctcmonth"] = string.Format("{0:0.00}", dr["ctcmonth"]);
            //}
            //Grd_branch.DataSource = obj_dt;
            //Grd_branch.DataBind();
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void Grd_branch_SelectedIndexChanged(object sender, EventArgs e)
        {

            try { 
            fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
            toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
            int index = Grd_branch.SelectedRow.RowIndex;
            if (Grd_branch.Rows.Count > 0)
            {
                lbl_department.Text = "Department Wise";
               // lbl_employee.Text = "Employee Wise";
                intBranch = Convert.ToInt32(Grd_branch.DataKeys[index]["branchid"]);
                hid_bid.Value = intBranch.ToString();
                for (int i = 0; i <= Grd_Department.Rows.Count - 1; i++)
                {
                    Grd_Department.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Department.DataBind();
                }

                for (int i = 0; i <= Grd_Employee.Rows.Count - 1; i++)
                {
                    Grd_Employee.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Employee.DataBind();
                }



                if (hid_strGet.Value == "Month")
                {
                    dtDept = obj_da_CTC.GetCTCDtls("DEPT", Convert.ToInt32(hid_divid.Value), intBranch, intDept, Convert.ToDateTime((hid_date.Value)));
                }
                else if (hid_strGet.Value == "Earn")
                {
                    dtDept = obj_da_CTC.GetCTCDtls4earn("DEPT", Convert.ToInt32(hid_divid.Value), intBranch, intDept, Convert.ToDateTime((hid_date.Value)));
                }

                else if (hid_strGet.Value == "Get" && ddlMonthYarn.Text == "Month")
                {
                    // dtDept = obj_da_CTC.GetCTCDtls4FromTo("DEPT", intDiv, intBranch, intDept, fromdate, toDate);
                    dtDept = obj_da_CTC.GetCTCDtls4FromTo("DEPT", Convert.ToInt32(hid_divid.Value), intBranch, intDept, fromdate, toDate);
                }
                else if (hid_strGet.Value == "Get" && ddlMonthYarn.Text == "Earned")
                {
                    fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
                    toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
                    dtDept = obj_da_CTC.GetCTCDtls4earnFromTo("DEPT", Convert.ToInt32(hid_divid.Value), intBranch, intDept, fromdate, toDate);
                }

                if (dtDept.Rows.Count > 0)
                {
                    strBranch = Grd_branch.SelectedRow.Cells[0].Text.ToString();
                    hid_branch.Value = strBranch;
                    lbl_department.Text = hid_strdiv.Value + "," + strBranch;
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("deptid");
                    dtTemp.Columns.Add("deptname");
                    dtTemp.Columns.Add("noofemp");
                    dtTemp.Columns.Add("ctcmonth");
                    dtTemp.Columns.Add("ctcannum");
                    DataRow dr = dtTemp.NewRow();
                    double ctc, ctcann;
                    for (int i = 0; i <= dtDept.Rows.Count - 1; i++)
                    {
                        dr = dtTemp.NewRow();
                        dtTemp.Rows.Add(dr);

                        dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtDept.Rows[i]["deptid"].ToString();
                        dtTemp.Rows[dtTemp.Rows.Count - 1][1] = dtDept.Rows[i]["deptname"].ToString().Trim();
                        dtTemp.Rows[dtTemp.Rows.Count - 1][2] = dtDept.Rows[i]["noofemp"].ToString();
                        ctc = Convert.ToDouble(dtDept.Rows[i]["ctcmonth"].ToString());
                        dtTemp.Rows[dtTemp.Rows.Count - 1][3] = ctc.ToString("0.00");
                        ctcann = Convert.ToDouble(dtDept.Rows[i]["ctcmonth"].ToString()) * 12;
                        dtTemp.Rows[dtTemp.Rows.Count - 1][4] = ctcann.ToString("0.00"); ;
                    }
                    Grd_Department.DataSource = dtTemp;
                    Grd_Department.DataBind();
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel2.Attributes["class"] = "btn ico-cancel";
                }
            }

            //lbl_department.Text = lbl_branch.Text + "," + Grd_branch.SelectedDataKey.Values[1].ToString();
            //hid_bid.Value = Grd_branch.SelectedDataKey.Values[0].ToString();

            //Fn_GetId();
            //DataTable obj_dt = new DataTable();
            //if (hid.Value.ToString() == "Month")
            //{
            //    obj_dt = obj_da_CTC.GetCTCDtls("DEPT", int_Divisionid, int_Branchid, int_Deptid, dt);
            //}
            //else if (hid.Value.ToString() == "Earned")
            //{
            //    obj_dt = obj_da_CTC.GetCTCDtls4earn("DEPT", int_Divisionid, int_Branchid, int_Deptid, dt);
            //}
            //obj_dt.Columns.Add("ctcannum", typeof(string));
            //foreach (DataRow dr in obj_dt.Rows)
            //{
            //    dr["ctcannum"] = string.Format("{0:0.00}", (double.Parse(dr["ctcmonth"].ToString()) * 12));
            //    dr["ctcmonth"] = string.Format("{0:0.00}", dr["ctcmonth"]);
            //}
            //Grd_Department.DataSource = obj_dt;
            //Grd_Department.DataBind();
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void Grd_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
            toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
            int index = Grd_Department.SelectedRow.RowIndex;
            if (Grd_Department.Rows.Count > 0)
            {
                intDept = Convert.ToInt32(Grd_Department.DataKeys[index]["deptid"]);

                for (int i = 0; i <= Grd_Employee.Rows.Count - 1; i++)
                {
                    Grd_Employee.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Employee.DataBind();
                }



                if (hid_strGet.Value == "Month")
                {
                    dtEmp = obj_da_CTC.GetCTCDtls("EMP", Convert.ToInt32(hid_divid.Value), Convert.ToInt32(hid_bid.Value), intDept, Convert.ToDateTime((hid_date.Value)));
                }
                else if (hid_strGet.Value == "Earn")
                {
                    dtEmp = obj_da_CTC.GetCTCDtls4earn("EMP", Convert.ToInt32(hid_divid.Value), Convert.ToInt32(hid_bid.Value), intDept, Convert.ToDateTime((hid_date.Value)));
                }

                else if (hid_strGet.Value == "Get" && ddlMonthYarn.Text == "Month")
                {
                    // dtDept = obj_da_CTC.GetCTCDtls4FromTo("DEPT", intDiv, intBranch, intDept, fromdate, toDate);
                    dtEmp = obj_da_CTC.GetCTCDtls4FromTo("EMP", Convert.ToInt32(hid_divid.Value), Convert.ToInt32(hid_bid.Value), intDept, fromdate, toDate);
                }
                else if (hid_strGet.Value == "Get" && ddlMonthYarn.Text == "Earned")
                {
                    fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
                    toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
                    dtEmp = obj_da_CTC.GetCTCDtls4earnFromTo("EMP", Convert.ToInt32(hid_divid.Value), Convert.ToInt32(hid_bid.Value), intDept, fromdate, toDate);
                }

                if (dtEmp.Rows.Count > 0)
                {
                    strDept = Grd_Department.SelectedRow.Cells[0].Text.ToString();
                    strDiv = hid_strdiv.Value;
                    strBranch = hid_branch.Value;
                    lbl_employee.Text = (hid_strdiv.Value.Trim()) + " , " + (hid_branch.Value.Trim()) + " , " + (strDept.Trim());
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("empname");
                    dtTemp.Columns.Add("ctcmonth");
                    dtTemp.Columns.Add("ctcannum");

                    DataRow dr = dtTemp.NewRow();
                    double ctc, ctcann;
                    for (int i = 0; i <= dtEmp.Rows.Count - 1; i++)
                    {
                        dr = dtTemp.NewRow();
                        dtTemp.Rows.Add(dr);


                        dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtEmp.Rows[i]["empname"].ToString();
                        ctc = Convert.ToDouble(dtEmp.Rows[i]["ctcmonth"].ToString());
                        dtTemp.Rows[dtTemp.Rows.Count - 1][1] = ctc.ToString("0.00");
                        ctcann = Convert.ToDouble(dtEmp.Rows[i]["ctcmonth"].ToString()) * 12;
                        dtTemp.Rows[dtTemp.Rows.Count - 1][2] = ctcann.ToString("0.00"); ;
                    }
                    Grd_Employee.DataSource = dtTemp;
                    Grd_Employee.DataBind();
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel2.Attributes["class"] = "btn ico-cancel";
                }

                //lbl_employee.Text = lbl_department.Text + "," + Grd_Department.SelectedDataKey.Values[1].ToString();
                //hid_deptid.Value = Grd_Department.SelectedDataKey.Values[0].ToString();

                //Fn_GetId();
                //DataTable obj_dt = new DataTable();
                //if (hid.Value.ToString() == "Month")
                //{
                //    obj_dt = obj_da_CTC.GetCTCDtls("EMP", int_Divisionid, int_Branchid, int_Deptid, dt);
                //}
                //else if (hid.Value.ToString() == "Earned")
                //{
                //    obj_dt = obj_da_CTC.GetCTCDtls4earn("EMP", int_Divisionid, int_Branchid, int_Deptid, dt);
                //}
                //obj_dt.Columns.Add("ctcannum", typeof(string));
                //foreach (DataRow dr in obj_dt.Rows)
                //{
                //    dr["ctcannum"] = string.Format("{0:0.00}", (double.Parse(dr["ctcmonth"].ToString()) * 12));
                //    dr["ctcmonth"] = string.Format("{0:0.00}", dr["ctcmonth"]);
                //}
                //Grd_Employee.DataSource = obj_dt;
                //Grd_Employee.DataBind();
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }
        private void Fn_ClearGrd()
        {
            Grd_branch.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_branch.DataBind();
            Grd_Employee.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Employee.DataBind();
            Grd_Company.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Company.DataBind();
            Grd_Department.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Department.DataBind();
             lbl_company.Text = "Company Wise";
            lbl_department.Text = "Department Wise";
            lbl_branch.Text = "Branch Wise";
            lbl_employee.Text = "Employee Wise";

            //Fn_ClearGrd();
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            txt_year.Text = obj_da_Log.GetDate().Year.ToString();
            //ddl_Monrh.SelectedIndex = 0;
        }
        

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if(btn_cancel.ToolTip=="Cancel")
            {

            Fn_ClearGrd();
            txtFromdate.Enabled = true;
            txtToDate.Enabled = true;
            ddlMonthYarn.Enabled = true;
            ddl_Monrh.Enabled = true;
            txt_year.Enabled = true;
            btn_Month.Enabled = true;
            ddlMonthYarn.SelectedIndex = 0;
            btn_Earned.Enabled = true;
            btnGet.Enabled = true;
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel2.Attributes["class"] = "btn ico-back";
            txtFromdate.Text = hid_from.Value;
            txtToDate.Text = hid_to.Value;
          
            }
            else 
            {
                this.Response.End();
            }
        }


        protected void getDetails()
        {
            try
            {
            //Grd_Company
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("divisionid");
            dtTemp.Columns.Add("divisionname");
            dtTemp.Columns.Add("noofemp");
            dtTemp.Columns.Add("ctcmonth");
            dtTemp.Columns.Add("ctcannum");
            DataRow dr = dtTemp.NewRow();
            double ctc, ctcann;
            for (int i = 0; i <= dtDivsn.Rows.Count - 1; i++)
            {
                dr = dtTemp.NewRow();
                dtTemp.Rows.Add(dr);

                dtTemp.Rows[dtTemp.Rows.Count - 1][0] = dtDivsn.Rows[i]["divisionid"].ToString();
                dtTemp.Rows[dtTemp.Rows.Count - 1][1] = dtDivsn.Rows[i]["divisionname"].ToString().Trim();
                dtTemp.Rows[dtTemp.Rows.Count - 1][2] = dtDivsn.Rows[i]["noofemp"].ToString();
                ctc = Convert.ToDouble(dtDivsn.Rows[i]["ctcmonth"].ToString());
                dtTemp.Rows[dtTemp.Rows.Count - 1][3] = ctc.ToString("0.00");
                ctcann = Convert.ToDouble(dtDivsn.Rows[i]["ctcmonth"].ToString()) * 12;
                dtTemp.Rows[dtTemp.Rows.Count - 1][4] = ctcann.ToString("0.00"); ;
            }
            Grd_Company.DataSource = dtTemp;
            Grd_Company.DataBind();

            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }
        protected void btnGet_Click(object sender, EventArgs e)
        {
            try { 
            txtFromdate.Enabled = true;
            txtToDate.Enabled = true;
            ddlMonthYarn.Enabled = true;
            ddl_Monrh.Enabled = false;
            txt_year.Enabled = false;
            btn_Month.Enabled = false;
            btn_Earned.Enabled = false;
            btnGet.Enabled = true;

            intDiv = 0;
            intBranch = 0;
            intDept = 0;
            Fn_ClearGrd(); 
            strVal = "Tr";
            strGet = "Get";
            hid_strGet.Value = strGet;

            lbl_company.Text = "Company Wise - From " + txtFromdate.Text + " To " + txtToDate.Text;

            fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
            toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));

            if (ddlMonthYarn.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_Earned, typeof(Button), "HRM", "alertify.alert('Select Month or Earned');", true);
                ddlMonthYarn.Focus();
                return;
            }

            else if (ddlMonthYarn.Text == "Month")
            {
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
                toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
                dtDivsn = obj_da_CTC.GetCTCDtls4FromTo("DIV", intDiv, intBranch, intDept, fromdate, toDate);
            }

            else if (ddlMonthYarn.Text == "Earned")
            {
                fromdate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtFromdate.Text));
                toDate = Convert.ToDateTime(Utility.fn_ConvertDateWithTime(txtToDate.Text));
                dtDivsn = obj_da_CTC.GetCTCDtls4earnFromTo("DIV", intDiv, intBranch, intDept, fromdate, toDate);
            }

            if (dtDivsn.Rows.Count > 0)
            {
                getDetails();
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1071, 3, Convert.ToInt32(Session["LoginBranchid"]), "View");
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Earned, typeof(Button), "HRM", "alertify.alert('Payroll not Generated for this Month');", true);
                return;
            }
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }          
        }

        protected void Grd_Company_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Company, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
          
        }

        protected void Grd_branch_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_branch, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
           
        }

        protected void Grd_Department_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Department, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            

        }

        protected void Grd_Employee_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Employee, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1071, "Job", "", "", Session["StrTranType"].ToString());

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