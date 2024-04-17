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
    public partial class CorpAccNFinance : System.Web.UI.Page
    {
        DataTable dtCout = new DataTable();

        DataAccess.Accounts.Payment paymentobj = new DataAccess.Accounts.Payment();
        DataAccess.Accounts.Payment objpay = new DataAccess.Accounts.Payment();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.DashBoard.LeftFrame leftObj = new DataAccess.DashBoard.LeftFrame();
        DataAccess.Accounts.Approval Appobj = new DataAccess.Accounts.Approval();
        DataAccess.DashBoard.RightFrame rightObj = new DataAccess.DashBoard.RightFrame();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();       
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
        DataSet Dtset = new DataSet();
        DataTable dt = new DataTable();
        string FADbname;
        int branchid;
        string voutype;
        int chkledgerid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btn_Get.Attributes.Add("OnClick", "return IsDate('txt_date')");             
                string Str_CurrrentDate = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                txt_date.Text = Str_CurrrentDate;
                Loaddata();
                Bankbalancetitle.Visible = false;
                GridbankBNL.Visible = false;
                PettyCash.Visible = false;
                lnk_Grid_bankbalance.Visible = false;
                lnk_Grid_cashbalance.Visible = false;
                btn_cancel.Visible = false;
                lbl_Header.Visible = true;
                linechart();
                count1();
                count2();
                Get_PaymentsCounts();
                Get_PaymentsPettyCashCounts();
                Get_PaymentsAdminTDS();
                paymentrequest();
                approvalcount();
            }
          
        }



        public void approvalcount()
        {
            DataTable dt = new DataTable();
            dt = objpay.getDNApprovalcount(Convert.ToInt32(Session["LoginBranchid"]), "DN");
            if (dt.Rows.Count > 0)
            {
                Link_approvalDN.Text = Convert.ToInt32(dt.Rows[0]["DN"]).ToString();
            }
            else
            {
                Link_approvalDN.Text = "0";
            }
            dt = objpay.getDNApprovalcount(Convert.ToInt32(Session["LoginBranchid"]), "PA");
            if (dt.Rows.Count > 0)
            {
                Link_ApprovalCN.Text = Convert.ToInt32(dt.Rows[0]["PA"]).ToString();
            }
            else
            {
                Link_ApprovalCN.Text = "0";
            }

        }

        protected void Link_approvalDN_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            frmdeopositdetails.Visible = false;
            lnk_Grid_cashbalance.Visible = false;
            GridbankBNL.Visible = false;
            lbl_Header.Visible = false;
            PettyCash.Visible = false;
            Bankbalancetitle.Visible = false;
            //  visible_false();
            div_DnCnApp.Visible = true;
            lblHead.Text = "Profoma DNApproval - Admin";
            hid_type.Value = "DN";
            Fn_LoadDetail1();

        }


        protected void Link_ApprovalCN_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            frmdeopositdetails.Visible = false;
            lnk_Grid_cashbalance.Visible = false;
            GridbankBNL.Visible = false;
            Bankbalancetitle.Visible = false;
            lbl_Header.Visible = false;
            div_DnCnApp.Visible = true;
            lblHead.Text = "Profoma CNApproval - Admin";
            hid_type.Value = "PA";
            Fn_LoadDetail1();
        }
        private void Fn_LoadDetail1()
        {
            DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
            DataAccess.Accounts.ProAdminDCNNo ProDCNObj = new DataAccess.Accounts.ProAdminDCNNo();
            DataTable obj_dt = new DataTable();
            obj_dt = ProDCNObj.GetApproveProAdminDCN(hid_type.Value.ToString(), int.Parse(Session["LoginBranchid"].ToString()));
            Grd_Admin.DataSource = obj_dt;
            Grd_Admin.DataBind();
        }


        public void Get_PaymentsCounts()
        {
            Double bankbalance = 0;
            FADbname = Session["FADbname"].ToString();
            int Vyraer = Convert.ToInt32(Session["Vouyear"]);
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            dt = paymentobj.getbankbalance(FADbname, branchid);
            bankbalance = Math.Round(Convert.ToDouble(dt.Rows[0][0]));

            if (bankbalance.ToString().Substring(0,1)=="-")
            {
                id_bnk.InnerHtml = "CR";
            }
            else
            {
                id_bnk.InnerHtml = "DR";
            }
            if (dt.Rows.Count > 0)
            {
                Lnk_BankBal.Text = bankbalance.ToString("#,0") + "";
            }
            else
            {
                Lnk_BankBal.Text = "0";
            }


           
           
           
           
        }

        public void Get_PaymentsPettyCashCounts()
        {
            double cashbalance = 0;
            FADbname=  Session["FADbname"].ToString();
            int Vyraer = Convert.ToInt32(Session["Vouyear"]);
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            dt = paymentobj.getcashbalance(FADbname, branchid);
           cashbalance = Math.Round(Convert.ToDouble(dt.Rows[0][0].ToString()));
           if (cashbalance.ToString().Substring(0, 1) == "-")
           {
               lbl_pcb.InnerHtml = "CR";
           }
           else
           {
               lbl_pcb.InnerHtml = "DR";
           }
            if (dt.Rows.Count > 0)
            {
                lnk_PCBal.Text = cashbalance.ToString("#,0")+"";
            }
            else
            {
                lnk_PCBal.Text = "0";
            }



        }

        public void Get_PaymentsAdminTDS()
        {
           
            branchid = int.Parse(Session["LoginBranchid"].ToString());
            dt = paymentobj.getcreditnote_tds(branchid,"P");

            if (dt.Rows.Count>0)
            {
                lbltds.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                lbltds.Text = "0";
            }
         


        }

        protected void Link_CNOPS_Click(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            
            dtuser = obj_UP.GetFormwiseuserRights(998, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CnOps";
                Response.Redirect("../Accounts/ChequeRequestApproval.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void Link_CN_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
           
            dtuser = obj_UP.GetFormwiseuserRights(998, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CN";
                Response.Redirect("../Accounts/ChequeRequestApproval.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void link_CNADmin_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
          
            dtuser = obj_UP.GetFormwiseuserRights(998, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CN Admin";
                Response.Redirect("../Accounts/ChequeRequestApproval.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }



        public void count1()
        {
            dtCout = objpay.getpaymentrquest(Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (dtCout.Rows.Count > 0)
            {

                if (dtCout.Rows[0]["voutype"].ToString() == "E")
                {

                    link_cnn.Text = dtCout.Rows[0]["counts"].ToString();
                }
                else
                {
                    link_cnn.Text = "0";
                }
                if (dtCout.Rows[1]["voutype"].ToString() == "P")
                {
                    link_CNOP.Text = dtCout.Rows[1]["counts"].ToString();
                }
                else
                {
                    link_CNOP.Text = "0";
                }
                if (dtCout.Rows[2]["voutype"].ToString() == "S")
                {
                    link_cnadmins.Text = dtCout.Rows[2]["counts"].ToString();
                }
                else
                {
                    link_cnadmins.Text = "0";
                }

            }

        }

        public void count2()
        {
            dtCout = objpay.getcreditnote_operation("PA", "CA", 0, Convert.ToInt32(Session["LoginDivisionId"]));
            if (dtCout.Rows.Count > 0)
            {

                if (dtCout.Rows[0]["voutype"].ToString() == "P")
                {

                    Link_CNOPS.Text = dtCout.Rows[0]["counts"].ToString();
                }
                else
                {
                    Link_CNOPS.Text = "0";
                }
            }
            dtCout = objpay.getcreditnote_operation("CN", "CA", 0, Convert.ToInt32(Session["LoginDivisionId"]));

            if (dtCout.Rows.Count > 0)
            {

                if (dtCout.Rows[0]["voutype"].ToString() == "E")
                {

                    Link_CN.Text = dtCout.Rows[0]["counts"].ToString();
                }
                else
                {
                    Link_CN.Text = "0";
                }
            }
            dtCout = objpay.getcreditnote_operation("AP", "CA", 0, Convert.ToInt32(Session["LoginDivisionId"]));

            if (dtCout.Rows.Count > 0)
            {

                if (dtCout.Rows[0]["voutype"].ToString() == "S")
                {

                    link_CNADmin.Text = dtCout.Rows[0]["counts"].ToString();
                }
                else
                {
                    link_CNADmin.Text = "0";
                }
            }

        }


        protected void link_button_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(643, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ChequeBounce.aspx?type=" + "Payment Cancel");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
           
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(1056, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/ACNotOverCheque.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(545, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/VoucherRegister.aspx?type=VoucherRegister");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(1342, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/Sinsaudit.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(562, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {

                    Response.Redirect("../Accounts/TDSidForCustomer.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
           
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            string trantype_process = Session["StrTranType"].ToString();
            DataTable dtuser = new DataTable();
            if (trantype_process == "CO")
            {
                if (Session["StrTranType"].ToString() == "CO")
                {
                    Session["RightsTranType"] = "MI";
                }
                dtuser = obj_UP.GetFormwiseuserRights(560, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
                if (dtuser.Rows.Count > 0)
                {
                   
                    Response.Redirect("../Accounts/JobSee.aspx");

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "CorpAcc&Finance", "alertify.alert('" + message + "');", true);

                }
            }
            
        }

        public void BANKBALANCE()
        {
        
           /* //FADbname = "FA1718";
            FADbname = Session["FADbname"].ToString();
            dt = objpay.GetBankBalancefordashboard(FADbname.ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            if (dt.Rows.Count > 0)
            {
                Grid_bankbalance.DataSource = dt;
                Grid_bankbalance.DataBind();
            }
            else
            {

            }
            lnk_Grid_bankbalance.Visible = true;
            ViewState["Grid_bankbalanceexp2ex"] = dt;*/

            //FADbname = "FA1718";
            Double debit = 0;
            Double credit = 0;
            DataTable dts = new DataTable();
            double closebal = 0, closebal1 = 0;
            FADbname = Session["FADbname"].ToString();
            dt = objpay.GetBankBalancefordashboard(FADbname.ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            dts.Columns.Add("S#");
            dts.Columns.Add("Bank");
            dts.Columns.Add("Debit");
            dts.Columns.Add("Credit");
            DataRow dr;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = dts.NewRow();
                    dts.Rows.Add();
                    dts.Rows[i]["S#"] = dt.Rows[i]["sno"];
                    dts.Rows[i]["Bank"] = dt.Rows[i]["bank"];
                    if (dt.Rows[i]["type"].ToString() == "D")
                    {
                        dts.Rows[i]["Debit"] = dt.Rows[i]["closingbal"];
                        if (string.IsNullOrEmpty(dt.Rows[i]["closingbal"].ToString()) != true)
                        {
                            closebal = closebal + Convert.ToDouble(dt.Rows[i]["closingbal"].ToString());
                        }
                        else
                        {
                            closebal = closebal + 0;
                        }
                    }
                   
                    if (dt.Rows[i]["type"].ToString() == "C")
                    {
                        dts.Rows[i]["Credit"] = dt.Rows[i]["closingbal"];
                        if (string.IsNullOrEmpty(dt.Rows[i]["closingbal"].ToString()) != true)
                        {
                            closebal1 = closebal1 + Convert.ToDouble(dt.Rows[i]["closingbal"].ToString());
                        }
                        else
                        {
                            closebal1 = closebal1 + 0;
                        }
                    }
                   
                }

                //debit = Convert.ToDouble(dts.Compute("sum(Debit)", ""));
                //credit = Convert.ToDouble(dts.Compute("sum(Credit)", ""));
                //debit = Convert.ToDouble(dts.Compute("sum(closingbal)", ""));
               // credit = Convert.ToDouble(dts.Compute("sum(closingbal)", ""));
                dts.Rows.Add();
                dts.Rows[dts.Rows.Count - 1]["Bank"] = "Total";
                dts.Rows[dts.Rows.Count-1]["Debit"] = closebal.ToString("#,0.00") + "";
                dts.Rows[dts.Rows.Count-1]["Credit"] = closebal1.ToString("#,0.00") + "";
                Grid_bankbalance.DataSource = dts;
                Grid_bankbalance.DataBind();
                lnk_Grid_bankbalance.Visible = true;
                ViewState["Grid_bankbalanceexp2ex"] = dts;
            }
            else
            {

            }
            
        }
        public void CASHBALANCE()
        {
           
           /* FADbname = Session["FADbname"].ToString();
            dt = objpay.GetCashBalancefordashboard(FADbname.ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            if (dt.Rows.Count > 0)
            {
                Grid_cashbalance.DataSource = dt;
                Grid_cashbalance.DataBind();
            }
            else
            {

            }*/

            double closebal = 0, closebal1 = 0;
            Double debit = 0;
            Double credit = 0;
            DataTable dts = new DataTable();
            FADbname = Session["FADbname"].ToString();
            dt = objpay.GetCashBalancefordashboard(FADbname.ToString(), Convert.ToInt32(Session["LoginBranchid"]));
            dts.Columns.Add("S#");
            dts.Columns.Add("Bank");
            dts.Columns.Add("Debit");
            dts.Columns.Add("Credit");
            DataRow dr;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dr = dts.NewRow();
                    dts.Rows.Add();
                    dts.Rows[i]["S#"] = dt.Rows[i]["sno"];
                    dts.Rows[i]["Bank"] = dt.Rows[i]["bank"];
                    if (dt.Rows[i]["type"].ToString() == "D")
                    {
                        dts.Rows[i]["Debit"] = dt.Rows[i]["closingbal"];
                        if (string.IsNullOrEmpty(dt.Rows[i]["closingbal"].ToString()) != true)
                        {
                            closebal = closebal + Convert.ToDouble(dt.Rows[i]["closingbal"].ToString());
                        }
                        else
                        {
                            closebal = closebal + 0;
                        }
                    }
                    if (dt.Rows[i]["type"].ToString() == "C")
                    {
                        dts.Rows[i]["Credit"] = dt.Rows[i]["closingbal"];
                        if (string.IsNullOrEmpty(dt.Rows[i]["closingbal"].ToString()) != true)
                        {
                            closebal1 = closebal1 + Convert.ToDouble(dt.Rows[i]["closingbal"].ToString());
                        }
                        else
                        {
                            closebal1 = closebal1 + 0;
                        }
                    }
                }
                //debit = Convert.ToDouble(dts.Compute("sum(closingbal)", ""));
                //credit = Convert.ToDouble(dts.Compute("sum(closingbal)", ""));
                dts.Rows.Add();
                dts.Rows[dts.Rows.Count - 1]["Bank"] = "Total";
                dts.Rows[dts.Rows.Count - 1]["Debit"] = closebal.ToString("#,0.00") + "";
                dts.Rows[dts.Rows.Count - 1]["Credit"] = closebal1.ToString("#,0.00") + "";

                Grid_cashbalance.DataSource = dts;
                Grid_cashbalance.DataBind();
                ViewState["Grid_cashbalanceexp2ex"] = dts;

            }
            else
            {

            }
           
        }

        protected void lnk_PCBal_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            frmdeopositdetails.Visible = false;
            lnk_Grid_cashbalance.Visible = true;
            Bankbalancetitle.Visible = false;
            Grid_cashbalance.Visible = true;
            Grid_bankbalance.Visible = false;
            GridbankBNL.Visible = false;
            PettyCash.Visible = true;
            lbl_Header.Visible = false;
            div_DnCnApp.Visible = false;
            PettyCash.Visible = true; 
            CASHBALANCE();
        }

        protected void lbltds_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "CO")
            {
                Session["RightsTranType"] = "MI";
            }
            GridbankBNL.Visible = false;
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
            dtuser = obj_UP.GetFormwiseuserRights(652, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CN-Admin TDS";
              
              Response.Redirect("../Accounts/PATDS.aspx?type=" + type + "&UIID=" + 652);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void Lnk_BankBal_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            frmdeopositdetails.Visible = false;
            Bankbalancetitle.Visible = true;
            Grid_cashbalance.Visible = false;
            Grid_bankbalance.Visible = true;
            GridbankBNL.Visible = true;
            PettyCash.Visible = false;
            lbl_Header.Visible = false;
            div_DnCnApp.Visible =false;
            
            BANKBALANCE();
        }

        protected void link_CNOP_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "CO")
            {
                Session["RightsTranType"] = "MI";
            }
            GridbankBNL.Visible = false;
           
            DataTable dtuser = new DataTable();
            // string uiid = "1065";
            dtuser = obj_UP.GetFormwiseuserRights(376, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "Payments";
                Response.Redirect("../Accounts/PaymentFA.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void link_cnn_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "CO")
            {
                Session["RightsTranType"] = "MI";
            }
            GridbankBNL.Visible = false;
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
            // string uiid = "1065";
            dtuser = obj_UP.GetFormwiseuserRights(376, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "Payments";
                Response.Redirect("../Accounts/PaymentFA.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void link_cnadmins_Click(object sender, EventArgs e)
        {
            if (Session["StrTranType"].ToString() == "CO")
            {
                Session["RightsTranType"] = "MI";
            }
            GridbankBNL.Visible = false;
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
            // string uiid = "1065";
            dtuser = obj_UP.GetFormwiseuserRights(376, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "Payments";
                Response.Redirect("../Accounts/PaymentFA.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }


        public void paymentrequest()
        {

            dtCout = objpay.getcreditnote_opera("PA", "AC", Convert.ToInt32(Session["LoginBranchId"]), Convert.ToInt32(Session["LoginDivisionId"]));

            if (dtCout.Rows.Count > 0)
            {

                if (dtCout.Rows[0]["voutype"].ToString() == "P")
                {

                    link_CNADminreq.Text = dtCout.Rows[0]["counts"].ToString();
                }
                else
                {
                    link_CNADminreq.Text = "0";
                }
            }
            dtCout = objpay.getcreditnote_opera("CN", "AC", Convert.ToInt32(Session["LoginBranchId"]), Convert.ToInt32(Session["LoginDivisionId"]));
            if (dtCout.Rows.Count > 0)
            {

                if (dtCout.Rows[0]["voutype"].ToString() == "E")
                {

                    link_cnpayreq.Text = dtCout.Rows[0]["counts"].ToString();
                }
                else
                {
                    link_cnpayreq.Text = "0";
                }
            }
        }

        protected void Lnk_paymentreq_Click(object sender, EventArgs e)
        {
            GridbankBNL.Visible = false;
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "CO")
            {
                Session["RightsTranType"] = "MI";
            }
            dtuser = obj_UP.GetFormwiseuserRights(1072, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "Payment Request";
                Response.Redirect("../Accounts/ChequeRequest.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }


        protected void btn_Approve_Click(object sender, EventArgs e)
        {

          
                try
                {

                    int int_Empid = 0, int_bid = 0, int_divisionid = 0, int_intdcno = 0, int_Vouyear = 0, int_DCno = 0, int_Voutypeid = 0;
                    string Str_Trantype = Session["StrTranType"].ToString();
                    int_Empid = int.Parse(Session["LoginEmpId"].ToString());
                    int_bid = int.Parse(Session["LoginBranchid"].ToString());
                    int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
                    DataTable obj_dt = new DataTable();
                    DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                    DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                    DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                    DataAccess.Accounts.ProAdminDCNNo ProDCNObj = new DataAccess.Accounts.ProAdminDCNNo();
                    bool flag = true;
                    List<string> Lst_DNno = new List<string>();
                    foreach (GridViewRow row in Grd_Admin.Rows)
                    {
                        CheckBox Chk = (CheckBox)row.FindControl("Chk_Approval");
                        if (Chk.Checked == true)
                        {
                            // int_intdcno = obj_da_Approval.GetNoforAcForApproval(int_bid, hid_type.Value.ToString());

                            int_Vouyear = int.Parse(Grd_Admin.DataKeys[row.RowIndex].Values[0].ToString());
                            int_intdcno = int.Parse(Grd_Admin.DataKeys[row.RowIndex].Values[1].ToString());
                            if (hid_type.Value.ToString() == "DN")
                            {
                                //obj_dt = obj_da_Invoice.GetPartyLedger4proPAAdmin(int_intdcno, "D", int_bid, int_Vouyear);
                                obj_dt = obj_da_Invoice.GetPartyLedger4PAPROAdminwithCust(int_intdcno, "D", int_bid, int_Vouyear);
                                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                                {
                                    chkledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int.Parse(obj_dt.Rows[i]["chargeid"].ToString()), obj_dt.Rows[i]["opstype"].ToString(), Session["FADbname"].ToString());
                                    if (chkledgerid == 0)
                                    {
                                        flag = false;
                                    }
                                }
                            }
                            if (flag == false)
                            {
                                ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "AdminDNCNApproval", "alertify.alert('LedgerName Not Found in Financial. You are not able to Approve DN " + int_intdcno + " Contact Your  Finanace Head');", true);
                            }
                            DataAccess.Accounts.AdminDCNNo obj_da_AdminDNCN = new DataAccess.Accounts.AdminDCNNo();
                            DataAccess.Accounts.ProAdminDCNNo obj_da_ProAdminDNCN = new DataAccess.Accounts.ProAdminDCNNo();
                            if (flag == true)
                            {
                                if (hid_type.Value.ToString() == "DN")
                                {
                                    int_DCno = obj_da_AdminDNCN.GetAdmDNno(int_bid);
                                }
                                else
                                {
                                    int_DCno = obj_da_AdminDNCN.GetAdmCNno(int_bid);
                                }


                                obj_da_ProAdminDNCN.UpdApprovalProAdminDCN(int_DCno, int_Empid, hid_type.Value.ToString(), int_Vouyear, int_bid, int_intdcno);
                                if (Session["LoginBranchName"].ToString() == "CO - ACCOUNTS")
                                {
                                    if (hid_type.Value.ToString() == "PA")
                                    {
                                        obj_da_Log.InsLogDetail(int_Empid, 1063, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                    }
                                    else
                                    {
                                        obj_da_Log.InsLogDetail(int_Empid, 1062, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                    }

                                }
                                else
                                {
                                    if (hid_type.Value.ToString() == "PA")
                                    {
                                        obj_da_Log.InsLogDetail(int_Empid, 1049, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                    }
                                    else
                                    {
                                        obj_da_Log.InsLogDetail(int_Empid, 1050, 1, int_bid, hid_type.Value.ToString() + "# - " + int_intdcno);
                                    }
                                }
                                Lst_DNno.Insert(row.RowIndex, int_DCno.ToString());
                            }
                        }
                        if (flag == true)
                        {
                            if (hid_type.Value.ToString() == "DN")
                            {//raj
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DCno, int_DCno, "Remarks", "Ref No", int_bid);
                                try
                                {
                                    obj_dt = obj_da_Invoice.FAShowTallyDt(int_DCno, "DN-Admin", int.Parse(Session["Vouyear"].ToString()), int_bid);
                                    if (obj_dt.Rows.Count > 0)
                                    {
                                        int int_custid = int.Parse(obj_dt.Rows[0].ItemArray[4].ToString());

                                        DateTime date_Voudate = Convert.ToDateTime(obj_dt.Rows[0].ItemArray[1].ToString());
                                        int int_Ledgerid = 0;
                                        int_Ledgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_custid, "C", Session["FADbname"].ToString());
                                        int_Voutypeid = obj_da_FAVoucher.Selvoutypeid("Admin Sales Invoice", Session["FADbname"].ToString());
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = Fn_Getcustomergroupid1(int_custid);
                                        }
                                        obj_da_Approval.InsLedgerOPBreakup(int_Ledgerid, int_DCno, Convert.ToDateTime(date_Voudate.ToShortDateString()), 'X', int_Vouyear, int_bid, double.Parse(row.Cells[3].Text.ToString()), "", 0.0, int_custid);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // Utility.SendMail("", "", "FA RECEIPT PMT - ERROR In ProAdminDCNApproval DNAdmin # " + int_DCno + " \\Year - " + Session["Vouyear"].ToString() + " \\BID - " + int_bid, ex.ToString(), "", Session["usermailpwd"].ToString());
                                }
                            }
                        }
                    }
                    if (int_DCno != 0)
                    {
                        string Str_DNNO = string.Join(",", Lst_DNno);
                        if (hid_type.Value.ToString() == "DN")
                        {
                            ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "AdminDNCNApproval", "alertify.alert('DN # " + Str_DNNO + " Generated and Transfered');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btn_Approve, typeof(Button), "AdminDNCNApproval", "alertify.alert('CN # " + Str_DNNO + " Generated and Transfered');", true);
                        }
                        Fn_LoadDetail1();
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
           
        }
        protected void Grd_Admin_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }

        private int Fn_Getcustomergroupid1(int int_Custid)
        {
            int int_Subgroupid = 0, int_Groupid = 0, int_Ledgerid = 0;
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            if (hid_type.Value.ToString() == "DN")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;

                int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Session["FADbname"].ToString());
            }
            return int_Ledgerid;
        }

        protected void btn_cancel1_Click(object sender, EventArgs e)
        {
            if (btn_cancel1.ToolTip == "Cancel")
            {
                Grd_Admin.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Admin.DataBind();
                //btn_cancel1.Text = "Back";

                btn_cancel1.ToolTip = "Back";
                btn_cancel11.Attributes["class"] = "btn ico-back";
            }
            else
            {
              
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "AC&FINhome")
                    {

                        Response.Redirect("../Home/CorpAccNFinance.aspx");
                    }
                    else
                    {
                        this.Response.End();
                    }
                }

                else
                {
                    this.Response.End();
                }
            }
        }

        protected void Grd_Deposit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grd_Deposit.Rows.Count > 0)
                {
                    Grd_detail.Visible = true;
                    grdViewDetails.Visible = true;
                    int bid = Convert.ToInt32(Grd_Deposit.SelectedDataKey.Values[0].ToString());
                    DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
                    DataTable obj_dt = new DataTable();
                    obj_dt = obj_da_Receipt.Getdetails4branchfromDeposit(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), int.Parse(Session["LoginDivisionId"].ToString()));
                    var total = obj_dt.Compute("sum(amount)", "");
                    if (obj_dt.Rows.Count > 0)
                    {
                        DataRow dr;
                        dr = obj_dt.NewRow();
                        obj_dt.Rows.Add(dr);
                        dr[2] = "Total"; ;
                        dr[3] = total;
                    }
                    Grd_detail.DataSource = obj_dt;
                    Grd_detail.DataBind();
                    btn_cancel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void Grd_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "Total")
                {
                    e.Row.Cells[0].Text = "";

                }
            }
        }

        protected void Grd_Deposit_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //if (e.Row.Cells[1].Text == "Total")
                //{
                //    e.Row.Cells[0].Text = "";


                //    //LinkButton Lnk = (LinkButton)e.Row.Cells[e.Row.Cells.Count - 1].FindControl("Lnk_Deposit");
                //    //Lnk.Visible = false;
                //}
                //else
                //{
                //    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Deposit, "Select$" + e.Row.RowIndex);
                //    e.Row.Attributes["style"] = "cursor:pointer";
                //}

                 for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                    
                }

                 if (e.Row.Cells[1].Text == "Total")
                 {


                     e.Row.ForeColor = System.Drawing.Color.Brown;
                 }
                 else if (e.Row.Cells[1].Text != "Total")
                 {
                    e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#aad0ed';");
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Deposit, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            
            }
        }

        private void Loaddata()
        {
            try
            {
                if (txt_date.Text.ToString().Trim().Length > 0)
                {
                    DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
                    DataTable obj_dt = new DataTable();
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "branch", DataType = typeof(string) });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "amount", DataType = typeof(double), DefaultValue = 0 });
                    obj_dt.Columns.Add(new DataColumn { ColumnName = "id", DataType = typeof(int) });
                    obj_dt = obj_da_Receipt.Getdeposit4branch(Convert.ToDateTime(Utility.fn_ConvertDate(txt_date.Text)), int.Parse(Session["LoginDivisionId"].ToString()));
                    var total = obj_dt.Compute("sum(amount)", "");
                    DataRow dr;
                    dr = obj_dt.NewRow();
                    obj_dt.Rows.Add(dr);
                    dr[0] = "Total"; ;
                    //dr[1] = Math.Round(double.Parse(total.ToString()));
                    dr[1] = total;
                    Grd_Deposit.DataSource = obj_dt;
                    Grd_Deposit.DataBind();
                }
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
                  string Str_CurrrentDate = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            txt_date.Text = Str_CurrrentDate;
            Grd_Deposit.DataSource = new DataTable();
            Grd_Deposit.DataBind();
            Grd_detail.DataSource = new DataTable();
            Grd_detail.DataBind();
               // btn_cancel.Text="Back";

            btn_cancel.ToolTip = "Back";
            btn_cancelid1.Attributes["class"] = "btn ico-back";
            }
            else
            {
                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "AC&FINhome")
                    {
                        Response.Redirect("../Home/CorpAccNFinance.aspx");
                    }
                    else if (Session["home"].ToString() == "CredConthome")
                    {
                        Response.Redirect("../Home/CorpCreditControl.aspx");
                    }
                    else if (Session["home"].ToString() == "Budgethome")
                    {
                        Response.Redirect("../Home/CorpBudgetHome.aspx");
                    }
                    else
                    {
                        this.Response.End();
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
          
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        public void linechart()
        {
            DataTable dt0 = new DataTable();
            dt0 = objpay.getExemptionlistHomeline( Convert.ToInt32(Session["LoginDivisionId"]));
            StringBuilder str = new StringBuilder();
            str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Month');
            data.addColumn('number', 'Bank Payments');
            data.addColumn('number', 'Cash Payment');
            data.addColumn('number', 'Bank Receipts');
            data.addColumn('number', 'Cash Receipts');
            data.addColumn('number', 'Remittance Inward');
            data.addColumn('number', 'Remittance Outward');
            data.addRows(" + dt0.Rows.Count + ");");
            for (int i = 0; i <= dt0.Rows.Count - 1; i++)
            {


                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt0.Rows[i]["Month"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt0.Rows[i]["BP"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt0.Rows[i]["CP"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt0.Rows[i]["BR"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 4 + "," + dt0.Rows[i]["CR"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 5 + "," + dt0.Rows[i]["OSR"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 6 + "," + dt0.Rows[i]["OSP"].ToString() + ") ;");
                

            }
            str.Append("var chart = new google.visualization.LineChart(document.getElementById('Liner_chart_div'));");
            str.Append("chart.draw(data, {width: 760, height: 320, title: '',");
            str.Append("hAxis: {title: '', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().Replace('*', '"');

        }

       

        protected void lnk_Grid_bankbalance_Click(object sender, EventArgs e)
        {
            DataTable dt_check = ViewState["Grid_bankbalanceexp2ex"] as DataTable;

            if (Grid_bankbalance.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Bank Balance.xls");
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

        protected void lnk_Grid_cashbalance_Click(object sender, EventArgs e)
        {
             DataTable dt_check = ViewState["Grid_cashbalanceexp2ex"] as DataTable;
          
            if (Grid_cashbalance.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //wb.Worksheets.Add("test");

                    wb.Worksheets.Add(dt_check);

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Petty Cash Balance.xls");
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

        protected void Grid_bankbalance_RowDataBound(object sender, GridViewRowEventArgs e)
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

                double dbl_temp = 0;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[2].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[2].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }

                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[3].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[3].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }
            }
        }

        protected void Grid_cashbalance_RowDataBound(object sender, GridViewRowEventArgs e)
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

                double dbl_temp = 0;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[2].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[2].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }

                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                if (double.TryParse(e.Row.Cells[3].Text.ToString(), out dbl_temp))
                {
                    e.Row.Cells[3].Text = string.Format("{0:#,##0.00}", dbl_temp);
                    e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                    // e.Row.Cells[3].Attributes.CssStyle["text-align"] = "Right";
                }
            }
        }

        protected void link_cnpayreq_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "CO")
            {
                Session["RightsTranType"] = "MI";
            }

            dtuser = obj_UP.GetFormwiseuserRights(1072, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CN";
                Response.Redirect("../Accounts/ChequeRequest.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

        protected void link_CNADminreq_Click(object sender, EventArgs e)
        {
            lbl_Header.Visible = false;
            DataTable dtuser = new DataTable();
            if (Session["StrTranType"].ToString() == "CO")
            {
                Session["RightsTranType"] = "MI";
            }

            dtuser = obj_UP.GetFormwiseuserRights(1072, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["RightsTranType"].ToString());
            if (dtuser.Rows.Count > 0)
            {
                string type = "CnOps";
                Response.Redirect("../Accounts/ChequeRequest.aspx?type=" + type);
            }
            else
            {
                string message = "No Rights";
                ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "OEOpsAndDocs", "alertify.alert('" + message + "');", true);

            }
        }

    }
}