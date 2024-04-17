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
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.DataVisualization.Charting;
using ClosedXML.Excel;
using DataAccess.BondedTrucking;
using logix.MIS;

namespace logix.Home
{
    public partial class SalesHome : System.Web.UI.Page
    {
        DataAccess.Accounts.Invoice invoiceobj = new DataAccess.Accounts.Invoice();
        DataAccess.BuyingRate Buyobj = new DataAccess.BuyingRate();
        DataAccess.Masters.MasterPort port = new DataAccess.Masters.MasterPort();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Outstanding outobj = new DataAccess.Outstanding();
        DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.Marketing.Quotation objQuat = new DataAccess.Marketing.Quotation();
        DataAccess.Masters.MasterEmployee empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.CostingDetails costobj = new DataAccess.CostingDetails();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        string naem;
        string tran;
        bool blerrOE, blerrOI, blerrAE, blerrAI, blerrBT, blerrCH;
        DataTable dt = new DataTable();
        DataTable dataOut = new DataTable();
        int time;
        DataTable dataQuat = new DataTable();
        DataTable dtNew = new DataTable();
        DataAccess.Outstanding oustobj = new DataAccess.Outstanding();
        //  DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        string customername;
        int customerid;
        double amt = 0.00;
        string product = "";
        string value = "";
        string trantype;
        int custid;
        DataTable dtTemp = new DataTable();
        DataAccess.Masters.MasterCreditApproval mca = new DataAccess.Masters.MasterCreditApproval();

        DataAccess.ForwardingExports.JobInfo objsales = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.BuyingRate byobj = new DataAccess.BuyingRate();

        DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Invoice da_obj_invoiceobj = new DataAccess.Accounts.Invoice();
         DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();

        DataAccess.CRMNew.TeleCaller objmain = new DataAccess.CRMNew.TeleCaller();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);



            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objbu.GetDataBase(Ccode);
                invoiceobj.GetDataBase(Ccode);
                Buyobj.GetDataBase(Ccode);
                port.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                objJob.GetDataBase(Ccode);
                outobj.GetDataBase(Ccode);


                exrobj.GetDataBase(Ccode);
                objQuat.GetDataBase(Ccode);
                empobj.GetDataBase(Ccode);
                objsales.GetDataBase(Ccode);
                costobj.GetDataBase(Ccode);


                obj_UP.GetDataBase(Ccode);
                oustobj.GetDataBase(Ccode);
                mca.GetDataBase(Ccode);
                byobj.GetDataBase(Ccode);
                obj_da_Logobj.GetDataBase(Ccode);


                da_obj_invoiceobj.GetDataBase(Ccode);
                obj_MasterCustomer.GetDataBase(Ccode);

                objmain.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);


            }





                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnoutExcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_Perfor_det);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(excportexc);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(credit_excel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(quatatio_exce);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(crdexp);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(exempexcel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_lblPerformance);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(excl_export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lnk_div_book);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(lbl_cust_name);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(workingprogess);

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LnkTB);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LnkApp);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LnkPR);

            //((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(LinkButton1);          

            lnk_div_book.Visible = false;
            excl_export.Visible = false;
            lbl_cust_name.Visible = false;
            lblBooking.Visible = false;

            //Edit
            Panel10.Visible = false;
            GrdCustomer.Visible = false;
            CallPannel.Visible = false;
            //Edit

            if (!IsPostBack)
            {
                txtFromdate.Text = Utility.fn_ConvertDate(logobj.GetDate().ToString());
                txtTodate.Text = Utility.fn_ConvertDate(logobj.GetDate().ToString());
                div_book.Visible = false;
                Panel7.Visible = false;
                GridView2.Visible = false;
                grdTranNew.Visible = true;
                grdQuatotion.Visible = true;
                divBooknew.Visible = false;
                div_coll.Visible = false;
                workingprogess.Visible = false;
                WIP.Visible = false;
                lnk_div_book.Visible = false;
                divebooking.Visible = false;
                //div5.Visible = false;
                // div6.Visible = true;
                // div5.Visible = false;
                Label1.Text = "OutStanding";
                Panel9.Visible = false;
                div1.Visible = false;
                Panel4.Visible = false;
                GrdBooking.Visible = false;
                pnlJobAE.Visible = false;
                excl_export.Visible = false;
                //div5.Visible = true;
                //div7.Visible = true;
                //div8.Visible = true;
                //div6.Visible = true;
                //div5.Visible = true;
                //bookingdata();

                getdata();
                // outstandingdata();
                // performancedata();

                exratedata();

                //Over_All_Booking();
                //Quot_Count();

                OutStanding_Count();
                //Over_All_Booking();
                //loadgrd();
                Work_Process();
                Get_PersonDetails();
                Booking_CountNew();
                // BookingDet();
                ddl_cmbase_add();
                CountCredi_excp();
                Un_App();
                App();
                Getcreditrequest();
                workcount();
                bookline();
                //salesline();
                salelinechart();
                CountFor_Collectionadvise();
                lblBooking.Visible = false;
                lbl_cust_name.Visible = false;

                GetApp();
            }

            Session["name"] = "";
        }

        //[WebMethod]
        //public static List<countrydetails> GetChartData()
        //{

        //        DataTable dtab = new DataTable();
        //        DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
        //        DataAccess.Outstanding outobj = new DataAccess.Outstanding();
        //        List<countrydetails> dataList = new List<countrydetails>();
        //        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        //        DataTable dataOut;
        //        int time = Logobj.GetDate().Hour;
        //        // dtab = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
        //        dataOut = outobj.GetOutStandingProcessUiNew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), time, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
        //        DataTable dtemptyfree = new DataTable();

        //        dtemptyfree.Columns.Add("customer");
        //        dtemptyfree.Columns.Add("amount");
        //        dtemptyfree.Columns.Add("custid");
        //        DataRow dr = dtemptyfree.NewRow();
        //        if (dataOut.Rows.Count > 0)
        //        {
        //            for (int j = 0; j <= dataOut.Rows.Count - 1; j++)
        //            {
        //                dtemptyfree.Rows.Add();
        //                dr = dtemptyfree.NewRow();
        //                dtemptyfree.Rows[j]["customer"] = dataOut.Rows[j]["customer"].ToString();
        //                dtemptyfree.Rows[j]["amount"] = dataOut.Rows[j]["amount"].ToString();
        //                dtemptyfree.Rows[j]["custid"] = dataOut.Rows[j]["custid"].ToString();
        //            }
        //            dtemptyfree.Rows.Add(dr);
        //            var sum_Income = dataOut.Compute("sum(amount)", "");
        //            dtemptyfree.Rows[dataOut.Rows.Count]["customer"] = "Total";
        //            dtemptyfree.Rows[dataOut.Rows.Count]["amount"] = sum_Income.ToString();

        //            dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

        //            foreach (DataRow dtrow in dtemptyfree.Rows)
        //            {
        //                countrydetails details = new countrydetails();
        //                details.Countryname = dtrow["customer"].ToString();
        //                details.Total = Convert.ToDouble(dtrow["amount"]);
        //                dataList.Add(details);
        //            }
        //        }

        //   return dataList;
        //}
        [WebMethod]
        public static List<countrydetails> GetChartPerformance()
        {

            DataTable dtab = new DataTable();
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            DataAccess.Outstanding outobj = new DataAccess.Outstanding();
            List<countrydetails> dataList = new List<countrydetails>();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            DataTable dataOut = new DataTable();
            string product = "";
            string value = "";
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("Product");
            dtTemp.Columns.Add("Amount", typeof(Double));
            DataRow dr;
            // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            DateTime Todate = Convert.ToDateTime(Logobj.GetDate().ToString());
            DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objbu.GetDataBase(Ccode);
            outobj.GetDataBase(Ccode);
            Logobj.GetDataBase(Ccode);
            objJob.GetDataBase (Ccode);
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            if (HttpContext.Current.Session["fromdate"] != null && (HttpContext.Current.Session["todate"]) != null)
            {
                dataOut = objJob.GetPerformanceRevenusales(Convert.ToDateTime(HttpContext.Current.Session["fromdate"]), Convert.ToDateTime(HttpContext.Current.Session["todate"]), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }
            else
            {
                dataOut = objJob.GetPerformanceRevenusales(fromdate, Todate, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }
            DataTable dtemptyfree = new DataTable();

            dtemptyfree.Columns.Add("product");
            dtemptyfree.Columns.Add("amount");
            dr = dtemptyfree.NewRow();
            if (dataOut.Rows.Count > 0)
            {

                for (int j = 0; j <= dataOut.Rows.Count - 1; j++)
                {

                    product = dataOut.Rows[j]["trantype"].ToString();

                    if (product == "FE")
                    {
                        value = "OE";
                    }
                    else if (product == "FI")
                    {
                        value = "OI";
                    }
                    else if (product == "AE")
                    {
                        value = "AE";
                    }
                    else if (product == "AI")
                    {
                        value = "AI";
                    }
                    else if (product == "CH")
                    {
                        value = "CHA";
                    }
                    else if (product == "BT")
                    {
                        value = "BT";
                    }
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows.Add();
                    dtemptyfree.Rows[j]["product"] = value.ToString();
                    // dtemptyfree.Rows[j]["product"] = dataOut.Rows[j]["trantype"].ToString();
                    dtemptyfree.Rows[j]["amount"] = dataOut.Rows[j]["amount"].ToString();

                }

                dtemptyfree.Rows.Add(dr);
                var sum_Income = dataOut.Compute("sum(amount)", "");
                dtemptyfree.Rows[dataOut.Rows.Count]["product"] = "Total";
                dtemptyfree.Rows[dataOut.Rows.Count]["amount"] = sum_Income.ToString();

                dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                foreach (DataRow dtrow in dtemptyfree.Rows)
                {
                    countrydetails details = new countrydetails();
                    details.Countryname = dtrow["product"].ToString();
                    details.Total = Convert.ToDouble(dtrow["amount"]);
                    dataList.Add(details);
                }

            }
            return dataList;
        }

        //public void linkouts()
        //{
        //    DataTable dtab = new DataTable();
        //    DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
        //    DataAccess.Outstanding outobj = new DataAccess.Outstanding();
        //    List<countrydetails> dataList = new List<countrydetails>();
        //    DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        //    DataTable dataOut;
        //    int time = Logobj.GetDate().Hour;
        //    // dtab = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
        //    dataOut = outobj.GetOutStandingProcessUiNew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), time, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
        //    DataTable dts = new DataTable();
        //    string[] x = new string[dataOut.Rows.Count];
        //    Double[] y = new Double[dataOut.Rows.Count];
        //    for (int i = 0; i < dataOut.Rows.Count; i++)
        //    {
        //        x[i] = dataOut.Rows[i]["customer"].ToString();
        //        y[i] = Convert.ToDouble(dataOut.Rows[i]["amount"]);
        //    }

        //    piechart.Legends.Clear();
        //    piechart.Series[0].Points.DataBindXY(x, y);
        //    piechart.Series[0].ChartType = SeriesChartType.Pie;
        //    piechart.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        //    piechart.Legends[0].Enabled = true;
        //    //piechart.Legends[0].Enabled = true;

        //    //piechart.Legends.Clear();
        //    //piechart.Visible = true;
        //    //piechart.Series[0].Points.DataBindXY(x, y);
        //    //piechart.Series[0].ChartType = SeriesChartType.Pie;
        //    //piechart.Series[0].Label = "#VALX (#PERCENT)";
        //    ////piechart.Titles.Clear();
        //    ////piechart.Titles.Add("M+R CHENNAI");
        //    //piechart.Legends.Add(new Legend("Default") { Docking = Docking.Right });
        //    //piechart.Series[0]["PieLabelStyle"] = "Disabled";

        //}

        public void outchart()
        {
            ViewState["grdOutStanding"] = dtTemp;
            DataView dv = dtTemp.DefaultView;
            dv.Sort = "";
            DataTable sortedDT = dv.ToTable();
            string[] x = new string[dataOut.Rows.Count];
            Double[] y = new Double[dataOut.Rows.Count];
            for (int i = 0; i < dataOut.Rows.Count; i++)
            {
                x[i] = dataOut.Rows[i]["customer"].ToString();
                y[i] = Convert.ToDouble(dataOut.Rows[i]["amount"]);
            }
            foreach (Series s1 in Chart1.Series)
            {
                s1.ToolTip = "State: #VALX\nPopulation: #VALY\nPercentage: #PERCENT";
            }
            Chart1.Legends.Clear();
            // chartoperProfit.Visible = false;
            Chart1.Visible = true;
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Series[0].Label = "#VALX (#PERCENT)";
            Chart1.Series[0].LegendText = "#AXISLABEL";
            //piechart.Titles.Clear();
            //piechart.Titles.Add("M+R CHENNAI");
            Chart1.Legends.Add(new Legend("Default") { Docking = Docking.Right });
            Chart1.Series[0]["PieLabelStyle"] = "Disabled";

        }
        public void bookchart()
        {

            //  dts = (DataTable)Session["GrdCuswise"];

            dts = objbu.SalesCustNameForBooking(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));
            DataView dv = dts.DefaultView;
            dv.Sort = "";
            DataTable sortedDT = dv.ToTable();
            string[] x = new string[dts.Rows.Count];
            int[] y = new int[dts.Rows.Count];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                x[i] = dts.Rows[i]["customername"].ToString();
                y[i] = Convert.ToInt32(dts.Rows[i]["Counts"]);
            }
            foreach (Series s in piechartbook.Series)
            {
                s.ToolTip = "State: #VALX\nPopulation: #VALY\nPercentage: #PERCENT";
            }
            piechartbook.Legends.Clear();
            // chartoperProfit.Visible = false;
            piechartbook.Visible = true;
            piechartbook.Series[0].Points.DataBindXY(x, y);
            piechartbook.Series[0].ChartType = SeriesChartType.Pie;
            piechartbook.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            piechartbook.Series[0].Label = "#VALX (#PERCENT)";
            piechartbook.Series[0].LegendText = "#AXISLABEL";
            //piechart.Titles.Clear();
            //piechart.Titles.Add("M+R CHENNAI");
            piechartbook.Legends.Add(new Legend("Default") { Docking = Docking.Right });
            piechartbook.Series[0]["PieLabelStyle"] = "Disabled";

        }
        public void perchart()
        {
            DataTable dtemptyfree = new DataTable();
            DataRow dr;
            DateTime Todate = Convert.ToDateTime(Logobj.GetDate().ToString());
           // DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            if (Session["fromdate"] != null && Session["todate"] != null)
            {
                dataOut = objJob.GetPerformanceRevenusales(Convert.ToDateTime(HttpContext.Current.Session["fromdate"]), Convert.ToDateTime(HttpContext.Current.Session["todate"]), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }
            else
            {
                dataOut = objJob.GetPerformanceRevenusales(fromdate, Todate, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
            }
            dtemptyfree.Columns.Add("product");
            dtemptyfree.Columns.Add("amount");
            dr = dtemptyfree.NewRow();
            if (dataOut.Rows.Count > 0)
            {

                for (int j = 0; j <= dataOut.Rows.Count - 1; j++)
                {

                    product = dataOut.Rows[j]["trantype"].ToString();

                    if (product == "FE")
                    {
                        value = "OE";
                    }
                    else if (product == "FI")
                    {
                        value = "OI";
                    }
                    else if (product == "AE")
                    {
                        value = "AE";
                    }
                    else if (product == "AI")
                    {
                        value = "AI";
                    }
                    else if (product == "CH")
                    {
                        value = "CHA";
                    }
                    else if (product == "BT")
                    {
                        value = "BT";
                    }
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows.Add();
                    dtemptyfree.Rows[j]["product"] = value.ToString();
                    // dtemptyfree.Rows[j]["product"] = dataOut.Rows[j]["trantype"].ToString();
                    dtemptyfree.Rows[j]["amount"] = dataOut.Rows[j]["amount"].ToString();

                }

                dtemptyfree.Rows.Add(dr);
                var sum_Income = dataOut.Compute("sum(amount)", "");
                dtemptyfree.Rows[dataOut.Rows.Count]["product"] = "Total";
                dtemptyfree.Rows[dataOut.Rows.Count]["amount"] = sum_Income.ToString();

                DataView dv = dtemptyfree.DefaultView;
                dv.Sort = "";
                DataTable sortedDT = dv.ToTable();
                string[] x = new string[dtemptyfree.Rows.Count];
                Double[] y = new Double[dtemptyfree.Rows.Count];
                for (int i = 0; i < dataOut.Rows.Count; i++)
                {
                    x[i] = dtemptyfree.Rows[i]["product"].ToString();
                    y[i] = Convert.ToDouble(dtemptyfree.Rows[i]["amount"]);
                }

                foreach (Series s in chartper.Series)
                {
                    s.ToolTip = "State: #VALX\nPopulation: #VALY\nPercentage: #PERCENT";
                    s.Label = "#PERCENT\n#VALX";
                }
                chartper.Legends.Clear();
                // chartoperProfit.Visible = false;
                chartper.Visible = true;
                chartper.Series[0].Points.DataBindXY(x, y);
                chartper.Series[0].ChartType = SeriesChartType.Pie;
                chartper.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chartper.Series[0].Label = "#VALX (#PERCENT)";
                chartper.Series[0].LegendText = "#AXISLABEL";
                //piechart.Titles.Clear();
                //piechart.Titles.Add("M+R CHENNAI");
                chartper.Legends.Add(new Legend("Default") { Docking = Docking.Right });
                chartper.Legends[0].Enabled = true;
                chartper.Series[0]["PieLabelStyle"] = "Disabled";
            }
        }

        //public void salesline()
        //{
        //    // DataTable dt_Booking = new DataTable();
        //    // dt_Booking = objbu.SalesCustNameForBooking(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));
        //   // dtTemp = outobj.GetOutStandingProcessUiNew(Convert.ToInt32(Session["LoginEmpId"]), time, Convert.ToInt32(Session["LoginDivisionId"]));
        //  //  ViewState["grdOutStanding"] = dtTemp;
        //    // DataView dv = dtTemp.DefaultView;
        //    DataAccess.ForwardingExports.JobInfo objsales = new DataAccess.ForwardingExports.JobInfo();
        //    //DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
        //    //int month = Todate.Month;
        //    //int year = Todate.Year - 1;
        //    //DateTime fromdat = Convert.ToDateTime(month + "/01/" + year);

        //    dtTemp = objsales.getperfomanceyear(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
        //    DataView dv = dtTemp.DefaultView;
        //    dv.Sort = "";
        //    DataTable sortedDT = dv.ToTable();
        //    string[] x = new string[dtTemp.Rows.Count];
        //    int[] y = new int[dtTemp.Rows.Count];
        //    for (int i = 0; i < dtTemp.Rows.Count; i++)
        //    {
        //        x[i] = dtTemp.Rows[i]["month"].ToString();
        //        y[i] = Convert.ToInt32(dtTemp.Rows[i]["amount"]);
        //    }
        //    foreach (Series s in chartoperProfit.Series)
        //    {
        //        s.ToolTip = "State: #VALX\nPopulation: #VALY\nPercentage: #PERCENT";
        //    }
        //    chartoperProfit.ChartAreas[0].AxisX.Title = "month";
        //    chartoperProfit.ChartAreas[0].AxisY.Title = "amount";

        //    chartoperProfit.Series[0].Points.DataBindXY(x, y);

        //    chartoperProfit.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        //    chartoperProfit.Series[0].LegendText = "Profit";
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = 1;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Interval = 1;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
        //    chartoperProfit.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
        //    // grd_Agent.Visible = false;
        //    chartoperProfit.Visible = true;
        //    piechart.Visible = false;
        //}
        public void bookline()
        {
            string color = "";
          //  DataAccess.ForwardingExports.JobInfo objsales = new DataAccess.ForwardingExports.JobInfo();
            dt = objsales.getbookingbar(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
                       var data = new google.visualization.DataTable();
                    data.addColumn('string', 'month');
                    data.addColumn('number', '');     
                    data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["month"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["BookingCounts"].ToString() + ") ;");
                if (dt.Rows[i]["month"].ToString() == "month")
                {
                    color = "green";
                }
                else
                {
                    color = "maroon";
                }
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_divbar'));");
            str.Append(" chart.draw(data, {width: 680, height: 300, title: 'Bookings',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'},slantedText:true},width:'685',colors: ['orange','" + color + "'],");
            // str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');

        }
        public void salelinechart()
        {
            string color = "";
           // DataAccess.ForwardingExports.JobInfo objsales = new DataAccess.ForwardingExports.JobInfo();
            //Session["fromdate"] = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            //Session["todate"] = Convert.ToDateTime(Utility.fn_ConvertDate(txtTodate.Text));
            // string fromdate = Convert.ToDateTime(Logobj.GetDate().Year-1).ToString();
            // string todate = Convert.ToDateTime(Logobj.GetDate().Year).ToString();
            //DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            //int  month = Todate.Month;
            //int  year = Todate.Year-1;
            // DateTime fromdat = Convert.ToDateTime(month + "/01/" + year);

            dt = objsales.getperfomanceyear(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            // dt= outobj.GetOutStandingProcessUiNew(Convert.ToInt32(Session["LoginEmpId"]), time, Convert.ToInt32(Session["LoginDivisionId"]));
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'month');
            data.addColumn('number', '');
            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["month"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["amount"].ToString() + ") ;");
                if (dt.Rows[i]["month"].ToString() == "month")
                {
                    color = "green";
                }
                else
                {
                    color = "DeepSkyBlue";
                }

            }

            str.Append("   var chart = new google.visualization.LineChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 580, height: 300, title: 'Performance',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'},slantedText:true},width:'645',colors: ['blue','" + color + "'],");
            //  str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().Replace('*', '"');

        }

        [WebMethod]
        public static List<countrydetails> GetChartPerformance1()
        {

            DataTable dtab = new DataTable();
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            DataAccess.Outstanding outobj = new DataAccess.Outstanding();
            List<countrydetails> dataList = new List<countrydetails>();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            DataTable dataOut = new DataTable();

            //double amt = 0;
            if (HttpContext.Current.Session["name"] != null)
            {
                if (HttpContext.Current.Session["name"].ToString() == "lnkPerfo")
                {
                    string product = "";
                    string value = "";
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("Product");
                    dtTemp.Columns.Add("Amount", typeof(Double));
                    DataRow dr;
                    // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                    DateTime Todate = Convert.ToDateTime(Logobj.GetDate().ToString());
                    DataAccess.ForwardingExports.JobInfo objJob = new DataAccess.ForwardingExports.JobInfo();
                    string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                    objJob.GetDataBase(Ccode);
                    objbu.GetDataBase(Ccode);
                    outobj.GetDataBase(Ccode);
                    Logobj.GetDataBase(Ccode);
                    int month = Todate.Month;
                    int year = Todate.Year;
                    DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
                    // dtab = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
                    if (HttpContext.Current.Session["fromdate"] != null && (HttpContext.Current.Session["todate"]) != null)
                    {
                        dataOut = objJob.GetPerformanceRevenusales(Convert.ToDateTime(HttpContext.Current.Session["fromdate"]), Convert.ToDateTime(HttpContext.Current.Session["todate"]), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
                    }
                    else
                    {
                        dataOut = objJob.GetPerformanceRevenusales(fromdate, Todate, Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
                    }

                    DataTable dtemptyfree = new DataTable();

                    dtemptyfree.Columns.Add("product");
                    dtemptyfree.Columns.Add("amount");
                    dr = dtemptyfree.NewRow();
                    if (dataOut.Rows.Count > 0)
                    {

                        for (int j = 0; j <= dataOut.Rows.Count - 1; j++)
                        {

                            product = dataOut.Rows[j]["trantype"].ToString();

                            if (product == "FE")
                            {
                                value = "OE";
                            }
                            else if (product == "FI")
                            {
                                value = "OI";
                            }
                            else if (product == "AE")
                            {
                                value = "AE";
                            }
                            else if (product == "AI")
                            {
                                value = "AI";
                            }
                            else if (product == "CH")
                            {
                                value = "CHA";
                            }
                            else if (product == "BT")
                            {
                                value = "BT";
                            }
                            dr = dtemptyfree.NewRow();
                            dtemptyfree.Rows.Add();
                            dtemptyfree.Rows[j]["product"] = value.ToString();
                            // dtemptyfree.Rows[j]["product"] = dataOut.Rows[j]["trantype"].ToString();
                            dtemptyfree.Rows[j]["amount"] = dataOut.Rows[j]["amount"].ToString();

                        }

                        dtemptyfree.Rows.Add(dr);
                        var sum_Income = dataOut.Compute("sum(amount)", "");
                        dtemptyfree.Rows[dataOut.Rows.Count]["product"] = "Total";
                        dtemptyfree.Rows[dataOut.Rows.Count]["amount"] = sum_Income.ToString();

                        dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                        foreach (DataRow dtrow in dtemptyfree.Rows)
                        {
                            countrydetails details = new countrydetails();
                            details.Countryname = dtrow["product"].ToString();
                            details.Total = Convert.ToDouble(dtrow["amount"]);
                            dataList.Add(details);
                        }

                    }

                }
                else if (HttpContext.Current.Session["name"] == "linkoust")
                {
                    DataRow dr;
                    int time = Logobj.GetDate().Hour;
                    // dtab = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
                    dataOut = outobj.GetOutStandingProcessUiNew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), time, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
                    DataTable dtemptyfree = new DataTable();

                    dtemptyfree.Columns.Add("customer");
                    dtemptyfree.Columns.Add("amount");
                    dtemptyfree.Columns.Add("custid");
                    dr = dtemptyfree.NewRow();
                    if (dataOut.Rows.Count > 0)
                    {
                        for (int j = 0; j <= dataOut.Rows.Count - 1; j++)
                        {
                            dtemptyfree.Rows.Add();
                            dr = dtemptyfree.NewRow();
                            dtemptyfree.Rows[j]["customer"] = dataOut.Rows[j]["customer"].ToString();
                            dtemptyfree.Rows[j]["amount"] = dataOut.Rows[j]["amount"].ToString();
                            dtemptyfree.Rows[j]["custid"] = dataOut.Rows[j]["custid"].ToString();
                        }
                        dtemptyfree.Rows.Add(dr);
                        var sum_Income = dataOut.Compute("sum(amount)", "");
                        dtemptyfree.Rows[dataOut.Rows.Count]["customer"] = "Total";
                        dtemptyfree.Rows[dataOut.Rows.Count]["amount"] = sum_Income.ToString();

                        dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                        foreach (DataRow dtrow in dtemptyfree.Rows)
                        {
                            countrydetails details = new countrydetails();
                            details.Countryname = dtrow["customer"].ToString();
                            details.Total = Convert.ToDouble(dtrow["amount"]);
                            dataList.Add(details);
                        }

                    }

                }
            }

            return dataList;

        }
        [WebMethod]
        public static List<countrydetails> GetChartDataBook()
        {
            DataTable dtab = new DataTable();
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            DataAccess.Outstanding outobj = new DataAccess.Outstanding();
            List<countrydetails> dataList = new List<countrydetails>();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
           
            objbu.GetDataBase(Ccode);
            outobj.GetDataBase(Ccode);
            Logobj.GetDataBase(Ccode);
            int time = Logobj.GetDate().Hour;
            // dtab = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
            // dataOut = outobj.GetOutStandingProcessUiNew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), time, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));

            dtab = objbu.SalesCustNameForBooking(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]));

            DataTable dtemptyfree = new DataTable();

            dtemptyfree.Columns.Add("customer");
            dtemptyfree.Columns.Add("Counts");

            DataRow dr = dtemptyfree.NewRow();
            if (dtab.Rows.Count > 0)
            {
                for (int j = 0; j <= dtab.Rows.Count - 1; j++)
                {
                    dtemptyfree.Rows.Add();
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows[j]["customer"] = dtab.Rows[j]["customername"].ToString();
                    dtemptyfree.Rows[j]["Counts"] = dtab.Rows[j]["Counts"].ToString();

                }
                dtemptyfree.Rows.Add(dr);
                var sum_Income = dtab.Compute("sum(Counts)", "");
                dtemptyfree.Rows[dtab.Rows.Count]["customer"] = "Total";
                dtemptyfree.Rows[dtab.Rows.Count]["Counts"] = sum_Income.ToString();

                dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                foreach (DataRow dtrow in dtemptyfree.Rows)
                {
                    countrydetails details = new countrydetails();
                    details.Countryname = dtrow["customer"].ToString();
                    details.Total = Convert.ToDouble(dtrow["Counts"]);
                    dataList.Add(details);
                }
            }

            return dataList;
        }
        [WebMethod]
        public static List<countrydetails> GetChartDataExemption()
        {
            DataTable dtab = new DataTable();
            DataAccess.BuyingRate objbu = new DataAccess.BuyingRate();
            DataAccess.Outstanding outobj = new DataAccess.Outstanding();
            List<countrydetails> dataList = new List<countrydetails>();
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            
            objbu.GetDataBase(Ccode);
            outobj.GetDataBase(Ccode);
            Logobj.GetDataBase(Ccode);
            int time = Logobj.GetDate().Hour;
            // dtab = objbu.selpendingBookcutomerwisecount(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["StrTranType"].ToString());
            // dataOut = outobj.GetOutStandingProcessUiNew(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), time, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));

            // dtab = objbu.SalesCustNameForBooking(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]));

            dtab = outobj.getgrpcreditexception(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]));
            DataTable dtemptyfree = new DataTable();

            dtemptyfree.Columns.Add("customer");
            dtemptyfree.Columns.Add("exception");

            DataRow dr = dtemptyfree.NewRow();
            if (dtab.Rows.Count > 0)
            {
                for (int j = 0; j <= dtab.Rows.Count - 1; j++)
                {
                    dtemptyfree.Rows.Add();
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows[j]["customer"] = dtab.Rows[j]["customer"].ToString();
                    dtemptyfree.Rows[j]["exception"] = dtab.Rows[j]["exception"].ToString();

                }
                dtemptyfree.Rows.Add(dr);
                var sum_Income = dtab.Compute("sum(exception)", "");
                dtemptyfree.Rows[dtab.Rows.Count]["customer"] = "Total";
                dtemptyfree.Rows[dtab.Rows.Count]["exception"] = sum_Income.ToString();

                dtemptyfree.Rows.RemoveAt(dtemptyfree.Rows.Count - 1);

                foreach (DataRow dtrow in dtemptyfree.Rows)
                {
                    countrydetails details = new countrydetails();
                    details.Countryname = dtrow["customer"].ToString();
                    details.Total = Convert.ToDouble(dtrow["exception"]);
                    dataList.Add(details);
                }
            }

            return dataList;
        }

        public void Getcreditrequest()
        {
            int count = mca.get_creditapproval_homecount(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]));
            span_creditreq.InnerText = count.ToString();

        }
        public void workcount()
        {
           // DataAccess.BuyingRate byobj = new DataAccess.BuyingRate();
            dt = byobj.Getworkinprogesscount(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]));
            int coun = Convert.ToInt32(dt.Rows[0][0]);
            span_wokingprogess.InnerText = coun.ToString();
        }
        public void Un_App()
        {
            dt = objJob.GetSalesBookingCount_Karthika(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));
            if (dt.Rows.Count > 0)
            {
                span_quotunapp.InnerText = dt.Rows[0][1].ToString();
            }
            else
            {
                span_quotunapp.InnerText = "0";
            }
        }
        public void App()
        {
            dt = objJob.GetSalesBookingCount_Karthika(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));
            if (dt.Rows.Count > 0)
            {
                span_quotapp.InnerText = dt.Rows[0][0].ToString();
            }
            else
            {
                span_quotapp.InnerText = "0";
            }
        }

        public void Booking_CountNew()
        {
            DataTable dt1 = new DataTable();
            dt = objJob.GetSalesBookingCountHome(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));
            if (dt.Rows.Count > 0)
            {
                span_book.InnerText = dt.Rows[0]["COUNTS"].ToString();
            }
            else
            {
                span_book.InnerText = "0";
            }

            dt1 = objJob.GetSalesBookingCountHomenewly(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));
            if (dt1.Rows.Count > 0)
            {
                span_ebook.InnerText = dt1.Rows[0]["COUNTS"].ToString();

            }
            else
            {
                span_ebook.InnerText = "0";

            }

        }

        public void Dis_Grid()
        {
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            Panel1.Visible = false;
            Panel7.Visible = false;
            Div4.Visible = false;
            divQuot.Visible = false;
            grdQuatotion.Visible = false;
            Panel2.Visible = false;
            grdOutStanding.Visible = false;
            cutnew.Visible = false;
            Panel2.Visible = false;
            grdOutStanding.Visible = false;
            btnoutExcel.Visible = false;
            div_out.Visible = false;
            grdQuatotion.Visible = false;
            //panelservice.Visible = false;
            Div3.Visible = false;
            GrdSalesPerformance.Visible = false;
            PanelPendingEvent.Visible = false;
            divPerson.Visible = false;
            quot.Visible = false;
            div_quotdetails.Visible = false;
            Panel6.Visible = false;
            // CRequests.Attributes["Class"] = "Hide";
            panel8.Visible = false;
            WIP.Visible = false;
            workingprogess.Visible = false;

            grdebooking.Visible = false;
        }
        public void CountCredi_excp()
        {
            Dis_Grid();
            dt = oustobj.getcountcreditexamp(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]));
            if (dt.Rows.Count > 0)
            {
                spCredEx.InnerText = dt.Rows[0][0].ToString();
            }
            else
            {
                spCredEx.InnerText = "0";
            }
        }

        public void CountFor_Collectionadvise()
        {
            Dis_Grid();
            time = logobj.GetDate().Hour;
            dataOut = outobj.GetOutStandingProcessUiHomepage(Convert.ToInt32(Session["LoginEmpId"]), time, Convert.ToInt32(Session["LoginDivisionId"]));
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("overdueamt");
            double amtcollection = 0;
            double collection = 0;
            if (dataOut.Rows.Count > 0)
            {
                for (int i = 0; i <= dataOut.Rows.Count - 1; i++)
                {
                    amtcollection = Convert.ToDouble(dataOut.Rows[i]["overdueamount"].ToString());
                    collection = collection + amtcollection;
                }
                spn_collectionadvise.InnerText = collection.ToString("#,0");

            }
            else
            {
                spn_collectionadvise.InnerText = "0";
            }
        }

        public void Get_ExCredEx()
        {
            Div2.Visible = true;
            Div3.Visible = true;
            int val = 0;
            dt = oustobj.getgrpcreditexception(Convert.ToInt32(Session["LoginEmpId"]));
            int count = dt.Rows.Count;

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["exception"].ToString() == "")
                {
                    val = 0;
                }
                else
                {
                    val = Convert.ToInt32(dt.Compute("sum(exception)", ""));
                }
            }
            dt.Rows.Add();
            dt.Rows[count][1] = "Total";
            dt.Rows[count][2] = val;
            divgrid.DataSource = dt;
            divgrid.DataBind();
            if (divgrid.Rows.Count > 0)
            {
                divgrid.Rows[divgrid.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                divgrid.Rows[divgrid.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Maroon;

            }
            // btn_exempt.Enabled = false;
            Session["data"] = dt;
            ViewState["divgridexp2ex"] = dt;
            divgrid.Visible = true;
            //divgrid.Columns[3].Visible = false;
        }

        [WebMethod]
        public static List<string> GetPOD(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
             string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
          
            dt = obj_MasterPort.GetPortNameDetails(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;
        }

        [WebMethod]
        public static List<string> GetPOL(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_MasterPort.GetDataBase(Ccode);
            dt = obj_MasterPort.GetPortNameDetails(prefix);
            list_result = Utility.Fn_TableToList(dt, "portname", "portid");
            return list_result;
        }

        public void bookingdata()
        {
            PanelPendingEvent.Visible = false;
            GrdSalesPerformance.Visible = false;
            divQuot.Visible = false;
            divPerson.Visible = false;

            GetNewTran();
        }

        public void getdata()
        {
            cutnew.Visible = true;

            pnlGrdCuswise.Visible = false;
            GrdCuswise.Visible = false;

            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;
            div1.Visible = false;
            PanelPendingEvent.Visible = false;
            GrdSalesPerformance.Visible = false;
            divPerson.Visible = false;
            divQuot.Visible = true;
            Panel3.Visible = true;
            grdQuatotion.Visible = true;
            grdebooking.Visible = true;

            Get_quotation();
        }

        //public void OutStanding_Count()
        //{
        //    double TotaCount;
        //    string currency = "";
        //    time = logobj.GetDate().Hour;
        //    dataOut = outobj.GetOutStandingCountProcessUi(Convert.ToInt32(Session["LoginEmpId"]), time, Convert.ToInt32(Session["LoginDivisionId"]));

        //    if (dataOut.Rows.Count > 0)
        //    {
        //        currency = dataOut.Rows[0][0].ToString();
        //        TotaCount = Convert.ToDouble(dataOut.Rows[0][1].ToString());
        //        TotaCount = Math.Round(TotaCount);
        //    }
        //    else
        //    {
        //        TotaCount = 0.0;
        //    }
        //    // lbl_outstanding.InnerText = TotaCount.ToString("#,0.00");
        //    lbl_outstanding.InnerText = TotaCount.ToString("#,0");
        //}

        public void outstandingdata()
        {
            cutnew.Visible = true;
            pnlGrdCuswise.Visible = true;
            GrdCuswise.Visible = true;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;
            PanelPendingEvent.Visible = false;
            GrdSalesPerformance.Visible = false;
            divPerson.Visible = false;
            get_out();
        }

        public void performancedata()
        {
            //Div3.Visible = false;
            //cutnew.Visible = false;
            //pnlGrdCuswise.Visible = true;
            //GrdCuswise.Visible = true;
            //classDiv.Visible = false;
            //Panel1.Visible = false;
            //GridView1.Visible = false;
            //div1.Visible = false;
            //Panel4.Visible = false;
            //GrdBooking.Visible = false;
            //divPerson.Visible = true;
            //PanelPendingEvent.Visible = true;
            //GrdSalesPerformance.Visible = true;
            Dis_Grid();
            Revenue_Funtion();
        }

        public void exratedata()
        {
            cutnew.Visible = true;
            pnlGrdCuswise.Visible = false;
            GrdCuswise.Visible = true;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;

            loadgrd();
        }

        //public void Get_PersonDetails()
        //{
        //    int month, year;
        //    string count = "";
        //    double cuur;
        //    DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
        //    month = Todate.Month;
        //    year = Todate.Year;
        //    DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
        //    dtNew = objJob.GetRevenuePersonCurr(fromdate, Todate, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

        //    if (dtNew.Rows.Count > 0)
        //    {
        //        count = dtNew.Rows[0][1].ToString();
        //        cuur = Convert.ToDouble(dtNew.Rows[0][0].ToString());
        //    }
        //    else
        //    {
        //        count = "0";
        //        cuur = 0;
        //    }
        //}     
        public void Get_PersonDetails()
        {
            //int count = 0;
            int month, year;
            string count = "";
            double cuur;
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            month = Todate.Month;
            year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            // txtTodate.Text = Utility.fn_ConvertDate(logobj.GetDate().ToString());
            dtNew = objJob.GetRevenuePersonCurr(fromdate, Todate, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            if (dtNew.Rows.Count > 0)
            {
                count = dtNew.Rows[0][1].ToString();
                cuur = Convert.ToDouble(dtNew.Rows[0][0].ToString());
                cuur = Math.Round(cuur);
            }
            else
            {
                count = "0";
                cuur = 0;
            }
            string ch = ".";
            if (count == "0" && cuur == 0)
            {
                spPerformance.InnerText = "0";
            }
            else
            {
                //  spPerformance.InnerText = "" + count + "" + ch + "" + cuur.ToString("#0.00") + "";
                //spPerformance.InnerText =  cuur.ToString("#,0.00") + "";

                spPerformance.InnerText = cuur.ToString("#,0") + "";
            }
            cutnew.Visible = false;
        }

        public void Quot_Count()
        {
            int Count = 0;
            dataQuat = objQuat.GetquationCount(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dataQuat.Rows.Count > 0)
            {
                Count = Convert.ToInt32(dataQuat.Rows[0][0].ToString());
            }
            else
            {
                Count = 0;
            }
        }

        public void OutStanding_Count()
        {
            double TotaCount;
            string currency = "";
            time = logobj.GetDate().Hour;
            dataOut = outobj.GetOutStandingCountProcessUi(Convert.ToInt32(Session["LoginEmpId"]), time, Convert.ToInt32(Session["LoginDivisionId"]));

            if (dataOut.Rows.Count > 0)
            {
                currency = dataOut.Rows[0][0].ToString();
                TotaCount = Convert.ToDouble(dataOut.Rows[0][1].ToString());
                TotaCount = Math.Round(TotaCount);
            }
            else
            {
                TotaCount = 0.0;
            }
            // lbl_outstanding.InnerText = TotaCount.ToString("#,0.00");
            lbl_outstanding.InnerText = TotaCount.ToString("#,0");
        }

        public void Work_Process()
        {
            int count = 0;
            DataTable dt = new DataTable();
            dt = outobj.GetWorkProces(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]));
            if (dt.Rows.Count > 0)
            {
                count = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            else
            {
                count = 0;
            }
        }

        //protected void lnk_booking_Click(object sender, EventArgs e)
        //{
        //    GetNewTran();
        //}

        public void Over_All_Booking()
        {

            string Type = "";
            int Count1 = 0, count2 = 0, count3 = 0, count4 = 0;
            int Total = 0;
            DataTable dt1 = new DataTable();
            dt1 = objJob.GetTrantypeForNewsales(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));

            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                {
                    Type = dt1.Rows[i][0].ToString();

                    if (Type == "FE")
                    {
                        Count1 = Convert.ToInt32(dt1.Rows[i][1].ToString());
                    }
                    else if (Type == "FI")
                    {
                        count2 = Convert.ToInt32(dt1.Rows[i][1].ToString());
                    }
                    else if (Type == "AE")
                    {
                        count3 = Convert.ToInt32(dt1.Rows[i][1].ToString());
                    }
                    else if (Type == "AI")
                    {
                        count4 = Convert.ToInt32(dt1.Rows[i][1].ToString());
                    }
                }
            }

            Total = Count1 + count2 + count3 + count4;
        }

        public class countrydetails
        {
            public string Countryname { get; set; }
            public Double Total { get; set; }
        }

        public void GetNewTran()
        {
            divBooknew.Visible = true;
            pnlTran.Visible = true;
            grdTranNew.Visible = true;

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("trantype");
            dtTemp.Columns.Add("Counts");
            DataTable dt1 = new DataTable();
            dt1 = objJob.GetTrantypeForNewsales(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));

            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                {
                    tran = dt1.Rows[i][0].ToString();
                    dtTemp.Rows.Add();
                    if (tran == "FE")
                    {
                        dtTemp.Rows[i][0] = "Ocean Exports";
                        dtTemp.Rows[i][1] = dt1.Rows[i][1].ToString();
                        hidfe.Text = dt1.Rows[i][1].ToString();
                    }
                    else if (tran == "FI")
                    {
                        dtTemp.Rows[i][0] = "Ocean Imports";
                        dtTemp.Rows[i][1] = dt1.Rows[i][1].ToString();
                        hidfi.Text = dt1.Rows[i][1].ToString();
                    }
                    else if (tran == "AE")
                    {
                        dtTemp.Rows[i][0] = "Air Exports";
                        dtTemp.Rows[i][1] = dt1.Rows[i][1].ToString();
                        hidae.Text = dt1.Rows[i][1].ToString();
                    }
                    else if (tran == "AI")
                    {
                        dtTemp.Rows[i][0] = "Air Imports";
                        dtTemp.Rows[i][1] = dt1.Rows[i][1].ToString();
                        hidai.Text = dt1.Rows[i][1].ToString();
                    }
                }
            }

            if (dtTemp.Rows.Count < 4 && dtTemp.Rows.Count != 0)
            {
                blerrOE = false; blerrOI = false; blerrAE = false; blerrAI = false; blerrBT = false; blerrCH = false;

                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    tran = dtTemp.Rows[j][0].ToString();
                    if (tran != "Ocean Exports")
                    {
                        blerrOE = false;
                        break;
                    }
                    else
                    {
                        blerrOE = true;
                    }
                }

                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    tran = dtTemp.Rows[j][0].ToString();
                    if (tran != "Ocean Imports")
                    {
                        blerrOI = false;
                        break;
                    }
                    else
                    {
                        blerrOI = true;
                    }
                }

                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    tran = dtTemp.Rows[j][0].ToString();
                    if (tran != "Air Exports")
                    {
                        blerrAE = false;
                        break;
                    }
                    else
                    {
                        blerrAE = true;
                    }
                }

                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    tran = dtTemp.Rows[j][0].ToString();
                    if (tran != "Air Imports")
                    {
                        blerrAI = false;
                        break;
                    }
                    else
                    {
                        blerrAI = true;
                    }
                }

                if (blerrOE == false)
                {
                    dtTemp.Rows.Add();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Ocean Exports";
                    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0";
                    hidfe.Text = dtTemp.Rows[dtTemp.Rows.Count - 1][1].ToString();
                }
                if (blerrOI == false)
                {
                    dtTemp.Rows.Add();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Ocean Imports";
                    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0";
                    hidfi.Text = dtTemp.Rows[dtTemp.Rows.Count - 1][1].ToString();
                }
                if (blerrAE == false)
                {
                    dtTemp.Rows.Add();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Air Exports";
                    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0";
                    hidae.Text = dtTemp.Rows[dtTemp.Rows.Count - 1][1].ToString();
                }
                if (blerrAI == false)
                {
                    dtTemp.Rows.Add();
                    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Air Imports";
                    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0";
                    hidai.Text = dtTemp.Rows[dtTemp.Rows.Count - 1][1].ToString();
                }
            }
            else if (dtTemp.Rows.Count == 0)
            {
                dtTemp.Rows.Add();
                dtTemp.Rows[0][0] = "Ocean Exports";
                dtTemp.Rows[0][1] = "0";
                dtTemp.Rows.Add();
                dtTemp.Rows[1][0] = "Ocean Imports";
                dtTemp.Rows[1][1] = "0";
                dtTemp.Rows.Add();
                dtTemp.Rows[2][0] = "Air Exports";
                dtTemp.Rows[2][1] = "0";
                dtTemp.Rows.Add();
                dtTemp.Rows[3][0] = "Air Imports";
                dtTemp.Rows[3][1] = "0";
            }

            grdTranNew.DataSource = dtTemp;
            grdTranNew.DataBind();

        }

        /*public void loadcustwise()
        {
            pnlGrdCuswise.Visible = true;
            GrdCuswise.Visible = true;

            dt = objbu.SpSalesCustName(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), Session["StrTranType"].ToString());
            DataTable dtemptyfree = new DataTable();

            dtemptyfree.Columns.Add("customername");
            dtemptyfree.Columns.Add("Counts");
            dtemptyfree.Columns.Add("cusid");
            DataRow dr = dtemptyfree.NewRow();
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j <= dt.Rows.Count - 1; j++)
                {

                    dtemptyfree.Rows.Add();
                    dr = dtemptyfree.NewRow();
                    dtemptyfree.Rows[j]["customername"] = dt.Rows[j]["customername"].ToString();
                    dtemptyfree.Rows[j]["Counts"] = dt.Rows[j]["Counts"].ToString();
                    dtemptyfree.Rows[j]["cusid"] = dt.Rows[j]["cusid"].ToString();
                }
                dtemptyfree.Rows.Add(dr);
                var sum_Income = dt.Compute("sum(counts)", "");
                dtemptyfree.Rows[dt.Rows.Count]["customername"] = "Total";
                dtemptyfree.Rows[dt.Rows.Count]["Counts"] = sum_Income.ToString();
                GrdCuswise.DataSource = dtemptyfree;
                GrdCuswise.DataBind();
            }
            else
            {
                GrdCuswise.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdCuswise.DataBind();
            }
        }
        */

        public void loadgrd()
        {
           // DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string dtexdate = obj_da_Logobj.GetDate().ToString();
            //dt = exrobj.GetExRateDetails(dtexdate);
            dt = exrobj.GetExRateDetails(Convert.ToDateTime(dtexdate));
            if (dt.Rows.Count > 0)
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
            else
            {
                Gridexrate.DataSource = dt;
                Gridexrate.DataBind();
            }
        }

        public void Revnue_Bind()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("Product");
            dtTemp.Columns.Add("Amount", typeof(Double));

            int i = 6;

            for (i = 0; i <= 5; i++)
            {

                dtTemp.Rows.Add();
                if (i == 0)
                {
                    dtTemp.Rows[0][0] = "Ocean Exports";
                    dtTemp.Rows[0][1] = "0.00";
                }
                if (i == 1)
                {

                    dtTemp.Rows[1][0] = "Ocean Imports";
                    dtTemp.Rows[1][1] = "0.00";
                }
                if (i == 2)
                {
                    dtTemp.Rows[2][0] = "Air Exports";
                    dtTemp.Rows[2][1] = "0.00";
                }
                if (i == 3)
                {
                    dtTemp.Rows[3][0] = "Air Imports";
                    dtTemp.Rows[3][1] = "0.00";
                }

                //if (i == 4)
                //{
                //    dtTemp.Rows[4][0] = "CHA";
                //    dtTemp.Rows[4][1] = "0.00";
                //}
                //if (i == 5)
                //{
                //    dtTemp.Rows[5][0] = "Bonded Trucking";
                //    dtTemp.Rows[5][1] = "0.00";
                //}
            }

            dtTemp.Rows.Add();
            var sum_Income = dtTemp.Compute("sum(amount)", "");
            dtTemp.Rows[6]["Product"] = "Total";
            dtTemp.Rows[6]["Amount"] = sum_Income.ToString();

            GrdSalesPerformance.DataSource = dtTemp;
            GrdSalesPerformance.DataBind();

            if (GrdSalesPerformance.Rows.Count > 0)
            {
                GrdSalesPerformance.Rows[GrdSalesPerformance.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                GrdSalesPerformance.Rows[GrdSalesPerformance.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Maroon;
            }
            ViewState["GrdSalesPerformanceexp2exc"] = dtTemp;
        }

        public void Revenue_Funtion()
        {
            cutnew.Visible = false;
            double amt = 0;
            string product = "";
            string value = "";
            // DataTable dtTemp = new DataTable();
            //dtTemp.Columns.Add("Product");
            //dtTemp.Columns.Add("Amount", typeof(Double));
            //DataRow dr;
            DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
            Session["todate"] = Todate;
            int month = Todate.Month;
            int year = Todate.Year;
            DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            Session["fromdate"] = fromdate;
            dtNew = objJob.GetPerformanceRevenusales(fromdate, Todate, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            bindrevenue();

        }

        //protected void Bin_function()
        //{
        //    dt = objJob.GetQuationIdForNew(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]));

        //    if (dt.Rows.Count > 0)
        //    {
        //        GrdBooking.DataSource = dt;
        //        ViewState["value"] = dt;
        //        GrdBooking.DataBind();
        //    }
        //    else
        //    {
        //        GrdBooking.DataSource = Utility.Fn_GetEmptyDataTable();
        //        GrdBooking.DataBind();
        //    }
        //}

        //protected void GrdBooking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    e.NewPageIndex = GrdBooking.PageIndex;
        //    GrdBooking.DataSource = ViewState["value"];
        //    GrdBooking.DataBind();
        //}

        protected void btnGet_Click(object sender, EventArgs e)
        {
            Revnu_FunPerson();
            //div5.Visible = false;
            // div6.Visible = true;

        }

        public void Revnu_FunPerson()
        {
            //DateTime Todate = Convert.ToDateTime(Utility.fn_ConvertDate(logobj.GetDate().ToString()));
            //int month = Todate.Month;
            //int year = Todate.Year;
            //DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
            //DataTable dtTemp = new DataTable();
            //dtTemp.Columns.Add("Product");
            //dtTemp.Columns.Add("Amount", typeof(Double));

            Session["fromdate"] = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text));
            Session["todate"] = Convert.ToDateTime(Utility.fn_ConvertDate(txtTodate.Text));
            dtNew = objJob.GetPerformanceRevenusales(Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txtTodate.Text)), Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            bindrevenue();

        }

        public void bindrevenue()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("Product");
            dtTemp.Columns.Add("Amount");
            DataRow dr;
            if (dtNew.Rows.Count > 0)
            {

                for (int i = 0; i <= dtNew.Rows.Count - 1; i++)
                {
                    dr = dtTemp.NewRow();
                    dtTemp.Rows.Add();

                    product = dtNew.Rows[i]["trantype"].ToString();
                    if (product == "FE")
                    {
                        value = "OE";
                    }
                    else if (product == "FI")
                    {
                        value = "OI";
                    }
                    else if (product == "AE")
                    {
                        value = "AE";
                    }
                    else if (product == "AI")
                    {
                        value = "AI";
                    }
                    else if (product == "CH")
                    {
                        value = "CHA";
                    }
                    else if (product == "BT")
                    {
                        value = "BT";
                    }

                    dtTemp.Rows[i][0] = value.ToString();
                    // amt = Convert.ToDouble(dtNew.Rows[i]["amount"].ToString());
                    dtTemp.Rows[i][1] = Convert.ToDouble(dtNew.Rows[i]["amount"].ToString()).ToString("#,0.00");  // amt.ToString("#,0.00"); //string.Format("{0:#,##0.00}", amt);
                }

                if (dtTemp.Rows.Count < 6 && dtTemp.Rows.Count != 0)
                {
                    blerrOE = false; blerrOI = false; blerrAE = false; blerrAI = false; blerrBT = false; blerrCH = false;

                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        tran = dtTemp.Rows[j][0].ToString();
                        if (tran == "OE")
                        {
                            blerrOE = false;
                            break;
                        }
                        else
                        {
                            blerrOE = true;
                        }
                    }

                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        tran = dtTemp.Rows[j][0].ToString();
                        if (tran == "OI")
                        {
                            blerrOI = false;
                            break;
                        }
                        else
                        {
                            blerrOI = true;
                        }
                    }

                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        tran = dtTemp.Rows[j][0].ToString();
                        if (tran == "AE")
                        {
                            blerrAE = false;
                            break;
                        }
                        else
                        {
                            blerrAE = true;
                        }
                    }

                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        tran = dtTemp.Rows[j][0].ToString();
                        if (tran == "AI")
                        {
                            blerrAI = false;
                            break;
                        }
                        else
                        {
                            blerrAI = true;
                        }
                    }

                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        tran = dtTemp.Rows[j][0].ToString();
                        if (tran == "BT")
                        {
                            blerrBT = false;
                            break;
                        }
                        else
                        {
                            blerrBT = true;
                        }
                    }

                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        tran = dtTemp.Rows[j][0].ToString();
                        if (tran == "CHA")
                        {
                            blerrCH = false;
                            break;
                        }
                        else
                        {
                            blerrCH = true;
                        }
                    }

                    if (blerrOE == true)
                    {
                        dtTemp.Rows.Add();
                        dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Ocean Exports";
                        dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0.00";
                    }

                    if (blerrOI == true)
                    {
                        dtTemp.Rows.Add();
                        dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Ocean Imports";
                        dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0.00";
                    }

                    if (blerrAE == true)
                    {
                        dtTemp.Rows.Add();
                        dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Air Exports";
                        dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0.00";
                    }

                    if (blerrAI == true)
                    {
                        dtTemp.Rows.Add();

                        dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "Air Imports";
                        dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0.00";

                    }

                    //if (blerrBT == true)
                    //{
                    //    dtTemp.Rows.Add();

                    //    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "BT";
                    //    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0.00";

                    //}

                    //if (blerrCH == true)
                    //{
                    //    dtTemp.Rows.Add();

                    //    dtTemp.Rows[dtTemp.Rows.Count - 1][0] = "CHA";
                    //    dtTemp.Rows[dtTemp.Rows.Count - 1][1] = "0.00";

                    //}

                }
                Double sum_Income = 0;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    sum_Income += Convert.ToDouble(dtTemp.Rows[i]["Amount"]);
                }
                dtTemp.Rows.Add();

                dtTemp.Rows[dtTemp.Rows.Count - 1]["Product"] = "Total";
                dtTemp.Rows[dtTemp.Rows.Count - 1]["Amount"] = sum_Income.ToString("#,0.00") + "";
                Double cuur = Convert.ToDouble(sum_Income);
                spPerformance.InnerText = cuur.ToString("#,0.00") + "";
                GrdSalesPerformance.DataSource = dtTemp;
                GrdSalesPerformance.DataBind();
                Session["GrdSalesPerformance"] = dtTemp;
                if (GrdSalesPerformance.Rows.Count > 0)
                {
                    GrdSalesPerformance.Rows[GrdSalesPerformance.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.DarkRed;
                    GrdSalesPerformance.Rows[GrdSalesPerformance.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.DarkRed;

                }
                perchart();
                GridView3.Visible = false;
                lbl_Perfor_det.Text = "";
                excl_export.Visible = false;

            }
            else
            {
                //dtTemp.Columns.Add("Product");
                //  dtTemp.Columns.Add("Amount", typeof(Double));

                dtTemp.Rows.Add();
                dtTemp.Rows[0][0] = "Ocean Exports";
                dtTemp.Rows[0][1] = "0.00";

                dtTemp.Rows.Add();
                dtTemp.Rows[1][0] = "Ocean Imports";
                dtTemp.Rows[1][1] = "0.00";

                dtTemp.Rows.Add();
                dtTemp.Rows[2][0] = "Air Exports";
                dtTemp.Rows[2][1] = "0.00";

                dtTemp.Rows.Add();
                dtTemp.Rows[3][0] = "Air Imports";
                dtTemp.Rows[3][1] = "0.00";


                //dtTemp.Rows.Add();
                //dtTemp.Rows[4][0] = "BT";
                //dtTemp.Rows[4][1] = "0.00";

                //dtTemp.Rows.Add();
                //dtTemp.Rows[5][0] = "CHA";
                //dtTemp.Rows[5][1] = "0.00";

                dtTemp.Rows.Add();
                Double sum_Income = 0.00;
                if (dtTemp.Rows.Count > 0)
                {
                    if (dtTemp.Rows[0]["Amount"] == "0.00")
                    {
                        sum_Income = 0.00;
                    }
                    else
                    {
                        sum_Income = Convert.ToDouble(dtTemp.Compute("sum(Amount)", ""));
                    }
                    dtTemp.Rows[dtTemp.Rows.Count - 1]["Product"] = "Total";
                    dtTemp.Rows[dtTemp.Rows.Count - 1]["Amount"] = sum_Income.ToString();
                }

                Double cuur = Convert.ToDouble(sum_Income);
                spPerformance.InnerText = cuur.ToString("#,0.00") + "";
                GrdSalesPerformance.DataSource = dtTemp;
                GrdSalesPerformance.DataBind();
                if (GrdSalesPerformance.Rows.Count > 0)
                {
                    GrdSalesPerformance.Rows[GrdSalesPerformance.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.DarkRed;
                    GrdSalesPerformance.Rows[GrdSalesPerformance.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.DarkRed;

                }
            }
            Session["GrdSalesPerformance"] = dtTemp;
            ViewState["GrdSalesPerformanceexp2exc"] = dtTemp;
            perchart();
            GrdSalesPerformance.Visible = true;
            PanelPendingEvent.Visible = true;
            divPerson.Visible = true;
        }

        public void get_out()
        {
            double amtToal1 = 0;
            double firstamt = 0;
            double secondamt = 0;
            double amto = 0;
            double amtover = 0;
            double amtToal = 0;
            Panel2.Visible = true;
            time = logobj.GetDate().Hour;
            dataOut = outobj.GetOutStandingProcessUiHomepage(Convert.ToInt32(Session["LoginEmpId"]), time, Convert.ToInt32(Session["LoginDivisionId"]));
            DataTable dtTemp = new DataTable();
            grdOutStanding.Visible = true;
            int amt;
            string name;
            dtTemp.Columns.Add("SI");
            dtTemp.Columns.Add("customer");
            dtTemp.Columns.Add("custid");
            dtTemp.Columns.Add("amount");
            dtTemp.Columns.Add("overdueamt");
            dtTemp.Columns.Add("totalamt");
            //dtTemp.Columns.Add("approvedon");
            if (dataOut.Rows.Count > 0)
            {

                for (int i = 0; i <= dataOut.Rows.Count - 1; i++)
                {
                    dtTemp.Rows.Add();
                    dtTemp.Rows[i][0] = i + 1;
                    dtTemp.Rows[i][2] = dataOut.Rows[i]["customerid"].ToString();
                    // amt = Convert.ToInt32(dataOut.Rows[i]["custid"].ToString());
                    //dtTemp.Rows[i][1] = dtTemp.Rows[i]["customer"].ToString();
                    // name = dataOut.Rows[i]["customer"].ToString();

                    dtTemp.Rows[i][1] = dataOut.Rows[i]["customer"].ToString();
                    double amtchk = Convert.ToDouble(dataOut.Rows[i]["overdueamount"].ToString());
                    dtTemp.Rows[i][4] = amtchk.ToString("#0.00");

                    double amtchk1 = Convert.ToDouble(dataOut.Rows[i]["amount"].ToString());
                    dtTemp.Rows[i][3] = amtchk1.ToString("#0.00");

                    if (dtTemp.Rows[i][3].ToString() == "")
                    {
                        dtTemp.Rows[i][3] = "0.00";
                    }
                    if (dtTemp.Rows[i][4].ToString() == "")
                    {
                        dtTemp.Rows[i][4] = "0.00";
                    }

                    firstamt = Convert.ToDouble(dtTemp.Rows[i][3].ToString());
                    secondamt = Convert.ToDouble(dtTemp.Rows[i][4].ToString());
                    dtTemp.Rows[i][5] = (firstamt + secondamt).ToString("#0.00");
                    amto = amto + firstamt;
                    amtover = amtover + secondamt;
                    amtToal1 = firstamt + secondamt;
                    amtToal = amtToal + amtToal1;
                }

                //Double data = 0;
                //data = Convert.ToDouble(dataOut.Compute("sum(amount)", ""));

                int count = 0;

                count = dtTemp.Rows.Count;
                dtTemp.Rows.Add();
                dtTemp.Rows[count]["customer"] = "Total";
                dtTemp.Rows[count]["amount"] = amto.ToString("#,0.00") + "";
                dtTemp.Rows[count]["overdueamt"] = amtover.ToString("#,0.00") + "";
                dtTemp.Rows[count]["totalamt"] = amtToal.ToString("#,0.00") + "";
                grdOutStanding.DataSource = dtTemp;
                grdOutStanding.DataBind();
                if (grdOutStanding.Rows.Count > 0)
                {
                    grdOutStanding.Rows[grdOutStanding.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                    grdOutStanding.Rows[grdOutStanding.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Maroon;
                    grdOutStanding.Rows[grdOutStanding.Rows.Count - 1].Cells[4].ForeColor = System.Drawing.Color.Maroon;
                    grdOutStanding.Rows[grdOutStanding.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Maroon;

                }
                ViewState["grdOutStanding"] = dtTemp;
                ViewState["grdOutStandingexp2ex"] = dtTemp;
                grdOutStanding.Visible = true;
                Panel2.Visible = true;
                div_out.Visible = true;

            }
            else
            {
                grdOutStanding.DataSource = dataOut;
                grdOutStanding.DataBind();
            }
        }

        protected void btnGetNew_Click(object sender, EventArgs e)
        {

            get_out();

        }
        public void Get_quotation1()
        {

            dataQuat = objQuat.GetQuation4salesnew1(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));

            if (dataQuat.Rows.Count > 0)
            {
                grdQuatotion.DataSource = dataQuat;
                grdQuatotion.DataBind();
                ViewState["Quotation"] = dataQuat;
                div_quotdetails.Visible = true;
                grdQuatotion.Visible = true;
                divQuot.Visible = true;
                //for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                //{
                //    if (string.IsNullOrEmpty(dataQuat.Rows[i]["approvedon"].ToString()))
                //    {
                //        System.Web.UI.WebControls.Image ImageUnApp = grdQuatotion.Rows[i].FindControl("UnAppImage") as System.Web.UI.WebControls.Image;
                //        ImageUnApp.Visible = true;
                //    }
                //    else
                //    {
                //        System.Web.UI.WebControls.Image ImageApp = grdQuatotion.Rows[i].FindControl("AppImage") as System.Web.UI.WebControls.Image;
                //        ImageApp.Visible = true;
                //    }                    
                //}
            }
        }

        public void Get_quotation()
        {
            DataSet dsgsk;
            DataTable dtgsk1;
            
            dsgsk = objQuat.GetQuation4salesappunapp(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dsgsk.Tables.Count > 0)
            {
                dtgsk1 = dsgsk.Tables[1];

                if (dtgsk1.Rows.Count > 0)
                {
                    grdQuatotion.DataSource = dtgsk1;
                    grdQuatotion.DataBind();
                    if (grdQuatotion.Rows.Count > 0)
                    {
                        for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                        {
                            if (grdQuatotion.Rows[i].Cells[8].Text == "UnApproved")
                            {
                                grdQuatotion.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                            }
                        }

                    }
                    ViewState["Quotation"] = dtgsk1;
                    div_quotdetails.Visible = true;
                    grdQuatotion.Visible = true;
                    divQuot.Visible = true;
                    //for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                    //{
                    //    if (string.IsNullOrEmpty(dataQuat.Rows[i]["approvedon"].ToString()))
                    //    {
                    //        System.Web.UI.WebControls.Image ImageUnApp = grdQuatotion.Rows[i].FindControl("UnAppImage") as System.Web.UI.WebControls.Image;
                    //        ImageUnApp.Visible = true;
                    //    }
                    //    else
                    //    {
                    //        System.Web.UI.WebControls.Image ImageApp = grdQuatotion.Rows[i].FindControl("AppImage") as System.Web.UI.WebControls.Image;
                    //        ImageApp.Visible = true;
                    //    }                    
                    //}
                }
                else
                {
                    grdQuatotion.DataSource = new DataTable();
                    grdQuatotion.DataBind();
                }
            }
        }

        protected void btnGetQuot_Click(object sender, EventArgs e)
        {
            Get_quotation();
        }

        protected void btnExcelPending_Click(object sender, EventArgs e)
        {
            if (GrdSalesPerformance.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Pending.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                GrdSalesPerformance.GridLines = GridLines.Both;
                GrdSalesPerformance.HeaderStyle.Font.Bold = true;
                GrdSalesPerformance.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void btnoutExcel_Click(object sender, EventArgs e)
        {
            if (grdOutStanding.Rows.Count > 0)
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grdOutStanding.GridLines = GridLines.Both;
                //grdOutStanding.HeaderStyle.Font.Bold = true;
                //grdOutStanding.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                grdOutStanding.AllowPaging = false;
                //  Grdincomnotbooked();
                get_out();

                grdOutStanding.GridLines = GridLines.Both;
                grdOutStanding.HeaderStyle.Font.Bold = true;
                grdOutStanding.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnQuatotion_Click(object sender, EventArgs e)
        {
            if (grdQuatotion.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Quatotion.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdQuatotion.GridLines = GridLines.Both;
                grdQuatotion.HeaderStyle.Font.Bold = true;
                grdQuatotion.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void grdOutStanding_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[3].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[3].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;

                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdOutStanding, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdOutStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            data();

            ////string customername = "";
            ////int index;
            ////if (grdOutStanding.Rows.Count > 0)
            ////{
            ////    index = grdOutStanding.SelectedRow.RowIndex;
            ////    //customername = grdOutStanding.Rows[index].Cells[1].Text;
            ////    Label lbl = (grdOutStanding.Rows[index].Cells[1].FindControl("customer") as Label);
            ////    customername = lbl.Text;
            ////    Session["OutStndingCustomerName"] = customername.ToString();

            ////}
            //DataTable dt_temp = new DataTable();
            //DataTable dtnew1 = new DataTable();
            //dt_temp = Session["dt_UserRights"] as DataTable;
            //DataView dv_co1 = new DataView(dt_temp);
            //dtnew1 = dv_co1.ToTable(true, "trantype");
            //dv_co1 = new DataView(dtnew1);
            //dv_co1.Sort = "trantype";
            //dtnew1 = dv_co1.ToTable();
            //DataTable dtuser = new DataTable();
            //string trantypenew; int count = 0;
            //for (int i = 0; i < dtnew1.Rows.Count; i++)
            //{
            //    trantypenew = dtnew1.Rows[0][0].ToString();
            //    if (trantypenew == "FE")
            //    {
            //        dtuser = obj_UP.GetFormwiseuserRights(586, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //        if (dtuser.Rows.Count > 0)
            //        {
            //            count += 1;
            //        }
            //        else
            //        {

            //        }

            //    }

            //    if (trantypenew == "FI")
            //    {
            //        dtuser = obj_UP.GetFormwiseuserRights(596, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //        if (dtuser.Rows.Count > 0)
            //        {
            //            count += 1;
            //        }
            //        else
            //        {

            //        }

            //    }

            //    if (trantypenew == "AE")
            //    {
            //        dtuser = obj_UP.GetFormwiseuserRights(593, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //        if (dtuser.Rows.Count > 0)
            //        {
            //            count += 1;
            //        }
            //        else
            //        {

            //        }

            //    }

            //    if (trantypenew == "AI")
            //    {
            //        dtuser = obj_UP.GetFormwiseuserRights(594, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //        if (dtuser.Rows.Count > 0)
            //        {
            //            count += 1;
            //        }
            //        else
            //        {

            //        }

            //    }
            //}
            //if (count > 0)
            //{

            //    Session["trantype_process"] = dtnew1;
            //    //this.aePopUpshow.Show();
            //    // iframecost.Attributes["src"] = "../Sales/Outstanding.aspx";

            //    Response.Redirect("../Sales/Outstanding.aspx");
            //}

            //else
            //{
            //    string message = "No Rights";
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "SalesHome", "alertify.alert('" + message + "');", true);

            //}

            //DataTable dt_temp = new DataTable();
            //DataTable dtnew1 = new DataTable();
            //dt_temp = Session["dt_UserRights"] as DataTable;
            //DataView dv_co1 = new DataView(dt_temp);
            //dtnew1 = dv_co1.ToTable(true, "trantype");
            //dv_co1 = new DataView(dtnew1);
            //dv_co1.Sort = "trantype";
            //dtnew1 = dv_co1.ToTable();
            //if (dtnew1.Rows.Count > 0)
            //{
            //    Session["trantype_process"] = dtnew1;
            //    this.aePopUpshow.Show();
            //    iframecost.Attributes["src"] = "../Sales/Outstanding.aspx";

            //}
        }

        public void data()
        {
            PieChart2.Visible = false;
            string customername = "";
            string str_SelFormula = "";
            int index;
            if (grdOutStanding.Rows.Count > 0)
            {
                index = grdOutStanding.SelectedRow.RowIndex;
                Label lbl = (grdOutStanding.Rows[index].Cells[1].FindControl("customer") as Label);
                customername = lbl.Text;
                Label2.Text = lbl.Text;
                Session["OutStndingCustomerName"] = customername.ToString();
            }
            if (customername == "Total")
            {
                customername = "";
            }
            int s = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int d = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            string empname = empobj.GetEmployeeName(s);
            int time = Logobj.GetDate().Hour;
            if (time < 13)
            {
                dt = outobj.OpsOutStdingGET(99999, d, s);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outobj.OpsOutStdingGET12N(99999, d, s);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outobj.OpsOutStdingGET3PM(99999, d, s);
            }
            if (customername != "")
            {
                if (customername != "ALL")
                {
                    if (str_SelFormula != "")
                    {
                        str_SelFormula = str_SelFormula + " and customer =  '" + customername + "'";
                    }
                    else
                    {
                        str_SelFormula = "customer like  '" + customername + "'";
                    }
                }
            }
            DataView dt_ldg = new DataView(dt);
            if (str_SelFormula != "")
            {
                dt_ldg.RowFilter = str_SelFormula;
            }
            DataTable dt2 = new DataTable();
            dt2 = dt_ldg.ToTable();
            if (dt2.Rows.Count > 0)
            {
                DataRow dr2 = dt2.NewRow();
                dr2["refno"] = "Total";
                Double amount = Convert.ToDouble(dt2.Compute("sum(amount)", ""));
                Double overdue = Convert.ToDouble(dt2.Compute("sum(overdue)", ""));
                Double famount = Convert.ToDouble(dt2.Compute("sum(famount)", ""));
                Double foverdue = Convert.ToDouble(dt2.Compute("sum(foverdue)", ""));
                dr2["amount"] = amount.ToString("#,0.00") + "";
                dr2["overdue"] = overdue.ToString("#,0.00") + "";
                dr2["famount"] = famount.ToString("#,0.00") + "";
                dr2["foverdue"] = foverdue.ToString("#,0.00") + "";

                //dr2["amount"] = dt2.Compute("sum(amount)", "");
                //dr2["overdue"] = dt2.Compute("sum(overdue)", "");
                //dr2["famount"] = dt2.Compute("sum(famount)", "");
                //dr2["foverdue"] = dt2.Compute("sum(foverdue)", "");

                dt2.Rows.Add(dr2);
            }
            Panel7.Visible = true;
            GridView2.Visible = true;
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            if (GridView2.Rows.Count > 0)
            {
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
            }

            Chart1.Visible = false;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;

            Panel6.Visible = false;
            GridView3.Visible = false;

        }

        protected void GrdSalesPerformance_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#aad0ed';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdSalesPerformance, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[1].Text == "Total")
                {

                    e.Row.Cells[0].Text = "";
                }
            }
        }

        protected void GrdSalesPerformance_SelectedIndexChanged(object sender, EventArgs e)
        {

            excl_export.Visible = true;
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            int index;
            string type = "";
            string trnType = "";
            int month, year;
            if (GrdSalesPerformance.Rows.Count > 0)
            {
                index = GrdSalesPerformance.SelectedRow.RowIndex;
                type = GrdSalesPerformance.Rows[index].Cells[1].Text;
                DateTime dtfrom = Convert.ToDateTime(Utility.fn_ConvertDate(txtFromdate.Text.ToString()));
                DateTime dtto = Convert.ToDateTime(Utility.fn_ConvertDate(txtTodate.Text.ToString()));
                DateTime Todate = Convert.ToDateTime(logobj.GetDate().ToString());
                month = Todate.Month;
                year = Todate.Year;
                DateTime fromdate = Convert.ToDateTime(month + "/01/" + year);
                if (dtfrom.ToShortDateString() == Todate.ToShortDateString() && dtto.ToShortDateString() == Todate.ToShortDateString())
                {
                    dtfrom = fromdate;
                }

                if (type == "OE")
                {
                    trnType = "FE";
                    lbl_Perfor_det.Text = "Ocean Exports";
                }
                else if (type == "OI")
                {
                    trnType = "FI";
                    lbl_Perfor_det.Text = "Ocean Imports";
                }
                else if (type == "AE")
                {
                    trnType = "AE";
                    lbl_Perfor_det.Text = "Air Exports";
                }
                else if (type == "AI")
                {
                    trnType = "AI";
                    lbl_Perfor_det.Text = "Air Imports";
                }
                else if (type == "CHA")
                {
                    trnType = "CH";
                    lbl_Perfor_det.Text = "CHA";
                }
                else if (type == "BT")
                {
                    trnType = "BT";
                    lbl_Perfor_det.Text = "Bonded Trucking";
                }
                else if (type == "Total")
                {
                    trnType = "AL";
                    lbl_Perfor_det.Text = "ALL";
                }

                //dt = costobj.getperformancecosting(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginBranchid"]), trnType, dtfrom);
                dt = costobj.getperformancecosting_Karthika(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginBranchid"]), trnType, dtfrom, dtto);

                Panel6.Visible = true;

                Double income = 0;
                Double expense = 0;
                Double Retention = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    income += Convert.ToDouble(dt.Rows[i]["income"].ToString());
                    expense += Convert.ToDouble(dt.Rows[i]["Expense"].ToString()); //Convert.ToDouble(dt.Compute("sum(Expense)", ""));
                    Retention += Convert.ToDouble(dt.Rows[i]["Retention"].ToString()); //Convert.ToDouble(dt.Compute("sum(Retention)", ""));
                }
                //if(dt.Rows.Count>0)
                //{
                //    income = Convert.ToDouble(dt.Compute("sum(Income)", ""));
                //    expense = Convert.ToDouble(dt.Compute("sum(Expense)", ""));
                //    Retention = Convert.ToDouble(dt.Compute("sum(Retention)", ""));
                //}

                //if(income !=0.00)
                //{
                //    income = Convert.ToDouble(dt.Compute("sum(Income)", ""));
                //}
                //if (expense != 0.00)
                //{
                //    expense = Convert.ToDouble(dt.Compute("sum(Expense)", ""));
                //}
                //if (Retention!= 0.00)
                //{
                //    Retention = Convert.ToDouble(dt.Compute("sum(Retention)", ""));
                //}
                DataTable dt_test = dt;
                int count = dt_test.Rows.Count;
                dt_test.Rows.Add();
                dt_test.Rows[count][9] = "Total";
                dt_test.Rows[count][10] = income.ToString("#,0.00");
                dt_test.Rows[count][11] = expense.ToString("#,0.00");
                dt_test.Rows[count][12] = Retention.ToString("#,0.00");
                GridView3.DataSource = dt_test;
                GridView3.DataBind();
                if (GridView3.Rows.Count > 0)
                {
                    GridView3.Rows[GridView3.Rows.Count - 1].Cells[9].ForeColor = System.Drawing.Color.Maroon;
                    GridView3.Rows[GridView3.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
                    GridView3.Rows[GridView3.Rows.Count - 1].Cells[11].ForeColor = System.Drawing.Color.Maroon;
                    GridView3.Rows[GridView3.Rows.Count - 1].Cells[12].ForeColor = System.Drawing.Color.Maroon;
                }
                GridView3.Visible = true;
                ViewState["GridView3exp2exc"] = dt_test;
                Panel1.Visible = false;
                classDiv.Visible = false;
                GridView1.Visible = false;
                chartper.Visible = false;
                // div6.Visible = false;
                Panel7.Visible = false;
                GridView2.Visible = false;
            }
        }

        protected void lnkWorkinProc_Click(object sender, EventArgs e)
        {
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            DataTable dt_temp = new DataTable();
            DataTable dtnew1 = new DataTable();
            dt_temp = Session["dt_UserRights"] as DataTable;
            DataView dv_co1 = new DataView(dt_temp);
            dtnew1 = dv_co1.ToTable(true, "trantype");
            dv_co1 = new DataView(dtnew1);
            dv_co1.Sort = "trantype";
            dtnew1 = dv_co1.ToTable();
            DataTable dtuser = new DataTable();
            string trantypenew; int count = 0;

            for (int i = 0; i < dtnew1.Rows.Count; i++)
            {
                trantypenew = dtnew1.Rows[0][0].ToString();

                if (trantypenew == "FE")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(818, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }

                if (trantypenew == "FI")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(817, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }

                if (trantypenew == "AE")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(816, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }

                if (trantypenew == "AI")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(815, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }
            }

            if (count > 0)
            {
                string str_frmname, str_RptName, str_sf, str_sp, str_Script;
               // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                str_frmname = "WorkINProgress";
                str_RptName = "FE WIP.rpt";
                str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"] + " and {FEBLDetails.salesid}=" + Session["LoginEmpId"] + " And isnull({FEJobInfo.jobclosedate})";
                str_sp = "Header=Booking Register For Work In Progress";
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;
                str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                ScriptManager.RegisterStartupScript(Page, typeof(Button), "Work IN Progress", str_Script, true);
                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 818, 1, Convert.ToInt32(Session["LoginBranchid"]), "/SalesID: " + Convert.ToInt32(Session["LoginEmpId"]) + "/ Report");
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "SalesHome", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnkShipmentQuery_Click(object sender, EventArgs e)
        {
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            DataTable dt_temp = new DataTable();
            DataTable dtnew1 = new DataTable();
            dt_temp = Session["dt_UserRights"] as DataTable;
            DataView dv_co1 = new DataView(dt_temp);
            dtnew1 = dv_co1.ToTable(true, "trantype");
            dv_co1 = new DataView(dtnew1);
            dv_co1.Sort = "trantype";
            dtnew1 = dv_co1.ToTable();
            DataTable dtuser = new DataTable();
            string trantypenew; int count = 0;
            for (int i = 0; i < dtnew1.Rows.Count; i++)
            {
                trantypenew = dtnew1.Rows[0][0].ToString();

                if (trantypenew == "FE")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(776, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }

                if (trantypenew == "AE")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(784, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }
                else if (trantypenew == "AI")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(785, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }
            }
            if (count > 0)
            {
                Session["trantype_process"] = dtnew1;
                this.aePopUpshow.Show();
                iframecost.Attributes["src"] = "../AE/SalesQuery.aspx";
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "SalesHome", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnkBuyRates_Click(object sender, EventArgs e)
        {
            //DataTable dt_temp = new DataTable();
            //DataTable dtnew1 = new DataTable();
            //dt_temp = Session["dt_UserRights"] as DataTable;
            //DataView dv_co1 = new DataView(dt_temp);
            //dtnew1 = dv_co1.ToTable(true, "trantype");
            //dv_co1 = new DataView(dtnew1);
            //dv_co1.Sort = "trantype";
            //dtnew1 = dv_co1.ToTable();
            //if (dtnew1.Rows.Count > 0)
            //{
            //    Session["trantype_process"] = dtnew1;
            //    this.aePopUpshow.Show();
            //    iframecost.Attributes["src"] = "../Sales/BuyingRate-Query.aspx";
            //}
            DataTable dt_temp = new DataTable();
            DataTable dtnew1 = new DataTable();
            dt_temp = Session["dt_UserRights"] as DataTable;
            DataView dv_co1 = new DataView(dt_temp);
            dtnew1 = dv_co1.ToTable(true, "trantype");
            dv_co1 = new DataView(dtnew1);
            dv_co1.Sort = "trantype";
            dtnew1 = dv_co1.ToTable();
            DataTable dtuser = new DataTable();
            string trantypenew; int count = 0;
            for (int i = 0; i < dtnew1.Rows.Count; i++)
            {
                trantypenew = dtnew1.Rows[0][0].ToString();

                if (trantypenew == "FE")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(626, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }
                else if (trantypenew == "FI")
                {
                    dtuser = obj_UP.GetFormwiseuserRights(627, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                    if (dtuser.Rows.Count > 0)
                    {
                        count += 1;
                    }
                    else
                    {

                    }
                }
            }

            if (count > 0)
            {
                Session["trantype_process"] = dtnew1;
                this.aePopUpshow.Show();
                iframecost.Attributes["src"] = "../Sales/BuyingRate-Query.aspx";
            }

            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "SalesHome", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdQuatotion_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b2d9f7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdQuatotion, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GrdBooking_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }

        protected void grdTranNew_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdTranNew, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdTranNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string trantype = "";
            //int index;
            //lblBooking.Visible = false;
            //Panel1.Visible = false;
            //pnlGrdCuswise.Visible = false;
            //GrdCuswise.Visible = false;
            //cutnew.Visible = false;
            //classDiv.Visible = false;
            //GridView1.Visible = false;
            //cutnew.Visible = false;
            //Panel4.Visible = false;
            ////Panel5.Visible = false;
            //if (grdTranNew.Rows.Count > 0)
            //{
            //    cutnew.Visible = true;
            //    pnlGrdCuswise.Visible = true;
            //    GrdCuswise.Visible = true;
            //    index = grdTranNew.SelectedRow.RowIndex;

            //    trantype = grdTranNew.Rows[index].Cells[0].Text;
            //    if (trantype == "Ocean Exports")
            //    {
            //        Session["trantype"] = "FE";
            //    }
            //    else if (trantype == "OI")
            //    {
            //        Session["trantype"] = "Ocean Imports";
            //    }
            //    else
            //    {
            //        Session["trantype"] = trantype;
            //    }

            //    dt = objbu.SpSalesCustName(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), Session["trantype"].ToString());
            //    DataTable dtemptyfree = new DataTable();
            //    dtemptyfree.Columns.Add("customername");
            //    dtemptyfree.Columns.Add("Counts");
            //    dtemptyfree.Columns.Add("cusid");
            //    DataRow dr = dtemptyfree.NewRow();

            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int j = 0; j <= dt.Rows.Count - 1; j++)
            //        {
            //            dtemptyfree.Rows.Add();
            //            dr = dtemptyfree.NewRow();
            //            dtemptyfree.Rows[j]["customername"] = dt.Rows[j]["customername"].ToString();
            //            dtemptyfree.Rows[j]["Counts"] = dt.Rows[j]["Counts"].ToString();
            //            dtemptyfree.Rows[j]["cusid"] = dt.Rows[j]["cusid"].ToString();
            //        }
            //        dtemptyfree.Rows.Add(dr);
            //        var sum_Income = dt.Compute("sum(counts)", "");
            //        dtemptyfree.Rows[dt.Rows.Count]["customername"] = "Total";
            //        dtemptyfree.Rows[dt.Rows.Count]["Counts"] = sum_Income.ToString();

            //        GrdCuswise.DataSource = dtemptyfree;
            //        GrdCuswise.DataBind();
            //        if (GrdCuswise.Rows.Count > 0)
            //        {

            //            GrdCuswise.Rows[GrdCuswise.Rows.Count - 1].Cells[0].ForeColor = System.Drawing.Color.Blue;
            //            GrdCuswise.Rows[GrdCuswise.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Crimson;
            //            GrdCuswise.Rows[GrdCuswise.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Crimson;
            //        }
            //    }
            //    else
            //    {                   
            //        GrdCuswise.DataSource = Utility.Fn_GetEmptyDataTable();
            //        GrdCuswise.DataBind();
            //    }
            //}
        }

        protected void grdQuatotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dtuser = new DataTable();
            //string trantypenew = ""; int count = 0;
            //DataTable dt_temp = new DataTable();
            //DataTable dtnew1 = new DataTable();
            //dt_temp = Session["dt_UserRights"] as DataTable;
            //DataView dv_co1 = new DataView(dt_temp);
            //dtnew1 = dv_co1.ToTable(true, "trantype");
            //dv_co1 = new DataView(dtnew1);
            //dv_co1.Sort = "trantype";
            //dtnew1 = dv_co1.ToTable();
            //int index = grdQuatotion.SelectedRow.RowIndex;

            //for (int i = 0; i < dtnew1.Rows.Count; i++)
            //{
            //    trantypenew = dtnew1.Rows[i][0].ToString();
            //    System.Web.UI.WebControls.Image ImageUnApp = grdQuatotion.Rows[i].FindControl("UnAppImage") as System.Web.UI.WebControls.Image;
            //    System.Web.UI.WebControls.Image ImageApp = grdQuatotion.Rows[i].FindControl("AppImage") as System.Web.UI.WebControls.Image;

            //    if (ImageApp.Visible == true)
            //    {
            //        if (trantypenew == "FE")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(10, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Booking.aspx");
            //            }
            //        }
            //        else if (trantypenew == "FI")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(11, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Booking.aspx");
            //            }
            //        }

            //        else if (trantypenew == "AI")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(13, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Booking.aspx");
            //            }
            //        }
            //        else if (trantypenew == "AE")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(12, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Booking.aspx");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (trantypenew == "FE")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(14, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Quotation.aspx");
            //            }
            //        }
            //        else if (trantypenew == "FI")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(15, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Quotation.aspx");
            //            }
            //        }
            //        else if (trantypenew == "AI")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(17, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Quotation.aspx");
            //            }
            //        }
            //        else if (trantypenew == "AE")
            //        {
            //            dtuser = obj_UP.GetFormwiseuserRights(16, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
            //            if (dtuser.Rows.Count > 0)
            //            {
            //                Response.Redirect("../Sales/Quotation.aspx");
            //            }
            //        }
            //    }
            //}
            DataTable dtuser = new DataTable();

            int uiid;
            int Row_Index = grdQuatotion.SelectedRow.RowIndex;
            if (grdQuatotion.Rows[Row_Index].Cells[8].Text == "Approved")
            {
                if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OE")
                {
                    uiid = 10;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OI")
                {
                    uiid = 11;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AE")
                {
                    uiid = 12;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AI")
                {
                    uiid = 13;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/Booking.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&uiid=" + uiid);
                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
            }
            else if (grdQuatotion.Rows[Row_Index].Cells[8].Text == "UnApproved")
            {

                string app = "Quotation Approval";
                if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OE")
                {
                    uiid = 181;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/QuotBuyBook.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "OI")
                {
                    uiid = 180;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/QuotBuyBook.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AE")
                {
                    uiid = 217;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AE");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/QuotBuyBook.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }
                else if (grdQuatotion.Rows[Row_Index].Cells[2].Text == "AI")
                {
                    uiid = 215;
                    dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "AI");
                    if (dtuser.Rows.Count > 0)
                    {
                        Response.Redirect("../Sales/QuotBuyBook.aspx?quotno=" + grdQuatotion.Rows[Row_Index].Cells[1].Text + "&product=" + grdQuatotion.Rows[Row_Index].Cells[2].Text + "&type=" + app + "&uiid=" + uiid);

                    }
                    else
                    {
                        string message = "No Rights";
                        ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
                    }
                }

            }
        }

        protected void GrdCuswise_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdCuswise, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }

            }

        }

        protected void GrdCuswise_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_cust_name.Visible = true;
            int index = GrdCuswise.SelectedRow.RowIndex;
            Label customer = GrdCuswise.Rows[index].FindControl("customername") as Label;
            cust_name.Text = customer.Text;
            if (customer.Text == "Total")
            {
                custid = 0;
            }
            if (customer.Text != "Total")
            {
                custid = Convert.ToInt32(GrdCuswise.DataKeys[index].Values[0].ToString());
            }

            dt = objbu.GetNewBookingDetailscust(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), custid, Convert.ToInt32(Session["LoginEmpId"]));

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            ViewState["GridView1exp2exc"] = dt;

            piechartbook.Visible = false;
            Panel7.Visible = false;
            GridView2.Visible = false;
            classDiv.Visible = false;
            //Panel6.Visible = false;
            //GridView3.Visible = false;
            classDiv.Visible = true;
            GridView1.Visible = true;
            Panel1.Visible = true;

            lblBooking.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;
            pnlJobAE.Visible = false;

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            if (GridView1.Rows.Count > 0)
            {
                lblBooking.Visible = true;
                div1.Visible = true;
                Panel4.Visible = true;
                GrdBooking.Visible = true;
                pnlJobAE.Visible = true;
                // Panel5.Visible = false;
                index = GridView1.SelectedRow.RowIndex;
                string name = GridView1.Rows[index].Cells[1].Text;
                lblBooking.Text = name;
                trantype = GridView1.Rows[index].Cells[2].Text;
                if (trantype == "OE - FCL" || trantype == "OE - LCL")
                {
                    product = "FE";
                }
                if (trantype == "OI - FCL" || trantype == "OI - LCL")
                {
                    product = "FI";
                }
                if (trantype == "AE")
                {
                    product = "AE";
                }
                if (trantype == "AI")
                {
                    product = "AI";
                }

                dt = objJob.GetSalesBookingNew(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), name, product);
                if (dt.Rows.Count > 0)
                {
                    if (product == "FE")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["blno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Stuffed on ";
                        DateTime newdate2 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["stuffedon"].ToString()));
                        dr1[1] = newdate2.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Sailed On ";
                        DateTime newdate5 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["eta"].ToString()));
                        dr1[1] = newdate5.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL Date ";
                        DateTime newdate4 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bldate"].ToString()));
                        dr1[1] = newdate4.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();
                    }
                    else if (product == "FI")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["blno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();

                    }
                    else if (product == "AE")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["hawblno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();

                    }
                    else if (product == "AI")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["hawblno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();

                    }
                    //this.popupBuying.Show();
                }
            }

            //int Row_Index = GridView1.SelectedRow.RowIndex;
            //Response.Redirect("../Sales/Booking.aspx?bookingno=" + GridView1.Rows[Row_Index].Cells[1].Text + "&product=" + GridView1.Rows[Row_Index].Cells[8].Text);

            //Karthika
            /*int index;
            if (GridView1.Rows.Count > 0)
            {
                lblBooking.Visible = true;
                div1.Visible = true;
                Panel4.Visible = true;
                GrdBooking.Visible = true;
                // Panel5.Visible = false;
                index = GridView1.SelectedRow.RowIndex;
                string name = GridView1.Rows[index].Cells[1].Text;
                //dt = objJob.GetSalesBookingNew(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), name, "AI");

                dt = objJob.GetSalesBookingNew_Karthika(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]), Convert.ToInt32(Session["LoginEmpId"]), name);
                if (dt.Rows.Count > 0)
                {
                    if (Session["trantype"].ToString() == "FE")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["blno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Stuffed on ";
                        DateTime newdate2 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["stuffedon"].ToString()));
                        dr1[1] = newdate2.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Sailed On ";
                        DateTime newdate5 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["eta"].ToString()));
                        dr1[1] = newdate5.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL Released on ";
                        DateTime newdate4 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bldate"].ToString()));
                        dr1[1] = newdate4.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();
                    }
                    else if (Session["trantype"].ToString() == "FI")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["blno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();

                    }
                    else if (Session["trantype"].ToString() == "AE")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["blno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();
                    }
                    else if (Session["trantype"].ToString() == "AI")
                    {
                        DataTable dtapp = new DataTable();
                        dtapp.Columns.Add("Booking");
                        dtapp.Columns.Add(" Details");
                        DataRow dr1 = dtapp.NewRow();
                        dr1[0] = "Booking #";
                        dr1[1] = dt.Rows[0]["BookingNo"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["bookingdate"].ToString()));
                        dr1[1] = newdate.ToShortDateString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Quot #";
                        dr1[1] = dt.Rows[0]["quotno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Date";
                        DateTime newdate1 = Convert.ToDateTime(Utility.fn_ConvertDate(dt.Rows[0]["quotdate"].ToString()));
                        dr1[1] = newdate1.ToShortDateString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "Customer";
                        dr1[1] = dt.Rows[0]["customername"].ToString();
                        dtapp.Rows.Add(dr1);

                        dr1 = dtapp.NewRow();
                        dr1[0] = "BL #";
                        dr1[1] = dt.Rows[0]["blno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        dr1[0] = "Job #";
                        dr1[1] = dt.Rows[0]["jobno"].ToString();
                        dtapp.Rows.Add(dr1);
                        dr1 = dtapp.NewRow();
                        GrdBooking.DataSource = dtapp;
                        GrdBooking.DataBind();

                    }
                    this.popupBuying.Show();
                }
            }*/

        }

        protected void lblWorking_Click(object sender, EventArgs e)
        {
            string trantypenew = "", str_Script = "";
            DataTable dtnew = new DataTable();
            dtnew = outobj.GetWorkProcesNew(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]));

            for (int i = 0; i < dtnew.Rows.Count; i++)
            {
                trantypenew = dtnew.Rows[i][1].ToString();

                if (trantypenew == "FE")
                {
                    string str_frmname, str_RptName, str_sf, str_sp;
                  //  DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                    str_frmname = "WorkINProgress";
                    str_RptName = "FE WIP.rpt";
                    str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"] + " and {FEBLDetails.salesid}=" + Session["LoginEmpId"] + " And isnull({FEJobInfo.jobclosedate})";
                    str_sp = "Header=Booking Register For Work In Progress";
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Button), "Work IN Progress", str_Script, true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 818, 1, Convert.ToInt32(Session["LoginBranchid"]), "/SalesID: " + Convert.ToInt32(Session["LoginEmpId"]) + "/ Report");
                }

                if (trantypenew == "FI")
                {
                    string str_frmname, str_RptName, str_sf, str_sp;
                  //  DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                    str_frmname = "WorkINProgress";
                    str_RptName = "FI WIP.rpt";
                    str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"] + " and {FEBLDetails.salesid}=" + Session["LoginEmpId"] + " And isnull({FEJobInfo.jobclosedate})";
                    str_sp = "Header=Booking Register For Work In Progress";
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Button), "Work IN Progress", str_Script, true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 818, 1, Convert.ToInt32(Session["LoginBranchid"]), "/SalesID: " + Convert.ToInt32(Session["LoginEmpId"]) + "/ Report");
                }

                if (trantypenew == "AE")
                {
                    string str_frmname, str_RptName, str_sf, str_sp;
                   // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                    str_frmname = "WorkINProgress";
                    str_RptName = "AE WIP.rpt";
                    str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"] + " and {FEBLDetails.salesid}=" + Session["LoginEmpId"] + " And isnull({FEJobInfo.jobclosedate})";
                    str_sp = "Header=Booking Register For Work In Progress";
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Button), "Work IN Progress", str_Script, true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 818, 1, Convert.ToInt32(Session["LoginBranchid"]), "/SalesID: " + Convert.ToInt32(Session["LoginEmpId"]) + "/ Report");
                }

                if (trantypenew == "AI")
                {
                    string str_frmname, str_RptName, str_sf, str_sp;
                   // DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
                    str_frmname = "WorkINProgress";
                    str_RptName = "AI WIP.rpt";
                    str_sf = "{FEJobInfo.bid}=" + Session["LoginBranchid"] + " and {FEBLDetails.salesid}=" + Session["LoginEmpId"] + " And isnull({FEJobInfo.jobclosedate})";
                    str_sp = "Header=Booking Register For Work In Progress";
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Button), "Work IN Progress", str_Script, true);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 818, 1, Convert.ToInt32(Session["LoginBranchid"]), "/SalesID: " + Convert.ToInt32(Session["LoginEmpId"]) + "/ Report");
                }
            }
        }

        protected void lnk_quotion_Click(object sender, EventArgs e)
        {
            divBooknew.Visible = false;
            cust_name.Visible = false;
            pnlTran.Visible = false;
            excl_export.Visible = false;
            grdTranNew.Visible = false;
            cutnew.Visible = true;
            pnlGrdCuswise.Visible = true;
            GrdCuswise.Visible = true;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            Panel9.Visible = false;
            GrdBooking.Visible = false;
            Grid_workprogress.Visible = false;
            lbl_Perfor_det.Visible = false;
            excl_export.Visible = false;
            //PanelPendingEvent.Visible = false;
            //GrdSalesPerformance.Visible = false;
            //divPerson.Visible = false;
            //divQuot.Visible = true;
            //Panel3.Visible = true;
            //grdQuatotion.Visible = true;
            //Divout.Visible = false;
            //Panel2.Visible = false;
            //grdOutStanding.Visible = false;
            Get_quotation();
        }

        //protected void lnk_outStanding_Click(object sender, EventArgs e)
        //{
        //    divBooknew.Visible = false;
        //    pnlTran.Visible = false;
        //    grdTranNew.Visible = false;
        //    cutnew.Visible = true;
        //    pnlGrdCuswise.Visible = true;
        //    GrdCuswise.Visible = true;
        //    classDiv.Visible = false;
        //    Panel1.Visible = false;
        //    GridView1.Visible = false;
        //    div1.Visible = false;
        //    Panel4.Visible = false;
        //    Panel9.Visible = false;
        //    GrdBooking.Visible = false;
        //    Grid_workprogress.Visible = false;
        //    //PanelPendingEvent.Visible = false;
        //    //GrdSalesPerformance.Visible = false;
        //    //divPerson.Visible = false;
        //    //divQuot.Visible = false;
        //    //Panel3.Visible = false;
        //    //grdQuatotion.Visible = false;
        //    //Divout.Visible = true;
        //    //Panel2.Visible = true;
        //    //grdOutStanding.Visible = true;
        //    Session["name"] = "linkoust";
        //    get_out();
        //    //div6.Attributes["class"] = "hide";
        //    //div6.Visible = false;
        //    grdOutStanding.Visible = false;
        //    //div5.Visible = true;
        //}

        //protected void linkPerfomance_Click(object sender, EventArgs e)
        //{
        //    divBooknew.Visible = false;
        //    pnlTran.Visible = false;
        //    grdTranNew.Visible = false;
        //    cutnew.Visible = true;
        //    pnlGrdCuswise.Visible = true;
        //    GrdCuswise.Visible = true;
        //    classDiv.Visible = false;
        //    Panel1.Visible = false;
        //    GridView1.Visible = false;
        //    div1.Visible = false;
        //    Panel4.Visible = false;
        //    GrdBooking.Visible = false;
        //    Panel9.Visible = false;
        //    Grid_workprogress.Visible = false;
        //    //divQuot.Visible = false;
        //    //Panel3.Visible = false;
        //    //grdQuatotion.Visible = false;
        //    //Divout.Visible = false;
        //    //Panel2.Visible = false;
        //    //grdOutStanding.Visible = false;

        //    //divPerson.Visible = true;
        //    //PanelPendingEvent.Visible = true;
        //    //GrdSalesPerformance.Visible = true;
        //    Revenue_Funtion();
        //   // div6.Visible = true;
        //}

        protected void lnkExReate_Click(object sender, EventArgs e)
        {
            divBooknew.Visible = false;
            pnlTran.Visible = false;
            grdTranNew.Visible = false;
            cutnew.Visible = true;
            pnlGrdCuswise.Visible = true;
            GrdCuswise.Visible = true;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;
            Grid_workprogress.Visible = false;
            //divPerson.Visible = false;
            //PanelPendingEvent.Visible = false;
            //GrdSalesPerformance.Visible = false;
            //divQuot.Visible = false;
            //Panel3.Visible = false;
            //grdQuatotion.Visible = false;
            //Divout.Visible = false;
            //Panel2.Visible = false;
            //grdOutStanding.Visible = false;
            //Panelexrate.Visible = true;
            //Gridexrate.Visible = true;
            loadgrd();
        }

        protected void lnkNewCustomerRequest_Click(object sender, EventArgs e)
        {
            DataTable dt_temp = new DataTable();
            DataTable dtnew1 = new DataTable();
            dt_temp = Session["dt_UserRights"] as DataTable;
            DataView dv_co1 = new DataView(dt_temp);
            dtnew1 = dv_co1.ToTable(true, "trantype");
            dv_co1 = new DataView(dtnew1);
            dv_co1.Sort = "trantype";
            dtnew1 = dv_co1.ToTable();
            DataTable dtuser = new DataTable();
            string trantypenew; int count = 0;
            dtuser = obj_UP.GetFormwiseuserRights(1927, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
            if (dtuser.Rows.Count > 0)
            {
                Response.Redirect("../Maintenance/MasterCustomerRequest.aspx");
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "Sales", "alertify.alert('" + message + "');", true);
            }

            /* for (int i = 0; i < dtnew1.Rows.Count; i++)
             {
                 trantypenew = dtnew1.Rows[0][0].ToString();

                 if (trantypenew == "FE")
                 {
                     dtuser = obj_UP.GetFormwiseuserRights(953, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                     if (dtuser.Rows.Count > 0)
                     {
                         Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");
                     }
                 }
                 else
                 {
                     string message = "No Rights";
                     ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "Sales", "alertify.alert('" + message + "');", true);
                 }

                 if (trantypenew == "FI")
                 {
                     dtuser = obj_UP.GetFormwiseuserRights(954, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                     if (dtuser.Rows.Count > 0)
                     {
                         Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");
                     }
                 }
                 else
                 {
                     string message = "No Rights";
                     ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "Sales", "alertify.alert('" + message + "');", true);
                 }

                 if (trantypenew == "AE")
                 {
                     dtuser = obj_UP.GetFormwiseuserRights(955, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                     if (dtuser.Rows.Count > 0)
                     {
                         Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");
                     }
                 }
                 else
                 {
                     string message = "No Rights";
                     ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "Sales", "alertify.alert('" + message + "');", true);
                 }
                 if (trantypenew == "AI")
                 {
                     dtuser = obj_UP.GetFormwiseuserRights(956, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), trantypenew);
                     if (dtuser.Rows.Count > 0)
                     {
                         Response.Redirect("../ForwardExports/ReqMasterCustomer.aspx");
                     }
                 }
                 else
                 {
                     string message = "No Rights";
                     ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.LinkButton), "Sales", "alertify.alert('" + message + "');", true);
                 }
             }*/
        }

        protected void lnkauo_Click(object sender, EventArgs e)
        {
            // string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();

            dtuser = obj_UP.GetFormwiseuserRights(97, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "");
            if (dtuser.Rows.Count > 0)
            {
                //Response.Redirect("../ForwardExports/CostingDetails.aspx");
                Response.Redirect("../ForwardExports/QuotationMultiport.aspx");
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
            }
        }

        //-------------Karthika_K

        protected void BookingDet()
        {
            DataTable dt_Booking = new DataTable();
            dt_Booking = objbu.SalesCustNameForBooking(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));
            int count = dt_Booking.Rows.Count;
            int value = 0;

            if (dt_Booking.Rows.Count > 0)
            {
                if (dt_Booking.Rows[0]["Counts"].ToString() == "")
                {
                    value = 0;
                }
                else
                {
                    value = Convert.ToInt32(dt_Booking.Compute("sum(Counts)", ""));
                }

            }
            dt_Booking.Rows.Add();
            dt_Booking.Rows[count][1] = "Total";

            //if(dt_Booking.Rows.Count>0)
            //{
            // value = value + Convert.ToInt32(dt_Booking.Rows[count][2]);

            //}
            dt_Booking.Rows[count][2] = value;
            GrdCuswise.Visible = true;
            GrdCuswise.DataSource = dt_Booking;
            GrdCuswise.DataBind();
            pnlGrdCuswise.Visible = true;
            Session["GrdCuswise"] = dt_Booking;
            if (GrdCuswise.Rows.Count > 0)
            {
                GrdCuswise.Rows[GrdCuswise.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                GrdCuswise.Rows[GrdCuswise.Rows.Count - 1].Cells[2].ForeColor = System.Drawing.Color.Maroon;
            }
            ViewState["GrdCuswiseexp2exc"] = dt_Booking;
            cutnew.Visible = true;
        }

        public void ddl_cmbase_add()
        {
         //   DataAccess.Accounts.Invoice da_obj_invoiceobj = new DataAccess.Accounts.Invoice();
            ddlBase.Items.Add("BL");
            ddlBase.Items.Add("CBM");
            ddlBase.Items.Add("MT");
            DataTable dt_base = new DataTable();
            dt_base = da_obj_invoiceobj.BaseFill();

            for (int i = 0; i <= dt_base.Rows.Count - 1; i++)
            {
                ddlBase.Items.Add(dt_base.Rows[i]["conttype"].ToString());
            }
        }

        protected void btnBuyQuery_Click(object sender, EventArgs e)
        {
            BuyingQueryDet();
        }

        protected void BuyingQueryDet()
        {
            DataTable Dt1 = new DataTable();
            DataTable DtLiner = new DataTable();

            int pol = 0, pod = 0, intliner = 0;
            string Base, ftype = "";

            if (hdf_POL.Value != "")
            {
                pol = Convert.ToInt32(hdf_POL.Value);
            }

            if (hdf_POD.Value != "")
            {
                pod = Convert.ToInt32(hdf_POD.Value);
            }

            int maxcol = 0, maxcol1 = 0;
            if (rdbExpired.Checked == true)
            {
                ftype = "E";
            }
            else if (rdbBoth.Checked == true)
            {
                ftype = "B";
            }
            DtLiner = Buyobj.GetBuyingQry4Liner(pol, pod, Convert.ToString(ddlBase.SelectedItem.Text), ftype);

            if (DtLiner.Rows.Count > 0)
            {
                DataTable dt_Tans = new DataTable();
                DataColumn Dc = new DataColumn("liner", typeof(string));

                dt_Tans.Columns.Add(Dc);

                for (int j = 0; j <= 3; j++)
                {
                    DataRow dr;
                    dr = dt_Tans.NewRow();
                    if (j == 0)
                    {
                        dr[0] = "Rateid";
                        dt_Tans.Rows.Add(dr);
                    }
                    else if (j == 1)
                    {
                        dr[0] = "Validtill";
                        dt_Tans.Rows.Add(dr);
                    }
                    else if (j == 2)
                    {
                        dr[0] = "Charges";
                        dt_Tans.Rows.Add(dr);
                    }
                }

                for (int i = 0; i <= DtLiner.Rows.Count - 1; i++)
                {
                    DataColumn dc_col2 = new DataColumn(i.ToString(), typeof(string));
                    dt_Tans.Columns.Add(dc_col2);
                    dt_Tans.Columns[i + 1].Caption = DtLiner.Rows[i]["customername"].ToString();
                    dt_Tans.Rows[0][i + 1] = DtLiner.Rows[i]["Rateid"].ToString();
                    dt_Tans.Rows[1][i + 1] = DtLiner.Rows[i]["validtill"].ToString();
                    intliner = Convert.ToInt32(DtLiner.Rows[i]["liner"].ToString());
                    Dt1 = Buyobj.GetBuyingQry(pol, pod, intliner, int.Parse(DtLiner.Rows[i]["rateid"].ToString()));

                    for (int j = 0; j <= Dt1.Rows.Count - 1; j++)
                    {
                        if (j == 0)
                            dt_Tans.Rows[2][i + 1] = Dt1.Rows[0]["rate"].ToString();

                        if (j > 0)
                        {
                            maxcol = j;
                            if (maxcol > maxcol1)
                            {
                                DataRow dr_charge;
                                dr_charge = dt_Tans.NewRow();
                                dt_Tans.Rows.Add(dr_charge);
                            }

                            dt_Tans.Rows[2 + j][i + 1] = Dt1.Rows[j]["rate"].ToString();
                        }
                    }

                    if (maxcol > maxcol1)
                    {
                        maxcol1 = maxcol;
                        maxcol = 0;
                    }
                    else if (maxcol1 == 0 && maxcol1 > 0)
                    {
                        maxcol1 = maxcol;
                        maxcol = 0;
                    }
                }
                Grd_Buying.Columns.Clear();

                foreach (DataColumn column in dt_Tans.Columns)
                {
                    BoundField obj_field = new BoundField();
                    obj_field.DataField = column.ColumnName;
                    obj_field.HeaderText = column.Caption;
                    Grd_Buying.Columns.Add(obj_field);
                }

                if (dt_Tans.Rows.Count > 0)
                {
                    Grd_Buying.DataSource = dt_Tans;
                    Grd_Buying.DataBind();
                    Session["Date"] = dt_Tans;
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 626, 2, Convert.ToInt32(Session["LoginBranchid"]), txtPOL.Text + " - " + txtPOD.Text);

                    pnlcncl.Visible = true;
                    popuprate.Show();
                }
                else
                {
                    Grd_Buying.DataSource = new DataTable();
                    Grd_Buying.DataBind();
                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 626, 2, Convert.ToInt32(Session["LoginBranchid"]), txtPOL.Text + " - " + txtPOD.Text);

                    pnlcncl.Visible = true;
                    popuprate.Show();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "DataFound", "alertify.alert('Details Not Available');", true);
                maxcol = 0;
                maxcol1 = 0;
            }
        }

        protected void txtPOL_TextChanged(object sender, EventArgs e)
        {
            btnBuyQuery.Enabled = true;
            int polid = port.GetNPortid(txtPOL.Text.Trim().ToUpper());
            if (polid != 0)
            {
                hdf_POL.Value = polid.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "alert", "alertify.alert('Please Enter Valid Port of Loading');", true);
                txtPOL.Text = "";
                txtPOL.Focus();
                return;
            }
        }

        protected void txtPOD_TextChanged(object sender, EventArgs e)
        {
            btnBuyQuery.Enabled = true;
            int podid = port.GetNPortid(txtPOD.Text.Trim().ToUpper());
            if (podid != 0)
            {
                hdf_POD.Value = podid.ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "alert", "alertify.alert('Please Enter Valid Port of DISCHARGE');", true);
                txtPOD.Text = "";
                txtPOD.Focus();
                return;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtPOD.Text = "";
            txtPOL.Text = "";
            rdbExpired.Checked = false;
            rdbLive.Checked = false;
            rdbBoth.Checked = false;
            ddlBase.SelectedIndex = -1;
        }

        protected void lnkapp_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../CRM/MainFrameAppointments.aspx");
        }
        protected void LnkApp_Click(object sender, EventArgs e)
        {
            divebooking.Visible = false;
            Response.Redirect("../CRM/MainFrameAppointments.aspx");
        }

        protected void LnkTB_Click(object sender, EventArgs e)
        {
            divebooking.Visible = false;
           // DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.GetTeleCalDetailsFilterTC(Convert.ToInt32(Session["LoginEmpId"]), 0, 0, 0, "", 0, 0, "", "");

            lblcallfoll.Text = "To Be Called";
            Panel10.Visible = true;
            GrdCustomer.Visible = true;
            CallPannel.Visible = true;

            Pertitle.Visible = false;
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            lnk_div_book.Visible = false;
            div_out.Visible = false;
            Div3.Visible = false;
            cust_name.Visible = false;
            //creditexamption.Visible = false;
            Div4.Visible = false;
            Panel9.Visible = false;
            excl_export.Visible = false;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            lts.Visible = false;
            lt.Visible = false;
            chartper.Visible = false;
            WIP.Visible = false;
            workingprogess.Visible = false;
            quot.Visible = false;
            div_book.Visible = false;
            lblPerformance.Visible = false;
            lblQuation.Visible = false;
            quatatio_exce.Visible = false;
            PanelPendingEvent.Visible = false;
            lblPerformance.Visible = false;
            txtFromdate.Visible = false;
            txtTodate.Visible = false;
            btnGet.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            classDiv.Visible = false;
            div1.Visible = false;
            lbl_Perfor_det.Visible = false;
            excl_export.Visible = false;
            PieChart2.Visible = false;
            lnk_lblPerformance.Visible = false;

            GrdCustomer.DataSource = dt;
            GrdCustomer.DataBind();
        }

        protected void LnkPR_Click(object sender, EventArgs e)
        {
            divebooking.Visible = false;
           // DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
            DataTable dt = new DataTable();
            dt = obj_MasterCustomer.GetTeleCalDetailsFilterFU(Convert.ToInt32(Session["LoginEmpId"]), 0, 0, 0, "", 0, 0, "", "");

            lblcallfoll.Text = "To Be Followed";
            Panel10.Visible = true;
            GrdCustomer.Visible = true;
            CallPannel.Visible = true;

            Pertitle.Visible = false;
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            lnk_div_book.Visible = false;
            div_out.Visible = false;
            Div3.Visible = false;
            cust_name.Visible = false;
            //creditexamption.Visible = false;
            Div4.Visible = false;
            Panel9.Visible = false;
            excl_export.Visible = false;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            lts.Visible = false;
            lt.Visible = false;
            chartper.Visible = false;
            WIP.Visible = false;
            workingprogess.Visible = false;
            quot.Visible = false;
            div_book.Visible = false;
            lblPerformance.Visible = false;
            lblQuation.Visible = false;
            quatatio_exce.Visible = false;
            PanelPendingEvent.Visible = false;
            lblPerformance.Visible = false;
            txtFromdate.Visible = false;
            txtTodate.Visible = false;
            btnGet.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            classDiv.Visible = false;
            div1.Visible = false;
            lbl_Perfor_det.Visible = false;
            excl_export.Visible = false;
            PieChart2.Visible = false;
            lnk_lblPerformance.Visible = false;

            GrdCustomer.DataSource = dt;
            GrdCustomer.DataBind();
        }
        protected void Grd_Buying_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Center";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
                }
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

        protected void lnkPerfo_Click(object sender, EventArgs e)
        {
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            lnk_lblPerformance.Visible = true;
            Session["name"] = "lnkPerfo";
            performancedata();
            lts.Visible = false;
            lt.Visible = false;
            cust_name.Visible = false;
            lbl_Perfor_det.Visible = true;
            lbl_Perfor_det.Text = "";
            lblPerformance.Visible = true;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            //div5.Attributes["class"] = "hide";
            // div5.Visible = false;
            // div6.Visible = true;
            perchart();
            //div7.Visible = false;
            //div8.Visible = false;
            txtFromdate.Visible = true;
            txtTodate.Visible = true;
            btnGet.Visible = true;
            div_book.Visible = false;
            Panel9.Visible = false;
            div1.Visible = false;
            PieChart2.Visible = false;
            divebooking.Visible = false;

        }
        protected void divgrid_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Dis_Grid();

            Div3.Visible = true;
            panelservice.Visible = true;
            divgrid.Visible = true;

            panel8.Visible = true;

            int empid = Convert.ToInt32(Session["LoginEmpId"]);

            hid_cusid.Value = HttpUtility.HtmlDecode(divgrid.SelectedRow.Cells[3].Text);
            int index = divgrid.SelectedRow.RowIndex;
            Label customername = divgrid.Rows[index].FindControl("lbl_custname") as Label;
            CRequests.InnerText = customername.Text;

            // int index = divgrid.SelectedRow.RowIndex;
            //Label customername = divgrid.SelectedRow.FindControl("customer") as Label;
            //cust_name.Text = customername.Text;
            // dts = oustobj.GetLikecustomernamesales(customername);
            //if(dts.Rows.Count>0)
            //{
            //    dts.Rows[0]["customerid"].ToString();
            //}

            if (hid_cusid.Value != "")
            {
                dt = oustobj.getcreditexception(empid, Convert.ToInt32(hid_cusid.Value));
                DataTable ddt = new DataTable();
                // ddt.Columns.Add("SI");
                ddt.Columns.Add("Branch");
                ddt.Columns.Add("Product");
                ddt.Columns.Add("BL #");
                ddt.Columns.Add("Pol");
                ddt.Columns.Add("Pod");
                ddt.Columns.Add("exceptionon");
                DataRow dr;
                if (dt.Rows.Count > 0)
                {
                    dr = ddt.NewRow();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        ddt.Rows.Add();
                        // ddt.Rows[i]["SI"] = dt.Rows[i]["SI"];
                        ddt.Rows[i]["Branch"] = dt.Rows[i]["Branch"];
                        ddt.Rows[i]["Product"] = dt.Rows[i]["Product"];
                        ddt.Rows[i]["BL #"] = dt.Rows[i]["Blno"];
                        ddt.Rows[i]["Pol"] = dt.Rows[i]["Pol"];
                        ddt.Rows[i]["Pod"] = dt.Rows[i]["Pod"];
                        ddt.Rows[i]["exceptionon"] = dt.Rows[i]["exceptionon"];
                    }
                }
                griddata.DataSource = ddt;
                griddata.DataBind();

                CRequests.Visible = true;
                exempexcel.Visible = true;
                // btn_exempt.Enabled = true;
                panel8.Visible = true;

                griddata.Visible = true;
            }

        }

        protected void divgrid_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(divgrid, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void lnkCreditEx_Click(object sender, EventArgs e)
        {
            divebooking.Visible = false;
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            lbl_cust_name.Visible = false;
            lnk_div_book.Visible = false;
            divPerson.Visible = false;
            Dis_Grid();
            Get_ExCredEx();
            CRequests.InnerText = "";
            excl_export.Visible = false;
            exempexcel.Visible = false;
            lts.Visible = false;
            lt.Visible = false;
            excl_export.Visible = false;
            cust_name.Visible = false;
            //div5.Attributes["class"] = "hide";
            //div6.Attributes["class"] = "hide";
            //div5.Visible = false;
            // div6.Visible = false;
            //CRequests.Visible = false;
            quot.Visible = false;
            chartper.Visible = false;
            Panel9.Visible = false;
            lblBooking.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;
            Grid_workprogress.Visible = false;
            pnlJobAE.Visible = false;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            div_book.Visible = false;
            Div3.Visible = true;
            excl_export.Visible = false;
            lbl_Perfor_det.Visible = false;
            PieChart2.Visible = false;
            //div7.Visible = false;
            //div8.Visible = true;
        }

        protected void linkoust_Click(object sender, EventArgs e)
        {
            div_coll.Visible = false;
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            //divBooknew.Visible = false;
            //pnlTran.Visible = false;
            //grdTranNew.Visible = false;
            //cutnew.Visible = true;
            //pnlGrdCuswise.Visible = true;
            //GrdCuswise.Visible = true;
            //classDiv.Visible = false;
            //Panel1.Visible = false;
            //GridView1.Visible = false;
            //div1.Visible = false;
            //Panel4.Visible = false;
            //GrdBooking.Visible = false;
            lts.Visible = false;
            cust_name.Visible = false;
            lt.Visible = false;
            Session["name"] = "linkoust";
            pnlJobAE.Visible = false;
            lblBooking.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;
            Grid_workprogress.Visible = false;

            Dis_Grid();
            Panel9.Visible = false;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            div_book.Visible = false;
            workingprogess.Visible = false;
            WIP.Visible = false;
            chartper.Visible = false;
            lbl_Perfor_det.Visible = false;
            lnk_Perfor_det.Visible = true;
            PieChart2.Visible = true;
            get_out();
            outchart();
            //Chart1.Visible = true;
            //chartdiv.Visible = true;
            //div6.Attributes["class"] = "PendingRightnew";
            // div6.Visible = true;
            // div6.Visible = true;
            //  div5.Visible = true;
            //div7.Visible = false;
            //div8.Visible = false;
            divebooking.Visible = false;

        }

        protected void lnkcreditRequest_Click(object sender, EventArgs e)
        {
            divPerson.Visible = false;
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            lnk_div_book.Visible = false;
            div_out.Visible = false;
            Div3.Visible = false;
            cust_name.Visible = false;
            //creditexamption.Visible = false;
            Div4.Visible = true;
            Panel9.Visible = false;
            excl_export.Visible = false;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            lts.Visible = false;
            lt.Visible = false;
            chartper.Visible = false;
            WIP.Visible = false;
            workingprogess.Visible = false;
            quot.Visible = false;
            div_book.Visible = false;
            lblPerformance.Visible = false;
            lblQuation.Visible = false;
            quatatio_exce.Visible = false;
            PanelPendingEvent.Visible = false;
            lblPerformance.Visible = false;
            txtFromdate.Visible = false;
            txtTodate.Visible = false;
            btnGet.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            classDiv.Visible = false;
            div1.Visible = false;
            lbl_Perfor_det.Visible = false;
            excl_export.Visible = false;
            PieChart2.Visible = false;
            //div5.Visible = false;
            //div6.Visible = false;
            //div8.Visible = false;
            //div7.Visible = false;
            Get_creditapproval();
            divebooking.Visible = false;

        }

        public void Get_creditapproval()
        {

            DataTable dt_credit = new DataTable();
            dt_credit = mca.get_creditapproval_home(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginEmpId"]));
            Double requestamount = 0.00;
            Double Approvedamount = 0.00;

            if (dt_credit.Rows.Count > 0)
            {
                for (int i = 0; i <= dt_credit.Rows.Count - 1; i++)
                {
                    if (dt_credit.Rows[i]["creditamt"].ToString() == "")
                    {
                        requestamount = 0.00;

                    }
                    else
                    {

                        requestamount = Convert.ToDouble(dt_credit.Compute("sum(creditamt)", ""));
                    }
                    if (dt_credit.Rows[i]["bappamount"].ToString() == "")
                    {
                        Approvedamount = 0.00;

                    }
                    else
                    {

                        Approvedamount = Convert.ToDouble(dt_credit.Compute("sum(bappamount)", ""));
                    }
                }

                int count = dt_credit.Rows.Count;
                dt_credit.Rows.Add();
                dt_credit.Rows[count]["customername"] = "Total";
                dt_credit.Rows[count]["creditamt"] = requestamount;
                dt_credit.Rows[count]["bappamount"] = Approvedamount;
                grid_credit.DataSource = dt_credit;
                grid_credit.DataBind();
                if (grid_credit.Rows.Count > 0)
                {
                    grid_credit.Rows[grid_credit.Rows.Count - 1].Cells[1].ForeColor = System.Drawing.Color.Maroon;
                    grid_credit.Rows[grid_credit.Rows.Count - 1].Cells[3].ForeColor = System.Drawing.Color.Maroon;
                    grid_credit.Rows[grid_credit.Rows.Count - 1].Cells[6].ForeColor = System.Drawing.Color.Maroon;

                }

            }
            else
            {
                grid_credit.DataSource = new DataTable();
                grid_credit.DataBind();
            }
        }

        protected void grid_credit_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    double dbl_temp = 0;
                    //DateTime dt_temp;
                    //Label lblCustomer = (Label)e.Row.FindControl("creditreqon");
                    //Label lblCustomer4 = (Label)e.Row.FindControl("appon");
                    if (double.TryParse(e.Row.Cells[3].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[3].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                    }
                    //if (DateTime.TryParse(lblCustomer.Text, out dt_temp))
                    //{
                    //    e.Row.Cells[4].Attributes.CssStyle["text-align"] = "Right";
                    //}

                    if (double.TryParse(e.Row.Cells[6].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[6].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                    }
                    //if (DateTime.TryParse(lblCustomer4.Text, out dt_temp))
                    //{
                    //    e.Row.Cells[7].Attributes.CssStyle["text-align"] = "Right";
                    //}

                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " his.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = 
                Page.ClientScript.GetPostBackClientHyperlink(grid_credit, "Select$" +
                e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void link_booking_Click(object sender, EventArgs e)
        {
            div_coll.Visible = false;
            lnk_div_book.Visible = true;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            Dis_Grid();
            BookingDet();
            excl_export.Visible = false;
            cust_name.Visible = true;
            cust_name.Text = "";
            lblBooking.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;
            Grid_workprogress.Visible = false;
            pnlJobAE.Visible = false;
            pnlGrdCuswise.Visible = true;
            piechartbook.Visible = true;
            lbl_Perfor_det.Visible = false;
            bookchart();
            chartper.Visible = false;
            div_book.Visible = true;
            lt.Visible = false;
            lts.Visible = false;
            PieChart1.Visible = true;
            PieChart2.Visible = false;
            piechartbook.Visible = true;
            Pertitle.Visible = false;

            divebooking.Visible = false;
            //div5.Visible = false;
            //div6.Visible = false;
            //div8.Visible = false;
            //div7.Visible = true;

        }

        protected void lnkApproved_Click(object sender, EventArgs e)
        {
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            Dis_Grid();
            Get_quotation();
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            div_book.Visible = false;
            quot.Visible = true;
            lblQuation.Visible = true;
            quatatio_exce.Visible = true;
            lt.Visible = false;
            lts.Visible = false;
            Panel9.Visible = false;
            WIP.Visible = false;
            lbl_Perfor_det.Visible = false;
            excl_export.Visible = false;
            workingprogess.Visible = false;
            cust_name.Visible = false;
            div1.Visible = false;
            PieChart2.Visible = false;
            //div5.Visible = false;
            //div6.Visible = false;
            //div8.Visible = false;
            //div7.Visible = false;
            divebooking.Visible = false;
        }

        protected void lnkUnapp_Click(object sender, EventArgs e)
        {
            Dis_Grid();
            Get_quotation1();
            cust_name.Visible = false;
            quot.Visible = true;
            lbl_Perfor_det.Visible = false;
            divebooking.Visible = false;
        }

        protected void GrdBooking_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[8].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[8].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[8].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[10].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[10].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[10].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                if (e.Row.Cells[7].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {

                    if (e.Row.Cells[i].Text == "Amount")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Left";
                    }
                    if (e.Row.Cells[i].Text == "Overdue")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Left";
                    }
                    if (e.Row.Cells[i].Text == "Overduedays")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Left";
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "Amount")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[i].Text == "Overdue")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[i].Text == "Overduedays")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }

                }

            }

        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 10; i < e.Row.Cells.Count; i++)
                {

                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[i].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
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
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "Branch Name")
                    {
                        e.Row.Cells[i].Text = "Branch";
                    }
                    if (e.Row.Cells[i].Text == "Volume")
                    {
                        e.Row.Cells[i].Text = "M3/KGS";
                    }
                    if (e.Row.Cells[i].Text == "Quotation Customer")
                    {
                        e.Row.Cells[i].Text = "Customer";
                    }
                    if (e.Row.Cells[i].Text == "cont20")
                    {
                        e.Row.Cells[i].Text = "20";
                    }
                    if (e.Row.Cells[i].Text == "cont40")
                    {
                        e.Row.Cells[i].Text = "40";
                    }
                    if (e.Row.Cells[i].Text == "Expense")
                    {
                        e.Row.Cells[i].Text = "Expenses";
                    }
                }
            }

        }

        protected void btn_export_Click(object sender, EventArgs e)
        {

            string Str_Title;
            Str_Title = Session["LoginDivisionName"].ToString() + "-" + Session["LoginBranchName"].ToString();
            string Filename;
            Filename = "Performance details";
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
            if (GridView3.Rows.Count > 0)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xls");
                Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                int cnt = GridView3.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Filename + "</B></font></td></tr>");
                SB.Append("</table>");
                GridView3.GridLines = GridLines.Both;
                GridView3.HeaderStyle.Font.Bold = true;
                GridView3.RenderControl(HtmlTextWriter);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
                //string strtemp = "";
                //strtemp = Utility.Fn_ExportExcel(GridView3, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Str_Title + "</td></tr>");
                //// Response.Clear();
                //// Response.Buffer = true;
                //// Response.AddHeader("content-disposition", "attachment;filename=Pending Voucher.xls");
                ////// Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(Filename));
                //// Response.Charset = "";
                //// Response.ContentType = "application/vnd.xls";
                //// Response.Write(strtemp);
                //// Response.Flush();
                //// Response.End();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=Pending Vouche.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.xls";
                //System.IO.StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //Response.Write(strtemp);
                //Response.End();

            }

        }

        protected void linkworkprogess_Click(object sender, EventArgs e)
        {

            divebooking.Visible = false;
            div_coll.Visible = false;

            lnk_div_book.Visible = false;

            lblBooking.Visible = false;
            lbl_cust_name.Visible = false;

            Pertitle.Visible = true;
            Dis_Grid();
            cust_name.Visible = false;
            lts.Visible = false;
            lt.Visible = false;
            excl_export.Visible = false;
            div_out.Visible = false;
            div1.Visible = false;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            div_book.Visible = false;
            chartper.Visible = false;
            lbl_Perfor_det.Visible = false;
            PieChart2.Visible = false;
            // div5.Visible = false;
            // div6.Visible = false;
            Panel9.Visible = true;
            workingprogess.Visible = true;
            WIP.Visible = true;
            PieChart1.Visible = false;
            piechartbook.Visible = false;
            dt = Buyobj.Getworkinprogess(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]));
            int count = dt.Rows.Count;
            Double sell = 0;
            Double Buy = 0;
            Double amount = 0;
            if (dt.Rows.Count > 0)
            {

                sell = Convert.ToDouble(dt.Compute("sum(Sell)", ""));
                Buy = Convert.ToDouble(dt.Compute("sum(Buy)", ""));
                amount = Convert.ToDouble(dt.Compute("sum(AMOUNT)", ""));
            }
            dt.Rows.Add();
            dt.Rows[count][5] = "Total";
            dt.Rows[count][6] = sell.ToString("#,0.00");
            dt.Rows[count][7] = Buy.ToString("#,0.00");
            dt.Rows[count][8] = amount.ToString("#,0.00");
            Grid_workprogress.DataSource = dt;
            Grid_workprogress.DataBind();
            if (Grid_workprogress.Rows.Count > 0)
            {
                Grid_workprogress.Rows[Grid_workprogress.Rows.Count - 1].Cells[5].ForeColor = System.Drawing.Color.Maroon;
                Grid_workprogress.Rows[Grid_workprogress.Rows.Count - 1].Cells[6].ForeColor = System.Drawing.Color.Maroon;
                Grid_workprogress.Rows[Grid_workprogress.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                Grid_workprogress.Rows[Grid_workprogress.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
            }
            Grid_workprogress.Visible = true;
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            if (GridView2.Rows.Count > 0)
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grdOutStanding.GridLines = GridLines.Both;
                //grdOutStanding.HeaderStyle.Font.Bold = true;
                //grdOutStanding.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();

                string filename = "";
                filename = "OutStandingWise";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                GridView2.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                GridView2.GridLines = GridLines.Both;
                GridView2.HeaderStyle.Font.Bold = true;
                GridView2.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }

        }

        protected void btn_exempt_Click(object sender, EventArgs e)
        {
            if (griddata.Rows.Count > 0)
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grdOutStanding.GridLines = GridLines.Both;
                //grdOutStanding.HeaderStyle.Font.Bold = true;
                //grdOutStanding.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                griddata.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                griddata.GridLines = GridLines.Both;
                griddata.HeaderStyle.Font.Bold = true;
                griddata.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void btn_creditrequest_Click(object sender, EventArgs e)
        {
            if (grid_credit.Rows.Count > 0)
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grdOutStanding.GridLines = GridLines.Both;
                //grdOutStanding.HeaderStyle.Font.Bold = true;
                //grdOutStanding.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=VoucherwiseDetails.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                grid_credit.AllowPaging = false;
                //  Grdincomnotbooked();
                //get_out();

                grid_credit.GridLines = GridLines.Both;
                grid_credit.HeaderStyle.Font.Bold = true;
                grid_credit.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void Grid_workprogress_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[6].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[6].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[6].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[7].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[7].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[7].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[8].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[8].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[8].Attributes.CssStyle["text-align"] = "Right";
                    }

                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " his.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = 
                Page.ClientScript.GetPostBackClientHyperlink(Grid_workprogress, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void quatatio_exce_Click(object sender, EventArgs e)
        {
            if (grdQuatotion.Rows.Count > 0)
            {
                string Filename = "";
                Filename = "Quatotion";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                grdQuatotion.GridLines = GridLines.Both;
                grdQuatotion.HeaderStyle.Font.Bold = true;
                grdQuatotion.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void exempexcel_Click(object sender, EventArgs e)
        {
            if (griddata.Rows.Count > 0)
            {
                string Filename = "";
                Filename = "Credit Exemption";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                griddata.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                griddata.GridLines = GridLines.Both;
                griddata.HeaderStyle.Font.Bold = true;
                griddata.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void credit_excel_Click(object sender, EventArgs e)
        {
            if (grid_credit.Rows.Count > 0)
            {
                string Filename = "";
                Filename = "Credit Request";
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                grid_credit.AllowPaging = false;
                //  Grdincomnotbooked();
                //get_out();

                grid_credit.GridLines = GridLines.Both;
                grid_credit.HeaderStyle.Font.Bold = true;
                grid_credit.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void excportexc_Click(object sender, EventArgs e)
        {
            if (GridView2.Rows.Count > 0)
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grdOutStanding.GridLines = GridLines.Both;
                //grdOutStanding.HeaderStyle.Font.Bold = true;
                //grdOutStanding.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();
                string Filename = "";
                Filename = "OutstandingWise";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=OutstandingWise.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                GridView2.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                GridView2.GridLines = GridLines.Both;
                GridView2.HeaderStyle.Font.Bold = true;
                GridView2.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }
        }

        protected void creditexamption_Click(object sender, EventArgs e)
        {

        }

        protected void workingprogess_Click(object sender, EventArgs e)
        {
            if (Grid_workprogress.Rows.Count > 0)
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grdOutStanding.GridLines = GridLines.Both;
                //grdOutStanding.HeaderStyle.Font.Bold = true;
                //grdOutStanding.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();
                string Filename = "";
                Filename = "Working Progess";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                Grid_workprogress.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                Grid_workprogress.GridLines = GridLines.Both;
                Grid_workprogress.HeaderStyle.Font.Bold = true;
                Grid_workprogress.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            string trantype_process = "AC";
            DataTable dtuser = new DataTable();

            if (trantype_process == "AC")
            {
                /*dtuser = obj_UP.GetFormwiseuserRights(66, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                    Response.Redirect("../ForwardExports/Costing.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                }*/

                Response.Redirect("../ForwardExports/Costing.aspx");
            }

            /* if (trantype_process == "FI")
             {
                 dtuser = obj_UP.GetFormwiseuserRights(67, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                 if (dtuser.Rows.Count > 0)
                 {

                     //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                     Response.Redirect("../ForwardExports/Costing.aspx");

                 }
                 else
                 {
                     string message = "No Rights";
                     ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                 }
             }

             if (trantype_process == "AE")
             {
                 dtuser = obj_UP.GetFormwiseuserRights(68, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                 if (dtuser.Rows.Count > 0)
                 {

                     //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                     Response.Redirect("../ForwardExports/Costing.aspx");

                 }
                 else
                 {
                     string message = "No Rights";
                     ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                 }
             }

             if (trantype_process == "AI")
             {
                 dtuser = obj_UP.GetFormwiseuserRights(69, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
                 if (dtuser.Rows.Count > 0)
                 {

                     //Response.Redirect("../ForwardExports/CostingDetails.aspx");

                     Response.Redirect("../ForwardExports/Costing.aspx");

                 }
                 else
                 {
                     string message = "No Rights";
                     ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

                 }
             }*/
        }

        protected void crdexp_Click(object sender, EventArgs e)
        {
            /*if (divgrid.Rows.Count > 0)
            {
              
                string Filename = "";
                Filename = "Credit Exemption";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Credit Exemption.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                divgrid.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                divgrid.GridLines = GridLines.Both;
                divgrid.HeaderStyle.Font.Bold = true;
                divgrid.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }*/

            DataTable dt_check = ViewState["divgridexp2ex"] as DataTable;
            if (divgrid.Rows.Count > 0)
            {

                /* dt_check.Columns.Remove("customerid");
                 using (XLWorkbook wb = new XLWorkbook())
                 {
                     //wb.Worksheets.Add("test");

                     wb.Worksheets.Add(dt_check);

                     Response.Clear();
                     Response.Buffer = true;
                     Response.Charset = "";
                     Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                     Response.AddHeader("content-disposition", "attachment;filename=Credit Exemption.xls");
                     using (MemoryStream MyMemoryStream = new MemoryStream())
                     {
                         wb.SaveAs(MyMemoryStream);
                         MyMemoryStream.WriteTo(Response.OutputStream);
                         Response.Flush();
                         Response.End();
                     }
                 }*/

                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Credit Exemption.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (divgrid.Visible == true)
                {
                    divgrid.GridLines = GridLines.Both;
                    divgrid.HeaderStyle.Font.Bold = true;
                    divgrid.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();

            }

        }

        protected void lnk_Perfor_det_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["grdOutStandingexp2ex"] as DataTable;
            /*if (grdOutStanding.Rows.Count > 0)
            {
                //Response.Clear();
                //Response.Buffer = true;
                //Response.AddHeader("content-disposition", "attachment;filename=oustanding.xls");
                //Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                //StringWriter StringWriter = new System.IO.StringWriter();
                //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                //grdOutStanding.GridLines = GridLines.Both;
                //grdOutStanding.HeaderStyle.Font.Bold = true;
                //grdOutStanding.RenderControl(HtmlTextWriter);
                //Response.Write(StringWriter.ToString());
                //Response.End();
                string Filename = "";
                Filename = "OutStanding";

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=OutStanding.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringWriter StringWriter = new System.IO.StringWriter();
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                grdOutStanding.AllowPaging = false;
                //  Grdincomnotbooked();
                // get_out();

                grdOutStanding.GridLines = GridLines.Both;
                grdOutStanding.HeaderStyle.Font.Bold = true;
                grdOutStanding.RenderControl(HtmlTextWriter);
                Response.Write(StringWriter.ToString());
                Response.End();
            }*/
            if (grdOutStanding.Rows.Count > 0)
            {

                /* dt_check.Columns.Remove("custid");
                 using (XLWorkbook wb = new XLWorkbook())
                 {
                     //wb.Worksheets.Add("test");

                     wb.Worksheets.Add(dt_check);

                     Response.Clear();
                     Response.Buffer = true;
                     Response.Charset = "";
                     Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                     Response.AddHeader("content-disposition", "attachment;filename=OutStanding.xls");
                     using (MemoryStream MyMemoryStream = new MemoryStream())
                     {
                         wb.SaveAs(MyMemoryStream);
                         MyMemoryStream.WriteTo(Response.OutputStream);
                         Response.Flush();
                         Response.End();
                     }
                 }*/

                //string Filename = "";
                //Filename = "OutStanding";

                /* Response.Clear();
                 Response.Buffer = true;
                 Response.AddHeader("content-disposition", "attachment;filename=OutStanding.xls");
                 Response.Charset = "";
                 Response.ContentType = "application/vnd.xls";
                 StringWriter StringWriter = new System.IO.StringWriter();
                 HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                 grdOutStanding.Columns[2].Visible = false;
                 grdOutStanding.AllowPaging = false;
                 //  Grdincomnotbooked();
                 // get_out();

                 grdOutStanding.GridLines = GridLines.Both;
                 grdOutStanding.HeaderStyle.Font.Bold = true;
                 grdOutStanding.RenderControl(HtmlTextWriter);
                 Response.Write(StringWriter.ToString());
                 Response.End();*/

                /* Response.Clear();
                 Response.Buffer = true;
                 Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                 Response.Charset = "";
                 Response.ContentType = "application/vnd.ms-excel";
                 using (StringWriter sw = new StringWriter())
                 {
                     HtmlTextWriter hw = new HtmlTextWriter(sw);

                     //To Export all pages
                     grdOutStanding.AllowPaging = false;
                     this.get_out();

                     //Response.AddHeader.BackColor = Color.WHITE;
                     foreach (TableCell cell in grdOutStanding.HeaderRow.Cells)
                     {
                         cell.BackColor = grdOutStanding.HeaderStyle.BackColor;
                     }
                     foreach (GridViewRow row in grdOutStanding.Rows)
                     {
                         // row.BackColor = Color.WHITE;
                         foreach (TableCell cell in row.Cells)
                         {
                             if (row.RowIndex % 2 == 0)
                             {
                                 cell.BackColor = grdOutStanding.AlternatingRowStyle.BackColor;
                             }
                             else
                             {
                                 cell.BackColor = grdOutStanding.RowStyle.BackColor;
                             }
                             cell.CssClass = "textmode";
                             List<Control> controls = new List<Control>();

                             //Add controls to be removed to Generic List
                             foreach (Control control in cell.Controls)
                             {
                                 controls.Add(control);
                             }

                             //Loop through the controls to be removed and replace then with Literal
                             foreach (Control control in controls)
                             {
                                 switch (control.GetType().Name)
                                 {
                                     case "HyperLink":
                                         cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                         break;
                                     case "TextBox":
                                         cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                         break;
                                     case "LinkButton":
                                         cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                         break;
                                     case "CheckBox":
                                         cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                         break;
                                     case "RadioButton":
                                         cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                         break;
                                 }
                                 cell.Controls.Remove(control);
                             }
                         }
                     }

                     Response.RenderControl(hw);

                     //style to format numbers to string
                     string style = @"<style> .textmode { } </style>";
                     Response.Write(style);
                     Response.Output.Write(sw.ToString());
                     Response.Flush();
                     Response.End();

                 }*/

                /*     Response.Clear();
                     Response.Buffer = true;
                     Response.AddHeader("content-disposition", "attachment;filename=OutStanding.xls");
                     Response.Charset = "";
                     Response.ContentType = "application/text";

                     //To Export all pages
                     grdOutStanding.AllowPaging = false;
                     this.get_out();

                     StringBuilder sb = new StringBuilder();
                     for (int k = 0; k < grdOutStanding.Columns.Count; k++)
                     {
                         sb.Append(grdOutStanding.Columns[k].HeaderText + ',');
                     }
                     sb.Append("\r\n");
                     foreach (GridViewRow row in grdOutStanding.Rows)
                     {

                         foreach (TableCell cell in row.Cells)
                         {
                             string text = "";
                             if (cell.Controls.Count > 0)
                             {
                                 foreach (Control control in cell.Controls)
                                 {
                                     switch (control.GetType().Name)
                                     {
                                         case "HyperLink":
                                             text = (control as HyperLink).Text;
                                             break;
                                         case "TextBox":
                                             text = (control as TextBox).Text;
                                             break;
                                         case "LinkButton":
                                             text = (control as LinkButton).Text;
                                             break;
                                         case "Button":
                                             text = (control as Button).Text;
                                             break;
                                         case "CheckBox":
                                             text = (control as CheckBox).Text;
                                             break;
                                         case "RadioButton":
                                             text = (control as RadioButton).Text;
                                             break;
                                         case "Label":
                                             text = (control as Label).Text;
                                             break;
                                     }
                                 }
                             }
                             else
                             {
                                 text = cell.Text;
                             }
                             sb.Append(text + ',');
                         }
                         sb.Append("\r\n");

                     }
                     Response.Output.Write(sb.ToString());
                     Response.Flush();
                     Response.End();

                     */

                /*grdOutStanding.AllowSorting = false;
                grdOutStanding.AllowPaging = false;
                this.get_out();
                EnableViewState = false;
                Response.Clear();
                DataTable dt2 = new DataTable("GridView1");
                foreach (TableCell cell in grdOutStanding.HeaderRow.Cells)
                {
                    dt2.Columns.Add(cell.Text);
                }
                foreach (GridViewRow row in grdOutStanding.Rows)
                {
                    dt2.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(row.Cells[i].Text))
                        {
                            dt2.Rows[dt2.Rows.Count - 1][i] = row.Cells[i].Text;
                        }
                        else
                        {
                            List<Control> controls = new List<Control>();
                            foreach (Control control in row.Cells[i].Controls)
                            {
                                controls.Add(control);
                            }
                            foreach (Control control in controls)
                            {
                                switch (control.GetType().Name)
                                {
                                    case "Label":
                                        string label = (control as Label).Text;
                                        dt2.Rows[dt2.Rows.Count - 1][i] = label;
                                        break;
                                    case "TextBox":
                                        string textbox = (control as TextBox).Text;
                                        dt2.Rows[dt2.Rows.Count - 1][i] = textbox;
                                        break;
                                    case "HyperLink":
                                        string hyperLink = (control as HyperLink).Text;
                                        dt2.Rows[dt2.Rows.Count - 1][i] = hyperLink;
                                        break;
                                    case "LinkButton":
                                        string linkButton = (control as LinkButton).Text;
                                        dt2.Rows[dt2.Rows.Count - 1][i] = linkButton;
                                        break;
                                    case "CheckBox":
                                        string checkBox = (control as CheckBox).Text;
                                        dt2.Rows[dt2.Rows.Count - 1][i] = checkBox;
                                        break;
                                    case "RadioButton":
                                        string radioButton = (control as RadioButton).Text;
                                        dt2.Rows[dt2.Rows.Count - 1][i] = radioButton;
                                        break;
                                }
                                row.Cells[i].Controls.Remove(control);
                            }
                        }
                    }
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt2);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=OutStanding.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
                */

                Response.ClearContent();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "oustanding.xls"));
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grdOutStanding.AllowPaging = false;
                //   GVProsFill();
                grdOutStanding.HeaderRow.Style.Add("background-color", "#FFFFFF");
                grdOutStanding.Columns[2].Visible = false;
                for (int a = 0; a < grdOutStanding.HeaderRow.Cells.Count; a++)
                {
                    grdOutStanding.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
                }
                int j = 1;
                foreach (GridViewRow gvrow in grdOutStanding.Rows)
                {
                    // gvrow.BackColor = Color.WHITE;
                    if (j <= grdOutStanding.Rows.Count)
                    {
                        if (j % 2 != 0)
                        {
                            for (int k = 0; k < gvrow.Cells.Count; k++)
                            {
                                gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                            }
                        }
                    }
                    j++;
                }
                grdOutStanding.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();

            }

        }

        protected void lnk_lblPerformance_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GrdSalesPerformanceexp2exc"] as DataTable;
            if (GrdSalesPerformance.Rows.Count > 0)
            {
                /*  using (XLWorkbook wb = new XLWorkbook())
                  {
                      //wb.Worksheets.Add("test");

                      wb.Worksheets.Add(dt_check);

                      Response.Clear();
                      Response.Buffer = true;
                      Response.Charset = "";
                      Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                      Response.AddHeader("content-disposition", "attachment;filename=SalesPerformance.xls");
                      using (MemoryStream MyMemoryStream = new MemoryStream())
                      {
                          wb.SaveAs(MyMemoryStream);
                          MyMemoryStream.WriteTo(Response.OutputStream);
                          Response.Flush();
                          Response.End();
                      }
                  }*/
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=SalesPerformance.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (GrdSalesPerformance.Visible == true)
                {
                    GrdSalesPerformance.GridLines = GridLines.Both;
                    GrdSalesPerformance.HeaderStyle.Font.Bold = true;
                    GrdSalesPerformance.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();

            }

        }

        protected void excl_export_Click(object sender, EventArgs e)
        {
            /* string Str_Title;
             Str_Title = Session["LoginDivisionName"].ToString() + "-" + Session["LoginBranchName"].ToString();
             string Filename;
             Filename = "Performance details";
             StringBuilder SB = new StringBuilder();
             StringWriter StringWriter = new System.IO.StringWriter(SB);
             HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
             if (GridView3.Rows.Count > 0)
             {
                 Response.Clear();
                 Response.AddHeader("content-disposition", "attachment;filename=" + Filename + ".xls");
                 Response.Charset = "";
                 //Response.ContentType = "application/vnd.ms-excel";
                 Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                 int cnt = GridView3.Columns.Count;
                 SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Filename + "</B></font></td></tr>");
                 SB.Append("</table>");
                 GridView3.GridLines = GridLines.Both;
                 GridView3.HeaderStyle.Font.Bold = true;
                 GridView3.RenderControl(HtmlTextWriter);
                 string style = @"<style> .textmode { } </style>";
                 Response.Write(style);
                 Response.Output.Write(StringWriter.ToString());
                 Response.Flush();
                 Response.End();
                 //string strtemp = "";
                 //strtemp = Utility.Fn_ExportExcel(GridView3, "<tr><td></td><td><FONT FACE=arial SIZE=2>" + Filename + "</td></tr><tr><td></td><td></td><td><FONT FACE=arial SIZE=2>" + Str_Title + "</td></tr>");
                 //// Response.Clear();
                 //// Response.Buffer = true;
                 //// Response.AddHeader("content-disposition", "attachment;filename=Pending Voucher.xls");
                 ////// Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(Filename));
                 //// Response.Charset = "";
                 //// Response.ContentType = "application/vnd.xls";
                 //// Response.Write(strtemp);
                 //// Response.Flush();
                 //// Response.End();
                 //Response.Buffer = true;
                 //Response.AddHeader("content-disposition", "attachment;filename=Pending Vouche.xls");
                 //Response.Charset = "";
                 //Response.ContentType = "application/vnd.xls";
                 //System.IO.StringWriter StringWriter = new System.IO.StringWriter();
                 //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                 //Response.Write(strtemp);
                 //Response.End();

             }*/
            DataTable dt_check = ViewState["GridView3exp2exc"] as DataTable;
            if (GridView3.Rows.Count > 0)
            {
                /*  using (XLWorkbook wb = new XLWorkbook())
                  {
                      //wb.Worksheets.Add("test");

                      wb.Worksheets.Add(dt_check);

                      Response.Clear();
                      Response.Buffer = true;
                      Response.Charset = "";
                      Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                      Response.AddHeader("content-disposition", "attachment;filename=Performance details.xls");
                      using (MemoryStream MyMemoryStream = new MemoryStream())
                      {
                          wb.SaveAs(MyMemoryStream);
                          MyMemoryStream.WriteTo(Response.OutputStream);
                          Response.Flush();
                          Response.End();
                      }
                  }*/

                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Performance details.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (GridView3.Visible == true)
                {
                    GridView3.GridLines = GridLines.Both;
                    GridView3.HeaderStyle.Font.Bold = true;
                    GridView3.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();

            }

        }

        protected void lnk_div_book_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GrdCuswiseexp2exc"] as DataTable;
            if (GrdCuswise.Rows.Count > 0)
            {
                /* using (XLWorkbook wb = new XLWorkbook())
                 {
                     //wb.Worksheets.Add("test");
                     dt_check.Columns.Remove("cusid");
                     wb.Worksheets.Add(dt_check);

                     Response.Clear();
                     Response.Buffer = true;
                     Response.Charset = "";
                     Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                     Response.AddHeader("content-disposition", "attachment;filename=Performance details.xls");
                     using (MemoryStream MyMemoryStream = new MemoryStream())
                     {
                         wb.SaveAs(MyMemoryStream);
                         MyMemoryStream.WriteTo(Response.OutputStream);
                         Response.Flush();
                         Response.End();
                     }
                 }*/

                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Performance details.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (GrdCuswise.Visible == true)
                {
                    GrdCuswise.GridLines = GridLines.Both;
                    GrdCuswise.HeaderStyle.Font.Bold = true;
                    GrdCuswise.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void lbl_cust_name_Click(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["GridView1exp2exc"] as DataTable;
            if (GridView1.Rows.Count > 0)
            {
                /* using (XLWorkbook wb = new XLWorkbook())
                 {
                     //wb.Worksheets.Add("test");

                     wb.Worksheets.Add(dt_check);

                     Response.Clear();
                     Response.Buffer = true;
                     Response.Charset = "";
                     Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                     Response.AddHeader("content-disposition", "attachment;filename=Performance details.xls");
                     using (MemoryStream MyMemoryStream = new MemoryStream())
                     {
                         wb.SaveAs(MyMemoryStream);
                         MyMemoryStream.WriteTo(Response.OutputStream);
                         Response.Flush();
                         Response.End();
                     }
                 }*/

                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Performance details.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (GridView1.Visible == true)
                {
                    GridView1.GridLines = GridLines.Both;
                    GridView1.HeaderStyle.Font.Bold = true;
                    GridView1.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Maintenance/processimages.aspx");
        }

        protected void overdueamt_Click(object sender, EventArgs e)
        {
            GridView2.Columns[10].Visible = true;
            GridView2.Columns[11].Visible = true;
            GridView2.Columns[8].Visible = false;
            GridView2.Columns[9].Visible = false;
            PieChart2.Visible = false;
            string customername = "";
            string str_SelFormula = "";
            int index;
            if (grdOutStanding.Rows.Count > 0)
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                index = Convert.ToInt32(row.RowIndex);
                // index = grdOutStanding.SelectedRow.RowIndex;
                Label lbl = (grdOutStanding.Rows[index].Cells[1].FindControl("customer") as Label);
                customername = lbl.Text;
                Label2.Text = lbl.Text;
                Session["OutStndingCustomerName"] = customername.ToString();
            }
            if (customername == "Total")
            {
                customername = "";
            }
            int s = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int d = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            string empname = empobj.GetEmployeeName(s);
            int time = Logobj.GetDate().Hour;
            if (time < 13)
            {
                dt = outobj.OpsOutStdingGET(99999, d, s);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outobj.OpsOutStdingGET12N(99999, d, s);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outobj.OpsOutStdingGET3PM(99999, d, s);
            }
            int tot = 0;
            if (customername != "")
            {
                if (customername != "ALL")
                {
                    if (str_SelFormula != "")
                    {
                        str_SelFormula = str_SelFormula + " and customer =  '" + customername + "' and overduedays >" + tot;
                    }
                    else
                    {
                        str_SelFormula = "customer like  '" + customername + "' and overduedays >" + tot;
                    }
                }
            }
            else
            {
                str_SelFormula = "overduedays >" + tot;

            }

            DataView dt_ldg = new DataView(dt);
            if (str_SelFormula != "")
            {
                dt_ldg.RowFilter = str_SelFormula;

            }
            DataTable dt2 = new DataTable();
            dt2 = dt_ldg.ToTable();
            if (dt2.Rows.Count > 0)
            {
                DataRow dr2 = dt2.NewRow();
                dr2["refno"] = "Total";
                //  Double amount = Convert.ToDouble(dt2.Compute("sum(amount)", ""));
                Double overdue = Convert.ToDouble(dt2.Compute("sum(overdue)", ""));
                // Double famount = Convert.ToDouble(dt2.Compute("sum(famount)", ""));
                Double foverdue = Convert.ToDouble(dt2.Compute("sum(foverdue)", ""));
                // dr2["amount"] = amount.ToString("#,0.00") + "";
                dr2["overdue"] = overdue.ToString("#,0.00") + "";
                //dr2["famount"] = famount.ToString("#,0.00") + "";
                dr2["foverdue"] = foverdue.ToString("#,0.00") + "";

                //dr2["amount"] = dt2.Compute("sum(amount)", "");
                //dr2["overdue"] = dt2.Compute("sum(overdue)", "");
                //dr2["famount"] = dt2.Compute("sum(famount)", "");
                //dr2["foverdue"] = dt2.Compute("sum(foverdue)", "");

                dt2.Rows.Add(dr2);
            }
            Panel7.Visible = true;
            GridView2.Visible = true;
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            if (GridView2.Rows.Count > 0)
            {
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
            }

            Chart1.Visible = false;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            Panel6.Visible = false;
            GridView3.Visible = false;

        }

        protected void totalamt_Click(object sender, EventArgs e)
        {
            GridView2.Columns[8].Visible = true;
            GridView2.Columns[9].Visible = true;
            GridView2.Columns[10].Visible = true;
            GridView2.Columns[11].Visible = true;
            PieChart2.Visible = false;
            string customername = "";
            string str_SelFormula = "";
            int index;
            if (grdOutStanding.Rows.Count > 0)
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                index = Convert.ToInt32(row.RowIndex);
                // index = grdOutStanding.SelectedRow.RowIndex;
                Label lbl = (grdOutStanding.Rows[index].Cells[1].FindControl("customer") as Label);
                customername = lbl.Text;
                Label2.Text = lbl.Text;
                Session["OutStndingCustomerName"] = customername.ToString();
            }
            if (customername == "Total")
            {
                customername = "";
            }
            int s = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int d = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            string empname = empobj.GetEmployeeName(s);
            int time = Logobj.GetDate().Hour;
            if (time < 13)
            {
                dt = outobj.OpsOutStdingGET(99999, d, s);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outobj.OpsOutStdingGET12N(99999, d, s);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outobj.OpsOutStdingGET3PM(99999, d, s);
            }
            int tot = 0;
            if (customername != "")
            {
                if (customername != "ALL")
                {
                    if (str_SelFormula != "")
                    {
                        str_SelFormula = str_SelFormula + " and customer =  '" + customername + "'";
                    }
                    else
                    {
                        str_SelFormula = "customer like  '" + customername + "'";
                    }
                }
            }
            DataView dt_ldg = new DataView(dt);
            if (str_SelFormula != "")
            {
                dt_ldg.RowFilter = str_SelFormula;
            }
            DataTable dt2 = new DataTable();
            dt2 = dt_ldg.ToTable();
            if (dt2.Rows.Count > 0)
            {
                DataRow dr2 = dt2.NewRow();
                dr2["refno"] = "Total";
                Double amount = Convert.ToDouble(dt2.Compute("sum(amount)", ""));
                Double overdue = Convert.ToDouble(dt2.Compute("sum(overdue)", ""));
                Double famount = Convert.ToDouble(dt2.Compute("sum(famount)", ""));
                Double foverdue = Convert.ToDouble(dt2.Compute("sum(foverdue)", ""));
                dr2["amount"] = amount.ToString("#,0.00") + "";
                dr2["overdue"] = overdue.ToString("#,0.00") + "";
                dr2["famount"] = famount.ToString("#,0.00") + "";
                dr2["foverdue"] = foverdue.ToString("#,0.00") + "";

                //dr2["amount"] = dt2.Compute("sum(amount)", "");
                //dr2["overdue"] = dt2.Compute("sum(overdue)", "");
                //dr2["famount"] = dt2.Compute("sum(famount)", "");
                //dr2["foverdue"] = dt2.Compute("sum(foverdue)", "");

                dt2.Rows.Add(dr2);
            }
            Panel7.Visible = true;
            GridView2.Visible = true;
            GridView2.DataSource = dt2;
            GridView2.DataBind();
            if (GridView2.Rows.Count > 0)
            {
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
            }

            Chart1.Visible = false;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;

            Panel6.Visible = false;
            GridView3.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
        }

        protected void amount_Click(object sender, EventArgs e)
        {
            div_coll.Visible = false;
            GridView2.Columns[8].Visible = true;
            GridView2.Columns[9].Visible = true;
            GridView2.Columns[10].Visible = false;
            GridView2.Columns[11].Visible = false;
            PieChart2.Visible = false;
            string customername = "";
            string str_SelFormula = "";
            int index;
            if (grdOutStanding.Rows.Count > 0)
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                index = Convert.ToInt32(row.RowIndex);
                // index = grdOutStanding.SelectedRow.RowIndex;
                Label lbl = (grdOutStanding.Rows[index].Cells[1].FindControl("customer") as Label);
                customername = lbl.Text;
                Label2.Text = lbl.Text;
                Session["OutStndingCustomerName"] = customername.ToString();
            }
            if (customername == "Total")
            {
                customername = "";
            }
            int s = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int d = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            string empname = empobj.GetEmployeeName(s);
            int time = Logobj.GetDate().Hour;
            if (time < 13)
            {
                dt = outobj.OpsOutStdingGET(99999, d, s);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outobj.OpsOutStdingGET12N(99999, d, s);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outobj.OpsOutStdingGET3PM(99999, d, s);
            }
            int tot = 0;
            if (customername != "")
            {
                if (customername != "ALL")
                {
                    if (str_SelFormula != "")
                    {
                        str_SelFormula = "customer like  '" + customername + "' and overduedays <=" + tot;

                    }
                    else
                    {
                        str_SelFormula = "customer like  '" + customername + "'and overduedays <=" + tot;

                    }
                }
            }
            else
            {
                {
                    str_SelFormula = "overduedays <=" + tot;

                }
            }
            DataView dt_ldg = new DataView(dt);
            if (str_SelFormula != "")
            {
                dt_ldg.RowFilter = str_SelFormula;
            }
            DataTable dt2 = new DataTable();
            dt2 = dt_ldg.ToTable();
            if (dt2.Rows.Count > 0)
            {
                DataRow dr2 = dt2.NewRow();
                dr2["refno"] = "Total";
                Double amount = Convert.ToDouble(dt2.Compute("sum(amount)", ""));
                //  Double overdue = Convert.ToDouble(dt2.Compute("sum(overdue)", ""));
                Double famount = Convert.ToDouble(dt2.Compute("sum(famount)", ""));
                // Double foverdue = Convert.ToDouble(dt2.Compute("sum(foverdue)", ""));
                dr2["amount"] = amount.ToString("#,0.00") + "";
                // dr2["overdue"] = overdue.ToString("#,0.00") + "";
                dr2["famount"] = famount.ToString("#,0.00") + "";
                //  dr2["foverdue"] = foverdue.ToString("#,0.00") + "";

                //dr2["amount"] = dt2.Compute("sum(amount)", "");
                //dr2["overdue"] = dt2.Compute("sum(overdue)", "");
                //dr2["famount"] = dt2.Compute("sum(famount)", "");
                //dr2["foverdue"] = dt2.Compute("sum(foverdue)", "");

                dt2.Rows.Add(dr2);
            }
            Panel7.Visible = true;
            GridView2.Visible = true;
            GridView2.DataSource = dt2;

            GridView2.DataBind();
            if (GridView2.Rows.Count > 0)
            {
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                GridView2.Rows[GridView2.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
            }

            Chart1.Visible = false;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;

            Panel6.Visible = false;
            GridView3.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
        }

        protected void lnk_collectionAdvise_Click(object sender, EventArgs e)
        {
            divebooking.Visible = false;
            Div2.Visible = false;
            Div3.Visible = false;
            lbl_cust_name.Visible = false;
            lnk_div_book.Visible = false;
            divPerson.Visible = false;
            Dis_Grid();
            CRequests.InnerText = "";
            excl_export.Visible = false;
            exempexcel.Visible = false;
            lts.Visible = false;
            lt.Visible = false;
            excl_export.Visible = false;
            cust_name.Visible = false;
            //div5.Attributes["class"] = "hide";
            //div6.Attributes["class"] = "hide";
            //div5.Visible = false;
            // div6.Visible = false;
            //CRequests.Visible = false;
            quot.Visible = false;
            chartper.Visible = false;
            Panel9.Visible = false;
            lblBooking.Visible = false;
            div1.Visible = false;
            Panel4.Visible = false;
            GrdBooking.Visible = false;
            Grid_workprogress.Visible = false;
            pnlJobAE.Visible = false;
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            div_book.Visible = false;
            Div3.Visible = true;
            excl_export.Visible = false;
            lbl_Perfor_det.Visible = false;
            PieChart2.Visible = false;

            div_coll.Visible = true;
            Pertitle.Visible = false;
            PanelCollection.Visible = true;
            Grd_collection.Visible = true;
            Grd_collection.Columns[10].Visible = true;
            Grd_collection.Columns[11].Visible = true;
            Grd_collection.Columns[8].Visible = false;
            Grd_collection.Columns[9].Visible = false;
            PieChart2.Visible = false;
            string customername = "";
            string str_SelFormula = "";
            int index;
            //if (grdOutStanding.Rows.Count > 0)
            //{
            //    LinkButton btn = (LinkButton)sender;
            //    GridViewRow row = (GridViewRow)btn.NamingContainer;
            //    index = Convert.ToInt32(row.RowIndex);
            //    // index = grdOutStanding.SelectedRow.RowIndex;
            //    Label lbl = (grdOutStanding.Rows[index].Cells[1].FindControl("customer") as Label);
            //    customername = lbl.Text;
            //    Label2.Text = lbl.Text;
            //    Session["OutStndingCustomerName"] = customername.ToString();
            //}
            //if (customername == "Total")
            //{
            //    customername = "";
            //}
            int s = Convert.ToInt32(Session["LoginEmpId"].ToString());
            int d = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            string empname = empobj.GetEmployeeName(s);
            int time = Logobj.GetDate().Hour;
            if (time < 13)
            {
                dt = outobj.OpsOutStdingGET(99999, d, s);
            }
            else if (time >= 13 && time < 16)
            {
                dt = outobj.OpsOutStdingGET12N(99999, d, s);
            }
            else if (time >= 16 && time < 23)
            {
                dt = outobj.OpsOutStdingGET3PM(99999, d, s);
            }
            int tot = 0;
            str_SelFormula = "overduedays >" + tot;

            DataView dt_ldg = new DataView(dt);
            if (str_SelFormula != "")
            {
                dt_ldg.RowFilter = str_SelFormula;

            }
            DataTable dt2 = new DataTable();
            dt2 = dt_ldg.ToTable();
            if (dt2.Rows.Count > 0)
            {
                DataRow dr2 = dt2.NewRow();
                dr2["refno"] = "Total";
                //  Double amount = Convert.ToDouble(dt2.Compute("sum(amount)", ""));
                Double overdue = Convert.ToDouble(dt2.Compute("sum(overdue)", ""));
                // Double famount = Convert.ToDouble(dt2.Compute("sum(famount)", ""));
                Double foverdue = Convert.ToDouble(dt2.Compute("sum(foverdue)", ""));
                // dr2["amount"] = amount.ToString("#,0.00") + "";
                dr2["overdue"] = overdue.ToString("#,0.00") + "";
                //dr2["famount"] = famount.ToString("#,0.00") + "";
                dr2["foverdue"] = foverdue.ToString("#,0.00") + "";

                //dr2["amount"] = dt2.Compute("sum(amount)", "");
                //dr2["overdue"] = dt2.Compute("sum(overdue)", "");
                //dr2["famount"] = dt2.Compute("sum(famount)", "");
                //dr2["foverdue"] = dt2.Compute("sum(foverdue)", "");

                dt2.Rows.Add(dr2);
            }
            PanelCollection.Visible = true;
            Grd_collection.Visible = true;
            Grd_collection.DataSource = dt2;
            Grd_collection.DataBind();
            if (Grd_collection.Rows.Count > 0)
            {
                Grd_collection.Rows[Grd_collection.Rows.Count - 1].Cells[7].ForeColor = System.Drawing.Color.Maroon;
                Grd_collection.Rows[Grd_collection.Rows.Count - 1].Cells[8].ForeColor = System.Drawing.Color.Maroon;
                Grd_collection.Rows[Grd_collection.Rows.Count - 1].Cells[10].ForeColor = System.Drawing.Color.Maroon;
            }
            ViewState["Collection"] = dt2;
            Chart1.Visible = false;
            classDiv.Visible = false;
            Panel1.Visible = false;
            GridView1.Visible = false;
            PanelCollection.Visible = true;
            Grd_collection.Visible = true;
            Panel6.Visible = false;
            GridView3.Visible = false;
        }

        protected void Grd_collection_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[8].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[8].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[8].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (double.TryParse(e.Row.Cells[10].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        e.Row.Cells[10].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[10].Attributes.CssStyle["text-align"] = "Right";
                    }
                }

                if (e.Row.Cells[7].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }

            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {

                    if (e.Row.Cells[i].Text == "Amount")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Left";
                    }
                    if (e.Row.Cells[i].Text == "Overdue")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Left";
                    }
                    if (e.Row.Cells[i].Text == "Overduedays")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Left";
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "Amount")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[i].Text == "Overdue")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }
                    if (e.Row.Cells[i].Text == "Overduedays")
                    {

                        e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                    }

                }

            }
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {

            DataTable dt_check = ViewState["Collection"] as DataTable;
            dt_check.Columns.Remove("amount");
            dt_check.Columns.Remove("nodays");
            dt_check.Columns.Remove("customerid");
            dt_check.Columns.Remove("appamt");
            dt_check.Columns.Remove("appdays");
            dt_check.Columns.Remove("bid");

            dt_check.Columns.Remove("custid");
            dt_check.Columns.Remove("salesid");
            dt_check.Columns.Remove("empid");
            dt_check.Columns.Remove("vamount");
            dt_check.Columns.Remove("fcurr");
            dt_check.Columns.Remove("famount");
            dt_check.Columns.Remove("foverdue");
            if (Grd_collection.Rows.Count > 0)
            {

                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=Collection Advise.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

                if (Grd_collection.Visible == true)
                {
                    Grd_collection.GridLines = GridLines.Both;
                    Grd_collection.HeaderStyle.Font.Bold = true;
                    Grd_collection.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();

                /*using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Collection Advise.xls");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }*/

            }
        }

        protected void GrdCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrdCustomer.Visible = true;
            int index = 0;
            Session["Customer"] = "";
            Session["hidcustomer"] = "";

            if (GrdCustomer.Rows.Count > 0)
            {
                index = GrdCustomer.SelectedRow.RowIndex;
                Session["Customer"] = HttpUtility.HtmlDecode(GrdCustomer.Rows[index].Cells[1].Text);
                Session["hidcustomer"] = GrdCustomer.Rows[index].Cells[0].Text;
                Session["hidcustomergrd"] = GrdCustomer.Rows[index].Cells[0].Text;
                ////Response.Redirect("../CRMNew/Customer.aspx?type=TS");
                //popup_Cus.Show();
                //iframe1.Attributes["src"] = "../CRMNew/Customer.aspx?type=TS";
                Response.Redirect("../CRM/CRMSalesDetails.aspx?type=Schedule Visit");
            }
        }
        protected void GrdCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdCustomer, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdOutStanding_PreRender(object sender, EventArgs e)
        {
            grdOutStanding.UseAccessibleHeader = true;
            grdOutStanding.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        public void GetApp()
        {
          //  DataAccess.CRMNew.MasterCustomerProspective obj_MasterCustomer = new DataAccess.CRMNew.MasterCustomerProspective();
          //  DataAccess.CRMNew.TeleCaller objmain = new DataAccess.CRMNew.TeleCaller();
            DataTable DtApp = new DataTable();
            DataTable dt = new DataTable();
            DataTable dtfollow = new DataTable();
            dt = obj_MasterCustomer.GetTeleCalDetailsFilterTC(Convert.ToInt32(Session["LoginEmpId"]), 0, 0, 0, "", 0, 0, "", "");
            int count = dt.Rows.Count;
            if (dt.Rows.Count == 0)
            {
                SpanTB.InnerText = "0";
            }
            else
            {
                SpanTB.InnerText = Convert.ToString(count);
            }

            int empid = Convert.ToInt32(Session["LoginEmpId"]);
            DtApp = objmain.GetMonthWiseCal(empid, DateTime.Now.Month);
            int countApp = DtApp.Rows.Count;
            if (DtApp.Rows.Count == 0)
            {
                SpanApp.InnerText = "0";
            }
            else
            {
                SpanApp.InnerText = Convert.ToString(countApp);
            }

            dtfollow = obj_MasterCustomer.GetTeleCalDetailsFilterFU(Convert.ToInt32(Session["LoginEmpId"]), 0, 0, 0, "", 0, 0, "", "");
            int countfollow = dtfollow.Rows.Count;
            if (dtfollow.Rows.Count == 0)
            {
                SpanPR.InnerText = "0";
            }
            else
            {
                SpanPR.InnerText = Convert.ToString(countfollow);
            }
        }

        protected void link_ebooking_Click(object sender, EventArgs e)
        {
            Dis_Grid();
            getebookingnew();
            cust_name.Visible = false;
            divebooking.Visible = true;
            lbl_Perfor_det.Visible = false;

        }

        protected void grdebooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            int uiid, index;
            DataTable dtuser = new DataTable();
            uiid = 10;
            index = grdebooking.SelectedRow.RowIndex;
            dtuser = obj_UP.GetFormwiseuserRights(uiid, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
            if (dtuser.Rows.Count > 0)
            {
                Response.Redirect("../Sales/Booking.aspx?ebookingno=" + grdebooking.Rows[index].Cells[1].Text + "&confirmed=" + grdebooking.Rows[index].Cells[12].Text + "&bookno=" + grdebooking.Rows[index].Cells[13].Text + "&uiid=" + uiid);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(grdQuatotion, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grdebooking_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b2d9f7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdebooking, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        public void getebookingnew()
        {

            dataQuat = objQuat.getebookingdetails(Convert.ToInt32(Session["LoginBranchid"]));

            if (dataQuat.Rows.Count > 0)
            {
                grdebooking.DataSource = dataQuat;
                grdebooking.DataBind();

                grdebooking.Visible = true;
                divebooking.Visible = true;
                //for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                //{
                //    if (string.IsNullOrEmpty(dataQuat.Rows[i]["approvedon"].ToString()))
                //    {
                //        System.Web.UI.WebControls.Image ImageUnApp = grdQuatotion.Rows[i].FindControl("UnAppImage") as System.Web.UI.WebControls.Image;
                //        ImageUnApp.Visible = true;
                //    }
                //    else
                //    {
                //        System.Web.UI.WebControls.Image ImageApp = grdQuatotion.Rows[i].FindControl("AppImage") as System.Web.UI.WebControls.Image;
                //        ImageApp.Visible = true;
                //    }                    
                //}
            }
        }

        protected void grdQuatotion_PreRender(object sender, EventArgs e)
        {
            if (grdQuatotion.Rows.Count > 0)
            {
                grdQuatotion.UseAccessibleHeader = true;
                grdQuatotion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_workprogress_PreRender(object sender, EventArgs e)
        {
            if (Grid_workprogress.Rows.Count > 0)
            {
                Grid_workprogress.UseAccessibleHeader = true;
                Grid_workprogress.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grid_credit_PreRender(object sender, EventArgs e)
        {
            if (grid_credit.Rows.Count > 0)
            {
                grid_credit.UseAccessibleHeader = true;
                grid_credit.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void divgrid_PreRender(object sender, EventArgs e)
        {
            if (divgrid.Rows.Count > 0)
            {
                divgrid.UseAccessibleHeader = true;
                divgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_collection_PreRender(object sender, EventArgs e)
        {
            if (Grd_collection.Rows.Count > 0)
            {
                Grd_collection.UseAccessibleHeader = true;
                Grd_collection.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdCustomer_PreRender(object sender, EventArgs e)
        {
            if (GrdCustomer.Rows.Count > 0)
            {
                GrdCustomer.UseAccessibleHeader = true;
                GrdCustomer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnkunapproved_Click(object sender, EventArgs e)
        {
            div_coll.Visible = false;
            PanelCollection.Visible = false;
            Grd_collection.Visible = false;
            Dis_Grid();
            
            pnlGrdCuswise.Visible = false;
            piechartbook.Visible = false;
            div_book.Visible = false;
            quot.Visible = true;
            lblQuation.Visible = true;
            quatatio_exce.Visible = true;
            lt.Visible = false;
            lts.Visible = false;
            Panel9.Visible = false;
            WIP.Visible = false;
            lbl_Perfor_det.Visible = false;
            excl_export.Visible = false;
            workingprogess.Visible = false;
            cust_name.Visible = false;
            div1.Visible = false;
            PieChart2.Visible = false;
            //div5.Visible = false;
            //div6.Visible = false;
            //div8.Visible = false;
            //div7.Visible = false;
            divebooking.Visible = false;
            DataSet dsg;
            DataTable dtgsk2;
            dsg = objQuat.GetQuation4salesappunapp(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dsg.Tables.Count > 0)
            {
                dtgsk2 = dsg.Tables[0];

                if (dtgsk2.Rows.Count > 0)
                {
                    grdQuatotion.DataSource = dtgsk2;
                    grdQuatotion.DataBind();
                    if (grdQuatotion.Rows.Count > 0)
                    {
                        for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                        {
                            if (grdQuatotion.Rows[i].Cells[8].Text == "UnApproved")
                            {
                                grdQuatotion.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                            }
                        }

                    }
                    ViewState["Quotation"] = dtgsk2;
                    div_quotdetails.Visible = true;
                    grdQuatotion.Visible = true;
                    divQuot.Visible = true;
                    //for (int i = 0; i <= grdQuatotion.Rows.Count - 1; i++)
                    //{
                    //    if (string.IsNullOrEmpty(dataQuat.Rows[i]["approvedon"].ToString()))
                    //    {
                    //        System.Web.UI.WebControls.Image ImageUnApp = grdQuatotion.Rows[i].FindControl("UnAppImage") as System.Web.UI.WebControls.Image;
                    //        ImageUnApp.Visible = true;
                    //    }
                    //    else
                    //    {
                    //        System.Web.UI.WebControls.Image ImageApp = grdQuatotion.Rows[i].FindControl("AppImage") as System.Web.UI.WebControls.Image;
                    //        ImageApp.Visible = true;
                    //    }                    
                    //}
                }
                else
                {
                    grdQuatotion.DataSource = new DataTable();
                    grdQuatotion.DataBind();
                }
            }
        }

    }
}