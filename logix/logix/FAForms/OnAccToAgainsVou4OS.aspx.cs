using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web.Services.Description;


namespace logix.FAForm
{
    public partial class OnAccToAgainsVou4OS : System.Web.UI.Page
    {
        DataAccess.Accounts.Payment obi_pay = new DataAccess.Accounts.Payment();
        DataAccess.Accounts.Recipts obj_Rec = new DataAccess.Accounts.Recipts();
        DataAccess.FAMaster.MasterLedger Ldrobj = new DataAccess.FAMaster.MasterLedger();
        DataAccess.Accounts.Approval Approveobj = new DataAccess.Accounts.Approval();
        int int_bid, int_cid, empid;
        int a;
        DataTable dt_temp = new DataTable();
        DataRow dr_row;
        string exrate, dBNAME;
        int rowIndex;
        int int_Ledgerid = 0;
        bool custbol, custexist;
        double custvouamt;
        DataTable dtgrddetails = new DataTable();
        DataTable Dt_Head = new DataTable();
        double GrdActualAmt, ActualAmt;
        DataTable Dt = new DataTable();
        DataTable DT_GetVOUID = new DataTable();
        int chkledgerid;
        DataAccess.FAVoucher FAObj = new DataAccess.FAVoucher();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
        DataAccess.Masters.MasterCustomer obj_Cust = new DataAccess.Masters.MasterCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                obi_pay.GetDataBase(Ccode);
                obj_Rec.GetDataBase(Ccode);
                Ldrobj.GetDataBase(Ccode);
                Approveobj.GetDataBase(Ccode);
                FAObj.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                obj_da_Log.GetDataBase(Ccode);
                obj_Cust.GetDataBase(Ccode);

            }

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            int_cid = Convert.ToInt32(Session["LoginDivisionid"].ToString());
            int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            if (ddl_receipt.SelectedItem.Text == "OSPayment")
            {

                Session["Rtype"] = "P";
                Session["rptype"] = Session["Rtype"];
            }
            else if (ddl_receipt.SelectedItem.Text == "OSReceipt")
            {

                Session["Rtype"] = "R";
                Session["rptype"] = Session["Rtype"];
            }
            dBNAME = Session["FADbname"].ToString();
            empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            if (!IsPostBack)
            {
                lbnl_logyear.Text = Session["LYEAR"].ToString();
                txt_VouYear.Text = Session["Vouyear"].ToString();
              //  DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
                hid_date.Value = Utility.fn_ConvertDate(obj_da_Log.GetDate().ToShortDateString());
                txt_RecDate.Text = hid_date.Value.ToString();
                Grd_INVRec.DataSource = new DataTable();
                Grd_INVRec.DataBind();
                txt_VouYear.Attributes.Add("OnKeypress", "return IntegerCheck(event);");

                ddl_mode.SelectedItem.Text = "Cheque/DD";

                hid_bln.Value = "False";
                hid_custbol.Value = "false";
                hid_custexist.Value = "false";
                hid_rptype.Value = "R";
            }
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_Recno.Text != "" && hid_int_rid.Value != "0")
            {
                double GrdIncAmt = 0, GrdExpAmt = 0, OnAccAmt = 0, OnAcc = 0, fcamt = 0;
                bool blnTDS = false;
                string IE = "";
                for (int i = 0; i < Grd_INVRec.Rows.Count; i++)
                {
                    TextBox txt2 = ((TextBox)Grd_INVRec.Rows[i].FindControl("txt_receiptamount"));
                    IE = Grd_INVRec.Rows[i].Cells[6].Text.Trim();


                    if (IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX")
                    {
                        GrdIncAmt += Convert.ToDouble(txt2.Text.TrimStart().TrimEnd().Trim());
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS"))
                    {
                        GrdExpAmt += Convert.ToDouble(txt2.Text.TrimStart().TrimEnd().Trim());
                    }
                    else if (IE == "O")
                    {
                        OnAcc += Convert.ToDouble(txt2.Text.TrimStart().TrimEnd().Trim());
                    }

                    if (IE == "U" || IE == "T")
                    {
                        if (Grd_INVRec.Rows[i].Cells[12].Text == "Dr")
                        {
                            GrdIncAmt += Convert.ToDouble(txt2.Text.TrimStart().TrimEnd().Trim());
                        }
                        else if (Grd_INVRec.Rows[i].Cells[12].Text == "Cr")
                        {
                            GrdExpAmt += Convert.ToDouble(txt2.Text.TrimStart().TrimEnd().Trim());
                        }
                    }
                }
                if (Session["rptype"].ToString() == "R")
                {
                    if (Convert.ToDouble(txt_amount.Text) == Convert.ToDouble(txt_CustAmt.Text))
                    {
                        GrdActualAmt = GrdIncAmt + Convert.ToDouble(txt_TDSAmt.Text) - GrdExpAmt;
                        blnTDS = true;
                    }
                    else if (Convert.ToDouble(txt_TDSAmt.Text) != 0)
                    {
                        GrdActualAmt = GrdIncAmt + Convert.ToDouble(txt_TDSAmt.Text) - GrdExpAmt;
                        blnTDS = true;
                    }
                    else
                    {
                        GrdActualAmt = GrdIncAmt - GrdExpAmt;
                    }
                }
                else if (Session["rptype"].ToString() == "P")
                {
                    if (Convert.ToDouble(txt_amount.Text) == Convert.ToDouble(txt_CustAmt.Text))
                    {
                        GrdActualAmt = GrdExpAmt + Convert.ToDouble(txt_TDSAmt.Text) - GrdIncAmt;
                        blnTDS = true;
                    }
                    else if (Convert.ToDouble(txt_TDSAmt.Text) != 0)
                    {
                        GrdActualAmt = GrdExpAmt + Convert.ToDouble(txt_TDSAmt.Text) - GrdIncAmt;
                        blnTDS = true;
                    }
                    else
                    {
                        GrdActualAmt = GrdExpAmt - GrdIncAmt;
                    }
                }

                GrdActualAmt = Convert.ToDouble(GrdActualAmt.ToString("#,0.00"));
                int count = 0;
                if (hid_RCurr.Value != "" && Grd_INVRec.Rows.Count > 0)
                {
                    for (int i = 0; i < Grd_INVRec.Rows.Count - 1; i++)
                    {
                        if (hid_RCurr.Value == Grd_INVRec.Rows[i].Cells[9].Text)
                        {
                            count = count + 1;
                        }
                    }
                }
                ActualAmt = Convert.ToDouble(hid_ActualAmt.Value);
                ActualAmt = Convert.ToDouble(ActualAmt.ToString("#,0.00"));
                if ((GrdActualAmt <= ActualAmt) || (GrdActualAmt >= ActualAmt && count != Grd_INVRec.Rows.Count))   // ActualAmt
                {
                    if (blnTDS == true && txt_TDSAmt.Text != "-0.00")
                    {

                    }
                    obj_Rec.DelRecAgInv4OS(Convert.ToInt32(hid_int_rid.Value), Convert.ToChar(Session["rptype"].ToString()));

                    int gbid = 0, RAVouYear = 0, invno = 0, gjlid = 0; double ramt = 0, vouamt = 0, exrate = 0, camt = 0;
                    string fcurr = "", gjltype = "";
                    String vtype = "X";
                    char setteled = 'X';

                    for (int i = 0; i < Grd_INVRec.Rows.Count; i++)
                    {
                        TextBox txt2 = ((TextBox)Grd_INVRec.Rows[i].FindControl("txt_receiptamount"));
                        ramt = Convert.ToDouble(txt2.Text.TrimStart().TrimEnd().Trim());
                        vtype = Grd_INVRec.Rows[i].Cells[6].Text.Trim();
                        if (ramt > 0 && vtype != "O")
                        {
                            gbid = Convert.ToInt32(Grd_INVRec.Rows[i].Cells[0].Text);
                            invno = Convert.ToInt32(Grd_INVRec.Rows[i].Cells[7].Text);
                            vouamt = Convert.ToDouble(Grd_INVRec.Rows[i].Cells[4].Text);
                            RAVouYear = Convert.ToInt32(Grd_INVRec.Rows[i].Cells[8].Text);
                            exrate = Convert.ToDouble(Grd_INVRec.Rows[i].Cells[3].Text);
                            //gjlid = Convert.ToInt32(Grd_INVRec.Rows[i].Cells[11].Text);
                            //gjltype = (Grd_INVRec.Rows[i].Cells[12].Text);


                            if (vtype == "I" || vtype == "D" || vtype == "V" || vtype == "X" || vtype == "OI" || vtype == "OD" || vtype == "OV" || vtype == "OX")
                            {
                                camt += (ramt * exrate);
                            }
                            else if (vtype == "P" || vtype == "C" || vtype == "E" || vtype == "S" || vtype == "OP" || vtype == "OC" || vtype == "OE" || vtype == "OS")
                            {
                                camt -= (ramt * exrate);
                            }
                            else if (vtype == "U" || vtype == "T")
                            {
                                if (Grd_INVRec.Rows[i].Cells[12].Text == "Dr")
                                {
                                    camt += (ramt * exrate);
                                }
                                else if (Grd_INVRec.Rows[i].Cells[12].Text == "Cr")
                                {
                                    camt -= (ramt * exrate);
                                }
                            }
                            fcurr = Grd_INVRec.Rows[i].Cells[9].Text;
                            if (vouamt > ramt)
                            {
                                setteled = 'N';
                            }
                            else if (vouamt == ramt)
                            {
                                setteled = 'Y';
                            }


                            if (vtype != "T")
                            {
                                //obj_Rec.InsRecptAginstInv4OS_new(Convert.ToInt32(hid_int_rid.Value), Convert.ToChar(Session["rptype"].ToString()), invno, vtype, gbid, (vouamt * exrate), (ramt * exrate), setteled, RAVouYear, fcurr, vouamt, exrate, Convert.ToDouble(txt_amount.Text), ramt);
                                obj_Rec.InsRecptAginstInv4OS1(Convert.ToInt32(hid_int_rid.Value), Convert.ToChar(Session["rptype"].ToString()), invno, vtype, gbid, (vouamt * exrate), (ramt * exrate), setteled, RAVouYear, fcurr, vouamt, exrate, Convert.ToDouble(txt_amount.Text), ramt);
                            }
                            else
                            {
                                obj_Rec.InsRecptAginstInv4OSAdjDCN(Convert.ToInt32(hid_int_rid.Value), Convert.ToChar(Session["rptype"].ToString()), invno, vtype, gbid, (vouamt * exrate), (ramt * exrate), setteled, RAVouYear, fcurr, vouamt, exrate, Convert.ToDouble(txt_amount.Text), ramt, gjltype, gjlid);
                            }
                            try
                            {
                                if (i >= 0)
                                {
                                    Approveobj.UpdLedgerOPBreakup_new(invno, vtype, RAVouYear, gbid, Convert.ToInt32(hid_int_rid.Value), Convert.ToChar(Session["rptype"].ToString()), Convert.ToInt32(txt_VouYear.Text), (ramt * exrate), fcurr, ramt, "", "");
                                }
                            }
                            catch (Exception ex)
                            {
                                Utility.SendMail("", "", "FA RECEIPT PMT ON AC AGN VOU - ERROR In OnAccuntToAgainsVoucher VOU # " + invno + " TRANID " + hid_int_rid.Value, ex.Message.ToString(), "", "", "", "");
                            }
                        }
                    }

                    OnAccAmt = ActualAmt - GrdActualAmt;
                    double onlocamt = 0;
                    onlocamt = OnAccAmt * Convert.ToDouble(hid_oexrate.Value);
                    double custAmt;
                    if ((GrdActualAmt <= ActualAmt))
                    {
                        custAmt = Convert.ToDouble(txt_amount.Text) - Convert.ToDouble(txt_TDSAmt.Text);
                        camt = camt + onlocamt;

                    }
                    else if (GrdActualAmt >= ActualAmt && count != Grd_INVRec.Rows.Count)
                    {
                        custAmt = (Convert.ToDouble(txt_amount.Text) - OnAccAmt) - Convert.ToDouble(txt_TDSAmt.Text);
                    }

                    obj_Rec.DelCustChrgsOS(Convert.ToInt32(hid_int_rid.Value), 4963, "Ch", Convert.ToChar(Session["rptype"].ToString()));

                    if (ViewState["grddetails"] != null)
                    {
                        DataTable dt = ViewState["grddetails"] as DataTable;
                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                obj_Rec.DelCustChrgsOS(Convert.ToInt32(hid_int_rid.Value), Convert.ToInt32(dt.Rows[i]["cid"].ToString()), "Cu", Convert.ToChar(Session["rptype"].ToString()));

                                if (dt.Rows[i]["cid"].ToString() == hid_RCustid.Value)
                                {                                    
                                    if ((OnAccAmt) > 0)
                                    {
                                        //obj_Rec.UpdRecptCustAmtOS(Convert.ToInt32(hid_int_rid.Value), Convert.ToInt32(dt.Rows[i]["cid"].ToString()), Convert.ToDouble(dt.Rows[i]["Amount"].ToString()) + (OnAccAmt * Convert.ToDouble(hid_oexrate.Value)), Convert.ToDouble(dt.Rows[i]["fc"].ToString()) + (OnAccAmt));
                                        obj_Rec.UpdRecptCustAmtOS(Convert.ToInt32(hid_int_rid.Value), Convert.ToInt32(dt.Rows[i]["cid"].ToString()), Math.Abs(camt), Convert.ToDouble(hid_custAmt.Value), Convert.ToChar(Session["rptype"].ToString()));
                                    }
                                    else if (OnAccAmt == 0)
                                    {
                                        //obj_Rec.UpdRecptCustAmtOS(Convert.ToInt32(hid_int_rid.Value), Convert.ToInt32(dt.Rows[i]["cid"].ToString()), Convert.ToDouble(dt.Rows[i]["Amount"].ToString()), Convert.ToDouble(dt.Rows[i]["fc"].ToString()));
                                        obj_Rec.UpdRecptCustAmtOS(Convert.ToInt32(hid_int_rid.Value), Convert.ToInt32(dt.Rows[i]["cid"].ToString()), Math.Abs(camt), Convert.ToDouble(hid_custAmt.Value), Convert.ToChar(Session["rptype"].ToString()));
                                    }
                                }
                                else
                                {
                                    //obj_Rec.UpdRecptCustAmtOS(Convert.ToInt32(hid_int_rid.Value), Convert.ToInt32(dt.Rows[i]["cid"].ToString()), Convert.ToDouble(dt.Rows[i]["Amount"].ToString()), Convert.ToDouble(dt.Rows[i]["fc"].ToString()));
                                    obj_Rec.UpdRecptCustAmtOS(Convert.ToInt32(hid_int_rid.Value), Convert.ToInt32(dt.Rows[i]["cid"].ToString()), Convert.ToDouble(dt.Rows[i]["Amount"].ToString()), Convert.ToDouble(dt.Rows[i]["fc"].ToString()), Convert.ToChar(Session["rptype"].ToString()));
                                }
                            }
                        }
                    }

                    Dt = obj_Rec.GetOSRecptHead(Convert.ToInt32(txt_Recno.Text), int_bid, Convert.ToChar(ddl_mode.SelectedItem.Value), Convert.ToInt32(txt_VouYear.Text), Convert.ToChar(Session["rptype"].ToString()));
                    if (Dt.Rows.Count > 0)
                    {
                        hid_Custid.Value = Dt.Rows[0]["customer"].ToString();
                        hid_exrate.Value = Dt.Rows[0]["exrate"].ToString();
                        hid_rpamt.Value = Dt.Rows[0]["receiptamount"].ToString();
                    }

                    if (Convert.ToDouble(txt_TDSAmt.Text) != 0)
                    {
                        double tdsamt = Convert.ToDouble(txt_TDSAmt.Text) * Convert.ToDouble(hid_exrate.Value);
                        string tds = tdsamt.ToString("#.00");
                        tdsamt = Convert.ToDouble(tds);
                        obj_Rec.InsOSReciptChargeDetail(Convert.ToInt32(hid_int_rid.Value), 4963, tdsamt, Convert.ToDouble(txt_TDSAmt.Text), Convert.ToChar(Session["rptype"].ToString()));
                    }
                    double cal = 0;
                    cal = (Convert.ToDouble(hid_custAmt.Value) * Convert.ToDouble(hid_oexrate.Value)) - camt;
                    if (cal != 0)
                    {
                        obj_Rec.DelCustChrgsOS(Convert.ToInt32(hid_int_rid.Value), 0, "Ch", Convert.ToChar(Session["rptype"].ToString()));
                        double gainloss = 0, eglcal = 0.00;
                        if (ViewState["grddetails"] != null)
                        {
                            DataTable dt = ViewState["grddetails"] as DataTable;
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    gainloss += Convert.ToDouble(dt.Rows[i]["Amount"].ToString());
                                }
                                gainloss += Convert.ToDouble(txt_TDSAmt.Text) * Convert.ToDouble(hid_exrate.Value);
                                string gl = gainloss.ToString("#.00");
                                gainloss = Convert.ToDouble(gl);

                                eglcal = Convert.ToDouble(hid_rpamt.Value) - gainloss;
                                string egl = eglcal.ToString("#,0.00");
                                eglcal = Convert.ToDouble(egl);

                                obj_Rec.InsOSReciptChargeDetail(Convert.ToInt32(hid_int_rid.Value), 0, eglcal, Convert.ToDouble((eglcal / Convert.ToDouble(hid_oexrate.Value)).ToString("#,0.00")), Convert.ToChar(Session["rptype"].ToString()));
                                //obj_Rec.InsOSReciptChargeDetail(Convert.ToInt32(hid_int_rid.Value), 0, cal, cal / Convert.ToDouble(hid_oexrate.Value), Convert.ToChar(Session["rptype"].ToString()));

                            }
                        }
                    }

                    if (OnAccAmt > 0)
                    {
                        obj_Rec.InsRecptAginstInv4OS_new(Convert.ToInt32(hid_int_rid.Value), Convert.ToChar(Session["rptype"].ToString()), 0, "O", int_bid, 0,
                            (OnAccAmt * Convert.ToDouble(hid_oexrate.Value)), setteled, Convert.ToInt32(hid_ovyear.Value),
                            hid_ocurr.Value, 0.0, Convert.ToDouble(hid_oexrate.Value), Convert.ToDouble(txt_amount.Text), OnAccAmt);

                        chkledgerid = Ldrobj.ChkLedgeridfrmLedHead(Convert.ToInt32(hid_RCustid.Value), "C", dBNAME);
                        Approveobj.InsLedgerOPBreakup4OACOS(chkledgerid, Convert.ToInt32(txt_VouYear.Text), int_bid,
                            Convert.ToInt32(hid_int_rid.Value), Convert.ToChar(Session["rptype"].ToString()), Convert.ToInt32(txt_VouYear.Text),
                            (OnAccAmt * Convert.ToDouble(hid_oexrate.Value)), Convert.ToInt32(hid_RCustid.Value), hid_ocurr.Value, OnAccAmt);
                    }
                    try
                    {
                        if (ddl_mode.SelectedItem.Value == "C")
                        {
                            DT_GetVOUID = FAObj.GetRepostDetails(Convert.ToInt32(txt_Recno.Text), 10, int_bid, 0, 0, "Voucher", dBNAME);
                        }
                        else if (ddl_mode.SelectedItem.Value == "B" && Session["rptype"].ToString() == "R")
                        {
                            DT_GetVOUID = FAObj.GetRepostDetails(Convert.ToInt32(txt_Recno.Text), 16, int_bid, 0, 0, "Voucher", dBNAME);
                        }
                        else if (ddl_mode.SelectedItem.Value == "B" && Session["rptype"].ToString() == "P")
                        {
                            DT_GetVOUID = FAObj.GetRepostDetails(Convert.ToInt32(txt_Recno.Text), 17, int_bid, 0, 0, "Voucher", dBNAME);
                        }


                        // Update for Trigger 
                        obj_Rec.UpdOSRecptPymt4trigger(Convert.ToInt32(txt_Recno.Text), int.Parse(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_VouYear.Text), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["rptype"].ToString(), ddl_mode.SelectedItem.Value);
                

                        if (DT_GetVOUID.Rows.Count == 1)
                        {
                            int intVouID;
                            intVouID = Convert.ToInt32(DT_GetVOUID.Rows[0]["vouid"].ToString());
                            //FAObj.Delvoudetail(intVouID, dBNAME, "Delete");
                            string voucher;


                            // Update for Trigger 
                            obj_Rec.UpdOSRecptPymt4trigger(Convert.ToInt32(txt_Recno.Text), int.Parse(Session["LoginBranchid"].ToString()), Convert.ToInt32(txt_VouYear.Text), Convert.ToInt32(Session["LoginEmpId"].ToString()), Session["rptype"].ToString(), ddl_mode.SelectedItem.Value);
                


                            if (ddl_mode.SelectedItem.Value == "C")
                            {

                            }
                            else if (ddl_mode.SelectedItem.Value == "B" && Session["rptype"].ToString() == "R")
                            {

                            }
                            else if (ddl_mode.SelectedItem.Value == "B" && Session["rptype"].ToString() == "P")
                            {

                            }
                            else if (ddl_mode.SelectedItem.Value == "P")
                            {

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    logobj.InsLogDetail(empid, 1329, 1, int_bid, "RID:" + Convert.ToInt32(hid_int_rid.Value) + "/RNo:" + txt_Recno.Text + "/VouYr: " + txt_VouYear.Text);
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('OnAccount Transfered To Against Overseas Voucher');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Customer Amount does not Match with Voucher Details Amount');", true);
                }
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                Fn_Clear();
            }
            else
            {

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

        [WebMethod]
        public static List<string> GetCustomer(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.FAMaster.MasterLedger Ldrobj = new DataAccess.FAMaster.MasterLedger();
            DataTable dt = new DataTable();
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            string dBNAME = HttpContext.Current.Session["FADbname"].ToString();
            dt = Ldrobj.GetLikeLedgernameLedger(prefix, did, bid, dBNAME);
            List_Result = Utility.Fn_DatatableToList_Customer(dt, "LNandPort", "opsid");
            return List_Result;
        }

        private void Fn_Clear()
        {
            txt_amount.Text = "";
            ddl_mode.SelectedIndex = 0;
            txt_Cust.Text = "";
            txt_VouYear.Text = Session["Vouyear"].ToString();
            txt_CustAmt.Text = "";
            txt_GrdVouTotAmt.Text = "";
            Grd_INVRec.DataSource = new DataTable();
            Grd_INVRec.DataBind();
            ViewState["Dt_Head"] = null;
            lbl_receipt.Text = "CN #";
            txt_amount.Text = "";
            txt_TDSAmt.Text = "0.00";
            txt_Recno.Text = "";
            txt_RecDate.Text = "";
            txtsch.Text = "";
            cmbvoutype.Text = "Vou Type";
            txtTotalAmt.Text = "";
            hid_bln.Value = "False";
            hid_custbol.Value = "false";
            hid_custexist.Value = "false";
            ViewState["grddetails"] = null;
            txt_Recno.Focus();
            btn_cancel.ToolTip = "Back";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void txt_Recno_TextChanged(object sender, EventArgs e) ///// 07-12-2022 hari
        {
            try
            {
                DataRow dr;// = new DataRow();
                int a = 0;
                if (ddl_mode.Text != "")
                {

                    Fn_Getdetail();
                    if (Grd_INVRec.Rows.Count > 0 && hid_Custid.Value != "0")
                    {
                        if (ViewState["grddetails"] != null)
                        {
                            dtgrddetails = ViewState["grddetails"] as DataTable;
                            dr = dtgrddetails.NewRow();
                            dtgrddetails.Rows.Add();
                            a = dtgrddetails.Rows.Count - 1;
                            dtgrddetails.Rows[a][0] = "Customer";
                            dtgrddetails.Rows[a][1] = txt_Cust.Text;
                            dtgrddetails.Rows[a][2] = "0.00";           // ((Convert.ToDouble(txt_GrdVouTotAmt.Text)) * (Convert.ToDouble(hid_oexrate.Value))).ToString();
                            dtgrddetails.Rows[a][3] = "0.00";           // txt_GrdVouTotAmt.Text;
                            dtgrddetails.Rows[a][4] = hid_Custid.Value;
                            dtgrddetails.Rows[a][5] = int_Ledgerid;
                            ViewState["grddetails"] = dtgrddetails;
                        }
                        else
                        {
                            if (dtgrddetails.Rows.Count == 0)
                            {
                                dtgrddetails.Columns.Add("Type");
                                dtgrddetails.Columns.Add("Customerortax");
                                dtgrddetails.Columns.Add("Amount");
                                dtgrddetails.Columns.Add("fc");
                                dtgrddetails.Columns.Add("cid");
                                dtgrddetails.Columns.Add("ledgerid");
                                dr = dtgrddetails.NewRow();
                                dtgrddetails.Rows.Add();
                                dtgrddetails.Rows[0][0] = "Customer";
                                dtgrddetails.Rows[0][1] = txt_Cust.Text;
                                dtgrddetails.Rows[0][2] = "0.00";           // ((Convert.ToDouble(txt_GrdVouTotAmt.Text)) * (Convert.ToDouble(hid_oexrate.Value))).ToString();
                                dtgrddetails.Rows[0][3] = "0.00";           // txt_GrdVouTotAmt.Text;
                                dtgrddetails.Rows[0][4] = hid_Custid.Value;
                                dtgrddetails.Rows[0][5] = int_Ledgerid;
                                ViewState["grddetails"] = dtgrddetails;
                            }

                        }
                    }
                    calgrdcustvouamount(hid_rptype.Value);
                    //  btn_cancel.Text = "Cancel";


                    btn_cancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txt_Recno, typeof(Button), "OnAccToAgainsVou4OS", "alertify.alert('Mode Can Not Be Blank');", true);
                    ddl_mode.Focus();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(txt_Recno, typeof(Button), "OnAccToAgainsVou4OS", "alertify.alert('" + ex.ToString() + "');", true);
            }
        }

        protected void calgrdcustvouamount(string rptype)
        {
            hid_custexist.Value = "false";
            int grdcustid = 0, grdledgrid = 0;
            double totamt = 0, inc = 0, exp = 0, custvouamtINR = 0; int grddtlscustid = 0;
            string IE = "";
            double incINR = 0, expINR = 0;

            if (ViewState["grddetails"] != null)
            {
                dtgrddetails = ViewState["grddetails"] as DataTable;
                for (int i = 0; i < dtgrddetails.Rows.Count; i++)
                {
                    if (dtgrddetails.Rows[i]["Type"].ToString() == "Customer")
                    {
                        grddtlscustid = Convert.ToInt32(dtgrddetails.Rows[i]["cid"].ToString());
                        if (rptype == "P")
                        {


                            for (int j = 0; j < Grd_INVRec.Rows.Count; j++)
                            {
                                IE = Grd_INVRec.Rows[j].Cells[6].Text.Trim();
                                TextBox txt1 = ((TextBox)Grd_INVRec.Rows[j].FindControl("txt_receiptamount"));
                                grdcustid = Convert.ToInt32(Grd_INVRec.Rows[j].Cells[10].Text);

                                if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX") && grdcustid == grddtlscustid)
                                {
                                    inc += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[4].Text);
                                    incINR += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                }
                                else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && grdcustid == grddtlscustid)
                                {
                                    exp += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[4].Text);
                                    expINR += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());

                                }

                                if (rptype == "R")
                                {
                                    if (IE == "P" || IE == "C")
                                    {
                                        if ((Grd_INVRec.Rows[j].Cells[12].Text == "Dr") && grdcustid == grddtlscustid)
                                        {
                                            inc += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[4].Text);
                                            incINR += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());

                                        }
                                        else if ((Grd_INVRec.Rows[j].Cells[12].Text == "Cr") && grdcustid == grddtlscustid)
                                        {
                                            exp += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[4].Text);
                                            expINR += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());

                                        }
                                    }
                                }
                                else if (rptype == "R" || IE == "U")
                                {
                                    if (IE == "J")
                                    {
                                        if ((Grd_INVRec.Rows[j].Cells[12].Text == "Dr") && grdcustid == grddtlscustid)
                                        {
                                            inc += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[4].Text);
                                            incINR += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());

                                        }
                                        else if ((Grd_INVRec.Rows[j].Cells[12].Text == "Cr") && grdcustid == grddtlscustid)
                                        {
                                            exp += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[4].Text);
                                            expINR += Convert.ToDouble(Grd_INVRec.Rows[j].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());

                                        }
                                    }
                                }
                            }

                            custvouamt = exp - inc;
                            //custvouamt = inc - exp;
                            custvouamtINR = expINR - incINR;

                        }
                        else if (rptype == "R")
                        {
                            //double incINR = 0, expINR = 0;
                            for (int k = 0; k < Grd_INVRec.Rows.Count; k++)
                            {
                                IE = Grd_INVRec.Rows[k].Cells[6].Text.Trim();
                                TextBox txt1 = ((TextBox)Grd_INVRec.Rows[k].FindControl("txt_receiptamount"));
                                grdcustid = Convert.ToInt32(Grd_INVRec.Rows[k].Cells[10].Text);
                                grdledgrid = Convert.ToInt32(Grd_INVRec.Rows[k].Cells[11].Text);
                                hid_custexist.Value = "false";
                                for (int j = 0; j < dtgrddetails.Rows.Count; j++)
                                {
                                    if (grdledgrid == Convert.ToInt32(dtgrddetails.Rows[j]["ledgerid"].ToString()))
                                    {
                                        hid_custexist.Value = "true";
                                        continue;
                                    }
                                }
                                if (hid_custexist.Value == "false" && grdledgrid != Convert.ToInt32(hid_ledgerid.Value) && grdcustid != Convert.ToInt32(hid_Custid.Value))
                                {
                                    if (dtgrddetails.Rows.Count == 0)
                                    {
                                        dtgrddetails.Columns.Add("Type");
                                        dtgrddetails.Columns.Add("Customerortax");
                                        dtgrddetails.Columns.Add("Amount");
                                        dtgrddetails.Columns.Add("fc");
                                        dtgrddetails.Columns.Add("cid");
                                        dtgrddetails.Columns.Add("ledgerid");
                                    }
                                    dr_row = dtgrddetails.NewRow();
                                    dtgrddetails.Rows.Add();

                                    a = dtgrddetails.Rows.Count - 1;
                                    dtgrddetails.Rows[i][0] = "Customer";
                                    dtgrddetails.Rows[i][1] = customerobj.GetCustomername(grdcustid);
                                    dtgrddetails.Rows[i][2] = "0.00";
                                    dtgrddetails.Rows[i][3] = "0.00";
                                    dtgrddetails.Rows[i][4] = hid_Custid.Value;
                                    dtgrddetails.Rows[i][5] = customerobj.Getledgeridfromcustid(grdcustid);
                                    ViewState["grddetails"] = dtgrddetails;
                                }
                                if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX") && grdcustid == grddtlscustid)
                                {
                                    inc += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                    incINR += Convert.ToDouble(Grd_INVRec.Rows[k].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());

                                }
                                else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && grdcustid == grddtlscustid)
                                {
                                    exp += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                    expINR += Convert.ToDouble(Grd_INVRec.Rows[k].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());

                                }

                                if (rptype == "R")
                                {
                                    if (IE == "J")
                                    {
                                        if ((Grd_INVRec.Rows[k].Cells[12].Text == "Dr") && grdcustid == grddtlscustid)
                                        {
                                            inc += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            incINR += Convert.ToDouble(Grd_INVRec.Rows[k].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        }
                                        else if ((Grd_INVRec.Rows[k].Cells[12].Text == "Cr") && grdcustid == grddtlscustid)
                                        {
                                            exp += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            expINR += Convert.ToDouble(Grd_INVRec.Rows[k].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        }
                                    }
                                }
                                else if (rptype == "R")
                                {
                                    if (IE == "J")
                                    {
                                        if ((Grd_INVRec.Rows[k].Cells[12].Text == "Dr") && grdcustid == grddtlscustid)
                                        {
                                            inc += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            incINR += Convert.ToDouble(Grd_INVRec.Rows[k].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        }
                                        else if ((Grd_INVRec.Rows[k].Cells[12].Text == "Cr") && grdcustid == grddtlscustid)
                                        {
                                            exp += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                            expINR += Convert.ToDouble(Grd_INVRec.Rows[k].Cells[3].Text) * Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                                        }
                                    }
                                }

                            }

                            custvouamt = inc - exp;
                            custvouamtINR = incINR - expINR;

                        }

                        dtgrddetails.Rows[i]["fc"] = custvouamt.ToString("#,0.00");
                        dtgrddetails.Rows[i]["Amount"] = custvouamtINR.ToString("#,0.00");


                    }


                }

                for (int i = 0; i < dtgrddetails.Rows.Count; i++)
                {
                    if (dtgrddetails.Rows[i]["Type"].ToString() == "Customer")
                    {
                        totamt += Convert.ToDouble(dtgrddetails.Rows[i]["fc"].ToString());
                    }
                }
                txtTotalAmt.Text = totamt.ToString("#,0.00");

            }
        }

        private void Fn_Getdetail()
        {

            //DataAccess.Masters.MasterCustomer obj_Cust = new DataAccess.Masters.MasterCustomer();

            DataTable Dt_Head = new DataTable();
            int_bid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            int_cid = Convert.ToInt32(Session["LoginDivisionid"].ToString());
            int int_rid = 0;
            double dbl_Amt = 0;


            if (ddl_mode.Text != "" && txt_Recno.Text != "" && txt_VouYear.Text != "")
            {
                if (hid_bln.Value.ToString() == "False")
                {
                    Dt = obj_Rec.GetOSRecptHead(Convert.ToInt32(txt_Recno.Text), int_bid, Convert.ToChar(ddl_mode.SelectedItem.Value), Convert.ToInt32(txt_VouYear.Text), Convert.ToChar(Session["rptype"].ToString()));
                    if (Dt.Rows.Count > 0)
                    {
                        int_rid = Convert.ToInt32(Dt.Rows[0][0].ToString());
                        hid_int_rid.Value = int_rid.ToString();
                        txt_RecDate.Text = Utility.fn_ConvertDate(Dt.Rows[0][2].ToString());
                        dbl_Amt = Convert.ToDouble(Dt.Rows[0]["receiptfamount"].ToString());
                        hid_dbl_Amt.Value = dbl_Amt.ToString();
                        txt_amount.Text = string.Format("{0:##,0.00}", dbl_Amt);

                        if (hid_Custid.Value == "")
                        {
                            hid_Custid.Value = Dt.Rows[0]["customer"].ToString();
                        }
                        
                        hid_RCustid.Value = hid_Custid.Value;
                        int_Ledgerid = Convert.ToInt32(Dt.Rows[0]["ledgerid"].ToString());

                        if (hid_ledgerid.Value == "")
                        {
                            hid_ledgerid.Value = int_Ledgerid.ToString();
                        }

                        hid_RCurr.Value = Dt.Rows[0]["curr"].ToString();

                        if (txt_Cust.Text == "")
                        {
                            txt_Cust.Text = Dt.Rows[0][6].ToString();
                        }

                        txt_TDSAmt.Text = "0.00";
                        Dt_Head = obj_Rec.GetRecptChrgOS(int_rid, Convert.ToChar(Session["rptype"].ToString()));
                        if (Dt_Head.Rows.Count > 0)
                        {
                            txt_TDSAmt.Text = Dt_Head.Rows[0][2].ToString();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(txt_Recno, typeof(Button), "OnAccToAgainsVou4OS", "alertify.alert('Invalid Receipt #');", true);
                        Fn_Clear();
                        return;
                    }
                }

                double dbl_dbamt, dbl_cramt, dbl_gamt;
                dbl_dbamt = 0;
                dbl_cramt = 0;
                dbl_gamt = 0;

                Dt_Head = obj_Rec.GetRAInvoiceToShow4OS_new_07(int_rid, Convert.ToChar(Session["rptype"].ToString()));
                if (Dt_Head.Rows.Count > 0)
                {
                    if (hid_bln.Value.ToString() == "False")
                    {
                        Boolean bln_OAExist = false;
                        string IE;

                        for (int i = 0; i <= Dt_Head.Rows.Count - 1; i++)
                        {
                            IE = (Dt_Head.Rows[i]["voutype"].ToString()).Trim();
                            if (IE == "O")
                            {
                                bln_OAExist = true;
                                hid_oexrate.Value = Dt_Head.Rows[i]["receiptexrate"].ToString();
                                hid_ocurr.Value = Dt_Head.Rows[i]["receiptfcurr"].ToString();
                                hid_ovyear.Value = Dt_Head.Rows[i]["ravouyear"].ToString();
                                break;
                            }

                        }
                        if (bln_OAExist == false)
                        {
                            ScriptManager.RegisterStartupScript(txt_Recno, typeof(Button), "OnAccToAgainsVou4OS", "alertify.alert('OnAccount Details Not Exist For this Receipt #');", true);
                            Fn_Clear();
                            return;
                        }

                        btn_Update.Enabled = true;


                        // ---Actual Voucher Details for That Receipt#--


                        a = 0;
                        if (ViewState["Dt_Head"] != null)
                        {
                            dt_temp = (DataTable)ViewState["Dt_Head"];
                            a = dt_temp.Rows.Count;
                        }

                        if (dt_temp.Rows.Count == 0)
                        {
                            dt_temp.Columns.Clear();
                            dt_temp.Columns.Add("branchid", typeof(string));
                            dt_temp.Columns.Add("branch", typeof(string));
                            dt_temp.Columns.Add("invoiceno", typeof(string));
                            dt_temp.Columns.Add("exrate", typeof(string));
                            dt_temp.Columns.Add("iamount", typeof(string));
                            dt_temp.Columns.Add("ramount", typeof(string));
                            dt_temp.Columns.Add("voutype", typeof(string));
                            dt_temp.Columns.Add("vouno", typeof(string));
                            dt_temp.Columns.Add("ravouyear", typeof(string));
                            dt_temp.Columns.Add("curr", typeof(string));
                            dt_temp.Columns.Add("customer", typeof(string));
                            dt_temp.Columns.Add("ledgrid", typeof(string));
                            dt_temp.Columns.Add("ltype", typeof(string));
                        }


                        for (int i = 0; i <= Dt_Head.Rows.Count - 1; i++)
                        {
                            dr_row = dt_temp.NewRow();
                            dr_row["branchid"] = Dt_Head.Rows[i][0].ToString();
                            dr_row["branch"] = Dt_Head.Rows[i][1].ToString();
                            if (Dt_Head.Rows[i][2].ToString() != "0")
                            {
                                if (Dt_Head.Rows[i]["voutype"].ToString() == "I")
                                {
                                    dr_row["invoiceno"] = "Inv - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "D")
                                {
                                    dr_row["invoiceno"] = "OSDN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "V")
                                {
                                    dr_row["invoiceno"] = "DN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "X")
                                {
                                    dr_row["invoiceno"] = "ADN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "P")
                                {
                                    dr_row["invoiceno"] = "CNOps - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "C")
                                {
                                    dr_row["invoiceno"] = "OSCN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "E")
                                {
                                    dr_row["invoiceno"] = "CN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "S")
                                {
                                    dr_row["invoiceno"] = "ACN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "T" || Dt_Head.Rows[i]["voutype"].ToString() == "U")
                                {
                                    dr_row["invoiceno"] = "AdjDCN - " + Dt_Head.Rows[i]["recptfcamt"].ToString();
                                    dr_row["ledtype"] = Dt_Head.Rows[i]["jltype"].ToString();
                                    if (Dt_Head.Rows[i]["jltype"].ToString() == "Dr")
                                    {
                                        dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                    }
                                    else if (Dt_Head.Rows[i]["jltype"].ToString() == "Cr")
                                    {
                                        dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                    }

                                }
                                if (Dt_Head.Rows[i]["voutype"].ToString() == "OI")
                                {
                                    dr_row["invoiceno"] = "OB Inv - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "OD")
                                {
                                    dr_row["invoiceno"] = "OB OSDN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "OV")
                                {
                                    dr_row["invoiceno"] = "OB DN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "OX")
                                {
                                    dr_row["invoiceno"] = "OB ADN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_dbamt = dbl_dbamt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "OP")
                                {
                                    dr_row["invoiceno"] = "OB CNOps - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "OC")
                                {
                                    dr_row["invoiceno"] = "OB OSCN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "E")
                                {
                                    dr_row["invoiceno"] = "OB CN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }
                                else if (Dt_Head.Rows[i]["voutype"].ToString() == "S")
                                {
                                    dr_row["invoiceno"] = "OB ACN - " + Dt_Head.Rows[i][2].ToString();
                                    dbl_cramt = dbl_cramt + Convert.ToDouble(Dt_Head.Rows[i]["recptfcamt"].ToString());
                                }

                            }
                            else
                            {
                                dr_row["invoiceno"] = "On Account";
                            }

                            dr_row["curr"] = Dt_Head.Rows[i]["receiptfcurr"].ToString();

                            exrate = Dt_Head.Rows[i]["receiptexrate"].ToString();
                            dr_row["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");

                            dr_row["iamount"] = Dt_Head.Rows[i]["receiptfamount"].ToString();
                            dr_row["ramount"] = Dt_Head.Rows[i]["recptfcamt"].ToString();

                            dr_row["voutype"] = Dt_Head.Rows[i]["voutype"].ToString();
                            dr_row["vouno"] = Dt_Head.Rows[i]["vouno"].ToString();
                            dr_row["ravouyear"] = Dt_Head.Rows[i]["ravouyear"].ToString();
                            dr_row["customer"] = Dt_Head.Rows[i]["customer"].ToString();
                            dr_row["ledgrid"] = Dt_Head.Rows[i]["ledgrid"].ToString();

                            DataTable dt_new = new DataTable();
                            if (Dt_Head.Rows[i]["voutype"].ToString() != "O")
                            {
                                dt_new = obj_Rec.OSGetCustomerVoutype(Dt_Head.Rows[i]["voutype"].ToString(), Convert.ToInt32(Dt_Head.Rows[i]["vouno"].ToString()), Convert.ToInt32(Dt_Head.Rows[i]["branch"].ToString()), Convert.ToInt32(Dt_Head.Rows[i]["ravouyear"].ToString()));
                                if (dt_new.Rows.Count > 0)
                                {
                                    if (Dt_Head.Rows[i]["voutype"].ToString() == "V" || Dt_Head.Rows[i]["voutype"].ToString() == "E" || Dt_Head.Rows[i]["voutype"].ToString() == "X" || 
                                        Dt_Head.Rows[i]["voutype"].ToString() == "S" || Dt_Head.Rows[i]["voutype"].ToString() == "OV" || Dt_Head.Rows[i]["voutype"].ToString() == "OE" || 
                                        Dt_Head.Rows[i]["voutype"].ToString() == "OX" || Dt_Head.Rows[i]["voutype"].ToString() == "OS")
                                    {
                                        dr_row["customer"] = dt_new.Rows[0]["customerid"].ToString();
                                        dr_row["ledgrid"] = obj_Cust.Getledgeridfromcustid(Convert.ToInt32(dt_new.Rows[0]["customerid"].ToString()));
                                    }
                                    else if (Dt_Head.Rows[i]["voutype"].ToString() == "C" || Dt_Head.Rows[i]["voutype"].ToString() == "D" || Dt_Head.Rows[i]["voutype"].ToString() == "OC" || Dt_Head.Rows[i]["voutype"].ToString() == "OD")
                                    {
                                        dr_row["customer"] = dt_new.Rows[0]["customer"].ToString();
                                        dr_row["ledgrid"] = obj_Cust.Getledgeridfromcustid(Convert.ToInt32(dt_new.Rows[0]["customer"].ToString()));
                                    }
                                }
                            }
                            else
                            {
                                dr_row["customer"] = "0";
                                dr_row["ledgrid"] = "0";
                            }

                            dt_temp.Rows.Add(dr_row);
                        }
                        ViewState["Dt_Head"] = dt_temp;
                    }


                    dbl_gamt = dbl_dbamt - dbl_cramt;
                    txt_GrdVouTotAmt.Text = dbl_gamt.ToString();

                    DataTable DtR = new DataTable();
                    DtR = obj_Rec.GetOSRecptCust(int_rid, Convert.ToChar(Session["rptype"].ToString()));
                    txt_CustAmt.Text = "0";
                    for (int k = 0; k <= DtR.Rows.Count - 1; k++)
                    {
                        txt_CustAmt.Text = (Convert.ToDouble(txt_CustAmt.Text) + Convert.ToDouble(DtR.Rows[k]["fcamt"].ToString())).ToString("#,0.00");
                        hid_ActualAmt.Value = txt_amount.Text;
                        hid_custAmt.Value = txt_CustAmt.Text;
                        int r = 0;
                        if (ViewState["Dt_Head"] != null)
                        {
                            dt_temp = (DataTable)ViewState["Dt_Head"];
                            r = dt_temp.Rows.Count;
                        }


                        Dt = obj_Rec.GetOSInvRecptDtlsLedger(int_Ledgerid, int_cid);
                        for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                        {
                            //dr_row = dt_temp.NewRow();
                            dt_temp.Rows.Add();
                            dt_temp.Rows[r]["branchid"] = Dt.Rows[i][0].ToString();
                            dt_temp.Rows[r]["branch"] = Dt.Rows[i][1].ToString();
                            if (Dt.Rows[i][2].ToString() != "0")
                            {
                                if (Dt.Rows[i]["voutype"].ToString() == "I")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "Inv - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "D")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OSDN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "V")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "DN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "X")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "ADN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "P")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "CNOps - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "C")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OSCN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "E")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "CN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "S")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "ACN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OI")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB Inv - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OD")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB OSDN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OV")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB DN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OX")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB ADN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OP")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB CNOps - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OC")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB OSCN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OE")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB CN - " + Dt.Rows[i][2].ToString();
                                }
                                else if (Dt.Rows[i]["voutype"].ToString() == "OS")
                                {
                                    dt_temp.Rows[r]["invoiceno"] = "OB ACN - " + Dt.Rows[i][2].ToString();
                                }
                            }


                            dt_temp.Rows[r]["curr"] = Dt.Rows[i]["receiptfcurr"].ToString();

                            exrate = Dt.Rows[i]["receiptexrate"].ToString();
                            dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");

                            dt_temp.Rows[r]["iamount"] = Dt.Rows[i]["receiptfamount"].ToString();
                            dt_temp.Rows[r]["ramount"] = Dt.Rows[i]["famount"].ToString();

                            dt_temp.Rows[r]["voutype"] = Dt.Rows[i]["voutype"].ToString();
                            dt_temp.Rows[r]["vouno"] = Dt.Rows[i]["vouno"].ToString();
                            dt_temp.Rows[r]["ravouyear"] = Dt.Rows[i]["ravouyear"].ToString();
                            dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                            dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                            r = r + 1;

                        }

                        ViewState["Dt_Head"] = dt_temp;

                        all();
                        //DN();
                        //OSDN();
                        //ADN();
                        //CN();
                        //OSCN();
                        //ACN();

                        // New for OB
                        OBBreakUpOS();
                        OBBreakUp4rectpmtOS();
                    }

                    Grd_INVRec.DataSource = dt_temp;
                    Grd_INVRec.DataBind();
                    ViewState["Dt_Head"] = dt_temp;
                    dt_temp.Clear();
                }
            }

        }

        private void OBBreakUp4rectpmtOS()
        {
            DataRow dr;
            DataTable dtINV = new DataTable();
            int Customer_Id, r = 0;
            if (hid_ledgerid.Value != "")
            {
                Customer_Id = Convert.ToInt32(hid_ledgerid.Value);
                dtINV = obj_Rec.RecPaymCalc4OBBreakupOS(Customer_Id, int_cid);
                DataTable obj_dtAccount = new DataTable();

                if (ViewState["Dt_Head"] != null)
                {
                    dt_temp = ViewState["Dt_Head"] as DataTable;
                    r = dt_temp.Rows.Count;
                }

                for (int i = 0; i < dtINV.Rows.Count; i++)
                {

                    dt_temp.Rows.Add();
                    dt_temp.Rows[r]["branchid"] = dtINV.Rows[i]["bid"].ToString();
                    dt_temp.Rows[r]["branch"] = dtINV.Rows[i]["port"].ToString();

                    //dt_temp.Rows[r]["invoiceno"] = "CN - " + dtINV.Rows[i]["cnno"].ToString();
                    if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OI")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB Inv - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OD")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB OSDN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OV")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB DN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OX")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB ADN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OP")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB CNOps - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OC")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB OSCN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OE")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB CN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OS")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB ACN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    dt_temp.Rows[r]["curr"] = dtINV.Rows[i]["fcurr"].ToString();
                    exrate = dtINV.Rows[i]["exrate"].ToString();
                    dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    dt_temp.Rows[r]["iamount"] = dtINV.Rows[i]["fcamt"].ToString();
                    dt_temp.Rows[r]["ramount"] = dtINV.Rows[i]["ramount"].ToString();
                    dt_temp.Rows[r]["voutype"] = dtINV.Rows[i]["voutype"].ToString();
                    dt_temp.Rows[r]["vouno"] = dtINV.Rows[i]["vouno"].ToString();
                    dt_temp.Rows[r]["ravouyear"] = dtINV.Rows[i]["vouyear"].ToString();
                    dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                    dt_temp.Rows[r]["ledgrid"] = Convert.ToInt32(hid_ledgerid.Value);
                    r = r + 1;

                }

                ViewState["Dt_Head"] = dt_temp;
            }

        }

        private void OBBreakUpOS()
        {
            DataRow dr;
            DataTable dtINV = new DataTable();
            int Customer_Id, r = 0;
            if (hid_ledgerid.Value != "")
            {

                Customer_Id = Convert.ToInt32(hid_ledgerid.Value);
                dtINV = obj_Rec.GetOBRecptDtlsOS(Customer_Id, int_cid);
                DataTable obj_dtAccount = new DataTable();

                if (ViewState["Dt_Head"] != null)
                {
                    dt_temp = ViewState["Dt_Head"] as DataTable;
                    r = dt_temp.Rows.Count;
                }

                for (int i = 0; i < dtINV.Rows.Count; i++)
                {

                    dt_temp.Rows.Add();
                    dt_temp.Rows[r]["branchid"] = dtINV.Rows[i]["bid"].ToString();
                    dt_temp.Rows[r]["branch"] = dtINV.Rows[i]["port"].ToString();

                    //dt_temp.Rows[r]["invoiceno"] = "CN - " + dtINV.Rows[i]["cnno"].ToString();
                    if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OI")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB Inv - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OD")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB OSDN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OV")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB DN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OX")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB ADN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OP")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB CNOps - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OC")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB OSCN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OE")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB CN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    else if (dtINV.Rows[i]["voutype"].ToString().Trim() == "OS")
                    {
                        dt_temp.Rows[r]["invoiceno"] = "OB ACN - " + dtINV.Rows[i]["vouno"].ToString();
                    }
                    dt_temp.Rows[r]["curr"] = dtINV.Rows[i]["fcurr"].ToString();
                    exrate = dtINV.Rows[i]["exrate"].ToString();
                    dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                    dt_temp.Rows[r]["iamount"] = dtINV.Rows[i]["fcamt"].ToString();
                    dt_temp.Rows[r]["ramount"] = dtINV.Rows[i]["ramount"].ToString();
                    dt_temp.Rows[r]["voutype"] = dtINV.Rows[i]["voutype"].ToString();
                    dt_temp.Rows[r]["vouno"] = dtINV.Rows[i]["vouno"].ToString();
                    dt_temp.Rows[r]["ravouyear"] = dtINV.Rows[i]["vouyear"].ToString();
                    dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                    dt_temp.Rows[r]["ledgrid"] = Convert.ToInt32(hid_ledgerid.Value);
                    r = r + 1;

                }

                ViewState["Dt_Head"] = dt_temp;
            }
        }


        protected void txtsch_TextChanged(object sender, EventArgs e)
        {
            string schstr = "", mchstr = "";
            string[] strary;
            int count = 0;
            int rowindex = 0;
            if (Grd_INVRec.Rows.Count > 0)
            {
                if (txtsch.Text != "" && cmbvoutype.Text != "" && cmbvoutype.Text != "Vou Type")
                {
                    schstr = cmbvoutype.Text.Trim() + " - " + txtsch.Text.Trim();
                }
                else if (txtsch.Text != "" && cmbvoutype.Text == "Vou Type")
                {
                    schstr = txtsch.Text.Trim();
                }
                for (int i = 0; i < Grd_INVRec.Rows.Count; i++)
                {
                    if (txtsch.Text != "" && cmbvoutype.Text != "" && cmbvoutype.Text != "Vou Type")
                    {
                        if (Grd_INVRec.Rows[i].Cells[2].Text == "On Account")
                        {

                        }
                        else
                        {
                            mchstr = Grd_INVRec.Rows[i].Cells[2].Text;
                        }
                    }
                    else if (txtsch.Text != "")
                    {
                        if (Grd_INVRec.Rows[i].Cells[2].Text == "On Account")
                        {

                        }
                        else
                        {
                            mchstr = Grd_INVRec.Rows[i].Cells[2].Text;
                            strary = mchstr.Split('-');
                            mchstr = strary[1].Remove(0, 1);
                        }
                    }
                    if (schstr == mchstr)
                    {
                        rowindex = i;
                        Grd_INVRec.Rows[i].BackColor = System.Drawing.Color.Gray;
                    }
                    if (schstr == "")
                    {
                        Grd_INVRec.Rows[i].BackColor = System.Drawing.Color.Empty;
                        count = count + 1;
                    }
                }
                if (count == Grd_INVRec.Rows.Count && schstr != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Voucher # does not Exists');", true);
                    return;
                }

                if (rowindex != 0)
                {
                    TextBox TxtAmount = ((TextBox)Grd_INVRec.Rows[rowindex].FindControl("txt_receiptamount"));
                    TxtAmount.Focus();
                }

            }
            else
            {

            }
        }

        protected void cmbvoutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsch_TextChanged(sender, e);
        }

        protected void txt_receiptamount_TextChanged(object sender, EventArgs e)
         {

            double grd_amt;
            int ouput;
            double dbl_exr, dbl_fcamount, dbl_grdinramt;


            int RowIndex = ((GridViewRow)((TextBox)sender).NamingContainer).RowIndex;
            hid_gridname.Value = RowIndex.ToString();
            int index = Convert.ToInt32(hid_gridname.Value);
            TextBox txt1 = ((TextBox)Grd_INVRec.Rows[index].FindControl("txt_receiptamount"));
            string value = txt1.Text.TrimStart().TrimEnd().Trim();
            if (value != "")
            {
                if (double.TryParse(value, out grd_amt))
                {
                    string number = Grd_INVRec.Rows[index].Cells[4].Text;
                    if (Convert.ToDouble(number) < Convert.ToDouble(value))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount');", true);
                        ((TextBox)Grd_INVRec.Rows[index].Cells[7].FindControl("txt_receiptamount")).Text = "0.00";
                        txt1.Focus();
                        return;
                    }
                }
                else
                {

                }

            }
            for (int i = 0; i <= Grd_INVRec.Rows.Count - 1; i++)
            {


                TextBox txtvale = ((TextBox)Grd_INVRec.Rows[i].FindControl("txt_receiptamount"));
                if (txtvale.Text == "")
                {
                    txtvale.Text = "0.00";
                }


            }

            //Grd_INVRec_SelectedIndexChanged(sender, e);

            string IE;
            double dbamt, cramt, gamt, Ramt;
            dbamt = 0;
            cramt = 0;
            gamt = 0;
            Ramt = 0;

            for (int i = 0; i <= Grd_INVRec.Rows.Count - 1; i++)
            {
                TextBox txt2 = ((TextBox)Grd_INVRec.Rows[i].FindControl("txt_receiptamount"));
                if (txt2.Text.TrimStart().TrimEnd().Trim() != "")
                {
                    Ramt = Convert.ToDouble(txt2.Text.TrimStart().TrimEnd().Trim());
                }
                IE = Grd_INVRec.Rows[i].Cells[6].Text.Trim();
                if (IE != "O" && Ramt > 0)
                {
                    if (IE == "D" || IE == "V" || IE == "X" || IE == "OD" || IE == "OV" || IE == "OX" || IE == "OI")
                    {
                        dbamt = dbamt + Ramt;
                    }
                    else if (IE == "C" || IE == "E" || IE == "S" || IE == "OC" || IE == "OE" || IE == "OS" || IE == "OP")
                    {
                        cramt = cramt + Ramt;
                    }
                    else if (IE == "U" || IE == "T")
                    {
                        if (Grd_INVRec.Rows[i].Cells[6].Text == "Dr")
                        {
                            dbamt = dbamt + Ramt;
                        }
                        else if (Grd_INVRec.Rows[i].Cells[6].Text == "Cr")
                        {
                            cramt = cramt + Ramt;
                        }
                    }
                }
            }

            if (Session["rptype"].ToString() == "R")
            {
                gamt = dbamt - cramt;
            }
            else if (Session["rptype"].ToString() == "P")
            {
                gamt = cramt - dbamt;
            }
            //gamt = dbamt - cramt;

            txt_GrdVouTotAmt.Text = gamt.ToString();
            txt1.Focus();
            hid_custbol.Value = "true";
            calgrdcustvouamount(hid_rptype.Value);
        }

        protected void Grd_INVRec_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    rowIndex = Convert.ToInt32(e.CommandArgument);
            //    Grd_INVRec_SelectedIndexChanged(sender, e);
            //}




            if (e.CommandName == "TxtClick")
            {


                for (int i = 0; i <= Grd_INVRec.Rows.Count - 1; i++)
                {

                    TextBox txtvale = ((TextBox)Grd_INVRec.Rows[i].FindControl("txt_receiptamount"));
                    if (txtvale.Text == "")
                    {
                        txtvale.Text = "0.00";
                    }
                }

                rowIndex = Convert.ToInt32(e.CommandArgument);
                TextBox txt1 = ((TextBox)Grd_INVRec.Rows[rowIndex].FindControl("txt_receiptamount"));
                //string value = txt1.Text;
                if (txt1.Text == "0.00")
                {
                    txt1.Text = "";
                    txt1.Focus();
                }
                else
                {
                    txt1.Focus();
                }


            }
        }

        protected void Grd_INVRec_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index; double grd_amt;
            if (hid_gridname.Value != "")
            {
                index = Convert.ToInt32(hid_gridname.Value);


                TextBox txt1 = ((TextBox)Grd_INVRec.Rows[index].FindControl("txt_receiptamount"));
                string value = txt1.Text.TrimStart().TrimEnd().Trim();
                if (value != "")
                {
                    if (double.TryParse(value, out grd_amt))
                    {
                        string number = Grd_INVRec.Rows[index].Cells[4].Text;
                        if (Convert.ToDouble(number) < Convert.ToDouble(value))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Receipt/Payment Amount Must be Less Than or Equal to Voucher Amount');", true);
                            ((TextBox)Grd_INVRec.Rows[index].Cells[7].FindControl("txt_receiptamount")).Text = "0.00";
                            return;
                        }
                    }
                    else
                    {

                    }

                }
                else
                {

                }

            }
        }

        protected void Grd_INVRec_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //  e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_INVRec, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_INVRec, "TxtClick$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }




        private void DN()
        {
            DataTable dtINV1 = new DataTable();
            int_cid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //GetYear();
            int r = 0;

            int b = 0;
            string getdecimal = "";
            dtINV1 = obj_Rec.GetDN4OSLedger(int_Ledgerid, int_cid);
            DataRow dtrow;

            if (ViewState["Dt_Head"] != null)
            {
                dt_temp = ViewState["Dt_Head"] as DataTable;
                r = dt_temp.Rows.Count;
            }

            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {

                dt_temp.Rows.Add();
                dt_temp.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dt_temp.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                dt_temp.Rows[r]["invoiceno"] = "DN - " + dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                exrate = dtINV1.Rows[i]["exrate"].ToString();
                dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dt_temp.Rows[r]["iamount"] = dtINV1.Rows[i]["fcamt"].ToString();
                dt_temp.Rows[r]["ramount"] = dtINV1.Rows[i]["famount"].ToString();
                dt_temp.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dt_temp.Rows[r]["vouno"] = dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                r = r + 1;

            }

            ViewState["Dt_Head"] = dt_temp;
        }

        private void all()
        {
            DataTable dtINV1 = new DataTable();
            int_cid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //GetYear();
            int r = 0;

            int b = 0;
            string getdecimal = "";
            dtINV1 = obj_Rec.Getall4OSLedgerlv(int_Ledgerid, int_cid);
            DataRow dtrow;

            if (ViewState["Dt_Head"] != null)
            {
                dt_temp = ViewState["Dt_Head"] as DataTable;
                r = dt_temp.Rows.Count;
            }

            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {

                dt_temp.Rows.Add();
                dt_temp.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dt_temp.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                if (dtINV1.Rows[i]["dnno"].ToString() == "I")
                {
                    dt_temp.Rows[r]["invoiceno"] = "INV - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "P")
                {
                    dt_temp.Rows[r]["invoiceno"] = "CN-Ops - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "S")
                {
                    dt_temp.Rows[r]["invoiceno"] = "ADN - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "X")
                {
                    dt_temp.Rows[r]["invoiceno"] = "ACN - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "D")
                {
                    dt_temp.Rows[r]["invoiceno"] = "OSDN - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "C")
                {
                    dt_temp.Rows[r]["invoiceno"] = "OSCN - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "V")
                {
                    dt_temp.Rows[r]["invoiceno"] = "DN - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "E")
                {
                    dt_temp.Rows[r]["invoiceno"] = "CN - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                else if (dtINV1.Rows[i]["dnno"].ToString() == "B")
                {
                    dt_temp.Rows[r]["invoiceno"] = "BOS - " + dtINV1.Rows[i]["dnno"].ToString();
                }
                //dt_temp.Rows[r]["invoiceno"] = "OSDN - " + dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                exrate = dtINV1.Rows[i]["exrate"].ToString();
                dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dt_temp.Rows[r]["iamount"] = dtINV1.Rows[i]["fcamt"].ToString();
                dt_temp.Rows[r]["ramount"] = dtINV1.Rows[i]["famount"].ToString();
                dt_temp.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dt_temp.Rows[r]["vouno"] = dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                r = r + 1;

            }

            ViewState["Dt_Head"] = dt_temp;
        }

        private void OSDN()
        {
            DataTable dtINV1 = new DataTable();
            int_cid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //GetYear();
            int r = 0;

            int b = 0;
            string getdecimal = "";
            dtINV1 = obj_Rec.GetOSDN4OSLedger(int_Ledgerid, int_cid);
            DataRow dtrow;

            if (ViewState["Dt_Head"] != null)
            {
                dt_temp = ViewState["Dt_Head"] as DataTable;
                r = dt_temp.Rows.Count;
            }

            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {

                dt_temp.Rows.Add();
                dt_temp.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dt_temp.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                dt_temp.Rows[r]["invoiceno"] = "OSDN - " + dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                exrate = dtINV1.Rows[i]["exrate"].ToString();
                dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dt_temp.Rows[r]["iamount"] = dtINV1.Rows[i]["fcamt"].ToString();
                dt_temp.Rows[r]["ramount"] = dtINV1.Rows[i]["famount"].ToString();
                dt_temp.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dt_temp.Rows[r]["vouno"] = dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                r = r + 1;

            }

            ViewState["Dt_Head"] = dt_temp;
        }

        private void ADN()
        {
            DataTable dtINV1 = new DataTable();
            int_cid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //GetYear();
            int r = 0;

            int b = 0;
            string getdecimal = "";
            dtINV1 = obj_Rec.GetDNAdmin4OSLedger(int_Ledgerid, int_cid);
            DataRow dtrow;

            if (ViewState["Dt_Head"] != null)
            {
                dt_temp = ViewState["Dt_Head"] as DataTable;
                r = dt_temp.Rows.Count;
            }

            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {

                dt_temp.Rows.Add();
                dt_temp.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dt_temp.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                dt_temp.Rows[r]["invoiceno"] = "ADN - " + dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                exrate = dtINV1.Rows[i]["exrate"].ToString();
                dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dt_temp.Rows[r]["iamount"] = dtINV1.Rows[i]["fcamt"].ToString();
                dt_temp.Rows[r]["ramount"] = dtINV1.Rows[i]["famount"].ToString();
                dt_temp.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dt_temp.Rows[r]["vouno"] = dtINV1.Rows[i]["dnno"].ToString();
                dt_temp.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                r = r + 1;

            }

            ViewState["Dt_Head"] = dt_temp;
        }

        private void CN()
        {
            DataTable dtINV1 = new DataTable();
            int_cid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //GetYear();
            int r = 0;

            int b = 0;
            string getdecimal = "";
            dtINV1 = obi_pay.GetCN4OSLedger(int_Ledgerid, int_cid);
            DataRow dtrow;

            if (ViewState["Dt_Head"] != null)
            {
                dt_temp = ViewState["Dt_Head"] as DataTable;
                r = dt_temp.Rows.Count;
            }

            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {

                dt_temp.Rows.Add();
                dt_temp.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dt_temp.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                dt_temp.Rows[r]["invoiceno"] = "CN - " + dtINV1.Rows[i]["cnno"].ToString();
                dt_temp.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                exrate = dtINV1.Rows[i]["exrate"].ToString();
                dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dt_temp.Rows[r]["iamount"] = dtINV1.Rows[i]["fcamt"].ToString();
                dt_temp.Rows[r]["ramount"] = dtINV1.Rows[i]["ramount"].ToString();
                dt_temp.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dt_temp.Rows[r]["vouno"] = dtINV1.Rows[i]["cnno"].ToString();
                dt_temp.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                r = r + 1;

            }

            ViewState["Dt_Head"] = dt_temp;
        }

        private void OSCN()
        {
            DataTable dtINV1 = new DataTable();
            int_cid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //GetYear();
            int r = 0;

            int b = 0;
            string getdecimal = "";
            dtINV1 = obi_pay.GetOSCN4OSLedger(int_Ledgerid, int_cid);
            DataRow dtrow;

            if (ViewState["Dt_Head"] != null)
            {
                dt_temp = ViewState["Dt_Head"] as DataTable;
                r = dt_temp.Rows.Count;
            }

            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {

                dt_temp.Rows.Add();
                dt_temp.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dt_temp.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                dt_temp.Rows[r]["invoiceno"] = "OSCN - " + dtINV1.Rows[i]["cnno"].ToString();
                dt_temp.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                exrate = dtINV1.Rows[i]["exrate"].ToString();
                dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dt_temp.Rows[r]["iamount"] = dtINV1.Rows[i]["fcamt"].ToString();
                dt_temp.Rows[r]["ramount"] = dtINV1.Rows[i]["ramount"].ToString();
                dt_temp.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dt_temp.Rows[r]["vouno"] = dtINV1.Rows[i]["cnno"].ToString();
                dt_temp.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                r = r + 1;

            }

            ViewState["Dt_Head"] = dt_temp;
        }

        private void ACN()
        {
            DataTable dtINV1 = new DataTable();
            int_cid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            //GetYear();
            int r = 0;

            int b = 0;
            string getdecimal = "";
            dtINV1 = obi_pay.GetCNAdmin4OSLedger(int_Ledgerid, int_cid);
            DataRow dtrow;

            if (ViewState["Dt_Head"] != null)
            {
                dt_temp = ViewState["Dt_Head"] as DataTable;
                r = dt_temp.Rows.Count;
            }

            for (int i = 0; i < dtINV1.Rows.Count; i++)
            {

                dt_temp.Rows.Add();
                dt_temp.Rows[r]["branchid"] = dtINV1.Rows[i]["branchid"].ToString();
                dt_temp.Rows[r]["branch"] = dtINV1.Rows[i]["port"].ToString();
                dt_temp.Rows[r]["invoiceno"] = "ACN - " + dtINV1.Rows[i]["cnno"].ToString();
                dt_temp.Rows[r]["curr"] = dtINV1.Rows[i]["curr"].ToString();
                exrate = dtINV1.Rows[i]["exrate"].ToString();
                dt_temp.Rows[r]["exrate"] = Convert.ToDecimal(exrate).ToString("#,0.00");
                dt_temp.Rows[r]["iamount"] = dtINV1.Rows[i]["fcamt"].ToString();
                dt_temp.Rows[r]["ramount"] = dtINV1.Rows[i]["ramount"].ToString();
                dt_temp.Rows[r]["voutype"] = dtINV1.Rows[i]["voutype"].ToString();
                dt_temp.Rows[r]["vouno"] = dtINV1.Rows[i]["cnno"].ToString();
                dt_temp.Rows[r]["ravouyear"] = dtINV1.Rows[i]["vouyear"].ToString();
                dt_temp.Rows[r]["customer"] = Convert.ToInt32(hid_Custid.Value);
                dt_temp.Rows[r]["ledgrid"] = int_Ledgerid;
                r = r + 1;

            }

            ViewState["Dt_Head"] = dt_temp;
        }



        protected void txt_Cust_TextChanged(object sender, EventArgs e)
        {
            int ledgerid = 0;
            DataTable dt = new DataTable();

            // vino -- hid_RCustid.Value to hid_Custid.Value
            if (txt_Cust.Text != "" && hid_Custid.Value != "0")
            {


                dt = Ldrobj.GetexactLedgernameLedger(txt_Cust.Text, int_cid, int_bid, dBNAME, Convert.ToInt32(hid_Custid.Value));
                if (dt.Rows.Count > 0)
                {
                    //hid_Custid
                    //if(hid_custbol.Value !="")
                    //{

                    //}
                    ledgerid = Convert.ToInt32(dt.Rows[0]["ledgerid"].ToString());
                    hid_ledgerid.Value = ledgerid.ToString();
                }
            }
            if (hid_custbol.Value == "true")
            {
                hid_custexist.Value = "false";
                if (ViewState["grddetails"] != null)
                {
                    dtgrddetails = ViewState["grddetails"] as DataTable;
                    for (int i = 0; i < dtgrddetails.Rows.Count; i++)
                    {
                        if (hid_Custid.Value == dtgrddetails.Rows[i]["cid"].ToString())
                        {
                            custexist = true;
                            hid_custexist.Value = "true";
                            continue;
                        }
                    }
                }
                if (hid_custexist.Value == "false")
                {
                    if (dtgrddetails.Rows.Count == 0)
                    {
                        dtgrddetails.Columns.Add("Type");
                        dtgrddetails.Columns.Add("Customerortax");
                        dtgrddetails.Columns.Add("Amount");
                        dtgrddetails.Columns.Add("fc");
                        dtgrddetails.Columns.Add("cid");
                        dtgrddetails.Columns.Add("ledgerid");
                    }
                    calcustvouamount(Session["rptype"].ToString(), Convert.ToInt32(hid_Custid.Value));
                    if (custvouamt > 0 && hid_Custid.Value != "0")
                    {
                        double PartyAmt, totamt = 0; int a;

                        for (int i = 0; i < dtgrddetails.Rows.Count; i++)
                        {
                            if (dtgrddetails.Rows[i]["Type"].ToString() == "Customer" && (dtgrddetails.Rows[i]["cid"].ToString() == hid_Custid.Value))
                            {
                                totamt += Convert.ToDouble(dtgrddetails.Rows[i]["fc"].ToString());
                            }
                        }
                        PartyAmt = totamt - custvouamt;
                        if (Math.Abs(PartyAmt) > 0)
                        {
                            DataRow dr = dtgrddetails.NewRow();
                            dtgrddetails.Rows.Add();
                            if (dtgrddetails.Rows.Count == 0)
                            {
                                a = 0;
                            }
                            else
                            {
                                a = dtgrddetails.Rows.Count - 1;
                            }

                            dtgrddetails.Rows[a][0] = "Customer";
                            dtgrddetails.Rows[a][1] = txt_Cust.Text;
                            dtgrddetails.Rows[a][2] = Math.Abs(PartyAmt).ToString("#,0.00");
                            dtgrddetails.Rows[a][3] = Math.Abs(PartyAmt).ToString("#,0.00");
                            dtgrddetails.Rows[a][4] = hid_Custid.Value;
                            dtgrddetails.Rows[a][5] = ledgerid;
                            ViewState["grddetails"] = dtgrddetails;
                        }
                        for (int i = 0; i < dtgrddetails.Rows.Count; i++)
                        {
                            totamt += Convert.ToDouble(dtgrddetails.Rows[i]["fc"].ToString());
                        }
                        txtTotalAmt.Text = totamt.ToString("#,0.00");
                    }
                    hid_custbol.Value = "false";
                }
            }




            if (txt_Cust.Text != "")
            {
                if (ViewState["grddetails"] != null)
                {
                    dtgrddetails = ViewState["grddetails"] as DataTable;
                    if (dtgrddetails.Rows.Count == 0)
                    {
                        dtgrddetails.Columns.Add("Type");
                        dtgrddetails.Columns.Add("Customerortax");
                        dtgrddetails.Columns.Add("Amount");
                        dtgrddetails.Columns.Add("fc");
                        dtgrddetails.Columns.Add("cid");
                        dtgrddetails.Columns.Add("ledgerid");
                    }
                    for (int i = 0; i < dtgrddetails.Rows.Count; i++)
                    {
                        if (hid_Custid.Value == dtgrddetails.Rows[i]["cid"].ToString())
                        {
                            custexist = true;
                            hid_custexist.Value = "true";
                            continue;
                        }
                    }
                    Fn_Getdetail();
                }

            }
            if (Grd_INVRec.Rows.Count > 0 && Convert.ToInt32(hid_Custid.Value) != 0 && hid_custexist.Value == "false")
            {
                if (dtgrddetails.Rows.Count == 0)
                {
                    dtgrddetails.Columns.Add("Type");
                    dtgrddetails.Columns.Add("Customerortax");
                    dtgrddetails.Columns.Add("Amount");
                    dtgrddetails.Columns.Add("fc");
                    dtgrddetails.Columns.Add("cid");
                    dtgrddetails.Columns.Add("ledgerid");

                }
                DataRow dr = dtgrddetails.NewRow();
                dtgrddetails.Rows.Add();
                if (dtgrddetails.Rows.Count == 0)
                {
                    a = 0;
                }
                else
                {
                    a = dtgrddetails.Rows.Count - 1;
                }
                dtgrddetails.Rows[a][0] = "Customer";
                dtgrddetails.Rows[a][1] = txt_Cust.Text;
                dtgrddetails.Rows[a][2] = "0.00";
                dtgrddetails.Rows[a][3] = "0.00";
                dtgrddetails.Rows[a][4] = hid_Custid.Value;
                dtgrddetails.Rows[a][5] = ledgerid;
                ViewState["grddetails"] = dtgrddetails;
            }

        }

        protected void calcustvouamount(string rptype, int custid)
        {
            int grdcustid; double inc = 0, exp = 0; string IE;
            if (rptype == "P")
            {

                for (int i = 0; i < Grd_INVRec.Rows.Count; i++)
                {
                    //TextBox txt1 = ((TextBox)Grd_INVRec.Rows[i].FindControl("txt_receiptamount"));
                    IE = Grd_INVRec.Rows[i].Cells[6].Text;
                    grdcustid = Convert.ToInt32(Grd_INVRec.Rows[i].Cells[10].Text);
                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX") && grdcustid == custid)
                    {
                        inc += Convert.ToDouble(Grd_INVRec.Rows[i].Cells[4].Text);
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && grdcustid == custid)
                    {
                        exp += Convert.ToDouble(Grd_INVRec.Rows[i].Cells[4].Text);
                    }

                    if (IE == "J")
                    {
                        if ((Grd_INVRec.Rows[i].Cells[9].Text == "Dr") && grdcustid == custid)
                        {
                            inc += Convert.ToDouble(Grd_INVRec.Rows[i].Cells[4].Text);
                        }
                        else if ((Grd_INVRec.Rows[i].Cells[9].Text == "Cr") && grdcustid == custid)
                        {
                            exp += Convert.ToDouble(Grd_INVRec.Rows[i].Cells[4].Text);
                        }
                    }
                }
                custvouamt = exp - inc;

            }
            else if (rptype == "R")
            {

                for (int i = 0; i < Grd_INVRec.Rows.Count; i++)
                {
                    TextBox txt1 = ((TextBox)Grd_INVRec.Rows[i].FindControl("txt_receiptamount"));
                    IE = Grd_INVRec.Rows[i].Cells[6].Text;
                    grdcustid = Convert.ToInt32(Grd_INVRec.Rows[i].Cells[10].Text);
                    if ((IE == "I" || IE == "D" || IE == "V" || IE == "X" || IE == "OI" || IE == "OD" || IE == "OV" || IE == "OX") && grdcustid == custid)
                    {
                        inc += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                    }
                    else if ((IE == "P" || IE == "C" || IE == "E" || IE == "S" || IE == "OP" || IE == "OC" || IE == "OE" || IE == "OS") && grdcustid == custid)
                    {
                        exp += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                    }

                    if (IE == "J")
                    {
                        if ((Grd_INVRec.Rows[i].Cells[9].Text == "Dr") && grdcustid == custid)
                        {
                            inc += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                        }
                        else if ((Grd_INVRec.Rows[i].Cells[9].Text == "Cr") && grdcustid == custid)
                        {
                            exp += Convert.ToDouble(txt1.Text.TrimStart().TrimEnd().Trim());
                        }
                    }
                }
                custvouamt = exp - inc;

            }
        }
        protected void ddl_receipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_receipt.SelectedItem.Text == "OSReceipt")
            {
                Session["rptype"] = "R";
                txt_Recno.ToolTip = "Receipt #";
                txt_Recno.ToolTip = "Received From";
                txt_amount.ToolTip = "Receipt Amount";
                txt_Recno.Attributes.Add("placeholder", "Receipt #");
                txt_Recno.Attributes.Add("placeholder", "Received From");
                txt_amount.Attributes.Add("placeholder", "Receipt Amount");
                Label3.Text = "Receipt #";
                Label4.Text = "Rec Date";
                hid_rptype.Value = "R";

            }
            else if (ddl_receipt.SelectedItem.Text == "OSPayment")
            {
                Session["rptype"] = "P";
                txt_Recno.ToolTip = "Payment #";
                txt_Recno.ToolTip = "Payment From";
                txt_amount.ToolTip = "Payment Amount";
                txt_Recno.Attributes.Add("placeholder", "Payment #");
                txt_Recno.Attributes.Add("placeholder", "Payment To");
                txt_amount.Attributes.Add("placeholder", "Payment Amount");
                Label3.Text = "Payment #";
                Label4.Text = "Pay Date";
                hid_rptype.Value = "P";
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
            //DataAccess.LogDetails obj_da_Log = new DataAccess.LogDetails();
            GridViewlog.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();

            lbl_no.InnerText = lbl_Header.Text;


            obj_dtlogdetails = obj_da_Log.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1329, "", "", "", Session["StrTranType"].ToString());


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void Grd_INVRec_PreRender(object sender, EventArgs e)
        {
            if (Grd_INVRec.Rows.Count > 0)
            {
                Grd_INVRec.UseAccessibleHeader = true;
                Grd_INVRec.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}