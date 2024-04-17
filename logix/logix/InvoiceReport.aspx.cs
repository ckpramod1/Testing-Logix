using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace logix
{
    public partial class InvoiceReport : System.Web.UI.Page
    {
        CustomerDataAccess.RegCustomer regCust = new CustomerDataAccess.RegCustomer();

        public Global globj = new Global();
        public string strTranType;
        public static string strvtype;
        public DataTable Dt = new DataTable();
        public DataTable dtCharge = new DataTable();
        public double total;
        //public DateTime dtdate;
        ReportShow rptObj;
        public bool flagMBL = false;
        public int intBranchID, intJobNo;
        public DataSet dsTemp;
        public string strBLNo = "", strMBLNo = "";
        public int intVouYear, intVouNo;
        public string strpmtr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (!IsPostBack)
            {
                txtInvno.Text = Request.QueryString["vouno"];
                strTranType = Request.QueryString["trantype"];
                intVouNo = int.Parse(txtInvno.Text);

                switch (strTranType)
                {
                    case "Ocean Exports":
                        strTranType = "FE";
                        break;
                    case "Ocean Imports":
                        strTranType = "FI";
                        break;
                    case "Air Exports":
                        strTranType = "AE";
                        break;
                    case "Air Imports":
                        strTranType = "AI";
                        break;
                    case "CHA":
                        strTranType = "CH";
                        break;
                }
                intBranchID = int.Parse(Request.QueryString["branchid"].ToString());
                strvtype = Request.QueryString["voutype"].ToString();
                intVouYear = int.Parse(Request.QueryString["vouyear"].ToString());
                lblhead.Text = strvtype;
                txtVouyear.Text = Request.QueryString["vouyear"].ToString();
                if (strvtype == "Debit Note" || strvtype == "OSSI")
                {
                    lblhead.Text = strvtype;
                    lblNO.Text = "DN #";
                    lblinvdate.Text = "DN Date";
                }
                txtInvno_TextChanged(sender, e);
                //if (strvtype == "Debit Note")
                //{ DNReport(); }
                //else
                //{ getreport(); }
            }
        }

        protected void txtInvno_TextChanged(object sender, EventArgs e)
        {
            switch (strvtype)
            {
                case "Invoice":
                    dsTemp = regCust.GetInvDetail4CustLogin(intVouNo, intBranchID, strTranType, intVouYear);
                    break;

                case "OSSI":
                    dsTemp = regCust.GetOSDNDetail4CustLogin(intVouNo, intBranchID, intVouYear, strTranType);
                    break;
                case "Debit Note":
                    dsTemp = regCust.GetOtherDNDetail4CustLogin(intVouNo, intBranchID, intVouYear, strTranType);
                    break;
            }
            Dt = dsTemp.Tables[0];
            dtCharge = dsTemp.Tables[1];
            string[] chrTemp = { "~~~" };
            if (Dt.Rows.Count != 0)
            {
                dtinvoice.Text = Dt.Rows[0]["voudate"].ToString();
                txtVouyear.Text = intVouYear.ToString();
                string[] strTempCust = Dt.Rows[0]["customer"].ToString().Split(chrTemp, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < strTempCust.Length; x++)
                {
                    if (x == 0)
                        txtCustomer.Text += strTempCust[x];
                    else
                        txtCustomer.Text += '\n' + strTempCust[x];
                }

                string[] strTempSpmt = Dt.Rows[0]["shipment"].ToString().Split(chrTemp, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < strTempSpmt.Length; x++)
                {
                    if (x == 0)
                        txtShipment.Text += strTempSpmt[x];
                    else
                        txtShipment.Text += '\n' + strTempSpmt[x];
                }
                strBLNo = Request.QueryString["blno"].ToString();
                strMBLNo = Dt.Rows[0]["mblno"].ToString();
                if (strMBLNo == strBLNo)
                    flagMBL = true;
                else
                    flagMBL = false;
            }

            total = 0;
            //if (strvtype == "Invoice")
            //{
            GrdInvRpt.DataSource = dtCharge;
            GrdInvRpt.DataBind();
            PnlGrd.Visible = true;
            for (int i = 0; i < GrdInvRpt.Rows.Count; i++)
            {
                total = total + double.Parse(GrdInvRpt.Rows[i].Cells[5].Text);
            }
            //}
            //else
            //{
            //    GrdOSDN.DataSource = dtCharge;
            //    GrdOSDN.DataBind();
            //    PnlOSDN.Visible = true;
            //    for (int i = 0; i < GrdOSDN.Rows.Count; i++)
            //    {
            //        total = total + double.Parse(GrdOSDN.Rows[i].Cells[3].Text);
            //    }            
            //}
            getreport();
            if (total.ToString().IndexOf('.') == -1)
                txttotal.Text = total.ToString() + ".00";
            else
                txttotal.Text = total.ToString();
        }

        public void getreport()
        {

            DateTime get_date, GST_date;
            get_date = Convert.ToDateTime(Utility.fn_ConvertDate(dtinvoice.Text));
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            string containernos = "";
            int i;
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            string bltype = "";
            string strRptFN = "", strPM = "", strSF = "";
            strPM = "LCurr=INR";
            bltype = "H";
            if (strvtype == "Invoice")
            {
             //   strSF = "InvoiceHead.invoiceno~txtInvno~Num~=,InvoiceHead.vouyear~txtVouyear~Num~=,InvoiceHead.branchid~" + intBranchID + "~Num~=,InvoiceDetails.vouyear~txtVouyear~Num~=,InvoiceDetails.invoiceno~txtInvno~Num~=,InvoiceDetails.branchid~" + intBranchID + "~Num~=";
                //strSF = "{InvoiceHead.trantype}=\'" + strTranType + "\' and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                //if (flagMBL == false)
                //    strRptFN = strTranType + "Invoice.rpt";
                //else
                //    strRptFN = strTranType + "MInvoice.rpt";
                //strPM = "LCurr=INR~container=" + containernos;

               

                if (txtInvno.Text == "")
                {
                    str_RptName = "InvoiceRegister.rpt";
                    str_sf = "{InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text + " and {InvoiceHead.trantype}=\"" + strTranType + "\"";
                    str_sp = "Title=INVOICE REGISTER ";
                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                    ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Shipment Details", str_Script, true);
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
                else
                {
                    if (strTranType == "FE" || strTranType == "CT" || strTranType == "WH" || strTranType == "TP")
                    {
                        str_RptName = "FEInvoice.rpt";
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                        str_sp = "Lcurr=INR~container=" + containernos;


                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&vouyear=" + txtVouyear.Text + "&trantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";

                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&vouyear=" + txtVouyear.Text + "&trantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                    else if (strTranType == "FI")
                    {
                        str_RptName = "FIInvoice.rpt";
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //  str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                    else if (strTranType == "AE")
                    {
                        str_RptName = "AEInvoice.rpt";
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                           // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";

                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                    else if (strTranType == "AI")
                    {
                        str_RptName = "AIInvoice.rpt";
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                          //  str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                    else if (strTranType == "CH")
                    {
                        str_RptName = "CHInvoice.rpt";
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                           // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&vouyear=" + txtVouyear.Text + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                    else if (strTranType == "CT" || strTranType == "WH" || strTranType == "TP")
                    {
                        if (get_date >= GST_date)
                        {
                           // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + txtVouyear.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";

                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + txtInvno.Text + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + txtVouyear.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                        }
                    }
                }
                Session["LoginBranchid"] = intBranchID;
            }
            else if (strvtype == "OSSI")
            {
                strPM = "FCurr=INR/module=" + strTranType + "~jobno=" + intJobNo;
                strSF = "OSDN.dnno~txtInvno~Num~=,OSDN.vouyear~txtVouyear~Num~=,OSDN.branchid~" + intBranchID + "~Num~=_MasterBranch.branchid~" + intBranchID + "~Num~=";
                strRptFN = strTranType + "OSDN.rpt/SOA1.rpt";
            }
            else
            {
                strPM = "Lcurr=INR";
                strSF = "DNHead.trantype~" + strTranType + "~Text~=,DNHead.dnno~txtInvno~Num~=,DNHead.branchid~" + intBranchID + "~Num~=,DNHead.vouyear~txtVouyear~Num~=,DNDetails.vouyear~txtVouyear~Num~=";
                if (flagMBL == false)
                    strRptFN = strTranType + "DN.rpt";
                else
                    strRptFN = strTranType + "MDN.rpt";
            }
            rptObj = new ReportShow(strRptFN, strSF, strPM, "", btnView, this.Page, intBranchID.ToString());
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Invoice.aspx?lgs=1&uid=" + Request.QueryString["uid"]);
            strpmtr = "?lgs=1&uid=" + Request.QueryString["uid"] + "&from=" + Request.QueryString["from"] + "&to=" + Request.QueryString["to"];
            Response.Redirect("Invoice.aspx" + strpmtr);
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            regCust.InsWebCustLogDtl(int.Parse(Session["webgroupid"].ToString()), CustomerDataAccess.RegCustomer.EventType.AccountsVouchers, DateTime.Now, intBranchID + "-" + strTranType + "-" + strvtype + "-" + txtInvno.Text + "/Print");
        }
    }
}