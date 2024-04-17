using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace logix.AutoCompleteClass
{
    public partial class AutoCompleteClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region LEDGER VIEW
        [WebMethod]
        public static List<string> GetLikeLedgerName(string prefix)
        {
            List<string> LedgerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.FAMaster.MasterLedger da_obj_Ledger = new DataAccess.FAMaster.MasterLedger();
            obj_dt = da_obj_Ledger.GetLikeLedgername(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            HttpContext.Current.Session["LV_Ledger"] = obj_dt;
            LedgerName = Utility.Fn_TableToList(obj_dt, "LNandPort", "Ledgerid","opsid");
            return LedgerName;
        }
        #endregion


        #region QUERY
        [WebMethod]
        public static List<string> GetLikePRCchqno(string prefix)
        {
            List<string> chequeNO = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Recipts da_obj_rec = new DataAccess.Accounts.Recipts();
            obj_dt = da_obj_rec.GetRecptPymtContraLikeChqno(Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), prefix.ToUpper(), 'O', HttpContext.Current.Session["FADbname"].ToString());
            HttpContext.Current.Session["Qry_Chq"] = obj_dt;
            chequeNO = Utility.Fn_DatatableToList_string(obj_dt, "chequeno", "chequeno");
            return chequeNO;
        }

        #endregion

        #region Contra
        [WebMethod]
        public static List<string> Getledgername4Contra(string prefix)
        {
            DataAccess.FAMaster.MasterLedger obj_ledger = new DataAccess.FAMaster.MasterLedger();
            DataTable obj_Dt = new DataTable();
            List<string> Ledgername = new List<string>();
            obj_Dt = obj_ledger.GetLikeLedgernameforcontra(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"]), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"]), HttpContext.Current.Session["FADbname"].ToString());
           // obj_Dt = obj_ledger.GetLikeLedgername(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            Ledgername = Utility.Fn_DatatableToList_int32(obj_Dt, "ledgername", "ledgerid");
            return Ledgername;
        }
        #endregion

        [WebMethod]
        public static List<string> GetLikeCustomerName(string prefix)
        {
            string[] Str_Value = prefix.Split(',');
            List<string> CustomerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            DateTime Dt_from,Dt_to;
            Dt_from=DateTime.Parse(Utility.fn_ConvertDate(Str_Value[4]));
            Dt_to=DateTime.Parse(Utility.fn_ConvertDate(Str_Value[5]));
            int int_bid=int.Parse(Str_Value[3]);
            char CustType=char.Parse(Str_Value[2]);

            if (Str_Value[1] == "R")
            {
                obj_dt = da_obj_Customer.Getlikecustomer4rec(Dt_from, Dt_to, CustType, Str_Value[0], int_bid);
            }
            else
            {
                obj_dt = da_obj_Customer.Getlikecustomer4pay(Dt_from, Dt_to, CustType, Str_Value[0], int_bid);
            }
            CustomerName = Utility.Fn_TableToList(obj_dt, "customer","customerid");
            return CustomerName;
        }

        [WebMethod]
        public static List<string> GetLikeSalesPersonName(string prefix)
        {
            string[] Str_Value = prefix.Split(',');
            List<string> CustomerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            DateTime Dt_from, Dt_to;
            Dt_from = DateTime.Parse(Utility.fn_ConvertDate(Str_Value[4]));
            Dt_to = DateTime.Parse(Utility.fn_ConvertDate(Str_Value[5]));
            int int_bid = int.Parse(Str_Value[3]);
            char CustType = char.Parse(Str_Value[2]);
            obj_dt = da_obj_Customer.Getlikesalesperson(Dt_from, Dt_to, CustType, Str_Value[0], int_bid);
            CustomerName = Utility.Fn_TableToList(obj_dt, "salesperson", "salesid");
            return CustomerName;
        }

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeIndianCustomer(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return List_Result;
        }
        
        [WebMethod]
        public static List<string> GetPort(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
            obj_dt = da_obj_Port.GetLikePort(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "portname", "portid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetLedgerName(string prefix)
        {
            List<string> LedgerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.FAMaster.MasterLedger da_obj_Ledger = new DataAccess.FAMaster.MasterLedger();
            obj_dt = da_obj_Ledger.GetLikeLedgername(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            LedgerName = Utility.Fn_TableToList(obj_dt, "LNandPort", "Ledgerid","opstype");
            return LedgerName;
        }


        [WebMethod]
        public static List<string> GetLedgerNamenew(string prefix)
        {
            List<string> LedgerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.FAMaster.MasterLedger da_obj_Ledger = new DataAccess.FAMaster.MasterLedger();
            obj_dt = da_obj_Ledger.GetLikeLedgernamenew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            LedgerName = Utility.Fn_TableToListnew(obj_dt, "LNandPort", "Ledgerid", "opstype", "blocked");
            return LedgerName;
        }


        [WebMethod]
        public static List<string> GetLedgerName_adjustment(string prefix)
        {
            List<string> LedgerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Journal da_obj_Ledger = new DataAccess.Accounts.Journal();
            obj_dt = da_obj_Ledger.GetLikeLedgernameforADCN(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            LedgerName = Utility.Fn_TableToList(obj_dt, "LNandPort", "Ledgerid", "opstype");
            return LedgerName;
        }

        [WebMethod]
        public static List<string> GetLedgerName_Journal(string prefix)
        {
            List<string> LedgerName = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Journal da_obj_Journal = new DataAccess.Accounts.Journal();
            obj_dt = da_obj_Journal.GetLikeLedgernameforjournal(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), HttpContext.Current.Session["FADbname"].ToString());
            LedgerName = Utility.Fn_TableToList(obj_dt, "ledgername", "ledgerid");
            return LedgerName;
        }

        [WebMethod]
        public static List<string> GetCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterExRate da_obj_Exrate = new DataAccess.Masters.MasterExRate();
            obj_dt = da_obj_Exrate.GetLikeCurrency(prefix.ToUpper());
            List_Result = Utility.Fn_DttableToList(obj_dt, "currency");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetVessel(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterVessel da_obj_Vessel = new DataAccess.Masters.MasterVessel();
            obj_dt = da_obj_Vessel.GetLikeVessel(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "vesselname", "vesselid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetConsignee(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(),"C");
            List_Result = Utility.Fn_TableToList(obj_dt, "customer", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetEmployee(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterEmployee da_obj_Employee = new DataAccess.Masters.MasterEmployee();
            obj_dt = da_obj_Employee.GetLikeEmployee(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "empnamecode", "employeeid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetShippingBill(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.ShippingBill da_obj_ShippingBill = new DataAccess.ForwardingExports.ShippingBill();
            obj_dt = da_obj_ShippingBill.GetLikeShipBill(prefix, int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_DttableToList(obj_dt, "sbno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetBLNo_Blprint(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
            if (HttpContext.Current.Session["StrTranType"].ToString() == "FE")
            {
                obj_dt = obj_da_FEBL.GetLikeOTHERBLDetails(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else if (HttpContext.Current.Session["StrTranType"].ToString() == "FI")
            {
                obj_dt = obj_da_FIBL.GetLikeOTHERIBL(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            List_Result = Utility.Fn_DttableToList(obj_dt, "blno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetBLNo_BlNo(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
            obj_dt = obj_da_book.GetLikeBooking(HttpContext.Current.Session["StrTranType"].ToString(), prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()));
            List_Result = Utility.Fn_DttableToList(obj_dt, "shiprefno");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCustomerBLprint(string prefix, string FType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), FType);
            List_Result = Utility.Fn_TableToList(obj_dt, "customername", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCustomer_India(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            obj_dt = customerobj.GetLikeIndianCustomer(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "customer");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetChequeNo(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.NotOverCheque noobj = new DataAccess.Accounts.NotOverCheque();
            obj_dt = noobj.GetNotOverChequelikeChequediv(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_TableToList(obj_dt, "ChequeNo");
            return List_Result;
        }

        [WebMethod]
        public static List<string> Getcurrentyname(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterExRate exrateobj = new DataAccess.Masters.MasterExRate();
            obj_dt = exrateobj.GetLikeCurrency(prefix.ToUpper());
            List_Result = Utility.Fn_TableToList(obj_dt, "currency");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCharge(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_Charge = new DataAccess.Masters.MasterCharges();
            obj_dt = da_obj_Charge.GetLikeCharges(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "chargename", "chargeid");
            return List_Result;
        }



        [WebMethod]
        public static List<string> GetCustomer_DNCN(string prefix, string ChkType)
        {

            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            if (ChkType == "C")
            {
                obj_dt = da_obj_Customer.GetLikeIndianCustomer(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            }
            else if (ChkType == "P")
            {
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), "P");
                List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            }
            else if (ChkType == "T")
            {
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            }
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetBL_DNCNnew(string prefix, string ChkType, string Tran, string head)
        {
            if (HttpContext.Current.Session["Header"] != null)
            {
                head = HttpContext.Current.Session["Header"].ToString();
            }
            int int_bid = int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString());
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            if (head != "InvoiceWoJ")
            {
                if (Tran == "FE")
                {
                    if (ChkType == "False")
                    {

                        DataAccess.ForwardingExports.BLDetails da_obj_FEBL = new DataAccess.ForwardingExports.BLDetails();
                        //obj_dt = da_obj_FEBL.GetLikeOTHERBLDetails(prefix.ToUpper(), int_bid, int_divisionid);
                        obj_dt = da_obj_FEBL.GetLikeOTHERBLDetails(prefix.ToUpper(), int_bid, int_divisionid);
                        List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
                    }
                    else
                    {
                        DataAccess.ForwardingExports.JobInfo da_obj_FEJob = new DataAccess.ForwardingExports.JobInfo();
                        obj_dt = da_obj_FEJob.GetOTHERFEJobInfoMBL(prefix.ToUpper(), int_bid, int_divisionid);
                        List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "mblno");
                    }
                }
                else if (Tran == "FI")
                {
                    if (ChkType == "False")
                    {
                        DataAccess.ForwardingImports.BLDetails da_obj_FIBL = new DataAccess.ForwardingImports.BLDetails();
                        obj_dt = da_obj_FIBL.GetLikeOTHERIBL(prefix.ToUpper(), int_bid, int_divisionid);
                        List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
                    }
                    else
                    {
                        DataAccess.ForwardingImports.JobInfo da_obj_FIJob = new DataAccess.ForwardingImports.JobInfo();
                        obj_dt = da_obj_FIJob.GetLikeOTHERMBLNo(prefix.ToUpper(), int_bid, int_divisionid);
                        List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "mblno");
                    }
                }
                else if (Tran == "AE" || Tran == "AI")
                {
                    if (ChkType == "False")
                    {
                        DataAccess.AirImportExports.AIEBLDetails da_obj_AIBL = new DataAccess.AirImportExports.AIEBLDetails();
                        obj_dt = da_obj_AIBL.GetLikeOTHERAIEBLDetails(prefix.ToUpper(), Tran, int_bid, int_divisionid);
                        List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "hawblno");
                    }
                    else
                    {
                        DataAccess.AirImportExports.AIEJobInfo da_obj_AEJob = new DataAccess.AirImportExports.AIEJobInfo();
                        obj_dt = da_obj_AEJob.GetLikeOTHERAIEJobMBLNo(prefix.ToUpper(), Tran, int_bid, int_divisionid);
                        List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "mawblno");
                    }
                }
                else if (Tran == "CH")
                {
                    DataAccess.CustomHousingAgent.JobInfo da_obj_CHABL = new DataAccess.CustomHousingAgent.JobInfo();
                    obj_dt = da_obj_CHABL.GetLikeOTHERDocno(prefix.ToUpper(), int_bid, int_divisionid);
                    List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "docno");
                }

            }
            else
            {
                DataAccess.ForwardingExports.BLDetailsWOJob FEBLWoJobj = new DataAccess.ForwardingExports.BLDetailsWOJob();
                obj_dt = FEBLWoJobj.GetLikeBLDetailsWOJ(prefix.ToUpper(), int_bid, int_divisionid);
                List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
            }
            return List_Result;
        }

    }
}