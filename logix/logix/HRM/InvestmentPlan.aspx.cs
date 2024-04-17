using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.IO;

namespace logix.HRM
{
    public partial class InvestmentPlan : System.Web.UI.Page
    {
        public static double BASIC = 0, RentPaid = 0, RP = 0, ARP = 0;
        int fyear, eid, curyear, curmonth, getmonth, Emp_ID;
        double basicamt;
        DateTime DtForm, DtTo, dtdate;
        DataTable obj_dt = new DataTable();
        DataRow foundrow;
        string itype = "";
        bool err;

        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Payroll.Details obj_da_detail = new DataAccess.Payroll.Details();
        DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        DataAccess.PayrollProcess obj_da_PayRoll = new DataAccess.PayrollProcess();
        DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();
        DataAccess.Payroll.ITComputation obj_it = new DataAccess.Payroll.ITComputation();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            //Emp_ID = Convert.ToInt32(Session["LoginEmpId"].ToString());

            if (!IsPostBack)
            {
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "txt_Empcode~ddl_Year~ddl_Section~ddl_plan~txt_Amount";
                str_MsgLists = "EmpCode~Financial Year~Section~Investment Plan~Amount";
                str_DataType = "String~DropDown~DropDown~DropDown~Double";
                btn_Save.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "');");
                txt_Amount.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Amount');");
                txt_ActualRent.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_ActualRent');");
                txt_Income.Attributes.Add("OnKeyUp", "return IsDoubleCheck('txt_Income');");
                txt_ActualRent.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'preincome')");
                txt_RentExp.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'tax')");
                txt_HRA.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'otherincome')");
                txt_Basic50.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'amount')");
                txt_RentPaid.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'amount')");
                txt_Income.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'amount')");

                Fn_LoadDYear();
                Fn_Loadplan();
                ddl_Year.Enabled = false;
                Grd.DataSource = new DataTable();
                Grd.DataBind();
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                txt_Empcode.Focus();
                lbl_AvailableLimit.Text = "";
                lbl_MaxLimit.Text = "";
                Session["InvestmentPlan"] = lbl_Header.Text;

                if (itype == "HR" || itype == "")
                {
                    txt_Empcode.ReadOnly = false;
                    fyear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));
                    hid_year.Value = fyear.ToString();
                    lnk_section.Visible = false;
                    lbl_AvailableLimit.Visible = false;
                    lbl_MaxLimit.Visible = false;
                    txt_ActualRent.ReadOnly = false;
                    txt_Income.ReadOnly = false;
                    btn_Confirm.Enabled = true;
                    btn_Confirm.ForeColor = System.Drawing.Color.White;
                    btn_Save.Enabled = true;
                    btn_Save.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    lnk_section.Visible = true;
                    lbl_AvailableLimit.Visible = true;
                    lbl_MaxLimit.Visible = true;
                    txt_ActualRent.ReadOnly = true;
                    txt_Empcode.ReadOnly = true;
                    txt_ActualRent.Focus();
                    int fd, td, mm;
                    fd = obj_da_Log.GetDate().Day;
                    mm = obj_da_Log.GetDate().Month;
                    td = 19;

                    if (fd <= 19)
                    {
                        btn_Save.Enabled = true;
                        btn_Save.ForeColor = System.Drawing.Color.White;
                        txt_ActualRent.ReadOnly = false;
                        txt_Income.ReadOnly = false;
                        btn_Confirm.Enabled = true;
                        btn_Confirm.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        btn_Save.Enabled = false;
                        btn_Save.ForeColor = System.Drawing.Color.Gray;
                        txt_ActualRent.ReadOnly = false;
                        txt_Income.ReadOnly = false;
                        btn_Confirm.Enabled = false;
                        btn_Confirm.ForeColor = System.Drawing.Color.Gray;
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('You can update your investment plan between 1st and 19th of every month');", true);
                    }

                    DataTable obj_dt = new DataTable();

                    try
                    {
                        Emp_ID = Convert.ToInt32(Session["LoginEmpId"].ToString());
                        //Emp_ID = obj_da_Employee.GetEmpId(txt_Empcode.Text);
                        //hid_Empid.Value = Emp_ID.ToString();
                        obj_dt = obj_da_detail.GetEmpDetails(Emp_ID);
                        if (obj_dt.Rows.Count > 0)
                        {
                            txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                            txt_Empcode.Text = obj_dt.Rows[0]["username"].ToString();
                            txt_Company.Text = obj_dt.Rows[0]["branchname"].ToString();
                            txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                            txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                            txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                            txt_DOJ.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["doj"].ToString());

                            var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("branch") == int.Parse("11315") || row.Field<Int16>("branch") == int.Parse("11288") ||
                                row.Field<Int16>("branch") == int.Parse("11312") || row.Field<Int16>("branch") == int.Parse("11289") || row.Field<Int16>("branch") == int.Parse("13906")).ToList();

                            if (Result.Count > 0)
                            {
                                hid_Amount.Value = "50";
                            }
                            else
                            {
                                hid_Amount.Value = "40";
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Not a Invalid User')", true);
                        }

                        //txt_PlanDetail.Focus();

                        Fn_LoadDLL();
                        Fn_Loadplan();

                        txt_Detail.Text = "";
                        fyear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));
                        hid_year.Value = fyear.ToString();
                        Fn_FillGrd();
                        Fn_GetIncomeDetail();
                        Fn_GetAmountDetail();
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert(" + ex.Message.ToString() + ")", true);
                    }
                }
            }
        }

        private void Fn_LoadDYear()
        {
           /* DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            for (int i = Dt_Date.AddYears(-1).Year; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }*/

            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            for (int i = Dt_Date.AddYears(-1).Year; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            }
            if (Dt_Date.Month > 4)
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            }
            else
            {
                ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            }
        }




        private void Fn_Loadplan()
        {
            ddl_plan.Items.Clear();
            ddl_plan.Items.Add("");
            DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Detail.Getplandetails();
            if (obj_dt.Rows.Count > 0)
            {
                ddl_plan.DataSource = obj_dt;
                ddl_plan.DataTextField = "categoryname";
                ddl_plan.DataValueField = "categoryid";
                ddl_plan.DataBind();
            }
        }


        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            //Popup_Emp.Show();
            //iframecost.Attributes["src"] = "../HRM/EmployeeFind.aspx";
        }

        private void Fn_GetDetail()
        {
            DataTable obj_dt = new DataTable();
            Emp_ID = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            obj_dt = obj_da_detail.GetEmpDetails(Emp_ID);
            hid_Empid.Value = Emp_ID.ToString();
            if (obj_dt.Rows.Count > 0)
            {
                txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                txt_Company.Text = obj_dt.Rows[0]["branchname"].ToString();
                txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                txt_DOJ.Text = Utility.fn_ConvertDate(obj_dt.Rows[0]["doj"].ToString());

                var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("branch") == int.Parse("11315") || row.Field<Int16>("branch") == int.Parse("11288") ||
                    row.Field<Int16>("branch") == int.Parse("11312") || row.Field<Int16>("branch") == int.Parse("11289") ||
                    row.Field<Int16>("branch") == int.Parse("13906")).ToList();

                if (Result.Count > 0)
                {
                    hid_Amount.Value = "50";
                }
                else
                {
                    hid_Amount.Value = "40";
                }
                Fn_LoadDLL();
                Fn_FillGrd();
                Fn_GetIncomeDetail();
                Fn_GetAmountDetail();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Enter The Correct EmployeeCode');", true);
                txt_Empcode.Text = "";
                txt_Empcode.Focus();
            }
        }


        private void Fn_GetAmountDetail()
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0) //&& ddl_Year.SelectedItem.Text!= ""
            {
                double temp = 0, temp1 = 0;

                DataTable obj_dt = new DataTable();
                fyear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(2, 2));
                hid_year.Value = fyear.ToString();
                DtForm = DateTime.Parse("11/1/" + fyear);

                investnew();

                if (Session["StrTranType"].ToString() == "HR")
                {
                    obj_dt = obj_it.GetITDet(Convert.ToInt32(hid_Empid.Value), Convert.ToDateTime(H_fromDate.Value), Convert.ToDateTime(H_ToDate.Value), Convert.ToDateTime(h_date.Value));
                }
                else
                {
                    obj_dt = obj_it.GetITDet(int.Parse(Session["LoginEmpId"].ToString()), Convert.ToDateTime(H_fromDate.Value), Convert.ToDateTime(H_ToDate.Value), Convert.ToDateTime(h_date.Value));
                }

                for (int i = 0; i <= obj_dt.Rows.Count; i++)
                {
                    if (obj_dt.Rows[i]["HeaderName"].ToString() == "BASIC")
                    {
                        var chosenRow = (from row in obj_dt.AsEnumerable() where row.Field<string>("HeaderName") == "BASIC" select row).First();
                        if (chosenRow != null)
                        {
                            temp = Convert.ToDouble(chosenRow[2]);
                            txt_Basic50.Text = temp.ToString("#0.00");
                            break;
                        }
                        else
                        {
                            txt_Basic50.Text = "0.00";
                        }
                    }

                    if (obj_dt.Rows[i]["HeaderName"].ToString() == "HRA")
                    {
                        var chosenRow = (from row in obj_dt.AsEnumerable() where row.Field<string>("HeaderName") == "HRA" select row).First();
                        if (chosenRow != null)
                        {
                            temp1 = Convert.ToInt32(chosenRow[2]);
                            txt_RentPaid.Text = temp1.ToString("#0.00");
                            break;
                        }
                        else
                        {
                            txt_HRA.Text = "0.00";

                        }
                    }

                    txt_Basic50.Text = string.Format("{0:0.00}", (((BASIC * int.Parse(hid_Amount.Value.ToString())) / 100) * 12));
                }
                if (obj_dt.Rows.Count > 0)
                {
                    double HRA = 0;
                    txt_HRA.Text = string.Format("{0:0.00}", temp1);
                    txt_Basic50.Text = string.Format("{0:0.00}", ((Convert.ToDecimal(temp / 12) * int.Parse(hid_Amount.Value.ToString())) / 100) * 12);

                    if (Session["StrTranType"].ToString() == "HR")
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(Convert.ToInt32(hid_Empid.Value), Convert.ToInt32(hid_year.Value));
                    }
                    else
                    {
                        obj_dt = obj_da_Rent.HRGetRentDetails(int.Parse(Session["LoginEmpId"].ToString()), Convert.ToInt32(hid_year.Value));
                    }
                    if (obj_dt.Rows.Count > 0)
                    {
                        RP = double.Parse(obj_dt.Rows[0]["rp"].ToString());
                        ARP = double.Parse(obj_dt.Rows[0]["arp"].ToString());

                        txt_ActualRent.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rp"]);
                        txt_HRA.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rr"]);
                        txt_RentExp.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["taxrebate"]);

                        if (obj_dt.Rows[0]["rb"].ToString().TrimEnd().Length > 0)
                        {
                            txt_RentPaid.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["rb"]);
                        }
                        else
                        {
                            txt_RentPaid.Text = "0.00";
                        }
                    }
                    else
                    {
                        txt_ActualRent.Text = "0";
                        txt_HRA.Text = "0";
                    }
                }
                else
                {
                    txt_HRA.Text = "0.00";
                    txt_Basic50.Text = "0.00";
                    txt_ActualRent.Text = "0.00";
                    txt_HRA.Text = "0.00";
                }
                txt_ActualRent.Focus();
            }
        }

        public void investnew()
        {
            fyear = Convert.ToInt32("20" + ddl_Year.SelectedItem.ToString().Substring(2, 2));
            hid_year.Value = fyear.ToString();

            if (fyear < curyear)
            {
                if (curmonth >= 4)
                {
                    curmonth = 3;
                    curyear = fyear + 1;
                    getmonth = 3;
                    dtdate = Convert.ToDateTime(getmonth + "/05/" + (curyear));
                }
                else
                {
                    curmonth = obj_da_Log.GetDate().Month;
                    curyear = obj_da_Log.GetDate().Year;
                    getmonth = curmonth;
                    dtdate = Convert.ToDateTime(getmonth + "/05/" + (curyear));
                    h_date.Value = dtdate.ToShortDateString();
                }
            }
            else
            {
                curmonth = obj_da_Log.GetDate().Month;
                curyear = obj_da_Log.GetDate().Year;
                getmonth = curmonth;
                dtdate = Convert.ToDateTime(getmonth + "/05/" + (curyear));
                h_date.Value = dtdate.ToShortDateString();
            }

            dt_date = Convert.ToDateTime("04/01/" + fyear);
            H_fromDate.Value = dt_date.ToShortDateString();
            DtTo = Convert.ToDateTime("03/31/" + Convert.ToInt32(fyear + 1).ToString());
            H_ToDate.Value = DtTo.ToString();
        }


        private void Fn_LoadDLL()
        {
            ddl_Section.Items.Clear();
            ddl_Section.Items.Add("");

            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_detail.GetSection();
            if (obj_dt.Rows.Count > 0)
            {
                ddl_Section.DataSource = obj_dt;
                ddl_Section.DataTextField = "seccode";
                ddl_Section.DataValueField = "secid";
                ddl_Section.DataBind();
            }
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                Fn_GetDetail();
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                //btn_Save.Text = "Save";
                btn_Save.ToolTip = "Save";
                btn_add2.Attributes["class"] = "btn ico-save";
            }
        }

        private void Fn_GetIncomeDetail()
        {
            Emp_ID = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_Rent.GetHouseRent(Emp_ID, int.Parse(ddl_Year.SelectedValue.ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                txt_Income.Text = string.Format("{0:0.00}", obj_dt.Rows[0]["income"]);
            }
        }


        private void Fn_FillGrd()
        {
            if (ddl_Year.SelectedItem.Text != "" && txt_Empcode.Text.TrimEnd().Length > 0)
            {
                Emp_ID = Convert.ToInt32(hid_Empid.Value);
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_detail.SelInvestPlan(Emp_ID, int.Parse(ddl_Year.SelectedValue.ToString()));
                if (obj_dt.Rows.Count > 0)
                {
                    Grd.DataSource = obj_dt;
                    Grd.DataBind();
                }
                else
                {
                    if (txt_Empcode.Text.ToString().TrimEnd().Length > 0)
                    {
                        int int_PayMonth = 4, int_PayYear = 0;
                        double Total = 0, PayTotal = 0;
                        for (int i = 0; i <= 11; i++)
                        {
                            PayTotal = obj_da_detail.Getpfamt4invest(Emp_ID, int_PayMonth, int_PayYear);
                            Total = Total + PayTotal;

                            if (int_PayMonth % 12 == 0)
                            {
                                int_PayMonth = 1;
                                int_PayYear++;
                            }
                            else
                            {
                                int_PayMonth++;
                            }
                        }
                        obj_da_detail.InsInvestPlan(Emp_ID, "PF", Total, 6, int.Parse(ddl_Year.SelectedValue.ToString()), obj_da_Log.GetDate());
                        Fn_FillGrd();
                    }
                }


            }
        }

        protected void ddl_Section_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            obj_dt = obj_da_detail.GetSection();
            Emp_ID = Convert.ToInt32(hid_Empid.Value);

            if (obj_dt.Rows.Count > 0)
            {
                var Result = obj_dt.AsEnumerable().Where(row => row.Field<Int16>("secid") == int.Parse(ddl_Section.SelectedValue.ToString())).ToList();
                if (Result.Count > 0)
                {
                    txt_Detail.Text = Result[0]["secname"].ToString();
                }
            }

            if (txt_Empcode.Text.ToString().TrimEnd().Length > 0)
            {
                double Amount = obj_da_detail.getInvesTotAmt(Emp_ID, int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                double MaxAmount = obj_da_detail.getMaxlimitAmt(int.Parse(ddl_Section.SelectedValue.ToString()));

                lbl_AvailableLimit.Text = "Available Limit For " + ddl_Section.SelectedItem.Text + " = " + (MaxAmount - Amount).ToString();
                lbl_MaxLimit.Text = "Maximum Limit For " + ddl_Section.SelectedItem.Text + " = " + MaxAmount.ToString();
            }
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index, secid;
            string invest;
            Emp_ID = Convert.ToInt32(hid_Empid.Value);

            index = Grd.SelectedRow.RowIndex;
            secid = Convert.ToInt32(Grd.SelectedDataKey.Values[0].ToString());
            invest = Grd.SelectedRow.Cells[2].Text.ToString();

            if (invest != "PF")
            {
                if (hid_confirm.Value.ToString() == "N")
                {
                    txt_Detail.Text = Grd.Rows[index].Cells[1].Text.TrimEnd();
                   /* txt_PlanDetail.Text = Grd.Rows[index].Cells[2].Text.TrimEnd();
                    hid_Plan.Value = txt_PlanDetail.Text;*/

                    ddl_plan.SelectedIndex = ddl_plan.Items.IndexOf(ddl_plan.Items.FindByText(Grd.SelectedRow.Cells[2].Text.TrimEnd()));
                     hid_Plan.Value=Grd.SelectedRow.Cells[2].Text.TrimEnd();
                    

                    txt_Amount.Text = Grd.Rows[index].Cells[3].Text.ToString().Replace(",", "");
                    ddl_Section.SelectedIndex = ddl_Section.Items.IndexOf(ddl_Section.Items.FindByText(Grd.SelectedRow.Cells[0].Text.TrimEnd()));
                    //btn_Save.Text = "Update";
                    btn_Save.ToolTip = "Update";
                    btn_add2.Attributes["class"] = "btn btn-update1";
                    //ddl_Section_SelectedIndexChanged(sender, e);
                }
                else if (hid_confirm.Value.ToString() == "Y")
                {
                    //int section = Convert.ToInt32(Grd.Rows[index].Cells[0].Text);
                    obj_da_detail.DelInvestPlan(Emp_ID, Grd.Rows[index].Cells[2].Text.TrimEnd(), Convert.ToInt32(hid_year.Value), secid);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "HRM", "alertify.alert('Details Deleted')", true);
                    Fn_FillGrd();
                    Fn_ClearSave();
                    //btn_Save.Text = "Save";
                    btn_Save.ToolTip = "Save";
                    btn_add2.Attributes["class"] = "btn ico-save";
                }
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            double allamt = 0.00, Amount, MaxAmount;
            DataTable obj_dt = new DataTable();
            Emp_ID = Convert.ToInt32(hid_Empid.Value);

            EmptyCheck();

            if (err == true)
            {
                err = false;
                return;
            }

            try
            {
                if (btn_Save.ToolTip == "Save")
                {
                    Amount = obj_da_detail.getInvesTotAmt(Emp_ID, int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                    Amount = Amount + double.Parse(txt_Amount.Text);
                    MaxAmount = obj_da_detail.getMaxlimitAmt(int.Parse(ddl_Section.SelectedValue.ToString()));
                    lbl_AvailableLimit.Text = "Available Limit For " + ddl_Section.SelectedItem.Text + "=" + (MaxAmount - allamt);

                    if (MaxAmount >= Amount)
                    {
                      //  obj_dt = obj_da_detail.InsInvestPlan(Emp_ID, txt_PlanDetail.Text, double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()), obj_da_Log.GetDate());
                        obj_dt = obj_da_detail.InsInvestPlan(Emp_ID, ddl_plan.SelectedItem.Text, double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()), obj_da_Log.GetDate());
                        if (obj_dt.Rows.Count > 0)
                        {
                            Fn_FillGrd();
                            ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Already exists')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Saved')", true);
                            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 804, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/" + ddl_Year.SelectedValue.ToString() + "/" + ddl_Section.SelectedItem.Text + "-" + txt_Amount.Text + "/S");
                            Fn_FillGrd();
                            Fn_ClearSave();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Amount should be less than the Maxlimit Amount')", true);
                        txt_Amount.Text = "";
                        txt_Amount.Focus();
                    }
                }
                else if (btn_Save.ToolTip == "Update")
                {
                    Amount = obj_da_detail.getInvesTotAmt(Emp_ID, int.Parse(ddl_Section.SelectedValue.ToString()), int.Parse(ddl_Year.SelectedValue.ToString()));
                    Amount = Amount - double.Parse(txt_Amount.Text);
                    MaxAmount = obj_da_detail.getMaxlimitAmt(int.Parse(ddl_Section.SelectedValue.ToString()));
                    if (Amount >= MaxAmount)
                    {
                        lbl_AvailableLimit.Text = "Available Limit For " + ddl_Section.SelectedItem.Text + "= 0";
                    }

                    if (MaxAmount >= Amount && MaxAmount >= double.Parse(txt_Amount.Text))
                    {
                       // obj_da_detail.UpdInvestPlan(Emp_ID, txt_PlanDetail.Text, double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()), hid_Plan.Value.ToString(), int.Parse(ddl_Year.SelectedValue.ToString()), DateTime.Parse("01/01/9999"), double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()));
                        obj_da_detail.UpdInvestPlan(Emp_ID, ddl_plan.SelectedItem.Text, double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()), hid_Plan.Value.ToString(), int.Parse(ddl_Year.SelectedValue.ToString()), DateTime.Parse("01/01/9999"), double.Parse(txt_Amount.Text), int.Parse(ddl_Section.SelectedValue.ToString()));
                        
                        ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated')", true);
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 804, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/" + ddl_Year.SelectedValue.ToString() + "/" + ddl_Section.SelectedItem.Text + "-" + txt_Amount.Text + "/U");
                        Fn_FillGrd();
                        Fn_ClearSave();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Amount Must be Less than the Maxlimit Amount')", true);
                        txt_Amount.Text = "";
                        txt_Amount.Focus();
                    }
                }
                //btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert(" + ex.Message.ToString() + ")", true);
            }
        }

        private void Fn_ClearSave()
        {
            txt_Detail.Text = "";
          //  txt_PlanDetail.Text = "";

            ddl_plan.SelectedItem.Text = "";
            txt_Amount.Text = "";
            lbl_AvailableLimit.Text = "";
            lbl_MaxLimit.Text = "";
            //btn_Save.Text = "Save";
            btn_Save.ToolTip = "Save";
            btn_add2.Attributes["class"] = "btn ico-save";
            Fn_LoadDYear();
        }

        private void Fn_Clear()
        {
            txt_ActualRent.Text = "";
            txt_Basic50.Text = "";
            txt_Company.Text = "";
            txt_Dept.Text = "";
            txt_Desg.Text = "";
            txt_Detail.Text = "";
            txt_DOJ.Text = "";
            txt_Empcode.Text = "";
            txt_Grade.Text = "";
            txt_HRA.Text = "";
            txt_Income.Text = "";
            txt_Name.Text = "";
            txt_RentExp.Text = "";
            txt_RentPaid.Text = "";

            Grd.DataSource = new DataTable();
            Grd.DataBind();
            Fn_ClearSave();
            //btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "HR")
            {
                if (btn_cancel.ToolTip == "Cancel")
                {
                    txt_Empcode.Focus();
                    Fn_Clear();
                }
                else
                {
                    this.Response.End();
                }
            }
            else
            {
                if (btn_cancel.ToolTip == "Cancel")
                {
                    Fn_Clear();
                    txt_Empcode.Focus();
                }
                else
                {
                    Response.Redirect("../Home/Profile.aspx");
                }
            }
        }

        protected void btn_Confirm_Click(object sender, EventArgs e)
        {
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_FileName = "", str_Script = "";
            Session["str_sfs"] = ""; Session["str_sp"] = "";

            if (txt_ActualRent.Text.TrimEnd().Length > 0)
            {
                Str_RptName = "/Payroll" + "/RptHRInvestApp.rpt";
                Session["str_sp"] = "year=" + ddl_Year.SelectedValue.ToString().Substring(2, 2) + " \" " + ddl_Year.SelectedItem.Text.ToString().Substring(7, 2) + "~tenperbasic=" + txt_Basic50.Text + "~atualpaid=" + txt_ActualRent.Text;
                Session["str_sfs"] = "{MasterEmployee.Employeeid}=" + Session["LoginEmpId"].ToString() + "and {HREmpInvestDetails.fy}=" + ddl_Year.SelectedValue.ToString();
                Str_FileName = Server.MapPath("~/UploadDocument/") + txt_Empcode.Text;

                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(btn_Confirm, typeof(Button), "JobInfo", str_Script, true);

                string Str_subject = "Investment Plan For " + txt_Empcode.Text + ":" + txt_Name.Text;
                Utility.SendMail(Session["usermailid"].ToString(), "", Str_subject, Fn_MailContent(Session["usermailid"].ToString()), Server.MapPath("~/UploadDocument/" + txt_Empcode.Text + ".pdf"), Session["usermailpwd"].ToString(), "", "");
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", "alertify.alert('Actual Rent Cannot Be Blank');", true);
                txt_ActualRent.Focus();
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        private string Fn_MailContent(string strUserMail)
        {
            string Str_Temp = "";

            Str_Temp = Str_Temp + Utility.Fn_GetCompanyAddress();
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2>Dear Sir / Madam,</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br><br>Please find the attachment</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br><br><br><br><br>Thanks & Best Regards,</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br>" + txt_Empcode.Text + "</FONT>";
            Str_Temp = Str_Temp + "<FONT FACE=sans-serif SIZE=2><br>" + " Email : " + strUserMail + "</FONT>";

            return Str_Temp;
        }

        protected void txt_ActualRent_TextChanged(object sender, EventArgs e)
        {
            Emp_ID = Convert.ToInt32(hid_Empid.Value);
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                if (txt_ActualRent.Text.TrimEnd().Length > 0)
                {
                    if (RP == ARP)
                    {
                        double Amount = double.Parse(txt_ActualRent.Text) - (((BASIC / 100) * 10) * 12);
                        if (Amount > 0)
                        {
                            txt_RentPaid.Text = string.Format("{0:0}", Amount);
                        }
                        else
                        {
                            txt_RentPaid.Text = "0";
                        }

                        RentPaid = double.Parse(txt_ActualRent.Text);

                        double ActualAmount = 0, Rentreceived = 0, RentPaidAmount = 0, Basic50 = 0, TotAmount = 0;
                        ActualAmount = double.Parse(txt_ActualRent.Text);
                        Rentreceived = double.Parse(txt_HRA.Text.ToString());
                        RentPaidAmount = double.Parse(txt_RentPaid.Text);
                        Basic50 = double.Parse(txt_Basic50.Text);
                        double[] RentAmount = { ActualAmount, Rentreceived, RentPaidAmount, Basic50 };
                        TotAmount = RentAmount.Min();

                        obj_da_Rent.HRInsRentDetailsWeb(Emp_ID, int.Parse(ddl_Year.SelectedValue.ToString()), ActualAmount, Rentreceived, RentPaidAmount, TotAmount, Basic50);
                        ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Rent Paid Updated Successfully');", true);
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 804, 2, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/" + ddl_Year.SelectedValue.ToString() + "/ Actual Rent -" + txt_ActualRent.Text + "/U");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Proof Received...Hence you canot update');", true);
                        ddl_Section.Focus();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_ActualRent, typeof(TextBox), "HRM", "alertify.alert('Actual Rent Cannot Be Blank');", true);
                    txt_ActualRent.Focus();
                }
            }
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
            Session["str_sfs"] = ""; Session["str_sp"] = "";
            string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Emp_ID = obj_da_Employee.GetEmpId(txt_Empcode.Text);

            Str_RptName = "/Payroll" + "/RptHRInvestApp.rpt";
            if (txt_ActualRent.Text.TrimEnd().Length > 0)
            {
                Session["str_sp"] = "year=" + ddl_Year.SelectedValue.ToString().Substring(2, 2) + " - " + ddl_Year.SelectedItem.Text.ToString().Substring(7, 2) + "~tenperbasic=" + txt_Basic50.Text + "~atualpaid=" + txt_ActualRent.Text;
            }
            else
            {
                Session["str_sp"] = "year=" + ddl_Year.SelectedValue.ToString().Substring(2, 2) + " - " + ddl_Year.SelectedItem.Text.ToString().Substring(7, 2) + "~tenperbasic=" + txt_Basic50.Text + "~atualpaid=" + RentPaid;
            }
            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                Session["str_sfs"] = " {HREmpInvestDetails.empid} = " + Emp_ID + " and {HREmpInvestDetails.fy} = " + ddl_Year.SelectedValue.ToString();
            }
            else
            {
                Session["str_sfs"] = "{HREmpInvestDetails.fy}=" + ddl_Year.SelectedValue.ToString();
            }

            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 804, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/" + ddl_Year.SelectedValue.ToString() + "/ Actual Rent -" + txt_ActualRent.Text + "/View");
            
            ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
        }

        protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public DateTime dt_date { get; set; }

        protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    if (e.Row.Cells[2].Text == "PF")
                    {
                        ImageButton img = (ImageButton)e.Row.Cells[4].FindControl("Img_delete");
                        img.Enabled = false;
                    }
                    else
                    {
                        ImageButton img = (ImageButton)e.Row.Cells[4].FindControl("Img_delete");
                        img.Enabled = true;

                    }
                }

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";


            }

        }

        protected void EmptyCheck()
        {
            if (ddl_Section.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select Section')", true);
                err = true;
                ddl_Section.Focus();
                return;
            }
          /*  else if (txt_PlanDetail.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Investment Plan Cannot Be Blank')", true);
                err = true;
                txt_PlanDetail.Focus();
                return;
            }*/

            else if (ddl_plan.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Investment Plan Cannot Be Blank')", true);
                ddl_plan.Focus();
                err = true;
                return;
            }
            else if (txt_Amount.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Amount Cannot Be Blank')", true);
                txt_Amount.Focus();
                err = true;
                return;
            }
            else if (txt_Amount.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Cannot Enter the Zero Amount')", true);
                txt_Amount.Focus();
                err = true;
                return;
            }
            else if (ddl_Year.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select Financial Year')", true);
                ddl_Year.Focus();
                err = true;
                return;
            }
            else if (txt_Empcode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter Employee Code')", true);
                txt_Empcode.Focus();
                err = true;
                return;
            }
        }

        protected void lnk_section_Click(object sender, EventArgs e)
        {
            string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            str_RptName = "/Payroll" + "rptHRSection.rpt";

            if (txt_Empcode.Text == "")
            {
                Session["str_sp"] = "year=" + ddl_Year.Text;
                Session["str_sfs"] = "{HREmpInvestDetails.fy}=" + Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));
            }
            else
            {
                Session["str_sp"] = "";
                Session["str_sfs"] = "";
            }

            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(lnk_section, typeof(LinkButton), "HRM", "alertify.alert('Job Not Available');", true);
            //btn_cancel.Text = "Cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 804, "Job", "", "", Session["StrTranType"].ToString());

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