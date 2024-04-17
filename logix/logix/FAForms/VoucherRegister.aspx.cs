using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;
using System.Xml;
using System.Text;
using ClosedXML.Excel;
namespace logix.FAForm
{
    public partial class VoucherRegister : System.Web.UI.Page
    {
        DataAccess.Accounts.Invoice objInv = new DataAccess.Accounts.Invoice();
        DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.TDS Obj_TDS = new DataAccess.Accounts.TDS();
        DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
        DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();
        DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
        DataAccess.Outstanding budgetobj = new DataAccess.Outstanding();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        double total = 0.00, temp = 0.00, tota11 = 0.00, tota12 = 0.00, tota14 = 0.00,  total1=0.00;
        int branchid, vouyear, divisionid;
        string strtrantype, voutypename;
        DataSet dtset = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                objInv.GetDataBase(Ccode);
                costtempobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                Obj_TDS.GetDataBase(Ccode);
                obj_da_Port.GetDataBase(Ccode);
                obipay.GetDataBase(Ccode);
                obj_da_Cost.GetDataBase(Ccode);


                budgetobj.GetDataBase(Ccode);
                HREmpobj.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
               



            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_Export);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (Session["LoginBranchid"] != null)
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_Header.Text = Request.QueryString["FormName"].ToString();
            }
            if (Session["str_ModuleName"] != null)
            {
                if (Session["str_ModuleName"].ToString() == "FC")
                {
                    strtrantype = "CA";
                }
                else
                {
                    strtrantype = "AC";
                }
            }
            if (!IsPostBack)
            {
                Fn_LoadBranch();
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
                int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
                string Str_CurrrentDate = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                if (stryear == vouyeartext)
                {
                    txt_from.Text = "01/01/" + vouyeartext;
                    txt_to.Text = Str_CurrrentDate.ToString();
                }
                else
                {
                    txt_from.Text = "01/01/" + vouyeartext;
                    txt_to.Text = "31/12/" + (vouyeartext + 1);
                }
                //txt_from.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                //txt_to.Text = txt_from.Text;
                if (lbl_Header.Text == "Registers")
                {
                    txt_from.Enabled = true;
                    txt_to.Enabled = true;
                    if (strtrantype == "CA")
                    {
                        //ddl_branch.Enabled = false;  ---4/18/2022

                        ddl_branch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                        Session["LoginBranchName"] = ddl_branch.SelectedItem.Text;

                        if (Session["LoginBranchName"] == "CORPORATE" || Session["LoginBranchName"] == "ALL")
                        {
                            chkConsolidate.Checked = true;
                        }

                        else
                        {
                            chkConsolidate.Checked = false;
                        }
                        //Fn_LoadBranch();
                    }
                    else
                    {
                        lbl_branch.Text = lbl_Header.Text;
                        ddl_branch.Enabled = false;
                        chkConsolidate.Visible = false;
                        ddl_branch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                    }
                    ddlSelect.Enabled = true;
                }
                else
                {
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                Grd_Invoice.DataSource = new DataTable();
                Grd_Invoice.DataBind();
                //btn_print.Attributes.Add("OnClick", "return IsDate('txt_from~txt_to');");
                //btn_Export.Attributes.Add("OnClick", "return IsDate('txt_from~txt_to');");
                btn_cancel.Text = "cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                Grd_load();
                Load_Reg();
            }
            if (ddl_branch.SelectedItem.Text == "CORPORATE" || ddl_branch.SelectedItem.Text == "ALL")
            {
                chkConsolidate.Checked = true;
            }
            else
            {
                chkConsolidate.Checked = false;
            }
            get_Year();
        }
        [WebMethod]
        public static List<string> GetCharge(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_Charge = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Charge.GetDataBase(Ccode);
            obj_dt = da_obj_Charge.GetLikeCharges(prefix.ToUpper());
            List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "chargename", "chargeid");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetSACCode(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataTable Dt_Filter = new DataTable();
            if (HttpContext.Current.Session["SACCode"] != null)
            {
                obj_dt = (DataTable)HttpContext.Current.Session["SACCode"];
                if (obj_dt.Rows.Count > 0)
                {
                    //DataTable dtLi = new DataTable();
                    DataView data1 = obj_dt.DefaultView;
                    data1.RowFilter = "saccode like '%" + prefix + "%' ";
                    Dt_Filter = data1.ToTable();
                }
            }
            List_Result = Utility.Fn_DttableToList(Dt_Filter, "saccode");
            return List_Result;
        }
        [WebMethod]
        public static List<string> GetCharge_FA(string prefix, string ChkTypeAdminPA, string ChkTypeAdminDN)
        {
            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges da_obj_Charge = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Charge.GetDataBase(Ccode);
            if (ChkTypeAdminPA == "GST Chargewise" || ChkTypeAdminPA == "Invoice-GST Chargewise" || ChkTypeAdminPA == "Credit Note-Operation-GST Chargewise" || ChkTypeAdminPA == "Credit Note-GST Chargewise" || ChkTypeAdminPA == "Debit Note-GST Chargewise" || ChkTypeAdminPA == "CN-Admin-GST Chargewise" || ChkTypeAdminPA == "DN-Admin-GST Chargewise" || ChkTypeAdminPA == "OSDN-GST Chargewise" || ChkTypeAdminPA == "OSCN-GST Chargewise")
            {
                obj_dt = da_obj_Charge.GetLikeChargesall(prefix.ToUpper());
            }
            else
                if (ChkTypeAdminPA == "Ledgerwise-AdminPA" || ChkTypeAdminDN == "Ledgerwise-AdminDN")
                {
                    obj_dt = da_obj_Charge.GetLikeChargesWChargeType(prefix.ToUpper(), "A");
                }
                else
                {
                    obj_dt = da_obj_Charge.GetLikeCharges4rpt(prefix.ToUpper());
                }
            List_Result = Utility.Fn_DatatableToList_int16(obj_dt, "chargename", "chargeid");
            return List_Result;
        }
        protected void Grd_load()
        {
            txt_saccode.Text = "";
            txt_saccode.Enabled = false;
            txt_charge.Text = "";
            txt_charge.Enabled = false;
            Grid_xl_head.Visible = false;
            Grid_xl.Visible = false;
            Grd_Invoice.Visible = false;
            GrdInterBranch.Visible = false;
            GrdDebitNote.Visible = false;
            grdCreditNote.Visible = false;
            grdCreditNoteOp.Visible = false;
            grdtSTChargewise.Visible = false;
            grdDebiteNote.Visible = false;
            Grid_creditNote.Visible = false;
            grdOtherDebitNote.Visible = false;
            GrdOtherCrediteNoteOpEr.Visible = false;
            GrdServiceTaxInvoice.Visible = false;
            grdServicesTacCnOps.Visible = false;
            grdReceiptBankReg.Visible = false;
            grdReceiptCashReg.Visible = false;
            grdTds.Visible = false;
            grdTdsType.Visible = false;
            GrdPayForBank.Visible = false;
            grdPaymentCashNew.Visible = false;
            GridView1.Visible = false;
            grdProformaInv.Visible = false;
            grdPerformaOsDN.Visible = false;
            grdOsCNNew.Visible = false;
            Grd_ServiceTaxPA.Visible = false;
            Grd_StCharge.Visible = false;
            Grd_AdminPA.Visible = false;
            Grd_AdminDN.Visible = false;
            Grd_OnAccountReceipt.Visible = false;
            Grd_OnAccountPayment.Visible = false;
            GrdReceivable.Visible = false;
            GrdPayable.Visible = false;
            grd_SerViceTax.Visible = false;
            tds_VoucherWise.Visible = false;
            grd_TdsSummary.Visible = false;
            grd_TdsVouchall.Visible = false;
            grd_internalBilling.Visible = false;
            grd_DncnJobClosing.Visible = false;
            grd_TdsAll.Visible = false;
            Grid_Receipt.Visible = false;
            Grid_payment.Visible = false;
            Grid_Osreceipt.Visible = false;
            Grid_ospayment.Visible = false;
            Grid_chequebounce.Visible = false;
            grid_paymentcancel.Visible = false;
            grid_contra.Visible = false;
            grdprofomaAdminDNCN.Visible = false;
            grd_pending.Visible = false;
            grd_pend.Visible = false;
        }
        protected void get_Year()
        {
            //DataAccess.LogDetails logobj = new DataAccess.LogDetails();
            if ((logobj.GetDate()).Month < 4)
            {
                vouyear = (logobj.GetDate()).Year - 1;
            }
            else
            {
                vouyear = (logobj.GetDate()).Year;
            }
        }
        protected void Load_Reg()
        {
            if (lbl_Header.Text == "Registers")
            {
                ddlSelect.Items.Add("Sales Invoice");
                ddlSelect.Items.Add("Purchase Invoice");
                ddlSelect.Items.Add("Debit Note");
                ddlSelect.Items.Add("Credit Note");
                ddlSelect.Items.Add("Other DebitNote");
                ddlSelect.Items.Add("Other CreditNote");
                ddlSelect.Items.Add("Debit Note-Admin");
                ddlSelect.Items.Add("Credit Note-Admin");
                ddlSelect.Items.Add("Receipt-Bank");
                ddlSelect.Items.Add("Receipt-Cash");
                ddlSelect.Items.Add("Payment-Bank");
                ddlSelect.Items.Add("Payment-Cash");
   
                //ddlSelect.Items.Add("Ledgerwise-Inv,DN");
                //ddlSelect.Items.Add("Ledgerwise-CNOps,CN");
                ddlSelect.Items.Add("Inter Branch Billing");
                //ddlSelect.Items.Add("Inter Company Billing");
                ddlSelect.Items.Add("TDS");
                ddlSelect.Items.Add("TDS With Type");
                ddlSelect.Items.Add("Proforma Sales Inv");
                ddlSelect.Items.Add("Proforma Purchase Inv");
                ddlSelect.Items.Add("Proforma OSSI");
                ddlSelect.Items.Add("Proforma OSPI");
                ddlSelect.Items.Add("Proforma Other DN");
                ddlSelect.Items.Add("Proforma Other CN");
                ddlSelect.Items.Add("Proforma DN-Admin");
                ddlSelect.Items.Add("Proforma CN-Admin");
                ddlSelect.Items.Add("Reversal Billing");


                ddlSelect.Items.Add("Proforma Sales Inv Pending");
                ddlSelect.Items.Add("Proforma Purchase Inv Pending");
                ddlSelect.Items.Add("Proforma OSSI Pending");
                ddlSelect.Items.Add("Proforma OSPI Pending");
                ddlSelect.Items.Add("Proforma Other DN Pending");
                ddlSelect.Items.Add("Proforma Other CN Pending");
                ddlSelect.Items.Add("Proforma DN-Admin Pending");
                ddlSelect.Items.Add("Proforma CN-Admin Pending");
                //-------------------------------New

              
                //ddlSelect.Items.Add("ServiceTax-Pro. Invoice");
                //ddlSelect.Items.Add("ServiceTax-FinalBill");
              //  ddlSelect.Items.Add("STChargewise-Vou,CN");
                //ddlSelect.Items.Add("Ledgerwise-AdminVou");
                //ddlSelect.Items.Add("Ledgerwise-AdminDN");
                ddlSelect.Items.Add("OnAccount Receipt");
                ddlSelect.Items.Add("OnAccount Payment");
                ddlSelect.Items.Add("TDS Receivable");
                ddlSelect.Items.Add("TDS Payable");

               
                ddlSelect.Items.Add("TDS Voucherwise");
                ddlSelect.Items.Add("TDS Summary");
                ddlSelect.Items.Add("Receipt");
                ddlSelect.Items.Add("Payment");
                ddlSelect.Items.Add("Remittance Receipt");
                ddlSelect.Items.Add("Remittance Payment");
                ddlSelect.Items.Add("Contra");
              //  ddlSelect.Items.Add("Ledgerwise Inc  & Exp");
                ddlSelect.Items.Add("Receipt - Cheque Bounce");
                ddlSelect.Items.Add("Payment Cancel");
                ddlSelect.Items.Add("TDS Voucherwise ALL");                              
                //ddlSelect.Items.Add("Internal Billing Branch");     
             //   ddlSelect.Items.Add("DNCN After JobClosing");    

                // GST XL
                ddlSelect.Items.Add("GST");
                //ddlSelect.Items.Add("Sales Invoice-GST");
                //ddlSelect.Items.Add("Purchase Invoice-GST");
                //ddlSelect.Items.Add("Credit Note-GST");
                //ddlSelect.Items.Add("Debit Note-GST");
                //ddlSelect.Items.Add("CN-Admin-GST");
                //ddlSelect.Items.Add("DN-Admin-GST");
                //ddlSelect.Items.Add("OSDN-GST");
                //ddlSelect.Items.Add("OSCN-GST");
                //ddlSelect.Items.Add("BOS-GST");

                ddlSelect.Items.Add("GST Chargewise");
                //ddlSelect.Items.Add("Sales Invoice-GST Chargewise");
                //ddlSelect.Items.Add("BOS-GST Chargewise");
                //ddlSelect.Items.Add("Purchase Invoice-GST Chargewise");
                //ddlSelect.Items.Add("Credit Note-GST Chargewise");
                //ddlSelect.Items.Add("Debit Note-GST Chargewise");
                //ddlSelect.Items.Add("CN-Admin-GST Chargewise");
                //ddlSelect.Items.Add("DN-Admin-GST Chargewise");
                //ddlSelect.Items.Add("OSDN-GST Chargewise");
                //ddlSelect.Items.Add("OSCN-GST Chargewise");
                ddlSelect.Items.Add("BOS");
                //-----------------------------------------------------------------------//
                //ddl_GST.Items.Add("B2B");
                //ddl_GST.Items.Add("B2CL");
                //ddl_GST.Items.Add("B2CS");
                //ddl_GST.Items.Add("CDNR");
                //ddl_GST.Items.Add("CDNUR");
                //ddl_GST.Items.Add("EXP");
                //ddl_GST.Items.Add("Exemption");
                //ddl_GST.Items.Add("HSN(SAC)");

                //-----------------------------------------------------------------------//
                ddlSelect.Items.Add("VoucherwiseReceipt-Bank");
                ddlSelect.Items.Add("VoucherwiseReceipt-Cash");
                ddlSelect.Items.Add("VoucherwisePayment-Bank");
                ddlSelect.Items.Add("VoucherwisePayment-Cash");
            }
        }
        private void Fn_LoadBranch()
        {
            DataTable obj_dt = new DataTable();
            //DataAccess.Masters.MasterPort obj_da_Port = new DataAccess.Masters.MasterPort();
            obj_dt = obj_da_Port.GetAllBranchNameforPortName();
            ddl_branch.Items.Add("ALL");
            ddl_branch.DataSource = obj_dt;
            ddl_branch.DataTextField = "portname";
            ddl_branch.DataBind();
        }
        protected void btn_print_Click(object sender, EventArgs e)
        {
            Grid_xl.Visible = false;
            txt_charge.Enabled = false;
            if (strtrantype != "CA")
            {
                if (ddl_branch.SelectedValue == "ALL")
                {
                    if (ddl_branch.SelectedValue == "ALL")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Revenue", "alertify.alert('Select the Branch');", true);
                        ddl_branch.Focus();
                        return;
                    }
                }
            }
            int int_Empid = 0, int_bid = 0, int_divisionid = 0;
            if (strtrantype == "CA")
            {
                int_bid = hrempobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), ddl_branch.SelectedItem.Text);
                int_divisionid = Convert.ToInt32(Session["LoginDivisionId"]);

            }
            else
            {
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
            }


            //if (ddlSelect.SelectedItem.Text == "Invoice-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            //else if (ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            //else if (ddlSelect.SelectedItem.Text == "Credit Note-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            //else if (ddlSelect.SelectedItem.Text == "Debit Note-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            //else if (ddlSelect.SelectedItem.Text == "CN-Admin-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            //else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            //else if (ddlSelect.SelectedItem.Text == "OSDN-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            //else if (ddlSelect.SelectedItem.Text == "OSCN-GST")
            //{
            //    txt_charge.Enabled = false;
            //    txt_charge.Text = "";
            //}
            DateTime dt_fromdate, dt_todate;
            dt_fromdate = DateTime.Parse(Utility.fn_ConvertDate(txt_from.Text));
            dt_todate = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));
            int_Empid = int.Parse(Session["LoginEmpId"].ToString());
            int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            DataTable obj_dt = new DataTable();
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            int r, i = 0;
            string Str_RptName = "", Str_SF = "", Str_SP = "", Str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            Grd_load();
            DataTable dtTemp = new DataTable();
            DataRow dtrow;
            if (ddl_GST.SelectedItem.Text == "B2B" || ddl_GST.SelectedItem.Text == "B2CL" || ddl_GST.SelectedItem.Text == "B2CS" || ddl_GST.SelectedItem.Text == "CDNR" || ddl_GST.SelectedItem.Text == "CDNUR" || ddl_GST.SelectedItem.Text == "EXP" || ddl_GST.SelectedItem.Text == "Exemption" || ddl_GST.SelectedItem.Text == "HSN(SAC)")
            {
                Grid_xl_bind();
                return;
            }
            else if (ddlSelect.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Revenue", "alertify.alert('Please Select Register');", true);
                ddlSelect.Focus();
                return;
            }
            if (ddlSelect.SelectedItem.Text == "Sales Invoice")
            {
                Grd_Invoice.Visible = true;
                r = 0;

                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, 0, divisionid,1);
                  //  obj_dt = objInv.GetInvoiceRegall(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, int_bid, 0, 1);
                   // obj_dt = objInv.GetInvoiceRegall(dt_fromdate, dt_todate, int_bid, 0);
                }
                // obj_dt = objInv.GetInvoiceReg(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchid");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        string amt = obj_dt.Rows[i]["amount"].ToString();
                        if (amt == "" || amt == "0")
                        {
                            amt = "0.00";
                        }
                        total = total + Convert.ToDouble(amt);
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add();
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                Grd_Invoice.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                Grd_Invoice.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Inter Branch Billing")
            {
                GrdInterBranch.Visible = true;

                //costtempobj.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(Session["countryid"].ToString()));
                if (chkConsolidate.Checked == true)
                {
                    costtempobj.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, divisionid, Convert.ToInt32(Session["countryid"].ToString()));
                }
                else
                {
                    costtempobj.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(Session["countryid"].ToString()));
                }
                DataTable dtnew = new DataTable();
                obj_dt = objInv.GetInterBilling(int_Empid, int_divisionid);
                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    DataTable Dtemp = new DataTable();
                    DataRow dataRow;
                    //   Dtemp.Columns.Add("SNo");
                    Dtemp.Columns.Add("vouno");
                    Dtemp.Columns.Add("voudate");
                    Dtemp.Columns.Add("voutype");
                    Dtemp.Columns.Add("trantype");
                    Dtemp.Columns.Add("jobno");
                    Dtemp.Columns.Add("blno");
                    Dtemp.Columns.Add("customername");
                    Dtemp.Columns.Add("amount");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "voutype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "voutype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = Dtemp.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "voutype = '" + dtnew.Rows[j]["voutype"] + "' ";
                        dtLi = data1.ToTable();
                        double amount = 0; temp = 0;
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            dataRow = Dtemp.NewRow();
                            string amt = "0";
                            dataRow["vouno"] = dtLi.Rows[i]["vouno"];
                            dataRow["voudate"] = dtLi.Rows[i]["voudate"];
                            dataRow["voutype"] = dtLi.Rows[i]["voutype"];
                            if (dtLi.Rows[i]["trantype"] == "FE")
                            {
                                dataRow["trantype"] = "OE";
                            }
                            else if (dtLi.Rows[i]["trantype"] == "FI")
                            {
                                dataRow["trantype"] = "OI";
                            }
                            else
                            {
                                dataRow["trantype"] = dtLi.Rows[i]["trantype"];
                            }
                            dataRow["jobno"] = dtLi.Rows[i]["jobno"];
                            dataRow["blno"] = dtLi.Rows[i]["blno"];
                            dataRow["customername"] = dtLi.Rows[i]["customername"];
                            amt = dtLi.Rows[i]["amount"].ToString();
                            if (amt == "" || amt == "0")
                            {
                                amt = "0.00";
                            }
                            dataRow["amount"] = Convert.ToDecimal(amt).ToString("#,0.00");
                            amount = amount + Convert.ToDouble(amt.ToString());
                            Dtemp.Rows.Add(dataRow);
                        }
                        dtrow = Dtemp.NewRow();
                        dtrow["customername"] = "Total";
                        dtrow["amount"] = amount.ToString("#,0.00");
                        Dtemp.Rows.Add(dtrow);
                        total = total + amount;
                    }
                    //DataTable dt12 = new DataTable();
                    //dt12 = Dtemp;
                    dtrow = Dtemp.NewRow();
                    dtrow["customername"] = obj_dt.Rows[0]["shortname"].ToString();
                    dtrow["amount"] = total.ToString("#,0.00");
                    Dtemp.Rows.Add(dtrow);
                    GrdInterBranch.DataSource = Dtemp;
                    ViewState["Value"] = Dtemp;
                    GrdInterBranch.DataBind();
                    return;
                }
                else {
                    GrdInterBranch.DataSource = "";
                    
                    GrdInterBranch.DataBind();
                    return;
                }

              
            }
            else if (ddlSelect.SelectedItem.Text == "Inter Company Billing")
            {
                GrdInterBranch.Visible = true;
                if (chkConsolidate.Checked == true)
                {
                    costtempobj.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, divisionid, Convert.ToInt32(Session["countryid"].ToString()));
                }
                else
                {
                    costtempobj.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(Session["countryid"].ToString()));
                }
                // costtempobj.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(Session["countryid"].ToString()));
                DataTable dtnew = new DataTable();
                obj_dt = objInv.GetInterBilling(int_Empid, int_divisionid);
                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    DataTable Dtemp = new DataTable();
                    DataRow dataRow;
                    Dtemp.Columns.Add("vouno");
                    Dtemp.Columns.Add("voudate");
                    Dtemp.Columns.Add("voutype");
                    Dtemp.Columns.Add("trantype");
                    Dtemp.Columns.Add("jobno");
                    Dtemp.Columns.Add("blno");
                    Dtemp.Columns.Add("customername");
                    Dtemp.Columns.Add("amount");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "voutype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "voutype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = Dtemp.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "voutype = '" + dtnew.Rows[j]["voutype"] + "' ";
                        dtLi = data1.ToTable();
                        double amount = 0; temp = 0;
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            dataRow = Dtemp.NewRow();
                            dataRow["vouno"] = dtLi.Rows[i]["vouno"];
                            dataRow["voudate"] = dtLi.Rows[i]["voudate"];
                            dataRow["voutype"] = dtLi.Rows[i]["voutype"];
                            if (dtLi.Rows[i]["trantype"] == "FE")
                            {
                                dataRow["trantype"] = "OE";
                            }
                            else if (dtLi.Rows[i]["trantype"] == "FI")
                            {
                                dataRow["trantype"] = "OI";
                            }
                            else
                            {
                                dataRow["trantype"] = dtLi.Rows[i]["trantype"];
                            }
                            dataRow["jobno"] = dtLi.Rows[i]["jobno"];
                            dataRow["blno"] = dtLi.Rows[i]["blno"];
                            string amt;
                            amt = dtLi.Rows[i]["amount"].ToString();
                            if (amt == "" || amt == "0")
                            {
                                amt = "0.00";
                            }
                            dataRow["amount"] = Convert.ToDecimal(amt).ToString("#,0.00");
                            amount = amount + Convert.ToDouble(amt.ToString());
                            Dtemp.Rows.Add(dataRow);
                        }
                        dtrow = Dtemp.NewRow();
                        dtrow["customername"] = "Total";
                        dtrow["amount"] = amount.ToString("#,0.00");
                        Dtemp.Rows.Add(dtrow);
                        total = total + amount;
                    }
                    dtrow = Dtemp.NewRow();
                    dtrow["customername"] = obj_dt.Rows[0]["shortname"].ToString();
                    dtrow["amount"] = total.ToString("#0.00");
                    Dtemp.Rows.Add(dtrow);
                    GrdInterBranch.DataSource = Dtemp;
                    ViewState["Value"] = Dtemp;
                    GrdInterBranch.DataBind();
                    GrdInterBranch.Visible = true;
                    return;
                }
                else
                {
                    GrdInterBranch.DataSource = "";
                    GrdInterBranch.DataBind();
                }
            }
            else if (ddlSelect.SelectedItem.Text == "Debit Note-Admin")
            {
                GrdDebitNote.Visible = true;
                r = 0;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetAdminRegisterall(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetAdminRegister(dt_fromdate, dt_todate, int_bid);
                }

                //obj_dt = objInv.GetAdminRegister(dt_fromdate, dt_todate, int_bid);
                r = obj_dt.Rows.Count;
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchid");
                if (obj_dt.Rows.Count > 0)
                {
                    string amt;
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amt = obj_dt.Rows[i]["amount"].ToString();
                        if (amt == "0.00" || amt == "0")
                        {
                            amt = "0.00";
                        }
                        total = total + Convert.ToDouble(amt.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add();
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                GrdDebitNote.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GrdDebitNote.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Credit Note-Admin")
            {
                grdCreditNote.Visible = true;
                r = 0;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetCreditNotAdminnew(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetCreditNotAdmin(dt_fromdate, dt_todate, int_bid);
                }
                // obj_dt = objInv.GetCreditNotAdmin(dt_fromdate, dt_todate, int_bid);
                r = obj_dt.Rows.Count;
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchid");
                if (obj_dt.Rows.Count > 0)
                {
                    string amt = "0";
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amt = obj_dt.Rows[i]["amount"].ToString();
                        if (amt == "0.00" || amt == "0")
                        {
                            amt = "0.00";
                        }
                        total = total + Convert.ToDouble(amt);
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add();
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdCreditNote.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdCreditNote.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Purchase Invoice")
            {
                r = 0;
                grdCreditNoteOp.Visible = true;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, 0, divisionid, 2);
                    //obj_dt = objInv.GetCreditNotOper(dt_fromdate, dt_todate, 0);
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, int_bid, 0, 2);
                    //obj_dt = objInv.GetCreditNotOper(dt_fromdate, dt_todate, int_bid);
                }
                //  obj_dt = objInv.GetCreditNotOper(dt_fromdate, dt_todate, int_bid);
                r = obj_dt.Rows.Count;
                string amount;
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchid");
                obj_dt.Columns.Remove("trantype");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add();
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdCreditNoteOp.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdCreditNoteOp.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-Inv,DN")
            {
                //DataAccess.CostingTemp costtempobj = new DataAccess.CostingTemp();
                grdtSTChargewise.Visible = true;
                costtempobj.InsSTChargewise(int_bid, vouyear, int_Empid, dt_fromdate, dt_todate, "Inc");
                r = 0;
                string first, second;
                string value, value1;
                double output = 0.00;
                double input = 0, input1 = 0, input2 = 0;
                string Tot, Tot1, Tot2;
                DataTable dataTable = new DataTable();
                DataRow drow;
                //obj_dt = objInv.GetSTChargewise(int_Empid);
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(divisionid, int_Empid, "Y");
                }
                else
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                }
                // obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                txt_charge.Enabled = true;
                //dataTable.Columns.Add("chargename");
                //dataTable.Columns.Add("chargetot");
                //dataTable.Columns.Add("chargest");
                //dataTable.Columns.Add("Total");
                /*if (obj_dt.Rows.Count > 0)
                {
                     txt_charge.Enabled = true;
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        drow = dataTable.NewRow();
                         drow["chargename"] = obj_dt.Rows[i]["chargename"];
                        first = obj_dt.Rows[i]["chargetot"].ToString();
                        if (first == "" || first == "0")
                        {
                            drow["chargetot"] = "0.00";
                        }
                        else
                        {
                            drow["chargetot"] = Convert.ToDouble(first).ToString("#0.00");
                        }
                         value = obj_dt.Rows[i]["chargetot"].ToString();
                         second = obj_dt.Rows[i]["chargest"].ToString();
                        if (second == "" || second == "0")
                        {
                            drow["chargest"] = "0.00";
                        }
                        else
                        {
                            drow["chargest"] = Convert.ToDouble(second).ToString("#0.00");
                        }
                         value1 = obj_dt.Rows[i]["chargest"].ToString();
                         if (value == "")
                        {
                            value = "0.00";
                        }
                        if (value1 == "")
                        {
                            value1 = "0.00";
                        }
                        output = Convert.ToDouble(value) + Convert.ToDouble(value1);
                        drow["Total"] = output.ToString("#,0.00");
                        //if (value != "0.00" && value1 != "0.00")
                        //{
                        //    output = Convert.ToDouble(value) + Convert.ToDouble(value1);
                        //    drow["Total"] = output.ToString("#0.00");
                        //}
                        //else
                        //{
                        //    drow["Total"] = "0.00";
                        //}
                          dataTable.Rows.Add(drow);
                    }
                    r = dataTable.Rows.Count;
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        Tot = obj_dt.Rows[i]["chargetot"].ToString();
                        if (Tot == "" || Tot == "0")
                        {
                            Tot = "0.00";
                        }
                        input = input + Convert.ToDouble(Tot.ToString());
                         Tot1 = obj_dt.Rows[i]["chargetot"].ToString();
                        if (Tot1 == "" || Tot1 == "0")
                        {
                            Tot1 = "0.00";
                        }
                        input1 = input1 + Convert.ToDouble(Tot1.ToString());
                         Tot2 = obj_dt.Rows[i]["chargetot"].ToString();
                        if (Tot2 == "" || Tot2 == "0")
                        {
                            Tot2 = "0.00";
                        }
                        input2 = input2 + Convert.ToDouble(Tot2.ToString());
                    }
                    dtrow = obj_dt.NewRow();
                    dataTable.Rows.Add();
                    dataTable.Rows[r]["chargename"] = "Local Service Tax";
                    dataTable.Rows[r]["chargetot"] = input.ToString("#,0.00");
                    dataTable.Rows[r]["chargest"] = input1.ToString("#,0.00");
                    dataTable.Rows[r]["Total"] = input2.ToString("#,0.00");
                    grdtSTChargewise.DataSource = dataTable;
                    ViewState["Value"] = dataTable;
                    grdtSTChargewise.DataBind();
                }*/
                grdtSTChargewise.DataSource = obj_dt;
                grdtSTChargewise.DataBind();
                ViewState["Value"] = obj_dt;
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-CNOps,CN")
            {
                costtempobj.InsSTChargewise(int_bid, vouyear, int_Empid, dt_fromdate, dt_todate, "Exp");
                grdtSTChargewise.Visible = true;
                r = 0;
                string first, second;
                string value, value1;
                double output = 0.00;
                DataTable dataTable = new DataTable();
                DataRow drow;
                double input = 0, input1 = 0, input2 = 0;
                string Tot, Tot1, Tot2;
                //dataTable.Columns.Add("chargename");
                //dataTable.Columns.Add("chargetot");
                //dataTable.Columns.Add("chargest");
                //dataTable.Columns.Add("Total");
                // obj_dt = objInv.GetSTChargewise(int_Empid);
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(divisionid, int_Empid, "Y");
                }
                else
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                }
                // obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                //if (obj_dt.Rows.Count > 0)
                //{
                //    txt_charge.Enabled = true;
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        drow = dataTable.NewRow();
                //        dataTable.Rows[i]["chargename"] = obj_dt.Rows[i]["chargename"];
                //        first = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (first == "" || first == "0")
                //        {
                //            dataTable.Rows[i]["chargetot"] = "0.00";
                //        }
                //        else
                //        {
                //            dataTable.Rows[i]["chargetot"] = Convert.ToDouble(first).ToString("#,0.00");
                //        }
                //        value = obj_dt.Rows[i]["chargetot"].ToString();
                //        second = obj_dt.Rows[i]["chargest"].ToString();
                //        if (second == "" || second == "0")
                //        {
                //            dataTable.Rows[i]["chargest"] = "0.00";
                //        }
                //        else
                //        {
                //            dataTable.Rows[i]["chargest"] = Convert.ToDouble(second).ToString("#,0.00");
                //        }
                //        value1 = obj_dt.Rows[i]["chargest"].ToString();
                //        if (value == "")
                //        {
                //            value = "0.00";
                //        }
                //        if (value1 == "")
                //        {
                //            value1 = "0.00";
                //        }
                //        output = Convert.ToDouble(value) + Convert.ToDouble(value1);
                //        dataTable.Rows[i]["Total"] = output.ToString("#,0.00");
                //        dataTable.Rows.Add(drow);
                //    }
                //    r = dataTable.Rows.Count;
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        Tot = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot == "" || Tot == "0")
                //        {
                //            Tot = "0.00";
                //        }
                //        input = input + Convert.ToDouble(Tot.ToString());
                //        Tot1 = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot1 == "" || Tot1 == "0")
                //        {
                //            Tot1 = "0.00";
                //        }
                //        input1 = input1 + Convert.ToDouble(Tot1.ToString());
                //        Tot2 = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot2 == "" || Tot2 == "0")
                //        {
                //            Tot2 = "0.00";
                //        }
                //        input2 = input2 + Convert.ToDouble(Tot2.ToString());
                //    }
                //    dtrow = dataTable.NewRow();
                //    dataTable.Rows.Add(dtrow);
                //    dataTable.Rows[r]["chargename"] = "Local Service Tax";
                //    dataTable.Rows[r]["chargetot"] = input.ToString("#,0.00");
                //    dataTable.Rows[r]["chargest"] = input1.ToString("#,0.00");
                //    dataTable.Rows[r]["Total"] = input2.ToString("#,0.00");
                //}
                grdtSTChargewise.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdtSTChargewise.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-DN")
            {
                r = 0;
                grdtSTChargewise.Visible = true;
                string first, second;
                string value, value1;
                double output = 0.00;
                double input = 0, input1 = 0, input2 = 0;
                string Tot, Tot1, Tot2;
                DataTable dataTable = new DataTable();
                DataRow drow;
                //obj_dt = objInv.GetSTChargewise(int_Empid);
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(divisionid, int_Empid, "Y");
                }
                else
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                }
                //obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                //if (obj_dt.Rows.Count > 0)
                //{
                //    txt_charge.Enabled = true;
                //    dataTable.Columns.Add("chargename");
                //    dataTable.Columns.Add("chargetot");
                //    dataTable.Columns.Add("chargest");
                //    dataTable.Columns.Add("Total");
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        drow = dataTable.NewRow();
                //        drow["chargename"] = obj_dt.Rows[i]["chargename"];
                //        first = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (first == "" || first == "0")
                //        {
                //            drow["chargetot"] = "0.00";
                //        }
                //        else
                //        {
                //            drow["chargetot"] = Convert.ToDouble(first).ToString("#,0.00");
                //        }
                //        value = obj_dt.Rows[i]["chargetot"].ToString();
                //        second = obj_dt.Rows[i]["chargest"].ToString();
                //        if (second == "" || second == "0")
                //        {
                //            drow["chargest"] = "0.00";
                //        }
                //        else
                //        {
                //            drow["chargest"] = Convert.ToDouble(second).ToString("#,0.00");
                //        }
                //        value1 = obj_dt.Rows[i]["chargest"].ToString();
                //        if (value == "")
                //        {
                //            value = "0.00";
                //        }
                //        if (value1 == "")
                //        {
                //            value1 = "0.00";
                //        }
                //        output = Convert.ToDouble(value) + Convert.ToDouble(value1);
                //        drow["Total"] = output.ToString("#,0.00");
                //        dataTable.Rows.Add(drow);
                //    }
                //    r = dataTable.Rows.Count;
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        Tot = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot == "" || Tot == "0")
                //        {
                //            Tot = "0.00";
                //        }
                //        input = input + Convert.ToDouble(Tot.ToString());
                //        Tot1 = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot1 == "" || Tot1 == "0")
                //        {
                //            Tot1 = "0.00";
                //        }
                //        input1 = input1 + Convert.ToDouble(Tot1.ToString());
                //        Tot2 = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot2 == "" || Tot2 == "0")
                //        {
                //            Tot2 = "0.00";
                //        }
                //        input2 = input2 + Convert.ToDouble(Tot2.ToString());
                //    }
                //    dtrow = obj_dt.NewRow();
                //    dataTable.Rows.Add();
                //    dataTable.Rows[r]["chargename"] = "Local Service Tax";
                //    dataTable.Rows[r]["chargetot"] = input.ToString("#,0.00");
                //    dataTable.Rows[r]["chargest"] = input1.ToString("#,0.00");
                //    dataTable.Rows[r]["Total"] = input2.ToString("#,0.00");
                //}
                grdtSTChargewise.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdtSTChargewise.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-CN")
            {
                txt_charge.Enabled = true;
                //Str_RptName = "STChargeWise.rpt";
                //Str_SF = "{TempCharges.empid}=" + int_Empid;
                //Str_SP = "Title=Service Tax On Other DebitNote Charge From " + txt_from.Text + " to " + txt_to.Text;
                r = 0;
                string first, second;
                string value, value1;
                double output = 0.00;
                double input = 0, input1 = 0, input2 = 0;
                string Tot, Tot1, Tot2;
                grdtSTChargewise.Visible = true;
                DataTable dataTable = new DataTable();
                DataRow drow;
                //obj_dt = objInv.GetSTChargewise(int_Empid);
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(divisionid, int_Empid, "Y");
                }
                else
                {
                    obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                }
                //obj_dt = costtempobj.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                //if (obj_dt.Rows.Count > 0)
                //{
                //    dataTable.Columns.Add("chargename");
                //    dataTable.Columns.Add("chargetot");
                //    dataTable.Columns.Add("chargest");
                //    dataTable.Columns.Add("Total");
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        drow = dataTable.NewRow();
                //        drow["chargename"] = obj_dt.Rows[i]["chargename"];
                //        first = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (first == "" || first == "0")
                //        {
                //            drow["chargetot"] = "0.00";
                //        }
                //        else
                //        {
                //            drow["chargetot"] = Convert.ToDouble(first).ToString("#,0.00");
                //        }
                //        value = obj_dt.Rows[i]["chargetot"].ToString();
                //        second = obj_dt.Rows[i]["chargest"].ToString();
                //        if (second == "" || second == "0")
                //        {
                //            drow["chargest"] = "0.00";
                //        }
                //        else
                //        {
                //            drow["chargest"] = Convert.ToDouble(second).ToString("#,0.00");
                //        }
                //        value1 = obj_dt.Rows[i]["chargest"].ToString();
                //        if (value == "")
                //        {
                //            value = "0.00";
                //        }
                //        if (value1 == "")
                //        {
                //            value1 = "0.00";
                //        }
                //        output = Convert.ToDouble(value) + Convert.ToDouble(value1);
                //        drow["Total"] = output.ToString("#,0.00");
                //        dataTable.Rows.Add(drow);
                //    }
                //    r = dataTable.Rows.Count;
                //    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                //    {
                //        Tot = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot == "" || Tot == "0")
                //        {
                //            Tot = "0.00";
                //        }
                //        input = input + Convert.ToDouble(Tot.ToString());
                //        Tot1 = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot1 == "" || Tot1 == "0")
                //        {
                //            Tot1 = "0.00";
                //        }
                //        input1 = input1 + Convert.ToDouble(Tot1.ToString());
                //        Tot2 = obj_dt.Rows[i]["chargetot"].ToString();
                //        if (Tot2 == "" || Tot2 == "0")
                //        {
                //            Tot2 = "0.00";
                //        }
                //        input2 = input2 + Convert.ToDouble(Tot2.ToString());
                //    }
                //    dtrow = obj_dt.NewRow();
                //    dataTable.Rows.Add();
                //    dataTable.Rows[r]["chargename"] = "Local Service Tax";
                //    dataTable.Rows[r]["chargetot"] = input.ToString("#,0.00");
                //    dataTable.Rows[r]["chargest"] = input1.ToString("#,0.00");
                //    dataTable.Rows[r]["Total"] = input2.ToString("#,0.00");
                //}
                grdtSTChargewise.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdtSTChargewise.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Debit Note")
            {
                //Str_RptName = "OSDNRegister.rpt";
                //Str_SF = "{OSDN.dndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {OSDN.dndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {OSDN.branchid}=" + int_bid;
                //Str_SP = "Title=Overseas Debit Note Register for the period of" + txt_from.Text + " to " + txt_to.Text;
                r = 0;
                grdDebiteNote.Visible = true;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, 0, divisionid, 5);
                   // obj_dt = objInv.GetDebiteNoteNewall(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, int_bid, 0, 5);
                   // obj_dt = objInv.GetDebiteNoteNew(dt_fromdate, dt_todate, int_bid);
                }
                //obj_dt = objInv.GetDebiteNoteNew(dt_fromdate, dt_todate, int_bid);
                r = obj_dt.Rows.Count;
                string amount;
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("trantype");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add();
                obj_dt.Rows[r]["curr"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdDebiteNote.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdDebiteNote.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Credit Note")
            {
                r = 0;
                Grid_creditNote.Visible = true;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, 0, divisionid, 6);
                   // obj_dt = objInv.GetCrediteNoteNewall(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, int_bid, 0, 6);
                   // obj_dt = objInv.GetCrediteNoteNewall(dt_fromdate, dt_todate, int_bid, 0);
                }
                //obj_dt = objInv.GetCrediteNoteNew(dt_fromdate, dt_todate, int_bid);
                r = obj_dt.Rows.Count;
                string amount;
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("trantype");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add();
                obj_dt.Rows[r]["curr"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                Grid_creditNote.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                Grid_creditNote.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Other DebitNote")
            {
                r = 0;
                string custype = "P";

                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, 0, divisionid, 7);
                   // obj_dt = objInv.GetSpGetOtherDebiNoteall(dt_fromdate, dt_todate, 0, Convert.ToChar(custype), divisionid);
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, int_bid, 0, 7);
                   // obj_dt = objInv.GetSpGetOtherDebiNote(dt_fromdate, dt_todate, int_bid, Convert.ToChar(custype));
                }
                //obj_dt = objInv.GetSpGetOtherDebiNote(dt_fromdate, dt_todate, int_bid, Convert.ToChar(custype));
                r = obj_dt.Rows.Count;
                grdOtherDebitNote.Visible = true;
                DataTable dtnew = new DataTable();
                DataTable Dtemp = new DataTable();
                if (obj_dt.Rows.Count > 0)
                {
                    DataRow dataRow;
                    //   Dtemp.Columns.Add("SNo");
                    Dtemp.Columns.Add("dnno");
                    Dtemp.Columns.Add("dndate");
                    Dtemp.Columns.Add("jobno");
                    Dtemp.Columns.Add("blno");
                    Dtemp.Columns.Add("customername");
                    Dtemp.Columns.Add("amount");
                    Dtemp.Columns.Add("approvedon");
                    Dtemp.Columns.Add("fatransfer");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "customertype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "customertype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = Dtemp.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "customertype = '" + dtnew.Rows[j]["customertype"] + "' ";
                        dtLi = data1.ToTable();
                        double amount = 0; temp = 0;
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            dataRow = Dtemp.NewRow();
                            dataRow["dnno"] = dtLi.Rows[i]["dnno"];
                            dataRow["dndate"] = dtLi.Rows[i]["dndate"];
                            dataRow["jobno"] = dtLi.Rows[i]["jobno"];
                            dataRow["blno"] = dtLi.Rows[i]["blno"];
                            dataRow["customername"] = dtLi.Rows[i]["customername"];
                            dataRow["approvedon"] = dtLi.Rows[i]["approvedon"];
                            dataRow["fatransfer"] = dtLi.Rows[i]["fatransfer"];
                            string amt = "0";
                            amt = dtLi.Rows[i]["amount"].ToString();
                            if (amt == "" || amt == "0")
                            {
                                amt = "0.00";
                            }
                            dataRow["amount"] = Convert.ToDecimal(amt).ToString("#,0.00");
                            amount = amount + Convert.ToDouble(amt);
                            Dtemp.Rows.Add(dataRow);
                        }
                        dtrow = Dtemp.NewRow();
                        if (dtnew.Rows[j]["customertype"].ToString() == "P")
                        {
                            dtrow["customername"] = "Local Total";
                        }
                        else if (dtnew.Rows[j]["customertype"].ToString() == "C")
                        {
                            dtrow["customername"] = " Over Seas Total";
                        }
                        dtrow["amount"] = amount.ToString("#,0.00");
                        Dtemp.Rows.Add(dtrow);
                        total = total + amount;
                    }
                    dr["customername"] = "Total";
                    dr["amount"] = total.ToString("#,0.00");
                    Dtemp.Rows.Add(dr);
                    grdOtherDebitNote.DataSource = Dtemp;
                    ViewState["Value"] = Dtemp;
                    grdOtherDebitNote.DataBind();
                    return;
                }
                else
                {
                    grdOtherDebitNote.DataSource = "";
                  
                    grdOtherDebitNote.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "Other CreditNote")
            {
                r = 0;
                string custype = "P";

                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, 0, divisionid, 8);
                  //  obj_dt = objInv.GetSpGetOtherCrediteNoteall(dt_fromdate, dt_todate, 0, Convert.ToChar(custype), divisionid);

                }
                else
                {
                    obj_dt = objInv.GetRegdtlsLV(dt_fromdate, dt_todate, int_bid, 0,8);
                   // obj_dt = objInv.GetSpGetOtherCrediteNote(dt_fromdate, dt_todate, int_bid, Convert.ToChar(custype));
                }
                //obj_dt = objInv.GetSpGetOtherCrediteNote(dt_fromdate, dt_todate, int_bid, Convert.ToChar(custype));
                r = obj_dt.Rows.Count;
                GrdOtherCrediteNoteOpEr.Visible = true;
                DataTable dtnew = new DataTable();
                DataTable Dtemp = new DataTable();
                if (obj_dt.Rows.Count > 0)
                {
                    DataRow dataRow;
                    //   Dtemp.Columns.Add("SNo");
                    Dtemp.Columns.Add("cnno");
                    Dtemp.Columns.Add("cndate");
                    Dtemp.Columns.Add("jobno");
                    Dtemp.Columns.Add("blno");
                    Dtemp.Columns.Add("customername");
                    Dtemp.Columns.Add("amount");
                    Dtemp.Columns.Add("approvedon");
                    Dtemp.Columns.Add("fatransfer");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "customertype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "customertype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = Dtemp.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "customertype = '" + dtnew.Rows[j]["customertype"] + "' ";
                        dtLi = data1.ToTable();
                        double amount = 0; temp = 0;
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            dataRow = Dtemp.NewRow();
                            dataRow["cnno"] = dtLi.Rows[i]["cnno"];
                            dataRow["cndate"] = dtLi.Rows[i]["cndate"];
                            dataRow["jobno"] = dtLi.Rows[i]["jobno"];
                            dataRow["blno"] = dtLi.Rows[i]["blno"];
                            dataRow["customername"] = dtLi.Rows[i]["customername"];
                            dataRow["approvedon"] = dtLi.Rows[i]["approvedon"];
                            dataRow["fatransfer"] = dtLi.Rows[i]["fatransfer"];
                            string amt = "0";
                            amt = dtLi.Rows[i]["amount"].ToString();
                            if (amt == "" || amt == "0")
                            {
                                amt = "0.00";
                            }
                            dataRow["amount"] = Convert.ToDecimal(amt).ToString("#,0.00");
                            amount = amount + Convert.ToDouble(amt);
                            Dtemp.Rows.Add(dataRow);
                        }
                        dtrow = Dtemp.NewRow();
                        if (dtnew.Rows[j]["customertype"].ToString() == "P")
                        {
                            dtrow["customername"] = "Local Total";
                        }
                        else if (dtnew.Rows[j]["customertype"].ToString() == "C")
                        {
                            dtrow["customername"] = " Over Seas Total";
                        }
                        dtrow["amount"] = amount.ToString("#,0.00");
                        Dtemp.Rows.Add(dtrow);
                        total = total + amount;
                    }
                    dr["customername"] = "Total";
                    dr["amount"] = total.ToString("#,0.00");
                    Dtemp.Rows.Add(dr);
                    GrdOtherCrediteNoteOpEr.DataSource = Dtemp;
                    ViewState["Value"] = Dtemp;
                    GrdOtherCrediteNoteOpEr.DataBind();
                    return;
                }
                else
                {
                    GrdOtherCrediteNoteOpEr.DataSource = "";
                   
                    GrdOtherCrediteNoteOpEr.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Inv")
            {
                string taxamt, payamt, serviceamt, totalamt;
                double taxamt1 = 0, taxamt2 = 0, taxamt3 = 0, taxamt4 = 0;
                GrdServiceTaxInvoice.Visible = true;
                r = 0;
                DataTable dataTable = new DataTable();
                DataRow drow;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetServiceTaxInv(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetServiceTaxInv(dt_fromdate, dt_todate, int_bid);
                }
                //obj_dt = objInv.GetServiceTaxInv(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                obj_dt.Columns.Remove("trantype");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        taxamt = obj_dt.Rows[i]["nontaxamt"].ToString();
                        if (taxamt == "" || taxamt == "0")
                        {
                            taxamt = "0.00";
                        }
                        taxamt1 = taxamt1 + Convert.ToDouble(taxamt.ToString());
                        payamt = obj_dt.Rows[i]["taxamt"].ToString();
                        if (payamt == "" || payamt == "0")
                        {
                            payamt = "0.00";
                        }
                        taxamt2 = taxamt2 + Convert.ToDouble(payamt.ToString());
                        serviceamt = obj_dt.Rows[i]["stamt"].ToString();
                        if (serviceamt == "" || serviceamt == "0")
                        {
                            serviceamt = "0.00";
                        }
                        taxamt3 = taxamt3 + Convert.ToDouble(serviceamt.ToString());
                        totalamt = obj_dt.Rows[i]["amount"].ToString();
                        if (totalamt == "" || totalamt == "0")
                        {
                            totalamt = "0.00";
                        }
                        taxamt4 = taxamt4 + Convert.ToDouble(totalamt.ToString());
                    }
                }
                drow = obj_dt.NewRow();
                obj_dt.Rows.Add(drow);
                drow["billtype"] = "Total";
                drow["nontaxamt"] = taxamt1.ToString("#,0.00");
                drow["taxamt"] = taxamt2.ToString("#,0.00");
                drow["stamt"] = taxamt3.ToString("#,0.00");
                drow["amount"] = taxamt4.ToString("#,0.00");
                GrdServiceTaxInvoice.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GrdServiceTaxInvoice.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax- CN Ops")
            {
                string taxamt, payamt, serviceamt, totalamt;
                double taxamt1 = 0, taxamt2 = 0, taxamt3 = 0, taxamt4 = 0;
                grdServicesTacCnOps.Visible = true;
                r = 0;
                DataTable dataTable = new DataTable();
                DataRow drow;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetServiceTaxInvCNOps(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetServiceTaxInvCNOps(dt_fromdate, dt_todate, int_bid);
                }
                //obj_dt = objInv.GetServiceTaxInvCNOps(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                obj_dt.Columns.Remove("trantype");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        taxamt = obj_dt.Rows[i]["nontaxamt"].ToString();
                        if (taxamt == "" || taxamt == "0")
                        {
                            taxamt = "0.00";
                        }
                        taxamt1 = taxamt1 + Convert.ToDouble(taxamt.ToString());
                        payamt = obj_dt.Rows[i]["taxamt"].ToString();
                        if (payamt == "" || payamt == "0")
                        {
                            payamt = "0.00";
                        }
                        taxamt2 = taxamt2 + Convert.ToDouble(payamt.ToString());
                        serviceamt = obj_dt.Rows[i]["stamt"].ToString();
                        if (serviceamt == "" || serviceamt == "0")
                        {
                            serviceamt = "0.00";
                        }
                        taxamt3 = taxamt3 + Convert.ToDouble(serviceamt.ToString());
                        totalamt = obj_dt.Rows[i]["amount"].ToString();
                        if (totalamt == "" || totalamt == "0")
                        {
                            totalamt = "0.00";
                        }
                        taxamt4 = taxamt4 + Convert.ToDouble(totalamt.ToString());
                    }
                }
                drow = obj_dt.NewRow();
                obj_dt.Rows.Add(drow);
                drow["billtype"] = "Total";
                drow["nontaxamt"] = taxamt1.ToString("#,0.00");
                drow["taxamt"] = taxamt2.ToString("#,0.00");
                drow["stamt"] = taxamt3.ToString("#,0.00");
                drow["amount"] = taxamt4.ToString("#,0.00");
                grdServicesTacCnOps.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdServicesTacCnOps.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other DN")
            {
                grdServicesTacCnOps.Visible = true;
                grdServicesTacCnOps.Columns[0].HeaderText = "DN #";
                grdServicesTacCnOps.Columns[1].HeaderText = "DN Date";
                string taxamt, payamt, serviceamt, totalamt;
                double taxamt1 = 0, taxamt2 = 0, taxamt3 = 0, taxamt4 = 0;
                r = 0;
                string cusType = "C";
                DataTable dataTable = new DataTable();
                DataRow drow;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetServiceTaxOtherDn(dt_fromdate, dt_todate, 0, Convert.ToChar(cusType), divisionid);
                }
                else
                {
                    obj_dt = objInv.GetServiceTaxOtherDn(dt_fromdate, dt_todate, int_bid, Convert.ToChar(cusType));
                }
                //obj_dt = objInv.GetServiceTaxOtherDn(dt_fromdate, dt_todate, int_bid, Convert.ToChar(cusType));
                obj_dt.Columns.Remove("branchid");
                obj_dt.Columns.Remove("trantype");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        taxamt = obj_dt.Rows[i]["nontaxamt"].ToString();
                        if (taxamt == "" || taxamt == "0")
                        {
                            taxamt = "0.00";
                        }
                        taxamt1 = taxamt1 + Convert.ToDouble(taxamt.ToString());
                        payamt = obj_dt.Rows[i]["taxamt"].ToString();
                        if (payamt == "" || payamt == "0")
                        {
                            payamt = "0.00";
                        }
                        taxamt2 = taxamt2 + Convert.ToDouble(payamt.ToString());
                        serviceamt = obj_dt.Rows[i]["stamt"].ToString();
                        if (serviceamt == "" || serviceamt == "0")
                        {
                            serviceamt = "0.00";
                        }
                        taxamt3 = taxamt3 + Convert.ToDouble(serviceamt.ToString());
                        totalamt = obj_dt.Rows[i]["amount"].ToString();
                        if (totalamt == "" || totalamt == "0")
                        {
                            totalamt = "0.00";
                        }
                        taxamt4 = taxamt4 + Convert.ToDouble(totalamt.ToString());
                    }
                }
                drow = obj_dt.NewRow();
                obj_dt.Rows.Add(drow);
                drow["billtype"] = "Total";
                drow["nontaxamt"] = taxamt1.ToString("#,0.00");
                drow["taxamt"] = taxamt2.ToString("#,0.00");
                drow["stamt"] = taxamt3.ToString("#,0.00");
                drow["amount"] = taxamt4.ToString("#,0.00");
                grdServicesTacCnOps.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdServicesTacCnOps.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other CN")
            {
                //Str_RptName = "ServiceTaxOtherCN.rpt";
                //Str_SF = "{CNHead.cndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {CNHead.cndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {CNHead.branchid}=" + int_bid + " and {MasterCustomer.customertype}=\"C\"";
                //Str_SP = "Title=ServiceTax Other Credit Note Register for the period of " + txt_from.Text + " to " + txt_to.Text;
                grdServicesTacCnOps.Columns[0].HeaderText = "CN #";
                grdServicesTacCnOps.Columns[0].HeaderText = "DN Date";
                grdServicesTacCnOps.Visible = true;
                string taxamt, payamt, serviceamt, totalamt;
                double taxamt1 = 0, taxamt2 = 0, taxamt3 = 0, taxamt4 = 0;
                r = 0;
                string cusType = "C";
                DataTable dataTable = new DataTable();
                DataRow drow;

                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetServiceTaxOtherCnNew(dt_fromdate, dt_todate, 0, Convert.ToChar(cusType), divisionid);
                }
                else
                {
                    obj_dt = objInv.GetServiceTaxOtherCnNew(dt_fromdate, dt_todate, int_bid, Convert.ToChar(cusType));
                }
                //obj_dt = objInv.GetServiceTaxOtherCnNew(dt_fromdate, dt_todate, int_bid, Convert.ToChar(cusType));
                obj_dt.Columns.Remove("branchid");
                obj_dt.Columns.Remove("trantype");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        taxamt = obj_dt.Rows[i]["nontaxamt"].ToString();
                        if (taxamt == "" || taxamt == "0")
                        {
                            taxamt = "0.00";
                        }
                        taxamt1 = taxamt1 + Convert.ToDouble(taxamt.ToString());
                        payamt = obj_dt.Rows[i]["taxamt"].ToString();
                        if (payamt == "" || payamt == "0")
                        {
                            payamt = "0.00";
                        }
                        taxamt2 = taxamt2 + Convert.ToDouble(payamt.ToString());
                        serviceamt = obj_dt.Rows[i]["stamt"].ToString();
                        if (serviceamt == "" || serviceamt == "0")
                        {
                            serviceamt = "0.00";
                        }
                        taxamt3 = taxamt3 + Convert.ToDouble(serviceamt.ToString());
                        totalamt = obj_dt.Rows[i]["amount"].ToString();
                        if (totalamt == "" || totalamt == "0")
                        {
                            totalamt = "0.00";
                        }
                        taxamt4 = taxamt4 + Convert.ToDouble(totalamt.ToString());
                    }
                }
                drow = obj_dt.NewRow();
                obj_dt.Rows.Add(drow);
                drow["billtype"] = "Total";
                drow["nontaxamt"] = taxamt1.ToString("#,0.00");
                drow["taxamt"] = taxamt2.ToString("#,0.00");
                drow["stamt"] = taxamt3.ToString("#,0.00");
                drow["amount"] = taxamt4.ToString("#,0.00");
                grdServicesTacCnOps.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdServicesTacCnOps.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt-Bank")
            {
                grdReceiptBankReg.Visible = true;
                double amt = 0;
                string payment;
                r = 0;
                DataTable dt = new DataTable();
                DataRow datatrow;
                string mode = "B";
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetReceiptBank(dt_fromdate, dt_todate, 0, Convert.ToChar(mode), divisionid);
                }
                else
                {
                    obj_dt = objInv.GetReceiptBank(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode));
                }
                //obj_dt = objInv.GetReceiptBank(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode));
                obj_dt.Columns.Remove("divisionname");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        payment = obj_dt.Rows[i]["receiptamount"].ToString();
                        if (payment == "" || payment == "0")
                        {
                            payment = "0.00";
                        }
                        amt = amt + Convert.ToDouble(payment);
                    }
                    datatrow = obj_dt.NewRow();
                    datatrow["branch"] = "Total";
                    datatrow["receiptamount"] = amt.ToString("#,0.00");
                    obj_dt.Rows.Add(datatrow);
                }
                grdReceiptBankReg.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdReceiptBankReg.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt-Cash")
            {
                grdReceiptCashReg.Visible = true;
                double amt = 0;
                string payment;
                r = 0;
                DataTable dt = new DataTable();
                DataRow datatrow;
                string mode = "C";
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetReceiptCashNew(dt_fromdate, dt_todate, 0, Convert.ToChar(mode), divisionid);
                }
                else
                {
                    obj_dt = objInv.GetReceiptCashNew(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode));
                }
                //obj_dt = objInv.GetReceiptCashNew(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode));
                obj_dt.Columns.Remove("divisionname");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        payment = obj_dt.Rows[i]["receiptamount"].ToString();
                        if (payment == "" || payment == "0")
                        {
                            payment = "0.00";
                        }
                        amt = amt + Convert.ToDouble(payment);
                    }
                    datatrow = obj_dt.NewRow();
                    datatrow["customername"] = "Total";
                    datatrow["receiptamount"] = amt.ToString("#,0.00");
                    obj_dt.Rows.Add(datatrow);
                }
                grdReceiptCashReg.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdReceiptCashReg.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS")
            {
                grdTds.Visible = true;
                string first, second;
                double total = 0;
                r = 0;
                DataRow dr;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetTdsNewall(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetTdsNewall(dt_fromdate, dt_todate, int_bid, 0);
                }
                //obj_dt = objInv.GetTdsNew(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Add("amount");
                r = obj_dt.Rows.Count;
                obj_dt.Columns.Remove("divisionname");
                obj_dt.Columns.Remove("portname");
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        //dr = obj_dt.NewRow();
                        first = obj_dt.Rows[i]["cstamount"].ToString();
                        if (first == "" || first == "0")
                        {
                            first = "0.00";
                        }
                        second = obj_dt.Rows[i]["tdsamount"].ToString();
                        if (second == "" || second == "0")
                        {
                            second = "0.00";
                        }
                        total = Convert.ToDouble(first) - Convert.ToDouble(second);
                        obj_dt.Rows[i]["amount"] = total.ToString("#,0.00");
                        // obj_dt.Rows.Add();
                    }
                    grdTds.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    grdTds.DataBind();
                }
                else
                {
                    grdTds.DataSource = "";
                    grdTds.DataBind();
                }
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS With Type")
            {
                DataTable dtnew = new DataTable();
                r = 0;
                string first, second;
                double total = 0;
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetTdsTypeNewall(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    obj_dt = objInv.GetTdsTypeNewall(dt_fromdate, dt_todate, int_bid, 0);
                }
                //obj_dt = objInv.GetTdsTypeNew(dt_fromdate, dt_todate, int_bid);
                r = obj_dt.Rows.Count;
                grdTdsType.Visible = true;
                DataTable Dtemparary = new DataTable();
                if (obj_dt.Rows.Count > 0)
                {
                    DataRow dataRow;
                    //   Dtemp.Columns.Add("SNo");
                    Dtemparary.Columns.Add("tdsdesc");
                    Dtemparary.Columns.Add("customername");
                    Dtemparary.Columns.Add("cstamount");
                    Dtemparary.Columns.Add("tdsamount");
                    Dtemparary.Columns.Add("amount");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "tdsdesc");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "tdsdesc";
                    dtnew = dv_co.ToTable();
                    DataRow dr = Dtemparary.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "tdsdesc = '" + dtnew.Rows[j]["tdsdesc"] + "' ";
                        dtLi = data1.ToTable();
                        double amount = 0; temp = 0;
                        dataRow = Dtemparary.NewRow();
                        dataRow["tdsdesc"] = dtLi.Rows[0]["tdsdesc"];
                        Dtemparary.Rows.Add(dataRow);
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            dataRow = Dtemparary.NewRow();
                            dataRow["customername"] = dtLi.Rows[i]["customername"];
                            dataRow["cstamount"] = dtLi.Rows[i]["cstamount"];
                            dataRow["tdsamount"] = dtLi.Rows[i]["tdsamount"];
                            first = dtLi.Rows[i]["cstamount"].ToString();
                            if (first == "" || first == "0")
                            {
                                first = "0.00";
                            }
                            second = dtLi.Rows[i]["tdsamount"].ToString();
                            if (second == "" || second == "0")
                            {
                                second = "0.00";
                            }
                            total = Convert.ToDouble(first) - Convert.ToDouble(second);
                            dataRow["amount"] = total.ToString("#,0.00");
                            Dtemparary.Rows.Add(dataRow);
                        }
                    }
                    grdTdsType.DataSource = Dtemparary;
                    ViewState["Value"] = Dtemparary;
                    grdTdsType.DataBind();
                    return;
                }
                else
                {
                    grdTdsType.DataSource = "";
                   
                    grdTdsType.DataBind();
                    return;
                }
                
            }
            else if (ddlSelect.SelectedItem.Text == "Payment-Bank")
            {
                string mode = "B";
                r = 0;
                GrdPayForBank.Visible = true;

                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetPaymentForBank(dt_fromdate, dt_todate, 0, Convert.ToChar(mode), int_divisionid);

                }
                else
                {
                    obj_dt = objInv.GetPaymentForBank(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode), 0);
                }
                //obj_dt = objInv.GetPaymentForBank(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode), int_divisionid);
                r = obj_dt.Rows.Count;
                obj_dt.Columns.Remove("divisionname");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("deleted");
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["paymentamount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["chequedate"] = "Total";
                obj_dt.Rows[r]["paymentamount"] = total.ToString("#,0.00");
                GrdPayForBank.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GrdPayForBank.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Payment-Cash")
            {
                string mode = "C";
                r = 0;
                grdPaymentCashNew.Visible = true;

                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetPaymentcashNew(dt_fromdate, dt_todate, divisionid, Convert.ToChar(mode));
                }
                else
                {
                    obj_dt = objInv.GetPaymentcashNew(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode));
                }
                //obj_dt = objInv.GetPaymentcashNew(dt_fromdate, dt_todate, int_bid, Convert.ToChar(mode));
                obj_dt.Columns.Remove("divisionname");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["paymentamount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["paymentamount"] = total.ToString("#,0.00");
                grdPaymentCashNew.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdPaymentCashNew.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-Inv,DN")
            {
                txt_charge.Enabled = true;
                GridView1.Visible = true;
                costtempobj.DelChargeWSTNewManoj(int_Empid);
                if (hid_chargeid.Value == "" || hid_chargeid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Revenue", "alertify.alert('Please Enter Charge Name');", true);
                    txt_charge.Focus();
                    return;
                }
                if (ddl_branch.Text == "CORPORATE")
                {
                    costtempobj.InsChargeWSTIncNewManoj(dt_fromdate, dt_todate, int_divisionid, Convert.ToInt32(hid_chargeid.Value), int_Empid, "D");
                }
                else
                {
                    costtempobj.InsChargeWSTIncNewManoj(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(hid_chargeid.Value), int_Empid, "B");
                }
                r = 0;
                obj_dt = objInv.GetSTLedgerwiseCNOps(int_Empid);
                obj_dt.Columns.Remove("chargename");
                obj_dt.Columns.Remove("address");
                obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("shortname");
                obj_dt.Columns.Remove("userid");
                r = obj_dt.Rows.Count;
                obj_dt.Columns.Add("total");
                DataRow dt;
                string amount, count, tot;
                double maxamt = 0, total1 = 0, max = 0;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                        count = obj_dt.Rows[i]["stamt"].ToString();
                        if (count == "" || count == "0")
                        {
                            count = "0.0";
                        }
                        total1 = total1 + Convert.ToDouble(count.ToString());
                        maxamt = Convert.ToDouble(amount) + Convert.ToDouble(count);
                        obj_dt.Rows[i]["total"] = maxamt.ToString("#,0.00");
                        tot = obj_dt.Rows[i]["total"].ToString();
                        max = max + Convert.ToDouble(tot);
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                obj_dt.Rows[r]["stamt"] = total1.ToString("#,0.00");
                obj_dt.Rows[r]["total"] = max.ToString("#,0.00");
                GridView1.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GridView1.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-CNOps,CN")
            {
                txt_charge.Enabled = true;
                GridView1.Visible = true;
                costtempobj.DelChargeWSTNewManoj(int_Empid);
                if (hid_chargeid.Value == "" || hid_chargeid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btn_print, typeof(Button), "Revenue", "alertify.alert('Please Enter Charge Name');", true);
                    txt_charge.Focus();
                    return;
                }
                if (ddl_branch.Text == "CORPORATE")
                {
                    costtempobj.InsChargeWSTExpNewManoj(dt_fromdate, dt_todate, int_divisionid, Convert.ToInt32(hid_chargeid.Value), int_Empid, "D");
                }
                else
                {
                    costtempobj.InsChargeWSTExpNewManoj(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(hid_chargeid.Value), int_Empid, "B");
                }
                r = 0;
                obj_dt = objInv.GetSTLedgerwiseCNOps(int_Empid);
                obj_dt.Columns.Remove("chargename");
                obj_dt.Columns.Remove("address");
                obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("shortname");
                obj_dt.Columns.Remove("userid");
                r = obj_dt.Rows.Count;
                obj_dt.Columns.Add("total");
                DataRow dt;
                string amount, count, tot;
                double maxamt = 0, total1 = 0, max = 0;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                        count = obj_dt.Rows[i]["stamt"].ToString();
                        if (count == "" || count == "0")
                        {
                            count = "0.0";
                        }
                        total1 = total1 + Convert.ToDouble(count.ToString());
                        maxamt = Convert.ToDouble(amount) + Convert.ToDouble(count);
                        obj_dt.Rows[i]["total"] = maxamt.ToString("#,0.00");
                        tot = obj_dt.Rows[i]["total"].ToString();
                        max = max + Convert.ToDouble(tot);
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                obj_dt.Rows[r]["stamt"] = total1.ToString("#,0.00");
                obj_dt.Rows[r]["total"] = max.ToString("#,0.00");
                GridView1.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GridView1.DataBind();
                return;
            }
            //else if (ddlSelect.SelectedItem.Text == "Proforma Sales Inv")
            //{
            //    //Str_RptName = "ProInvRegister.rpt";
            //    //Str_SF = "{ACProInvoiceHead.invoicedate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACProInvoiceHead.invoicedate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACProInvoiceHead.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma Invoice Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    grdProformaInv.Visible = true;
            //    r = 0;
            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.ProformaInvNew(dt_fromdate, dt_todate, 0, divisionid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.ProformaInvNew(dt_fromdate, dt_todate, int_bid);
            //    }
            //    //obj_dt = objInv.ProformaInvNew(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //    obj_dt.Columns.Remove("trantype");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount;
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    grdProformaInv.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdProformaInv.DataBind();
            //    return;
            //}
            //else if (ddlSelect.SelectedItem.Text == "Proforma Purchase Inv")
            //{
            //    //Str_RptName = "Pro PA Register.rpt";
            //    //Str_SF = "{ACProPAHead.padate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACProPAHead.padate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACProPAHead.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma Credit Note - Operations Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    grdProformaInv.Columns[0].HeaderText = "Performa CN-Ops #";
            //    grdProformaInv.Columns[6].HeaderText = "Actual CN-Ops #";
            //    grdProformaInv.Visible = true;
            //    r = 0;

            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.ProformaCNOperations(dt_fromdate, dt_todate, 0, divisionid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.ProformaCNOperations(dt_fromdate, dt_todate, int_bid);
            //    }
            //    //obj_dt = objInv.ProformaCNOperations(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //    obj_dt.Columns.Remove("trantype");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount;
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    grdProformaInv.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdProformaInv.DataBind();
            //    return;
            //}
            //else if (ddlSelect.SelectedItem.Text == "Proforma OSDN")
            //{
            //    //Str_RptName = "Pro OSDN Register.rpt";
            //    //Str_SF = "{ACOSDNPro.dndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACOSDNPro.dndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACOSDNPro.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma OSDN Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    r = 0;
            //    grdPerformaOsDN.Visible = true;
            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.GetPerformaOSDN(dt_fromdate, dt_todate, 0, divisionid);
            //        //obj_dt = objInv.GetPerformaOSDN(dt_fromdate, dt_todate, int_bid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.GetPerformaOSDN(dt_fromdate, dt_todate, int_bid);

            //    }
            //    //obj_dt = objInv.GetPerformaOSDN(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //   // obj_dt.Columns.Remove("trantype");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount, amount1;
             
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            amount1 = obj_dt.Rows[i]["localamount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //                amount1="0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //            total1 = total1 + Convert.ToDouble(amount1.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    obj_dt.Rows[r]["localamount"] = total1.ToString("#,0.00");
            //    grdPerformaOsDN.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdPerformaOsDN.DataBind();
            //    return;
            //}
            //else if (ddlSelect.SelectedItem.Text == "Proforma OSCN")
            //{
            //    //Str_RptName = "Pro OSCN Register.rpt";
            //    //Str_SF = "{ACOSCNPro.cndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACOSCNPro.cndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACOSCNPro.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma OSCN Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    r = 0;
            //    grdOsCNNew.Visible = true;
            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.GetPerformaOSCN(dt_fromdate, dt_todate, 0, divisionid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.GetPerformaOSCN(dt_fromdate, dt_todate, int_bid);
            //    }
            //    //obj_dt = objInv.GetPerformaOSCN(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //    //obj_dt.Columns.Remove("trantype");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount, amount1;
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            amount1 = obj_dt.Rows[i]["localamount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //                amount1 = "0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //            total1 = total1 + Convert.ToDouble(amount1.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    obj_dt.Rows[r]["localamount"] = total1.ToString("#,0.00");
            //    grdOsCNNew.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdOsCNNew.DataBind();
            //    return;
            //}
            //else if (ddlSelect.SelectedItem.Text == "Proforma Other DN")
            //{
            //    //Str_RptName = "Pro OtherDN Register.rpt";grdProformaInv
            //    //Str_SF = "{ACProDNHead.dndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACProDNHead.dndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACProDNHead.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma Other DebitNote Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    grdProformaInv.Columns[0].HeaderText = "Performa DN-Ops #";
            //    grdProformaInv.Columns[6].HeaderText = "Actual DN-Ops #";
            //    grdProformaInv.Visible = true;
            //    r = 0;

            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.GetPerformaOtherDnNew(dt_fromdate, dt_todate, 0, divisionid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.GetPerformaOtherDnNew(dt_fromdate, dt_todate, int_bid);
            //    }
            //    //obj_dt = objInv.GetPerformaOtherDnNew(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //    obj_dt.Columns.Remove("trantype");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount;
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    grdProformaInv.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdProformaInv.DataBind();
            //    return;
            //}
            //else if (ddlSelect.SelectedItem.Text == "Proforma Other CN")
            //{
            //    //Str_RptName = "Pro OtherCN Register.rpt";
            //    //Str_SF = "{ACProCNHead.cndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACProCNHead.cndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACProCNHead.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma Other CreditNote Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    grdProformaInv.Columns[0].HeaderText = "Performa CN-Ops #";
            //    grdProformaInv.Columns[6].HeaderText = "Actual CN-Ops #";
            //    grdProformaInv.Visible = true;
            //    r = 0;
            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.GetProOtherCnRegister(dt_fromdate, dt_todate, 0, divisionid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.GetProOtherCnRegister(dt_fromdate, dt_todate, int_bid);

            //    }
            //    //obj_dt = objInv.GetProOtherCnRegister(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //    obj_dt.Columns.Remove("trantype");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount;
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    grdProformaInv.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdProformaInv.DataBind();
            //    return;
            //}
            //else if (ddlSelect.SelectedItem.Text == "Proforma CN-Admin")
            //{
            //    //Str_RptName = "ProPA Admin Register.rpt";
            //    //Str_SF = "{ACProAdminCNHead.cndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACProAdminCNHead.cndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACProAdminCNHead.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma  Credit Note-Admin Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    grdPerformaOsDN.Columns[0].HeaderText = "Performa CN Adm #";
            //    grdPerformaOsDN.Columns[2].HeaderText = "Ref #";
            //    grdPerformaOsDN.Columns[5].HeaderText = "Actual CN Adm #";
            //    grdPerformaOsDN.Visible = true;
            //    r = 0;
            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.GEtProProformaCNAdminNew(dt_fromdate, dt_todate, 0, divisionid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.GEtProProformaCNAdminNew(dt_fromdate, dt_todate, int_bid);
            //    }
            //    //obj_dt = objInv.GEtProProformaCNAdminNew(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount;
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    grdPerformaOsDN.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdPerformaOsDN.DataBind();
            //    return;
            //}
            //else if (ddlSelect.SelectedItem.Text == "Proforma DN-Admin")
            //{
            //    //Str_RptName = "ProDNadminregister.rpt";
            //    //Str_SF = "{ACProAdminDNHead.dndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACProAdminDNHead.dndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACProAdminDNHead.branchid}=" + int_bid;
            //    //Str_SP = "Title=Proforma  DebitNote-Admin Register for the period of " + txt_from.Text + " to " + txt_to.Text;
            //    grdPerformaOsDN.Columns[0].HeaderText = "Performa DN Adm #";
            //    grdPerformaOsDN.Columns[2].HeaderText = "Ref #";
            //    grdPerformaOsDN.Columns[5].HeaderText = "Actual DN Adm #";
            //    grdPerformaOsDN.Columns[5].HeaderText = "Actual DN Adm #";
            //    grdPerformaOsDN.Visible = true;
            //    r = 0;
            //    if (chkConsolidate.Checked == true)
            //    {
            //        obj_dt = objInv.GEtProProformaDNAdminNew(dt_fromdate, dt_todate, 0, divisionid);
            //    }
            //    else
            //    {
            //        obj_dt = objInv.GEtProProformaDNAdminNew(dt_fromdate, dt_todate, int_bid);
            //    }
            //    //obj_dt = objInv.GEtProProformaDNAdminNew(dt_fromdate, dt_todate, int_bid);
            //    obj_dt.Columns.Remove("branchid");
            //    obj_dt.Columns.Remove("portname");
            //    obj_dt.Columns.Remove("branchname");
            //    obj_dt.Columns.Remove("deleted");
            //    r = obj_dt.Rows.Count;
            //    string amount;
            //    if (obj_dt.Rows.Count > 0)
            //    {
            //        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
            //        {
            //            amount = obj_dt.Rows[i]["amount"].ToString();
            //            if (amount == "" || amount == "0")
            //            {
            //                amount = "0.0";
            //            }
            //            total = total + Convert.ToDouble(amount.ToString());
            //        }
            //    }
            //    dtrow = obj_dt.NewRow();
            //    obj_dt.Rows.Add(dtrow);
            //    obj_dt.Rows[r]["customername"] = "Total";
            //    obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
            //    grdPerformaOsDN.DataSource = obj_dt;
            //    ViewState["Value"] = obj_dt;
            //    grdPerformaOsDN.DataBind();
            //    return;
            //}


                // new fro pro amd pro pending --sindhu 14122020

            else if (ddlSelect.SelectedItem.Text == "Proforma Sales Inv")
            {

                
                grdProformaInv.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]),1);
                  //  obj_dt = objInv.ProformaInvNew(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]), 1);
                   // obj_dt = objInv.ProformaInvNew(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = false;
                }
                obj_dt.Columns.Remove("branchid");
                //  obj_dt.Columns.Remove("portname");
               // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdProformaInv.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdProformaInv.DataBind();
                return;
            }



            else if (ddlSelect.SelectedItem.Text == "Proforma Sales Inv Pending")
            {

                
                grd_pending.Visible = true;
                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                lbl_from.Visible = false;
                lbl_to.Visible = false;

                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.ProformaInvPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = true;
                    grd_pending.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.ProformaInvPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = false;
                    grd_pending.Columns[2].Visible = true;
                }
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
                // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grd_pending.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pending.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Purchase Inv")
            {

               
                grdProformaInv.Columns[1].HeaderText = "Proforma CN-Ops #";
                grdProformaInv.Columns[7].HeaderText = "Actual CN-Ops #";
                grdProformaInv.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]), 2);
                   // obj_dt = objInv.ProformaCNOperationsnew(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = true;


                }
                else
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]), 2);
                  //  obj_dt = objInv.ProformaCNOperationsnew(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = false;

                }
               // obj_dt = objInv.ProformaCNOperations(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
              //  obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdProformaInv.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdProformaInv.DataBind();
                return;
            }

            else if (ddlSelect.SelectedItem.Text == "Proforma Purchase Inv Pending")
            {
                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                lbl_from.Visible = false;
                lbl_to.Visible = false;
               
                grd_pending.Columns[1].HeaderText = "Proforma CN-Ops #";

                grd_pending.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.ProformaCNOperationsPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = true;
                    grd_pending.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.ProformaCNOperationsPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = false;
                    grd_pending.Columns[2].Visible = true;
                }
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
              // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grd_pending.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pending.DataBind();
                return;
            }
           
            else if (ddlSelect.SelectedItem.Text == "Proforma OSSI")
            {
               
                r = 0;
                grdPerformaOsDN.Visible = true;

                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]), 5);
                  //  obj_dt = objInv.GetPerformaOSDNnew1(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    grdPerformaOsDN.Columns[0].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]), 5);
                   // obj_dt = objInv.GetPerformaOSDNnew1(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    grdPerformaOsDN.Columns[0].Visible = false;
                }
                //obj_dt = objInv.GetPerformaOSDN(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                // obj_dt.Columns.Remove("portname");
                // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount, amount1;

                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        amount1 = obj_dt.Rows[i]["localamount"].ToString();
                        if (amount == "" || amount == "0" || amount=="Null")
                        {
                            amount = "0.0";
                            amount1 = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                        total1 = total1 + Convert.ToDouble(amount1.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                obj_dt.Rows[r]["localamount"] = total1.ToString("#,0.00");
                grdPerformaOsDN.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdPerformaOsDN.DataBind();
                return;
            }

            else if (ddlSelect.SelectedItem.Text == "Proforma OSSI Pending")
            {
                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                lbl_from.Visible = false;
                lbl_to.Visible = false;
                r = 0;
                grd_pend.Visible = true;
                // grd_pending.Columns.RemoveAt(3);

                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetPerformaOSDNPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = true;
                    grd_pend.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GetPerformaOSDNPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = false;
                    grd_pend.Columns[2].Visible = true;
                }
                //obj_dt = objInv.GetPerformaOSDN(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
              // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("blno");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;//, amount1;

                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        //  amount1 = obj_dt.Rows[i]["localamount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                            //    amount1 = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                        //  total1 = total1 + Convert.ToDouble(amount1.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                // obj_dt.Rows[r]["localamount"] = total1.ToString("#,0.00");
                grd_pend.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pend.DataBind();
                return;
            }

          
            else if (ddlSelect.SelectedItem.Text == "Proforma OSPI")
            {
               
                r = 0;
                grdOsCNNew.Visible = true;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]), 6);
                  //  obj_dt = objInv.GetPerformaOSCNnew(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    grdOsCNNew.Columns[0].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]), 6);
                  //  obj_dt = objInv.GetPerformaOSCNnew(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    grdOsCNNew.Columns[0].Visible = false;
                }
                //obj_dt = objInv.GetPerformaOSCN(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
               // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount, amount1;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        amount1 = obj_dt.Rows[i]["localamount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                            amount1 = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                        total1 = total1 + Convert.ToDouble(amount1.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                obj_dt.Rows[r]["localamount"] = total1.ToString("#,0.00");
                grdOsCNNew.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdOsCNNew.DataBind();
                return;
            }

            else if (ddlSelect.SelectedItem.Text == "Proforma OSPI Pending")
            {
                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                lbl_from.Visible = false;
                lbl_to.Visible = false;
                r = 0;
                grd_pend.Visible = true;
                // grd_pending.Columns.RemoveAt(3);

                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetPerformaOSCNPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = true;
                    grd_pend.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GetPerformaOSCNPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = false;
                    grd_pend.Columns[2].Visible = true;
                }

                //obj_dt = objInv.GetPerformaOSCN(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
             //   obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                obj_dt.Columns.Remove("blno");
                r = obj_dt.Rows.Count;
                string amount, amount1;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        // amount1 = obj_dt.Rows[i]["localamount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                            // amount1 = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                        //total1 = total1 + Convert.ToDouble(amount1.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                //obj_dt.Rows[r]["localamount"] = total1.ToString("#,0.00");
                grd_pend.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pend.DataBind();
                return;
            }

            else if (ddlSelect.SelectedItem.Text == "Proforma Other DN")
            {

                
                grdProformaInv.Columns[1].HeaderText = "Proforma DN-Ops #";
                grdProformaInv.Columns[7].HeaderText = "Actual DN-Ops #";
                grdProformaInv.Visible = true;
                r = 0;

                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]), 7);
                 //   obj_dt = objInv.GetPerformaOtherDnNew1(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = true;

                }
                else
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]), 7);
                   // obj_dt = objInv.GetPerformaOtherDnNew1(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = false;

                }

                obj_dt.Columns.Remove("branchid");
                // obj_dt.Columns.Remove("portname");
               // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdProformaInv.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdProformaInv.DataBind();
                return;

            }

            else if (ddlSelect.SelectedItem.Text == "Proforma Other DN Pending")
            {
                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                lbl_from.Visible = false;
                lbl_to.Visible = false;
                grd_pending.Columns[1].HeaderText = "Proforma DN-Ops #";

                grd_pending.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetPerformaOtherDnPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = true;
                    grd_pending.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GetPerformaOtherDnPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = false;
                    grd_pending.Columns[2].Visible = true;
                }
                obj_dt.Columns.Remove("branchid");
                // obj_dt.Columns.Remove("portname");
            // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grd_pending.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pending.DataBind();
                return;

            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other CN")
            {

                
                grdProformaInv.Columns[1].HeaderText = "Proforma CN-Ops #";
                grdProformaInv.Columns[7].HeaderText = "Actual CN-Ops #";
                grdProformaInv.Visible = true;
                r = 0;

                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]), 8);
                   // obj_dt = objInv.GetProOtherCnRegisternew(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = true;

                }
                else
                {
                    obj_dt = objInv.GetRegdtlsProLV(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]), 8);
                   // obj_dt = objInv.GetProOtherCnRegisternew(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdProformaInv.Columns[0].Visible = false;

                }

                obj_dt.Columns.Remove("branchid");
                //   obj_dt.Columns.Remove("portname");
                // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdProformaInv.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdProformaInv.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other CN Pending")
            {
                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                lbl_from.Visible = false;
                lbl_to.Visible = false;
               
                grd_pending.Columns[1].HeaderText = "Proforma CN-Ops #";
                //grdProformaInv.Columns[6].HeaderText = "Actual CN-Ops #";
                grd_pending.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GetProOtherCnRegisterPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = true;
                    grd_pending.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GetProOtherCnRegisterPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pending.Columns[0].Visible = false;
                    grd_pending.Columns[2].Visible = true;
                }
                // obj_dt = objInv.GetProOtherCnRegisterPending(int_bid);
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
               // obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }

                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grd_pending.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pending.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma CN-Admin")
            {
                //Str_RptName = "ProPA Admin Register.rpt";
                //Str_SF = "{ACProAdminCNHead.cndate}>=date(\"" + dt_fromdate.Year + "," + dt_fromdate.Month + "," + dt_fromdate.Day + "\") and {ACProAdminCNHead.cndate}<=date(\"" + dt_todate.Year + "," + dt_todate.Month + "," + dt_todate.Day + "\")  and {ACProAdminCNHead.branchid}=" + int_bid;
                //Str_SP = "Title=Proforma  Credit Note-Admin Register for the period of " + txt_from.Text + " to " + txt_to.Text;
                grdprofomaAdminDNCN.Columns[1].HeaderText = "Proforma CN Adm #";
                // grdprofomaAdminDNCN.Columns[2].HeaderText = "Ref #";
                grdprofomaAdminDNCN.Columns[6].HeaderText = "Actual CN Adm #";
                grdprofomaAdminDNCN.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GEtProProformaCNAdminNew1(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdprofomaAdminDNCN.Columns[0].Visible = true;
                    grdprofomaAdminDNCN.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GEtProProformaCNAdminNew1(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdprofomaAdminDNCN.Columns[0].Visible = false;
                    grdprofomaAdminDNCN.Columns[2].Visible = true;
                }
                //if (chkConsolidate.Checked == true)
                //{
                //    obj_dt = objInv.GEtProProformaCNAdminNew(dt_fromdate, dt_todate, 0, divisionid);
                //}
                //else
                //{
                //    obj_dt = objInv.GEtProProformaCNAdminNew(dt_fromdate, dt_todate, int_bid);
                //}
                //  obj_dt = objInv.GEtProProformaCNAdminNew(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdprofomaAdminDNCN.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdprofomaAdminDNCN.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma DN-Admin")
            {
                
                grdprofomaAdminDNCN.Columns[1].HeaderText = "Proforma DN Adm #";
                
                grdprofomaAdminDNCN.Columns[6].HeaderText = "Actual DN Adm #";
                grdprofomaAdminDNCN.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GEtProProformaDNAdminNew1(dt_fromdate, dt_todate, 0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdprofomaAdminDNCN.Columns[0].Visible = true;
                    grdprofomaAdminDNCN.Columns[2].Visible = true;
                }
                else
                {
                    obj_dt = objInv.GEtProProformaDNAdminNew1(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grdprofomaAdminDNCN.Columns[0].Visible = false;
                    grdprofomaAdminDNCN.Columns[2].Visible = true;
                }
               
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grdprofomaAdminDNCN.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grdprofomaAdminDNCN.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma CN-Admin Pending")
            {
                lbl_from.Visible = false;
                lbl_to.Visible = false;
                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                
                grd_pend.Columns[1].HeaderText = "Proforma CN Adm #";
              
                grd_pend.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GEtProProformaCNAdminPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = true;
                    grd_pend.Columns[2].Visible = false;
                }
                else
                {
                    obj_dt = objInv.GEtProProformaCNAdminPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = false;
                    grd_pend.Columns[2].Visible = false;
                }
                
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchname");
                
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grd_pend.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pend.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma DN-Admin Pending")
            {
                lbl_from.Visible = false;
                lbl_to.Visible = false;

                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
               
                grd_pend.Columns[1].HeaderText = "Proforma DN Adm #";
                //  grd_pending.Columns.RemoveAt(3);
                //grdprofomaAdminDNCN.Columns[2].HeaderText = "Ref #";
                //grdprofomaAdminDNCN.Columns[5].HeaderText = "Actual DN Adm #";
                // grdprofomaAdminDNCN.Columns[5].HeaderText = "Actual DN Adm #";
                grd_pend.Visible = true;
                r = 0;
                if (ddl_branch.Text == "CORPORATE" || ddl_branch.Text == "ALL")
                {
                    obj_dt = objInv.GEtProProformaDNAdminPending(0, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = true;
                    grd_pend.Columns[2].Visible = false;
                }
                else
                {
                    obj_dt = objInv.GEtProProformaDNAdminPending(int_bid, Convert.ToInt32(Session["LoginDivisionId"]));
                    grd_pend.Columns[0].Visible = false;
                    grd_pend.Columns[2].Visible = false;
                }
                
                obj_dt.Columns.Remove("branchid");
                //obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("deleted");
                r = obj_dt.Rows.Count;
                string amount;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        amount = obj_dt.Rows[i]["amount"].ToString();
                        if (amount == "" || amount == "0")
                        {
                            amount = "0.0";
                        }
                        total = total + Convert.ToDouble(amount.ToString());
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add(dtrow);
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                grd_pend.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                grd_pend.DataBind();
                return;
            }



















            else if (ddlSelect.SelectedItem.Text == "Reversal Billing")
            {
                GrdInterBranch.Visible = true;
                if (int_bid == 0)
                {
                    costtempobj.InsTempReversalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_divisionid, "D");
                }
                else
                {
                    costtempobj.InsTempReversalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_bid, "B");
                }
                DataTable dtnew = new DataTable();
                obj_dt = objInv.GetInterBilling(int_Empid, int_divisionid);
                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    DataTable Dtemp = new DataTable();
                    DataRow dataRow;
                    //   Dtemp.Columns.Add("SNo");
                    Dtemp.Columns.Add("vouno");
                    Dtemp.Columns.Add("voudate");
                    Dtemp.Columns.Add("voutype");
                    Dtemp.Columns.Add("trantype");
                    Dtemp.Columns.Add("jobno");
                    Dtemp.Columns.Add("blno");
                    Dtemp.Columns.Add("customername");
                    Dtemp.Columns.Add("amount");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "voutype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "voutype";
                    dtnew = dv_co.ToTable();
                    DataRow dr = Dtemp.NewRow();
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "voutype = '" + dtnew.Rows[j]["voutype"] + "' ";
                        dtLi = data1.ToTable();
                        double amount = 0; temp = 0;
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            dataRow = Dtemp.NewRow();
                            string amt = "0";
                            dataRow["vouno"] = dtLi.Rows[i]["vouno"];
                            dataRow["voudate"] = dtLi.Rows[i]["voudate"];
                            dataRow["voutype"] = dtLi.Rows[i]["voutype"];
                            if (dtLi.Rows[i]["trantype"] == "FE")
                            {
                                dataRow["trantype"] = "OE";
                            }
                            else if (dtLi.Rows[i]["trantype"] == "FI")
                            {
                                dataRow["trantype"] = "OI";
                            }
                            else
                            {
                                dataRow["trantype"] = dtLi.Rows[i]["trantype"];
                            }
                            dataRow["jobno"] = dtLi.Rows[i]["jobno"];
                            dataRow["blno"] = dtLi.Rows[i]["blno"];
                            dataRow["customername"] = dtLi.Rows[i]["customername"];
                            amt = dtLi.Rows[i]["amount"].ToString();
                            if (amt == "" || amt == "0")
                            {
                                amt = "0.00";
                            }
                            dataRow["amount"] = Convert.ToDecimal(amt).ToString("#,0.00");
                            amount = amount + Convert.ToDouble(amt.ToString());
                            Dtemp.Rows.Add(dataRow);
                        }
                        dtrow = Dtemp.NewRow();
                        dtrow["customername"] = "Total";
                        dtrow["amount"] = amount.ToString("#0.00");
                        Dtemp.Rows.Add(dtrow);
                        total = total + amount;
                    }
                    //DataTable dt12 = new DataTable();
                    //dt12 = Dtemp;
                    dtrow = Dtemp.NewRow();
                    if (int_bid == 0)
                    {
                        dtrow["customername"] = "Grand Total";
                    }
                    else
                    {
                        dtrow["customername"] = obj_dt.Rows[0]["shortname"].ToString();
                    }
                    dtrow["amount"] = total.ToString("#,0.00");
                    Dtemp.Rows.Add(dtrow);
                    GrdInterBranch.DataSource = Dtemp;
                    ViewState["Value"] = Dtemp;
                    GrdInterBranch.DataBind();
                    return;
                }
                else
                {
                    GrdInterBranch.DataSource = "";
                  
                    GrdInterBranch.DataBind();
                }
            }  //------------ Karthika_K           
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-PA")
            {
                DataTable dtServiceTax = new DataTable();
                double Amount = 0.00, Total_Amount = 0.00, taxamt = 0.00, Total_taxamt = 0.00, nontaxamt = 0.00, Total_nontaxamt = 0.00, stamt = 0.00, Total_stamt = 0.00;
                if (chkConsolidate.Checked == true)
                {
                    dtServiceTax = objInv.fn_ServiceTaxPA(dt_fromdate, dt_todate, 0, divisionid);
                }
                else
                {
                    dtServiceTax = objInv.fn_ServiceTaxPA(dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                }

                //dtServiceTax = objInv.fn_ServiceTaxPA(dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                Grd_ServiceTaxPA.Visible = true;
                if (dtServiceTax.Rows.Count > 0)
                {
                    for (i = 0; i <= dtServiceTax.Rows.Count - 1; i++)
                    {
                        if (dtServiceTax.Rows[i]["taxamt"].ToString() != "")
                        {
                            taxamt = Convert.ToDouble(dtServiceTax.Rows[i]["taxamt"].ToString());
                        }
                        else
                        {
                            taxamt = 0.00;
                        }
                        Total_taxamt = Total_taxamt + Convert.ToDouble(taxamt.ToString());
                        if (dtServiceTax.Rows[i]["nontaxamt"].ToString() != "")
                        {
                            nontaxamt = Convert.ToDouble(dtServiceTax.Rows[i]["nontaxamt"].ToString());
                        }
                        else
                        {
                            nontaxamt = 0.00;
                        }
                        Total_nontaxamt = Total_nontaxamt + Convert.ToDouble(nontaxamt.ToString());
                        if (dtServiceTax.Rows[i]["stamt"].ToString() != "")
                        {
                            stamt = Convert.ToDouble(dtServiceTax.Rows[i]["stamt"].ToString());
                        }
                        else
                        {
                            stamt = 0.00;
                        }
                        Total_stamt = Total_stamt + Convert.ToDouble(stamt.ToString());
                        if (dtServiceTax.Rows[i]["amount"].ToString() != "")
                        {
                            Amount = Convert.ToDouble(dtServiceTax.Rows[i]["amount"].ToString());
                        }
                        else
                        {
                            Amount = 0.00;
                        }
                        Total_Amount = Total_Amount + Convert.ToDouble(Amount.ToString());
                    }
                }
                DataTable dtTotal = new DataTable();
                dtTotal = dtServiceTax;
                DataRow drow = dtTotal.NewRow();
                drow["customername"] = "Total";
                drow["taxamt"] = string.Format("{0:#,##0.00}", Total_taxamt);
                drow["nontaxamt"] = string.Format("{0:#,##0.00}", Total_nontaxamt);
                drow["stamt"] = string.Format("{0:#,##0.00}", Total_stamt);
                drow["amount"] = string.Format("{0:#,##0.00}", Total_Amount);
                dtTotal.Rows.Add(drow);
                Grd_ServiceTaxPA.DataSource = dtServiceTax;
                Grd_ServiceTaxPA.DataBind();
                ViewState["ServiceTax-PA"] = dtServiceTax;
                ViewState["Value"] = dtServiceTax;
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-PA,CN")
            {
                DataTable dtstCharge = new DataTable();

                costtempobj.InsSTChargewise(Convert.ToInt32(Session["LoginBranchid"].ToString()), vouyear, Convert.ToInt32(Session["LoginEmpId"].ToString()), dt_fromdate, dt_todate, "Exp");
                dtstCharge = objInv.fn_STChargewise_PACN(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                Grd_StCharge.Visible = true;
                Grd_StCharge.DataSource = dtstCharge;
                Grd_StCharge.DataBind();
                ViewState["STChargewise-PA,CN"] = dtstCharge;
                ViewState["Value"] = dtstCharge;
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-AdminPA")
            {
                double amount = 0.00, Total_amount = 0.00;
                if (hid_chargeid.Value != "")
                {
                    costtempobj.DelChargeWST(Convert.ToInt32(Session["LoginEmpId"].ToString()));

                    costtempobj.InsChargeWSTExp(dt_fromdate, dt_todate, branchid, Convert.ToInt32(hid_chargeid.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    DataTable dtLedgerwise_AdminPA = new DataTable();
                    dtLedgerwise_AdminPA = objInv.fn_Ledgerwise_AdminPA(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    if (dtLedgerwise_AdminPA.Rows.Count > 0)
                    {
                        for (i = 0; i <= dtLedgerwise_AdminPA.Rows.Count - 1; i++)
                        {
                            if (dtLedgerwise_AdminPA.Rows[i]["amount"].ToString() != "")
                            {
                                amount = Convert.ToDouble(dtLedgerwise_AdminPA.Rows[i]["amount"].ToString());
                            }
                            else
                            {
                                amount = 0.00;
                            }
                            Total_amount = Total_amount + Convert.ToDouble(amount.ToString());
                        }
                    }
                    DataTable dtTotal = new DataTable();
                    dtTotal = dtLedgerwise_AdminPA;
                    DataRow drow = dtTotal.NewRow();
                    drow["billtype"] = "Total";
                    drow["amount"] = string.Format("{0:#,##0.00}", Total_amount);
                    dtTotal.Rows.Add(drow);
                    Grd_AdminPA.Visible = true;
                    Grd_AdminPA.DataSource = dtLedgerwise_AdminPA;
                    Grd_AdminPA.DataBind();
                    ViewState["Ledgerwise-AdminPA"] = dtLedgerwise_AdminPA;
                    ViewState["Value"] = dtLedgerwise_AdminPA;
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter the Charge Name')", true);
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-AdminDN")
            {
                double Total_amount = 0.00, amount = 0.00;
                if (hid_chargeid.Value != "")
                {
                    costtempobj.DelChargeWST(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    costtempobj.InsChargeWSTInc(dt_fromdate, dt_todate, branchid, Convert.ToInt32(hid_chargeid.Value), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    DataTable dtLedgerwise_AdminDN = new DataTable();
                    dtLedgerwise_AdminDN = objInv.fn_Ledgerwise_AdminDN(Convert.ToInt32(Session["LoginEmpId"].ToString()));
                    if (dtLedgerwise_AdminDN.Rows.Count > 0)
                    {
                        for (i = 0; i <= dtLedgerwise_AdminDN.Rows.Count - 1; i++)
                        {
                            if (dtLedgerwise_AdminDN.Rows[i]["amount"].ToString() != "")
                            {
                                amount = Convert.ToDouble(dtLedgerwise_AdminDN.Rows[i]["amount"].ToString());
                            }
                            else
                            {
                                amount = 0.00;
                            }
                            Total_amount = Total_amount + Convert.ToDouble(amount.ToString());
                        }
                    }
                    DataTable dtTotal = new DataTable();
                    dtTotal = dtLedgerwise_AdminDN;
                    DataRow drow = dtTotal.NewRow();
                    drow["billtype"] = "Total";
                    drow["amount"] = string.Format("{0:#,##0.00}", Total_amount);
                    dtTotal.Rows.Add(drow);
                    Grd_AdminDN.Visible = true;
                    Grd_AdminDN.DataSource = dtLedgerwise_AdminDN;
                    Grd_AdminDN.DataBind();
                    ViewState["Ledgerwise-AdminDN"] = dtLedgerwise_AdminDN;
                    ViewState["Value"] = dtLedgerwise_AdminDN;
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter the Charge Name')", true);
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "OnAccount Receipt")
            {
                double amount = 0.00, Total_amount = 0.00;
                DataTable dt_OnAccountReceipt = new DataTable();
                if (chkConsolidate.Checked == true)
                {

                }

                dt_OnAccountReceipt = objInv.fn_OnAccount_Receipt(dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dt_OnAccountReceipt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt_OnAccountReceipt.Rows.Count - 1; i++)
                    {
                        if (dt_OnAccountReceipt.Rows[i]["tamount"].ToString() != "")
                        {
                            amount = Convert.ToDouble(dt_OnAccountReceipt.Rows[i]["tamount"].ToString());
                        }
                        else
                        {
                            amount = 0.00;
                        }
                        Total_amount = Total_amount + Convert.ToDouble(amount.ToString());
                    }
                }
                DataTable dtTotal = new DataTable();
                dtTotal = dt_OnAccountReceipt;
                DataRow drow = dtTotal.NewRow();
                drow["bankname"] = "Total";
                drow["tamount"] = string.Format("{0:#,##0.00}", Total_amount);
                dtTotal.Rows.Add(drow);
                Grd_OnAccountReceipt.Visible = true;
                Grd_OnAccountReceipt.DataSource = dt_OnAccountReceipt;
                Grd_OnAccountReceipt.DataBind();
                ViewState["OnAccountReceipt"] = dt_OnAccountReceipt;
                ViewState["Value"] = dt_OnAccountReceipt;
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "OnAccount Payment")
            {
                double amount = 0.00, Total_amount = 0.00;
                DataTable dt_OnAccountPayment = new DataTable();
                dt_OnAccountPayment = objInv.fn_OnAccount_Payment(dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                if (dt_OnAccountPayment.Rows.Count > 0)
                {
                    for (i = 0; i <= dt_OnAccountPayment.Rows.Count - 1; i++)
                    {
                        if (dt_OnAccountPayment.Rows[i]["tamount"].ToString() != "")
                        {
                            amount = Convert.ToDouble(dt_OnAccountPayment.Rows[i]["tamount"].ToString());
                        }
                        else
                        {
                            amount = 0.00;
                        }
                        Total_amount = Total_amount + Convert.ToDouble(amount.ToString());
                    }
                }
                DataTable dtTotal = new DataTable();
                dtTotal = dt_OnAccountPayment;
                DataRow drow = dtTotal.NewRow();
                drow["bankname"] = "Total";
                drow["tamount"] = string.Format("{0:#,##0.00}", Total_amount);
                dtTotal.Rows.Add(drow);
                Grd_OnAccountPayment.Visible = true;
                Grd_OnAccountPayment.DataSource = dt_OnAccountPayment;
                Grd_OnAccountPayment.DataBind();
                ViewState["OnAccountPayment"] = dt_OnAccountPayment;
                ViewState["Value"] = dt_OnAccountPayment;
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Receivable")
            {
                DataTable dt_TDSReceivable = new DataTable();
                //  dt_TDSReceivable = objInv.fn_TDSReceivable(Convert.ToInt32(Session["LoginEmpId"].ToString()));

                if (ddl_branch.SelectedItem.Text == "CORPORATE")
                {
                    dt_TDSReceivable = costtempobj.GetTDS("R", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), 0, Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }
                else
                {
                    dt_TDSReceivable = costtempobj.GetTDS("R", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), Convert.ToInt32(Session["LoginBranchID"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }
                //dt_TDSReceivable = costtempobj.GetTDS("R",Convert.ToDateTime(Utility.fn_ConvertDate( txt_from.Text)),Convert.ToDateTime(Utility.fn_ConvertDate( txt_to.Text)),Convert.ToInt32(Session["LoginBranchID"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                dt_TDSReceivable.Columns.Add("voutypename");
                DataRow dr_temp;
                double amount = 0.00, Total_amount = 0.00, Total_tdsamt = 0.00, tdsamt = 0.00;
                dr_temp = dt_TDSReceivable.NewRow();
                for (int k = 0; k < dt_TDSReceivable.Rows.Count; k++)
                {
                    string vouchername = FillVoucher(dt_TDSReceivable.Rows[k]["voutype"].ToString());
                    dt_TDSReceivable.Rows[k]["voutypename"] = vouchername;
                }
                if (dt_TDSReceivable.Rows.Count > 0)
                {
                    for (i = 0; i <= dt_TDSReceivable.Rows.Count - 1; i++)
                    {
                        if (dt_TDSReceivable.Rows[i]["tdsamt"].ToString() != "")
                        {
                            tdsamt = Convert.ToDouble(dt_TDSReceivable.Rows[i]["tdsamt"].ToString());
                        }
                        else
                        {
                            tdsamt = 0.00;
                        }
                        Total_tdsamt = Total_tdsamt + Convert.ToDouble(tdsamt.ToString());
                        if (dt_TDSReceivable.Rows[i]["amount"].ToString() != "")
                        {
                            amount = Convert.ToDouble(dt_TDSReceivable.Rows[i]["amount"].ToString());
                        }
                        else
                        {
                            amount = 0.00;
                        }
                        Total_amount = Total_amount + Convert.ToDouble(amount.ToString());
                    }
                }
                DataTable dtTotal = new DataTable();
                dtTotal = dt_TDSReceivable;
                DataRow drow = dtTotal.NewRow();
                drow["customername"] = "Over All";
                drow["tdsamt"] = string.Format("{0:#,##0.00}", Total_tdsamt);
                drow["amount"] = string.Format("{0:#,##0.00}", Total_amount);
                dtTotal.Rows.Add(drow);
                GrdReceivable.Visible = true;
                GrdReceivable.DataSource = dt_TDSReceivable;
                GrdReceivable.DataBind();
                ViewState["TDSReceivable"] = dt_TDSReceivable;
                ViewState["Value"] = dt_TDSReceivable;
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Payable")
            {
                DataTable dt_TDSPayable = new DataTable();
                // dt_TDSPayable = objInv.fn_TDSPayable(Convert.ToInt32(Session["LoginEmpId"].ToString()));

                if (ddl_branch.SelectedItem.Text == "CORPORATE")
                {
                    dt_TDSPayable = costtempobj.GetTDS("P", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), divisionid, Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }
                else
                {
                    dt_TDSPayable = costtempobj.GetTDS("P", Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), Convert.ToInt32(Session["LoginBranchID"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()));
                }

                dt_TDSPayable.Columns.Add("voutypename");
                DataRow dr_temp;
                double amount = 0.00, Total_amount = 0.00, Total_tdsamt = 0.00, tdsamt = 0.00;
                dr_temp = dt_TDSPayable.NewRow();
                for (int k = 0; k < dt_TDSPayable.Rows.Count; k++)
                {
                    string vouchername = FillVoucher(dt_TDSPayable.Rows[k]["voutype"].ToString());
                    dt_TDSPayable.Rows[k]["voutypename"] = vouchername;
                }
                if (dt_TDSPayable.Rows.Count > 0)
                {
                    for (i = 0; i <= dt_TDSPayable.Rows.Count - 1; i++)
                    {
                        if (dt_TDSPayable.Rows[i]["tdsamt"].ToString() != "")
                        {
                            tdsamt = Convert.ToDouble(dt_TDSPayable.Rows[i]["tdsamt"].ToString());
                        }
                        else
                        {
                            tdsamt = 0.00;
                        }
                        Total_tdsamt = Total_tdsamt + Convert.ToDouble(tdsamt.ToString());
                        if (dt_TDSPayable.Rows[i]["amount"].ToString() != "")
                        {
                            amount = Convert.ToDouble(dt_TDSPayable.Rows[i]["amount"].ToString());
                        }
                        else
                        {
                            amount = 0.00;
                        }
                        Total_amount = Total_amount + Convert.ToDouble(amount.ToString());
                    }
                }
                DataTable dtTotal = new DataTable();
                dtTotal = dt_TDSPayable;
                DataRow drow = dtTotal.NewRow();
                drow["customername"] = "Over All";
                drow["tdsamt"] = string.Format("{0:#,##0.00}", Total_tdsamt);
                drow["amount"] = string.Format("{0:#,##0.00}", Total_amount);
                dtTotal.Rows.Add(drow);
                GrdPayable.Visible = true;
                GrdPayable.DataSource = dt_TDSPayable;
                GrdPayable.DataBind();
                ViewState["TDSPayable"] = dt_TDSPayable;
                ViewState["Value"] = dt_TDSPayable;
                return;
            }//---------Arun
            else if (ddlSelect.SelectedItem.Text == "Service Tax")
            {
                if (int_bid != 0)
                {
                    grd_SerViceTax.Visible = true;
                    Obj_TDS.InsFAST(int_Empid, int_bid, dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginDivisionId"]));
                    if (chkConsolidate.Checked == true)
                    {

                        obj_dt = costtempobj.RetriveDtlsServiceTax(int_Empid, divisionid);
                    }
                    else
                    {
                        obj_dt = costtempobj.RetriveDtlsServiceTax(int_Empid, int_bid);
                    }

                    //}
                    //obj_dt = costtempobj.RetriveDtlsServiceTax(int_Empid, int_bid);
                    double amt1 = 0, amt2 = 0, amt3 = 0;
                    if (obj_dt.Rows.Count > 0)
                    {
                        DataTable Dtemp = new DataTable();
                        Dtemp.Columns.Add("SI#");
                        Dtemp.Columns.Add("vouno");
                        Dtemp.Columns.Add("voudate");
                        Dtemp.Columns.Add("customername");
                        Dtemp.Columns.Add("amount");
                        Dtemp.Columns.Add("stamt");
                        Dtemp.Columns.Add("voutype");
                        Dtemp.Columns.Add("jobtype");
                        Dtemp.Columns.Add("trantype");
                        Dtemp.Columns.Add("taxamt");
                        Dtemp.Columns.Add("vendorrefno");
                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            Dtemp.Rows.Add();
                            Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt.Rows[i]["voudate"].ToString()).ToShortDateString());
                            Dtemp.Rows[i]["customername"] = obj_dt.Rows[i]["customername"].ToString();
                            Dtemp.Rows[i]["amount"] = Convert.ToDouble(obj_dt.Rows[i]["amount"]).ToString("#0.00");
                            amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            Dtemp.Rows[i]["stamt"] = Convert.ToDouble(obj_dt.Rows[i]["stamt"]).ToString("#0.00");
                            amt2 = amt2 + Convert.ToDouble(obj_dt.Rows[i]["stamt"].ToString());
                            Dtemp.Rows[i]["voutype"] = obj_dt.Rows[i]["voutype"].ToString();
                            Dtemp.Rows[i]["jobtype"] = obj_dt.Rows[i]["jobtype"].ToString();
                            Dtemp.Rows[i]["trantype"] = obj_dt.Rows[i]["trantype"].ToString();
                            Dtemp.Rows[i]["taxamt"] = (Convert.ToDouble(obj_dt.Rows[i]["taxamt"])).ToString("#0.00");
                            amt3 = amt3 + Convert.ToDouble(obj_dt.Rows[i]["taxamt"].ToString());
                            Dtemp.Rows[i]["vendorrefno"] = obj_dt.Rows[i]["vendorrefno"].ToString();
                        }
                        Dtemp.Rows.Add();
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["customername"] = "Total";
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = amt1.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["stamt"] = amt2.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["taxamt"] = amt3.ToString("#0.00");
                        grd_SerViceTax.DataSource = Dtemp;
                        ViewState["Value"] = Dtemp;
                        grd_SerViceTax.DataBind();
                        return;
                    }
                    else
                    {
                        grd_SerViceTax.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd_SerViceTax.DataBind();
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "VoucherRegister", "alertify.alert('Select Any Branch');", true);
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Voucherwise")
            {
                tds_VoucherWise.Visible = true;
                if (int_bid != 0 && strtrantype != "CA")
                {
                    Obj_TDS.InsFATDS(int_Empid, int_bid, dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginDivisionId"]));

                    obj_dt = costtempobj.RetiveDtlsTdsVoucherVise(int_Empid, int_bid);
                    double amt1 = 0, amt2 = 0, amt3 = 0;
                    if (obj_dt.Rows.Count > 0)
                    {
                        //DataTable Dtemp = new DataTable();
                        //Dtemp.Columns.Add("SI#");
                        //Dtemp.Columns.Add("shortname");
                        //Dtemp.Columns.Add("panno");
                        //Dtemp.Columns.Add("tdstype");
                        //Dtemp.Columns.Add("tdssection");
                        //Dtemp.Columns.Add("amount");
                        //Dtemp.Columns.Add("voudate");
                        //Dtemp.Columns.Add("customername");
                        //Dtemp.Columns.Add("taxRate");
                        //Dtemp.Columns.Add("tdsamount");
                        //Dtemp.Columns.Add("vouno");
                        //Dtemp.Columns.Add("jobno");

                        DataTable Dtemp = new DataTable();
                        Dtemp.Columns.Add("SI#");
                        Dtemp.Columns.Add("branch");
                        Dtemp.Columns.Add("jobno");
                        Dtemp.Columns.Add("voutype");
                        Dtemp.Columns.Add("vouno");
                        Dtemp.Columns.Add("voudate");
                        Dtemp.Columns.Add("vendorrefno");
                        Dtemp.Columns.Add("partyname");
                        Dtemp.Columns.Add("vouamt");
                        Dtemp.Columns.Add("gstamt");
                        Dtemp.Columns.Add("total");
                        Dtemp.Columns.Add("grossamt");
                        Dtemp.Columns.Add("taxRate");
                        Dtemp.Columns.Add("tdsamount");
                        Dtemp.Columns.Add("panno");
                        Dtemp.Columns.Add("tdssection");
                        Dtemp.Columns.Add("curr");
                        Dtemp.Columns.Add("amount");

                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            Dtemp.Rows.Add();
                            //  Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            Dtemp.Rows[i]["branch"] = obj_dt.Rows[i]["branch"].ToString();
                            Dtemp.Rows[i]["jobno"] = obj_dt.Rows[i]["jobno"].ToString();
                            Dtemp.Rows[i]["voutype"] = obj_dt.Rows[i]["voutype"].ToString();
                            Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt.Rows[i]["voudate"].ToString()).ToShortDateString());
                            Dtemp.Rows[i]["vendorrefno"] = obj_dt.Rows[i]["vendorrefno"].ToString();
                            Dtemp.Rows[i]["partyname"] = obj_dt.Rows[i]["partyname"].ToString();
                            Dtemp.Rows[i]["vouamt"] = (Convert.ToDouble(obj_dt.Rows[i]["vouamt"])).ToString("#0.00");
                            Dtemp.Rows[i]["gstamt"] = (Convert.ToDouble(obj_dt.Rows[i]["gstamt"])).ToString("#0.00");
                            Dtemp.Rows[i]["total"] = (Convert.ToDouble(obj_dt.Rows[i]["total"])).ToString("#0.00");
                            Dtemp.Rows[i]["grossamt"] = (Convert.ToDouble(obj_dt.Rows[i]["grossamt"])).ToString("#0.00");
                            Dtemp.Rows[i]["taxRate"] = obj_dt.Rows[i]["TaxRate"].ToString();
                            Dtemp.Rows[i]["tdsamount"] = (Convert.ToDouble(obj_dt.Rows[i]["tdsamount"])).ToString("#0.00");
                            Dtemp.Rows[i]["panno"] = obj_dt.Rows[i]["panno"].ToString();
                            Dtemp.Rows[i]["tdssection"] = obj_dt.Rows[i]["tdssection"].ToString();
                            Dtemp.Rows[i]["curr"] = obj_dt.Rows[i]["curr"].ToString();
                            Dtemp.Rows[i]["amount"] = (Convert.ToDouble(obj_dt.Rows[i]["amount"])).ToString("#0.00");
                            amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            amt3 = amt3 + Convert.ToDouble(obj_dt.Rows[i]["tdsamount"].ToString());
                            //   amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            //if (obj_dt.Rows[i]["tdstype"].ToString() == "C")
                            //{
                            //    Dtemp.Rows[i]["tdstype"] = "01";
                            //}
                            //else
                            //{
                            //    Dtemp.Rows[i]["tdstype"] = "02";
                            //}
                            // Dtemp.Rows[i]["taxRate"] = obj_dt.Rows[i]["taxRate"].ToString();
                            //if (amt1 > 0 && amt3 > 0)
                            //{
                            //    Dtemp.Rows[i]["taxRate"] = ((amt3 * 100) / (amt1)).ToString("#0.00");
                            //}


                            //Dtemp.Rows[i]["surcharge"] = "0.00";
                            //Dtemp.Rows[i]["cess"] = "0.00";
                            //Dtemp.Rows[i]["deducteecode"] = " ";
                        }

                        //for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        //{
                        //    Dtemp.Rows.Add();
                        //    //  Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                        //    Dtemp.Rows[i]["shortname"] = obj_dt.Rows[i]["shortname"].ToString();
                        //    Dtemp.Rows[i]["panno"] = obj_dt.Rows[i]["panno"].ToString();
                        //    //   amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                        //    if (obj_dt.Rows[i]["tdstype"].ToString() == "C")
                        //    {
                        //        Dtemp.Rows[i]["tdstype"] = "01";
                        //    }
                        //    else
                        //    {
                        //        Dtemp.Rows[i]["tdstype"] = "02";
                        //    }
                        //    Dtemp.Rows[i]["tdssection"] = obj_dt.Rows[i]["tdssection"].ToString();
                        //    Dtemp.Rows[i]["amount"] = (Convert.ToDouble(obj_dt.Rows[i]["amount"])).ToString("#0.00");
                        //    amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                        //    Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt.Rows[i]["voudate"].ToString()).ToShortDateString());
                        //    Dtemp.Rows[i]["customername"] = obj_dt.Rows[i]["customername"].ToString();
                        //    // Dtemp.Rows[i]["taxRate"] = obj_dt.Rows[i]["taxRate"].ToString();
                        //    Dtemp.Rows[i]["tdsamount"] = (Convert.ToDouble(obj_dt.Rows[i]["tdsamount"])).ToString("#0.00");
                        //    amt3 = amt3 + Convert.ToDouble(obj_dt.Rows[i]["tdsamount"].ToString());
                        //    //if (amt1 > 0 && amt3 > 0)
                        //    //{
                        //    //    Dtemp.Rows[i]["taxRate"] = ((amt3 * 100) / (amt1)).ToString("#0.00");
                        //    //}
                        //    Dtemp.Rows[i]["taxRate"] = obj_dt.Rows[i]["TaxRate"].ToString();
                        //    Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                        //    Dtemp.Rows[i]["jobno"] = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                        //}
                        Dtemp.Rows.Add();
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdssection"] = "Total";
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = amt1.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdsamount"] = amt3.ToString("#0.00");
                        tds_VoucherWise.DataSource = Dtemp;
                        ViewState["Value"] = Dtemp;
                        tds_VoucherWise.DataBind();
                        return;
                    }
                    else
                    {
                        tds_VoucherWise.DataSource = Utility.Fn_GetEmptyDataTable();
                        tds_VoucherWise.DataBind();
                        return;
                    }
                }
                else
                {
                    Obj_TDS.InsFATDS(int_Empid, 0, dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginDivisionId"]));
                    obj_dt = costtempobj.RetiveDtlsTdsVoucherViseDivision(int_Empid, Convert.ToInt32(Session["LoginDivisionId"]));
                    double amt1 = 0, amt2 = 0, amt3 = 0;
                    if (obj_dt.Rows.Count > 0)
                    {
                        DataTable Dtemp = new DataTable();
                        //Dtemp.Columns.Add("SI#");
                        //Dtemp.Columns.Add("shortname");
                        //Dtemp.Columns.Add("panno");
                        //Dtemp.Columns.Add("tdstype");
                        //Dtemp.Columns.Add("tdssection");
                        //Dtemp.Columns.Add("amount");
                        //Dtemp.Columns.Add("voudate");
                        //Dtemp.Columns.Add("customername");
                        //Dtemp.Columns.Add("taxRate");
                        //Dtemp.Columns.Add("tdsamount");
                        //Dtemp.Columns.Add("vouno");
                        //Dtemp.Columns.Add("jobno");

                        Dtemp.Columns.Add("SI#");
                        Dtemp.Columns.Add("branch");
                        Dtemp.Columns.Add("jobno");
                        Dtemp.Columns.Add("voutype");
                        Dtemp.Columns.Add("vouno");
                        Dtemp.Columns.Add("voudate");
                        Dtemp.Columns.Add("vendorrefno");
                        Dtemp.Columns.Add("partyname");
                        Dtemp.Columns.Add("vouamt");
                        Dtemp.Columns.Add("gstamt");
                        Dtemp.Columns.Add("total");
                        Dtemp.Columns.Add("grossamt");
                        Dtemp.Columns.Add("taxRate");
                        Dtemp.Columns.Add("tdsamount");
                        Dtemp.Columns.Add("panno");
                        Dtemp.Columns.Add("tdssection");
                        Dtemp.Columns.Add("curr");
                        Dtemp.Columns.Add("amount");

                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {

                            Dtemp.Rows.Add();
                            //  Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            Dtemp.Rows[i]["branch"] = obj_dt.Rows[i]["branch"].ToString();
                            Dtemp.Rows[i]["jobno"] = obj_dt.Rows[i]["jobno"].ToString();
                            Dtemp.Rows[i]["voutype"] = obj_dt.Rows[i]["voutype"].ToString();
                            Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt.Rows[i]["voudate"].ToString()).ToShortDateString());
                            Dtemp.Rows[i]["vendorrefno"] = obj_dt.Rows[i]["vendorrefno"].ToString();
                            Dtemp.Rows[i]["partyname"] = obj_dt.Rows[i]["partyname"].ToString();
                            Dtemp.Rows[i]["vouamt"] = (Convert.ToDouble(obj_dt.Rows[i]["vouamt"])).ToString("#0.00");
                            Dtemp.Rows[i]["gstamt"] = (Convert.ToDouble(obj_dt.Rows[i]["gstamt"])).ToString("#0.00");
                            Dtemp.Rows[i]["total"] = (Convert.ToDouble(obj_dt.Rows[i]["total"])).ToString("#0.00");
                            Dtemp.Rows[i]["grossamt"] = (Convert.ToDouble(obj_dt.Rows[i]["grossamt"])).ToString("#0.00");
                            Dtemp.Rows[i]["taxRate"] = obj_dt.Rows[i]["TaxRate"].ToString();
                            Dtemp.Rows[i]["tdsamount"] = (Convert.ToDouble(obj_dt.Rows[i]["tdsamount"])).ToString("#0.00");
                            Dtemp.Rows[i]["panno"] = obj_dt.Rows[i]["panno"].ToString();
                            Dtemp.Rows[i]["tdssection"] = obj_dt.Rows[i]["tdssection"].ToString();
                            Dtemp.Rows[i]["curr"] = obj_dt.Rows[i]["curr"].ToString();
                            Dtemp.Rows[i]["amount"] = (Convert.ToDouble(obj_dt.Rows[i]["amount"])).ToString("#0.00");
                            amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            amt3 = amt3 + Convert.ToDouble(obj_dt.Rows[i]["tdsamount"].ToString());

                            //Dtemp.Rows.Add();
                            //Dtemp.Rows[i]["shortname"] = obj_dt.Rows[i]["shortname"].ToString();
                            //Dtemp.Rows[i]["panno"] = obj_dt.Rows[i]["panno"].ToString();
                            //if (obj_dt.Rows[i]["tdstype"].ToString() == "C")
                            //{
                            //    Dtemp.Rows[i]["tdstype"] = "01";
                            //}
                            //else
                            //{
                            //    Dtemp.Rows[i]["tdstype"] = "02";
                            //}
                            //Dtemp.Rows[i]["tdssection"] = obj_dt.Rows[i]["tdssection"].ToString();
                            //Dtemp.Rows[i]["amount"] = (Convert.ToDouble(obj_dt.Rows[i]["amount"])).ToString("#0.00");
                            //amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            //Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt.Rows[i]["voudate"].ToString()).ToShortDateString());
                            //Dtemp.Rows[i]["customername"] = obj_dt.Rows[i]["customername"].ToString();
                            //Dtemp.Rows[i]["tdsamount"] = (Convert.ToDouble(obj_dt.Rows[i]["tdsamount"])).ToString("#0.00");
                            //amt3 = amt3 + Convert.ToDouble(obj_dt.Rows[i]["tdsamount"].ToString());
                            ////if (amt1 > 0)
                            ////{
                            ////    Dtemp.Rows[i]["taxRate"] = ((amt3 * 100) / (amt1)).ToString("#0.00");
                            ////}
                            //Dtemp.Rows[i]["taxRate"] = obj_dt.Rows[i]["TaxRate"].ToString();
                            //Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            //Dtemp.Rows[i]["jobno"] = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                        }
                        Dtemp.Rows.Add();
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdssection"] = "Total";
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = amt1.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdsamount"] = amt3.ToString("#0.00");
                        tds_VoucherWise.DataSource = Dtemp;
                        ViewState["Value"] = Dtemp;
                        tds_VoucherWise.DataBind();
                        return;
                    }
                    else
                    {
                        tds_VoucherWise.DataSource = Utility.Fn_GetEmptyDataTable();
                        tds_VoucherWise.DataBind();
                        return;
                    }
                }
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Summary")
            {
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                double tot = 0;
                pnl_tdsAll.Visible = true;
                grd_TdsAll.Visible = true;
                if (int_bid != 0 && strtrantype != "CA")
                {
                    Obj_TDS.InsFATDS(int_Empid, int_bid, dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginDivisionId"]));
                    dtset = costtempobj.GetTDSSum(int_Empid, int_bid);
                    dt1 = dtset.Tables[0];
                    dt2 = dtset.Tables[1];
                    if (dt1.Rows.Count > 0)
                    {
                        dt1.Columns.Add("Total");
                        for (int l = 0; l < dt1.Rows.Count; l++)
                        {
                            for (i = 1; i < dt1.Columns.Count - 1; i++)
                            {
                                if (string.IsNullOrEmpty(dt1.Rows[l][i].ToString()) != true)
                                {
                                    tot = tot + Convert.ToDouble(dt1.Rows[l][i].ToString());
                                }
                                else
                                {
                                    tot = tot + 0;
                                }
                            }
                            //dt1.Columns.Add();
                            dt1.Rows[l][dt1.Columns.Count - 1] = tot.ToString("#0.00");
                        }
                        grd_TdsAll.DataSource = dt1;
                        ViewState["Value"] = dt1;
                        grd_TdsAll.DataBind();
                        return;
                    }
                    else
                    {
                        grd_TdsAll.DataSource = "";
                    
                        grd_TdsAll.DataBind();
                    }
                }
                else
                {
                    Obj_TDS.InsFATDS(int_Empid, 0, dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginDivisionId"]));
                    dtset = costtempobj.GetTDSSum(int_Empid, int_bid);
                    dt1 = dtset.Tables[0];
                    dt2 = dtset.Tables[1];
                    if (dt1.Rows.Count > 0)
                    {
                        //DataTable dtemp = new DataTable();
                        dt1.Columns.Add("Total");
                        for (int l = 0; l < dt1.Rows.Count; l++)
                        {
                            for (i = 1; i < dt1.Columns.Count - 1; i++)
                            {
                                if (string.IsNullOrEmpty(dt1.Rows[l][i].ToString()) != true)
                                {
                                    tot = tot + Convert.ToDouble(dt1.Rows[l][i].ToString());
                                }
                                else
                                {
                                    tot = tot + 0;
                                }
                            }
                            //dt1.Columns.Add();
                            dt1.Rows[l][dt1.Columns.Count - 1] = tot.ToString("#0.00");
                        }
                        grd_TdsAll.DataSource = dt1;
                        ViewState["Value"] = dt1;
                        grd_TdsAll.DataBind();
                        return;
                    }
                }
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Voucherwise ALL")
            {
                grd_TdsVouchall.Visible = true;
                if (int_bid != 0 && strtrantype != "CA")
                {
                    Obj_TDS.InsFATDSALL(int_Empid, int_bid, dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginDivisionId"]));
                    obj_dt = costtempobj.RetriveTdsVouchwiseAll(int_Empid, int_bid);
                    double amt1 = 0, amt2 = 0, amt3 = 0;
                    if (obj_dt.Rows.Count > 0)
                    {
                        DataTable Dtemp = new DataTable();
                        Dtemp.Columns.Add("SI#");
                        Dtemp.Columns.Add("shortname");
                        Dtemp.Columns.Add("customername");
                        Dtemp.Columns.Add("panno");
                        Dtemp.Columns.Add("tdstype");
                        Dtemp.Columns.Add("tdssection");
                        Dtemp.Columns.Add("amount");
                        Dtemp.Columns.Add("voudate");
                        Dtemp.Columns.Add("taxRate");
                        Dtemp.Columns.Add("tdsamount");
                        Dtemp.Columns.Add("stamt");
                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            Dtemp.Rows.Add();
                            // Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            Dtemp.Rows[i]["shortname"] = obj_dt.Rows[i]["shortname"].ToString();
                            Dtemp.Rows[i]["panno"] = obj_dt.Rows[i]["panno"].ToString();
                            //   amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            if (obj_dt.Rows[i]["tdstype"].ToString() == "C")
                            {
                                Dtemp.Rows[i]["tdstype"] = "01";
                            }
                            else
                            {
                                Dtemp.Rows[i]["tdstype"] = "02";
                            }
                            Dtemp.Rows[i]["tdssection"] = obj_dt.Rows[i]["tdssection"].ToString();
                            Dtemp.Rows[i]["amount"] = (Convert.ToDouble(obj_dt.Rows[i]["amount"])).ToString("#0.00");
                            amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt.Rows[i]["voudate"].ToString()).ToShortDateString());
                            Dtemp.Rows[i]["customername"] = obj_dt.Rows[i]["customername"].ToString();
                            // Dtemp.Rows[i]["taxRate"] = obj_dt.Rows[i]["taxRate"].ToString();
                            Dtemp.Rows[i]["tdsamount"] = (Convert.ToDouble(obj_dt.Rows[i]["tdsamount"])).ToString("#0.00");
                            amt3 = amt3 + Convert.ToDouble(obj_dt.Rows[i]["tdsamount"].ToString());
                            if (amt1 > 0 && amt3 > 0)
                            {
                                Dtemp.Rows[i]["taxRate"] = ((Convert.ToDouble(obj_dt.Rows[i]["tdsamount"].ToString()) * 100) / (Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString()))).ToString("#0.00");
                            }
                            else
                            {
                                Dtemp.Rows[i]["taxRate"] = "0.00";
                            }
                            Dtemp.Rows[i]["stamt"] = (Convert.ToDouble(obj_dt.Rows[i]["stamt"])).ToString("#0.00"); ;
                            amt2 = amt2 + Convert.ToDouble(obj_dt.Rows[i]["stamt"].ToString());
                        }
                        Dtemp.Rows.Add();
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdssection"] = "Total";
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = amt1.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdsamount"] = amt3.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["stamt"] = amt2.ToString("#0.00");
                        grd_TdsVouchall.DataSource = Dtemp;
                        ViewState["Value"] = Dtemp;
                        grd_TdsVouchall.DataBind();
                        return;
                    }
                    else
                    {
                        grd_TdsVouchall.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd_TdsVouchall.DataBind();
                        return;
                    }
                }
                else
                {
                    Obj_TDS.InsFATDSALL(int_Empid, 0, dt_fromdate, dt_todate, Convert.ToInt32(Session["LoginDivisionId"]));
                    obj_dt = costtempobj.RetriveTdsVouchwiseAllDiv(int_Empid, Convert.ToInt32(Session["LoginDivisionId"]));
                    double amt1 = 0, amt2 = 0, amt3 = 0;
                    if (obj_dt.Rows.Count > 0)
                    {
                        DataTable Dtemp = new DataTable();
                        Dtemp.Columns.Add("SI#");
                        Dtemp.Columns.Add("shortname");
                        Dtemp.Columns.Add("customername");
                        Dtemp.Columns.Add("panno");
                        Dtemp.Columns.Add("tdstype");
                        Dtemp.Columns.Add("tdssection");
                        Dtemp.Columns.Add("amount");
                        Dtemp.Columns.Add("voudate");
                        Dtemp.Columns.Add("taxRate");
                        Dtemp.Columns.Add("tdsamount");
                        Dtemp.Columns.Add("stamt");
                        for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                        {
                            Dtemp.Rows.Add();
                            //  Dtemp.Rows[i]["vouno"] = obj_dt.Rows[i]["vouno"].ToString();
                            Dtemp.Rows[i]["shortname"] = obj_dt.Rows[i]["shortname"].ToString();
                            Dtemp.Rows[i]["panno"] = obj_dt.Rows[i]["panno"].ToString();
                            //   amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            if (obj_dt.Rows[i]["tdstype"].ToString() == "C")
                            {
                                Dtemp.Rows[i]["tdstype"] = "01";
                            }
                            else
                            {
                                Dtemp.Rows[i]["tdstype"] = "02";
                            }
                            Dtemp.Rows[i]["tdssection"] = obj_dt.Rows[i]["tdssection"].ToString();
                            Dtemp.Rows[i]["amount"] = (Convert.ToDouble(obj_dt.Rows[i]["amount"])).ToString("#0.00");
                            amt1 = amt1 + Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(obj_dt.Rows[i]["voudate"].ToString()).ToShortDateString());
                            Dtemp.Rows[i]["customername"] = obj_dt.Rows[i]["customername"].ToString();
                            Dtemp.Rows[i]["tdsamount"] = (Convert.ToDouble(obj_dt.Rows[i]["tdsamount"])).ToString("#0.00");
                            amt3 = amt3 + Convert.ToDouble(obj_dt.Rows[i]["tdsamount"].ToString());
                            if (amt1 > 0)
                            {
                                Dtemp.Rows[i]["taxRate"] = ((amt3 * 100) / (amt1)).ToString("#0.00");
                            }
                            Dtemp.Rows[i]["stamt"] = (Convert.ToDouble(obj_dt.Rows[i]["stamt"])).ToString("#0.00");
                            amt2 = amt2 + Convert.ToDouble(obj_dt.Rows[i]["stamt"].ToString());
                        }
                        Dtemp.Rows.Add();
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdssection"] = "Total";
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = amt1.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["tdsamount"] = amt3.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["stamt"] = amt2.ToString("#0.00");
                        grd_TdsVouchall.DataSource = Dtemp;
                        ViewState["Value"] = Dtemp;
                        grd_TdsVouchall.DataBind();
                        return;
                    }
                    else
                    {
                        grd_TdsVouchall.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd_TdsVouchall.DataBind();
                        return;
                    }
                }
            }
            else if (ddlSelect.SelectedItem.Text == "Internal Billing Branch")
            {
                double total = 0, total1 = 0;
                DataTable dtnew = new DataTable();
                if (hid_chargeid.Value == "0" || hid_chargeid.Value == "")
                {
                    //  costtempobj.InsTempInternalBillingBranchCharge(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(hid_chargeid.Value));
                    obj_dt = costtempobj.GetInternalBillDtls(int_Empid, Convert.ToInt32(Session["LoginDivisionId"]));
                    if (obj_dt.Rows.Count > 0)
                    {
                        DataTable Dtemp = new DataTable();
                        double amt = 0, amt1 = 0;
                        Dtemp.Columns.Add("SI#");
                        Dtemp.Columns.Add("vouno");
                        Dtemp.Columns.Add("voudate");
                        Dtemp.Columns.Add("voutype");
                        Dtemp.Columns.Add("trantype");
                        Dtemp.Columns.Add("jobno");
                        Dtemp.Columns.Add("blno");
                        Dtemp.Columns.Add("customername");
                        Dtemp.Columns.Add("amount");
                        Dtemp.Columns.Add("stamount");
                        DataView dv_co = new DataView(obj_dt);
                        dtnew = dv_co.ToTable(true, "shortname");
                        dv_co = new DataView(dtnew);
                        dv_co.Sort = "shortname";
                        dtnew = dv_co.ToTable();
                        DataRow dr = Dtemp.NewRow();
                        string name = "";
                        for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                        {
                            DataTable dtLi = new DataTable();
                            DataView data1 = obj_dt.DefaultView;
                            data1.RowFilter = "shortname = '" + dtnew.Rows[j]["shortname"] + "' ";
                            dtLi = data1.ToTable();
                            //Dtemp.Rows.Add();
                            name = dtLi.Rows[0]["shortname"].ToString();
                            for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                            {
                                //if (i != 0)
                                // {
                                Dtemp.Rows.Add();
                                // }
                                Dtemp.Rows[i]["vouno"] = dtLi.Rows[i]["vouno"];
                                Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["voudate"].ToString()).ToShortDateString());
                                if (dtLi.Rows[i]["voutype"].ToString() == "I")
                                {
                                    Dtemp.Rows[i]["voutype"] = "INV";
                                }
                                else if (dtLi.Rows[i]["voutype"].ToString() == "V")
                                {
                                    Dtemp.Rows[i]["voutype"] = "DN";
                                }
                                else if (dtLi.Rows[i]["voutype"].ToString() == "P")
                                {
                                    Dtemp.Rows[i]["voutype"] = "PA";
                                }
                                else if (dtLi.Rows[i]["voutype"].ToString() == "E")
                                {
                                    Dtemp.Rows[i]["voutype"] = "CN";
                                }
                                if (dtLi.Rows[i]["trantype"] == "FE")
                                {
                                    Dtemp.Rows[i]["trantype"] = "OE";
                                }
                                else if (dtLi.Rows[i]["trantype"] == "FI")
                                {
                                    Dtemp.Rows[i]["trantype"] = "OI";
                                }
                                else
                                {
                                    Dtemp.Rows[i]["trantype"] = dtLi.Rows[i]["trantype"];
                                }
                                Dtemp.Rows[i]["jobno"] = dtLi.Rows[i]["jobno"];
                                Dtemp.Rows[i]["blno"] = dtLi.Rows[i]["blno"];
                                Dtemp.Rows[i]["customername"] = dtLi.Rows[i]["customername"];
                                Dtemp.Rows[i]["amount"] = (Convert.ToDouble(dtLi.Rows[i]["amount"])).ToString("#0.00");
                                amt = amt + Convert.ToDouble(dtLi.Rows[i]["amount"]);
                                Dtemp.Rows[i]["stamount"] = (Convert.ToDouble(dtLi.Rows[i]["stamount"])).ToString("#0.00");
                                amt1 = amt1 + Convert.ToDouble(dtLi.Rows[i]["stamount"]);
                            }
                            Dtemp.Rows.Add();
                            // Dtemp.Rows[Dtemp.Rows.Count - 1]["blno"] = Dtemp.Rows[0]["shortname"];
                            Dtemp.Rows[Dtemp.Rows.Count - 1]["customername"] = "Total";
                            Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = amt.ToString("#0.00");
                            Dtemp.Rows[Dtemp.Rows.Count - 1]["stamount"] = amt1.ToString("#0.00");
                            total = total + amt;
                            total1 = total1 + amt1;
                        }
                        Dtemp.Rows.Add();
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["blno"] = name;
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["customername"] = "Total";
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = total.ToString("#0.00");
                        Dtemp.Rows[Dtemp.Rows.Count - 1]["stamount"] = total1.ToString("#0.00");
                        grd_TdsVouchall.DataSource = Dtemp;
                        ViewState["Value"] = Dtemp;
                        grd_TdsVouchall.DataBind();
                        return;
                    }
                    else
                    {
                        grd_TdsVouchall.Visible = true;
                        grd_TdsVouchall.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd_TdsVouchall.DataBind();
                        return;
                    }
                }
                else
                {
                    string name = "";
                    if (hid_chargeid.Value != "0" && hid_chargeid.Value != "")
                    {
                        //  costtempobj.InsTempInternalBillingBranchCharge(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(hid_chargeid.Value));
                        obj_dt = costtempobj.GetInternalBillDtlsall(int_Empid, Convert.ToInt32(Session["LoginDivisionId"]));
                        if (obj_dt.Rows.Count > 0)
                        {
                            DataTable Dtemp = new DataTable();
                            double amt = 0, amt1 = 0;
                            Dtemp.Columns.Add("SI#");
                            Dtemp.Columns.Add("vouno");
                            Dtemp.Columns.Add("voudate");
                            Dtemp.Columns.Add("voutype");
                            Dtemp.Columns.Add("trantype");
                            Dtemp.Columns.Add("jobno");
                            Dtemp.Columns.Add("blno");
                            Dtemp.Columns.Add("customername");
                            Dtemp.Columns.Add("amount");
                            Dtemp.Columns.Add("stamount");
                            DataView dv_co = new DataView(obj_dt);
                            dtnew = dv_co.ToTable(true, "shortname");
                            dv_co = new DataView(dtnew);
                            dv_co.Sort = "shortname";
                            dtnew = dv_co.ToTable();
                            // DataRow dr = Dtemp.NewRow();
                            for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                            {
                                DataTable dtLi = new DataTable();
                                DataView data1 = obj_dt.DefaultView;
                                data1.RowFilter = "shortname = '" + dtnew.Rows[j]["shortname"] + "' ";
                                dtLi = data1.ToTable();
                                //Dtemp.Rows.Add();
                                name = dtLi.Rows[0]["shortname"].ToString();
                                for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                                {
                                    //if (i != 0)
                                    //{
                                    Dtemp.Rows.Add();
                                    //}
                                    Dtemp.Rows[i]["vouno"] = dtLi.Rows[i]["vouno"];
                                    Dtemp.Rows[i]["voudate"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["voudate"].ToString()).ToShortDateString());
                                    if (dtLi.Rows[i]["voutype"].ToString() == "I")
                                    {
                                        Dtemp.Rows[i]["voutype"] = "INV";
                                    }
                                    else if (dtLi.Rows[i]["voutype"].ToString() == "V")
                                    {
                                        Dtemp.Rows[i]["voutype"] = "DN";
                                    }
                                    else if (dtLi.Rows[i]["voutype"].ToString() == "P")
                                    {
                                        Dtemp.Rows[i]["voutype"] = "PA";
                                    }
                                    else if (dtLi.Rows[i]["voutype"].ToString() == "E")
                                    {
                                        Dtemp.Rows[i]["voutype"] = "CN";
                                    }
                                    if (dtLi.Rows[i]["trantype"] == "FE")
                                    {
                                        Dtemp.Rows[i]["trantype"] = "OE";
                                    }
                                    else if (dtLi.Rows[i]["trantype"] == "FI")
                                    {
                                        Dtemp.Rows[i]["trantype"] = "OI";
                                    }
                                    else
                                    {
                                        Dtemp.Rows[i]["trantype"] = dtLi.Rows[i]["trantype"];
                                    }
                                    Dtemp.Rows[i]["jobno"] = dtLi.Rows[i]["jobno"];
                                    Dtemp.Rows[i]["blno"] = dtLi.Rows[i]["blno"];
                                    Dtemp.Rows[i]["customername"] = dtLi.Rows[i]["customername"];
                                    Dtemp.Rows[i]["amount"] = (Convert.ToDouble(dtLi.Rows[i]["amount"])).ToString("#0.00");
                                    amt = amt + Convert.ToDouble(dtLi.Rows[i]["amount"]);
                                    Dtemp.Rows[i]["stamount"] = (Convert.ToDouble(dtLi.Rows[i]["stamount"])).ToString("#0.00");
                                    amt1 = amt1 + Convert.ToDouble(dtLi.Rows[i]["stamount"]);
                                }
                                Dtemp.Rows.Add();
                                // Dtemp.Rows[Dtemp.Rows.Count - 1]["blno"] = Dtemp.Rows[0]["shortname"];
                                Dtemp.Rows[Dtemp.Rows.Count - 1]["customername"] = "Total";
                                Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = amt.ToString("#0.00");
                                Dtemp.Rows[Dtemp.Rows.Count - 1]["stamount"] = amt1.ToString("#0.00");
                                total = total + amt;
                                total1 = total1 + amt1;
                                //grd_TdsVouchall.DataSource = Dtemp;
                                //ViewState["Value"] = Dtemp;
                                //grd_TdsVouchall.DataBind();
                            }
                            Dtemp.Rows.Add();
                            Dtemp.Rows[Dtemp.Rows.Count - 1]["blno"] = name;
                            Dtemp.Rows[Dtemp.Rows.Count - 1]["customername"] = "Total";
                            Dtemp.Rows[Dtemp.Rows.Count - 1]["amount"] = total.ToString("#0.00");
                            Dtemp.Rows[Dtemp.Rows.Count - 1]["stamount"] = total1.ToString("#0.00");
                            grd_TdsVouchall.DataSource = Dtemp;
                            ViewState["Value"] = Dtemp;
                            grd_TdsVouchall.DataBind();
                            return;
                        }
                        else
                        {
                            grd_TdsVouchall.DataSource = Utility.Fn_GetEmptyDataTable();
                            grd_TdsVouchall.DataBind();
                            return;
                        }
                    }
                }
            }
            else if (ddlSelect.SelectedItem.Text == "DN After JobClosing")
            {
                string type = "";
                double amout = 0;
                double amt = 0;
                DataTable dtnew = new DataTable();
                obj_dt = costtempobj.GetRetriveDnJobClosing(int_bid, Convert.ToInt32(Session["Vouyear"]), dt_fromdate, dt_todate);
                int m = 1;
                if (obj_dt.Rows.Count > 0)
                {
                    DataTable Dtemp = new DataTable();
                    //   Dtemp.Columns.Add("Product");
                    Dtemp.Columns.Add("SI#");
                    Dtemp.Columns.Add("Dn#");
                    Dtemp.Columns.Add("Dndate");
                    Dtemp.Columns.Add("Closeddate");
                    //  Dtemp.Columns.Add("trantype");
                    Dtemp.Columns.Add("Job#");
                    Dtemp.Columns.Add("Bl#");
                    Dtemp.Columns.Add("Customername");
                    Dtemp.Columns.Add("DNAmount");
                    Dtemp.Columns.Add("Approvedon");
                    Dtemp.Columns.Add("Tally Transfered");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "trantype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "trantype";
                    dtnew = dv_co.ToTable();
                    string name = "";
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "trantype = '" + dtnew.Rows[j]["trantype"] + "' ";
                        dtLi = data1.ToTable();
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            Dtemp.Rows.Add();
                            Dtemp.Rows[i]["SI#"] = m + i;
                            Dtemp.Rows[i]["Dn#"] = dtLi.Rows[i]["dnno"];
                            Dtemp.Rows[i]["Dndate"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["dndate"]).ToShortDateString());
                            Dtemp.Rows[i]["Closeddate"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["closeddate"]).ToShortDateString());
                            if (dtLi.Rows[i]["trantype"] == "FE")
                            {
                                type = "OE";
                            }
                            else if (dtLi.Rows[i]["trantype"] == "FI")
                            {
                                type = "OI";
                            }
                            else
                            {
                                type = dtLi.Rows[i]["trantype"].ToString();
                            }
                            Dtemp.Rows[i]["Job#"] = dtLi.Rows[i]["jobno"] + "-" + type;
                            Dtemp.Rows[i]["Customername"] = dtLi.Rows[i]["customername"];
                            Dtemp.Rows[i]["DNAmount"] = Convert.ToDouble(dtLi.Rows[i]["amount"]).ToString("#0.00");
                            amt = amt + Convert.ToDouble(dtLi.Rows[i]["amount"]);
                            //Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["closeddate"]).ToShortDateString());
                            Dtemp.Rows[i]["Approvedon"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["closeddate"]).ToShortDateString());
                            // Dtemp.Rows[i]["approvedon"] = dtLi.Rows[i]["approvedon"];
                            //fatransfer
                            if (dtLi.Rows[i]["fatransfer"] == "1")
                            {
                                name = "EDI";
                            }
                            else
                            {
                                name = dtLi.Rows[i]["fatransfer"].ToString();
                            }
                            if (dtLi.Rows[i]["deleted"] == "Y")
                            {
                                Dtemp.Rows[i]["Tally Transfered"] = "Cancelled" + "-" + name;
                            }
                            else
                            {
                                Dtemp.Rows[i]["Tally Transfered"] = dtLi.Rows[i]["deleted"].ToString();
                            }
                        }
                    }
                    amout = amt;
                    Dtemp.Rows.Add();
                    Dtemp.Rows[Dtemp.Rows.Count - 1]["Customername"] = "Total";
                    Dtemp.Rows[Dtemp.Rows.Count - 1]["DNAmount"] = amout.ToString("#0.00");
                    grd_DncnJobClosing.DataSource = Dtemp;
                    ViewState["Value"] = Dtemp;
                    grd_DncnJobClosing.DataBind();
                    return;
                }
                else
                {
                    grd_DncnJobClosing.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd_DncnJobClosing.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "CN After JobClosing")
            {
                string type = "";
                double amout = 0;
                double amt = 0;
                int m = 1;
                obj_dt = costtempobj.GetRetriveCNJobClosing(int_bid, Convert.ToInt32(Session["Vouyear"]), dt_fromdate, dt_todate);
                DataTable dtnew = new DataTable();
                if (obj_dt.Rows.Count > 0)
                {
                    DataTable Dtemp = new DataTable();
                    //Dtemp.Columns.Add("Product");
                    Dtemp.Columns.Add("SI#");
                    Dtemp.Columns.Add("Cn#");
                    Dtemp.Columns.Add("Cndate");
                    Dtemp.Columns.Add("Closeddate");
                    // Dtemp.Columns.Add("trantype");
                    Dtemp.Columns.Add("Job#");
                    Dtemp.Columns.Add("Bl#");
                    Dtemp.Columns.Add("Customername");
                    Dtemp.Columns.Add("CNAmount");
                    Dtemp.Columns.Add("Approvedon");
                    Dtemp.Columns.Add("Tally Transfered");
                    DataView dv_co = new DataView(obj_dt);
                    dtnew = dv_co.ToTable(true, "trantype");
                    dv_co = new DataView(dtnew);
                    dv_co.Sort = "trantype";
                    dtnew = dv_co.ToTable();
                    string name = "";
                    for (int j = 0; j <= dtnew.Rows.Count - 1; j++)
                    {
                        DataTable dtLi = new DataTable();
                        DataView data1 = obj_dt.DefaultView;
                        data1.RowFilter = "trantype = '" + dtnew.Rows[j]["trantype"] + "' ";
                        dtLi = data1.ToTable();
                        for (i = 0; i <= dtLi.Rows.Count - 1; i++)
                        {
                            // Dtemp.Rows.Add();
                            //if (i != 0)
                            //{
                            Dtemp.Rows.Add();
                            // }
                            Dtemp.Rows[i]["SI#"] = m + i;
                            Dtemp.Rows[i]["Cn#"] = dtLi.Rows[i]["cnno"];
                            Dtemp.Rows[i]["Cndate"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["cndate"]).ToShortDateString());
                            Dtemp.Rows[i]["Closeddate"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["closeddate"]).ToShortDateString());
                            if (dtLi.Rows[i]["trantype"] == "FE")
                            {
                                type = "OE";
                            }
                            else if (dtLi.Rows[i]["trantype"] == "FI")
                            {
                                type = "OI";
                            }
                            else
                            {
                                type = dtLi.Rows[i]["trantype"].ToString();
                            }
                            Dtemp.Rows[i]["Job#"] = dtLi.Rows[i]["jobno"] + "-" + type;
                            Dtemp.Rows[i]["Customername"] = dtLi.Rows[i]["customername"];
                            Dtemp.Rows[i]["CNAmount"] = dtLi.Rows[i]["amount"];
                            amt = amt + Convert.ToDouble(dtLi.Rows[i]["amount"]);
                            Dtemp.Rows[i]["Approvedon"] = Utility.fn_ConvertDate(Convert.ToDateTime(dtLi.Rows[i]["approvedon"]).ToShortDateString());
                            //fatransfer
                            if (dtLi.Rows[0]["fatransfer"] == "1")
                            {
                                name = "EDI";
                            }
                            else
                            {
                                name = dtLi.Rows[0]["fatransfer"].ToString();
                            }
                            if (dtLi.Rows[i]["deleted"] == "Y")
                            {
                                Dtemp.Rows[i]["Tally Transfered"] = "Cancelled" + "-" + name;
                            }
                            else
                            {
                                Dtemp.Rows[i]["Tally Transfered"] = dtLi.Rows[i]["deleted"].ToString();
                            }
                        }
                    }
                    amout = amt;
                    Dtemp.Rows.Add();
                    Dtemp.Rows[Dtemp.Rows.Count - 1]["Customername"] = "Total";
                    Dtemp.Rows[Dtemp.Rows.Count - 1]["CNAmount"] = amout.ToString("#0.00");
                    grd_DncnJobClosing.DataSource = Dtemp;
                    ViewState["Value"] = Dtemp;
                    grd_DncnJobClosing.DataBind();
                    return;
                }
                else
                {
                    grd_DncnJobClosing.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd_DncnJobClosing.DataBind();
                    return;
                }
            }//------------Muthu Raj
            else if (ddlSelect.SelectedItem.Text == "Receipt")
            {
                //DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();
                obj_dt = obipay.sp_receipt(Convert.ToInt32(Session["LoginDivisionId"]), dt_fromdate, dt_todate);
                if (obj_dt.Rows.Count > 0)
                {
                    Double amount = 0;
                    amount = Convert.ToDouble(obj_dt.Compute("sum(receiptamount)", ""));
                    int count = obj_dt.Rows.Count;
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["customername"] = "Total";
                    obj_dt.Rows[count]["receiptamount"] = amount.ToString("#,0.00");
                    Grid_Receipt.Visible = true;
                    Grid_Receipt.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    Grid_Receipt.DataBind();
                    return;

                }
                else
                {
                    Grid_Receipt.Visible = true;
                    Grid_Receipt.DataSource = "";
                    
                    Grid_Receipt.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "Payment")
            {
                //DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();
                obj_dt = obipay.sp_payments(Convert.ToInt32(Session["LoginDivisionId"]), dt_fromdate, dt_todate);
                if (obj_dt.Rows.Count > 0)
                {
                    Double amount = 0;
                    amount = Convert.ToDouble(obj_dt.Compute("sum(paymentamount)", ""));
                    int count = obj_dt.Rows.Count;
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["customername"] = "Total";
                    obj_dt.Rows[count]["paymentamount"] = amount.ToString("#,0.00");
                    Grid_payment.Visible = true;
                    Grid_payment.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    Grid_payment.DataBind();
                    return;
                }
                else
                {
                    Grid_payment.Visible = true;
                    Grid_payment.DataSource = "";
                   
                    Grid_payment.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "OS Receipt")
            {
                //DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();

                obj_dt = obipay.sp_osreceipt(Convert.ToInt32(Session["LoginDivisionId"]), dt_fromdate, dt_todate);
                if (obj_dt.Rows.Count > 0)
                {
                    Double amount = 0;
                    amount = Convert.ToDouble(obj_dt.Compute("sum(receiptamount)", ""));
                    int count = obj_dt.Rows.Count;
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["customername"] = "Total";
                    obj_dt.Rows[count]["receiptamount"] = amount.ToString("#,0.00");
                    Grid_Osreceipt.Visible = true;
                    Grid_Osreceipt.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    Grid_Osreceipt.DataBind();
                    return;
                }
                else
                {
                    Grid_Osreceipt.Visible = true;
                    Grid_Osreceipt.DataSource = "";
                  
                    Grid_Osreceipt.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "OS Payment")
            {
               // DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();
                obj_dt = obipay.sp_ospayments(Convert.ToInt32(Session["LoginDivisionId"]), dt_fromdate, dt_todate);
                if (obj_dt.Rows.Count > 0)
                {
                    Double amount = 0;
                    amount = Convert.ToDouble(obj_dt.Compute("sum(paymentamount)", ""));
                    int count = obj_dt.Rows.Count;
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["customername"] = "Total";
                    obj_dt.Rows[count]["paymentamount"] = amount.ToString("#,0.00");
                    Grid_ospayment.Visible = true;
                    Grid_ospayment.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    Grid_ospayment.DataBind();
                    return;
                }
                else
                {
                    Grid_ospayment.Visible = true;
                    Grid_ospayment.DataSource = "";
                   Grid_ospayment.DataBind();
                }
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt - Cheque Bounce")
            {
               // DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();
                obj_dt = obipay.spreceiptchecquebounce(Convert.ToInt32(Session["LoginBranchid"]), dt_fromdate, dt_todate);
                if (obj_dt.Rows.Count > 0)
                {
                    Double amount = 0;
                    amount = Convert.ToDouble(obj_dt.Compute("sum(receiptamount)", ""));
                    int count = obj_dt.Rows.Count;
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["customername"] = "Total";
                    obj_dt.Rows[count]["receiptamount"] = amount.ToString("#,0.00");
                    Grid_chequebounce.Visible = true;
                    Grid_chequebounce.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    Grid_chequebounce.DataBind();
                    return;
                }
                else
                {
                    Grid_chequebounce.Visible = true;
                    Grid_chequebounce.DataSource = "";
                      Grid_chequebounce.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "Contra")
            {
              //  DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();
                obj_dt = obipay.sp_contra(Convert.ToDateTime(dt_fromdate), Convert.ToDateTime(dt_todate), int.Parse(Session["LoginDivisionId"].ToString()), Session["FADbname"].ToString());
                if (obj_dt.Rows.Count > 0)
                {
                    Double amount = 0;
                    amount = Convert.ToDouble(obj_dt.Compute("sum(ledgeramount)", ""));
                    int count = obj_dt.Rows.Count;
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["ptc"] = "Total";
                    obj_dt.Rows[count]["ledgeramount"] = amount.ToString("#,0.00");
                    grid_contra.Visible = true;
                    grid_contra.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    grid_contra.DataBind();
                    return;
                }
                else
                {
                    grid_contra.Visible = true;
                    grid_contra.DataSource = "";
                   
                    grid_contra.DataBind();
                    return;
                }
            }

            else if (ddlSelect.SelectedItem.Text == "Payment Cancel")
            {
               // DataAccess.Accounts.Payment obipay = new DataAccess.Accounts.Payment();
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = obipay.SP_PAYMENTCANCEL(0, dt_fromdate, dt_todate, divisionid);
                }
                else
                {
                    obj_dt = obipay.SP_PAYMENTCANCEL(branchid, dt_fromdate, dt_todate);
                }
                //obj_dt = obipay.SP_PAYMENTCANCEL(Convert.ToInt32(Session["LoginDivisionId"]), dt_fromdate, dt_todate);
                if (obj_dt.Rows.Count > 0)
                {
                    Double amount = 0;
                    amount = Convert.ToDouble(obj_dt.Compute("sum(paymentamount)", ""));
                    int count = obj_dt.Rows.Count;
                    obj_dt.Rows.Add();
                    obj_dt.Rows[count]["customername"] = "Total";
                    obj_dt.Rows[count]["paymentamount"] = amount.ToString("#,0.00");
                    grid_paymentcancel.Visible = true;
                    grid_paymentcancel.DataSource = obj_dt;
                    ViewState["Value"] = obj_dt;
                    grid_paymentcancel.DataBind();
                    return;
                }
                else
                {
                    grid_paymentcancel.Visible = true;
                    grid_paymentcancel.DataSource = "";
                  
                    grid_paymentcancel.DataBind();
                    return;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "BOS")
            {

                Grd_Invoice.Visible = true;
                r = 0;

                obj_dt = objInv.GetInvoiceRegBOS(dt_fromdate, dt_todate, int_bid);
                obj_dt.Columns.Remove("trantype");
                obj_dt.Columns.Remove("branchname");
                obj_dt.Columns.Remove("portname");
                obj_dt.Columns.Remove("branchid");
                obj_dt.Columns.Remove("deleted");

                r = obj_dt.Rows.Count;

                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        string amt = obj_dt.Rows[i]["amount"].ToString();
                        if (amt == "" || amt == "0")
                        {
                            amt = "0.00";
                        }
                        total = total + Convert.ToDouble(amt);
                    }
                }
                dtrow = obj_dt.NewRow();
                obj_dt.Rows.Add();
                obj_dt.Rows[r]["customername"] = "Total";
                obj_dt.Rows[r]["amount"] = total.ToString("#,0.00");
                Grd_Invoice.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                Grd_Invoice.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "Invoice-GST" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST" || ddlSelect.SelectedItem.Text == "Credit Note-GST" || ddlSelect.SelectedItem.Text == "Debit Note-GST" || ddlSelect.SelectedItem.Text == "CN-Admin-GST" || ddlSelect.SelectedItem.Text == "DN-Admin-GST" || ddlSelect.SelectedItem.Text == "OSDN-GST" || ddlSelect.SelectedItem.Text == "OSCN-GST" || ddlSelect.SelectedItem.Text == "BOS-GST")
            {
                Grid_xl_bind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST Chargewise")
            {
                Grid_xl_bind();
                return;
            }


            else if (ddlSelect.SelectedItem.Text == "VoucherwiseReceipt-Bank")
            {
                GrdVouReceipt.Visible = true;
                double amt = 0;
                string payment;
                r = 0;
                DataTable dt = new DataTable();
                DataRow datatrow;
                string mode = "B";
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRecPmtDtls("R", dt_fromdate, dt_todate, mode, 0);
                }
                else
                {
                    obj_dt = objInv.GetRecPmtDtls("R", dt_fromdate, dt_todate, mode, int_bid);
                }


                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        payment = obj_dt.Rows[i]["VoucherAmount"].ToString();
                        if (payment == "" || payment == "0")
                        {
                            payment = "0.00";
                        }
                        amt = amt + Convert.ToDouble(payment);
                    }
                    datatrow = obj_dt.NewRow();
                    datatrow["VoucherType"] = "Total";
                    datatrow["VoucherAmount"] = amt.ToString("#,0.00");
                    obj_dt.Rows.Add(datatrow);
                }

                GrdVouReceipt.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GrdVouReceipt.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "VoucherwiseReceipt-Cash")
            {
                GrdVouReceipt.Visible = true;
                double amt = 0;
                string payment;
                r = 0;
                DataTable dt = new DataTable();
                DataRow datatrow;
                string mode = "C";
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRecPmtDtls("R", dt_fromdate, dt_todate, mode, 0);
                }
                else
                {
                    obj_dt = objInv.GetRecPmtDtls("R", dt_fromdate, dt_todate, mode, int_bid);
                }


                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        payment = obj_dt.Rows[i]["VoucherAmount"].ToString();
                        if (payment == "" || payment == "0")
                        {
                            payment = "0.00";
                        }
                        amt = amt + Convert.ToDouble(payment);
                    }
                    datatrow = obj_dt.NewRow();
                    datatrow["VoucherType"] = "Total";
                    datatrow["VoucherAmount"] = amt.ToString("#,0.00");
                    obj_dt.Rows.Add(datatrow);
                }
                GrdVouReceipt.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GrdVouReceipt.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "VoucherwisePayment-Bank")
            {
                GrdVouPayment.Visible = true;
                double amt = 0;
                string payment;
                r = 0;
                DataTable dt = new DataTable();
                DataRow datatrow;
                string mode = "B";
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRecPmtDtls("P", dt_fromdate, dt_todate, mode, 0);
                }
                else
                {
                    obj_dt = objInv.GetRecPmtDtls("P", dt_fromdate, dt_todate, mode, int_bid);
                }


                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        payment = obj_dt.Rows[i]["VoucherAmount"].ToString();
                        if (payment == "" || payment == "0")
                        {
                            payment = "0.00";
                        }
                        amt = amt + Convert.ToDouble(payment);
                    }
                    datatrow = obj_dt.NewRow();
                    datatrow["VoucherType"] = "Total";
                    datatrow["VoucherAmount"] = amt.ToString("#,0.00");
                    obj_dt.Rows.Add(datatrow);
                }
                GrdVouPayment.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GrdVouPayment.DataBind();
                return;
            }
            else if (ddlSelect.SelectedItem.Text == "VoucherwisePayment-Cash")
            {
                GrdVouPayment.Visible = true;
                double amt = 0;
                string payment;
                r = 0;
                DataTable dt = new DataTable();
                DataRow datatrow;
                string mode = "C";
                if (chkConsolidate.Checked == true)
                {
                    obj_dt = objInv.GetRecPmtDtls("P", dt_fromdate, dt_todate, mode, 0);
                }
                else
                {
                    obj_dt = objInv.GetRecPmtDtls("P", dt_fromdate, dt_todate, mode, int_bid);
                }


                r = obj_dt.Rows.Count;
                if (obj_dt.Rows.Count > 0)
                {
                    for (i = 0; i <= obj_dt.Rows.Count - 1; i++)
                    {
                        payment = obj_dt.Rows[i]["VoucherAmount"].ToString();
                        if (payment == "" || payment == "0")
                        {
                            payment = "0.00";
                        }
                        amt = amt + Convert.ToDouble(payment);
                    }
                    datatrow = obj_dt.NewRow();
                    datatrow["VoucherType"] = "Total";
                    datatrow["VoucherAmount"] = amt.ToString("#,0.00");
                    obj_dt.Rows.Add(datatrow);
                }
                GrdVouPayment.DataSource = obj_dt;
                ViewState["Value"] = obj_dt;
                GrdVouPayment.DataBind();
                return;
            }

            int Emp_ID = Convert.ToInt32(Session["LoginEmpId"]);
            int BranchId = Convert.ToInt32(Session["LoginBranchid"].ToString());
           
             logobj.InsLogDetail(Emp_ID, 1783, 3, BranchId, "/V");
        
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        protected void btn_Export_Click(object sender, EventArgs e)
        {
            int int_Empid = 0, int_bid = 0, int_divisionid = 0;
            string Str_SelectedText = "", Str_FileName = "";
            DateTime dt_fromdate, dt_todate;
            dt_fromdate = DateTime.Parse(Utility.fn_ConvertDate(txt_from.Text));
            dt_todate = DateTime.Parse(Utility.fn_ConvertDate(txt_to.Text));
            int_Empid = int.Parse(Session["LoginEmpId"].ToString());
            int_bid = int.Parse(Session["LoginBranchid"].ToString());
            int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            DataTable obj_dt = new DataTable();
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            //DataAccess.ServicetaxReg obj_da_Services = new DataAccess.ServicetaxReg();
            if (ddlSelect.SelectedItem.Text == "Sales Invoice")
            {
                Str_FileName = "Invoice Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Inter Branch Billing")
            {
                obj_da_Cost.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(Session["countryid"].ToString()));
                Str_FileName = "Inter Branch Billing Details from " + txt_from.Text + " To " + txt_to.Text;
            }
            else if (ddlSelect.SelectedItem.Text == "Inter Company Billing")
            {
                obj_da_Cost.InsTempInternalBillingBranch(dt_fromdate, dt_todate, int_Empid, int_bid, Convert.ToInt32(Session["countryid"].ToString()));
                //obj_dt = obj_da_Cost.SelTempInternalBillingBranch(int_Empid, int_bid);
                Str_FileName = "Inter Company Billing Details from " + txt_from.Text + " To " + txt_to.Text;
            }
            else if (ddlSelect.SelectedItem.Text == "Purchase Invoice")
            {
                //obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "PA", dt_fromdate, dt_todate, "R");
                Str_FileName = "PaymentAdvise Register";
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-Inv,DN")
            {
                obj_da_Cost.InsSTChargewise(int_bid, int.Parse(Session["Vouyear"].ToString()), int_Empid, dt_fromdate, dt_todate, "Inc");
                //obj_dt = obj_da_Cost.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                Str_FileName = "Invoice ChargeWise Register";
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-CNOps,CN")
            {
                obj_da_Cost.InsSTChargewise(int_bid, int.Parse(Session["Vouyear"].ToString()), int_Empid, dt_fromdate, dt_todate, "Exp");
                //obj_dt = obj_da_Cost.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                Str_FileName = "PaymentAdvise ChargeWise Register";
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-DN")
            {
                obj_da_Cost.InsSTChargewise(int_bid, int.Parse(Session["Vouyear"].ToString()), int_Empid, dt_fromdate, dt_todate, "D");
                //obj_dt = obj_da_Cost.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                Str_FileName = "Other DebitNote ChargeWise Register";
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-CN")
            {
                obj_da_Cost.InsSTChargewise(int_bid, int.Parse(Session["Vouyear"].ToString()), int_Empid, dt_fromdate, dt_todate, "C");
                //obj_dt = obj_da_Cost.SelExcelVoucherCharSt(int_bid, int_Empid, "Y");
                Str_FileName = "Other CreditNote ChargeWise Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Debit Note")
            {
                // obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "OSSI", dt_fromdate, dt_todate, "R");
                Str_FileName = "DebitNote Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Credit Note")
            {
                //obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "OSPI", dt_fromdate, dt_todate, "R");
                Str_FileName = "CreditNote Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Other DebitNote")
            {
                // obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "DN", dt_fromdate, dt_todate, "R");
                Str_FileName = "Other DebitNote Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Other CreditNote")
            {
                //obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "CN", dt_fromdate, dt_todate, "R");
                Str_FileName = "Other CreditNote Register";
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Inv")
            {
                //obj_dt = obj_da_Services.SelServiceTaxReg(int_bid, 'I', dt_fromdate, dt_todate);
                Str_FileName = "Service Tax Invoice Register";
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax- CN Ops")
            {
                //obj_dt = obj_da_Services.SelServiceTaxReg(int_bid, 'P', dt_fromdate, dt_todate);
                Str_FileName = "Service Tax PaymentAdvise Register";
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other DN")
            {
                // obj_dt = obj_da_Services.SelServiceTaxReg(int_bid, 'V', dt_fromdate, dt_todate);
                Str_FileName = "Service Tax Other Debit Note";
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other CN")
            {
                //obj_dt = obj_da_Services.SelServiceTaxReg(int_bid, 'E', dt_fromdate, dt_todate);
                Str_FileName = "Service Tax Other Credit Note";
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt-Bank")
            {
                // obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "RB", dt_fromdate, dt_todate, "R");
                Str_FileName = "Receipt-Bank Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt-Cash")
            {
                // obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "RC", dt_fromdate, dt_todate, "R");
                Str_FileName = "Receipt-Cash Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Payment-Bank")
            {
                // obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "PB", dt_fromdate, dt_todate, "R");
                Str_FileName = "Payment-Bank Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Payment-Cash")
            {
                //obj_dt = obj_da_Cost.SelExcelVoucherReg(int_bid, "PC", dt_fromdate, dt_todate, "R");
                Str_FileName = "Payment-Cash Register";
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-Inv,DN")
            {
                //obj_da_Cost.DelChargeWST(int_Empid);
                //obj_da_Cost.InsChargeWSTExp(dt_fromdate, dt_todate, int_bid, int.Parse(hid_chargeid.Value.ToString()), int_Empid);
                //obj_dt = obj_da_Cost.SelExcelVoucherCharSt(int_bid, int_Empid, "N");
                Str_FileName = "Services Tax Ledgerwise (Inv / DN)";
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-CNOps,CN")
            {
                //obj_da_Cost.DelChargeWST(int_Empid);
                //obj_da_Cost.InsChargeWSTExp(dt_fromdate, dt_todate, int_bid, int.Parse(hid_chargeid.Value.ToString()), int_Empid);
                //obj_dt = obj_da_Cost.SelExcelVoucherCharSt(int_bid, int_Empid, "N");
                Str_FileName = "Services Tax Ledgerwise (CN-Ops / CN)";
            }
            else if (ddlSelect.SelectedItem.Text == "Debit Note-Admin")
            {
                Str_FileName = "Debit Note-Admin";
            }
            else if (ddlSelect.SelectedItem.Text == "Credit Note-Admin")
            {
                Str_FileName = "Credit Note-Admin";
            }
            else if (ddlSelect.SelectedItem.Text == "Reversal Billing")
            {
                Str_FileName = "Reversal Billing";
            }
            else if (ddlSelect.SelectedItem.Text == "Purchase Invoice")
            {
                Str_FileName = "Purchase Invoice";
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax- CN Ops")
            {
                Str_FileName = "ServiceTax- CN Ops";
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other DN")
            {
                Str_FileName = "ServiceTax-Other DN";
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-Inv,DN")
            {
                Str_FileName = "Ledgerwise-Inv,DN";
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other CN")
            {
                Str_FileName = "ServiceTax-Other CN";
            }
            else if (ddlSelect.SelectedItem.Text == "TDS")
            {
                Str_FileName = "TDS";
            }
            else if (ddlSelect.SelectedItem.Text == "TDS With Type")
            {
                Str_FileName = "TDS With Type";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Sales Inv")
            {
                Str_FileName = "Proforma Sales Inv";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Purchase Inv")
            {
                Str_FileName = "TProforma CN-Operations";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma OSSI")
            {
                Str_FileName = "Proforma OSSI";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma OSPI")
            {
                Str_FileName = "Proforma OSPI";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other DN")
            {
                Str_FileName = "Proforma Other DN";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other CN")
            {
                Str_FileName = "Proforma Other CN";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma DN-Admin")
            {
                Str_FileName = "Proforma DN-Admin";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma CN-Admin")
            {
                Str_FileName = "Proforma CN-Admin";
            }//-----Muthuraj

            else if (ddlSelect.SelectedItem.Text == "Proforma Sales Inv Pending")
            {
                Str_FileName = "Proforma Sales Inv Pending";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Purchase Inv Pending")
            {
                Str_FileName = "Proforma Purchase Inv Pending";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma OSSI Pending")
            {
                Str_FileName = "Proforma OSSI Pending";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma OSPI Pending")
            {
                Str_FileName = "Proforma OSPI Pending";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other DN Pending")
            {
                Str_FileName = "Proforma Other DN Pending";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other CN Pending")
            {
                Str_FileName = "Proforma Other CN Pending";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma DN-Admin Pending")
            {
                Str_FileName = "Proforma DN-Admin Pending";
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma CN-Admin Pending")
            {
                Str_FileName = "Proforma CN-Admin Pending";
            }








            else if (ddlSelect.SelectedItem.Text == "Receipt")
            {
                Str_FileName = "Receipt";
            }
            else if (ddlSelect.SelectedItem.Text == "Payment")
            {
                Str_FileName = "Payment";
            }
            else if (ddlSelect.SelectedItem.Text == "OS Receipt")
            {
                Str_FileName = "OS Receipt";
            }
            else if (ddlSelect.SelectedItem.Text == "OS Payment")
            {
                Str_FileName = "OS Payment";
            }
            else if (ddlSelect.SelectedItem.Text == "Contra")
            {
                Str_FileName = "Contra";
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt - Cheque Bounce")
            {
                Str_FileName = "Receipt - Cheque Bounce";
            }
            else if (ddlSelect.SelectedItem.Text == "Payment Cancel")
            {
                Str_FileName = "Payment Cancel";
            }
            else if (ddlSelect.SelectedItem.Text == "Service Tax")
            {
                Str_FileName = "Service Tax Register for the period of " + dt_fromdate + " to " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Voucherwise")
            {
                //DataTable dt_TDS = new DataTable();
                //Str_FileName = "Customerwise TDS Deductions for the period of " + dt_fromdate + " to " + dt_todate;
                //Obj_TDS.InsFATDS(int_Empid, int_bid, dt_fromdate, dt_todate, int_divisionid);
                //dt_TDS = Obj_TDS.GetTDSEXCEL(int_Empid);
                // if (dt_TDS.Rows.Count > 0)
                //{
                //    ViewState["Value"] = (DataTable)dt_TDS;
                //}
                Str_FileName = "Customerwise TDS Deductions for the period of " + dt_fromdate + " to " + dt_todate;
                if (tds_VoucherWise.Rows.Count > 0 && tds_VoucherWise.Visible == true)
                {


                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=" + Str_FileName + ".xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    int Count = tds_VoucherWise.Columns.Count;

                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");
                    SB.Append("</table><br />");

                    if (tds_VoucherWise.Visible == true)
                    {
                        tds_VoucherWise.GridLines = GridLines.Both;
                        tds_VoucherWise.HeaderStyle.Font.Bold = true;
                        tds_VoucherWise.RenderControl(HtmlTextWriter);
                    }
                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Voucherwise ALL")
            {
                DataTable dt_TDSAll = new DataTable();
                Str_FileName = "Customerwise TDS Deductions for the period of " + dt_fromdate + " to " + dt_todate;
                Obj_TDS.InsFATDSALL(int_Empid, int_bid, dt_fromdate, dt_todate, int_divisionid);
                dt_TDSAll = Obj_TDS.GetTDSEXCELALL(int_Empid);
                if (dt_TDSAll.Rows.Count > 0)
                {
                    ViewState["Value"] = (DataTable)dt_TDSAll;
                }
                Str_FileName = "Customerwise TDS Deductions for the period of" + dt_fromdate + " to " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "Internal Billing Branch")
            {
                Str_FileName = "Internal Billing Charges Details for " + txt_charge.Text + " from " + dt_fromdate + " to " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "DN After JobClosing")
            {
                Str_FileName = "Debit Note Raised After Job Closing";
            }
            else if (ddlSelect.SelectedItem.Text == "CN After JobClosing")
            {
                Str_FileName = "Credit Note Raised After Job Closing";
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise Inc  & Exp")
            {
                DataTable dt_ledger = new DataTable();
                if (int_bid == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "VoucherRegister", "alertify.alert('Kindly Select the Branch);", true);
                    return;
                }
                Str_FileName = "Ledgerwise Income and Expenses Details from " + dt_fromdate + " To " + dt_todate;
                dt_ledger = costtempobj.TempChargesWSTInc4NewReport(dt_fromdate, dt_todate, int_bid, Convert.ToInt32(hid_chargeid.Value), int_Empid);
                if (dt_ledger.Rows.Count > 0)
                {
                    ViewState["Value"] = (DataTable)dt_ledger;
                }
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Summary")
            {
                Str_FileName = "Branchwise TDS Deductions for the period of" + dt_fromdate + " To " + dt_todate;
            }//-------------Karthika_K
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-PA")
            {
                Str_FileName = "ServiceTax Credit Note - Operations Register for the period of " + dt_fromdate + " To " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-PA,CN")
            {
                Str_FileName = "Service Tax Details(PaymentAdvise & CN) From " + dt_fromdate + " To " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-AdminDN")
            {
                Str_FileName = "Service Tax Ledgerwise (Admin DN) for the period of " + dt_fromdate + " To " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-AdminPA")
            {
                Str_FileName = "Service Tax Ledgerwise (Admin PA) for the period of " + dt_fromdate + " To " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "OnAccount Receipt")
            {
                Str_FileName = "On Account - Receipt Register for the period of " + dt_fromdate + " To " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "OnAccount Payment")
            {
                Str_FileName = "On Account - Payment Register for the period of " + dt_fromdate + " To " + dt_todate;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Receivable")
            {
                Str_FileName = "Received From : TDS Receivable Register for the period of " + dt_fromdate + " To " + dt_todate;
                int Count;
                if (GrdReceivable.Rows.Count > 0 && GrdReceivable.Visible == true)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=" + Str_FileName + ".xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    Count = GrdReceivable.Columns.Count;

                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");
                    SB.Append("</table><br />");

                    if (GrdReceivable.Visible == true)
                    {
                        GrdReceivable.GridLines = GridLines.Both;
                        GrdReceivable.HeaderStyle.Font.Bold = true;
                        GrdReceivable.RenderControl(HtmlTextWriter);
                    }
                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Payable")
            {
                int Count;
                Str_FileName = "Payment To : TDS Payable Register for the period of " + dt_fromdate + " To " + dt_todate;
                if (GrdPayable.Rows.Count > 0 && GrdPayable.Visible == true)
                {
                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=" + Str_FileName + ".xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    Count = GrdPayable.Columns.Count;

                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");
                    SB.Append("</table><br />");

                    if (GrdPayable.Visible == true)
                    {
                        GrdPayable.GridLines = GridLines.Both;
                        GrdPayable.HeaderStyle.Font.Bold = true;
                        GrdPayable.RenderControl(HtmlTextWriter);
                    }
                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else if (ddlSelect.SelectedItem.Text == "GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST Chargewise")
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=GST_XL_Chargewise.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                if (Grid_xl.Visible == true)
                {
                    Grid_xl.GridLines = GridLines.Both;
                    Grid_xl.HeaderStyle.Font.Bold = true;
                    Grid_xl.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "Invoice-GST" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST" || ddlSelect.SelectedItem.Text == "Debit Note-GST" || ddlSelect.SelectedItem.Text == "Credit Note-GST" || ddlSelect.SelectedItem.Text == "CN-Admin-GST" || ddlSelect.SelectedItem.Text == "DN-Admin-GST" || ddlSelect.SelectedItem.Text == "OSDN-GST" || ddlSelect.SelectedItem.Text == "OSCN-GST" || ddlSelect.SelectedItem.Text == "BOS-GST")
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=GST_XL.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                if (Grid_xl_head.Visible == true)
                {
                    Grid_xl_head.GridLines = GridLines.Both;
                    Grid_xl_head.HeaderStyle.Font.Bold = true;
                    Grid_xl_head.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else if (Grid_xl.Rows.Count > 0 && Grid_xl.Visible == true)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=GST_XL.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                if (Grid_xl.Visible == true)
                {
                    Grid_xl.GridLines = GridLines.Both;
                    Grid_xl.HeaderStyle.Font.Bold = true;
                    Grid_xl.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            else if (Grid_xl_head.Rows.Count > 0 && Grid_xl_head.Visible == true)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "Attachment;filename=GST_XL.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                StringBuilder SB = new StringBuilder();
                StringWriter StringWriter = new System.IO.StringWriter(SB);
                HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                if (Grid_xl_head.Visible == true)
                {
                    Grid_xl_head.GridLines = GridLines.Both;
                    Grid_xl_head.HeaderStyle.Font.Bold = true;
                    Grid_xl_head.RenderControl(HtmlTextWriter);
                }
                Response.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }
            if (ViewState["Value"] != null)
            {
                int Count;
                DataTable dt = (DataTable)ViewState["Value"];
                if (dt.Rows.Count > 0)
                {
                    //string strtemp;
                    //strtemp = Utility.Fn_ExportExcel_Datatable(dt, "<tr><td><td><td></td><td><FONT FACE=arial SIZE=2>" + Str_FileName + "</td></tr>");
                    //Response.Clear();
                    //Response.AddHeader("Content-Disposition", "Attachment;Filename=" + Str_FileName + ".xls");
                    //Response.Buffer = true;
                    //Response.Charset = "UTF-8";
                    //Response.ContentType = "application/vnd.ms-excel";
                    //Response.Write(strtemp);
                    //Response.End();
                    GridView grdexcel = new GridView();
                    grdexcel.DataSource = null;
                    grdexcel.DataBind();
                    Response.Clear();
                    Response.AddHeader("content-disposition", "Attachment;filename=VoucherwiseDetails.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.xls";
                    StringBuilder SB = new StringBuilder();
                    StringWriter StringWriter = new System.IO.StringWriter(SB);
                    HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
                    grdexcel.DataSource = dt;
                    grdexcel.DataBind();
                    Count = dt.Columns.Count;
                    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + Count + "><font face=arial size=3><B>" + Session["LoginDivisionName"].ToString() + "</B></font></td></tr>");
                    SB.Append("</table><br />");
                    if (grdexcel.Visible == true)
                    {
                        grdexcel.GridLines = GridLines.Both;
                        grdexcel.HeaderStyle.Font.Bold = true;
                        grdexcel.RenderControl(HtmlTextWriter);
                    }
                    Response.Write(StringWriter.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_Export, typeof(Button), "VoucherDetail", "alertify.alert('Data not Avaliable');", true);
            }
        }
        protected void lst_rbt_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                txt_from.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
                txt_to.Text = txt_from.Text;
                ddlSelect.SelectedIndex = -1;
                ddl_GST.SelectedIndex = -1;
                txt_charge.Text = "";
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                Grd_load();
                txt_charge.Visible = true;
                txt_from.Visible = true;
                txt_saccode.Visible = true;
                txt_to.Visible = true;
                ddl_GST.Visible = true;
                lbl_from.Visible = true;
                lbl_to.Visible = true;
                if (strtrantype == "CA")
                {
                    //ddl_branch.SelectedValue = "ALL";
                    chkConsolidate.Enabled = false;
                    chkConsolidate.Visible = false;
                    ddl_branch.SelectedItem.Text = Session["LoginBranchName"].ToString();
                }
            }
            else
            {
                // this.Response.End();
                if (Session["StrTranType"] != null)
                {
                    if (Session["StrTranType"].ToString() == "CO")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                    else if (Session["StrTranType"].ToString() == "BR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/CorporateHome.aspx");
                    }
                }
                else
                {
                    this.Response.End();
                }
            }
        }
        protected void Grd_Invoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_Invoice.PageIndex = e.NewPageIndex;
            Grd_Invoice.DataSource = ViewState["Value"];
            Grd_Invoice.DataBind();
        }
        protected void Grd_Invoice_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void GrdDebitNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdDebitNote.PageIndex = e.NewPageIndex;
            GrdDebitNote.DataSource = ViewState["Value"];
            GrdDebitNote.DataBind();
        }
        protected void GrdInterBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdInterBranch.PageIndex = e.NewPageIndex;
            GrdInterBranch.DataSource = ViewState["Value"];
            GrdInterBranch.DataBind();
        }
        protected void grdCreditNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCreditNote.PageIndex = e.NewPageIndex;
            grdCreditNote.DataSource = ViewState["Value"];
            grdCreditNote.DataBind();
        }
        protected void grdCreditNoteOp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCreditNoteOp.PageIndex = e.NewPageIndex;
            grdCreditNoteOp.DataSource = ViewState["Value"];
            grdCreditNoteOp.DataBind();
        }
        protected void grdtSTChargewise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdtSTChargewise.PageIndex = e.NewPageIndex;
            grdtSTChargewise.DataSource = ViewState["Value"];
            grdtSTChargewise.DataBind();
        }
        protected void grdDebiteNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDebiteNote.PageIndex = e.NewPageIndex;
            grdDebiteNote.DataSource = ViewState["Value"];
            grdDebiteNote.DataBind();
        }
        protected void Grid_creditNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_creditNote.PageIndex = e.NewPageIndex;
            Grid_creditNote.DataSource = ViewState["Value"];
            Grid_creditNote.DataBind();
        }
        protected void grdOtherDebitNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOtherDebitNote.PageIndex = e.NewPageIndex;
            grdOtherDebitNote.DataSource = ViewState["Value"];
            grdOtherDebitNote.DataBind();
        }
        protected void GrdOtherCrediteNoteOpEr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdOtherCrediteNoteOpEr.PageIndex = e.NewPageIndex;
            GrdOtherCrediteNoteOpEr.DataSource = ViewState["Value"];
            GrdOtherCrediteNoteOpEr.DataBind();
        }
        protected void GrdServiceTaxInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdServiceTaxInvoice.PageIndex = e.NewPageIndex;
            GrdServiceTaxInvoice.DataSource = ViewState["Value"];
            GrdServiceTaxInvoice.DataBind();
        }
        protected void grdServicesTacCnOps_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdServicesTacCnOps.PageIndex = e.NewPageIndex;
            grdServicesTacCnOps.DataSource = ViewState["Value"];
            grdServicesTacCnOps.DataBind();
        }
        protected void grdReceiptBankReg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReceiptBankReg.PageIndex = e.NewPageIndex;
            grdReceiptBankReg.DataSource = ViewState["Value"];
            grdReceiptBankReg.DataBind();
        }
        protected void grdReceiptCashReg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReceiptCashReg.PageIndex = e.NewPageIndex;
            grdReceiptCashReg.DataSource = ViewState["Value"];
            grdReceiptCashReg.DataBind();
        }
        protected void grdTds_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTds.PageIndex = e.NewPageIndex;
            grdTds.DataSource = ViewState["Value"];
            grdTds.DataBind();
        }
        protected void grdTdsType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTdsType.PageIndex = e.NewPageIndex;
            grdTdsType.DataSource = ViewState["Value"];
            grdTdsType.DataBind();
        }
        protected void grdPaymentCashNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPaymentCashNew.PageIndex = e.NewPageIndex;
            grdPaymentCashNew.DataSource = ViewState["Value"];
            grdPaymentCashNew.DataBind();
        }
        protected void GrdPayForBank_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdPayForBank.PageIndex = e.NewPageIndex;
            GrdPayForBank.DataSource = ViewState["Value"];
            GrdPayForBank.DataBind();
        }
        protected void grdProformaInv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProformaInv.PageIndex = e.NewPageIndex;
            grdProformaInv.DataSource = ViewState["Value"];
            grdProformaInv.DataBind();
        }
        protected void grdPerformaOsDN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPerformaOsDN.PageIndex = e.NewPageIndex;
            grdPerformaOsDN.DataSource = ViewState["Value"];
            grdPerformaOsDN.DataBind();
        }
        protected void grdOsCNNew_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdOsCNNew.PageIndex = e.NewPageIndex;
            grdOsCNNew.DataSource = ViewState["Value"];
            grdOsCNNew.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ViewState["Value"];
            GridView1.DataBind();
        }
        protected void GrdInterBranch_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdInterBranch, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void GrdDebitNote_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdDebitNote, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdCreditNote_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCreditNote, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdCreditNoteOp_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdCreditNoteOp, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdDebiteNote_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdDebiteNote, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void Grid_creditNote_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_creditNote, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdOtherDebitNote_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdOtherDebitNote, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void GrdOtherCrediteNoteOpEr_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdOtherCrediteNoteOpEr, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void GrdServiceTaxInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdServiceTaxInvoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdServicesTacCnOps_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdServicesTacCnOps, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdReceiptBankReg_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdReceiptBankReg, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdReceiptCashReg_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdReceiptCashReg, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdTds_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdTds, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdTdsType_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdTdsType, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void GrdPayForBank_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GrdPayForBank, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdPaymentCashNew_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdPaymentCashNew, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdProformaInv_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdProformaInv, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdPerformaOsDN_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdPerformaOsDN, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdOsCNNew_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdOsCNNew, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_charge.Text = "";
            txt_from.Text = Utility.fn_ConvertDate(logobj.GetDate().ToShortDateString());
            txt_to.Text = txt_from.Text;
            txt_charge.Visible = true;
            txt_from.Visible = true;
            txt_saccode.Visible = true;
            txt_to.Visible = true;
            ddl_GST.Visible = true;
            lbl_from.Visible = true;
            lbl_to.Visible = true;
            Grd_load();
            btn_cancel.Text = "cancel";
            btn_cancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            ddl_GST.SelectedIndex = -1;
            if (ddlSelect.SelectedItem.Text == "Sales Invoice")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Purchase Invoice")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Debit Note")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Credit Note")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Other DebitNote")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Other CreditNote")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Debit Note-Admin")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Credit Note-Admin")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt-Bank")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Payment-Bank")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Receipt-Cash")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Payment-Cash")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Inv")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax- CN Ops")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other DN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-Other CN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-Inv,DN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-CNOps,CN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-Inv,DN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = true;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-CNOps,CN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = true;
            }
            else if (ddlSelect.SelectedItem.Text == "Inter Branch Billing")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Inter Company Billing")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS With Type")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Sales Inv")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Purchase Inv")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma OSDN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma OSPI")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other DN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma Other CN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma DN-Admin")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Proforma CN-Admin")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Reversal Billing")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-DN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-CN")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "ServiceTax-PA")
            {
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "STChargewise-PA,CN")
            {
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-AdminPA")
            {
                txt_charge.Enabled = true;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise-AdminDN")
            {
                txt_charge.Enabled = true;
            }
            else if (ddlSelect.SelectedItem.Text == "OnAccount Receipt")
            {
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "OnAccount Payment")
            {
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Receivable")
            {
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Payable")
            {
                txt_charge.Enabled = false;
            }//------Arun
            else if (ddlSelect.SelectedItem.Text == "Service Tax")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Voucherwise")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Summary")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Ledgerwise Inc  & Exp")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "TDS Voucherwise ALL")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "DN After JobClosing")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "CN After JobClosing")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = false;
            }
            else if (ddlSelect.SelectedItem.Text == "Internal Billing Branch")
            {
                if (lbl_Header.Text == "Pending Approval" || lbl_Header.Text == "Pending Transfer")
                {
                    txt_charge.Enabled = false;
                    txt_from.Enabled = false;
                    txt_to.Enabled = false;
                }
                txt_charge.Enabled = true;
            }
            else if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "Invoice-GST" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST" || ddlSelect.SelectedItem.Text == "Credit Note-GST" || ddlSelect.SelectedItem.Text == "Debit Note-GST" || ddlSelect.SelectedItem.Text == "CN-Admin-GST" || ddlSelect.SelectedItem.Text == "DN-Admin-GST" || ddlSelect.SelectedItem.Text == "OSDN-GST" || ddlSelect.SelectedItem.Text == "OSCN-GST")
            {
                txt_charge.Enabled = false;
                txt_charge.Text = "";
            }
            else if (ddlSelect.SelectedItem.Text == "GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise")
            {
                txt_charge.Enabled = true;
                txt_charge.Text = "";
                txt_charge.Focus();
            }

            if (ddlSelect.SelectedItem.Text == "Proforma Sales Inv Pending" || ddlSelect.SelectedItem.Text == "Proforma Purchase Inv Pending" || ddlSelect.SelectedItem.Text == "Proforma OSSI Pending" || ddlSelect.SelectedItem.Text == "Proforma OSPI Pending" || ddlSelect.SelectedItem.Text == "Proforma Other DN Pending" || ddlSelect.SelectedItem.Text == "Proforma Other CN Pending" || ddlSelect.SelectedItem.Text == "Proforma CN-Admin Pending" || ddlSelect.SelectedItem.Text == "Proforma DN-Admin Pending")
            {

                txt_charge.Visible = false;
                txt_from.Visible = false;
                txt_saccode.Visible = false;
                txt_to.Visible = false;
                ddl_GST.Visible = false;
                lbl_from.Visible = false;
                lbl_to.Visible = false;
            }
        }
        //RAJ
        protected void Grid_xl_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void Grid_xl_bind()
        {
            try
            {
                //txt_charge.Text = "";
                string voutype = "", charge = "";
                DataTable DT_get = new DataTable();
                //DataAccess.Outstanding budgetobj = new DataAccess.Outstanding();
                //DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();
                int bid = 0, did = Convert.ToInt32(Session["LoginDivisionId"]);
                if (ddl_GST.SelectedItem.Text == "B2B")
                {
                    //ddlSelect.SelectedValue = "Invoice-GST";
                    if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "GST Chargewise")
                    {
                        charge = "ALL";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST")
                    {
                        charge = "Invoice";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        charge = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        charge = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        charge = "DN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        charge = "BOS";
                    }
                    voutype = "B2B";
                }
                else if (ddl_GST.SelectedItem.Text == "B2CL")
                {
                    //ddlSelect.SelectedValue = "Invoice-GST";
                    if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "GST Chargewise")
                    {
                        charge = "ALL";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST")
                    {
                        charge = "Invoice";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        charge = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        charge = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        charge = "DN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        charge = "BOS";
                    }
                    voutype = "B2CL";
                }
                else if (ddl_GST.SelectedItem.Text == "B2CS")
                {
                    //ddlSelect.SelectedValue = "Invoice-GST";
                    if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "GST Chargewise")
                    {
                        charge = "ALL";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST")
                    {
                        charge = "Invoice";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        charge = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        charge = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        charge = "DN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        charge = "BOS";
                    }
                    voutype = "B2CS";
                }
                else if (ddl_GST.SelectedItem.Text == "CDNR")
                {
                    if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "GST Chargewise")
                    {
                        charge = "ALL";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        charge = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        charge = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        charge = "DN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST")
                    {
                        charge = "CN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST")
                    {
                        charge = "CN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST")
                    {
                        charge = "OSPI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        charge = "BOS";
                    }
                    voutype = "CDNR";
                }
                else if (ddl_GST.SelectedItem.Text == "CDNUR")
                {
                    if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "GST Chargewise")
                    {
                        charge = "ALL";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        charge = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        charge = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        charge = "DN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST")
                    {
                        charge = "CN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST")
                    {
                        charge = "CN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST")
                    {
                        charge = "OSPI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        charge = "BOS";
                    }
                    voutype = "CDNUR";
                }
                else if (ddl_GST.SelectedItem.Text == "EXP")
                {
                    //ddlSelect.SelectedIndex = -1;
                    voutype = "EXP";
                }
                else if (ddl_GST.SelectedItem.Text == "Exemption")
                {
                    if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "GST Chargewise")
                    {
                        charge = "ALL";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST")
                    {
                        charge = "Invoice";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        charge = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        charge = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        charge = "DN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST")
                    {
                        charge = "CN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST")
                    {
                        charge = "CN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST")
                    {
                        charge = "OSPI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST")
                    {
                        charge = "PA";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        charge = "BOS";
                    }
                    voutype = "Exemption";
                }
                else if (ddl_GST.SelectedItem.Text == "HSN(SAC)")
                {
                    if (ddlSelect.SelectedItem.Text == "GST" || ddlSelect.SelectedItem.Text == "GST Chargewise")
                    {
                        charge = "ALL";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST")
                    {
                        charge = "Invoice";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        charge = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        charge = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        charge = "DN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST")
                    {
                        charge = "CN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST")
                    {
                        charge = "CN-Admin";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST")
                    {
                        charge = "OSPI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST")
                    {
                        charge = "PA";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        charge = "BOS";
                    }
                    voutype = "SAC";
                    txt_saccode.Enabled = true;
                    txt_charge.Enabled = true;
                }
                else
                    if (ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST")
                    {
                        voutype = "Invoice";
                    }
                    else if (ddlSelect.SelectedItem.Text == "GST Chargewise" || ddlSelect.SelectedItem.Text == "GST")
                    {
                        voutype = "All";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST")
                    {
                        voutype = "PA";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST")
                    {
                        voutype = "CN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST")
                    {
                        voutype = "DN";
                    }
                    else if (ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST")
                    {
                        voutype = "CNA";
                    }
                    else if (ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST")
                    {
                        voutype = "DNA";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST")
                    {
                        voutype = "OSSI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST")
                    {
                        voutype = "OSPI";
                    }
                    else if (ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST")
                    {
                        voutype = "BOS";
                    }
                if (ddlSelect.SelectedItem.Text == "GST Chargewise" || ddlSelect.SelectedItem.Text == "Invoice-GST Chargewise" || ddlSelect.SelectedItem.Text == "BOS-GST Chargewise" | ddlSelect.SelectedItem.Text == "Credit Note-Operation-GST Chargewise" || ddlSelect.SelectedItem.Text == "Credit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "Debit Note-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSDN-GST Chargewise" || ddlSelect.SelectedItem.Text == "OSCN-GST Chargewise")
                {
                    txt_charge.Enabled = true;
                    charge = "Charge";
                }
                if (ddl_branch.SelectedValue == "ALL" || ddl_branch.SelectedValue == "CORPORATE")
                {
                    if (voutype == "B2B" || voutype == "B2CL" || voutype == "B2CS" || voutype == "CDNR" || voutype == "CDNUR" || voutype == "EXP" || voutype == "Exemption" || voutype == "SAC")
                    {
                        DT_get = budgetobj.Get_GSTvoucher4xlGSTReport(0, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), voutype, charge); //ddl_GST.SelectedValue,
                    }
                    else
                        if (txt_charge.Text != "" && (hid_chargeid.Value != "" || hid_chargeid.Value != "0"))
                        {
                            DT_get = budgetobj.Get_GSTvoucher4xl4charges(0, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), voutype, Convert.ToInt32(hid_chargeid.Value)); //ddl_GST.SelectedValue,
                        }
                        else
                        {
                            DT_get = budgetobj.Get_GSTvoucher4xl(0, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), voutype, charge); //ddl_GST.SelectedValue,
                        }
                }
                else
                {
                    bid = HREmpobj.GetBranchId(did, ddl_branch.SelectedItem.Text);
                    if (voutype == "B2B" || voutype == "B2CL" || voutype == "B2CS" || voutype == "CDNR" || voutype == "CDNUR" || voutype == "EXP" || voutype == "Exemption" || voutype == "SAC")
                    {
                        DT_get = budgetobj.Get_GSTvoucher4xlGSTReport(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), voutype, charge); //ddl_GST.SelectedValue,
                    }
                    else
                        if (txt_charge.Text != "" && (hid_chargeid.Value != "" || hid_chargeid.Value != "0"))
                        {
                            DT_get = budgetobj.Get_GSTvoucher4xl4charges(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), voutype, Convert.ToInt32(hid_chargeid.Value)); //ddl_GST.SelectedValue,
                        }
                        else
                        {
                            DT_get = budgetobj.Get_GSTvoucher4xl(bid, Convert.ToDateTime(Utility.fn_ConvertDate(txt_from.Text)), Convert.ToDateTime(Utility.fn_ConvertDate(txt_to.Text)), voutype, charge); //ddl_GST.SelectedValue,
                        }
                }
                if (DT_get.Rows.Count > 0)
                {
                    if (charge == "Charge" || voutype == "SAC")
                    {
                        Grid_xl.Visible = true;
                        var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                        var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                        var NonTax = DT_get.Compute("sum(TaxValue)", "");
                        var cgst = DT_get.Compute("sum(cgst)", "");
                        var sgst = DT_get.Compute("sum(sgst)", "");
                        var igst = DT_get.Compute("sum(igst)", "");
                        var taxtotal = DT_get.Compute("sum(taxtotal)", "");
                        var total = DT_get.Compute("sum(total)", "");
                        DataRow dr1 = DT_get.NewRow();
                        DT_get.Rows.Add(dr1);
                        dr1[5] = "Total";
                        //dr1[7] = vouchervalue;
                        dr1[14] = TaxableValue;
                        dr1[15] = NonTax;
                        dr1[17] = cgst;
                        dr1[18] = sgst;
                        dr1[19] = igst;
                        dr1[20] = taxtotal;
                        dr1[21] = total;
                        Grid_xl.DataSource = DT_get;
                        Grid_xl.DataBind();
                        Session["SACCode"] = DT_get;
                    }
                    else
                    {
                        Grid_xl_head.Visible = true;
                        var vouchervalue = DT_get.Compute("sum(vouchervalue)", "");
                        var TaxableValue = DT_get.Compute("sum(TaxableValue)", "");
                        var NonTax = DT_get.Compute("sum(NonTaxableValue)", "");
                        var cgst = DT_get.Compute("sum(cgst)", "");
                        var sgst = DT_get.Compute("sum(sgst)", "");
                        var igst = DT_get.Compute("sum(igst)", "");
                        var taxtotal = DT_get.Compute("sum(taxtotal)", "");
                        var total = DT_get.Compute("sum(total)", "");
                        DataRow dr1 = DT_get.NewRow();
                        DT_get.Rows.Add(dr1);
                        if (ddlSelect.SelectedItem.Text == "Invoice-GST" || ddlSelect.SelectedItem.Text == "BOS-GST" || ddlSelect.SelectedItem.Text == "GST")
                        {
                            dr1[6] = "Total";
                            //dr1[7] = vouchervalue;
                            dr1[13] = TaxableValue;
                            dr1[14] = NonTax;
                            dr1[16] = cgst;
                            dr1[17] = sgst;
                            dr1[18] = igst;
                            dr1[19] = taxtotal;
                            dr1[20] = total;
                            Grid_xl_head.DataSource = DT_get;
                            Grid_xl_head.DataBind();
                        }
                        else
                        {
                            if ( ddlSelect.SelectedItem.Text == "DN-Admin-GST Chargewise" || ddlSelect.SelectedItem.Text == "CN-Admin-GST Chargewise")
                            { 
                                dr1[5] = "Total";
                            //dr1[7] = vouchervalue;
                            dr1[12] = TaxableValue;
                            dr1[13] = NonTax;
                            dr1[15] = cgst;
                            dr1[16] = sgst;
                            dr1[17] = igst;
                            dr1[18] = taxtotal;
                            dr1[19] = total;
                            Grid_xl_head.DataSource = DT_get;
                            Grid_xl_head.DataBind();
                            }
                            else if(ddlSelect.SelectedItem.Text == "CN-Admin-GST" || ddlSelect.SelectedItem.Text == "DN-Admin-GST" )
                            {
                                dr1[6] = "Total";
                                //dr1[7] = vouchervalue;
                                dr1[12] = TaxableValue;
                                dr1[13] = NonTax;
                                dr1[15] = cgst;
                                dr1[16] = sgst;
                                dr1[17] = igst;
                                dr1[18] = taxtotal;
                                dr1[19] = total;
                                Grid_xl_head.DataSource = DT_get;
                                Grid_xl_head.DataBind();

                            }
                            else
                            {

                            dr1[11] = "Total";
                            //dr1[7] = vouchervalue;
                            dr1[12] = TaxableValue;
                            dr1[13] = NonTax;
                            dr1[15] = cgst;
                            dr1[16] = sgst;
                            dr1[17] = igst;
                            dr1[18] = taxtotal;
                            dr1[19] = total;
                            Grid_xl_head.DataSource = DT_get;
                            Grid_xl_head.DataBind();
                            }
                        }
                    }
                    ViewState["Grid_xl"] = DT_get;
                }
                else
                {
                    if (charge == "Charge")
                    {
                        Grid_xl.Visible = true;
                        Grid_xl.DataSource = new DataTable();
                        Grid_xl.DataBind();
                    }
                    else
                    {
                        Grid_xl_head.Visible = true;
                        Grid_xl_head.DataSource = new DataTable();
                        Grid_xl_head.DataBind();
                    }
                }
                txt_charge.Focus();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        //----------Arun
        protected void grd_TdsAll_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string hexfore = "#dbdbdb";
            string hex = "#aaaaaa";
            int int_bid = 0;
            int int_Empid = 0;
            if (strtrantype == "CA")
            {
                int_bid = hrempobj.GetBranchId(Convert.ToInt32(Session["LoginDivisionId"]), ddl_branch.Text);
            }
            else
            {
                int_bid = int.Parse(Session["LoginBranchid"].ToString());
            }
            int_Empid = int.Parse(Session["LoginEmpId"].ToString());
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    //HeaderGridRow.BorderColor = System.Drawing.Color.Chocolate;
                    HeaderGridRow.Font.Bold = true;
                    TableCell HeaderCell = new TableCell();
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Branch";
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Font.Size = 10;
                    // HeaderCell.BorderColor = System.Drawing.Color.Black;
                    HeaderCell.RowSpan = 1;
                    HeaderCell.ColumnSpan = 1;
                    HeaderGridRow.Cells.Add(HeaderCell);
                    dtset = costtempobj.GetTDSSum(int_Empid, int_bid);
                    if (dtset.Tables.Count > 0)
                    {
                        if (dtset.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < dtset.Tables[1].Rows.Count; i++)
                            {
                                HeaderCell = new TableCell();
                                HeaderCell.Text = dtset.Tables[1].Rows[i]["tdstype"].ToString();
                                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                                HeaderCell.Font.Size = 10;
                                // HeaderCell.BorderColor = System.Drawing.Color.Black;
                                HeaderCell.RowSpan = 1;
                                HeaderCell.ColumnSpan = 2;
                                HeaderGridRow.Cells.Add(HeaderCell);
                            }
                            TableCell HeaderCell5 = new TableCell();
                            HeaderCell5 = new TableCell();
                            HeaderCell5.Text = "Total";
                            HeaderCell5.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                            HeaderCell5.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                            HeaderCell5.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell5.Font.Size = 10;
                            // HeaderCell.BorderColor = System.Drawing.Color.Black;
                            HeaderCell5.RowSpan = 1;
                            HeaderCell5.ColumnSpan = 1;
                            HeaderGridRow.Cells.Add(HeaderCell5);
                            grd_TdsAll.Controls[0].Controls.AddAt(0, HeaderGridRow);
                        }
                    }
                    GridView HeaderGrid3 = (GridView)sender;
                    GridViewRow HeaderGridRow3 = new GridViewRow(2, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    //  HeaderGridRow3.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderGridRow3.Font.Bold = true;
                    HeaderGridRow3.CssClass = "clsgridback";
                    //HeaderGridRow3.ForeColor = System.Drawing.Color.White;
                    TableCell HeaderCell32 = new TableCell();
                    HeaderCell32.Text = "";
                    HeaderCell32.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell32.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell32.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell32.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell32.Font.Size = 10;
                    HeaderGridRow3.Cells.Add(HeaderCell32);
                    dtset = costtempobj.GetTDSSum(int_Empid, int_bid);
                    if (dtset.Tables.Count > 0)
                    {
                        if (dtset.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < dtset.Tables[1].Rows.Count; i++)
                            {
                                TableCell HeaderCell33 = new TableCell();
                                HeaderCell33.Text = "Company";
                                HeaderCell33.HorizontalAlign = HorizontalAlign.Center;
                                HeaderCell33.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                                HeaderCell33.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                HeaderCell33.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                                HeaderCell33.Font.Size = 10;
                                HeaderGridRow3.Cells.Add(HeaderCell33);
                                TableCell HeaderCell34 = new TableCell();
                                HeaderCell34.Text = "Non - Company";
                                HeaderCell34.HorizontalAlign = HorizontalAlign.Center;
                                HeaderCell34.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                                HeaderCell34.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                                HeaderCell34.BorderColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                                HeaderCell34.Font.Size = 10;
                                HeaderGridRow3.Cells.Add(HeaderCell34);
                            }
                        }
                    }
                    TableCell HeaderCell6 = new TableCell();
                    HeaderCell6 = new TableCell();
                    HeaderCell6.Text = " ";
                    HeaderCell6.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexfore);
                    HeaderCell6.BackColor = System.Drawing.ColorTranslator.FromHtml(hex);
                    HeaderCell6.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell6.Font.Size = 10;
                    // HeaderCell.BorderColor = System.Drawing.Color.Black;
                    HeaderCell6.RowSpan = 1;
                    HeaderCell6.ColumnSpan = 1;
                    HeaderGridRow3.Cells.Add(HeaderCell6);
                    grd_TdsAll.Controls[0].Controls.AddAt(1, HeaderGridRow3);
                    //  DataSet dtset = new DataSet();
                }
            }
            catch
            {
            }
        }
        protected void grd_SerViceTax_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_SerViceTax.PageIndex = e.NewPageIndex;
            grd_SerViceTax.DataSource = ViewState["Value"];
            grd_SerViceTax.DataBind();
        }
        protected void grd_SerViceTax_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_SerViceTax, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void tds_VoucherWise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tds_VoucherWise.PageIndex = e.NewPageIndex;
            tds_VoucherWise.DataSource = ViewState["Value"];
            tds_VoucherWise.DataBind();
        }
        protected void tds_VoucherWise_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(tds_VoucherWise, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void grd_TdsVouchall_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_TdsVouchall.PageIndex = e.NewPageIndex;
            grd_TdsVouchall.DataSource = ViewState["Value"];
            grd_TdsVouchall.DataBind();
        }
        protected void grd_TdsVouchall_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_TdsVouchall, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void grd_internalBilling_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_internalBilling.PageIndex = e.NewPageIndex;
            grd_internalBilling.DataSource = ViewState["Value"];
            grd_internalBilling.DataBind();
        }
        protected void grd_internalBilling_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_internalBilling, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void grd_DncnJobClosing_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_DncnJobClosing.PageIndex = e.NewPageIndex;
            grd_DncnJobClosing.DataSource = ViewState["Value"];
            grd_DncnJobClosing.DataBind();
        }
        protected void grd_DncnJobClosing_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    if (double.TryParse(e.Row.Cells[7].Text.ToString(), out dbl_temp))
                    {
                        //e.Row.Cells[h].HorizontalAlign = HorizontalAlign.Right;                        
                        // e.Row.Cells[11].Text = dbl_temp.ToString("#,##.00");//string.Format("{0:#,#.00}", dbl_temp); //string.Format("{0:#,##0.00}", dbl_temp);
                        e.Row.Cells[7].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_DncnJobClosing, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void grd_TdsAll_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    if (i != 0)
                    {
                        if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                        {
                            e.Row.Cells[i].Text = dbl_temp.ToString("#.00");
                            e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                        }
                    }
                }
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_TdsAll, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void grd_TdsAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_TdsAll.PageIndex = e.NewPageIndex;
            grd_TdsAll.DataSource = ViewState["Value"];
            grd_TdsAll.DataBind();
        }
        protected void Grd_ServiceTaxPA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_ServiceTaxPA.PageIndex = e.NewPageIndex;
            Grd_ServiceTaxPA.DataSource = ViewState["ServiceTax-PA"] as DataTable;
            Grd_ServiceTaxPA.DataBind();
        }
        protected void Grd_StCharge_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_StCharge.PageIndex = e.NewPageIndex;
            Grd_StCharge.DataSource = ViewState["STChargewise-PA,CN"] as DataTable;
            Grd_StCharge.DataBind();
        }
        protected void Grd_AdminPA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_AdminPA.PageIndex = e.NewPageIndex;
            Grd_AdminPA.DataSource = ViewState["Ledgerwise-AdminPA"] as DataTable;
            Grd_AdminPA.DataBind();
        }
        protected void Grd_AdminDN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_AdminDN.PageIndex = e.NewPageIndex;
            Grd_AdminDN.DataSource = ViewState["Ledgerwise-AdminDN"] as DataTable;
            Grd_AdminDN.DataBind();
        }
        protected void Grd_OnAccountReceipt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_OnAccountReceipt.PageIndex = e.NewPageIndex;
            Grd_OnAccountReceipt.DataSource = ViewState["OnAccountReceipt"] as DataTable;
            Grd_OnAccountReceipt.DataBind();
        }
        protected void Grd_OnAccountPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grd_OnAccountPayment.PageIndex = e.NewPageIndex;
            Grd_OnAccountPayment.DataSource = ViewState["OnAccountPayment"] as DataTable;
            Grd_OnAccountPayment.DataBind();
        }
        protected void GrdReceivable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdReceivable.PageIndex = e.NewPageIndex;
            GrdReceivable.DataSource = ViewState["TDSReceivable"] as DataTable;
            GrdReceivable.DataBind();
        }
        protected void GrdPayable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdPayable.PageIndex = e.NewPageIndex;
            GrdPayable.DataSource = ViewState["TDSPayable"] as DataTable;
            GrdPayable.DataBind();
        }
        private string FillVoucher(string voutypeid)
        {
            if (voutypeid == "I")
            {
                voutypename = "Invoice";
            }
            else if (voutypeid == "P")
            {
                voutypename = "Credit Note - Operations";
            }
            else if (voutypeid == "S")
            {
                voutypename = "Admin Purchase Invoice";
            }
            else if (voutypeid == "X")
            {
                voutypename = "Admin Sales Invoice";
            }
            else if (voutypeid == "D")
            {
                voutypename = "OSSI";
            }
            else if (voutypeid == "C")
            {
                voutypename = "OSPI";
            }
            else if (voutypeid == "V")
            {
                voutypename = "Debit Note - Others";
            }
            else if (voutypeid == "E")
            {
                voutypename = "Credit Note - Others";
            }
            return voutypename;
        }
        protected void Grid_Receipt_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_Receipt, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[5].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
        }
        protected void Grid_Receipt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_Receipt.PageIndex = e.NewPageIndex;
            Grid_Receipt.DataSource = ViewState["Value"];
            Grid_Receipt.DataBind();
        }
        protected void Grid_payment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_payment.PageIndex = e.NewPageIndex;
            Grid_payment.DataSource = ViewState["Value"];
            Grid_payment.DataBind();
        }
        protected void Grid_payment_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_payment, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[5].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
        }
        protected void Grid_Osreceipt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_Osreceipt.PageIndex = e.NewPageIndex;
            Grid_Osreceipt.DataSource = ViewState["Value"];
            Grid_Osreceipt.DataBind();
        }
        protected void Grid_Osreceipt_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_Osreceipt, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[5].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
        }
        protected void Grid_ospayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_ospayment.PageIndex = e.NewPageIndex;
            Grid_ospayment.DataSource = ViewState["Value"];
            Grid_ospayment.DataBind();
        }
        protected void Grid_chequebounce_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grid_chequebounce.PageIndex = e.NewPageIndex;
            Grid_chequebounce.DataSource = ViewState["Value"];
            Grid_chequebounce.DataBind();
        }
        protected void Grid_chequebounce_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grid_chequebounce, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[4].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
        }
        protected void grid_paymentcancel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_paymentcancel.PageIndex = e.NewPageIndex;
            grid_paymentcancel.DataSource = ViewState["Value"];
            grid_paymentcancel.DataBind();
        }
        protected void grid_paymentcancel_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grid_paymentcancel, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[4].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
        }
        protected void grid_contra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_contra.PageIndex = e.NewPageIndex;
            grid_contra.DataSource = ViewState["Value"];
            grid_contra.DataBind();
        }
        protected void grid_contra_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grid_contra, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[5].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
        }
        protected void Grid_ospayment_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#b9ddf7';");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grid_contra, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[5].Text == "Total")
                {
                    e.Row.ForeColor = System.Drawing.Color.Brown;
                    e.Row.Cells[0].Text = "";
                }
            }
        }
        protected void Grid_xl_head_RowDataBound(object sender, GridViewRowEventArgs e)
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
        protected void txt_charge_TextChanged(object sender, EventArgs e)
        {
            if (ViewState["Grid_xl"] != null)
            {
                if (txt_charge.Text != "")
                {
                    DataTable DT_filter = ViewState["Grid_xl"] as DataTable;
                    if (txt_saccode.Text != "")
                    {
                        EnumerableRowCollection<DataRow> query = from Filter in DT_filter.AsEnumerable()
                                                                 where Filter.Field<string>("chargename") == txt_charge.Text && Filter.Field<string>("saccode") == txt_saccode.Text
                                                                 select Filter;
                        DataView view = query.AsDataView();
                        Grid_xl.DataSource = view;
                        Grid_xl.DataBind();
                    }
                    else
                    {
                        EnumerableRowCollection<DataRow> query = from Filter in DT_filter.AsEnumerable()
                                                                 where Filter.Field<string>("chargename") == txt_charge.Text
                                                                 select Filter;
                        DataView view = query.AsDataView();
                        Grid_xl.DataSource = view;
                        Grid_xl.DataBind();
                    }
                }
                else
                {
                    Grid_xl.DataSource = ViewState["Grid_xl"] as DataTable;
                    Grid_xl.DataBind();
                }
            }
        }
        protected void txt_saccode_TextChanged(object sender, EventArgs e)
        {
            if (Session["SACCode"] != null)
            {
                if (txt_saccode.Text != "")
                {
                    if (txt_charge.Text != "")
                    {
                        DataTable DT_filter = Session["SACCode"] as DataTable;
                        EnumerableRowCollection<DataRow> query = from Filter in DT_filter.AsEnumerable()
                                                                 where Filter.Field<string>("saccode") == txt_saccode.Text && Filter.Field<string>("chargename") == txt_charge.Text
                                                                 select Filter;
                        DataView view = query.AsDataView();
                        Grid_xl.DataSource = view;
                        Grid_xl.DataBind();
                    }
                    else
                    {
                        DataTable DT_filter = Session["SACCode"] as DataTable;
                        EnumerableRowCollection<DataRow> query = from Filter in DT_filter.AsEnumerable()
                                                                 where Filter.Field<string>("saccode") == txt_saccode.Text
                                                                 select Filter;
                        DataView view = query.AsDataView();
                        Grid_xl.DataSource = view;
                        Grid_xl.DataBind();
                    }
                }
                else
                {
                    Grid_xl.DataSource = Session["SACCode"] as DataTable;
                    Grid_xl.DataBind();
                }
            }
        }
        protected void grd_pending_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdProformaInv, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";

                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }
        protected void grdprofomaAdminDNCN_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdPerformaOsDN, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
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
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Invoice, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int h = 0; h <= e.Row.Cells.Count - 1; h++)
                {
                    double dbl_temp = 0;
                    if (double.TryParse(e.Row.Cells[h].Text.ToString(), out dbl_temp))
                    {
                        e.Row.Cells[h].Attributes.CssStyle["text-align"] = "Right";
                    }
                }
            }
        }

        protected void Grid_xl_head_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtm = new DataTable();
            if (ViewState["Grid_xl"] != null)
            {
                dtm = (DataTable)ViewState["Grid_xl"];
                if (dtm.Rows.Count > 0)
                {
                    Grid_xl_head.PageIndex = e.NewPageIndex;
                    Grid_xl_head.DataSource = dtm;
                    Grid_xl_head.DataBind();
                }
                else
                {
                    Grid_xl_head.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grid_xl_head.DataBind();
                }

            }
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
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1354, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1783, "", "", "", Session["StrTranType"].ToString());
            }



            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void grdCreditNoteOp_PreRender(object sender, EventArgs e)
        {
          
            if (grdCreditNoteOp.Rows.Count > 0)
            {
                grdCreditNoteOp.UseAccessibleHeader = true;
                grdCreditNoteOp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
  
        }

        protected void Grd_Invoice_PreRender(object sender, EventArgs e)
        {
            if (Grd_Invoice.Rows.Count > 0)
            {
                Grd_Invoice.UseAccessibleHeader = true;
                Grd_Invoice.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdDebiteNote_PreRender(object sender, EventArgs e)
        {
            if (grdDebiteNote.Rows.Count > 0)
            {
                grdDebiteNote.UseAccessibleHeader = true;
                grdDebiteNote.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_creditNote_PreRender(object sender, EventArgs e)
        {
            if (Grid_creditNote.Rows.Count > 0)
            {
                Grid_creditNote.UseAccessibleHeader = true;
                Grid_creditNote.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdOtherDebitNote_PreRender(object sender, EventArgs e)
        {
            if (grdOtherDebitNote.Rows.Count > 0)
            {
                grdOtherDebitNote.UseAccessibleHeader = true;
                grdOtherDebitNote.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdOtherCrediteNoteOpEr_PreRender(object sender, EventArgs e)
        {
            if (GrdOtherCrediteNoteOpEr.Rows.Count > 0)
            {
                GrdOtherCrediteNoteOpEr.UseAccessibleHeader = true;
                GrdOtherCrediteNoteOpEr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdServiceTaxInvoice_PreRender(object sender, EventArgs e)
        {
            if (GrdServiceTaxInvoice.Rows.Count > 0)
            {
                GrdServiceTaxInvoice.UseAccessibleHeader = true;
                GrdServiceTaxInvoice.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdServicesTacCnOps_PreRender(object sender, EventArgs e)
        {
            if (grdServicesTacCnOps.Rows.Count > 0)
            {
                grdServicesTacCnOps.UseAccessibleHeader = true;
                grdServicesTacCnOps.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdReceiptBankReg_PreRender(object sender, EventArgs e)
        {
            if (grdReceiptBankReg.Rows.Count > 0)
            {
                grdReceiptBankReg.UseAccessibleHeader = true;
                grdReceiptBankReg.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdReceiptCashReg_PreRender(object sender, EventArgs e)
        {
            if (grdReceiptCashReg.Rows.Count > 0)
            {
                grdReceiptCashReg.UseAccessibleHeader = true;
                grdReceiptCashReg.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdTds_PreRender(object sender, EventArgs e)
        {
            if (grdTds.Rows.Count > 0)
            {
                grdTds.UseAccessibleHeader = true;
                grdTds.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdTdsType_PreRender(object sender, EventArgs e)
        {
            if (grdTdsType.Rows.Count > 0)
            {
                grdTdsType.UseAccessibleHeader = true;
                grdTdsType.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdPayForBank_PreRender(object sender, EventArgs e)
        {
            if (GrdPayForBank.Rows.Count > 0)
            {
                GrdPayForBank.UseAccessibleHeader = true;
                GrdPayForBank.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdPaymentCashNew_PreRender(object sender, EventArgs e)
        {
            if (grdPaymentCashNew.Rows.Count > 0)
            {
                grdPaymentCashNew.UseAccessibleHeader = true;
                grdPaymentCashNew.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdProformaInv_PreRender(object sender, EventArgs e)
        {
            if (grdProformaInv.Rows.Count > 0)
            {
                grdProformaInv.UseAccessibleHeader = true;
                grdProformaInv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdPerformaOsDN_PreRender(object sender, EventArgs e)
        {
            if (grdPerformaOsDN.Rows.Count > 0)
            {
                grdPerformaOsDN.UseAccessibleHeader = true;
                grdPerformaOsDN.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdOsCNNew_PreRender(object sender, EventArgs e)
        {
            if (grdOsCNNew.Rows.Count > 0)
            {
                grdOsCNNew.UseAccessibleHeader = true;
                grdOsCNNew.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_ServiceTaxPA_PreRender(object sender, EventArgs e)
        {
            if (Grd_ServiceTaxPA.Rows.Count > 0)
            {
                Grd_ServiceTaxPA.UseAccessibleHeader = true;
                Grd_ServiceTaxPA.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_StCharge_PreRender(object sender, EventArgs e)
        {
            if (Grd_StCharge.Rows.Count > 0)
            {
                Grd_StCharge.UseAccessibleHeader = true;
                Grd_StCharge.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_AdminPA_PreRender(object sender, EventArgs e)
        {
            if (Grd_AdminPA.Rows.Count > 0)
            {
                Grd_AdminPA.UseAccessibleHeader = true;
                Grd_AdminPA.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_AdminDN_PreRender(object sender, EventArgs e)
        {
            if (Grd_AdminDN.Rows.Count > 0)
            {
                Grd_AdminDN.UseAccessibleHeader = true;
                Grd_AdminDN.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_OnAccountReceipt_PreRender(object sender, EventArgs e)
        {
            if (Grd_OnAccountReceipt.Rows.Count > 0)
            {
                Grd_OnAccountReceipt.UseAccessibleHeader = true;
                Grd_OnAccountReceipt.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grd_OnAccountPayment_PreRender(object sender, EventArgs e)
        {
            if (Grd_OnAccountPayment.Rows.Count > 0)
            {
                Grd_OnAccountPayment.UseAccessibleHeader = true;
                Grd_OnAccountPayment.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdReceivable_PreRender(object sender, EventArgs e)
        {
            if (GrdReceivable.Rows.Count > 0)
            {
                GrdReceivable.UseAccessibleHeader = true;
                GrdReceivable.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdPayable_PreRender(object sender, EventArgs e)
        {
            if (GrdPayable.Rows.Count > 0)
            {
                GrdPayable.UseAccessibleHeader = true;
                GrdPayable.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_SerViceTax_PreRender(object sender, EventArgs e)
        {
            if (grd_SerViceTax.Rows.Count > 0)
            {
                grd_SerViceTax.UseAccessibleHeader = true;
                grd_SerViceTax.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void tds_VoucherWise_PreRender(object sender, EventArgs e)
        {
            if (tds_VoucherWise.Rows.Count > 0)
            {
                tds_VoucherWise.UseAccessibleHeader = true;
                tds_VoucherWise.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_TdsSummary_PreRender(object sender, EventArgs e)
        {
            if (grd_TdsSummary.Rows.Count > 0)
            {
                grd_TdsSummary.UseAccessibleHeader = true;
                grd_TdsSummary.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_TdsVouchall_PreRender(object sender, EventArgs e)
        {
            if (grd_TdsVouchall.Rows.Count > 0)
            {
                grd_TdsVouchall.UseAccessibleHeader = true;
                grd_TdsVouchall.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_internalBilling_PreRender(object sender, EventArgs e)
        {
            if (grd_internalBilling.Rows.Count > 0)
            {
                grd_internalBilling.UseAccessibleHeader = true;
                grd_internalBilling.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_DncnJobClosing_PreRender(object sender, EventArgs e)
        {
            if (grd_DncnJobClosing.Rows.Count > 0)
            {
                grd_DncnJobClosing.UseAccessibleHeader = true;
                grd_DncnJobClosing.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_TdsAll_PreRender(object sender, EventArgs e)
        {
            if (grd_TdsAll.Rows.Count > 0)
            {
                grd_TdsAll.UseAccessibleHeader = true;
                grd_TdsAll.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_Receipt_PreRender(object sender, EventArgs e)
        {
            if (Grid_Receipt.Rows.Count > 0)
            {
                Grid_Receipt.UseAccessibleHeader = true;
                Grid_Receipt.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_payment_PreRender(object sender, EventArgs e)
        {
            if (Grid_payment.Rows.Count > 0)
            {
                Grid_payment.UseAccessibleHeader = true;
                Grid_payment.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_Osreceipt_PreRender(object sender, EventArgs e)
        {
            if (Grid_Osreceipt.Rows.Count > 0)
            {
                Grid_Osreceipt.UseAccessibleHeader = true;
                Grid_Osreceipt.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_ospayment_PreRender(object sender, EventArgs e)
        {
            if (Grid_ospayment.Rows.Count > 0)
            {
                Grid_ospayment.UseAccessibleHeader = true;
                Grid_ospayment.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_chequebounce_PreRender(object sender, EventArgs e)
        {
            if (Grid_chequebounce.Rows.Count > 0)
            {
                Grid_chequebounce.UseAccessibleHeader = true;
                Grid_chequebounce.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grid_paymentcancel_PreRender(object sender, EventArgs e)
        {
            if (grid_paymentcancel.Rows.Count > 0)
            {
                grid_paymentcancel.UseAccessibleHeader = true;
                grid_paymentcancel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grid_contra_PreRender(object sender, EventArgs e)
        {
            if (grid_contra.Rows.Count > 0)
            {
                grid_contra.UseAccessibleHeader = true;
                grid_contra.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdVouReceipt_PreRender(object sender, EventArgs e)
        {
            if (GrdVouReceipt.Rows.Count > 0)
            {
                GrdVouReceipt.UseAccessibleHeader = true;
                GrdVouReceipt.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_pending_PreRender(object sender, EventArgs e)
        {
            if (grd_pending.Rows.Count > 0)
            {
                grd_pending.UseAccessibleHeader = true;
                grd_pending.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grd_pend_PreRender(object sender, EventArgs e)
        {
            if (grd_pend.Rows.Count > 0)
            {
                grd_pend.UseAccessibleHeader = true;
                grd_pend.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdprofomaAdminDNCN_PreRender(object sender, EventArgs e)
        {
            if (grdprofomaAdminDNCN.Rows.Count > 0)
            {
                grdprofomaAdminDNCN.UseAccessibleHeader = true;
                grdprofomaAdminDNCN.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_xl_PreRender(object sender, EventArgs e)
        {
            if (Grid_xl.Rows.Count > 0)
            {
                Grid_xl.UseAccessibleHeader = true;
                Grid_xl.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Grid_xl_head_PreRender(object sender, EventArgs e)
        {
            if (Grid_xl_head.Rows.Count > 0)
            {
                Grid_xl_head.UseAccessibleHeader = true;
                Grid_xl_head.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdtSTChargewise_PreRender(object sender, EventArgs e)
        {
            if (grdtSTChargewise.Rows.Count > 0)
            {
                grdtSTChargewise.UseAccessibleHeader = true;
                grdtSTChargewise.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdInterBranch_PreRender(object sender, EventArgs e)
        {
            if (GrdInterBranch.Rows.Count > 0)
            {
                GrdInterBranch.UseAccessibleHeader = true;
                GrdInterBranch.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdDebitNote_PreRender(object sender, EventArgs e)
        {
            if (GrdDebitNote.Rows.Count > 0)
            {
                GrdDebitNote.UseAccessibleHeader = true;
                GrdDebitNote.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdCreditNote_PreRender(object sender, EventArgs e)
        {
            if (grdCreditNote.Rows.Count > 0)
            {
                grdCreditNote.UseAccessibleHeader = true;
                grdCreditNote.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

      
    }
}