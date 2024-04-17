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
using DataAccess.Accounts;
using logix.FI;
using System.Runtime.Remoting;

namespace logix.AE
{
    public partial class AWBRelease : System.Web.UI.Page
    {
        DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCargo pckObj = new DataAccess.Masters.MasterCargo();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Corporate Corpobj = new DataAccess.Corporate();
        DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Accounts.OSDNCN OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.ForwardingExports.BLPrinting FEBLPrint = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
        DataAccess.Reportasp objRpt = new DataAccess.Reportasp();
        DataAccess.CreditException Crexobj = new DataAccess.CreditException();
        DataTable dt = new DataTable();

        DateTime bldate;
        int sloc, cloc, nloc, aloc;
        int cargo, intjobno, intcustomerid;
        string saddress, caddress, naddress, aaddress, ar;
        string freight, wtf, bookingno, incode, business;
        Double WCP, WCC, TOCDAP, TOCDAC, TOCDCC, TOCDCP;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                AEBLobj.GetDataBase(Ccode);
                custobj.GetDataBase(Ccode);
                pckObj.GetDataBase(Ccode);
                Corpobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                FIBLobj.GetDataBase(Ccode);
                FEBLobj.GetDataBase(Ccode);


                FEBLPrint.GetDataBase(Ccode);
                Logobj.GetDataBase(Ccode);
                obj_da_Log1.GetDataBase(Ccode);
                objRpt.GetDataBase(Ccode);
                Crexobj.GetDataBase(Ccode);


                



            }

            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btn_cancel);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (!IsPostBack)
            {

                if (Request.QueryString.ToString().Contains("BLReleaseNO"))
                {
                    txt_hawb.Text = Request.QueryString["BLReleaseNO"].ToString();
                    txt_hawb_TextChanged(sender, e);
                    //return;
                }
                hid_WCP.Value = "0";
                hid_WCC.Value = "0";
                hid_TOCDAP.Value = "0";
                hid_TOCDCP.Value = "0";
                hid_TOCDAC.Value = "0";
                hid_TOCDCC.Value = "0";
                 btn_cancel.Text = "Cancel";

                btn_cancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";

                ddl_cmbwttype.Items.Add("KGS");
                ddl_cmbwttype.Items.Add("LBS");

                if (Session["StrTranType"].ToString() == "AE")
                {
                    HeaderLabel1.InnerText = "Air Exports";
                }
                AEBLRelease_Load();
                if (Request.QueryString.ToString().Contains("BLReleaseNO"))

                {
                    txt_hawb.Text = Request.QueryString["BLReleaseNO"].ToString();
                    txt_hawb_TextChanged(sender, e);
                }
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
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            AEBLobj.GetDataBase(Ccode);
            DataTable dt = new DataTable();
            dt = AEBLobj.GetLikeOTHERAIEBLDetails(prefix, trantype, bid, did);
            List_Result = Utility.Fn_TableToList(dt, "hawblno", "hawblno");
            return List_Result;
        }

        private void AEBLRelease_Load()
        {
            ddl_awb.Items.Add("ORIGINAL - 3 (FOR SHIPPER)");
            ddl_awb.Items.Add("ORIGINAL - 2 (FOR CONSIGNEE)");
            ddl_awb.Items.Add("ACCOUNTS COPY");
            ddl_awb.Items.Add("ORIGINAL - 1 (FOR ISSUING AGENT)");
            ddl_awb.Items.Add("EXTRA - 1");
            ddl_awb.Items.Add("EXTRA - 2");
        }

        protected void txt_hawb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                DataTable DtAIEDetails = new DataTable();
                DataTable DtDetails = new DataTable();
                DataTable dtchrg = new DataTable();

                DtAIEDetails = AEBLobj.GetAIEDetail(txt_hawb.Text, trantype, bid, did);
                if (DtAIEDetails.Rows.Count > 0)
                {
                    if (DtAIEDetails.Rows[0]["sname"].ToString() == "")
                    {
                        txt_bldate.Text = Utility.fn_ConvertDate(DtAIEDetails.Rows[0]["issuedon"].ToString());
                        txt_ship.Text = DtAIEDetails.Rows[0]["Shipper"].ToString();
                        txt_consignee.Text = DtAIEDetails.Rows[0]["consignee"].ToString();
                        txt_notify.Text = DtAIEDetails.Rows[0]["notiFyparty1"].ToString();
                        txt_agent.Text = DtAIEDetails.Rows[0]["notiFyparty2"].ToString();
                        sloc = Convert.ToInt32(DtAIEDetails.Rows[0][27].ToString());
                        saddress = portobj.GetPortname(sloc);
                        txt_saddress.Text = custobj.GetCustomerAddress(txt_ship.Text, "Shipper", saddress);
                        // txt_saddress.Text = saddress;
                        cloc = Convert.ToInt32(DtAIEDetails.Rows[0][28].ToString());
                        caddress = portobj.GetPortname(cloc);
                        txt_caddress.Text = custobj.GetCustomerAddress(txt_consignee.Text, "Consignee", caddress);
                        // txt_caddress.Text = caddress;
                        nloc = Convert.ToInt32(DtAIEDetails.Rows[0][29].ToString());
                        naddress = portobj.GetPortname(nloc);
                        txt_naddress.Text = custobj.GetCustomerAddress(txt_notify.Text, "Notify Party", naddress);
                        //  txt_naddress.Text = naddress;
                        aloc = Convert.ToInt32(DtAIEDetails.Rows[0][30].ToString());
                        aaddress = portobj.GetPortname(aloc);
                        txt_aaddress.Text = custobj.GetCustomerAddress(txt_agent.Text, "Notify Party", aaddress);
                        //txt_aaddress.Text = aaddress;
                        txt_fromport.Text = DtAIEDetails.Rows[0]["fromport"].ToString();
                        txt_toport.Text = DtAIEDetails.Rows[0]["toport"].ToString();

                    }
                    else
                    {
                        DtAIEDetails = AEBLobj.GetAEBLDtls(txt_hawb.Text, bid, did);
                        if (DtAIEDetails.Rows.Count > 0)
                        {
                            txt_bldate.Text = Utility.fn_ConvertDate(DtAIEDetails.Rows[0]["issuedon"].ToString());
                            txt_ship.Text = DtAIEDetails.Rows[0]["Shipper"].ToString();
                            txt_consignee.Text = DtAIEDetails.Rows[0]["consignee"].ToString();
                            txt_notify.Text = DtAIEDetails.Rows[0]["notiFyparty1"].ToString();
                            txt_agent.Text = DtAIEDetails.Rows[0]["notiFyparty2"].ToString();
                            //txt_saddress.Text = custobj.GetCustomerAddress(txt_ship.Text, "Shipper", saddress);
                            //txt_caddress.Text = custobj.GetCustomerAddress(txt_ship.Text, "Consignee", saddress);
                            //txt_naddress.Text = custobj.GetCustomerAddress(txt_ship.Text, "Notify Party", saddress);
                            //txt_aaddress.Text = custobj.GetCustomerAddress(txt_ship.Text, "Notify Party", saddress);
                            //txt_fromport.Text = DtAIEDetails.Rows[0]["fromport"].ToString();
                            //txt_toport.Text = DtAIEDetails.Rows[0]["toport"].ToString();
                            sloc = Convert.ToInt32(DtAIEDetails.Rows[0][27].ToString());
                            saddress = portobj.GetPortname(sloc);
                            txt_saddress.Text = custobj.GetCustomerAddress(txt_ship.Text, "Shipper", saddress);
                            // txt_saddress.Text = saddress;
                            cloc = Convert.ToInt32(DtAIEDetails.Rows[0][28].ToString());
                            caddress = portobj.GetPortname(cloc);
                            txt_caddress.Text = custobj.GetCustomerAddress(txt_consignee.Text, "Consignee", caddress);
                            // txt_caddress.Text = caddress;
                            nloc = Convert.ToInt32(DtAIEDetails.Rows[0][29].ToString());
                            naddress = portobj.GetPortname(nloc);
                            txt_naddress.Text = custobj.GetCustomerAddress(txt_notify.Text, "Notify Party", naddress);
                            // txt_naddress.Text = naddress;
                            aloc = Convert.ToInt32(DtAIEDetails.Rows[0][30].ToString());
                            aaddress = portobj.GetPortname(aloc);
                            txt_aaddress.Text = custobj.GetCustomerAddress(txt_agent.Text, "Notify Party", aaddress);
                            // txt_aaddress.Text = aaddress;
                            txt_fromport.Text = DtAIEDetails.Rows[0]["fromport"].ToString();
                            txt_toport.Text = DtAIEDetails.Rows[0]["toport"].ToString();

                            //Changes Dinesh
                            txt_saddress.Text = DtAIEDetails.Rows[0]["saddress"].ToString();
                            txt_caddress.Text = DtAIEDetails.Rows[0]["caddress"].ToString();
                            txt_naddress.Text = DtAIEDetails.Rows[0]["n1address"].ToString();
                            txt_aaddress.Text = DtAIEDetails.Rows[0]["n2address"].ToString();
                            /*txt_fromport.Text = DtAIEDetails.Rows[0]["fromport"].ToString();
                            txt_toport.Text = DtAIEDetails.Rows[0]["toport"].ToString();*/
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alertify.alert('Invalid BL');", true);
                            txt_hawb.Focus();
                        }
                    }
                    txt_gross.Text = DtAIEDetails.Rows[0]["grosswt"].ToString();
                    if (!string.IsNullOrEmpty(DtAIEDetails.Rows[0]["agreedorrate"].ToString()))
                    {
                        ar = DtAIEDetails.Rows[0]["agreedorrate"].ToString();
                        if (ar == "A")
                        {
                            rdb_agreed.Checked = true;
                        }
                        else if (ar == "R")
                        {
                            rdb_rate.Checked = true;
                        }
                        else
                        {
                            rdb_agreed.Checked = false;
                            rdb_rate.Checked = false;
                        }
                    }

                    txt_charge.Text = DtAIEDetails.Rows[0]["CHARgewt"].ToString();
                    if (DtAIEDetails.Rows[0]["cargoid"].ToString() != "0" && DtAIEDetails.Rows[0]["cargoid"].ToString() != "")
                    {
                        cargo = Convert.ToInt32(DtAIEDetails.Rows[0]["cargoid"].ToString());
                        txt_commodity.Text = pckObj.GetCargoname(cargo);
                    }

                    freight = DtAIEDetails.Rows[0]["freight"].ToString();
                    intjobno = Convert.ToInt32(DtAIEDetails.Rows[0]["jobno"].ToString());
                    wtf = DtAIEDetails.Rows[0]["wttype"].ToString();

                    if (wtf == "K")
                    {
                        ddl_cmbwttype.SelectedValue = "KGS";
                    }
                    else
                    {
                        ddl_cmbwttype.SelectedValue = "LBS";
                    }
                    bookingno = "";
                    bookingno = FIBLobj.GetBookinkNo(txt_hawb.Text, bid, did);
                    DtDetails = FEBLobj.GetBookingDt(bookingno, bid, did);

                    if (DtDetails.Rows.Count > 0)
                    {
                        intcustomerid = Convert.ToInt32(DtDetails.Rows[0][13].ToString());
                        incode = DtDetails.Rows[0]["incocode"].ToString();
                        business = DtDetails.Rows[0]["business"].ToString();
                    }
                    //WCP = 0;
                    //WCC = 0;
                    //TOCDAP = 0;
                    //TOCDAC = 0;
                    //TOCDCP = 0;
                    //TOCDCC = 0;

                    dtchrg = AEBLobj.SelAEBLChargeDtls(intjobno, txt_hawb.Text, bid);
                    for (int i = 0; i <= dtchrg.Rows.Count - 1; i++)
                    {
                        int charge = Convert.ToInt32(dtchrg.Rows[i]["chargeid"].ToString());
                        string ppcc = dtchrg.Rows[i]["ppcc"].ToString();
                        if (charge == 1)
                        {
                            if (ppcc == "P")
                            {
                                WCP = Convert.ToDouble(dtchrg.Rows[i]["amount"].ToString());
                                hid_WCP.Value = WCP.ToString("#0.00");
                            }
                            else if (ppcc == "C")
                            {
                                WCC = Convert.ToDouble(dtchrg.Rows[i]["amount"].ToString());
                                hid_WCC.Value = WCC.ToString("#0.00");
                            }


                        }
                        if (charge == 2)
                        {
                            if (ppcc == "P")
                            {
                                TOCDAP = Convert.ToDouble(dtchrg.Rows[i]["amount"].ToString());
                                hid_TOCDAP.Value = TOCDAP.ToString("#0.00");
                            }

                            else if (ppcc == "C")
                            {
                                TOCDAC = Convert.ToDouble(dtchrg.Rows[i]["amount"].ToString());
                                hid_TOCDAC.Value = TOCDAC.ToString("#0.00");
                            }

                        }
                        if (charge == 3)
                        {
                            if (ppcc == "P")
                            {
                                TOCDCP = Convert.ToDouble(dtchrg.Rows[i]["amount"].ToString());
                                hid_TOCDCP.Value = TOCDCP.ToString("#0.00");
                            }

                            else if (ppcc == "C")
                            {
                                TOCDCC = Convert.ToDouble(dtchrg.Rows[i]["amount"].ToString());
                                hid_TOCDCC.Value = TOCDCC.ToString("#0.00");
                            }

                        }
                    }
                    //
                    if (business == "A" && incode == "EXW")
                    {
                        btn_draft.Enabled = true;
                        btn_original.Enabled = true;

                        btn_draft.ForeColor = System.Drawing.Color.White;
                        btn_original.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        if (freight != "C")
                        {
                            DataTable dti = new DataTable();
                            dti = FEBLPrint.GetBLPrintInvDt(txt_hawb.Text, trantype, bid);
                            if (dti.Rows.Count == 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alertify.alert('There is No Invoice for this Shipment');", true);
                                ddl_awb.Items.Clear();
                                ddl_awb.Items.Add("ORIGINAL - 2 (FOR CONSIGNEE)");
                                ddl_awb.Items.Add("ACCOUNTS COPY");
                                ddl_awb.Items.Add("ORIGINAL - 1 (FOR ISSUING AGENT)");
                                ddl_awb.Items.Add("EXTRA - 1");
                                ddl_awb.Items.Add("EXTRA - 2");
                                btn_draft.Enabled = true;
                                btn_original.Enabled = false;
                                btn_draft.ForeColor = System.Drawing.Color.White;
                                btn_original.ForeColor = System.Drawing.Color.Gray;
                                return;
                            }
                        }

                        if (Corpobj.GetGroupID(intcustomerid, did) != 0)
                        {
                            if (custobj.CheckCreditException(txt_hawb.Text, trantype, bid) == "")
                            {
                                if (custobj.CheckCreditAmount(intcustomerid, bid, did) < 0)
                                {
                                    ScriptManager.RegisterStartupScript(btn_original, typeof(Button), "DataFound", "alertify.alert('" + custobj.GetCustomername(Convert.ToInt32(intcustomerid)) + "has already reached the credit limit Rs." + custobj.GetCreditAmount(Convert.ToInt32(intcustomerid), did) + "This Shipment has blocked, Hence you cannot print Bill of Lading " + "');", true);
                                    ddl_awb.Items.Clear();
                                    ddl_awb.Items.Add("ORIGINAL - 2 (FOR CONSIGNEE)");
                                    ddl_awb.Items.Add("ACCOUNTS COPY");
                                    ddl_awb.Items.Add("ORIGINAL - 1 (FOR ISSUING AGENT)");
                                    ddl_awb.Items.Add("EXTRA - 1");
                                    ddl_awb.Items.Add("EXTRA - 2");
                                    btn_draft.Enabled = true;
                                    btn_original.Enabled = false;
                                    btn_draft.ForeColor = System.Drawing.Color.White;
                                    btn_original.ForeColor = System.Drawing.Color.Gray;
                                    //Elengo
                                    CreatDetails(intcustomerid);
                                    hid_CustomerName.Value = custobj.GetCustomername(Convert.ToInt32(intcustomerid));
                                    return;

                                }
                                else if (custobj.CheckCreditDays4Customer(intcustomerid, did) < 0)
                                {
                                    ScriptManager.RegisterStartupScript(btn_original, typeof(Button), "DataFound", "alertify.alert('" + custobj.GetCustomername(Convert.ToInt32(intcustomerid)) + "has already reached the credit limit Rs." + custobj.GetCreditAmount(Convert.ToInt32(intcustomerid), did) + "/" + custobj.GetCreditDays(Convert.ToInt32(intcustomerid), did) + "This Shipment has blocked, Hence you cannot print Bill of Lading" + "');", true);
                                    ddl_awb.Items.Clear();
                                    ddl_awb.Items.Add("ORIGINAL - 2 (FOR CONSIGNEE)");
                                    ddl_awb.Items.Add("ACCOUNTS COPY");
                                    ddl_awb.Items.Add("ORIGINAL - 1 (FOR ISSUING AGENT)");
                                    ddl_awb.Items.Add("EXTRA - 1");
                                    ddl_awb.Items.Add("EXTRA - 2");
                                    btn_draft.Enabled = true;
                                    btn_original.Enabled = false;
                                    btn_draft.ForeColor = System.Drawing.Color.White;
                                    btn_original.ForeColor = System.Drawing.Color.Gray;
                                    //Elengo
                                    CreatDetails(intcustomerid);
                                    hid_CustomerName.Value = custobj.GetCustomername(Convert.ToInt32(intcustomerid));
                                    return;
                                }
                                else
                                {
                                    ddl_awb.Items.Clear();
                                    AEBLRelease_Load();
                                    btn_original.Enabled = true;
                                    btn_original.ForeColor = System.Drawing.Color.White;
                                    btn_draft.ForeColor = System.Drawing.Color.Gray;

                                }

                            }
                            else
                            {
                                ddl_awb.Items.Clear();
                                AEBLRelease_Load();
                                btn_original.Enabled = true;
                                btn_original.ForeColor = System.Drawing.Color.White;
                                btn_draft.ForeColor = System.Drawing.Color.Gray;
                            }
                        }
                        else
                        {
                            DataTable DtDt = new DataTable();
                            if (custobj.CheckCreditException(txt_hawb.Text, trantype, bid) == "")
                            {
                                DtDt = FEBLPrint.GetBLPrintRcptDt(txt_hawb.Text, bid);
                                if (DtDt.Rows.Count > 0)
                                {
                                    ddl_awb.Items.Clear();
                                    AEBLRelease_Load();
                                    btn_original.Enabled = true;
                                    btn_original.ForeColor = System.Drawing.Color.White;
                                    btn_draft.ForeColor = System.Drawing.Color.Gray;
                                }
                                else if (freight == "C")
                                {
                                    DataTable dtosdn = new DataTable();
                                    dtosdn = OSDNCN.GetOSDCNDtls(intjobno, trantype, "OSSI", bid);
                                    if (dtosdn.Rows.Count > 0)
                                    {
                                        ddl_awb.Items.Clear();
                                        AEBLRelease_Load();
                                        btn_original.Enabled = true;
                                        btn_original.ForeColor = System.Drawing.Color.White;
                                        btn_draft.ForeColor = System.Drawing.Color.Gray;
                                    }
                                    else
                                    {

                                        // temporarily hide because OSDN  not enabled to create  start


                                        //ScriptManager.RegisterStartupScript(btn_original, typeof(Button), "DataFound", "alertify.alert('We have not received the Payment for this shipment" + "/" + "Please Check with Accounts Department" + "');", true);
                                        //ddl_awb.Items.Clear();
                                        //ddl_awb.Items.Add("ORIGINAL - 2 (FOR CONSIGNEE)");
                                        //ddl_awb.Items.Add("ACCOUNTS COPY");
                                        //ddl_awb.Items.Add("ORIGINAL - 1 (FOR ISSUING AGENT)");
                                        //ddl_awb.Items.Add("EXTRA - 1");
                                        //ddl_awb.Items.Add("EXTRA - 2");
                                        //btn_draft.Enabled = true;
                                        //btn_original.Enabled = false;
                                        //btn_draft.ForeColor = System.Drawing.Color.White;
                                        //btn_original.ForeColor = System.Drawing.Color.Gray;
                                        //return;


                                        //end 

                                        ddl_awb.Items.Clear();
                                        AEBLRelease_Load();
                                        btn_original.Enabled = true;
                                        btn_original.ForeColor = System.Drawing.Color.White;
                                        btn_draft.ForeColor = System.Drawing.Color.Gray;

                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(btn_original, typeof(Button), "DataFound", "alertify.alert('We have not received the Payment for this shipment" + "/" + "Please Check with Accounts Department" + "');", true);
                                    ddl_awb.Items.Clear();
                                    ddl_awb.Items.Add("ORIGINAL - 2 (FOR CONSIGNEE)");
                                    ddl_awb.Items.Add("ACCOUNTS COPY");
                                    ddl_awb.Items.Add("ORIGINAL - 1 (FOR ISSUING AGENT)");
                                    ddl_awb.Items.Add("EXTRA - 1");
                                    ddl_awb.Items.Add("EXTRA - 2");
                                    btn_draft.Enabled = true;
                                    btn_original.Enabled = false;
                                    btn_draft.ForeColor = System.Drawing.Color.White;
                                    btn_original.ForeColor = System.Drawing.Color.Gray;
                                    return;
                                }

                            }

                            else
                            {
                                ddl_awb.Items.Clear();
                                AEBLRelease_Load();
                                btn_original.Enabled = true;
                                btn_original.ForeColor = System.Drawing.Color.White;
                                btn_draft.ForeColor = System.Drawing.Color.Gray;
                                return;
                            }
                        }
                        txt_hawb.Enabled = false;
                        btn_cancel.Text = "Cancel";
                        btn_cancel.ToolTip = "Cancel";
                        btn_cancel1.Attributes["class"] = "btn ico-cancel";

                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alertify.alert('Please Enter Valid BL#');", true);
                    txt_hawb.Text = "";
                    txt_hawb.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            return;
        }
        protected void btn_yes_Click(object sender, EventArgs e)
        {
            return;
        }

        protected void btn_original_Click(object sender, EventArgs e)
        {
            try
            {
                //   Session["ViewBLRelease"] = "ViewBLRelease";
                string trantype = HttpContext.Current.Session["StrTranType"].ToString();
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                int did = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionid"].ToString());
                string str_RptName = "", str_RptName1 = "";
                string str_sf = "";
                string str_Script;
                string str_Script1;
                string str_sp = "";

                string str_sf1 = "";
                string str_sp1 = "";
                Session["str_sfs1"] = "";
                Session["str_sp1"] = "";
                Session["str_spae"] = "";
                Session["str_sfsae"] = "";
                //Session["str_sfs"] = "";
                //Session["str_sp"] = "";
                //str_frmname = "AEBLDetails";

                if (txt_hawb.Text != "" && ddl_awb.SelectedIndex != -1)
                {
                    if (rdb_agreed.Checked == true || rdb_rate.Checked == true)
                    {
                        if (rdb_agreed.Checked == true)
                        {
                            ar = "A";
                        }
                        else
                        {
                            ar = "R";
                        }

                        if (rdb_agreed.Checked == true)
                        {
                            ar = "A";
                        }
                        else
                        {
                            ar = "R";
                        }
                        AEBLobj.Updagreedrate(ar, txt_hawb.Text, bid);
                        AEBLobj.UpdAETextDtls(txt_ship.Text, txt_saddress.Text, txt_consignee.Text, txt_caddress.Text, txt_notify.Text, txt_naddress.Text, txt_agent.Text, txt_aaddress.Text, txt_fromport.Text, txt_toport.Text, txt_hawb.Text, bid);
                        AEBLobj.SPUpdAEhblreleasedon(txt_hawb.Text, int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                        //if (chk_notify.Checked)
                        //{
                        //    str_sp = "format=" + ddl_awb.Text + "~np=NO~WCP=" + hid_WCP.Value + "~WCC=" + hid_WCC.Value + "~TOCDAP=" + hid_TOCDAP.Value + "~TOCDAC=" + hid_TOCDAC.Value + "~TOCDCP=" + hid_TOCDCP.Value + "~TOCDCC=" + hid_TOCDCC.Value;
                        //}
                        //else
                        //{
                        //    str_sp = "format=" + ddl_awb.Text + "~np=YES~WCP=" + hid_WCP.Value + "~WCC=" + hid_WCC.Value + "~TOCDAP=" + hid_TOCDAP.Value + "~TOCDAC=" + hid_TOCDAC.Value + "~TOCDCP=" + hid_TOCDCP.Value + "~TOCDCC=" + hid_TOCDCC.Value;
                        //}


                        string np1 = "No", np2 = "No";
                        if (chk_notify.Checked)
                        {
                            np1 = "Yes";
                        }
                        if (chk_notify2.Checked)
                        {
                            np2 = "Yes";
                        }
                        str_sp = "format=" + ddl_awb.Text + "~np1=" + np1 + "~np2=" + np2 + "~WCP=" + hid_WCP.Value + "~WCC=" + hid_WCC.Value + "~TOCDAP=" + hid_TOCDAP.Value + "~TOCDAC=" + hid_TOCDAC.Value + "~TOCDCP=" + hid_TOCDCP.Value + "~TOCDCC=" + hid_TOCDCC.Value;

                        Session["str_sfsae"] = "{AEBLDetails.hawblno}='" + txt_hawb.Text + "'" + " and {AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                        //str_sf = "{AEBLDetails.hawblno}=" + txt_hawb.Text + "" + " and {AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                        //str_RptName1 = "AEBLOriginalText.rpt";
                        //str_Script1 = "window.open('../Tools/ReportView3.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";

                        //str_RptName = "AEBLOriginal.rpt";
                        //str_Script = "window.open('../Tools/ReportView3.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script = "window.open('../Reportasp/AEBLOriginal.aspx?hawblno=" + txt_hawb.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&format=" + ddl_awb.Text + "&WCP=" + hid_WCP.Value + "&WCC=" + hid_WCC.Value + "&TOCDAP=" + hid_TOCDAP.Value + "&TOCDAC=" + hid_TOCDAC.Value + "&TOCDCP=" + hid_TOCDCP.Value + "&TOCDCC=" + hid_TOCDCC.Value + "&np1=" + np1 + "&np2=" + np2 + "&draft=" + 0 + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script1 = "window.open('../Reportasp/AEBLOriginalText.aspx?&=" + this.Page.ClientQueryString + "','','');";

                        str_Script = str_Script1 + str_Script;
                        ScriptManager.RegisterStartupScript(btn_original, typeof(Button), "Shipment Details", str_Script, true);
                        //Session["str_sfs"] = str_sf;
                        Session["str_spae"] = str_sp;
                        Session["str_sfs1"] = str_sf1;
                        Session["str_sp1"] = str_sp1;





                        //DataAccess.LogDetails obj_da_Log1 = new DataAccess.LogDetails();
                        string date = Utility.fn_ConvertDate(obj_da_Log1.GetDate().ToShortDateString());
                        //DataAccess.Reportasp objRpt = new DataAccess.Reportasp();

                        objRpt.InsOEeventdetailsTask(0, txt_hawb.Text.ToString(), "", "BL /AWB Release",
                       Convert.ToDateTime(Utility.fn_ConvertDate(date.ToString())), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), 0, "", 14);

                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1258, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_hawb.Text + "-" + "Original");

                        // ScriptManager.RegisterStartupScript(btn_original, typeof(Button), "alert", "alertify.alert('Updated');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_original, typeof(Button), "alert", "alertify.alert('Select Agreed Or Rate');", true);

                    }


                }
                else if (txt_hawb.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_draft, typeof(Button), "alert", "alertify.alert('BL# Cannot be Blank');", true);
                    txt_hawb.Focus();
                }
                else if (ddl_awb.SelectedIndex != -1)
                {
                    ScriptManager.RegisterStartupScript(btn_draft, typeof(Button), "alert", "alertify.alert('BL Format Cannot be Blank');", true);
                    ddl_awb.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_draft_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ViewBLRelease"] = "ViewBLRelease";
                int bid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                string sp = "";
                string str_RptName = "";
                string str_sf = "";
                string str_Script;
                string str_sp = "";
                //Session["str_sfs"] = "";
                //Session["str_sp"] = "";
                //str_frmname = "AEBLDetails";
                str_RptName = "AEBLOriginalDraft.rpt";


                if (txt_hawb.Text != "" && ddl_awb.SelectedIndex != -1)
                {
                    if (rdb_agreed.Checked == true || rdb_rate.Checked == true)
                    {
                        if (rdb_agreed.Checked == true)
                        {
                            ar = "A";
                        }
                        else
                        {
                            ar = "R";
                        }

                        AEBLobj.Updagreedrate(ar, txt_hawb.Text, bid);
                        AEBLobj.UpdAETextDtls(txt_ship.Text, txt_saddress.Text, txt_consignee.Text, txt_caddress.Text, txt_notify.Text, txt_naddress.Text, txt_agent.Text, txt_aaddress.Text, txt_fromport.Text, txt_toport.Text, txt_hawb.Text, bid);
                        //if (chk_notify.Checked)
                        //{


                        //    str_sp = "format=" + ddl_awb.Text + "~np=NO~WCP=" + hid_WCP.Value + "~WCC=" + hid_WCC.Value + "~TOCDAP=" + hid_TOCDAP.Value + "~TOCDAC=" + hid_TOCDAC.Value + "~TOCDCP=" + hid_TOCDCP.Value + "~TOCDCC=" + hid_TOCDCC.Value;
                        //}
                        //else
                        //{
                        //    str_sp = "format=" + ddl_awb.Text + "~np=YES~WCP=" + hid_WCP.Value + "~WCC=" + hid_WCC.Value + "~TOCDAP=" + hid_TOCDAP.Value + "~TOCDAC=" + hid_TOCDAC.Value + "~TOCDCP=" + hid_TOCDCP.Value + "~TOCDCC=" + hid_TOCDCC.Value;
                        //}
                        string np1 = "No", np2 = "No";
                        if (chk_notify.Checked)
                        {
                            np1 = "Yes";
                        }
                        if (chk_notify2.Checked)
                        {
                            np2 = "Yes";
                        }
                        str_sp = "format=" + ddl_awb.Text + "~np1=" + np1 + "~np2=" + np2 + "~WCP=" + hid_WCP.Value + "~WCC=" + hid_WCC.Value + "~TOCDAP=" + hid_TOCDAP.Value + "~TOCDAC=" + hid_TOCDAC.Value + "~TOCDCP=" + hid_TOCDCP.Value + "~TOCDCC=" + hid_TOCDCC.Value;
                        Session["str_sfs1"] = "{AEBLDetails.hawblno}='" + txt_hawb.Text + "'" + " and {AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                        // str_sf = "{AEBLDetails.hawblno}=\"" + txt_hawb.Text + "'" + " and {AEBLDetails.bid}=" + Convert.ToInt32(Session["LoginBranchid"].ToString());
                        //str_Script = "window.open('../Tools/ReportView3.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        str_Script = "window.open('../Reportasp/AEBLOriginal.aspx?hawblno=" + txt_hawb.Text + "&bid=" + Convert.ToInt32(Session["LoginBranchid"].ToString()) + "&format=" + ddl_awb.Text + "&WCP=" + hid_WCP.Value + "&WCC=" + hid_WCC.Value + "&TOCDAP=" + hid_TOCDAP.Value + "&TOCDAC=" + hid_TOCDAC.Value + "&TOCDCP=" + hid_TOCDCP.Value + "&TOCDCC=" + hid_TOCDCC.Value + "&np1=" + np1 + "&np2=" + np2 + "&draft=" + 1 + "&" + this.Page.ClientQueryString + "','','');";

                        ScriptManager.RegisterStartupScript(btn_draft, typeof(Button), "Shipment Details", str_Script, true);
                        //   Session["str_sfs"] = str_sf;
                        Session["str_sp1"] = str_sp;
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1258, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), txt_hawb.Text + "-" + "Original");


                        //ScriptManager.RegisterStartupScript(btn_draft, typeof(Button), "alert", "alertify.alert('Updated');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btn_draft, typeof(Button), "alert", "alertify.alert('Select Agreed Or Rate');", true);

                    }


                }
                else if (txt_hawb.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btn_draft, typeof(Button), "alert", "alertify.alert('BL# Cannot be Blank');", true);
                    txt_hawb.Focus();
                }
                else if (ddl_awb.SelectedIndex != 0)
                {
                    ScriptManager.RegisterStartupScript(btn_draft, typeof(Button), "alert", "alertify.alert('BL Format Cannot be Blank');", true);
                    ddl_awb.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            //this.PopUpService.Show();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.ToolTip == "Cancel")
            {
                JobInput.Text = "";
                txt_hawb.Enabled = true;
                txt_bldate.Text = "";
                txt_hawb.Text = "";
                txt_ship.Text = "";
                txt_consignee.Text = "";
                txt_notify.Text = "";
                txt_agent.Text = "";
                txt_saddress.Text = "";
                txt_caddress.Text = "";
                txt_naddress.Text = "";
                txt_aaddress.Text = "";
                txt_gross.Text = "";
                txt_charge.Text = "";
                txt_commodity.Text = "";
                btn_cancel.Text = "Back";

                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";


                txt_fromport.Text = "";
                txt_toport.Text = "";
                rdb_agreed.Checked = false;
                rdb_rate.Checked = false;
                if (chk_notify.Checked == true)
                {
                    chk_notify.Checked = false;
                }
                ddl_awb.Items.Clear();
                //ddl_cmbwttype.Items.Clear();
                ddl_cmbwttype.SelectedIndex = 0;
                btn_original.Enabled = true;
                btn_original.ForeColor = System.Drawing.Color.White;
                btn_draft.Enabled = true;
                btn_draft.ForeColor = System.Drawing.Color.White;
                btn_cancel.Text = "Back";
                btn_cancel.ToolTip = "Back";
                btn_cancel1.Attributes["class"] = "btn ico-back";
                lnk_Creditdet.Visible = false;
                hid_CustomerId.Value = "";
                hid_CustomerName.Value = "";
            }
            else
            {
                // this.Response.End();

                if (Request.QueryString.ToString().Contains("BLReleaseNO"))
                {
                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                }
                else
                {
                    this.Response.End();
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

            obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1258, "BLREL", txt_hawb.Text, txt_hawb.Text, "");  //"/Rate ID: " +
            if (txt_hawb.Text != "")
            {
                JobInput.Text = txt_hawb.Text;
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
                CustomerLbl1.InnerText = hid_CustomerName.Value;
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


    }
}

