using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;


namespace logix.CommanClass
{

   
    public class TallyEDIFA
    {
        public static int int_Subgroupid = 0, int_Groupid = 0, int_Customerid = 0, int_deptid = 0, int_Receiptid = 0, int_Receiptcount = 0, int_ReceiptBankid = 0;
        public static Boolean Voucher = false, R_Flag = false, bounbln = false;
        public static int int_bid = 0;
        public static int int_divisionid = 0;
        public static int int_Empid = 0;
        public static int int_Vouyear = 0, int_Voutypeid_Corp = 0, int_RBranchid = 0;
        public static string Str_DBname = "", Str_Check = "", str_reciptnar = "", Str_ReceiptNarration = "", Str_ddl_voucher = "", Str_ledgerExp = "", Str_Reference = "", Str_deleted = "", Str_ReceiptBank = "", str_voutype = "", Str_Container = "", Str_Narration = "", Str_FAVoucherType = "", Str_Fcurr = "";
        public static double ReceiptAmount = 0, Amt_F = 0, Exrate = 0;
        public static char Str_Mode;
        public static string partyname = "", strRdate = "", strCHdate = "";
        public static int int_RVouno = 0;
        public static int int_Ryear = 0;
        public static string Str_Rtype = "";

        public static int customerid4branch = 0;
        
        public static void Fn_FATransfer_Slip(string Str_ddlvoucher, string int_from, int int_to, string Str_ddlnarration, string Str_ddlreference, string Str_Reverse = "", int Rvouno = 0, int Ryear = 0, string Rtype = "")
        {
            int_bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int_Empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
            int_Vouyear = Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString());
            Str_DBname = HttpContext.Current.Session["FADbname"].ToString();

            string Str_vouname = "";
            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            DataAccess.Accounts.Journal obj_da_Journal = new DataAccess.Accounts.Journal();
           // DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            int int_Voutypeid = 0;
            DataTable dt_ok = new DataTable();
            DataTable dt_ok1 = new DataTable();
            Str_ddl_voucher = Str_ddlvoucher;
            Fn_Getcustomergroupid(Str_ddlvoucher);
            string status;
            status = "N";
            status = obj_da_FA.getfinalize(int_bid, int_divisionid, int_Empid, Str_DBname);

            if (status == "Y")
            {
                status = "Y";
            }
            else
            {
                status = "N";
            }

            if ((status == "Y" && Str_ddlvoucher == "Bank Receipt") || (status == "Y" && Str_ddlvoucher == "Cash Receipt"))
            {

            }
            else if ((status == "Y" && Str_ddlvoucher != "Bank Receipt") || (status == "Y" && Str_ddlvoucher != "Cash Receipt"))
            {
                return;
            }
            else if (status == "N")
            {

            }

            if (Str_ddlvoucher == "Bank Deposit - Transfer To CO" || Str_ddlvoucher == "Cash Deposit - Transfer To CO")
            {
                int Corid;
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");

                if (Corid == int_bid)
                {
                    return;
                }


                else
                {
                    int_Voutypeid = obj_da_FA.Selvoutypeid("BDJV", Str_DBname);
                    Str_vouname = "Bank  Deposit";
                    Str_ledgerExp = "CHEQUE COLLECTION ACCOUNT";
                    Fn_GetDeposite4BRBD(int_from, int_Voutypeid);
                }
            }
        }

        public static void Fn_FATransfer(string Str_ddlvoucher, int int_from, int int_to, string Str_ddlnarration, string Str_ddlreference, int branchid , string Str_Reverse = "", int Rvouno = 0, int Ryear = 0, string Rtype = "", int vouyearcheck=0,int vouyearTDS=0)
        {
            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();
            log1.Info("********************************************************************************************************************************************************");
            log1.Info("Fn_FATransfer has been Called");
            log1.Info("" + Str_ddlvoucher + " = From - " + int_from + " | To - " + int_to + " | Narr - " + Str_ddlnarration + " | Ref - " + Str_ddlreference + " | Branch - "
                + branchid + " | strRev - " + Str_Reverse + " | Rvouno - " + Rvouno + " | Ryear - " + Ryear + " | Rtype - "
                + Rtype + " | FA_DBname -" + HttpContext.Current.Session["FADbname"].ToString() + " | Vouyear - " + HttpContext.Current.Session["Vouyear"].ToString());

            //log1.Info("" + Str_ddlvoucher + " = From - " + int_from + " | To - " + int_to + " | Narr - " + Str_ddlnarration + " | Ref - " + Str_ddlreference + " | Branch - "
            //    + branchid + " | strRev - " + Str_Reverse + " | Rvouno - " + Rvouno + " | Ryear - " + Ryear + " | Rtype - " + Rtype + "");

            if (branchid == 0)
            {
                int_bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            }
            else
            {
                int_bid = branchid;
            }
            //if (Str_ddlvoucher == "Bank Payment" )
            //{
            //    int_bid = Rvouno;
            //}else if(Str_ddlvoucher == "Cash Payment")
            //{
            //    if (Rvouno == 0)
            //    {
            //        int_bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            //    }
            //    else
            //    {
            //        int_bid = Rvouno;
            //    }
            //}
            //else
            //{
            //    int_bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            //}

            int_Empid = Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"].ToString());
            int_divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
            //int_Vouyear = Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString());


            if (HttpContext.Current.Session["AgainstVouYear"] == null)
            {
                if (vouyearcheck==0)
                {
                    if (vouyearTDS==0)
                    {
                        int_Vouyear = Convert.ToInt32(obj_da_FA.Getvouyearforautotransfer(int_bid).ToString());
                    }
                    else
                    {
                        int_Vouyear = vouyearTDS;
                    }
                   
                }
                else
                {
                    if (HttpContext.Current.Session["LogYear"] != null)
                    {
                        int_Vouyear = Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString());
                    }
                    else
                    {
                        int_Vouyear = Convert.ToInt32(HttpContext.Current.Session["Vouyear"].ToString());
                    }

                }
               


            }
            else
            {
                if (HttpContext.Current.Session["AgainstVou"].ToString() == "True")
                {
                    int_Vouyear = Convert.ToInt32(HttpContext.Current.Session["AgainstVouYear"].ToString());
                }
            }

            Str_DBname = HttpContext.Current.Session["FADbname"].ToString();
            string str_Total_AmountWOST = "", str_Total_Amount = "", str_Total_AmountST = "", TDStype = "";
            string Str_vouname = "";
            //DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            DataAccess.Accounts.Journal obj_da_Journal = new DataAccess.Accounts.Journal();
            int int_Voutypeid = 0;
            DataTable dt_ok = new DataTable();
            DataTable dt_ok1 = new DataTable();
            Str_ddl_voucher = Str_ddlvoucher;
            if (Str_ddl_voucher == "Bill of Supply")
            {
                Str_ddlvoucher = "BOS";
            }
            Fn_Getcustomergroupid(Str_ddlvoucher);
            string status;
            status = "N";
            status = obj_da_FA.getfinalize(int_bid, int_divisionid, int_Empid, Str_DBname);

            if (status == "Y")
            {
                status = "Y";
            }
            else
            {
                status = "N";
            }

            if ((status == "Y" && Str_ddlvoucher == "Bank Receipt") || (status == "Y" && Str_ddlvoucher == "Cash Receipt"))
            {

            }
            else if ((status == "Y" && Str_ddlvoucher != "Bank Receipt") || (status == "Y" && Str_ddlvoucher != "Cash Receipt"))
            {
                return;
            }
            else if (status == "N")
            {

            }

            if (Str_ddlvoucher == "Credit Note - Operations")
            {
                TDStype = "P";
            }
            else if (Str_ddlvoucher == "Credit Note - Others")
            {
                TDStype = "E";
            }
            else if (Str_ddlvoucher == "Admin Purchase Invoice")
            {
                TDStype = "S";
            }

            if (Str_ddlvoucher == "Bank Deposit - Transfer To CO" || Str_ddlvoucher == "Cash Deposit - Transfer To CO")
            {
                int Corid;
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");

                if (Corid == int_bid)
                {
                    return;
                }

                if (int_from == 0)
                {
                    return;
                }
                else
                {
                    int_Voutypeid = obj_da_FA.Selvoutypeid("BDJV", Str_DBname);
                    Str_vouname = "Bank  Deposit";
                    Str_ledgerExp = "CHEQUE COLLECTION ACCOUNT";
                    //  Fn_GetDeposite4BRBD(int_from, int_Voutypeid);
                }
            }
            else
            {
                int_RVouno = Rvouno;
                int_Ryear = Ryear;
                Str_Rtype = Rtype;

                //int int_RVouno = HttpContext.Current.Session["Rvouno"].ToString() != null ? Convert.ToInt32(HttpContext.Current.Session["Rvouno"].ToString()) : 0;
                //int int_Ryear = HttpContext.Current.Session["Ryear"].ToString() != null ? Convert.ToInt32(HttpContext.Current.Session["Ryear"].ToString()) : 0;
                //string Str_Rtype = HttpContext.Current.Session["Rtype"].ToString() != null ? HttpContext.Current.Session["Rtype"].ToString() : "";
                string Str_voucherReverse = Str_Reverse;

                for (int i = int_from; i <= int_to; i++)
                {
                    string int_vouno = i.ToString();
                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    string Str_temp = "";
                    str_voutype = "";

                    switch (Str_ddlvoucher)
                    {
                        case "Contra":
                            Str_temp = Fn_GenerateXML_Contra(int_from, int_to);
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Contra" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Journal":
                            Str_temp = Fn_GenerateXML_Journal(int_from, int_to);
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Journal" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual Invoices":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual Invoices");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual Invoices" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual CN - Opeartions":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual CN - Opeartions");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual CN - Opeartions" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual OSCN":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual OSCN");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual OSCN" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual Debit Note - Others":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual Debit Note - Others");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual Debit Note - Others" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual Credit Note - Others":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual Credit Note - Others");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual Credit Note - Others" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual Bank Receipt":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual Bank Receipt");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual Bank Receipt" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual Cash Receipt":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual Cash Receipt");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual Cash Receipt" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual Bank Payment":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual Bank Payment");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual Bank Payment" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Manual Cash Payment":
                            Str_temp = Fn_GenerateXML_ManualVoucher(int_from, int_to, "Manual Cash Payment");
                            HttpContext.Current.Response.Clear();
                            HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;Filename=Manual Cash Payment" + int_from + "To" + int_to + ".xml");
                            HttpContext.Current.Response.Buffer = true;
                            HttpContext.Current.Response.Charset = "UTF-8";
                            HttpContext.Current.Response.ContentType = "text/xml";
                            HttpContext.Current.Response.Write(Str_temp);
                            obj_da_Log.InsLogDetail(int_Empid, 1177, 4, int_bid, i + Str_ddlvoucher);
                            HttpContext.Current.Response.End();
                            break;

                        case "Invoices":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "I";
                            Str_vouname = "Invoice";
                            Str_ledgerExp = "Income";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "Invoice", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "Credit Note - Operations":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "P";
                            Str_vouname = "PaymentAdvise";
                            Str_ledgerExp = "Expenses";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "PA", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "Admin Purchase Invoice":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "S";
                            Str_vouname = "PA-Admin";
                            Str_ledgerExp = "Expenses";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "PA-Admin", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "Admin Sales Invoice":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "DN-Admin";
                            Str_vouname = "DN-Admin";
                            Str_ledgerExp = "Income";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "DN-Admin", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "OSSI":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "D";
                            Str_vouname = "OSSI";
                            checkrever(Convert.ToInt32(int_vouno), str_voutype, Str_voucherReverse);

                            if (Str_voucherReverse == "OSCN2OSDN")
                            {
                                Str_ledgerExp = "Expenses";
                            }
                            else
                            {
                                Str_ledgerExp = "Income";
                            }
                            //Str_ledgerExp = "Income";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "OSSI", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "OSPI":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "C";
                            Str_vouname = "OSPI";
                            checkrever(Convert.ToInt32(int_vouno), str_voutype, Str_voucherReverse);

                            if (Str_voucherReverse == "OSDN2OSCN")
                            {
                                Str_ledgerExp = "Income";
                            }
                            else
                            {
                                Str_ledgerExp = "Expenses";
                            }
                            //Str_ledgerExp = "Expenses";

                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "OSPI", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "Debit Note - Others":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "V";
                            Str_vouname = "DNHead";
                            checkrever(Convert.ToInt32(int_vouno), str_voutype, Str_voucherReverse);

                            if (Str_voucherReverse == "CNOps2DN")
                            {
                                Str_ledgerExp = "Expenses";
                            }
                            else
                            {
                                Str_ledgerExp = "Income";
                            }
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "DNHead", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "Credit Note - Others":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "E";
                            Str_vouname = "CNHead";
                            checkrever(Convert.ToInt32(int_vouno), str_voutype, Str_voucherReverse);
                            if (Str_voucherReverse == "Inv2CN")
                            {
                                Str_ledgerExp = "Income";
                            }
                            else
                            {
                                Str_ledgerExp = "Expenses";
                            }
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "CNHead", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "Bank Receipt":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'B';
                            str_voutype = "R";
                            Str_ledgerExp = "Cheque Collection Account";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetBankReceipt(i, int_Voutypeid,int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //Fn_GetBankReceipt(i, int_Voutypeid);
                            break;

                        case "Cash Receipt":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'C';
                            str_voutype = "R";
                            Str_ledgerExp = "Cash Collection Account";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetBankReceipt(i, int_Voutypeid,int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //Fn_GetBankReceipt(i, int_Voutypeid);
                            break;

                        case "Receipt - Petty Cash":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'P';
                            str_voutype = "R";

                            Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(int_bid).ToUpper();
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetBankReceipt(i, int_Voutypeid, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //Fn_GetBankReceipt(i, int_Voutypeid);
                            break;

                        case "Bank Payment":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'B';
                            str_voutype = "P";
                            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                            int Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
                            if (Corid == int_bid)
                            {
                                int_Voutypeid_Corp = 0;
                                int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            }
                            else
                            {
                                int_Voutypeid = obj_da_FA.Selvoutypeid("BPJV", Str_DBname);
                                int_Voutypeid_Corp = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            }
                            Str_vouname = "BANK";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetBankPayment(i, int_Voutypeid, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //Fn_GetBankPayment(i, int_Voutypeid);

                            break;

                        case "Cash Payment":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'C';
                            str_voutype = "P";
                            //Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(int_bid).ToUpper();
                            if (int_bid == 4)
                            {
                                DataTable DtTemp = new DataTable();
                                DataAccess.Accounts.Payment Payment_Obj2 = new DataAccess.Accounts.Payment();
                                DtTemp = Payment_Obj2.GetPaymentHead(i, int_bid, Convert.ToChar("C"), Convert.ToInt32(int_Vouyear));
                                string vis = "";
                                if (DtTemp.Rows.Count > 0)
                                {
                                    vis = DtTemp.Rows[0]["vis"].ToString();
                                }
                                if (vis == "Y")
                                {
                                    Str_ledgerExp = "PETTY CASH - AXL - VIZ";
                                }
                                else if (vis == "N")
                                {
                                    Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(int_bid).ToUpper();
                                }
                            }
                            else
                            {
                                Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(int_bid).ToUpper();
                            }
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetBankPayment(i, int_Voutypeid, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //Fn_GetBankPayment(i, int_Voutypeid);

                            break;

                        case "Remittance-Receipt":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'B';
                            str_voutype = "R";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetRemitReceipt(i, int_Voutypeid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "Remittance-Payment":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'B';
                            str_voutype = "P";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetRemitPayment(i, int_Voutypeid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;

                        case "BRG":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            Str_Mode = 'M';
                            str_voutype = "R";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Fn_GetBankReceipt(i, int_Voutypeid, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //Fn_GetBankReceipt(i, int_Voutypeid);

                            break;

                        //Ruban Add For BOS
                        case "BOS":
                            int_Voutypeid = obj_da_FA.Selvoutypeid(Str_ddlvoucher, Str_DBname);
                            str_voutype = "B";
                            Str_vouname = "BOS";
                            Str_ledgerExp = "Income";
                            log1.Info("Before Call the Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_ok = obj_da_Invoice.FAShowTallyDtlv(i, "BOS", int_Vouyear, int_bid);
                            log1.Info("After Procedure - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            break;
                    }

                    if (dt_ok.Rows.Count > 0)
                    {
                        log1.Info("Table Count>0 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

                        DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
                        Str_Fcurr = "";
                        string Str_trantype = "", Str_Ledgername = "", int_BLcount = "", Str_PartyLedger = "", Str_LedgernameEx = "", Str_Custtype = "", Str_VendorRef = "", Str_BLno = "", Str_Cust_TDS = "";
                        int int_Approveid = 0, int_Custid = 0, int_Custid_AD = 0, int_jobno = 0, int_Ledgerid = 0, int_ChkLedgerid = 0, int_Voucherid = 0;
                        DateTime voucherdate;
                        Amt_F = 0; Exrate = 0;
                        double Total_Amount = 0, Total_AmountWOST = 0, Total_AmountST = 0;
                        DataTable dt_oktemp = new DataTable();

                        Str_trantype = dt_ok.Rows[0]["trantype"].ToString();
                        if (Str_trantype == "FE")
                        {
                            Str_Ledgername = "Ocean Forwarding Exports";
                        }
                        else if (Str_trantype == "FI")
                        {
                            Str_Ledgername = "Ocean Forwarding Imports";
                        }
                        else if (Str_trantype == "FC")
                        {
                            Str_Ledgername = "CFS";
                        }
                        else if (Str_trantype == "AE")
                        {
                            Str_Ledgername = "Air Exports";
                        }
                        else if (Str_trantype == "AI")
                        {
                            Str_Ledgername = "Air Imports";
                        }
                        else if (Str_trantype == "CH")
                        {
                            Str_Ledgername = "CHA";
                        }
                        else if (Str_trantype == "AP" || Str_trantype == "AD")
                        {
                            Str_Ledgername = "Admin";
                        }
                        else if (Str_trantype == "BT")
                        {
                            Str_Ledgername = "BONDED TRUCKING";
                        }

                        Str_deleted = dt_ok.Rows[0]["deleted"].ToString();
                        int_Approveid = Convert.ToInt32(dt_ok.Rows[0]["approvedby"].ToString());
                        int_Custid = Convert.ToInt32(dt_ok.Rows[0].ItemArray[4].ToString());
                        string vdate = dt_ok.Rows[0].ItemArray[1].ToString();
                        voucherdate = Convert.ToDateTime(vdate);

                        DataAccess.Masters.MasterCharges obj_da_Charge = new DataAccess.Masters.MasterCharges();
                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

                        if (Str_ddlvoucher == "Admin Sales Invoice" || Str_ddl_voucher == "Admin Purchase Invoice")
                        {
                            Str_PartyLedger = obj_da_Charge.GetChargeName(Convert.ToInt32(dt_ok.Rows[0].ItemArray[4].ToString()));
                        }
                        else
                        {
                            Str_PartyLedger = obj_da_Customer.GetLedgerName(Convert.ToInt32(dt_ok.Rows[0].ItemArray[4].ToString()));
                        }

                        Str_LedgernameEx = (Str_Ledgername + " - " + Str_ledgerExp).ToUpper();
                        if (Str_ddlvoucher == "Admin Sales Invoice" || Str_ddl_voucher == "Admin Purchase Invoice")
                        {
                            int_Custid_AD = Convert.ToInt32(dt_ok.Rows[0].ItemArray[13].ToString());
                        }

                        int_jobno = Convert.ToInt32(dt_ok.Rows[0].ItemArray[3].ToString());
                        if (Str_ddlvoucher == "Admin Sales Invoice" || Str_ddl_voucher == "Admin Purchase Invoice")
                        {
                            Str_Custtype = "C";
                        }
                        else
                        {
                            Str_Custtype = obj_da_Customer.GetCustomerType(Convert.ToInt32(dt_ok.Rows[0].ItemArray[4].ToString()));
                        }

                        if (Str_ddlvoucher == "Invoices" || Str_ddlvoucher == "Credit Note - Operations" || Str_ddlvoucher == "Debit Note - Others" || Str_ddlvoucher == "Credit Note - Others" || Str_ddl_voucher == "BOS")
                        {
                            //int_BLcount = Convert.ToInt32(dt_ok.Rows[0]["blno"].ToString().Replace(".",""));
                            int_BLcount = dt_ok.Rows[0]["blno"].ToString();
                        }
                        //if (Str_ddlvoucher == "Admin Sales Invoice" || Str_ddlvoucher == "Admin Purchase Invoice")
                        //{
                        //    Str_VendorRef = dt_ok.Rows[0]["vendorrefno"].ToString();
                        //}
                        if (Str_ddlvoucher == "Credit Note - Operations" || Str_ddlvoucher == "Credit Note - Others")
                        {
                            Str_VendorRef = dt_ok.Rows[0]["vendorrefno"].ToString();
                        }

                        Fn_GetContainer(Str_trantype, int_BLcount, int_jobno.ToString());

                        if (Str_ddlvoucher == "OSSI" || Str_ddl_voucher == "OSPI")
                        {
                            log1.Info("Table Count>0:A - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Str_Fcurr = dt_ok.Rows[0]["curr"].ToString();
                            Amt_F = double.Parse(dt_ok.Rows[0]["amount"].ToString());
                            Exrate = double.Parse(dt_ok.Rows[0]["exrate"].ToString());
                            log1.Info("Table Count>0:B - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        }
                        else if (Str_ddlvoucher == "Debit Note - Others" || Str_ddlvoucher == "Credit Note - Others" || Str_ddlvoucher == "Admin Sales Invoice" || Str_ddlvoucher == "Admin Purchase Invoice")
                        {
                            if (Str_ddlvoucher == "Debit Note - Others")
                            {
                                dt_oktemp = obj_da_Invoice.GetOtherDCNAmount(i, "DNHead", int_bid, int_Vouyear);
                            }
                            else if (Str_ddlvoucher == "Credit Note - Others")
                            {
                                dt_oktemp = obj_da_Invoice.GetOtherDCNAmount(i, "CNHead", int_bid, int_Vouyear);
                            }
                            else if (Str_ddlvoucher == "Admin Sales Invoice")
                            {
                                dt_oktemp = obj_da_Invoice.GetOtherDCNAmount(i, "ADNHead", int_bid, int_Vouyear);
                            }
                            else if (Str_ddlvoucher == "Admin Purchase Invoice")
                            {
                                dt_oktemp = obj_da_Invoice.GetOtherDCNAmount(i, "ACNHead", int_bid, int_Vouyear);
                            }

                            if (dt_oktemp.Rows.Count > 0)
                            {
                                Str_Fcurr = dt_oktemp.Rows[0]["curr"].ToString();
                                Amt_F = double.Parse(dt_oktemp.Rows[0]["amt"].ToString());
                                Exrate = double.Parse(dt_oktemp.Rows[0]["exrate"].ToString());
                            }
                        }
                        else
                        {
                            Str_Fcurr = "";
                            Amt_F = 0;
                            Exrate = 0;
                        }

                        DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
                        if (Str_ddlvoucher == "OSSI")
                        {
                            log1.Info("Table Count>0:C - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            dt_oktemp = obj_da_DC.GetDCAdviseWBranch(int_jobno, Str_trantype, "DebitAdvise", int_bid, i, int_Vouyear);
                            if (dt_oktemp.Rows.Count > 0)
                            {
                                Str_BLno = dt_oktemp.Rows[0]["blno"].ToString();
                            }
                            Total_Amount = double.Parse(dt_ok.Rows[0].ItemArray[5].ToString()) * double.Parse(dt_ok.Rows[0].ItemArray[6].ToString());
                            str_Total_Amount = Total_Amount.ToString("#0.000");
                            Total_Amount = Convert.ToDouble(str_Total_Amount);
                            log1.Info("Table Count>0:D - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        }
                        else if (Str_ddlvoucher == "OSPI")
                        {
                            dt_oktemp = obj_da_DC.GetDCAdviseWBranch(int_jobno, Str_trantype, "CreditAdvise", int_bid, i, int_Vouyear);
                            if (dt_oktemp.Rows.Count > 0)
                            {
                                Str_BLno = dt_oktemp.Rows[0]["blno"].ToString();
                            }
                            Total_Amount = double.Parse(dt_ok.Rows[0].ItemArray[5].ToString()) * double.Parse(dt_ok.Rows[0].ItemArray[6].ToString());
                            str_Total_Amount = Total_Amount.ToString("#0.000");
                            Total_Amount = Convert.ToDouble(str_Total_Amount);
                        }
                        else
                        {
                            if (Str_ddlvoucher == "Admin Sales Invoice" || Str_ddlvoucher == "Admin Purchase Invoice")
                            {
                                Str_BLno = dt_ok.Rows[0]["refno"].ToString();
                            }
                            else
                            {
                                Str_BLno = dt_ok.Rows[0]["blno"].ToString();
                            }
                            /*if (Str_voucherReverse == "CNOps2DN")
                            {
                                Total_AmountWOST = obj_da_Invoice.GetIPDNAmountWOST(int_RVouno, "PaymentAdvise", int_bid, int_Ryear);
                                Total_Amount = obj_da_Invoice.GetIPDNAmount(int_RVouno, "PaymentAdvise", int_bid, int_Ryear);
                                Total_AmountST = Total_Amount - Total_AmountWOST;

                                str_Total_Amount = Total_Amount.ToString("#0.000");
                                str_Total_AmountWOST = Total_AmountWOST.ToString("#0.000");
                                str_Total_AmountST = Total_AmountST.ToString("#0.000");
                                Total_Amount = Convert.ToDouble(str_Total_Amount);
                                Total_AmountWOST = Convert.ToDouble(str_Total_AmountWOST);
                                Total_AmountST = Convert.ToDouble(str_Total_AmountST);
                            }
                            else if (Str_voucherReverse == "Inv2CN")
                            {
                                Total_AmountWOST = obj_da_Invoice.GetIPDNAmountWOST(int_RVouno, "Invoice", int_bid, int_Ryear);
                                Total_Amount = obj_da_Invoice.GetIPDNAmount(int_RVouno, "Invoice", int_bid, int_Ryear);
                                Total_AmountST = Total_Amount - Total_AmountWOST;

                                str_Total_Amount = Total_Amount.ToString("#0.000");
                                str_Total_AmountWOST = Total_AmountWOST.ToString("#0.000");
                                str_Total_AmountST = Total_AmountST.ToString("#0.000");
                                Total_Amount = Convert.ToDouble(str_Total_Amount);
                                Total_AmountWOST = Convert.ToDouble(str_Total_AmountWOST);
                                Total_AmountST = Convert.ToDouble(str_Total_AmountST);
                            }
                            else
                            {*/

                            Total_AmountWOST = obj_da_Invoice.GetIPDNAmountWOST(i, Str_vouname, int_bid, int_Vouyear);
                            Total_Amount = obj_da_Invoice.GetIPDNAmount(i, Str_vouname, int_bid, int_Vouyear);
                            Total_AmountST = Total_Amount - Total_AmountWOST;

                            str_Total_Amount = Total_Amount.ToString("#0.000");
                            str_Total_AmountWOST = Total_AmountWOST.ToString("#0.000");
                            str_Total_AmountST = Total_AmountST.ToString("#0.000");
                            Total_Amount = Convert.ToDouble(str_Total_Amount);
                            Total_AmountWOST = Convert.ToDouble(str_Total_AmountWOST);
                            Total_AmountST = Convert.ToDouble(str_Total_AmountST);
                            //}
                        }
                        log1.Info("Table Count>0:E - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        Fn_GetNarration(Convert.ToInt32(int_vouno), Str_BLno, str_voutype, Str_ddlnarration, int_jobno, Str_trantype);
                        log1.Info("Table Count>0:E1 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        Fn_GetReference(Convert.ToInt32(int_vouno), Str_ddlreference, int_jobno, Str_trantype, Str_BLno);
                        log1.Info("Table Count>0:E2 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        if (int_Approveid == 0 && Str_deleted == "N")
                        {             
                        log1.Info("Table Count>0:E3 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        return;
                        }

                        if (obj_da_FAVoucher.CheckFAExists4Voucher(Convert.ToInt32(int_vouno), int_Vouyear, int_bid, int_Voutypeid, Str_DBname) == 0)
                        {
                            log1.Info("Table Count>0:F - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            Voucher = false;
                        }
                        else
                        {
                            log1.Info("Table Count>0:E4 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            //if (Str_Check.Length > 0)
                            if (Str_Check != "")
                            {
                                Str_Check = Str_Check + " , " + int_vouno;
                            }
                            else
                            {
                                Str_Check = int_vouno;
                            }

                            Voucher = true;
                            bounbln = true;
                            log1.Info("Table Count>0:E5 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                        }

                        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
                        if (Voucher == false)
                        {
                            if (Str_ddlvoucher == "Admin Sales Invoice" || Str_ddlvoucher == "Admin Purchase Invoice")
                            {
                                if (Str_ddlvoucher == "Admin Sales Invoice")
                                {
                                    //  dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdmin(i, "D", int_bid, int_Vouyear);
                                    dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdminwithCust(i, "D", int_bid, int_Vouyear);
                                }
                                else
                                {
                                    //dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdmin(i, "C", int_bid, int_Vouyear);
                                    dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdminwithCust(i, "C", int_bid, int_Vouyear);
                                }

                                if (dt_oktemp.Rows.Count > 0)
                                {
                                    for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                    {
                                        int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_oktemp.Rows[k]["chargeid"].ToString()), dt_oktemp.Rows[k]["opstype"].ToString(), Str_DBname);
                                        if (dt_oktemp.Rows[k]["opstype"].ToString() == "A")
                                        {
                                            int_Subgroupid = 87;
                                            int_Groupid = 18;
                                        }
                                        if (int_ChkLedgerid == 0)
                                        {
                                            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_oktemp.Rows[k]["chargename"].ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_oktemp.Rows[k]["chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()), Str_DBname);
                                        }
                                    }
                                }

                                int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid_AD, "C", Str_DBname);

                                if (int_ChkLedgerid == 0)
                                {
                                    int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid_AD), int_Subgroupid, int_Groupid, 'G', int_Custid_AD, 'C', Str_DBname);
                                }
                            }
                            else
                            {

                                int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(int_Custid, "C", Str_DBname);

                                if (int_ChkLedgerid == 0)
                                {
                                    int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(int_Custid), int_Subgroupid, int_Groupid, 'G', int_Custid, 'C', Str_DBname);
                                }
                                //RAJA FOR INV EN
                                if (Str_trantype == "WH" || Str_trantype == "CT" || Str_trantype == "LT")
                                {
                                    if (Str_ddlvoucher == "Invoices" || Str_ddlvoucher == "Debit Note - Others")
                                    {
                                        if (Str_ddlvoucher == "Invoices")
                                        {
                                            dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "I", int_bid, int_Vouyear);
                                        }
                                        else if (Str_ddlvoucher == "Debit Note - Others")
                                        {
                                            dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "V", int_bid, int_Vouyear);
                                        }



                                        for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                        {
                                            int_ChkLedgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                            if (int_ChkLedgerid == 0)
                                            {
                                                int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_oktemp.Rows[k]["chargename"].ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_oktemp.Rows[k]["chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()), Str_DBname);
                                            }


                                            //obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())), int_Vouyear, int_bid, int_divisionid);
                                        }
                                    }
                                    if (Str_ddlvoucher == "Credit Note - Operations" || Str_ddlvoucher == "Credit Note - Others")
                                    {
                                        if (Str_ddlvoucher == "Credit Note - Operations")
                                        {
                                            dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "P", int_bid, int_Vouyear);
                                        }
                                        else if (Str_ddlvoucher == "Credit Note - Others")
                                        {
                                            dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "E", int_bid, int_Vouyear);
                                        }

                                        for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                        {
                                            int_ChkLedgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                            if (int_ChkLedgerid == 0)
                                            {
                                                int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_oktemp.Rows[k]["chargename"].ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_oktemp.Rows[k]["chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()), Str_DBname);
                                            }


                                            //obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())), int_Vouyear, int_bid, int_divisionid);
                                        }
                                    }



                                }
                            }
                            log1.Info("Table Count>0:E6 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            if (Str_deleted == "N")
                            {
                                log1.Info("Table Count>0:F1 - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                                Fn_CheckDebitCredit(Total_Amount, Total_AmountWOST, Total_AmountST, str_voutype, i);
                                if (R_Flag == true)
                                {
                                    R_Flag = false;
                                    return;
                                }
                            }
                            log1.Info("Table Count>0:G - (Voutype- " + int_Voutypeid + " | Vouno-" + i + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");
                            if (Str_deleted == "Y")
                            {
                                log1.Info("Cancelled - Before Insertion of Record in VoucherHead - (Voutype-" + int_Voutypeid + "|Vouno-" + int_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
                                int_Voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_Voutypeid, int_vouno, voucherdate, Str_Narration, Str_trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                                log1.Info("Cancelled - Record has been Inserted in VoucherHead - (" + int_Voucherid + ")");
                                HttpContext.Current.Session["vouid"] = int_Voucherid;
                            }
                            else if (Str_deleted == "N" && int_Approveid != 0)
                            {                                
                                log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_Voutypeid + "|Vouno-" + int_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
                                log1.Info("Record VoucherHead Details - (Str_DBname: " + Str_DBname + " | Voutypeid: " + int_Voutypeid + " | Vouno: " + int_vouno + " | Voudate: " + voucherdate + " | Narration: " + Str_Narration + " | Trantype: " + Str_trantype + " | Job: " + int_jobno + " | BranchID: " + int_bid + " | DivisionID: " + int_divisionid + " | UpdatedBy: " + int_Empid + " | Updatedon: " + obj_da_Log.GetDate() + " | Deleted: " + Str_deleted + " | Vouyear: " + int_Vouyear + "Session Branch - " + HttpContext.Current.Session["LoginBranchid"].ToString() + ")");
                                
                                int_Voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_Voutypeid, int_vouno, voucherdate, Str_Narration, Str_trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                                log1.Info("Record has been Inserted in VoucherHead - (" + int_Voucherid + ")");
                                HttpContext.Current.Session["vouid"] = int_Voucherid;

                                //int_Voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_Voutypeid, int_vouno, voucherdate, Str_Narration, Str_trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                                obj_da_FA.UpdRefno4VouHead(int_Voucherid, Str_Reference, Str_DBname);
                                obj_da_FA.UpdNEW4VouHead(int_Voucherid, Str_VendorRef, Str_Container, Str_DBname);

                               //VIno

                                if (Str_ddlvoucher == "Invoices" || Str_ddlvoucher == "Debit Note - Others" || Str_ddlvoucher == "BOS")
                                {
                                    double Total_AmountWOTDS = 0, Amt = 0;
                                    if (Str_voucherReverse == "CNOps2DN")
                                    {
                                        //VIno
                                        log1.Info("Ledger-" + Str_LedgernameEx + "-ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOST.ToString("#0.000")) + ") - Cr - Before Inserted");

                                        int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgernameEx, 'O');
                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountWOST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger-" + Str_LedgernameEx + "-ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOST.ToString("#0.000")) + ") - Cr - Inserted");
                                        
                                        if (Str_voucherReverse == "CNOps2DN")
                                        {
                                            //Amt = obj_da_FA.GetFATDSAmount(int_bid, 'P', int_RVouno, int_Ryear);
                                            Amt = obj_da_FA.GetFARevTDSAmount(int_bid, 'V', int_RVouno, int_Ryear);
                                            if (Amt != 0)
                                            {
                                                Amt = Math.Abs(Amt);
                                            }
                                            Total_AmountWOTDS = Total_Amount - Amt;
                                        }
                                        else
                                        {
                                            Amt = obj_da_FA.GetFATDSAmount(int_bid, char.Parse(str_voutype), int_RVouno, int_Vouyear);
                                            if (Amt != 0)
                                            {
                                                Amt = Math.Abs(Amt);
                                            }
                                            Total_AmountWOTDS = Total_Amount - Amt;
                                        }
                                        //VIno
                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid, 'C');

                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Dr - Before Inserted");

                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Dr - Inserted");
                                        DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();

                                        //RAJ-Need to change for TDS new FORM
                                        //DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                                        dt_oktemp = obj_da_TDS.GetTDSinTDSdetails(i, int_bid, int_Vouyear, TDStype);
                                        if (dt_oktemp.Rows.Count > 0 && (!string.IsNullOrEmpty(dt_oktemp.Rows[0]["tdsdesc"].ToString())))
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }
                                        else
                                        {
                                            dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid);
                                            if (dt_oktemp.Rows.Count > 0)
                                            {
                                                Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                            }
                                        }



                                        dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid);
                                        if (dt_oktemp.Rows.Count > 0)
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }



                                        int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("TDS Payable - " + Str_Cust_TDS, 27, 23, 'G', 0, 'O', Str_DBname);
                                        }
                                        if (Amt != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');

                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Dr - Before Inserted");

                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Dr - Inserted");

                                        }
                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Recovery", 'O');

                                            log1.Info("Ledger-Service Tax Recovery -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Cr - Before Inserted");


                                            obj_da_FA.InsFAVouDetailsRev(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-Service Tax Recovery -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Cr - Inserted");
                                        }
                                        obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Convert.ToDouble(Amt_F.ToString("#0.000")), Exrate);

                                        if (obj_da_Customer.GetCustomerType(int_Custid).ToString() == "P")
                                        {
                                            Fn_OtherDN_JVFA(i, voucherdate, Str_trantype, int_jobno, Total_Amount, int_Custid);
                                        }
                                    }
                                    else
                                    {

                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid, 'C');

                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Before Inserted");

                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Inserted");

                                        //RAJA TO ENABLE INV
                                        if (Str_trantype == "WH" || Str_trantype == "CT" || Str_trantype == "LT")
                                        {
                                            if (Str_ddlvoucher == "Invoices")
                                            {
                                                dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "I", int_bid, int_Vouyear);
                                            }
                                            else if (Str_ddlvoucher == "Debit Note - Others")
                                            {
                                                dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "V", int_bid, int_Vouyear);
                                            }

                                            for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                            {
                                                int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                                if (double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString()) > 0)
                                                {
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Before Inserted");

                                                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Inserted");
                                                }
                                                else
                                                {
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Before Inserted");

                                                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Inserted");
                                                }

                                            }
                                        }
                                        else
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgernameEx, 'O');

                                            log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOST.ToString("#0.000")) + ") - Cr - Before Inserted");

                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountWOST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOST.ToString("#0.000")) + ") - Cr - Inserted");
                                        }


                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Payable", 'O');

                                            log1.Info("Ledger-Service Tax Payable -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Cr - Before Inserted");
                                            
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-Service Tax Payable -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Cr - Inserted");
                                        }
                                        obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Amt_F, Exrate);

                                        if (Str_ddl_voucher == "Debit Note - Others")
                                        {
                                            if (obj_da_Customer.GetCustomerType(int_Custid).ToString() == "P")
                                            {
                                                Fn_OtherDN_JVFA(i, voucherdate, Str_trantype, int_jobno, Total_Amount, int_Custid);
                                            }
                                        }
                                    }

                                }
                                else if (Str_ddlvoucher == "OSSI")
                                {

                                    log1.Info("Fn_FATransfer has been Called For OSDN ledger insert");
                                    log1.Info("" + Str_ddlvoucher + " = From - " + int_from + " | To - " + int_to + " | Narr - " + Str_ddlnarration + " | Ref - " + Str_ddlreference + " | Branch - "
                                        + branchid + " | strRev - " + Str_Reverse + " | Rvouno - " + Rvouno + " | Ryear - " + Ryear + " | Rtype - "
                                        + Rtype + " | FA_DBname -" + HttpContext.Current.Session["FADbname"].ToString() + " | Vouyear - " + HttpContext.Current.Session["Vouyear"].ToString());


                                    string Reversal = obj_da_FA.CheckVocherReversal(Convert.ToInt32(int_vouno), int_bid, int_Vouyear, 'D');
                                    if (Reversal == "R")
                                    {
                                        Str_LedgernameEx = Str_LedgernameEx.ToString().Replace("INCOME", "EXPENSES");
                                    }

                                    int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid, 'C');

                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Before Inserted");

                                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Inserted");

                                    int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgernameEx, 'O');
                                    //RAJA Hide the below for GST
                                    //obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Total_Amount, int_Vouyear, int_bid, int_divisionid);

                                    log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Before Inserted");

                                    obj_da_FA.GetSTAmt4STTypeGSTOS(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid, i, int_Voutypeid, int_jobno, Str_trantype);
                                    log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Inserted");

                                    obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Convert.ToDouble(Amt_F.ToString("#0.000")), Exrate);
                                    Fn_OSDN_JVFA(i, voucherdate, Str_trantype, int_jobno, Total_Amount, int_Custid);



                                }
                                else if (Str_ddlvoucher == "Credit Note - Operations" || Str_ddlvoucher == "Credit Note - Others")
                                {
                                    double Total_AmountWOTDS = 0, Amt = 0;
                                    if (Str_voucherReverse == "Inv2CN")
                                    {

                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid, 'C');

                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Before Inserted");

                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Inserted");

                                        int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgernameEx, 'O');

                                        log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Total_AmountWOST + ") - Dr - Before Inserted");

                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Total_AmountWOST, int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Total_AmountWOST + ") - Dr - Inserted");


                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Payable", 'O');
                                            log1.Info("Ledger-Service Tax Payable -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Before Inserted");
                                            obj_da_FA.InsFAVouDetailsRev(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-Service Tax Payable -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Inserted");
                                        }

                                        obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Convert.ToDouble(Amt_F.ToString("#0.000")), Exrate);

                                        /*if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Payable", 'O');
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Total_AmountST, int_Vouyear, int_bid, int_divisionid);
                                        }
                                        obj_da_FA.UpdVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Amt_F, Exrate);*/

                                        if (obj_da_Customer.GetCustomerType(int_Custid).ToString() == "P")
                                        {
                                            Fn_OtherCN_JVFA(i, voucherdate, Str_trantype, int_jobno, Convert.ToDouble((Total_Amount - Total_AmountST).ToString("#0.000")), int_Custid);
                                        }
                                    }

                                    else
                                    {

                                        //RAJA TO ENABLE INV
                                        if (Str_trantype == "WH" || Str_trantype == "CT" || Str_trantype == "LT")
                                        {
                                            if (Str_ddlvoucher == "Credit Note - Operations")
                                            {
                                                dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "P", int_bid, int_Vouyear);
                                            }
                                            else if (Str_ddlvoucher == "Credit Note - Others")
                                            {
                                                dt_oktemp = obj_da_Invoice.GetPartyLedger4INVCN(i, "E", int_bid, int_Vouyear);
                                            }

                                            for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                            {
                                                int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                                if (double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString()) > 0)
                                                {
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Before Inserted");
                                                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Inserted");
                                                }
                                                else
                                                {
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Before Inserted");
                                                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Inserted");
                                                }

                                            }
                                        }
                                        else
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgernameEx, 'O');
                                            //Deposit Concor Charges for Axelerom
                                            DataTable dtdeposit = new DataTable();
                                            double chargeamount = 0;
                                            double totalamont = 0, subtotal = 0;

                                            dtdeposit = obj_da_FA.SpGetChargeid4Pa(Convert.ToInt32(int_vouno), Convert.ToInt32(int_Vouyear), Convert.ToInt32(int_bid));
                                            if (dtdeposit.Rows.Count > 0)
                                            {
                                                for (int k = 0; k < dtdeposit.Rows.Count; k++)
                                                {
                                                    chargeamount = Convert.ToDouble(dtdeposit.Rows[k]["amount"]);
                                                    int_Ledgerid = Convert.ToInt32(dtdeposit.Rows[k]["LEDGERID"]);
                                                    if (int_Ledgerid == 0)
                                                    {
                                                        obj_da_Ledger.InsLedgerHeadfromTally(dtdeposit.Rows[k]["chargename"].ToString(), 86, 20, 'G', 4741, 'A', Str_DBname);
                                                    }
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(chargeamount.ToString("#0.000")) + ") - Dr - Before Inserted");
                                                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(chargeamount.ToString("#,0.000")), int_Vouyear, int_bid, int_divisionid);
                                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(chargeamount.ToString("#0.000")) + ") - Dr - Inserted");
                                                    subtotal = subtotal + chargeamount;
                                                }
                                                if (subtotal != 0)
                                                {
                                                    int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgernameEx, 'O');

                                                    log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble((Total_AmountWOST - subtotal).ToString("#0.000")) + ") - Dr - Before Inserted");
                                                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble((Total_AmountWOST - subtotal).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                                    log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble((Total_AmountWOST - subtotal).ToString("#0.000")) + ") - Dr - Inserted");
                                                }
                                            }
                                            else
                                            {
                                                log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOST.ToString("#0.000")) + ") - Dr - Before Inserted");
                                                obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountWOST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                                log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOST.ToString("#0.000")) + ") - Dr - Inserted");
                                            }

                                            // obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountWOST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);

                                        }

                                        /* Amt = obj_da_FA.GetFATDSAmount(int_bid, ' ', 0, 0);
                                           Amt = obj_da_FA.GetFATDSAmount(int_bid,char.Parse(Str_Rtype), Convert.ToInt32(int_vouno),Convert.ToInt32(int_Vouyear));

                                           if (Amt > 0)
                                           {
                                               Amt = Math.Abs(Amt);
                                           }
                                           Total_AmountWOTDS = Total_Amount - Amt;*/

                                        //Amt = obj_da_FA.GetFATDSAmount(int_bid, char.Parse(Str_Rtype), i, int_Ryear);

                                        Amt = obj_da_FA.GetFATDSAmount(int_bid, char.Parse(str_voutype), i, int_Vouyear);
                                        if (Amt != 0)
                                        {
                                            Amt = Math.Abs(Amt);
                                        }

                                        Total_AmountWOTDS = Total_Amount - Amt;
                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid, 'C');
                                        if (obj_da_Customer.GetCustomerType(int_Custid).ToString() == "P")
                                        {
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Cr - Before Inserted");
                                            obj_da_FA.GetSTAmt4STTypeGSTOS(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid, i, int_Voutypeid, int_jobno, Str_trantype);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Cr - Inserted");
                                        }
                                        else
                                        {
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Cr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Cr - Inserted");
                                        }


                                        DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                                        //RAJ-Need to change for TDS new FORM
                                        //DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                                        dt_oktemp = obj_da_TDS.GetTDSinTDSdetails(i, int_bid, int_Vouyear, TDStype);
                                        if (dt_oktemp.Rows.Count > 0 && (!string.IsNullOrEmpty(dt_oktemp.Rows[0]["tdsdesc"].ToString())))
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }
                                        else
                                        {
                                            dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid);
                                            if (dt_oktemp.Rows.Count > 0)
                                            {
                                                Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                            }
                                        }
                                        dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid);
                                        if (dt_oktemp.Rows.Count > 0)
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }

                                        int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("TDS Payable - " + Str_Cust_TDS, 27, 23, 'G', 0, 'O', Str_DBname);
                                        }

                                        if (Amt != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');
                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Inserted");
                                        }

                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Recovery", 'O');
                                            log1.Info("Ledger-Service Tax Recovery -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-Service Tax Recovery -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Inserted");
                                        }


                                        obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Convert.ToDouble(Amt_F.ToString("#0.000")), Exrate);

                                        if (Str_ddl_voucher == "Credit Note - Others")
                                        {
                                            if (obj_da_Customer.GetCustomerType(int_Custid).ToString() == "P")
                                            {
                                                Fn_OtherCN_JVFA(i, voucherdate, Str_trantype, int_jobno, Convert.ToDouble((Total_Amount - Total_AmountST).ToString("#0.000")), int_Custid);
                                            }
                                        }
                                    }
                                }
                                else if (Str_ddlvoucher == "OSPI")
                                {
                                    string Reversal = obj_da_FA.CheckVocherReversal(Convert.ToInt32(int_vouno), int_bid, int_Vouyear, 'C');
                                    double oscn_amt = 0;
                                    if (Reversal == "R")
                                    {
                                        Str_LedgernameEx = Str_LedgernameEx.ToString().Replace("EXPENSES", "INCOME");
                                    }

                                    int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, Str_LedgernameEx, 'O');
                                    //RAJA Hide the below for GST
                                    // obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Total_Amount, int_Vouyear, int_bid, int_divisionid);
                                    log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
                                    obj_da_FA.GetSTAmt4STTypeGSTOS(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid, i, int_Voutypeid, int_jobno, Str_trantype);
                                    log1.Info("Ledger-" + Str_LedgernameEx + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Inserted");


                                    int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid, 'C');
                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                                    oscn_amt = obj_da_FA.GetSTAmt4STTypeGSTOSagent(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid, i, int_Voutypeid, int_jobno, Str_trantype);
                                    log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Inserted");
                                    //obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Total_Amount, int_Vouyear, int_bid, int_divisionid);

                                    obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Convert.ToDouble(Amt_F.ToString("#0.000")), Exrate);
                                    if (Reversal == "R")
                                    {
                                        Fn_OSCN_JVFA(i, voucherdate, Str_trantype, int_jobno, Convert.ToDouble((Total_Amount).ToString("#0.000")), int_Custid);
                                    }
                                    else
                                    {
                                        Fn_OSCN_JVFA(i, voucherdate, Str_trantype, int_jobno, Convert.ToDouble((Total_Amount - oscn_amt).ToString("#0.000")), int_Custid);
                                    }

                                }
                                else if (Str_ddlvoucher == "Admin Sales Invoice")
                                {
                                    DataTable Dt_Revchk = new DataTable();
                                    Dt_Revchk = obj_da_FA.CheckReversalCNAdmin(Convert.ToInt32(int_vouno), int_Vouyear, int_bid, int_Voutypeid);
                                    if (Dt_Revchk.Rows.Count > 0)
                                    {
                                        //obj_da_FA.ReversalCNAdmin(Convert.ToInt32(int_vouno), int_Vouyear, int_bid, int_Voutypeid, int_Voucherid);
                                        double Total_AmountWOTDS = 0, Amt = 0;
                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid_AD, 'C');

                                        Amt = obj_da_FA.GetFARevTDSAmount(int_bid, 'X', i, int_Vouyear);
                                        if (Amt != 0)
                                        {
                                            Amt = Math.Abs(Amt);
                                        }
                                        Total_AmountWOTDS = Total_Amount - Amt;
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Dr - Before Inserted");
                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Dr - Inserted");

                                        DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                                        //RAJ-Need to change for TDS new FORM
                                        //DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                                        dt_oktemp = obj_da_TDS.GetTDSinTDSdetails(i, int_bid, int_Vouyear, TDStype);
                                        if (dt_oktemp.Rows.Count > 0 && (!string.IsNullOrEmpty(dt_oktemp.Rows[0]["tdsdesc"].ToString())))
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }
                                        else
                                        {
                                            dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid);
                                            if (dt_oktemp.Rows.Count > 0)
                                            {
                                                Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                            }
                                        }

                                        dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid_AD);
                                        if (dt_oktemp.Rows.Count > 0)
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }
                                        int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("TDS Payable - " + Str_Cust_TDS, 49, 17, 'G', 0, 'O', Str_DBname);
                                        }
                                        if (Amt != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');
                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Dr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS+" -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Dr - Inserted");
                                        }

                                        dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdminwithCust(i, "D", int_bid, int_Vouyear);

                                        for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Inserted");
                                        }
                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Payable", 'O');
                                            log1.Info("Ledger-Service Tax Payable -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") -Cr - Before Inserted");
                                            obj_da_FA.InsFAVouDetailsRev(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-Service Tax Payable -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") -Cr - Inserted");
                                        }
                                    }
                                    else
                                    {
                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid_AD, 'C');

                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Dr - Inserted");

                                        dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdminwithCust(i, "D", int_bid, int_Vouyear);
                                        for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Cr - Inserted");
                                        }
                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Payable", 'O');
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Cr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Cr - Inserted");

                                        }
                                    }
                                }
                                else if (Str_ddlvoucher == "Admin Purchase Invoice")
                                {
                                    DataTable Dt_Revchk = new DataTable();
                                    Dt_Revchk = obj_da_FA.CheckReversalCNAdmin(Convert.ToInt32(int_vouno), int_Vouyear, int_bid, int_Voutypeid);
                                    if (Dt_Revchk.Rows.Count > 0)
                                    {
                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid_AD, 'C');
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_Amount.ToString("#0.000")) + ") - Cr - Inserted");


                                        dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdminwithCust(i, "C", int_bid, int_Vouyear);
                                        for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Inserted");

                                        }
                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Payable", 'O');
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Before Inserted");
                                            obj_da_FA.InsFAVouDetailsRev(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Inserted");

                                        }

                                    }
                                    else
                                    {
                                        double Total_AmountWOTDS = 0, Amt = 0;
                                        dt_oktemp = obj_da_Invoice.GetPartyLedger4PAAdminwithCust(i, "C", int_bid, int_Vouyear);

                                        for (int k = 0; k <= dt_oktemp.Rows.Count - 1; k++)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(dt_oktemp.Rows[k]["Chargeid"].ToString()), Convert.ToChar(dt_oktemp.Rows[k]["opstype"].ToString()));
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(double.Parse(dt_oktemp.Rows[k].ItemArray[1].ToString())).ToString("#0.000")) + ") - Dr - Inserted");
                                        }

                                        Amt = obj_da_FA.GetFATDSAmount(int_bid, char.Parse(str_voutype), i, int_Vouyear);
                                        //  if (Amt > 0)
                                        if (Amt != 0)
                                        {
                                            Amt = Math.Abs(Amt);
                                        }
                                        Total_AmountWOTDS = Total_Amount - Amt;

                                        int_Ledgerid = obj_da_FA.Selledgerid(Str_DBname, int_Custid_AD, 'C');
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Cr - Before Inserted");
                                        obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                        log1.Info("Ledger- -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountWOTDS.ToString("#0.000")) + ") - Cr - Inserted");

                                        DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                                        //RAJ-Need to change for TDS new FORM
                                        //DataAccess.Masters.MasterTDSType obj_da_TDS = new DataAccess.Masters.MasterTDSType();
                                        dt_oktemp = obj_da_TDS.GetTDSinTDSdetails(i, int_bid, int_Vouyear, TDStype);
                                        if (dt_oktemp.Rows.Count > 0 && (!string.IsNullOrEmpty(dt_oktemp.Rows[0]["tdsdesc"].ToString())))
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }
                                        else
                                        {
                                            dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid);
                                            if (dt_oktemp.Rows.Count > 0)
                                            {
                                                Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                            }
                                        }

                                        dt_oktemp = obj_da_TDS.GetTDSDtlsForCustomer(int_Custid_AD);
                                        if (dt_oktemp.Rows.Count > 0)
                                        {
                                            Str_Cust_TDS = dt_oktemp.Rows[0]["tdsdesc"].ToString();
                                        }
                                        int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');
                                        if (int_Ledgerid == 0)
                                        {
                                            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("TDS Payable - " + Str_Cust_TDS, 49, 17, 'G', 0, 'O', Str_DBname);
                                        }
                                        if (Amt != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "TDS Payable - " + Str_Cust_TDS, 'O');
                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Cr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-TDS Payable - " + Str_Cust_TDS + " -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Inserted");
                                        }

                                        if (Total_AmountST != 0)
                                        {
                                            int_Ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "Service Tax Recovery", 'O');
                                            log1.Info("Ledger-Service Tax Recovery -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Before Inserted");
                                            obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid, int_Ledgerid, "Dr", Convert.ToDouble(Total_AmountST.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                            log1.Info("Ledger-Service Tax Recovery -ID(" + int_Ledgerid + ")-Rs.(" + Convert.ToDouble(Total_AmountST.ToString("#0.000")) + ") - Dr - Inserted");
                                        }

                                        obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid, Str_Fcurr, Convert.ToDouble(Amt_F.ToString("#0.000")), Exrate);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            log1.Info("********************************************************************************************************************************************************");
        }

        public static void Fn_GetDeposite4BRBD(string int_from, int int_voutypeid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();
            Boolean type = false;
            string Str_mode = "B", Str_slipdate = "", Str_dssldate = "", Str_vouno = "", Str_bankname = "", Str_cheque = "", Str_refno = "", Str_partyledger = "", Str_ledgername = "", Str_narration = "";
            int int_ledgerid = 0, int_BDvouyear = 0, int_voucherid = 0;
            DataTable dt_ok = new DataTable();
            DataAccess.Accounts.Recipts obj_da_Recipts = new DataAccess.Accounts.Recipts();
            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();

            dt_ok = obj_da_Recipts.GetSlipDetails4tally(int_from.ToString(), int_bid, 'B');
            if (dt_ok.Rows.Count == 0)
            {
                dt_ok = obj_da_Recipts.GetSlipDetails4tally(int_from.ToString(), int_bid, 'C');
                Str_mode = "C";
                type = true;
            }

            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
            {
                Str_slipdate = dt_ok.Rows[i]["slipdate"].ToString();
                Str_dssldate = string.Format("{0:yyyyMMdd}", Str_slipdate);

                if (type == true)
                {
                    Str_ledgername = "CASH COLLECTION ACCOUNT";
                    Str_vouno = dt_ok.Rows[i]["LTtCd"].ToString();
                    Str_narration = "DEPOSIT SLIP NO. " + int_from.ToString();
                }
                else
                {
                    Str_ledgername = "CHEQUE COLLECTION ACCOUNT";
                    Str_bankname = dt_ok.Rows[i]["bankname"].ToString().Replace("&", "&amp;");
                    Str_vouno = dt_ok.Rows[i]["LTtbd"].ToString();
                    Str_cheque = dt_ok.Rows[i]["chequeno"].ToString();

                    Str_narration = " CHQ." + Str_cheque + " DEPOSITED INTO  " + Str_bankname + " VIDE DEPOSIT SLIP NO. " + int_from.ToString();
                }

                Str_refno = Str_mode + " - " + dt_ok.Rows[i]["receiptno"].ToString();
                double amount = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                DataAccess.Masters.MasterDivision obj_da_division = new DataAccess.Masters.MasterDivision();
                Str_partyledger = "CTC ACCOUNT-" + obj_da_division.GetShortName(int_divisionid) + "-CO";
                int_BDvouyear = Convert.ToInt32(dt_ok.Rows[i]["vouyear"].ToString());

                if (obj_da_FAVoucher.CheckFAExists4Voucher(Convert.ToInt32(Str_vouno), int_Vouyear, int_bid, int_voutypeid, Str_DBname) != 0)
                {
                    //Voucher = false;
                    //break;

                    string chk = "";
                    chk = obj_da_FAVoucher.ChkDepositSlipinFA(int_from.ToString(), Str_DBname);

                    if (chk.ToUpper() == "OK")
                    {
                        Voucher = false;
                        break;
                    }
                    else
                    {
                        Voucher = true;
                    } 


                }
                else
                {
                    Voucher = true;
                }
            }
            if (Voucher == true)
            {
                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    Str_slipdate = dt_ok.Rows[i]["slipdate"].ToString();
                    Str_dssldate = string.Format("{0:yyyyMMdd}", Str_slipdate);

                    if (type == true)
                    {
                        Str_ledgername = "CASH COLLECTION ACCOUNT";
                        Str_vouno = dt_ok.Rows[i]["LTtCd"].ToString();
                        Str_narration = "DEPOSIT SLIP NO. " + int_from.ToString();
                    }
                    else
                    {
                        Str_ledgername = "CHEQUE COLLECTION ACCOUNT";
                        Str_bankname = dt_ok.Rows[i]["bankname"].ToString().Replace("&", "&amp;");
                        Str_vouno = dt_ok.Rows[i]["LTtbd"].ToString();
                        Str_cheque = dt_ok.Rows[i]["chequeno"].ToString();
                        Str_narration = " CHQ." + Str_cheque + " DEPOSITED INTO  " + Str_bankname + " VIDE DEPOSIT SLIP NO. " + int_from.ToString();
                    }

                    Str_refno = Str_mode + " - " + dt_ok.Rows[i]["receiptno"].ToString();
                    double amount = Convert.ToDouble(double.Parse(dt_ok.Rows[i]["amount"].ToString()).ToString("#0.000"));
                    DataAccess.Masters.MasterDivision obj_da_division = new DataAccess.Masters.MasterDivision();
                    Str_partyledger = "CTC ACCOUNT-" + obj_da_division.GetShortName(int_divisionid) + "-CO";
                    int_BDvouyear = Convert.ToInt32(dt_ok.Rows[i]["vouyear"].ToString());

                    DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                    log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid + "|Vouno-" + Str_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");

                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutypeid, Str_vouno, Convert.ToDateTime(Str_slipdate), Str_narration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, Convert.ToDateTime(obj_da_Log.GetDate()), 'N', int_BDvouyear);
                    log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                    obj_da_FAVoucher.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, Str_refno, 0, "");
                    int_ledgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgername, 'O');

                    if (int_ledgerid == 0)
                    {
                        int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgername, 15, 1, 'G', 0, 'O', Str_DBname);
                    }

                    if (int_ledgerid != 0)
                    {
                        log1.Info("Ledger-" + Str_ledgername + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(amount.ToString("#0.000")), int_BDvouyear, int_bid, int_divisionid);
                        log1.Info("Ledger-" + Str_ledgername + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Inserted");
                    }

                    int_ledgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_partyledger, 'O');
                    if (int_ledgerid == 0)
                    {
                        int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgername, 32, 13, 'G', 0, 'O', Str_DBname);
                    }
                    if (int_ledgerid != 0)
                    {
                        log1.Info("Ledger-" + Str_ledgername + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(amount.ToString("#0.000")), int_BDvouyear, int_bid, int_divisionid);
                        log1.Info("Ledger-" + Str_ledgername + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Inserted");
                    }
                }

                Fn_GetDeposite4BRBDCOR(int_from, int_voutypeid);
            }
        }

        public static void Fn_GetDeposite4BRBDCOR(string int_from, int int_voutypeid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            Boolean type = false;
            string Str_mode = "B", Str_slipdate = "", Str_dssldate = "", Str_chequedate = "", Str_vouno = "", Str_bankname = "", Str_cheque = "", Str_refno = "", Str_partyledger = "", Str_ledgername = "", Str_narration = "", Str_Recbank = "";
            int int_ledgerid = 0, int_BDvouyear = 0, int_voucherid = 0, int_Corid = 0;
            DataTable dt_ok = new DataTable();
            DataAccess.Accounts.Recipts obj_da_Recipts = new DataAccess.Accounts.Recipts();
            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");

            dt_ok = obj_da_Recipts.GetSlipDetails4CORtally(int_from.ToString(), int_bid, 'B');
            if (dt_ok.Rows.Count == 0)
            {
                dt_ok = obj_da_Recipts.GetSlipDetails4CORtally(int_from.ToString(), int_bid, 'C');
                // Str_mode = "C";
                type = true;
            }
            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
            {
                Str_slipdate = dt_ok.Rows[i]["slipdate"].ToString();
                Str_dssldate = string.Format("{0:yyyyMMdd}", Str_slipdate);

                if (type == true)
                {
                    //Str_ledgername = "CASH COLLECTION ACCOUNT";
                    Str_bankname = dt_ok.Rows[i]["bankname"].ToString().Replace("&", "&amp;");
                    Str_narration = "DEPOSIT SLIP NO. " + int_from.ToString();
                }
                else
                {
                    //Str_ledgername = "CHEQUE COLLECTION ACCOUNT";
                    Str_bankname = dt_ok.Rows[i]["bankname"].ToString().Replace("&", "&amp;");
                    Str_cheque = dt_ok.Rows[i]["chequeno"].ToString();
                    Str_chequedate = dt_ok.Rows[i]["chequedate"].ToString();
                    Str_Recbank = dt_ok.Rows[i]["recbankname"].ToString().Replace("&", "&amp;");
                    Str_narration = " CHQ." + Str_cheque + " DEPOSITED INTO  " + Str_bankname + " VIDE DEPOSIT SLIP NO. " + int_from.ToString();
                }

                Str_vouno = obj_da_FAVoucher.GetBDJVNONo(Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString())).ToString();
                DataAccess.Masters.MasterBranch obj_da_branch = new DataAccess.Masters.MasterBranch();
                Str_refno = obj_da_branch.GetShortName(int_bid) + "/" + dt_ok.Rows[i]["receiptno"].ToString() + "/" + dt_ok.Rows[i]["vouyear"].ToString();
                double amount = Convert.ToDouble(double.Parse(dt_ok.Rows[i]["amount"].ToString()).ToString("#0.000"));
                Str_partyledger = "CTC ACCOUNT-" + obj_da_branch.GetShortName(int_bid);
                int_BDvouyear = Convert.ToInt32(dt_ok.Rows[i]["vouyear"].ToString());

                if (obj_da_FAVoucher.CheckFAExists4Voucher4CorpJV(Convert.ToInt32(Str_vouno), int_Vouyear, int_bid, int_voutypeid, int_Corid, Str_DBname) != 0)
                {
                    Voucher = false;
                    continue;
                }
                else
                {
                    Voucher = true;
                }

                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid + "|Vouno-" + Str_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
                int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutypeid, Str_vouno, DateTime.Parse(Str_slipdate), Str_narration, "AC", 1, 0, int_Corid, int_divisionid, int_Empid, obj_da_Log.GetDate(), 'N', int_BDvouyear);
                log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                HttpContext.Current.Session["vouid"] = int_voucherid;
                obj_da_FAVoucher.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);
                obj_da_FAVoucher.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, Str_refno, 0, "");
                int_ledgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_bankname, 'O');

                if (int_ledgerid == 0)
                {
                    int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_bankname, 26, 1, 'G', 0, 'O', Str_DBname);
                }

                if (int_ledgerid != 0)
                {
                    log1.Info("Ledger-" + Str_bankname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Before Inserted");
                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(amount.ToString("#0.000")), int_BDvouyear, int_bid, int_divisionid);
                    log1.Info("Ledger-" + Str_bankname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Inserted");
                }

                int_ledgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_partyledger, 'O');
                if (int_ledgerid == 0)
                {
                    int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgername, 32, 13, 'G', 0, 'O', Str_DBname);
                }

                if (int_ledgerid != 0)
                {
                    log1.Info("Ledger-" + Str_partyledger + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(amount.ToString("#0.000")), int_BDvouyear, int_bid, int_divisionid);
                    log1.Info("Ledger-" + Str_partyledger + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Inserted");
                }
            }
        }

        public static void Fn_Getcustomergroupid(string str_voucher)
        {
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            if (str_voucher == "Invoices")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
            else if (str_voucher == "Proforma Invoices")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
            else if (str_voucher == "Extentions")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
            else if (str_voucher == "Debit Note - Others")
            {
                if (obj_da_Customer.GetCustomerType(int_Customerid) == "P")
                {
                    int_Subgroupid = 65;
                    int_Groupid = 13;
                }
                else
                {
                    int_Subgroupid = 40;
                    int_Groupid = 13;
                }
            }
            else if (str_voucher == "Credit Note - Others")
            {
                if (obj_da_Customer.GetCustomerType(int_Customerid) == "P")
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
            else if (str_voucher == "FinalBills")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
            else if (str_voucher == "Credit Note - Operations")
            {
                int_Subgroupid = 67;
                int_Groupid = 12;
            }
            else if (str_voucher == "Admin Purchase Invoice")
            {
                int_Subgroupid = 41;
                int_Groupid = 12;
            }
            else if (str_voucher == "Admin Sales Invoice")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
            else if (str_voucher == "Bank Receipt" || str_voucher == "Cash Receipt" || str_voucher == "Receipt - Petty Cash" || str_voucher == "BRG")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
            else if (str_voucher == "Bank Payment" || str_voucher == "Cash Payment")
            {
                int_Subgroupid = 67;
                int_Groupid = 12;
            }
            else if (str_voucher == "OSPI" || str_voucher == "Remittance-Payment")
            {
                int_Subgroupid = 44;
                int_Groupid = 12;
            }
            else if (str_voucher == "OSSI" || str_voucher == "Remittance-Receipt")
            {
                int_Subgroupid = 65;
                int_Groupid = 13;
            }
            //Ruban Add for BOS
            else if (str_voucher == "BOS")
            {
                int_Subgroupid = 40;
                int_Groupid = 13;
            }
        }

        public static string Fn_GenerateXML_Contra(int int_from, int int_to)
        {
            string Str_XML = "";
            Str_XML = "<TALLYMESSAGE xmlns:UDF='TallyUDF'>" + System.Environment.NewLine;
            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataTable dt_ok = new DataTable();
            int int_voutypeid = 0;
            int_voutypeid = obj_da_FAVoucher.Selvoutypeid("Contra", Str_DBname);
            DateTime date_Rdate;
            for (int i = int_from; i <= int_to; i++)
            {
                dt_ok = obj_da_FAVoucher.SelFAvoucherHeadWOMonth(int_bid, int_Vouyear, i, int_voutypeid, Str_DBname);
                if (dt_ok.Rows.Count > 0)
                {
                    Str_XML = Str_XML + "<VOUCHER REMOTEID='' VCHTYPE='Contra' ACTION='Create'>" + System.Environment.NewLine;
                    date_Rdate = DateTime.Parse(dt_ok.Rows[0]["voudate"].ToString());
                    Str_XML = Str_XML + "<DATE>" + string.Format("{0:yyyyMMdd}", date_Rdate) + "</DATE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<NARRATION>Ch. No. : " + dt_ok.Rows[0]["Chequeno"].ToString() + " / " + string.Format("{0:dd-MM-yyyy}", date_Rdate) + " #~#  - " + dt_ok.Rows[0]["narration"].ToString().Replace("&", "&amp;") + "</NARRATION>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VOUCHERTYPENAME>Contra</VOUCHERTYPENAME>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VOUCHERNUMBER>" + i.ToString() + "</VOUCHERNUMBER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<PARTYLEDGERNAME>######</PARTYLEDGERNAME>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<CSTFORMISSUETYPE/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<CSTFORMRECVTYPE/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VCHGSTCLASS/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ENTEREDBY>FA</ENTEREDBY>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<EFFECTIVEDATE>" + string.Format("{0:yyyyMMdd}", date_Rdate) + "</EFFECTIVEDATE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISCOSTCENTRE>No</ISCOSTCENTRE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;


                    dt_ok = obj_da_FAVoucher.SelFAvoucherDetailsWOMonth(int_bid, int_Vouyear, i, int_voutypeid, Str_DBname);
                    for (int j = 0; j <= dt_ok.Rows.Count - 1; j++)
                    {
                        if (dt_ok.Rows[j]["ledgertype"].ToString() != "Dr")
                        {
                            Str_XML = Str_XML + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERNAME>" + dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;") + "</LEDGERNAME>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<GSTCLASS/>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<AMOUNT>" + string.Format("{0:0.00}", dt_ok.Rows[j]["ledgeramount"]) + " </AMOUNT>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;

                            if (dt_ok.Rows[j]["groupid"].ToString() == "1")
                            {
                                Str_XML = Str_XML.Replace("######", dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;"));
                            }
                        }
                    }
                    Str_XML = Str_XML + "</VOUCHER>" + System.Environment.NewLine;
                }
            }

            Str_XML = Str_XML + "</TALLYMESSAGE>";
            return Str_XML;
        }

        public static string Fn_GenerateXML_Journal(int int_from, int int_to)
        {
            string Str_XML = "";
            Str_XML = "<TALLYMESSAGE xmlns:UDF='TallyUDF'>" + System.Environment.NewLine;
            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataTable dt_ok = new DataTable();
            int int_voutypeid = 0;
            int_voutypeid = obj_da_FAVoucher.Selvoutypeid("Journal", Str_DBname);
            DateTime date_Rdate;
            for (int i = int_from; i <= int_to; i++)
            {
                dt_ok = obj_da_FAVoucher.SelFAvoucherHead(int_bid, int_Vouyear, i, int_voutypeid, Str_DBname, 0);
                if (dt_ok.Rows.Count > 0)
                {
                    Str_XML = Str_XML + "<VOUCHER REMOTEID='' VCHTYPE='Journal' ACTION='Create'>" + System.Environment.NewLine;
                    date_Rdate = DateTime.Parse(dt_ok.Rows[0]["voudate"].ToString());
                    Str_XML = Str_XML + "<DATE>" + string.Format("{0:yyyyMMdd}", date_Rdate) + "</DATE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<NARRATION>Ch. No. : " + dt_ok.Rows[0]["narration"].ToString() + " / " + string.Format("{0:dd-MM-yyyy}", date_Rdate) + " #~#  - " + dt_ok.Rows[0]["narration"].ToString().Replace("&", "&amp;") + "</NARRATION>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VOUCHERTYPENAME>Journal</VOUCHERTYPENAME>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VOUCHERNUMBER>" + i.ToString() + "</VOUCHERNUMBER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<PARTYLEDGERNAME>######</PARTYLEDGERNAME>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<CSTFORMISSUETYPE/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<CSTFORMRECVTYPE/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VCHGSTCLASS/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ENTEREDBY>FA</ENTEREDBY>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<EFFECTIVEDATE>" + string.Format("{0:yyyyMMdd}", date_Rdate) + "</EFFECTIVEDATE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<HASCASHFLOW>Yes</HASCASHFLOW>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISCOSTCENTRE>No</ISCOSTCENTRE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;

                    dt_ok = obj_da_FAVoucher.SelFAvoucherDetails(int_bid, int_Vouyear, i, int_voutypeid, Str_DBname, 0);
                    for (int j = 0; j <= dt_ok.Rows.Count - 1; j++)
                    {
                        if (dt_ok.Rows[j]["ledgertype"].ToString() == "Dr")
                        {
                            Str_XML = Str_XML + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERNAME>" + dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;") + "</LEDGERNAME>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<GSTCLASS/>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<AMOUNT>- " + string.Format("{0:0.00}", dt_ok.Rows[j]["ledgeramount"]) + " </AMOUNT>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<NAME> " + dt_ok.Rows[j]["refno"].ToString() + "</NAME>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<AMOUNT>- " + string.Format("{0:0.00}", dt_ok.Rows[j]["ledgeramount"]) + " </AMOUNT>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML.Replace("######", dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;"));

                        }
                        if (dt_ok.Rows[j]["ledgertype"].ToString() != "Dr")
                        {
                            Str_XML = Str_XML + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERNAME>" + dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;") + "</LEDGERNAME>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<GSTCLASS/>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<AMOUNT>- " + string.Format("{0:0.00}", dt_ok.Rows[j]["ledgeramount"]) + " </AMOUNT>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                        }
                    }
                    Str_XML = Str_XML + "</VOUCHER>" + System.Environment.NewLine;
                }
            }

            Str_XML = Str_XML + "</TALLYMESSAGE>";
            return Str_XML;
        }

        public static string Fn_GenerateXML_ManualVoucher(int int_from, int int_to, string Str_Manualvoucher)
        {
            string Str_Vouname = "";
            string vutype = "";
            if (Str_Manualvoucher == "Manual CN - Opeartions")
            {
                Str_Vouname = "Manual PaymentAdvises";
                vutype = "Manual CN - Opeartions";
            }
            else
            {
                Str_Vouname = Str_Manualvoucher;
                vutype = Str_Manualvoucher;
            }

            string Str_XML = "";
            Str_XML = "<TALLYMESSAGE xmlns:UDF='TallyUDF'>" + System.Environment.NewLine;
            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.Accounts.Journal obj_da_Journal = new DataAccess.Accounts.Journal();
            DataTable dt_ok = new DataTable();
            int int_voutypeid = 0;
            int_voutypeid = obj_da_FAVoucher.Selvoutypeid(Str_Vouname, Str_DBname);
            DateTime date_Rdate;

            for (int i = int_from; i <= int_to; i++)
            {
                dt_ok = obj_da_Journal.SelVouHead4ManualVou(int_bid, int_Vouyear, i, int_voutypeid, Str_DBname);
                if (dt_ok.Rows.Count > 0)
                {
                    Str_XML = Str_XML + "<VOUCHER REMOTEID='' VCHTYPE='" + vutype + "' ACTION='Create'>" + System.Environment.NewLine;
                    date_Rdate = DateTime.Parse(dt_ok.Rows[0]["voudate"].ToString());
                    Str_XML = Str_XML + "<DATE>" + string.Format("{0:yyyyMMdd}", date_Rdate) + "</DATE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<NARRATION>Ch. No. : " + dt_ok.Rows[0]["narration"].ToString() + " / " + string.Format("{0:dd-MM-yyyy}", date_Rdate) + " #~#  - " + dt_ok.Rows[0]["narration"].ToString().Replace("&", "&amp;") + "</NARRATION>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VOUCHERTYPENAME>Contra</VOUCHERTYPENAME>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<PARTYLEDGERNAME>######</PARTYLEDGERNAME>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<CSTFORMISSUETYPE/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<CSTFORMRECVTYPE/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<VCHGSTCLASS/>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ENTEREDBY>Admin</ENTEREDBY>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<DIFFACTUALQTY>No</DIFFACTUALQTY>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<AUDITED>No</AUDITED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<FORJOBCOSTING>No</FORJOBCOSTING>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISOPTIONAL>No</ISOPTIONAL>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<EFFECTIVEDATE>" + string.Format("{0:yyyyMMdd}", date_Rdate) + "</EFFECTIVEDATE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORINTEREST>No</USEFORINTEREST>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORGAINLOSS>No</USEFORGAINLOSS>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USEFORCOMPOUND>No</USEFORCOMPOUND>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISCANCELLED>No</ISCANCELLED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<HASCASHFLOW>No</HASCASHFLOW>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISPOSTDATED>No</ISPOSTDATED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISINVOICE>No</ISINVOICE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<MFGJOURNAL>No</MFGJOURNAL>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<HASDISCOUNTS>No</HASDISCOUNTS>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ASPAYSLIP>No</ASPAYSLIP>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISCOSTCENTRE>No</ISCOSTCENTRE>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ISDELETED>No</ISDELETED>" + System.Environment.NewLine;
                    Str_XML = Str_XML + "<ASORIGINAL>No</ASORIGINAL>" + System.Environment.NewLine;

                    dt_ok = obj_da_Journal.SelFAvoucherDetails4ManualVou(int_bid, int_Vouyear, i, int_voutypeid, Str_DBname);
                    for (int j = 0; j <= dt_ok.Rows.Count - 1; j++)
                    {
                        if (dt_ok.Rows[j]["ledgertype"].ToString() == "Dr")
                        {
                            Str_XML = Str_XML + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERNAME>" + dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;") + "</LEDGERNAME>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<GSTCLASS/>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<AMOUNT>- " + string.Format("{0:0.00}", dt_ok.Rows[j]["ledgeramount"]) + " </AMOUNT>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<NAME> " + dt_ok.Rows[j]["refno"].ToString() + "</NAME>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<BILLTYPE>New Ref</BILLTYPE>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<AMOUNT>- " + string.Format("{0:0.00}", dt_ok.Rows[j]["ledgeramount"]) + " </AMOUNT>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "</BILLALLOCATIONS.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            //If vtype =  Or vtype =  Or vtype =  Or vtype =  Or vtype =  Then
                            if (Str_Manualvoucher == "Manual Invoices" || Str_Manualvoucher == "Manual OSDN" || Str_Manualvoucher == "Manual Debit Note - Others" || Str_Manualvoucher == "Manual Bank Receipt" || Str_Manualvoucher == "Manual Cash Receipt")
                            {
                                Str_XML = Str_XML.Replace("######", dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;"));
                            }
                        }

                        if (dt_ok.Rows[j]["ledgertype"].ToString() != "Dr")
                        {
                            Str_XML = Str_XML + "<ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERNAME>" + dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;") + "</LEDGERNAME>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<GSTCLASS/>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<LEDGERFROMITEM>No</LEDGERFROMITEM>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "<AMOUNT>- " + string.Format("{0:0.00}", dt_ok.Rows[j]["ledgeramount"]) + " </AMOUNT>" + System.Environment.NewLine;
                            Str_XML = Str_XML + "</ALLLEDGERENTRIES.LIST>" + System.Environment.NewLine;
                            if (Str_Manualvoucher == "Manual CN - Opeartions" || Str_Manualvoucher == "Manual OSCN" || Str_Manualvoucher == "Manual Credit Note - Others" || Str_Manualvoucher == "Manual Bank Payment" || Str_Manualvoucher == "Manual Cash Payment")
                            {
                                Str_XML = Str_XML.Replace("######", dt_ok.Rows[j]["ledgername"].ToString().Replace("&", "&amp;"));
                            }
                        }
                    }
                    Str_XML = Str_XML + "</VOUCHER>" + System.Environment.NewLine;
                }
            }

            Str_XML = Str_XML + "</TALLYMESSAGE>";
            return Str_XML;
        }

        public static void Fn_CheckcreditdebitAmount(int int_vouno, int int_voutype, int int_Rcount)
        {
            double Debit_1 = 0, Debit_2 = 0, Debit_3 = 0, Debit_4 = 0, Credit_1 = 0, Credit_2 = 0, Credit_3 = 0, Credit_4 = 0;
            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataTable dt_ok = new DataTable();
            DataTable dt_ok1 = new DataTable();

            if (obj_da_FA.CheckFAExists4Voucher(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
            {
                Voucher = false;
            }
            else
            {
                if (Str_Check.Length > 0)
                {
                    Str_Check = Str_Check + "-" + int_vouno.ToString();
                }
                else
                {
                    Str_Check = int_vouno.ToString();
                }
                Voucher = true;
                bounbln = true;
            }

            if (Voucher == false)
            {
                if (ReceiptAmount > 0)
                {
                    Debit_1 = ReceiptAmount;
                }
                DataAccess.Accounts.Recipts obj_da_receipt = new DataAccess.Accounts.Recipts();
                dt_ok = obj_da_receipt.GetRecptCust4FA(int_Receiptid);

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    if (Amt > 0)
                    {
                        Credit_1 = Credit_1 + Amt;
                    }
                    else if (Amt < 0)
                    {
                        if (int_Rcount == 1)
                            Debit_2 = Debit_2 + Math.Abs(Amt);
                    }
                }

                dt_ok = obj_da_receipt.GetRecptChrg(int_Receiptid);

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt1 = double.Parse(dt_ok.Rows[i]["amount"].ToString());

                    // ledgerid = FAObj.Selledgeridforops(Login.FADbname, "TAX DEDUCTED AT SOURCE RECEIVABLE", "O")
                    if (Amt1 < 0)
                    {
                        Debit_3 = Debit_3 + Math.Abs(Amt1);
                    }
                    else if (((dt_ok.Rows[i]["cc"] == "BANK CHARGES") || (dt_ok.Rows[i]["cc"] == "BANK INTEREST")) && (HttpContext.Current.Session["LoginBranchName"].ToString() == "CORPORATE"))
                    {
                        Credit_2 = Credit_2 + Amt1;
                    }
                }

                if (int_Rcount == 1)
                {
                    dt_ok = obj_da_FA.GetFAES(int_Receiptid);
                }
                else
                {
                    dt_ok = obj_da_receipt.GetES(int_Receiptid);
                }

                if (dt_ok.Rows.Count > 0)
                {
                    string str_LedgerType = "";
                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                    {
                        double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                        if (Amt >= 0)
                        {
                            str_LedgerType = "Cr";
                            Credit_2 = Credit_2 + Math.Abs(Amt);
                        }
                        else if (Amt < 0)
                        {
                            str_LedgerType = "Dr";
                            Debit_4 = Debit_4 + Math.Abs(Amt);
                        }
                    }

                }

                if (Double_Truncate((Debit_1 + Debit_2 + Debit_3 + Debit_4), 4) == Double_Truncate((Credit_1 + Credit_2), 4))
                {
                    R_Flag = false;
                }
                else
                {
                    R_Flag = true;
                }
            }
        }

        public static void Fn_CheckcreditdebitAmountBonus(int int_vouno, int int_voutype, int int_Rcount)
        {
            double Debit_1 = 0, Debit_2 = 0, Debit_3 = 0, Debit_4 = 0, Credit_1 = 0, Credit_2 = 0, Credit_3 = 0;
            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataTable dt_ok = new DataTable();

            if (obj_da_FA.CheckFAExists4Voucher(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
            {
                Voucher = false;
            }
            else
            {
                if (Str_Check.Length > 0)
                {
                    Str_Check = Str_Check + "-" + int_vouno.ToString();
                }
                else
                {
                    Str_Check = int_vouno.ToString();
                }
                Voucher = true;
                bounbln = true;
            }

            if (Voucher == false)
            {
                if (ReceiptAmount < 0)
                {
                    Credit_1 = Math.Abs(ReceiptAmount);
                }

                DataAccess.Accounts.Recipts obj_da_receipt = new DataAccess.Accounts.Recipts();
                dt_ok = obj_da_receipt.GetRecptCust(int_Receiptid);

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    if (Amt < 0)
                    {
                        Debit_1 = Debit_1 + Math.Abs(Amt);
                    }
                }

                dt_ok = obj_da_receipt.GetRecptChrg(int_Receiptid);

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    if (Amt > 0)
                    {
                        Credit_2 = Credit_2 + Amt;
                    }
                }

                dt_ok = obj_da_FA.GetFAES(int_Receiptid);
                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    string str_LedgerType = "";
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    if (Amt >= 0)
                    {
                        str_LedgerType = "Cr";
                        Credit_3 = Credit_3 + Math.Abs(Amt);
                    }
                    else if (Amt < 0)
                    {
                        str_LedgerType = "Dr";
                        Debit_2 = Debit_2 + Math.Abs(Amt);
                    }
                }

                if (Double_Truncate((Debit_1 + Debit_2 + Debit_3 + Debit_4), 4) == Double_Truncate((Credit_1 + Credit_2 + Credit_3), 4))
                {
                    R_Flag = false;
                }
                else
                {
                    R_Flag = true;
                }
            }
        }

        public static double Double_Truncate(double num, int int_Digits)
        {
            double y = Math.Pow(10, int_Digits);
            return Math.Truncate(Convert.ToDouble(num.ToString("#0.000")) * y) / y;
        }

        public static void Fn_CheckBankreceiptCreditAmount(int int_vouno, int int_voutype)
        {
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            int Month = obj_da_Log.GetDate().Month;
            int_Receiptcount = 0;
            string str_Month = "", Str_Year = "";
            str_Month = Month.ToString();

            if (Month < 10)
            {
                str_Month = "0" + str_Month;
            }
            Str_Year = HttpContext.Current.Session["LogYear"].ToString();
            Str_Year = Str_Year.Substring(2, 2);
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataTable dt_ok = new DataTable();

            dt_ok = obj_da_Receipt.GetRecptHeadFA(int_vouno, int_bid, Str_Mode, int_Vouyear);

            if ((dt_ok.Rows.Count > 0))
            {
                int_Receiptcount = dt_ok.Rows.Count;
                ReceiptAmount = double.Parse(dt_ok.Rows[0]["rfamount"].ToString());
                Str_deleted = "";
                Str_deleted = dt_ok.Rows[0]["deleted"].ToString();
                if (Str_deleted == "0")
                {
                    Str_deleted = "N";
                }
                else if (Str_deleted == "1")
                {
                    Str_deleted = "Y";
                }
                int_Receiptid = Convert.ToInt32(dt_ok.Rows[0]["receiptid"].ToString());
                Fn_CheckcreditdebitAmount(int_vouno, int_voutype, int_Receiptcount);

                if ((dt_ok.Rows.Count > 1) && (bounbln == false))
                {
                    for (int L = 0; L <= dt_ok.Rows.Count - 1; L++)
                    {
                        ReceiptAmount = double.Parse(dt_ok.Rows[L]["rfamount"].ToString());
                        Str_deleted = "";
                        Str_deleted = dt_ok.Rows[L]["deleted"].ToString();
                        if (Str_deleted == "0")
                        {
                            Str_deleted = "N";
                        }
                        else if (Str_deleted == "1")
                        {
                            Str_deleted = "Y";
                        }
                        int_Receiptid = Convert.ToInt32(dt_ok.Rows[L]["receiptid"].ToString());
                        if (ReceiptAmount < 0)
                        {
                            Fn_CheckcreditdebitAmountBonus(int_vouno, int_voutype, int_Receiptcount);
                        }
                    }
                }
            }
        }

        public static void Fn_GetBankReceipt(int int_vouno, int int_voutype, int branchid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();
            log1.Info("********************************************************************************************************************************************************");
            log1.Info("Fn_GetBankReceipt has been Called");
            log1.Info("Voucher Details - (Voutype- " + int_voutype + " | Vouno-" + int_vouno + " | Branchid- " + branchid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

            string Str_chequedate = "";
            Str_ReceiptNarration = "";
            string msgfromonacc = "";
            string usermail = "", empmailadd = "", sendqry = "";
            DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();

            Fn_CheckBankreceiptCreditAmount(int_vouno, int_voutype);

            //if (R_Flag == true && Str_Check.Length == 0)
            //{
            //    return;
            //}
            //msgfromonacc = HttpContext.Current.Session["OnAccountVoutypeEdi"].ToString();

            if (R_Flag == true && Str_Check.Length == 0)
            {

                try
                {
                    if (HttpContext.Current.Session["OnAccountVoutypeEdi"].ToString() == "O")
                    {
                        usermail = HREmpobj.GetMailAdd(Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]));
                        //usermail = HREmpobj.GetMailAdd(HttpContext.Current.Session["LoginEmpId"].ToString());
                        sendqry = sendqry + "<table border=1 width=100% text=blue><tr><td align=center BGCOLOR=#CCCCCC><FONT FACE=Arial SIZE=3 COLOR=Black><B>On Account Adjustment Wrong Entry</B></FONT></td></tr></table>";
                        sendqry = sendqry + "<table><tr><td align=left>Dear Sir / Madam</td></tr>";
                        sendqry = sendqry + "<table><tr><td align=left>The below " + int_voutype + " entry was Wrongly Adjusted. Kindly Check and correct the same. </td></tr>";
                        sendqry = sendqry + "<tr><td align=left>" + int_voutype + " #: " + int_vouno + " / Vouyear : " + int_Vouyear + " /Branch : " + int_RBranchid + "</td></tr></table><br><br><br>";
                        sendqry = sendqry + "</table><table width=100% text=black><tr><td align=left>Thanks & Regards </td></tr><tr><td align=left>Admin</td></tr></table><br><br><br>";

   return;
                    }
                }
                catch (Exception ex)
                {
                }
                // return;
            }





            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            int Month = obj_da_Log.GetDate().Month;
            int_Receiptcount = 0;
            string str_Month = "", Str_Year = "";
            str_Month = Month.ToString();

            if (Month < 10)
            {
                str_Month = "0" + str_Month;
            }
            Str_Year = HttpContext.Current.Session["LogYear"].ToString();
            Str_Year = Str_Year.Substring(2, 2);
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataTable dt_ok = new DataTable();

            dt_ok = obj_da_Receipt.GetRecptHeadFA(int_vouno, branchid, Str_Mode, int_Vouyear);
            if (dt_ok.Rows.Count > 0)
            {
                int_Receiptcount = dt_ok.Rows.Count;
                DateTime Receiptdate = DateTime.Parse(dt_ok.Rows[0]["receiptdate"].ToString());
                partyname = dt_ok.Rows[0]["customername"].ToString();
                ReceiptAmount = double.Parse(dt_ok.Rows[0]["rfamount"].ToString());
                Str_deleted = "";
                Str_deleted = dt_ok.Rows[0]["deleted"].ToString();
                if (Str_deleted == "0")
                {
                    Str_deleted = "N";
                }
                else if (Str_deleted == "1")
                {
                    Str_deleted = "Y";
                }
                int_Receiptid = Convert.ToInt32(dt_ok.Rows[0]["receiptid"].ToString());

                int_ReceiptBankid = 0;
                string str_Chequeno = "";
                if (Str_Mode.ToString() == "B" || Str_Mode.ToString() == "M")
                {
                    int_ReceiptBankid = Convert.ToInt32(dt_ok.Rows[0]["bank"].ToString());

                    Str_chequedate = dt_ok.Rows[0]["chequedate"].ToString();
                    str_Chequeno = dt_ok.Rows[0]["chequeno"].ToString();
                }
                Str_ReceiptNarration = dt_ok.Rows[0]["naration"].ToString();
                int_RBranchid = Convert.ToInt32(dt_ok.Rows[0]["branchid"].ToString());
                Str_ReceiptBank = "";

                Str_ReceiptBank = obj_da_Receipt.GetBankName(int_ReceiptBankid);

                int int_Corid = 0;
                DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");

                if (int_Corid == branchid && Str_ddl_voucher == "Bank Receipt")
                {
                    Str_ledgerExp = Str_ReceiptBank;
                }
                else if (Str_ddl_voucher == "BRG")
                {
                    Str_ledgerExp = Str_ReceiptBank;
                }

                dt_ok = obj_da_Receipt.GetRAInvoiceToShow(int_Receiptid, 'R');
                if (dt_ok.Rows.Count > 0)
                {
                    //var obj_Vouno = (from r in dt_ok.AsEnumerable()
                    //                 select r.Field<Int32>("vouno").ToString());
                    //Str_ReceiptNarration = string.Join(",", obj_Vouno);

                    str_reciptnar = "";
                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            Str_ReceiptNarration += "/V-" + dt_ok.Rows[i]["vouno"].ToString() + ",";
                        }
                        else
                        {
                            Str_ReceiptNarration += dt_ok.Rows[i]["vouno"].ToString() + ",";
                        }
                        str_reciptnar += dt_ok.Rows[i]["vouno"].ToString() + ",";
                    }

                    if (Str_ReceiptNarration != "")
                    {
                        string last = Str_ReceiptNarration.Substring(Str_ReceiptNarration.Length - 1, 1);

                        if (last == ",")
                        {
                            Str_ReceiptNarration = Str_ReceiptNarration.Substring(0, Str_ReceiptNarration.Length - 1);
                        }
                    }

                    if (Str_ReceiptNarration.Length > 0)
                    {
                        Str_ReceiptNarration = HttpUtility.HtmlDecode(Str_ReceiptNarration.Replace("&", "&amp;"));
                    }
                }

                Fn_GetReceiptRef();
                Fn_InsertReceipt(int_vouno, int_voutype, Receiptdate, str_Chequeno, branchid);
                //Fn_InsertReceipt(int_vouno, int_voutype, Receiptdate, str_Chequeno);


                //Hide by Raja 
                //If a company have corporate account then the below code is not necessary (For EX M+R,Dhanay, Fcan....)
                //If a company dont  have corporate account then the below code is  necessary (For EX Seahawk,Bignavigators....)

                //dt_ok = obj_da_Receipt.GetRecptHeadFA(int_vouno, int_bid, Str_Mode, int_Vouyear);
                //if ((dt_ok.Rows.Count > 0) && (bounbln == false))
                //{
                //    int_Receiptcount = dt_ok.Rows.Count;
                //    Receiptdate = DateTime.Parse(dt_ok.Rows[1]["receiptdate"].ToString());
                //    partyname = dt_ok.Rows[1]["customername"].ToString();
                //    ReceiptAmount = double.Parse(dt_ok.Rows[1]["rfamount"].ToString());
                //    Str_deleted = "";
                //    Str_deleted = dt_ok.Rows[1]["deleted"].ToString();
                //    if (Str_deleted == "0")
                //    {
                //        Str_deleted = "N";
                //    }
                //    else if (Str_deleted == "1")
                //    {
                //        Str_deleted = "Y";
                //    }
                //    int_Receiptid = Convert.ToInt32(dt_ok.Rows[1]["receiptid"].ToString());

                //    int_ReceiptBankid = 0;
                //    str_Chequeno = "";
                //    if (Str_Mode.ToString() == "B")
                //    {
                //        int_ReceiptBankid = Convert.ToInt32(dt_ok.Rows[1]["bank"].ToString());
                //        str_Chequeno = dt_ok.Rows[1]["chequeno"].ToString();
                //    }
                //    Str_ReceiptBank = "";

                //    Str_ReceiptBank = obj_da_Receipt.GetBankName(int_ReceiptBankid);

                //    dt_ok = obj_da_Receipt.GetRAInvoiceToShow(int_Receiptid, 'R');
                //    if (dt_ok.Rows.Count > 0)
                //    {
                //        var obj_Vouno = (from r in dt_ok.AsEnumerable()
                //                         select r.Field<Int32>("vouno").ToString());
                //        Str_ReceiptNarration = string.Join(",", obj_Vouno);
                //    }
                //    if (ReceiptAmount < 0)
                //    {
                //        Fn_InsertReceiptBonusCheck(int_vouno, int_voutype, Receiptdate);
                //    }
                //}
            }
            log1.Info("********************************************************************************************************************************************************");
        }

        public static void Fn_GetReceiptRef()
        {
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();

            Str_Reference = "";
            DataTable dt_ok = new DataTable();
            DataTable dt_ok1 = new DataTable();
            DataTable dt_ok2 = new DataTable();

            dt_ok = obj_da_Receipt.GetRecptCust(int_Receiptid);
            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
            {
                dt_ok1 = obj_da_Receipt.GetRAInvoiceToShowWithCustomer(int_Receiptid, 'R', Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()));
                for (int j = 0; j <= dt_ok1.Rows.Count - 1; j++)
                {
                    if (dt_ok1.Rows[j].ItemArray[2].ToString().Trim().Length > 0)
                    {
                        if (dt_ok1.Rows[j]["voutype"].ToString() == "I")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "Invoice", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "P")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "Credit Note - Operations", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "M")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "Proforma Invoices", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "T")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "Extentions", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "F")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "FinalBills", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "V")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "DNHead", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "E")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "CNHead", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        if (dt_ok2.Rows.Count > 0)
                        {
                            Str_Reference = Str_Reference + dt_ok2.Rows[0].ItemArray[5].ToString() + ",";
                        }
                    }
                }
            }

            if (Str_Reference.Length > 0)
            {
                Str_Reference = HttpUtility.HtmlDecode(Str_Reference.Substring(0, Str_Reference.Length - 1));
            }
        }

        public static void Fn_InsertReceipt(int int_vouno, int int_voutype, DateTime RDate, string Chequeno, int bid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();            
            log1.Info("********************************************************************************************************************************************************");
            log1.Info("Fn_InsertReceipt has been Called");
            log1.Info("Voucher Details - (Voutype- " + int_voutype + " | Vouno-" + int_vouno + " | Branchid- " + bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataTable dt_ok = new DataTable();
            int int_ChkLedgerid = 0, int_voucherid = 0;
            if (obj_da_FAVoucher.CheckFAExists4Voucher(int_vouno, int_Vouyear, bid, int_voutype, Str_DBname) == 0)
            {
                Voucher = false;
            }
            else
            {
                if (Str_Check.Length > 0)
                {
                    Str_Check = Str_Check + "-" + int_vouno.ToString();
                }
                else
                {
                    Str_Check = int_vouno.ToString();
                }
                Voucher = true;

                bounbln = true;
            }

            if (Voucher == false)
            {
                DataAccess.Accounts.Recipts obj_da_receipt = new DataAccess.Accounts.Recipts();
                dt_ok = obj_da_receipt.GetRecptCust(int_Receiptid);
                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), "C", Str_DBname);
                    if (int_ChkLedgerid == 0)
                    {
                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString())).ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), 'C', Str_DBname);
                    }
                }
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                if (Str_deleted == "Y")
                {
                    log1.Info("Cancelled - Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + bid + "|EmployeeID-" + int_Empid + ")");
                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                    log1.Info("Cancelled - Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                }
                else
                {
                    log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + bid + "|EmployeeID-" + int_Empid + ")");
                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                    log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                    obj_da_FAVoucher.UpdateFAVouHeadDetails(Str_DBname, "Cheque", int_voucherid, Chequeno, 0, "");
                    obj_da_FAVoucher.UpdRefno4VouHead(int_voucherid, HttpUtility.HtmlDecode(Str_Reference), Str_DBname);
                    obj_da_FAVoucher.UpdRPNarr4VouHead(int_voucherid, str_reciptnar, Str_DBname);

                    int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                    if (int_ChkLedgerid == 0)
                    {
                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 32, 13, 'C', 0, 'O', Str_DBname);
                    }
                    if (ReceiptAmount > 0)
                    {
                        log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(ReceiptAmount.ToString("#0.000")) + ") - Dr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(ReceiptAmount.ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                        log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(ReceiptAmount.ToString("#0.000")) + ") - Dr - Inserted");
                    }

                    if (Str_ddl_voucher == "Receipt - Petty Cash")
                    {
                        dt_ok = obj_da_receipt.GetRecptCust(int_Receiptid);
                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        {
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgerid(Str_DBname, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C');
                            if (Amt > 0)
                            {
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Before Inserted");
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Inserted");
                            }
                            else if (Amt < 0)
                            {
                                if (int_Receiptcount == 1)
                                {
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Inserted");
                                }
                            }
                        }

                        dt_ok = obj_da_receipt.GetRecptChrg(int_Receiptid);
                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        {
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());


                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "TAX DEDUCTED AT SOURCE RECEIVABLE", 'O');
                            if (Amt < 0)
                            {
                                log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Before Inserted");
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Inserted");
                            }
                            else if (Amt > 0)
                            {
                                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_ok.Rows[i]["cc"].ToString(), 'A');
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                            }
                        }
                    }
                    else
                    {
                        dt_ok = obj_da_receipt.GetRecptCust4FA(int_Receiptid, "R");
                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        {
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                            if (Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()) == bid)
                            {
                                int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), "C", Str_DBname);
                                if (int_ChkLedgerid == 0)
                                {
                                    int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_ok.Rows[i]["cc"].ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C', Str_DBname);
                                }
                            }
                            else
                            {
                                obj_da_FAVoucher.InsFAJournalDtls(int_vouno, bid, "R", int_Vouyear, Str_Mode.ToString(), Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()), Str_deleted, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()));

                                Fn_InsertJV4ML(int_vouno, Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()), double.Parse(dt_ok.Rows[i]["amount"].ToString()), dt_ok.Rows[i]["Customer"].ToString(), RDate, int_voutype);
                                DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
                                DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
                                string str_cust = obj_da_OSDN.GetPortCode(Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()));
                                // ledgerid = FAObj.Sellegerid4IntrBr(strCustName4Rcpt, "O", dtCuschrg.Rows(x).Item("branchid"), Login.FADbname);
                                int_ChkLedgerid = obj_da_FA.Sellegerid4IntrBr(str_cust, 'O', Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()), Str_DBname);
                                // int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, str_cust, 'O');
                                if (int_ChkLedgerid == 0)
                                {
                                    int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(str_cust, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
                                }
                            }
                            if (Amt > 0)
                            {
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Before Inserted");
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Inserted");
                            }
                            else if (Amt < 0)
                            {
                                if (int_Receiptcount == 1)
                                {
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Dr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Dr - Inserted");
                                }
                            }
                        }

                        dt_ok = obj_da_receipt.GetRecptChrg(int_Receiptid);
                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        {
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                            if (((dt_ok.Rows[i]["cc"] == "BANK CHARGES") || (dt_ok.Rows[i]["cc"] == "BANK INTEREST")) && (HttpContext.Current.Session["LoginBranchName"].ToString() == "CORPORATE"))
                            {
                                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_ok.Rows[i]["cc"].ToString(), 'A');
                                if (Amt < 0)
                                {
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Inserted");
                                }

                            }
                            else
                            {
                                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "TAX DEDUCTED AT SOURCE RECEIVABLE", 'O');
                                if (Amt < 0)
                                {
                                    log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                    log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Inserted");
                                }
                                else if (Amt > 0)
                                {
                                    int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_ok.Rows[i]["cc"].ToString(), 'A');
                                    log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                    log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Inserted");
                                }
                            }
                        }
                    }

                    if (int_Receiptcount > 1)
                    {
                        dt_ok = obj_da_FAVoucher.GetFAES(int_Receiptid);
                    }
                    else
                    {
                        dt_ok = obj_da_receipt.GetES(int_Receiptid);
                    }
                    string str_LedgerType = "";
                    for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                    {
                        double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                        if (Amt >= 0)
                        {
                            str_LedgerType = "Cr";
                        }
                        else if (Amt < 0)
                        {
                            str_LedgerType = "Dr";
                        }
                        int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "EXCESS / SHORT", 'O');
                        log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                        log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Inserted");
                        break;
                    }
                }
            }
            log1.Info("********************************************************************************************************************************************************");
        }

        public static void Fn_InsertJV4ML(int int_vouno, int int_bid_JV, double amount, string Customer, DateTime Rdate1)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.Accounts.Journal obj_da_Journal = new DataAccess.Accounts.Journal();
            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.OSDNCN OSDCNObj = new DataAccess.Accounts.OSDNCN();

            DataTable dt_ok = new DataTable();
            int int_divisionid_JV = 0, int_Ledgerid_JV = 0;
            string Str_branchname = OSDCNObj.GetPortCode(int_bid);
            dt_ok = obj_da_Emp.GetBranchandDivision(int_bid_JV);

            if (dt_ok.Rows.Count > 0)
            {
                int_divisionid_JV = Convert.ToInt32(dt_ok.Rows[0]["divisionid"].ToString());
            }
            int int_voutypeid_JV = obj_da_Journal.Selvoutypeid("Journal", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DateTime Journal_date = Rdate1;
            int int_vouno_JV = obj_da_Journal.GetJournalNoMONTH(int_bid_JV, Rdate1);

            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_JV + "|Vouno-" + int_vouno_JV + "|Branchid-" + int_bid_JV + "|EmployeeID-" + int_Empid + ")");
            int int_Voucherid_JV = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_JV, int_vouno_JV.ToString(), Journal_date, obj_da_Branch.GetShortName(int_bid_JV) + " - Receipt #: " + int_vouno + " Amount collected at " + Str_branchname + "./" + Str_ReceiptNarration, "AC", 1, 0, int_bid_JV, int_divisionid_JV, int_Empid, Journal_date, char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_Voucherid_JV + ")");
            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voutypeid_JV, int_vouno.ToString(), 0, "");

            // 1nd entry for JV

            int_Ledgerid_JV = obj_da_FA.Sellegerid4IntrBr(Str_branchname, 'O', int_bid, Str_DBname);

            // int int_Ledgerid_JV = obj_da_FA.Selledgeridforops(Str_DBname, Str_branchname, 'O');

            if (int_Ledgerid_JV == 0)
            {
                int_Ledgerid_JV = obj_da_Ledger.InsLedgerHeadfromTally(Str_branchname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }

            if (amount < 0)
            {
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Cr - Before Inserted");
                obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Cr", Convert.ToDouble(Math.Abs(amount).ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Cr - Inserted");
            }
            else
            {
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Before Inserted");
                obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Dr", Convert.ToDouble(amount.ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Inserted");
            }

            //----------------------------------------------------------------------------------------------------------------------------------------------------

            // 1st entry for JV

            //int_Ledgerid_JV = obj_da_FA.Selledgeridforops(Str_DBname, Customer, 'C');

            int_Ledgerid_JV = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(Customer), 'C');

            if (int_Ledgerid_JV == 0)
            {
                int_Ledgerid_JV = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Convert.ToInt32(Customer)), int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }

            if (amount < 0)
            {
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Before Inserted");
                obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Dr", Convert.ToDouble(Math.Abs(amount).ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Inserted");
            }
            else
            {
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Cr", Convert.ToDouble(amount.ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Inserted");
            }

            //obj_da_FA.UpdVouDtls4OS(Str_DBname, int_Voucherid_JV, "", 0, 0);
            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid_JV, Str_Fcurr, Amt_F, Exrate);
        }

        public static void Fn_InsertReceiptBonusCheck(int int_vouno, int int_voutypeid, DateTime Rdate)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataTable dt_ok = new DataTable();
            int int_ChkLedgerid = 0, int_voucherid = 0;

            if (obj_da_FAVoucher.CheckFAExists4Voucher(int_vouno, int_Vouyear, int_bid, int_voutypeid, Str_DBname) == 0)
            {
                Voucher = false;
            }
            else
            {
                if (Str_Check.Length > 0)
                {
                    Str_Check = Str_Check + "-" + int_vouno.ToString();
                }
                else
                {
                    Str_Check = int_vouno.ToString();
                }
                Voucher = true;
                bounbln = true;
            }
            if (Voucher == true)
            {
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid + "|Vouno-" + int_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
                int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutypeid, int_vouno.ToString(), Rdate, Str_ReceiptNarration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                HttpContext.Current.Session["vouid"] = int_voucherid;
                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                obj_da_FAVoucher.UpdRPNarr4VouHead(int_voucherid, str_reciptnar, Str_DBname);

                if (obj_da_FAVoucher.CheckFAExists4VoucherES(int_vouno, int_Vouyear, int_bid, int_voutypeid, int_ChkLedgerid, "Cr", Str_DBname) != 0)
                {
                    if (Str_Check.Length > 0)
                    {
                        Str_Check = Str_Check + "-" + int_vouno.ToString();
                    }
                    else
                    {
                        Str_Check = int_vouno.ToString();
                    }
                }
                if (ReceiptAmount < 0)
                {
                    log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ReceiptAmount).ToString("#0.000")) + ") - Cr - Before Inserted");
                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(ReceiptAmount).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                    log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ReceiptAmount).ToString("#0.000")) + ") - Cr - Inserted");
                }
                DataAccess.Accounts.Recipts obj_da_receipt = new DataAccess.Accounts.Recipts();
                dt_ok = obj_da_receipt.GetRecptCust(int_Receiptid);

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    int_ChkLedgerid = obj_da_FAVoucher.Selledgerid(Str_DBname, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C');
                    if (Amt < 0)
                    {
                        log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                        log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Inserted");
                    }
                }

                dt_ok = obj_da_receipt.GetRecptChrg(int_Receiptid);

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "TAX DEDUCTED AT SOURCE RECEIVABLE", 'O');
                    if (Amt > 0)
                    {
                        log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                        log1.Info("Ledger-TAX DEDUCTED AT SOURCE RECEIVABLE -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Inserted");
                    }
                }

                dt_ok = obj_da_FAVoucher.GetFAES(int_Receiptid);

                string str_LedgerType = "";
                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    if (Amt >= 0)
                    {
                        str_LedgerType = "Cr";
                    }
                    else if (Amt < 0)
                    {
                        str_LedgerType = "Dr";
                    }
                    int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "EXCESS / SHORT", 'O');
                    if (obj_da_FAVoucher.CheckFAExists4VoucherES(int_vouno, int_Vouyear, int_bid, int_voutypeid, int_ChkLedgerid, str_LedgerType, Str_DBname) == 0)
                    {
                        log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                        log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Inserted");
                    }
                }
            }
        }

        public static void checkrever(int int_vouno, string voutype, string Str_voucherReverse)
        {
            DataAccess.Accounts.Payment objpa = new DataAccess.Accounts.Payment();
            DataTable dtCheck = new DataTable();
            dtCheck = objpa.CheckVouReversalfa(int_vouno, int_bid, voutype, int_Vouyear);
            {
                if (dtCheck.Rows.Count > 0)
                {
                    if (Str_voucherReverse == "")
                    {
                        if (voutype == "E")
                        {
                            Str_voucherReverse = "Inv2CN";
                        }
                        else if (voutype == "V")
                        {
                            Str_voucherReverse = "CNOps2DN";
                        }
                        else if (voutype == "C")
                        {
                            Str_voucherReverse = "OSDN2OSCN";
                        }
                        else if (voutype == "D")
                        {
                            Str_voucherReverse = "OSCN2OSDN";
                        }
                        else if (voutype == "S")
                        {
                            Str_voucherReverse = "ADN2OACN";
                        }
                        else if (voutype == "X")
                        {
                            Str_voucherReverse = "ACN2OADN";
                        }
                        int_RVouno = Convert.ToInt32(dtCheck.Rows[0]["vouno"]);
                        int_Ryear = Convert.ToInt32(dtCheck.Rows[0]["vouyear"]);
                        Str_Rtype = "P";
                    }
                }
            }
        }

        public static void Fn_GetBankPayment(int int_vouno, int int_voutype, int branchid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();
            log1.Info("********************************************************************************************************************************************************");
            log1.Info("Fn_GetBankPayment has been Called");
            log1.Info("Voucher Details - (Voutype- " + int_voutype + " | Vouno-" + int_vouno + " | Branchid- " + branchid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");

            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            int Month = obj_da_Log.GetDate().Month;
            int_Receiptcount = 0;
            string str_Month = "", Str_Year = "";
            str_Month = Month.ToString();
            Str_ReceiptNarration = "";

            if (Month < 10)
            {
                str_Month = "0" + str_Month;
            }
            Str_Year = int_Vouyear.ToString();
            Str_Year = Str_Year.Substring(2, 2);
            DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
            DataTable dt_ok = new DataTable();

            dt_ok = obj_da_Payment.GetPaymentHead(int_vouno, branchid, Str_Mode, int_Vouyear);
            if (dt_ok.Rows.Count > 0)
            {
                int_Receiptcount = dt_ok.Rows.Count;
                DateTime Receiptdate = Convert.ToDateTime((dt_ok.Rows[0]["paymentdate"].ToString()));
                ReceiptAmount = double.Parse(dt_ok.Rows[0]["rfamount"].ToString());
                Str_deleted = "";
                Str_deleted = dt_ok.Rows[0]["deleted"].ToString();
                if (Str_deleted == "0")
                {
                    Str_deleted = "N";
                }
                else if (Str_deleted == "1")
                {
                    Str_deleted = "Y";
                }
                int_Receiptid = Convert.ToInt32(dt_ok.Rows[0]["paymentid"].ToString());

                int_ReceiptBankid = 0;
                string str_Chequeno = "";
                if (Str_Mode.ToString() == "B")
                {
                    int_ReceiptBankid = Convert.ToInt32(dt_ok.Rows[0]["bank"].ToString());
                    str_Chequeno = dt_ok.Rows[0]["chequeno"].ToString();
                }
                Str_ReceiptNarration = dt_ok.Rows[0]["naration"].ToString();
                int_RBranchid = Convert.ToInt32(dt_ok.Rows[0]["branchid"].ToString());
                Str_ReceiptBank = "";
                DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();

                Str_ReceiptBank = obj_da_Receipt.GetBankName(int_ReceiptBankid);


                if (Str_ddl_voucher == "Bank Payment")
                {
                    Str_ledgerExp = Str_ReceiptBank;
                }

                dt_ok = obj_da_Receipt.GetRAInvoiceToShow(int_Receiptid, 'P');
                if (dt_ok.Rows.Count > 0)
                {
                    //var obj_Vouno = (from r in dt_ok.AsEnumerable()
                    //                 select r.Field<Int32>("vouno").ToString());
                    //Str_ReceiptNarration = string.Join(",", obj_Vouno);

                    str_reciptnar = "";
                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            Str_ReceiptNarration += "/V-" + dt_ok.Rows[i]["vouno"].ToString() + ",";
                        }
                        else
                        {
                            Str_ReceiptNarration += dt_ok.Rows[i]["vouno"].ToString() + ",";
                        }
                        str_reciptnar += dt_ok.Rows[i]["vouno"].ToString() + ",";
                    }

                    if (Str_ReceiptNarration != "")
                    {
                        string last = Str_ReceiptNarration.Substring(Str_ReceiptNarration.Length - 1, 1);

                        if (last == ",")
                        {
                            Str_ReceiptNarration = Str_ReceiptNarration.Substring(0, Str_ReceiptNarration.Length - 1);
                        }
                    }

                    if (Str_ReceiptNarration.Length > 0)
                    {
                        Str_ReceiptNarration = HttpUtility.HtmlDecode(Str_ReceiptNarration.Replace("&", "&amp;"));
                    }
                }

                Fn_GetPaymentRef();
                Fn_InsertPayment(int_vouno, int_voutype, Receiptdate, str_Chequeno, branchid);
                //Fn_InsertPayment(int_vouno, int_voutype, Receiptdate, str_Chequeno);

            }
            log1.Info("********************************************************************************************************************************************************");
        }

        public static void Fn_GetPaymentRef()
        {
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();

            Str_Reference = "";
            DataTable dt_ok = new DataTable();
            DataTable dt_ok1 = new DataTable();
            DataTable dt_ok2 = new DataTable();

            dt_ok = obj_da_Payment.GetPaymentCust(int_Receiptid);
            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
            {
                dt_ok1 = obj_da_Receipt.GetRAInvoiceToShowWithCustomer(int_Receiptid, 'P', Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()));
                for (int j = 0; j <= dt_ok1.Rows.Count - 1; j++)
                {
                    if (dt_ok1.Rows[j].ItemArray[2].ToString().Trim().Length > 0)
                    {
                        if (dt_ok1.Rows[j]["voutype"].ToString() == "F")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "FinalBills", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "P")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "PA", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "I")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "Invoices", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "V")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "DNHead", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "S")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "PA-Admin", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "X")
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "DN-Admin", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "CNHead", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }

                        if (dt_ok2.Rows.Count > 0)
                        {
                            Str_Reference = Str_Reference + dt_ok2.Rows[0].ItemArray[5].ToString() + ",";
                        }
                    }
                }
            }

            if (Str_Reference.Length > 0)
            {
                Str_Reference = HttpUtility.HtmlDecode(Str_Reference.Substring(0, Str_Reference.Length - 1));
            }
        }

        /*  public static void Fn_InsertPayment(int int_vouno, int int_voutype, DateTime RDate, string Chequeno)
          {
              DataAccess.Accounts.Payment Payment_Obj = new DataAccess.Accounts.Payment();
              DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
              DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
              DataTable dt_ok = new DataTable();
              DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
              int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
              int int_ChkLedgerid = 0, int_voucherid = 0;

              if (int_Corid == int_bid)
              {
                  if (obj_da_FAVoucher.CheckFAExists4Voucher4Corp(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
                  {
                      Voucher = false;
                  }
                  else
                  {
                      if (Str_Check.Length > 0)
                      {
                          Str_Check = Str_Check + "-" + int_vouno.ToString();
                      }
                      else
                      {
                          Str_Check = int_vouno.ToString();
                      }
                      Voucher = true;

                      bounbln = true;
                  }
              }
              else
              {
                  if (obj_da_FAVoucher.CheckFAExists4Voucher(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
                  {
                      Voucher = false;
                  }
                  else
                  {
                      if (Str_Check.Length > 0)
                      {
                          Str_Check = Str_Check + "-" + int_vouno.ToString();
                      }
                      else
                      {
                          Str_Check = int_vouno.ToString();
                      }
                      Voucher = true;
                  }
              }
              if (Voucher == false)
              {
                  DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                  dt_ok = obj_da_Payment.GetPaymentCust(int_Receiptid);
                  //4 Contra and Branch Impress Account 

                  if (dt_ok.Rows.Count > 0)
                  {
                      customerid4branch = Convert.ToInt32(dt_ok.Rows[0]["Customer"].ToString());
                  }

                  for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                  {

                      int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), "C", Str_DBname);
                      if (int_ChkLedgerid == 0)
                      {
                          DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

                          int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString())).ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), 'C', Str_DBname);
                      }
                  }
                  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                  if (Str_deleted == "N")
                  {
                      Fn_CheckdebitPaymentAmount(int_vouno, int_voutype);
                      if (R_Flag == true)
                      {
                          R_Flag = false;
                          return;
                      }
                  }
                  if (Str_deleted == "Y")
                  {
                      int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                      HttpContext.Current.Session["vouid"] = int_voucherid;
                  }
                  else
                  {
                      if (customerid4branch != 965)
                      {
                          int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                          HttpContext.Current.Session["vouid"] = int_voucherid;
                          obj_da_FAVoucher.UpdateFAVouHeadDetails(Str_DBname, "Cheque", int_voucherid, Chequeno, 0, "");
                          obj_da_FAVoucher.UpdRefno4VouHead(int_voucherid, HttpUtility.HtmlDecode(Str_Reference), Str_DBname);
                          obj_da_FAVoucher.UpdRPNarr4VouHead(int_voucherid, str_reciptnar, Str_DBname);
                          //  DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();




                          if (int_Voutypeid_Corp == 11)
                          {
                              DataAccess.Masters.MasterDivision obj_da_division = new DataAccess.Masters.MasterDivision();

                              Str_ledgerExp = "CTC ACCOUNT-" + obj_da_division.GetShortName(int_divisionid) + "-CO";
                              if (customerid4branch == 965)
                              {
                                  int_ChkLedgerid = 351514;
                              }
                              else
                              {
                                  int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                              }

                              if (int_ChkLedgerid == 0)
                              {
                                  int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 58, 14, 'G', 0, 'O', Str_DBname);
                              }

                          }
                          else
                          {
                              int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                              if (int_ChkLedgerid == 0)
                              {
                                  int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 58, 14, 'G', 0, 'O', Str_DBname);
                              }
                          }
                          DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
                          if (int_voutype == 12)
                          {
                              if (Str_ledgerExp.Contains("CTC ACCOUNT"))
                              {
                                  Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(int_bid).ToUpper();
                                  int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                                  if (int_ChkLedgerid == 0)
                                  {
                                      int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 58, 14, 'G', 0, 'O', Str_DBname);
                                  }
                              }
                          }
                          obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(ReceiptAmount).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                          dt_ok = obj_da_Payment.GetPaymentCust(int_Receiptid);
                          if (dt_ok.Rows.Count > 0)
                          {
                              for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                              {
                                  double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());

                                  if (customerid4branch == 965)
                                  {
                                      int_ChkLedgerid = 351514;
                                  }
                                  else
                                  {
                                      int_ChkLedgerid = obj_da_FAVoucher.Selledgerid(Str_DBname, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C');
                                  }

                                  obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                              }
                          }

                          dt_ok = obj_da_Payment.GetPaymentChrg(int_Receiptid);

                          for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                          {
                              string str_LedgerType = "";
                              int int_chargeid = Convert.ToInt32(dt_ok.Rows[i]["chargeID"].ToString());
                              char Str_Chargetype = char.Parse(dt_ok.Rows[i]["chargetype"].ToString());
                              double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                              if (Amt >= 0)
                              {
                                  str_LedgerType = "Dr";
                              }
                              else if (Amt < 0)
                              {
                                  str_LedgerType = "Cr";
                              }
                              int int_Subgroupid_BP = 0, int_Groupid_BP = 0;
                              int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_ok.Rows[i]["cc"].ToString(), Str_Chargetype);
                              if (int_ChkLedgerid == 0)
                              {
                                  if (dt_ok.Rows[i]["cc"].ToString().Substring(0, 3) == "TAX" || dt_ok.Rows[i]["cc"].ToString().Substring(0, 3) == "TDS")
                                  {
                                      int_Subgroupid_BP = 3;
                                      int_Groupid_BP = 20;
                                  }
                                  else
                                  {
                                      int_Subgroupid_BP = 87;
                                      int_Groupid_BP = 18;
                                  }
                                  int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_ok.Rows[i]["cc"].ToString(), int_Subgroupid_BP, int_Groupid_BP, 'G', int_chargeid, Str_Chargetype, Str_DBname);
                              }
                              int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_ok.Rows[i]["cc"].ToString(), Str_Chargetype);
                              obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                          }
                          dt_ok = obj_da_Payment.GetPaymentES(int_Receiptid);
                          if (dt_ok.Rows.Count > 0)
                          {
                              string str_LedgerType = "";
                              double Amt = double.Parse(dt_ok.Rows[0]["amount"].ToString());
                              if (Amt >= 0)
                              {
                                  str_LedgerType = "Dr";
                              }
                              else if (Amt < 0)
                              {
                                  str_LedgerType = "Cr";
                              }
                              int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "EXCESS / SHORT", 'O');
                              if (Amt > 0)
                              {
                                  obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                              }
                              else if (Amt < 0)
                              {
                                  obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                              }
                          }

                      }

                      if (int_Voutypeid_Corp == 11)
                      {
                          if (int_voutype != 12)
                          {
                              Fn_CheckPaymentDetail4CO(int_vouno, int_voucherid, RDate);
                              if (customerid4branch == 965)
                              {
                                  string fcur = "";
                                  double famt = 0.00;
                                  double exrate = 0.00;
                                  DataAccess.FAVoucher obj_fa = new DataAccess.FAVoucher();
                                  DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
                                  // int bid = Emp_Obj.GetBranchId(Convert.ToInt32(HttpContext.Current. Session["LoginDivisionId"])), ddl_branch.SelectedItem.Text);
                                  int contrano = obj_fa.GetJournalNo(Convert.ToInt32(int_bid));
                                  int_ChkLedgerid = 351514;
                                  int voucherid = obj_fa.InsFAVouHead(HttpContext.Current.Session["FADbname"].ToString(), 14, contrano.ToString(), RDate, Str_ReceiptNarration, "FA", 0, 0, int_bid, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), RDate, 'N', Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()));
                                  obj_fa.UpdateFAVouHeadDetails(HttpContext.Current.Session["FADbname"].ToString(), "Contra", voucherid, Chequeno, 0, "");
                                  obj_fa.InsFAVouDetails(HttpContext.Current.Session["FADbname"].ToString(), voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]), Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
                                  fcur = "INR";
                                  famt = 1.00;
                                  exrate = 1.00;

                                  obj_fa.SPFAUpdVouDtls4Fcur(HttpContext.Current.Session["FADbname"].ToString(), voucherid, fcur, famt, exrate, int_ChkLedgerid, "Cr", Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()));
                                  DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
                                  //pETTY CASH CONTRA.
                                  Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(int_bid).ToUpper();
                                  int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                                  if (int_ChkLedgerid == 0)
                                  {
                                      int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 19, 10, 'G', 0, 'O', Str_DBname);
                                  }

                                  obj_fa.InsFAVouDetails(HttpContext.Current.Session["FADbname"].ToString(), voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]), Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
                                  fcur = "INR";
                                  famt = 1.00;
                                  exrate = 1.00;

                                  obj_fa.SPFAUpdVouDtls4Fcur(HttpContext.Current.Session["FADbname"].ToString(), voucherid, fcur, famt, exrate, int_ChkLedgerid, "Dr", Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()));

                              }
                          }
                      }
                  }
              }
          }*/

        public static void Fn_CheckdebitPaymentAmount(int int_vouno, int int_voutype)
        {
            double Debit_1 = 0, Debit_2 = 0, Debit_3 = 0, Debit_4 = 0, Credit_1 = 0, Credit_2 = 0, Credit_3 = 0, Credit_4 = 0;
            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataTable dt_ok = new DataTable();

            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            int int_ChkLedgerid = 0, int_voucherid = 0;
            if (int_Corid == int_bid)
            {
                if (obj_da_FAVoucher.CheckFAExists4Voucher4Corp(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
                {
                    Voucher = false;
                }
                else
                {
                    if (Str_Check.Length > 0)
                    {
                        Str_Check = Str_Check + "-" + int_vouno.ToString();
                    }
                    else
                    {
                        Str_Check = int_vouno.ToString();
                    }
                    Voucher = true;

                    bounbln = true;
                }
            }
            else
            {
                if (obj_da_FAVoucher.CheckFAExists4Voucher(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
                {
                    Voucher = false;
                }
                else
                {
                    if (Str_Check.Length > 0)
                    {
                        Str_Check = Str_Check + "-" + int_vouno.ToString();
                    }
                    else
                    {
                        Str_Check = int_vouno.ToString();
                    }
                    Voucher = true;

                    bounbln = true;
                }
            }

            if (Voucher == false)
            {
                if (ReceiptAmount > 0)
                {
                    Credit_1 = ReceiptAmount;
                }
                DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                dt_ok = obj_da_Payment.GetPaymentCust(int_Receiptid);

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                    if (Amt != 0)
                    {
                        Debit_1 = Debit_1 + Amt;
                    }
                }

                dt_ok = obj_da_Payment.GetPaymentChrg(int_Receiptid);

                if (dt_ok.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                    {
                        double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                        if (Amt > 0)
                        {
                            Debit_3 = Debit_3 + Math.Abs(Amt);
                        }
                        else if (Amt < 0)
                        {
                            Credit_3 = Credit_3 + Math.Abs(Amt);
                        }
                    }
                }

                dt_ok = obj_da_Payment.GetPaymentES(int_Receiptid);

                if (dt_ok.Rows.Count > 0)
                {
                    string str_LedgerType = "";

                    for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                    {
                        double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                        if (Amt < 0)
                        {
                            str_LedgerType = "Cr";
                            Credit_2 = Credit_2 + Math.Abs(Amt);
                        }
                        else if (Amt >= 0)
                        {
                            str_LedgerType = "Dr";
                            Debit_2 = Debit_2 + Math.Abs(Amt);
                        }
                    }
                }


                if (Double_Truncate((Debit_1 + Debit_2 + Debit_3 + Debit_4), 4) == Double_Truncate((Credit_1 + Credit_2 + Math.Abs(Credit_3)), 4) && Double_Truncate((Debit_1 + Debit_2 + Debit_3 + Debit_4), 4) > 0)
                {
                    R_Flag = false;
                }
                else
                {
                    R_Flag = true;
                }
            }
        }

        public static void Fn_CheckPaymentDetail4CO(int int_vouno, int int_voutype, DateTime Rdate)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataTable dt_ok = new DataTable();
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            DataAccess.LogDetails obj_Log = new DataAccess.LogDetails();
            DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            DataAccess.FAMaster.MasterLedger obj_da_ledger = new DataAccess.FAMaster.MasterLedger();
            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");

            int int_ChkLedgerid = 0, int_voucherid = 0;
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_Voutypeid_Corp + "|Vouno-" + int_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
            int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_Voutypeid_Corp, int_vouno.ToString(), Rdate, Str_ReceiptNarration, "AC", 1, 0, int_Corid, int_divisionid, int_Empid, obj_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FAVoucher.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);
            obj_da_FAVoucher.UpdRPNarr4VouHead(int_voucherid, Str_ReceiptNarration, Str_DBname);
            DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();

            dt_ok = obj_da_Payment.GetPaymentCust(int_Receiptid);
            if (dt_ok.Rows.Count > 0)
            {
                customerid4branch = Convert.ToInt32(dt_ok.Rows[0]["Customer"].ToString());
            }

            //4 Contra and Branch Impress Account 


            string str_PartyLedger = "CTC ACCOUNT-" + obj_da_Branch.GetShortName(int_RBranchid);
            if (customerid4branch == 965)
            {
                int_ChkLedgerid = 351514;
            }
            else
            {
                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, str_PartyLedger, 'O');
            }


            if (int_ChkLedgerid == 0)
            {
                int_ChkLedgerid = obj_da_ledger.InsLedgerHeadfromTally(str_PartyLedger, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-" + str_PartyLedger + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(ReceiptAmount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(ReceiptAmount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger-" + str_PartyLedger + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(ReceiptAmount.ToString("#0.000")) + ") - Dr - Inserted");

            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ReceiptBank, 'O');

            if (int_ChkLedgerid == 0)
            {
                int_ChkLedgerid = obj_da_ledger.InsLedgerHeadfromTally(Str_ReceiptBank, 18, 10, 'B', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-" + Str_ReceiptBank + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(ReceiptAmount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(ReceiptAmount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger-" + Str_ReceiptBank + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(ReceiptAmount.ToString("#0.000")) + ") - Cr - Inserted");
            HttpContext.Current.Session["Custamount4Branch"] = ReceiptAmount.ToString("#0.000");
        }

        public static void Fn_GetRemitReceipt(int int_vouno, int int_voutype)
        {
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            int Month = obj_da_Log.GetDate().Month;
            int_Receiptcount = 0;
            string str_Month = "", Str_Year = "";
            str_Month = Month.ToString();
            if (Month < 10)
            {
                str_Month = "0" + str_Month;
            }
            Str_Year = HttpContext.Current.Session["LogYear"].ToString();
            Str_Year = Str_Year.Substring(2, 2);
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataTable dt_ok = new DataTable();
            dt_ok = obj_da_Receipt.GetOSRecptHeadForTally(int_vouno, int_bid, Str_Mode, int_Vouyear);
            if (dt_ok.Rows.Count > 0)
            {
                int_Receiptcount = dt_ok.Rows.Count;

                //DateTime Receiptdate = DateTime.Parse(Utility.fn_ConvertDate(dt_ok.Rows[0]["paymentdate"].ToString()));
                //double Remit_amount = double.Parse(dt_ok.Rows[0]["pamount"].ToString());
                //double Remit_Exrate = double.Parse(dt_ok.Rows[0]["exrate"].ToString());
                //string Remit_Curr = dt_ok.Rows[0]["curr"].ToString();
                //ReceiptAmount = double.Parse(dt_ok.Rows[0]["payfamount"].ToString());

                DateTime Receiptdate = DateTime.Parse(dt_ok.Rows[0]["receiptdate"].ToString());
                double Remit_amount = double.Parse(dt_ok.Rows[0]["ramount"].ToString());
                double Remit_Exrate = double.Parse(dt_ok.Rows[0]["exrate"].ToString());
                string Remit_Curr = dt_ok.Rows[0]["curr"].ToString();
                ReceiptAmount = double.Parse(dt_ok.Rows[0]["receiptfamount"].ToString());

                Str_deleted = "";
                Str_deleted = dt_ok.Rows[0]["deleted"].ToString();
                if (Str_deleted == "0")
                {
                    Str_deleted = "N";
                }
                else if (Str_deleted == "1")
                {
                    Str_deleted = "Y";
                }
                int_Receiptid = Convert.ToInt32(dt_ok.Rows[0]["receiptid"].ToString());

                int_ReceiptBankid = 0;
                string str_Chequeno = "";

                if (Str_Mode.ToString() == "B")
                {
                    int_ReceiptBankid = Convert.ToInt32(dt_ok.Rows[0]["bank"].ToString());
                    str_Chequeno = dt_ok.Rows[0]["chequeno"].ToString();
                }
                Str_Narration = dt_ok.Rows[0]["naration"].ToString();
                Str_Narration = Str_Narration.Replace("&", "&amp;");
                int_RBranchid = Convert.ToInt32(dt_ok.Rows[0]["branchid"].ToString());

                Str_ReceiptBank = "";
                Str_ReceiptBank = obj_da_Receipt.GetBankName(int_ReceiptBankid);

                dt_ok = obj_da_Receipt.GetRAInvoiceToShow4OS(int_Receiptid, char.Parse(str_voutype));
                if (dt_ok.Rows.Count > 0)
                {
                    //var obj_Vouno = (from r in dt_ok.AsEnumerable()
                    //                 select r.Field<Int32>("vouno").ToString());
                    //Str_ReceiptNarration = string.Join(",", obj_Vouno);

                    Str_ReceiptNarration = ""; str_reciptnar = "";
                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                    {
                        Str_ReceiptNarration += dt_ok.Rows[i]["vouno"].ToString() + ",";
                        str_reciptnar += dt_ok.Rows[i]["vouno"].ToString() + ",";
                    }

                    if (Str_ReceiptNarration != "")
                    {
                        string last = Str_ReceiptNarration.Substring(Str_ReceiptNarration.Length - 1, 1);

                        if (last == ",")
                        {
                            Str_ReceiptNarration = Str_ReceiptNarration.Substring(0, Str_ReceiptNarration.Length - 1);
                        }
                    }

                    if (Str_ReceiptNarration.Length > 0)
                    {
                        Str_ReceiptNarration = HttpUtility.HtmlDecode(Str_ReceiptNarration.Replace("&", "&amp;"));
                    }
                }
                //Fn_GetReceiptRef();
                Fn_GetRemitRef();
                Fn_InsertRemitRec(int_vouno, int_voutype, Receiptdate, str_Chequeno, Remit_Curr, Remit_amount, Remit_Exrate);
            }
        }


        public static void Fn_GetRemitRef()
        {
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
            DataAccess.Accounts.DCAdvise obj_da_DCadvice = new DataAccess.Accounts.DCAdvise();

            Str_Reference = "";
            DataTable dt_ok = new DataTable();
            DataTable dt_ok1 = new DataTable();
            DataTable dt_ok2 = new DataTable();
            DataTable dt_ok3 = new DataTable();

            string str_Ftype = "";
            dt_ok = obj_da_Payment.GetOSPaymentCust(int_Receiptid);
            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
            {
                dt_ok1 = obj_da_Receipt.GetOSRAInvoiceToShowWithCustomerForTally(int_Receiptid, char.Parse(str_voutype), Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()));
                for (int j = 0; j <= dt_ok1.Rows.Count - 1; j++)
                {
                    if (dt_ok1.Rows[j].ItemArray[2].ToString().Trim().Length > 0)
                    {
                        if (dt_ok1.Rows[j]["voutype"].ToString() == "V")
                        {
                            str_Ftype = "DNHead";
                            //dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "FinalBills", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "E")
                        {
                            str_Ftype = "CNHead";
                            //dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "PA", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "D")
                        {
                            str_Ftype = "OSSI";
                            //dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), "Invoices", Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }
                        else if (dt_ok1.Rows[j]["voutype"].ToString() == "C")
                        {
                            str_Ftype = "OSPI";

                        }
                        if ((str_Ftype == "OSPI" || str_Ftype == "OSSI") && Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()) != 0)
                        {
                            dt_ok2 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), str_Ftype, Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                            if (str_Ftype == "OSSI")
                            {
                                dt_ok3 = obj_da_DCadvice.GetDCAdviseWBranch(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), dt_ok2.Rows[0]["trantype"].ToString(), "DebitAdvise", Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["vouno"].ToString()), int_Vouyear);
                            }
                            else
                            {
                                dt_ok3 = obj_da_DCadvice.GetDCAdviseWBranch(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), dt_ok2.Rows[0]["trantype"].ToString(), "CreditAdvise", Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["vouno"].ToString()), int_Vouyear);
                            }
                        }
                        else
                        {
                            dt_ok3 = obj_da_Invoice.ShowTallyDt(Convert.ToInt32(dt_ok1.Rows[j].ItemArray[2].ToString()), str_Ftype, Convert.ToInt32(dt_ok1.Rows[j].ItemArray[7].ToString()), Convert.ToInt32(dt_ok1.Rows[j]["branch"].ToString()));
                        }

                        //if (dt_ok3.Rows.Count > 0)
                        //{

                        //    var obj_Vouno = (from r in dt_ok3.AsEnumerable()
                        //                     select r.Field<string>("blno").ToString());
                        //    Str_ReceiptNarration = string.Join(",", obj_Vouno);
                        //}

                        Str_ReceiptNarration = ""; str_reciptnar = "";
                        for (int l = 0; l < dt_ok3.Rows.Count; l++)
                        {
                            Str_ReceiptNarration += dt_ok3.Rows[l]["blno"].ToString() + ",";
                            //str_reciptnar += dt_ok1.Rows[l]["vouno"].ToString() + ",";
                        }

                        if (Str_ReceiptNarration != "")
                        {
                            string last = Str_ReceiptNarration.Substring(Str_ReceiptNarration.Length - 1, 1);

                            if (last == ",")
                            {
                                Str_ReceiptNarration = Str_ReceiptNarration.Substring(0, Str_ReceiptNarration.Length - 1);
                            }
                        }
                    }
                }
            }

            if (Str_ReceiptNarration.Length > 0)
            {
                Str_ReceiptNarration = HttpUtility.HtmlDecode(Str_ReceiptNarration.Substring(0, Str_ReceiptNarration.Length - 1));
            }
        }

        public static void Fn_InsertRemitRec(int int_vouno, int int_voutype, DateTime RDate, string Chequeno, String R_Curr, double R_Amount, double R_Exrate)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataTable dt_ok = new DataTable();
            DataTable dt_CT = new DataTable();

            int int_ChkLedgerid = 0, int_voucherid = 0;
            if (obj_da_FAVoucher.CheckFAExists4Voucher(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
            {
                Voucher = false;
            }
            else
            {
                if (Str_Check.Length > 0)
                {
                    Str_Check = Str_Check + " , " + int_vouno.ToString(); //change
                }
                else
                {
                    Str_Check = int_vouno.ToString();
                }
                Voucher = true;
                R_Flag = true;
            }
            if (Voucher == false)
            {
                DataAccess.Accounts.Recipts obj_da_receipt = new DataAccess.Accounts.Recipts();
                dt_ok = obj_da_receipt.GetOSRecptCust(int_Receiptid); //change
                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), "C", Str_DBname);
                    if (int_ChkLedgerid == 0)
                    {
                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString())).ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), 'C', Str_DBname);
                    }
                }
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();


                if (Str_deleted == "Y")
                {
                    log1.Info("Cancelled - Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                    log1.Info("Cancelled - Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                }
                else
                {
                    log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                    log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                    obj_da_FAVoucher.UpdateFAVouHeadDetails(Str_DBname, "Cheque", int_voucherid, Chequeno, 0, "");
                    obj_da_FAVoucher.UpdRefno4VouHead(int_voucherid, Str_Reference, Str_DBname);

                    DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                    DataAccess.Accounts.Recipts obj_da_Recipts = new DataAccess.Accounts.Recipts();
                    string str_LedgerType = "";
                    int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ReceiptBank, 'O');
                    if (int_ChkLedgerid == 0)
                    {

                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ReceiptBank, int_Subgroupid, int_Groupid, 'G', int_ReceiptBankid, 'O', Str_DBname);
                    }

                    if (ReceiptAmount > 0)
                    {
                        log1.Info("Ledger-" + Str_ReceiptBank + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(R_Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(R_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                        log1.Info("Ledger-" + Str_ReceiptBank + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(R_Amount.ToString("#0.000")) + ") - Dr - Inserted");


                        int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", R_Amount, int_Vouyear);
                        log1.Info("Ledger-" + Str_ReceiptBank + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(R_Amount.ToString("#0.000")) + ") - Dr - Inserted");
                        obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, ReceiptAmount, R_Exrate);
                    }
                    dt_ok = obj_da_Recipts.GetOSRecptCust(int_Receiptid);
                    if (dt_ok.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        { 
                            str_LedgerType = "";
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString()); //* (-1); 
                            double F_Amt = double.Parse(dt_ok.Rows[i]["fcamt"].ToString()); //* (-1);
                            if (F_Amt == 0.0)
                            {
                                double Exrate = 1;
                            }
                            else
                            {
                                double Exrate = Math.Round(Amt / F_Amt, 2);
                            }
                            //double Exrate = Math.Round(Amt / F_Amt, 2);

                            int_ChkLedgerid = obj_da_FAVoucher.Selledgerid(Str_DBname, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C');
                            if (Amt > 0)
                            {
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Before Inserted");
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Inserted");
                                int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Amt, int_Vouyear);
                                obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, F_Amt, Exrate);
                            }
                            else if (Amt < 0)
                            {
                                if (int_Receiptcount == 1)
                                {
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid); // nee check Amt = abs(Amt)
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Inserted");
                                    int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Math.Abs(Amt), int_Vouyear);
                                    obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, Math.Abs(F_Amt), Math.Abs(Exrate));
                                }
                            }

                        }
                    }

                    dt_CT = obj_da_Recipts.GetOSRecptChrg(int_Receiptid);
                    if (dt_CT.Rows.Count > 0)
                    {
                        str_LedgerType = "";
                        char str_chrgtype;
                        string str_cltype = "";
                        int Int_intchargeid = 0;
                        for (int i = 0; i <= dt_CT.Rows.Count - 1; i++)
                        {
                            double ctamt = double.Parse(dt_CT.Rows[i]["amount"].ToString());
                            double cfamt = double.Parse(dt_CT.Rows[i]["fcamt"].ToString());
                            double chexrate = Math.Round(ctamt / cfamt, 2);
                            str_chrgtype = char.Parse(dt_CT.Rows[i]["chargetype"].ToString());
                            Int_intchargeid = int.Parse(dt_CT.Rows[i]["chargeID"].ToString());

                            if (ctamt > 0)
                            {
                                str_cltype = "Cr";
                            }
                            else if (ctamt <= 0)
                            {
                                str_cltype = "Dr";
                            }
                            int_ChkLedgerid = 0;
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_CT.Rows[i]["CC"].ToString().Trim(), str_chrgtype);
                            if (int_ChkLedgerid == 0)
                            {
                                if (dt_CT.Rows[i]["CC"].ToString().Substring(0, 3) == "TAX" || dt_CT.Rows[i]["CC"].ToString().Substring(0, 3) == "TDS")
                                {
                                    int_Subgroupid = 27;
                                    int_Groupid = 23;
                                }
                                else
                                {
                                    int_Subgroupid = 61;
                                    int_Groupid = 19;
                                }
                                int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_CT.Rows[i]["CC"].ToString(), int_Subgroupid, int_Groupid, 'G', Int_intchargeid, str_chrgtype, Str_DBname);
                            }
                            
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_CT.Rows[i]["CC"].ToString().Trim(), str_chrgtype);
                            log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ctamt).ToString("#0.000")) + ") - " + str_cltype + " - Before Inserted");
                            obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_cltype, Convert.ToDouble(Math.Abs(ctamt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                            log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ctamt).ToString("#0.000")) + ") - " + str_cltype + " - Inserted");
                            int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, str_cltype, Math.Abs(ctamt), int_Vouyear);
                            obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, Math.Abs(cfamt), chexrate);
                        }
                    }

                    if (int_Receiptcount == 1)
                    {
                        dt_ok = obj_da_receipt.GetOSES(int_Receiptid);
                    }

                    if (dt_ok.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        {
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString()); //* (-1);
                            if (Amt >= 0)
                            {
                                str_LedgerType = "Cr";
                            }
                            else if (Amt < 0)
                            {
                                str_LedgerType = "Dr";
                            }
                            
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "EXCHANGE GAIN / LOSS", 'C');
                            log1.Info("Ledger-EXCHANGE GAIN / LOSS -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Before Inserted");
                            obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                            log1.Info("Ledger-EXCHANGE GAIN / LOSS -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Inserted");
                            break;
                        }
                    }
                }
            }
        }

        public static void Fn_GetRemitPayment(int int_vouno, int int_voutype)
        {
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            int Month = obj_da_Log.GetDate().Month;
            int_Receiptcount = 0;
            string str_Month = "", Str_Year = "";
            str_Month = Month.ToString();
            if (Month < 10)
            {
                str_Month = "0" + str_Month;
            }
            Str_Year = HttpContext.Current.Session["LogYear"].ToString();
            Str_Year = Str_Year.Substring(2, 2);
            DataAccess.Accounts.Recipts obj_da_Receipt = new DataAccess.Accounts.Recipts();
            DataTable dt_ok = new DataTable();
            dt_ok = obj_da_Receipt.GetOSPaymentHeadForTally(int_vouno, int_bid, Str_Mode, int_Vouyear);

            if (dt_ok.Rows.Count > 0)
            {
                int_Receiptcount = dt_ok.Rows.Count;

                //DateTime Receiptdate = DateTime.Parse(Utility.fn_ConvertDate(dt_ok.Rows[0]["paymentdate"].ToString()));
                //double Remit_amount = double.Parse(dt_ok.Rows[0]["pamount"].ToString());
                //double Remit_Exrate = double.Parse(dt_ok.Rows[0]["exrate"].ToString());
                //string Remit_Curr = dt_ok.Rows[0]["curr"].ToString();
                //ReceiptAmount = double.Parse(dt_ok.Rows[0]["payfamount"].ToString());

                DateTime Receiptdate = DateTime.Parse(dt_ok.Rows[0]["paymentdate"].ToString());
                double Remit_amount = double.Parse(dt_ok.Rows[0]["pamount"].ToString());
                double Remit_Exrate = double.Parse(dt_ok.Rows[0]["exrate"].ToString());
                string Remit_Curr = dt_ok.Rows[0]["curr"].ToString();
                ReceiptAmount = double.Parse(dt_ok.Rows[0]["payfamount"].ToString());

                Str_deleted = "";
                Str_deleted = dt_ok.Rows[0]["deleted"].ToString();
                if (Str_deleted == "0")
                {
                    Str_deleted = "N";
                }
                else if (Str_deleted == "1")
                {
                    Str_deleted = "Y";
                }
                int_Receiptid = Convert.ToInt32(dt_ok.Rows[0]["paymentid"].ToString());

                int_ReceiptBankid = 0;
                string str_Chequeno = "";

                if (Str_Mode.ToString() == "B")
                {
                    int_ReceiptBankid = Convert.ToInt32(dt_ok.Rows[0]["bank"].ToString());
                    str_Chequeno = dt_ok.Rows[0]["chequeno"].ToString();
                }
                Str_Narration = dt_ok.Rows[0]["naration"].ToString();
                Str_Narration = Str_Narration.Replace("&", "&amp;");
                int_RBranchid = Convert.ToInt32(dt_ok.Rows[0]["branchid"].ToString());

                Str_ReceiptBank = "";
                Str_ReceiptBank = obj_da_Receipt.GetBankName(int_ReceiptBankid);

                dt_ok = obj_da_Receipt.GetRAInvoiceToShow4OS(int_Receiptid, char.Parse(str_voutype));
                if (dt_ok.Rows.Count > 0)
                {
                    //var obj_Vouno = (from r in dt_ok.AsEnumerable()
                    //                 select r.Field<Int32>("vouno").ToString());
                    //Str_ReceiptNarration = string.Join(",", obj_Vouno);

                    Str_ReceiptNarration = ""; str_reciptnar = "";
                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                    {
                        Str_ReceiptNarration += dt_ok.Rows[i]["vouno"].ToString() + ",";
                        str_reciptnar += dt_ok.Rows[i]["vouno"].ToString() + ",";
                    }

                    if (Str_ReceiptNarration != "")
                    {
                        string last = Str_ReceiptNarration.Substring(Str_ReceiptNarration.Length - 1, 1);

                        if (last == ",")
                        {
                            Str_ReceiptNarration = Str_ReceiptNarration.Substring(0, Str_ReceiptNarration.Length - 1);
                        }
                    }
                }

                if (Str_ReceiptNarration.Length > 0)
                {
                    Str_ReceiptNarration = HttpUtility.HtmlDecode(Str_ReceiptNarration.Replace("&", "&amp;"));
                }

                //Fn_GetReceiptRef();
                Fn_GetRemitRef();
                Fn_InsertRemitPay(int_vouno, int_voutype, Receiptdate, str_Chequeno, Remit_Curr, Remit_amount, Remit_Exrate);
            }
        }

        public static void Fn_InsertRemitPay(int int_vouno, int int_voutype, DateTime RDate, string Chequeno, String R_Curr, double R_Amount, double R_Exrate)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataTable dt_ok = new DataTable();
            DataTable dt_CT = new DataTable();

            int int_ChkLedgerid = 0, int_voucherid = 0;
            if (obj_da_FAVoucher.CheckFAExists4Voucher(int_vouno, int_Vouyear, int_bid, int_voutype, Str_DBname) == 0)
            {
                Voucher = false;
            }
            else
            {
                if (Str_Check.Length > 0)
                {
                    Str_Check = Str_Check + " , " + int_vouno.ToString(); //change
                }
                else
                {
                    Str_Check = int_vouno.ToString();
                }
                Voucher = true;
                R_Flag = true;
            }
            if (Voucher == false)
            {
                DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                dt_ok = obj_da_Payment.GetOSPaymentCust(int_Receiptid); //change
                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {
                    int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), "C", Str_DBname);
                    if (int_ChkLedgerid == 0)
                    {
                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString())).ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), 'C', Str_DBname);
                    }
                }
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();


                if (Str_deleted == "Y")
                {
                    log1.Info("Cancelled - Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                    log1.Info("Cancelled - Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                }
                else
                {
                    log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                    log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                    obj_da_FAVoucher.UpdateFAVouHeadDetails(Str_DBname, "Cheque", int_voucherid, Chequeno, 0, "");
                    obj_da_FAVoucher.UpdRefno4VouHead(int_voucherid, Str_Reference, Str_DBname);
                    obj_da_FAVoucher.UpdRPNarr4VouHead(int_voucherid, str_reciptnar, Str_DBname);
                    //DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                    DataAccess.Accounts.Recipts obj_da_Recipts = new DataAccess.Accounts.Recipts();
                    string str_LedgerType = "";
                    int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ReceiptBank, 'O');
                    if (int_ChkLedgerid == 0)
                    {

                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ReceiptBank, int_Subgroupid, int_Groupid, 'G', int_ReceiptBankid, 'O', Str_DBname);
                    }

                    if (ReceiptAmount > 0)
                    {
                        log1.Info("Ledger-" + Str_ReceiptBank + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(R_Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(R_Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                        log1.Info("Ledger-" + Str_ReceiptBank + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(R_Amount.ToString("#0.000")) + ") - Cr - Inserted");
                        int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", R_Amount, int_Vouyear);
                        obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, ReceiptAmount, R_Exrate);
                    }
                    dt_ok = obj_da_Payment.GetOSPaymentCust(int_Receiptid);
                    if (dt_ok.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        {
                            str_LedgerType = "";
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString()) * (-1);
                            double F_Amt = double.Parse(dt_ok.Rows[i]["fcamt"].ToString()) * (-1);
                            if (F_Amt == 0.0)
                            {
                                double Exrate = 1;
                            }
                            else
                            {
                                double Exrate = Math.Round(Amt / F_Amt, 2);
                            }
                            //double Exrate = Math.Round(Amt / F_Amt, 2);

                            int_ChkLedgerid = obj_da_FAVoucher.Selledgerid(Str_DBname, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C');
                            if (Amt > 0)
                            {
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Before Inserted");
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Amt.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Amt.ToString("#0.000")) + ") - Cr - Inserted");
                                int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Amt, int_Vouyear);
                                obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, F_Amt, Exrate);
                            }
                            else if (Amt < 0)
                            {
                                if (int_Receiptcount == 1)
                                {
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid); // nee check Amt = abs(Amt)
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Inserted");
                                    int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Math.Abs(Amt), int_Vouyear);
                                    obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, Math.Abs(F_Amt), Math.Abs(Exrate));
                                }
                            }

                        }
                    }

                    dt_CT = obj_da_Payment.GetOSPaymentChrg(int_Receiptid);
                    if (dt_CT.Rows.Count > 0)
                    {
                        str_LedgerType = "";
                        char str_chrgtype;
                        string str_cltype = "";
                        int Int_intchargeid = 0;
                        for (int i = 0; i <= dt_CT.Rows.Count - 1; i++)
                        {
                            double ctamt = double.Parse(dt_CT.Rows[i]["amount"].ToString());
                            double cfamt = double.Parse(dt_CT.Rows[i]["fcamt"].ToString());

                            double chexrate;
                            //double chexrate = Math.Round(ctamt / cfamt, 2);

                            str_chrgtype = char.Parse(dt_CT.Rows[i]["chargetype"].ToString());
                            Int_intchargeid = int.Parse(dt_CT.Rows[i]["chargeID"].ToString());

                            if (ctamt >= 0)
                            {
                                str_cltype = "Dr";
                            }
                            else if (ctamt < 0)
                            {
                                str_cltype = "Cr";
                            }

                            if (cfamt != 0.00)
                            {
                                chexrate = Math.Round(ctamt / cfamt, 2);
                            }
                            else
                            {
                                chexrate = 0.00;
                            }

                            int_ChkLedgerid = 0;
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_CT.Rows[i]["CC"].ToString().Trim(), str_chrgtype);
                            if (int_ChkLedgerid == 0)
                            {
                                if (dt_CT.Rows[i]["CC"].ToString().Substring(0, 3) == "TAX" || dt_CT.Rows[i]["CC"].ToString().Substring(0, 3) == "TDS")
                                {
                                    int_Subgroupid = 27;
                                    int_Groupid = 23;
                                }
                                else
                                {
                                    int_Subgroupid = 61;
                                    int_Groupid = 19;
                                }
                                int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_CT.Rows[i]["CC"].ToString(), int_Subgroupid, int_Groupid, 'G', Int_intchargeid, str_chrgtype, Str_DBname);
                            }
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_CT.Rows[i]["CC"].ToString().Trim(), str_chrgtype);
                            log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ctamt).ToString("#0.000")) + ") - " + str_cltype + " - Before Inserted");
                            obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_cltype, Convert.ToDouble(Math.Abs(ctamt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                            log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ctamt).ToString("#0.000")) + ") - " + str_cltype + " - Inserted");
                            int int_vid = obj_da_FAVoucher.Getvousubid4OS(Str_DBname, int_voucherid, int_ChkLedgerid, str_cltype, Math.Abs(ctamt), int_Vouyear);
                            obj_da_FAVoucher.UpdFAVouDtls4OSRP(Str_DBname, int_vid, R_Curr, Math.Abs(cfamt), chexrate);
                        }
                    }


                    if (int_Receiptcount == 1)
                    {
                        dt_ok = obj_da_Payment.GetOSPaymentES(int_Receiptid);
                    }

                    for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                    {
                        double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString()) * (-1);
                        if (Amt >= 0)
                        {
                            str_LedgerType = "Cr";
                        }
                        else if (Amt < 0)
                        {
                            str_LedgerType = "Dr";
                        }
                        int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "EXCHANGE GAIN / LOSS", 'C');
                        log1.Info("Ledger-EXCHANGE GAIN / LOSS -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
                        log1.Info("Ledger-EXCHANGE GAIN / LOSS -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Inserted");
                        break;
                    }
                }
            }
        }

        public static void Fn_GetContainer(string Trantype, string Blcount, string Str_jobno)
        {
            DataTable dt_ok = new DataTable();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            if (Trantype == "FE" || Trantype == "FI" || Trantype == "FC")
            {
                if (Str_ddl_voucher == "Invoices" || Str_ddl_voucher == "Credit Note - Operations" || Str_ddl_voucher == "Debit Note - Others" || Str_ddl_voucher == "Credit Note - Others" || Str_ddl_voucher == "BOS")
                {
                    dt_ok = obj_da_Invoice.GetHBLContainerDtls(Blcount, Trantype, int_bid);

                    if (dt_ok.Rows.Count > 0)
                    {
                        //var obj_Containerno = (from r in dt_ok.AsEnumerable()
                        //                       select r.Field<string>("containerno").ToString());
                        //Str_Container = string.Join(",", obj_Containerno);    

                        Str_Container = "";
                        for (int i = 0; i < dt_ok.Rows.Count; i++)
                        {
                            Str_Container += dt_ok.Rows[i]["containerno"].ToString() + ",";
                        }

                        if (Str_Container != "")
                        {
                            string last = Str_Container.Substring(Str_Container.Length - 1, 1);

                            if (last == ",")
                            {
                                Str_Container = Str_Container.Substring(0, Str_Container.Length - 1);
                            }
                        }
                    }
                    else if (dt_ok.Rows.Count == 0)
                    {
                        dt_ok = obj_da_Invoice.GetMblContainerDtls(Convert.ToInt32(Str_jobno), Str_jobno, Trantype, int_bid);
                        if (dt_ok.Rows.Count > 0)
                        {
                            //var obj_Containerno = (from r in dt_ok.AsEnumerable()
                            //                       select r.Field<string>("containerno").ToString());
                            //Str_Container = string.Join(",", obj_Containerno);  

                            Str_Container = "";
                            for (int i = 0; i < dt_ok.Rows.Count; i++)
                            {
                                Str_Container += dt_ok.Rows[i]["containerno"].ToString() + ",";
                            }

                            if (Str_Container != "")
                            {
                                string last = Str_Container.Substring(Str_Container.Length - 1, 1);

                                if (last == ",")
                                {
                                    Str_Container = Str_Container.Substring(0, Str_Container.Length - 1);
                                }
                            }
                        }
                    }
                }
                else if (Str_ddl_voucher == "OSSI" || Str_ddl_voucher == "OSPI")
                {
                    dt_ok = obj_da_Invoice.GetMblContainerDtls(Convert.ToInt32(Str_jobno), Str_jobno, Trantype, int_bid);
                    if (dt_ok.Rows.Count > 0)
                    {
                        //var obj_Containerno = (from r in dt_ok.AsEnumerable()
                        //                       select r.Field<string>("containerno").ToString());
                        //Str_Container = string.Join(",", obj_Containerno);      

                        Str_Container = "";
                        for (int i = 0; i < dt_ok.Rows.Count; i++)
                        {
                            Str_Container += dt_ok.Rows[i]["containerno"].ToString() + ",";
                        }

                        if (Str_Container != "")
                        {
                            string last = Str_Container.Substring(Str_Container.Length - 1, 1);

                            if (last == ",")
                            {
                                Str_Container = Str_Container.Substring(0, Str_Container.Length - 1);
                            }
                        }
                    }
                }
            }
            else
            {
                Str_Container = "";
            }
        }

        public static void Fn_GetNarration(int vouno, string Blno, string voutype, string Narration, int Jobno, string Trantype)
        {
            DataTable dt_ok = new DataTable();
            DataTable dt_oktemp = new DataTable();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
            Str_Narration = "";
            switch (Narration)
            {
                case "LedgerNames":
                    switch (Str_ddl_voucher)
                    {
                        case "Invoices":
                            dt_ok = obj_da_Invoice.GetInvoiceDetails(vouno, voutype, int_Vouyear, int_bid);
                            if (dt_ok.Rows.Count > 0)
                            {
                                //var obj_Narration = (from r in dt_ok.AsEnumerable()
                                //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());
                                //Str_Narration = string.Join(",", obj_Narration);   

                                Str_Narration = "";
                                for (int i = 0; i < dt_ok.Rows.Count; i++)
                                {
                                    Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                                }

                                if (Str_Narration != "")
                                {
                                    string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                    if (last == ",")
                                    {
                                        Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                    }
                                }
                            }
                            break;
                        case "Credit Note - Operations":
                            dt_ok = obj_da_Invoice.GetPADetails(vouno, int_Vouyear, int_bid);
                            if (dt_ok.Rows.Count > 0)
                            {
                                //var obj_Narration = (from r in dt_ok.AsEnumerable()
                                //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());
                                //Str_Narration = string.Join(",", obj_Narration); 

                                Str_Narration = "";
                                for (int i = 0; i < dt_ok.Rows.Count; i++)
                                {
                                    Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                                }

                                if (Str_Narration != "")
                                {
                                    string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                    if (last == ",")
                                    {
                                        Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                    }
                                }
                            }
                            break;
                        case "OSSI":
                            dt_ok = obj_da_DC.GetDCAdviseWBranch(Jobno, Trantype, "DebitAdvise", int_bid, vouno, int_Vouyear);
                            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                            {
                                dt_oktemp = obj_da_DC.GetDCCharge(dt_ok.Rows[i]["blno"].ToString(), Trantype, "DebitAdvise", int_bid);
                                if (dt_oktemp.Rows.Count > 0)
                                {
                                    //var obj_Narration = (from r in dt_oktemp.AsEnumerable()
                                    //                     select r.Field<string>(dt_oktemp.Columns[0].ColumnName.ToString()).ToString());
                                    //Str_Narration += string.Join(",", obj_Narration);

                                    Str_Narration = "";
                                    for (int j = 0; j < dt_oktemp.Rows.Count; j++)
                                    {
                                        Str_Narration += dt_oktemp.Rows[j][0].ToString() + ",";
                                    }

                                    if (Str_Narration != "")
                                    {
                                        string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                        if (last == ",")
                                        {
                                            Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                        }
                                    }
                                }
                            }
                            break;
                        case "OSPI":
                            dt_ok = obj_da_DC.GetDCAdviseWBranch(Jobno, Trantype, "CreditAdvise", int_bid, vouno, int_Vouyear);
                            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                            {
                                dt_oktemp = obj_da_DC.GetDCCharge(dt_ok.Rows[i]["blno"].ToString(), Trantype, "CreditAdvise", int_bid);
                                if (dt_oktemp.Rows.Count > 0)
                                {
                                    //var obj_Narration = (from r in dt_oktemp.AsEnumerable()
                                    //                     select r.Field<string>(dt_oktemp.Columns[0].ColumnName.ToString()).ToString());
                                    //Str_Narration += string.Join(",", obj_Narration);  

                                    Str_Narration = "";
                                    for (int j = 0; j < dt_oktemp.Rows.Count; j++)
                                    {
                                        Str_Narration += dt_oktemp.Rows[j][0].ToString() + ",";
                                    }

                                    if (Str_Narration != "")
                                    {
                                        string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                        if (last == ",")
                                        {
                                            Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                        }
                                    }
                                }
                            }
                            break;
                        case "Debit Note - Others":
                            dt_ok = obj_da_Invoice.GetInvoiceDetails(vouno, voutype, int_Vouyear, int_bid);
                            if (dt_ok.Rows.Count > 0)
                            {
                                //var obj_Narration = (from r in dt_ok.AsEnumerable()
                                //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());
                                //Str_Narration = string.Join(",", obj_Narration);    

                                Str_Narration = "";
                                for (int i = 0; i < dt_ok.Rows.Count; i++)
                                {
                                    Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                                }

                                if (Str_Narration != "")
                                {
                                    string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                    if (last == ",")
                                    {
                                        Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                    }
                                }
                            }
                            break;
                        case "Credit Note - Others":
                            dt_ok = obj_da_Invoice.GetPADetails(vouno, int_Vouyear, int_bid);
                            if (dt_ok.Rows.Count > 0)
                            {
                                //var obj_Narration = (from r in dt_ok.AsEnumerable()
                                //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());
                                //Str_Narration = string.Join(",", obj_Narration);    

                                Str_Narration = "";
                                for (int i = 0; i < dt_ok.Rows.Count; i++)
                                {
                                    Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                                }

                                if (Str_Narration != "")
                                {
                                    string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                    if (last == ",")
                                    {
                                        Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                    }
                                }
                            }
                            break;
                        //RUban 
                        case "BOS":
                            dt_ok = obj_da_Invoice.GetInvoiceDetails(vouno, voutype, int_Vouyear, int_bid);
                            if (dt_ok.Rows.Count > 0)
                            {
                                //var obj_Narration = (from r in dt_ok.AsEnumerable()
                                //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());
                                //Str_Narration = string.Join(",", obj_Narration);   

                                Str_Narration = "";
                                for (int i = 0; i < dt_ok.Rows.Count; i++)
                                {
                                    Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                                }

                                if (Str_Narration != "")
                                {
                                    string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                    if (last == ",")
                                    {
                                        Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                    }
                                }
                            }
                            break;
                    }
                    break;
                case "Vessel/Voyage/Container":
                    if (Str_ddl_voucher == "OSSI" || Str_ddl_voucher == "OSPI")
                    {
                        if (Trantype == "FE" || Trantype == "FI" || Trantype == "FC")
                        {
                            DataAccess.ForwardingExports.JobInfo obj_da_FEjob = new DataAccess.ForwardingExports.JobInfo();
                            DataAccess.ForwardingImports.JobInfo obj_da_FIjob = new DataAccess.ForwardingImports.JobInfo();

                            if (Trantype == "FE")
                            {
                                dt_ok = obj_da_FEjob.GetFEJobInfo(Jobno, int_bid, int_divisionid);
                                if (dt_ok.Rows.Count > 0)
                                {
                                    Str_Narration = dt_ok.Rows[0].ItemArray[3].ToString() + " / " + dt_ok.Rows[0].ItemArray[7].ToString() + " / ";
                                }
                            }
                            else
                            {
                                dt_ok = obj_da_FIjob.ShowJobDetails(Jobno, int_bid, int_divisionid);
                                if (dt_ok.Rows.Count > 0)
                                {
                                    DataAccess.Masters.MasterVessel obj_da_Vessel = new DataAccess.Masters.MasterVessel();
                                    Str_Narration = obj_da_Vessel.GetVesselname(Convert.ToInt32(dt_ok.Rows[0].ItemArray[1].ToString())) + " / " + dt_ok.Rows[0].ItemArray[2].ToString() + " / ";
                                }
                            }

                            if (Trantype == "FE")
                            {
                                dt_ok = obj_da_FEjob.GetContainerDetails(Jobno, Jobno.ToString(), int_bid, int_divisionid);
                                if (dt_ok.Rows.Count > 0)
                                {
                                    //var obj_Narration = (from r in dt_ok.AsEnumerable()
                                    //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());
                                    //Str_Narration = string.Join(",", obj_Narration) + Str_Narration;    

                                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                                    {
                                        Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                                    }

                                    if (Str_Narration != "")
                                    {
                                        string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                        if (last == ",")
                                        {
                                            Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();

                                dt_ok = obj_da_FIBL.GetContainerDetails(Jobno, Jobno.ToString(), int_bid, int_divisionid);
                                if (dt_ok.Rows.Count > 0)
                                {
                                    //var obj_Narration = (from r in dt_ok.AsEnumerable()
                                    //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());
                                    //Str_Narration = Str_Narration + string.Join(",", obj_Narration); 

                                    Str_Narration = "";
                                    for (int i = 0; i < dt_ok.Rows.Count; i++)
                                    {
                                        Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                                    }

                                    if (Str_Narration != "")
                                    {
                                        string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                        if (last == ",")
                                        {
                                            Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        dt_ok = obj_da_Invoice.GetHblInvoiceHead(Blno, Trantype, int_bid);

                        if (dt_ok.Rows.Count > 0)
                        {
                            Str_Narration = dt_ok.Rows[0].ItemArray[3].ToString() + " / " + dt_ok.Rows[0].ItemArray[2].ToString() + " / ";
                        }

                        dt_ok = obj_da_Invoice.GetHBLContainerDtls(Blno, Trantype, int_bid);
                        if (dt_ok.Rows.Count > 0)
                        {
                            //var obj_Narration = (from r in dt_ok.AsEnumerable()
                            //                     select r.Field<string>(dt_ok.Columns[0].ColumnName.ToString()).ToString());

                            //Str_Narration = Str_Narration + " / " + obj_Narration;

                            for (int i = 0; i < dt_ok.Rows.Count; i++)
                            {
                                Str_Narration += dt_ok.Rows[i][0].ToString() + ",";
                            }

                            if (Str_Narration != "")
                            {
                                string last = Str_Narration.Substring(Str_Narration.Length - 1, 1);

                                if (last == ",")
                                {
                                    Str_Narration = Str_Narration.Substring(0, Str_Narration.Length - 1);
                                }
                            }
                        }
                    }
                    break;
                case "Remarks":
                    if (Str_ddl_voucher == "OSSI" || Str_ddl_voucher == "OSPI")
                    {
                        Str_Narration = "";
                    }
                    else
                    {
                        dt_ok = obj_da_Invoice.ShowTallyDt(vouno, voutype, int_Vouyear, int_bid);
                        if (dt_ok.Rows.Count > 0)
                        {
                            Str_Narration = dt_ok.Rows[0].ItemArray[10].ToString();
                        }
                    }
                    break;
            }

            if (Str_Narration.Length > 0)
            {
                Str_Narration = HttpUtility.HtmlDecode(Str_Narration.Replace("&", "&amp;"));
            }
        }

        public static void Fn_GetReference(int int_vouno, string Reference, int jobno, string trantype, string BL)
        {
            switch (Str_ddl_voucher)
            {
                case "Proforma Invoices":
                    Str_FAVoucherType = "Proforma Invoices";
                    Fn_Reference(int_vouno, "Proforma Invoices", Reference, trantype, jobno, BL);
                    break;
                case "Extentions":
                    Str_FAVoucherType = "Extentions";
                    Fn_Reference(int_vouno, "Extentions", Reference, trantype, jobno, BL);
                    break;
                case "FinalBills":
                    Str_FAVoucherType = "FinalBills";
                    Fn_Reference(int_vouno, "FinalBills", Reference, trantype, jobno, BL);
                    break;
                case "Invoices":
                    Str_FAVoucherType = "Invoices";
                    Fn_Reference(int_vouno, "Invoice", Reference, trantype, jobno, BL);
                    break;
                case "Admin Sales Invoice":
                    Str_FAVoucherType = "DN-Admin";
                    Fn_Reference(int_vouno, "Admin Sales Invoice", Reference, trantype, jobno, BL);
                    break;
                case "Credit Note - Operations":
                    Str_FAVoucherType = "Payment Advise";
                    Fn_Reference(int_vouno, "Credit Note - Operations", Reference, trantype, jobno, BL);
                    break;
                case "Admin Purchase Invoice":
                    Str_FAVoucherType = "PA-Admin";
                    Fn_Reference(int_vouno, "Admin Purchase Invoice", Reference, trantype, jobno, BL);
                    break;
                case "OSSI":
                    Str_FAVoucherType = "OSSI";
                    if (Reference == "Voucher No")
                    {
                        Fn_Reference(int_vouno, "OSSI", Reference, trantype, jobno, BL);
                    }
                    else
                    {
                        Fn_Reference(jobno, "OSSI", Reference, trantype, jobno, BL);
                    }
                    break;
                case "OSPI":
                    Str_FAVoucherType = "OSPI";
                    Fn_Reference(int_vouno, "OSPI", Reference, trantype, jobno, BL);
                    break;
                case "Debit Note - Others":
                    Str_FAVoucherType = "DNHead";
                    Fn_Reference(int_vouno, "DNHead", Reference, trantype, jobno, BL);
                    break;
                case "Credit Note - Others":
                    Str_FAVoucherType = "CNHead";
                    Fn_Reference(int_vouno, "CNHead", Reference, trantype, jobno, BL);
                    break;
                //Ruban Add for BOS
                case "BOS":
                    Str_FAVoucherType = "BOS";
                    Fn_Reference(int_vouno, "BOS", Reference, trantype, jobno, BL);
                    break;
            }
        }


        private static void Fn_Reference(int int_vouno, string voutype, string ddlreference, string trantype, int int_jobno, string BL)
        {
            DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
            DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataTable dt_ok = new DataTable();
            switch (ddlreference)
            {
                case "Voucher No":
                    Str_Reference = trantype + " " + int_vouno.ToString();
                    break;
                case "Ref No":
                    Str_Reference = BL;
                    break;
                case "Vendor Ref No":
                    Str_Reference = "";
                    break;

                case "BL No":
                    /* if (voutype == "OSSI")
                     {
                         dt_ok = obj_da_DC.GetDCAdviseWBranch(int_vouno, trantype, "DebitAdvise", int_bid);
                         if (dt_ok.Rows.Count > 0)
                         {
                             var obj_Reference = (from r in dt_ok.AsEnumerable() select r.Field<string>("blno").ToString());
                             Str_Reference = string.Join(",", obj_Reference);
                         }
                     }
                     else if (voutype == "OSPI")
                     {
                         dt_ok = obj_da_DC.GetDCAdviseWBranch(int_vouno, trantype, "CreditAdvise", int_bid);
                         if (dt_ok.Rows.Count > 0)
                         {
                             var obj_Reference = (from r in dt_ok.AsEnumerable() select r.Field<string>("blno").ToString());
                             Str_Reference = string.Join(",", obj_Reference);
                         }
                     }
                     else
                     {
                         dt_ok = obj_da_Invoice.ShowTallyDt(int_vouno, trantype, int_Vouyear, int_bid);
                         if (dt_ok.Rows.Count > 0)
                         {
                             var obj_Reference = (from r in dt_ok.AsEnumerable() select r.Field<string>("blno").ToString());
                             Str_Reference = string.Join(",", obj_Reference);
                         }
                     }*/

                    if (voutype == "OSSI" || voutype == "OSPI")
                    {
                        if (voutype == "OSSI")
                        {
                            dt_ok = obj_da_DC.GetDCAdviseWBranch(int_jobno, trantype, "DebitAdvise", int_bid, int_vouno, int_Vouyear);
                            //if (dt_ok.Rows.Count > 0)
                            //{
                            //    var obj_Reference = (from r in dt_ok.AsEnumerable() select r.Field<string>("blno").ToString());
                            //    Str_Reference = string.Join(",", obj_Reference);
                            //}

                            Str_Reference = "";
                            for (int i = 0; i < dt_ok.Rows.Count; i++)
                            {
                                Str_Reference += dt_ok.Rows[i]["blno"].ToString() + ",";
                            }

                            if (Str_Reference != "")
                            {
                                string last = Str_Reference.Substring(Str_Reference.Length - 1, 1);

                                if (last == ",")
                                {
                                    Str_Reference = Str_Reference.Substring(0, Str_Reference.Length - 1);
                                }
                            }
                        }
                        else if (voutype == "OSPI")
                        {
                            dt_ok = obj_da_DC.GetDCAdviseWBranch(int_jobno, trantype, "CreditAdvise", int_bid, int_vouno, int_Vouyear);
                            //if (dt_ok.Rows.Count > 0)
                            //{
                            //    var obj_Reference = (from r in dt_ok.AsEnumerable()
                            //                         select r.Field<string>("blno").ToString());
                            //    Str_Reference = string.Join(",", obj_Reference);
                            //}
                            //Str_Reference = "MVGSFRT45664";

                            Str_Reference = "";
                            for (int i = 0; i < dt_ok.Rows.Count; i++)
                            {
                                Str_Reference += dt_ok.Rows[i]["blno"].ToString() + ",";
                            }
                            if (Str_Reference != "")
                            {
                                string last = Str_Reference.Substring(Str_Reference.Length - 1, 1);
                                //Str_Reference = Str_Reference.Substring(0, Str_Reference.Length - 1);
                                if (last == ",")
                                {
                                    Str_Reference = Str_Reference.Substring(0, Str_Reference.Length - 1);
                                }
                            }
                        }
                    }
                    else
                    {
                        dt_ok = obj_da_Invoice.ShowTallyDt(int_vouno, voutype, int_Vouyear, int_bid);
                        //if (dt_ok.Rows.Count > 0)
                        //{
                        //    var obj_Reference = (from r in dt_ok.AsEnumerable()
                        //                         select r.Field<string>("blno").ToString());
                        //    //Str_Reference = obj_Reference.ToString() + ",";
                        //    Str_Reference = string.Join(",", obj_Reference);
                        //}
                        //Str_Reference = "jhsdjghgd1221423";

                        Str_Reference = "";
                        for (int i = 0; i < dt_ok.Rows.Count; i++)
                        {
                            Str_Reference += dt_ok.Rows[i]["blno"].ToString() + ",";
                        }

                        if (Str_Reference != "")
                        {
                            string last = Str_Reference.Substring(Str_Reference.Length - 1, 1);
                            //Str_Reference = Str_Reference.Substring(0, Str_Reference.Length - 1);
                            if (last == ",")
                            {
                                Str_Reference = Str_Reference.Substring(0, Str_Reference.Length - 1);
                            }
                        }
                    }
                    break;
            }

            if (Str_Reference.Length > 0)
            {
                Str_Reference = HttpUtility.HtmlDecode(Str_Reference.Replace("&", "&amp;"));
            }
        }

        private static void Fn_CheckDebitCredit(double T_Amount, double T_AmountWOST, double T_AmountST, string voutype, int int_vouno)
        {
            if (Str_ddl_voucher == "Admin Sales Invoice" || Str_ddl_voucher == "Invoices" || Str_ddl_voucher == "Proforma Invoices" || Str_ddl_voucher == "Extentions" || Str_ddl_voucher == "Debit Note - Others" || Str_ddl_voucher == "BOS")
            {
                string str_T_Amount = T_Amount.ToString("#0.000");
                string T_AmountWOST_st = (T_AmountWOST + T_AmountST).ToString("#0.000");
                if (Double_Truncate(T_Amount, 4) == Double_Truncate((T_AmountWOST + T_AmountST), 4))
                {

                }
                else
                {
                    R_Flag = true;
                    return;
                }
            }

            else if (Str_ddl_voucher == "Credit Note - Operations" || Str_ddl_voucher == "Admin Purchase Invoice" || Str_ddl_voucher == "Credit Note - Others")
            {
                DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
                double Amt = obj_da_FA.GetFATDSAmount(int_bid, char.Parse(str_voutype), int_vouno, int_Vouyear);
                if (Amt != 0)
                {
                    Amt = Math.Abs(Amt);
                }
                double AmountTDS = T_Amount - Amt;
                if (Double_Truncate((T_AmountWOST + T_AmountST), 4) == Double_Truncate((AmountTDS + Amt), 4))
                {

                }
                else
                {
                    R_Flag = true;
                    return;
                }
            }
        }

        private static void Fn_OtherDN_JVFA(int int_vouno, DateTime Vdate, string trantype, int int_jobno, double Amount, int Cid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();

            int vouno_j = obj_da_invoice.GetAlreadyJVNo("V", int_vouno, int_bid, int_Vouyear);
            if (vouno_j == 0)
            {
                vouno_j = obj_da_invoice.GetJVNo(int_bid);
                obj_da_invoice.InsDCNJV("V", int_vouno, vouno_j, int_bid, int_Vouyear, int_divisionid);
            }
            int int_voutypeid_j = obj_da_FA.Selvoutypeid("OSDNCNJV", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + vouno_j + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
            int int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, vouno_j.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, int_vouno.ToString(), int_jobno, "");

            DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
            string str_Shortname = obj_da_Division.GetShortName(int_divisionid);
            int int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname + "-CO", 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname + "-CO", int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + int_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
            int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, int_vouno.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_Corid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);
            obj_da_FA.Updosvtype4VouHead(Str_DBname, int_voucherid, "V");

            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, vouno_j.ToString(), int_jobno, "");


            //KARTHIKA1
            DataAccess.Masters.MasterBranch obj_da_BranchKAR = new DataAccess.Masters.MasterBranch();
            str_Shortname = obj_da_BranchKAR.GetShortName(int_bid);
            int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname, 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

        }

        private static void Fn_OSDN_JVFA(int int_vouno, DateTime Vdate, string trantype, int int_jobno, double Amount, int Cid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();

            int vouno_j = obj_da_invoice.GetAlreadyJVNo("D", int_vouno, int_bid, int_Vouyear);
            if (vouno_j == 0)
            {
                vouno_j = obj_da_invoice.GetJVNo(int_bid);
                obj_da_invoice.InsDCNJV("D", int_vouno, vouno_j, int_bid, int_Vouyear, int_divisionid);
            }
            int int_voutypeid_j = obj_da_FA.Selvoutypeid("OSDNCNJV", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + vouno_j + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
            int int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, vouno_j.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, int_vouno.ToString(), int_jobno, "");

            DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
            string str_Shortname = obj_da_Division.GetShortName(int_divisionid);
            int int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname + "-CO", 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname + "-CO", int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + int_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
            int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, int_vouno.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_Corid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            obj_da_FA.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);

            obj_da_FA.Updosvtype4VouHead(Str_DBname, int_voucherid, "D");

            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, vouno_j.ToString(), int_jobno, "");

            //KARTHIKA1
            DataAccess.Masters.MasterBranch obj_da_BranchKAR = new DataAccess.Masters.MasterBranch();
            str_Shortname = obj_da_BranchKAR.GetShortName(int_bid);

            int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname, 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

        }
        private static void Fn_OtherCN_JVFA(int int_vouno, DateTime Vdate, string trantype, int int_jobno, double Amount, int Cid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();

            int vouno_j = obj_da_invoice.GetAlreadyJVNo("E", int_vouno, int_bid, int_Vouyear);
            if (vouno_j == 0)
            {
                vouno_j = obj_da_invoice.GetJVNo(int_bid);
                obj_da_invoice.InsDCNJV("E", int_vouno, vouno_j, int_bid, int_Vouyear, int_divisionid);
            }
            int int_voutypeid_j = obj_da_FA.Selvoutypeid("OSDNCNJV", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + vouno_j + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
            int int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, vouno_j.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, int_vouno.ToString(), int_jobno, "");

            DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
            string str_Shortname = obj_da_Division.GetShortName(int_divisionid);
            int int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname + "-CO", 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname + "-CO", int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + int_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
            int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, int_vouno.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_Corid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);
            obj_da_FA.Updosvtype4VouHead(Str_DBname, int_voucherid, "E");

            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, vouno_j.ToString(), int_jobno, "");

            //KARTHIKA1
            DataAccess.Masters.MasterBranch obj_da_BranchKAR = new DataAccess.Masters.MasterBranch();
            str_Shortname = obj_da_BranchKAR.GetShortName(int_bid);
            int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname, 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

        }
        private static void Fn_OSCN_JVFA(int int_vouno, DateTime Vdate, string trantype, int int_jobno, double Amount, int Cid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();


            int vouno_j = obj_da_invoice.GetAlreadyJVNo("C", int_vouno, int_bid, int_Vouyear);
            if (vouno_j == 0)
            {
                vouno_j = obj_da_invoice.GetJVNo(int_bid);
                obj_da_invoice.InsDCNJV("C", int_vouno, vouno_j, int_bid, int_Vouyear, int_divisionid);
            }
            int int_voutypeid_j = obj_da_FA.Selvoutypeid("OSDNCNJV", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + vouno_j + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
            int int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, vouno_j.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, int_vouno.ToString(), int_jobno, "");

            DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
            string str_Shortname = obj_da_Division.GetShortName(int_divisionid);
            int int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname + "-CO", 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname + "-CO", int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + int_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
            int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, int_vouno.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_Corid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            obj_da_FA.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);

            obj_da_FA.Updosvtype4VouHead(Str_DBname, int_voucherid, "C");

            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, vouno_j.ToString(), int_jobno, "");

            //KARTHIKA
            DataAccess.Masters.MasterBranch obj_da_BranchKAR = new DataAccess.Masters.MasterBranch();
            str_Shortname = obj_da_BranchKAR.GetShortName(int_bid);
            int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname, 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

        }
        public static void Fn_InsertPayment(int int_vouno, int int_voutype, DateTime RDate, string Chequeno, int bid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();            
            log1.Info("********************************************************************************************************************************************************");
            log1.Info("Fn_InsertPayment has been Called");
            log1.Info("Voucher Details - (Voutype- " + int_voutype + " | Vouno-" + int_vouno + " | Branchid- " + bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vouyear + ")");


            DataAccess.Accounts.Payment Payment_Obj = new DataAccess.Accounts.Payment();
            DataAccess.FAVoucher obj_da_FAVoucher = new DataAccess.FAVoucher();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataTable dt_ok = new DataTable();
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            int int_ChkLedgerid = 0, int_voucherid = 0;

            if (int_Corid == bid)
            {
                if (obj_da_FAVoucher.CheckFAExists4Voucher4Corp(int_vouno, int_Vouyear, bid, int_voutype, Str_DBname) == 0)
                {
                    Voucher = false;
                }
                else
                {
                    if (Str_Check.Length > 0)
                    {
                        Str_Check = Str_Check + "-" + int_vouno.ToString();
                    }
                    else
                    {
                        Str_Check = int_vouno.ToString();
                    }
                    Voucher = true;

                    bounbln = true;
                }
            }
            else
            {
                if (obj_da_FAVoucher.CheckFAExists4Voucher(int_vouno, int_Vouyear, bid, int_voutype, Str_DBname) == 0)
                {
                    Voucher = false;
                }
                else
                {
                    if (Str_Check.Length > 0)
                    {
                        Str_Check = Str_Check + "-" + int_vouno.ToString();
                    }
                    else
                    {
                        Str_Check = int_vouno.ToString();
                    }
                    Voucher = true;
                }
            }
            if (Voucher == false)
            {
                DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                dt_ok = obj_da_Payment.GetPaymentCust(int_Receiptid);
                //4 Contra and Branch Impress Account

                if (dt_ok.Rows.Count > 0)
                {
                    customerid4branch = Convert.ToInt32(dt_ok.Rows[0]["Customer"].ToString());
                }

                for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                {

                    int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), "C", Str_DBname);
                    if (int_ChkLedgerid == 0)
                    {
                        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();

                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString())).ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_ok.Rows[i]["customer"].ToString()), 'C', Str_DBname);
                    }
                }
                DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();

                if (Str_deleted == "N")
                {
                    Fn_CheckdebitPaymentAmount(int_vouno, int_voutype);
                    if (R_Flag == true)
                    {
                        R_Flag = false;
                        return;
                    }
                }
                if (Str_deleted == "Y")
                {
                    log1.Info("Cancelled - Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + bid + "|EmployeeID-" + int_Empid + ")");
                    int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                    log1.Info("Cancelled - Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                    HttpContext.Current.Session["vouid"] = int_voucherid;
                }
                else
                {
                    if (customerid4branch != 965)
                    {
                        log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutype + "|Vouno-" + int_vouno + "|Branchid-" + bid + "|EmployeeID-" + int_Empid + ")");
                        int_voucherid = obj_da_FAVoucher.InsFAVouHead(Str_DBname, int_voutype, int_vouno.ToString(), RDate, Str_ReceiptNarration, "AC", 1, 0, bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                        log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
                        HttpContext.Current.Session["vouid"] = int_voucherid;
                        obj_da_FAVoucher.UpdateFAVouHeadDetails(Str_DBname, "Cheque", int_voucherid, Chequeno, 0, "");
                        obj_da_FAVoucher.UpdRefno4VouHead(int_voucherid, HttpUtility.HtmlDecode(Str_Reference), Str_DBname);
                        obj_da_FAVoucher.UpdRPNarr4VouHead(int_voucherid, str_reciptnar, Str_DBname);
                        //  DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();




                        if (int_Voutypeid_Corp == 11)
                        {
                            DataAccess.Masters.MasterDivision obj_da_division = new DataAccess.Masters.MasterDivision();

                            Str_ledgerExp = "CTC ACCOUNT-" + obj_da_division.GetShortName(int_divisionid) + "-CO";
                            if (customerid4branch == 965)
                            {
                                int_ChkLedgerid = 351514;
                            }
                            else
                            {
                                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                            }

                            if (int_ChkLedgerid == 0)
                            {
                                int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 58, 14, 'G', 0, 'O', Str_DBname);
                            }

                        }
                        else
                        {
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                            if (int_ChkLedgerid == 0)
                            {
                                int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 58, 14, 'G', 0, 'O', Str_DBname);
                            }
                        }
                        DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
                        if (int_voutype == 12)
                        {
                            if (Str_ledgerExp.Contains("CTC ACCOUNT"))
                            {
                                Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(bid).ToUpper();
                                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                                if (int_ChkLedgerid == 0)
                                {
                                    int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 58, 14, 'G', 0, 'O', Str_DBname);
                                }
                            }
                        }
                        log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ReceiptAmount).ToString("#0.000")) + ") - Cr - Before Inserted");
                        obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(ReceiptAmount).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                        log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(ReceiptAmount).ToString("#0.000")) + ") - Cr - Inserted");
                        //dt_ok = obj_da_Payment.GetPaymentCust(int_Receiptid);
                        dt_ok = obj_da_Payment.GetPaymentCust4FA(int_Receiptid, "P");
                        if (dt_ok.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                            {
                                double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                                if (Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()) == bid)
                                {
                                    int_ChkLedgerid = obj_da_Ledger.ChkLedgeridfrmLedHead(Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), "C", Str_DBname);
                                    if (int_ChkLedgerid == 0)
                                    {
                                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_ok.Rows[i]["cc"].ToString(), int_Subgroupid, int_Groupid, 'G', Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C', Str_DBname);
                                    }
                                    if (customerid4branch == 965)
                                    {
                                        int_ChkLedgerid = 351514;
                                    }
                                    else
                                    {
                                        int_ChkLedgerid = obj_da_FAVoucher.Selledgerid(Str_DBname, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C');
                                    }
                                }
                                else
                                {
                                    obj_da_FAVoucher.InsFAJournalDtls(int_vouno, bid, "P", int_Vouyear, Str_Mode.ToString(), Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()), Str_deleted, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()));

                                    Fn_InsertJV4ML(int_vouno, Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()), double.Parse(dt_ok.Rows[i]["amount"].ToString()), dt_ok.Rows[i]["Customer"].ToString(), RDate, int_voutype);
                                    DataAccess.Accounts.OSDNCN obj_da_OSDN = new DataAccess.Accounts.OSDNCN();
                                    string str_cust = obj_da_OSDN.GetPortCode(Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()));
                                    if (customerid4branch == 965)
                                    {
                                        int_ChkLedgerid = 351514;
                                    }
                                    else
                                    {
                                        int_ChkLedgerid = obj_da_FAVoucher.Selledgerid(Str_DBname, Convert.ToInt32(dt_ok.Rows[i]["Customer"].ToString()), 'C');
                                    }
                                    //   int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, str_cust, 'O');
                                    int_ChkLedgerid = obj_da_FAVoucher.Sellegerid4IntrBr(str_cust, 'O', Convert.ToInt32(dt_ok.Rows[i]["branchid"].ToString()), Str_DBname);
                                    if (int_ChkLedgerid == 0)
                                    {
                                        int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(str_cust, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
                                    }
                                }

                                if (Amt > 0)
                                {
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Dr - Inserted");
                                }
                                else if (Amt < 0)
                                {
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Before Inserted");
                                    obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                    log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - Cr - Inserted");
                                }
                                // obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                            }
                        }

                        dt_ok = obj_da_Payment.GetPaymentChrg(int_Receiptid);

                        for (int i = 0; i <= dt_ok.Rows.Count - 1; i++)
                        {
                            string str_LedgerType = "";
                            int int_chargeid = Convert.ToInt32(dt_ok.Rows[i]["chargeID"].ToString());
                            char Str_Chargetype = char.Parse(dt_ok.Rows[i]["chargetype"].ToString());
                            double Amt = double.Parse(dt_ok.Rows[i]["amount"].ToString());
                            if (Amt >= 0)
                            {
                                str_LedgerType = "Dr";
                            }
                            else if (Amt < 0)
                            {
                                str_LedgerType = "Cr";
                            }
                            int int_Subgroupid_BP = 0, int_Groupid_BP = 0;
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_ok.Rows[i]["cc"].ToString(), Str_Chargetype);
                            if (int_ChkLedgerid == 0)
                            {
                                if (dt_ok.Rows[i]["cc"].ToString().Substring(0, 3) == "TAX" || dt_ok.Rows[i]["cc"].ToString().Substring(0, 3) == "TDS")
                                {
                                    int_Subgroupid_BP = 3;
                                    int_Groupid_BP = 20;
                                }
                                else
                                {
                                    int_Subgroupid_BP = 87;
                                    int_Groupid_BP = 18;
                                }
                                int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(dt_ok.Rows[i]["cc"].ToString(), int_Subgroupid_BP, int_Groupid_BP, 'G', int_chargeid, Str_Chargetype, Str_DBname);
                            }
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, dt_ok.Rows[i]["cc"].ToString(), Str_Chargetype);
                            log1.Info("Ledger-" + Str_Chargetype + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Before Inserted");
                            obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                            log1.Info("Ledger-" + Str_Chargetype + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Inserted");
                        }
                        dt_ok = obj_da_Payment.GetPaymentES(int_Receiptid);
                        if (dt_ok.Rows.Count > 0)
                        {
                            string str_LedgerType = "";
                            double Amt = double.Parse(dt_ok.Rows[0]["amount"].ToString());
                            if (Amt >= 0)
                            {
                                str_LedgerType = "Dr";
                            }
                            else if (Amt < 0)
                            {
                                str_LedgerType = "Cr";
                            }
                            int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, "EXCESS / SHORT", 'O');
                            if (Amt > 0)
                            {
                                log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Before Inserted");
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Inserted");
                            }
                            else if (Amt < 0)
                            {
                                log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Before Inserted");
                                obj_da_FAVoucher.InsFAVouDetails(Str_DBname, int_voucherid, int_ChkLedgerid, str_LedgerType, Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")), int_Vouyear, bid, int_divisionid);
                                log1.Info("Ledger-EXCESS / SHORT -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(Math.Abs(Amt).ToString("#0.000")) + ") - " + str_LedgerType + " - Inserted");
                            }
                        }

                    }

                    if (int_Voutypeid_Corp == 11)
                    {
                        if (int_voutype != 12)
                        {
                            Fn_CheckPaymentDetail4CO(int_vouno, int_voucherid, RDate);
                            if (customerid4branch == 965)
                            {
                                string fcur = "";
                                double famt = 0.00;
                                double exrate = 0.00;
                                DataAccess.FAVoucher obj_fa = new DataAccess.FAVoucher();
                                DataAccess.HR.Employee Emp_Obj = new DataAccess.HR.Employee();
                                // int bid = Emp_Obj.GetBranchId(Convert.ToInt32(HttpContext.Current. Session["LoginDivisionId"])), ddl_branch.SelectedItem.Text);
                                int contrano = obj_fa.GetJournalNo(Convert.ToInt32(bid));
                                int_ChkLedgerid = 351514;
                                log1.Info("Before Insertion of Record in VoucherHead - (Voutype-14|Vouno-" + contrano + "|Branchid-" + bid + "|EmployeeID-" + Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]) + ")");
                                int voucherid = obj_fa.InsFAVouHead(HttpContext.Current.Session["FADbname"].ToString(), 14, contrano.ToString(), RDate, Str_ReceiptNarration, "FA", 0, 0, bid, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]), Convert.ToInt32(HttpContext.Current.Session["LoginEmpId"]), RDate, 'N', Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()));
                                log1.Info("Record has been Inserted in VoucherHead - (" + voucherid + ")");
                                obj_fa.UpdateFAVouHeadDetails(HttpContext.Current.Session["FADbname"].ToString(), "Contra", voucherid, Chequeno, 0, "");

                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]) + ") - Cr - Before Inserted");
                                obj_fa.InsFAVouDetails(HttpContext.Current.Session["FADbname"].ToString(), voucherid, int_ChkLedgerid, "Cr", Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]), Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
                                log1.Info("Ledger- -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]) + ") - Cr - Inserted");
                                fcur = "INR";
                                famt = 1.00;
                                exrate = 1.00;

                                obj_fa.SPFAUpdFAVouDtls4Fcur(HttpContext.Current.Session["FADbname"].ToString(), voucherid, fcur, famt, exrate, int_ChkLedgerid, "Cr", Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()));
                                DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
                                //pETTY CASH CONTRA.
                                if (bid == 4)
                                {
                                    DataTable DtTemp = new DataTable();
                                    DataAccess.Accounts.Payment Payment_Obj2 = new DataAccess.Accounts.Payment();
                                    DtTemp = Payment_Obj2.GetPaymentHead(int_vouno, bid, Convert.ToChar("B"), Convert.ToInt32(int_Vouyear));
                                    string vis = "";
                                    if (DtTemp.Rows.Count > 0)
                                    {
                                        vis = DtTemp.Rows[0]["vis"].ToString();
                                    }
                                    if (vis == "Y")
                                    {
                                        if (Convert.ToInt32(int_Vouyear) == 2018)
                                        {
                                            Str_ledgerExp = "PETTY CASH - AXL - VIZ";
                                        }
                                        else
                                        {
                                            Str_ledgerExp = "PETTY CASH - FIL - VIZ";
                                        }

                                    }
                                    else if (vis == "N")
                                    {
                                        Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(bid).ToUpper();
                                    }
                                }
                                else
                                {
                                    Str_ledgerExp = "PETTY CASH - " + obj_da_Branch.GetShortName(bid).ToUpper();
                                }
                                int_ChkLedgerid = obj_da_FAVoucher.Selledgeridforops(Str_DBname, Str_ledgerExp, 'O');
                                if (int_ChkLedgerid == 0)
                                {
                                    int_ChkLedgerid = obj_da_Ledger.InsLedgerHeadfromTally(Str_ledgerExp, 19, 10, 'G', 0, 'O', Str_DBname);
                                }

                                log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]) + ") - Dr - Before Inserted");
                                obj_fa.InsFAVouDetails(HttpContext.Current.Session["FADbname"].ToString(), voucherid, int_ChkLedgerid, "Dr", Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]), Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]));
                                log1.Info("Ledger-" + Str_ledgerExp + " -ID(" + int_ChkLedgerid + ")-Rs.(" + Convert.ToDouble(HttpContext.Current.Session["Custamount4Branch"]) + ") - Dr - Inserted");
                                fcur = "INR";
                                famt = 1.00;
                                exrate = 1.00;

                                obj_fa.SPFAUpdFAVouDtls4Fcur(HttpContext.Current.Session["FADbname"].ToString(), voucherid, fcur, famt, exrate, int_ChkLedgerid, "Dr", Convert.ToInt32(HttpContext.Current.Session["LogYear"].ToString()));


                            }
                        }
                    }
                }
            }
            log1.Info("********************************************************************************************************************************************************");
        }
        public static void Fn_InsertJV4ML(int int_vouno, int int_bid_JV, double amount, string Customer, DateTime Rdate1, int int_voutype)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.Accounts.Journal obj_da_Journal = new DataAccess.Accounts.Journal();
            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
            DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.OSDNCN OSDCNObj = new DataAccess.Accounts.OSDNCN();

            DataTable dt_ok = new DataTable();
            int int_divisionid_JV = 0, int_Ledgerid_JV = 0;
            string Str_branchname = OSDCNObj.GetPortCode(int_bid);
            dt_ok = obj_da_Emp.GetBranchandDivision(int_bid_JV);

            if (dt_ok.Rows.Count > 0)
            {
                int_divisionid_JV = Convert.ToInt32(dt_ok.Rows[0]["divisionid"].ToString());
            }
            int int_voutypeid_JV = obj_da_Journal.Selvoutypeid("Journal", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            DateTime Journal_date = Rdate1;
            int int_vouno_JV = obj_da_Journal.GetJournalNoMONTH(int_bid_JV, Rdate1);
            int int_Voucherid_JV = 0;

            /*******************************************************************************/
            DataTable dtjv = new DataTable();
            string mode = "", rptype = "", narration_jv = "";

            if (int_voutype == 1102 || int_voutype == 9 || int_voutype == 10)
            {
                rptype = "R";
            }
            else if (int_voutype == 103 || int_voutype == 11 || int_voutype == 12)
            {
                rptype = "P";
            }

            dtjv = obj_da_FA.GetFAJournalDtls(int_vouno, int_bid, rptype, int_Vouyear, Str_Mode.ToString(), int_bid_JV, Convert.ToInt32(Customer));
            if (dtjv.Rows.Count > 0)
            {
                if (rptype == "R")
                {
                    narration_jv = obj_da_Branch.GetShortName(int_bid_JV) + " - Receipt #: " + int_vouno + " Amount collected at " + Str_branchname ;
                }
                else if (rptype == "P")
                {
                    narration_jv = obj_da_Branch.GetShortName(int_bid_JV) + " - Payment #: " + int_vouno + " Amount collected at " + Str_branchname ;
                }
                obj_da_FA.DelFAJournalDtls(int_bid_JV, int_Vouyear, Journal_date.Month, Str_DBname, narration_jv, Convert.ToInt32(Customer));
            }
            //*******************************************************************************//


            if (int_voutype == 1102 || int_voutype == 9 || int_voutype == 10)
            {
                log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_JV + "|Vouno-" + int_vouno_JV + "|Branchid-" + int_bid_JV + "|EmployeeID-" + int_Empid + ")");
                int_Voucherid_JV = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_JV, int_vouno_JV.ToString(), Journal_date, obj_da_Branch.GetShortName(int_bid_JV) + " - Receipt #: " + int_vouno + " Amount collected at " + Str_branchname + "./ " + Str_ReceiptNarration, "AC", 1, 0, int_bid_JV, int_divisionid_JV, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                log1.Info("Record has been Inserted in VoucherHead - (" + int_Voucherid_JV + ")");
                obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voutypeid_JV, int_vouno.ToString(), 0, "");
            }
            else if (int_voutype == 103 || int_voutype == 11 || int_voutype == 12)
            {
                log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_JV + "|Vouno-" + int_vouno_JV + "|Branchid-" + int_bid_JV + "|EmployeeID-" + int_Empid + ")");
                int_Voucherid_JV = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_JV, int_vouno_JV.ToString(), Journal_date, obj_da_Branch.GetShortName(int_bid_JV) + " - Payment #: " + int_vouno + " Amount collected at " + Str_branchname + "./ " + Str_ReceiptNarration, "AC", 1, 0, int_bid_JV, int_divisionid_JV, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
                log1.Info("Record has been Inserted in VoucherHead - (" + int_Voucherid_JV + ")");
                obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voutypeid_JV, int_vouno.ToString(), 0, "");
            }
            /*******************************************************************************/
            obj_da_FA.UpdFAJournalDtls(int_vouno, int_bid, rptype, int_Vouyear, Str_Mode.ToString(), int_bid_JV, int_vouno_JV, Journal_date.Month, Convert.ToInt32(Customer));
            //*******************************************************************************//

            // 1nd entry for JV

            int_Ledgerid_JV = obj_da_FA.Sellegerid4IntrBr(Str_branchname, 'O', int_bid, Str_DBname);

            // int int_Ledgerid_JV = obj_da_FA.Selledgeridforops(Str_DBname, Str_branchname, 'O');

            if (int_Ledgerid_JV == 0)
            {
                int_Ledgerid_JV = obj_da_Ledger.InsLedgerHeadfromTally(Str_branchname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            if (int_voutype == 1102 || int_voutype == 9 || int_voutype == 10)
            {
                if (amount < 0)
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Cr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Cr", Convert.ToDouble(Math.Abs(amount).ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Cr - Inserted");
                }
                else
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Dr", Convert.ToDouble(amount.ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Inserted");
                }
            }
            else if (int_voutype == 103 || int_voutype == 11 || int_voutype == 12)
            {
                if (amount < 0)
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Dr", Convert.ToDouble(Math.Abs(amount).ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Inserted");
                }
                else
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Cr", Convert.ToDouble(amount.ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Inserted");
                }
            }


            //----------------------------------------------------------------------------------------------------------------------------------------------------

            // 1st entry for JV

            //int_Ledgerid_JV = obj_da_FA.Selledgeridforops(Str_DBname, Customer, 'C');

            int_Ledgerid_JV = obj_da_FA.Selledgerid(Str_DBname, Convert.ToInt32(Customer), 'C');
            if (int_Ledgerid_JV == 0)
            {
                int_Ledgerid_JV = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Convert.ToInt32(Customer)), int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }

            if (int_voutype == 1102 || int_voutype == 9 || int_voutype == 10)
            {
                if (amount < 0)
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Dr", Convert.ToDouble(Math.Abs(amount).ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Dr - Inserted");
                }
                else
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Cr", Convert.ToDouble(amount.ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Cr - Inserted");
                }


            }
            else if (int_voutype == 103 || int_voutype == 11 || int_voutype == 12)
            {
                if (amount < 0)
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Cr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Cr", Convert.ToDouble(Math.Abs(amount).ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(Math.Abs(amount).ToString("#0.000")) + ") - Cr - Inserted");
                }
                else
                {
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Before Inserted");
                    obj_da_FA.InsFAVouDetails(Str_DBname, int_Voucherid_JV, int_Ledgerid_JV, "Dr", Convert.ToDouble(amount.ToString("#0.000")), int_Vouyear, int_bid_JV, int_divisionid_JV);
                    log1.Info("Ledger- -ID(" + int_Ledgerid_JV + ")-Rs.(" + Convert.ToDouble(amount.ToString("#0.000")) + ") - Dr - Inserted");
                }

            }


            //obj_da_FA.UpdVouDtls4OS(Str_DBname, int_Voucherid_JV, "", 0, 0);
            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_Voucherid_JV, Str_Fcurr, Amt_F, Exrate);
        }

        private static void Fn_OSDN_JVFAreverse(int int_vouno, DateTime Vdate, string trantype, int int_jobno, double Amount, int Cid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();

            int vouno_j = obj_da_invoice.GetAlreadyJVNo("D", int_vouno, int_bid, int_Vouyear);
            if (vouno_j == 0)
            {
                vouno_j = obj_da_invoice.GetJVNo(int_bid);
                obj_da_invoice.InsDCNJV("D", int_vouno, vouno_j, int_bid, int_Vouyear, int_divisionid);
            }
            int int_voutypeid_j = obj_da_FA.Selvoutypeid("OSDNCNJV", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + vouno_j + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
            int int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, vouno_j.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, int_vouno.ToString(), int_jobno, "");

            DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
            string str_Shortname = obj_da_Division.GetShortName(int_divisionid);
            int int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname + "-CO", 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname + "-CO", int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + int_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
            int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, int_vouno.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_Corid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            obj_da_FA.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);

            obj_da_FA.Updosvtype4VouHead(Str_DBname, int_voucherid, "D");

            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, vouno_j.ToString(), int_jobno, "");

            //KARTHIKA1
            DataAccess.Masters.MasterBranch obj_da_BranchKAR = new DataAccess.Masters.MasterBranch();
            str_Shortname = obj_da_BranchKAR.GetShortName(int_bid);

            int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname, 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

        }


        private static void Fn_OSCN_JVFAreverse(int int_vouno, DateTime Vdate, string trantype, int int_jobno, double Amount, int Cid)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(TallyEDIFA));
            log4net.Config.BasicConfigurator.Configure();

            DataAccess.FAVoucher obj_da_FA = new DataAccess.FAVoucher();
            DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
            DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();


            int vouno_j = obj_da_invoice.GetAlreadyJVNo("C", int_vouno, int_bid, int_Vouyear);
            if (vouno_j == 0)
            {
                vouno_j = obj_da_invoice.GetJVNo(int_bid);
                obj_da_invoice.InsDCNJV("C", int_vouno, vouno_j, int_bid, int_Vouyear, int_divisionid);
            }
            int int_voutypeid_j = obj_da_FA.Selvoutypeid("OSDNCNJV", Str_DBname);
            DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + vouno_j + "|Branchid-" + int_bid + "|EmployeeID-" + int_Empid + ")");
            int int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, vouno_j.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_bid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, int_vouno.ToString(), int_jobno, "");

            DataAccess.Masters.MasterDivision obj_da_Division = new DataAccess.Masters.MasterDivision();
            string str_Shortname = obj_da_Division.GetShortName(int_divisionid);
            int int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname + "-CO", 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname + "-CO", int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_bid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();

            int int_Corid = obj_da_Emp.GetBranchId(int_divisionid, "CORPORATE");
            log1.Info("Before Insertion of Record in VoucherHead - (Voutype-" + int_voutypeid_j + "|Vouno-" + int_vouno + "|Branchid-" + int_Corid + "|EmployeeID-" + int_Empid + ")");
            int_voucherid = obj_da_FA.InsFAVouHead(Str_DBname, int_voutypeid_j, int_vouno.ToString(), Vdate, Str_Narration, trantype, 1, int_jobno, int_Corid, int_divisionid, int_Empid, obj_da_Log.GetDate(), char.Parse(Str_deleted), int_Vouyear);
            log1.Info("Record has been Inserted in VoucherHead - (" + int_voucherid + ")");
            HttpContext.Current.Session["vouid"] = int_voucherid;
            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

            obj_da_FA.UpdPBid4VouHead(Str_DBname, int_voucherid, int_bid);

            obj_da_FA.Updosvtype4VouHead(Str_DBname, int_voucherid, "C");

            obj_da_FA.UpdateFAVouHeadDetails(Str_DBname, "REFNO", int_voucherid, vouno_j.ToString(), int_jobno, "");

            //KARTHIKA
            DataAccess.Masters.MasterBranch obj_da_BranchKAR = new DataAccess.Masters.MasterBranch();
            str_Shortname = obj_da_BranchKAR.GetShortName(int_bid);
            int_ledgerid = obj_da_FA.Selledgeridforops(Str_DBname, "OVC Account-" + str_Shortname, 'O');

            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally("OVC Account-" + str_Shortname, int_Subgroupid, int_Groupid, 'G', 0, 'O', Str_DBname);
            }
            log1.Info("Ledger-OVC Account-" + str_Shortname + " -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Cr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger-OVC Account-" + str_Shortname+" -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Cr - Inserted");

            int_ledgerid = obj_da_FA.Selledgerid(Str_DBname, Cid, 'C');
            if (int_ledgerid == 0)
            {
                int_ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Str_DBname);
            }
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Before Inserted");
            obj_da_FA.InsFAVouDetails(Str_DBname, int_voucherid, int_ledgerid, "Dr", Convert.ToDouble(Amount.ToString("#0.000")), int_Vouyear, int_Corid, int_divisionid);
            log1.Info("Ledger- -ID(" + int_ledgerid + ")-Rs.(" + Convert.ToDouble(Amount.ToString("#0.000")) + ") - Dr - Inserted");

            obj_da_FA.UpdFAVouDtls4OS(Str_DBname, int_voucherid, Str_Fcurr, Amt_F, Exrate);

        }

        public static void Fn_AutoMailVouchers(int vouno, string voutype, int branchid, int vouyear, string dbname, DateTime voudate)
        {
            try
            {
                DataAccess.checkvouchercount chkvoucher = new DataAccess.checkvouchercount();

                if (vouno != 0)
                {
                    string html = "";
                    string sub = "";
                    double gst = 0.00, totamt = 0.00, dbtot = 0.00, crtot = 0.00, tdsamt = 0.00, totamt1 = 0.00;
                    bool transfer = false;

                    DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();

                    if (voutype != "BOS")
                    {
                        //ds = objrv.Getapprovingvouchermail(2092, Session["vname"].ToString(), BranchID, Vou_Year, FADbName);
                        ds = objrv.Getapprovingvouchermail(vouno, voutype, branchid, vouyear, dbname);

                        dt = ds.Tables[0];
                        dt1 = ds.Tables[1];

                        
                        if (dt.Rows.Count > 0)
                        {                            
                            string vtype = dt.Rows[0]["voutype"].ToString();
                            string BranchName = "", shortname = "";

                            DataTable dtbranch = new DataTable();
                            dtbranch = objrv.GetPortNameforBranch(branchid);
                            shortname = dtbranch.Rows[0]["shortname"].ToString();
                            BranchName = dtbranch.Rows[0]["portname"].ToString();

                            if (dt1.Rows.Count == 0)
                            {                                
                                int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
                                Fn_FATransfer(vtype, vno, vno, "Remarks", "Ref No", branchid);
                                ds = objrv.Getapprovingvouchermail(vouno, voutype, branchid, vouyear, dbname);
                                dt1 = ds.Tables[1];                                
                            }

                            if (dt1.Rows.Count == 0)
                            {                               

                                string subj = "", mailcontent = "";
                                int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());

                                subj = "logix Error Vouchers : " + vtype + " – " + vno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                mailcontent = "Financial Entry Not Found After Re-Transfer : Voutype : " + vtype + " – Vou# From : " + vno + " – Vou# To : " + vno + " – " + "Remarks" + "Ref No" + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());

                              }
                            else
                            {
                                sub = "Vouchers : Proforma " + vtype + " – " + vouno + ", " + voudate + ", " + shortname + ", " + vouyear;

                                html += "<br><table border=1 colspan=3 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                html += "<th align=center colspan=3 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> " + " FORWARDING PRIVATE LIMITED, " + BranchName + "</b></th>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Type " + "</b></label>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["voutype"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher # " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["vouno"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Date " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["voucherdate"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " FY " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["vouyear"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Customer Name " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["customername"].ToString() + "</b></label></td>";
                                html += "</tr>";

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    double chrgamt = Convert.ToDouble(dt.Rows[i]["actamount"].ToString());
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Charge Name " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[i]["chargename"].ToString() + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + chrgamt.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }

                                //gst = (double)dt.Compute("SUM(gst)", "");

                                gst = Convert.ToDouble(dt.Compute("SUM(gst)", string.Empty));
                                if (gst != 0.00)
                                {

                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " GST " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + gst.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }

                                //totamt = (double)dt.Compute("SUM(amount)", "");
                                totamt = Convert.ToDouble(dt.Compute("SUM(amount)", string.Empty));
                                //DataRow[] dr1 = dt.Select("SUM(amount)");
                                //totamt = Convert.ToDouble(dr1[0]);

                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                tdsamt = Convert.ToDouble(dt.Rows[0]["tdsamount"].ToString());
                                if (tdsamt != 0.00)
                                {
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " TDS " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. -" + tdsamt.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";

                                    totamt1 = totamt - tdsamt;

                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "Grand Total " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt1.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }


                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Prepared By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["preparedby"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Approved By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["approvedby"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "</table>";

                                //html += " <br><br> <b><p style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>" +" Financial Entries "+" </p></b> <br>";
                                html += "<br><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> Financial Entries </b></td></tr></table><br>";

                                html += "<table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Type </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Ledgername </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Debit [Rs.] </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Credit [Rs.] </b></label></td>";
                                html += "</tr>";

                                for (int j = 0; j < dt1.Rows.Count; j++)
                                {
                                    double dbamt = Convert.ToDouble(dt1.Rows[j]["Debit"].ToString());
                                    double cramt = Convert.ToDouble(dt1.Rows[j]["Credit"].ToString());

                                    string debit = "", credit = "";

                                    if (dbamt != 0.00)
                                    {
                                        debit = dbamt.ToString("0.00");
                                    }
                                    if (cramt != 0.00)
                                    {
                                        credit = cramt.ToString("0.00");
                                    }


                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt1.Rows[j]["ledgertype"].ToString() + ".</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt1.Rows[j]["ledgername"].ToString() + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + debit + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + credit + "</b></label></td>";
                                    html += "</tr>";
                                }
                                dbtot = Convert.ToDouble(dt1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dt1.Compute("SUM(Credit)", string.Empty));
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + dbtot.ToString("0.00") + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + crtot.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                html += "</table><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>Thanks & Regards </b></td></tr><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>System Generated Statement</b></td></tr></table><br><br><br>";

                                if (dbtot != crtot)
                                {
                                    //transfer = true;

                                    // Retransfer For Debit - Credit Mismatch

                                    double dbtot1 = 0.00, crtot1 = 0.00;
                                    int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
                                    
                                    chkvoucher.DelMyUseCompareDrCrinFA(dbname);
                                    Fn_FATransfer(vtype, vno, vno, "Remarks", "Ref No", branchid);

                                    DataSet ds1 = objrv.Getapprovingvouchermail(vno, vtype, branchid, vouyear, dbname);
                                    DataTable dtretransfer = ds1.Tables[1];

                                    if (dtretransfer.Rows.Count > 0)
                                    {
                                        dbtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Debit)", string.Empty));
                                        crtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Credit)", string.Empty));
                                        
                                        if (dbtot1 != crtot1)
                                        {
                                            transfer = true;
                                        }
                                        else
                                        {
                                            transfer = false;
                                        }
                                    }                                    
                                }

                                if (transfer == true)
                                {
                                    string subj = "", mailcontent = "";
                                    int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());

                                    subj = "logixFA Error : " + vtype + " – " + vno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                    mailcontent = "Debit - Credit Mistmatch After ReTransfer : Voutype : " + vtype + " – Vou# From : " + vno + " – Vou# To : " + vno + " – " + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());

                                      }

                                                                            
                            }
                        }
                    }
                    else if (voutype == "BOS")
                    {                       

                        ds = objrv.Getapprovingvouchermail(vouno, voutype, branchid, vouyear, dbname);

                        dt = ds.Tables[0];
                        dt1 = ds.Tables[1];
                        dt2 = ds.Tables[2];
                        dt3 = ds.Tables[3];


                        if (dt.Rows.Count > 0)
                        {
                            string vtype = dt.Rows[0]["voutype"].ToString();
                            string BranchName = "", shortname = "";

                            // Setting db-cr amount=0
                            gst = 0.00; totamt = 0.00; dbtot = 0.00; crtot = 0.00; tdsamt = 0.00; totamt1 = 0.00;

                            DataTable dtbranch = new DataTable();
                            dtbranch = objrv.GetPortNameforBranch(branchid);
                            shortname = dtbranch.Rows[0]["shortname"].ToString();
                            BranchName = dtbranch.Rows[0]["portname"].ToString();


                            if (dt2.Rows.Count == 0)
                            {
                                int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
                                Fn_FATransfer(vtype, vno, vno, "Remarks", "Ref No", branchid);
                                ds = objrv.Getapprovingvouchermail(vouno, voutype, branchid, vouyear, dbname);
                                dt2 = ds.Tables[1];
                            }

                            if (dt2.Rows.Count == 0)
                            {
                                string subj = "", mailcontent = "";
                                int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());

                                subj = "logix Error Vouchers : " + vtype + " – " + vno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                mailcontent = "Financial Entry Not Found After Re-Transfer : Voutype : " + vtype + " – Vou# From : " + vno + " – Vou# To : " + vno + " – " + "Remarks" + "Ref No" + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                                                                
                               
                            }
                            else
                            {

                                sub = "Vouchers : Proforma for " + "Invoices & BOS " + " – " + vouno + ", " + voudate + ", " + shortname + ", " + vouyear;

                                html += "<br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> INVOICES </b></td></tr></table><br>";

                                html += "<br><table border=1 colspan=3 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                html += "<th align=center colspan=3 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> " + " FORWARDING PRIVATE LIMITED, " + BranchName + "</b></th>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Type " + "</b></label>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["voutype"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher # " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["vouno"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Date " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["voucherdate"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " FY " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["vouyear"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Customer Name " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["customername"].ToString() + "</b></label></td>";
                                html += "</tr>";

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    double chrgamt = Convert.ToDouble(dt.Rows[i]["actamount"].ToString());
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Charge Name " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[i]["chargename"].ToString() + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + chrgamt.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }
                                                                
                                gst = Convert.ToDouble(dt.Compute("SUM(gst)", string.Empty));
                                if (gst != 0.00)
                                {

                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " GST " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + gst.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }
                                
                                totamt = Convert.ToDouble(dt.Compute("SUM(amount)", string.Empty));
                                
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                tdsamt = Convert.ToDouble(dt.Rows[0]["tdsamount"].ToString());
                                if (tdsamt != 0.00)
                                {
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " TDS " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. -" + tdsamt.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";

                                    totamt1 = totamt - tdsamt;

                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "Grand Total " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt1.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }


                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Prepared By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["preparedby"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Approved By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[0]["approvedby"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "</table>";
                                                                
                                html += "<br><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> Financial Entries </b></td></tr></table><br>";

                                html += "<table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Type </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Ledgername </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Debit [Rs.] </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Credit [Rs.] </b></label></td>";
                                html += "</tr>";

                                for (int j = 0; j < dt2.Rows.Count; j++)
                                {
                                    double dbamt = Convert.ToDouble(dt2.Rows[j]["Debit"].ToString());
                                    double cramt = Convert.ToDouble(dt2.Rows[j]["Credit"].ToString());

                                    string debit = "", credit = "";

                                    if (dbamt != 0.00)
                                    {
                                        debit = dbamt.ToString("0.00");
                                    }
                                    if (cramt != 0.00)
                                    {
                                        credit = cramt.ToString("0.00");
                                    }


                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt2.Rows[j]["ledgertype"].ToString() + ".</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt2.Rows[j]["ledgername"].ToString() + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + debit + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + credit + "</b></label></td>";
                                    html += "</tr>";
                                }
                                dbtot = Convert.ToDouble(dt2.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dt2.Compute("SUM(Credit)", string.Empty));
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + dbtot.ToString("0.00") + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + crtot.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                html += "</table><br>";
                                //html += "</table><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>Thanks & Regards </b></td></tr><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>System Generated Statement</b></td></tr></table><br><br><br>";

                                if (dbtot != crtot)
                                {
                                    //transfer = true;

                                    // Retransfer For Debit - Credit Mismatch

                                    double dbtot1 = 0.00, crtot1 = 0.00;
                                    int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());

                                    chkvoucher.DelMyUseCompareDrCrinFA(dbname);
                                    Fn_FATransfer(vtype, vno, vno, "Remarks", "Ref No", branchid);

                                    DataSet ds1 = objrv.Getapprovingvouchermail(vno, vtype, branchid, vouyear, dbname);
                                    DataTable dtretransfer = ds1.Tables[2];

                                    if (dtretransfer.Rows.Count > 0)
                                    {
                                        dbtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Debit)", string.Empty));
                                        crtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Credit)", string.Empty));

                                        if (dbtot1 != crtot1)
                                        {
                                            transfer = true;
                                        }
                                        else
                                        {
                                            transfer = false;
                                        }
                                    }        
                                }

                                if (transfer == true)
                                {
                                    string subj = "", mailcontent = "";
                                    int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());

                                    subj = "logixFA Error : " + vtype + " – " + vno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                    mailcontent = "Debit - Credit Mistmatch After ReTransfer : Voutype : " + vtype + " – Vou# From : " + vno + " – Vou# To : " + vno + " – " + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                                                                        
                                 }

                             }
                        }
                        
                        if (dt1.Rows.Count > 0)
                        {
                            string vtype = dt1.Rows[0]["voutype"].ToString();
                            string BranchName = "", shortname = "";

                            // Setting db-cr amount=0
                            gst = 0.00; totamt = 0.00; dbtot = 0.00; crtot = 0.00; tdsamt = 0.00; totamt1 = 0.00;

                            DataTable dtbranch = new DataTable();
                            dtbranch = objrv.GetPortNameforBranch(branchid);
                            shortname = dtbranch.Rows[0]["shortname"].ToString();
                            BranchName = dtbranch.Rows[0]["portname"].ToString();


                            if (dt3.Rows.Count == 0)
                            {
                                int vno = Convert.ToInt32(dt1.Rows[0]["vouno"].ToString());
                                Fn_FATransfer(vtype, vno, vno, "Remarks", "Ref No", branchid);
                                ds = objrv.Getapprovingvouchermail(vno, vtype, branchid, vouyear, dbname);
                                dt3 = ds.Tables[3];
                            }

                            if (dt3.Rows.Count == 0)
                            {
                                string subj = "", mailcontent = "";
                                int vno = Convert.ToInt32(dt1.Rows[0]["vouno"].ToString());

                                subj = "logix Error Vouchers : " + vtype + " – " + vno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                mailcontent = "Financial Entry Not Found After Re-Transfer : Voutype : " + vtype + " – Vou# From : " + vno + " – Vou# To : " + vno + " – " + "Remarks" + "Ref No" + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                                                                
                             }
                            else
                            {

                                //sub = "Vouchers : Proforma " + vtype + " – " + vouno + ", " + voudate + ", " + shortname + ", " + vouyear;

                                html += "<br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> BILL OF SUPPLY </b></td></tr></table><br>";

                                html += "<br><table border=1 colspan=3 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                html += "<th align=center colspan=3 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> " + " FORWARDING PRIVATE LIMITED, " + BranchName + "</b></th>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Type " + "</b></label>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[0]["voutype"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher # " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[0]["vouno"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Date " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[0]["voucherdate"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " FY " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[0]["vouyear"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Customer Name " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[0]["customername"].ToString() + "</b></label></td>";
                                html += "</tr>";

                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    double chrgamt = Convert.ToDouble(dt1.Rows[i]["actamount"].ToString());
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Charge Name " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[i]["chargename"].ToString() + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + chrgamt.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }

                                //gst = (double)dt.Compute("SUM(gst)", "");

                                gst = Convert.ToDouble(dt1.Compute("SUM(gst)", string.Empty));
                                if (gst != 0.00)
                                {

                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " GST " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + gst.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }
                                                                
                                totamt = Convert.ToDouble(dt1.Compute("SUM(amount)", string.Empty));
                                
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                tdsamt = Convert.ToDouble(dt1.Rows[0]["tdsamount"].ToString());
                                if (tdsamt != 0.00)
                                {
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " TDS " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. -" + tdsamt.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";

                                    totamt1 = totamt - tdsamt;

                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "Grand Total " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt1.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";
                                }


                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Prepared By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[0]["preparedby"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Approved By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[0]["approvedby"].ToString() + "</b></label></td>";
                                html += "</tr>";
                                html += "</table>";
                                
                                html += "<br><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> Financial Entries </b></td></tr></table><br>";

                                html += "<table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Type </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Ledgername </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Debit [Rs.] </b></label></td>";
                                html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Credit [Rs.] </b></label></td>";
                                html += "</tr>";

                                for (int j = 0; j < dt3.Rows.Count; j++)
                                {
                                    double dbamt = Convert.ToDouble(dt3.Rows[j]["Debit"].ToString());
                                    double cramt = Convert.ToDouble(dt3.Rows[j]["Credit"].ToString());

                                    string debit = "", credit = "";

                                    if (dbamt != 0.00)
                                    {
                                        debit = dbamt.ToString("0.00");
                                    }
                                    if (cramt != 0.00)
                                    {
                                        credit = cramt.ToString("0.00");
                                    }


                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt3.Rows[j]["ledgertype"].ToString() + ".</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt3.Rows[j]["ledgername"].ToString() + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + debit + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + credit + "</b></label></td>";
                                    html += "</tr>";
                                }
                                dbtot = Convert.ToDouble(dt3.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dt3.Compute("SUM(Credit)", string.Empty));
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + dbtot.ToString("0.00") + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + crtot.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                html += "</table><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>Thanks & Regards </b></td></tr><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>System Generated Statement</b></td></tr></table><br><br><br>";

                                if (dbtot != crtot)
                                {
                                    //transfer = true;

                                    // Retransfer For Debit - Credit Mismatch

                                    double dbtot1 = 0.00, crtot1 = 0.00;
                                    int vno = Convert.ToInt32(dt1.Rows[0]["vouno"].ToString());

                                    chkvoucher.DelMyUseCompareDrCrinFA(dbname);
                                    Fn_FATransfer(vtype, vno, vno, "Remarks", "Ref No", branchid);

                                    DataSet ds1 = objrv.Getapprovingvouchermail(vno, vtype, branchid, vouyear, dbname);
                                    DataTable dtretransfer = ds1.Tables[3];

                                    if (dtretransfer.Rows.Count > 0)
                                    {
                                        dbtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Debit)", string.Empty));
                                        crtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Credit)", string.Empty));

                                        if (dbtot1 != crtot1)
                                        {
                                            transfer = true;
                                        }
                                        else
                                        {
                                            transfer = false;
                                        }
                                    }      
                                }

                                if (transfer == true)
                                {
                                    string subj = "", mailcontent = "";
                                    int vno = Convert.ToInt32(dt1.Rows[0]["vouno"].ToString());

                                    subj = "logixFA Error : " + vtype + " – " + vno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                    mailcontent = "Debit - Credit Mistmatch After ReTransfer : Voutype : " + vtype + " – Vou# From : " + vno + " – Vou# To : " + vno + " – " + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                                                                        
                                 }

                       
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alter('" + ex.Message.ToString() + "')", true);
            }

        }

        public static void Fn_AutoMailVouchersRP(int vouno, string voutype, int branchid, int vouyear, string dbname, DateTime voudate)
        {
            try
            {
                DataAccess.checkvouchercount chkvoucher = new DataAccess.checkvouchercount();

                if (vouno != 0)
                {
                    string html = "";
                    string sub = "";
                    double dbtot = 0.00, crtot = 0.00, totamt = 0.00, rpamt = 0.00;
                    double jdbtot = 0.00, jcrtot = 0.00, camt = 0.00, chamt = 0.00;
                    bool transfer = false;
                    bool journal = false;
                    bool jtransfer = false;                    


                    DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();

                    //ds = objrv.Getapprovingvouchermail(2092, Session["vname"].ToString(), BranchID, Vou_Year, FADbName);
                    ds = objrv.GetRecPymtVoucherMail(vouno, voutype, branchid, vouyear, dbname);

                    dt = ds.Tables[0];
                    dt1 = ds.Tables[1];
                    dt2 = ds.Tables[2];

                    if (ds.Tables.Count > 3)
                    {
                        dt3 = ds.Tables[3];
                    }

                    if (ds.Tables.Count > 0)
                    {
                        if (voutype == "CR" || voutype == "BR" || voutype == "RR")
                        {
                            string vtype = "", vdate = "", rcustomer = "", approvedby = "", preparedby = "";
                            int voucherno = 0, vyear = 0;

                            //DateTime vdate;

                            if (dt.Rows.Count > 0)
                            {
                                vtype = dt.Rows[0]["voutype"].ToString();
                                voucherno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
                                vdate = dt.Rows[0]["voucherdate"].ToString();
                                vyear = Convert.ToInt32(dt.Rows[0]["vouyear"].ToString());
                                rcustomer = dt.Rows[0]["ReceiptCustomer"].ToString();

                                preparedby = dt.Rows[0]["preparedby"].ToString();
                                approvedby = dt.Rows[0]["approvedby"].ToString();

                                rpamt = Convert.ToDouble(dt.Rows[0]["Receiptamount"].ToString());

                                if (dt.Rows[0]["ReceiptBranch"].ToString() != dt.Rows[0]["VoucherBranch"].ToString())
                                {
                                    journal = true;
                                }

                            }
                            else if (dt1.Rows.Count > 0)
                            {
                                vtype = dt1.Rows[0]["voutype"].ToString();
                                voucherno = Convert.ToInt32(dt1.Rows[0]["vouno"].ToString());
                                vdate = dt1.Rows[0]["voucherdate"].ToString();
                                vyear = Convert.ToInt32(dt1.Rows[0]["vouyear"].ToString());
                                rcustomer = dt1.Rows[0]["ReceiptCustomer"].ToString();

                                preparedby = dt1.Rows[0]["preparedby"].ToString();
                                approvedby = dt1.Rows[0]["approvedby"].ToString();

                                rpamt = Convert.ToDouble(dt1.Rows[0]["Receiptamount"].ToString());

                            }

                            if (dt2.Rows.Count == 0)
                            {
                                Fn_FATransfer(vtype, voucherno, voucherno, "", "", branchid);
                                ds = objrv.GetRecPymtVoucherMail(voucherno, vtype, branchid, vouyear, dbname);
                                dt2 = ds.Tables[2];
                            }

                            if (dt2.Rows.Count == 0)
                            {
                                string subj = "", mailcontent = "";

                                subj = "logix Error Vouchers : " + vtype + " – " + voucherno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                mailcontent = "Financial Entry Not Found After Re-Transfer : Voutype : " + vtype + " – Vou# From : " + voucherno + " – Vou# To : " + voucherno + " – " + "Remarks" + "Ref No" + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());

                             }
                            else
                            {

                                string BranchName = "", shortname = "";

                                DataTable dtbranch = new DataTable();
                                dtbranch = objrv.GetPortNameforBranch(branchid);
                                shortname = dtbranch.Rows[0]["shortname"].ToString();
                                BranchName = dtbranch.Rows[0]["portname"].ToString();

                                sub = "Vouchers : " + vtype + " – " + vouno + ", " + voudate + ", " + shortname + ", " + vouyear;

                                html += "<br><table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";
                                html += "<th align=center colspan=3 > FORWARDING PRIVATE LIMITED, " + BranchName + "</th>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Type " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + vtype + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher # " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + voucherno + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Date " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + vdate + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " FY " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + vyear + "</b></label></td>";
                                html += "</tr>";

                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Received From " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + rcustomer + "</b></label></td>";
                                html += "</tr>";

                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        double custamount = Convert.ToDouble(dt.Rows[i]["custamount"].ToString());

                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Customer Name " + "</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[i]["customer"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b>" + custamount.ToString("0.00") + "</b></label></td>";
                                        html += "</tr>";

                                        camt = camt + custamount;
                                    }
                                }

                                if (dt1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt1.Rows.Count; i++)
                                    {
                                        double chargeamount = Convert.ToDouble(dt1.Rows[i]["chargeamount"].ToString());

                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Charge Name " + "</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[i]["charges"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b>" + chargeamount.ToString("0.00") + "</b></label></td>";
                                        html += "</tr>";

                                        chamt = chamt + chargeamount;
                                    }
                                }

                                string strcamt = camt.ToString("0.00");
                                camt = Convert.ToDouble(strcamt);
                                string strchamt = chamt.ToString("0.00");
                                chamt = Convert.ToDouble(strchamt);

                                totamt = camt + chamt;

                                string strtotamt = totamt.ToString("0.00");
                                totamt = Convert.ToDouble(strtotamt);


                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Prepared By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + preparedby + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Approved By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + approvedby + "</b></label></td>";
                                html += "</tr>";
                                html += "</table>";

                                html += "<br><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> Financial Entries </b></td></tr></table><br>";

                                html += "<table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                if (dt2.Rows.Count > 0)
                                {
                                    //add header row
                                    html += "<tr>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Type </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Ledgername </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Debit [Rs.] </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Credit [Rs.] </b></label></td>";
                                    html += "</tr>";

                                    for (int j = 0; j < dt2.Rows.Count; j++)
                                    {
                                        double dbamt = Convert.ToDouble(dt2.Rows[j]["Debit"].ToString());
                                        double cramt = Convert.ToDouble(dt2.Rows[j]["Credit"].ToString());

                                        string debit = "", credit = "";

                                        if (dbamt != 0.00)
                                        {
                                            debit = dbamt.ToString("0.00");
                                        }
                                        if (cramt != 0.00)
                                        {
                                            credit = cramt.ToString("0.00");
                                        }


                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt2.Rows[j]["ledgertype"].ToString() + ".</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt2.Rows[j]["ledgername"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + debit + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + credit + "</b></label></td>";
                                        html += "</tr>";
                                    }
                                    dbtot = Convert.ToDouble(dt2.Compute("SUM(Debit)", string.Empty));
                                    crtot = Convert.ToDouble(dt2.Compute("SUM(Credit)", string.Empty));
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + dbtot.ToString("0.00") + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + crtot.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";

                                    html += "</table>";
                                }

                                if (dt3.Rows.Count > 0)
                                {
                                    html += "<br><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> Journal Entries </b></td></tr></table><br>";
                                    html += "<table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                    //add header row
                                    html += "<tr>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Type </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Ledgername </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Debit [Rs.] </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Credit [Rs.] </b></label></td>";
                                    html += "</tr>";

                                    for (int j = 0; j < dt3.Rows.Count; j++)
                                    {
                                        double jdbamt = Convert.ToDouble(dt3.Rows[j]["Debit"].ToString());
                                        double jcramt = Convert.ToDouble(dt3.Rows[j]["Credit"].ToString());

                                        string jdebit = "", jcredit = "";

                                        if (jdbamt != 0.00)
                                        {
                                            jdebit = jdbamt.ToString("0.00");
                                        }
                                        if (jcramt != 0.00)
                                        {
                                            jcredit = jcramt.ToString("0.00");
                                        }


                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt3.Rows[j]["ledgertype"].ToString() + ".</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt3.Rows[j]["ledgername"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jdebit + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jcredit + "</b></label></td>";
                                        html += "</tr>";
                                    }
                                    jdbtot = Convert.ToDouble(dt3.Compute("SUM(Debit)", string.Empty));
                                    jcrtot = Convert.ToDouble(dt3.Compute("SUM(Credit)", string.Empty));
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jdbtot.ToString("0.00") + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jcrtot.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";

                                    html += "</table>";
                                }

                                html += "<br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>Thanks & Regards </b></td></tr><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>System Generated Statement</b></td></tr></table><br><br><br>";

                                if (rpamt != totamt || dbtot != crtot)
                                {                                    
                                    //transfer = true;

                                    // Retransfer For Debit - Credit Mismatch

                                    double dbtot1 = 0.00, crtot1 = 0.00;
                                    int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());

                                    chkvoucher.DelMyUseCompareDrCrinFA(dbname);

                                    Fn_FATransfer(vtype, voucherno, voucherno, "", "", branchid);
                                    DataSet ds1 = objrv.GetRecPymtVoucherMail(voucherno, vtype, branchid, vouyear, dbname);
                                    DataTable dtretransfer = ds1.Tables[2];


                                    if (dtretransfer.Rows.Count > 0)
                                    {
                                        dbtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Debit)", string.Empty));
                                        crtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Credit)", string.Empty));

                                        if (dbtot1 != crtot1)
                                        {
                                            transfer = true;
                                        }
                                        else
                                        {
                                            transfer = false;
                                        }
                                    }  

                                }
                                if ((jdbtot == 0.00 && jcrtot == 0.00 || jdbtot != jcrtot) && journal == true )
                                {
                                    jtransfer = true;
                                }

                             }

                        }
                        else if (voutype == "CP" || voutype == "BP" || voutype == "RP")
                        {
                            string vtype = "", vdate = "", pcustomer = "", approvedby = "", preparedby = "";
                            int voucherno = 0, vyear = 0;

                            if (dt.Rows.Count > 0)
                            {
                                vtype = dt.Rows[0]["voutype"].ToString();
                                voucherno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());
                                vdate = dt.Rows[0]["voucherdate"].ToString();
                                vyear = Convert.ToInt32(dt.Rows[0]["vouyear"].ToString());
                                pcustomer = dt.Rows[0]["PaymentCustomer"].ToString();

                                preparedby = dt.Rows[0]["preparedby"].ToString();
                                approvedby = dt.Rows[0]["approvedby"].ToString();

                                rpamt = Convert.ToDouble(dt.Rows[0]["Paymentamount"].ToString());

                                if (dt.Rows[0]["PaymentBranch"].ToString() != dt.Rows[0]["VoucherBranch"].ToString())
                                {
                                    journal = true;
                                }
                            }
                            else if (dt1.Rows.Count > 0)
                            {
                                vtype = dt1.Rows[0]["voutype"].ToString();
                                voucherno = Convert.ToInt32(dt1.Rows[0]["vouno"].ToString());
                                vdate = dt1.Rows[0]["voucherdate"].ToString();
                                vyear = Convert.ToInt32(dt1.Rows[0]["vouyear"].ToString());
                                pcustomer = dt1.Rows[0]["PaymentCustomer"].ToString();

                                preparedby = dt1.Rows[0]["preparedby"].ToString();
                                approvedby = dt1.Rows[0]["approvedby"].ToString();

                                rpamt = Convert.ToDouble(dt1.Rows[0]["Paymentamount"].ToString());

                            }

                            if (dt2.Rows.Count == 0)
                            {
                                Fn_FATransfer(vtype, voucherno, voucherno, "", "", branchid);
                                ds = objrv.GetRecPymtVoucherMail(voucherno, vtype, branchid, vouyear, dbname);
                                dt2 = ds.Tables[2];
                            }

                            if (dt2.Rows.Count == 0)
                            {
                                string subj = "", mailcontent = "";

                                subj = "logix Error Vouchers : " + vtype + " – " + voucherno + ", " + voudate + ", " + branchid + ", " + vouyear;
                                mailcontent = "Financial Entry Not Found After Re-Transfer : Voutype : " + vtype + " – Vou# From : " + voucherno + " – Vou# To : " + voucherno + " – " + "Remarks" + "Ref No" + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());

                             }
                            else
                            {

                                string BranchName = "", shortname = "";

                                DataTable dtbranch = new DataTable();
                                dtbranch = objrv.GetPortNameforBranch(branchid);
                                shortname = dtbranch.Rows[0]["shortname"].ToString();
                                BranchName = dtbranch.Rows[0]["portname"].ToString();

                                sub = "Vouchers : " + vtype + " – " + vouno + ", " + voudate + ", " + shortname + ", " + vouyear;

                                html += "<br><table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";
                                html += "<th align=center colspan=3 > FORWARDING PRIVATE LIMITED, " + BranchName + "</th>";

                                //add header row
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Type " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + vtype + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher # " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + voucherno + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Voucher Date " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + vdate + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " FY " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + vyear + "</b></label></td>";
                                html += "</tr>";

                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Payment To " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + pcustomer + "</b></label></td>";
                                html += "</tr>";

                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        double custamount = Convert.ToDouble(dt.Rows[i]["custamount"].ToString());

                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Customer Name " + "</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt.Rows[i]["customer"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b>" + custamount.ToString("0.00") + "</b></label></td>";
                                        html += "</tr>";

                                        camt = camt + custamount;
                                    }
                                }

                                if (dt1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt1.Rows.Count; i++)
                                    {
                                        double chargeamount = Convert.ToDouble(dt1.Rows[i]["chargeamount"].ToString());

                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Charge Name " + "</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + dt1.Rows[i]["charges"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b>" + chargeamount.ToString("0.00") + "</b></label></td>";
                                        html += "</tr>";

                                        chamt = chamt + chargeamount;
                                    }
                                }

                                string strcamt = camt.ToString("0.00");
                                camt = Convert.ToDouble(strcamt);
                                string strchamt = chamt.ToString("0.00");
                                chamt = Convert.ToDouble(strchamt);

                                totamt = camt + chamt;

                                string strtotamt = totamt.ToString("0.00");
                                totamt = Convert.ToDouble(strtotamt);


                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                html += "<td align=right style='color:#2c2b2b;'><label style='display:inline-block; float:right;'><b> Rs. " + totamt.ToString("0.00") + "</b></label></td>";
                                html += "</tr>";

                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Prepared By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + preparedby + "</b></label></td>";
                                html += "</tr>";
                                html += "<tr>";
                                html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Approved By " + "</b></label></td>";
                                html += "<td align=left colspan=2 style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + approvedby + "</b></label></td>";
                                html += "</tr>";
                                html += "</table>";

                                html += "<br><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> Financial Entries </b></td></tr></table><br>";

                                html += "<table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                if (dt2.Rows.Count > 0)
                                {
                                    //add header row
                                    html += "<tr>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Type </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Ledgername </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Debit [Rs.] </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Credit [Rs.] </b></label></td>";
                                    html += "</tr>";

                                    for (int j = 0; j < dt2.Rows.Count; j++)
                                    {
                                        double dbamt = Convert.ToDouble(dt2.Rows[j]["Debit"].ToString());
                                        double cramt = Convert.ToDouble(dt2.Rows[j]["Credit"].ToString());

                                        string debit = "", credit = "";

                                        if (dbamt != 0.00)
                                        {
                                            debit = dbamt.ToString("0.00");
                                        }
                                        if (cramt != 0.00)
                                        {
                                            credit = cramt.ToString("0.00");
                                        }


                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt2.Rows[j]["ledgertype"].ToString() + ".</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt2.Rows[j]["ledgername"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + debit + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + credit + "</b></label></td>";
                                        html += "</tr>";
                                    }
                                    dbtot = Convert.ToDouble(dt2.Compute("SUM(Debit)", string.Empty));
                                    crtot = Convert.ToDouble(dt2.Compute("SUM(Credit)", string.Empty));
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + dbtot.ToString("0.00") + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + crtot.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";

                                    html += "</table>";
                                }

                                if (dt3.Rows.Count > 0)
                                {
                                    html += "<br><br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b> Journal Entries </b></td></tr></table><br>";
                                    html += "<table border=1 style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'>";

                                    //add header row
                                    html += "<tr>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Type </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Ledgername </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Debit [Rs.] </b></label></td>";
                                    html += "<td align=center style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:center;width=100%;'><b> Credit [Rs.] </b></label></td>";
                                    html += "</tr>";

                                    for (int j = 0; j < dt3.Rows.Count; j++)
                                    {
                                        double jdbamt = Convert.ToDouble(dt3.Rows[j]["Debit"].ToString());
                                        double jcramt = Convert.ToDouble(dt3.Rows[j]["Credit"].ToString());

                                        string jdebit = "", jcredit = "";

                                        if (jdbamt != 0.00)
                                        {
                                            jdebit = jdbamt.ToString("0.00");
                                        }
                                        if (jcramt != 0.00)
                                        {
                                            jcredit = jcramt.ToString("0.00");
                                        }


                                        html += "<tr>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt3.Rows[j]["ledgertype"].ToString() + ".</b></label></td>";
                                        html += "<td align=left style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:left;width=100%;'><b>" + dt3.Rows[j]["ledgername"].ToString() + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jdebit + "</b></label></td>";
                                        html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jcredit + "</b></label></td>";
                                        html += "</tr>";
                                    }
                                    jdbtot = Convert.ToDouble(dt3.Compute("SUM(Debit)", string.Empty));
                                    jcrtot = Convert.ToDouble(dt3.Compute("SUM(Credit)", string.Empty));
                                    html += "<tr>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + "  " + "</b></label></td>";
                                    html += "<td align=left style='color:#2c2b2b;'><label style='display:inline-block; float:left;'><b>" + " Total " + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jdbtot.ToString("0.00") + "</b></label></td>";
                                    html += "<td align=right style='color:#2c2b2b; width=100%;'><label style='display:inline-block; float:right;width=100%;'><b>" + jcrtot.ToString("0.00") + "</b></label></td>";
                                    html += "</tr>";

                                    html += "</table>";
                                }

                                html += "<br><table width=100% text=black><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>Thanks & Regards </b></td></tr><tr><td align=left style='width:100%; font-family:sans-serif; font-weight:normal; font-size:13px;'><b>System Generated Statement</b></td></tr></table><br><br><br>";

                                if (rpamt != totamt || dbtot != crtot)
                                {
                                    //transfer = true;

                                    // Retransfer For Debit - Credit Mismatch

                                    double dbtot1 = 0.00, crtot1 = 0.00;
                                    int vno = Convert.ToInt32(dt.Rows[0]["vouno"].ToString());

                                    chkvoucher.DelMyUseCompareDrCrinFA(dbname);

                                    Fn_FATransfer(vtype, voucherno, voucherno, "", "", branchid);
                                    DataSet ds1 = objrv.GetRecPymtVoucherMail(voucherno, vtype, branchid, vouyear, dbname);
                                    DataTable dtretransfer = ds1.Tables[2];


                                    if (dtretransfer.Rows.Count > 0)
                                    {
                                        dbtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Debit)", string.Empty));
                                        crtot1 = Convert.ToDouble(dtretransfer.Compute("SUM(Credit)", string.Empty));

                                        if (dbtot1 != crtot1)
                                        {
                                            transfer = true;
                                        }
                                        else
                                        {
                                            transfer = false;
                                        }
                                    }  
                                }
                                if ((jdbtot == 0.00 || jcrtot == 0.00 || jdbtot != jcrtot) && journal == true)
                                {
                                    jtransfer = true;
                                }

                             }

                        }

 
                        if (transfer == true)
                        {
                            string subj = "", mailcontent = "";

                            subj = "logixFA Error : " + voutype + " – " + vouno + ", " + voudate + ", " + branchid + ", " + vouyear;
                            mailcontent = "Debit - Credit Mistmatch After ReTransfer : Voutype : " + voutype + " – Vou# From : " + vouno + " – Vou# To : " + vouno + " – " + " Branch : " + branchid + " Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                                                        
                         }

                        if (jtransfer == true)
                        {
                            string subj = "", mailcontent = "";
                            subj = "logix Error Journal Vouchers";
                            mailcontent = "Vouchers : " + voutype + " – Vou# : " + vouno + ", Voudate : " + voudate + ", Branch : " + branchid + ", Vouyear : " + vouyear + ", Session Branch : " + Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());

                         }

                    }
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alter('" + ex.Message.ToString() + "')", true);

                string sub = "", mailcontent = "";

                sub = "logix Error Vouchers : " + voutype + " – " + vouno + ", " + voudate + ", " + branchid + ", " + vouyear;
                mailcontent = "Error : " + ex;

             }

        }



    }
}