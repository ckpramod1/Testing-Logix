using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;

namespace logix.AI
{
    public partial class BLPrintingAir : System.Web.UI.Page
    {
        string nomination, shiprefno;
        int customerid;
        int rccnt;
        string sendqry;
        DataAccess.LogDetails da_obj_Logobj = new DataAccess.LogDetails();
        DataAccess.AirImportExports.AIEBLDetails AIEBLObj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.ForwardingExports.BLPrinting FEBLPrint = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.Corporate Corpobj = new DataAccess.Corporate();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.Invoice invoiceobj = new DataAccess.Accounts.Invoice();
        DataAccess.CreditException Crexobj = new DataAccess.CreditException();
        DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                da_obj_Logobj.GetDataBase(Ccode);
                AIEBLObj.GetDataBase(Ccode);
                FEBLPrint.GetDataBase(Ccode);
                Corpobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                invoiceobj.GetDataBase(Ccode);


                Crexobj.GetDataBase(Ccode);
                obj_da_Branch.GetDataBase(Ccode);
                

            }


            try
            {
                ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);
                if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                }
                else if (Session["StrTranType"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
                }
                Session["str_sfs"] = "";
                Session["str_sp"] = "";
                string str_FornName = "", str_Uiid = "";

                Grd_Invoice.Visible = false;
                Grd_DN.Visible = false;
                Grd_receipt.Visible = false;


                if (Request.QueryString.ToString().Contains("POPUP"))
                {
                    crumbslbl.Attributes["class"] = "crumbslbl";
                }
                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                }

                if (Session["StrTranType"].ToString() == "AE")
                {
                    lbl_header.Text = " BL Details";
                }
                else
                {
                    lbl_header.Text = " DO Details";
                }

                if (!IsPostBack)
                {

                    Grd_DN.DataSource = new DataTable();
                    Grd_DN.DataBind();

                    Grd_freightdetail.DataSource = new DataTable();
                    Grd_freightdetail.DataBind();

                    Grd_receipt.DataSource = new DataTable();
                    Grd_receipt.DataBind();

                    Grd_Invoice.DataSource = new DataTable();
                    Grd_Invoice.DataBind();

                    if (Session["blno"] != null)
                    {
                        lnk_back.Visible = true;
                        btnprint.Enabled = true;
                        txtblno.Text = Session["blno"].ToString();
                        getvalue();
                        txtblno.Enabled = false;
                        btnback.Enabled = true;
                        Session["blno"] = null;
                        txtDOdate.Visible = false;
                        txtDOPDays.Visible = false;
                        return;
                    }

                    if (Request.QueryString.ToString().Contains("BLNO"))
                    {
                        //txt_bl.Text = Request.QueryString["BLNO"].ToString();
                        //Fn_Getvalue();
                        lnk_bl.Text = "";
                        lnk_blfreight.Text = "";
                        lnk_bl.Visible = false;
                        lnk_blfreight.Visible = false;
                        div_BLDetails.Visible = false;
                        div_BLfreigthdetail.Visible = false;
                        //btn_DO.Visible = true;
                        //btn_DOsale.Visible = true;
                    }
                    if (str_FornName == "Booking")
                    {
                        lbl_header.Text = "Booking #";
                        //txt_bl.Enabled = false;
                        //txt_book.ReadOnly = false;
                        //txt_book.Focus();
                        //txt_cfs.Visible = false;
                        //lbl_cfs.Text = "";
                        div_cha.Attributes["class"] = "div_cha_visible";
                        //doday.Visible = false;
                        dodaytxt.Visible = false;
                        //btn_DOsale.Visible = false;
                        //btn_DO.Visible = false;
                        //Btn_Print.Visible = false;
                        //btn_DO.Visible = true;
                        //btn_DOsale.Visible = true;
                    }
                    else if (str_FornName == "DODetails")
                    {
                        lbl_header.Text = "DODetails";
                        //txt_bl.Enabled = true;
                        //txt_book.ReadOnly = true;
                        //div_cha.Attributes["class"] = "div_cha_visible";

                        //dodaytxt.Visible = false;
                        //btn_DOsale.Visible = true;
                        //btn_DO.Visible = true;
                        //Btn_Print.Visible = true;
                        //btn_DO.Visible = true;
                        //btn_DOsale.Visible = true;
                        //Session["blno"] = txt_bl.Text;
                        lnk_back.Visible = false;
                    }
                    else
                    {
                        // txt_cfs.Visible = false;
                    }

                    if (Session["StrTranType"].ToString() == "AI")
                    {
                        HeaderLabel1.InnerText = "Air Imports";
                    }

                    if (Request.QueryString.ToString().Contains("BLReleaseAi"))

                    {
                        txtblno.Text = Request.QueryString["BLReleaseAi"].ToString();
                        txtblno_TextChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        [WebMethod]
        public static List<string> GetAIEBLDetails(string prefix)
        {
            List<string> List_Result = new List<string>();
            string trantype = HttpContext.Current.Session["StrTranType"].ToString();
            int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
            DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
            DataTable dt = new DataTable();
            dt = AEBLobj.GetLikeOTHERAIEBLDetails(prefix, trantype, bid, did);
            List_Result = Utility.Fn_TableToList(dt, "hawblno", "hawblno");
            return List_Result;
        }

        protected void lnk_bl_Click(object sender, EventArgs e)
        {
            try
            {
                div_BLDetails.Visible = true;
                div_BLvoucherdetail.Visible = false;
                div_BLfreigthdetail.Visible = false;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_blvoucher_Click(object sender, EventArgs e)
        {
            try
            {
                div_BLDetails.Visible = false;
                div_BLvoucherdetail.Visible = true;
                div_BLfreigthdetail.Visible = false;

                Grd_Invoice.Visible = true;
                Grd_DN.Visible = true;
                Grd_receipt.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void lnk_blfreight_Click(object sender, EventArgs e)
        {
            try
            {
                div_BLDetails.Visible = false;
                div_BLvoucherdetail.Visible = false;
                div_BLfreigthdetail.Visible = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void txtclear()
        {
            if (lbl_header.Text == "Booking #")
            {
                txtblno.Text = "";
            }
            else if (btnback.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                //   txtblno.Text = "";
                txtdate.Text = "";
                txtissue.Text = "";
                txtfreight.Text = "";
                txtjobno.Text = "";
                txtFlight.Text = "";
                txtManiFest.Text = "";
                txtMBL.Text = "";
                txtmlo.Text = "";
                txtagent.Text = "";
                txtbooking.Text = "";
                txtquot.Text = "";
                txtQuotCustomer.Text = "";
                txtmartketed.Text = "";
                txtshipper.Text = "";
                txtconsignee.Text = "";
                txtnotify1.Text = "";
                TxtNotify2.Text = "";
                txtpol.Text = "";
                txtfd.Text = "";
                txtCarrier1.Text = "";
                txtCarrier2.Text = "";
                txtCarrier3.Text = "";
                txtcnf.Text = "";
                txtcargo.Text = "";
                txtpackage.Text = "";
                txtcbm.Text = "";
                txtweight.Text = "";
                txthandling.Text = "";
                txtdesc.Text = "";
                txtothchg.Text = "";
                txtDOdate.Text = "";
                txtDOPDays.Text = "";


                txtbooking.Font.Bold = false;
                txtquot.Font.Bold = false;
                txtQuotCustomer.Font.Bold = false;

                btnprint.Visible = true;btnprint_id.Visible = true;

                Grd_DN.DataSource = null;
                Grd_DN.DataBind();

                Grd_freightdetail.DataSource = null;
                Grd_freightdetail.DataBind();

                Grd_Invoice.DataSource = null;
                Grd_Invoice.DataBind();

                Grd_receipt.DataSource = null;
                Grd_receipt.DataBind();
                txtjobno.Focus();
                 btnback.Text = "Back";

                btnback.ToolTip = "Back";
                btn_back1.Attributes["class"] = "btn ico-back";
                lnk_Creditdet.Visible = false;
                hid_CustomerId.Value = "";
                hidinvmailchk.Value = "";
                hidcustname.Value = "";
            }

            else
            {
                //this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "OPS&DOC")
                    {

                        if (Session["StrTranType"].ToString() == "AE")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }

                        else if (Session["StrTranType"].ToString() == "AI")
                        {

                            Response.Redirect("../Home/OEOpsAndDocs.aspx");
                        }
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

        protected void btnprint_Click(object sender, EventArgs e)
        {
            //DataAccess.AirImportExports.AIEBLDetails AIEBLObj = new DataAccess.AirImportExports.AIEBLDetails();
            try
            {
                if (txtblno.Text != "")
                {
                    string str_Script = "";
                    AIEBLObj.InsDelOrd(Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginEmpId"].ToString()), txtblno.Text, Convert.ToInt32(txtjobno.Text));
                    /*string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";
                    str_RptName = "rptDeliveryorder.rpt";
                    Session["str_sfs"] = "{AIBLDetails.hawblno}='" + txtblno.Text + "' and {AIBLDetails.bid}=" + Session["LoginBranchid"].ToString();
                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";*/
                    str_Script = "window.open('../Reportasp/deliveryorderAI.aspx?BLNO=" + txtblno.Text + "&" + this.Page.ClientQueryString + "','','');";
                    da_obj_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1417, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), txtblno.Text + "&View");
                    ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "BL  print", str_Script, true);
                    //Session["str_sp"] = str_sp; 
                }


                //  str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";  
                // Session["str_sfs"] = str_sf;       
                //str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                //str_Script = str_Script1 + ";" + str_Script2;
                //ScriptManager.RegisterStartupScript(btnPrint, typeof(Button), "Shipment Details", str_Script, true);
                //Session["str_sfs1"] = str_sf1;
                //Session["str_sp1"] = str_sp1;

                //newly added on mail sent
                if (hidinvmailchk.Value == "1")
                {

                    sendmail(txtblno.Text.Trim(), hidcustname.Value.ToString(), txtjobno.Text.Trim());
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void GetDetails()
        {
            try
            {
                DataTable DtDetails = new DataTable();
                DataTable Dt = new DataTable();
                DataTable dttn = new DataTable();
                DataTable dtrecptchk = new DataTable();
                //DataAccess.AirImportExports.AIEBLDetails AIEBLObj = new DataAccess.AirImportExports.AIEBLDetails();
                //DataAccess.ForwardingExports.BLPrinting FEBLPrint = new DataAccess.ForwardingExports.BLPrinting();
                //DataAccess.Corporate Corpobj = new DataAccess.Corporate();
                //DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
                //DataAccess.Accounts.Invoice invoiceobj = new DataAccess.Accounts.Invoice();
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
                int int_divisionid = int.Parse(Session["LoginDivisionId"].ToString());

                DtDetails = AIEBLObj.GetBLDetails4BLPrint(txtblno.Text, int_bid, Session["StrTranType"].ToString());

                if (DtDetails.Rows.Count > 0)
                {
                    txtdate.Text = DtDetails.Rows[0]["issuedon"].ToString();
                    txtissue.Text = DtDetails.Rows[0]["issueat"].ToString();
                    txtfreight.Text = DtDetails.Rows[0]["freight"].ToString();
                    txtjobno.Text = DtDetails.Rows[0]["jobno"].ToString();
                    txtFlight.Text = DtDetails.Rows[0]["flight"].ToString();
                    txtManiFest.Text = DtDetails.Rows[0]["manifest"].ToString();
                    txtMBL.Text = DtDetails.Rows[0]["mawblno"].ToString();
                    txtmlo.Text = DtDetails.Rows[0]["airliner"].ToString();
                    txtagent.Text = DtDetails.Rows[0]["agent"].ToString();
                    txtbooking.Text = DtDetails.Rows[0]["bookingno"].ToString();
                    txtquot.Text = DtDetails.Rows[0]["quotno"].ToString();
                    txtQuotCustomer.Text = DtDetails.Rows[0]["quotcust"].ToString();
                    txtmartketed.Text = DtDetails.Rows[0]["marketedby"].ToString();
                    txtshipper.Text = DtDetails.Rows[0]["shipper"].ToString();
                    txtconsignee.Text = DtDetails.Rows[0]["consignee"].ToString();
                    txtnotify1.Text = DtDetails.Rows[0]["notifyparty1"].ToString();
                    TxtNotify2.Text = DtDetails.Rows[0]["notifyparty2"].ToString();
                    txtpol.Text = DtDetails.Rows[0]["fromport"].ToString();
                    txtfd.Text = DtDetails.Rows[0]["toport"].ToString();
                    txtCarrier1.Text = DtDetails.Rows[0]["carrier1"].ToString();
                    txtCarrier2.Text = DtDetails.Rows[0]["carrier2"].ToString();
                    txtCarrier3.Text = DtDetails.Rows[0]["carrier3"].ToString();
                    txtcnf.Text = DtDetails.Rows[0]["cnf"].ToString();
                    txtcargo.Text = DtDetails.Rows[0]["cargo"].ToString();
                    txtpackage.Text = DtDetails.Rows[0]["packages"].ToString();
                    txtcbm.Text = DtDetails.Rows[0]["chargewt"].ToString();
                    txtweight.Text = DtDetails.Rows[0]["grosswt"].ToString();
                    txthandling.Text = DtDetails.Rows[0]["handling"].ToString();
                    txtdesc.Text = DtDetails.Rows[0]["descn"].ToString();
                    txtothchg.Text = DtDetails.Rows[0]["otherchg"].ToString();
                    txtDOdate.Text = DtDetails.Rows[0]["dodate"].ToString();
                    txtDOPDays.Text = DtDetails.Rows[0]["dopendingdays"].ToString();
                    nomination = DtDetails.Rows[0]["nomination"].ToString();
                    shiprefno = DtDetails.Rows[0]["shiprefno"].ToString();
                    customerid = Convert.ToInt32(DtDetails.Rows[0]["customerid"]);

                    txtbooking.Font.Bold = true;
                    txtquot.Font.Bold = true;
                    txtQuotCustomer.Font.Bold = true;

                }
                else
                {
                    txtclear();
                }

                Dt = FEBLPrint.GetBLPrintInvDt(txtblno.Text, Session["StrTranType"].ToString(), int_bid);
                if (Dt.Rows.Count > 0)
                {
                    Grd_Invoice.DataSource = Dt;
                    Grd_Invoice.DataBind();
                }
                else
                {
                    Grd_Invoice.DataSource = null;
                    Grd_Invoice.DataBind();
                }

                dttn = FEBLPrint.GetBLPrintDNDt(txtblno.Text, Session["StrTranType"].ToString(), int_bid);

                if (dttn.Rows.Count > 0)
                {
                    Grd_DN.DataSource = dttn;
                    Grd_DN.DataBind();
                }
                else
                {
                    Grd_DN.DataSource = null;
                    Grd_DN.DataBind();
                }

                DtDetails = FEBLPrint.GetBLPrintRcptDt(txtblno.Text, int_bid);
                if (DtDetails.Rows.Count > 0)
                {
                    Grd_receipt.DataSource = DtDetails;
                    Grd_receipt.DataBind();
                }
                else
                {
                    Grd_receipt.DataSource = null;
                    Grd_receipt.DataBind();
                }


                if (lbl_header.Text == " DO Details" && txtDOdate.Text == "")
                {
                    DataTable dtinvc = new DataTable();
                    dtinvc = FEBLPrint.GetBLPrintInvDtCHK(txtblno.Text, Session["StrTranType"].ToString(), int_bid);

                    if (dtinvc.Rows.Count > 0)
                    {
                        btnprint.Visible = true;btnprint_id.Visible = true;
                    }
                    else
                    {
                        //hide on 29092021 -- dhivya
                        //btnprint.Visible = false;btnprint_id.Visible = false;
                        //ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('There is No Invoice for this Shipment');", true);
                        //return;
                        if (hidnoinvchk.Value == "Y")
                        {
                            hidinvmailchk.Value = "1";
                            if (customerid != 0)
                            {
                                string custname = custobj.GetCustomername(customerid);
                                hidcustname.Value = custname;//added on 041021
                                if (Corpobj.GetGroupID(customerid, int_divisionid) != 0)
                                {
                                    if (custobj.CheckCreditException(txtblno.Text, "AI", int_bid) == "")
                                    {
                                        if (custobj.CheckCreditAmount(customerid, int_bid, int_divisionid) < 0)
                                        {

                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + custname + " has already reached the credit limit rupees " + custobj.GetCreditAmount(customerid, int_divisionid) + "This Shipment has been blocked, Hence you cannot print Bill of Lading.');", true);
                                            btnprint.Visible = false;btnprint_id.Visible = false;
                                            //Elengo
                                            CreatDetails(customerid);
                                            return;
                                        }
                                        //As per padhu sir instruction oct0721
                                        //else
                                        //{
                                        //    if (custobj.CheckCreditDays4Customer(customerid, int_divisionid) < 0)
                                        //    {
                                        //        if (custobj.GetCreditAmount(customerid, int_divisionid) > custobj.CheckCreditAmount(customerid, int_bid, int_divisionid))
                                        //        {
                                        //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + custname + " has already reached the credit limit Rs " + custobj.GetCreditAmount(customerid, int_divisionid) + "/" + custobj.GetCreditDays(customerid, int_divisionid) + " Days. " + "This Shipment has been blocked, Hence you cannot print Bill of Lading.');", true);
                                        //            btnprint.Visible = false;btnprint_id.Visible = false;
                                        //            //Elengo
                                        //            CreatDetails(customerid);
                                        //            return;
                                        //        }
                                        //    }
                                        //}

                                        btnprint.Enabled = true;
                                        btnprint.ForeColor = System.Drawing.Color.White;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (custobj.CheckCreditException(txtblno.Text, "AI", int_bid) == "")
                                    {
                                        dtrecptchk = FEBLPrint.GetBLPrintRcptDtchk(txtblno.Text, int_bid);
                                        if (dtrecptchk.Rows.Count > 0)
                                        {
                                            btnprint.Visible = true;btnprint_id.Visible = true;
                                        }
                                        else
                                        {
                                            btnprint.Visible = false;btnprint_id.Visible = false;
                                            txtcnf.Focus();
                                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this shipment Please Check with Accounts Department');", true);
                                            return;
                                        }
                                    }

                                }

                            }
                        }
                    } //end

                    if (customerid != 0)
                    {
                        string custname = custobj.GetCustomername(customerid);
                        if (Corpobj.GetGroupID(customerid, int_divisionid) != 0)
                        {
                            if (custobj.CheckCreditException(txtblno.Text, "AI", int_bid) == "")
                            {
                                if (custobj.CheckCreditAmount(customerid, int_bid, int_divisionid) < 0)
                                {

                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + custname + " has already reached the credit limit rupees " + custobj.GetCreditAmount(customerid, int_divisionid) + "This Shipment has been blocked, Hence you cannot print Bill of Lading.');", true);
                                    btnprint.Visible = false;btnprint_id.Visible = false;
                                    //Elengo
                                    CreatDetails(customerid);
                                    return;
                                }
                                //As per padhu sir instruction oct0721
                                //else
                                //{
                                //    if (custobj.CheckCreditDays4Customer(customerid, int_divisionid) < 0)
                                //    {
                                //        if (custobj.GetCreditAmount(customerid, int_divisionid) > custobj.CheckCreditAmount(customerid, int_bid, int_divisionid))
                                //        {
                                //            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('" + custname + " has already reached the credit limit Rs " + custobj.GetCreditAmount(customerid, int_divisionid) + "/" + custobj.GetCreditDays(customerid, int_divisionid) + " Days. " + "This Shipment has been blocked, Hence you cannot print Bill of Lading.');", true);
                                //            btnprint.Visible = false;btnprint_id.Visible = false;
                                //            //Elengo
                                //            CreatDetails(customerid);
                                //            return;
                                //        }
                                //    }
                                //}
                            }
                        }
                        else
                        {
                            if (custobj.CheckCreditException(txtblno.Text, "AI", int_bid) == "")
                            {
                                dtrecptchk = FEBLPrint.GetBLPrintRcptDtchk(txtblno.Text, int_bid);
                                if (dtrecptchk.Rows.Count > 0)
                                {
                                    btnprint.Visible = true;btnprint_id.Visible = true;
                                }
                                else
                                {
                                    btnprint.Visible = false;btnprint_id.Visible = false;
                                    txtcnf.Focus();
                                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this shipment Please Check with Accounts Department');", true);
                                    return;
                                }
                            }

                        }

                    }
                    else
                    {
                        Grd_receipt.DataSource = null;
                        Grd_receipt.DataBind();

                        DtDetails = FEBLPrint.GetBLPrintRcptDt(txtblno.Text, int_bid);
                        if (DtDetails.Rows.Count > 0)
                        {
                            Grd_receipt.DataSource = DtDetails;
                            Grd_receipt.DataBind();
                        }

                        if (Grd_Invoice.Rows.Count > 0)
                        {
                            dtrecptchk = FEBLPrint.GetBLPrintRcptDtchk(txtblno.Text, int_bid);

                            if (dtrecptchk.Rows.Count > 0)
                            {
                                btnprint.Visible = true;btnprint_id.Visible = true;
                            }
                            else
                            {
                                if (Grd_Invoice.Rows.Count > 0)
                                {
                                    if (rccnt != 1)
                                    {
                                        if (custobj.CheckCreditException(txtblno.Text, "AI", int_bid) == "")
                                        {
                                            Dt = invoiceobj.ShowIPHead(Convert.ToInt32(Grd_Invoice.Rows[0].Cells[0].Text), "AI", "Invoice", Convert.ToInt32(Session["Vouyear"].ToString()), int_bid);

                                            if (Dt.Rows.Count > 0)
                                            {
                                                if (Dt.Rows[0]["billtype"].ToString() == "I")
                                                {
                                                    return;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            btnprint.Visible = true;btnprint_id.Visible = true;
                                            return;

                                        }
                                    }

                                }

                                btnprint.Visible = false;btnprint_id.Visible = false;

                                txtcnf.Focus();
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "BLprint", "alertify.alert('We have not received the Payment for this freehand shipment.Please Check with Accounts Department');", true);
                                return;
                            }
                        }
                    }



                }
                else
                {
                    if (Session["StrTranType"].ToString() == "AI")
                    {
                        btnprint.Visible = true;btnprint_id.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txtblno_TextChanged(object sender, EventArgs e)
        {
            btnprint.Enabled = true;
            getvalue();
             btnback.Text = "Cancel";

            btnback.ToolTip = "Cancel";
            btn_back1.Attributes["class"] = "btn ico-cancel";


        }
        public void getvalue()
        {
            if (txtblno.Text != "")
            {
                int int_bid = int.Parse(Session["LoginBranchid"].ToString());
              //  DataAccess.ForwardingExports.BLPrinting FEBLPrint = new DataAccess.ForwardingExports.BLPrinting();
                DataTable Dt = new DataTable();
                 btnback.Text = "Cancel";

                btnback.ToolTip = "Cancel";
                btn_back1.Attributes["class"] = "btn ico-cancel";

                GetDetails();
                Dt = FEBLPrint.GetBLFreightDetails(txtblno.Text.Trim(), Session["StrTranType"].ToString(), int_bid);
                Grd_freightdetail.DataSource = Dt;
                Grd_freightdetail.DataBind();
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            txtclear();


        }

        protected void lnk_Quotation_Click(object sender, EventArgs e)
        {

        }

        protected void lnk_book_Click(object sender, EventArgs e)
        {

        }

        protected void lnk_back_Click(object sender, EventArgs e)
        {
            try
            {
                string type1 = Session["Queries"].ToString();
                Response.Redirect("../ForwardExports/Query.aspx?type='" + type1 + "'");
                return;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
            if (Session["StrTranType"] == "AE")
            {
                obj_dtlogdetails = da_obj_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1417, "Job", txtblno.Text, txtblno.Text, Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = da_obj_Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1417, "Job", txtblno.Text, txtblno.Text, Session["StrTranType"].ToString());
            }
            if (txtblno.Text != "")
            {
                JobInput.Text = txtblno.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        //Elengo
        public void CreatDetails(int Customerid)
        {
            hid_CustomerId.Value = Customerid.ToString();
            lnk_Creditdet.Visible = true;
        }

        protected void lnk_Creditdet_Click(object sender, EventArgs e)
        {
            try
            {
                this.PopCreditdet.Show();
                CustomerLbl1.InnerText = hid_customer.Value;
                grdCridtDet.DataSource = new DataTable();
                grdCridtDet.DataBind();
                //DataAccess.CreditException Crexobj = new DataAccess.CreditException();
                DataTable dtinv = Crexobj.GetCustInvOut(Convert.ToInt32(hid_CustomerId.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtinv.Rows.Count > 0)
                {
                    DataTable dtt = new DataTable();
                    DataRow dr;
                    dtt.Columns.Add("shortname");
                    dtt.Columns.Add("customername");
                    dtt.Columns.Add("invoiceno");
                    dtt.Columns.Add("invdate");
                    dtt.Columns.Add("days");
                    dtt.Columns.Add("osamount", typeof(Double));
                    dtt.Columns.Add("branchid");

                    for (int i = 0; i <= (dtinv.Rows.Count - 1); i++)
                    {
                        int invouno = Convert.ToInt32(dtinv.Rows[i]["vouno"].ToString());
                        DateTime invoudate = Convert.ToDateTime(dtinv.Rows[i]["voudate"].ToString());
                        int invodays = Convert.ToInt32(dtinv.Rows[i]["noofdays"].ToString());
                        string voutype = dtinv.Rows[i]["voutype"].ToString();
                        double invamount = Convert.ToDouble(dtinv.Rows[i]["osamount"].ToString());

                        dr = dtt.NewRow();
                        dr["shortname"] = dtinv.Rows[i]["shortname"].ToString();
                        dr["customername"] = dtinv.Rows[i]["customername"].ToString();
                        dr["invoiceno"] = voutype + " - " + invouno;
                        dr["invdate"] = invoudate.ToShortDateString();
                        dr["days"] = invodays.ToString();
                        dr["osamount"] = Math.Round(invamount, 2).ToString("#0.00");
                        dr["branchid"] = dtinv.Rows[i]["branchid"].ToString();
                        dtt.Rows.Add(dr);
                    }
                    //Total
                    DataRow dr1 = dtt.NewRow();
                    dr1[4] = "Total";
                    dr1[5] = dtt.Compute("Sum(osamount)", "");
                    dtt.Rows.Add(dr1);
                    DataView Dtview = dtt.DefaultView;
                    ////Branchwise filtering
                    //dt_check.RowFilter = "branchid = " + Convert.ToInt32(Session["LoginBranchid"]);
                    DataTable dtbrafil = Dtview.ToTable();
                    grdCridtDet.DataSource = dtbrafil;
                    grdCridtDet.DataBind();
                    grdCridtDet.Rows[grdCridtDet.Rows.Count - 1].Font.Bold = true;
                }
                else
                {
                    grdCridtDet.DataSource = new DataTable();
                    grdCridtDet.DataBind();
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdCridtDet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
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
                        if (i == 5)
                        {
                            //double dbl_temp = 0;
                            //if (double.TryParse(e.Row.Cells[i].Text.ToString(), out dbl_temp))
                            //{
                            //    e.Row.Cells[i].Text = string.Format("{0:#,##0.00}", dbl_temp);
                            //    e.Row.Cells[i].Attributes.CssStyle["text-align"] = "Right";
                            //}
                            double dbl_temp = Convert.ToDouble(e.Row.Cells[i].Text);
                            e.Row.Cells[i].Text = dbl_temp.ToString("#0.00");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grdCridtDet_PreRender(object sender, EventArgs e)
        {
            if (grdCridtDet.Rows.Count > 0)
            {
                grdCridtDet.UseAccessibleHeader = true;
                grdCridtDet.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        //send mail 
        public void sendmail(string blno, string custname,string jobno)
        {

          //  DataAccess.Masters.MasterBranch obj_da_Branch = new DataAccess.Masters.MasterBranch();
            string str_usermailid = Session["usermailid"].ToString();
            string str_mailpwd = Session["usermailpwd"].ToString();
            string branchshort = obj_da_Branch.GetShortName(Convert.ToInt32(Session["LoginBranchid"]));
            string trantype = Session["StrTranType"].ToString();
            if (trantype == "AI")
            {
                trantype = "AI";
            }
            else if (trantype == "FI")
            {
                trantype = "OI";
            }
            DataTable bmdt = new DataTable();

            DataSet mds;
            mds = obj_da_Branch.getbmrmid(Convert.ToInt32(Session["LoginBranchid"]));

            string Bmmail = "";

           

            if (mds.Tables.Count > 0)
            {
                bmdt = (DataTable)mds.Tables[0];

                if (bmdt.Rows.Count > 0)
                {
                    Bmmail = bmdt.Rows[0]["offmailid"].ToString();
                  
                }


            }
            sendqry = "";
            sendqry = sendqry + "<table width=100%><FONT FONT  SIZE=2 FACE=tahoma><tr><td align=left>Dear Sir / Madam,</td></tr></font></table><br>";
            sendqry = sendqry + "<table width=100%><FONT FACE=tahoma   SIZE=2><tr><td align=left>There is no invoice raised against the BL # " + blno + " and " + custname + " is credit customer. " + "<br>" + "Since you have requested to change the process to release the DO without invoice for credit customer, system has allowed to release the DO ." + "</td></tr></font></table><br>";
            sendqry = sendqry + "<table width=100%  CELLSPACING=0   ><FONT FACE=tahoma >";
            sendqry = sendqry + "<br><br>Auto Generated - Do not reply ";
            Utility.SendMailnew(str_usermailid, str_usermailid, " Mail for DO Wihtout Invoice : " + branchshort + " / " + trantype + " / Job # " + jobno + " / HAWBL # " + blno, sendqry, "", str_mailpwd, "VS@copperhawk.tech", Bmmail);//Bmmail          
        }
    }
}