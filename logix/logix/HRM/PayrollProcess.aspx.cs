using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace logix.HRM
{
    public partial class PayrollProcess : System.Web.UI.Page
    {
        DataAccess.PayrollProcess obj_da_Payroll = new DataAccess.PayrollProcess();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        double grbsa = 0;
        double grotha = 0;
        double EntertainAllowance = 0;
        int Month_Diff;
        DateTime edatepf;
        double premonthpf = 0;
        double pfgross = 0;
        bool blpf;
        double Total_ESI = 0;
        double grtt = 0;
        double EsiValue;
        double EsiAmount = 0;
        int bid=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_Update, null, null);
            }
            if (!IsPostBack)
            {
                hid.Value = "";
                Fn_BindDivision();
                ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
                txt_year.Text = obj_da_Log.GetDate().Year.ToString();
                string str_CtrlLists, str_MsgLists, str_DataType;
                str_CtrlLists = "ddl_Company~ddl_Monrh";
                str_MsgLists = "Company~Month";
                str_DataType = "DropDown~DropDown";
                btn_Process.Attributes.Add("OnClick", "return IsValid('" + str_CtrlLists + "','" + str_MsgLists + "','" + str_DataType + "') && Chk_update();");
                DataTable obj_dt = new DataTable();
                Grd_Pay.DataSource = obj_dt;
                Grd_Pay.DataBind();
            }
            //else if( Page.IsPostBack)
            //{
            //   // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            //   // ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtLocationFocus();", true);
            //}
            //if(txt_EmpName.Text=="")
            //{
            //    Session["ConditionData"] = null;
            //}

            //if(txt_location.Text=="")
            //{
            //    Session["ConditionData"] = null;
            //}
        }

        protected void btn_Process_Click(object sender, EventArgs e)
        {
            Fn_GetPayrolldetail();
        }
        public void Fn_BindDivision()
        {
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            DataTable obj_dt = new DataTable();
            // obj_dt = obj_da_Emp.GetDivisionhrm("M");
            obj_dt = obj_da_Emp.GetDivision("HR");
            ddl_Company.DataSource = obj_dt;
            ddl_Company.DataTextField = "divisionname";
            ddl_Company.DataValueField = "divisionid";
            ddl_Company.DataBind();


        }
        private void Fn_GetPayrolldetail()
        {
            try
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Payroll.GetParyollDet(int.Parse(ddl_Monrh.SelectedValue.ToString()), int.Parse(txt_year.Text), int.Parse(ddl_Company.SelectedValue.ToString()));
                Session["Data"] = obj_dt;
                if (obj_dt.Rows.Count > 0)
                {
                    hid.Value = obj_dt.Rows.Count.ToString();
                    Confirm.Show();
                }
                else
                {
                    data_Bind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Confirm.Hide();
            data_Bind();
           
        }

        public void data_Bind()
        {
            try
            {


                DataTable obj_dt = new DataTable();
                DataTable obj_dtPay = new DataTable();

                obj_dtPay.Columns.Add("EMPID");
                obj_dtPay.Columns.Add("EMPCODE");
                obj_dtPay.Columns.Add("EMPNAME");
                obj_dtPay.Columns.Add("DESIGNATION");
                obj_dtPay.Columns.Add("GRADE");
                obj_dtPay.Columns.Add("DEPT");
                obj_dtPay.Columns.Add("CL");
                obj_dtPay.Columns.Add("SL");
                obj_dtPay.Columns.Add("EL");
                obj_dtPay.Columns.Add("LOCATION");
                obj_dtPay.Columns.Add("BASIC");
                obj_dtPay.Columns.Add("HRA");
                obj_dtPay.Columns.Add("CONVEYANCE");
                obj_dtPay.Columns.Add("SPECIALALLOWANCE");
                obj_dtPay.Columns.Add("OTHEREARNING");
                obj_dtPay.Columns.Add("BASICARR");
                obj_dtPay.Columns.Add("OTHERARR");
                obj_dtPay.Columns.Add("LOYALITY");
                obj_dtPay.Columns.Add("PF");
                obj_dtPay.Columns.Add("ESI");
                obj_dtPay.Columns.Add("LWF");
                obj_dtPay.Columns.Add("LOANADVANCE");
                obj_dtPay.Columns.Add("OTHERDED");
                obj_dtPay.Columns.Add("DRIVERWAGES");
                obj_dtPay.Columns.Add("ENTERTAINALLOWANCE");
                obj_dtPay.Columns.Add("PETROL");
                obj_dtPay.Columns.Add("EMI");
                obj_dtPay.Columns.Add("MOBILE");
                obj_dtPay.Columns.Add("DATACARD");
                obj_dtPay.Columns.Add("RESIDENCEPHONE");
                obj_dtPay.Columns.Add("IT");
                obj_dtPay.Columns.Add("PROFTAX");
                obj_dtPay.Columns.Add("MEDICAL");
                obj_dtPay.Columns.Add("GR");
                obj_dtPay.Columns.Add("GRPF");

                double PfAmt = 0;
                PfAmt = 12;
                EsiAmount = 1.75;
                EsiValue = 15000;

                int int_Month = int.Parse(ddl_Monrh.SelectedValue.ToString());
                int int_Year = int.Parse(txt_year.Text);
                DateTime dt_date = DateTime.Parse(ddl_Monrh.SelectedValue.ToString() + "/15/" + txt_year.Text);
                if (txt_Empcode.Text.TrimEnd().Length > 0)
                {
                    obj_dt = obj_da_Payroll.GetEmp4OneEemp(txt_Empcode.Text, dt_date);
                }
                else
                {
                    obj_dt = obj_da_Payroll.GetEmp4Division(int.Parse(ddl_Company.SelectedValue.ToString()), dt_date);
                }
                DataRow dr;



                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    double Empworkday = DateTime.DaysInMonth(int_Year, int_Month);
                    DataTable obj_dttemp = new DataTable();
                    double CL = 0, SL = 0, EL = 0, LoPday = 0, Amount = 0, WorkingDay = 0, Old_Amount = 0;
                    Boolean LWFTaken = false;
                    int int_Empid;

                    dr = obj_dtPay.NewRow();
                    obj_dtPay.Rows.Add(dr);

                    dr["EMPID"] = obj_dt.Rows[i]["employeeid"].ToString();
                    dr["EMPCODE"] = obj_dt.Rows[i]["username"].ToString();
                    dr["EMPNAME"] = obj_dt.Rows[i]["empname"].ToString();
                    dr["LOCATION"] = obj_dt.Rows[i]["portname"].ToString();
                    dr["DESIGNATION"] = obj_dt.Rows[i]["designame"].ToString();
                    dr["GRADE"] = obj_dt.Rows[i]["grade"].ToString();
                    dr["DEPT"] = obj_dt.Rows[i]["deptname"].ToString();
                    int_Empid = int.Parse(obj_dt.Rows[i]["employeeid"].ToString());

                    obj_dttemp = obj_da_Payroll.GetEmp4LeaveDtls(int_Empid, int_Year);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        CL = double.Parse(obj_dttemp.Rows[0]["clbalance"].ToString());
                        SL = double.Parse(obj_dttemp.Rows[0]["slbalance"].ToString());
                        EL = double.Parse(obj_dttemp.Rows[0]["elbalance"].ToString());
                    }
                    else
                    {
                        CL = 0.00;
                        SL = 0.00;
                        EL = 0.00;
                    }
                    dr["CL"] = CL;
                    dr["SL"] = SL;
                    dr["EL"] = EL;

                    LWFTaken = obj_da_Payroll.ChkLWFEmpcount(int.Parse(obj_dt.Rows[i]["BranchId"].ToString()), int_Month, int_Year);
                    if (LWFTaken == true)
                    {
                        double tot = Convert.ToDouble(obj_da_Payroll.GetLWFAmt(int.Parse(obj_dt.Rows[i]["BranchId"].ToString()), int_Month, int_Year, obj_dt.Rows[i]["grade"].ToString()));
                        dr["LWF"] = tot.ToString("#0.00");
                    }
                    else
                    {
                        dr["LWF"] = "0.00";
                    }
                    obj_dttemp = obj_da_Payroll.GetLopDates(int_Empid, int_Month, int_Year);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        LoPday = double.Parse(obj_dttemp.Rows[0]["lopdays"].ToString());
                        WorkingDay = double.Parse(obj_dttemp.Rows[0]["workdays"].ToString());
                    }
                    DateTime dt_doj = DateTime.Parse(obj_dt.Rows[i]["doj"].ToString());
                    DateTime dt = DateTime.Parse(int_Month.ToString() + "/" + dt_doj.Day.ToString() + "/" + int_Year.ToString());
                    obj_dttemp = obj_da_Payroll.GetEmpSalaryDetails(int_Empid, dt);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Amount = double.Parse(obj_dttemp.Rows[0]["basic"].ToString());
                        Total_ESI = Total_ESI + Amount;
                        dr["BASIC"] = Fn_CalculateAmount(Amount, WorkingDay, LoPday, Empworkday);

                        Amount = double.Parse(obj_dttemp.Rows[0]["hra"].ToString());
                        Total_ESI = Total_ESI + Amount;
                        dr["HRA"] = Fn_CalculateAmount(Amount, WorkingDay, LoPday, Empworkday);

                        Amount = double.Parse(obj_dttemp.Rows[0]["conveyance"].ToString());
                        Total_ESI = Total_ESI + Amount;
                        dr["CONVEYANCE"] = Fn_CalculateAmount(Amount, WorkingDay, LoPday, Empworkday);

                        Amount = double.Parse(obj_dttemp.Rows[0]["sallowence"].ToString());
                        Total_ESI = Total_ESI + Amount;
                        dr["SPECIALALLOWANCE"] = Fn_CalculateAmount(Amount, WorkingDay, LoPday, Empworkday);

                        Amount = double.Parse(obj_dttemp.Rows[0]["others"].ToString());
                        Total_ESI = Total_ESI + Amount;
                        dr["OTHEREARNING"] = Fn_CalculateAmount(Amount, WorkingDay, LoPday, Empworkday);

                        Amount = double.Parse(obj_dttemp.Rows[0]["medical"].ToString());
                        Total_ESI = Total_ESI + Amount;
                        dr["MEDICAL"] = Fn_CalculateAmount(Amount, WorkingDay, LoPday, Empworkday);

                        dr["BASICARR"] = "0.00";
                        dr["OTHERARR"] = "0.00";
                        DataTable obj_dt_Lop = new DataTable();
                        double Lop_Amount = 0, Lop_OldAmount = 0, Basic_Arrear = 0, Other_Arrear = 0, Basic = 0;
                        Basic = double.Parse(obj_dttemp.Rows[0]["basic"].ToString());
                        EntertainAllowance = double.Parse(obj_dttemp.Rows[0]["entertainallow"].ToString());
                        Old_Amount = double.Parse(obj_dttemp.Rows[0]["hra"].ToString()) + double.Parse(obj_dttemp.Rows[0]["conveyance"].ToString()) + double.Parse(obj_dttemp.Rows[0]["sallowence"].ToString()) + double.Parse(obj_dttemp.Rows[0]["others"].ToString());
                        DateTime dt_Effdate = DateTime.Parse(ddl_Monrh.SelectedValue.ToString() + "/20/" + txt_year.Text);
                        obj_dttemp = obj_da_Payroll.GetEffdate(int_Empid, dt_Effdate);
                        if (obj_dttemp.Rows.Count > 0)
                        {
                            DateTime dt_Edate = DateTime.Parse(obj_dttemp.Rows[0]["edate"].ToString());
                            edatepf = dt_Edate;
                            Month_Diff = Fn_GetMonths(dt_Edate, dt_Effdate);
                            premonthpf = Month_Diff;
                            Amount = double.Parse(obj_dttemp.Rows[0]["ba"].ToString());
                            for (int j = 0; j <= Month_Diff - 1; j++)
                            {
                                obj_dttemp = obj_da_Payroll.GetParyollDet4empmonthyear(dt_Edate.AddMonths(j).Month, dt_Edate.Year, int_Empid);
                                if (obj_dttemp.Rows.Count > 0)
                                {
                                    obj_dt_Lop = obj_da_Payroll.GetLopDates(int_Empid, dt_Edate.AddMonths(j).Month, dt_Edate.Year);
                                    if (obj_dt_Lop.Rows.Count > 0)
                                    {
                                        LoPday = double.Parse(obj_dt_Lop.Rows[0]["lopdays"].ToString());
                                        WorkingDay = double.Parse(obj_dt_Lop.Rows[0]["workdays"].ToString());
                                        Empworkday = DateTime.DaysInMonth(dt_Edate.Year, dt_Edate.AddMonths(j).Month);
                                        Lop_Amount = double.Parse(Fn_CalculateAmount(Amount, WorkingDay, LoPday, Empworkday));
                                        Lop_Amount = Lop_Amount - double.Parse(obj_dttemp.Rows[0]["basic"].ToString());


                                        Lop_OldAmount = double.Parse(Fn_CalculateAmount(Old_Amount, WorkingDay, LoPday, Empworkday));
                                        Lop_OldAmount = Lop_OldAmount - (double.Parse(obj_dttemp.Rows[0]["hra"].ToString()) + double.Parse(obj_dttemp.Rows[0]["Conv"].ToString()) + double.Parse(obj_dttemp.Rows[0]["spallow"].ToString()) + double.Parse(obj_dttemp.Rows[0]["otherearn"].ToString()));
                                    }
                                    Basic_Arrear = Basic_Arrear + Lop_Amount;
                                    Other_Arrear = Other_Arrear + Lop_OldAmount;
                                }
                            }
                            dr["BASICARR"] = Basic_Arrear.ToString("#0.00");
                            dr["OTHERARR"] = Other_Arrear.ToString("#0.00");
                        }
                        if (dt_doj.Month == dt.AddMonths(-1).Month && dt_doj.Year == dt.AddYears(-1).Year)
                        {
                            obj_dttemp = obj_da_Payroll.GetParyollDet4empmonthyear(dt_doj.Month, dt_doj.Year, int_Empid);
                            if (obj_dttemp.Rows.Count > 0)
                            {
                                obj_dt_Lop = obj_da_Payroll.GetLopDates(int_Empid, dt_doj.Month, dt_doj.Year);
                                if (obj_dt_Lop.Rows.Count > 0)
                                {
                                    LoPday = double.Parse(obj_dt_Lop.Rows[0]["lopdays"].ToString());
                                    WorkingDay = double.Parse(obj_dt_Lop.Rows[0]["workdays"].ToString());
                                    Empworkday = DateTime.DaysInMonth(dt_doj.Year, dt_doj.Month);
                                    Lop_Amount = double.Parse(Fn_CalculateAmount(Basic, LoPday, WorkingDay, Empworkday));
                                    Basic_Arrear = Lop_Amount;


                                    Lop_OldAmount = double.Parse(Fn_CalculateAmount(Old_Amount, LoPday, WorkingDay, Empworkday));
                                    Other_Arrear = Lop_OldAmount;

                                    dr["BASICARR"] = Basic_Arrear.ToString("#0.00");
                                    dr["OTHERARR"] = Other_Arrear.ToString("#0.00");
                                }
                            }
                        }
                        dr["LOYALITY"] = "0.00";
                        dr["ENTERTAINALLOWANCE"] = EntertainAllowance.ToString("#0.00");
                    }
                    else
                    {
                        dr["BASIC"] = "0.00";
                        dr["HRA"] = "0.00";
                        dr["CONVEYANCE"] = "0.00";
                        dr["SPECIALALLOWANCE"] = "0.00";
                        dr["OTHEREARNING"] = "0.00";
                        dr["BASICARR"] = "0.00";
                        dr["OTHERARR"] = "0.00";
                        dr["LOYALITY"] = "0.00";
                        dr["ENTERTAINALLOWANCE"] = "0.00";
                        dr["MEDICAL"] = "0.00";
                    }
                    obj_dttemp = obj_da_Payroll.GetEmpDeducationDetails(int_Empid, dt);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        //Amount = double.Parse(dr["BASIC"].ToString()) + double.Parse(dr["BASICARR"].ToString());
                        //Amount = (Amount * PfAmt) / 100;
                        //dr["PF"] = string.Format("{0:0}", Amount);

                        //Amount = double.Parse(dr["BASIC"].ToString()) + double.Parse(dr["HRA"].ToString()) + double.Parse(dr["CONVEYANCE"].ToString()) + double.Parse(dr["SPECIALALLOWANCE"].ToString()) + double.Parse(dr["OTHEREARNING"].ToString()) + double.Parse(dr["BASICARR"].ToString()) + double.Parse(dr["MEDICAL"].ToString()) + double.Parse(dr["OTHERARR"].ToString());
                        //if (Total_ESI < EsiValue)
                        //{
                        //    Amount = (Amount * EsiAmount) / 100;
                        //    dr["ESI"] = Math.Ceiling(Amount);
                        //}
                        //else
                        //{
                        //    dr["ESI"] = 0;
                        // }

                        double amt = 0;
                        double amtnew1 = 0;

                        if (double.Parse(dr["BASICARR"].ToString()) > 0)
                        {
                            amt = double.Parse(dr["BASIC"].ToString());
                            grbsa = double.Parse(dr["BASICARR"].ToString());
                            grotha = double.Parse(dr["OTHERARR"].ToString());

                            double arr1 = 0;
                            double arr2 = 0;
                            double arr3 = 0;
                            double prmonthpf = 0;
                            double prmonthbasic = 0;
                            DataTable dthra = new DataTable();
                            int pfi = 0;
                            double arr4 = 0;
                            double arr5 = 0;
                            double arr6 = 0;
                            double arr7 = 0;
                            EntertainAllowance = 0;
                            for (pfi = 0; pfi < premonthpf - 1; pfi++)
                            {
                                dthra = obj_da_Payroll.GetEmpHRADetails(int_Empid, edatepf.AddMonths(pfi));
                                if (dthra.Rows.Count > 0)
                                {
                                    prmonthpf = Convert.ToDouble(dthra.Rows[0]["pf"]);
                                    prmonthbasic = Convert.ToDouble(dthra.Rows[0]["basic"]);
                                    if (prmonthbasic < 15000)
                                    {
                                        arr7 = arr7 + Convert.ToDouble(dr["HRA"]) - Convert.ToDouble(dthra.Rows[0]["hraa"]);
                                    }
                                    else
                                    {
                                        arr7 = 0;
                                        grotha = 0;
                                    }

                                    if (amt >= 15000)
                                    {
                                        pfgross = amt;
                                        EntertainAllowance = (amt * PfAmt) / 100;
                                        arr6 = (amt * PfAmt) / 100;

                                        if (prmonthpf < EntertainAllowance && prmonthbasic >= 15000)
                                        {
                                            arr5 = 0;
                                            arr5 = EntertainAllowance - prmonthpf;
                                        }
                                        arr4 = arr4 + arr5;
                                        if (arr4 == 0)
                                        {
                                            blpf = true;
                                        }
                                    }
                                    else if (amt < 15000)
                                    {
                                        arr5 = 0;
                                        arr6 = 0;
                                        if (prmonthpf < 1800)
                                        {
                                            arr6 = (Total_ESI * PfAmt) / 100;
                                            EntertainAllowance = (Total_ESI * PfAmt) / 100;
                                            if (EntertainAllowance >= 1800)
                                            {
                                                arr2 = 1800 - prmonthpf;
                                                EntertainAllowance = 1800;
                                                arr6 = 1800;
                                                pfgross = 15000;
                                            }
                                            else
                                            {
                                                arr2 = EntertainAllowance - prmonthpf;
                                            }
                                            if (EntertainAllowance - prmonthpf > 0)
                                            {
                                                arr5 = arr2;
                                            }
                                            arr4 = arr4 + arr5;
                                        }
                                        else
                                        {
                                            amt = double.Parse(dr["BASIC"].ToString());
                                            if (amt > 15000)
                                            {
                                                pfgross = amt;
                                                EntertainAllowance = (amt * PfAmt) / 100;
                                                blpf = true;
                                            }
                                            else if (amt <= 15000)
                                            {
                                                amtnew1 = Convert.ToDouble(dr["BASIC"]) + Convert.ToDouble(dr["CONVEYANCE"]) + Convert.ToDouble(dr["SPECIALALLOWANCE"]) + Convert.ToDouble(dr["BASICARR"]) + Convert.ToDouble(dr["MEDICAL"]);
                                                if (amtnew1 > 15000)
                                                {
                                                    pfgross = 15000;
                                                    EntertainAllowance = (15000 * PfAmt) / 100;
                                                    blpf = true;
                                                }
                                                else if (amtnew1 <= 15000)
                                                {
                                                    pfgross = amtnew1;
                                                    EntertainAllowance = (amtnew1 * PfAmt) / 100;
                                                    blpf = true;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (arr6 + arr4 == 0)
                                {
                                    EntertainAllowance = EntertainAllowance;
                                }
                                else
                                {
                                    EntertainAllowance = arr6 + arr4;
                                }
                                if (blpf == true)
                                {
                                    grtt = 0;
                                    blpf = false;
                                }
                                else
                                {
                                    double ARW = 0;
                                    double ARW1 = 0;
                                    ARW = arr4 * 100 / 12;
                                    grtt = ARW;
                                }
                            }
                        }
                        else
                        {
                            amt = double.Parse(dr["BASIC"].ToString());
                            if (amt > 15000)
                            {
                                pfgross = amt;
                                EntertainAllowance = (amt * PfAmt) / 100;
                            }
                            else if (amt <= 15000)
                            {
                                amtnew1 = Convert.ToDouble(dr["BASIC"]) + Convert.ToDouble(dr["CONVEYANCE"]) + Convert.ToDouble(dr["SPECIALALLOWANCE"]) + Convert.ToDouble(dr["BASICARR"]) + Convert.ToDouble(dr["MEDICAL"]);
                                if (amtnew1 > 15000)
                                {
                                    pfgross = 15000;
                                    EntertainAllowance = (15000 * PfAmt) / 100;
                                }
                                else if (amtnew1 <= 15000)
                                {
                                    pfgross = amtnew1;
                                    EntertainAllowance = (amtnew1 * PfAmt) / 100;
                                }

                            }
                        }

                        dr["PF"] = EntertainAllowance.ToString("#0.00");
                        if (Convert.ToDouble(dr["BASICARR"]) > 0)
                        {
                            dr["GR"] = pfgross.ToString("#0.00");
                            dr["GRPF"] = grtt.ToString("#0.00");
                        }
                        else
                        {
                            if (pfgross < 0)
                            {
                                pfgross = 0;
                            }
                            grtt = 0;
                            dr["GR"] = pfgross.ToString("#0.00");
                            dr["GRPF"] = grtt.ToString("#0.00");
                        }
                        double basamt = 0;
                        basamt = Convert.ToDouble(dr["BASIC"]);
                        amt = Convert.ToDouble(dr["BASIC"]) + Convert.ToDouble(dr["HRA"]) + Convert.ToDouble(dr["CONVEYANCE"]) + Convert.ToDouble(dr["SPECIALALLOWANCE"]) + Convert.ToDouble(dr["OTHEREARNING"]) + Convert.ToDouble(dr["BASICARR"]) + Convert.ToDouble(dr["OTHERARR"]) + +Convert.ToDouble(dr["MEDICAL"]);
                        if (Total_ESI < EsiValue)
                        {
                            EntertainAllowance = (amt * EsiAmount) / 100;
                            dr["ESI"] = Math.Ceiling(EntertainAllowance);
                        }
                        else
                        {
                            dr["ESI"] = "0.00";
                        }
                    }
                    else
                    {
                        dr["PF"] = "0.00";
                        dr["ESI"] = "0.00";
                        dr["GR"] = "0.00";
                        dr["GRPF"] = "0.00";
                    }

                    obj_dttemp = obj_da_Payroll.GetEmpLoanDetails(int_Empid, dt);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Amount = double.Parse(obj_dttemp.Rows[0]["amount"].ToString());
                        dr["LOANADVANCE"] = Amount.ToString("#0.00");
                        dr["OTHERDED"] = "0.00";
                    }
                    else
                    {
                        dr["LOANADVANCE"] = "0.00";
                        dr["OTHERDED"] = "0.00";
                    }

                    obj_dttemp = obj_da_Payroll.GetEmpAllAllowanceDetails(int_Empid, dt);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        Amount = double.Parse(obj_dttemp.Rows[0]["driverwages"].ToString());
                        dr["DRIVERWAGES"] = string.Format("{0:0}", Amount);
                        Amount = double.Parse(obj_dttemp.Rows[0]["petrol"].ToString());
                        dr["PETROL"] = string.Format("{0:0}", Amount);
                        dr["EMI"] = 0;
                        Amount = double.Parse(obj_dttemp.Rows[0]["mobile"].ToString());
                        dr["MOBILE"] = string.Format("{0:0}", Amount);
                        Amount = double.Parse(obj_dttemp.Rows[0]["datacard"].ToString());
                        dr["DATACARD"] = string.Format("{0:0}", Amount);
                        Amount = double.Parse(obj_dttemp.Rows[0]["phoner"].ToString());
                        dr["RESIDENCEPHONE"] = string.Format("{0:0}", Amount);

                    }
                    else
                    {
                        dr["DRIVERWAGES"] = "0.00";
                        dr["PETROL"] = "0.00";
                        dr["EMI"] = "0.00";
                        dr["MOBILE"] = "0.00";
                        dr["DATACARD"] = "0.00";
                        dr["RESIDENCEPHONE"] = "0.00";
                    }
                    DateTime dt_to, dt_from;
                    if (int_Month >= 4)
                    {
                        dt_to = DateTime.Parse("03/31/" + (int_Year + 1));
                    }
                    else
                    {
                        dt_to = DateTime.Parse("03/31/" + int_Year);
                    }
                    obj_dttemp = obj_da_Payroll.GetITTax(int_Empid, dt, dt_to);
                    Amount = double.Parse(obj_dttemp.Rows[0]["iTax"].ToString());
                    dr["IT"] = Amount.ToString("#0.00");
                    Amount = double.Parse(dr["BASIC"].ToString()) + double.Parse(dr["HRA"].ToString()) + double.Parse(dr["CONVEYANCE"].ToString()) + double.Parse(dr["SPECIALALLOWANCE"].ToString()) + double.Parse(dr["BASICARR"].ToString()) + double.Parse(dr["MEDICAL"].ToString()) + double.Parse(dr["OTHERARR"].ToString());
                    int int_PFmonth = 0;
                    double Prof_Amount = 0;
                    DataAccess.payroll.ProfessionalTax obj_da_ProfTax = new DataAccess.payroll.ProfessionalTax();
                    obj_dttemp = obj_da_ProfTax.GetProfTaxMonth(int.Parse(obj_dt.Rows[i]["BranchId"].ToString()), int_Month, int_Year);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        if (obj_dttemp.Rows[0]["monthno"].ToString() == int_Month.ToString())
                        {
                            int_PFmonth = int.Parse(obj_dttemp.Rows[obj_dttemp.Rows.Count - 1]["monthno"].ToString());
                        }
                        else
                        {
                            for (int j = 1; j <= obj_dttemp.Rows.Count - 1; j++)
                            {
                                if (obj_dttemp.Rows[j]["monthno"].ToString() == int_Month.ToString())
                                {
                                    int_PFmonth = int.Parse(obj_dttemp.Rows[j - 1]["monthno"].ToString());
                                }
                            }
                        }

                        if (int_PFmonth != 12 && int_Month != 1)
                        {
                            int_PFmonth = Math.Abs(int_PFmonth - int_Month) - 1;
                            dt_to = DateTime.Parse(int_Month + "/01/" + int_Year);
                            dt_from = dt_to.AddMonths(-int_PFmonth).Date;
                            dt_to = dt_to.AddDays(-1).Date;
                            Prof_Amount = obj_da_Payroll.GetGross4ProfTax(int_Empid, dt_from, dt_to);
                        }
                        Amount = Prof_Amount + Amount;
                        bid = int.Parse(obj_dt.Rows[i]["BranchId"].ToString());
                        if (bid == 4 || bid == 5 || bid == 47 || bid == 48 || bid == 58 || bid == 61)
                        {
                            Prof_Amount = obj_da_ProfTax.GetProfTaxAmt4Mum(int.Parse(obj_dt.Rows[i]["BranchId"].ToString()), (int)Amount, int_Month, int_Year, int.Parse(obj_dt.Rows[i]["employeeid"].ToString()));
                        }
                        else
                        {
                            Prof_Amount = obj_da_ProfTax.GetProfTaxAmt(int.Parse(obj_dt.Rows[i]["BranchId"].ToString()), (int)Amount, int_Month, int_Year);
                        }


                    }
                    dr["PROFTAX"] = Prof_Amount.ToString("#0.00");

                }
                //dr["GR"].v
                //dr["GRPF"] = string.Format("{0:0}", grtt);
                Grd_Pay.DataSource = obj_dtPay;
                // Grd_Pay.Attributes.CssStyle["hide"].ce = "Class";
                Grd_Pay.DataBind();
                if (Session["Data"] == null)
                {
                    Grd_Pay.Columns[19].Visible = true;
                    Grd_Pay.Columns[20].Visible = true;
                }
                Grd_Pay.Columns[19].Visible = false;
                Grd_Pay.Columns[20].Visible = false;
                Session["Data"] = obj_dtPay;
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 797, 1, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedItem.Text + "/" + txt_year.Text + "/P");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                if (Grd_Pay.Rows.Count>0)
                {
                    ConUpdate.Show();
                }
                else
                {
                    Fn_Clear();
                }
               // Fn_Clear();
            }
            else
            {
                this.Response.End();
            }
        }
        private void Fn_Clear()
        {
            hid.Value = "";
            ddl_Monrh.SelectedIndex = ddl_Monrh.Items.IndexOf(ddl_Monrh.Items.FindByValue(obj_da_Log.GetDate().Month.ToString()));
            txt_year.Text = obj_da_Log.GetDate().Year.ToString();
            Grd_Pay.DataSource = new DataTable();
            Grd_Pay.DataBind();
            ddl_Company.SelectedIndex = 0;
            ddl_Monrh.SelectedIndex = 0;
            txt_EmpName.Text = "";
            txt_location.Text = "";
            txt_Empcode.Text = "";
            Session["Data"] = null;
            Session["ConditionData"] = null;
           // btn_cancel.Text = "Back";
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                if (Grd_Pay.Rows.Count > 0)
                {
                    if (Session["Data"] != null)
                    {
                        obj_dt = (DataTable)Session["Data"];

                        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {

                            obj_dt.Rows[i]["BASIC"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_basic"))).Text;
                            obj_dt.Rows[i]["HRA"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_HRA"))).Text;
                            obj_dt.Rows[i]["CONVEYANCE"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_conveyance"))).Text; ;
                            obj_dt.Rows[i]["SPECIALALLOWANCE"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_splallowance"))).Text;
                            obj_dt.Rows[i]["OTHEREARNING"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_ohterearning"))).Text;
                            obj_dt.Rows[i]["BASICARR"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_basicarr"))).Text;
                            obj_dt.Rows[i]["OTHERARR"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_otherarr"))).Text;
                            obj_dt.Rows[i]["LOYALITY"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_loyality"))).Text;
                            obj_dt.Rows[i]["PF"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_pf"))).Text;
                            obj_dt.Rows[i]["ESI"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_Esi"))).Text;
                            obj_dt.Rows[i]["LWF"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_lwf"))).Text;
                            obj_dt.Rows[i]["LOANADVANCE"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_loan"))).Text;
                            obj_dt.Rows[i]["OTHERDED"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_otherded"))).Text;
                            obj_dt.Rows[i]["IT"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_it"))).Text;
                            obj_dt.Rows[i]["PROFTAX"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_Proftax"))).Text;
                            obj_dt.Rows[i]["MEDICAL"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_medical"))).Text;
                            if (Grd_Pay.Columns[19].Visible == true)
                                obj_dt.Rows[i]["GR"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_Gr"))).Text;
                            if (Grd_Pay.Columns[20].Visible == true)
                                obj_dt.Rows[i]["GRPF"] = ((TextBox)(Grd_Pay.Rows[i].FindControl("txt_Grpf"))).Text;
                        }
                        obj_da_Payroll.SavePayrollProcessdet(obj_dt, int.Parse(ddl_Monrh.SelectedValue.ToString()), int.Parse(txt_year.Text));
                        ScriptManager.RegisterStartupScript(btn_Update, typeof(Button), "HRM", "alertify.alert('Payroll Process Details Saved');", true);
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 797, 2, int.Parse(Session["LoginBranchid"].ToString()), ddl_Monrh.SelectedItem.Text + "/" + txt_year.Text + "/U");

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        private string Fn_CalculateAmount(double Amt, double Lop, double Workday, double Empworkday)
        {
            double Total;
            Total = (Amt / Empworkday) * (Lop - Workday);
            string Str_Temp = string.Format("{0:0.00}", Total);
            return Str_Temp;
        }
        public int Fn_GetMonths(DateTime startDate, DateTime endDate)
        {

            int months = ((endDate.Year * 12) + endDate.Month) - ((startDate.Year * 12) + startDate.Month);

            //if (endDate.Day >= startDate.Day)
            //{
            //    months++;
            //}

            return months;
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {

            genPayroll();
        }

        public void genPayroll()
        {
            try
            {
                Confirm.Hide();
                DataTable obj_dtPay = new DataTable();

                if (Session["Data"] != null)
                {
                    obj_dtPay = (DataTable)Session["Data"];

                    obj_dtPay.Columns[13].ColumnName = "SPECIALALLOWANCE";
                    obj_dtPay.Columns[14].ColumnName = "OTHEREARNING";
                    obj_dtPay.Columns[15].ColumnName = "BASICARR";
                    obj_dtPay.Columns[16].ColumnName = "OTHERARR";
                    obj_dtPay.Columns[21].ColumnName = "LOANADVANCE";
                    obj_dtPay.Columns[22].ColumnName = "OTHERDED";
                    obj_dtPay.Columns[23].ColumnName = "DRIVERWAGES";
                    obj_dtPay.Columns[24].ColumnName = "ENTERTAINALLOWANCE";
                    obj_dtPay.Columns[29].ColumnName = "RESIDENCEPHONE";

                    foreach (DataRow dr in obj_dtPay.Rows)
                    {
                        dr["BASIC"] = string.Format("{0:0.00}", dr["BASIC"]);
                        dr["HRA"] = string.Format("{0:0.00}", dr["HRA"]);
                        dr["CONVEYANCE"] = string.Format("{0:0.00}", dr["CONVEYANCE"]);
                        dr["SPECIALALLOWANCE"] = string.Format("{0:0.00}", dr["SPECIALALLOWANCE"]);
                        dr["OTHEREARNING"] = string.Format("{0:0.00}", dr["OTHEREARNING"]);
                        dr["BASICARR"] = string.Format("{0:0.00}", dr["BASICARR"]);
                        dr["OTHERARR"] = string.Format("{0:0.00}", dr["OTHERARR"]);
                        dr["LOYALITY"] = string.Format("{0:0.00}", dr["LOYALITY"]);
                        dr["PF"] = string.Format("{0:0.00}", dr["PF"]);
                        dr["ESI"] = string.Format("{0:0.00}", dr["ESI"]);
                        dr["LWF"] = string.Format("{0:0.00}", dr["LWF"]);
                        dr["LOANADVANCE"] = string.Format("{0:0.00}", dr["LOANADVANCE"]);
                        dr["OTHERDED"] = string.Format("{0:0.00}", dr["OTHERDED"]);
                        dr["IT"] = string.Format("{0:0.00}", dr["IT"]);
                        dr["PROFTAX"] = string.Format("{0:0.00}", dr["PROFTAX"]);
                        dr["MEDICAL"] = string.Format("{0:0.00}", dr["MEDICAL"]);
                        dr["GR"] = string.Format("{0:0.00}", dr["GR"]);
                        dr["GRPF"] = string.Format("{0:0.00}", dr["GRPF"]);
                    }
                    obj_dtPay.AcceptChanges();
                    Grd_Pay.DataSource = obj_dtPay;
                    Grd_Pay.DataBind();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        [WebMethod]
        public static void GetEmpName(string Prefix,string location)
        {

           
            DataTable obj_dt = new DataTable();
            if (HttpContext.Current.Session["Data"] != null)
            {
                obj_dt = (DataTable)HttpContext.Current.Session["Data"];
                if (location != "" || Prefix != "")
                {
                    var Result = obj_dt.AsEnumerable().Where(row => row.Field<string>("EMPNAME").StartsWith(Prefix.ToUpper())
                       && row.Field<string>("LOCATION").StartsWith(location.ToUpper())).ToList();
                    if (Result.Count > 0)
                    {
                        obj_dt = Result.CopyToDataTable();
                    }
                    else
                    {
                        obj_dt = new DataTable();
                    }
                }else if(Prefix =="" && location =="")
                {
                    if(HttpContext.Current.Session["Data"] !=null)
                    {
                        obj_dt = (HttpContext.Current.Session["Data"]) as DataTable;
                    }else
                    {
                        obj_dt = new DataTable();
                    }
                }
                
                HttpContext.Current.Session["ConditionData"] = obj_dt;
            }

        }

        [WebMethod]
        public static void GetLocationName(string Prefix,string empname)
        {
            DataTable obj_dt = new DataTable();

            if (HttpContext.Current.Session["Data"] != null)
            {
                obj_dt = (DataTable)HttpContext.Current.Session["Data"];
                if (empname != "" || Prefix != "")
                {
                    var Result = obj_dt.AsEnumerable().Where(row => row.Field<string>("LOCATION").StartsWith(Prefix.ToUpper())
                       && row.Field<string>("EMPNAME").StartsWith(empname.ToUpper())).ToList();
                    if (Result.Count > 0)
                    {
                        obj_dt = Result.CopyToDataTable();
                    }
                    else
                    {
                        obj_dt = new DataTable();
                    }
                }
                else if (empname != "" || Prefix != "")
                {
                    if(HttpContext.Current.Session["Data"] !=null)
                    {
                        obj_dt = (HttpContext.Current.Session["Data"]) as DataTable;
                    }else
                    {
                        obj_dt = new DataTable();
                    }
                }
                
                HttpContext.Current.Session["ConditionData"] = obj_dt;
            }
        }

        protected void btn_Emp_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            if (Session["ConditionData"] != null)
            {
                obj_dt = (DataTable)Session["ConditionData"];
            }
            Grd_Pay.DataSource = obj_dt;
            Grd_Pay.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
            txt_EmpName.Focus();
        }

        protected void btn_Location_Click(object sender, EventArgs e)
        {
            DataTable obj_dt = new DataTable();
            if (Session["ConditionData"] != null)
            {
                obj_dt = (DataTable)Session["ConditionData"];
            }
            Grd_Pay.DataSource = obj_dt;
            Grd_Pay.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtLocationFocus();", true);
            txt_location.Focus();
        }



        protected void Grd_Pay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataTable obj_dt = new DataTable();
                Grd_Pay.PageIndex = e.NewPageIndex;
                Grd_Pay.DataSource = obj_dt;
                Grd_Pay.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_Pay_RowDataBound(object sender, GridViewRowEventArgs e)
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


                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Pay, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void btnYes1_Click(object sender, EventArgs e)
        {
            Fn_Clear();
        }

        protected void btnNo1_Click(object sender, EventArgs e)
        {

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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 797, "Job", "", "", Session["StrTranType"].ToString());

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