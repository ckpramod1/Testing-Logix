using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Script.Services;
using System.Web.Services;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;

namespace logix.FAForms
{
    public partial class FALedgerViewPG : System.Web.UI.Page
    {
        DataAccess.FAMaster.ReportView da_obj_rv = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails da_obj_log = new DataAccess.LogDetails();
        DataAccess.FAMaster.ReportView da_obj_famaster = new DataAccess.FAMaster.ReportView();
        DataAccess.HR.Employee da_obj_emp = new DataAccess.HR.Employee();
        DataAccess.FAMaster.MasterLedger obj_mledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Masters.MasterPort potbj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
        DataAccess.FAMaster.ReportView Obj_Report = new DataAccess.FAMaster.ReportView();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string ctrlList;
        string msgList;
        string dtypeList;
        double dbl_temp = 0;
        double cncl = 0;
        int voutypeid = 0;
        string voutypename = "";
        int osid;
        string gst;
        int portidlgd;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "generateLableAutomatically();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_rv.GetDataBase(Ccode);
                da_obj_log.GetDataBase(Ccode);
                da_obj_famaster.GetDataBase(Ccode);
                da_obj_emp.GetDataBase(Ccode);
                obj_mledger.GetDataBase(Ccode);
                potbj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                Emp_Obj.GetDataBase(Ccode);


                Obj_Report.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnexcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_head.Text = Request.QueryString["FormName"].ToString();
            }
            if (TXTPANO.Text != "")
            {
                Session["TXTPANO"] = TXTPANO.Text;
            }

            
            //this.GRD_PAN.EnableFiltering = true;
            //this.GRD_PAN.MasterTemplate.ShowHeaderCellButtons = true;
            //this.GRD_PAN.MasterTemplate.ShowFilteringRow = false;
            //ddl_Gst.Items.Clear();
            //ddl_Gst.Items.Add("All");
            //txtLedgerName.Visible = false;
            if (IsPostBack != true)
            {
                //DataAccess.Masters.MasterPort potbj = new DataAccess.Masters.MasterPort();
                DataTable dt1 = new DataTable();
                dt1 = potbj.GetAllBranchNameforPortName();
                if (dt1.Rows.Count > 0)
                {
                    ddl_branch.Items.Clear();
                    ddl_branch.Items.Add("All");
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        ddl_branch.Items.Add(dt1.Rows[j]["portname"].ToString());
                    }
                }
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                hidId.Value = "0";
                ctrlList = txtLedgerName.ID;
                msgList = "Ledger";
                dtypeList = "string";
                btnview.Attributes.Add("OnClick", "return IsValid('" + ctrlList + "','" + msgList + "','" + dtypeList + "');");

                dvWithDetails.Visible = false;
                Consolidated.Visible = false;
                btnagref.Visible = false;
                btnprint.Visible = false;
                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime Date = da_obj_rv.MaxVouGetDate(Session["FADbname"].ToString());


                if (Session["LoginBranchid"].ToString() == "2")
                {
                    
                }
                else
                {
                    
                    ddl_branch.Enabled = false;
                    ddl_branch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                }

                //if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                //{
                //    //dtfrom.Text = Str_CurrrentDate;
                //    //dtto.Text = Str_CurrrentDate;
                //    dtfrom.Text = "01/04/" + Vouyear;
                //    dtto.Text = Str_CurrrentDate;
                //}
                //else
                //{
                //    dtfrom.Text = "01/04/" + Vouyear;
                //    dtto.Text = "31/03/" + (Vouyear + 1);
                //}

                //if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month < 3) || Vouyear == (DateTime.Now).Year)
                //{
                //    //dtfrom.Text = Str_CurrrentDate;
                //    //dtto.Text = Str_CurrrentDate;
                //    dtfrom.Text = "01/01/" + Vouyear;
                //    dtto.Text = Str_CurrrentDate;
                //}
                //else
                //{
                //    dtfrom.Text = "01/01/" + Vouyear;
                //    //dtto.Text = "31/12/" + (Vouyear + 1);
                //    dtto.Text = "31/12/" + (Vouyear);
                //}
                if (Session["countryid"].ToString() == "1102" || Session["countryid"].ToString() == "102")
                {
                    if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                    {
                        dtfrom.Text = "01/04/" + Vouyear;
                        dtto.Text = (Str_CurrrentDate.ToString());

                    }
                    else
                    {
                        dtfrom.Text = "01/04/" + Vouyear;
                        dtto.Text = "31/03/" + (Vouyear + 1);
                    }
                }
                else
                {
                    if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month <= 3) || Vouyear == (DateTime.Now).Year)
                    {
                        dtfrom.Text = "01/01/" + Vouyear;
                        dtto.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());

                    }
                    else
                    {
                        dtfrom.Text = "01/01/" + Vouyear;
                        dtto.Text = "31/12/" + (Vouyear + 1);
                    }
                }
                // Utility.fn_ConvertDate(Date.ToString());

                //dtfrom.Text = Utility.fn_ConvertDate(da_obj_log.GetDate().AddMonths(-1).ToShortDateString());
                //dtto.Text = Utility.fn_ConvertDate(da_obj_log.GetDate().ToShortDateString());

                //string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                //dtfrom.Text = Str_CurrrentDate;
                //dtto.Text = Str_CurrrentDate;
                string str_CtrlLists = "dtfrom~dtto";
                btnview.Attributes.Add("OnClick", "return IsDate('" + str_CtrlLists + "')");
                chkConsolidate.Visible = false;  Consolidated.Visible = false;
                grd.DataSource = new DataTable();
                grd.DataBind();

                //if (Session["StrTranType"].ToString() == "CA" || Session["StrTranType"].ToString() == "CO")
                //{
                //    chkConsolidate.Visible = true;  Consolidated.Visible = true;
                //}

                if (Request.QueryString.ToString().Contains("LedgerID"))
                {
                    hidId.Value = Request.QueryString["LedgerID"].ToString();
                    hf_custid.Value = hidId.Value;
                    txtLedgerName.Text = obj_mledger.GetLedgernamewithID(Convert.ToInt32(hidId.Value), Session["FADbname"].ToString());
                    if (Request.QueryString.ToString().Contains("FromDate"))
                    {

                        dtfrom.Text = Request.QueryString["FromDate"].ToString();
                    }
                    if (Request.QueryString.ToString().Contains("ToDate"))
                    {
                        dtto.Text = Request.QueryString["ToDate"].ToString();
                    }
                    if (Request.QueryString.ToString().Contains("EcsValue"))
                    {
                        Session["EcsValue"] = Request.QueryString["EcsValue"].ToString();
                    }

                    if (Request.QueryString.ToString().Contains("CheckedValue"))
                    {
                        if (Request.QueryString["CheckedValue"].ToString() == "false")
                        {
                            chk_MonthWise.Checked = false;
                        }
                    }
                    //if (hidId.Value != "")
                    //{
                    //    if (hidId.Value == "338996")
                    //    {
                    //        chkConsolidate.Checked = true;
                    //    }
                    //}
                    if (Request.QueryString.ToString().Contains("Consolidate"))
                    {
                        if (Request.QueryString["Consolidate"].ToString() == "True")
                        {
                            chkConsolidate.Checked = true;
                        }
                        else
                        {
                            chkConsolidate.Checked = false;
                        }
                    }

                    if (Request.QueryString.ToString().Contains("Branch"))
                    {
                        if (Request.QueryString["Branch"].ToString() == "CORPORATE")
                        {
                            //chkConsolidate.Visible = true;  Consolidated.Visible = true;
                            //chkConsolidate.Checked = true;
                        }
                    }

                    FillGrid();
                }

                if (Request.QueryString.ToString().Contains("LedgerName"))
                {

                    hidId.Value = Request.QueryString["LedgerNo"].ToString();
                    hf_custid.Value = hidId.Value;
                    txtLedgerName.Text = obj_mledger.GetLedgernamewithID(Convert.ToInt32(hidId.Value), Session["FADbname"].ToString());
                    if (Request.QueryString.ToString().Contains("From"))
                    {
                        dtfrom.Text = Request.QueryString["From"].ToString();
                    }
                    if (Request.QueryString.ToString().Contains("To"))
                    {
                        dtto.Text = Request.QueryString["To"].ToString();
                    }

                    btnview_Click(sender, e);
                }

                if (Request.QueryString.ToString().Contains("ledgerid"))
                {
                    hidId.Value = Request.QueryString["ledgerid"].ToString();
                    hf_custid.Value = hidId.Value;
                    txtLedgerName.Text = obj_mledger.GetLedgernamewithID(Convert.ToInt32(hidId.Value), Session["FADbname"].ToString());
                    chkConsolidate.Checked = true;
                    btnview_Click(sender, e);

                }
            }
        }
        [WebMethod]
        public static List<string> GetCustomerPano(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = customerobj.GetLikeCustomerpantype(prefix);
            List_Result = Utility.Fn_TableToList(dt, "pano");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCustomergst(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = customerobj.GetLikeCustomergst(prefix, HttpContext.Current.Session["TXTPANO"].ToString());
            List_Result = Utility.Fn_TableToList(dt, "gstno");
            return List_Result;
        }

        protected void BTNPANo_Click(object sender, EventArgs e)
        {
            if (TXTPANO.Text !="" || TXT_custn.Text != "")
            {
                FillGrid();
            }
           
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                div_outstd.Visible = false;
                btncancel.ToolTip = "Cancel";
                DateTime FromDate;
                DateTime ToDate;

                FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));

                if (FromDate > ToDate)
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                    return;
                }

                if (Convert.ToInt32(hidId.Value.ToString()) > 0)
                {
                    if (chk_MonthWise.Checked)
                    {
                        FillGrd4Month();
                    }
                    else if (chkDayWise.Checked)
                    {
                        FillGrid4Day();
                    }
                    else
                    {
                        FillGrid();
                    }

                    if (Session["str_ModuleName"].ToString() == "FA")
                    {
                        da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1110, 3, int.Parse(Session["LoginBranchid"].ToString()), txtLedgerName.Text + " " + dtfrom.Text + " " + dtto.Text);
                    }
                    else
                    {
                        da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1202, 3, int.Parse(Session["LoginBranchid"].ToString()), txtLedgerName.Text + " " + dtfrom.Text + " " + dtto.Text);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Please Enter Ledger');", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        private void FillGrd4Month()
        {
            try
            {
                DataTable obj_dt_month = new DataTable();
                DateTime FromDate;
                DateTime ToDate;

                FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));

                obj_dt_month = da_obj_rv.FAselLedgergrd4Month4web(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());
                grd_DayWise.Visible = false;
                divgrd.Visible = false;
                grd.Visible = false;
                Monthwise.Visible = true;
                grd_consol_div.Visible = false;
                grdconsol.Visible = false;
                grd_Monthwise.Visible = true;
                grd_Monthwise.DataSource = obj_dt_month;
                grd_Monthwise.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        private void FillGrid4Day()
        {
            try
            {
                DataTable dt_lv_day = new DataTable();

                DateTime FromDate;
                DateTime ToDate;

                FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));

                if (chkConsolidate.Checked)
                {
                    dt_lv_day = da_obj_rv.FAselLedgergrd4Day4AllBranch(Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());
                }
                else
                {
                    dt_lv_day = da_obj_rv.FAselLedgergrd4Day(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());
                }
                Daywise.Visible = true;
                grd_DayWise.Visible = true;
                divgrd.Visible = false;
                grd.Visible = false;
                Monthwise.Visible = false;
                grd_Monthwise.Visible = false;
                grd_consol_div.Visible = false;
                var var_lvday = dt_lv_day.AsEnumerable()
                                 .Select(row_value => new
                                 {
                                     lday = row_value["VoucherDay"].ToString() + "\\" + row_value["MonthName"].ToString() + "\\" + row_value["VoucherYear"].ToString(),
                                     DayDebit = row_value["DayDebit"],
                                     Daycredit = row_value["DayCredit"]
                                 });

                grd_DayWise.DataSource = var_lvday;
                grd_DayWise.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        private string FillVoucher(int voutypeid)
        {
            if (voutypeid == 1)
            {
                voutypename = "Invoice";
            }
            else if (voutypeid == 2)
            {
                voutypename = "Purchase Invoice";
            }
            else if (voutypeid == 3)
            {
                voutypename = "Admin Purchase Invoice";
            }
            else if (voutypeid == 4)
            {
                voutypename = "Admin Sales Invoice";
            }
            else if (voutypeid == 5)
            {
                voutypename = "OSSI";
            }
            else if (voutypeid == 6)
            {
                voutypename = "OSPI";
            }
            else if (voutypeid == 7)
            {
                voutypename = "Debit Note - Others";
            }
            else if (voutypeid == 8)
            {
                voutypename = "Credit Note - Others";
            }
            else if (voutypeid == 9)
            {
                voutypename = "Bank Receipt";
            }
            else if (voutypeid == 10)
            {
                voutypename = "Cash Receipt";
            }
            else if (voutypeid == 11)
            {
                voutypename = "Bank Payment";
            }
            else if (voutypeid == 12)
            {
                voutypename = "Cash Payment";
            }
            else if (voutypeid == 13)
            {
                voutypename = "Journal";
            }
            else if (voutypeid == 14)
            {
                voutypename = "Contra";
            }
            else if (voutypeid == 15)
            {
                voutypename = "Receipt - Petty Cash";
            }
            else if (voutypeid == 35)
            {
                voutypename = "Manual Invoices";
            }
            else if (voutypeid == 36)
            {
                voutypename = "Manual PaymentAdvises";
            }
            else if (voutypeid == 37)
            {
                voutypename = "Manual OSDN";
            }
            else if (voutypeid == 38)
            {
                voutypename = "Manual OSCN";
            }
            else if (voutypeid == 39)
            {
                voutypename = "Manual Debit Note - Others";
            }
            else if (voutypeid == 40)
            {
                voutypename = "Manual Credit Note - Others";
            }
            else if (voutypeid == 41)
            {
                voutypename = "Manual Bank Receipt";
            }
            else if (voutypeid == 42)
            {
                voutypename = "Manual Cash Receipt";
            }
            else if (voutypeid == 43)
            {
                voutypename = "Manual Bank Payment";
            }
            else if (voutypeid == 44)
            {
                voutypename = "Manual Cash Payment";
            }
            else if (voutypeid == 45)
            {
                voutypename = "Manual Contra";
            }
            else if (voutypeid == 101)
            {
                voutypename = "OSDNCNJV";
            }
            else if (voutypeid == 1102)
            {
                voutypename = "BDJV";
            }
            else if (voutypeid == 103)
            {
                voutypename = "BPJV";
            }
            else if (voutypeid == 104)
            {
                voutypename = "BRRJV";
            }
            else if (voutypeid == 105)
            {
                voutypename = "BPRJV";
            }
            else if (voutypeid == 16)
            {
                voutypename = "Remittance-Receipt";
            }
            else if (voutypeid == 17)
            {
                voutypename = "Remittance-Payment";
            }
            else if (voutypeid == 19)
            {
                voutypename = "Adjustment DCN";
            }
            else if (voutypeid == 106)
            {
                voutypename = "BRG";
            }

            else if (voutypeid == 20)
            {
                voutypename = "Bill of Supply";
            }

            return voutypename;
        }

        //private void FillGrid()
        //{
        //    try
        //    {
        //        grd_DayWise.Visible = false;
        //        divgrd.Visible = true;
        //        grd.Visible = true;
        //        grd_Monthwise.Visible = false;
        //        grd_consol_div.Visible = true;
        //        DataSet ds_OpBal = new DataSet();
        //        DataTable dt_Tans = new DataTable();
        //        DataSet dt_transset = new DataSet();
        //        grd_Monthwise.Visible = false;
        //        grd.Visible = true;
        //        DateTime FromDate;
        //        DateTime ToDate;
        //        Double opbaldb = 0;
        //        Double opbalcr = 0;
        //        Double opbaldbUSD = 0;
        //        Double opbalcrUSD = 0;
        //        string dispname;
        //        FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
        //        ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));

        //        if (chk_MonthWise.Checked)
        //        {
        //            //index = grd_Monthwise.CurrentRow.Index;
        //            //dt_tmpFrom = grd_Monthwise.Rows(index).Cells("VoucherMonth").Value.ToString() + "/01/" + grd_Monthwise.Rows(index).Cells("VoucherYear").Value.ToString();
        //            //dt_tmpTo = dt_tmpFrom.AddMonths(1);
        //            //dt_tmpTo = dt_tmpTo.AddDays(-1);
        //        }
        //        if (chk_alias.Checked == true)
        //        {
        //            dispname = "alias";
        //        }
        //        else
        //        {
        //            dispname = "ledgername";
        //        }

        //        if (chkConsolidate.Checked)
        //        {
        //            ds_OpBal = da_obj_rv.FASelopbal4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]));
        //            if (chkwithdtls.Checked == true)
        //            {
        //                dt_Tans = da_obj_rv.FAselLedgergrd4AllBranchwithDet(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]));
        //            }
        //            else
        //            {
        //                dt_Tans = da_obj_rv.FAselLedgergrd4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]));
        //            }
        //            divgrd.Visible = false;
        //            grd.Visible = false;
        //        }
        //        else
        //        {
        //            ds_OpBal = da_obj_rv.FASelopbal(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());
        //            if (chkwithdtls.Checked == true)
        //            {
        //                dt_Tans = da_obj_rv.FAselLedgergrdWithDet(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());
        //            }
        //            else
        //            {
        //                dt_Tans = da_obj_rv.FAselLedgergrd(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname);
        //            }
        //        }
        //        if (chkwithdtls.Checked == true || chkConsolidate.Checked == true)
        //        {
        //            dt_Tans.Columns.Add("amountcr", typeof(double));
        //            dt_Tans.Columns.Add("voutypename");
        //            dt_Tans.Columns.Add("ClearedOn");
        //        }
        //        dt_Tans.Columns.Add("famtcr", typeof(double));
        //        //else if (chkConsolidate.Checked==false)
        //        //{
        //        //    dt_Tans.Columns.Add("gstin");
        //        //}

        //        double dbl_Closing_dbamt = 0;
        //        double dbl_Closing_cramt = 0;
        //        double dbl_dbamt = 0;
        //        double dbl_cramt = 0;
        //        double dbl_Closing_dbfamt = 0;
        //        double dbl_Closing_crfamt = 0;
        //        double dbl_dbfamt = 0;
        //        double dbl_crfamt = 0;

        //        double totopbaldb = 0;
        //        double totopbalcr = 0;
        //        double totopbalcrUSD = 0;
        //        double totopbaldbUSD = 0;
        //        DataTable dt = new DataTable();
        //        DataTable dtv = new DataTable();
        //        string str_curtype = "";

        //        if (ds_OpBal.Tables.Count > 0)
        //        {
        //            dt = ds_OpBal.Tables[0];
        //            if (dt.Rows.Count > 0)
        //            {
        //                totopbaldb = Convert.ToDouble(dt.Rows[0][0].ToString());
        //                totopbalcr = Convert.ToDouble(dt.Rows[0][1].ToString());
        //                totopbaldbUSD = Convert.ToDouble(dt.Rows[0][2].ToString());
        //                totopbalcrUSD = Convert.ToDouble(dt.Rows[0][3].ToString());
        //                str_curtype = dt.Rows[0]["opbalcurr"].ToString();
        //            }
        //        }

        //        dtv = ds_OpBal.Tables[1];
        //        if (dtv.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dtv.Rows.Count; i++)
        //            {
        //                if (dtv.Rows[i]["ledgertype"].ToString() == "Cr")
        //                {
        //                    totopbalcr = totopbalcr + Convert.ToDouble(dtv.Rows[i]["amount"].ToString());
        //                    totopbalcrUSD = totopbalcrUSD + Convert.ToDouble(dtv.Rows[i]["amountUSD"].ToString());
        //                }
        //                else
        //                {
        //                    totopbaldb = totopbaldb + Convert.ToDouble(dtv.Rows[i]["amount"].ToString());
        //                    totopbaldbUSD = totopbaldbUSD + Convert.ToDouble(dtv.Rows[i]["amountUSD"].ToString());
        //                }
        //            }
        //        }

        //        if (totopbalcr > totopbaldb)
        //        {
        //            totopbalcr = totopbalcr - totopbaldb;
        //            totopbaldb = 0;
        //        }
        //        else if (totopbalcr < totopbaldb)
        //        {
        //            totopbaldb = totopbaldb - totopbalcr;
        //            totopbalcr = 0;
        //        }
        //        else
        //        {
        //            totopbaldb = 0;
        //            totopbalcr = 0;
        //        }

        //        if (totopbalcrUSD > totopbaldbUSD)
        //        {
        //            totopbalcrUSD = totopbalcrUSD - totopbaldbUSD;
        //            totopbaldbUSD = 0;
        //        }

        //        else if (totopbalcrUSD < totopbaldbUSD)
        //        {
        //            totopbaldbUSD = totopbaldbUSD - totopbalcrUSD;
        //            totopbalcrUSD = 0;
        //        }
        //        else
        //        {
        //            totopbaldbUSD = 0;
        //            totopbalcrUSD = 0;
        //        }

        //        DataRow dr_temp;
        //        dr_temp = dt_Tans.NewRow();
        //        dr_temp["voudate"] = Utility.fn_ConvertDate(dtfrom.Text);
        //        dr_temp["Vouno"] = -1;
        //        dr_temp["ltype"] = "Cr";
        //        dr_temp["voutypename"] = "";
        //        dr_temp["prti"] = "Opening Balance";
        //        dr_temp["amount"] = totopbaldb;
        //        dr_temp["amountcr"] = totopbalcr;

        //        if (chkConsolidate.Checked == false)
        //        {
        //            if (ds_OpBal.Tables[0].Rows.Count > 0)
        //            {
        //                if (totopbaldb > 0)
        //                {
        //                    dr_temp["ltype"] = "Dr";
        //                    dr_temp["amount"] = totopbaldb;
        //                    opbaldb = totopbaldb;
        //                    dr_temp["amountcr"] = 0;
        //                }
        //                else
        //                {
        //                    dr_temp["ltype"] = "Cr";
        //                    dr_temp["amountcr"] = totopbalcr;
        //                    opbalcr = totopbalcr;
        //                    dr_temp["amount"] = 0;
        //                }
        //                dr_temp["fcur"] = str_curtype;
        //                if (totopbaldbUSD > 0)
        //                {

        //                    dr_temp["famt"] = totopbaldbUSD;
        //                    opbaldbUSD = totopbaldbUSD;
        //                    dr_temp["famtcr"] = 0;
        //                }
        //                else
        //                {
        //                    dr_temp["famtcr"] = totopbalcrUSD;
        //                    opbalcrUSD = totopbalcrUSD;
        //                    dr_temp["famt"] = 0;
        //                }
        //            }

        //            for (int i = 0; i < dt_Tans.Rows.Count; i++)
        //            {
        //                if (dt_Tans.Rows[i]["ltype"].ToString() == "Cr")
        //                {
        //                    dt_Tans.Rows[i]["amountcr"] = dt_Tans.Rows[i]["amount"].ToString();
        //                    dt_Tans.Rows[i]["famtcr"] = Convert.ToDouble(dt_Tans.Rows[i]["famt"].ToString());
        //                    dt_Tans.Rows[i]["famt"] = 0;
        //                }
        //                else
        //                {
        //                    dt_Tans.Rows[i]["amount"] = dt_Tans.Rows[i]["amount"].ToString();
        //                    dt_Tans.Rows[i]["amountcr"] = "0.00";
        //                    dt_Tans.Rows[i]["famt"] = Convert.ToDouble(dt_Tans.Rows[i]["famt"].ToString());
        //                    dt_Tans.Rows[i]["famtcr"] = 0;
        //                }
        //                string vouchername = FillVoucher(Convert.ToInt32(dt_Tans.Rows[i]["voutype"].ToString()));
        //                dt_Tans.Rows[i]["voutypename"] = vouchername;
        //            }

        //            dt_Tans.Rows.InsertAt(dr_temp, 0);

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            dr_temp["voutypename"] = 0;
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Transaction Total";
        //            dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' and vouno>0");
        //            dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr' and vouno>0");
        //            dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' and vouno>0");
        //            dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr' and vouno>0");
        //            dt_Tans.Rows.Add(dr_temp);

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            dr_temp["voutypename"] = 0;
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Total";
        //            dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' ");
        //            dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr'");
        //            dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' ");
        //            dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr'");
        //            if (dr_temp["amount"].ToString().Length == 0)
        //            {
        //                dr_temp["amount"] = "0.00";
        //            }
        //            if (dr_temp["famt"].ToString().Length == 0)
        //            {
        //                dr_temp["famt"] = "0.00";
        //            }
        //            else
        //            {

        //            }
        //            if (dr_temp["famtcr"].ToString().Length == 0)
        //            {
        //                dr_temp["famtcr"] = "0.00";
        //            }
        //            else
        //            {

        //            }

        //            if (dr_temp["amountcr"].ToString().Length == 0)
        //            {
        //                dr_temp["amountcr"] = "0.00";
        //            }

        //            dt_Tans.Rows.Add(dr_temp);

        //            dbl_Closing_dbamt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountCr"].ToString());
        //            dbl_Closing_cramt = dbl_Closing_dbamt;
        //            dbl_dbamt = Convert.ToDouble(dr_temp["amount"].ToString());
        //            dbl_cramt = Convert.ToDouble(dr_temp["amountCr"].ToString());

        //            dbl_Closing_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString()) - Convert.ToDouble(dr_temp["famtCr"].ToString());
        //            dbl_Closing_crfamt = dbl_Closing_dbfamt;
        //            dbl_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString());
        //            dbl_crfamt = Convert.ToDouble(dr_temp["famtCr"].ToString());

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            dr_temp["voutypename"] = 0;
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Closing Balance";
        //            if (dbl_Closing_dbamt < 0)
        //            {
        //                dr_temp["amount"] = dbl_Closing_dbamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_dbamt = Convert.ToDouble(dbl_Closing_dbamt.ToString().Replace("-", ""));
        //                dbl_Closing_cramt = 0;

        //            }
        //            else
        //            {
        //                dr_temp["amountcr"] = dbl_Closing_dbamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_dbamt = 0;

        //            }

        //            if (dbl_Closing_dbfamt < 0)
        //            {
        //                dr_temp["famt"] = dbl_Closing_dbfamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_dbfamt = Convert.ToDouble(dbl_Closing_dbfamt.ToString().Replace("-", ""));
        //                dbl_Closing_crfamt = 0;
        //            }
        //            else
        //            {
        //                dr_temp["famtcr"] = dbl_Closing_dbfamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_dbfamt = 0;
        //            }

        //            dt_Tans.Rows.Add(dr_temp);

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            dr_temp["voutypename"] = 0;
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Grand Total";
        //            dr_temp["amount"] = (dbl_Closing_dbamt + dbl_dbamt).ToString("0.00").Replace("-", "");
        //            dr_temp["amountcr"] = (dbl_Closing_cramt + dbl_cramt).ToString("0.00").Replace("-", "");

        //            dr_temp["famt"] = (dbl_Closing_dbfamt + dbl_dbfamt).ToString("0.00").Replace("-", "");
        //            dr_temp["famtcr"] = (dbl_Closing_crfamt + dbl_crfamt).ToString("0.00").Replace("-", "");

        //            dt_Tans.Rows.Add(dr_temp);
        //            grd.DataSource = dt_Tans;
        //            grd.DataBind();
        //            grdconsol.Visible = false;
        //        }
        //        else
        //        {
        //            grdconsol.Visible = true;
        //            if (ds_OpBal.Tables[0].Rows.Count > 0)
        //            {
        //                if (totopbaldb > 0)
        //                {
        //                    dr_temp["ltype"] = "Dr";
        //                    dr_temp["amount"] = totopbaldb;
        //                    opbaldb = totopbaldb;
        //                    dr_temp["amountcr"] = 0;
        //                }
        //                else
        //                {
        //                    dr_temp["ltype"] = "Cr";
        //                    dr_temp["amountcr"] = totopbalcr;
        //                    opbalcr = totopbalcr;
        //                    dr_temp["amount"] = 0;
        //                }
        //                dr_temp["fcur"] = str_curtype;
        //                if (totopbaldbUSD > 0)
        //                {

        //                    dr_temp["famt"] = totopbaldbUSD;
        //                    opbaldbUSD = totopbaldbUSD;
        //                    dr_temp["famtcr"] = 0;
        //                }
        //                else
        //                {
        //                    dr_temp["famtcr"] = totopbalcrUSD;
        //                    opbalcrUSD = totopbalcrUSD;
        //                    dr_temp["famt"] = 0;
        //                }
        //            }

        //            for (int i = 0; i < dt_Tans.Rows.Count; i++)
        //            {
        //                if (dt_Tans.Rows[i]["ltype"].ToString() == "Cr")
        //                {
        //                    dt_Tans.Rows[i]["amountcr"] = dt_Tans.Rows[i]["amount"].ToString();
        //                    dt_Tans.Rows[i]["famtcr"] = dt_Tans.Rows[i]["famt"].ToString();
        //                    dt_Tans.Rows[i]["famt"] = "0.00";
        //                }
        //                else
        //                {
        //                    dt_Tans.Rows[i]["amount"] = dt_Tans.Rows[i]["amount"].ToString();
        //                    dt_Tans.Rows[i]["famt"] = dt_Tans.Rows[i]["famt"].ToString();
        //                    dt_Tans.Rows[i]["amountcr"] = "0.00";
        //                    dt_Tans.Rows[i]["famtcr"] = "0.00";
        //                }
        //                string vouchername = FillVoucher(Convert.ToInt32(dt_Tans.Rows[i]["voutype"].ToString()));
        //                dt_Tans.Rows[i]["voutypename"] = vouchername;
        //            }

        //            dt_Tans.Rows.InsertAt(dr_temp, 0);

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            //dr_temp["voutype"] = 0;
        //            dr_temp["voutypename"] = "";
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Transaction Total";
        //            dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' and vouno>0");
        //            dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr' and vouno>0");

        //            dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' and vouno>0");
        //            dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr' and vouno>0");
        //            dt_Tans.Rows.Add(dr_temp);

        //            //double dbl_Closing_dbamt = 0;
        //            //double dbl_Closing_cramt = 0;
        //            //double dbl_dbamt = 0;
        //            //double dbl_cramt = 0;

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            //dr_temp["voutype"] = 0;
        //            dr_temp["voutypename"] = "";
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Total";
        //            dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' ");
        //            dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr'");

        //            dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' ");
        //            dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr'");
        //            if (dr_temp["amount"].ToString().Length == 0)
        //            {
        //                dr_temp["amount"] = "0.00";
        //            }
        //            else
        //            {
        //                dr_temp["amount"] = Convert.ToDouble(dr_temp["amount"].ToString());
        //            }

        //            if (dr_temp["famt"].ToString().Length == 0)
        //            {
        //                dr_temp["famt"] = "0.00";
        //            }
        //            else
        //            {
        //                dr_temp["famt"] = Convert.ToDouble(dr_temp["famt"].ToString());
        //            }

        //            if (dr_temp["famtcr"].ToString().Length == 0)
        //            {
        //                dr_temp["famtcr"] = "0.00";
        //            }
        //            else
        //            {
        //                dr_temp["famtcr"] = Convert.ToDouble(dr_temp["famtcr"].ToString()) + opbalcrUSD;
        //            }

        //            if (dr_temp["amountcr"].ToString().Length == 0)
        //            {
        //                dr_temp["amountcr"] = "0.00";
        //            }
        //            else
        //            {
        //                dr_temp["amountcr"] = Convert.ToDouble(dr_temp["amountcr"].ToString()) + opbalcr;
        //            }
        //            dt_Tans.Rows.Add(dr_temp);

        //            dbl_Closing_dbamt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountcr"].ToString()); // -Convert.ToDouble(dr_temp["amountCr"].ToString());
        //            dbl_Closing_cramt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountcr"].ToString());
        //            dbl_dbamt = Convert.ToDouble(dr_temp["amount"].ToString());
        //            dbl_cramt = Convert.ToDouble(dr_temp["amountCr"].ToString());

        //            dbl_Closing_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString()) - Convert.ToDouble(dr_temp["famtcr"].ToString()); // -Convert.ToDouble(dr_temp["amountCr"].ToString());
        //            dbl_Closing_crfamt = Convert.ToDouble(dr_temp["famt"].ToString()) - Convert.ToDouble(dr_temp["famtcr"].ToString());
        //            dbl_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString());
        //            dbl_crfamt = Convert.ToDouble(dr_temp["famtcr"].ToString());

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            //dr_temp["voutype"] = 0;
        //            dr_temp["voutypename"] = "";
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Closing Balance";
        //            if (dbl_Closing_dbamt < 0)
        //            {
        //                dr_temp["amount"] = dbl_Closing_dbamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_cramt = 0;
        //            }
        //            else
        //            {
        //                dr_temp["amountcr"] = dbl_Closing_dbamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_dbamt = 0;
        //            }

        //            if (dbl_Closing_dbfamt < 0)
        //            {
        //                dr_temp["famt"] = dbl_Closing_dbfamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_crfamt = 0;
        //            }
        //            else
        //            {
        //                dr_temp["famtcr"] = dbl_Closing_dbfamt.ToString("0.00").Replace("-", "");
        //                dbl_Closing_dbfamt = 0;
        //            }

        //            dt_Tans.Rows.Add(dr_temp);

        //            dr_temp = dt_Tans.NewRow();
        //            dr_temp["Vouno"] = 0;
        //            //dr_temp["voutype"] = 0;
        //            dr_temp["voutypename"] = "";
        //            dr_temp["ltype"] = "";
        //            dr_temp["prti"] = "Grand Total";
        //            dr_temp["amount"] = (dbl_Closing_dbamt + dbl_dbamt).ToString("0.00").Replace("-", "");
        //            dr_temp["amountcr"] = (dbl_Closing_cramt + dbl_cramt).ToString("0.00").Replace("-", "");

        //            dr_temp["famt"] = (dbl_Closing_dbfamt + dbl_dbfamt).ToString("0.00").Replace("-", "");
        //            dr_temp["famtcr"] = (dbl_Closing_crfamt + dbl_crfamt).ToString("0.00").Replace("-", "");

        //            dt_Tans.Rows.Add(dr_temp);
        //            grdconsol.DataSource = dt_Tans;
        //            grdconsol.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
        //    }
        //}

        private void FillGrid()
        {
            try
            {
                grd_DayWise.Visible = false;
                divgrd.Visible = true;
                grd.Visible = true;
                grd_Monthwise.Visible = false;
                grd_consol_div.Visible = false;
                DataSet ds_OpBal = new DataSet();
                DataTable dt_Tans = new DataTable();
                grd_Monthwise.Visible = false;
                grd.Visible = true;
                DateTime FromDate;
                DateTime ToDate;
                Double opbaldb = 0;
                Double opbalcr = 0;
                Double opbaldbUSD = 0;
                Double opbalcrUSD = 0;
                FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));
                string dispname;
                if (chk_alias.Checked == true)
                {
                    dispname = "alias";
                }
                else
                {
                    dispname = "ledgername";
                }
                if (chk_MonthWise.Checked)
                {
                    //index = grd_Monthwise.CurrentRow.Index;
                    //dt_tmpFrom = grd_Monthwise.Rows(index).Cells("VoucherMonth").Value.ToString() + "/01/" + grd_Monthwise.Rows(index).Cells("VoucherYear").Value.ToString();
                    //dt_tmpTo = dt_tmpFrom.AddMonths(1);
                    //dt_tmpTo = dt_tmpTo.AddDays(-1);
                }
                if (TXTPANO.Text == "" && TXT_custn.Text =="")
                {
                    
                    if (chkConsolidate.Checked)
                    {
                        grd_consol_div.Visible = true;
                        ds_OpBal = da_obj_rv.FASelopbal4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]));
                        if (chkwithdtls.Checked == true)
                        {
                            dt_Tans = da_obj_rv.FAselLedgergrd4AllBranchwithDet(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]));

                        }
                        else
                        {
                            dt_Tans = da_obj_rv.FAselLedgergrd4AllBranch(Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginDivisionId"]));

                        }
                        divgrd.Visible = false;
                        grd.Visible = false;
                    }
                    else
                    {
                        ds_OpBal = da_obj_rv.FASelopbal(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());
                        if (chkwithdtls.Checked == true)
                        {
                            dt_Tans = da_obj_rv.FAselLedgergrdWithDet(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());

                        }
                        else
                        {
                            dt_Tans = da_obj_rv.FAselLedgergrd(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname);

                        }
                    }
                }
                else
                {
                    if (ddl_Gst.SelectedItem.Text != "All")
                    {
                        gst = ddl_Gst.SelectedItem.Text;
                        string[] gstarr = gst.Split('/');

                        int len = gstarr[0].Count();
                        //len = len - 15;
                        //gst = gst.Remove(gst.Length - len);

                        gst = gstarr[0];

                    }
                    else
                    {
                        gst = "All";
                    }

                    if (ddl_lk.SelectedItem.Text!="All")
                    {
                        //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                        DataTable dt1 = new DataTable();
                        gst = ddl_Gst.SelectedItem.Text;
                        string[] gstarr = gst.Split('/');
                        //int len = gst.Count();
                        //len = len - 15;
                        //gst = gst.Remove(gst.Length - len);
                        gst = gstarr[0]; 
                        // dt1 = customerobj.GetLikeCustomerpan(TXTPANO.Text.ToString());
                        dt1 = customerobj.GetLikeCustomergst_lgd(gst.ToString(), TXTPANO.Text.ToString(), ddl_lk.SelectedItem.Text);
                        if (dt1.Rows.Count > 0)
                        {
                            portidlgd = Convert.ToInt32(dt1.Rows[0]["portid"].ToString());
                        }
                    }

                    //DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
                    int bid;

                    //bid = isfobj.GetBranch();
                    if (ddl_branch.SelectedItem.Text != "All")
                    {
                        bid = Emp_Obj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), ddl_branch.SelectedItem.Text);                      
                        Session["panBranchid"] = bid.ToString();
                    }
                    else if (ddl_branch.SelectedItem.Text == "All")
                    {
                        Session["panBranchid"] = "2";
                    }

                    ds_OpBal = da_obj_rv.FASelopbal(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());
                    if (chkwithdtls.Checked == true)
                    {
                        dt_Tans = da_obj_rv.FAselLedgergrdWithDet(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString());

                    }
                    else
                    {
                        if (portidlgd == 0)
                        {
                            dt_Tans = da_obj_rv.FAselLedgergrdGST_panno12almt(Convert.ToInt32(Session["panBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname, TXTPANO.Text, gst.ToString());
                        }
                        else
                        {
                            dt_Tans = da_obj_rv.FAselLedgergrdGST_panno_ledg(Convert.ToInt32(Session["panBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname, TXTPANO.Text, gst.ToString(), portidlgd);
                        }
                    }
                }
                //if (chkwithdtls.Checked == true || chkConsolidate.Checked == true)
                //{
                //    dt_Tans.Columns.Add("amountcr", typeof(double));
                //    dt_Tans.Columns.Add("voutypename");
                //    dt_Tans.Columns.Add("ClearedOn");

                //}
                dt_Tans.Columns.Add("famtcr", typeof(double));
                dt_Tans.Columns.Add("NetAmt", typeof(double));

                double dbl_Closing_dbamt = 0;
                double dbl_Closing_cramt = 0;
                double dbl_dbamt = 0;
                double dbl_cramt = 0;
                double dbl_Closing_dbfamt = 0;
                double dbl_Closing_crfamt = 0;
                double dbl_dbfamt = 0;
                double dbl_crfamt = 0;
                string pol = null;
                string pod = null;
                string mbl = null;

                double totopbaldb = 0;
                double totopbalcr = 0;
                double totopbalcrUSD = 0;
                double totopbaldbUSD = 0;
                DataTable dt = new DataTable();
                DataTable dtv = new DataTable();
                string str_curtype = "";

                if (ds_OpBal.Tables.Count > 0)
                {
                    dt = ds_OpBal.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        totopbaldb = Convert.ToDouble(dt.Rows[0][0].ToString());
                        totopbalcr = Convert.ToDouble(dt.Rows[0][1].ToString());
                        totopbaldbUSD = Convert.ToDouble(dt.Rows[0][2].ToString());
                        totopbalcrUSD = Convert.ToDouble(dt.Rows[0][3].ToString());
                        str_curtype = dt.Rows[0]["opbalcurr"].ToString();
                    }
                }

                dtv = ds_OpBal.Tables[1];
                if (dtv.Rows.Count > 0)
                {
                    for (int i = 0; i < dtv.Rows.Count; i++)
                    {
                        if (dtv.Rows[i]["ledgertype"].ToString() == "Cr")
                        {
                            totopbalcr = totopbalcr + Convert.ToDouble(dtv.Rows[i]["amount"].ToString());
                            totopbalcrUSD = totopbalcrUSD + Convert.ToDouble(dtv.Rows[i]["amountUSD"].ToString());
                        }
                        else
                        {
                            totopbaldb = totopbaldb + Convert.ToDouble(dtv.Rows[i]["amount"].ToString());
                            totopbaldbUSD = totopbaldbUSD + Convert.ToDouble(dtv.Rows[i]["amountUSD"].ToString());
                        }
                    }
                }

                if (totopbalcr > totopbaldb)
                {
                    totopbalcr = totopbalcr - totopbaldb;
                    totopbaldb = 0;
                }
                else if (totopbalcr < totopbaldb)
                {
                    totopbaldb = totopbaldb - totopbalcr;
                    totopbalcr = 0;
                }
                else
                {
                    totopbaldb = 0;
                    totopbalcr = 0;
                }

                if (totopbalcrUSD > totopbaldbUSD)
                {
                    totopbalcrUSD = totopbalcrUSD - totopbaldbUSD;
                    totopbaldbUSD = 0;
                }

                else if (totopbalcrUSD < totopbaldbUSD)
                {
                    totopbaldbUSD = totopbaldbUSD - totopbalcrUSD;
                    totopbalcrUSD = 0;
                }
                else
                {
                    totopbaldbUSD = 0;
                    totopbalcrUSD = 0;
                }

                DataRow dr_temp;
                dr_temp = dt_Tans.NewRow();
                dr_temp["voudate"] = Utility.fn_ConvertDate(dtfrom.Text);
                dr_temp["Vouno"] = -1;
                dr_temp["ltype"] = "Cr";
                dr_temp["voutypename"] = "";
                dr_temp["prti"] = "Opening Balance";
                dr_temp["amount"] = totopbaldb;
                dr_temp["amountcr"] = totopbalcr;

                if (chkConsolidate.Checked == false)
                {
                    if (ds_OpBal.Tables[0].Rows.Count > 0)
                    {
                        if (totopbaldb > 0)
                        {
                            dr_temp["ltype"] = "Dr";
                            dr_temp["amount"] = totopbaldb;
                            opbaldb = totopbaldb;
                            dr_temp["amountcr"] = 0;
                        }
                        else
                        {
                            dr_temp["ltype"] = "Cr";
                            dr_temp["amountcr"] = totopbalcr;
                            opbalcr = totopbalcr;
                            dr_temp["amount"] = 0;
                        }

                        dr_temp["fcur"] = str_curtype;
                        if (totopbaldbUSD > 0)
                        {

                            dr_temp["famt"] = totopbaldbUSD;
                            opbaldbUSD = totopbaldbUSD;
                            dr_temp["famtcr"] = 0;
                        }
                        else
                        {
                            dr_temp["famtcr"] = totopbalcrUSD;
                            opbalcrUSD = totopbalcrUSD;
                            dr_temp["famt"] = 0;
                        }
                    }

                    for (int i = 0; i < dt_Tans.Rows.Count; i++)
                    {
                        if (dt_Tans.Rows[i]["ltype"].ToString() == "Cr")
                        {
                            dt_Tans.Rows[i]["amountcr"] = dt_Tans.Rows[i]["amount"].ToString();
                            dt_Tans.Rows[i]["famtcr"] = Convert.ToDouble(dt_Tans.Rows[i]["famt"].ToString());
                            dt_Tans.Rows[i]["famt"] = 0;
                        }
                        else
                        {
                            dt_Tans.Rows[i]["amount"] = dt_Tans.Rows[i]["amount"].ToString();
                            dt_Tans.Rows[i]["amountcr"] = "0.00";
                            dt_Tans.Rows[i]["famt"] = Convert.ToDouble(dt_Tans.Rows[i]["famt"].ToString());
                            dt_Tans.Rows[i]["famtcr"] = 0;
                        }
                        string vouchername = FillVoucher(Convert.ToInt32(dt_Tans.Rows[i]["voutype"].ToString()));
                        dt_Tans.Rows[i]["voutypename"] = vouchername;
                        dt_Tans.Rows[i]["pol"] = dt_Tans.Rows[i]["pol"].ToString();
                        dt_Tans.Rows[i]["pod"] = dt_Tans.Rows[i]["pod"].ToString();
                        dt_Tans.Rows[i]["mbl"] = dt_Tans.Rows[i]["mbl"].ToString();
                        dt_Tans.Rows[i]["product"] = dt_Tans.Rows[i]["product"].ToString();
                        dt_Tans.Rows[i]["shipper"] = dt_Tans.Rows[i]["shipper"].ToString();
                        dt_Tans.Rows[i]["consignee"] = dt_Tans.Rows[i]["consignee"].ToString();

                        //dt_Tans.Rows[i]["NetAmt"] = (Convert.ToDouble(dt_Tans.Rows[i]["GrossAmt"]) - Convert.ToDouble(dt_Tans.Rows[i]["TaxAmt"])).ToString();
                        dt_Tans.Rows[i]["NetAmt"] = (Convert.ToDouble(dt_Tans.Rows[i]["GrossAmt"].ToString()) - Convert.ToDouble(dt_Tans.Rows[i]["TaxAmt"].ToString()) + Convert.ToDouble(dt_Tans.Rows[i]["TDSAmt"].ToString()));
                    }

                    dt_Tans.Rows.InsertAt(dr_temp, 0);

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    dr_temp["voutypename"] = 0;
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Transaction Total";
                    dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' and vouno>0");
                    dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr' and vouno>0");

                    dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' and vouno>0");
                    dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr' and vouno>0");
                    dt_Tans.Rows.Add(dr_temp);

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    dr_temp["voutypename"] = 0;
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Total";
                    dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' ");
                    dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr'");
                    dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' ");
                    dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr'");
                    if (dr_temp["amount"].ToString().Length == 0)
                    {
                        dr_temp["amount"] = "0.00";
                    }

                    if (dr_temp["amountcr"].ToString().Length == 0)
                    {
                        dr_temp["amountcr"] = "0.00";
                    }

                    if (dr_temp["famt"].ToString().Length == 0)
                    {
                        dr_temp["famt"] = "0.00";
                    }

                    if (dr_temp["famtcr"].ToString().Length == 0)
                    {
                        dr_temp["famtcr"] = "0.00";
                    }

                    dt_Tans.Rows.Add(dr_temp);

                    dbl_Closing_dbamt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountCr"].ToString());
                    dbl_Closing_cramt = dbl_Closing_dbamt;
                    dbl_dbamt = Convert.ToDouble(dr_temp["amount"].ToString());
                    dbl_cramt = Convert.ToDouble(dr_temp["amountCr"].ToString());

                    dbl_Closing_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString()) - Convert.ToDouble(dr_temp["famtCr"].ToString());
                    dbl_Closing_crfamt = dbl_Closing_dbfamt;
                    dbl_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString());
                    dbl_crfamt = Convert.ToDouble(dr_temp["famtCr"].ToString());

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    dr_temp["voutypename"] = 0;
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Closing Balance";

                    if (dbl_Closing_dbamt < 0)
                    {
                        dr_temp["amount"] = dbl_Closing_dbamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_dbamt = Convert.ToDouble(dbl_Closing_dbamt.ToString().Replace("-", ""));
                        dbl_Closing_cramt = 0;

                    }
                    else
                    {
                        dr_temp["amountcr"] = dbl_Closing_dbamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_dbamt = 0;

                    }

                    if (dbl_Closing_dbfamt < 0)
                    {
                        dr_temp["famt"] = dbl_Closing_dbfamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_dbfamt = Convert.ToDouble(dbl_Closing_dbfamt.ToString().Replace("-", ""));
                        dbl_Closing_crfamt = 0;
                    }
                    else
                    {
                        dr_temp["famtcr"] = dbl_Closing_dbfamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_dbfamt = 0;
                    }

                    dt_Tans.Rows.Add(dr_temp);

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    dr_temp["voutypename"] = 0;
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Grand Total";
                    dr_temp["amount"] = (dbl_Closing_dbamt + dbl_dbamt).ToString("#0.00").Replace("-", "");
                    dr_temp["amountcr"] = (dbl_Closing_cramt + dbl_cramt).ToString("#0.00").Replace("-", "");

                    dr_temp["famt"] = (dbl_Closing_dbfamt + dbl_dbfamt).ToString("#0.00").Replace("-", "");
                    dr_temp["famtcr"] = (dbl_Closing_crfamt + dbl_crfamt).ToString("#0.00").Replace("-", "");
                    dt_Tans.Rows.Add(dr_temp);
                    GRD_PAN.Visible = true;
                    grd.Visible = false;
                    grd.DataSource = dt_Tans;
                    grd.DataBind();
                    GRD_PAN.DataSource = dt_Tans;
                    GRD_PAN.DataBind();
                    
                    grdconsol.Visible = false;
                    if (grd.Rows.Count > 0)
                    {
                        div_outstd.Visible = true;
                    }
                    if (GRD_PAN.Rows.Count > 0)
                    {
                        div_outstd.Visible = true;
                    }
                }
                else
                {
                    grdconsol.Visible = true;
                    if (ds_OpBal.Tables[0].Rows.Count > 0)
                    {
                        if (totopbaldb > 0)
                        {
                            dr_temp["ltype"] = "Dr";
                            dr_temp["amount"] = totopbaldb;
                            opbaldb = totopbaldb;
                            dr_temp["amountcr"] = 0;
                        }
                        else
                        {
                            dr_temp["ltype"] = "Cr";
                            dr_temp["amountcr"] = totopbalcr;
                            opbalcr = totopbalcr;
                            dr_temp["amount"] = 0;
                        }

                        dr_temp["fcur"] = str_curtype;
                        if (totopbaldbUSD > 0)
                        {

                            dr_temp["famt"] = totopbaldbUSD;
                            opbaldbUSD = totopbaldbUSD;
                            dr_temp["famtcr"] = 0;
                        }
                        else
                        {
                            dr_temp["famtcr"] = totopbalcrUSD;
                            opbalcrUSD = totopbalcrUSD;
                            dr_temp["famt"] = 0;
                        }
                    }

                    for (int i = 0; i < dt_Tans.Rows.Count; i++)
                    {
                        if (dt_Tans.Rows[i]["ltype"].ToString() == "Cr")
                        {
                            dt_Tans.Rows[i]["amountcr"] = dt_Tans.Rows[i]["amount"].ToString();
                            dt_Tans.Rows[i]["famtcr"] = dt_Tans.Rows[i]["famt"].ToString();
                            dt_Tans.Rows[i]["famt"] = "0.00";
                        }
                        else
                        {
                            dt_Tans.Rows[i]["amount"] = dt_Tans.Rows[i]["amount"].ToString();
                            dt_Tans.Rows[i]["famt"] = dt_Tans.Rows[i]["famt"].ToString();
                            dt_Tans.Rows[i]["amountcr"] = "0.00";
                            dt_Tans.Rows[i]["famtcr"] = "0.00";
                        }
                        string vouchername = FillVoucher(Convert.ToInt32(dt_Tans.Rows[i]["voutype"].ToString()));
                        dt_Tans.Rows[i]["voutypename"] = vouchername;
                        dt_Tans.Rows[i]["pol"] = dt_Tans.Rows[i]["pol"].ToString();
                        dt_Tans.Rows[i]["pod"] = dt_Tans.Rows[i]["pod"].ToString();
                        dt_Tans.Rows[i]["mbl"] = dt_Tans.Rows[i]["mbl"].ToString();
                        dt_Tans.Rows[i]["product"] = dt_Tans.Rows[i]["product"].ToString();
                        dt_Tans.Rows[i]["shipper"] = dt_Tans.Rows[i]["shipper"].ToString();
                        dt_Tans.Rows[i]["consignee"] = dt_Tans.Rows[i]["consignee"].ToString();

                        //dt_Tans.Rows[i]["NetAmt"] = (Convert.ToDouble(dt_Tans.Rows[i]["GrossAmt"]) - Convert.ToDouble(dt_Tans.Rows[i]["TaxAmt"])).ToString();
                        dt_Tans.Rows[i]["NetAmt"] = (Convert.ToDouble(dt_Tans.Rows[i]["GrossAmt"].ToString()) - Convert.ToDouble(dt_Tans.Rows[i]["TaxAmt"].ToString()) + Convert.ToDouble(dt_Tans.Rows[i]["TDSAmt"].ToString()));

                    }

                    dt_Tans.Rows.InsertAt(dr_temp, 0);

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    //dr_temp["voutype"] = 0;
                    dr_temp["voutypename"] = "";
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Transaction Total";
                    dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' and vouno>0");
                    dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr' and vouno>0");
                    dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' and vouno>0");
                    dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr' and vouno>0");

                    dt_Tans.Rows.Add(dr_temp);

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    //dr_temp["voutype"] = 0;
                    dr_temp["voutypename"] = "";
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Total";
                    dr_temp["amount"] = dt_Tans.Compute("sum(Amount)", "ltype='Dr' ");
                    dr_temp["amountcr"] = dt_Tans.Compute("sum(Amountcr)", "ltype='Cr'");
                    dr_temp["famt"] = dt_Tans.Compute("sum(famt)", "ltype='Dr' ");
                    dr_temp["famtcr"] = dt_Tans.Compute("sum(famtcr)", "ltype='Cr' ");
                    if (dr_temp["amount"].ToString().Length == 0)
                    {
                        dr_temp["amount"] = "0.00";
                    }

                    if (dr_temp["amountcr"].ToString().Length == 0)
                    {
                        dr_temp["amountcr"] = "0.00";
                    }

                    if (dr_temp["famt"].ToString().Length == 0)
                    {
                        dr_temp["famt"] = "0.00";
                    }

                    if (dr_temp["famtcr"].ToString().Length == 0)
                    {
                        dr_temp["famtcr"] = "0.00";
                    }
                    //if (dr_temp["amount"].ToString().Length == 0)
                    //{
                    //    dr_temp["amount"] = "0.00";
                    //}
                    //else
                    //{
                    //    dr_temp["amount"] = Convert.ToDouble(dr_temp["amount"].ToString());
                    //}
                    //if (dr_temp["amountcr"].ToString().Length == 0)
                    //{
                    //    dr_temp["amountcr"] = "0.00";
                    //}
                    //else
                    //{
                    //    dr_temp["amountcr"] = Convert.ToDouble(dr_temp["amountcr"].ToString()) + opbalcr;
                    //}

                    //if (dr_temp["famt"].ToString().Length == 0)
                    //{
                    //    dr_temp["famt"] = "0.00";
                    //}
                    //else
                    //{
                    //    dr_temp["famt"] = Convert.ToDouble(dr_temp["famt"].ToString());
                    //}

                    //if (dr_temp["famtcr"].ToString().Length == 0)
                    //{
                    //    dr_temp["famtcr"] = "0.00";
                    //}
                    //else
                    //{
                    //    dr_temp["famtcr"] = Convert.ToDouble(dr_temp["famtcr"].ToString()) + opbalcrUSD;
                    //}

                    dt_Tans.Rows.Add(dr_temp);

                    dbl_Closing_dbamt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountcr"].ToString()); // -Convert.ToDouble(dr_temp["amountCr"].ToString());
                    dbl_Closing_cramt = Convert.ToDouble(dr_temp["amount"].ToString()) - Convert.ToDouble(dr_temp["amountcr"].ToString());
                    dbl_dbamt = Convert.ToDouble(dr_temp["amount"].ToString());
                    dbl_cramt = Convert.ToDouble(dr_temp["amountCr"].ToString());

                    dbl_Closing_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString()) - Convert.ToDouble(dr_temp["famtcr"].ToString()); // -Convert.ToDouble(dr_temp["amountCr"].ToString());
                    dbl_Closing_crfamt = Convert.ToDouble(dr_temp["famt"].ToString()) - Convert.ToDouble(dr_temp["famtcr"].ToString());
                    dbl_dbfamt = Convert.ToDouble(dr_temp["famt"].ToString());
                    dbl_crfamt = Convert.ToDouble(dr_temp["famtcr"].ToString());

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    //dr_temp["voutype"] = 0;
                    dr_temp["voutypename"] = "";
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Closing Balance";

                    if (dbl_Closing_dbamt < 0)
                    {
                        dr_temp["amount"] = dbl_Closing_dbamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_cramt = 0;
                    }
                    else
                    {
                        dr_temp["amountcr"] = dbl_Closing_dbamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_dbamt = 0;
                    }

                    if (dbl_Closing_dbfamt < 0)
                    {
                        dr_temp["famt"] = dbl_Closing_dbfamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_crfamt = 0;
                    }
                    else
                    {
                        dr_temp["famtcr"] = dbl_Closing_dbfamt.ToString("#0.00").Replace("-", "");
                        dbl_Closing_dbfamt = 0;
                    }

                    dt_Tans.Rows.Add(dr_temp);

                    dr_temp = dt_Tans.NewRow();
                    dr_temp["Vouno"] = 0;
                    //dr_temp["voutype"] = 0;
                    dr_temp["voutypename"] = "";
                    dr_temp["ltype"] = "";
                    dr_temp["prti"] = "Grand Total";
                    dr_temp["amount"] = (dbl_Closing_dbamt + dbl_dbamt).ToString("#0.00").Replace("-", "");
                    dr_temp["amountcr"] = (dbl_Closing_cramt + dbl_cramt).ToString("#0.00").Replace("-", "");

                    dr_temp["famt"] = (dbl_Closing_dbfamt + dbl_dbfamt).ToString("#0.00").Replace("-", "");
                    dr_temp["famtcr"] = (dbl_Closing_crfamt + dbl_crfamt).ToString("#0.00").Replace("-", "");

                    dt_Tans.Rows.Add(dr_temp);

                    GRD_PAN.DataSource = dt_Tans;
                    GRD_PAN.DataBind();
                    grdconsol.DataSource = dt_Tans;
                    grdconsol.DataBind();
                    if (grdconsol.Rows.Count > 0)
                    {
                        div_outstd.Visible = true;
                    }
                    if (GRD_PAN.Rows.Count > 0)
                    {
                        div_outstd.Visible = true;
                    }
                }
            }

            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                if (e.Row.Cells[1].Text == "0")
                {
                    e.Row.Cells[1].Text = "";
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[16].Text.Length > 25)
                    e.Row.Cells[16].Text = e.Row.Cells[16].Text.Substring(0, 25) + " ...";
                if (e.Row.Cells[9].Text.Length > 25)
                    e.Row.Cells[9].Text = e.Row.Cells[9].Text.Substring(0, 25) + " ...";
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString().Replace("AC-", "");

                if (e.Row.RowIndex == 0)
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                    {
                        e.Row.Cells[7].Text = e.Row.Cells[5].Text;
                    }
                    else
                    {
                        if (e.Row.Cells[6].Text != "&nbsp")
                        {
                            e.Row.Cells[7].Text = "-" + e.Row.Cells[6].Text.Replace("&nbsp", "");
                        }
                        else
                        {
                            e.Row.Cells[7].Text = "-" + string.Empty;
                        }
                    }
                }

                if (Convert.ToInt64(grd.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) <= 0 && e.Row.RowIndex > 0)
                {
                    if (double.TryParse(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text.ToString(), out dbl_temp))
                    {
                        if (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
                        {
                            grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Cr)").ToString().Replace("-", "");
                        }
                        else
                        {
                            grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Dr)").ToString();
                        }
                    }
                    e.Row.Cells[7].Text = "";
                }
                else
                {
                    if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                    {
                        e.Row.Cells[6].Text = "";
                        e.Row.Cells[20].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[5].Text = "";
                        e.Row.Cells[19].Text = "";
                    }

                    if (e.Row.Cells[7].Text == "-;")
                    {
                        e.Row.Cells[7].Text = "0.00";
                    }
                    if (Convert.ToInt32(grd.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) == 0)
                    {
                        e.Row.Cells[3].Text = FillVoucher(Convert.ToInt32(grd.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()));
                    }

                    if (e.Row.RowIndex >= 1)
                    {
                        if (grd.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                        {
                            e.Row.Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) + Convert.ToDouble(e.Row.Cells[5].Text)).ToString();
                        }
                        else
                        {
                            e.Row.Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) - Convert.ToDouble(e.Row.Cells[6].Text)).ToString();
                        }

                        if (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
                        {
                            grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Cr)").ToString().Replace("-", "");
                        }
                        else
                        {
                            grd.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grd.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Dr)").ToString();
                        }
                    }
                }
            }
        }

        protected void grd_Monthwise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToDouble(e.Row.Cells[2].Text.ToString()) > Convert.ToDouble(e.Row.Cells[3].Text.ToString()))
                {
                    e.Row.Cells[2].Text = string.Format("{0:#,##0.00}", Convert.ToDouble(e.Row.Cells[2].Text.ToString()) - Convert.ToDouble(e.Row.Cells[3].Text.ToString()));
                    e.Row.Cells[3].Text = "0.00";
                }
                else
                {
                    e.Row.Cells[3].Text = string.Format("{0:#,##0.00}", Convert.ToDouble(e.Row.Cells[3].Text.ToString()) - Convert.ToDouble(e.Row.Cells[2].Text.ToString()));
                    e.Row.Cells[2].Text = "0.00";
                }
            }
        }

        protected void grd_DayWise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToDouble(e.Row.Cells[1].Text) >= Convert.ToDouble(e.Row.Cells[2].Text))
                {
                    e.Row.Cells[1].Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(e.Row.Cells[1].Text) - Convert.ToDouble(e.Row.Cells[2].Text)));
                    e.Row.Cells[2].Text = "0.00";
                }
                else
                {
                    e.Row.Cells[2].Text = string.Format("{0:#,##0.00}", (Convert.ToDouble(e.Row.Cells[2].Text) - Convert.ToDouble(e.Row.Cells[1].Text)));
                    e.Row.Cells[1].Text = "0.00";
                }
            }
            //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        }

        protected void btnagref_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds_ARD = new DataSet();
                DataTable dt_ARD = new DataTable();
                DateTime FromDate;
                DateTime ToDate;
                int cncl = 0;
                FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));
                if (chkConsolidate.Checked == true)
                {
                    ds_ARD = da_obj_famaster.SelAgainstRefDet(Session["FADbname"].ToString(), int.Parse(hidId.Value.ToString()), FromDate, ToDate, 0, int.Parse(Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    ds_ARD = da_obj_famaster.SelAgainstRefDet(Session["FADbname"].ToString(), int.Parse(hidId.Value.ToString()), FromDate, ToDate, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                }

                dt_ARD = ds_ARD.Tables[0];
                dt_ARD.Merge(ds_ARD.Tables[1]);

                if (dt_ARD.Rows.Count > 1)
                {
                    DataRow drv;
                    drv = dt_ARD.NewRow();
                    drv[3] = "Total";
                    int int_vouno = 0;
                    double dbl_TOTamt = 0;
                    double dbl_AdjAMt = 0;
                    for (int i = 0; i <= dt_ARD.Rows.Count - 1; i++)
                    {
                        if (int_vouno != Convert.ToInt32(dt_ARD.Rows[i]["voucher#"].ToString()))
                        {
                            int_vouno = Convert.ToInt32(dt_ARD.Rows[i]["voucher#"].ToString());
                            dbl_TOTamt = dbl_TOTamt + Convert.ToDouble(dt_ARD.Rows[i]["VouAmt"].ToString());
                        }
                    }
                    drv[5] = dbl_TOTamt;
                    drv[8] = dt_ARD.Compute("sum(AdjustAmt)", "");
                    for (int i = 0; i <= dt_ARD.Rows.Count - 1; i++)
                    {
                        dbl_AdjAMt = dbl_AdjAMt + Convert.ToDouble(dt_ARD.Rows[i]["OutStanding"].ToString());
                    }
                    drv[9] = dbl_AdjAMt.ToString();
                    dt_ARD.Rows.Add(drv);
                }

                dt_ARD.Merge(ds_ARD.Tables[2]);
                grdard.DataSource = dt_ARD;
                grdard.DataBind();
                if (grdard.Rows.Count > 0)
                {
                    divgrd.Visible = false;
                    grd.Visible = false;
                    grdard.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void btnpendbills_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt_tempfrom;
                DateTime dt_tempto;
                DataTable dtpend = new DataTable();
                DataRow dr = null;
                DataTable dtgrddy = new DataTable();

                int index = 0;
                int c = 0;
                int lastindex = 0;
                Double dbl_tot_OB = 0;
                Double dbl_tot_PA = 0;
                int cncl = 0;
                dt_tempfrom = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                dt_tempto = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));

                if (chk_MonthWise.Checked == true)
                {
                    if (grd_Monthwise.Rows.Count == 0)
                    {
                        return;
                    }

                    //index = grd_Monthwise.CurrentRow.Index;
                    //dt_tmpFrom = grd_Monthwise.Rows(index).Cells("VoucherMonth").Value.ToString() + "/01/" + grd_Monthwise.Rows(index).Cells("VoucherYear").Value.ToString();
                    //dt_tmpTo = dt_tmpFrom.AddMonths(1);
                    //dt_tmpTo = dt_tmpTo.AddDays(-1);
                }
                else
                {
                    dt_tempfrom = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                    dt_tempto = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));
                }

                dtpend = da_obj_famaster.FAgetinvoice4Refno(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(hidId.Value.ToString()), dt_tempfrom, dt_tempto, Session["FADbname"].ToString());

                dtgrddy = new DataTable();

                for (int i = 0; i <= dtpend.Rows.Count - 1; i++)
                {
                    if (int.Parse(dtpend.Rows[i]["diff"].ToString()) != 0)
                    {
                        DataRow drCurrentRow = dtgrddy.NewRow();
                        drCurrentRow["grdref"] = ((Label)grdPendingRef.FindControl("grdref")).Text;
                        drCurrentRow["job"] = ((TextBox)grdPendingRef.FindControl("job")).Text;
                        drCurrentRow["grdopbal"] = ((TextBox)grdPendingRef.FindControl("grdopbal")).Text;
                        drCurrentRow["grdpenamt"] = ((TextBox)grdPendingRef.FindControl("grdpenamt")).Text;
                        drCurrentRow["grdtypevalue"] = ((TextBox)grdPendingRef.FindControl("grdtypevalue")).Text;

                        dtgrddy.Rows.Add(drCurrentRow);

                        DataRow dr1 = dtgrddy.NewRow();
                        dr1["grdref"] = dtpend.Rows[i]["refno"].ToString();
                        dr1["job"] = dtpend.Rows[i]["jobno"].ToString();
                        dr1["grdopbal"] = String.Format("{0:0.00}", (dtpend.Rows[i]["damt"]));
                        dr1["grdpenamt"] = String.Format("{0:0.00}", (dtpend.Rows[i]["diff"]));
                        dbl_tot_OB = dbl_tot_OB + double.Parse(dtpend.Rows[i]["damt"].ToString());
                        dbl_tot_PA = dbl_tot_PA + double.Parse(dtpend.Rows[i]["diff"].ToString());
                        dtgrddy.Rows.Add(dr1);
                    }
                }
                DataRow dr2 = dtgrddy.NewRow();
                dr2["grdref"] = ((Label)grdPendingRef.FindControl("grdref")).Text;
                dr2["job"] = ((TextBox)grdPendingRef.FindControl("job")).Text;
                dr2["grdopbal"] = ((TextBox)grdPendingRef.FindControl("grdopbal")).Text;
                dr2["grdpenamt"] = ((TextBox)grdPendingRef.FindControl("grdpenamt")).Text;
                dr2["grdtypevalue"] = ((TextBox)grdPendingRef.FindControl("grdtypevalue")).Text;
                dr2["grdref"] = "";
                dr2["job"] = "Total";
                dr2["grdopbal"] = String.Format("{0:0.00}", (dbl_tot_OB));
                dr2["grdpenamt"] = String.Format("{0:0.00}", (dbl_tot_PA));
                dtgrddy.Rows.Add(dr2);

                grdPendingRef.DataSource = dtgrddy;
                grdPendingRef.DataBind();

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1110, 3, int.Parse(Session["LoginBranchid"].ToString()), "Pending Bills" + grdPendingRef.Rows[cncl].Cells[0].Text + "Against Reference/V");
                }
                else
                {
                    da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1202, 3, int.Parse(Session["LoginBranchid"].ToString()), "Pending Bills" + grdPendingRef.Rows[cncl].Cells[0].Text + "Against Reference/V");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btnallbills_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt_tempfrom;
                DateTime dt_tempto;
                DataTable dtpend = new DataTable();
                DataRow dr = null;
                DataTable dtgrddy = new DataTable();

                Double dbl_tot_OB = 0;
                Double dbl_tot_PA = 0;
                int cncl = 0;
                dt_tempfrom = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                dt_tempto = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));

                if (chk_MonthWise.Checked == true)
                {
                    if (grd_Monthwise.Rows.Count == 0)
                    {
                        return;
                    }

                    //index = grd_Monthwise.CurrentRow.Index;
                    //dt_tmpFrom = grd_Monthwise.Rows(index).Cells("VoucherMonth").Value.ToString() + "/01/" + grd_Monthwise.Rows(index).Cells("VoucherYear").Value.ToString();
                    //dt_tmpTo = dt_tmpFrom.AddMonths(1);
                    //dt_tmpTo = dt_tmpTo.AddDays(-1);
                }
                else
                {
                    dt_tempfrom = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                    dt_tempto = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));
                }

                dtpend = da_obj_famaster.FAgetinvoice4Refno(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(hidId.Value.ToString()), dt_tempfrom, dt_tempto, Session["FADbname"].ToString());

                dtgrddy = new DataTable();

                for (int i = 0; i <= dtpend.Rows.Count - 1; i++)
                {
                    if (int.Parse(dtpend.Rows[i]["diff"].ToString()) != 0)
                    {
                        DataRow drCurrentRow = dtgrddy.NewRow();
                        drCurrentRow["grdref"] = ((Label)grdPendingRef.FindControl("grdref")).Text;
                        drCurrentRow["job"] = ((TextBox)grdPendingRef.FindControl("job")).Text;
                        drCurrentRow["grdopbal"] = ((TextBox)grdPendingRef.FindControl("grdopbal")).Text;
                        drCurrentRow["grdpenamt"] = ((TextBox)grdPendingRef.FindControl("grdpenamt")).Text;
                        drCurrentRow["grdtypevalue"] = ((TextBox)grdPendingRef.FindControl("grdtypevalue")).Text;

                        dtgrddy.Rows.Add(drCurrentRow);

                        DataRow dr1 = dtgrddy.NewRow();
                        dr1["grdref"] = dtpend.Rows[i]["refno"].ToString();
                        dr1["job"] = dtpend.Rows[i]["jobno"].ToString();
                        dr1["grdopbal"] = String.Format("{0:0.00}", (dtpend.Rows[i]["damt"]));
                        dr1["grdpenamt"] = String.Format("{0:0.00}", (dtpend.Rows[i]["diff"]));
                        dbl_tot_OB = dbl_tot_OB + double.Parse(dtpend.Rows[i]["damt"].ToString());
                        dbl_tot_PA = dbl_tot_PA + double.Parse(dtpend.Rows[i]["diff"].ToString());
                        dtgrddy.Rows.Add(dr1);
                    }
                }
                DataRow dr2 = dtgrddy.NewRow();
                dr2["grdref"] = ((Label)grdPendingRef.FindControl("grdref")).Text;
                dr2["job"] = ((TextBox)grdPendingRef.FindControl("job")).Text;
                dr2["grdopbal"] = ((TextBox)grdPendingRef.FindControl("grdopbal")).Text;
                dr2["grdpenamt"] = ((TextBox)grdPendingRef.FindControl("grdpenamt")).Text;
                dr2["grdtypevalue"] = ((TextBox)grdPendingRef.FindControl("grdtypevalue")).Text;
                dr2["grdref"] = "";
                dr2["job"] = "Total";
                dr2["grdopbal"] = String.Format("{0:0.00}", (dbl_tot_OB));
                dr2["grdpenamt"] = String.Format("{0:0.00}", (dbl_tot_PA));
                dtgrddy.Rows.Add(dr2);

                grdPendingRef.DataSource = dtgrddy;
                grdPendingRef.DataBind();

                if (Session["str_ModuleName"].ToString() == "FA")
                {
                    da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1110, 3, int.Parse(Session["LoginBranchid"].ToString()), "Pending Bills" + grdPendingRef.Rows[cncl].Cells[0].Text + "Against Reference/V");
                }
                else
                {
                    da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1202, 3, int.Parse(Session["LoginBranchid"].ToString()), "Pending Bills" + grdPendingRef.Rows[cncl].Cells[0].Text + "Against Reference/V");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        //private void ExportToExcel()
        //{
        //    int did = Convert.ToInt32(Session["LoginDivisionid"].ToString());
        //    if (grdconsol.Rows.Count > 0 && grdconsol.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        grdconsol.GridLines = GridLines.Both;
        //        grdconsol.HeaderStyle.Font.Bold = true;
        //        grdconsol.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }
        //    else if (grd.Rows.Count > 0 && grd.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        if (TXTPANO.Text != "")
        //        {
        //            Response.AddHeader("content-disposition", "attachment;filename=" + TXTPANO.Text.Replace(",", "") + ".xls");
        //        }
        //        else
        //        {
        //            Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        }
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        grd.GridLines = GridLines.Both;
        //        grd.HeaderStyle.Font.Bold = true;
        //        grd.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }
        //    else if (GRD_PAN.Rows.Count > 0 && GRD_PAN.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        if (TXTPANO.Text != "")
        //        {
        //            Response.AddHeader("content-disposition", "attachment;filename=" + TXTPANO.Text.Replace(",", "") + ".xls");
        //        }
        //        else
        //        {
        //            Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        }
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        GRD_PAN.GridLines = GridLines.Both;
        //        GRD_PAN.HeaderStyle.Font.Bold = true;
        //        GRD_PAN.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }
        //    else if (grd_Monthwise.Rows.Count > 0 && grd_Monthwise.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        grd_Monthwise.GridLines = GridLines.Both;
        //        grd_Monthwise.HeaderStyle.Font.Bold = true;
        //        grd_Monthwise.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }
        //    else if (grd_DayWise.Rows.Count > 0 && grd_DayWise.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        grd_DayWise.GridLines = GridLines.Both;
        //        grd_DayWise.HeaderStyle.Font.Bold = true;
        //        grd_DayWise.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }
        //    else if (grdPendingRef.Rows.Count > 0 && grdPendingRef.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        grdPendingRef.GridLines = GridLines.Both;
        //        grdPendingRef.HeaderStyle.Font.Bold = true;
        //        grdPendingRef.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }
        //    else if (grdPendingBills.Rows.Count > 0 && grdPendingBills.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        grdPendingBills.GridLines = GridLines.Both;
        //        grdPendingBills.HeaderStyle.Font.Bold = true;
        //        grdPendingBills.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }
        //    else if (grdard.Rows.Count > 0 && grdard.Visible == true)
        //    {
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.xls";
        //        StringWriter StringWriter = new System.IO.StringWriter();
        //        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        //        grdard.GridLines = GridLines.Both;
        //        grdard.HeaderStyle.Font.Bold = true;
        //        grdard.RenderControl(HtmlTextWriter);
        //        Response.Write(StringWriter.ToString());
        //        Response.End();
        //    }

        //}

        private void ExportToExcel()
        {
            int did = Convert.ToInt32(Session["LoginDivisionid"].ToString());
            if (grdconsol.Rows.Count > 0 && grdconsol.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = grdconsol.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + txtLedgerName.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                grdconsol.GridLines = GridLines.Both;
                grdconsol.HeaderStyle.Font.Bold = true;
                grdconsol.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (grd.Rows.Count > 0 && grd.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                if (TXTPANO.Text != "")
                {
                    Response.AddHeader("content-disposition", "attachment;filename=" + TXTPANO.Text.Replace(",", "") + ".xls");
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                }
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = grd.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + txtLedgerName.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                grd.GridLines = GridLines.Both;
                grd.HeaderStyle.Font.Bold = true;
                grd.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (GRD_PAN.Rows.Count > 0 && GRD_PAN.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                if (TXTPANO.Text != "")
                {
                    Response.AddHeader("content-disposition", "attachment;filename=" + TXTPANO.Text.Replace(",", "") + ".xls");
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                }
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = GRD_PAN.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + TXT_custn.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                GRD_PAN.GridLines = GridLines.Both;
                GRD_PAN.HeaderStyle.Font.Bold = true;
                GRD_PAN.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (grd_Monthwise.Rows.Count > 0 && grd_Monthwise.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = grd_Monthwise.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + txtLedgerName.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                grd_Monthwise.GridLines = GridLines.Both;
                grd_Monthwise.HeaderStyle.Font.Bold = true;
                grd_Monthwise.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (grd_DayWise.Rows.Count > 0 && grd_DayWise.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = grd_DayWise.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + txtLedgerName.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                grd_DayWise.GridLines = GridLines.Both;
                grd_DayWise.HeaderStyle.Font.Bold = true;
                grd_DayWise.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (grdPendingRef.Rows.Count > 0 && grdPendingRef.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = grdPendingRef.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + txtLedgerName.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                grdPendingRef.GridLines = GridLines.Both;
                grdPendingRef.HeaderStyle.Font.Bold = true;
                grdPendingRef.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (grdPendingBills.Rows.Count > 0 && grdPendingBills.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = grdPendingBills.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + txtLedgerName.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                grdPendingBills.GridLines = GridLines.Both;
                grdPendingBills.HeaderStyle.Font.Bold = true;
                grdPendingBills.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
            else if (grdard.Rows.Count > 0 && grdard.Visible == true)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + txtLedgerName.Text.Replace(",", "") + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                int Count = grdard.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=center colspan=" + Count + "><font face=arial size=3;><B>" + txtLedgerName.Text + " From " + dtfrom.Text + " To " + dtto.Text + "</B></font></td></tr>");
                SB.Append("</table><br />");

                grdard.GridLines = GridLines.Both;
                grdard.HeaderStyle.Font.Bold = true;
                grdard.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }

        }

        protected void btnexcel_Click(object sender, EventArgs e)
        {

            ExportToExcel();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.FAMaster.ReportView Obj_Report = new DataAccess.FAMaster.ReportView();
                string Str_RptName = "", Str_Script = "", Str_SF = "", Str_SP = "";

                if (hidId.Value != "")
                {
                    if (grd.Rows.Count > 0)
                    {
                        Obj_Report.DelTempFALedgerView(Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

                        for (int i = 0; i < grd.Rows.Count - 1; i++)
                        {
                            if (grd.Rows[i].Visible == true)
                            {
                                if (grd.Rows[i].Cells[5].Text == "")
                                {
                                    grd.Rows[i].Cells[5].Text = "0.00";
                                }
                                if (grd.Rows[i].Cells[6].Text == "")
                                {
                                    grd.Rows[i].Cells[6].Text = "0.00";
                                }
                                if (grd.Rows[i].Cells[2].Text == "")
                                {
                                    grd.Rows[i].Cells[2].Text = "0";
                                }
                                if (grd.Rows[i].Cells[21].Text == "")
                                {
                                    grd.Rows[i].Cells[21].Text = "0.00";
                                }
                                if (grd.Rows[i].Cells[22].Text == "")
                                {
                                    grd.Rows[i].Cells[22].Text = "0.00";
                                }
                                if (grd.Rows[i].Cells[23].Text == "")
                                {
                                    grd.Rows[i].Cells[23].Text = "0.00";
                                }

                                Label grdconsolvalue1 = (Label)grd.Rows[i].FindControl("lblprti");
                                Label grdconsolvalue2 = (Label)grd.Rows[i].FindControl("lblnarration");
                                Label grdconsolvalue3 = (Label)grd.Rows[i].FindControl("lblcontainerno");
                                Label grdconsolvalue4 = (Label)grd.Rows[i].FindControl("lblvendorrefno");
                                Label grdconsolvalue5 = (Label)grd.Rows[i].FindControl("lblrefno");

                                string str1 = grdconsolvalue1.Text;
                                string str2 = grdconsolvalue2.Text;
                                string str3 = grdconsolvalue3.Text;
                                string str4 = grdconsolvalue4.Text;
                                string str5 = grdconsolvalue5.Text;

                                //Obj_Report.InsTempLedgerView(Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), grd.Rows[i].Cells[0].Text, grd.Rows[i].Cells[2].Text, grd.Rows[i].Cells[1].Text, grd.Rows[i].Cells[4].Text,
                                //Convert.ToDouble(grd.Rows[i].Cells[5].Text), Convert.ToDouble(grd.Rows[i].Cells[6].Text), grd.Rows[i].Cells[7].Text, grd.Rows[i].Cells[8].Text, grd.Rows[i].Cells[9].Text, grd.Rows[i].Cells[10].Text, Convert.ToInt32(grd.Rows[i].Cells[11].Text), grd.Rows[i].Cells[12].Text,
                                //grd.Rows[i].Cells[14].Text, Convert.ToDouble(grd.Rows[i].Cells[15].Text), Convert.ToDouble(grd.Rows[i].Cells[16].Text), Convert.ToDouble(grd.Rows[i].Cells[17].Text), i);
                                string value = "";
                                int jobno = 0;
                                if (i == 0)
                                {
                                    if (grd.DataKeys[i].Values[1].ToString() == "-1")
                                    {
                                        value = "";

                                    }
                                }
                                else
                                {
                                    value = grd.DataKeys[i].Values[1].ToString();
                                }
                                if (grd.Rows[i].Cells[2].Text != "0" && grd.Rows[i].Cells[2].Text != "" && grd.Rows[i].Cells[2].Text != "0.00")
                                {
                                    jobno = Convert.ToInt32((grd.Rows[i].Cells[2].Text).Substring(7, (grd.Rows[i].Cells[2].Text).Length - 7));
                                }
                                Obj_Report.InsTempLedgerView(Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), grd.Rows[i].Cells[0].Text, value, grd.Rows[i].Cells[2].Text, str1,
                                Convert.ToDouble(grd.Rows[i].Cells[5].Text), Convert.ToDouble(grd.Rows[i].Cells[6].Text), grd.Rows[i].Cells[7].Text, str2, str3, str4, jobno, str5,
                                grd.Rows[i].Cells[20].Text, Convert.ToDouble(grd.Rows[i].Cells[21].Text), Convert.ToDouble(grd.Rows[i].Cells[22].Text), Convert.ToDouble(grd.Rows[i].Cells[23].Text), i);
                            }
                        }
                    }

                    if (grdconsol.Rows.Count > 0)
                    {
                        Obj_Report.DelTempFALedgerView(Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString());

                        for (int i = 0; i < grdconsol.Rows.Count - 1; i++)
                        {
                            if (grdconsol.Rows[i].Visible == true)
                            {
                                if (grdconsol.Rows[i].Cells[5].Text == "")
                                {
                                    grdconsol.Rows[i].Cells[5].Text = "0.00";
                                }
                                if (grdconsol.Rows[i].Cells[6].Text == "")
                                {
                                    grdconsol.Rows[i].Cells[6].Text = "0.00";
                                }
                                if (grdconsol.Rows[i].Cells[2].Text == "")
                                {
                                    grdconsol.Rows[i].Cells[2].Text = "0";
                                }
                                if (grdconsol.Rows[i].Cells[21].Text == "")
                                {
                                    grdconsol.Rows[i].Cells[21].Text = "0.00";
                                }
                                if (grdconsol.Rows[i].Cells[22].Text == "")
                                {
                                    grdconsol.Rows[i].Cells[22].Text = "0.00";
                                }
                                if (grdconsol.Rows[i].Cells[23].Text == "")
                                {
                                    grdconsol.Rows[i].Cells[23].Text = "0.00";
                                }

                                Label grdconsolvalue1 = (Label)grdconsol.Rows[i].FindControl("lblprti");
                                Label grdconsolvalue2 = (Label)grdconsol.Rows[i].FindControl("lblnarration");
                                Label grdconsolvalue3 = (Label)grdconsol.Rows[i].FindControl("lblcontainerno");
                                Label grdconsolvalue4 = (Label)grdconsol.Rows[i].FindControl("lblvendorrefno");
                                Label grdconsolvalue5 = (Label)grdconsol.Rows[i].FindControl("lblrefno");

                                string str1 = grdconsolvalue1.Text;
                                string str2 = grdconsolvalue2.Text;
                                string str3 = grdconsolvalue3.Text;
                                string str4 = grdconsolvalue4.Text;
                                string str5 = grdconsolvalue5.Text;

                                //Obj_Report.InsTempLedgerView(Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), grd.Rows[i].Cells[0].Text, grd.Rows[i].Cells[2].Text, grd.Rows[i].Cells[1].Text, grd.Rows[i].Cells[4].Text,
                                //Convert.ToDouble(grd.Rows[i].Cells[5].Text), Convert.ToDouble(grd.Rows[i].Cells[6].Text), grd.Rows[i].Cells[7].Text, grd.Rows[i].Cells[8].Text, grd.Rows[i].Cells[9].Text, grd.Rows[i].Cells[10].Text, Convert.ToInt32(grd.Rows[i].Cells[11].Text), grd.Rows[i].Cells[12].Text,
                                //grd.Rows[i].Cells[14].Text, Convert.ToDouble(grd.Rows[i].Cells[15].Text), Convert.ToDouble(grd.Rows[i].Cells[16].Text), Convert.ToDouble(grd.Rows[i].Cells[17].Text), i);
                                string value = "";
                                int jobno = 0;
                                if (i == 0)
                                {
                                    if (grdconsol.DataKeys[i].Values[1].ToString() == "-1")
                                    {
                                        value = "";

                                    }
                                }
                                else
                                {
                                    value = grdconsol.DataKeys[i].Values[1].ToString();
                                }
                                if (grdconsol.Rows[i].Cells[2].Text != "0" && grdconsol.Rows[i].Cells[2].Text != "" && grdconsol.Rows[i].Cells[2].Text != "0.00")
                                {
                                    jobno = Convert.ToInt32((grdconsol.Rows[i].Cells[2].Text).Substring(7, (grdconsol.Rows[i].Cells[2].Text).Length - 7));
                                }
                                Obj_Report.InsTempLedgerView(Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), grdconsol.Rows[i].Cells[0].Text, value, grdconsol.Rows[i].Cells[2].Text, str1,
                                Convert.ToDouble(grdconsol.Rows[i].Cells[5].Text), Convert.ToDouble(grdconsol.Rows[i].Cells[6].Text), grdconsol.Rows[i].Cells[7].Text, str2, str3, str4, jobno, str5,
                                grdconsol.Rows[i].Cells[20].Text, Convert.ToDouble(grdconsol.Rows[i].Cells[21].Text), Convert.ToDouble(grdconsol.Rows[i].Cells[22].Text), Convert.ToDouble(grdconsol.Rows[i].Cells[23].Text), i);
                            }
                        }
                    }

                    Str_RptName = "rptFALedgerView.rpt";
                    Session["str_sfs"] = "{tempLedgerview.empid}=" + Session["LoginEmpId"].ToString();
                    Session["str_sp"] = "LegName=" + txtLedgerName.Text + "~FromDate= " + Utility.fn_ConvertDate(dtfrom.Text) + "~ToDate= " + Utility.fn_ConvertDate(dtto.Text);

                    Str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "JobInfo", Str_Script, true);

                    if (Session["str_ModuleName"].ToString() == "FA")
                    {
                        da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1110, 3, int.Parse(Session["LoginBranchid"].ToString()), txtLedgerName.Text + "" + dtfrom.Text + "" + dtto.Text + "Print/V");
                    }
                    else
                    {
                        da_obj_log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 1202, 3, int.Parse(Session["LoginBranchid"].ToString()), txtLedgerName.Text + "" + dtfrom.Text + "" + dtto.Text + "Print/V");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string voutype = ""; int vtype = 0;
                int vouno = 0, index = 0, PBid = 0;
                string osvtype = "";
                string gvlname = "";
                string VDate = "";
                Boolean flag = false;
                int logcorid = 0;
                int uiid;
                logcorid = da_obj_emp.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), "CORPORATE");
                index = grd.SelectedRow.RowIndex;
                voutype = grd.Rows[index].Cells[1].Text;
                vouno = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());

                if (voutype != "")
                {
                    if (grd.DataKeys[index].Values[2].ToString() == "" || grd.DataKeys[index].Values[2].ToString() == "&nbsp")
                    {
                        PBid = 0;
                    }
                    else
                    {
                        PBid = Convert.ToInt32(grd.DataKeys[index].Values[2].ToString());
                    }


                    if (voutype == "Invoice" || voutype == "Sales Invoice")
                    {
                        gvlname = "Invoices";
                        vtype = 1;
                    }
                    else if (voutype == "Bill of Supply")
                    {
                        gvlname = "Bill of Supply";
                        vtype = 20;
                    }

                    else if (voutype == "Purchase Invoice" || voutype == "CreditNote - Operations")
                    {
                        gvlname = "Credit Note - Operations";
                        vtype = 2;
                    }
                    else if (voutype == "OS DN" || voutype == "OSSI")
                    {
                        gvlname = "OSSI";
                        vtype = 5;
                    }
                    else if (voutype == "OS CN" || voutype == "OSPI")
                    {
                        gvlname = "OSPI";
                        vtype = 6;
                    }
                    else if (voutype == "Debit Note" || voutype == "Debit Note - Others")
                    {
                        gvlname = "Debit Note - Others";
                        vtype = 7;
                    }
                    else if (voutype == "Credit Note" || voutype == "Credit Note - Others")
                    {
                        gvlname = "Credit Note - Others";
                        vtype = 8;
                    }
                    else if (voutype == "Proforma Invoices")
                    {
                        gvlname = "Proforma Invoices";
                        vtype = 1;
                    }
                    else if (voutype == "Extentions")
                    {
                        gvlname = "Extentions";
                    }
                    else if (voutype == "FinalBills")
                    {
                        gvlname = "FinalBills";
                    }
                    else if (voutype == "OSDNCNJV")
                    {
                        gvlname = "OSDNCNJV";
                    }

                    //if (voutype == "Invoice")
                    //{
                    //    gvlname = "Invoices";
                    //}
                    //else if (voutype == "Bill of Supply")
                    //{
                    //    gvlname = "Bill of Supply";
                    //}

                    //else if (voutype == "Purchase Invoice" || voutype == "CreditNote - Operations")
                    //{
                    //    gvlname = "Credit Note - Operations";
                    //}
                    //else if (voutype == "OS DN" || voutype == "OSSI")
                    //{
                    //    gvlname = "OSSI";
                    //}
                    //else if (voutype == "OS CN" || voutype == "OSPI")
                    //{
                    //    gvlname = "OSPI";
                    //}
                    //else if (voutype == "Debit Note" || voutype == "Debit Note - Others")
                    //{
                    //    gvlname = "Debit Note - Others";
                    //}
                    //else if (voutype == "Credit Note" || voutype == "Credit Note - Others")
                    //{
                    //    gvlname = "Credit Note - Others";
                    //}
                    //else if (voutype == "Proforma Invoices")
                    //{
                    //    gvlname = "Proforma Invoices";
                    //}
                    //else if (voutype == "Extentions")
                    //{
                    //    gvlname = "Extentions";
                    //}
                    //else if (voutype == "FinalBills")
                    //{
                    //    gvlname = "FinalBills";
                    //}
                    //else if (voutype == "OSDNCNJV")
                    //{
                    //    gvlname = "OSDNCNJV";
                    //}

                    if (gvlname != "")
                    {
                        if (grd.Rows.Count > 0)
                        {
                            index = grd.SelectedRow.RowIndex;
                            voutype = grd.Rows[index].Cells[1].Text;
                            vouno = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                            if (grd.DataKeys[index].Values[2].ToString() == "" || grd.DataKeys[index].Values[2].ToString() == "&nbsp")
                            {
                                PBid = 0;
                            }
                            else
                            {
                                PBid = int.Parse(grd.DataKeys[index].Values[2].ToString());
                            }

                            osvtype = grd.DataKeys[index].Values[3].ToString().Replace("&nbsp", ""); //grd.Rows[index].Cells[16].Text.Replace("&nbsp", "");
                            if (voutype != "")
                            {
                                if (PBid == Convert.ToInt32(Session["Loginbranchid"].ToString()))
                                {
                                    if (gvlname == "OSDNCNJV")
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&VNo=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);
                                        voutype = grd.DataKeys[index].Values[3].ToString();
                                        string FrmName = "LedgerView_Voucher";
                                        iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&Vno=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        ModalPopupExtender1.Show();
                                    }
                                    else
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?QueryVoucherName=" + gvlname + "&Flag=" + true + "&PBranch_ID=" + PBid + "&QueryVoucherNo=" + vouno + "&OsvType=" + osvtype + "&LedgerID=" + hidId.Value + "&FromDate=" + dtfrom.Text + "&ToDate=" + dtto.Text + "&LedgerName=" + txtLedgerName.Text + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        //string FrmName = "LedgerView_Voucher";
                                        //iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?QueryVoucherName=" + gvlname + "&Flag=" + true + "&PBranch_ID=" + PBid + "&QueryVoucherNo=" + vouno + "&OsvType=" + osvtype + "&LedgerID=" + hidId.Value + "&FromDate=" + dtfrom.Text + "&ToDate=" + dtto.Text + "&LedgerName=" + txtLedgerName.Text + "&FrmName=" + FrmName;

                                        string FrmName = "LedgerView_Voucher";
                                        if (vtype == 5 || vtype == 6)
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/OSVouchers.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }
                                        else
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/ApprovedLV.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }

                                        ModalPopupExtender1.Show();
                                    }
                                }
                                else
                                {
                                    if (gvlname == "OSDNCNJV")
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&VNo=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);
                                        voutype = grd.DataKeys[index].Values[3].ToString();
                                        string FrmName = "LedgerView_Voucher";
                                        iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&Vno=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        ModalPopupExtender1.Show();
                                    }
                                    else
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?Vno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&FormName=" + gvlname + "&OsvType=" + osvtype + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        string FrmName = "LedgerView_Voucher";
                                        //iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?Vno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&FormName=" + gvlname + "&OsvType=" + osvtype + "&FrmName=" + FrmName;
                                        if (vtype == 5 || vtype == 6)
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/OSVouchers.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }
                                        else
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/ApprovedLV.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }

                                        ModalPopupExtender1.Show();
                                    }
                                }
                            }
                            return;
                        }
                    }

                    if (voutype == "Bank Receipt")
                    {
                        gvlname = "Bank Receipt";
                    }
                    else if (voutype == "Cash Receipt")
                    {
                        gvlname = "Cash Receipt";
                    }
                    else if (voutype == "Bank Payment")
                    {
                        gvlname = "Bank Payment";
                    }
                    else if (voutype == "Cash Payment")
                    {
                        gvlname = "Cash Payment";
                    }
                    else if (voutype == "BDJV")
                    {
                        gvlname = "BDJV";
                    }
                    else if (voutype == "BPJV")
                    {
                        gvlname = "BPJV";
                    }
                    else if (voutype == "Receipt - Petty Cash")
                    {
                        gvlname = "Receipt - Petty Cash";
                    }
                    else if (voutype == "Remittance-Receipt")
                    {
                        gvlname = "Remittance-Receipt";
                    }
                    else if (voutype == "Remittance-Payment")
                    {
                        gvlname = "Remittance-Payment";
                    }
                    else if (voutype == "BRG")
                    {
                        gvlname = "BRG";
                    }

                    if (gvlname != "")
                    {
                        if (grd.Rows.Count > 0)
                        {
                            index = grd.SelectedRow.RowIndex;
                            voutype = grd.Rows[index].Cells[1].Text;
                            vouno = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                            if (grd.DataKeys[index].Values[2].ToString() == "" || grd.DataKeys[index].Values[2].ToString() == "&nbsp")
                            {
                                PBid = 0;
                            }
                            else
                            {
                                PBid = Convert.ToInt32(grd.DataKeys[index].Values[2].ToString());
                            }

                            osvtype = grd.DataKeys[index].Values[3].ToString();
                            if (voutype != "")
                            {
                                if (PBid == int.Parse(Session["Loginbranchid"].ToString()))
                                {
                                    //string url = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);

                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    ModalPopupExtender1.Show();

                                }
                                else
                                {
                                    //string url = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + true;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);

                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + true;
                                    ModalPopupExtender1.Show();
                                }
                            }
                            return;
                        }
                    }

                    if (voutype == "Admin Sales Invoice")
                    {
                        gvlname = "Admin Sales Invoice"; ;
                    }
                    else if (voutype == "Admin Purchase Invoice")
                    {
                        gvlname = "Admin Purchase Invoice";
                    }

                    if (gvlname != "")
                    {

                        if (grd.Rows.Count > 0)
                        {
                            index = grd.SelectedRow.RowIndex;
                            voutype = grd.Rows[index].Cells[1].Text;

                            if (voutype == "Admin Sales Invoice")
                            {
                                uiid = 1182;
                            }
                            else
                            {
                                uiid = 1183;
                            }
                            vouno = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                            if (grd.DataKeys[index].Values[2].ToString() == "" || grd.DataKeys[index].Values[2].ToString() == "&nbsp")
                            {
                                PBid = 0;
                            }
                            else
                            {
                                PBid = Convert.ToInt32(grd.DataKeys[index].Values[2].ToString());
                            }

                            osvtype = grd.DataKeys[index].Values[3].ToString();
                            if (voutype != "")
                            {
                                //string url = "../FAForms/FAPAAdmin.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                                //string fullURL = "window.open('" + url + "', '_blank' );";
                                //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                //Response.Redirect(url);

                                string FrmName = "LedgerView_Voucher";
                                //iframecost.Attributes["src"] = "../FAForms/AdminDCNNo.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid + "&uiid=" + uiid;
                                iframecost.Attributes["src"] = "../FAForms/ApprovedAdminDCNvouchers.aspx?type=" + voutype + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                                ModalPopupExtender1.Show();
                            }
                            return;
                        }
                    }

                    if (voutype == "Contra")
                    {
                        gvlname = "Contra";
                        index = grd.SelectedRow.RowIndex;
                        voutype = grd.Rows[index].Cells[1].Text;
                        VDate = grd.Rows[index].Cells[0].Text;
                        vouno = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                        if (grd.DataKeys[index].Values[1].ToString() == "" || grd.DataKeys[index].Values[1].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                        }

                        osvtype = grd.DataKeys[index].Values[3].ToString();
                        if (voutype != "")
                        {
                            //string url = "../FAForms/Contra.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            //string fullURL = "window.open('" + url + "', '_blank' );";
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                            //Response.Redirect(url);
                            //return;

                            string FrmName = "LedgerView_Voucher";
                            iframecost.Attributes["src"] = "../FAForms/Contra.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + VDate;
                            ModalPopupExtender1.Show();
                        }
                    }

                    if (voutype == "Journal")
                    {

                        gvlname = "Journal";
                        index = grd.SelectedRow.RowIndex;
                        VDate = grd.Rows[index].Cells[0].Text;
                        voutype = grd.Rows[index].Cells[1].Text;
                        vouno = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                        if (grd.DataKeys[index].Values[2].ToString() == "" || grd.DataKeys[index].Values[2].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = Convert.ToInt32(grd.DataKeys[index].Values[2].ToString());
                        }

                        osvtype = grd.DataKeys[index].Values[3].ToString();
                        if (voutype != "")
                        {
                            //string url = "../FAForms/Journal.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            //string fullURL = "window.open('" + url + "', '_blank' );";
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                            //Response.Redirect(url);
                            //return;

                            string FrmName = "LedgerView_Voucher";
                            iframecost.Attributes["src"] = "../FAForms/Journal.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + grd.Rows[index].Cells[0].Text + "&VType=" + osvtype;
                            ModalPopupExtender1.Show();
                        }
                    }

                    if (voutype == "Adjustment DCN")
                    {
                        gvlname = "CN";
                        index = grd.SelectedRow.RowIndex;
                        voutype = grd.Rows[index].Cells[1].Text;
                        vouno = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                        if (grd.DataKeys[index].Values[1].ToString() == "" || grd.DataKeys[index].Values[1].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = Convert.ToInt32(grd.DataKeys[index].Values[1].ToString());
                        }

                        osvtype = grd.DataKeys[index].Values[3].ToString();
                        if (voutype != "")
                        {
                            //string url = "../FAForms/AdjustmenrtDNCN.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            //string fullURL = "window.open('" + url + "', '_blank' );";
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                            //Response.Redirect(url);
                            //return;

                            string FrmName = "LedgerView_Voucher";
                            iframecost.Attributes["src"] = "../FAForms/AdjustmenrtDNCN.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            ModalPopupExtender1.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grdPendingRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string refno = "";
                int index = 0;
                string voutype = "";
                int vouno = 0;
                Boolean flag = false;
                DateTime FromDate;
                DateTime ToDate;
                DateTime dt_tmpFrom;
                DateTime dt_tmpto;
                DataTable dt1 = new DataTable();
                Double dbl_tot_OB = 0;
                Double dbl_tot_PA = 0;

                index = grdPendingRef.SelectedRow.RowIndex;

                if (refno != "")
                {
                    int grdindex = 0;

                    grdindex = grdPendingRef.SelectedRow.RowIndex;

                    if (chk_MonthWise.Checked == true)
                    {
                        index = grd_Monthwise.SelectedRow.RowIndex;
                        dt_tmpFrom = Convert.ToDateTime(Utility.fn_ConvertDate(grd_Monthwise.DataKeys[index]["VoucherMonth"].ToString() + "/01/" + grd_Monthwise.Rows[index].Cells[0].ToString()));
                        dt_tmpto = dt_tmpFrom.AddMonths(1);
                        dt_tmpto = dt_tmpto.AddDays(-1);
                    }
                    else
                    {
                        FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                        ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));
                    }

                    for (int i = 0; i > grdPendingRef.Rows.Count; i++)
                    {
                        if (grdPendingRef.Rows[i].Cells[4].Text == "V")
                        {
                            if (grdPendingRef.Rows[grdindex].Cells[4].Text == "V")
                            {
                                voutype = grdPendingRef.Rows[grdindex].Cells[0].Text.ToString();
                                try
                                {
                                    vouno = int.Parse(grdPendingRef.Rows[grdindex].Cells[1].Text.ToString());
                                }
                                catch (Exception ex)
                                {
                                    return;
                                }

                                if (voutype != "")
                                {
                                    int PBid = 0;
                                    string osvtype = "";
                                    string gvlname = "";
                                    int logcorid = 0;
                                    logcorid = da_obj_emp.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), "CORPORATE");
                                    //int pBid = 0;
                                    if (voutype == "Invoice")
                                    {
                                        gvlname = "Invoices";
                                    }
                                    else if (voutype == "Purchase Invoice" || voutype == "CreditNote - Operations")
                                    {
                                        gvlname = "Credit Note - Operations";
                                    }
                                    else if (voutype == "OS DN" || voutype == "OSSI")
                                    {
                                        gvlname = "OSSI";
                                    }
                                    else if (voutype == "OS CN" || voutype == "OSPI")
                                    {
                                        gvlname = "OSPI";
                                    }
                                    else if (voutype == "Debit Note" || voutype == "Debit Note - Others")
                                    {
                                        gvlname = "Debit Note - Others";
                                    }
                                    else if (voutype == "Credit Note" || voutype == "Credit Note - Others")
                                    {
                                        gvlname = "Credit Note - Others";
                                    }
                                    else if (voutype == "Proforma Invoices")
                                    {
                                        gvlname = "Proforma Invoices";
                                    }
                                    else if (voutype == "Extentions")
                                    {
                                        gvlname = "Extentions";
                                    }
                                    else if (voutype == "FinalBills")
                                    {
                                        gvlname = "FinalBills";
                                    }

                                    //string url = "../FAForms/Voucher.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);

                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    ModalPopupExtender1.Show();

                                    if (voutype == "Bank Receipt")
                                    {
                                        gvlname = "Bank Receipt";
                                        //url = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        //fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        ModalPopupExtender1.Show();
                                    }
                                    else if (voutype == "Cash Receipt")
                                    {
                                        gvlname = "Cash Receipt";
                                        //url = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        //fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        ModalPopupExtender1.Show();
                                    }
                                    else if (voutype == "Bank Payment")
                                    {
                                        gvlname = "Bank Payment";
                                        //url = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        //fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        ModalPopupExtender1.Show();
                                    }
                                    else if (voutype == "Cash Payment")
                                    {
                                        gvlname = "Cash Payment";
                                        //url = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        //fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?gblvname=" + gvlname + "&vouno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                        ModalPopupExtender1.Show();
                                    }

                                    if (voutype == "Admin Sales Invoice")
                                    {
                                        gvlname = "Admin Sales Invoice"; ;
                                        //url = "../FAForms/FAPAAdmin.aspx?vname=" + gvlname + "&vouno=" + vouno;
                                        //fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        //iframecost.Attributes["src"] = "../FAForms/AdminDCNNo.aspx?vname=" + gvlname + "&vouno=" + vouno + "&PBranch_ID=" + PBid + "&uiid=" + "1182";
                                        
                                        
                                        iframecost.Attributes["src"] = "../FAForms/ApprovedAdminDCNvouchers.aspx?type=" + voutype + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                                        
                                        ;
                                        ModalPopupExtender1.Show();
                                    }
                                    else if (voutype == "Admin Purchase Invoice")
                                    {
                                        gvlname = "Admin Purchase Invoice";
                                        //url = "../FAForms/FAPAAdmin.aspx?vname=" + gvlname + "&vouno=" + vouno;
                                        //fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        //iframecost.Attributes["src"] = "../FAForms/AdminDCNNo.aspx?vname=" + gvlname + "&vouno=" + vouno + "&PBranch_ID=" + PBid + "&uiid=" + "1183";
                                        iframecost.Attributes["src"] = "../FAForms/ApprovedAdminDCNvouchers.aspx?type=" + voutype + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                                        ModalPopupExtender1.Show();
                                    }

                                    if (voutype == "Contra")
                                    {
                                        gvlname = "Contra";
                                        if (voutype != "")
                                        {                                        //url = "../FAForms/Contra.aspx?vname=" + gvlname + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                            //fullURL = "window.open('" + url + "', '_blank' );";
                                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                            //Response.Redirect(url);

                                            iframecost.Attributes["src"] = "../FAForms/Contra.aspx?vname=" + gvlname + "&vouno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + grdPendingRef.Rows[index].Cells[0].Text + "&VType=" + osvtype;
                                            ModalPopupExtender1.Show();
                                        }
                                    }

                                    if (voutype == "Journal")
                                    {
                                        gvlname = "Journal";
                                        index = grdPendingRef.SelectedRow.RowIndex;
                                        voutype = grdPendingRef.Rows[index].Cells[1].Text;
                                        vouno = int.Parse(grdPendingRef.Rows[index].Cells[2].Text);
                                        PBid = int.Parse(grdPendingRef.Rows[index].Cells[13].Text);
                                        osvtype = grdPendingRef.Rows[index].Cells[19].Text;

                                        if (voutype != "")
                                        {
                                            //url = "../FAForms/Journal.aspx?vname=" + gvlname + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                            //fullURL = "window.open('" + url + "', '_blank' );";
                                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                            //Response.Redirect(url);

                                            iframecost.Attributes["src"] = "../FAForms/Journal.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + grdPendingRef.Rows[index].Cells[0].Text + "&VType=" + osvtype;
                                            ModalPopupExtender1.Show();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                FromDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtfrom.Text.ToString()));
                ToDate = Convert.ToDateTime(Utility.fn_ConvertDate(dtto.Text.ToString()));

                int j = 0;
                DataTable dtnew = da_obj_famaster.FAgetinvoice4Vouno(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), refno);
                if (dtnew.Rows.Count > 0)
                {

                    for (int i = 0; i > dtnew.Rows.Count; i++)
                    {
                        DataRow drCurrentRow = dtnew.NewRow();
                        drCurrentRow["grdref"] = ((Label)grdPendingRef.FindControl("grdref")).Text;
                        drCurrentRow["job"] = ((TextBox)grdPendingRef.FindControl("job")).Text;
                        drCurrentRow["grdopbal"] = ((TextBox)grdPendingRef.FindControl("grdopbal")).Text;
                        drCurrentRow["grdpenamt"] = ((TextBox)grdPendingRef.FindControl("grdpenamt")).Text;
                        //drCurrentRow["grdtypevalue"] = ((TextBox)grdPendingRef.FindControl("grdtypevalue")).Text;

                        dtnew.Rows.Add(drCurrentRow);

                        DataRow dr1 = dtnew.NewRow();
                        dr1["grdref"] = dtnew.Rows[i]["voutypename"].ToString();
                        dr1["job"] = dtnew.Rows[i]["vouno"].ToString();
                        dr1["grdopbal"] = String.Format("{0:0.00}", (dtnew.Rows[i]["damt"]));
                        dr1["grdpenamt"] = String.Format("{0:0.00}", (dtnew.Rows[i]["diff"]));
                        dbl_tot_OB = dbl_tot_OB + double.Parse(dtnew.Rows[i]["damt"].ToString());
                        dbl_tot_PA = dbl_tot_PA + double.Parse(dtnew.Rows[i]["diff"].ToString());
                        dtnew.Rows.Add(dr1);
                    }

                    DataRow dr2 = dtnew.NewRow();
                    dr2["grdref"] = ((Label)grdPendingRef.FindControl("grdref")).Text;
                    dr2["job"] = ((TextBox)grdPendingRef.FindControl("job")).Text;
                    dr2["grdopbal"] = ((TextBox)grdPendingRef.FindControl("grdopbal")).Text;
                    dr2["grdpenamt"] = ((TextBox)grdPendingRef.FindControl("grdpenamt")).Text;
                    dr2["grdref"] = "";
                    dr2["job"] = "Total";
                    dr2["grdopbal"] = String.Format("{0:0.00}", (dbl_tot_OB));
                    dr2["grdpenamt"] = String.Format("{0:0.00}", (dbl_tot_PA));
                    dtnew.Rows.Add(dr2);

                    grdPendingRef.DataSource = dtnew;
                    grdPendingRef.DataBind();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void grdPendingRef_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdPendingRef, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        }

        protected void Esc_Btn_Click(object sender, EventArgs e)
        {
            //bool EscValue = Convert.ToBoolean(Session["EcsValue"]);
            //string Customer = Request.QueryString["Customer"].ToString();
            //if (EscValue == true)
            //{
            //    Response.Redirect("../FAForms/Outstanding_Online.aspx?FlgValue=" + true + "&CustomerName=" + Customer + "");
            //}
        }

        protected void grdconsol_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdconsol, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                if (e.Row.Cells[1].Text == "0")
                {
                    e.Row.Cells[1].Text = "";
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[16].Text.Length > 25)
                    e.Row.Cells[16].Text = e.Row.Cells[16].Text.Substring(0, 25) + " ...";
                if (e.Row.Cells[9].Text.Length > 25)
                    e.Row.Cells[9].Text = e.Row.Cells[9].Text.Substring(0, 25) + " ...";
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString().Replace("AC-", "");

                if (e.Row.RowIndex == 0)
                {
                    if (grdconsol.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                    {
                        e.Row.Cells[7].Text = e.Row.Cells[5].Text;
                    }
                    else
                    {
                        if (e.Row.Cells[6].Text != "&nbsp")
                        {
                            e.Row.Cells[7].Text = "-" + e.Row.Cells[6].Text.Replace("&nbsp", "");
                        }
                        else
                        {
                            e.Row.Cells[7].Text = "-" + string.Empty;
                        }
                    }
                }

                if (Convert.ToInt64(grdconsol.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) <= 0 && e.Row.RowIndex > 0)
                {
                    if (double.TryParse(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text.ToString(), out dbl_temp))
                    {
                        if (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
                        {
                            grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Cr)").ToString().Replace("-", "");
                        }
                        else
                        {
                            grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Dr)").ToString();
                        }
                    }
                    e.Row.Cells[7].Text = "";
                }
                else
                {
                    if (grdconsol.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                    {
                        e.Row.Cells[6].Text = "";
                        e.Row.Cells[20].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[5].Text = "";
                        e.Row.Cells[19].Text = "";
                    }

                    if (e.Row.Cells[7].Text == "-;")
                    {
                        e.Row.Cells[7].Text = "0.00";
                    }
                    if (Convert.ToInt32(grdconsol.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) == 0)
                    {
                        e.Row.Cells[3].Text = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()));
                    }

                    if (e.Row.RowIndex >= 1)
                    {
                        if (grdconsol.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                        {
                            e.Row.Cells[7].Text = (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text) + Convert.ToDouble(e.Row.Cells[5].Text)).ToString();
                        }
                        else
                        {
                            e.Row.Cells[7].Text = (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text) - Convert.ToDouble(e.Row.Cells[6].Text)).ToString();
                        }

                        if (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text) < 0)
                        {
                            grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Cr)").ToString().Replace("-", "");
                        }
                        else
                        {
                            grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text = (Convert.ToDouble(grdconsol.Rows[e.Row.RowIndex - 1].Cells[7].Text).ToString("#,0.00") + "  (Dr)").ToString();
                        }
                    }
                }
            }
        }

        protected void grdconsol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String voutype = "";
                int vouno = 0;
                int index = 0;
                int PBid = 0;
                string osvtype = "";
                string gvlname = "";
                Boolean flag = false;
                int logcorid = 0;
                int uiid;

                logcorid = da_obj_emp.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), "CORPORATE");
                index = grdconsol.SelectedRow.RowIndex;
                voutype = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[index].Values["voutype"].ToString()));
                vouno = Convert.ToInt32(grdconsol.DataKeys[index].Values["vouno"].ToString());
                string Pbranchid = grdconsol.DataKeys[index].Values[3].ToString();

                if (Pbranchid == "")
                {
                    PBid = 0;
                }
                else
                {
                    PBid = Convert.ToInt32(grdconsol.DataKeys[index].Values[3].ToString());
                }

                if (voutype == "Invoice")
                {
                    gvlname = "Invoices";
                }
                else if (voutype == "Bill of Supply")
                {
                    gvlname = "Bill of Supply";
                }
                else if (voutype == "Credit Note - Operations" || voutype == "CreditNote - Operations")
                {
                    gvlname = "Credit Note - Operations";
                }
                else if (voutype == "OS DN" || voutype == "OSSI")
                {
                    gvlname = "OSSI";
                }
                else if (voutype == "OS CN" || voutype == "OSPI")
                {
                    gvlname = "OSPI";
                }
                else if (voutype == "Debit Note" || voutype == "Debit Note - Others")
                {
                    gvlname = "Debit Note - Others";
                }
                else if (voutype == "Credit Note" || voutype == "Credit Note - Others")
                {
                    gvlname = "Credit Note - Others";
                }
                else if (voutype == "Proforma Invoices")
                {
                    gvlname = "Proforma Invoices";
                }
                else if (voutype == "Extentions")
                {
                    gvlname = "Extentions";
                }
                else if (voutype == "FinalBills")
                {
                    gvlname = "FinalBills";
                }
                else if (voutype == "OSDNCNJV")
                {
                    gvlname = "OSDNCNJV";
                }

                if (gvlname != "")
                {
                    if (grdconsol.Rows.Count > 0)
                    {
                        index = grdconsol.SelectedRow.RowIndex;
                        // voutype = grdconsol.Rows[index].Cells[2].Text.ToString();
                        voutype = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[index].Values["voutype"].ToString()));
                        vouno = Convert.ToInt32(grdconsol.DataKeys[index].Values["vouno"].ToString());
                        if (grdconsol.DataKeys[index].Values[3].ToString() == "" || grdconsol.DataKeys[index].Values[3].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = Convert.ToInt32(grdconsol.DataKeys[index].Values[3].ToString());
                        }

                        osvtype = grdconsol.DataKeys[index].Values[4].ToString().Replace("&nbsp", ""); //grdconsol.Rows[index].Cells[16].Text.Replace("&nbsp", "");
                        if (voutype != "")
                        {
                            if (PBid == int.Parse(Session["Loginbranchid"].ToString()))
                            {
                                if (gvlname == "OSDNCNJV")
                                {
                                    //string url = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&VNo=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    // string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);
                                    voutype = grd.DataKeys[index].Values[3].ToString();
                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&Vno=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    ModalPopupExtender1.Show();
                                }
                                else
                                {
                                    //string url = "../FAForms/Voucher.aspx?QueryVoucherName=" + gvlname + "&Flag=" + true + "&PBranch_ID=" + PBid + "&QueryVoucherNo=" + vouno + "&OsvType=" + osvtype;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);

                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?QueryVoucherName=" + gvlname + "&Flag=" + true + "&PBranch_ID=" + PBid + "&QueryVoucherNo=" + vouno + "&OsvType=" + osvtype;
                                    ModalPopupExtender1.Show();
                                }
                            }
                            else
                            {
                                if (gvlname == "OSDNCNJV")
                                {
                                    //string url = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&VNo=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);
                                    voutype = grd.DataKeys[index].Values[3].ToString();
                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&Vno=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    ModalPopupExtender1.Show();
                                }
                                else
                                {
                                    //string url = "../FAForms/Voucher.aspx?Vno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&FormName=" + gvlname + "&OsvType=" + osvtype;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);

                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?Vno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&FormName=" + gvlname + "&OsvType=" + osvtype;
                                    ModalPopupExtender1.Show();
                                }
                            }
                        }
                        return;
                    }
                }

                if (voutype == "Bank Receipt")
                {
                    gvlname = "Bank Receipt";
                }
                else if (voutype == "Cash Receipt")
                {
                    gvlname = "Cash Receipt";
                }
                else if (voutype == "Bank Payment")
                {
                    gvlname = "Bank Payment";
                }
                else if (voutype == "Cash Payment")
                {
                    gvlname = "Cash Payment";
                }
                else if (voutype == "BDJV")
                {
                    gvlname = "BDJV";
                }
                else if (voutype == "BPJV")
                {
                    gvlname = "BPJV";
                }
                else if (voutype == "Receipt - Petty Cash")
                {
                    gvlname = "Receipt - Petty Cash";
                }
                else if (voutype == "Remittance-Receipt")
                {
                    gvlname = "Remittance-Receipt";
                }
                else if (voutype == "Remittance-Payment")
                {
                    gvlname = "Remittance-Payment";
                }
                else if (voutype == "BRG")
                {
                    gvlname = "BRG";
                }

                if (gvlname != "")
                {
                    if (grdconsol.Rows.Count > 0)
                    {
                        index = grdconsol.SelectedRow.RowIndex;
                        //  voutype = grdconsol.Rows[index].Cells[2].Text.ToString();
                        voutype = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[index].Values["voutype"].ToString()));
                        vouno = Convert.ToInt32(grdconsol.DataKeys[index].Values["vouno"].ToString());
                        //if (grdconsol.DataKeys[index].Values[3].ToString() == "" || grdconsol.DataKeys[index].Values[3].ToString() == "&nbsp")
                        //{
                        //    PBid = 0;
                        //}
                        //else
                        //{
                        //    PBid = int.Parse(grdconsol.DataKeys[index].Values[3].ToString());
                        //}

                        if (voutype == "Bank Payment")
                        {
                            if (grdconsol.Rows[index].Cells[26].Text == "" || grdconsol.Rows[index].Cells[26].Text == "&nbsp")
                            {
                                PBid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                            }
                            else
                            {
                                PBid = int.Parse(grdconsol.Rows[index].Cells[26].Text);
                            }
                        }
                        else
                        {
                            if (grdconsol.DataKeys[index].Values[3].ToString() == "" || grdconsol.DataKeys[index].Values[3].ToString() == "&nbsp")
                            {
                                PBid = 0;
                            }
                            else
                            {
                                PBid = int.Parse(grdconsol.DataKeys[index].Values[3].ToString());
                            }
                        }

                        osvtype = grdconsol.Rows[index].Cells[16].Text;
                        if (voutype != "")
                        {
                            if (PBid == int.Parse(Session["Loginbranchid"].ToString()))
                            {
                                //string url = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                //string fullURL = "window.open('" + url + "', '_blank' );";
                                //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                //Response.Redirect(url);

                                string FrmName = "LedgerView_Voucher";
                                iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                ModalPopupExtender1.Show();
                            }
                            else
                            {
                                //string url = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + true;
                                //string fullURL = "window.open('" + url + "', '_blank' );";
                                //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                //Response.Redirect(url);

                                string FrmName = "LedgerView_Voucher";
                                iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + true;
                                ModalPopupExtender1.Show();
                            }
                        }
                        return;
                    }
                }

                if (voutype == "Admin Sales Invoice")
                {
                    gvlname = "Admin Sales Invoice"; ;
                }
                else if (voutype == "Admin Purchase Invoice")
                {
                    gvlname = "Admin Purchase Invoice";
                }

                if (gvlname != "")
                {

                    if (grdconsol.Rows.Count > 0)
                    {
                        index = grdconsol.SelectedRow.RowIndex;
                        //voutype = grdconsol.Rows[index].Cells[2].Text.ToString();
                        voutype = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[index].Values["voutype"].ToString()));
                        if (voutype == "Admin Sales Invoice")
                        {
                            uiid = 1182;
                        }
                        else
                        {
                            uiid = 1183;
                        }
                        vouno = Convert.ToInt32(grdconsol.DataKeys[index].Values["vouno"].ToString());
                        if (grdconsol.DataKeys[index].Values[3].ToString() == "" || grdconsol.DataKeys[index].Values[3].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = int.Parse(grdconsol.DataKeys[index].Values[3].ToString());
                        }

                        osvtype = grdconsol.DataKeys[index].Values[4].ToString();
                        if (voutype != "")
                        {
                            //string url = "../FAForms/FAPAAdmin.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            //string fullURL = "window.open('" + url + "', '_blank' );";
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                            //Response.Redirect(url);

                            string FrmName = "LedgerView_Voucher";
                            //iframecost.Attributes["src"] = "../FAForms/AdminDCNNo.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid + "&uiid=" + uiid;
                            iframecost.Attributes["src"] = "../FAForms/ApprovedAdminDCNvouchers.aspx?type=" + voutype + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            ModalPopupExtender1.Show();
                        }
                        return;
                    }
                }

                if (voutype == "Contra")
                {
                    gvlname = "Contra";
                    index = grdconsol.SelectedRow.RowIndex;
                    //voutype = grdconsol.Rows[index].Cells[2].Text.ToString();
                    voutype = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[index].Values["voutype"].ToString()));
                    vouno = Convert.ToInt32(grdconsol.DataKeys[index].Values["vouno"].ToString());
                    if (grdconsol.DataKeys[index].Values[3].ToString() == "" || grdconsol.DataKeys[index].Values[3].ToString() == "&nbsp")
                    {
                        PBid = 0;
                    }
                    else
                    {
                        PBid = int.Parse(grdconsol.DataKeys[index].Values[3].ToString());
                    }

                    osvtype = grdconsol.DataKeys[index].Values[4].ToString();
                    if (voutype != "")
                    {
                        //string url = "../FAForms/Contra.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                        //string fullURL = "window.open('" + url + "', '_blank' );";
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                        //Response.Redirect(url);
                        //return;

                        string FrmName = "LedgerView_Voucher";
                        iframecost.Attributes["src"] = "../FAForms/Contra.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + grdconsol.Rows[index].Cells[0].Text;
                        ModalPopupExtender1.Show();
                    }
                }

                if (voutype == "Journal")
                {
                    gvlname = "Journal";
                    index = grdconsol.SelectedRow.RowIndex;
                    // voutype = grdconsol.Rows[index].Cells[2].Text.ToString();
                    voutype = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[index].Values["voutype"].ToString()));
                    vouno = Convert.ToInt32(grdconsol.DataKeys[index].Values["vouno"].ToString());
                    if (grdconsol.DataKeys[index].Values[3].ToString() == "" || grdconsol.DataKeys[index].Values[3].ToString() == "&nbsp")
                    {
                        PBid = 0;
                    }
                    else
                    {
                        PBid = int.Parse(grdconsol.DataKeys[index].Values[3].ToString());
                    }

                    osvtype = grdconsol.DataKeys[index].Values[4].ToString();
                    if (voutype != "")
                    {
                        //string url = "../FAForms/Journal.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                        //string fullURL = "window.open('" + url + "', '_blank' );";
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                        //Response.Redirect(url);
                        //return;

                        string FrmName = "LedgerView_Voucher";
                        iframecost.Attributes["src"] = "../FAForms/Journal.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + grdconsol.Rows[index].Cells[0].Text + "&VType=" + osvtype;
                        ModalPopupExtender1.Show();
                    }
                }

                if (voutype == "Adjustment DCN")
                {
                    gvlname = "CN";
                    index = grdconsol.SelectedRow.RowIndex;
                    voutype = FillVoucher(Convert.ToInt32(grdconsol.DataKeys[index].Values["voutype"].ToString()));
                    //voutype = grdconsol.Rows[index].Cells[2].Text.ToString();
                    vouno = Convert.ToInt32(grdconsol.DataKeys[index].Values["vouno"].ToString());
                    if (grdconsol.DataKeys[index].Values[3].ToString() == "" || grdconsol.DataKeys[index].Values[3].ToString() == "&nbsp")
                    {
                        PBid = 0;
                    }
                    else
                    {
                        PBid = int.Parse(grdconsol.DataKeys[index].Values[3].ToString());
                    }

                    osvtype = grdconsol.DataKeys[index].Values[4].ToString();
                    if (voutype != "")
                    {
                        //string url = "../FAForms/AdjustmenrtDNCN.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                        //string fullURL = "window.open('" + url + "', '_blank' );";
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                        //Response.Redirect(url);
                        //return;

                        string FrmName = "LedgerView_Voucher";
                        iframecost.Attributes["src"] = "../FAForms/AdjustmenrtDNCN.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                        ModalPopupExtender1.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {

                div_outstd.Visible = false;
                grdconsol.DataSource = new DataTable();
                grdconsol.DataBind();
                divgrd.Visible = true;
                grd.DataSource = new DataTable();
                grd.DataBind();
                TXTPANO.Text = "";
                TXT_custn.Text = "";
                ddl_Gst.Items.Clear();
                txt_gstl.Text = "";
                ddl_Gst.Items.Add("All");
                ddl_lk.Items.Clear();
                txt_gstl.Text = "";
                ddl_lk.Items.Add("All");
                txtLedgerName.Text = "";
                //dtfrom.Text = Utility.fn_ConvertDate(da_obj_log.GetDate().AddMonths(-1).ToShortDateString());
                //dtto.Text = Utility.fn_ConvertDate(da_obj_log.GetDate().ToShortDateString());
                int Vouyear = Convert.ToInt32(Session["LogYear"].ToString());
                string Str_CurrrentDate = DateTime.Now.ToString("dd/MM/yyyy");
                DateTime Date = da_obj_rv.MaxVouGetDate(Session["FADbname"].ToString());

                //if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month < 3) || Vouyear == (DateTime.Now).Year)
                //{
                //    //dtfrom.Text = Str_CurrrentDate;
                //    //dtto.Text = Str_CurrrentDate;
                //    dtfrom.Text = "01/04/" + Vouyear;
                //    dtto.Text = Str_CurrrentDate;
                //}
                //else
                //{
                //    dtfrom.Text = "01/04/" + Vouyear;
                //    dtto.Text = "31/03/" + (Vouyear + 1);
                //}
                if ((Vouyear == (DateTime.Now).Year - 1 && (DateTime.Now).Month < 3) || Vouyear == (DateTime.Now).Year)
                {
                    //dtfrom.Text = Str_CurrrentDate;
                    //dtto.Text = Str_CurrrentDate;
                    dtfrom.Text = "01/01/" + Vouyear;
                    dtto.Text = Str_CurrrentDate;
                }
                else
                {
                    dtfrom.Text = "01/01/" + Vouyear;
                    dtto.Text = "31/12/" + (Vouyear + 1);
                }
                chk_alias.Checked = false;
                chk_MonthWise.Checked = false;
                chkConsolidate.Checked = false;
                chkDayWise.Checked = false;
                chkwithdtls.Checked = false;
                btncancel.ToolTip = "Back";
                Txt_subname.Text = "";
                Txt_Groupname.Text = "";

                GRD_PAN.DataSource = new DataTable();
                GRD_PAN.DataBind();

            }
            else
            {
                this.Response.End();
            }
        }

        protected void btn_outstd_Click(object sender, EventArgs e)
        {

            iframe_outstd.Attributes["src"] = "../FAForms/OutstandingNewOnline.aspx?Ledgername=" + TXT_custn.Text + "&LedgerID=" + hidId.Value + "&hf_custid=" + hf_custid.Value + "&Todate=" + dtto.Text;
            this.MOdal_popup_outstd.Show();
            //iframe_outstd.
         /*   if (txtLedgerName.Text.Trim() != "" && hidId.Value != "" && chkConsolidate.Checked == false)
            {
                ScriptManager.RegisterStartupScript(btn_outstd, typeof(Button), "DataFound", "alertify.alert('Oustanding Contains Consolidated detail. Kindly select Consolidation');", true);
                return;
            }
            else if (chkConsolidate.Checked == true && txtLedgerName.Text.Trim() != "" && hidId.Value != "" && hf_custid.Value != "")
            {
                iframe_outstd.Attributes["src"] = "../FAForms/OutstandingNewOnline.aspx?Ledgername=" + txtLedgerName.Text + "&LedgerID=" + hidId.Value + "&hf_custid=" + hf_custid.Value + "&Todate=" + dtto.Text;
                this.MOdal_popup_outstd.Show();
            }*/

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
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();

            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1110, "PA", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1202, "PA", "", "", Session["StrTranType"].ToString());
            }

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

        protected void txtLedgerName_TextChanged(object sender, EventArgs e)
        {
            int sgroupid = 0, groupid, ledgerid = 0;
            int customerid = 0;
            DataTable dtl1 = new DataTable();
            try
            {
                if (txtLedgerName.Text == "")
                {
                    //btnGet_Click(sender, e);
                    //return;
                    ScriptManager.RegisterStartupScript(txtLedgerName, typeof(Button), "DataFound", "alertify.alert(' Kindly enter the ledger name');", true);
                    return;
                }
                else if (txtLedgerName.Text != "")
                {
                    if (hf_custid.Value != "")
                    {
                        customerid = Convert.ToInt32(hf_custid.Value);
                        dtl1 = obj_mledger.SelMasterLedger(customerid, Session["FADbname"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                        if (dtl1.Rows.Count > 0)
                        {
                            sgroupid = Convert.ToInt32(dtl1.Rows[0]["subgroupid"].ToString());
                            //  hdf_id.Value = sgroupid.ToString();
                            Session["sgpid"] = sgroupid;
                            groupid = Convert.ToInt32(dtl1.Rows[0]["groupid"].ToString());
                            Session["gpid"] = groupid;
                            // hdf_groupdi.Value = groupid.ToString();

                            //Txt_subname.Text = dtl1.Rows[0]["subgroupname"].ToString() + " / " + dtl1.Rows[0]["groupname"].ToString();
                            Txt_subname.Text = dtl1.Rows[0]["subgroupname"].ToString();
                            Txt_Groupname.Text = dtl1.Rows[0]["groupname"].ToString();
                        }
                    }

                }
                //  get_Ledger_filter();
                txtLedgerName.Focus();
            }

            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void TXTPANO_TextChanged(object sender, EventArgs e)
        {
            if (TXTPANO.Text!="")
            {
                string cutname;
                //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
                DataTable dt = new DataTable();
                dt = customerobj.GetLikeCustomerpan_gst_in(TXTPANO.Text);
                if (dt.Rows.Count>0)
                {
                    CUST.Visible = true;
                    cutname = dt.Rows[0]["customername"].ToString();

                    if ((hidId.Value == "" || hidId.Value == "0") && dt.Rows[0]["ledgerid"].ToString() != "")
                    {
                        hidId.Value = dt.Rows[0]["ledgerid"].ToString();
                        hf_custid.Value = dt.Rows[0]["ledgerid"].ToString();

                    }
                    //if ((hf_custid.Value == "" || hf_custid.Value == "0") && dt.Rows[0]["customerid"].ToString() != "")
                    //{
                    //    hf_custid.Value = dt.Rows[0]["customerid"].ToString();
                    //}

                    TXT_custn.Text = cutname;
                    ddl_Gst.Items.Clear();
                    ddl_Gst.Items.Add("All");
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ddl_Gst.Items.Add(dt.Rows[j]["gstno"].ToString() + "/" + dt.Rows[j]["statename"].ToString());
                    }
                    
                    //TXT_custn.Enabled = false;
                }

            }
        }

        protected void GRD_PAN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string voutype = ""; int vtype = 0;
                int vouno = 0, index = 0, PBid = 0;
                string osvtype = "";
                string gvlname = "";
                string VDate = "";
                Boolean flag = false;
                int logcorid = 0;
                int uiid;
                logcorid = da_obj_emp.GetBranchId(int.Parse(Session["LoginDivisionId"].ToString()), "CORPORATE");
                index = GRD_PAN.SelectedRow.RowIndex;
                voutype = GRD_PAN.Rows[index].Cells[1].Text;
                vouno = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());

                if (voutype != "")
                {
                    if (GRD_PAN.DataKeys[index].Values[2].ToString() == "" || GRD_PAN.DataKeys[index].Values[2].ToString() == "&nbsp")
                    {
                        PBid = 0;
                    }
                    else
                    {
                        PBid = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[2].ToString());
                    }


                    if (voutype == "Invoice" || voutype == "Sales Invoice")
                    {
                        gvlname = "Invoices";
                        vtype = 1;
                    }
                    else if (voutype == "Bill of Supply")
                    {
                        gvlname = "Bill of Supply";
                        vtype = 20;
                    }

                    else if (voutype == "Purchase Invoice" || voutype == "CreditNote - Operations")
                    {
                        gvlname = "Credit Note - Operations";
                        vtype = 2;
                    }
                    else if (voutype == "OS DN" || voutype == "OSSI")
                    {
                        gvlname = "OSSI";
                        vtype = 5;
                    }
                    else if (voutype == "OS CN" || voutype == "OSPI")
                    {
                        gvlname = "OSPI";
                        vtype = 6;
                    }
                    else if (voutype == "Debit Note" || voutype == "Debit Note - Others")
                    {
                        gvlname = "Debit Note - Others";
                        vtype = 7;
                    }
                    else if (voutype == "Credit Note" || voutype == "Credit Note - Others")
                    {
                        gvlname = "Credit Note - Others";
                        vtype = 8;
                    }
                    else if (voutype == "Proforma Invoices")
                    {
                        gvlname = "Proforma Invoices";
                        vtype = 1;
                    }
                    else if (voutype == "Extentions")
                    {
                        gvlname = "Extentions";
                    }
                    else if (voutype == "FinalBills")
                    {
                        gvlname = "FinalBills";
                    }
                    else if (voutype == "OSDNCNJV")
                    {
                        gvlname = "OSDNCNJV";
                    }

                    //if (voutype == "Invoice")
                    //{
                    //    gvlname = "Invoices";
                    //}
                    //else if (voutype == "Bill of Supply")
                    //{
                    //    gvlname = "Bill of Supply";
                    //}

                    //else if (voutype == "Purchase Invoice" || voutype == "CreditNote - Operations")
                    //{
                    //    gvlname = "Credit Note - Operations";
                    //}
                    //else if (voutype == "OS DN" || voutype == "OSSI")
                    //{
                    //    gvlname = "OSSI";
                    //}
                    //else if (voutype == "OS CN" || voutype == "OSPI")
                    //{
                    //    gvlname = "OSPI";
                    //}
                    //else if (voutype == "Debit Note" || voutype == "Debit Note - Others")
                    //{
                    //    gvlname = "Debit Note - Others";
                    //}
                    //else if (voutype == "Credit Note" || voutype == "Credit Note - Others")
                    //{
                    //    gvlname = "Credit Note - Others";
                    //}
                    //else if (voutype == "Proforma Invoices")
                    //{
                    //    gvlname = "Proforma Invoices";
                    //}
                    //else if (voutype == "Extentions")
                    //{
                    //    gvlname = "Extentions";
                    //}
                    //else if (voutype == "FinalBills")
                    //{
                    //    gvlname = "FinalBills";
                    //}
                    //else if (voutype == "OSDNCNJV")
                    //{
                    //    gvlname = "OSDNCNJV";
                    //}

                    if (gvlname != "")
                    {
                        if (GRD_PAN.Rows.Count > 0)
                        {
                            index = GRD_PAN.SelectedRow.RowIndex;
                            voutype = GRD_PAN.Rows[index].Cells[1].Text;
                            vouno = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                            if (GRD_PAN.DataKeys[index].Values[2].ToString() == "" || GRD_PAN.DataKeys[index].Values[2].ToString() == "&nbsp")
                            {
                                PBid = 0;
                            }
                            else
                            {
                                PBid = int.Parse(GRD_PAN.DataKeys[index].Values[2].ToString());
                            }

                            osvtype = GRD_PAN.DataKeys[index].Values[3].ToString().Replace("&nbsp", ""); //GRD_PAN.Rows[index].Cells[16].Text.Replace("&nbsp", "");
                            if (voutype != "")
                            {
                                if (PBid == Convert.ToInt32(Session["Loginbranchid"].ToString()))
                                {
                                    if (gvlname == "OSDNCNJV")
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&VNo=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);
                                        voutype = GRD_PAN.DataKeys[index].Values[3].ToString();
                                        string FrmName = "LedgerView_Voucher";
                                        iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&Vno=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        ModalPopupExtender1.Show();
                                    }
                                    else
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?QueryVoucherName=" + gvlname + "&Flag=" + true + "&PBranch_ID=" + PBid + "&QueryVoucherNo=" + vouno + "&OsvType=" + osvtype + "&LedgerID=" + hidId.Value + "&FromDate=" + dtfrom.Text + "&ToDate=" + dtto.Text + "&LedgerName=" + txtLedgerName.Text + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        //string FrmName = "LedgerView_Voucher";
                                        //iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?QueryVoucherName=" + gvlname + "&Flag=" + true + "&PBranch_ID=" + PBid + "&QueryVoucherNo=" + vouno + "&OsvType=" + osvtype + "&LedgerID=" + hidId.Value + "&FromDate=" + dtfrom.Text + "&ToDate=" + dtto.Text + "&LedgerName=" + txtLedgerName.Text + "&FrmName=" + FrmName;

                                        string FrmName = "LedgerView_Voucher";
                                        if (vtype == 5 || vtype == 6)
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/OSVouchers.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }
                                        else
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/ApprovedLV.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }

                                        ModalPopupExtender1.Show();
                                    }
                                }
                                else
                                {
                                    if (gvlname == "OSDNCNJV")
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&VNo=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);
                                        voutype = GRD_PAN.DataKeys[index].Values[3].ToString();
                                        string FrmName = "LedgerView_Voucher";
                                        iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?FormName=" + gvlname + "&Flag=" + true + "&Vno=" + vouno + "&OsvType=" + osvtype + "&PBranch_ID=" + PBid + "&LView_Flag=" + false + "&FrmName=" + FrmName;
                                        ModalPopupExtender1.Show();
                                    }
                                    else
                                    {
                                        //string FrmName = "LedgerView_Voucher";
                                        //string url = "../FAForms/Voucher.aspx?Vno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&FormName=" + gvlname + "&OsvType=" + osvtype + "&FrmName=" + FrmName;
                                        //string fullURL = "window.open('" + url + "', '_blank' );";
                                        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                        //Response.Redirect(url);

                                        string FrmName = "LedgerView_Voucher";
                                        //iframecost.Attributes["src"] = "../FAForms/Voucher.aspx?Vno=" + vouno + "&Flag=" + true + "&PBranch_ID=" + PBid + "&FormName=" + gvlname + "&OsvType=" + osvtype + "&FrmName=" + FrmName;
                                        if (vtype == 5 || vtype == 6)
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/OSVouchers.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }
                                        else
                                        {
                                            iframecost.Attributes["src"] = "../Accounts/ApprovedLV.aspx?COvouTYPE=" + vtype + "&vouno=" + vouno + "&PBranch_ID=" + PBid;
                                        }

                                        ModalPopupExtender1.Show();
                                    }
                                }
                            }
                            return;
                        }
                    }

                    if (voutype == "Bank Receipt")
                    {
                        gvlname = "Bank Receipt";
                    }
                    else if (voutype == "Cash Receipt")
                    {
                        gvlname = "Cash Receipt";
                    }
                    else if (voutype == "Bank Payment")
                    {
                        gvlname = "Bank Payment";
                    }
                    else if (voutype == "Cash Payment")
                    {
                        gvlname = "Cash Payment";
                    }
                    else if (voutype == "BDJV")
                    {
                        gvlname = "BDJV";
                    }
                    else if (voutype == "BPJV")
                    {
                        gvlname = "BPJV";
                    }
                    else if (voutype == "Receipt - Petty Cash")
                    {
                        gvlname = "Receipt - Petty Cash";
                    }
                    else if (voutype == "Remittance-Receipt")
                    {
                        gvlname = "Remittance-Receipt";
                    }
                    else if (voutype == "Remittance-Payment")
                    {
                        gvlname = "Remittance-Payment";
                    }
                    else if (voutype == "BRG")
                    {
                        gvlname = "BRG";
                    }

                    if (gvlname != "")
                    {
                        if (GRD_PAN.Rows.Count > 0)
                        {
                            index = GRD_PAN.SelectedRow.RowIndex;
                            voutype = GRD_PAN.Rows[index].Cells[1].Text;
                            vouno = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                            if (GRD_PAN.DataKeys[index].Values[2].ToString() == "" || GRD_PAN.DataKeys[index].Values[2].ToString() == "&nbsp")
                            {
                                PBid = 0;
                            }
                            else
                            {
                                PBid = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[2].ToString());
                            }

                            osvtype = GRD_PAN.DataKeys[index].Values[3].ToString();
                            if (voutype != "")
                            {
                                if (PBid == int.Parse(Session["Loginbranchid"].ToString()))
                                {
                                    //string url = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);

                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + false;
                                    ModalPopupExtender1.Show();

                                }
                                else
                                {
                                    //string url = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + true;
                                    //string fullURL = "window.open('" + url + "', '_blank' );";
                                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                    //Response.Redirect(url);

                                    string FrmName = "LedgerView_Voucher";
                                    iframecost.Attributes["src"] = "../FAForms/FAReceipt.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&LView_Flag=" + true;
                                    ModalPopupExtender1.Show();
                                }
                            }
                            return;
                        }
                    }

                    if (voutype == "Admin Sales Invoice")
                    {
                        gvlname = "Admin Sales Invoice"; ;
                    }
                    else if (voutype == "Admin Purchase Invoice")
                    {
                        gvlname = "Admin Purchase Invoice";
                    }

                    if (gvlname != "")
                    {

                        if (GRD_PAN.Rows.Count > 0)
                        {
                            index = GRD_PAN.SelectedRow.RowIndex;
                            voutype = GRD_PAN.Rows[index].Cells[1].Text;

                            if (voutype == "Admin Sales Invoice")
                            {
                                uiid = 1182;
                            }
                            else
                            {
                                uiid = 1183;
                            }
                            vouno = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                            if (GRD_PAN.DataKeys[index].Values[2].ToString() == "" || GRD_PAN.DataKeys[index].Values[2].ToString() == "&nbsp")
                            {
                                PBid = 0;
                            }
                            else
                            {
                                PBid = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[2].ToString());
                            }

                            osvtype = GRD_PAN.DataKeys[index].Values[3].ToString();
                            if (voutype != "")
                            {
                                //string url = "../FAForms/FAPAAdmin.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                                //string fullURL = "window.open('" + url + "', '_blank' );";
                                //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                                //Response.Redirect(url);

                                //string FrmName = "LedgerView_Voucher";
                                //iframecost.Attributes["src"] = "../FAForms/AdminDCNNo.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid + "&uiid=" + uiid;
                                //ModalPopupExtender1.Show();
                                string FrmName = "Approved Admin Vouchers";
                                iframecost.Attributes["src"] = "../FAForms/ApprovedAdminDCNvouchers.aspx?type=" + voutype + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                                ModalPopupExtender1.Show();
                            }
                            return;
                        }
                    }

                    if (voutype == "Contra")
                    {
                        gvlname = "Contra";
                        index = GRD_PAN.SelectedRow.RowIndex;
                        voutype = GRD_PAN.Rows[index].Cells[1].Text;
                        VDate = GRD_PAN.Rows[index].Cells[0].Text;
                        vouno = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                        if (GRD_PAN.DataKeys[index].Values[1].ToString() == "" || GRD_PAN.DataKeys[index].Values[1].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                        }

                        osvtype = GRD_PAN.DataKeys[index].Values[3].ToString();
                        if (voutype != "")
                        {
                            //string url = "../FAForms/Contra.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            //string fullURL = "window.open('" + url + "', '_blank' );";
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                            //Response.Redirect(url);
                            //return;

                            string FrmName = "LedgerView_Voucher";
                            iframecost.Attributes["src"] = "../FAForms/Contra.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + VDate;
                            ModalPopupExtender1.Show();
                        }
                    }

                    if (voutype == "Journal")
                    {

                        gvlname = "Journal";
                        index = GRD_PAN.SelectedRow.RowIndex;
                        VDate = GRD_PAN.Rows[index].Cells[0].Text;
                        voutype = GRD_PAN.Rows[index].Cells[1].Text;
                        vouno = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                        if (GRD_PAN.DataKeys[index].Values[2].ToString() == "" || GRD_PAN.DataKeys[index].Values[2].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[2].ToString());
                        }

                        osvtype = GRD_PAN.DataKeys[index].Values[3].ToString();
                        if (voutype != "")
                        {
                            //string url = "../FAForms/Journal.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            //string fullURL = "window.open('" + url + "', '_blank' );";
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                            //Response.Redirect(url);
                            //return;

                            string FrmName = "LedgerView_Voucher";
                            iframecost.Attributes["src"] = "../FAForms/Journal.aspx?FormName=" + gvlname + "&Vno=" + vouno + "&PBranch_ID=" + PBid + "&Vdate=" + GRD_PAN.Rows[index].Cells[0].Text + "&VType=" + osvtype;
                            ModalPopupExtender1.Show();
                        }
                    }

                    if (voutype == "Adjustment DCN")
                    {
                        gvlname = "CN";
                        index = GRD_PAN.SelectedRow.RowIndex;
                        voutype = GRD_PAN.Rows[index].Cells[1].Text;
                        vouno = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                        if (GRD_PAN.DataKeys[index].Values[1].ToString() == "" || GRD_PAN.DataKeys[index].Values[1].ToString() == "&nbsp")
                        {
                            PBid = 0;
                        }
                        else
                        {
                            PBid = Convert.ToInt32(GRD_PAN.DataKeys[index].Values[1].ToString());
                        }

                        osvtype = GRD_PAN.DataKeys[index].Values[3].ToString();
                        if (voutype != "")
                        {
                            //string url = "../FAForms/AdjustmenrtDNCN.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            //string fullURL = "window.open('" + url + "', '_blank' );";
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
                            //Response.Redirect(url);
                            //return;

                            string FrmName = "LedgerView_Voucher";
                            iframecost.Attributes["src"] = "../FAForms/AdjustmenrtDNCN.aspx?FormName=" + gvlname + "&VNo=" + vouno + "&PBranch_ID=" + PBid;
                            ModalPopupExtender1.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void ApplyFilter()
        {
            // Implement filtering logic here
            // Filter the data based on the selected filter criteria
            // Then rebind the GridView with the filtered data
            // Example:
            // var filteredData = YourData.Where(...); // Filter the data
            // GridView1.DataSource = filteredData;
            // GridView1.DataBind();
        }
        protected void GRD_PAN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //for (int i = 0; i < GRD_PAN.Columns.Count; i++)
                //{
                //    // Create a new text box for filtering
                //    TextBox txtFilter = new TextBox();
                //    txtFilter.Attributes["placeholder"] = "Filter...";
                //    txtFilter.Attributes["onkeyup"] = string.Format("filterColumn(this, {0})", i); // Call JavaScript function on keyup event
                //    e.Row.Cells[i].Controls.Add(txtFilter);
                //}

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GRD_PAN, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";

                if (e.Row.Cells[1].Text == "0")
                {
                    e.Row.Cells[1].Text = "";
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[22].Text.Length > 25)
                    e.Row.Cells[22].Text = e.Row.Cells[22].Text.Substring(0, 25) + " ...";
                if (e.Row.Cells[15].Text.Length > 25)
                    e.Row.Cells[15].Text = e.Row.Cells[15].Text.Substring(0, 25) + " ...";
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString().Replace("AC-", "");

                if (e.Row.RowIndex == 0)
                {
                    if (GRD_PAN.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                    {
                        e.Row.Cells[9].Text = e.Row.Cells[7].Text;
                    }
                    else
                    {
                        if (e.Row.Cells[8].Text != "&nbsp")
                        {
                            e.Row.Cells[9].Text = "-" + e.Row.Cells[8].Text.Replace("&nbsp", "");
                        }
                        else
                        {
                            e.Row.Cells[9].Text = '-'+string.Empty;
                        }
                    }
                }

                if (Convert.ToInt64(GRD_PAN.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) <= 0 && e.Row.RowIndex > 0)
                {
                    if (double.TryParse(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text.ToString(), out dbl_temp))
                    {
                        if (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text) < 0)
                        {
                            GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text = (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text).ToString("#,0.00") + "  (Cr)").ToString().Replace("-", "");
                        }
                        else
                        {
                            GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text = (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text).ToString("#,0.00") + "  (Dr)").ToString();
                        }
                    }
                    e.Row.Cells[9].Text = "";
                }
                else
                {
                    if (GRD_PAN.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                    {
                        e.Row.Cells[8].Text = "";
                        e.Row.Cells[12].Text = "";
                    }
                    else
                    {
                        e.Row.Cells[7].Text = "";
                        e.Row.Cells[11].Text = "";
                    }

                    if (e.Row.Cells[9].Text == "-;")
                    {
                        e.Row.Cells[9].Text = "0.00";
                    }
                    if (Convert.ToInt32(GRD_PAN.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()) == 0)
                    {
                        e.Row.Cells[3].Text = FillVoucher(Convert.ToInt32(GRD_PAN.DataKeys[e.Row.RowIndex].Values["vouno"].ToString()));
                    }

                    if (e.Row.RowIndex >= 1)
                    {
                        if (GRD_PAN.DataKeys[e.Row.RowIndex].Values["ltype"].ToString() == "Dr")
                        {
                            e.Row.Cells[9].Text = (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text) + Convert.ToDouble(e.Row.Cells[7].Text)).ToString();
                        }
                        else
                        {
                            e.Row.Cells[9].Text = (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text) - Convert.ToDouble(e.Row.Cells[8].Text)).ToString();
                        }

                        if (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text) < 0)
                        {
                            GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text = (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text).ToString("#,0.00") + "  (Cr)").ToString().Replace("-", "");
                        }
                        else
                        {
                            GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text = (Convert.ToDouble(GRD_PAN.Rows[e.Row.RowIndex - 1].Cells[9].Text).ToString("#,0.00") + "  (Dr)").ToString();
                        }
                    }
                }
            }

        }

        protected void TXT_custn_TextChanged(object sender, EventArgs e)
        {
            
            DataTable obj_dt = new DataTable();
            //DataAccess.FAMaster.MasterLedger da_obj_Ledger = new DataAccess.FAMaster.MasterLedger();
            //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (TXT_custn.Text != "")
            {
                if (hidId.Value != "")
                {
                    osid = Convert.ToInt32(hidId.Value);
                }
                if (osid != 0)
                {
                    dt = customerobj.LikeCustomerid_get(Convert.ToInt32(osid));
                    if (dt.Rows.Count > 0)
                    {
                        TXTPANO.Text = dt.Rows[0]["pano"].ToString();
                    }
                    dt1 =customerobj.GetLikeCustomerpan_gst_in(TXTPANO.Text.ToString());
                    if (TXTPANO.Text != "")
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            if ((hidId.Value == "" || hidId.Value == "0") && dt1.Rows[0]["ledgerid"].ToString() != "")
                            {
                                hidId.Value = dt1.Rows[0]["ledgerid"].ToString();
                                hf_custid.Value = dt1.Rows[0]["ledgerid"].ToString();
                            }
                            //if ((hf_custid.Value == "" || hf_custid.Value == "0") && dt1.Rows[0]["customerid"].ToString() != "")
                            //{
                            //    hf_custid.Value = dt1.Rows[0]["customerid"].ToString();
                            //}
                            ddl_Gst.Items.Clear();
                            ddl_Gst.Items.Add("All");
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {
                                ddl_Gst.Items.Add(dt1.Rows[j]["gstno"].ToString() + "/" + dt1.Rows[j]["statename"].ToString());
                            }
                        }
                    }
                }
            }
        }

        //protected void GRD_PAN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //    GRD_PAN.PageIndex = e.NewPageIndex;
        //    this.BindGrid();

        //}

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            //dt = da_obj_rv.FAselLedgergrd(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hidId.Value.ToString()), FromDate, ToDate, Session["FADbname"].ToString(), dispname);

            GRD_PAN.DataSource = dt;
            GRD_PAN.DataBind();
            DropDownList ddlCountry =
                (DropDownList)GRD_PAN.HeaderRow.FindControl("ddlCountry");
            this.BindCountryList(ddlCountry);
        }

        private void BindCountryList(DropDownList ddlCountry)
        {
            DataTable dt = new DataTable();
            dt = da_obj_rv.mstbrnch(0);
            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "Branch";
            ddlCountry.DataValueField = "Branch";
            ddlCountry.DataBind();
            
            ddlCountry.Items.FindByValue(ViewState["Filter"].ToString())
                    .Selected = true;
        }

        protected void ddl_Gst_TextChanged(object sender, EventArgs e)
        {
            //string gst;
            //DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt1 = new DataTable();
            gst = ddl_Gst.SelectedItem.Text;
            //int len= gst.Count();
            //len = len-15  ;
            //gst = gst.Remove(gst.Length - len);
            if (ddl_Gst.SelectedItem.Text != "All")
            {
                gst = ddl_Gst.SelectedItem.Text;
                string[] gstarr = gst.Split('/');

                int len = gstarr[0].Count();
                //len = len - 15;
                //gst = gst.Remove(gst.Length - len);

                gst = gstarr[0];

            }
            else
            {
                gst = "All";
            }
            // dt1 = customerobj.GetLikeCustomerpan(TXTPANO.Text.ToString());
            dt1 = customerobj.GetLikeCustomergst_12(gst.ToString(), TXTPANO.Text.ToString());
            if (dt1.Rows.Count > 0)
            {
               
                //for (int j = 0; j < dt1.Rows.Count; j++)
                //{
                //    txt_gstl.Text +=dt1.Rows[j]["portname"].ToString()+',';
                //}

                ddl_lk.Items.Clear();
                ddl_lk.Items.Add("All");
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    ddl_lk.Items.Add(dt1.Rows[j]["portname"].ToString());
                }
            }
            else
            {
                txt_gstl.Text = "";
            }
            if (ddl_Gst.SelectedItem.Text == "All")
            {
                ddl_lk.Items.Clear();
                ddl_lk.Items.Add("All");
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    ddl_lk.Items.Add(dt1.Rows[j]["portname"].ToString());
                }
            }

        }

        protected void ddl_lk_TextChanged(object sender, EventArgs e)
        {
            //string gst;
           // DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable dt1 = new DataTable();
            gst = ddl_Gst.SelectedItem.Text;
            //int len = gst.Count();
            //len = len - 15;
            //gst = gst.Remove(gst.Length - len);
            if (ddl_Gst.SelectedItem.Text != "All")
            {
                gst = ddl_Gst.SelectedItem.Text;
                string[] gstarr = gst.Split('/');

                int len = gstarr[0].Count();
                //len = len - 15;
                //gst = gst.Remove(gst.Length - len);

                gst = gstarr[0];

            }
            else
            {
                gst = "All";
            }
            // dt1 = customerobj.GetLikeCustomerpan(TXTPANO.Text.ToString());
            dt1 = customerobj.GetLikeCustomergst_lgd(gst.ToString(), TXTPANO.Text.ToString(),ddl_lk.SelectedItem.Text);
            if (dt1.Rows.Count > 0)
            {
                portidlgd= Convert.ToInt32( dt1.Rows[0]["portid"].ToString());
            }
        }
        protected void ddl_branch_TextChanged(object sender, EventArgs e)
        {
          //  DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
            int bid;

            //bid = isfobj.GetBranch();
            if (ddl_branch.SelectedItem.Text!="All")
            {
                bid = Emp_Obj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), ddl_branch.SelectedItem.Text);
                Session["panBranchid"] = bid.ToString();
            }
            else if (ddl_branch.SelectedItem.Text == "All")
            {
                Session["panBranchid"] = "2";
            }
            
        }
    }
}