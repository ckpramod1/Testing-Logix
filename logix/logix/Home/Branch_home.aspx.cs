using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Text;


using System.Web.UI.DataVisualization.Charting;
using ClosedXML.Excel;
using DataAccess.FAMaster;

namespace logix.Home
{
    public partial class Branch_home : System.Web.UI.Page
    {

        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Recipts Obj_rec = new DataAccess.Accounts.Recipts();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.FAVoucher obj_voucher = new DataAccess.FAVoucher();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Outstanding Obj_out = new DataAccess.Outstanding();
        DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
        DataAccess.Accounts.Recipts objReceipt = new DataAccess.Accounts.Recipts();
        DataAccess.LogDetails lobobj = new DataAccess.LogDetails();
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();
        DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.FundFlow objfund = new DataAccess.Accounts.FundFlow();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();



        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        int row = 0;
        int branchid, divisionid, logempid, Vouyear, UiiD;
        string Strtrantype, formname, Modulename;
        DataSet ds1;
        DataTable dtuser = new DataTable();
        DataTable DT_Tds = new DataTable();
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        DataTable dt_sel = new DataTable();
        DataTable dt_funddata = new DataTable();
        DataTable Dt_Out = new DataTable();
        double tmp_tot;
        DataTable Dtckeck = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Obj_rec.GetDataBase(Ccode);
                leftObj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                obj_voucher.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                Obj_out.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);

                da_obj_misgrd.GetDataBase(Ccode);
                objReceipt.GetDataBase(Ccode);
                lobobj.GetDataBase(Ccode);
                outsobj.GetDataBase(Ccode);


                obj_da_Receipt.GetDataBase(Ccode);
                objfund.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                obj_da_invoice.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_da_OSDNCN.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);

                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_Ledger.GetDataBase(Ccode);
                obj_da_FAVoucher.GetDataBase(Ccode);
                employeeobj.GetDataBase(Ccode);
                obj_da_Cheque.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);

            }


            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            Strtrantype = Session["StrTranType"].ToString();
            Vouyear = Convert.ToInt32(Session["LogYear"]);
            Modulename = "FA";
            if (!IsPostBack)
            {

                if (Session["FA_Year"] != null)
                {
                    lblLoginYear.Visible = true;
                    lblLoginYear.Text = " " + Session["FA_Year"].ToString();
                }
                BindCollectionTot();
                BindDepositTot();
                Bindfundtot();
                Bindtds();
                BindChqreqapproval4Branch();
                Bind_Un_Closed_Job();
                Bind_outstandingdetails();
                div_bar.Visible = true;
                div2_Bookchart.Visible = true;
                bookline();

                //Vino For Sales/Purchase Report [22-02-2024]

                DataTable dtempty = new DataTable();
                if (dtempty.Rows.Count > 0)
                {
                    grdB_SPRDet.Visible = false;
                    grdB_SPRDet.DataSource = dtempty;
                    grdB_SPRDet.DataBind();
                }

                btncancel.Visible = false;
                BindSPRDetails();
                lblheadersrp.Visible = false;
                btnexcelsrp.Visible = false;

            }
            btncancel.Visible = false;
        }


        private void BindSPRDetails()
        {
            DataTable dtspr = new DataTable();
            grdBranchSPRDet.DataSource = Utility.Fn_GetEmptyDataTable();
            grdBranchSPRDet.DataBind();

            dtspr = obj_voucher.GetFinanceBranchDashBoard(Convert.ToInt32(Session["LogYear"]), Convert.ToInt32(Session["LoginBranchid"]));

            if (dtspr.Rows.Count > 0)
            {
                grdBranchSPRDet.DataSource = dtspr;
                grdBranchSPRDet.DataBind();
            }

        }


        public class countrydetails
        {
            public string Countryname { get; set; }
            public Double Total { get; set; }
        }

        public void bookline()
        {
            DataTable dt0 = new DataTable();
            dt0 = objReceipt.GetOverallAmtForBarChart(Convert.ToInt32(Session["LoginBranchid"]));
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Month');
            data.addColumn('number', 'Payments');
             data.addColumn('number', 'Collections');
           
            data.addRows(" + dt0.Rows.Count + ");");



            for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            {


                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["Month"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["Payments"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt0.Rows[i]["Collections"].ToString() + ") ;");

            }

            str.Append("   var chart = new google.visualization.ColumnChart(document.getElementById('chart_divbar'));");
            str.Append(" chart.draw(data, {width: 550, height: 300, title: 'Payments Vs Collections',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}},colors: ['#4ebcd5','#bce3c8']");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');



        }

        [WebMethod]

        public static List<countrydetails> GetChartDataBooking()
        {

            DataAccess.MISGrd da_obj_misgrd = new DataAccess.MISGrd();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_misgrd.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            int subgrpid = 40;
            if (HttpContext.Current.Session["LoginBranchid"] != null || HttpContext.Current.Session["LoginDivisionId"] != null)
            {
                dt = da_obj_misgrd.Getnewoutstanding4MISHomeOutStndTotal(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), subgrpid);
            }

            List<countrydetails> dataList = new List<countrydetails>();
            foreach (DataRow dtrow in dt.Rows)
            {
                countrydetails details = new countrydetails();
                details.Countryname = dtrow[0].ToString();
                details.Total = Convert.ToDouble(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }
        protected void Bind_outstandingdetails()
        {
            DataTable dt = new DataTable();

           // DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

            int subgrpid = 40, count_row = 0;
            int time = 0;
            double temp_TOTAL = 0, temp_out = 0, temp_overdue;

            time = lobobj.GetDate().Hour;
            if (time < 13)
            {
                dt = outsobj.OutStdingGET(99999, divisionid, subgrpid);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outsobj.OutStdingGET12N(99999, divisionid, subgrpid);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outsobj.OutStdingGET3PM(99999, divisionid, subgrpid);
            }

            // dt = da_obj_misgrd.Getnewoutstanding4MISHomeOutStndTotal(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgrpid);
            // dt = da_obj_misgrd.Getnewoutstanding4MISHomeOutStndTotal(logempid, branchid, divisionid, subgrpid);

            if (dt.Rows.Count > 0)
            
            {
                //  DataView dataView = dt.DefaultView;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["bid"].ToString()) == branchid)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["amount"].ToString()))
                        {
                            temp_TOTAL += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                        }
                    }


                }
            

          
            DataTable DT_Temp = new DataTable();
            DataTable DT_Tempnew = new DataTable();
            DataTable DT_bind = new DataTable();
            DataTable DT_sales = new DataTable();
            //Dt_Out = da_obj_misgrd.Getnewoutstanding4MIS(logempid, branchid, divisionid, subgrpid, "AC");
            DataTable DT_branch = new DataTable();
            DataView data_view = dt.DefaultView;
            data_view.RowFilter = "bid =" + branchid + " ";
            DT_branch = data_view.ToTable();
           
            if (DT_branch.Rows.Count > 0)
            {
                DataView dv_co = new DataView(DT_branch);
                DT_Temp = dv_co.ToTable(true, "salesname", "salesid");
                dv_co = new DataView(DT_Temp);
                dv_co.Sort = "salesname";
                DT_Temp = dv_co.ToTable();
                dv_co = DT_Temp.DefaultView;
                dv_co.RowFilter = "salesid<>0";
                DT_Temp = dv_co.ToTable();

               DataView dv_co1 = new DataView(DT_branch);
                DT_Tempnew = dv_co1.ToTable(true, "salesname", "salesid");
                dv_co = new DataView(DT_Tempnew);
                dv_co1.Sort = "salesname";
                DT_Tempnew = dv_co1.ToTable();
                dv_co = DT_Tempnew.DefaultView;
                dv_co1.RowFilter = "salesid<>0";
                DT_Tempnew = dv_co1.ToTable();
                dv_co = DT_Tempnew.DefaultView;
                dv_co1.RowFilter = "salesid=0";
                DT_Tempnew = dv_co1.ToTable();




                DT_bind.Columns.Add("salesname", typeof(string));
                DT_bind.Columns.Add("amount", typeof(double));
                DT_bind.Columns.Add("overdue", typeof(double));
                DT_bind.Columns.Add("salesid", typeof(string));
                DataRow Drow = DT_bind.NewRow();
                //count_row = DT_Temp.Rows.Count ;
                for (int i = 0; i < DT_Temp.Rows.Count; i++)
                {
                    DataView data1 = DT_branch.DefaultView;
                    data1.RowFilter = "salesname = '" + DT_Temp.Rows[i]["salesname"] + "' ";
                    DT_sales = data1.ToTable();

                    Drow = DT_bind.NewRow();
                    DT_bind.Rows.Add(Drow);
                    DT_bind.Rows[count_row][0] = DT_sales.Rows[0]["salesname"].ToString();
                    temp_out = 0; temp_overdue = 0;
                    for (int j = 0; j < DT_sales.Rows.Count; j++)
                    {
                        temp_out += Convert.ToDouble(DT_sales.Rows[j]["amount"].ToString());
                        temp_overdue += Convert.ToDouble(DT_sales.Rows[j]["overdue"].ToString());
                    }
                    DT_bind.Rows[count_row][1] = temp_out;
                    DT_bind.Rows[count_row][2] = temp_overdue;
                    DT_bind.Rows[count_row][3] = DT_sales.Rows[0]["salesid"].ToString();
                    count_row += 1;
                }


                if (DT_Tempnew.Rows.Count > 0)
                {
                    DataView data1 = DT_branch.DefaultView;
                    data1.RowFilter = "salesid = 0";
                    DT_sales = data1.ToTable();
                    Drow = DT_bind.NewRow();
                    DT_bind.Rows.Add(Drow);
                    DT_bind.Rows[count_row][0] = "Others";
                    temp_out = 0; temp_overdue = 0;
                    for (int j = 0; j < DT_sales.Rows.Count; j++)
                    {
                        temp_out += Convert.ToDouble(DT_sales.Rows[j]["amount"].ToString());
                        temp_overdue += Convert.ToDouble(DT_sales.Rows[j]["overdue"].ToString());
                    }
                    DT_bind.Rows[count_row][1] = temp_out;
                    DT_bind.Rows[count_row][2] = temp_overdue;
                    DT_bind.Rows[count_row][3] = "0";
                    count_row += 1;
                }
                var sum_Outstanding = DT_bind.Compute("sum(amount)", "");
                var sum_Over = DT_bind.Compute("sum(overdue)", "");
                Drow = DT_bind.NewRow();
                DT_bind.Rows.Add(Drow);
                DT_bind.Rows[count_row][0] = "Total";
                DT_bind.Rows[count_row][1] = Convert.ToDouble(sum_Outstanding);
                DT_bind.Rows[count_row][2] = Convert.ToDouble(sum_Over);
                Grid_salesout.DataSource = DT_bind;
                Grid_salesout.DataBind();
                ViewState["GridSalesOutPerson"] = DT_bind;
                lbl_outTot.Text = Convert.ToDouble(sum_Outstanding).ToString("#,0.00");//string.Format("{0:#,##0.00}", temp_TOTAL);


            }
            }
            else
            {
                lbl_outTot.Text = "0.0";
                Grid_salesout.DataSource = new DataTable();
                Grid_salesout.DataBind();
            }
        } 
        //protected void Bind_outstandingdetails()
        //{

        //    DataTable dt = new DataTable();

        //    DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

        //    int subgrpid = 40, count_row = 0;
        //    int time = 0;
        //    double temp_TOTAL = 0, temp_out = 0, temp_overdue;

        //    time = lobobj.GetDate().Hour;
        //    if (time < 13)
        //    {
        //        dt = outsobj.OutStdingGET(99999, divisionid, subgrpid);
        //    }
        //    else if (time >= 13 && time < 16)
        //    {
        //        dt = outsobj.OutStdingGET12N(99999, divisionid, subgrpid);
        //    }
        //    else if (time >= 16 && time < 23)
        //    {
        //        dt = outsobj.OutStdingGET3PM(99999, divisionid, subgrpid);
        //    }


        //    // dt = da_obj_misgrd.Getnewoutstanding4MISHomeOutStndTotal(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), subgrpid);
        //    if (dt.Rows.Count > 0)
        //    {
        //        //  DataView dataView = dt.DefaultView;

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (Convert.ToInt32(dt.Rows[i]["bid"].ToString()) == branchid)
        //            {
        //                if (!string.IsNullOrEmpty(dt.Rows[i]["amount"].ToString()))
        //                {
        //                    temp_TOTAL += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
        //                }
        //            }


        //        }
        //    }

        //    lbl_outTot.Text = string.Format("{0:#,##0.00}", temp_TOTAL); 
        //    DataTable DT_Temp = new DataTable();
        //    DataTable DT_Tempnew = new DataTable();
        //    DataTable DT_bind = new DataTable();
        //    DataTable DT_sales = new DataTable();
        //    Dt_Out = da_obj_misgrd.Getnewoutstanding4MIS(logempid, branchid, divisionid, subgrpid, "AC");

        //    if (Dt_Out.Rows.Count > 0)
        //    {
        //        DataView dv_co = new DataView(Dt_Out);
        //        DT_Temp = dv_co.ToTable(true, "salesname", "salesid");
        //        dv_co = new DataView(DT_Temp);
        //        dv_co.Sort = "salesname";
        //        DT_Temp = dv_co.ToTable();
        //        dv_co = DT_Temp.DefaultView;
        //        dv_co.RowFilter = "salesid<>0";
        //        DT_Temp = dv_co.ToTable();

        //        DataView dv_co1 = new DataView(Dt_Out);
        //        DT_Tempnew = dv_co1.ToTable(true, "salesname", "salesid");
        //        dv_co = new DataView(DT_Tempnew);
        //        dv_co1.Sort = "salesname";
        //        DT_Tempnew = dv_co1.ToTable();
        //        dv_co = DT_Tempnew.DefaultView;
        //        dv_co1.RowFilter = "salesid<>0";
        //        DT_Tempnew = dv_co1.ToTable();
        //        dv_co = DT_Tempnew.DefaultView;
        //        dv_co1.RowFilter = "salesid=0";
        //        DT_Tempnew = dv_co1.ToTable();




        //        DT_bind.Columns.Add("salesname", typeof(string));
        //        DT_bind.Columns.Add("amount", typeof(double));
        //        DT_bind.Columns.Add("overdue", typeof(double));
        //        DT_bind.Columns.Add("salesid", typeof(string));
        //        DataRow Drow = DT_bind.NewRow();
        //        //count_row = DT_Temp.Rows.Count ;
        //        for (int i = 0; i < DT_Temp.Rows.Count; i++)
        //        {
        //            DataView data1 = Dt_Out.DefaultView;
        //            data1.RowFilter = "salesname = '" + DT_Temp.Rows[i]["salesname"] + "' ";
        //            DT_sales = data1.ToTable();

        //            Drow = DT_bind.NewRow();
        //            DT_bind.Rows.Add(Drow);
        //            DT_bind.Rows[count_row][0] = DT_sales.Rows[0]["salesname"].ToString();
        //            temp_out = 0; temp_overdue = 0;
        //            for (int j = 0; j < DT_sales.Rows.Count; j++)
        //            {
        //                temp_out += Convert.ToDouble(DT_sales.Rows[j]["amount"].ToString());
        //                temp_overdue += Convert.ToDouble(DT_sales.Rows[j]["overdue"].ToString());
        //            }
        //            DT_bind.Rows[count_row][1] = temp_out;
        //            DT_bind.Rows[count_row][2] = temp_overdue;
        //            DT_bind.Rows[count_row][3] = DT_sales.Rows[0]["salesid"].ToString();
        //            count_row += 1;
        //        }


        //        if (DT_Tempnew.Rows.Count > 0)
        //        {
        //            DataView data1 = Dt_Out.DefaultView;
        //            data1.RowFilter = "salesid = 0";
        //            DT_sales = data1.ToTable();
        //            Drow = DT_bind.NewRow();
        //            DT_bind.Rows.Add(Drow);
        //            DT_bind.Rows[count_row][0] = "Others";
        //            temp_out = 0; temp_overdue = 0;
        //            for (int j = 0; j < DT_sales.Rows.Count; j++)
        //            {
        //                temp_out += Convert.ToDouble(DT_sales.Rows[j]["amount"].ToString());
        //                temp_overdue += Convert.ToDouble(DT_sales.Rows[j]["overdue"].ToString());
        //            }
        //            DT_bind.Rows[count_row][1] = temp_out;
        //            DT_bind.Rows[count_row][2] = temp_overdue;
        //            DT_bind.Rows[count_row][3] = "0";
        //            count_row += 1;
        //        }
        //        var sum_Outstanding = DT_bind.Compute("sum(amount)", "");
        //        var sum_Over = DT_bind.Compute("sum(overdue)", "");
        //        Drow = DT_bind.NewRow();
        //        DT_bind.Rows.Add(Drow);
        //        DT_bind.Rows[count_row][0] = "Total";
        //        DT_bind.Rows[count_row][1] = Convert.ToDouble(sum_Outstanding);
        //        DT_bind.Rows[count_row][2] = Convert.ToDouble(sum_Over);
        //        Grid_salesout.DataSource = DT_bind;
        //        Grid_salesout.DataBind();
        //    }

        //}

        public void Bind_Un_Closed_Job()
        {
            DataTable DtApp = new DataTable();
            DtApp = Approveobj.GetPendingUnclose_Job(branchid);
            if (DtApp.Rows.Count > 0)
            {
                unclosed.InnerText = DtApp.Rows[0][0].ToString();
                Lnk_unclosed.Enabled = true;
            }
            else
            {
                unclosed.InnerText = "0";
                Lnk_unclosed.Enabled = false;
            }
        }



        protected void BindCollectionTot()
        {
            lbl_collection.Text = string.Format("{0:#,##0.00}", Obj_rec.Getcollectionamt(branchid, Vouyear));
        }
        protected void BindDepositTot()
        {

            DateTime Str_CurrrentDate = DateTime.Now.AddDays(-1);

            txt_date.Text = Str_CurrrentDate.ToString("dd/MM/yyyy");

            DateTime dte = Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text));
            if (dte.DayOfWeek == DayOfWeek.Sunday)
            {
                txt_date.Text = dte.AddDays(-1).ToString("dd/MM/yyyy");
            }
            else
            {
                txt_date.Text = Str_CurrrentDate.ToString("dd/MM/yyyy");
            }
            Session["DateTime"] = txt_date.Text;

            loaddate();


        }
        protected void loaddate()
        {
            DataTable obj_dt = new DataTable();
          //  DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
           // obj_dt = obj_da_Receipt.Getdeposit4branch(Convert.ToDateTime(Utility.fn_ConvertDate(Session["DateTime"].ToString())), int.Parse(Session["LoginDivisionId"].ToString()));

            obj_dt = obj_da_Receipt.GetdepositTot(branchid, Vouyear, Convert.ToDateTime(Utility.fn_ConvertDate(Session["DateTime"].ToString())), int.Parse(Session["LoginDivisionId"].ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(obj_dt.Rows[0]["Amount"].ToString()))
                {
                    link_deposit.Text = Convert.ToDouble(obj_dt.Rows[0]["Amount"]).ToString("#,0.00");
                    link_deposit.Enabled = true;
                }
               
            }
            else
            {
                link_deposit.Text = "0.00";
                link_deposit.Enabled = false;
            }

           
        }

        //protected void BindDepositTot()
        //{
        //    lbl_deposit.Text = string.Format("{0:#,##0.00}", Obj_rec.GetdepositTot(branchid, Vouyear));
        //}

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {

          //  GridbankBNL.Visible = false;

            Session["DateTime"] = txt_date.Text;
            loaddate(); 
          //  BindDepositTot();
        }

        protected void link_deposit_Click(object sender, EventArgs e)
        {
            //ddl_branch.Visible = false;
            GridbankBNL.Visible = false;

            //Bankbalancetitle.Visible = false;
            DataTable dtuser = new DataTable();

            dtuser = obj_UP.GetFormwiseuserRights(1803, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FC");
            if (dtuser.Rows.Count > 0)
            {
                string type = "DepositDetails";
                Response.Redirect("../FAForms/DepositDetails.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
            //string type = "DepositDetails";
            //Response.Redirect("../FAForms/DepositDetails.aspx?type=" + type);
        }


        //protected void BindDepositTot()
        //{
        //    lbl_deposit.Text = string.Format("{0:#,##0.00}", Obj_rec.GetdepositTot(branchid, Vouyear));
        //}

        protected void lnk_collection_Click(object sender, EventArgs e)
        {

        }

        protected void Bindfundtot()
        {
           // DataAccess.Accounts.FundFlow objfund = new DataAccess.Accounts.FundFlow();
            int cid = Convert.ToInt16(Session["LoginDivisionId"].ToString());

            string strall;
            string str;

            string str1;
            str1 = "";

            string[] strbranch;
            string[] strArray;


            strall = "";
            str = "Total Collections from Branch deposited to CO Bank (A)~Total payments received from CO (B)~Net CTC Account(cashflow between CO to Branch) (C)~Overseas Debit Note Total Billing (D)~Overseas Credit Note Total Billing (E)~Net OVC Account(receviable/(-) payable with CO) (F)~Interbranch Balance as per the Branch books (G)~Net funding from CO to Branch for the given Period (H)~Net profit Contribution from Branch for given Period (I)~Total funding for the Branch Bussiness (J)";


            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            DateTime FromDate = Convert.ToDateTime(startDate);
            DateTime ToDate = Convert.ToDateTime(endDate);


            branchid = Convert.ToInt16(Session["LoginBranchid"].ToString()); ;
            if (str1 == "")
            {
                str1 = branchid.ToString();
            }
            else
            {
                str1 += "," + branchid.ToString();
            }

            DataRow[] fRows;

            grd.DataSource = new DataTable();
            grd.DataBind();
            strbranch = str1.Split(',');
            str = strall + str;
            strArray = str.Split('~');
            ds1 = objfund.fundsflowforAllBranches(FromDate, ToDate, Session["FADbname"].ToString(), cid);
            dts = ds1.Tables[0];
            dt_sel = ds1.Tables[1];

            grd.DataSource = ds1;
            grd.DataBind();
            fRows = dt_sel.Select("branchid in(" + str1 + ")");

            dt_funddata.Columns.Add("Fund Flow");

            for (int j = 0; j <= fRows.Length - 1; j++)
            {
                dt_funddata.Columns.Add(fRows[j][2].ToString());
            }
            dt_funddata.Columns.Add("Total");

            for (int i = 0; i <= 10 - 1; i++)
            {
                dt_funddata.Rows.Add();
                dt_funddata.Rows[i][0] = strArray[i];
            }

            DataRow[] foundRows;
            int int_CNO = 0, int_RNO = 0, sbid = 0;
            double A, B, C, D, Ee, F, G, H, Ii, Jj, Debit, Credit;

            for (int j = 0; j <= fRows.Length - 1; j++)
            {
                if (sbid != Convert.ToInt16(fRows[j][0].ToString()))
                {
                    sbid = Convert.ToInt16(fRows[j][0].ToString());
                    int_RNO = 0;
                    int_CNO = int_CNO + 1;
                    foundRows = dts.Select("branchid=" + fRows[j][0].ToString());
                    A = 0.0;
                    B = 0.0;
                    C = 0.0;
                    D = 0.0;
                    Ee = 0.0;
                    F = 0.0;
                    G = 0.0;
                    H = 0.0;
                    Ii = 0.0;
                    Jj = 0.0;
                    Debit = 0.0;
                    Credit = 0.0;

                    for (int k = 0; k <= foundRows.Length - 1; k++)
                    {
                        if (foundRows[k][1].ToString() == "A")
                        {
                            A = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        if (foundRows[k][1].ToString() == "B")
                        {
                            B = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        C = A - B;

                        if (foundRows[k][1].ToString() == "D")
                        {
                            D = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        if (foundRows[k][1].ToString() == "E")
                        {
                            Ee = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        if (Convert.ToInt16(foundRows[k][0].ToString()) == 40 || Convert.ToInt16(foundRows[k][0].ToString()) == 51 || Convert.ToInt16(foundRows[k][0].ToString()) == 62)
                        {
                            F = Ee - D;
                        }
                        else
                        {
                            F = D - Ee;
                        }

                        if (foundRows[k][1].ToString() == "G")
                        {
                            if (foundRows[k][2].ToString() == "Cr")
                            {
                                Credit = Convert.ToDouble(foundRows[k][3].ToString());
                            }
                            else
                            {
                                Debit = Convert.ToDouble(foundRows[k][3].ToString());
                            }
                            G = Debit - Credit;
                        }

                        H = C + F + G;

                        if (foundRows[k][1].ToString() == "I")
                        {
                            Ii = Convert.ToDouble(foundRows[k][3].ToString());
                        }

                        Jj = H - Ii;
                    }

                    dt_funddata.Rows[int_RNO][int_CNO] = A.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = B.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = C.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = D.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = Ee.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = F.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = G.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = H.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = Ii.ToString("#,0.00");
                    int_RNO = int_RNO + 1;
                    dt_funddata.Rows[int_RNO][int_CNO] = Jj.ToString("#,0.00");
                }
            }

            int ccount, rcount;
            double tot;
            ccount = dt_funddata.Columns.Count - 1;
            rcount = dt_funddata.Rows.Count - 1;

            for (int j = 0; j <= rcount; j++)
            {
                tot = 0;
                for (int k = 1; k <= ccount - 1; k++)
                {
                    tot = tot + Convert.ToDouble(dt_funddata.Rows[j][k].ToString());
                }
                dt_funddata.Rows[j][ccount] = tot.ToString("#,0.00");
            }

            for (int i = dt_funddata.Rows.Count - 2; i >= 0; i--)
            {
                dt_funddata.Rows.RemoveAt(i);
            }
            grd.DataSource = dt_funddata;
            grd.DataBind();
            tmp_tot = 0;
            for (int i = 0; i < dt_funddata.Rows.Count; i++)
            {
                tmp_tot += Convert.ToDouble(dt_funddata.Rows[i][1].ToString());
            }
            lnk_fund.Text = string.Format("{0:#,##0.00}", tmp_tot);
            if (tmp_tot != 0)
            {
                lnk_fund.Enabled = true;
            }
            grd.Visible = false;
        }


        protected void lnk_fund_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(lnk_fund.Text) > 0)
            {
                grd.Visible = true;
                this.ModalPopupExtender_fund.Show();
            }

        }

        protected void BindChqreqapproval4Branch()
        {
            DT_Tds = leftObj.GetChkreqpending4Branch(branchid);

            for (int i = 0; i < DT_Tds.Rows.Count; i++)
            {
                if (DT_Tds.Rows[i][1].ToString().Trim() == "CN - Operation")
                {
                    if (Convert.ToInt32(DT_Tds.Rows[i][0].ToString()) > 0)
                    {
                        link_CNOP.Text = DT_Tds.Rows[i][0].ToString();
                        link_CNOP.Enabled = true;
                    }
                }
                else if (DT_Tds.Rows[i][1].ToString().Trim() == "Other CN")
                {
                    if (Convert.ToInt32(DT_Tds.Rows[i][0].ToString()) > 0)
                    {
                        link_cnn.Text = DT_Tds.Rows[i][0].ToString();
                        link_cnn.Enabled = true;
                    }
                }
                else if (DT_Tds.Rows[i][1].ToString().Trim() == "CN - Admin")
                {
                    if (Convert.ToInt32(DT_Tds.Rows[i][0].ToString()) > 0)
                    {
                        link_cnadmins.Text = DT_Tds.Rows[i][0].ToString();
                      // link_cnadmins.Enabled = true;
                    }
                }
            }
        }

        protected void Bindtds()
        {
            DT_Tds = leftObj.GetTDS4dash(branchid);

            for (int i = 0; i < DT_Tds.Rows.Count; i++)
            {
                if (DT_Tds.Rows[i][1].ToString().Trim() == "CN - Operation")
                {
                    if (Convert.ToInt32(DT_Tds.Rows[i][0].ToString()) > 0)
                    {
                        lnk_cnopstds.Text = DT_Tds.Rows[i][0].ToString();
                        lnk_cnopstds.Enabled = true;
                    }
                }
                else if (DT_Tds.Rows[i][1].ToString().Trim() == "Other CN")
                {
                    if (Convert.ToInt32(DT_Tds.Rows[i][0].ToString()) > 0)
                    {
                        lnk_cntds.Text = DT_Tds.Rows[i][0].ToString();
                        lnk_cntds.Enabled = true;
                    }
                }
                else if (DT_Tds.Rows[i][1].ToString().Trim() == "CN - Admin")
                {
                    if (Convert.ToInt32(DT_Tds.Rows[i][0].ToString()) > 0)
                    {
                        lnk_admincntds.Text = DT_Tds.Rows[i][0].ToString();
                        lnk_admincntds.Enabled = true;
                    }
                }
            }
        }

        protected void lnk_cnopstds_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "CN-Ops TDS";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/PATDS.aspx?FormName=" + formname + "&UIID=" + UiiD + "&Home=Yes");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void lnk_cntds_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "Other CN TDS";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/PATDS.aspx?FormName=" + formname + "&UIID=" + UiiD + "&Home=Yes");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void lnk_admincntds_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "CN - Admin TDS";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/PATDS.aspx?FormName=" + formname + "&UIID=" + UiiD + "&Home=Yes");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void link_CNOP_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "Cheque Request &Approval";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        string type = "CnOps";
                        Response.Redirect("../FAForms/ChequeRequestApproval.aspx?FormName=Cheque Request Approval" + "&UIID=" + UiiD + "&Home=Yes" + "&type=" + type);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void link_cnn_Click(object sender, EventArgs e)
        {
            
            try
            {
                formname = "Cheque Request &Approval";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        string type = "CN";
                        Response.Redirect("../FAForms/ChequeRequestApproval.aspx?FormName=Cheque Request Approval" + "&UIID=" + UiiD + "&Home=Yes" + "&type=" + type);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void link_cnadmins_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "Cheque Request &Approval";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {

                        string type = "CN Admin";
                        Response.Redirect("../FAForms/ChequeRequestApproval.aspx?FormName=Cheque Request Approval" + "&UIID=" + UiiD + "&Home=Yes"+"&type="+type);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void visible_false()
        {
            div_bar.Visible = false;
            div2_Bookchart.Visible = false;
            Div_chart.Visible = false;

            //Vino [27-02-2024]
            PnlBranchSPRDet.Visible = false;
            grdBranchSPRDet.Visible = false;
            grdB_SPRDet.Visible = false;
            PnlB_SPRDet.Visible = false;

        }

        protected void Lnk_unclosed_Click(object sender, EventArgs e)
        {
            //exp2excGrd_Deposite.Visible = false;
            div_ComApproval.Visible = false;
            div_iframe.Visible = false;

            visible_false();
            div_UnClos.Visible = true;
            Panel13.Visible = true;
            int necount1 = 0, nicount1 = 0, fecount1 = 0, ficount1 = 0, chcount1 = 0;
            string Strtrantype = Session["StrTranType"].ToString();
            int intcount = 0;
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable dt1 = new DataTable();
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("Product") });
            dt1.Columns.AddRange(new DataColumn[1] { new DataColumn("UnClosed Jobs") });
            dt = Approveobj.GetPenUnClose("AC", branchid, 0, logempid);
            hidunclosed.Text = Convert.ToInt32(dt.Rows.Count).ToString();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (dt.Rows[i]["trantype"].ToString() == "AE") { necount1 = necount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "AI") { nicount1 = nicount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "FE") { fecount1 = fecount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "FI") { ficount1 = ficount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "CH") { chcount1 = chcount1 + 1; }
                if (dt.Rows[i]["trantype"].ToString() == "AC") { chcount1 = chcount1 + 1; }
            }
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "Air Exports";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = necount1;
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "Air Imports";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = nicount1;
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "Ocean Exports";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = fecount1;
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "Ocean Imports";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = ficount1;
            //dt1.Rows.Add();
            //dt1.Rows[dt1.Rows.Count - 1]["Product"] = "CH";
            //dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = chcount1;
            int total = necount1 + nicount1 + fecount1 + ficount1 + chcount1;
            dt1.Rows.Add();
            dt1.Rows[dt1.Rows.Count - 1]["Product"] = "Total";
            dt1.Rows[dt1.Rows.Count - 1]["UnClosed Jobs"] = total.ToString();
            grdunclosejobs.DataSource = dt1;
            grdunclosejobs.DataBind();
            ViewState["UnClosedJob"] = dt1;
        }

        protected void grdunclosejobs_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Cells[1].Attributes.CssStyle["text-align"] = "Right";
                }

                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                if (e.Row.Cells[0].Text != "Total")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdunclosejobs, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }

            }
        }


        protected void grdunclosejobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            string name = "";
            visible_false();
            _Pend_UN.Visible = true;
            div_UnClos.Visible = true;
            Panel13.Visible = true;
            Panel_unc.Visible = true;
            grd_UNC.Visible = true;
            index = grdunclosejobs.SelectedRow.RowIndex;
            name = grdunclosejobs.Rows[index].Cells[0].Text;
            if (name == "OE")
            {
                name = "FE";
            }
            else if (name == "OI")
            {
                name = "FI";
            }
            string Strtrantype = Session["StrTranType"].ToString();
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            logempid = int.Parse(Session["LoginEmpId"].ToString());
            DataTable dt1 = new DataTable();
            dt = Approveobj.GetPenUnCloseForNew(name, branchid, int.Parse(Session["LoginDivisionId"].ToString()), logempid);
            if (name == "FE")
            {
                div_unClos_new.InnerText = "Ocean Exports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                dtemptyfree.Columns.Add("Vessel & Voyage");

                dtemptyfree.Columns.Add("ETD");
                dtemptyfree.Columns.Add("MBL #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["Vessel & Voyage"] = dt.Rows[j]["vslvoy"].ToString();
                        dtemptyfree.Rows[j]["ETD"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["etd"].ToString()).ToShortDateString()).ToString();

                        dtemptyfree.Rows[j]["MBL #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();

                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
            else if (name == "FI")
            {
                div_unClos_new.InnerText = "Ocean Imports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                dtemptyfree.Columns.Add("Vessel & Voyage");
                dtemptyfree.Columns.Add("ETA");
                dtemptyfree.Columns.Add("MBL #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["Vessel & Voyage"] = dt.Rows[j]["vslvoy"].ToString();
                        dtemptyfree.Rows[j]["ETA"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["MBL #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }

            else if (name == "AE")
            {
                div_unClos_new.InnerText = "Air Exports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                dtemptyfree.Columns.Add("Flight Date");
                dtemptyfree.Columns.Add("MAWB #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();

                        dtemptyfree.Rows[j]["Flight Date"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["MAWB #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
            else if (name == "AI")
            {
                div_unClos_new.InnerText = "Air Imports";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                dtemptyfree.Columns.Add("Flight Date");
                dtemptyfree.Columns.Add("MAWB #");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();

                        dtemptyfree.Rows[j]["Flight Date"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["MAWB #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
            else if (name == "CH")
            {
                div_unClos_new.InnerText = "CHA";
                DataTable dtemptyfree = new DataTable();
                dtemptyfree.Columns.Add("Sl #");
                dtemptyfree.Columns.Add("Job #");
                dtemptyfree.Columns.Add("Job Opened On");
                dtemptyfree.Columns.Add("Doc #");
                dtemptyfree.Columns.Add("Doc Date");
                dtemptyfree.Columns.Add("Job Opened By");
                DataRow dr = dtemptyfree.NewRow();


                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {


                        dtemptyfree.Rows.Add();
                        dr = dtemptyfree.NewRow();
                        dtemptyfree.Rows[j]["Sl #"] = j + 1;
                        dtemptyfree.Rows[j]["Job #"] = dt.Rows[j]["jobno"].ToString();
                        dtemptyfree.Rows[j]["Job Opened On"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["jobopen"].ToString()).ToShortDateString()).ToString();

                        dtemptyfree.Rows[j]["Doc #"] = dt.Rows[j]["mblno"].ToString();
                        dtemptyfree.Rows[j]["Doc Date"] = Utility.fn_ConvertDate(Convert.ToDateTime(dt.Rows[j]["eta"].ToString()).ToShortDateString()).ToString();
                        dtemptyfree.Rows[j]["Job Opened By"] = dt.Rows[j]["preparedby"].ToString();



                    }
                    grd_UNC.DataSource = dtemptyfree;
                    grd_UNC.DataBind();
                }
                else
                {
                    grd_UNC.DataSource = new DataTable();
                    grd_UNC.DataBind();
                }
                ViewState["grd_UNCexp2exc"] = dtemptyfree;
            }
        }

    

     

        protected void grd_UNC_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void lnk_query_OE_Click(object sender, EventArgs e)
        {


            try
            {
                formname = "Ocean &Exports";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/FE_Query.aspx?FormName=OCEAN EXPORTS" + "&Trantype=FE");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }



           /* try
            {
                Response.Redirect("../FAForms/FE_Query.aspx?FormName=OCEAN EXPORTS" + "&Trantype=FE");
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }*/
        }

        protected void lnk_query_OI_Click(object sender, EventArgs e)
        {

            try
            {
                formname = "Ocean &Imports";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/FE_Query.aspx?FormName=OCEAN IMPORTS" + "&Trantype=FI");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }



            /*try
            {
                Response.Redirect("../FAForms/FE_Query.aspx?FormName=OCEAN IMPORTS" + "&Trantype=FI");
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }*/
        }

        protected void lnk_query_AIRExport_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "Air Exports";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                      Response.Redirect("../FAForms/Bl_Query.aspx?FormName=AIR EXPORTS" + "&Trantype=AE");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }





           /* try
            {
                Response.Redirect("../FAForms/Bl_Query.aspx?FormName=AIR EXPORTS" + "&Trantype=AE");
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }*/
        }

        protected void lnk_query_AIRImport_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "Air Imports";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/BL_Query.aspx?FormName=AIR IMPORTS" + "&Trantype=AI");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }


          /*  try
            {
                Response.Redirect("../FAForms/BL_Query.aspx?FormName=AIR IMPORTS" + "&Trantype=AI");
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }*/
        }

        protected void lnk_cost_sheet_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "Cost &Sheet";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../FAForms/Costsheet.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }






            /*try
            {
                Response.Redirect("../FAForms/Costsheet.aspx");
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }*/
        }

        protected void Grid_salesout_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "0")
                    {
                        e.Row.Cells[i].Text = "0.00";
                    }
                    e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                for (int h = 1; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;                  
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void excportexc_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GridSalesOutPerson"] as DataTable;
            dt_check.Columns.Remove("salesid");

            if (Grid_salesout.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Outstanding.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

        protected void excportexc1_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["UnClosedJob"] as DataTable;
            if (grdunclosejobs.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=UnclosedJob.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }

        protected void exp2excgrdunc_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["grd_UNCexp2exc"] as DataTable;
            if (grd_UNC.Rows.Count > 0)
            {
                //using (XLWorkbook wb = new XLWorkbook())
                //{
                //    //wb.Worksheets.Add("test");

                //    wb.Worksheets.Add(dt_check);

                //    Response.Clear();
                //    Response.Buffer = true;
                //    Response.Charset = "";
                //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //    Response.AddHeader("content-disposition", "attachment;filename=UnclosedJobDetails.xls");
                //    using (MemoryStream MyMemoryStream = new MemoryStream())
                //    {
                //        wb.SaveAs(MyMemoryStream);
                //        MyMemoryStream.WriteTo(Response.OutputStream);
                //        Response.Flush();
                //        Response.End();
                //    }
                //}



                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=UnclosedJobDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                if (grd_UNC.Visible == true)
                {
                    grd_UNC.GridLines = GridLines.Both;
                    grd_UNC.HeaderStyle.Font.Bold = true;
                    grd_UNC.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void lnk_proInvoice_Click(object sender, EventArgs e)
        {
            div_UnClos.Visible = false;
            _Pend_UN.Visible = false;
            btn_transfer.Visible = true;
            visible_false();
            vis_div();
            if (ddl_module.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Select Product ');", true);
                return;

            }
           
            string vouname, vouname1;
            //string trantype_process = Session["StrTranType"].ToString();

            string trantype_process = ddl_module.SelectedValue.ToString();
               
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {


                dtuser = obj_UP.GetFormwiseuserRights(1016, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {
                    // this.aePopUpshow.Show();
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";


                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";

                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Invoice";

                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {

                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }



            }

            if (trantype_process == "FI")
            {


                dtuser = obj_UP.GetFormwiseuserRights(1023, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Invoice";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //  btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }

                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }


            }

            if (trantype_process == "AE")
            {


                dtuser = obj_UP.GetFormwiseuserRights(1030, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Invoice";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //  btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }



            }

            if (trantype_process == "AI")
            {


                dtuser = obj_UP.GetFormwiseuserRights(1037, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    string app1 = "Invoice Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else if (hid_type.Value.ToString() == "Invoice Proforma to Commercial")
                        {
                            hid_type.Value = "Transfer To Commercial Invoice";
                            lbl_Header.Text = "Transfer To Commercial Invoice";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_proInvoice, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }


            }
        }

        public void vis_div()
        {
          
            div2_Bookchart.Visible = false;
            div_ComApproval.Visible = true;
           
            
            div_iframe.Visible = true;
            //Div1.Visible = false;
        }

        private void Fn_Getdetail()
        {
            try
            {
                string trantype_process = ddl_module.SelectedValue.ToString();
                if (hid_type.Value.ToString() != "Transfer To Commercial PA")
                {
                    Grd_Approval.Columns[5].Visible = false;
                    Grd_Approval.Columns[6].Visible = false;
                    Grd_Approval.Columns[7].Visible = false;

                }
                else
                {
                    Grd_Approval.Columns[5].Visible = true;
                    Grd_Approval.Columns[6].Visible = true;
                    Grd_Approval.Columns[7].Visible = true;

                }

                DataTable obj_dt = new DataTable();
               // DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                //obj_dt = obj_da_Approval.FillDt4Pro(Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString());
                obj_dt = obj_da_Approval.FillDt4ProTDS(trantype_process, int.Parse(Session["LoginBranchid"].ToString()), hid_type.Value.ToString());
                Grd_Approval.DataSource = obj_dt;
                Grd_Approval.DataBind();


                btn_delete.Visible = false;
                TextBox lnkbtn;
                int i = 0;
                if (Grd_Approval.Rows.Count > 0)
                {
                    if (obj_dt.Rows.Count > 0)
                    {
                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {

                                lnkbtn = (TextBox)(Grd_Approval.Rows[i].FindControl("TDSPERS"));
                                lnkbtn.Visible = true;


                            }
                            else
                            {
                                lnkbtn = (TextBox)(Grd_Approval.Rows[i].FindControl("TDSPERS"));
                                lnkbtn.Visible = false;
                            }

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


        protected void Grd_Approval_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Approval, "" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";


                //LinkButton _singleClickButton1 = (LinkButton)e.Row.Cells[6].Controls[0];
                //string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton1, "");
                //// Add events to each editable cell

                //    for (int columnIndex = 0; columnIndex < e.Row.Cells.Count-2; columnIndex++)
                //    {
                //        // Add the column index as the event argument parameter
                //        string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                //        // Add this javascript to the onclick Attribute of the cell
                //        e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                //        // Add a cursor style to the cells
                //        e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";

                //    }


            }
        }
        protected void Grd_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            approval();

        }

        public void approval()
        {

            DateTime get_date, GST_date;
            // get_date = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
            get_date = Convert.ToDateTime(Grd_Approval.SelectedRow.Cells[12].Text.ToString());
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());

            string header = "";
            double amount = Convert.ToDouble(Grd_Approval.SelectedRow.Cells[3].Text.ToString());
            if (hid_credit.Value == "")
            {
                hid_credit.Value = "0";
            }

            if (hid_debit.Value == "")
            {
                hid_debit.Value = "0";
            }
            string str_Voucher = "", Str_StrTrantype = "";
            int int_Vouno = 0, int_vouyear = 0;
            //Session["str_sfs"] = "";
            //Session["str_sp"] = "";
            string Str_SP1 = "", Str_SF1 = "", Str_SF2 = "", Str_SP2 = "", str_RptName1 = "", str_RptName2 = "", BL = "";
           // Str_StrTrantype = Session["StrTranType"].ToString();


            Str_StrTrantype = ddl_module.SelectedValue.ToString();
            // if (Grd_Approval.SelectedRow.Cells[5].Text == "Transfer")

            if (Str_StrTrantype == "CH")
            {
                return;
            }
            DataTable obj_dt = new DataTable();
            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
            {
                header = "Invoice";
                str_Voucher = "Invoice";
            }
            else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
            {
                header = "PA";
                str_Voucher = "PA";
            }
            else if (hid_type.Value.ToString() == "ProOSDNApproval")
            {
                str_Voucher = "OSSI";
            }
            else
            {
                str_Voucher = "OSPI";
            }

          //  DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            if (!DBNull.Value.Equals(Grd_Approval.SelectedRow.Cells[0].Text))
            {
                int_Vouno = int.Parse(Grd_Approval.SelectedRow.Cells[0].Text.ToString());
            }
            else
            {
                return;
            }
            int_vouyear = Convert.ToInt32(Grd_Approval.SelectedDataKey.Values[0].ToString());
            BL = HttpUtility.HtmlDecode(Grd_Approval.SelectedRow.Cells[1].Text.ToString());
            obj_dt = obj_da_invoice.CheckHblno(BL, Str_StrTrantype, int.Parse(Session["LoginBranchid"].ToString()));

            //obj_dt = obj_da_invoice.CheckHblno(BL, Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            Fn_Getcontainer(obj_dt, Grd_Approval.SelectedRow.RowIndex);
            if (str_Voucher == "OSSI" || str_Voucher == "OSPI")
            {
                Fn_GetCredit(row);
            }
            string Str_RptName = "", Str_SF = "", Str_SP = "", Str_Script = "";
            int int_bid = int.Parse(Session["LoginBranchid"].ToString());
            if (obj_dt.Rows.Count > 0)
            {
                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProInvoice.rpt";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProInvoice.rpt";
                        Str_SP = "Lcurr=INR ";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Str_SP = "Lcurr=INR";
                    }

                    Str_SF = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\"  and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}=" + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    if (get_date >= GST_date)
                    {
                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&trantype=" + Str_StrTrantype + "&blno=" + BL + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);

                    Session["str_sp"] = Str_SP;
                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear;
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAPA.rpt";
                        Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    }

                    Str_SP = "Lcurr=INR";
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                        Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";

                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                    Session["str_sp"] = Str_SP;
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                }
            }
            else
            {

                if (str_Voucher == "Invoice")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR~container=" + hid_container.Value.ToString();
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR ";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear + "";
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProInvoice.rpt";
                        Session["str_sfs"] = "{InvoiceHead.trantype}=\"" + Str_StrTrantype + "\" and {InvoiceHead.refno}=" + int_Vouno + " and {InvoiceHead.branchid}= " + int_bid + " and {InvoiceHead.vouyear}=" + int_vouyear;
                        Str_SP = "Lcurr=INR";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    //Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    }
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1054, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                }
                if (str_Voucher == "PA")
                {
                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIMProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "M" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "CH")
                    {
                        Str_RptName = "CHAProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    else if (Str_StrTrantype == "BT")
                    {
                        Str_RptName = "BTProPA.rpt";
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + int_Vouno.ToString() + "&vouyear=" + int_vouyear.ToString() + "&total=" + amount.ToString() + "&blno=" + BL + "&trantype=" + Str_StrTrantype + "&bltype=" + "H" + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                    }
                    Session["str_sfs"] = "{PAHead.trantype}=\"" + Str_StrTrantype + "\" and {PAHead.refno}=" + int_Vouno + " and {PAHead.branchid}=" + int_bid + " and {PAHead.vouyear}=" + int_vouyear + "";
                    Str_SP = "Lcurr=INR";
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1055, 4, Convert.ToInt32(Session["LoginBranchid"]), int_Vouno.ToString());

                    Session["str_sp"] = Str_SP;
                    if (get_date >= GST_date)
                    {
                    }
                    else
                    {
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                    }

                }


                string str_curr = "";
              //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                if (str_Voucher == "OSSI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[1].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;

                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {

                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;


                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSDN.rpt";
                        Str_SF = "{OSDN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString()); Session["str_sfs"] = Str_SF;
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                        //Session["str_sp"] = Str_SP;

                    }


                    /*if (Str_StrTrantype == "FE")
                    {
                        str_RptName1 = "FEProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;

                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                       
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 40, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        str_RptName1 = "FIProOSDN.rpt";
                        //  Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 41, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        str_RptName1 = "AEProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;
                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 42, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else
                    {
                        str_RptName1 = "AIProOSDN.rpt";
                        // Session["str_sfs"] = "{OSDN.trantype}='" + Str_StrTrantype + "' and {OSDN.jobno}=" + int_jobno + " and {OSDN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSDN.trantype}=\"" + Str_StrTrantype + "\" and {OSDN.refno}=" + int_Vouno + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                     
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 43, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }*/

                }
                if (str_Voucher == "OSPI")
                {
                    int int_jobno = int.Parse(Grd_Approval.SelectedRow.Cells[1].Text.ToString());

                    if (Str_StrTrantype == "FE")
                    {
                        Str_RptName = "FEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 40, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());

                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        Str_RptName = "FIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 41, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        Str_RptName = "AEProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 42, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }
                    else if (Str_StrTrantype == "AI")
                    {
                        Str_RptName = "AIProOSCN.rpt";
                        Str_SF = "{OSCN.trantype}=\"" + Convert.ToString(Str_StrTrantype) + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        if (get_date >= GST_date)
                        {
                            Str_Script = "window.open('../Reportasp/ProformaOverseaDebiCredi.aspx?refno=" + int_Vouno + "&vouyear=" + int_vouyear + "&tran=" + Convert.ToString(Str_StrTrantype) + "&jobno=" + Convert.ToInt32(int_jobno) + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                        }

                        else
                        {
                            Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP1 + "&RFName=" + Str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 43, 3, Convert.ToInt32(Session["LoginBranchid"]), int_jobno.ToString());
                        Session["str_sfs"] = Str_SF;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                    }


                    /*if (Str_StrTrantype == "FE")
                    {

                        str_RptName1 = "FEProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                    
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 40, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "FI")
                    {
                        str_RptName1 = "FIProOSCN.rpt";
                        //  Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();

                        //Session["str_sfs2"] = Str_SF2;
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');

                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 41, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else if (Str_StrTrantype == "AE")
                    {
                        str_RptName1 = "AEProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();
                        //Session["str_sfs2"] = Str_SF2;                        
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 42, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    else
                    {
                        str_RptName1 = "AIProOSCN.rpt";
                        // Session["str_sfs"] = "{OSCN.trantype}='" + Str_StrTrantype + "' and {OSCN.jobno}=" + int_jobno + " and {OSCN.branchid}=" + int_bid;
                        Session["str_sfs"] = "{OSCN.trantype}=\"" + Str_StrTrantype + "\" and {OSCN.refno}=" + int_Vouno + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + int_vouyear;
                        Str_SP1 = "FCurr=" + str_curr;
                        Session["str_sp"] = Str_SP1;

                        //str_RptName2 = "SOA1.rpt";
                        //Str_SF2 = "{MasterBranch.branchid}=" + int_bid;
                        //Str_SP2 = "module=FE~jobno=" + int_jobno + "~crow=" + hid_credit.Value.ToString() + "~drow=" + hid_debit.Value.ToString();

                        //Session["str_sfs2"] = Str_SF2;                    
                        //Session["str_sp2"] = Str_SP2;
                        Str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF + "&Parameter=" + Str_SP + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                        //window.open('../Tools/ReportView.aspx?SFormula=" + Str_SF1 + "&Parameter=" + Str_SP1 + "&RFName=" + str_RptName2 + "&" + this.Page.ClientQueryString + "','','');
                        obj_da_Log.InsLogDetail(int.Parse(Session["LoginEmpId"].ToString()), 43, 3, int.Parse(Session["LoginBranchid"].ToString()), int_jobno.ToString());
                    }
                    */





                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                    btn_delete.Visible = false;
                    return;
                }
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Approval", Str_Script, true);
                btn_delete.Visible = false;
            }
            // UserRights();
        }

        private void Fn_Getcontainer(DataTable dt, int int_Rowindex)
        {
            try
            {
                string Str_StrTrantype = ddl_module.SelectedValue.ToString();
                if (dt.Rows.Count > 0)
                {
                    string Str_sblno = "";

                    if (Str_StrTrantype == "FE" || Str_StrTrantype == "FI")
                    {
                        Str_sblno = dt.Rows[0]["blno"].ToString();
                    }
                    else
                    {
                        Str_sblno = dt.Rows[0]["hawblno"].ToString();
                    }
                    if (Str_StrTrantype == "FE" || Str_StrTrantype == "FI")
                    {
                        if (Grd_Approval.Rows[int_Rowindex].Cells[1].Text.ToString().Trim().Length > 0)
                        {
                            if (Grd_Approval.Rows[int_Rowindex].Cells[1].Text.ToString() == Str_sblno)
                            {
                               // DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
                                DataTable obj_dt = new DataTable();

                                obj_dt = obj_da_invoice.GetHBLContainerDtls(Str_sblno, Str_StrTrantype, int.Parse(Session["LoginBranchid"].ToString()));
                                if (obj_dt.Rows.Count > 0)
                                {
                                    var obj_Container = (from r in obj_dt.AsEnumerable()
                                                         select r.Field<string>("containerno"));
                                    hid_container.Value = string.Join("-", obj_Container);
                                }
                            }
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
        private void Fn_GetCredit(int int_Rowindex)
        {
            try
            {
                string Str_StrTrantype = ddl_module.SelectedValue.ToString();
                DataAccess.Accounts.OSDNCN obj_da_invoice = new DataAccess.Accounts.OSDNCN();
                string Ccode = Convert.ToString(Session["Ccode"]);
                obj_da_invoice.GetDataBase(Ccode);
                DataSet obj_ds = new DataSet();

                obj_ds = obj_da_invoice.RptOSDNCNProFromJobNo(Str_StrTrantype, int.Parse(Grd_Approval.Rows[int_Rowindex].Cells[1].Text.ToString()), int.Parse(Session["LoginBranchid"].ToString()));

                if (obj_ds.Tables.Count > 1)
                {
                    hid_debit.Value = (obj_ds.Tables[1].Rows.Count > 0 ? obj_ds.Tables[2].Rows.Count : 0).ToString();
                    hid_credit.Value = (obj_ds.Tables[2].Rows.Count > 0 ? obj_ds.Tables[2].Rows.Count : 0).ToString();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_transfer_Click(object sender, EventArgs e)
        {
            try
            {
              
                string type = "";
                string str_favourname = "";
                int invoinumber = 0;
              //  DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
                int int_osdncn = 0;
                DataTable dtosdn = new DataTable();
               // DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
                string cutname = "";
                // DataSet dsosdn=new DataSet();
                int jobnoosdn = 0;
                //int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0;
                //string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "";
                int gsttype = 0, statename = 0, supplyto = 0, int_osdncn1 = 0, int_TDS = 0;
                string gsttype_ = "", statename_ = "", supplyto_ = "", str_osdncn1 = "", str_TDS = "";



                int int_Invoiceno = 0, int_Refno = 0, int_Vouyear = 0, int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Voutypeid = 0;
                string Str_Trantype = ddl_module.SelectedValue.ToString(), Str_invoiceno = "", Str_invoicenonew = "";
                int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                DataTable obj_dt = new DataTable();
                string StrScript = "";
                int countinv = 0;
                double st_amt = 0.0;
                double Amount = 0, TDS = 0, TDSAmount = 0, CSTAmount = 0, gstamt = 0;
                //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                //DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                //DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                //DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
                //DataAccess.Masters.MasterChequeReq_App obj_da_Cheque = new DataAccess.Masters.MasterChequeReq_App();
                int int_Custid = 0;
                TextBox Txt = new TextBox();

                string tdstype = "", tdsdesc = "";
                string str_tdstype = "", str_tdsdesc = "";
                int int_tdstype = 0, int_tdsdesc = 0;

                if (hid_type.Value.ToString() == "Transfer To Commercial Invoice" || hid_type.Value.ToString() == "Transfer To Commercial PA")
                {

                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        type = Grd_Approval.Rows[row.RowIndex].Cells[13].Text;
                        string str_Voutype = type;
                        bool ChkLedger = true;
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        if (Chk.Checked == true)
                        {
                            countinv = 1;

                            if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {
                                Txt = (TextBox)Grd_Approval.Rows[row.RowIndex].FindControl("TDSPERS");
                                if (Txt.Text.Trim().Length == 0)
                                {
                                    //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "TDS", "alertify.alert('Enter TDS%');", true);
                                    if (int_TDS == 0)
                                    {
                                        str_TDS = "Enter TDS% for Ref number is " + int_Refno;

                                    }
                                    else
                                    {
                                        str_TDS = str_TDS + "," + int_Refno;
                                    }
                                    Txt.Focus();
                                    int_TDS = 1;
                                    continue;

                                }
                                else
                                {
                                    tdstype = row.Cells[5].Text.ToString();
                                    tdsdesc = row.Cells[6].Text.ToString();
                                    if (tdstype == "" && tdstype == "")
                                    {
                                        if (int_tdstype == 0)
                                        {
                                            str_tdstype = "TDS Type is Empty && TDS DESC is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdstype = str_tdstype + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdstype = 1;
                                        continue;
                                    }
                                    else if (tdstype == "")
                                    {
                                        if (int_tdstype == 0)
                                        {
                                            str_tdstype = "TDS Type is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdstype = str_tdstype + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdstype = 1;
                                        continue;
                                    }

                                    else if (tdsdesc == "")
                                    {
                                        if (int_tdsdesc == 0)
                                        {
                                            str_tdsdesc = "TDS DESC is Empty for Ref number is " + int_Refno;

                                        }
                                        else
                                        {
                                            str_tdsdesc = str_tdsdesc + "," + int_Refno;
                                        }
                                        Txt.Focus();
                                        int_tdsdesc = 1;
                                        continue;
                                    }

                                }
                            }




                            int_Refno = Convert.ToInt32(row.Cells[0].Text.ToString());



                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());




                            //hid_stamt.Value = row.Cells[7].Text.ToString();
                            //hid_supplyto.Value = row.Cells[8].Text.ToString();
                            hid_stamt.Value = row.Cells[10].Text.ToString();
                            hid_supplyto.Value = row.Cells[11].Text.ToString();
                            if (hid_supplyto.Value != "0")
                            {
                                cutname = obj_da_Customer.GetCustomername(Convert.ToInt32(hid_supplyto.Value));
                            }
                            string emp = row.Cells[4].Text.ToString();
                            int empp = employeeobj.GetNEmpid(emp);
                            if (empp == int_Empid)
                            {
                                StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                continue;
                            }
                            DataTable dtnewexrate = obj_da_Invoice.GET_exratecheck(int_Refno, int_bid, int_Vouyear, hid_type.Value.ToString());
                            if (dtnewexrate.Rows.Count > 0)
                            {
                                StrScript += "Ex.Rate Different in Voucher Details " + int_Refno + ".Kindly check Proforma Invoice";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                continue;
                            }

                            Dtckeck = obj_da_Approval.GetInvoiceAppSTCheckAmt(int_Refno, Convert.ToInt32(Session["LoginBranchid"].ToString()), int_Vouyear);
                            if (Dtckeck.Rows.Count > 0)
                            {
                                StrScript += "GST didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Service tax didnt calculate properly in the " + int_Refno + ".Kindly check Proforma Invoice" + "');", true);
                                continue;

                            }
                            if (Session["hid_gstdate"] != null)
                            {
                                if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                                {

                                    if (hid_supplyto.Value != "0")
                                    {

                                        if (Convert.ToDouble(hid_stamt.Value) > 0)
                                        {


                                            int int_custidnew;
                                            DataTable dt_list = new DataTable();
                                          //  DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                            //int int_custid = Convert.ToInt32(hdncustid.Value);
                                            if (!string.IsNullOrEmpty(row.Cells[11].Text.ToString()))
                                            {
                                                int_custidnew = Convert.ToInt32(row.Cells[11].Text.ToString());
                                                dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                            }


                                            if (dt_list.Rows.Count > 0)
                                            {
                                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                {
                                                    if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                    {
                                                        if (gsttype == 0)
                                                        {
                                                            gsttype_ = cutname;
                                                        }
                                                        else
                                                        {
                                                            gsttype_ = " ," + cutname;
                                                        }
                                                        gsttype = 1;
                                                        //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                        continue;
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
                                                if (statename == 0)
                                                {
                                                    statename_ = cutname;
                                                }
                                                else
                                                {
                                                    statename_ = " ," + cutname;
                                                }
                                                statename = 1;
                                                continue;
                                            }




                                        }

                                    }
                                    else
                                    {
                                        //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;
                                        if (supplyto == 0)
                                        {
                                            supplyto_ = int_Refno.ToString();
                                        }
                                        else
                                        {
                                            supplyto_ = " ," + int_Refno.ToString();
                                        }
                                        supplyto = 1;
                                        continue;
                                    }
                                }
                            }


                            string inapproved = obj_da_Approval.CHKVoucherbos(int_Refno);

                            if (inapproved.ToString() == "TRUE" && hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {
                                invoinumber = obj_da_Approval.UpdProApprovalnewbos(hid_type.Value.ToString(), int_bid, int_Refno, int_Vouyear, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype);


                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("BOS", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", branchid, "");

                                //string retransfer = "N";
                                //if (Session["vouid"] != null)
                                //{

                                //    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                                //    if (retransfer == "Y")
                                //    {
                                //        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", "");

                                //    }
                                //    Session["vouid"] = null;

                                //}


                                if (invoinumber != 0)
                                {
                                    Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                                }
                                else
                                {
                                    Str_invoicenonew = "Invoice not Approved";
                                }
                            }
                            string inapproved1 = obj_da_Approval.CHKVoucherinvgen(int_Refno);

                            if (inapproved1.ToString() == "TRUE" && hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {
                                int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(int_bid, hid_type.Value.ToString());
                                obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());
                            }
                            else
                            {
                                int_Invoiceno = obj_da_Approval.GetNoforAcForApproval(int_bid, hid_type.Value.ToString());
                                obj_da_Approval.UpdProApproval(int_Refno, row.Cells[1].Text.Replace("&amp;", "&"), int_Empid, Str_Trantype, int_Vouyear, int_bid, int_Invoiceno, hid_type.Value.ToString());
                            }




                            if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {




                                int_Custid = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[1].ToString());
                                Amount = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[3].Text.ToString()));
                                gstamt = double.Parse((Grd_Approval.Rows[row.RowIndex].Cells[10].Text.ToString()));
                                Amount = Amount - gstamt;
                                TDS = double.Parse(Txt.Text.ToString());

                                TDSAmount = Amount * (TDS / 100);
                                CSTAmount = Amount - TDSAmount;

                                if (str_Voutype == "S")
                                {
                                    obj_dt = obj_da_Invoice.GetPartyLedger4PAAdmin(int_Invoiceno, "C", int.Parse(Session["LoginBranchid"].ToString()), int_Vouyear);
                                }
                                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                {
                                    int int_Ledgerid = 0;
                                    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), "A", Session["FADbname"].ToString());
                                    if (int_Ledgerid == 0)
                                    {
                                        ChkLedger = false;
                                    }
                                }
                                string Str_ddlVoucherType = "", Str_ddlNarration = "", Str_ddlReference = "";
                                if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                {
                                    str_Voutype = "P";              //CN-OPS  -->P  //Admin-CN-->S//  Other-CN-->E
                                    type = "P";
                                }

                                //CheckBox Chkrcm = (CheckBox)row.FindControl("Chk_rcm"); // For RCM
                                //if (Chkrcm.Checked == true)
                                //{

                                //    if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                //    {
                                //        obj_da_Invoice.inspaheadgsttype("R", int_Invoiceno, int_bid, int_Vouyear, "P");
                                //        switch (Session["StrTranType"].ToString())
                                //        {
                                //            case "FE":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                //                break;
                                //            case "FI":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                //                break;
                                //            case "AE":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                //                break;
                                //            case "AI":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                //                break;
                                //            case "CH":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                //                break;
                                //            case "BT":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1053, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/RCM");
                                //                break;
                                //        }
                                //    }
                                //}
                                //else if (Chkrcm.Checked == false)
                                //{
                                //    if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                //    {
                                //        switch (Session["StrTranType"].ToString())
                                //        {
                                //            case "FE":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                //                break;
                                //            case "FI":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                //                break;
                                //            case "AE":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                //                break;
                                //            case "AI":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                //                break;
                                //            case "CH":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                //                break;
                                //            case "BT":
                                //                obj_da_Log.InsLogDetail(int_Empid, 1053, 1, int_bid, "Refno:" + int_Refno + "/Invoiceno:" + int_Invoiceno + "/Vouyear:" + int_Vouyear + "/Voutype:" + str_Voutype + "/NOT RCM");
                                //                break;
                                //        }
                                //    }
                                //}

                                if (ChkLedger == true)
                                {
                                    obj_da_Invoice.InsertPATDS(int_Invoiceno, str_Voutype, int.Parse(Session["LoginBranchid"].ToString()), int_Custid, int_Vouyear, CSTAmount, TDSAmount, "", Convert.ToDouble(Txt.Text.ToString()));


                                    //if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                                    // {
                                    //     str_Voutype="P";
                                    //     type = "P";
                                    // }


                                    if (str_Voutype == "P")
                                    {
                                        Str_ddlVoucherType = "Credit Note - Operations";
                                        Str_ddlNarration = "Vessel/Voyage/Container";
                                        Str_ddlReference = "BL No";
                                    }
                                    else if (str_Voutype == "E")
                                    {
                                        Str_ddlVoucherType = "Credit Note - Others";
                                        Str_ddlNarration = "Vessel/Voyage/Container";
                                        Str_ddlReference = "BL No";
                                    }
                                    else if (str_Voutype == "S")
                                    {
                                        Str_ddlVoucherType = "Admin Purchase Invoice";
                                        Str_ddlNarration = "Remarks";
                                        Str_ddlReference = "Ref No";
                                    }//raj

                                    logix.CommanClass.TallyEDIFA.Fn_FATransfer(Str_ddlVoucherType, int_Invoiceno, int_Invoiceno, Str_ddlNarration, Str_ddlReference, branchid);




                                    int int_Ledgerid = 0;
                                    int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Session["FADbname"].ToString());
                                    int_Voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_ddlVoucherType, Session["FADbname"].ToString());
                                    if (int_Ledgerid == 0)
                                    {
                                        int_Ledgerid = Fn_Getcustomergroupid(int_Custid, Str_ddlVoucherType);
                                    }
                                    //DateTime dtdate = DateTime.Parse(Utility.fn_ConvertDate(Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                                    DateTime dtdate = DateTime.Parse((Grd_Approval.Rows[row.RowIndex].Cells[12].Text));
                                    string Str_CustType = obj_da_Customer.GetCustomerType(int_Custid);
                                    if (Str_CustType == "P" || Str_CustType == "E")
                                    {
                                        DataTable dt = new DataTable();
                                        dt = obj_da_Invoice.GetOtherDCNAmount(int_Invoiceno, "CNHead", int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["Vouyear"].ToString()));
                                        string Str_Curr = "";
                                        double F_Curr = 0;
                                        if (dt.Rows.Count > 0)
                                        {
                                            Str_Curr = dt.Rows[0]["curr"].ToString();
                                            F_Curr = double.Parse(dt.Rows[0]["amt"].ToString());
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, Str_Curr, F_Curr, int_Custid);
                                    }
                                    else
                                    {

                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, dtdate, char.Parse(type), int.Parse(Session["Vouyear"].ToString()), int.Parse(Session["LoginBranchid"].ToString()), CSTAmount, "", 0, int_Custid);
                                    }
                                }

                                //str_favourname = row.Cells[2].Text.ToString();
                                //obj_da_Cheque.UpdChequeRequest(int_Invoiceno, int.Parse(Session["Vouyear"].ToString()), Session["StrTranType"].ToString(), int.Parse(Session["LoginBranchid"].ToString()), int_Empid, "PA", char.Parse("C"), "", str_favourname);

                            }




                            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                            {//raj



                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", branchid, "");
                                if (inapproved.ToString() == "TRUE")
                                {

                                    if (invoinumber != 0)
                                    {
                                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", invoinumber, invoinumber, "Vessel/Voyage/Container", "BL No", branchid, "");
                                    }
                                }



                                string retransfer = "N";
                                if (Session["vouid"] != null)
                                {

                                    retransfer = obj_da_Approval.CHKVoucher(Convert.ToInt32(Session["vouid"]), Session["FADbname"].ToString());

                                    if (retransfer == "Y")
                                    {
                                        logix.CommanClass.TallyEDIFA.Fn_FATransfer("Invoices", int_Invoiceno, int_Invoiceno, "Vessel/Voyage/Container", "BL No", branchid, "");

                                    }
                                    Session["vouid"] = null;

                                }
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_Invoiceno, "Invoice", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());
                                        DateTime date_Voudate = DateTime.Parse(obj_dt.Rows[0].ItemArray[1].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Invoices", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_Invoiceno, date_Voudate, 'I', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERROR In ProApprove Inv#" + int_Invoiceno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                    //   Utility.SendMail("", "", "FA RECEIPT PMT - ERROR In ProApprove Inv#" + int_Invoiceno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                                switch (Str_Trantype)
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1016, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1023, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1030, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1037, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1043, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                }
                            }
                            else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                            {
                                switch (Str_Trantype)
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1017, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1024, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1031, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1038, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;
                                    case "CH":
                                        obj_da_Log.InsLogDetail(int_Empid, 1044, 1, int_bid, int_Refno.ToString() + "/" + int_Invoiceno);
                                        break;

                                }
                            }
                            /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                             {//raj
                                 // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                 try
                                 {
                                     obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                     if (obj_dt.Rows.Count > 0)
                                     {
                                         int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                         DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0]["dndate"].ToString()));
                                         string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                         double amount = double.Parse(row.Cells[3].Text.ToString());
                                         double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                         int int_Ledgerid = 0;
                                         int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                         int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                                         if (int_Ledgerid == 0)
                                         {
                                             int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                     //Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERRORIn ProApprove OSDN#" + int_intdcno + " \\Year - " + int_Vouyear + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                 }
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString());
                                         break;

                                 }
                             }
                             else if (hid_type.Value.ToString() == "ProOSCNApproval")
                             {//raj
                                 // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", "");
                                 try
                                 {
                                     obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                     if (obj_dt.Rows.Count > 0)
                                     {
                                         int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                         DateTime date_Voudate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[0]["cndate"].ToString()));
                                         string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                         double amount = double.Parse(row.Cells[3].Text.ToString());
                                         double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                         int int_Ledgerid = 0;
                                         int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                         int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                                         if (int_Ledgerid == 0)
                                         {
                                             int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                         }
                                         obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                     }
                                 }
                                 catch (Exception ex)
                                 {
                                     //Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERRORIn ProApprove OSCN#" + int_intdcno + " \\Year - " + int_Vouyear + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                 }
                                 switch (Session["StrTranType"].ToString())
                                 {
                                     case "FE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "FI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AE":
                                         obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString());
                                         break;

                                     case "AI":
                                         obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString());
                                         break;

                                 }
                             }*/
                            Str_invoiceno = Str_invoiceno + int_Invoiceno.ToString() + ",";

                        }
                        //else if (countinv != 1)
                        //{

                        //    ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        //    return;
                        //}
                    }
                    if (countinv != 1)
                    {

                        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);


                        if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
                        {

                            StrScript += "Invoice # " + Str_invoiceno + " Generated and Transfered";


                            //if (invoinumber != 0)
                            //{
                            //    StrScript += "BOS # " + invoinumber + " Generated and Transfered";
                            //}
                            //if (int_Invoiceno != 0)
                            //{
                            //    StrScript += "Invoice # " + int_Invoiceno + " Generated and Transfered";
                            //}
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial PA")
                        {
                            StrScript += "CN-Ops # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial CN")
                        {
                            StrScript += "CN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "Transfer To Commercial DN")
                        {
                            StrScript += "DN # " + Str_invoiceno + " Generated and Transfered";
                        }

                        /* else if (hid_type.Value.ToString() == "ProOSDNApproval")
                         {
                             StrScript = "OSDN # " + Str_invoiceno + " Generated and Transfered";
                         }
                         else if (hid_type.Value.ToString() == "ProOSCNApproval")
                         {
                             StrScript = "OSCN # " + Str_invoiceno + " Generated and Transfered";
                         }*/

                    }
                    if (gsttype == 1)
                    {
                        StrScript += "GST TYPE not Updated for the Customer Name :" + gsttype_;
                    }
                    if (statename == 1)
                    {
                        StrScript += "State Name not Updated in Master Kindly update Master Customer for" + statename_;
                    }
                    if (supplyto == 1)
                    {
                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + supplyto_;
                    }

                    if (int_TDS == 1)
                    {
                        StrScript += " " + str_TDS;
                    }

                    if (int_tdstype == 1)
                    {
                        StrScript += " " + str_tdstype;
                    }

                    if (int_tdsdesc == 1)
                    {
                        StrScript += " " + str_tdsdesc;
                    }
                    if (countinv != 1)
                    {

                        StrScript += "Check Atleast One Ref#";
                        //ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        //return;
                    }
                    if (invoinumber != 0)
                    {
                        // Str_invoicenonew = Str_invoicenonew + invoinumber.ToString() + ",";
                        StrScript += "BOS # " + Str_invoicenonew;
                    }
                    // ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert(" + StrScript + ");", true);
                }
                else if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                {
                    foreach (GridViewRow row in Grd_Approval.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_transfer");
                        if (Chk.Checked == true)
                        {
                            countinv = 1;
                            int_Refno = int.Parse(row.Cells[0].Text.ToString());
                            jobnoosdn = int.Parse(row.Cells[1].Text.ToString());
                            int_Vouyear = int.Parse(Grd_Approval.DataKeys[row.RowIndex].Values[0].ToString());
                            // dcno = Approveobj.UpdProApprovalOSDCN(refno, strblno, Login.logempid, strTranType, vouyear, branchid, strFType)
                            hid_stamt.Value = row.Cells[7].Text.ToString();
                            hid_supplyto.Value = row.Cells[8].Text.ToString();
                            string emp = row.Cells[4].Text.ToString();
                            int empp = employeeobj.GetNEmpid(emp);
                            if (empp == int_Empid)
                            {
                                StrScript += "You have no rights to approve Voucher # " + int_Refno + " prepared by you";
                                //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);
                                continue;
                            }


                            /* if (Session["hid_gstdate"] != null)
                             {
                                 if (Convert.ToDateTime(logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                                 {
                                     if (hid_supplyto.Value != "0")
                                     {
                                         if (Convert.ToDouble(hid_stamt.Value) > 0)
                                         {

                                             int int_custidnew;
                                             DataTable dt_list = new DataTable();
                                             DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                                             //int int_custid = Convert.ToInt32(hdncustid.Value);
                                             if (!string.IsNullOrEmpty(row.Cells[8].Text.ToString()))
                                             {
                                                 int_custidnew = Convert.ToInt32(row.Cells[8].Text.ToString());
                                                 dt_list = customerobj.GetIndianCustomergstadd(int_custidnew);
                                             }


                                             /*if (dt_list.Rows.Count > 0)
                                             {
                                                 if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                                 {

                                                 }
                                                 else
                                                 {
                                                     StrScript += "State Name not Updated in Master Kindly update Master Customer ";

                                                     continue;
                                                 }
                                             }
                                             else
                                             {
                                                 StrScript += "State Name not Updated in Master Kindly update Master Customer";

                                                 continue;
                                             }
                                            

                                             if (dt_list.Rows.Count > 0)
                                             {
                                                 if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                                 {
                                                     if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                                     {
                                                         if (gsttype == 0)
                                                         {
                                                             gsttype_ = row.Cells[2].Text;
                                                         }
                                                         else
                                                         {
                                                             gsttype_ = " ," + row.Cells[2].Text;
                                                         }
                                                         gsttype = 1;
                                                         //StrScript += "GST TYPE not Updated for the Customer Name :" + row.Cells[2].Text.ToString() + " in the Voucher #" + int_Refno;
                                                         continue;
                                                     }
                                                 }

                                             }
                                             else
                                             {
                                                 //StrScript += "State Name not Updated in Master Kindly update Master Customer for" + row.Cells[2].Text.ToString();
                                                 if (statename == 0)
                                                 {
                                                     statename_ = row.Cells[2].Text;
                                                 }
                                                 else
                                                 {
                                                     statename_ = " ," + row.Cells[2].Text;
                                                 }
                                                 statename = 1;
                                                 continue;
                                             }



                                         }
                                     }
                                     else
                                     {

                                         //StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + int_Refno;

                                         //continue;


                                         if (supplyto == 0)
                                         {
                                             supplyto_ = int_Refno.ToString();
                                         }
                                         else
                                         {
                                             supplyto_ = " ," + int_Refno.ToString();
                                         }
                                         supplyto = 1;
                                         continue;
                                     }
                                 }
                             }*/


                            dtosdn = obj_da_OSDNCN.GetCheckosdncnnew(Str_Trantype, jobnoosdn, int_bid);
                            int cnt = 0;
                            cnt = dtosdn.Rows.Count;
                            if (cnt == 1)
                            {
                                if (int_osdncn1 == 0)
                                {
                                    str_osdncn1 = int_Refno.ToString();
                                }
                                else
                                {
                                    str_osdncn1 = " ," + int_Refno.ToString();
                                }
                                int_osdncn1 = 1;
                                continue;

                            }


                            else
                            {


                                int_intdcno = obj_da_Approval.UpdProApprovalOSDCN(int_Refno, Convert.ToInt32(row.Cells[1].Text.ToString()), int_Empid, Str_Trantype, int_Vouyear, int_bid, hid_type.Value.ToString());
                                obj_da_Approval.insForOSDNCNDNCNNumber(int_intdcno, hid_type.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(row.Cells[1].Text.ToString()), Str_Trantype, int_Refno);
                            }


                            if (hid_type.Value.ToString() == "ProOSDNApproval")
                            {//raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", branchid, "");
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSSI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                        DateTime date_Voudate = DateTime.Parse((obj_dt.Rows[0]["dndate"].ToString()));
                                        string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                        double amount = double.Parse(row.Cells[3].Text.ToString());
                                        double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSSI", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'D', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERRORIn ProApprove OSDN#" + int_intdcno + " \\Year - " + int_Vouyear + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                    // Utility.SendMail("", "", "FA RECEIPT PMT - ERRORIn ProApprove OSDN#" + int_intdcno + " \\Year - " + int_Vouyear + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                                switch (Str_Trantype)
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1018, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1025, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1032, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1039, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                }
                            }
                            else if (hid_type.Value.ToString() == "ProOSCNApproval")
                            {//raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_intdcno, int_intdcno, "Vessel/Voyage/Container", "BL No", branchid, "");
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_intdcno, "OSPI", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0]["customer"].ToString());
                                        DateTime date_Voudate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[0]["cndate"].ToString()));
                                        string str_curr = obj_dt.Rows[0]["curr"].ToString();
                                        double amount = double.Parse(row.Cells[3].Text.ToString());
                                        double vamount = amount * double.Parse(obj_dt.Rows[0]["exrate"].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("OSPI", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_intdcno, date_Voudate, 'C', int_Vouyear, int_bid, vamount, str_curr, amount, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Utility.SendMail(Session["usermailid"].ToString(), "", "FA RECEIPT PMT - ERRORIn ProApprove OSCN#" + int_intdcno + " \\Year - " + int_Vouyear + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                    //  Utility.SendMail("", "", "FA RECEIPT PMT - ERRORIn ProApprove OSCN#" + int_intdcno + " \\Year - " + int_Vouyear + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                                switch (Str_Trantype)
                                {
                                    case "FE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1019, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "FI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1026, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AE":
                                        obj_da_Log.InsLogDetail(int_Empid, 1036, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                    case "AI":
                                        obj_da_Log.InsLogDetail(int_Empid, 1040, 1, int_bid, int_Refno.ToString() + "/" + int_intdcno);
                                        break;

                                }
                            }
                            if (int_intdcno != 0)
                            {
                                Str_invoiceno = Str_invoiceno + int_intdcno.ToString() + ",";
                            }
                            else
                            {
                                StrScript += "OSDN # or OSCN # Not Generated and Transfered";

                            }

                        }



                    }
                    if (countinv != 1)
                    {

                        ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Check Atleast One Ref#');", true);
                        return;
                    }
                    if (Str_invoiceno.Length > 0)
                    {
                        Str_invoiceno = Str_invoiceno.Substring(0, Str_invoiceno.Length - 1);

                        // string StrScript = "";
                        if (hid_type.Value.ToString() == "ProOSDNApproval")
                        {
                            StrScript += "OSDN # " + Str_invoiceno + " Generated and Transfered";
                        }
                        else if (hid_type.Value.ToString() == "ProOSCNApproval")
                        {
                            StrScript += "OSCN # " + Str_invoiceno + " Generated and Transfered";
                        }

                    }
                    if (gsttype == 1)
                    {
                        StrScript += "GST TYPE not Updated for the Customer Name :" + gsttype_;
                    }
                    if (statename == 1)
                    {
                        StrScript += "State Name not Updated in Master Kindly update Master Customer for" + statename_;
                    }
                    if (supplyto == 1)
                    {
                        StrScript += "Kindly Update SupplyTo Customer for the Voucher # " + supplyto_;
                    }
                    if (int_osdncn1 == 1)
                    {
                        StrScript += "Kindly Save the Proforma Voucher Again and Approve for" + str_osdncn1;
                    }

                }

                Fn_Getdetail();
                if (Session["usermailid"].ToString() != "" || Session["usermailpwd"].ToString() != "")
                {
                    Utility.SendMail(Session["usermailid"].ToString(), Session["usermailid"].ToString(), "Approve " + StrScript + " \\Year - " + Session["Vouyear"].ToString() + " \\Branch - " + Session["LoginBranchName"].ToString(), "Approve " + StrScript + " \\Year - " + Session["Vouyear"].ToString() + " \\Branch - " + Session["LoginBranchName"].ToString(), "", Session["usermailpwd"].ToString());
                }
                //if (Str_invoiceno.Length > 0)
                //{
                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('" + StrScript + "');", true);

                //}
                //  UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btn_delete.Visible = false;

        }

        private int Fn_Getcustomergroupid(int int_Custid)
        {
            int int_Subgroupid = 0, int_Groupid = 0;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            if (hid_type.Value.ToString() == "Transfer To Commercial Invoice")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
            else if (hid_type.Value.ToString() == "ProOSCNApproval")
            {
                int_Subgroupid = 44;
                int_Groupid = 12;
            }
            else if (hid_type.Value.ToString() == "ProOSDNApproval")
            {
                int_Subgroupid = 65;
                int_Groupid = 13;
            }
            int int_Ledgerid = 0;
            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Session["FADbname"].ToString());

            return int_Ledgerid;
        }

        private int Fn_Getcustomergroupid(int int_Custid, string Str_VType)
        {
            int int_Subgroupid = 0, int_Groupid = 0;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            if (Str_VType == "Credit Note - Others")
            {
                if (obj_da_Customer.GetCustomerType(int_Custid) == "P")
                {
                    int_Subgroupid = 44;
                    int_Groupid = 12;
                }
                else
                {
                    int_Subgroupid = 67;
                    int_Groupid = 12;
                }
            }
            else if (Str_VType == "Credit Note - Operations")
            {
                int_Subgroupid = 67;
                int_Groupid = 12;
            }
            else if (Str_VType == "Admin Purchase Invoice")
            {
                int_Subgroupid = 41;
                int_Groupid = 12;
            }
            int int_Ledgerid = 0;
            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Session["FADbname"].ToString());

            return int_Ledgerid;
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Grd_Approval.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Approval.DataBind();
               

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                btn_delete.Visible = false;
            }
            else
            {
                div_iframe.Visible = false;
              
            }

            
        }

        protected void lnk_Prooncps_Click(object sender, EventArgs e)
        {
            div_UnClos.Visible = false;
            _Pend_UN.Visible = false;
            btn_transfer.Visible = true;
            //btn_backdated.Visible = true;
            visible_false();
            vis_div();
            if (ddl_module.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btn_transfer, typeof(Button), "Costing", "alertify.alert('Select Product ');", true);
                return;

            }
            // lnk_Unclosed.Visible = false;
            string vouname, vouname1;
            //string trantype_process = Session["StrTranType"].ToString();
            string trantype_process = ddl_module.SelectedValue.ToString();
            string str_sp = "";
            string str_sf = "";
            string str_RptName = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            DataTable dtuser = new DataTable();
            if (trantype_process == "FE")
            {


                dtuser = obj_UP.GetFormwiseuserRights(1017, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";

                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;

                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {

                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {

                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {

                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                       
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    // btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }



            }
            if (trantype_process == "FI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1024, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    string app1 = "CN-Ops Proforma to Commercial";
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    //string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }



            }
            if (trantype_process == "AE")
            {


                dtuser = obj_UP.GetFormwiseuserRights(1031, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {
                    div_ComApproval.Visible = true;
                    // this.aePopUpshow.Show();
                    string app1 = "CN-Ops Proforma to Commercial";
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    // string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    // btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    //  Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }



            }
            if (trantype_process == "AI")
            {

                dtuser = obj_UP.GetFormwiseuserRights(1038, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantype_process);
                if (dtuser.Rows.Count > 0)
                {

                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    div_ComApproval.Visible = true;
                    // Session["Value"] = 1;
                    //  string app1 = "Invoice Proforma to Commercial";
                    //  string app1 = "CN-Ops Proforma to Commercial";
                    string app1 = "CN-Ops Proforma to Commercial";
                    hid_type.Value = app1;
                    if (hid_type.Value == "CN-Ops Proforma to Commercial")
                    {
                        lbl_Header.Text = "Transfer To Commercial CN - Operations";
                        hid_type.Value = "Transfer To Commercial PA";
                    }
                    else if (hid_type.Value == "Transfer To Commercial DN" || hid_type.Value == "Transfer To Commercial CN")
                    {
                        lbl_Header.Text = hid_type.Value;
                        hid_type.Value = lbl_Header.Text;
                    }

                    else
                        if (hid_type.Value.ToString() == "OSDN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSDN Proforma To Commercial";
                            hid_type.Value = "ProOSDNApproval";

                        }
                        else if (hid_type.Value.ToString() == "OSCN Proforma to Commercial")
                        {
                            lbl_Header.Text = "OSCN Proforma To Commercial";
                            hid_type.Value = "ProOSCNApproval";
                        }
                        else
                        {
                            hid_type.Value = lbl_Header.Text;
                        }
                    // HeaderLabel.InnerText = lbl_Header.Text;

                    Fn_Getdetail();
                    if (hid_type.Value.ToString() == "ProOSDNApproval" || hid_type.Value.ToString() == "ProOSCNApproval")
                    {
                        if (Grd_Approval.Rows.Count > 0)
                        {
                            Grd_Approval.HeaderRow.Cells[1].Text = "Job #";
                        }
                    }
                    // UserRights();
                    // Response.Redirect("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //Session["app1"] = app1;
                    // iframecost.Attributes["src"] = ("../ForwardExports/CommercialApproval.aspx?app1=" + app1);
                    //btn_cancel.Text = "Cancel";

                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(lnk_Prooncps, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                }



            }
        }

        protected void ddl_module_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbl_Header.Text == "Transfer To Commercial Invoice")
            {
                lnk_proInvoice_Click(sender, e);
            }
            else if (lbl_Header.Text == "Transfer To Commercial CN - Operations")
            {
                lnk_Prooncps_Click(sender,e);
            }
           
        }


        protected void ExRate_Change_Click(object sender, EventArgs e)
        {
            try
            {
                formname = "ExRate Change";
                if (!string.IsNullOrEmpty(obj_voucher.GetUiidfromFormname(formname, Modulename)))
                {
                    UiiD = Convert.ToInt32(obj_voucher.GetUiidfromFormname(formname, Modulename));
                }

                if (UiiD == 0)
                {

                }
                else
                {
                    dtuser = obj_UP.GetFormwiseuserRights(UiiD, logempid, branchid, Modulename);
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Accounts/AmendExRatenew.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(lnk_cnopstds, typeof(LinkButton), "Vouchers", "alertify.alert('You dont have rigts for this form.')", true);
                    }

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void Grid_salesout_PreRender(object sender, EventArgs e)
        {
            if (Grid_salesout.Rows.Count > 0)
            {
                Grid_salesout.UseAccessibleHeader = true;
                Grid_salesout.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnk_group_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/MasterGroup.aspx");
        }

        protected void lnk_subgroup_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/MasterSubGroup.aspx");
        }

        protected void lnk_ledger_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/Ledgers.aspx");
        }

        protected void lnk_daybook_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/DayBook.aspx");
        }

        protected void lnk_reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/VoucherRegister.aspx?FormName=Registers&uiid=1783");
        }

        protected void lnk_ledg_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/FALedgerView.aspx");
        }

        protected void lnk_statistics_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/Statistics.aspx");
        }

        protected void lnk_outst_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/Outstanding_Online_New.aspx");
        }

        protected void lnk_svp_Click(object sender, EventArgs e)
        {

        }

        protected void lnk_trialba_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/TrialBalanceWEB.aspx");
        }

        protected void lnk_pl_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/profitandloss.aspx");
        }

        protected void lnk_balsheet_Click(object sender, EventArgs e)
        {
            Response.Redirect("../FAForms/balanceSheet.aspx");
        }


        // Vino New for MIS Home - Sales,Purchase, Receipt and Payment Details [26-02-2024]
        protected void grdBranchSPRDet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //for (int i = 0; i < e.Row.Cells.Count; i++)
                //{
                //    if (e.Row.Cells[i].Text == "0")
                //    {
                //        e.Row.Cells[i].Text = "0.00";
                //    }
                //    e.Row.Cells[i].Text = HttpUtility.HtmlDecode(e.Row.Cells[i].Text);
                //    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                //}

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (i > 1 && i <= 5)
                    {
                        if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                // Add events to each editable cell
                for (int columnIndex = 0; columnIndex < e.Row.Cells.Count; columnIndex++)
                {
                    // Add the column index as the event argument parameter
                    string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                    // Add this javascript to the onclick Attribute of the cell
                    e.Row.Cells[columnIndex].Attributes["onclick"] = js;

                    // Add a cursor style to the cells
                    //e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                }

                e.Row.Attributes["style"] = "cursor:pointer";

                for (int h = 1; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void grdBranchSPRDet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = 0, cindex = 0, selectedColumnIndex = 0, selectedRowIndex = 0, voumonth = 0;
                string selcolname = "";
                DataTable dtdet = new DataTable();
                lblheadersrp.Text = "";

                if (e.CommandName.ToString() == "ColumnClick")
                {
                    foreach (GridViewRow r in grdBranchSPRDet.Rows)
                    {
                        if (r.RowType == DataControlRowType.DataRow)
                        {
                            for (int columnIndex = 0; columnIndex < r.Cells.Count; columnIndex++)
                            {
                                r.Cells[columnIndex].Attributes["style"] += "background-color:White;";
                            }
                        }
                    }

                    selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                    selectedColumnIndex = Convert.ToInt32(Request.Form["__EVENTARGUMENT"].ToString());
                }

                if (grdBranchSPRDet.Rows.Count > 0)
                {
                    index = selectedRowIndex;
                    cindex = selectedColumnIndex;

                    selcolname = grdBranchSPRDet.Columns[selectedColumnIndex].HeaderText;

                    lblheadersrp.Text = selcolname;

                    voumonth = Convert.ToInt32(grdBranchSPRDet.DataKeys[index].Values[0].ToString());
                    ViewState["RrtMonth"] = grdBranchSPRDet.Rows[index].Cells[cindex].Text;


                    if (voumonth != 0)
                    {
                        dtdet = obj_voucher.GetFinanceBranchDashBoardDetails(selcolname, Convert.ToInt32(Session["LogYear"]), Convert.ToInt32(Session["LoginBranchid"].ToString()), voumonth);

                        if (dtdet.Rows.Count > 0)
                        {
                            grdB_SPRDet.Visible = true;
                            btncancel.Visible = true;
                            lblheadersrp.Visible = true;
                            btnexcelsrp.Visible = true;

                            DataTable dt1 = new DataTable();
                            dt1 = dtdet;
                            DataRow dr = dt1.NewRow();

                            if (selcolname == "Purchase" || selcolname == "Sales")
                            {
                                dr["Customer"] = "Total";
                            }
                            else if (selcolname == "Receipts")
                            {
                                dr["Received From"] = "Total";
                            }
                            else if (selcolname == "Payments")
                            {
                                dr["Payment To"] = "Total";
                            }
                            dr["Amount"] = dt1.Compute("sum(Amount)", "");

                            dt1.Rows.Add(dr);

                            PnlBranchSPRDet.Visible = false;
                            grdBranchSPRDet.Visible = false;

                            grdB_SPRDet.DataSource = dt1;
                            grdB_SPRDet.DataBind();

                        }
                        else
                        {
                            grdB_SPRDet.Visible = false;
                            btncancel.Visible = false;
                            lblheadersrp.Visible = false;
                            lblheadersrp.Text = "";
                            btnexcelsrp.Visible = false;
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

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (grdB_SPRDet.Visible == true)
            {
                if (grdBranchSPRDet.Rows.Count > 0)
                {
                    grdB_SPRDet.Visible = false;
                    btncancel.Visible = false;
                    lblheadersrp.Visible = false;
                    btnexcelsrp.Visible = false;

                    PnlBranchSPRDet.Visible = true;
                    grdBranchSPRDet.Visible = true;
                }

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void grdB_SPRDet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    double dbl_temp = 0;
                    if (e.Row.Cells[6].Text != "")
                    {
                        if (double.TryParse(e.Row.Cells[6].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[6].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }

                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    if (e.Row.Cells[i].Text == "Total")
                    {
                        e.Row.Cells[i].ForeColor = System.Drawing.Color.Brown;
                        e.Row.Cells[i + 1].ForeColor = System.Drawing.Color.Brown;
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;

                }
            }
        }

        protected void btnexcelsrp_Click(object sender, EventArgs e)
        {
            if (grdB_SPRDet.Rows.Count > 0)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=" + lblheadersrp.Text + "_Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (grdB_SPRDet.Visible == true)
                {
                    grdB_SPRDet.GridLines = GridLines.Both;
                    grdB_SPRDet.HeaderStyle.Font.Bold = true;
                    grdB_SPRDet.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }



    }
}