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

namespace logix.Home
{
    public partial class CorpCreditControl : System.Web.UI.Page
    {
        DataTable dtCout = new DataTable();
        DataAccess.Accounts.Payment objpay = new DataAccess.Accounts.Payment();
        DataAccess.Outstanding outobj = new DataAccess.Outstanding();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
        DataAccess.Masters.MasterEmployee employeeobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Masters.MasterExRate exrobj = new DataAccess.Masters.MasterExRate();
        DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.Recipts objreceipt = new DataAccess.Accounts.Recipts();
        DataAccess.Masters.MasterChequeReq_App objCheqReq = new DataAccess.Masters.MasterChequeReq_App();
        DataAccess.Accounts.Recipts objReceipt = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.ProAdminDCNNo objAdminDnCn = new DataAccess.Accounts.ProAdminDCNNo();
        DataAccess.MIS MISObj = new DataAccess.MIS();
        int Did;
        DataTable dtdummy = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtb = new DataTable();
        Double data=0;
      
        int bid, dsodays;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DateTime joudate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            OutstandingGrid.Visible = false;
            grid_Creditrequest1.Visible = false;
            Pannectrl.Visible = false;
            pnlcreditapprovallimit.Visible = false;
            barchart();
            creditrequest();
            //DSODays();
            overdue();
            CreditApprovalLimits();
            ExceptionList();
            Customerprofile();
            outstanding();          
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            DataAccess.LogDetails logobj = new DataAccess.LogDetails();
            joudate = logobj.GetDate();
            txt_date.Text = Utility.fn_ConvertDate(joudate.ToShortDateString());
            Link_overdue.Visible = false;
            lnk_creditrequest.Visible = false;
            Link_request.Visible = false;
            Link_excep.Visible = false;
            Link_ousta.Visible = false;
            div_overdue.Visible = false;
            grid_Creditrequest1.Visible = false;
            pnlcreditapprovallimit.Visible = false;
            div_overdue.Visible = false;
            }

        }

        [WebMethod]
        public static void GetEmpName(string Prefix)
        {

            DataTable obj_dtEmp = new DataTable();
            DataTable dt1 = new DataTable();
            DataAccess.Masters.MasterBranch branchobj = new DataAccess.Masters.MasterBranch();
            if (Prefix.Length > 0)
            {
                obj_dtEmp = HttpContext.Current.Session["dt1"] as DataTable;
                DataView data1 = obj_dtEmp.DefaultView;
                data1.RowFilter = "portname like '" + Prefix.ToString() + "%'";
                obj_dtEmp = data1.ToTable();
                HttpContext.Current.Session["dttt"] = obj_dtEmp;
            }
            else
            {
                dt1 = branchobj.GetBranchwithdso();
                HttpContext.Current.Session["dttt"] = dt1;
            }

        }

    public void creditrequest()
    {
        DataTable dt = new DataTable();
        Did = int.Parse(Session["LoginDivisionId"].ToString());
        dt = objpay.GetCreditRequest4home(Did);

        if (dt.Rows.Count > 0)
        {
            Lnk_Credit.Text = dt.Rows[0][0].ToString();
        }
        else
        {
            Lnk_Credit.Text = "0";
        }
         
    }
    //public void DSODays()
    //{
    //    DataTable dt = new DataTable();
    //    Did = int.Parse(Session["LoginDivisionId"].ToString());
    //    dt = objpay.getdsodays4creditcontrol(Did);

    //    if (dt.Rows.Count > 0)
    //    {
    //        Link_dso.Text = dt.Rows[0][0].ToString();
    //    }
    //    else
    //    {
    //        Link_dso.Text = "0";
    //    }
    //}
    public void CreditApprovalLimits()
    {
        DataTable dt = new DataTable();
        Did = int.Parse(Session["LoginDivisionId"].ToString());
        dt = objpay.GetCreditlimit4home(Did);
        Double approvallimit = 0.0;
        if(!string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
        {
            approvallimit = Convert.ToDouble(dt.Rows[0][0]);
        }
         
        if (dt.Rows.Count > 0)
        {
            LinkCAlimit.Text = approvallimit.ToString("#,0")+"";
        }
        else
        {
            LinkCAlimit.Text = "0";
        }
    }
    public void ExceptionList()
    {
        DataTable dt = new DataTable();
        Did = int.Parse(Session["LoginDivisionId"].ToString());
        dt = objpay.getExemptionList4Home(Did);
        Double except = 0.0;
             if(!string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
        {
            except = Convert.ToDouble(dt.Rows[0][0]);
        }
           
        if (dt.Rows.Count > 0)
        {
            Linkexcemption.Text = except.ToString();
        }
        else
        {
            Linkexcemption.Text = "0";
        }
    }
    public void Customerprofile()
    {

    }

    public void overdue()
    {
        
        int time = logobj.GetDate().Hour;
        dtb = objpay.getOverduecorporate(int.Parse(Session["LoginDivisionId"].ToString()));
        if (dtb.Rows.Count > 0)
        {
            Double overdue = 0.00;
                if(!string.IsNullOrEmpty(dtb.Rows[0][0].ToString()))
                {
                overdue = Convert.ToDouble(dtb.Rows[0][0]);
                }

            LinkOverdue.Text = overdue.ToString("#,0") + "";

        }




        /*DataTable dt = new DataTable();

        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

        Did=Convert.ToInt32(Session["LoginDivisionId"].ToString());
        int subgrpid = 40, count_row = 0;
        int time = 0;
        double temp_TOTAL = 0, temp_out = 0, temp_overdue;

        time = obj_da_Log.GetDate().Hour;
        if (time < 13)
        {
            dt = outsobj.OutStdingGET(99999, Did, subgrpid);
        }
        else if (time >= 13 && time < 16)
        {
            dt = outsobj.OutStdingGET12N(99999, Did, subgrpid);
        }
        else if (time >= 16 && time < 23)
        {
            dt = outsobj.OutStdingGET3PM(99999, Did, subgrpid);
        }
        if (dt.Rows.Count > 0)
        {
            //  DataView dataView = dt.DefaultView;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt.Rows[i]["amount"].ToString()))
                {
                    temp_TOTAL += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                }
            }
        }
        //SPoutsttot.InnerText = Convert.ToDouble(temp_TOTAL).ToString("#,0.00");


        DataTable DT_Temp = new DataTable();
        DataTable DT_Tempnew = new DataTable();
        DataTable DT_bind = new DataTable();
        DataTable DT_sales = new DataTable();
        DataTable Dt_Out = new DataTable();

        if (dt.Rows.Count > 0)
        {
            DataView dv_co = new DataView(dt);
            DT_Temp = dv_co.ToTable(true, "salesname", "salesid");
            dv_co = new DataView(DT_Temp);
            dv_co.Sort = "salesid";
            DT_Temp = dv_co.ToTable();
            dv_co = DT_Temp.DefaultView;
            dv_co.RowFilter = "salesid<>0 and  salesid is not null";
            DT_Temp = dv_co.ToTable();

            /*   DataView dv_co1 = new DataView(dt);
               DT_Tempnew = dv_co1.ToTable(true, "salesname", "salesid");
               dv_co = new DataView(DT_Tempnew);
               dv_co1.Sort = "salesid";
               DT_Tempnew = dv_co1.ToTable();
               dv_co = DT_Tempnew.DefaultView;
               dv_co1.RowFilter = "salesid<>0 and  salesid is not null";
               DT_Tempnew = dv_co1.ToTable();
               dv_co = DT_Tempnew.DefaultView;
               dv_co1.RowFilter = "salesid=0 or  salesid is  null";
               DT_Tempnew = dv_co1.ToTable();

               


            DT_bind.Columns.Add("salesname", typeof(string));
            DT_bind.Columns.Add("amount", typeof(double));
            DT_bind.Columns.Add("overdue", typeof(double));
            DT_bind.Columns.Add("salesid", typeof(string));
            DataRow Drow = DT_bind.NewRow();
            //count_row = DT_Temp.Rows.Count ;
            for (int i = 0; i < DT_Temp.Rows.Count; i++)
            {
                DataView data1 = dt.DefaultView;
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


            /* if (DT_Tempnew.Rows.Count > 0)
             {
                 DataView data1 = dt.DefaultView;
                 data1.RowFilter = "salesid = 0 or  salesid is null";
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

            LinkOutstanding.Text = Convert.ToDouble(sum_Over).ToString("#,0.00");
        }
        else
        {
            LinkOutstanding.Text = "0.00";
        }*/


    }
    public void outstanding()
    {
        DataTable dt = new DataTable();
        Did = int.Parse(Session["LoginDivisionId"].ToString());
        int time = logobj.GetDate().Hour;
        dt = objpay.GetOutstanding4Home(time, Did);
        Double oustanding = 0.00;
        if (!string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
        {
            oustanding = Convert.ToDouble(dt.Rows[0][0]);
        }
       
        if (dt.Rows.Count > 0)
        {
            LinkOutstanding.Text = oustanding.ToString("#,0")+"";
        }
        else
        {
            LinkOutstanding.Text = "0";
        }

       /* DataTable dt = new DataTable();
        Did = Convert.ToInt32(Session["LoginDivisionId"].ToString());
        DataAccess.Outstanding outsobj = new DataAccess.Outstanding();

        int subgrpid = 40, count_row = 0;
        int time = 0;
        double temp_TOTAL = 0, temp_out = 0, temp_overdue;

        time = obj_da_Log.GetDate().Hour;
        if (time < 13)
        {
            dt = outsobj.OutStdingGET(99999, Did, subgrpid);
        }
        else if (time >= 13 && time < 16)
        {
            dt = outsobj.OutStdingGET12N(99999, Did, subgrpid);
        }
        else if (time >= 16 && time < 23)
        {
            dt = outsobj.OutStdingGET3PM(99999, Did, subgrpid);
        }
        if (dt.Rows.Count > 0)
        {
            //  DataView dataView = dt.DefaultView;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt.Rows[i]["amount"].ToString()))
                {
                    temp_TOTAL += Convert.ToDouble(dt.Rows[i]["amount"].ToString());
                }
            }
        }
        //SPoutsttot.InnerText = Convert.ToDouble(temp_TOTAL).ToString("#,0.00");


        DataTable DT_Temp = new DataTable();
        DataTable DT_Tempnew = new DataTable();
        DataTable DT_bind = new DataTable();
        DataTable DT_sales = new DataTable();
        DataTable Dt_Out = new DataTable();

        if (dt.Rows.Count > 0)
        {
            DataView dv_co = new DataView(dt);
            DT_Temp = dv_co.ToTable(true, "salesname", "salesid");
            dv_co = new DataView(DT_Temp);
            dv_co.Sort = "salesid";
            DT_Temp = dv_co.ToTable();
            dv_co = DT_Temp.DefaultView;
            dv_co.RowFilter = "salesid<>0 and  salesid is not null";
            DT_Temp = dv_co.ToTable();

            /*   DataView dv_co1 = new DataView(dt);
               DT_Tempnew = dv_co1.ToTable(true, "salesname", "salesid");
               dv_co = new DataView(DT_Tempnew);
               dv_co1.Sort = "salesid";
               DT_Tempnew = dv_co1.ToTable();
               dv_co = DT_Tempnew.DefaultView;
               dv_co1.RowFilter = "salesid<>0 and  salesid is not null";
               DT_Tempnew = dv_co1.ToTable();
               dv_co = DT_Tempnew.DefaultView;
               dv_co1.RowFilter = "salesid=0 or  salesid is  null";
               DT_Tempnew = dv_co1.ToTable();

              


            DT_bind.Columns.Add("salesname", typeof(string));
            DT_bind.Columns.Add("amount", typeof(double));
            DT_bind.Columns.Add("overdue", typeof(double));
            DT_bind.Columns.Add("salesid", typeof(string));
            DataRow Drow = DT_bind.NewRow();
            //count_row = DT_Temp.Rows.Count ;
            for (int i = 0; i < DT_Temp.Rows.Count; i++)
            {
                DataView data1 = dt.DefaultView;
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


            /* if (DT_Tempnew.Rows.Count > 0)
             {
                 DataView data1 = dt.DefaultView;
                 data1.RowFilter = "salesid = 0 or  salesid is null";
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
          
            LinkOutstanding.Text = Convert.ToDouble(sum_Outstanding).ToString("#,0.00");
        }
        else
        {
            LinkOutstanding.Text = "0.00";
        }
        */



    }
   

        protected void formpaymentcancel_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(966, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/CreditApprovelLimits.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void formnotover_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(1000, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/DSODays.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void formvoureg_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(422, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Sales/CreditApproval.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void formsince_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(1366, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/CreditExemptionList.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void formtds_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(1449, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/MasterCustomrate.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void formcost_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(1450, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/MasterCreditrateExec.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void Lnk_Credit_Click(object sender, EventArgs e)
        {
            pnlcreditapprovallimit.Visible = false;
            grid_Creditrequest1.Visible = true;
            OutstandingGrid.Visible = false;
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Pannectrl.Visible = true;
            Link_overdue.Visible = false;
            lnk_creditrequest.Visible = false;
            Link_excep.Visible = false;
            Link_request.Visible = true;
            Link_ousta.Visible = false;
            chart_divbar.Visible = false;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = true;
            pnlcreditapprovallimit.Visible = false;
            OutstandingGrid.Visible = false;
            div_overdue.Visible = false;
            dtb = objpay.getCreditRequestHome(Convert.ToInt32(Session["LoginDivisionId"]));
            if(dtb.Rows.Count>0)
            {
                grid_Creditrequest.DataSource = dtb;
                grid_Creditrequest.DataBind();
                ViewState["grid_Creditrequest"] = dtb;
            }

        }

        protected void Link_dso_Click(object sender, EventArgs e)
        {
            pnlcreditapprovallimit.Visible = false;
            grid_Creditrequest1.Visible = false;
            grd.DataSource = dtdummy;
            grd.DataBind();
            fillbranch();
            cmbbranch.Text = Session["LoginDivisionName"].ToString();
            lbal_Header.Visible = true;
            div_dsoday.Visible = true;
            div_dsoday11.Visible = true;
            Panel3.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Pannectrl.Visible = false;
            OutstandingGrid.Visible = false;
            Link_overdue.Visible = false;
            lnk_creditrequest.Visible = false;
            Link_excep.Visible = false;
            Link_request.Visible = false;
            Link_ousta.Visible = false;
            chart_divbar.Visible = false;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = false;
            pnlcreditapprovallimit.Visible = false;
            OutstandingGrid.Visible = false;
            div_overdue.Visible = false;
        }

        protected void Linkexcemption_Click(object sender, EventArgs e)
        {  
            Double amount=0;
            string trantype="";
            pnlcreditapprovallimit.Visible = false;
            grid_Creditrequest1.Visible = false;
            Pannectrl.Visible = true;
            OutstandingGrid.Visible = false;         
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = true;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Link_overdue.Visible = false;
            lnk_creditrequest.Visible = false;
            Link_excep.Visible = true;
            Link_request.Visible = false;
            Link_ousta.Visible = false;
            chart_divbar.Visible = false;
            Pannectrl.Visible = true;
            grid_Creditrequest1.Visible = false;
            pnlcreditapprovallimit.Visible = false;
            OutstandingGrid.Visible = false;
            div_overdue.Visible = false;
            dtb = objpay.getExemptionlistHome(Convert.ToInt32(Session["LoginDivisionId"]));
            DataTable dts = new DataTable();
           
            dts.Columns.Add("Branch");
            dts.Columns.Add("Docno");
            dts.Columns.Add("Product");            
            dts.Columns.Add("Customer");
            dts.Columns.Add("Creditamt");
            dts.Columns.Add("Date");
            dts.Columns.Add("ExemptedBy");
            dts.Columns.Add("Creditdays");
            dts.Columns.Add("Remarks");

            dts.Columns.Add("customerid");
            
            DataRow dr;
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dr = dts.NewRow();
                    dts.Rows.Add();
                   
                    dts.Rows[i]["Branch"] = dtb.Rows[i]["branch"];
                    dts.Rows[i]["Docno"] = dtb.Rows[i]["docno"];
                    dts.Rows[i]["ExemptedBy"] = dtb.Rows[i]["reqby"];
                    dts.Rows[i]["Customer"] = dtb.Rows[i]["Customer"];
                    dts.Rows[i]["Creditamt"] = dtb.Rows[i]["creditamt"];
                    amount = Convert.ToDouble(dtb.Compute("sum(creditamt)", ""));
                    // string trantype= dtb.Rows[i]["trantype"].ToString();
                    if (dtb.Rows[i]["trantype"].ToString() == "OE")
                    {
                        trantype = "OE";
                    }
                    else if (dtb.Rows[i]["trantype"].ToString() == "OI")
                    {
                        trantype = "OI";
                    }
                    else if (dtb.Rows[i]["trantype"].ToString() == "AE")
                    {
                        trantype = "AE";
                    }
                    else if (dtb.Rows[i]["trantype"].ToString() == "AI")
                    {
                        trantype = "AI";
                    }
                    else if (dtb.Rows[i]["trantype"].ToString() == "CH")
                    {
                        trantype = "CHA";
                    }
                    else if (dtb.Rows[i]["trantype"].ToString() == "BT")
                    {
                        trantype = "BT";
                    }

                    dts.Rows[i]["Product"] = trantype.ToString();
                    dts.Rows[i]["Date"] = Utility.fn_ConvertDate(dtb.Rows[i]["Date"].ToString());
                    dts.Rows[i]["Creditdays"] = dtb.Rows[i]["creditdays"];
                    dts.Rows[i]["Remarks"] = dtb.Rows[i]["remarks"];

                    dts.Rows[i]["customerid"] = dtb.Rows[i]["customerid"];
                }

                int count = dts.Rows.Count;
                dts.Rows.Add();
                dts.Rows[count]["Customer"] = "Total";
                dts.Rows[count]["creditamt"] = amount.ToString("#,0.00") + "";
                GridView1.DataSource = dts;
                GridView1.DataBind();
                //ViewState["GridView1"] = dtb;
                ViewState["GridView1"] = dts;
            }

            //Edited
            Double amount1 = 0;
            string trantype1 = "";
            DataTable dttb = new DataTable();
            dttb = objpay.getExemptionlistHome(Convert.ToInt32(Session["LoginDivisionId"]));
            DataTable dtts = new DataTable();

            dtts.Columns.Add("Branch");
            dtts.Columns.Add("Docno");
            dtts.Columns.Add("Product");
            dtts.Columns.Add("Customer");
            dtts.Columns.Add("Creditamt");
            dtts.Columns.Add("Date");
            dtts.Columns.Add("ExemptedBy");
            dtts.Columns.Add("Creditdays");
            dtts.Columns.Add("Remarks");

            DataRow drr;
            if (dttb.Rows.Count > 0)
            {
                for (int i = 0; i < dttb.Rows.Count; i++)
                {
                    drr = dtts.NewRow();
                    dtts.Rows.Add();

                    dtts.Rows[i]["Branch"] = dttb.Rows[i]["branch"];
                    dtts.Rows[i]["Docno"] = dttb.Rows[i]["docno"];
                    dtts.Rows[i]["ExemptedBy"] = dttb.Rows[i]["reqby"];
                    dtts.Rows[i]["Customer"] = dttb.Rows[i]["Customer"];
                    dtts.Rows[i]["Creditamt"] = dttb.Rows[i]["creditamt"];
                    amount1 = Convert.ToDouble(dttb.Compute("sum(creditamt)", ""));
                    // string trantype= dtb.Rows[i]["trantype"].ToString();
                    if (dttb.Rows[i]["trantype"].ToString() == "OE")
                    {
                        trantype1 = "OE";
                    }
                    else if (dttb.Rows[i]["trantype"].ToString() == "OI")
                    {
                        trantype1 = "OI";
                    }
                    else if (dttb.Rows[i]["trantype"].ToString() == "AE")
                    {
                        trantype1 = "AE";
                    }
                    else if (dttb.Rows[i]["trantype"].ToString() == "AI")
                    {
                        trantype1 = "AI";
                    }
                    else if (dttb.Rows[i]["trantype"].ToString() == "CH")
                    {
                        trantype1 = "CHA";
                    }
                    else if (dttb.Rows[i]["trantype"].ToString() == "BT")
                    {
                        trantype1 = "BT";
                    }

                    dtts.Rows[i]["Product"] = trantype1.ToString();
                    dtts.Rows[i]["Date"] = Utility.fn_ConvertDate(dttb.Rows[i]["Date"].ToString());
                    dtts.Rows[i]["Creditdays"] = dttb.Rows[i]["creditdays"];
                    dtts.Rows[i]["Remarks"] = dttb.Rows[i]["remarks"];
                }

                int count = dtts.Rows.Count;
                dtts.Rows.Add();
                dtts.Rows[count]["Customer"] = "Total";
                dtts.Rows[count]["creditamt"] = amount1.ToString("#,0.00") + "";
                
                ViewState["GridView2"] = dtts;
            }
        }

     

        protected void Linkcuspro_Click(object sender, EventArgs e)
        {
            pnlcreditapprovallimit.Visible = false;
            grid_Creditrequest1.Visible = false;
            Pannectrl.Visible = false;
            OutstandingGrid.Visible = false;
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            Link_overdue.Visible = false;
            lnk_creditrequest.Visible = false;
            Link_request.Visible = false;
            chart_divbar.Visible = false;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = false;
            pnlcreditapprovallimit.Visible = false;
            OutstandingGrid.Visible = false;
            div_overdue.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(1792, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "customer";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../ForwardExports/CustomerProfile.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           

        }

        protected void LinkOutstanding_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            grdOutStanding.Visible = true;
            DataTable dts = new DataTable();
            Panel4.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = false;
            OutstandingGrid.Visible = true;
            Link_overdue.Visible = false;
            lnk_creditrequest.Visible = false;
            Link_excep.Visible = false;
            Link_ousta.Visible = true;
            // DataTable data = new DataTable();
            Link_request.Visible = false;
            chart_divbar.Visible = false;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = false;
            pnlcreditapprovallimit.Visible = false;
            OutstandingGrid.Visible = true;
            div_overdue.Visible = false;
            DataAccess.Outstanding objoust = new DataAccess.Outstanding();
            int time = logobj.GetDate().Hour;
            dts = objpay.getoustandingcorporate(Convert.ToInt32(Session["LoginDivisionId"]), time);
            if (dts.Rows.Count > 0)
            {
                for (int i = 0; i < dts.Rows.Count - 1; i++)
                {
                    data = Convert.ToDouble(dts.Compute("sum(amount)", ""));
                }
                int count = 0;
                count = dts.Rows.Count;
                dts.Rows.Add();
                dts.Rows[count]["ledgername"] = "Total";
                dts.Rows[count]["amount"] = data.ToString("#,0.00") + "";
                grdOutStanding.DataSource = dts;
                grdOutStanding.DataBind();
                grdOutStanding.Columns[2].Visible = false;
                grdOutStanding.Columns[3].Visible = false;
                grdOutStanding.Columns[4].Visible = false;
                ViewState["grdOutStanding"] = dts;
            }

        }

        protected void LinkOverdue_Click(object sender, EventArgs e)
        {
            pnlcreditapprovallimit.Visible = false;
            grid_Creditrequest1.Visible = false;
            Pannectrl.Visible = false;
            OutstandingGrid.Visible = false;
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel4.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Link_overdue.Visible = true;
            lnk_creditrequest.Visible = false;
            Link_excep.Visible = false;
            Link_request.Visible = false;
            Link_ousta.Visible = false;
            overdueing();
            chart_divbar.Visible = false;
            div_dsoday.Visible = false;
            div_overdue.Visible = true;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = false;
            pnlcreditapprovallimit.Visible = false;
            div_overdue.Visible = true;
        }

        protected void LinkCAlimit_Click(object sender, EventArgs e)
        {
            Double amount = 0;
            pnlcreditapprovallimit.Visible = true;
            grid_Creditrequest1.Visible = false;
            Pannectrl.Visible = false;
            OutstandingGrid.Visible = false;
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel4.Visible = true;
            Panel3.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Link_overdue.Visible = false;
            lnk_creditrequest.Visible = true;
            Link_excep.Visible = false;
            Link_request.Visible = false;
            Link_ousta.Visible = false;
            chart_divbar.Visible = false;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = false;
            pnlcreditapprovallimit.Visible = true;
            OutstandingGrid.Visible = false;
            div_overdue.Visible = false;
           // string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            dtb = objpay.GetCreditApprovallimithome(Convert.ToInt32(Session["LoginDivisionId"]));
            if (dtb.Rows.Count > 0)
            {
              amount =Convert.ToDouble(dtb.Compute("sum(amountlmt)", ""));
            }
            int count = dtb.Rows.Count;
            dtb.Rows.Add();
            dtb.Rows[count]["branch"] = "Total";
            dtb.Rows[count]["amountlmt"] = amount.ToString("#,0.00") + "";
            Grid_creditapprovallimit.DataSource = dtb;
            Grid_creditapprovallimit.DataBind();
            ViewState["Grid_creditapprovallimit"] = dtb;

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
                if (e.Row.Cells[0].Text == "DSO Days")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    for (int h = 2; h < e.Row.Cells.Count; h++)
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";

                Label lblReview = (Label)e.Row.FindControl("lbldivsname");
                string tooltip = lblReview.Text;
                e.Row.Cells[1].Attributes.Add("title", tooltip);

                Label lblReview1 = (Label)e.Row.FindControl("lblbm");
                string tooltip1 = lblReview1.Text;
                e.Row.Cells[2].Attributes.Add("title", tooltip1);

                Label lblReview2 = (Label)e.Row.FindControl("lblrm");
                string tooltip2 = lblReview2.Text;
                e.Row.Cells[3].Attributes.Add("title", tooltip2);

            }

        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }

            //  DataView sortedView = (DataView)ViewState["dirState1"];
            DataTable dsortview = (DataTable)ViewState["dirState1"];
            DataView sortedView = new DataView();
            sortedView = dsortview.DefaultView;
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            grd.DataSource = sortedView;
            grd.DataBind();
        }
        public SortDirection dir
        {

            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                    //DataTable dstate = (DataTable)ViewState["dirState"];
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }

        protected void cmbbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbranch.SelectedIndex == 0)
            {
                dtb = branchobj.FilterBranch(1);
                hdndivid.Value = "1";

            }
            else if (cmbbranch.SelectedIndex == 1)
            {
                dtb = branchobj.FilterBranch(2);
                hdndivid.Value = "2";

            }
            else if (cmbbranch.SelectedIndex == 2)
            {
                dtb = branchobj.FilterBranch(5);
                hdndivid.Value = "5";

            }
            else if (cmbbranch.SelectedIndex == 3)
            {
                dtb = branchobj.FilterBranch(6);
                hdndivid.Value = "6";

            }
            else if (cmbbranch.SelectedIndex == 4)
            {
                dtb = branchobj.FilterBranch(7);
                hdndivid.Value = "7";

            }
            txtbname.Text = "";
            grd.DataSource = dtb;
            grd.DataBind();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    bid = Convert.ToInt32(grd.Rows[i].Cells[5].Text);
                    TextBox lbldsodays = (TextBox)grd.Rows[i].Cells[4].FindControl("lbldsodays");
                    if (lbldsodays.Text != "")
                    {
                        //TextBox lbldsodays = (TextBox)grd.Rows[i].Cells[4].FindControl("lbldsodays");
                        dsodays = Convert.ToInt32(lbldsodays.Text);
                    }
                    branchobj.Updbranchwithdso(dsodays, bid);
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1000, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), "DSO Days" + dsodays.ToString() + "/Bid-" + bid.ToString() + "/U");
                }
                ScriptManager.RegisterStartupScript(this, typeof(Button), "alert", "alertify.alert('DSO Details Updated');", true);
                fillbranch();
            }
        }
        public void fillbranch()
        {
            dtb = branchobj.FilterBranch(Convert.ToInt32(Session["LoginDivisionId"].ToString()));


            DataTable obj_dtTemp = new DataTable();
            obj_dtTemp = hrempobj.GetDivision();
            cmbbranch.DataSource = obj_dtTemp;
            cmbbranch.DataTextField = "divisionname";
            cmbbranch.DataBind();
            //dt1 = branchobj.GetBranchwithdso();
            Session["dt1"] = dtb;
            grd.DataSource = dtb;
            grd.DataBind();
            txtbname.Text = "";
            ViewState["dirState1"] = dtb;
        }
        public void overdueing()
        {
            Double overdues = 0;
            Double Oustanding = 0;
           int time = logobj.GetDate().Hour;
           dtb = objpay.getOverduecorporatebaroverdue(Convert.ToInt32(Session["LoginDivisionId"]), time);
            if (dtb.Rows.Count > 0)
            {
                overdues = Convert.ToDouble(dtb.Compute("sum(amount)", ""));
            }
            //int count = dtb.Rows.Count;
            dtb.Rows.Add();
            dtb.Rows[dtb.Rows.Count-1]["customername"] = "Total";
            dtb.Rows[dtb.Rows.Count-1]["amount"] = overdues.ToString("#,0.00") + "";
           
            Grid_overdue.DataSource = dtb;
            Grid_overdue.DataBind();
            Grid_overdue.Columns[2].Visible = false;
            Grid_overdue.Columns[3].Visible = false;
            Grid_overdue.Columns[4].Visible = false;
            ViewState["Grid_overdue"] = dtb;

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
           // this.Response.End();

            Response.Redirect("../Home/CorpCreditControl.aspx");
        }

        protected void LinkCAlimit1_Click(object sender, EventArgs e)
        {
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = false;
            OutstandingGrid.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {

                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(966, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/CreditApprovelLimits.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void LinkOutstanding1_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            grdOutStanding.Visible = true;
            DataTable dts = new DataTable();
            Panel4.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = false;
            OutstandingGrid.Visible = true;
            Pannectrl.Visible = false;
            grid_Creditrequest1.Visible = false;
            
           // DataTable data = new DataTable();
            DataAccess.Outstanding objoust = new DataAccess.Outstanding();
             int  time = logobj.GetDate().Hour;
             dts = objpay.getoustandingcorporate(Convert.ToInt32(Session["LoginDivisionId"]), time);
            if(dts.Rows.Count>0)
            {
                for (int i = 0; i < dts.Rows.Count - 1;i++ )
                {
                     data =Convert.ToDouble(dts.Compute("sum(osamt)",""));
                }
                int count = 0;
                count = dts.Rows.Count;
                dts.Rows.Add();
                dts.Rows[count]["customername"] = "Total";
                dts.Rows[count]["osamt"] = data.ToString("#,0.00") + "";
                grdOutStanding.DataSource = dts;
                grdOutStanding.DataBind();
            }
        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Depositslip_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        public void barchart()
        {

            dt1 = objpay.getOverduecorporatebar(Convert.ToInt32(Session["LoginEmpId"]), 0, Convert.ToInt32(Session["LoginDivisionId"]), 40, Session["StrTranType"].ToString());
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Branch');
            data.addColumn('number', 'Overdue');
            data.addColumn('number', 'Oustanding');
           
            data.addRows(" + dt1.Rows.Count + ");");



            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {

                if (dt1.Rows[i]["osamount"].ToString() != "0")
                {
                    str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt1.Rows[i]["branch"].ToString() + "');");
                    str.Append("data.setValue(" + i + "," + 1 + "," + dt1.Rows[i]["overdue"].ToString() + ") ;");
                    str.Append("data.setValue(" + i + "," + 2 + "," + dt1.Rows[i]["osamount"].ToString() + ") ;");
                }
            }

            str.Append("   var chart = new google.visualization.ColumnChart(document.getElementById('chart_divbar'));");
            str.Append(" chart.draw(data, {width: 1300, height: 343, title: 'Oustanding',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}} ,colors: ['#4ebcd5','#bce3c8']");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                int Row_Index = GridView1.SelectedRow.RowIndex;
                //string legdername = GridView1.Rows[Row_Index].Cells[3].Text.ToString();
                //string customerid = GridView1.Rows[Row_Index].Cells[4].Text.ToString();
                string legdername = GridView1.Rows[Row_Index].Cells[4].Text.ToString();
                string customerid = GridView1.Rows[Row_Index].Cells[10].Text.ToString();
                dtuser = obj_UP.GetFormwiseuserRights(1366, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/CreditExemptionList.aspx?type=" + type + "&legdername=" + legdername + "&customerid=" + customerid);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                if (e.Row.Cells[1].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
            
            double dbl_temp = 0;
            if (double.TryParse(e.Row.Cells[5].Text.ToString(), out dbl_temp))
            {
                //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                e.Row.Cells[5].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                e.Row.Cells[5].Attributes.CssStyle["text-align"] = "Right";
            }
        }

        protected void Grid_creditapprovallimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(966, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/CreditApprovelLimits.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
          

        }

        protected void Grid_creditapprovallimit_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_creditapprovallimit, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Center";
                }
            }
            double dbl_temp = 0;
            if (double.TryParse(e.Row.Cells[3].Text.ToString(), out dbl_temp))
            {
                //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                e.Row.Cells[3].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
            }
        }

        protected void lnk_creditrequest_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["Grid_creditapprovallimit"] as DataTable;

            if (Grid_creditapprovallimit.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=CreditApprovalLimit.xls");
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

        protected void Link_overdue_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["Grid_overdue"] as DataTable;
            dt_check.Columns.Remove("customerid");
            dt_check.Columns.Remove("subgroupid");
            if (Grid_overdue.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Overdue.xls");
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

        protected void Link_excep_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["GridView2"] as DataTable;
            if (GridView1.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);
                   
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Exemption List.xls");
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

        protected void Link_request_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["grid_Creditrequest"] as DataTable;
            if (grid_Creditrequest.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Creditrequest.xls");
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

        protected void Link_ousta_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["grdOutStanding"] as DataTable;
            if (grdOutStanding.Rows.Count > 0)
            {
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
                }
            } 
        }

        protected void grdOutStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                int Row_Index = grdOutStanding.SelectedRow.RowIndex;
                string legdername = grdOutStanding.Rows[Row_Index].Cells[1].Text.ToString();
                string customerid = grdOutStanding.Rows[Row_Index].Cells[2].Text.ToString();
                string subgroupid = grdOutStanding.Rows[Row_Index].Cells[3].Text.ToString();
                string subgroupname = grdOutStanding.Rows[Row_Index].Cells[4].Text.ToString();

                dtuser = obj_UP.GetFormwiseuserRights(1429, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/OutstandingNew.aspx?type=" + type + "&legdername=" + legdername + "&customerid=" + customerid + "&subgroupid=" + subgroupid + "&subgroupname=" + subgroupname);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void grdOutStanding_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double dbl_temp = 0;
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }


                    if (double.TryParse(e.Row.Cells[5].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[5].Text = string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[5].Attributes.CssStyle["text-align"] = "Right";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdOutStanding, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Center";
                }
            }
        }

        protected void grid_Creditrequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }

                int Row_Index = grid_Creditrequest.SelectedRow.RowIndex;
                string customername = grid_Creditrequest.Rows[Row_Index].Cells[1].Text.ToString();
                dtuser = obj_UP.GetFormwiseuserRights(1429, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "customer";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/CreditRequestDetails.aspx?type=" + type + "&customername=" + customername);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void grid_Creditrequest_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grid_Creditrequest, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Center";
                }
            }
        }

        protected void Grid_overdue_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbal_Header.Visible = false;
            div_dsoday.Visible = false;
            div_dsoday11.Visible = false;
            Panel3.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }

                int Row_Index = Grid_overdue.SelectedRow.RowIndex;
                string legdername = Grid_overdue.Rows[Row_Index].Cells[1].Text.ToString();
                string customerid = Grid_overdue.Rows[Row_Index].Cells[2].Text.ToString();
                string subgroupid = Grid_overdue.Rows[Row_Index].Cells[3].Text.ToString();
                string subgroupname = Grid_overdue.Rows[Row_Index].Cells[4].Text.ToString();

                dtuser = obj_UP.GetFormwiseuserRights(1429, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/OutstandingNew.aspx?type=" + type + "&legdername=" + legdername + "&customerid=" + customerid + "&subgroupid=" + subgroupid + "&subgroupname=" + subgroupname);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void Grid_overdue_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_overdue, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Center";
                }
            }
            if (e.Row.Cells[1].Text == "Total")
            {
                e.Row.ForeColor = System.Drawing.Color.Brown;
                e.Row.Cells[0].Text = "";
            }
            double dbl_temp = 0;
            if (double.TryParse(e.Row.Cells[5].Text.ToString(), out dbl_temp))
            {
                //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                e.Row.Cells[5].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                e.Row.Cells[5].Attributes.CssStyle["text-align"] = "Right";
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            DataTable obj_dtEmp = new DataTable();
            if (Session["dttt"] != null)
            {
                obj_dtEmp = (DataTable)Session["dttt"];

                //DataView data1 = obj_dtEmp.DefaultView;
                //data1.RowFilter = "divsname  Like'" + cmbbranch.SelectedValue.Substring(0, 1) + "%'";
                //dt1 = data1.ToTable();

                grd.DataSource = obj_dtEmp;
                grd.DataBind();
            }
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "test", "TxtFocus();", true);
        }

        protected void CustomerRating_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }

                dtuser = obj_UP.GetFormwiseuserRights(1451, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/CreditPattern.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["GridView1"];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}