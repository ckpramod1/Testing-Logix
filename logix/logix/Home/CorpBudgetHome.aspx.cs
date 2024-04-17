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

namespace logix.Home
{
    public partial class CorpBudgetHome : System.Web.UI.Page
    {
        DataTable dtCout = new DataTable();
        DataAccess.Accounts.Payment objpay = new DataAccess.Accounts.Payment();

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
        Double data = 0;
        DataSet dst = new DataSet();

        int bid, dsodays;
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DateTime joudate;
        protected void Page_Load(object sender, EventArgs e)
        {
            oceanFCLTues();
            barchart();
        }

        public void oceanFCLTues()
        {
            dst = objpay.GetBudetVsActual4Home(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

            if (dst.Tables.Count > 0)//
            {
                
                lnkweight.Text = dst.Tables[0].Rows[0]["Actual"].ToString();
                lnkAIweight.Text = dst.Tables[0].Rows[1]["Actual"].ToString();
                lnkCHA.Text = dst.Tables[0].Rows[2]["Actual"].ToString();
                Link_Budget.Text = dst.Tables[0].Rows[3]["Budget"].ToString();
                Link_Actual.Text = dst.Tables[0].Rows[3]["Actual"].ToString();
                LinkFCL.Text = dst.Tables[0].Rows[4]["Budget"].ToString();
                LinkFCLmp3.Text = dst.Tables[0].Rows[4]["Actual"].ToString();
                lnkFCl.Text = dst.Tables[0].Rows[5]["Actual"].ToString();
                lnkm3.Text = dst.Tables[0].Rows[6]["Actual"].ToString();
            }
        }

        protected void LinkFCL_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void LinkFCLmp3_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void lnkFCl_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void lnkm3_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void lnkweight_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void lnkAIweight_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void lnkCHA_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
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
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx");

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
                string type = "Performance Analysis - N vs F";
                dtuser = obj_UP.GetFormwiseuserRights(748, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/Performanceactivity.aspx?type=" + type);

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
                dtuser = obj_UP.GetFormwiseuserRights(751, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Corporate/Performancecomparison.aspx");

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
                string formsince1= "Revenue Projections";
                dtuser = obj_UP.GetFormwiseuserRights(749, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/VolumeProjection.aspx?type=" + formsince1);

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
                string formtds1 = "Volume projections";
                dtuser = obj_UP.GetFormwiseuserRights(750, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/VolumeProjection.aspx?type=" + formtds1);

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
                dtuser = obj_UP.GetFormwiseuserRights(1431, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../CRM/Budgetsales.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void Link_Budget_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void Link_Actual_Click(object sender, EventArgs e)
        {
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(421, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                string type = "credit";
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ActualPerformance.aspx?type=" + type);

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }


        public void barchart()
        {

            dst = objpay.GetBudetVsActual4Home(Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Product');
            data.addColumn('number', 'Budget');
            data.addColumn('number', 'Actual');

            data.addRows(" + dst.Tables[1].Rows.Count + ");");



            for (int i = 0; i <= dst.Tables[1].Rows.Count - 1; i++)
            {


                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dst.Tables[1].Rows[i]["Product"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dst.Tables[1].Rows[i]["Budget"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dst.Tables[1].Rows[i]["Actual"].ToString() + ") ;");

               

            }

            str.Append("   var chart = new google.visualization.ColumnChart(document.getElementById('chart_divbar'));");
            str.Append(" chart.draw(data, {width: 1300, height: 300, title: 'BudgetRevenue Vs ActualRevenue',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}} ,colors: ['#4ebcd5','#bce3c8']");
            str.Append("}); }");
            str.Append("</script>");
            lts.Text = str.ToString().Replace('*', '"');
        }
    }
}