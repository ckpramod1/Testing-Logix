using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace logix.FAForm
{
    public partial class DNCNReversalchargewise : System.Web.UI.Page
    {
        DataAccess.Accounts.Reversal obj_da_Reversal = new DataAccess.Accounts.Reversal();
        DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Accounts.Recipts Obj_Recipts = new DataAccess.Accounts.Recipts();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Journal Jnlobj = new DataAccess.Accounts.Journal();
        DataAccess.FAVoucher Obj_Voucher = new DataAccess.FAVoucher();
        DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
        DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
        DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
        DataAccess.Accounts.Payment obj_da_payment = new DataAccess.Accounts.Payment();

        DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
        DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DataAccess.Documents objnew = new DataAccess.Documents();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        string reversal = "";
        int int_Curr_Vouyear;
        Boolean blr;
        Double amount, strvolume, doublevolume, strntweight, strchgweight, strgrosswght, sizecount, famount;
        string strTranType = "", type, fd;
        int divisionid, branchid;

        string trantype, Str_CurrrentDate, Type;
        int int_bid;
        DateTime Close_date;

        bool recedit;
        DateTime vdate;
        int voutypeid, Vou_ID, txtvouyear, vouid;
        double totdbAmnt, totcramnt;
        DataRow row;
        DataTable dt_chkrev = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obj_da_Reversal.GetDataBase(Ccode);
                obj_da_Ledger.GetDataBase(Ccode);
                Obj_Recipts.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                DCAdviseObj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                Jnlobj.GetDataBase(Ccode);


                Obj_Voucher.GetDataBase(Ccode);
                obj_da_Emp.GetDataBase(Ccode);
                obj_da_Invoice.GetDataBase(Ccode);
                obj_da_invoice.GetDataBase(Ccode);
                obj_da_Payment.GetDataBase(Ccode);
                obj_da_Cost.GetDataBase(Ccode);
                obj_da_OSDNCN.GetDataBase(Ccode);
                obj_da_Approval.GetDataBase(Ccode);
                objrv.GetDataBase(Ccode);
                obj_da_Customer.GetDataBase(Ccode);
                objnew.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);




            }


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txt_receipt);

            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txt_year.Text = Session["Vouyear"].ToString();
                Grd_Charge.DataSource = new DataTable();
                Grd_Charge.DataBind();
                txt_receipt.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                txt_year.Attributes.Add("OnKeypress", "return IntegerCheck(event);");
                CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");
                chkHeader.Enabled = false;
                int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                hid_divisionid.Value = Session["LoginDivisionId"].ToString();
                int Corid;
                //DataAccess.HR.Employee obj_da_Emp = new DataAccess.HR.Employee();
                Corid = obj_da_Emp.GetBranchId(Convert.ToInt32(hid_divisionid.Value), "CORPORATE");

                if (Corid == int_bid)
                {
                    ddl_voucher.Items.Clear();
                    ddl_voucher.Items.Add("");
                    ddl_voucher.Items.Add("DN-Admin");
                    ddl_voucher.Items.Add("CN-Admin");
                    ddl_voucher.Items.Add("Journal");
                }
                //if (int_bid == 5)
                //{
                //    ddl_voucher.Items.Clear();
                //    ddl_voucher.Items.Add("Voucher Type");
                //    ddl_voucher.Items.Add("DN-Admin");
                //    ddl_voucher.Items.Add("CN-Admin");
                //    ddl_voucher.Items.Add("Journal");
                //}
                else
                {
                    ddl_voucher.Items.Clear();
                    ddl_voucher.Items.Add("");
                    ddl_voucher.Items.Add("Sales Invoice");
                    ddl_voucher.Items.Add("Purchase Invoice");
                    ddl_voucher.Items.Add("BOS");
                    ddl_voucher.Items.Add("OSSI");
                    ddl_voucher.Items.Add("OSPI");
                    ddl_voucher.Items.Add("Debit Note");
                    ddl_voucher.Items.Add("Credit Note");
                    ddl_voucher.Items.Add("DN-Admin");
                    ddl_voucher.Items.Add("CN-Admin");
                    ddl_voucher.Items.Add("Journal");
                }
            }

            int_Curr_Vouyear = Convert.ToInt32(txt_year.Text);
            hid_Vouyear.Value = txtdate.Text;
            //if (Request.QueryString.ToString().Contains("Vno"))
            //{
            //    vdate = Convert.ToDateTime(Utility.fn_ConvertDate(Request.QueryString["Vdate"].ToString()));
            //}
            if (txtdate.Text == "")
            {
                GetTextDate();
            }
            txtvouyear = Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Year;
            if (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month > 3)
            {

            }
            else
            {
                txtvouyear = txtvouyear - 1;
            }
            hid_txtyear.Value = txtvouyear.ToString();
        }

        private void Fn_Clear()
        {

            hid_custid.Value = "";
            hid_customername.Value = "";
            //txt_year.Text = Session["Vouyear"].ToString();
            txt_detail.Text = "";
            txt_receipt.Text = "";
            txt_received.Text = "";
            //txt_rvouno.Text = "";
            //txt_ryear.Text = "";
            //txt_total.Text = "";
            txt_trantype.Text = "";
            Grd_Charge.DataSource = new DataTable();
            Grd_Charge.DataBind();
            //ddl_voucher.SelectedValue = "0";
            btn_reverse.Enabled = true;
            btn_VouCancel.Enabled = true;
            btn_cancel.ToolTip = "Back";
            btn_cancel.Text = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
            txt_date.Text = "";
            txt_AmountTot.Text = "0.00";
            txt_GstTot.Text = "0.00";
            txt_NetTot.Text = "0.00";
            txt_RevRateTot.Text = "0.00";
            txt_RevAmtTot.Text = "0.00";
            txt_RevGstTot.Text = "0.00";
            txt_RevNetTot.Text = "0.00";
            txt_DiffAmtTot.Text = "0.00";
            txt_DiffGstTot.Text = "0.00";
            txt_DiffNetTot.Text = "0.00";
            txt_DiffNetTot.Text = "0.00";
            txt_UnitTot.Text = "0";
            txt_DiffRevRateTot.Text = "0.00";
            txt_DiffFcamtTot.Text = "0.00";
        }

        private void Fn_GetDetail()
        {
           // DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
            DataTable obj_dt = new DataTable();
            DataTable ibj_dttemp = new DataTable();
            if (txt_receipt.Text.Trim().Length > 0 && txt_year.Text.Trim().Length > 0)
            {
                obj_dt = obj_da_Invoice.RptIP(Convert.ToInt32(txt_receipt.Text), "TE", hid_type.Value.ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text));
                if (obj_dt.Rows.Count > 0)
                {
                    hid_job.Value = obj_dt.Rows[0]["jobno"].ToString();
                    hid_Custtype.Value = obj_dt.Rows[0]["customertype"].ToString();
                    hid_trantype.Value = obj_dt.Rows[0]["trantype"].ToString();
                    hid_blno.Value = obj_dt.Rows[0][6].ToString();
                    Fn_LoadTrantype(hid_trantype.Value.ToString());
                    txt_date.Text = obj_dt.Rows[0][1].ToString();
                    hid_custid.Value = obj_dt.Rows[0]["supplyto"].ToString();
                    hid_customername.Value = obj_dt.Rows[0][2].ToString();
                    hid_Chk_Mbl.Value = obj_dt.Rows[0]["horm"].ToString();
                    hid_Mbl.Value = obj_dt.Rows[0][7].ToString();
                    txt_received.Text = obj_dt.Rows[0][2].ToString() + " ," + obj_dt.Rows[0][3].ToString() + " ," + System.Environment.NewLine + obj_dt.Rows[0][4].ToString() + " - " + obj_dt.Rows[0][5].ToString() + " .";
                    if (hid_trantype.Value.ToString() == "FE" || hid_trantype.Value.ToString() == "FI")
                    {
                        txt_detail.Text = "BL # : " + obj_dt.Rows[0][6].ToString() + System.Environment.NewLine + "MBL #  : " + obj_dt.Rows[0][7].ToString() + System.Environment.NewLine + "Vessel & Voyage : " + obj_dt.Rows[0][8].ToString() + "  " + obj_dt.Rows[0][9].ToString() +
                             System.Environment.NewLine + "POL : " + obj_dt.Rows[0][10].ToString() + " , " + "  ETA : " + obj_dt.Rows[0][11].ToString();
                    }
                    else if (hid_trantype.Value.ToString() == "AE" || hid_trantype.Value.ToString() == "AI")
                    {
                        txt_detail.Text = "BL # : " + obj_dt.Rows[0][6].ToString() + System.Environment.NewLine + "MAWBL # : " + obj_dt.Rows[0][7].ToString() + System.Environment.NewLine + "Airline & Flight : " + obj_dt.Rows[0][8].ToString() + "  " + obj_dt.Rows[0][9].ToString() +
                            System.Environment.NewLine + "POL : " + obj_dt.Rows[0][10].ToString() + " , " + "  Flight Date : " + obj_dt.Rows[0][11].ToString();
                    }
                    else
                    {
                        txt_detail.Text = "Doc # : " + obj_dt.Rows[0][6].ToString() + System.Environment.NewLine + "MDoc # : " + obj_dt.Rows[0][7].ToString() + System.Environment.NewLine + "Mode : " + obj_dt.Rows[0][8].ToString() +
                                 System.Environment.NewLine + "POL : " + obj_dt.Rows[0][9].ToString() + " , " + "  Doc Date : " + obj_dt.Rows[0][10].ToString();
                    }
                    if (ddl_voucher.SelectedItem.Text == "Sales Invoice")
                    {
                        obj_dt = obj_da_Invoice.GetInvoiceDetailsnew(Convert.ToInt32(txt_receipt.Text), "I", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "BOS")
                    {
                        obj_dt = obj_da_Invoice.GetInvoiceDetailsnew(Convert.ToInt32(txt_receipt.Text), "B", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "Purchase Invoice")
                    {
                        obj_dt = obj_da_Invoice.GetPADetailsnew(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "OSSI")
                    {
                        obj_dt = obj_da_Invoice.GetOSDNCNDetailsnew(Convert.ToInt32(txt_receipt.Text), "D", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "OSPI")
                    {
                        obj_dt = obj_da_Invoice.GetOSDNCNDetailsnew(Convert.ToInt32(txt_receipt.Text), "C", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "Debit Note")
                    {
                        obj_dt = obj_da_Invoice.GetInvoiceDetailsnew(Convert.ToInt32(txt_receipt.Text), "V", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "Credit Note")
                    {
                        obj_dt = obj_da_Invoice.GetInvoiceDetailsnew(Convert.ToInt32(txt_receipt.Text), "E", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "DN-Admin")
                    {
                        obj_dt = obj_da_Invoice.GetInvoiceDetailsnew(Convert.ToInt32(txt_receipt.Text), "X", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }
                    else if (ddl_voucher.SelectedItem.Text == "CN-Admin")
                    {
                        obj_dt = obj_da_Invoice.GetInvoiceDetailsnew(Convert.ToInt32(txt_receipt.Text), "S", Convert.ToInt32(txt_year.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                    }

                    Grd_Charge.DataSource = obj_dt;
                    Grd_Charge.DataBind();
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel.Text = "cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";



                    for (int b = 0; b < obj_dt.Rows.Count; b++)
                    {
                        DataTable Revised_Charges = new DataTable();
                        Revised_Charges = obj_da_Reversal.GetRevisedChargesEnabled(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(obj_dt.Rows[b]["chargeid"].ToString()), obj_dt.Rows[b]["charge"].ToString(), obj_dt.Rows[b]["base"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));

                        CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");
                        if (Revised_Charges.Rows.Count > 0)
                        {
                            if (Revised_Charges.Rows[0]["RevRate"] == "")
                            {
                                Revised_Charges.Rows[0]["RevRate"] = "0.00";
                            }
                            Grd_Charge.Rows[b].Cells[8].Text = Revised_Charges.Rows[0]["RevRate"].ToString();
                            Grd_Charge.Rows[b].Cells[9].Text = Revised_Charges.Rows[0]["RevAmt"].ToString();
                            Grd_Charge.Rows[b].Cells[10].Text = Revised_Charges.Rows[0]["RevGST"].ToString();
                            Grd_Charge.Rows[b].Cells[11].Text = Revised_Charges.Rows[0]["RevNET"].ToString();
                            Grd_Charge.Rows[b].Cells[12].Text = Revised_Charges.Rows[0]["Diff"].ToString();
                            Grd_Charge.Rows[b].Cells[13].Text = Revised_Charges.Rows[0]["DiffGST"].ToString();
                            Grd_Charge.Rows[b].Cells[14].Text = Revised_Charges.Rows[0]["DiffNET"].ToString();
                            Grd_Charge.Rows[b].Cells[18].Text = Revised_Charges.Rows[0]["unit"].ToString();
                            Grd_Charge.Rows[b].Cells[19].Text = Revised_Charges.Rows[0]["DiffRevRate"].ToString();
                            Grd_Charge.Rows[b].Cells[20].Text = Revised_Charges.Rows[0]["DiffFcamt"].ToString();
                            Grd_Charge.Rows[b].Cells[17].Text = "Y";
                            chkHeader.Enabled = false;
                        }

                    }
                    Fn_CalculateTotal();
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel.Text = "cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Reversal", "alertify.alert('Please check the Voucher #');", true);
                    Fn_Clear();
                    blr = true;
                    return;
                }
            }
        }


        private void Fn_CalculateTotal()
        {
            double AmountTot = 0, NetTot = 0, RevAmtTot = 0, RevNetTot = 0, DiffAmtTot = 0, DiffNetTot = 0, RevRateTot = 0, GstTot = 0, RevGstTot = 0, DiffGstTot = 0, DiffRevRate = 0, DiffFcamt = 0;
            double unit = 0;
            for (int i = 0; i <= Grd_Charge.Rows.Count - 1; i++)
            {
                if (Grd_Charge.Rows[i].Cells[5].Text != "")
                {
                    AmountTot = AmountTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[5].Text);
                }
                if (Grd_Charge.Rows[i].Cells[6].Text != "")
                {
                    GstTot = GstTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[6].Text);
                }
                if (Grd_Charge.Rows[i].Cells[7].Text != "")
                {
                    NetTot = NetTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[7].Text);
                }
                if (Grd_Charge.Rows[i].Cells[8].Text != "")
                {
                    RevRateTot = RevRateTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[8].Text);
                }
                if (Grd_Charge.Rows[i].Cells[9].Text != "")
                {
                    RevAmtTot = RevAmtTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text);
                }
                if (Grd_Charge.Rows[i].Cells[10].Text != "")
                {
                    RevGstTot = RevGstTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[10].Text);
                }
                if (Grd_Charge.Rows[i].Cells[11].Text != "")
                {
                    RevNetTot = RevNetTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[11].Text);
                }
                if (Grd_Charge.Rows[i].Cells[12].Text != "")
                {
                    DiffAmtTot = DiffAmtTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[12].Text);
                }
                if (Grd_Charge.Rows[i].Cells[13].Text != "")
                {
                    DiffGstTot = DiffGstTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[13].Text);
                }
                if (Grd_Charge.Rows[i].Cells[14].Text != "")
                {
                    DiffNetTot = DiffNetTot + Convert.ToDouble(Grd_Charge.Rows[i].Cells[14].Text);
                }
                if (Grd_Charge.Rows[i].Cells[18].Text != "")
                {
                    unit = unit + Convert.ToDouble(Grd_Charge.Rows[i].Cells[18].Text);
                }
                if (Grd_Charge.Rows[i].Cells[19].Text != "")
                {
                    DiffRevRate = DiffRevRate + Convert.ToDouble(Grd_Charge.Rows[i].Cells[19].Text);
                }
                if (Grd_Charge.Rows[i].Cells[20].Text != "")
                {
                    DiffFcamt = DiffFcamt + Convert.ToDouble(Grd_Charge.Rows[i].Cells[20].Text);
                }

            }
            txt_AmountTot.Text = AmountTot.ToString("#,##0.00");
            txt_GstTot.Text = GstTot.ToString("#,##0.00");
            txt_NetTot.Text = NetTot.ToString("#,##0.00");
            txt_RevRateTot.Text = RevRateTot.ToString("#,##0.00");
            txt_RevAmtTot.Text = RevAmtTot.ToString("#,##0.00");
            txt_RevGstTot.Text = RevGstTot.ToString("#,##0.00");
            txt_RevNetTot.Text = RevNetTot.ToString("#,##0.00");
            txt_DiffAmtTot.Text = DiffAmtTot.ToString("#,##0.00");
            txt_DiffGstTot.Text = DiffGstTot.ToString("#,##0.00");
            txt_DiffNetTot.Text = DiffNetTot.ToString("#,##0.00");
            txt_DiffNetTot.Text = DiffNetTot.ToString("#,##0.00");
            txt_UnitTot.Text = unit.ToString("#,##0.00");
            txt_DiffRevRateTot.Text = DiffRevRate.ToString("#,##0.00");
            txt_DiffFcamtTot.Text = DiffFcamt.ToString("#,##0.00");
        }

        private void Fn_LoadTrantype(string Trantype)
        {
            if (Trantype == "FE")
            {
                txt_trantype.Text = "Ocean Exports";
            }
            else if (Trantype == "FI")
            {
                txt_trantype.Text = "Ocean Imports";
            }
            else if (Trantype == "AE")
            {
                txt_trantype.Text = "Air Exports";
            }
            else if (Trantype == "AI")
            {
                txt_trantype.Text = "Air Imports";
            }
            else if (Trantype == "CH")
            {
                txt_trantype.Text = "C H A";
            }
            else if (Trantype == "WH")
            {
                txt_trantype.Text = "WAREHOUSE";
            }
        }

        protected void ddl_voucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddl_voucher.SelectedItem.Text)
            {
                case "Sales Invoice":
                    hid_type.Value = "Invoice";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    //lbl_rvoucher.Text = "CN #";
                    //lbl_rvoucher.Text = "Inv #";
                    Hid_voutype.Value = "I";
                    //txt_receipt.Attributes.Add("placeholder", "Inv #");
                    txt_receipt.ToolTip = "Vou #";
                    //txt_date.Attributes.Add("placeholder", "Inv Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "BOS":
                    hid_type.Value = "BOS";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    //lbl_rvoucher.Text = "CN #";
                    //lbl_rvoucher.Text = "Inv #";
                    Hid_voutype.Value = "B";
                    //txt_receipt.Attributes.Add("placeholder", "BOS #");
                    txt_receipt.ToolTip = "Vou #";
                    //txt_date.Attributes.Add("placeholder", "BOS Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "Purchase Invoice":
                    hid_type.Value = "PA";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    //lbl_rvoucher.Text = "DN #";
                    //lbl_rvoucher.Text = "CN-Ops #";
                    Hid_voutype.Value = "P";
                    //txt_receipt.Attributes.Add("placeholder", "CNOps #");
                    txt_receipt.ToolTip = "Vou #";
                    //txt_date.Attributes.Add("placeholder", "CN-Ops Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "OSSI":
                    hid_type.Value = "OSSI";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    //lbl_rvoucher.Text = "CN #";
                    Hid_voutype.Value = "D";
                    //txt_receipt.Attributes.Add("placeholder", "DN #");
                    txt_receipt.ToolTip = "Vou #";
                    //txt_date.Attributes.Add("placeholder", "OSDN Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "OSPI":
                    hid_type.Value = "OSPI";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    //lbl_rvoucher.Text = "CN #";
                    Hid_voutype.Value = "C";
                    //txt_receipt.Attributes.Add("placeholder", "CN #");
                    txt_receipt.ToolTip = "Vou #";
                    //txt_date.Attributes.Add("placeholder", "OSCN Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "Debit Note":
                    hid_type.Value = "DNHead";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    //lbl_rvoucher.Text = "CN #";
                    Hid_voutype.Value = "V";
                    //txt_receipt.Attributes.Add("placeholder", "DN #");
                    txt_receipt.ToolTip = "Vou";
                    //txt_date.Attributes.Add("placeholder", "DN Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "Credit Note":
                    hid_type.Value = "CNHead";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "CN #";
                    //lbl_rvoucher.Text = "DN #";
                    Hid_voutype.Value = "E";
                    //txt_receipt.Attributes.Add("placeholder", "CN #");
                    txt_receipt.ToolTip = "CN Number";
                    //txt_date.Attributes.Add("placeholder", "CN Date");
                    txt_date.ToolTip = "CN Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "DN-Admin":
                    hid_type.Value = "DN-Admin";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    Hid_voutype.Value = "X";
                    //txt_receipt.Attributes.Add("placeholder", "DN-Admin #");
                    txt_receipt.ToolTip = "Vou #";
                    //txt_date.Attributes.Add("placeholder", "DN-Admin Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "CN-Admin":
                    hid_type.Value = "CN-Admin";
                    lbl_date.Text = "Date";
                    lbl_receipt.Text = "Vou #";
                    Hid_voutype.Value = "S";
                    //txt_receipt.Attributes.Add("placeholder", "CN-Admin #");
                    txt_receipt.ToolTip = "Vou Number";
                    //txt_date.Attributes.Add("placeholder", "CN-Admin Date");
                    txt_date.ToolTip = "Vou Date";
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = true;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
                case "Journal":
                    Panel2.Visible = true;
                    this.ModalPopupExtenderlog.Show();
                    DataTable Empty_DT = new DataTable();
                    grd_journal.DataSource = Empty_DT;
                    grd_journal.DataBind();
                    GetTextDate();
                    btn_reverse.Visible = false;
                    btn_cancel.Visible = false;
                    btn_RevJV.Enabled = false;
                    btn_CancelJVpopup.Enabled = false;
                    Fn_Clear();
                    ClearCharge();
                    //ddl_voucher.SelectedValue = "0";
                    CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");
                    chkHeader.Enabled = false;
                    string t = "Voucher Type";
                    ddl_voucher.ClearSelection();
                    ddl_voucher.Items.FindByText(t).Selected = true;
                    //txt_receipt.Attributes.Add("placeholder", "Vou #");
                    //txt_date.Attributes.Add("placeholder", "Vou Date");
                    break;
                case "Voucher Type":
                    //txt_receipt.Attributes.Add("placeholder", "Vou #");
                    //txt_date.Attributes.Add("placeholder", "Vou Date");
                    txt_receipt.Text = "";
                    txt_receipt.Enabled = false;
                    Fn_Clear();
                    ClearCharge();
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    break;
            }
        }

        protected void txt_receipt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_receipt.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Voucher can't be Blank !');", true);
                    Fn_Clear();
                    ClearCharge();
                    txt_receipt.Focus();
                    return;
                }
                int BookClosure_Status = obj_da_Reversal.CheckBookClosureStatus(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_divisionid.Value), Session["FADbname"].ToString());
                if (BookClosure_Status > 0)
                {
                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Book Closed for the Financial Year.');", true);
                    return;
                }
                if (ddl_voucher.SelectedItem.Text == "OSSI" || ddl_voucher.SelectedItem.Text == "OSPI")
                {
                    Grd_Charge.Columns[22].Visible = true;
                    Grd_Charge.Columns[25].Visible = true;
                }
                else if (ddl_voucher.SelectedItem.Text == "DN-Admin" || ddl_voucher.SelectedItem.Text == "CN-Admin")
                {
                    Grd_Charge.Columns[18].Visible = false;
                }
                else
                {
                    Grd_Charge.Columns[22].Visible = false;
                    Grd_Charge.Columns[25].Visible = true;
                    Grd_Charge.Columns[18].Visible = true;
                }
                CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");
                chkHeader.Enabled = true;
                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                hid_divisionid.Value = int_divisionid.ToString();
                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int int_Vyear = Convert.ToInt32(txt_year.Text.ToString());
                int int_Jobno = Convert.ToInt32(hid_job.Value.ToString());
                int int_Receipt = Convert.ToInt32(txt_receipt.Text.ToString());
               // DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
                DataTable dtrev = new DataTable();

                if (ddl_voucher.SelectedItem.Text == "Purchase Invoice")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "P");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Payment has genearated for this voucher. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Payment has genearated for this voucher. So you can not Reverse.');", true);

                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }

                    }

                    if (obj_da_invoice.CheckTDSApplyORNot("P", int_Receipt, int_Vyear, int_bid) == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('TDS Not Applied. Hence you can not Reverse.');", true);
                        Fn_Clear();
                        ClearCharge();
                        txt_receipt.Focus();
                        return;
                    }
                }
                else if (ddl_voucher.SelectedItem.Text == "Sales Invoice")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "I");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this Invoice. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this Invoice. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }
                }
                else if (ddl_voucher.SelectedItem.Text == "BOS")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "B");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this BOS. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this BOS. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }
                }
                else if (ddl_voucher.SelectedItem.Text == "OSSI")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "D");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this OSDN. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this OSDN. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }
                }
                else if (ddl_voucher.SelectedItem.Text == "OSPI")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "C");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this OSCN. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this OSCN. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }
                }

                else if (ddl_voucher.SelectedItem.Text == "Debit Note")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "V");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this DN. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this DN. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }
                }
                else if (ddl_voucher.SelectedItem.Text == "Credit Note")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "E");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this CN. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this CN. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }
                    if (obj_da_invoice.CheckTDSApplyORNot("E", int_Receipt, int_Vyear, int_bid) == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('TDS Not Applied. Hence you can not Reverse.');", true);
                        Fn_Clear();
                        ClearCharge();
                        txt_receipt.Focus();
                        return;
                    }
                }
                else if (ddl_voucher.SelectedItem.Text == "DN-Admin")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "X");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this DN-Admin. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this DN-Admin. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }

                }
                else if (ddl_voucher.SelectedItem.Text == "CN-Admin")
                {
                    dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "S");

                    if (dtrev.Rows.Count > 0)
                    {
                        int tranid = Convert.ToInt32(dtrev.Rows[0]["tranid"]);
                        if (tranid > 0)
                        {
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this CN-Admin. So you can not Reverse.');", true);
                            Fn_Clear();
                            ClearCharge();
                            txt_receipt.Focus();
                            return;
                        }
                        else
                        {
                            if (tranid == -5)
                            {
                                lbl_title.InnerText = "Revised Charges : ";
                                receiptno.Text = txt_receipt.Text;
                                DataTable Obj_Revised = new DataTable();
                                PanelReviesd.Visible = true;
                                Panel3.Visible = true;
                                Obj_Revised = obj_da_Reversal.GetRevisedCharges(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_year.Text), Convert.ToChar(Hid_voutype.Value));
                                if (Obj_Revised.Rows.Count > 0)
                                {
                                    ModalPopupExtenderCharges.Show();
                                    GridCharges.DataSource = Obj_Revised;
                                    GridCharges.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(txt_receipt, typeof(TextBox), "Reversal", "alertify.alert('Entered Voucher is Invalid.');", true);
                                    Fn_Clear();
                                    ClearCharge();
                                    txt_receipt.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this CN-Admin. So you can not Reverse.');", true);
                                Fn_Clear();
                                ClearCharge();
                                txt_receipt.Focus();
                                return;
                            }
                        }
                    }
                    if (obj_da_invoice.CheckTDSApplyORNot("S", int_Receipt, int_Vyear, int_bid) == 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('TDS Not Applied. Hence you can not Reverse.');", true);
                        Fn_Clear();
                        ClearCharge();
                        txt_receipt.Focus();
                        return;
                    }
                }

                ClearCharge();
                Fn_GetDetail();

                if (blr == true)
                {
                    return;
                }
                DataTable obj_dt = new DataTable();
                //DataAccess.Accounts.Payment obj_da_Payment = new DataAccess.Accounts.Payment();
                obj_dt = obj_da_Payment.CheckVouReversal(Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Hid_voutype.Value, Convert.ToInt32(txt_year.Text));
                if (Grd_Charge.Rows.Count > 0)
                {
                    for (int i = 0; i < Grd_Charge.Rows.Count; i++)
                    {
                        if (Grd_Charge.Rows[i].Cells[8].Text != "")
                        {
                            Grd_Charge.Rows[i].Enabled = false;
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
        protected void txt_year_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Fn_GetDetail();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                btn_reverse.Enabled = false;
                Fn_Clear();
                //ddl_voucher.SelectedValue = "0";
                ClearCharge();
                txt_receipt.Enabled = false;
                CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");
                chkHeader.Enabled = false;
                //ddl_voucher.SelectedValue = "Voucher Type";
                ddl_voucher.Text = "";
                ddl_voucher_SelectedIndexChanged(sender, e);
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
                    else if (Session["StrTranType"].ToString() == "AC")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"] != null)
                    {
                        if (Session["home"].ToString() == "FABR")
                        {
                            Response.Redirect("../Home/Branch_home.aspx");
                        }
                        else if (Session["home"].ToString() == "FAFC")
                        {
                            Response.Redirect("../Home/CorporateHome.aspx");
                        }
                    }

                }
                else if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "FABR")
                    {
                        Response.Redirect("../Home/Branch_home.aspx");
                    }
                    else if (Session["home"].ToString() == "FAFC")
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

        public void Fn_DNCNBLBT(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        {
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            DateTime dtdate = CDate;
            //DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            if (int_bid == 0 || int_bid == null)
            {
                int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            if (type == "Closed")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype);
                //obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew4Reclose(jobno, int_bid, trantype, vouno, voutype);
            }
            else if (type == "Approve")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromVounonew(jobno, int_bid, trantype, vouno, voutype);
            }
            int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
            char Nomination;
            string blno;
            double volume = 0;
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    blno = obj_dt.Rows[i]["blno"].ToString();
                    int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                    if (trantype != "CH" && trantype != "BT")
                    {
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
                    }
                    else
                    {
                        MLO = 0;
                    }
                    if (type == "Closed")
                    {
                        //dtdate = CDate;
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                        vouno = Convert.ToInt32(obj_dt.Rows[i]["vouno"].ToString());
                        voutype = obj_dt.Rows[i]["voutype"].ToString();
                    }
                    else if (type == "Approve")
                    {
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                    }
                    obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        BL_Amount = 0;
                        BL_Expense = 0;

                        if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }
                        else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }

                        else if (obj_dt.Rows[i]["voutype"].ToString() == "I")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }
                        else if (obj_dt.Rows[i]["voutype"].ToString() == "P")
                        {
                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                            {
                                BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                            }
                        }


                        int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
                        blno = obj_dttemp.Rows[0][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());

                        if (trantype != "CH" && trantype != "BT")
                        {
                            int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        }
                        Nomination = char.Parse(" ");
                        volume = 0;

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
                                JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI" || trantype == "CH" || trantype == "BT")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                            JobType = 0;
                        }
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //obj_da_Cost.InsCostingTempRptnew(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, 0, char.Parse(string.Empty));
                        obj_da_Cost.InsCostingTempRptnew(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, Convert.ToChar(voutype));
                    }
                    //else
                    //{
                    //    Fn_DNCNMBL4Reclose(jobno, trantype, vouno, voutype, i, obj_dt, int_bid, dtdate);
                    //}
                }
            }
        }

        protected void btn_reverse_Click(object sender, EventArgs e)
        {
            log4net.ILog log1 = log4net.LogManager.GetLogger(typeof(DNCNReversalchargewise));
            log4net.Config.BasicConfigurator.Configure();


            // Einvoice newly added start//
            //DataAccess.Documents objnew = new DataAccess.Documents();
            int ind_div1 = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            string div_id = "", gstirn_ = "", gstirnerr_ = "";
            int gstirn = 0, gstirnerr = 0;
            // Einvoice newly added end//

            DateTime dt_date = obj_da_Log.GetDate();
            int year = (dt_date).Year;
            if (Convert.ToDateTime(dt_date).Month > 3)
            {

            }
            else
            {
                year = year - 1;
            }
            int Charges_Count = 0;
            for (int s = 0; s <= Grd_Charge.Rows.Count - 1; s++)
            {
                if (Grd_Charge.Rows[s].Cells[17].Text == "N")
                {
                    Charges_Count = Charges_Count + 1;
                }
            }
            if (Charges_Count > 0)
            {
                try
                {
                    string cname = "", StrScript;
                    int int_Receipt;
                    int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    int int_Vyear = Convert.ToInt32(txt_year.Text.ToString());
                    int int_Jobno = Convert.ToInt32(hid_job.Value.ToString());
                    string Str_DBName = Session["FADbname"].ToString();
                   // DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
                    DateTime dtdate = obj_da_Log.GetDate();
                    DataTable dtacc = new DataTable();
                    int jobclosed = 0;
                    string Afterjobclosed = "N";
                    DataTable dtrev = new DataTable();

                    int int_refno;


                    dtacc = obj_da_invoice.SelEmpDtls4Accnew(int_Empid, int_Jobno, int_bid, hid_trantype.Value.ToString(), "");

                    if (dtacc.Rows.Count > 0)
                    {
                        jobclosed = Convert.ToInt32(dtacc.Rows[0]["closedjob"].ToString());
                        if (jobclosed == 1)
                        {
                            Afterjobclosed = "Y";
                        }
                    }

                    if (txt_receipt.Text != "")
                    {
                        int_Receipt = Convert.ToInt32(txt_receipt.Text.ToString());
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Please Enter the Voucher #')", true);
                        return;
                    }

                    //if (ddl_voucher.SelectedValue != "0")
                    //{
                    //if ((txt_receipt.Text.Trim().Length > 0 && int_Jobno != 0) || (txt_trantype.Text == "WAREHOUSE" && txt_receipt.Text.Trim().Length > 0))
                    //{

                    //DataAccess.Accounts.Payment obj_da_payment = new DataAccess.Accounts.Payment();

                    //DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
                    //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                    DataTable obj_dt = new DataTable();
                    DataTable dt = new DataTable();
                    DataTable dt_list = new DataTable();
                    if (hid_custid.Value == "0" || hid_custid.Value == "")
                    {
                        StrScript = "Suppply To not updated for the Voucher #: " + txt_receipt.Text;
                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                        return;
                    }
                    else
                    {
                        if ((hid_custid.Value != "0" || hid_custid.Value != "") && (hid_Custtype.Value.ToString() != "P"))
                        {
                          //  DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                            dt_list = customerobj.GetIndianCustomergstadd(Convert.ToInt32(hid_custid.Value));
                            //if (dt_list.Rows.Count > 0)
                            //{
                            //    cname = dt_list.Rows[0]["customername"].ToString();
                            //    if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                            //    {
                            //        if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                            //        {
                            //            StrScript = "GST TYPE not Updated for the Customer Name : " + cname + " in the Voucher # " + txt_receipt.Text;
                            //            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                            //            return;
                            //        }
                            //    }
                            //}

                            if (dt_list.Rows.Count > 0)
                            {
                                if (dt_list.Rows[0]["customername"].ToString() == "1")
                                {

                                }
                                else
                                {
                                    cname = dt_list.Rows[0]["customername"].ToString();
                                    if (!string.IsNullOrEmpty(dt_list.Rows[0]["GSTGroup"].ToString()))
                                    {
                                        if (dt_list.Rows[0]["GSTGroup"].ToString() == "N")
                                        {
                                            StrScript = "GST TYPE not Updated for the Customer Name : " + cname + " in the Voucher # " + txt_receipt.Text;
                                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        cname = customerobj.GetCustomername(Convert.ToInt32(hid_custid.Value));
                                        StrScript = "State Name not Updated in Master Kindly update Master Customer for " + cname;
                                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                        return;
                                    }
                                }

                            }
                            else
                            {
                                cname = customerobj.GetCustomername(Convert.ToInt32(hid_custid.Value));
                                StrScript = "State Name not Updated in Master Kindly update Master Customer for " + cname;
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                                return;
                            }

                        }
                    }
                     
                    //as per raj sir instruction 14022022
                    dt_chkrev = obj_da_payment.CheckVouReversalExistorNot(int_Receipt, int_bid, Hid_voutype.Value, int_Vyear);
                    if (dt_chkrev.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Already Reversed');", true);
                        return;
                        btn_reverse.Enabled = false;
                    }
                    //end

                    obj_dt = obj_da_payment.CheckVouReversal(int_Receipt, int_bid, Hid_voutype.Value, int_Vyear);

                    if (obj_dt.Rows.Count <= 0)
                    {
                        int int_DNno = 0, int_CNno = 0;
                        //if (hid_Custtype.Value.ToString() == "P")
                        //{
                        //    StrScript = "Voucher Raised for Agent - " + cname;
                        //    ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "GST", "alertify.alert('" + StrScript + "');", true);
                        //    return;
                        //}
                        Double VouTotAmount = 0, ReVouTotAmount = 0;
                        int grdcount = Grd_Charge.Rows.Count;
                        int dcount = 0;

                        for (int i = 0; i < Grd_Charge.Rows.Count; i++)
                        {
                            VouTotAmount = VouTotAmount + Convert.ToDouble(Grd_Charge.Rows[i].Cells[7].Text);
                            if (Grd_Charge.Rows[i].Cells[11].Text != "")
                            {
                                ReVouTotAmount = ReVouTotAmount + Convert.ToDouble(Grd_Charge.Rows[i].Cells[11].Text);
                                dcount = dcount + 1;
                            }
                        }

                        if (Convert.ToInt32(grdcount) == Convert.ToInt32(dcount) && VouTotAmount == ReVouTotAmount)
                        {
                            reversal = "F";
                        }
                        else if (Convert.ToInt32(grdcount) != Convert.ToInt32(dcount) || VouTotAmount != ReVouTotAmount)
                        {
                            reversal = "P";
                        }


                        if (ddl_voucher.SelectedItem.Text == "Purchase Invoice") ////////DONE
                        {
                            /*dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "P");

                            if (dtrev.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Payment has genearated for this voucher. So you can not Reverse.')", true);
                                return;
                            }

                            if (obj_da_invoice.CheckTDSApplyORNot("P", int_Receipt, int_Vyear, int_bid) == 0)
                            {
                                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('TDS Not Applied. Hence you can not Reverse.');", true);
                                return;
                            }*/

                            int_DNno = obj_da_OSDNCN.GetOSDCNno("DN", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {


                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'V', int_DNno, year);
                                }
                            }



                            //Changed Query
                            obj_da_payment.InsCNHeadforreversalnewlv(int_Receipt, int_Vyear, int_bid, int_DNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);

                            //obj_da_payment.InsVouReversal(int_bid, "P", int_Receipt, int_Vyear, "V", int_DNno, int_Vyear);// new table
                            if (jobclosed == 1)
                            {
                                if (hid_trantype.Value != "BT")
                                {
                                    Fn_DNCNBL(int_Jobno, hid_trantype.Value.ToString(), "Approve", dtdate, int_DNno, "V");
                                }
                                else
                                {
                                    Fn_DNCNBLBT(int_Jobno, hid_trantype.Value, "Approve", dtdate, int_DNno, "V");
                                }
                            }
                            //try
                            //{
                            //    int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_DNno, int_Empid, 2, 7, Str_DBName);
                            //    obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 2, int_Vyear, int_bid);
                            //    dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);
                            //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            //    {
                            //        obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                            //    }
                            //}
                            //catch (Exception ex)
                            //{

                            //}

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'P', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                try
                                {
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'P', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'N', Convert.ToInt32(txt_year.Text));
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_DNno, 'V', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                                    //Obj_Recipts.InsRecptAginstVou("P", int_Receipt, int_Vyear,Convert.ToDouble(txt_total.Text), int_bid, "V", int_DNno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), int_bid, "REV");
                                }
                                catch (Exception ex)
                                {

                                }

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "PA", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);

                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_DNno, dtdate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);
                                    obj_da_Approval.UpdLedgerOPBreakup(int_DNno, 'V', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            {
                                log1.Info("Before Call the Procedure ReversalDebitnote1 - (Voutype- " + "Debit Note - Others" + " | Vouno-" + int_DNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");

                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid, "CNOps2DN", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());

                                log1.Info("After Call the Procedure ReversalDebitnote2 - (Voutype- " + "Debit Note - Others" + " | Vouno-" + int_DNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");
                             
                            }
                            /***************** For Re-Transfer *******************/

                            //DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_DNno, "Debit Note - Others", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                                log1.Info("Before Call the Procedure ReversalDebitnote A - (Voutype- " + "Debit Note - Others" + " | Vouno-" + int_DNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");
                            }
                            if (retransfer == "Y")
                            {
                                log1.Info("Before Call the Procedure ReversalDebitnote B- (Voutype- " + "Debit Note - Others" + " | Vouno-" + int_DNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");

                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid, "CNOps2DN", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());

                                log1.Info("After Call the Procedure ReversalDebitnote C- (Voutype- " + "Debit Note - Others" + " | Vouno-" + int_DNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");
                            }

                            /***************** End *******************/
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'P', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_DNno, 'V', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);

                            obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "P #" + Convert.ToInt32(txt_receipt.Text) + "-V #" + int_DNno + "/S");

                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('DN #:" + int_DNno + " generated.');", true);

                        }
                        else if (ddl_voucher.SelectedItem.Text == "Sales Invoice") ////////Done
                        {
                            /*dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "I");

                            if (dtrev.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt has genearated for this Invoice. So you can not Reverse.')", true);
                                return;
                            }*/
                            int_CNno = obj_da_OSDNCN.GetOSDCNno("CN", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'E', int_CNno, year);
                                }
                            }


                            //Changed by Priya set of adjustment
                            obj_da_payment.InsCNHeadforreversalnewlv(int_Receipt, int_Vyear, int_bid, int_CNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);

                            //int_CNno = obj_da_OSDNCN.GetOSDCNno("CN", int_bid);
                            //obj_da_payment.InsCNHeadforreversal(int_Receipt, int_Vyear, int_bid, int_CNno, int_Empid, int_Empid);
                            //obj_da_payment.InsVouReversal(int_bid, "I", int_Receipt, int_Vyear, "E", int_CNno, int_Vyear);
                            //ins pro inv 4 revesal
                            //if (jobclosed == 0)
                            //{
                            //    int_refno = obj_da_payment.InsProVou4Reversal(int_bid, "I", int_Receipt, int_Vyear);
                            //    //ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "DNCNReversal", "alertify.alert('CN #: " + int_CNno + " and Pro Invoice Ref # " + int_refno + " generated.');", true);
                            //}
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('CN #: " + int_CNno + "  generated.');", true);
                            if (jobclosed == 1)
                            {
                                if (hid_trantype.Value != "BT")
                                {
                                    //Fn_DNCNBL(int_Jobno, hid_trantype.Value, "Approve", dtdate, int_CNno, "E");
                                    Fn_DNCNBL(int_Jobno, hid_trantype.Value.ToString(), "Approve", dtdate, int_CNno, "E");
                                }
                                else
                                {
                                    Fn_DNCNBLBT(int_Jobno, hid_trantype.Value, "Approve", dtdate, int_CNno, "E");
                                }
                            }


                            //// Einvoice newly added satrt//
                            //div_id = objnew.getinsmastergstdetailsMR(Convert.ToInt32(Session["LoginDivisionId"].ToString()));

                            //string custid1ung = objnew.getunregcustvouchers(int_CNno, year, int_bid, "E");


                            //if (div_id == "1" && custid1ung == "0")
                            //{
                            //    try
                            //    {

                                    
                            //        string json1 = objnew.getgstdetails(int_CNno, int_bid, year, "E");
                                 
                            //        string datajson = DineshhttpPostWebRequets("http://my.gstzen.in/~gstzen/a/post-einvoice-data/einvoice-json/", json1);
                                   

                            //        DataTable dtjson = new DataTable();
                            //        string status = "";
                            //        if (datajson != null)
                            //        {
                            //            dtjson = ConvertJsonToDatatable(datajson);
                            //            status = dtjson.Rows[0][0].ToString().Trim();
                            //        }
                            //        else
                            //        {
                            //            status = "0";
                            //        }

                            //        string message1 = "";
                            //        string IRN1 = "";
                            //        string Ackdt = "";
                            //        string Ackno = "";
                            //        string status1 = "";
                            //        string SignedQRCode = "";
                            //        string SignedInvoice = "";

                            //        string uuid = "";
                            //        string SignedQrCodeImgUrl = "";
                            //        string IrnStatus = "";
                            //        string EwbStatus = "";
                            //        string Irp = "";

                            //        string EwbDt = "";
                            //        string EwbNo = "";
                            //        string EwbValidTill = "";
                            //        string Remarks = "";

                            //        if (status == "1")
                            //        {
                                       


                            //            message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();    		//	1                       
                            //            IRN1 = dtjson.Rows[0][2].ToString().Replace('"', ' ').Trim();       // 2
                            //            Ackdt = dtjson.Rows[0][3].ToString().Replace('"', ' ').Trim();     //3
                            //            Ackno = dtjson.Rows[0][4].ToString().Replace('"', ' ').Trim();    // 4 
                            //            status1 = dtjson.Rows[0][7].ToString().Replace('"', ' ').Trim();  // 7
                            //            SignedQRCode = dtjson.Rows[0][10].ToString().Replace('"', ' ').Trim(); //10

                            //            SignedInvoice = dtjson.Rows[0][11].ToString().Replace('"', ' ').Trim(); //11



                            //            uuid = dtjson.Rows[0][12].ToString().Replace('"', ' ').Trim();  //12
                            //            SignedQrCodeImgUrl = dtjson.Rows[0][13].ToString().Replace('"', ' ').Trim();// 13 
                            //            IrnStatus = dtjson.Rows[0][14].ToString().Replace('"', ' ').Trim();  //14 
                            //            EwbStatus = dtjson.Rows[0][15].ToString().Replace('"', ' ').Trim(); //15
                            //            Irp = dtjson.Rows[0][16].ToString().Replace('"', ' ').Trim(); //16

                            //            EwbDt = dtjson.Rows[0][5].ToString().Replace('"', ' ').Trim(); //5
                            //            EwbNo = dtjson.Rows[0][6].ToString().Replace('"', ' ').Trim(); //6
                            //            EwbValidTill = dtjson.Rows[0][9].ToString().Replace('"', ' ').Trim(); // 9
                            //            Remarks = dtjson.Rows[0][8].ToString().Replace('"', ' ').Trim();//  8



                            //            objnew.insmastergstdetails(int_CNno, year, int_bid, ind_div1, status, message1, IRN1, Ackdt, Ackno, status1, SignedQRCode, SignedInvoice, uuid, SignedQrCodeImgUrl, IrnStatus, EwbStatus, Irp, "E", EwbDt, EwbNo, EwbValidTill, Remarks);


                            //        }
                            //        else
                            //        {
                            //            if (datajson != null)
                            //            {
                            //                message1 = dtjson.Rows[0][1].ToString().Replace('"', ' ').Trim();
                            //            }
                            //            else
                            //            {
                            //                message1 = "The GSTZen user credentials provided in the request are invalid-.";
                            //            }
                            //            objnew.insmastergstdetails(int_CNno, year, int_bid, ind_div1, status, message1, "", "", "", "", "", "", "", "", "", "", "", "E", "", "", "", "");
                            //        }


                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        string message = ex.Message.ToString();
                            //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                            //    }
                            //}

                            // Einvoice newly added end//








                            /* try
                             {
                                 int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_CNno, int_Empid, 1, 8, Str_DBName);
                                 obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 1, int_Vyear, int_bid);
                                 dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);

                                 for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                 {
                                     obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                                 }
                             }
                             catch (Exception ex)
                             {

                             }*/

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'I', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                try
                                {
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'I', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                                    //Obj_Recipts.InsRecptAginstVou("I", int_Receipt, int_Vyear, Convert.ToDouble(txt_total.Text), int_bid, "E", int_CNno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), int_bid, "REV");
                                }
                                catch (Exception ex)
                                {

                                }

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "Invoice", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_CNno, dtdate, 'E', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);

                                    obj_da_Approval.UpdLedgerOPBreakup(int_CNno, 'E', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            /*if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", "Invoice", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                            }*/
                            log1.Info("Before Call the Procedure Reversalcreditnote1 - (Voutype- " + "credit Note - Others" + " | Vouno-" + int_CNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");

                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid, "Inv2CN", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());

                            log1.Info("After Call the Procedure Reversalcreditnote1 - (Voutype- " + "credit Note - Others" + " | Vouno-" + int_CNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");
                            /***************** For Re-Transfer *******************/

                           // DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_CNno, "Credit Note - Others", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";

                                log1.Info("Before Call the Procedure Reversalcreditnote A - (Voutype- " + "credit Note - Others" + " | Vouno-" + int_CNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");
                             
                            }
                            if (retransfer == "Y")
                            {
                                log1.Info("Before Call the Procedure Reversalcreditnote B - (Voutype- " + "credit Note - Others" + " | Vouno-" + int_CNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");

                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid, "Inv2CN", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());

                                log1.Info("After Call the Procedure Reversalcreditnote C - (Voutype- " + "credit Note - Others" + " | Vouno-" + int_CNno + " | Branchid- " + int_bid + " |EmployeeID- " + int_Empid + " |Vouyear- " + int_Vyear + ")");
                            }

                            /***************** End *******************/
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'I', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                            obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "I #" + Convert.ToInt32(txt_receipt.Text) + "-E #" + int_CNno + "/S");

                        }


                        else if (ddl_voucher.SelectedItem.Text == "BOS") /////// Demo
                        {
                            /*dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "I");

                            if (dtrev.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt has genearated for this Invoice. So you can not Reverse.')", true);
                                return;
                            }*/
                            int_CNno = obj_da_OSDNCN.GetOSDCNno("CN", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'E', int_CNno, year);
                                }
                            }


                            //Changed by Priya set of adjustment
                            obj_da_payment.InsCNHeadforreversalnewlv(int_Receipt, int_Vyear, int_bid, int_CNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);

                            //int_CNno = obj_da_OSDNCN.GetOSDCNno("CN", int_bid);
                            //obj_da_payment.InsCNHeadforreversal(int_Receipt, int_Vyear, int_bid, int_CNno, int_Empid, int_Empid);
                            //obj_da_payment.InsVouReversal(int_bid, "I", int_Receipt, int_Vyear, "E", int_CNno, int_Vyear);
                            //ins pro inv 4 revesal
                            //if (jobclosed == 0)
                            //{
                            //    int_refno = obj_da_payment.InsProVou4Reversal(int_bid, "I", int_Receipt, int_Vyear);
                            //    //ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "DNCNReversal", "alertify.alert('CN #: " + int_CNno + " and Pro Invoice Ref # " + int_refno + " generated.');", true);
                            //}
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('CN #: " + int_CNno + "  generated.');", true);
                            if (jobclosed == 1)
                            {
                                if (hid_trantype.Value != "BT")
                                {
                                    Fn_DNCNBL(int_Jobno, hid_trantype.Value.ToString(), "Approve", dtdate, int_CNno, "E");
                                }
                                else
                                {
                                    Fn_DNCNBLBT(int_Jobno, hid_trantype.Value, "Approve", dtdate, int_CNno, "E");
                                }
                            }
                            //try
                            //{
                            //    int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_CNno, int_Empid, 20, 8, Str_DBName);
                            //    obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 20, int_Vyear, int_bid);
                            //    dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);

                            //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            //    {
                            //        obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                            //    }
                            //}
                            //catch (Exception ex)
                            //{

                            //}

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'B', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                try
                                {
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'I', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                                    //Obj_Recipts.InsRecptAginstVou("I", int_Receipt, int_Vyear, Convert.ToDouble(txt_total.Text), int_bid, "E", int_CNno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), int_bid, "REV");
                                }
                                catch (Exception ex)
                                {

                                }

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "BOS", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_CNno, dtdate, 'E', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);

                                    obj_da_Approval.UpdLedgerOPBreakup(int_CNno, 'E', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid, "BOS", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                            }
                            
                            /***************** For Re-Transfer *******************/
                            
                          //  DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_CNno, "Credit Note - Others", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                            }
                            if (retransfer == "Y")
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid, "BOS", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                            }

                            /***************** End *******************/

                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'I', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                            obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "B #" + Convert.ToInt32(txt_receipt.Text) + "-E #" + int_CNno + "/S");

                        }
                        else if (ddl_voucher.SelectedItem.Text == "OSSI")
                        {
                            int_CNno = obj_da_OSDNCN.GetOSDCNno("OSPI", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'C', int_CNno, year);
                                }
                            }


                            //Changed by Priya set of adjustment
                            obj_da_payment.InsCNHeadforreversalnewOSDNlv(int_Receipt, int_Vyear, int_bid, int_CNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);

                            //obj_da_payment.InsVouReversal(int_bid, "I", int_Receipt, int_Vyear, "E", int_CNno, int_Vyear);
                            //ins pro inv 4 revesal
                            //if (jobclosed == 0)
                            //{
                            //int_refno = obj_da_payment.InsProVou4Reversal(int_bid, "D", int_Receipt, int_Vyear);
                            //ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "DNCNReversal", "alertify.alert('CN #: " + int_CNno + " and Pro Invoice Ref # " + int_refno + " generated.');", true);
                            //}
                            if (jobclosed == 1)
                            {
                                Fn_CostTemp4OSDCN(int_Jobno, int_CNno, 'C');
                            }
                            /*try
                            {
                                int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_CNno, int_Empid, 5, 6, Str_DBName);
                                obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 5, int_Vyear, int_bid);
                                dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);

                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                                }
                            }
                            catch (Exception ex)
                            {

                            }*/

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'D', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                try
                                {
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'I', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                                    //Obj_Recipts.InsRecptAginstVou("I", int_Receipt, int_Vyear, Convert.ToDouble(txt_total.Text), int_bid, "E", int_CNno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), int_bid, "REV");
                                }
                                catch (Exception ex)
                                {

                                }

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "OSSI", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customer"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_CNno, dtdate, 'C', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);

                                    obj_da_Approval.UpdLedgerOPBreakup(int_CNno, 'C', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            
                            /*if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", "Invoice", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No");
                            }*/
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid);

                            /***************** For Re-Transfer *******************/

                           // DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_CNno, "OSPI", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                            }
                            if (retransfer == "Y")
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid);
                            }

                            /***************** End *******************/
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'I', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                            obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "OSSI #" + Convert.ToInt32(txt_receipt.Text) + "-C #" + int_CNno + "/S");
                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('OSCN #: " + int_CNno + "  generated.');", true);
                           
                        }
                        else if (ddl_voucher.SelectedItem.Text == "OSPI")
                        {
                            int_DNno = obj_da_OSDNCN.GetOSDCNno("OSSI", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'D', int_DNno, year);
                                }
                            }



                            //Changed Query
                            obj_da_payment.InsCNHeadforreversalnewOSDNlv(int_Receipt, int_Vyear, int_bid, int_DNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);
                            if (jobclosed == 1)
                            {
                                Fn_CostTemp4OSDCN(int_Jobno, int_DNno, 'D');
                            }
                            //obj_da_payment.InsVouReversal(int_bid, "P", int_Receipt, int_Vyear, "V", int_DNno, int_Vyear);// new table

                            /*try
                            {
                                int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_DNno, int_Empid, 6, 5, Str_DBName);
                                obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 6, int_Vyear, int_bid);
                                dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);
                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                                }
                            }
                            catch (Exception ex)
                            {

                            }*/

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'C', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                try
                                {
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'P', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'N', Convert.ToInt32(txt_year.Text));
                                    //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_DNno, 'V', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                                    //Obj_Recipts.InsRecptAginstVou("P", int_Receipt, int_Vyear,Convert.ToDouble(txt_total.Text), int_bid, "V", int_DNno, Convert.ToInt32(Session["Vouyear"].ToString()), Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), int_bid, "REV");
                                }
                                catch (Exception ex)
                                {

                                }

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "OSPI", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);

                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customer"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_DNno, dtdate, 'D', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);
                                    obj_da_Approval.UpdLedgerOPBreakup(int_DNno, 'D', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            /*if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", "CNOps2DN", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSPI", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No");
                            }*/
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid);

                            /***************** For Re-Transfer *******************/

                           // DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_DNno, "OSSI", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                            }
                            if (retransfer == "Y")
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("OSSI", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid);
                            }

                            /***************** End *******************/
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'P', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_DNno, 'V', int_bid, Convert.ToDouble(txt_total.Text), Convert.ToDouble(txt_total.Text), 'Y', int_Curr_Vouyear);
                            obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "OSPI #" + Convert.ToInt32(txt_receipt.Text) + "-D #" + int_DNno + "/S");

                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('OSDN #:" + int_DNno + " generated.');", true);
                          

                        }
                        else if (ddl_voucher.SelectedItem.Text == "Debit Note")
                        {
                            int_CNno = obj_da_OSDNCN.GetOSDCNno("CN", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'E', int_CNno, year);
                                }
                            }


                            obj_da_payment.InsCNHeadforreversalnewlv(int_Receipt, int_Vyear, int_bid, int_CNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);
                            //obj_da_payment.InsVouReversal(int_bid, "V", int_Receipt, int_Vyear, "E", int_CNno, int_Vyear);
                            if (jobclosed == 1)
                            {
                                Fn_DNCNBL(int_Jobno, hid_trantype.Value.ToString(), "Approve", dtdate, int_CNno, "E");
                            }
                            //try
                            //{
                            //    int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_CNno, int_Empid, 7, 8, Str_DBName);
                            //    obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 7, int_Vyear, int_bid);
                            //    //dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);

                            //    //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            //    //{
                            //    //    obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                            //    //}
                            //}
                            //catch (Exception ex)
                            //{

                            //}

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'V', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "Debit Note - Others", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_CNno, dtdate, 'E', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);

                                    obj_da_Approval.UpdLedgerOPBreakup(int_CNno, 'E', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            //if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            //{
                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid, "Credit Note - Others", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());

                            //}

                            /***************** For Re-Transfer *******************/

                          //  DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_CNno, "Credit Note - Others", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                            }
                            if (retransfer == "Y")
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Credit Note - Others", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", int_bid, "Credit Note - Others", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                            }

                            /***************** End *******************/
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'V', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', int_Curr_Vouyear);
                            obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "V #" + Convert.ToInt32(txt_receipt.Text) + "-E #" + int_CNno + "/S");

                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('CN # is:" + int_CNno + "');", true);

                        }
                        else if (ddl_voucher.SelectedItem.Text == "Credit Note")
                        {
                            int_DNno = obj_da_OSDNCN.GetOSDCNno("DN", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'V', int_DNno, year);
                                }
                            }


                            obj_da_payment.InsCNHeadforreversalnewlv(int_Receipt, int_Vyear, int_bid, int_DNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);
                            //obj_da_payment.InsVouReversal(int_bid, "E", int_Receipt, int_Vyear, "V", int_DNno, int_Vyear);
                            if (jobclosed == 1)
                            {
                                Fn_DNCNBL(int_Jobno, hid_trantype.Value.ToString(), "Approve", dtdate, int_DNno, "V");
                            }
                            //try
                            //{
                            //    int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_DNno, int_Empid, 8, 7, Str_DBName);
                            //    obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 8, int_Vyear, int_bid);
                            //    //dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);
                            //    //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            //    //{
                            //    //    obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                            //    //}
                            //}
                            //catch (Exception ex)
                            //{

                            //}

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'E', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "Credit Note - Others", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);

                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_DNno, dtdate, 'V', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);
                                    obj_da_Approval.UpdLedgerOPBreakup(int_DNno, 'V', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            //if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            //{
                            //    logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", "Credit Note - Others", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                            //}

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'E', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                            }
                            catch (Exception Ex)
                            {
                            }

                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid, "Debit Note - Others", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());

                            /***************** For Re-Transfer *******************/

                           // DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_DNno, "Debit Note - Others", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                            }
                            if (retransfer == "Y")
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Debit Note - Others", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid, "Debit Note - Others", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                            }

                            /***************** End *******************/
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'E', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_DNno, 'V', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', int_Curr_Vouyear);
                            obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "E #" + Convert.ToInt32(txt_receipt.Text) + "-V #" + int_DNno + "/S");

                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('DN # is:" + int_DNno + "');", true);

                        }

                        else if (ddl_voucher.SelectedItem.Text == "DN-Admin")
                        {
                            int_CNno = obj_da_OSDNCN.GetOSDCNno("ACN", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'S', int_CNno, year);
                                }
                            }


                            obj_da_payment.InsCNHeadforreversalnewADNlv(int_Receipt, int_Vyear, int_bid, int_CNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);
                            //obj_da_payment.InsVouReversal(int_bid, "V", int_Receipt, int_Vyear, "E", int_CNno, int_Vyear);
                            /*if (jobclosed == 1)
                            {
                                Fn_DNCNBL(int_Jobno, hid_trantype.Value.ToString(), "Closed", dtdate, int_CNno, "S");
                            }*/
                            /*try
                            {
                                int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_CNno, int_Empid, 4, 3, Str_DBName);
                                obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 4, int_Vyear, int_bid);
                                dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);

                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                                }
                            }
                            catch (Exception ex)
                            {

                            }*/

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'X', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "Admin Sales Invoice", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);
                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_CNno, dtdate, 'S', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);

                                    obj_da_Approval.UpdLedgerOPBreakup(int_CNno, 'S', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }

                            if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Purchase Invoice", int_CNno, int_CNno, "Vessel/Voyage/Container", "BL No", "Admin Sales Invoice", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Purchase Invoice", int_CNno, int_CNno, "Remarks", "Ref No", int_bid);
                            }

                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Purchase Invoice", int_CNno, int_CNno, "Remarks", "Ref No", int_bid);

                            /***************** For Re-Transfer *******************/

                           // DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_CNno, "Admin Purchase Invoice", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                            }
                            if (retransfer == "Y")
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Purchase Invoice", int_CNno, int_CNno, "Remarks", "Ref No", int_bid);
                            }

                            /***************** End *******************/
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'V', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_CNno, 'E', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', int_Curr_Vouyear);
                            if (int_bid == 5)
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1954, 1, int_bid, "X #" + Convert.ToInt32(txt_receipt.Text) + "-S #" + int_CNno + "/S");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "X #" + Convert.ToInt32(txt_receipt.Text) + "-S #" + int_CNno + "/S");
                            }


                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('CN-ADN # is:" + int_CNno + "');", true);

                        }
                        else if (ddl_voucher.SelectedItem.Text == "CN-Admin")
                        {
                            int_DNno = obj_da_OSDNCN.GetOSDCNno("ADN", int_bid);

                            for (int d = 0; d <= Grd_Charge.Rows.Count - 1; d++)
                            {
                                if (Grd_Charge.Rows[d].Cells[11].Text != "" && Grd_Charge.Rows[d].Cells[17].Text == "N")
                                {
                                    obj_da_payment.InsVouReversalNew(Convert.ToInt32(Grd_Charge.Rows[d].Cells[16].Text), Grd_Charge.Rows[d].Cells[0].Text.Replace("&amp;", "&"),
                                        (Grd_Charge.Rows[d].Cells[1].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[2].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[3].Text), Grd_Charge.Rows[d].Cells[4].Text,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[5].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[6].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[7].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[8].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[9].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[10].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[11].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[12].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[13].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[14].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[15].Text), Convert.ToChar(Hid_voutype.Value), Convert.ToInt32(txt_receipt.Text), Convert.ToInt32(txt_year.Text), int_bid,
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[24].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[18].Text), Convert.ToDouble(Grd_Charge.Rows[d].Cells[19].Text),
                                        Convert.ToDouble(Grd_Charge.Rows[d].Cells[20].Text), Grd_Charge.Rows[d].Cells[22].Text, int_Jobno, hid_trantype.Value, 'X', int_DNno, year);
                                }
                            }

                            obj_da_payment.InsCNHeadforreversalnewADNlv(int_Receipt, int_Vyear, int_bid, int_DNno, int_Empid, int_Empid, reversal, Afterjobclosed, ddl_voucher.SelectedItem.Text);
                            //obj_da_payment.InsVouReversal(int_bid, "E", int_Receipt, int_Vyear, "V", int_DNno, int_Vyear);
                            /*if (jobclosed == 1)
                            {
                                Fn_DNCNBL(int_Jobno, hid_trantype.Value.ToString(), "Closed", dtdate, int_DNno, "X");
                            }
                            try
                            {
                                int int_voucherid = obj_da_Reversal.InsReversalVouchers(int_bid, int_Vyear, int_Receipt, int_DNno, int_Empid, 3, 4, Str_DBName);
                                obj_da_Reversal.InsReversalFAVouDetails(Str_DBName, int_voucherid, int_Receipt, 3, int_Vyear, int_bid);
                                dt = obj_da_Reversal.GetReversalVoucherDtls(int_voucherid, Str_DBName);
                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    obj_da_Reversal.UpdReversalLedgerDtls(Convert.ToInt32(dt.Rows[i]["ledgerid"].ToString()), int_bid, int_divisionid, Convert.ToDouble(dt.Rows[i]["ledgeramount"].ToString()), Str_DBName, dt.Rows[i]["ledgertype"].ToString(), int_Vyear);
                                }
                            }
                            catch (Exception ex)
                            {

                            }

                            try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'S', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");

                                dt = obj_da_invoice.FAShowTallyDtlv(int_Receipt, "Admin Purchase Invoice", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);

                                if (dt.Rows.Count > 0)
                                {
                                    int Custid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                                    int int_ChkLedherid = obj_da_Ledger.ChkLedgeridfrmLedHead(Custid, "C", Str_DBName);
                                    if (int_ChkLedherid == 0)
                                    {
                                        int_ChkLedherid = Fn_Getcustomergroupid(ddl_voucher.SelectedItem.Text, Custid);
                                    }

                                    obj_da_Approval.InsLedgerOPBreakuplv(int_ChkLedherid, int_DNno, dtdate, 'X', Convert.ToInt32(Session["Vouyear"].ToString()), int_bid, Convert.ToDouble(txt_AmountTot.Text), "", 0, Custid);
                                    obj_da_Approval.UpdLedgerOPBreakup(int_DNno, 'X', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                                }
                            }
                            catch (Exception Ex)
                            {
                            }
                                     
                             try
                            {
                                obj_da_Approval.UpdLedgerOPBreakup(int_Receipt, 'S', int_Vyear, int_bid, -5, 'C', int_Vyear, Convert.ToDouble(txt_AmountTot.Text), "", 0, "", "");
                            }
                            catch (Exception Ex)
                            {
                            }
                                     

                            if (int_Vyear == (Convert.ToInt32(Session["Vouyear"].ToString()) - 1))
                            {
                                // logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", "Admin Purchase Invoice", int_Receipt, int_Vyear, ddl_voucher.SelectedValue.ToString());
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No");
                            }*/


                            logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid);

                            /***************** For Re-Transfer *******************/

                          //  DataAccess.FAMaster.ReportView objrv = new DataAccess.FAMaster.ReportView();
                            DataSet ds = new DataSet();
                            //DataTable dtnew = new DataTable();
                            DataTable dtnew1 = new DataTable();
                            double dbtot = 0.00, crtot = 0.00;
                            string retransfer = "N";

                            ds = objrv.Getapprovingvouchermail(int_DNno, "Admin Sales Invoice", int_bid, int_Vyear, Session["FADbname"].ToString());

                            //dtnew = ds.Tables[0];
                            dtnew1 = ds.Tables[1];

                            if (dtnew1.Rows.Count > 0)
                            {
                                dbtot = Convert.ToDouble(dtnew1.Compute("SUM(Debit)", string.Empty));
                                crtot = Convert.ToDouble(dtnew1.Compute("SUM(Credit)", string.Empty));
                            }

                            if (dbtot != crtot)
                            {
                                retransfer = "Y";
                            }
                            if (retransfer == "Y")
                            {
                                logix.CommanClass.TallyEDIFA.Fn_FATransfer("Admin Sales Invoice", int_DNno, int_DNno, "Vessel/Voyage/Container", "BL No", int_bid);
                            }

                            /***************** End *******************/

                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', Convert.ToInt32(txt_receipt.Text), 'E', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', Convert.ToInt32(txt_year.Text));
                            //Obj_Recipts.InsRecptAginstInv(-5, 'C', int_DNno, 'V', int_bid, Convert.ToDouble(txt_AmountTot.Text), Convert.ToDouble(txt_AmountTot.Text), 'Y', int_Curr_Vouyear);
                            if (int_bid == 5)
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1954, 1, int_bid, "S #" + Convert.ToInt32(txt_receipt.Text) + "-X #" + int_DNno + "/S");
                            }
                            else
                            {
                                obj_da_Log.InsLogDetail(int_Empid, 1904, 1, int_bid, "S #" + Convert.ToInt32(txt_receipt.Text) + "-X #" + int_DNno + "/S");
                            }

                            ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('DN-ADN # is:" + int_DNno + "');", true);

                        }

                        //dt = obj_da_payment.CheckVouReversal(int_Receipt, int_bid, Hid_voutype.Value, int_Vyear);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Already Reversed');", true);
                        btn_reverse.Enabled = false;
                    }
                    btn_cancel.Text = "Cancel";
                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    btn_reverse.Enabled = false;
                    txt_USDRate.Enabled = false;
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Please Select" + lbl_receipt.Text + "');", true);
                    //    txt_receipt.Focus();
                    //}
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Please Select Voucher Type')", true);
                    //    ddl_voucher.Focus();
                    //    return;
                    //}
                    Fn_Clear();
                    //ddl_voucher.SelectedValue = "0";
                    ClearCharge();
                    txt_receipt.Enabled = false;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Please Select the Charge')", true);
            }
        }

        private int Fn_Getcustomergroupid(string str_voucher, int Cid)
        {
            int int_Subgroupid = 0, int_Groupid = 0, int_Ledgerid = 0;
            //DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
            //DataAccess.FAMaster.MasterLedger obj_da_Ledger = new DataAccess.FAMaster.MasterLedger();
            if (str_voucher == "Purchase Invoice")
            {
                if (obj_da_Customer.GetCustomerType(Cid) == "P")
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
            else if (str_voucher == "Invoices")
            {
                if (obj_da_Customer.GetCustomerType(Cid) == "P")
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
            else if (str_voucher == "BOS")
            {
                if (obj_da_Customer.GetCustomerType(Cid) == "P")
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
            int_Ledgerid = obj_da_Ledger.InsLedgerHeadfromTally(obj_da_Customer.GetCustomername(Cid), int_Subgroupid, int_Groupid, 'G', Cid, 'C', Session["FADbname"].ToString());
            return int_Ledgerid;

        }
        ////hideon 24Nov2021
        //private void Fn_DNCNBL(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        //{
        //    int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
        //    double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
        //    int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
        //    DateTime dtdate = CDate;
        //    DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
        //    if (int_bid == 0 || int_bid == null)
        //    {
        //        int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
        //    }
        //    obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "O", int_bid, vouno, voutype);
        //    DataTable obj_dt = new DataTable();
        //    DataTable obj_dttemp = new DataTable();
        //    if (type == "Closed")
        //    {
        //        obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype);

        //    }
        //    else if (type == "Approve")
        //    {
        //        obj_dt = obj_da_Cost.GetDNCN4MISFromVouno(jobno, int_bid, trantype, vouno, voutype);
        //    }
        //    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
        //    char Nomination = ' ';
        //    string blno;
        //    double volume = 0;
        //    if (obj_dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
        //        {
        //            blno = obj_dt.Rows[i]["blno"].ToString();
        //            int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
        //            if (trantype != "CH")
        //            {
        //                MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
        //            }
        //            else
        //            {
        //                MLO = 0;
        //            }
        //            if (type == "Closed")
        //            {
        //                dtdate = CDate;
        //            }
        //            else if (type == "Approve")
        //            {
        //                //dtdate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["voudate"].ToString()));
        //                dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
        //            }
        //            obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
        //            if (obj_dttemp.Rows.Count > 0)
        //            {
        //                if (i < obj_dt.Rows.Count - 1)
        //                {
        //                    if (obj_dt.Rows[i]["blno"].ToString() != obj_dt.Rows[i + 1]["blno"].ToString())
        //                    {
        //                        if (obj_dt.Rows[i]["voutype"].ToString() == "V")
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                        else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (obj_dt.Rows[i]["voutype"].ToString() == "V")
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                            {
        //                                BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    if (obj_dt.Rows[i]["voutype"].ToString() == "V")
        //                    {
        //                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                        {
        //                            BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
        //                        }
        //                    }
        //                    else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
        //                    {
        //                        if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
        //                        {
        //                            BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
        //                        }
        //                    }
        //                }
        //                int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
        //                blno = obj_dttemp.Rows[0][1].ToString();
        //                int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
        //                int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
        //                int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
        //                int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
        //                int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
        //                int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());
        //                if (trantype != "CH")
        //                {
        //                    int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
        //                }
        //                if (!string.IsNullOrEmpty(obj_dttemp.Rows[0][4].ToString()))
        //                {
        //                    if (obj_dttemp.Rows[0][4].ToString().Length > 0)
        //                    {
        //                        Nomination = char.Parse(obj_dttemp.Rows[0][4].ToString());
        //                    }
        //                }
        //                else
        //                {
        //                    Nomination = ' ';
        //                }

        //                volume = Convert.ToDouble(obj_dttemp.Rows[0][5].ToString());

        //                if (trantype == "FE" || trantype == "FI")
        //                {
        //                    if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
        //                    {
        //                        int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
        //                        int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
        //                        JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
        //                    }
        //                }
        //                else if (trantype == "AE" || trantype == "AI" || trantype == "CH")
        //                {
        //                    int_Cont20 = 0;
        //                    int_Cont40 = 0;
        //                    JobType = 0;
        //                }
        //                BL_Amount = BL_Amount + BL_debit;
        //                BL_Expense = BL_Expense + BL_credit;
        //                volume = 0;
        //                int_Cont20 = 0;
        //                int_Cont40 = 0;


        //                obj_da_Cost.InsCostingTempRptnew(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, char.Parse(voutype));
        //            }
        //            else
        //            {
        //                Fn_DNCNMBL(jobno, trantype, vouno, voutype, i, obj_dt, int_bid, dtdate);
        //            }
        //        }
        //    }

        //}
        private void Fn_DNCNBL(int jobno, string trantype, string type, DateTime CDate, int vouno, string voutype)
        {
            int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            double BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
            DateTime dtdate = CDate;
          //  DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            if (int_bid == 0 || int_bid == null)
            {
                int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "O", int_bid, vouno, voutype);
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            if (type == "Closed")
            {
                // obj_dt = obj_da_Cost.GetDNCN4MISFromJobNo(jobno, int_bid, trantype); hideon02112021
                obj_dt = obj_da_Cost.GetDNCN4MISFromJobNoReversal(jobno, int_bid, trantype);
            }
            else if (type == "Approve")
            {
                obj_dt = obj_da_Cost.GetDNCN4MISFromVouno(jobno, int_bid, trantype, vouno, voutype);
            }
            int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
            char Nomination = ' ';
            string blno;
            double volume = 0;
            if (obj_dt.Rows.Count > 0)
            {
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    blno = obj_dt.Rows[i]["blno"].ToString();
                    int_job = Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString());
                    if (trantype != "CH")
                    {
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());
                    }
                    else
                    {
                        MLO = 0;
                    }
                    if (type == "Closed")
                    {
                        dtdate = CDate;
                    }
                    else if (type == "Approve")
                    {
                        //dtdate = DateTime.Parse(Utility.fn_ConvertDate(obj_dt.Rows[i]["voudate"].ToString()));
                        dtdate = DateTime.Parse((obj_dt.Rows[i]["voudate"].ToString()));
                    }
                    obj_dttemp = obj_da_Cost.GetBLRowBL(blno, trantype, int_bid);
                    if (obj_dttemp.Rows.Count > 0)
                    {
                        if (i < obj_dt.Rows.Count - 1)
                        {
                            if (obj_dt.Rows[i]["blno"].ToString() != obj_dt.Rows[i + 1]["blno"].ToString())
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    //if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    //{
                                    //    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    //}
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                    else if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        BL_Expense = -Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    //if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    //{
                                    //    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    //}
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                    else if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        BL_Amount = -Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    //if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    //{
                                    //    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    //}
                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                    else if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        BL_Expense = -Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                                else
                                {
                                    //if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                    //{
                                    //    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    //}

                                    if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "N")
                                    {
                                        BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                    else if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "R")
                                    {
                                        BL_Amount = -Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (obj_dt.Rows[i]["voutype"].ToString() == "V")
                            {
                                //if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                //{
                                //    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                //}
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    BL_Amount = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                                else if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    BL_Expense = -Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                            else if (obj_dt.Rows[i]["voutype"].ToString() == "E")
                            {
                                //if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0)
                                //{
                                //    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                //}
                                if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "N")
                                {
                                    BL_Expense = Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                                else if (obj_dt.Rows[i]["amount"].ToString().Trim().Length > 0 && obj_dt.Rows[i]["Reversal"].ToString() == "R")
                                {
                                    BL_Amount = -Convert.ToDouble(obj_dt.Rows[i]["amount"].ToString());
                                }
                            }
                        }
                        int_job = Convert.ToInt32(obj_dttemp.Rows[0][0].ToString());
                        blno = obj_dttemp.Rows[0][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[0][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[0][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[0][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[0][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[0][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[0][11].ToString());
                        if (trantype != "CH")
                        {
                            int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        }
                        if (!string.IsNullOrEmpty(obj_dttemp.Rows[0][4].ToString()))
                        {
                            if (obj_dttemp.Rows[0][4].ToString().Length > 0)
                            {
                                Nomination = char.Parse(obj_dttemp.Rows[0][4].ToString());
                            }
                        }
                        else
                        {
                            Nomination = ' ';
                        }

                        volume = Convert.ToDouble(obj_dttemp.Rows[0][5].ToString());

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[0][2].ToString().Length > 0 && obj_dttemp.Rows[0][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[0][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[0][3].ToString());
                                JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI" || trantype == "CH")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                            JobType = 0;
                        }
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;
                        volume = 0;
                        int_Cont20 = 0;
                        int_Cont40 = 0;


                        obj_da_Cost.InsCostingTempRpt(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, dtdate, MLO, vouno, char.Parse(voutype));
                    }
                    else
                    {
                        Fn_DNCNMBL(jobno, trantype, vouno, voutype, i, obj_dt, int_bid, dtdate);
                    }
                }
            }

        }
        private void Fn_DNCNMBL(int jobno, string trantype, int vouno, string voutype, int count, DataTable dt, int int_bid, DateTime Close_date)
        {
            double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
            int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
          //  DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
            // obj_da_Cost.DelCostingDetailsRpt(jobno, trantype, "V", int_bid, 0, "");
            DataTable obj_dt = new DataTable();
            DataTable obj_dttemp = new DataTable();
            if (int_bid == 0 || int_bid == null)
            {
                int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }
            obj_dt = obj_da_Cost.GetBLRow(jobno, trantype, int_bid);

            if (obj_dt.Rows.Count > 0)
            {
                if (count < dt.Rows.Count - 1)
                {
                    if (dt.Rows[count]["blno"].ToString() != dt.Rows[count + 1]["blno"].ToString())
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (dt.Rows[count]["voutype"].ToString() == "V")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                // BL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                                MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                        else if (dt.Rows[count]["voutype"].ToString() == "E")
                        {
                            if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                            {
                                //  BL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                                MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                            }
                        }
                    }
                }
                else
                {
                    if (dt.Rows[count]["voutype"].ToString() == "V")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Amount = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                    else if (dt.Rows[count]["voutype"].ToString() == "E")
                    {
                        if (dt.Rows[count]["amount"].ToString().Trim().Length > 0)
                        {
                            MBL_Expense = Convert.ToDouble(dt.Rows[count]["amount"].ToString());
                        }
                    }
                }
                if (trantype == "FE" || trantype == "FI")
                {
                    JobType = Convert.ToInt32(dt.Rows[count]["jobtype"].ToString());
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                    {
                        Total_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                        Total_Tues = Convert.ToDouble(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                    }
                }
                else if (trantype == "AE" || trantype == "AI")
                {
                    JobType = 0;
                    obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(dt.Rows[count]["jobno"].ToString()), trantype, int_bid);
                    if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                    {
                        JobChargeWT = Convert.ToDouble(obj_dttemp.Rows[0][0].ToString());

                    }
                }
                for (int j = 0; j <= obj_dt.Rows.Count - 1; j++)
                {
                    BL_Amount = 0;
                    BL_Expense = 0;
                    if (trantype == "FE" || trantype == "FI")
                    {
                        BL_Tues = Convert.ToInt32(obj_dt.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dt.Rows[j]["cont40"].ToString()) * 2);
                        BL_CBM = Convert.ToDouble(obj_dt.Rows[j]["cbm"].ToString());
                        if (MBL_Amount != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Amount = ((MBL_Amount / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                BL_Amount = ((MBL_Amount / Total_CBM) * BL_CBM);
                            }
                        }

                        if (MBL_Expense != 0)
                        {
                            if (JobType == 3)
                            {
                                BL_Expense = ((MBL_Expense / Total_Tues) * BL_Tues);
                            }
                            else
                            {
                                if (BL_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else if (Total_CBM == 0)
                                {
                                    BL_Expense = 0;
                                }
                                else
                                {
                                    BL_Expense = ((MBL_Expense / Total_CBM) * BL_CBM);
                                }
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        BL_ChargeWT = Convert.ToDouble(obj_dt.Rows[j]["chargewt"].ToString());

                        if (MBL_Amount != 0)
                        {
                            BL_Amount = ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                        }
                        if (MBL_Expense != 0)
                        {
                            BL_Expense = ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
                        }
                    }

                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (obj_dt.Rows[j][2].ToString().Length > 0 && obj_dt.Rows[j][3].ToString().Length > 0)
                        {
                            int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        int_Cont20 = 0;
                        int_Cont40 = 0;
                    }
                    int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                    char Nomination = ' ';
                    string blno;
                    double volume = 0;
                    int_job = Convert.ToInt32(obj_dt.Rows[j][0].ToString());
                    blno = obj_dt.Rows[j][1].ToString();
                    int_shipper = Convert.ToInt32(obj_dt.Rows[j][6].ToString());
                    int_consignee = Convert.ToInt32(obj_dt.Rows[j][7].ToString());
                    int_notify = Convert.ToInt32(obj_dt.Rows[j][8].ToString());
                    int_agent = Convert.ToInt32(obj_dt.Rows[j][9].ToString());
                    int_pol = Convert.ToInt32(obj_dt.Rows[j][10].ToString());
                    int_pod = Convert.ToInt32(obj_dt.Rows[j][11].ToString());
                    int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                    if (!string.IsNullOrEmpty(obj_dt.Rows[j][4].ToString()))
                    {
                        if (obj_dt.Rows[j][4].ToString().Length > 0)
                        {
                            Nomination = char.Parse(obj_dt.Rows[j][4].ToString());
                        }

                    }
                    else
                    {
                        Nomination = ' ';
                    }

                    volume = Convert.ToDouble(obj_dt.Rows[j][5].ToString());
                    if (trantype == "FE" || trantype == "FI")
                    {
                        if (JobType == 3)
                        {

                            volume = 0;
                            //int_Cont20 = Convert.ToInt32(obj_dt.Rows[j][2].ToString());
                            //int_Cont40 = Convert.ToInt32(obj_dt.Rows[j][3].ToString());
                        }
                        else
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                    }
                    obj_da_Cost.InsCostingTempRptnew(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, 0, 0, 0, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, vouno, char.Parse(voutype));

                }
            }
        }

        protected void btn_VouCancel_Click(object sender, EventArgs e)
        {
            this.PopUpService.Show();

        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            try
            {
                Voucancel();
                // this.PopUpService.Hide();

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        public void Voucancel()
        {
            try
            {

                string cname = "", StrScript;
                int int_Receipt;
                int int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                int int_Vyear = Convert.ToInt32(txt_year.Text.ToString());
                int int_Jobno = Convert.ToInt32(hid_job.Value.ToString());
                string Str_DBName = Session["FADbname"].ToString();
                DateTime dtdate = obj_da_Log.GetDate();
                DataTable dtrev = new DataTable();

                //DataAccess.Accounts.Payment obj_da_payment = new DataAccess.Accounts.Payment();
                //DataAccess.Accounts.Invoice obj_da_invoice = new DataAccess.Accounts.Invoice();
                //DataAccess.Accounts.OSDNCN obj_da_OSDNCN = new DataAccess.Accounts.OSDNCN();
                //DataAccess.Accounts.Approval obj_da_Approval = new DataAccess.Accounts.Approval();
                DataTable obj_dt = new DataTable();
                DataTable dt = new DataTable();
                DataTable dt_list = new DataTable();
                string jobvalid = "";

                if (txt_receipt.Text != "")
                {
                    int_Receipt = Convert.ToInt32(txt_receipt.Text.ToString());
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Enter the Voucher #')", true);
                    ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Please Enter the Voucher #');", true);
                    return;
                }

                //if (ddl_voucher.SelectedValue != "0")
                //{
                //    if ((txt_receipt.Text.Trim().Length > 0 && int_Jobno != 0) || (txt_trantype.Text == "WAREHOUSE" && txt_receipt.Text.Trim().Length > 0))
                //    {
                obj_dt = obj_da_payment.CheckVouReversal(int_Receipt, int_bid, Hid_voutype.Value, int_Vyear);

                if (obj_dt.Rows.Count <= 0)
                {

                    if (hid_Custtype.Value.ToString() == "P")
                    {
                        return;
                    }
                    if (ddl_voucher.SelectedItem.Text == "Sales Invoice")
                    {
                        dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "I");

                        if (dtrev.Rows.Count > 0)
                        {
                            //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt has genearated for this Invoice. So you can not cancel the Vocuher.')", true);
                            ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Receipt has genearated for this Invoice. So you can not cancel the Vocuher.');", true);
                            return;
                        }

                        jobvalid = obj_da_invoice.Chkjobvalid(int_Jobno, int_bid, hid_trantype.Value);
                        if (jobvalid == "0" || jobvalid == "False")
                        {
                            obj_da_invoice.InsDelVouDetails(Convert.ToInt32(txt_receipt.Text), "I", Convert.ToInt32(txt_year.Text), int_bid, int_Jobno, hid_trantype.Value, hid_blno.Value, Str_DBName);
                            ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Invoice # " + txt_receipt.Text + " Cancelled.');", true);

                            obj_da_Log.InsLogDetail(int_Empid, 1904, 5, int_bid, "I #" + Convert.ToInt32(txt_receipt.Text) + "-Job #" + int_Jobno + "Year -" + Convert.ToInt32(txt_year.Text) + "/Cancel");
                        }
                        else if (jobvalid == "1" || jobvalid == "True")
                        {
                            ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Job already closed.So you can not cancel the Vocuher. Kindly Reverse the Voucher.');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Job already closed.So you can't cancel the Vocuher. Kindly Reverse the Voucher.')", true);
                            return;
                        }

                    }

                    else if (ddl_voucher.SelectedItem.Text == "Purchase Invoice")
                    {
                        dtrev = obj_da_Reversal.GetReciptPaymentDet4VouNo(Convert.ToInt32(txt_receipt.Text), int_bid, int_divisionid, Convert.ToInt32(txt_year.Text), "P");

                        if (dtrev.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Receipt has genearated for this CN-Ops. So you can not cancel the Vocuher.')", true);
                            return;
                        }

                        jobvalid = obj_da_invoice.Chkjobvalid(int_Jobno, int_bid, hid_trantype.Value);
                        if (jobvalid == "0" || jobvalid == "False")
                        {
                            obj_da_invoice.InsDelVouDetails(Convert.ToInt32(txt_receipt.Text), "P", Convert.ToInt32(txt_year.Text), int_bid, int_Jobno, hid_trantype.Value, hid_blno.Value, Str_DBName);
                            ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Cn-Ops # " + txt_receipt.Text + " Cancelled.');", true);
                            obj_da_Log.InsLogDetail(int_Empid, 1904, 5, int_bid, "P #" + Convert.ToInt32(txt_receipt.Text) + "-Job #" + int_Jobno + "Year -" + Convert.ToInt32(txt_year.Text) + "/Cancel");
                            Fn_Clear();
                            ddl_voucher.SelectedValue = "0";
                        }
                        else if (jobvalid == "1" || jobvalid == "True")
                        {
                            ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Job already closed.So you can not cancel the Vocuher. Kindly Reverse the Voucher.');", true);
                            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Job already closed.So you can't cancel the Vocuher. Kindly Reverse the Voucher.')", true);
                            return;
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Already Reversed');", true);
                    //txt_rvouno.Text = obj_dt.Rows[0]["rvouno"].ToString();
                    //txt_ryear.Text = obj_dt.Rows[0]["rvouyear"].ToString();
                    btn_VouCancel.Enabled = false;
                }
                btn_cancel.Text = "Cancel";
                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

                //    }
                //    else
                //    {
                //        ScriptManager.RegisterStartupScript(btn_VouCancel, typeof(Button), "Reversal", "alertify.alert('Please Select" + lbl_receipt.Text + "');", true);
                //        txt_receipt.Focus();
                //    }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Please Select Voucher Type')", true);
                //    ddl_voucher.Focus();
                //    return;
                //}
                btn_reverse.Enabled = false;
                txt_USDRate.Enabled = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopUpService.Hide();

            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void Grd_Charge_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkChild = (e.Row.FindControl("chkChild") as CheckBox);
                if ((Convert.ToInt32(txt_year.Text) > 2020) && (ddl_voucher.SelectedItem.Text.ToString() == "Invoice"))
                {
                    chkChild.Enabled = true;
                    btn_add.Enabled = true; // by hari 12-1-23
                }
                else
                {
                    chkChild.Enabled = true;
                    btn_add.Enabled = true;
                }


                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Charge, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";


            }


        }

        protected void Grd_Charge_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_USDRate.Enabled = true;
            if (Grd_Charge.SelectedRow.Cells[17].Text == "N" || Grd_Charge.SelectedRow.Cells[17].Text == "")
            {
                //if (Grd_Charge.SelectedRow.Cells[21].Text != "0")
                if (Convert.ToInt32(Grd_Charge.SelectedRow.Cells[16].Text) != 3063 && Convert.ToInt32(Grd_Charge.SelectedRow.Cells[16].Text) != 4537)
                {
                    txt_charge.Text = Grd_Charge.SelectedRow.Cells[0].Text.Replace("&amp;", "&");
                    hid_Chargeid.Value = Convert.ToInt32(Grd_Charge.SelectedRow.Cells[16].Text).ToString();
                    txt_curr.Text = Grd_Charge.SelectedRow.Cells[1].Text;
                    txt_rate.Text = Grd_Charge.SelectedRow.Cells[2].Text.Replace(",", "");
                    txt_exrate.Text = Grd_Charge.SelectedRow.Cells[3].Text;
                    txt_base.Text = Grd_Charge.SelectedRow.Cells[4].Text;
                    txt_amount.Text = Grd_Charge.SelectedRow.Cells[5].Text;
                    txt_amount.Text = String.Format("{0:F2}", txt_amount.Text);
                    txt_GST.Text = Grd_Charge.SelectedRow.Cells[6].Text;
                    txt_NET.Text = Grd_Charge.SelectedRow.Cells[7].Text;
                    //txt_USDRate.Text = Grd_Charge.SelectedRow.Cells[8].Text;
                    //txt_reversal.Text = Grd_Charge.SelectedRow.Cells[9].Text;
                    //txt_Diff.Text = Grd_Charge.SelectedRow.Cells[12].Text;
                    txt_Unit.Text = Grd_Charge.SelectedRow.Cells[21].Text;
                    hdnUnit.Value = Grd_Charge.SelectedRow.Cells[21].Text;
                    if (ddl_voucher.SelectedItem.Text == "OSSI" || ddl_voucher.SelectedItem.Text == "OSPI")
                    {
                        hid_blno.Value = Grd_Charge.SelectedRow.Cells[22].Text;
                        hid_Chk_Mbl.Value = Grd_Charge.SelectedRow.Cells[25].Text;
                        if (hid_Chk_Mbl.Value == "&nbsp;" || hid_Chk_Mbl.Value == " ")
                        {
                            if (hid_Mbl.Value == hid_blno.Value)
                            {
                                hid_Chk_Mbl.Value = "M";
                            }
                            else
                            {
                                hid_Chk_Mbl.Value = "H";
                            }
                        }
                    }
                    txt_USDRate.Focus();
                    hid_fcamount.Value = "0.00";

                    hid_GSTpercentage.Value = Grd_Charge.SelectedRow.Cells[15].Text;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('ROUND UP and ROUND OFF charge can not be Revised');", true);
                    ClearCharge();
                }

                CheckBox chkChild = (CheckBox)Grd_Charge.SelectedRow.FindControl("chkChild");
                if (chkChild.Checked == true)
                {
                    GridViewRow gvr = Grd_Charge.SelectedRow;
                    gvr.Cells[8].Text = "";
                    gvr.Cells[9].Text = "";
                    gvr.Cells[10].Text = "";
                    gvr.Cells[11].Text = "";
                    gvr.Cells[12].Text = "";
                    gvr.Cells[13].Text = "";
                    gvr.Cells[14].Text = "";
                    gvr.Cells[17].Text = "";
                    gvr.Cells[18].Text = "";
                    gvr.Cells[19].Text = "";
                    gvr.Cells[20].Text = "";

                    chkChild.Checked = false;

                    ChkHeader();
                }
            }
            else if (Grd_Charge.SelectedRow.Cells[17].Text == "Y")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('Selected Charge was Revised already');", true);
                ClearCharge();
            }



        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_USDRate.Text != "")
            {
                GridViewRow gvr = Grd_Charge.SelectedRow;
                double percentage = Convert.ToDouble(hid_GSTpercentage.Value);
                if (Convert.ToDouble(txt_rate.Text) - Convert.ToDouble(txt_USDRate.Text) == 0)
                {
                    gvr.Cells[9].Text = Convert.ToDouble(gvr.Cells[5].Text).ToString("#,##0.00");
                    gvr.Cells[10].Text = Convert.ToDouble(gvr.Cells[6].Text).ToString("#,##0.00");
                    gvr.Cells[11].Text = Convert.ToDouble(gvr.Cells[7].Text).ToString("#,##0.00");
                }
                gvr.Cells[8].Text = Convert.ToDouble(txt_USDRate.Text).ToString("#,##0.00");
                gvr.Cells[9].Text = Convert.ToDouble(txt_reversal.Text).ToString("#,##0.00");
                if (Convert.ToDouble(gvr.Cells[6].Text) > 0.00)
                {
                    gvr.Cells[10].Text = ((Convert.ToDouble(gvr.Cells[9].Text) * percentage) / 100.00).ToString("#,##0.00");
                }
                else
                {
                    gvr.Cells[10].Text = "0.00";
                }
                //gvr.Cells[10].Text = ((Convert.ToDouble(gvr.Cells[9].Text) * percentage) / 100.00).ToString("#,##0.00");
                gvr.Cells[11].Text = (Convert.ToDouble(gvr.Cells[9].Text) + Convert.ToDouble(gvr.Cells[10].Text)).ToString("#,##0.00");
                gvr.Cells[12].Text = Convert.ToDouble(txt_Diff.Text).ToString("#,##0.00");
                if (Convert.ToDouble(gvr.Cells[6].Text) > 0.00)
                {
                    gvr.Cells[13].Text = (((Convert.ToDouble(gvr.Cells[12].Text)) * percentage) / 100.00).ToString("#,##0.00");
                }
                else
                {
                    gvr.Cells[13].Text = "0.00";
                }
                //gvr.Cells[13].Text = (((Convert.ToDouble(gvr.Cells[12].Text)) * percentage) / 100.00).ToString("#,##0.00");
                gvr.Cells[14].Text = (Convert.ToDouble(gvr.Cells[12].Text) + Convert.ToDouble(gvr.Cells[13].Text)).ToString("#,##0.00");
                gvr.Cells[17].Text = "N";
                gvr.Cells[18].Text = txt_Unit.Text;
                gvr.Cells[19].Text = Convert.ToDouble(txt_DiffRevRate.Text).ToString("#,##0.00");
                gvr.Cells[20].Text = Convert.ToDouble(txt_DiffFcamt.Text).ToString("#,##0.00");
                CheckBox chkChild = (CheckBox)Grd_Charge.SelectedRow.FindControl("chkChild");
                chkChild.Checked = true;
                ClearCharge();
                Fn_CalculateTotal();
                btn_reverse.Enabled = true;
                ChkHeader();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('Please Enter the Reversal Rate');", true);
                txt_USDRate.Focus();
            }
        }

        protected void txt_reversal_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txt_amount.Text) >= Convert.ToDouble(txt_reversal.Text))
            {
                txt_Diff.Text = ((Convert.ToDouble(txt_amount.Text.Replace(",", ""))) - (Convert.ToDouble(txt_reversal.Text))).ToString("#,##0.00");
                txt_DiffRevRate.Text = (Convert.ToDouble(txt_rate.Text) - Convert.ToDouble(txt_USDRate.Text)).ToString("#,##0.00");
                if (Hid_voutype.Value != "S" && Hid_voutype.Value != "X")
                {
                    if (txt_Unit.Text == "0" || txt_Unit.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('Selected Charge is not Valid.');", true);
                        ClearCharge();
                    }
                    else
                    {
                        txt_DiffFcamt.Text = (Convert.ToDouble(txt_Unit.Text) * Convert.ToDouble(txt_DiffRevRate.Text)).ToString("#,##0.00");
                    }
                }
                else
                {
                    if (Convert.ToInt32(Grd_Charge.SelectedRow.Cells[16].Text) != 3063 || Convert.ToInt32(Grd_Charge.SelectedRow.Cells[16].Text) != 4537)
                    {
                        txt_DiffFcamt.Text = (Convert.ToDouble(txt_Unit.Text) * Convert.ToDouble(txt_DiffRevRate.Text)).ToString("#,##0.00");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('ROUND UP/ROUND OFF charge can't be Revised');", true);
                        ClearCharge();
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('Please Enter a Valid Reversal Amount');", true);
                txt_reversal.Text = "";
                txt_reversal.Focus();
            }

        }

        public void ClearCharge()
        {
            txt_charge.Text = "";
            txt_curr.Text = "";
            txt_rate.Text = "";
            txt_exrate.Text = "";
            txt_base.Text = "";
            txt_amount.Text = "";
            txt_GST.Text = "";
            txt_NET.Text = "";
            txt_reversal.Text = "";
            txt_Diff.Text = "";
            txt_USDRate.Text = "";
            txt_Unit.Text = "";
            txt_DiffRevRate.Text = "";
            txt_DiffFcamt.Text = "";
        }

        protected void txt_USDRate_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txt_rate.Text) >= Convert.ToDouble(txt_USDRate.Text))
            {
                if (txt_base.Text != "" && txt_charge.Text != "" && txt_curr.Text != "" && txt_rate.Text != "" && txt_exrate.Text != "")
                {
                    string strbase = txt_base.Text;
                    famount = CheckBase(strbase, Convert.ToDouble(txt_USDRate.Text), Convert.ToDouble(txt_exrate.Text));
                    txt_reversal.Text = famount.ToString();
                    txt_reversal.Text = Convert.ToDecimal(txt_reversal.Text).ToString("#,##0.00");
                }
                txt_reversal_TextChanged(sender, e);
                hid_fcamount.Value = (Convert.ToDecimal(txt_reversal.Text) / Convert.ToDecimal(txt_exrate.Text)).ToString("0.00");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('Please Enter a Valid Reversal Rate');", true);
                txt_USDRate.Text = "";
                txt_USDRate.Focus();
                return;
            }
        }




        public double CheckBase(string strbase, double rate, double exrate)
        {

            divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            branchid = Convert.ToInt32(Session["LoginBranchid"]);
            if (txt_base.Text.ToUpper() == "BL".ToUpper() || txt_base.Text.ToUpper() == "HWBL".ToUpper() || txt_base.Text.ToUpper() == "DOC".ToUpper() || txt_base.Text.ToUpper() == "HAWB".ToUpper())
            {
                amount = rate * exrate;
                hdnUnit.Value = "1";
            }
            //---------------------------------------------------------------

            else if (txt_base.Text.ToUpper() == "CBM".ToUpper() || txt_base.Text.ToUpper() == "MT".ToUpper())
            {
                if (txt_base.Text.ToUpper() == "CBM".ToUpper())
                {
                    if (hid_trantype.Value == "FE")
                    {
                        if (hid_Chk_Mbl.Value != "M")
                        {
                            if (hid_type.Value == "InvoiceWoJ")
                            {
                                strvolume = INVOICEobj.GetVolume(hid_blno.Value.ToUpper().ToUpper(), "Wo", branchid);
                                amount = rate * exrate * strvolume;
                            }
                            else
                            {
                                strvolume = INVOICEobj.GetVolume(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid);
                                amount = rate * exrate * strvolume;
                                doublevolume = strvolume;
                                hdnUnit.Value = doublevolume.ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "H");
                            }
                        }
                        else
                        {
                            strvolume = INVOICEobj.GetSumofVolume(hid_job.Value, hid_trantype.Value, branchid);
                            amount = rate * exrate * strvolume;
                            doublevolume = strvolume;
                            hdnUnit.Value = doublevolume.ToString();
                            fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "M");
                        }
                    }

                    //--------------------------------------------------------------------------
                    else
                    {
                        if (hid_Chk_Mbl.Value != "M")
                        {
                            strvolume = INVOICEobj.GetVolume(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid);
                            if (strvolume < 1)
                            {
                                amount = rate * exrate * 1;
                                doublevolume = 1;
                                hdnUnit.Value = doublevolume.ToString();
                            }
                            else
                            {
                                amount = rate * exrate * strvolume;
                                doublevolume = strvolume;
                                hdnUnit.Value = doublevolume.ToString();
                            }
                            fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "H");
                        }
                        else
                        {
                            strvolume = INVOICEobj.GetSumofVolume(hid_job.Value, hid_trantype.Value, branchid);
                            if (strvolume < 1)
                            {
                                amount = rate * exrate * 1;
                                doublevolume = strvolume;
                                hdnUnit.Value = "1";
                            }
                            else
                            {
                                amount = rate * exrate * strvolume;
                                doublevolume = strvolume;
                                hdnUnit.Value = doublevolume.ToString();
                            }
                            fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "M");
                        }
                    }
                }
                //--------------------------------------------------------------------------

                else
                {
                    if (txt_base.Text.ToUpper() == "MT".ToUpper())
                    {
                        if (hid_trantype.Value == "FE")
                        {
                            if (hid_Chk_Mbl.Value != "M")
                            {
                                if (hid_type.Value == "InvoiceWoJ")
                                {
                                    strntweight = INVOICEobj.GetWeight(hid_blno.Value.ToUpper().ToUpper(), "Wo", branchid);
                                    amount = rate * exrate * (strntweight / 1000);
                                }
                                else
                                {
                                    strntweight = INVOICEobj.GetWeight(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid);
                                    amount = rate * exrate * (strntweight / 1000);
                                    doublevolume = strntweight;
                                    hdnUnit.Value = (strntweight / 1000).ToString();
                                    fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "H");
                                }

                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeight(hid_job.Value, hid_trantype.Value, branchid);
                                amount = rate * exrate * (strntweight / 1000);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight / 1000).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "M");
                            }
                        }

                        else
                        {
                            if (hid_Chk_Mbl.Value != "M")
                            {
                                strntweight = INVOICEobj.GetWeight(hid_blno.Value, hid_trantype.Value, branchid);
                                amount = rate * exrate * (strntweight / 1000);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight / 1000).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value, hid_trantype.Value, branchid, "H");
                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeight(hid_job.Value, hid_trantype.Value, branchid);
                                amount = rate * exrate * (strntweight / 1000);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight / 1000).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value, hid_trantype.Value, branchid, "M");
                            }

                        }
                    }
                }
            }

            else if (txt_base.Text.ToUpper() == "COTTON/PALLET".ToUpper())
            {
                string doublevolume1;
                if (hid_trantype.Value == "AE" || hid_trantype.Value == "AI")
                {
                    if (hid_Chk_Mbl.Value == "M")
                    {

                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        doublevolume1 = INVOICEobj.Getchargepallet(hid_blno.Value, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(doublevolume1);
                        hdnUnit.Value = doublevolume1.ToString();
                        //   unit = strchgweight.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper(), strTranType, branchid, "M");
                    }
                    else
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        doublevolume1 = INVOICEobj.Getchargepallet(hid_blno.Value, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(doublevolume1);
                        hdnUnit.Value = doublevolume1.ToString();
                        //   unit = strchgweight.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper(), strTranType, branchid, "H");
                    }

                }
            }


            else if (txt_base.Text.ToUpper() == "PERTRUCK".ToUpper())
            {
                string doublevolume1;
                if (hid_trantype.Value == "AE" || hid_trantype.Value == "AI")
                {
                    if (hid_Chk_Mbl.Value == "M")
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        doublevolume1 = INVOICEobj.Getchargetruck(hid_blno.Value, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(doublevolume1);
                        hdnUnit.Value = doublevolume1.ToString();
                        //   unit = strchgweight.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), strTranType, branchid, "M");
                    }
                    else
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        doublevolume1 = INVOICEobj.Getchargetruck(hid_blno.Value, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(doublevolume1);
                        hdnUnit.Value = doublevolume1.ToString();
                        //   unit = strchgweight.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), strTranType, branchid, "H");
                    }
                }
            }
            else if (txt_base.Text.ToUpper() == "Kgs".ToUpper() || txt_base.Text.ToUpper() == "PER KG".ToUpper())
            {
                if (hid_trantype.Value == "AE" || hid_trantype.Value == "AI")
                {
                    if (hid_Chk_Mbl.Value == "M")
                    {
                        strchgweight = INVOICEobj.GetSumofChargeWght(Convert.ToInt32(hid_job.Value), hid_trantype.Value, branchid);
                        amount = rate * exrate * strchgweight;
                        doublevolume = strchgweight;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "M");
                    }
                    else
                    {
                        strchgweight = INVOICEobj.GetChargeWeight(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid);
                        amount = rate * exrate * strchgweight;
                        doublevolume = strchgweight;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "H");
                    }
                }
                else
                {
                    strgrosswght = INVOICEobj.GetGrossWeight(hid_blno.Value.ToUpper().ToUpper(), branchid);
                    amount = rate * exrate * strgrosswght;
                    hdnUnit.Value = strgrosswght.ToString();
                }
            }
            else if (txt_base.Text.ToUpper() == "SB".ToUpper())
            {
                if (hid_trantype.Value == "FE")
                {
                    if (hid_Chk_Mbl.Value == "M")
                    {
                        if (hid_job.Value != "")
                        {
                            sizecount = INVOICEobj.GetSBillCount(hid_blno.Value.ToUpper().ToUpper(), Convert.ToInt32(hid_job.Value), "MBL", branchid);
                            amount = rate * exrate * sizecount;
                            doublevolume = sizecount;
                            hdnUnit.Value = doublevolume.ToString();
                            fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "M");
                        }
                    }
                    else
                    {
                        if (hid_job.Value != "")
                        {
                            sizecount = INVOICEobj.GetSBillCount(hid_blno.Value.ToUpper().ToUpper(), Convert.ToInt32(hid_job.Value), "BL", branchid);
                            amount = rate * exrate * sizecount;
                            doublevolume = sizecount;
                            hdnUnit.Value = doublevolume.ToString();
                            fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper().ToUpper(), hid_trantype.Value, branchid, "H");
                        }
                    }
                }
            }
            else if (txt_base.Text.ToUpper() == "Volume".ToUpper())
            {
                strgrosswght = INVOICEobj.GetVolumeQty(hid_blno.Value.ToUpper().ToUpper(), branchid);
                amount = rate * exrate * strgrosswght;
                hdnUnit.Value = strgrosswght.ToString();
            }
            else
            {
                string chargebase;
                chargebase = txt_base.Text;
                if (hid_Chk_Mbl.Value != "M")
                {
                    if (hid_trantype.Value == "FE")
                    {
                        sizecount = INVOICEobj.GetBaseCount(hid_blno.Value.ToUpper(), chargebase, hid_trantype.Value, "BL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper(), hid_trantype.Value, branchid, "H");
                    }
                    else
                    {
                        sizecount = INVOICEobj.GetBaseCount(hid_blno.Value.ToUpper(), chargebase, hid_trantype.Value, "BL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper(), hid_trantype.Value, branchid, "H");
                    }
                }
                else
                {
                    sizecount = INVOICEobj.GetBaseCount(hid_job.Value, chargebase, hid_trantype.Value, "MBL", branchid);
                    amount = rate * exrate * sizecount;
                    doublevolume = sizecount;
                    hdnUnit.Value = doublevolume.ToString();
                    fd = DCAdviseObj.GetFDFromBLNO(hid_blno.Value.ToUpper(), hid_trantype.Value, branchid, "M");
                }
            }
            return amount;
        }

        protected void chkHeader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");

            foreach (GridViewRow row in Grd_Charge.Rows)
            {

                CheckBox chkChild = (CheckBox)row.FindControl("chkChild");

                if (chkHeader.Checked == true)
                {
                    chkChild.Checked = true;
                }
                else
                {
                    chkChild.Checked = false;
                }

            }

            chkChild_CheckedChanged(sender, e);
        }

        protected void chkChild_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");
            ClearCharge();
            for (int i = 0; i < Grd_Charge.Rows.Count; i++)
            {
                CheckBox chkChild = (CheckBox)Grd_Charge.Rows[i].FindControl("chkChild");
                if (chkChild.Checked == true)
                {
                    if (Grd_Charge.Rows[i].Cells[8].Text == "" && Grd_Charge.Rows[i].Cells[9].Text == "")
                    {
                        if (Hid_voutype.Value != "S" && Hid_voutype.Value != "X")
                        {
                            if (Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 3063 && Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 4537)
                            {
                                Grd_Charge.Rows[i].Cells[8].Text = Grd_Charge.Rows[i].Cells[2].Text;
                                Grd_Charge.Rows[i].Cells[9].Text = Grd_Charge.Rows[i].Cells[5].Text;
                                Grd_Charge.Rows[i].Cells[10].Text = Grd_Charge.Rows[i].Cells[6].Text;
                                Grd_Charge.Rows[i].Cells[11].Text = Grd_Charge.Rows[i].Cells[7].Text;
                                Grd_Charge.Rows[i].Cells[12].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[5].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[13].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[6].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[10].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[14].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[7].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[11].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[17].Text = "N";
                                Grd_Charge.Rows[i].Cells[18].Text = Grd_Charge.Rows[i].Cells[21].Text;
                                Grd_Charge.Rows[i].Cells[19].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[2].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[8].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[20].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[21].Text) * Convert.ToDouble(Grd_Charge.Rows[i].Cells[19].Text)).ToString();
                                hid_fcamount.Value = "0.00";
                                Fn_CalculateTotal();
                            }
                            else if ((Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 3063 || Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 4537) && chkHeader.Checked == true)
                            {
                                Grd_Charge.Rows[i].Cells[8].Text = Grd_Charge.Rows[i].Cells[2].Text;
                                Grd_Charge.Rows[i].Cells[9].Text = Grd_Charge.Rows[i].Cells[5].Text;
                                Grd_Charge.Rows[i].Cells[10].Text = Grd_Charge.Rows[i].Cells[6].Text;
                                Grd_Charge.Rows[i].Cells[11].Text = Grd_Charge.Rows[i].Cells[7].Text;
                                Grd_Charge.Rows[i].Cells[12].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[5].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[13].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[6].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[10].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[14].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[7].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[11].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[17].Text = "N";
                                Grd_Charge.Rows[i].Cells[18].Text = Grd_Charge.Rows[i].Cells[21].Text;
                                Grd_Charge.Rows[i].Cells[19].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[2].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[8].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[20].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[21].Text) * Convert.ToDouble(Grd_Charge.Rows[i].Cells[19].Text)).ToString();
                                hid_fcamount.Value = "0.00";
                                Fn_CalculateTotal();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('ROUND UP and ROUND OFF charge can not be Revised');", true);
                                ClearCharge();
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 3063 && Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 4537)
                            {
                                Grd_Charge.Rows[i].Cells[8].Text = Grd_Charge.Rows[i].Cells[2].Text;
                                Grd_Charge.Rows[i].Cells[9].Text = Grd_Charge.Rows[i].Cells[5].Text;
                                Grd_Charge.Rows[i].Cells[10].Text = Grd_Charge.Rows[i].Cells[6].Text;
                                Grd_Charge.Rows[i].Cells[11].Text = Grd_Charge.Rows[i].Cells[7].Text;
                                Grd_Charge.Rows[i].Cells[12].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[5].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[13].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[6].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[10].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[14].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[7].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[11].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[17].Text = "N";
                                Grd_Charge.Rows[i].Cells[18].Text = Grd_Charge.Rows[i].Cells[21].Text;
                                Grd_Charge.Rows[i].Cells[19].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[2].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[8].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[20].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[21].Text) * Convert.ToDouble(Grd_Charge.Rows[i].Cells[19].Text)).ToString();
                                hid_fcamount.Value = "0.00";
                                Fn_CalculateTotal();
                            }
                            else if ((Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 3063 || Convert.ToInt32(Grd_Charge.Rows[i].Cells[16].Text) != 4537) && chkHeader.Checked == true)
                            {
                                Grd_Charge.Rows[i].Cells[8].Text = Grd_Charge.Rows[i].Cells[2].Text;
                                Grd_Charge.Rows[i].Cells[9].Text = Grd_Charge.Rows[i].Cells[5].Text;
                                Grd_Charge.Rows[i].Cells[10].Text = Grd_Charge.Rows[i].Cells[6].Text;
                                Grd_Charge.Rows[i].Cells[11].Text = Grd_Charge.Rows[i].Cells[7].Text;
                                Grd_Charge.Rows[i].Cells[12].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[5].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[9].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[13].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[6].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[10].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[14].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[7].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[11].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[17].Text = "N";
                                Grd_Charge.Rows[i].Cells[18].Text = Grd_Charge.Rows[i].Cells[21].Text;
                                Grd_Charge.Rows[i].Cells[19].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[2].Text) - Convert.ToDouble(Grd_Charge.Rows[i].Cells[8].Text)).ToString();
                                Grd_Charge.Rows[i].Cells[20].Text = (Convert.ToDouble(Grd_Charge.Rows[i].Cells[21].Text) * Convert.ToDouble(Grd_Charge.Rows[i].Cells[19].Text)).ToString();
                                hid_fcamount.Value = "0.00";
                                Fn_CalculateTotal();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Button), "Reversal", "alertify.alert('ROUND UP and ROUND OFF charge can not be Revised');", true);
                                ClearCharge();
                            }
                        }
                    }
                }
                else if (chkChild.Checked == false)
                {

                    if (Grd_Charge.Rows[i].Cells[8].Text != "" && Grd_Charge.Rows[i].Cells[9].Text != "" && Grd_Charge.Rows[i].Cells[17].Text == "N")
                    {
                        Grd_Charge.Rows[i].Cells[8].Text = "";
                        Grd_Charge.Rows[i].Cells[9].Text = "";
                        Grd_Charge.Rows[i].Cells[10].Text = "";
                        Grd_Charge.Rows[i].Cells[11].Text = "";
                        Grd_Charge.Rows[i].Cells[12].Text = "";
                        Grd_Charge.Rows[i].Cells[13].Text = "";
                        Grd_Charge.Rows[i].Cells[14].Text = "";
                        Grd_Charge.Rows[i].Cells[17].Text = "";
                        Grd_Charge.Rows[i].Cells[18].Text = "";
                        Grd_Charge.Rows[i].Cells[19].Text = "";
                        Grd_Charge.Rows[i].Cells[20].Text = "";
                        Fn_CalculateTotal();
                    }
                }
            }

            ChkHeader();

        }

        private void ChkHeader()
        {
            CheckBox chkHeader = (CheckBox)Grd_Charge.HeaderRow.FindControl("chkHeader");
            int ChkdCount = 0;
            for (int i = 0; i < Grd_Charge.Rows.Count; i++)
            {
                CheckBox chkChild = (CheckBox)Grd_Charge.Rows[i].FindControl("chkChild");
                if (chkChild.Checked == true)
                {
                    ChkdCount = ChkdCount + 1;
                }
            }

            if (Grd_Charge.Rows.Count == ChkdCount)
            {
                chkHeader.Checked = true;
            }
            else
            {
                chkHeader.Checked = false;
            }

            if (ChkdCount > 0)
            {
                btn_reverse.Visible = true;
                btn_reverse.Enabled = true;
            }
            else
            {
                btn_reverse.Visible = false;
                btn_reverse.Enabled = false;
            }
        }

        // Oversease DN/CN Reversal To Costing

        private void Fn_CostTemp4OSDCN(int Jobno, int vouno, char voutype)
        {
            try
            {
                trantype = hid_trantype.Value;
                double MBL_Amount = 0, MBL_credit = 0, MBL_debit = 0, MBL_Expense = 0, BL_Amount = 0, BL_Expense = 0, BL_debit = 0, BL_credit = 0, Total_CBM = 0, Total_Tues = 0, JobChargeWT = 0, BL_CBM = 0, BL_Tues = 0, BL_ChargeWT = 0;
                int JobType = 0, MLO = 0, int_Cont20 = 0, int_Cont40 = 0;
              //  DataAccess.CostingTemp obj_da_Cost = new DataAccess.CostingTemp();
                //obj_da_Cost.DelCostingDetailsRpt(Jobno, trantype, "V", int_bid, 0, "");
                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                Str_CurrrentDate = obj_da_Log.GetDate().ToShortDateString();
                if (int_bid == 0 || int_bid == null)
                {
                    int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                }
                obj_dt = obj_da_Cost.GetClosedJobDts(Jobno, trantype, int_bid);
                for (int i = 0; i <= obj_dt.Rows.Count - 1; i++)
                {
                    //MBL_Expense = obj_da_Cost.GetcostPA(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid);
                    if (voutype == 'C')
                    {
                        MBL_credit = obj_da_Cost.GetCreditDebitReversal(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Credit", vouno);
                        MBL_debit = 0;
                    }
                    else if (voutype =='D' )
                    {
                        MBL_credit = 0;
                        MBL_debit = obj_da_Cost.GetCreditDebitReversal(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid, "Debit", vouno);
                    }
                    //MBL_Amount = obj_da_Cost.GetcostInv(obj_dt.Rows[i].ItemArray[1].ToString(), trantype, int_bid);
                    Close_date = obj_da_Log.GetDate();// DateTime.Parse((obj_dt.Rows[i]["jobclosedate"].ToString()));
                    if (trantype == "FE" || trantype == "FI")
                    {
                        JobType = Convert.ToInt32(obj_dt.Rows[i]["jobtype"].ToString());
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["mlo"].ToString());

                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);

                        if (obj_dttemp.Rows.Count > 0)
                        {
                            if (obj_dttemp.Rows[0]["cbmtotal"].ToString().Trim().Length > 0 && obj_dttemp.Rows[0]["Tuestotal"].ToString().Trim().Length > 0)
                            {
                                Total_CBM = Convert.ToDouble(obj_dttemp.Rows[0]["cbmtotal"].ToString());
                                Total_Tues = Convert.ToDouble(obj_dttemp.Rows[0]["Tuestotal"].ToString());
                            }
                        }
                    }
                    else if (trantype == "AE" || trantype == "AI")
                    {
                        JobType = 0;
                        MLO = Convert.ToInt32(obj_dt.Rows[i]["airline"].ToString());

                        obj_dttemp = obj_da_Cost.GetCBMTues(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);

                        if (obj_dttemp.Rows.Count > 0)
                        {
                            if (obj_dttemp.Rows[0][0].ToString().Trim().Length > 0)
                            {
                                JobChargeWT = Convert.ToDouble(obj_dttemp.Rows[0][0].ToString());
                            }
                        }
                    }

                    obj_dttemp = obj_da_Cost.GetBLRow(Convert.ToInt32(obj_dt.Rows[i]["jobno"].ToString()), trantype, int_bid);
                    for (int j = 0; j <= obj_dttemp.Rows.Count - 1; j++)
                    {
                        BL_Amount = 0;
                        BL_Expense = 0;

                        BL_debit = 0;
                        BL_credit = 0;
                        //BL_Expense = obj_da_Cost.GetcostPA(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid);
                        if(voutype == 'C')
                        {
                            BL_credit = obj_da_Cost.GetCreditDebitReversal(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid, "Credit", vouno);
                            BL_debit = 0;
                        }
                        else if (voutype == 'D')
                        {
                            BL_credit = 0;
                            BL_debit = obj_da_Cost.GetCreditDebitReversal(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid, "Debit", vouno);
                        }
                        //BL_Amount = obj_da_Cost.GetcostInv(obj_dttemp.Rows[j].ItemArray[1].ToString(), trantype, int_bid);
                        if (trantype == "FE" || trantype == "FI")
                        {
                            BL_Tues = Convert.ToInt32(obj_dttemp.Rows[j]["cont20"].ToString()) + (Convert.ToInt32(obj_dttemp.Rows[j]["cont40"].ToString()) * 2);
                            BL_CBM = Convert.ToDouble(obj_dttemp.Rows[j]["cbm"].ToString());
                            if (MBL_Amount != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_Amount = BL_Amount + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_Amount = BL_Amount + 0;
                                    }
                                    else
                                    {
                                        BL_Amount = BL_Amount + ((MBL_Amount / Total_CBM) * BL_CBM);
                                    }
                                }
                            }
                            if (MBL_debit != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_debit = BL_debit + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_debit = BL_debit + 0;
                                    }
                                    else
                                    {
                                        BL_debit = BL_debit + ((MBL_debit / Total_CBM) * BL_CBM);
                                    }
                                }
                            }
                            if (MBL_credit != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_credit = BL_credit + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_credit = BL_credit + 0;
                                    }
                                    else
                                    {
                                        BL_credit = BL_credit + ((MBL_credit / Total_CBM) * BL_CBM);
                                    }
                                }
                            }

                            if (MBL_Expense != 0)
                            {
                                if (JobType == 3)
                                {
                                    if (BL_Tues == 0)
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / 1) * 1);
                                    }
                                    else if (Total_Tues == 0)
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / 1) * 1);
                                    }
                                    else
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / Total_Tues) * BL_Tues);
                                    }
                                }
                                else
                                {
                                    if (BL_CBM == 0)
                                    {
                                        BL_Expense = BL_Expense + 0;
                                    }
                                    else if (Total_CBM == 0)
                                    {
                                        BL_Expense = BL_Expense + 0;
                                    }
                                    else
                                    {
                                        BL_Expense = BL_Expense + ((MBL_Expense / Total_CBM) * BL_CBM);
                                    }
                                }
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            BL_ChargeWT = Convert.ToDouble(obj_dttemp.Rows[j]["chargewt"].ToString());

                            if (MBL_Amount != 0)
                            {
                                BL_Amount = BL_Amount + ((MBL_Amount / JobChargeWT) * BL_ChargeWT);
                            }
                            if (MBL_debit != 0)
                            {
                                BL_debit = BL_debit + ((MBL_debit / JobChargeWT) * BL_ChargeWT);
                            }
                            if (MBL_credit != 0)
                            {
                                BL_credit = BL_credit + ((MBL_credit / JobChargeWT) * BL_ChargeWT);
                            }
                            if (MBL_Expense != 0)
                            {
                                BL_Expense = BL_Expense + ((MBL_Expense / JobChargeWT) * BL_ChargeWT);
                            }
                        }

                        if (trantype == "FE" || trantype == "FI")
                        {
                            if (obj_dttemp.Rows[j][2].ToString().Length > 0 && obj_dttemp.Rows[j][3].ToString().Length > 0)
                            {
                                int_Cont20 = Convert.ToInt32(obj_dttemp.Rows[j][2].ToString());
                                int_Cont40 = Convert.ToInt32(obj_dttemp.Rows[j][3].ToString());
                            }
                        }
                        else if (trantype == "AE" || trantype == "AI")
                        {
                            int_Cont20 = 0;
                            int_Cont40 = 0;
                        }
                        int int_job = 0, int_shipper = 0, int_consignee = 0, int_notify = 0, int_agent = 0, int_pol = 0, int_pod = 0, int_sales = 0;
                        char Nomination;
                        string blno;
                        double volume = 0;
                        int_job = Convert.ToInt32(obj_dttemp.Rows[j][0].ToString());
                        blno = obj_dttemp.Rows[j][1].ToString();
                        int_shipper = Convert.ToInt32(obj_dttemp.Rows[j][6].ToString());
                        int_consignee = Convert.ToInt32(obj_dttemp.Rows[j][7].ToString());
                        int_notify = Convert.ToInt32(obj_dttemp.Rows[j][8].ToString());
                        int_agent = Convert.ToInt32(obj_dttemp.Rows[j][9].ToString());
                        int_pol = Convert.ToInt32(obj_dttemp.Rows[j][10].ToString());
                        int_pod = Convert.ToInt32(obj_dttemp.Rows[j][11].ToString());
                        int_sales = obj_da_Cost.GetSalesPerson(blno, trantype, int_bid);
                        Nomination = char.Parse(obj_dttemp.Rows[j][4].ToString());
                        volume = 0;// Convert.ToDouble(obj_dttemp.Rows[j][5].ToString());
                        BL_Amount = BL_Amount + BL_debit;
                        BL_Expense = BL_Expense + BL_credit;

                        //if (DBNull.Value.Equals(BL_Amount) == true)
                        //{ 

                        //}
                        obj_da_Cost.InsCostingTempRptnew(Convert.ToInt32(Session["LoginEmpId"].ToString()), int_job, trantype, int_bid, blno, volume, int_Cont20, int_Cont40, BL_Amount, BL_Expense, Nomination, int_sales, int_shipper, int_consignee, int_notify, int_agent, int_pol, int_pod, JobType, Close_date, MLO, vouno, voutype);

                    }
                }
                //Fn_DNCNBL(Jobno, "Closed", Close_date, 0, " ");
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            this.ModalPopupExtenderlog.Show();
            DateTime dt_logDate = new DateTime();
            DateTime Fbegin, Fend;
            string[] FAYEAR;

            FAYEAR = Session["LYEAR"].ToString().Split('-');
            Fbegin = Convert.ToDateTime("04/01/20" + FAYEAR[0]);
            Fend = Convert.ToDateTime("03/31/20" + FAYEAR[1]);
            txtvouyear = Convert.ToInt32(Fbegin.Year.ToString());
            hid_txtyear.Value = txtvouyear.ToString();


            dt_logDate = Convert.ToDateTime(Utility.fn_ConvertDate(hid_Vouyear.Value));

            if (dt_logDate.Month == obj_da_Log.GetDate().Month && dt_logDate.Year == obj_da_Log.GetDate().Year)
            {
                txtdate.Text = obj_da_Log.GetDate().ToString("dd/MM/yyyy");
            }
            else
            {
                if (dt_logDate.Month == 12)
                {
                    dt_logDate = new DateTime(dt_logDate.Year, (dt_logDate.Month), 31);//.AddDays(-1)
                    txtdate.Text = Utility.fn_ConvertDate(dt_logDate.ToString());
                }
                else
                {
                    dt_logDate = new DateTime(dt_logDate.Year, (dt_logDate.Month + 1), 1).AddDays(-1);
                    txtdate.Text = Utility.fn_ConvertDate(dt_logDate.ToString());
                }

            }

            if (dt_logDate.Month < 4 && dt_logDate.Year <= Convert.ToInt32(Session["LogYear"].ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Invalid Finanical Year')", true);
                txtdate.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
            }

        }

        protected void txtjnlno_TextChanged(object sender, EventArgs e)
        {
            if (txtjnlno.Text != "")
            {
                getjourvalue();
            }
        }

        public void getjourvalue()
        {
            this.ModalPopupExtenderlog.Show();
            recedit = false;
            //txtmont.Value = Convert.ToInt32(txtdate.Month).ToString();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            DataTable dts = new DataTable();

            if (txtmont.Value == "")
            {
                txtmont.Value = "0";
            }

            voutypeid = Jnlobj.Selvoutypeid("Journal", Session["FADbname"].ToString());
            Vou_ID = Obj_Voucher.GetVouIdJou(Convert.ToInt32(txtjnlno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), voutypeid, Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month);
            hid_VouID.Value = Vou_ID.ToString();

            if (txtjnlno.Text != "")
            {
                DataTable Dt = new DataTable();
                DataTable Dt2 = new DataTable();
                Dt = Jnlobj.SelFAvoucherHead(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_txtyear.Value), Convert.ToInt32(txtjnlno.Text), voutypeid, Session["FADbname"].ToString(), (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text))).Month);

                if (Dt.Rows.Count > 0)
                {
                    string RevCheck = Dt.Rows[0][1].ToString();
                    if (RevCheck.Contains("/Reversal of JV #-"))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(TextBox), "Reversal", "alertify.alert('Revised Journals are not allowed');", true);
                        txtjnlno.Text = "";
                        txtjnlno.Focus();
                        //GetTextDate();
                        ClearJVRevDetails();

                        return;
                    }
                    int journal = obj_da_Reversal.CheckJournalRevised(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_txtyear.Value), Convert.ToInt32(txtjnlno.Text), Session["FADbname"].ToString(), (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text))).Month, (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text))).Year);
                    if (journal == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(TextBox), "Reversal", "alertify.alert(' Journal already Revised');", true);
                        txtjnlno.Text = "";
                        txtjnlno.Focus();
                        ClearJVRevDetails();
                        return;
                    }
                    recedit = true;
                    txtnarration.Text = Dt.Rows[0]["narration"].ToString();
                    vouid = Convert.ToInt32(Dt.Rows[0]["vouid"]);
                    Session["vouid"] = vouid;
                    txtjobno.Text = Dt.Rows[0]["JobNo"].ToString();
                    txtref.Text = Dt.Rows[0]["RefNo"].ToString();

                    DateTime journaldate = new DateTime();
                    journaldate = Convert.ToDateTime(Dt.Rows[0]["voudate"].ToString());
                    txtdate.Text = Utility.fn_ConvertDate(journaldate.ToString());

                    //lbl_name.Text = Dt.Rows[0]["empname"].ToString();
                    Dt2 = Jnlobj.SelFAvoucherDetails(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_txtyear.Value), Convert.ToInt32(txtjnlno.Text), voutypeid, Session["FADbname"].ToString(), Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)).Month);
                }

                if (Dt2.Rows.Count > 0)
                {
                    dts.Columns.Add("ledgertype");
                    dts.Columns.Add("ledgername");
                    dts.Columns.Add("Debit");
                    dts.Columns.Add("Credit");
                    dts.Columns.Add("vousubid");
                    dts.Columns.Add("opstype");
                    dts.Columns.Add("ledgerid");

                    for (int i = 0; i <= Dt2.Rows.Count - 1; i++)
                    {
                        Type = Dt2.Rows[i]["ledgertype"].ToString();
                        if (Type == "Dr")
                        {
                            row = dts.NewRow();
                            dts.Rows.Add();
                            dts.Rows[i]["ledgertype"] = Dt2.Rows[i]["ledgertype"].ToString();
                            dts.Rows[i]["ledgername"] = Dt2.Rows[i]["ledgername"].ToString();
                            dts.Rows[i]["Debit"] = Convert.ToDouble(Dt2.Rows[i]["ledgeramount"]).ToString();
                            dts.Rows[i]["vousubid"] = Dt2.Rows[i]["vousubid"].ToString();
                            dts.Rows[i]["opstype"] = Dt2.Rows[i]["opstype"].ToString();
                            dts.Rows[i]["ledgerid"] = Dt2.Rows[i]["ledgerid"].ToString();
                            grd_journal.DataSource = dts;
                            grd_journal.DataBind();
                        }
                    }

                    for (int i = 0; i <= Dt2.Rows.Count - 1; i++)
                    {
                        Type = Dt2.Rows[i]["ledgertype"].ToString();

                        if (Type == "Cr")
                        {
                            row = dts.NewRow();
                            dts.Rows.Add();
                            dts.Rows[i]["ledgertype"] = Dt2.Rows[i]["ledgertype"];
                            dts.Rows[i]["ledgername"] = Dt2.Rows[i]["ledgername"];
                            dts.Rows[i]["Credit"] = Convert.ToDouble(Dt2.Rows[i]["ledgeramount"]);
                            dts.Rows[i]["vousubid"] = Dt2.Rows[i]["vousubid"].ToString();
                            dts.Rows[i]["opstype"] = Dt2.Rows[i]["opstype"].ToString();
                            dts.Rows[i]["ledgerid"] = Dt2.Rows[i]["ledgerid"].ToString();
                            grd_journal.DataSource = dts;
                            grd_journal.DataBind();
                        }
                    }
                }

                if (dts.Rows.Count > 0)
                {
                    totdbAmnt = 0;
                    totcramnt = 0;
                    for (int i = 0; i <= dts.Rows.Count - 1; i++)
                    {
                        if (dts.Rows[i]["Debit"].ToString() != "")
                        {
                            totdbAmnt = totdbAmnt + Convert.ToDouble(dts.Rows[i]["Debit"].ToString());
                        }
                        if (dts.Rows[i]["Credit"].ToString() != "")
                        {
                            totcramnt = totcramnt + Convert.ToDouble(dts.Rows[i]["Credit"].ToString());
                        }
                    }
                    txtDbtAmnt.Text = string.Format("{0:0.00}", totdbAmnt);
                    txtCrAmnt.Text = string.Format("{0:0.00}", totcramnt);
                    btn_RevJV.Enabled = true;
                    btn_CancelJVpopup.Enabled = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Button), "Valid text", "alertify.alert('Invalid voucher');", true);
                    ClearAll();
                }
                // btncancel.Text = "Cancel";


                //btncancel.ToolTip = "Cancel";
                //btncancel1.Attributes["class"] = "btn ico-cancel";

            }
        }

        public void ClearAll()
        {
            //btncancel.ToolTip = "Back";
            //btncancel1.Attributes["class"] = "btn ico-back";
            //txtvouyear = Session["LogYear"].ToString();
            //txtmonth.Text = "";
            txtjnlno.Text = "";
            txtnarration.Text = "";
            txtDbtAmnt.Text = "";
            txtCrAmnt.Text = "";
            txtjobno.Text = "";
            txtref.Text = "";
            recedit = false;
            txtdate.Enabled = true;
            grd_journal.DataSource = new DataTable();
            grd_journal.DataBind();
            txtdate.Text = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToString());
            GetTextDate();
            //lbl_name.Text = "Name";
        }

        protected void grd_journal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text == "Dr")
                {
                    e.Row.Cells[3].Text = "";
                }
                if (e.Row.Cells[0].Text == "Cr")
                {
                    e.Row.Cells[2].Text = "";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text == "&nbsp" || e.Row.Cells[i].Text == "&nbsp;")
                    {
                        e.Row.Cells[i].Text = "";
                    }

                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }
        }

        protected void btn_RevJV_Click(object sender, EventArgs e)
        {
            int journal = obj_da_Reversal.JournalReversal(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_VouID.Value), Convert.ToInt32(Session["LoginEmpId"]), Session["FADbname"].ToString(), Convert.ToInt32(hid_divisionid.Value));
            if (int_bid == 5)
            {
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1954, 1, Convert.ToInt32(Session["LoginBranchid"]), "JV #" + Convert.ToInt32(txtjnlno.Text) + "-RevJV #" + journal + "/S");
            }
            else
            {
                obj_da_Log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1904, 1, Convert.ToInt32(Session["LoginBranchid"]), "JV #" + Convert.ToInt32(txtjnlno.Text) + "-RevJV #" + journal + "/S");
            }
            int BookClosure_Status = obj_da_Reversal.CheckBookClosureStatus(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_divisionid.Value), Session["FADbname"].ToString());
            if (BookClosure_Status > 0)
            {
                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Reversal JV #:" + journal + " generated in the Current Financial Year due to Book Closed.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(btn_reverse, typeof(Button), "Reversal", "alertify.alert('Reversal JV #:" + journal + " generated.');", true);
            }
            btn_RevJV.Enabled = false;
            btn_CancelJVpopup.Enabled = false;
            ClearJVRevDetails();
            this.ModalPopupExtenderlog.Show();
            return;
        }

        protected void btn_CancelJVpopup_Click(object sender, EventArgs e)
        {
            this.ModalPopupExtenderlog.Show();
            ClearJVRevDetails();
            btn_reverse.Visible = true;
            btn_cancel.Visible = true;
            GetTextDate();
        }

        public void GetTextDate()
        {
            Str_CurrrentDate = obj_da_Log.GetDate().ToShortDateString();
            int stryear = Convert.ToInt32(DateTime.Now.Year.ToString());
            int vouyeartext = Convert.ToInt32(Session["Vouyear"].ToString());
            if (stryear == vouyeartext)
            {
                txtdate.Text = Utility.fn_ConvertDate(Str_CurrrentDate.ToString());
            }
            else
            {
                txtdate.Text = "31/03/" + (vouyeartext + 1);
            }
        }

        public void ClearJVRevDetails()
        {
            txtjnlno.Text = "";
            txtnarration.Text = "";
            txtCrAmnt.Text = "";
            txtDbtAmnt.Text = "";
            txtjobno.Text = "";
            txtref.Text = "";
            DataTable Empty = new DataTable();
            grd_journal.DataSource = Empty;
            grd_journal.DataBind();
            GetTextDate();
        }


        // Einvoice newly added satrt//

        public static string DineshhttpPostWebRequets(string url, string postData)
        {
            string strResponse = null;
            string dataval = null;
            string tokenvalue = null;
           DataAccess.Documents objnew = new DataAccess.Documents();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            objnew.GetDataBase(Ccode);
            if (System.Net.ServicePointManager.MaxServicePointIdleTime > 10000)
            {
                System.Net.ServicePointManager.MaxServicePointIdleTime = 10000;
            }

            if (System.Net.ServicePointManager.MaxServicePoints != 0) //unlimit
                System.Net.ServicePointManager.MaxServicePoints = 0;
            // System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 |(SecurityProtocolType)768 | (SecurityProtocolType)3072;
            //System.Net.ServicePointManager.SecurityProtocol =  SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 |  SecurityProtocolType.Tls;
            try
            {

                var webRequest = System.Net.WebRequest.Create(url);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Timeout = 120000;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    webRequest.ContentType = "application/json";
                  //  webRequest.Headers.Add("Token", "ceadc473-7dc7-42f9-a99b-63ae924a8adb"); // M+R Einvoice Token
                    tokenvalue = objnew.geteinvoicetoken(Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));

                    webRequest.Headers.Add("Token", tokenvalue);  //"ceadc473-7dc7-42f9-a99b-63ae924a8adb"
                    webRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        using (Stream s = webRequest.GetResponse().GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s))
                            {
                                strResponse = sr.ReadToEnd();
                            }
                        }


                    }
                }
                webRequest = null;


            }
            catch (Exception ex)
            {

            }
            return strResponse;
        }

        protected DataTable ConvertJsonToDatatable(string jsonString)
        {
            DataTable dt = new DataTable();
            //strip out bad characters
            string[] jsonParts = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");

            //hold column names
            List<string> dtColumns = new List<string>();

            //get columns
            foreach (string jp in jsonParts)
            {
                //only loop thru once to get column names
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1);
                        string v = rowData.Substring(idx + 1);
                        if (!dtColumns.Contains(n))
                        {
                            dtColumns.Add(n.Replace("'", ""));//'
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", rowData));
                    }

                }
                break; // TODO: might not be correct. Was : Exit For
            }

            //build dt
            foreach (string c in dtColumns)
            {
                dt.Columns.Add(c);
            }
            //get table data
            foreach (string jp in jsonParts)
            {
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1).Replace("'", "");
                        string v = rowData.Substring(idx + 1).Replace("'", "");
                        nr[n] = v;
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
                dt.Rows.Add(nr);
            }
            return dt;
        }

        
        // Einvoice newly added end//


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
            GridViewlog11.Visible = true;
            Panel111.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            //DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            if (Session["str_ModuleName"].ToString() == "FA")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1904, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1954, "", "", "", Session["StrTranType"].ToString());
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtender111.Show();
                GridViewlog11.DataSource = obj_dtlogdetails;
                GridViewlog11.DataBind();
            }
        }
    }
}
