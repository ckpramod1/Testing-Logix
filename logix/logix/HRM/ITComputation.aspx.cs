using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace logix.HRM
{
    public partial class ITComputation : System.Web.UI.Page
    {
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Payroll.ITComputation obj_da_IT = new DataAccess.Payroll.ITComputation();
        DataAccess.Payroll.Details PayRolllDet = new DataAccess.Payroll.Details();
        DataAccess.HR.Employee obj_da_Employee = new DataAccess.HR.Employee();
        DataAccess.Payroll.Details obj_da_Detail = new DataAccess.Payroll.Details();
        DataAccess.PAYROLL.RentDetailss obj_da_Rent = new DataAccess.PAYROLL.RentDetailss();

        public  int int_Empid = 0, FYear = 0, int_Month, int_year, trans, GenMonth, FinanYear, Taxslab, ddlFYear;
        public  double Grand_Total = 0, TaxAmountYear = 0, TaxAmountMonth = 0, PaidAmount = 0, TaxSlabAmount = 0, MonTot, YearTot, PrvEmpTax = 0.00, PrsntEmpTax = 0.00;
        public  DateTime Dt_From, Dt_To, Dt_ITdate, Dt_Join, Dt_Date, DtEmp_Date, DtDateTime, CurDate;
        public  DataTable obj_dt_detail = new DataTable();
        public  DataTable obj_dt_Tax = new DataTable();
        public  DataTable dt_EmpDet = new DataTable();
        public  DataTable dt1 = new DataTable();
        public  decimal Sum_Gross;
        string DispYear, FinYear; string[] Fin_Year;

        DataTable dt_Emp = new DataTable();
        string EmpName; int EmpId;
        int j;
        bool bolerr;

        int k = 0;

        DateTime dt_Date1;
        DataTable dtable1 = new DataTable();
        string str_dispyear = "";
        int curfayear;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Clear);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_View);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            if (Session["StrTranType"] == null)
            {
                Session["StrTranType"] = "";
                Session["TransferType"] = "";
                crumbslabel.Attributes["class"] = "crumbslbl";
            }

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                string str_Uiid = "";
                str_Uiid = Request.QueryString["UIID"].ToString();
                Utility.Fn_CheckUserRights(str_Uiid, btn_Save, btn_View, null);
            }

            

            //}
            //else
            //    if (Session["StrTranType"] == null)
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //    }

            if (!IsPostBack)
            {


                if (Session["StrTranType"]!=null)
                {
                    if(Session["StrTranType"].ToString()=="HR")
                    {
                        btn_Save.Visible = true;

                    }
                    else
                    {
                        btn_Save.Visible = false;
                    }
                }
                else
                {
                    btn_Save.Visible = false;
                }
                if (Request.QueryString.ToString().Contains("profile"))
                {
                    crumbslabel.Attributes["class"] = "crumbslbl";
                    lnk_empcode1.Attributes["class"] = "empcodelinkl";
                    txt_Empcode.Enabled = false;
                    txt_Empcode.Text = Session["LoginUserName"].ToString();
                    txt_Empcode_TextChanged(sender, e);
                    lnk_empcode.Enabled = false;
                    trans = 0;
                    Fn_LoadYear();
                    Grd_IT.DataSource = new DataTable();
                    Grd_IT.DataBind();
                    Session["Packages"] = lbl_Header.Text;
                    int_Month = obj_da_Log.GetDate().Month;
                    int_year = obj_da_Log.GetDate().Year;
                    GenMonth = int_Month - 1;
                    BtnCompare.Visible = false;

                    /* if (int_Month > 4)
                     {
                         for (int i = 2012; i <= int_year; i++)
                         {
                             DispYear = Convert.ToString(i);
                         }
                     }
                     else
                     {
                         for (int i = 2012; i <= int_year-1; i++)
                         {
                             DispYear = Convert.ToString(i);
                         }
                     }

                     ddl_Year.SelectedIndex = ddl_Year.Items.Count-1;
                     FinYear = ddl_Year.SelectedItem.ToString();
                     Fin_Year = FinYear.Split('-');

                     for (int Count = 0; Count <= Fin_Year.Length - 2; Count++)
                     {
                         FYear = Convert.ToInt32(Fin_Year[Count]);
                     }
                     ddlFYear = FYear;*/

                    dt_Date1 = obj_da_Log.GetDate();
                    dtable1.Columns.Add("FAYear");
                   
                    if (dt_Date1.Month < 4)
                    {
                        for (int i = 2012; i <= dt_Date1.Year - 1; i++)
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
                        for (int i = 2012; i <= dt_Date1.Year; i++)
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
                        ddl_Year.DataSource = dtable1;
                        ddl_Year.DataTextField = "FAYear";
                        ddl_Year.DataBind();
                    }
                    else
                    {
                        ddl_Year.DataSource = dtable1;
                        ddl_Year.DataTextField = "FAYear";
                        ddl_Year.DataBind();
                    }
                    //ddlFYear = Convert.ToInt32(ddl_Year.Text.Substring(0, 4));

                    //btn_Clear.Text = "Back";
                    btn_Clear.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                    // GetDetails();
                    return;
                }


                if (Session["TransferType"] != null)
                {
                    dt_EmpDet = (DataTable)Session["EmpDet"];
                    trans = Convert.ToInt32(Session["TransferType"]);
                    int_Month = Convert.ToInt32(Session["CurMonth"]);
                    int_year = Convert.ToInt32(Session["CurYear"]);
                    GenMonth = Convert.ToInt32(Session["GetMontth"]);
                    FYear = Convert.ToInt32(Session["Fin_Year"]);
                    Dt_Date = Convert.ToDateTime(Session["dtDate"]);

                    for (int i = 0; i <= dt_EmpDet.Rows.Count - 1; i++)
                    {
                        trans = 2;
                        EmpName = dt_EmpDet.Rows[i]["username"].ToString();
                        EmpId = Convert.ToInt32(dt_EmpDet.Rows[i]["employeeid"].ToString());
                        dt_Emp = PayRolllDet.GetEmpDetails(EmpId);
                        int_Empid = EmpId;
                        GenMonth = int_Month;
                        btn_Get_Click(sender, e);
                        btn_Save_Click(sender, e);
                        Session["Wrk"] = "Details Updated";
                    }
                    Response.Redirect("../HRM/ProcessITComput.aspx");
                }

                BtnCompare.Visible = true;
                trans = 0;
                Fn_LoadYear();
                Grd_IT.DataSource = new DataTable();
                Grd_IT.DataBind();
                Session["Packages"] = lbl_Header.Text;
                int_Month = obj_da_Log.GetDate().Month;
                int_year = obj_da_Log.GetDate().Year;
                GenMonth = int_Month;

             /*   if (int_Month > 4)
                {
                    for (int i = 2012; i <= int_year; i++)
                    {
                        DispYear = Convert.ToString(i);
                    }
                }
                else
                {
                    for (int i = 2012; i <= int_year - 1; i++)
                    {
                        DispYear = Convert.ToString(i);
                    }
                }

                ddl_Year.SelectedIndex = ddl_Year.Items.Count - 2;
                FinYear = ddl_Year.SelectedItem.ToString();
                Fin_Year = FinYear.Split('-');

                for (int Count = 0; Count <= Fin_Year.Length - 2; Count++)
                {
                    FYear = Convert.ToInt32(Fin_Year[Count]);
                }
                ddlFYear = FYear;

                */

                dt_Date1 = obj_da_Log.GetDate();
              
                dtable1.Columns.Add("FAYear");
             
           
                if (dt_Date1.Month < 4)
                {
                    for (int i = 2012; i <= dt_Date1.Year - 1; i++)
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
                    for (int i = 2012; i <= dt_Date1.Year; i++)
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
                    ddl_Year.DataSource = dtable1;
                    ddl_Year.DataTextField = "FAYear";
                    ddl_Year.DataBind();
                }
                else
                {
                    ddl_Year.DataSource = dtable1;
                    ddl_Year.DataTextField = "FAYear";
                    ddl_Year.DataBind();
                }
               // ddlFYear = Convert.ToInt32(ddl_Year.Text.Substring(0, 4));

                txt_Empcode.Focus();
               
            }

            if (Session["empcode"] != null)
            {
                txt_Empcode.Text = Session["empcode"].ToString();
                txt_Empcode_TextChanged(sender, e);
                Session["empcode"] = null;
                //btn_Clear.Text = "Cancel";
                btn_Clear.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
            }

            //curfayear=Convert.ToInt32(Session["Loginyear"].ToString());

        }

        protected void lnk_empcode_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeFind.aspx");
        }

        protected void txt_Empcode_TextChanged(object sender, EventArgs e)
        {            
            if (txt_Empcode.Text.TrimEnd().Length != 4)
            {
                Fn_Clear();
            }

            int_Empid = obj_da_Employee.GetEmpId(txt_Empcode.Text);

            if (int_Empid != 0)
            {
                DataTable obj_dt = new DataTable();
                obj_dt = obj_da_Detail.GetEmpDetails(int_Empid);
                if (obj_dt.Rows.Count > 0)
                {
                    txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                    txt_Company.Text = obj_dt.Rows[0]["branchname"].ToString();
                    txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                    txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                    txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                    txt_DOJ.Text = string.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["doj"]);
                    hid_Title.Value = obj_dt.Rows[0]["title"].ToString();
                    //btn_Clear.Text = "Cancel";
                    btn_Clear.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    Fn_Clear();
                }
            }
            else
            {
                int_Empid = 0;
                Fn_Clear();
            }
        }

        private void Fn_Clear()
        {
            txt_Empcode.Text = "";
            txt_Name.Text = "";
            txt_Company.Text = "";
            txt_Dept.Text = "";
            txt_Desg.Text = "";
            txt_Grade.Text = "";
            txt_DOJ.Text = "";
            Grd_IT.DataSource = new DataTable();
            Grd_IT.DataBind();
            //btn_Clear.Text = "Back";
            btn_Clear.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            ddl_Year_SelectedIndexChanged(sender, e);
            if (trans == 2)
            {
                int_Empid = EmpId;
            }
            else
            {
                int_Empid = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            }

            if (trans == 2)
            {
                if (int_Empid != 0)
                {
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_Detail.GetEmpDetails(int_Empid);
                    if (obj_dt.Rows.Count > 0)
                    {
                        txt_Name.Text = obj_dt.Rows[0]["empname"].ToString();
                        txt_Company.Text = obj_dt.Rows[0]["branchname"].ToString();
                        txt_Dept.Text = obj_dt.Rows[0]["deptname"].ToString();
                        txt_Desg.Text = obj_dt.Rows[0]["designame"].ToString();
                        txt_Grade.Text = obj_dt.Rows[0]["grade"].ToString();
                        txt_DOJ.Text = string.Format("{0:dd/MM/yyyy}", obj_dt.Rows[0]["doj"]);
                        hid_Title.Value = obj_dt.Rows[0]["title"].ToString();
                        //btn_Clear.Text = "Cancel";
                        btn_Clear.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";
                        //Grd_IT.DataSource = new DataTable();
                        //Grd_IT.DataBind();
                    }
                }
                else
                {
                    Fn_Clear();
                    txt_Empcode.Focus();
                    return;
                }
                GetDetails();
                trans = 0;
                return;
            }
            else
            {
                //FinYear = ddl_Year.SelectedItem.ToString();
                //Fin_Year = FinYear.Split('-');

                //for (int Count = 0; Count <= Fin_Year.Length - 2; Count++)
                //{
                //    FYear = Convert.ToInt32(Fin_Year[Count]);
                //}  

                CheckData();

                if (bolerr == true)
                {
                    bolerr = false;
                    return;
                }

                if (ddlFYear < int_year)
                {

                    //HIDE 
                    //if (int_Month >= 4)
                    //{
                    //    int_Month = 3;
                    //    int_year = ddlFYear + 1;
                    //    GenMonth = 3;
                    //    Dt_Date = Convert.ToDateTime(GenMonth + "/05/" + int_year);
                    //}
                    //else
                    //{
                    //    int_Month = obj_da_Log.GetDate().Month;
                    //    int_year = obj_da_Log.GetDate().Year;
                    //    GenMonth = int_Month;
                    //    Dt_Date = Convert.ToDateTime(GenMonth + "/05/" + int_year);
                    //}

                    int_Month = 3;
                    int_year = ddlFYear + 1;
                    GenMonth = 3;
                    Dt_Date = Convert.ToDateTime(GenMonth + "/05/" + int_year);


                }
                else
                {
                    int_Month = obj_da_Log.GetDate().Month;
                    int_year = obj_da_Log.GetDate().Year;
                    GenMonth = int_Month;
                    Dt_Date = Convert.ToDateTime(GenMonth + "/05/" + int_year);
                }                
            }


            if (btn_Get.ToolTip == "Get")
            {
                GenMonth = int_Month;
                GetDetails();
            }
            //btn_Get.Text = "Get";
            btn_Get.ToolTip = "Get";
            btn_get1.Attributes["class"] = "btn btn-get1";
        }

        protected void CheckData()
        {
            if (ddl_Year.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Select Financial Year')", true);
                ddl_Year.Focus();
                return;
            }

            if (txt_Empcode.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Employee Code Cannot Be Blank')", true);
                bolerr = true;
                txt_Empcode.Focus();
                return;
            }
        }
        
    
        protected void GetDetails()
        {
            if (trans == 2)
            {
                int_Empid = EmpId;
            }
            else
            {
                int_Empid = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            }


            if (ddlFYear < int_year)
            {
                if (int_Month >= 4)
                {
                    int_Month = 3;
                    int_year = ddlFYear + 1;
                    GenMonth = 3;
                    Dt_Date = Convert.ToDateTime(GenMonth + "/05/" + int_year);
                }
                else
                {
                    int_Month = obj_da_Log.GetDate().Month;
                    int_year = obj_da_Log.GetDate().Year;
                    GenMonth = int_Month;
                    Dt_Date = Convert.ToDateTime(GenMonth + "/05/" + int_year);
                }
            }
            else
            {
                int_Month = obj_da_Log.GetDate().Month;
                int_year = obj_da_Log.GetDate().Year;
                GenMonth = int_Month;
                Dt_Date = Convert.ToDateTime(GenMonth + "/05/" + int_year);
            }
            
            if (int_Empid != 0)
            {
                DateTime Date = DateTime.Parse(Dt_Date.ToString("MM-dd-yyyy"));
                DateTime Time = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss"));

                DtDateTime = Date.Date + Time.TimeOfDay;
                Dt_ITdate = DateTime.Parse(Dt_Date.ToString("MM-dd-yyyy")).AddDays(-1);

                Dt_Join = DateTime.Parse(Utility.fn_ConvertDate(txt_DOJ.Text));

                if (Dt_Join > Dt_Date)
                {
                    ScriptManager.RegisterStartupScript(btn_Get, typeof(Button), "HRM", "alertify.alert('Selected Employee is not Join in this Date');", true);
                    txt_Empcode.Focus();
                    return;
                }
                
                Dt_From = Convert.ToDateTime("04/01/" + ddlFYear);
                Dt_To = Convert.ToDateTime("03/31/" + (ddlFYear + 1));

                int int_FYyear = 0;
               
                if (int_Month > 3)
                {
                    int_FYyear = int_year;
                }
                else
                {
                    int_FYyear = int_year - 1;
                }
                      
                obj_dt_detail = obj_da_IT.GetITDet(int_Empid, Dt_From, Dt_To, Dt_Date);
                obj_dt_Tax = obj_da_IT.GetITDet4TaxDebate(int_Empid, Dt_From);
             
                if (obj_dt_detail.Rows.Count > 0)
                {
                    //Fn_GetDetail(int_Month, int_FYyear);     

                    if (int_FYyear<2018)
                    {
                        Fn_GetDetail(int_Month, int_FYyear); 
                    }
                    else
                    {
                        Fn_GetDetailfromfy2018(int_Month, int_FYyear);     
                    }


                }
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 812, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/View");                            
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Get, typeof(Button), "HRM", "alertify.alert('Enter Valid Employee Code');", true);
                txt_Empcode.Focus();
            }
        }

        private void Fn_GetDetail(int int_Month, int int_FYyear)      
        {
            double medicalamt = 0, PayableAmount = 250000;
            double sum_Month, sum_Year;
                       
            if (int_Month > 3)
            {
                int_FYyear = int_year;
            }
            else
            {
                int_FYyear = int_year - 1;
            }
            
            DataTable obj_dt = new DataTable();
            obj_dt.Columns.Add("Particulars");
            obj_dt.Columns.Add("Monthly", typeof(double));
            obj_dt.Columns.Add("Yearly", typeof(double));
            
            string[] Str_item = { "Basic", "HRA", "Conveyance", "Special Allowance", "Medical", "LTA", "Bonus / Exgratia", "Incentives", "Motor Car", "Entertainment Allow", "Leave EnCashment", "Loss from House Property (Sec 24)", "Previous Employer Income", "Other Income", "Rent Free Accommodation", "Total Earnings (AA)", "Less Exemptions", "HRA (Sec 10(13))", "Actual HRA Received", "Rent Paid in excess of 10% Basic Salary", "50% or 40% of Basic Salary", "Whichever is least from the above", "HRA Excemption - (a)", "Conveyance (Sec (10(14)))", "Medical", "Professional Tax (Sec 16(III))" };
            //string[] Str_GridItem = { "BASIC", "HRA", "CONVEYANCE", "SPALLOW", "MEDICAL", "LTA", "BONUS", "INCENTIVE", "DWAGES", "EALLOW", "LeaveEncashment", "Medical_Claim" };
              
            //Karthika_K

            string[] Str_GridItem = { "BASIC", "HRA", "CONVEYANCE", "SPALLOW", "MEDICAL", "LTA", "BONUS", "INCENTIVE", "DWAGES", "EALLOW", "LeaveEncashment", "Medical_Claim" };
            
            DataRow dr;
            DataTable dt = new DataTable();

            foreach (string str_temp in Str_item)
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = str_temp;
            }

            for (int i = 0; i <= Str_GridItem.Length - 1; i++)
            {
                var Result = obj_dt_detail.AsEnumerable().Where(row => row.Field<string>("HeaderName") == Str_GridItem[i]).ToList();

                if (Result.Count > 0)
                {
                    obj_dt.Rows[i][1] = Result[0]["Monthly"];
                    obj_dt.Rows[i][2] = Result[0]["Yearly"];                   
                }
                else
                {
                    obj_dt.Rows[i][1] = 0;
                    obj_dt.Rows[i][2] = 0;
                }

                if (Str_GridItem[i] == "MEDICAL")
                {
                    medicalamt = Convert.ToDouble(obj_dt.Rows[i][2].ToString());
                }

                if (Str_GridItem[i] == "BONUS")
                {
                    obj_dt.Rows[i][1] = 0;
                    obj_dt.Rows[i][2] = obj_da_IT.GetHRITBnsAmt(int_Empid, int_FYyear).ToString();
                }

                if (Str_GridItem[i] == "Less Exemptions" || Str_GridItem[i] == "HRA (Sec 10(13))")
                {
                    if (obj_dt.Rows[i][1].ToString() == (0.00).ToString())
                    {
                        
                    }
                    if (obj_dt.Rows[i][1].ToString() == (0.00).ToString())
                    {

                    }                  
                }
            }

            dt1 = obj_da_Rent.GetHouseRent(int_Empid, int_FYyear);

            obj_dt.Rows[11][1] = 0;
            obj_dt.Rows[12][1] = 0;
            obj_dt.Rows[13][1] = 0;
            obj_dt.Rows[14][1] = 0;

            obj_dt.Rows[11][2] = 0;
            obj_dt.Rows[12][2] = 0;
            obj_dt.Rows[13][2] = 0;
            obj_dt.Rows[14][2] = 0;

            string[] ArrList = {"House Rent Received PerAnnum", "Other Income", "Previous Employer Income", "Rent Free Accommodation" };

            for (int i = 0; i <= ArrList.Length - 1; i++)
            {
                var Data = dt1.AsEnumerable().Where(row => row.Field<string>("otherincome") == ArrList[i]).ToList();

                if (Data.Count > 0)
                {
                    if (ArrList[i] == "House Rent Received PerAnnum")
                    {
                        obj_dt.Rows[11][2] = Data[0]["income"];
                    }
                    if (ArrList[i] == "Previous Employer Income")
                    {
                        obj_dt.Rows[12][2] = Data[0]["income"];
                    }
                    if (ArrList[i] == "Other Income")
                    {
                        obj_dt.Rows[13][2] = Data[0]["income"];
                    }
                    if (ArrList[i] == "Rent Free Accommodation")
                    {
                        obj_dt.Rows[14][2] = Data[0]["income"];
                    }
                }
            }

            for (int k = 0; k <= 14; k++)
            {
                MonTot = Convert.ToDouble(obj_dt.Compute("Sum([Monthly])", string.Empty));
                YearTot = Convert.ToDouble(obj_dt.Compute("Sum([Yearly])", string.Empty));
            }

            double Mcrossptax = MonTot;

            sum_Month = Convert.ToDouble(obj_dt.Compute("sum(Monthly)", string.Empty));
            sum_Year = Convert.ToDouble(obj_dt.Compute("sum(Yearly)", string.Empty));

            obj_dt.Rows[15][1] = sum_Month;
            obj_dt.Rows[15][2] = sum_Year;           
            
            //---------------------------------------------TAX CALCULATION--------------------------------------------------------------------------------------------------

            //----------HRA--------------------------------

            string[] Str_HRA = { "LESSHRAACT", "LESSHRA10", "LESSHRA50", "LESSHRA", "LESSHRA", "CONVEYANCE", "MEDICAL" };

            //Sum_Gross = obj_dt_detail.AsEnumerable().Where(row => (String)row["HeaderName"] == "BASIC" || (String)row["HeaderName"] == "HRA" || (String)row["HeaderName"] == "CONVEYANCE" || (String)row["HeaderName"] == "SPALLOW" || (String)row["HeaderName"] == "EALLOW" || (String)row["HeaderName"] == "LeaveEncashment" || (String)row["HeaderName"] == "Medical_Claim").Sum(row => row.Field<decimal>("Yearly"));                   

            double Total = 0, Total_80C = 0, MaxAmount = 0, ExTotal = 0;
            int j = 17;
            for (int i = 0; i <= Str_HRA.Length - 1; i++)
            {
                j++;
                var Result = obj_dt_detail.AsEnumerable().Where(row => row.Field<string>("HeaderName") == Str_HRA[i]).ToList();
                if (Result.Count > 0)
                {
                    obj_dt.Rows[j][2] = Result[0]["Yearly"];

                    if (Str_HRA[i] == "CONVEYANCE")
                    {
                        Total = Total + double.Parse(obj_dt.Rows[j][2].ToString());
                    }

                    if (Str_HRA[i] == "MEDICAL")
                    {
                        dt = obj_da_IT.GetMedicalIT(int_Empid, Dt_From, Dt_To, Dt_Date);

                        if (dt.Rows.Count > 0)
                        {
                            string amt = dt.Rows[0][2].ToString();
                            double total = Convert.ToDouble(amt);

                            if (dt.Rows[0]["proof"].ToString() == "N")
                            {
                                if (medicalamt < total)
                                {
                                    obj_dt.Rows[j][2] = medicalamt.ToString("#0.00");
                                    Total = Total + medicalamt;
                                }
                                else
                                {
                                    obj_dt.Rows[j][2] = dt.Rows[0][2].ToString();
                                    double tot = Convert.ToDouble(dt.Rows[0][2].ToString());
                                    Total = Total + tot;
                                }
                            }
                            else if ((dt.Rows[0]["proof"].ToString() == "Y"))
                            {
                                if (medicalamt < total)
                                {
                                    obj_dt.Rows[j][2] = medicalamt.ToString("#0.00");
                                    Total = Total + medicalamt;
                                }
                                else
                                {
                                    obj_dt.Rows[j][2] = dt.Rows[0][2].ToString();
                                    double tot = Convert.ToDouble(dt.Rows[0][2].ToString());
                                    Total = Total + tot;
                                }
                            }
                        }
                    }
                }
                else
                {
                    obj_dt.Rows[j][2] = 0;
                }

                if (Str_HRA[i] == "LESSHRA")
                {
                    ExTotal = ExTotal + double.Parse(obj_dt.Rows[j][2].ToString());
                }
            }

            ExTotal = ExTotal / 2;                 
            double proftaxAmt = 0.00;
            obj_dt.Rows[25][2] = obj_da_IT.GetHRITProfTaxAmt(int_Empid, Mcrossptax, int_FYyear);
            Total = Total + double.Parse(obj_dt.Rows[25][2].ToString());                  
            
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total (b)";
            dr[2] = Total;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Tax Rebate & Relief u/s 80C";
            obj_dt_Tax = obj_da_IT.GetITComp4TaxDebateNew(int_Empid, Dt_From, "80C");

            if (obj_dt_Tax.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt_Tax.Rows.Count - 1; i++)
                {
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = obj_dt_Tax.Rows[i]["investplan"].ToString();
                    dr[2] = obj_dt_Tax.Rows[i]["investamt"].ToString();
                    Total_80C = Total_80C + double.Parse(obj_dt_Tax.Rows[i]["investamt"].ToString());
                    MaxAmount = MaxAmount + double.Parse(obj_dt_Tax.Rows[i]["maxlimit"].ToString());
                }
            }

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);

            dr[0] = "Total";
            dr[2] = Total_80C;

            //Total_80C = Total_80C > MaxAmount ? MaxAmount : Total_80C;
            //Total = Total + Total_80C;

            if (Total_80C > MaxAmount)
            {
                Total_80C = MaxAmount;
            }
            Total = Total + Total_80C;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total Tax Rebate u/s 80C - (C)";
            dr[2] = Total_80C;
            ExTotal = ExTotal + Total;
            
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Deduction under Chapter VIA";
            obj_dt_Tax = obj_da_IT.GetITComp4TaxDebateNew(int_Empid, Dt_From, "80");
            Total = 0;

            for (int i = 0; i <= obj_dt_Tax.Rows.Count - 1; i++)
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = obj_dt_Tax.Rows[i]["secname"].ToString() + "-" + obj_dt_Tax.Rows[i]["seccode"].ToString();
                dr[2] = obj_dt_Tax.Rows[i]["investamt"].ToString();
                Total = Total + double.Parse(obj_dt_Tax.Rows[i]["investamt"].ToString());
            }

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total Deduction under Chapter VIA - (d)";
            dr[2] = Total;

            ExTotal = ExTotal + Total;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total Exemption (a+b+c+d) (BB)";
            dr[2] = ExTotal;

            Taxslab = Convert.ToInt32(sum_Year) - Convert.ToInt32(ExTotal);
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Taxable Income (AA - BB)";
            dr[2] = Taxslab;

            //-----------------------------------------------------TAX SLAB RATE----------------------------------------------------------------------------------------------

            TaxSlabAmount = Taxslab;
            Double examt = 0.0;
            string strexamt = "";
            if (hid_Title.Value.ToString() == "Mr")
            {
                dt = obj_da_IT.GetITDet4TaxSlabto('M', Dt_To);
            }
            else
            {
                dt = obj_da_IT.GetITDet4TaxSlabto('F', Dt_To);
            }

            double Tax_Amount = 0,  TotalPayment = 0, Total_Tax = 0;
            Total = 0;
            if (dt.Rows.Count > 0)
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Slab Rate ";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string Value1 = dt.Rows[i]["slabfrom"].ToString().Replace(".0000", "");
                    string value2 = dt.Rows[i]["slabto"].ToString().Replace(".0000", "");

                    if (TaxSlabAmount >= double.Parse(Value1) && TaxSlabAmount <= double.Parse(value2))
                    {
                        string TaxValue = dt.Rows[i]["taxpercent"].ToString().Replace(".0000", "");

                        Tax_Amount = TaxSlabAmount - (double.Parse(Value1) - 1);
                        Total = Total + ((Tax_Amount * double.Parse(TaxValue)) / 100);
                        TaxSlabAmount = TaxSlabAmount - Tax_Amount;

                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = Value1 + " - " + value2 + "(" + Tax_Amount + ")";
                        dr[2] = ((Tax_Amount * double.Parse(TaxValue)) / 100);
                    }
                }

                Total = Math.Round(Total);
                Grand_Total = Total;

                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "0  - " + PayableAmount + "(" + PayableAmount + ")";
                dr[2] = 0;
            }

            if ((Convert.ToDouble(sum_Year.ToString()) - ExTotal) < PayableAmount)
            {
                TotalPayment = 0.0;
            }
            else
            {
                TotalPayment = (Convert.ToDouble(sum_Year.ToString()) - ExTotal) - PayableAmount;
            }

            string Exmp = "";

           //HIDE DINESH

            //if (Taxslab >= 250001 && Taxslab <= 500000)
            //{
            //    Exmp = "Y";
            //}


            if (int_FYyear < 2016)
            {
                if (Taxslab >= 250001 && Taxslab <= 500000)
                {
                    Exmp = "Y";
                    examt = 2000;
                    strexamt = "2000";
                }

            }
            else if (int_FYyear == 2016)
            {
                if (Taxslab >= 250001 && Taxslab <= 500000)
                {
                    Exmp = "Y";
                    examt = 5000;
                    strexamt = "5000";
                }
            }
            else
            {
                if (Taxslab >= 250001 && Taxslab <= 350000)
                {
                    Exmp = "Y";
                    examt = 2500;
                    strexamt = "2500";
                }
            }


            //------------------------Tax Amount--------------------------

            if (Exmp == "Y")
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount - Total";
                dr[2] = Total;

                //------------------------Excemption--------------------------

                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Excemption";
                //dr[2] = -2000;

                dr[2] = -examt;

                //------------------------Edu Chess--------------------------

                //double SubTotal = Convert.ToInt16(Total) - 2000;
                double SubTotal = Convert.ToInt16(Total) - examt;
                double EduAmnt;
                if (int_FYyear > 2017)
                {
                    EduAmnt = Math.Round(SubTotal * 4 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (4%)";
                    dr[2] = EduAmnt;
                }
                else
                {
                    EduAmnt = Math.Round(SubTotal * 3 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (3%)";
                    dr[2] = EduAmnt;
                }
                //Total_Tax = Total + EduAmnt - 2000;
                Total_Tax = Total + EduAmnt - examt; 
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount";
                dr[2] = Total_Tax;
            }

            // Checking

            if (Exmp != "Y")
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount - Total";
                dr[2] = Total;

                //------------------------Edu Chess--------------------------

                double EduAmount ;
                if (int_FYyear > 2017)
                {
                    EduAmount = Math.Round(Total * 4 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (4%)";
                    dr[2] = EduAmount;
                }
                else
                {
                    EduAmount = Math.Round(Total * 3 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (3%)";
                    dr[2] = EduAmount;
                }
                Total_Tax = Total + EduAmount;
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount";
                dr[2] = Total_Tax;
            }

            PaidAmount = obj_da_IT.GetHRITAmt(int_Month, int_year, int_Empid);
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Tax Paid";
            dr[2] = PaidAmount;

            TaxAmountYear = 0;
            TaxAmountYear = Total - PaidAmount;

            DateTime Date_From, Date_To;

            if (int_Month > 4)
            {
                Date_From = DateTime.Parse(int_Month + "/01/" + int_year.ToString());
                Date_To = DateTime.Parse("03/31/" + (int_year + 1).ToString());
            }
            else
            {
                Date_From = DateTime.Parse(int_Month + "/01/" + int_year.ToString());
                Date_To = DateTime.Parse("03/31/" + int_year.ToString());
            }
            int int_MonthDiff = (Date_To.Month - Date_From.Month) + 12 * (Date_To.Year - Date_From.Year) + 1; ;

            TaxAmountYear = Total_Tax - PaidAmount;

            TaxAmountMonth = 0;
            TaxAmountMonth = Math.Round(TaxAmountYear / int_MonthDiff);

            if (TaxAmountMonth < 0)
            {
                TaxAmountMonth = 0;
            }

            PrvEmpTax = obj_da_IT.GetHRITAmtPrvEmpInco(int_Month, int_year, int_Empid);
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Previous Emp Tax Paid";
            dr[2] = PrvEmpTax;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Present Emp Tax Paid";
            if (PrvEmpTax != 0)
            {
                dr[2] = PaidAmount - PrvEmpTax;
            }
            else
            {
                dr[2] = "0.00";
            }

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Taxable Amount Per Month";
            dr[2] = TaxAmountMonth;

            Grd_IT.DataSource = obj_dt;
            Grd_IT.DataBind();

            obj_dt.Dispose();
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            double Taxpay = 0, Amount = 0, TaxPerMonth;

            if (trans == 2)
            {
                int_Empid = EmpId;
            }
            else
            {
                int_Empid = obj_da_Employee.GetEmpId(txt_Empcode.Text);
            }

            if (txt_Empcode.Text.TrimEnd().Length > 0 && int_Empid != 0)
            {
                DataTable obj_dt = new DataTable();

                if (Grd_IT.Rows.Count > 0)
                {
                    obj_dt = obj_da_IT.SelITTaxDetect(int_Empid, Dt_From, Dt_ITdate);
                    if (obj_dt.Rows.Count > 0)
                    {
                        Amount = double.Parse(obj_dt.Rows[0]["TAXDetect"].ToString());
                        Taxpay = Grand_Total - Amount;
                    }

                    int Month = 0;
                    Month = ((Dt_To.Year - Dt_ITdate.Year) * 12) + (Dt_To.Month - Dt_ITdate.Month);

                    if (Month <= 0)
                    {
                        Month = 1;
                    }

                    TaxPerMonth = Taxpay / Month;

                    obj_da_IT.SveITComp(int_Empid, DtDateTime, Taxslab, Grand_Total, PaidAmount, TaxAmountYear, TaxAmountMonth);
                    obj_da_IT.SveITProfTax(double.Parse(Grd_IT.Rows[19].Cells[2].Text.ToString()));

                    obj_da_IT.SveITComDedDet(Grd_IT.Rows[6].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[6].Cells[2].Text.ToString()));
                    obj_da_IT.SveITComDedDet(Grd_IT.Rows[7].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[7].Cells[2].Text.ToString()));
                    obj_da_IT.SveITComDedDet(Grd_IT.Rows[9].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[9].Cells[2].Text.ToString()));
                    obj_da_IT.SveITComDedDet(Grd_IT.Rows[15].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[15].Cells[2].Text.ToString()));

                    if (Grd_IT.Rows[17].Cells[2].Text.ToString().Length > 0)
                    {
                        obj_da_IT.SveITComDedDet(Grd_IT.Rows[17].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[17].Cells[2].Text.ToString()));
                    }

                    obj_da_IT.SveITComDedDet(Grd_IT.Rows[20].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[20].Cells[2].Text.ToString()));
                    obj_da_IT.SveITComDedDet(Grd_IT.Rows[21].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[21].Cells[2].Text.ToString()));
                    obj_da_IT.SveITComDedDet(Grd_IT.Rows[22].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[22].Cells[2].Text.ToString()));

                    for (int i = 0; i <= obj_dt_Tax.Rows.Count - 1; i++)
                    {
                        obj_da_IT.SveITCompExcemDet(int.Parse(obj_dt_Tax.Rows[i]["secid"].ToString()), obj_dt_Tax.Rows[i]["secname"].ToString(), double.Parse(obj_dt_Tax.Rows[i]["investamt"].ToString()));
                    }

                    for (int i = 0; i <= 13; i++)
                    {
                        if (Grd_IT.Rows[i].Cells[2].Text != "0.00")
                        {
                            obj_da_IT.SveITComIncDet(Grd_IT.Rows[i].Cells[0].Text.ToString(), double.Parse(Grd_IT.Rows[i].Cells[2].Text.ToString()));
                        }
                    }

                    DateTime Dt_Currentdate = obj_da_Log.GetDate();
                    double Monthly, Yearly;

                    for (int i = 0; i <= Grd_IT.Rows.Count - 1; i++)
                    {
                        Monthly = Grd_IT.Rows[i].Cells[1].Text.Length == 0 ? 0 : double.Parse(Grd_IT.Rows[i].Cells[1].Text);
                        Yearly = Grd_IT.Rows[i].Cells[2].Text.Length == 0 ? 0 : double.Parse(Grd_IT.Rows[i].Cells[2].Text);
                        obj_da_IT.SveHRITComputation(int_Empid, Dt_Currentdate, Grd_IT.Rows[i].Cells[0].Text, Monthly, Yearly, Fn_GetTitle(Grd_IT.Rows[i].Cells[0].Text), ddlFYear);
                    }

                    if (trans != 2)
                    {
                        ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('Details Updated')", true);
                    }
                    
                    obj_dt.Dispose();
                    Fn_Clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_Save, typeof(Button), "HRM", "alertify.alert('No Rows to Insert')", true);
                }
                trans = 0;
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 812, 1, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "Save");  

            }
        }

        private char Fn_GetTitle(string Str_HeaderValue)
        {
            Str_HeaderValue = Str_HeaderValue.Replace("&amp;", "&");
            char Header;
            if ((Str_HeaderValue == "Basic") || (Str_HeaderValue == "HRA") || (Str_HeaderValue == "Conveyance") || (Str_HeaderValue == "Special Allowance")
                || (Str_HeaderValue == "Medical") || (Str_HeaderValue == "LTA") || (Str_HeaderValue == "Bonus / Exgratia") || (Str_HeaderValue == "Incentives")
                || (Str_HeaderValue == "Motor Car") || (Str_HeaderValue == "Entertainment Allow") || (Str_HeaderValue == "Leave EnCashment") || (Str_HeaderValue == "Medical-Claim")
                || (Str_HeaderValue == "Conveyance (Sec (10(14)))") || (Str_HeaderValue == "Medical") || (Str_HeaderValue == "Professional Tax (Sec 16(III))")
                || (Str_HeaderValue == "Loss from House Property (Sec 24)") || (Str_HeaderValue == "Conveyance (Sec (10(14)))") || (Str_HeaderValue == "Professional Tax (Sec 16(III))")
                || (Str_HeaderValue == "Loss from House Property (Sec 24)"))
            {
                Header = 'L';
            }
            else if ((Str_HeaderValue == "Total Earnings (AA)") || (Str_HeaderValue == "HRA Excemption - (a)") || (Str_HeaderValue == "Total (b)")
                        || (Str_HeaderValue == "Total Tax Rebate u/s 80C - (C)") || (Str_HeaderValue == "Total Deduction under Chapter VIA - (d)")
                        || (Str_HeaderValue == "Total Exemption (a+b+c+d) (BB)") || (Str_HeaderValue == "Total Exemption (a+b+c+d) (BB)")
                        || (Str_HeaderValue == "Taxable Income (AA - BB)") || (Str_HeaderValue == "Tax Amount - Total") || (Str_HeaderValue == "Edu Chess - (3%)")
                        || (Str_HeaderValue == "Tax Amount") || (Str_HeaderValue == "Tax Paid") || (Str_HeaderValue == "Taxable Amount Per Month"))
            {
                Header = 'R';
            }
            else if ((Str_HeaderValue == "Less Exemptions") || (Str_HeaderValue == "Tax Slab Rate "))
            {
                Header = 'H';
            }
            else if ((Str_HeaderValue == "HRA (Sec 10(13))"))
            {
                Header = 'C';
            }
            else if ((Str_HeaderValue == " Actual HRA Received") || (Str_HeaderValue == "Rent Paid in excess of 10% Basic Salary") || (Str_HeaderValue == "50% or 40% of Basic Salary")
                        || (Str_HeaderValue == "Whichever is least from the above") || (Str_HeaderValue == "PF"))
            {
                Header = 'S';
            }
            else if ((Str_HeaderValue == "Tax Rebate & Relief u/s 80C") || (Str_HeaderValue == "Deduction under Chapter VIA"))
            {
                Header = 'C';
            }
            else
            {
                Header = 'S';
            }

            return Header;
        }

        protected void btn_View_Click(object sender, EventArgs e)
        {
           /* string Str_sp = "", Str_sf = "", Str_RptName = "", Str_Script = "";
            Session["str_sfs"] = ""; Session["str_sp"] = "";

            if (txt_Empcode.Text.TrimEnd().Length > 0)
            {
                Str_RptName = "/Payroll/" + "NewHRITCompDtls.rpt";
                if (int_year > ddlFYear)
                {
                    Session["str_sfs"]= "{HRITComputation.empid}=" + int_Empid + " and Month({HRITComputation.logindate})= " + GenMonth + " and Year({HRITComputation.logindate})= " + int_year + " ";
                }
                else
                {
                    DataTable dtRpt = new DataTable();
                    dtRpt = obj_da_IT.Get_PreYear_ITComputationDtls(int_Empid, ddlFYear);
                    if (dtRpt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtRpt.Rows[0][0].ToString()))
                        {
                        DateTime MaxDate;
                        MaxDate = Convert.ToDateTime(dtRpt.Rows[0][0].ToString());
                        Session["str_sfs"]= "{HRITComputation.empid}=" + int_Empid + " and Month({HRITComputation.logindate})= " + MaxDate.Month + " and Year({HRITComputation.logindate})= " + MaxDate.Year + " ";
                        }
                    }
                }

            }

            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_sf + "&Parameter=" + Str_sp + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
            ScriptManager.RegisterStartupScript(btn_View, typeof(Button), "HRM", Str_Script, true);
            obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 812,3, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/View");  
            */


            try
            {
                int_Month = obj_da_Log.GetDate().Month;
                int_year = obj_da_Log.GetDate().Year;
                GenMonth = int_Month;


                ddl_Year_SelectedIndexChanged(sender, e);
                ExportGridToPDF();
                obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 812, 3, int.Parse(Session["LoginBranchid"].ToString()), txt_Empcode.Text + "/View"); 
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            } 
        }

        protected void Grd_IT_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if (e.Row.RowIndex == 15 || e.Row.Cells[0].Text == "Total Exemption (a+b+c+d) (BB)" || e.Row.Cells[0].Text == "Taxable Income (AA - BB)" || e.Row.Cells[0].Text == "Tax Amount - Total" || e.Row.Cells[0].Text == "Excemption" || e.Row.Cells[0].Text == "Edu Chess - (3%)")
                {                  
                    e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[0].Attributes.CssStyle["text-align"] = "Right";
                }
                else if (e.Row.Cells[0].Text.TrimEnd() == "HRA (Sec 10(13))" || e.Row.Cells[0].Text.Replace("&amp;", "&") == "Tax Rebate & Relief u/s 80C" || e.Row.Cells[0].Text == "Deduction under Chapter VIA")
                {
                    e.Row.CssClass = "GrdTitle";
                }
                else if (e.Row.RowIndex == 22 || e.Row.RowIndex == 26 || e.Row.RowIndex == 30 || e.Row.RowIndex == 31 || e.Row.Cells[0].Text == "Total Deduction under Chapter VIA - (d)" || e.Row.Cells[0].Text == "Tax Amount" || e.Row.Cells[0].Text == "Tax Paid" || e.Row.Cells[0].Text == "Previous Emp Tax Paid" || e.Row.Cells[0].Text == "Present Emp Tax Paid" || e.Row.Cells[0].Text == "Taxable Amount Per Month")
                {
                    if (e.Row.Cells[0].Text == "Tax Amount" || e.Row.Cells[0].Text == "Tax Paid" || e.Row.Cells[0].Text == "Previous Emp Tax Paid" || e.Row.Cells[0].Text == "Present Emp Tax Paid" || e.Row.Cells[0].Text == "Taxable Amount Per Month")
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Blue;
                        e.Row.Cells[1].ForeColor = System.Drawing.Color.Blue;
                        e.Row.Cells[2].ForeColor = System.Drawing.Color.Blue;
                        e.Row.Cells[0].Attributes.CssStyle["text-align"] = "Right";
                    }
                    else
                    {
                        e.Row.Cells[0].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
               
                else if (e.Row.RowIndex == 16)
                {
                    e.Row.CssClass = "GrdLess";
                }
            }
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"] == "HR")
            {
                if (btn_Clear.ToolTip == "Cancel")
                {
                    if (Request.QueryString.ToString().Contains("profile"))
                    {

                    }
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
                if (btn_Clear.ToolTip == "Cancel")
                {
                    if (Request.QueryString.ToString().Contains("profile"))
                    {

                    }
                    Fn_Clear();
                }
                else
                {
                    Response.Redirect("../Home/Profile.aspx");
                }
            }
        }

        public void Fn_LoadYear()
        {
            //DateTime Dt_Date = obj_da_Log.GetDate();
            //ddl_Year.Items.Clear();
            //for (int i = 2012; i <= Dt_Date.Year-1; i++)
            //{
            //    ddl_Year.Items.Add(new ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
            //}
            //if (Dt_Date.Month > 4)
            //{
            //    ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.Year.ToString()));
            //}
            //else
            //{
            //    ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(Dt_Date.AddYears(-1).Year.ToString()));
            //}     

            DateTime Dt_Date = obj_da_Log.GetDate();
            ddl_Year.Items.Clear();
            //for (int i = Dt_Date.AddYears(-1).Year; i <= Dt_Date.Year; i++)
            for (int i = 2012; i <= Dt_Date.Year; i++)
            {
                ddl_Year.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString() + "-" + (i + 1).ToString(), i.ToString()));
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

        protected void BtnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridData();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void BindGridData()
        {
            int count1 = 0, count2 = 0;
            int i;
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dtTemp = new DataTable();
                DataRow dtrow;

                //  ds = obj_da_IT.GetComparisionofITComputation(int_Empid);              
                ds = obj_da_IT.GetComparisionofITCompu(int_Empid);
                dt = ds.Tables[0];
                dt1 = ds.Tables[1];
                dt2 = ds.Tables[2];

                Panel3.Visible = true;
                this.programmaticModalCancelCredit.Show();
                GVCmpre.Visible = true;

                count1 = dt.Rows.Count;
                count2 = dt1.Rows.Count;

                if (count1 > count2)
                {
                    dtTemp.Columns.Add("Particulars");
                    dtTemp.Columns.Add("CurMonth", typeof(double));
                    dtTemp.Columns.Add("Parti");
                    dtTemp.Columns.Add("PreMonth", typeof(double));
                }
                else
                {
                    dtTemp.Columns.Add("Particulars");
                    dtTemp.Columns.Add("CurMonth", typeof(double));
                    dtTemp.Columns.Add("Parti");
                    dtTemp.Columns.Add("PreMonth", typeof(double));
                }
              
                for (int j = 0; j <= dt.Rows.Count - 1; j++)
                {                  
                    dtTemp.Rows.Add();
                    dtTemp.Rows[j]["Particulars"] = dt.Rows[j][0].ToString();
                    dtTemp.Rows[j]["CurMonth"] = string.Format("{0:0.00}", dt.Rows[j][1].ToString());
                }
                for (int l = 0; l <= dt1.Rows.Count - 1; l++)
                {                   
                    dtTemp.Rows[l]["Parti"] = dt1.Rows[l][0].ToString();
                    dtTemp.Rows[l]["PreMonth"] = string.Format("{0:0.00}", dt1.Rows[l][1].ToString());
                }               

                GVCmpre.DataSource = dtTemp;
                GVCmpre.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void GVCmpre_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCmpre.PageIndex = e.NewPageIndex;
            BindGridData();
        }





        private void ExportGridToPDF()
        {

            /*Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Events.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            DataTable dt = new DataTable();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

           //// Grd_IT.AllowPaging = false;
           // dt = (DataTable)ViewState["obj_dt"];
           // Grd_IT.DataSource = dt;
           // Grd_IT.DataBind();


            Grd_IT.RenderControl(hw);
            Grd_IT.HeaderRow.Style.Add("width", "5%");
            Grd_IT.HeaderRow.Style.Add("font-size", "10px");
            Grd_IT.Style.Add("text-decoration", "none");
            Grd_IT.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            Grd_IT.Style.Add("font-size", "8pt");
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();*/


            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {


                    /*iTextSharp.text.Table table = new iTextSharp.text

                 .Table(Grd_IT.Columns.Count);

                    table.Cellpadding = 5;



                    //Set the column widths

                    int[] widths = new int[Grd_IT.Columns.Count];

                    for (int x = 0; x < Grd_IT.Columns.Count; x++)
                    {

                        widths[x] = (int)Grd_IT.Columns[x].ItemStyle.Width.Value;

                        string cellText = Server.HtmlDecode(Grd_IT.HeaderRow.Cells[x].Text);

                        iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);

                        cell.BackgroundColor = new Color(System

                                           .Drawing.ColorTranslator.FromHtml("#008000"));

                        table.AddCell(cell);

                    }

                    table.SetWidths(widths);



                    //Transfer rows from GridView to table

                    for (int i = 0; i < Grd_IT.Rows.Count; i++)
                    {

                        if (Grd_IT.Rows[i].RowType == DataControlRowType.DataRow)
                        {

                            for (int j = 0; j < Grd_IT.Columns.Count; j++)
                            {

                                string cellText = Server.HtmlDecode

                                                  (Grd_IT.Rows[i].Cells[j].Text);

                                iTextSharp.text.Cell cell = new iTextSharp.text.Cell(cellText);



                                //Set Color of Alternating row

                                if (i % 2 != 0)
                                {

                                    cell.BackgroundColor = new Color(System.Drawing

                                                        .ColorTranslator.FromHtml("#C2D69B"));

                                }

                                table.AddCell(cell);

                            }

                        }

                    }
 
                    */
                    //To Export all pages
                    ddlFYear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));
                    Grd_IT.AllowPaging = false;

                    this.GetDetails();
                    string Filename = Session["LoginDivisionName"].ToString();

                    Grd_IT.RenderControl(hw);
                    //Grd_IT.HeaderRow.Style.Add("width", "35%");
                    //Grd_IT.HeaderRow.Style.Add("font-size", "12px");
                    //Grd_IT.Style.Add("text-decoration", "none");
                    //Grd_IT.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
                    //Grd_IT.Style.Add("font-size", "10pt");
                    //Grd_IT.Columns[1].ItemStyle.Width = 500;
                    //Grd_IT.Columns[1].HeaderStyle.Wrap = false;
                    //Grd_IT.Columns[1].FooterStyle.Wrap = false;


                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 20f, 40f);


                    string year1 = ddl_Year.SelectedItem.ToString();


                    // Document pdfDoc = new Document(PageSize.A2, 25f, 25f, 25f, 25f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    Paragraph para = new Paragraph(Filename, new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12));
                    Paragraph para1 = new Paragraph(Session["LoginBranchName"].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.BOLD, 12));
                    Paragraph para2 = new Paragraph("Employee Name :" + Session["LoginEmpName"].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10));
                    Paragraph para4 = new Paragraph("Employee Code :" + Session["LoginUserName"].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10));
                    Paragraph para5 = new Paragraph("Year :" + year1, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 10));
                    Paragraph para3 = new Paragraph(" ", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));

                    //Chunk glue = new Chunk(new VerticalPositionMark());
                    //Phrase ph1 = new Phrase();
                    //ph1.Add(new Chunk(Environment.NewLine));
                    //string projectname = "Project Name: " + dr["ProjectName"].ToString();
                    //string date = dr["StartDate"].ToString() + "-" + dr["EndDate"].ToString();
                    //Paragraph main = new Paragraph();
                    //ph1.Add(new Chunk(projectname)); // Here I add projectname as a chunk into Phrase.    
                    //ph1.Add(glue); // Here I add special chunk to the same phrase.    
                    //ph1.Add(new Chunk('(' + date + ')')); // Here I add date as a chunk into same phrase.    
                    //main.Add(ph1);    

                    para.Alignment = Element.ALIGN_CENTER;
                    para1.Alignment = Element.ALIGN_CENTER;
                    para5.Alignment = Element.ALIGN_RIGHT;
                    pdfDoc.Add(para);
                    pdfDoc.Add(para1);
                    pdfDoc.Add(para4);
                    pdfDoc.Add(para5);
                    pdfDoc.Add(para2);
                    pdfDoc.Add(para3);
                    /*for (int i = 0; i < 10; i++)
                    {
                        
                    }*/

                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
       



        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFYear = Convert.ToInt32(ddl_Year.SelectedItem.ToString().Substring(0, 4));
           
        }




        private void Fn_GetDetailfromfy2018(int int_Month, int int_FYyear)
        {
            double medicalamt = 0, PayableAmount = 250000;
            double sum_Month, sum_Year;
            double sd, Total=0;
            if (int_Month > 3)
            {
                int_FYyear = int_year;
            }
            else
            {
                int_FYyear = int_year - 1;
            }

            DataTable obj_dt = new DataTable();
            obj_dt.Columns.Add("Particulars");
            obj_dt.Columns.Add("Monthly", typeof(double));
            obj_dt.Columns.Add("Yearly", typeof(double));

            string[] Str_item = { "Basic", "HRA", "Conveyance", "Special Allowance", "Medical", "LTA", "Bonus / Exgratia", "Incentives", "Motor Car", "Entertainment Allow", "Leave EnCashment", "Loss from House Property (Sec 24)", "Previous Employer Income", "Other Income", "Rent Free Accommodation", "Total Earnings (AA)", "Less Exemptions", "HRA (Sec 10(13))", "Actual HRA Received", "Rent Paid in excess of 10% Basic Salary", "50% or 40% of Basic Salary", "Whichever is least from the above", "HRA Excemption - (a)", "Standard Deduction", "Medical", "Professional Tax (Sec 16(III))" };
            //string[] Str_GridItem = { "BASIC", "HRA", "CONVEYANCE", "SPALLOW", "MEDICAL", "LTA", "BONUS", "INCENTIVE", "DWAGES", "EALLOW", "LeaveEncashment", "Medical_Claim" };

            //Karthika_K

            string[] Str_GridItem = { "BASIC", "HRA", "CONVEYANCE", "SPALLOW", "MEDICAL", "LTA", "BONUS", "INCENTIVE", "DWAGES", "EALLOW", "LeaveEncashment", "Medical_Claim" };

            DataRow dr;
            DataTable dt = new DataTable();

            foreach (string str_temp in Str_item)
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = str_temp;
            }


            for (int i = 0; i <= Str_item.Length - 1; i++)
            {
                var Result = obj_dt_detail.AsEnumerable().Where(row => row.Field<string>("HeaderName") == Str_item[i]).ToList();
                if (Result.Count > 0)
                {

                    if (Str_item[i] == "Standard Deduction")
                    {
                        sd = 40000;

                        obj_dt.Rows[i][2] = sd;
                        

                        Total = Total + sd;
                    }
                }
            }
            for (int i = 0; i <= Str_GridItem.Length - 1; i++)
            {
                var Result = obj_dt_detail.AsEnumerable().Where(row => row.Field<string>("HeaderName") == Str_GridItem[i]).ToList();

                if (Result.Count > 0)
                {
                    obj_dt.Rows[i][1] = Result[0]["Monthly"];
                    obj_dt.Rows[i][2] = Result[0]["Yearly"];
                }
                else
                {
                    obj_dt.Rows[i][1] = 0;
                    obj_dt.Rows[i][2] = 0;
                }

                if (Str_GridItem[i] == "MEDICAL")
                {
                    //medicalamt = Convert.ToDouble(obj_dt.Rows[i][2].ToString());
                    medicalamt = 0;
                }

                if (Str_GridItem[i] == "BONUS")
                {
                    obj_dt.Rows[i][1] = 0;
                    obj_dt.Rows[i][2] = obj_da_IT.GetHRITBnsAmt(int_Empid, int_FYyear).ToString();
                }

                if (Str_GridItem[i] == "Less Exemptions" || Str_GridItem[i] == "HRA (Sec 10(13))")
                {
                    if (obj_dt.Rows[i][1].ToString() == (0.00).ToString())
                    {

                    }
                    if (obj_dt.Rows[i][1].ToString() == (0.00).ToString())
                    {

                    }
                }
            }

            dt1 = obj_da_Rent.GetHouseRent(int_Empid, int_FYyear);

            obj_dt.Rows[11][1] = 0;
            obj_dt.Rows[12][1] = 0;
            obj_dt.Rows[13][1] = 0;
            obj_dt.Rows[14][1] = 0;

            obj_dt.Rows[11][2] = 0;
            obj_dt.Rows[12][2] = 0;
            obj_dt.Rows[13][2] = 0;
            obj_dt.Rows[14][2] = 0;
            sd = 40000;
            
            string[] ArrList = { "House Rent Received PerAnnum", "Other Income", "Previous Employer Income", "Rent Free Accommodation" };

            for (int i = 0; i <= ArrList.Length - 1; i++)
            {
                var Data = dt1.AsEnumerable().Where(row => row.Field<string>("otherincome") == ArrList[i]).ToList();

                if (Data.Count > 0)
                {
                    if (ArrList[i] == "House Rent Received PerAnnum")
                    {
                        obj_dt.Rows[11][2] = Data[0]["income"];
                    }
                    if (ArrList[i] == "Previous Employer Income")
                    {
                        obj_dt.Rows[12][2] = Data[0]["income"];
                    }
                    if (ArrList[i] == "Other Income")
                    {
                        obj_dt.Rows[13][2] = Data[0]["income"];
                    }
                    if (ArrList[i] == "Rent Free Accommodation")
                    {
                        obj_dt.Rows[14][2] = Data[0]["income"];
                    }
                }
            }

            for (int k = 0; k <= 14; k++)
            {
                MonTot = Convert.ToDouble(obj_dt.Compute("Sum([Monthly])", string.Empty));
                YearTot = Convert.ToDouble(obj_dt.Compute("Sum([Yearly])", string.Empty));
            }

            double Mcrossptax = MonTot;

            sum_Month = Convert.ToDouble(obj_dt.Compute("sum(Monthly)", string.Empty));
            sum_Year = Convert.ToDouble(obj_dt.Compute("sum(Yearly)", string.Empty));

            obj_dt.Rows[15][1] = sum_Month;
            obj_dt.Rows[15][2] = sum_Year;

            //---------------------------------------------TAX CALCULATION--------------------------------------------------------------------------------------------------

            //----------HRA--------------------------------

            string[] Str_HRA = { "LESSHRAACT", "LESSHRA10", "LESSHRA50", "LESSHRA", "LESSHRA", "CONVEYANCE", "MEDICAL" };

            //Sum_Gross = obj_dt_detail.AsEnumerable().Where(row => (String)row["HeaderName"] == "BASIC" || (String)row["HeaderName"] == "HRA" || (String)row["HeaderName"] == "CONVEYANCE" || (String)row["HeaderName"] == "SPALLOW" || (String)row["HeaderName"] == "EALLOW" || (String)row["HeaderName"] == "LeaveEncashment" || (String)row["HeaderName"] == "Medical_Claim").Sum(row => row.Field<decimal>("Yearly"));                   

            double Total_80C = 0, MaxAmount = 0, ExTotal = 0;  //Total = 0
            int j = 17;
          
            for (int i = 0; i <= Str_HRA.Length - 1; i++)
            {
                j++;
                var Result = obj_dt_detail.AsEnumerable().Where(row => row.Field<string>("HeaderName") == Str_HRA[i]).ToList();
                if (Result.Count > 0)
                {
                    obj_dt.Rows[j][2] = Result[0]["Yearly"];

                    //if (Str_HRA[i] == "Standard Deduction")
                    //{
                    //    sd = 40000;
                    //    //Total = Total + double.Parse(obj_dt.Rows[j][2].ToString());

                    //    Total = Total + sd;
                    //}

                    //if (Str_HRA[i] == "MEDICAL")
                    //{
                    //    dt = obj_da_IT.GetMedicalIT(int_Empid, Dt_From, Dt_To, Dt_Date);

                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        string amt = dt.Rows[0][2].ToString();
                    //        double total = Convert.ToDouble(amt);

                    //        if (dt.Rows[0]["proof"].ToString() == "N")
                    //        {
                    //            if (medicalamt < total)
                    //            {
                    //                obj_dt.Rows[j][2] = medicalamt.ToString("#0.00");
                    //                Total = Total + medicalamt;
                    //            }
                    //            else
                    //            {
                    //                obj_dt.Rows[j][2] = dt.Rows[0][2].ToString();
                    //                double tot = Convert.ToDouble(dt.Rows[0][2].ToString());
                    //                Total = Total + tot;
                    //            }
                    //        }
                    //        else if ((dt.Rows[0]["proof"].ToString() == "Y"))
                    //        {
                    //            if (medicalamt < total)
                    //            {
                    //                obj_dt.Rows[j][2] = medicalamt.ToString("#0.00");
                    //                Total = Total + medicalamt;
                    //            }
                    //            else
                    //            {
                    //                obj_dt.Rows[j][2] = dt.Rows[0][2].ToString();
                    //                double tot = Convert.ToDouble(dt.Rows[0][2].ToString());
                    //                Total = Total + tot;
                    //            }
                    //        }
                    //    }
                    //}

                    if (Str_HRA[i] == "MEDICAL")
                    {
                        medicalamt = 0;
                       // sd = 40000;
                       

                        Total = Total + sd;
                    }



                }
                else
                {
                    obj_dt.Rows[j][2] = 0;
                }

                if (Str_HRA[i] == "LESSHRA")
                {
                    //ExTotal = ExTotal + double.Parse(obj_dt.Rows[j][2].ToString());

                    ExTotal = 0;
                }
            }
            obj_dt.Rows[23][2] = sd;
            obj_dt.Rows[24][2] = 0;

            obj_dt.Rows[24][0] = "";
          
            ExTotal = ExTotal / 2;

            double proftaxAmt = 0.00;
            obj_dt.Rows[25][2] = obj_da_IT.GetHRITProfTaxAmt(int_Empid, Mcrossptax, int_FYyear);
            Total = Total + double.Parse(obj_dt.Rows[25][2].ToString()) ;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total (b)";
            dr[2] = Total;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Tax Rebate & Relief u/s 80C";
            obj_dt_Tax = obj_da_IT.GetITComp4TaxDebateNew(int_Empid, Dt_From, "80C");

            if (obj_dt_Tax.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt_Tax.Rows.Count - 1; i++)
                {
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = obj_dt_Tax.Rows[i]["investplan"].ToString();
                    dr[2] = obj_dt_Tax.Rows[i]["investamt"].ToString();
                    Total_80C = Total_80C + double.Parse(obj_dt_Tax.Rows[i]["investamt"].ToString());
                    MaxAmount = MaxAmount + double.Parse(obj_dt_Tax.Rows[i]["maxlimit"].ToString());
                }
            }

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);

            dr[0] = "Total";
            dr[2] = Total_80C;

            //Total_80C = Total_80C > MaxAmount ? MaxAmount : Total_80C;
            //Total = Total + Total_80C;

            if (Total_80C > MaxAmount)
            {
                Total_80C = MaxAmount;
            }
            Total = Total + Total_80C;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total Tax Rebate u/s 80C - (C)";
            dr[2] = Total_80C;
            ExTotal = ExTotal + Total;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Deduction under Chapter VIA";
            obj_dt_Tax = obj_da_IT.GetITComp4TaxDebateNew(int_Empid, Dt_From, "80");
            Total = 0;

            for (int i = 0; i <= obj_dt_Tax.Rows.Count - 1; i++)
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = obj_dt_Tax.Rows[i]["secname"].ToString() + "-" + obj_dt_Tax.Rows[i]["seccode"].ToString();
                dr[2] = obj_dt_Tax.Rows[i]["investamt"].ToString();
                Total = Total + double.Parse(obj_dt_Tax.Rows[i]["investamt"].ToString());
            }

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total Deduction under Chapter VIA - (d)";
            dr[2] = Total;

            ExTotal = ExTotal + Total;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Total Exemption (a+b+c+d) (BB)";
            ExTotal = ExTotal + double.Parse(obj_dt.Rows[22][2].ToString());
            dr[2] = ExTotal;

            Taxslab = Convert.ToInt32(sum_Year) - Convert.ToInt32(ExTotal);
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Taxable Income (AA - BB)";
            dr[2] = Taxslab;

            //-----------------------------------------------------TAX SLAB RATE----------------------------------------------------------------------------------------------

            TaxSlabAmount = Taxslab;
            Double examt = 0.0;
            string strexamt = "";
            if (hid_Title.Value.ToString() == "Mr")
            {
                dt = obj_da_IT.GetITDet4TaxSlabto('M', Dt_To);
            }
            else
            {
                dt = obj_da_IT.GetITDet4TaxSlabto('F', Dt_To);
            }

            double Tax_Amount = 0, TotalPayment = 0, Total_Tax = 0;
            Total = 0;
            if (dt.Rows.Count > 0)
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Slab Rate ";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string Value1 = dt.Rows[i]["slabfrom"].ToString().Replace(".0000", "");
                    string value2 = dt.Rows[i]["slabto"].ToString().Replace(".0000", "");

                    if (TaxSlabAmount >= double.Parse(Value1) && TaxSlabAmount <= double.Parse(value2))
                    {
                        string TaxValue = dt.Rows[i]["taxpercent"].ToString().Replace(".0000", "");

                        Tax_Amount = TaxSlabAmount - (double.Parse(Value1) - 1);
                        Total = Total + ((Tax_Amount * double.Parse(TaxValue)) / 100);
                        TaxSlabAmount = TaxSlabAmount - Tax_Amount;

                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[0] = Value1 + " - " + value2 + "(" + Tax_Amount + ")";
                        dr[2] = ((Tax_Amount * double.Parse(TaxValue)) / 100);
                    }
                }

                Total = Math.Round(Total);
                Grand_Total = Total;

                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "0  - " + PayableAmount + "(" + PayableAmount + ")";
                dr[2] = 0;
            }

            if ((Convert.ToDouble(sum_Year.ToString()) - ExTotal) < PayableAmount)
            {
                TotalPayment = 0.0;
            }
            else
            {
                TotalPayment = (Convert.ToDouble(sum_Year.ToString()) - ExTotal) - PayableAmount;
            }

            string Exmp = "";

            //HIDE DINESH

            //if (Taxslab >= 250001 && Taxslab <= 500000)
            //{
            //    Exmp = "Y";
            //}


            if (int_FYyear < 2016)
            {
                if (Taxslab >= 250001 && Taxslab <= 500000)
                {
                    Exmp = "Y";
                    examt = 2000;
                    strexamt = "2000";
                }

            }
            else if (int_FYyear == 2016)
            {
                if (Taxslab >= 250001 && Taxslab <= 500000)
                {
                    Exmp = "Y";
                    examt = 5000;
                    strexamt = "5000";
                }
            }
            else
            {
                if (Taxslab >= 250001 && Taxslab <= 350000)
                {
                    Exmp = "Y";
                    examt = 2500;
                    strexamt = "2500";
                }
            }


            //------------------------Tax Amount--------------------------

            if (Exmp == "Y")
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount - Total";
                dr[2] = Total;

                //------------------------Excemption--------------------------

                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Excemption";
                //dr[2] = -2000;

                dr[2] = -examt;

                //------------------------Edu Chess--------------------------

                //double SubTotal = Convert.ToInt16(Total) - 2000;
                double SubTotal = Convert.ToInt16(Total) - examt;
                double EduAmnt;
                if (int_FYyear > 2017)
                {
                    EduAmnt = Math.Round(SubTotal * 4 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (4%)";
                    dr[2] = EduAmnt;
                }
                else
                {
                    EduAmnt = Math.Round(SubTotal * 3 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (3%)";
                    dr[2] = EduAmnt;
                }
                //Total_Tax = Total + EduAmnt - 2000;
                Total_Tax = Total + EduAmnt - examt;
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount";
                dr[2] = Total_Tax;
            }

            // Checking

            if (Exmp != "Y")
            {
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount - Total";
                dr[2] = Total;

                //------------------------Edu Chess--------------------------

                double EduAmount;
                if (int_FYyear > 2017)
                {
                    EduAmount = Math.Round(Total * 4 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (4%)";
                    dr[2] = EduAmount;
                }
                else
                {
                    EduAmount = Math.Round(Total * 3 / 100);
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Edu Chess - (3%)";
                    dr[2] = EduAmount;
                }
                Total_Tax = Total + EduAmount;
                dr = obj_dt.NewRow();
                obj_dt.Rows.Add(dr);
                dr[0] = "Tax Amount";
                dr[2] = Total_Tax;
            }

            PaidAmount = obj_da_IT.GetHRITAmt(int_Month, int_year, int_Empid);
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Tax Paid";
            dr[2] = PaidAmount;

            TaxAmountYear = 0;
            TaxAmountYear = Total - PaidAmount;

            DateTime Date_From, Date_To;

            if (int_Month > 4)
            {
                Date_From = DateTime.Parse(int_Month + "/01/" + int_year.ToString());
                Date_To = DateTime.Parse("03/31/" + (int_year + 1).ToString());
            }
            else
            {
                Date_From = DateTime.Parse(int_Month + "/01/" + int_year.ToString());
                Date_To = DateTime.Parse("03/31/" + int_year.ToString());
            }
            int int_MonthDiff = (Date_To.Month - Date_From.Month) + 12 * (Date_To.Year - Date_From.Year) + 1; ;

            TaxAmountYear = Total_Tax - PaidAmount;

            TaxAmountMonth = 0;
            TaxAmountMonth = Math.Round(TaxAmountYear / int_MonthDiff);

            if (TaxAmountMonth < 0)
            {
                TaxAmountMonth = 0;
            }

            PrvEmpTax = obj_da_IT.GetHRITAmtPrvEmpInco(int_Month, int_year, int_Empid);
            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Previous Emp Tax Paid";
            dr[2] = PrvEmpTax;

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Present Emp Tax Paid";
            if (PrvEmpTax != 0)
            {
                dr[2] = PaidAmount - PrvEmpTax;
            }
            else
            {
                dr[2] = "0.00";
            }

            dr = obj_dt.NewRow();
            obj_dt.Rows.Add(dr);
            dr[0] = "Taxable Amount Per Month";
            dr[2] = TaxAmountMonth;

            Grd_IT.DataSource = obj_dt;
            Grd_IT.DataBind();

            obj_dt.Dispose();
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 812, "Job", "", "", Session["StrTranType"].ToString());

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