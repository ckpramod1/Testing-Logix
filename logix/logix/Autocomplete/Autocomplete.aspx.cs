using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using logix;

namespace logix.Autocomplete
{
    public partial class Autocomplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<string> GetPort(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterPort da_obj_Port = new DataAccess.Masters.MasterPort();
            obj_dt = da_obj_Port.GetLikePort(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "portname", "portid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCustomerAddress(string prefix, string FType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), FType);
            List_Result = Utility.Fn_DatatableToList_CustomerAddress2(obj_dt, "customer","customername", "customerid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetVessel(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterVessel da_obj_Vessel = new DataAccess.Masters.MasterVessel();
            obj_dt = da_obj_Vessel.GetLikeVessel(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList(obj_dt, "vesselname", "vesselid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCargo(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCargo da_obj_Cargo = new DataAccess.Masters.MasterCargo();
            obj_dt = da_obj_Cargo.GetLikeCargo(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "cargotype", "cargoid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCustomer(string prefix, string FType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), FType);
            List_Result = Utility.Fn_DatatableToList_Customer(obj_dt, "customer", "customerid");
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
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetBLNo_BlNo(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Marketing.Booking obj_da_book = new DataAccess.Marketing.Booking();
            obj_dt = obj_da_book.GetLikeBooking(HttpContext.Current.Session["StrTranType"].ToString(), prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "shiprefno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetBLNo(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
            obj_dt = obj_da_FEBL.GetLikeOTHERBLDetails(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "blno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetBLNoEDI(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable dtblno = new DataTable();
            DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
            dtblno=AEBLobj.GetLikeOTHERAIEBLDetails(prefix.ToUpper(),"AE",Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()),Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(dtblno, "hawblno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetVessel_Picked(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo da_obj_Vessel = new DataAccess.ForwardingExports.JobInfo();
            if (HttpContext.Current.Session["FEPicked"].ToString() == "PickedOn")
            {
                obj_dt = da_obj_Vessel.GetLikeVessel(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), 1);
            }
            else
            {
                obj_dt = da_obj_Vessel.GetLikeVessel(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), 2);
            }
            List_Result = Utility.Fn_DatatableToList(obj_dt, "vesselname", "vesselid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetContainer_Picked(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo da_obj_Vessel = new DataAccess.ForwardingExports.JobInfo();
            if (HttpContext.Current.Session["FEPicked"].ToString() == "PickedOn")
            {
                obj_dt = da_obj_Vessel.GetLikeContainerno(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), 1);
            }
            else
            {
                obj_dt = da_obj_Vessel.GetLikeContainerno(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), 2);
            }
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "containerno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetMBL_Picked(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo da_obj_Vessel = new DataAccess.ForwardingExports.JobInfo();
            if (HttpContext.Current.Session["FEPicked"].ToString() == "PickedOn")
            {
                obj_dt = da_obj_Vessel.GetLikemblno(prefix.ToUpper().TrimEnd().TrimStart(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), 1);
            }
            else
            {
                obj_dt = da_obj_Vessel.GetLikemblno(prefix.ToUpper().TrimEnd().TrimStart(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), 2);
            }
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "mblno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetMBL(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo da_obj_FEJob = new DataAccess.ForwardingExports.JobInfo();
            obj_dt = da_obj_FEJob.GetLikembl(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "mblno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetMBL_Liner(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo da_obj_FEJob = new DataAccess.ForwardingExports.JobInfo();
            obj_dt = da_obj_FEJob.GetLikemlo(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "mlo");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetMBL_Liner_ReceivedOn(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCreditApproval da_obj_Credit = new DataAccess.Masters.MasterCreditApproval();
            obj_dt = da_obj_Credit.GetLikeCustomerMBLNotReleased(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), "C");
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "customer");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetMBL_ReceivedOn(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.ForwardingExports.JobInfo da_obj_FEJob = new DataAccess.ForwardingExports.JobInfo();
            obj_dt = da_obj_FEJob.GetLikeJobMBLNotReleased(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "mblno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCustomer_List(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_Customer(obj_dt, "customer", "customerid");
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
        public static List<string> GetCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_Charge = new DataAccess.Masters.MasterCharges();
            obj_dt = da_obj_Charge.GetLikeCurrency(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "currency");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetBL_DNCN(string prefix, string ChkType, string Tran)
        {
            int int_bid = int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString());
            int int_divisionid = int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString());
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();

            if (Tran == "FE")
            {
                if (ChkType == "False")
                {
                    DataAccess.ForwardingExports.BLDetails da_obj_FEBL = new DataAccess.ForwardingExports.BLDetails();
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
            //else if (Tran == "CH")
            else
            {
                DataAccess.CustomHousingAgent.JobInfo da_obj_CHABL = new DataAccess.CustomHousingAgent.JobInfo();
                obj_dt = da_obj_CHABL.GetLikeOTHERDocno(prefix.ToUpper(), int_bid, int_divisionid);
                List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "docno");
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
        [WebMethod]
        public static List<string> GetCustomer_DNCN(string prefix, string ChkType)
        {
           
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
                if (ChkType == "C")
                {
                    obj_dt = da_obj_Customer.GetLikeIndianCustomer(prefix.ToUpper());
                    List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer","customerid");
                }
                else if (ChkType == "P")
                {
                    obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(),"P");
                    List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer","customerid");
                }
                else if (ChkType == "T")
                {
                    obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper());
                    List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
                }
                return List_Result;
        }

        [WebMethod]
        public static List<string> GetCustomer_Payment(string prefix, string ChkType)
        {
           
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            DataAccess.Accounts.Recipts obj_da_receipt = new DataAccess.Accounts.Recipts();
            if (ChkType == "R")
            {
                obj_dt = obj_da_receipt.GetLikeReceiptCustomer(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            }
            else
            {
                obj_dt = da_obj_Customer.GetLikeIndianCustomer(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");
            }
          
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetChargePayment(string prefix, string ChkType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_Charges = new DataAccess.Masters.MasterCharges();
           
            if (ChkType == "R")
            {
                obj_dt = da_obj_Charges.GetLikeCharges(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "chargename", "chargeid");
            }
            else
            {
                obj_dt = da_obj_Charges.GetLikeCashPaymentCharges(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "chargename", "chargeid");
            }

            return List_Result;
        }
        [WebMethod]
        public static List<string> GetBank(string prefix, string ChkType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Recipts da_obj_Receipt = new DataAccess.Accounts.Recipts();

            if (ChkType == "P")
            {
                obj_dt = da_obj_Receipt.GetLikeBankName(prefix.ToUpper(),"O");
                List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "bankname", "bankid");
            }
            else
            {
                obj_dt = da_obj_Receipt.GetLikeBankName(prefix.ToUpper());
                List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "bankname", "bankid");
            }

            return List_Result;
        }
        [WebMethod]
        public static List<string> GetChequeNo(string prefix)
        {
            int int_divisionid = int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString());
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.NotOverCheque da_obj_Cheque = new DataAccess.Accounts.NotOverCheque();
            obj_dt = da_obj_Cheque.GetNotOverChequelikeChequediv(prefix.ToUpper(), int_divisionid);
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "ChequeNo");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetChequeSlip(string prefix,string Type)
        {
            int int_bid = int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString());
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.Recipts da_obj_Receipt = new DataAccess.Accounts.Recipts();
            obj_dt = da_obj_Receipt.GetRecptPymtContraLikeChqno(int_bid, prefix.ToUpper(), char.Parse(Type), HttpContext.Current.Session["FADbname"].ToString());
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "chequeno");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCompany(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomerGroup da_obj_Customer = new DataAccess.Masters.MasterCustomerGroup();
            obj_dt = da_obj_Customer.GetLikeCustGroup(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "gname", "groupid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCustomer_India(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeIndianCustomer(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16Display(obj_dt, "customer", "customerid", "Custtype");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCust(string prefix, string FType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            if (FType != "")
            {
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper(), FType);
            }
            else
            {
                obj_dt = da_obj_Customer.GetLikeCustomer(prefix.ToUpper());
            }
            List_Result = Utility.Fn_DatatableToList_Customer(obj_dt, "customer", "customerid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetTicket(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterMaintenance da_obj_Maintenance = new DataAccess.Masters.MasterMaintenance();
            obj_dt = da_obj_Maintenance.GetLikeTicketcode(prefix.ToUpper(), int.Parse(HttpContext.Current.Session["LoginEmpId"].ToString()));
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "ticketcode");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetEmployee(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
            obj_dt = da_obj_Employee.GetLikeEmpNameBranchwise(int.Parse(HttpContext.Current.Session["LoginDivisionId"].ToString()), int.Parse(HttpContext.Current.Session["LoginBranchid"].ToString()), prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "empnamecode", "employeeid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetEmpDetail(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.payroll.ProfessionalTax da_obj_payroll = new DataAccess.payroll.ProfessionalTax();
            obj_dt = da_obj_payroll.GetEmployeeDtls(prefix);
            List_Result = Utility.Fn_DatatableToList_string(obj_dt, "empname", "username");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetEmployeeName(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.HR.Employee da_obj_Employee = new DataAccess.HR.Employee();
            obj_dt = da_obj_Employee.GetLikeEmpName(prefix);
            List_Result = Utility.Fn_DatatableToList_string(obj_dt, "empname", "empcode");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetGradeName(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Payroll.LWF da_obj_LWF = new DataAccess.Payroll.LWF();
            obj_dt = da_obj_LWF.GetGrade(prefix.ToUpper());
            DataColumn Dc=new DataColumn("id");
            Dc.DataType=System.Type.GetType("System.String");
            Dc.DefaultValue="1";
            obj_dt.Columns.Add(Dc);
            List_Result = Utility.Fn_DatatableToList_string(obj_dt, "grade", "id");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetSectionCode(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.PAYROLL.MasterSection da_obj_Section = new DataAccess.PAYROLL.MasterSection();
            obj_dt = da_obj_Section.GetLikeSeccode(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_Text(obj_dt, "seccode");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetBranch(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.payroll.ProfessionalTax obj_da_ProfTax = new DataAccess.payroll.ProfessionalTax();
            obj_dt = obj_da_ProfTax.GetAllBranches4HR(prefix.ToUpper());
            List_Result = Fn_DatatableToList_Byteint32(obj_dt, "division", "branchid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> Get_GradeBranch(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.payroll.ProfessionalTax obj_da_ProfTax = new DataAccess.payroll.ProfessionalTax();
            obj_dt = obj_da_ProfTax.GetAllBranches4HR(prefix.ToUpper());
            List_Result = Fn_DatatableToList(obj_dt, "division", "branchid", "portid");
            return List_Result;
        }

        public static List<string> Fn_DatatableToList_Byteint32(DataTable dt, string str_Textfield, string str_Valuefield)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" +Convert.ToInt32(r.Field<Byte>(str_Valuefield).ToString().TrimEnd())).ToList();

            return lst_details;
        }
        private static List<string> Fn_DatatableToList(DataTable dt, string str_Textfield, string str_Valuefield_1, string str_Valuefield_2)
        {
            List<string> lst_details = new List<string>();
            lst_details = (from r in dt.AsEnumerable()
                           select r.Field<string>(str_Textfield) + "~" + Convert.ToInt32(r.Field<Byte>(str_Valuefield_1).ToString().TrimEnd())
                           + "~" + r.Field<Int16>(str_Valuefield_2)).ToList();

            return lst_details;
        }
        [WebMethod]
        public static List<string> GetCustomerAddressnew(string prefix, string FType)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();
            obj_dt = da_obj_Customer.GetLikeCustomernew(prefix.ToUpper(), FType);
            List_Result = Utility.Fn_DatatableToList_CustomerAddress2new(obj_dt, "customer", "customerid");
            return List_Result;
        }

        [WebMethod]
        public static List<string> SelPortName4typepadimg(string prefix)
        {
            List<string> list_result = new List<string>();
            DataTable dt = new DataTable();
            DataAccess.Masters.MasterPort obj_MasterPort = new DataAccess.Masters.MasterPort();
            //dt = obj_MasterPort.GetPortNameDetails(prefix.Trim());
            if (HttpContext.Current.Session["StrTranType"] != null)
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                dt = obj_MasterPort.SelPortName4typepadimg(prefix.Trim(), trantype);
                list_result = Utility.Fn_TableToList4type(dt, "portname", "portid", "portcode", "countryname", "countrycode");
            }
            return list_result;

        }



    }
}