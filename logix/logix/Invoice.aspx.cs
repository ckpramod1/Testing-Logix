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
using System.Text;
using System.IO;
using ClosedXML.Excel;
using System.Data.SqlClient;


namespace logix
{
    public partial class Invoice : System.Web.UI.Page
    {
        Calendar CldrFrom, CldrTo;
        DataTable Dt;//, DtCombined;
        Calendar CldrTemp = new Calendar();
        CustomerDataAccess.RegCustomer custObj = new CustomerDataAccess.RegCustomer();
        CustomerDataAccess.PODetails Logobj = new CustomerDataAccess.PODetails();
        public static int intCustID;
        public string voutype;
        public int intvouno, intBid;
        Global glObj = new Global();
        ReportShow rptObj;
        public string strFrom, strTo;


        public Global globj = new Global();
        public string strTranType;
        public static string strvtype;
        //public DataTable Dt = new DataTable();
        public DataTable dtCharge = new DataTable();
        public double total;
        //public DateTime dtdate;
        //ReportShow rptObj;
        public bool flagMBL = false;
        public int intBranchID, intJobNo;
        public DataSet dsTemp;
        public string strBLNo = "", strMBLNo = "";
        public int intVouYear, intVouNo;
        public string strpmtr;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //CldrFrom = new Calendar(this.Page, dtFrom, ImgFrom);
                //CldrTo = new Calendar(this.Page, dtTo, imgTo);
                //dtFrom.Text = DateTime.Today.AddDays(-60).ToString("dd/MM/yyyy");
                if (Session["username"] == null)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
                }
                DateTime dtmTMPSS = new DateTime();
                dtmTMPSS = DateTime.Now.AddDays(-30);
                //dtFrom.Text = dtmTMPSS.ToString("dd/MM/yyyy");
                dtFrom.Text = Convert.ToDateTime(DateTime.Now.AddDays(-90).ToShortDateString()).ToString("dd/MM/yyyy");
                dtTo.Text = Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");


                strFrom = Request.QueryString["from"];
                strTo = Request.QueryString["to"];
                if (strFrom != null)
                    dtFrom.Text = ConvertDateReverse(strFrom);

                if (strTo != null)
                    dtTo.Text = ConvertDateReverse(strTo);
            }
            intCustID = int.Parse(Request.QueryString["uid"].ToString());
            if (strFrom != null)
                BindInvoice();
        }

        public void BindInvoice()
        {
            intCustID = int.Parse(Request.QueryString["uid"].ToString());
            Dt = custObj.GetCustomerInvoiceAll(intCustID, DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text)), DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text)));
            grdInvoice.DataSource = Dt;
            grdInvoice.DataBind();
            ViewState["dt"] = Dt;
            if (Dt.Rows.Count != 0)
            {
                btnExcel.Enabled = true;
                lblError.Text = "";
            }
            else
            {
                btnExcel.Enabled = false;
                lblError.Text = "No data available";
            }
            custObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsVouchers, DateTime.Now, dtFrom.Text + " to " + dtTo.Text);
           /* for (int z = 0; z < grdInvoice.Rows.Count; z++)
            {
                ImageButton imgTemp;
                imgTemp = (ImageButton)grdInvoice.Rows[z].Cells[0].Controls[0];
                string strTempUrl = "";
                grdInvoice.SelectedIndex = z;
                voutype = grdInvoice.Rows[z].Cells[1].Text;
                //if (voutype != "OSSI")
                //  //  strTempUrl = "window.open('InvoiceReport.aspx?&blno=" + grdInvoice.SelectedRow.Cells[6].Text + "&uid=" + Request.QueryString["uid"].ToString() + "&vouno=" + grdInvoice.SelectedRow.Cells[2].Text + "&trantype=" + grdInvoice.SelectedRow.Cells[5].Text + "&vouyear=" + grdInvoice.SelectedDataKey["vouyear"].ToString() + "&branchid=" + grdInvoice.SelectedDataKey["branchid"].ToString() + "&voutype=" + grdInvoice.SelectedRow.Cells[1].Text + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text) + "','Accounts','menubar=0,toolbar=0,titlebar=no,close=0,resizable=0,width=580,height=465,top=100,left=100,scrollbars=0');return false;";
                //else
                //  //  strTempUrl = "window.open('OSDN.aspx?uid=" + Request.QueryString["uid"].ToString() + "&jobno=" + grdInvoice.SelectedRow.Cells[6].Text + "&trantype=" + grdInvoice.SelectedRow.Cells[5].Text + "&branchid=" + grdInvoice.SelectedDataKey["branchid"].ToString() + "','Accounts','menubar=0,toolbar=0,titlebar=no,close=0,resizable=0,width=690,height=500,top=100,left=100,scrollbars=0');return false;";
                imgTemp.Attributes.Add("OnClick", strTempUrl);
                grdInvoice.SelectedIndex = -1;
            }*/

           




        }





        

        protected void btnView_Click(object sender, EventArgs e)
        {
            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btnView, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }
            BindInvoice();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            if (BtnCancel.Text == "Cancel")
            {
                dtTo.Text = dtFrom.Text = CldrTemp.ConvertDate(DateTime.Today.Date.ToShortDateString());
                Dt = null;
                grdInvoice.DataSource = Dt;
                grdInvoice.DataBind();
                btnExcel.Enabled = false;
                //BindGrd(grdInvoice, pnlScroll);
                BtnCancel.Text = "Back";
            }
            else
            {
                //Response.Redirect("Default.aspx");
            }

        }

        protected void grdInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtnew = new DataTable();
            string voudate="";
            string strTranType = "";
            CustomerDataAccess.RegCustomer regCust = new CustomerDataAccess.RegCustomer();
            custObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsVouchers, DateTime.Now, grdInvoice.SelectedRow.Cells[2].Text + "-" + grdInvoice.SelectedRow.Cells[1].Text);
          // Response.Redirect("InvoiceReport.aspx?&blno=" + grdInvoice.SelectedRow.Cells[6].Text + "&uid=" + Request.QueryString["uid"].ToString() + "&vouno=" + grdInvoice.SelectedRow.Cells[1].Text + "&trantype=" + grdInvoice.SelectedRow.Cells[4].Text + "&vouyear=" + grdInvoice.SelectedDataKey["vouyear"].ToString() + "&branchid=" + grdInvoice.SelectedDataKey["branchid"].ToString() + "&voutype=" + grdInvoice.SelectedRow.Cells[2].Text + "&from=" + ConvertDate(dtFrom.Text) + "&to=" + ConvertDate(dtTo.Text));
            intBranchID =Convert.ToInt32(grdInvoice.SelectedDataKey["branchid"].ToString());
            strvtype = grdInvoice.SelectedRow.Cells[1].Text;
            intVouNo = Convert.ToInt32(grdInvoice.SelectedRow.Cells[2].Text);
            intVouYear = Convert.ToInt32(grdInvoice.SelectedDataKey["vouyear"].ToString());
            strTranType= grdInvoice.SelectedRow.Cells[5].Text;
            strBLNo = grdInvoice.SelectedRow.Cells[6].Text;
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
            switch (strvtype)
            {
                case "Invoice":
                    dsTemp = regCust.GetInvDetail4CustLogin(intVouNo, intBranchID, strTranType, intVouYear);
                    break;

                case "BOS":
                    dsTemp = regCust.GetBOSDetail4CustLogin(intVouNo, intBranchID, strTranType, intVouYear);
                    break;

                case "OSSI":
                    dsTemp = regCust.GetOSDNDetail4CustLogin(intVouNo, intBranchID, intVouYear, strTranType);
                    break;
                case "Debit Note":
                    dsTemp = regCust.GetOtherDNDetail4CustLogin(intVouNo, intBranchID, intVouYear, strTranType);
                    break;
            }
            dtnew = dsTemp.Tables[0];
            if (dtnew.Rows.Count != 0)
            {
                voudate = dtnew.Rows[0]["voudate"].ToString();
            }
            getreport(intVouNo, voudate, intVouYear, strTranType, strBLNo);



        }




        public void getreport(int intVouNo, string voudate, int intVouYear, string strTranType, string strBLNo)
        {

            DateTime get_date, GST_date;
            get_date = Convert.ToDateTime(Utility.fn_ConvertDate(voudate));
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
            if (strvtype == "Invoice")
            {
                //   strSF = "InvoiceHead.invoiceno~txtInvno~Num~=,InvoiceHead.vouyear~txtVouyear~Num~=,InvoiceHead.branchid~" + intBranchID + "~Num~=,InvoiceDetails.vouyear~txtVouyear~Num~=,InvoiceDetails.invoiceno~txtInvno~Num~=,InvoiceDetails.branchid~" + intBranchID + "~Num~=";
                //strSF = "{InvoiceHead.trantype}=\'" + strTranType + "\' and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                //if (flagMBL == false)
                //    strRptFN = strTranType + "Invoice.rpt";
                //else
                //    strRptFN = strTranType + "MInvoice.rpt";
                //strPM = "LCurr=INR~container=" + containernos;



                if (intVouNo.ToString() == "")
                {
                    str_RptName = "InvoiceRegister.rpt";
                    str_sf = "{InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear + " and {InvoiceHead.strtrantype}=\"" + strTranType + "\"";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" +intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Lcurr=INR~container=" + containernos;


                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&vouyear=" + intVouYear + "&strtrantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&vouyear=" + intVouYear + "&strtrantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" +intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                           // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" +intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" +intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";

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
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" +intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&trantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                   /* else if (strTranType == "CT" || strTranType == "WH" || strTranType == "TP")
                    {
                        if (get_date >= GST_date)
                        {
                           // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + intVouYear + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + intVouYear + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                        }
                    }*/
                }
                Session["LoginBranchid"] = intBranchID;
            }
            else if (strvtype == "BOS")
            {
                //   strSF = "InvoiceHead.invoiceno~txtInvno~Num~=,InvoiceHead.vouyear~txtVouyear~Num~=,InvoiceHead.branchid~" + intBranchID + "~Num~=,InvoiceDetails.vouyear~txtVouyear~Num~=,InvoiceDetails.invoiceno~txtInvno~Num~=,InvoiceDetails.branchid~" + intBranchID + "~Num~=";
                //strSF = "{InvoiceHead.trantype}=\'" + strTranType + "\' and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                //if (flagMBL == false)
                //    strRptFN = strTranType + "Invoice.rpt";
                //else
                //    strRptFN = strTranType + "MInvoice.rpt";
                //strPM = "LCurr=INR~container=" + containernos;



                if (intVouNo.ToString() == "")
                {
                    str_RptName = "InvoiceRegister.rpt";
                    str_sf = "{InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear + " and {InvoiceHead.strtrantype}=\"" + strTranType + "\"";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Lcurr=INR~container=" + containernos;


                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&vouyear=" + intVouYear + "&strtrantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&vouyear=" + intVouYear + "&strtrantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";

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
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&trantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                    //else if (strTranType == "CT" || strTranType == "WH" || strTranType == "TP")
                    //{
                    //    if (get_date >= GST_date)
                    //    {
                    //        // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + intVouYear + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                    //        str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + intVouYear + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
                    //        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    //    }
                    //}
                }
                Session["LoginBranchid"] = intBranchID;
            }

            else if (strvtype == "Debit Note")
            {
                //   strSF = "InvoiceHead.invoiceno~txtInvno~Num~=,InvoiceHead.vouyear~txtVouyear~Num~=,InvoiceHead.branchid~" + intBranchID + "~Num~=,InvoiceDetails.vouyear~txtVouyear~Num~=,InvoiceDetails.invoiceno~txtInvno~Num~=,InvoiceDetails.branchid~" + intBranchID + "~Num~=";
                //strSF = "{InvoiceHead.trantype}=\'" + strTranType + "\' and {InvoiceHead.invoiceno}=" + txtInvno.Text + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + txtVouyear.Text;
                //if (flagMBL == false)
                //    strRptFN = strTranType + "Invoice.rpt";
                //else
                //    strRptFN = strTranType + "MInvoice.rpt";
                //strPM = "LCurr=INR~container=" + containernos;



                if (intVouNo.ToString() == "")
                {
                    //str_RptName = "InvoiceRegister.rpt";
                    //str_sf = "{InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear + " and {InvoiceHead.strtrantype}=\"" + strTranType + "\"";
                    //str_sp = "Title=INVOICE REGISTER ";
                    //str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                    //ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Shipment Details", str_Script, true);
                    //Session["str_sfs"] = str_sf;
                    //Session["str_sp"] = str_sp;
                }
                else
                {
                    if (strTranType == "FE" || strTranType == "CT" || strTranType == "WH" || strTranType == "TP")
                    {
                        str_RptName = "FEInvoice.rpt";
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Lcurr=INR~container=" + containernos;


                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&vouyear=" + intVouYear + "&strtrantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&vouyear=" + intVouYear + "&strtrantype=" + strTranType + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "DN" + "&customertype=" + "P" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "DN" + "&customertype=" + "P" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "DN" + "&customertype=" + "P" + "','','');";
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
                        str_sf = "{InvoiceHead.strtrantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR";
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "DN" + "&customertype=" + "P" + "','','');";

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
                        str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + intVouNo.ToString() + "and {InvoiceHead.branchid}=" + intBranchID + "and {InvoiceHead.vouyear}=" + intVouYear;
                        str_sp = "Title=INVOICE REGISTER " + containernos;
                        str_sp = "Lcurr=INR~container=" + containernos;
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                        if (get_date >= GST_date)
                        {
                            //str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&trantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                            str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&strtrantype=" + strTranType + "&vouyear=" + intVouYear + "&blno=" + strBLNo + "&bltype=" + bltype + "&header=" + "DN" + "&customertype=" + "P" + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    }
                    //else if (strTranType == "CT" || strTranType == "WH" || strTranType == "TP")
                    //{
                    //    if (get_date >= GST_date)
                    //    {
                    //        // str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" +intVouNo.ToString() + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + intVouYear + "&bltype=" + bltype + "&header=" + "Invoice" + "','','');";
                    //        str_Script = "window.open('../Reportasp/InvoicerptFAnew.aspx?Invoiceno=" + intVouNo.ToString() + "&trantype=" + strTranType + "&blno=" + strBLNo + "&vouyear=" + intVouYear + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "','','');";
                    //        ScriptManager.RegisterStartupScript(btnView, typeof(Button), "Quotation", str_Script, true);
                    //    }
                    //}
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
            //rptObj = new ReportShow(strRptFN, strSF, strPM, "", btnView, this.Page, intBranchID.ToString());
        }
      

        public void BindGrd(GridView GrdTemp, Panel PnlTemp)
        {
            GrdTemp.DataSource = Dt;
            GrdTemp.DataBind();
            glObj.Scroll(GrdTemp, PnlTemp, 800, 380);
        }

        public DataTable CombineData(DataTable DtSource, DataTable dtNew)
        {
            DataTable dtTemp;
            dtTemp = new DataTable();
            dtTemp = DtSource;

            for (int i = 0; i < dtNew.Rows.Count; i++)
            {
                DataRow dtrow = dtTemp.NewRow();

                for (int j = 0; j < dtTemp.Columns.Count; j++)
                {
                    dtrow[j] = dtNew.Rows[i][j];
                }
                dtTemp.Rows.Add(dtrow);
            }
            return dtTemp;
        }
        protected void btnExcel_Click(object sender, EventArgs e)
        {
            /*//int[] intTempArray = { 1, 2, 3, 4, 5, 6, 7 };
            //DataTable dtToExcel = ConvertToExCel.ConvertGridToDtbl(grdInvoice, intTempArray);
            //custObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsVouchers, DateTime.Now, dtFrom.Text + " to " + dtTo.Text + "/Excel");
            //ConvertToExCel.SetData(dtToExcel, "Voucher(s).csv", ConvertToExCel.ConversionType.Excel);
            //Response.Redirect("ToExcel.aspx?pmtr=Table");


            string Str_SelectedText = "Vouchers";
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            //if (grdInvoice.Rows.Count > 0)
            //{
            //    Response.Clear();
            //    Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + ".xls");
            //    Response.Charset = "";
            //    //Response.ContentType = "application/vnd.ms-excel";
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    int cnt = grdInvoice.Columns.Count;
            //    SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + "</B></font></td></tr>");
            //    SB.Append("</table>");
            //    grdInvoice.GridLines = GridLines.Both;
            //    grdInvoice.HeaderStyle.Font.Bold = true;
            //    grdInvoice.RenderControl(HtmlTextWriter);
            //    string style = @"<style> .textmode { } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(StringWriter.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

            DataTable dt_check = ViewState["dt"] as DataTable;
            dt_check.Columns.Remove("branchid");
            if (grdInvoice.Rows.Count > 0)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt_check, "Vouchers");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Vouchers.xlsx");
                    using (MemoryStream mymemorystream = new MemoryStream())
                    {
                        wb.SaveAs(mymemorystream);
                        mymemorystream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }

            //DataTable dtTarget;
            //int[] intTempArray = { 1, 2, 3, 4, 5, 6, 7 };
            //dtTarget = ConvertToExCel.ConvertGridToDtbl(grdInvoice, intTempArray);
            //custObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsVouchers, DateTime.Now, dtFrom.Text + " to " + dtTo.Text + "/Excel");
            //ConvertToExCel.SetData(dtTarget, "Receipts.csv", ConvertToExCel.ConversionType.Excel);
            //btnExcel.Enabled = false;
            Response.Redirect("ToExcel.aspx?pmtr=Table");*/


            /* try
             {
                 if (grdInvoice.Rows.Count > 0)
                 {

                     Response.Clear();
                     Response.AddHeader("content-disposition", "Attachment;filename=" + "for the period of " + ".xls");
                     Response.Charset = "";
                     Response.ContentType = "application/vnd.xls";
                     StringBuilder SB = new StringBuilder();
                     StringWriter StringWriter = new System.IO.StringWriter(SB);
                     HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);


                     if (grdInvoice.Visible == true)
                     {
                         grdInvoice.GridLines = GridLines.Both;
                         grdInvoice.HeaderStyle.Font.Bold = true;
                         grdInvoice.RenderControl(HtmlTextWriter);
                     }
                     grdInvoice.Columns[0].Visible = false;
                     Response.Write(StringWriter.ToString());
                     //Response.Flush();
                     Response.End();
                 }
             }
             catch (Exception ex)
             {
                 string message = ex.Message.ToString();
                 ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
             }

             */

            DateTime FromDate;
            DateTime ToDate;

            FromDate = DateTime.Parse(CldrTemp.ConvertDate(dtFrom.Text));
            ToDate = DateTime.Parse(CldrTemp.ConvertDate(dtTo.Text));
            if (FromDate > ToDate)
            {
                ScriptManager.RegisterStartupScript(btnExcel, typeof(Button), "DataFound", "alertify.alert('From Date is Lesser than To Date');", true);
                return;
            }
            int[] intTempArray = { 1, 2, 3, 4, 5, 6, 7 };
            DataTable dtToExcel = ConvertToExCel.ConvertGridToDtbl(grdInvoice, intTempArray);
            custObj.InsWebCustLogDtl(intCustID, CustomerDataAccess.RegCustomer.EventType.AccountsVouchers, DateTime.Now, dtFrom.Text + " to " + dtTo.Text + "/Excel");
            ConvertToExCel.SetData(dtToExcel, "Voucher(s).csv", ConvertToExCel.ConversionType.Excel);

            string Str_SelectedText = "Vouchers";
            StringBuilder SB = new StringBuilder();
            StringWriter StringWriter = new System.IO.StringWriter(SB);
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            if (grdInvoice.Rows.Count > 0)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + Str_SelectedText + ".xls");
                Response.Charset = "";
                //Response.ContentType = "application/vnd.ms-excel";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                int cnt = grdInvoice.Columns.Count;
                SB.Append("<table BORDER=1 BORDERCOLOR=Black><tr><td align=left colspan=" + cnt + "><font face=arial size=3><B>" + Str_SelectedText + "</B></font></td></tr>");
                SB.Append("</table>");
                grdInvoice.Columns[0].Visible = false;
                grdInvoice.GridLines = GridLines.Both;
                grdInvoice.HeaderStyle.Font.Bold = true;
                grdInvoice.RenderControl(HtmlTextWriter);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(StringWriter.ToString());
                Response.Flush();
                Response.End();
            }



            /* Response.Clear();
             Response.Buffer = true;
             Response.AddHeader("content-disposition", "attachment;filename=ToExcel.xls");
             Response.Charset = "";
             Response.ContentType = "application/vnd.ms-excel";
             using (StringWriter sw = new StringWriter())
             {
                 HtmlTextWriter hw = new HtmlTextWriter(sw);

                 //To Export all pages
                 grdInvoice.AllowPaging = false;
                 this.BindInvoice();

            
                 foreach (TableCell cell in grdInvoice.HeaderRow.Cells)
                 {
                     cell.BackColor = grdInvoice.HeaderStyle.BackColor;
                 }
                 foreach (GridViewRow row in grdInvoice.Rows)
                 {
                  
                     foreach (TableCell cell in row.Cells)
                     {
                         if (row.RowIndex % 2 == 0)
                         {
                             cell.BackColor = grdInvoice.AlternatingRowStyle.BackColor;
                         }
                         else
                         {
                             cell.BackColor = grdInvoice.RowStyle.BackColor;
                         }
                         cell.CssClass = "textmode";
                     }
                 }


                 grdInvoice.Columns[0].Visible = false;

                 grdInvoice.RenderControl(hw);

                 //style to format numbers to string
                 string style = @"<style> .textmode { } </style>";
                 Response.Write(style);
                 Response.Output.Write(sw.ToString());
                 Response.Flush();
                 Response.End();
             }*/

        }
        public string ConvertDateReverse(string strSource)
        {
            //string strTemp = "";
            strSource = strSource.Replace('~', '/');
            return strSource;
        }
        public string ConvertDate(string strSource)
        {
            //string strTemp = "";
            strSource = strSource.Replace('/', '~');
            return strSource;
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }



    }
}