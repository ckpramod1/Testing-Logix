using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Web.Security;
using DataAccess.Accounts;

namespace logix.Accounts
{
    public partial class ApprovedLV : System.Web.UI.Page
    {
        DataAccess.Accounts.Approval appobj = new DataAccess.Accounts.Approval();
        DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.CustomHousingAgent.JobInfo CHAobj = new DataAccess.CustomHousingAgent.JobInfo();
        DataAccess.ForwardingImports.JobInfo FIJobobj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.AirImportExports.AIEJobInfo AEJobobj = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.AirImportExports.AIEBLDetails AEBLobj = new DataAccess.AirImportExports.AIEBLDetails();
        DataAccess.Accounts.CostingDt Costobj = new DataAccess.Accounts.CostingDt();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterPort portobj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterEmployee Empobj = new DataAccess.Masters.MasterEmployee();
        DataAccess.HR.Employee hrempobj = new DataAccess.HR.Employee();
        DataAccess.Accounts.OSDNCN OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.ForwardingExports.BLDetailsWOJob FEBLWoJobj = new DataAccess.ForwardingExports.BLDetailsWOJob();
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.Marketing.Quotation Quotobj = new DataAccess.Marketing.Quotation();
        DataAccess.FAVoucher FAobj = new DataAccess.FAVoucher();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
        string branch, division;
        string billtype, voutype;
        int customerid, salesid, ijobtype;
        int branchid, divisionid, consignee, shipper;
        string frmname, strTranType;
        string extype;
        DataTable Dt = new DataTable();
        DataTable DtConDetails, DtCon = new DataTable();
        string vessel, voyage, agent, jobtype;
        DateTime eta;
        DataTable DtInfo = new DataTable();
        string volume, wt;
        int JobNumner;
        string vtype;
        DataTable DtSHead = new DataTable();
        int custid, supplytoid, intsupplytoid;
        string city, citysupplyid;
        int cityid, intcustid, approvedby;
        string fatransfer;
        DateTime voudate;
        string blno;
        bool returnval = false;
        string cust;
        string str_Uiid = "", str_FornName;
        string bill;
        DataTable dtfa = new DataTable();
        int voutypeid;
        string FADbName, str_dispyear;
        string vname = "";
        string vouno;
        string refno;
        int i, BranchID;

        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                FEJobobj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                FEBLobj.GetDataBase(Ccode);
                appobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                FEJobobj.GetDataBase(Ccode);
                DCAdviseObj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
                FIBLobj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                DCAdviseObj.GetDataBase(Ccode);
                CHAobj.GetDataBase(Ccode);
                FIJobobj.GetDataBase(Ccode);
                OSDNCN.GetDataBase(Ccode);
                AEJobobj.GetDataBase(Ccode);
                AEBLobj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                Costobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                portobj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
                Empobj.GetDataBase(Ccode);
                hrempobj.GetDataBase(Ccode);
                OSDNCN.GetDataBase(Ccode);
                FEBLWoJobj.GetDataBase(Ccode);


                Logobj.GetDataBase(Ccode);
                Quotobj.GetDataBase(Ccode);
                FAobj.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                obj_da_Logobj.GetDataBase(Ccode);
                //customerobj.GetDataBase(Ccode);
                //ProINVobj.GetDataBase(Ccode);
                //DCAdviseObj.GetDataBase(Ccode);
                //chargeobj.GetDataBase(Ccode);


            }
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

                lbnl_logyear.Text = Session["LYEAR"].ToString();
                if (Request.QueryString.ToString().Contains("type"))
                {
                    if (Request.QueryString["type"].ToString() == "Purchase Invoice")
                    {
                        frmname = "Purchase Invoice";
                    }
                    else
                    {
                        frmname = Request.QueryString["type"].ToString();
                    }
                    //  
                }
                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    frmname = Request.QueryString["FormName"].ToString();
                }
                hf_LogBr_ID.Value = Session["LoginBranchid"].ToString();

                //if (Session["StrTranType"].ToString() == "FE")
                //{
                //    lblHead.InnerText = "Ocean Exports";
                //    homelbl.Visible = true;
                //}
                //else if (Session["StrTranType"].ToString() == "FI")
                //{
                //    lblHead.InnerText = "Ocean Imports";
                //    homelbl.Visible = true;
                //} 
                //else if (Session["StrTranType"].ToString() == "AE")
                //{
                //    lblHead.InnerText = "Air Exports";
                //    homelbl.Visible = true;
                //}
                //else if (Session["StrTranType"].ToString() == "AI")
                //{
                //    lblHead.InnerText = "Air Imports";
                //    homelbl.Visible = true;
                //}
                //else if (Session["StrTranType"].ToString() == "CH")
                //{
                //    lblHead.InnerText = "Custom House Agent";
                //}

                try
                {
                    Session["mblchk"] = "false";
                    Session["cmbbill"] = "Select";
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        lbl_InvHeader.Text = Request.QueryString["type"].ToString();
                    }
                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_InvHeader.Text = Request.QueryString["FormName"].ToString();
                    }
                    if (lbl_InvHeader.Text == "Purchase Invoice")
                    {
                        txtto.ToolTip = "Bill From";
                        txtsupplyto.ToolTip = "Supply From";
                        Label8.Text = "Bill From";
                        Label9.Text = "Supply From";
                        //txtto.Attributes["Placeholder"] = "Bill From";
                        //txtsupplyto.Attributes["Placeholder"] = "Supply From";
                        //lbllVenRefno.Visible = true;
                        txtVendorref.Visible = true;
                        Label21.Visible = true;
                        Label22.Visible = true;
                        txtVendorRefnodate.Visible = true;
                        //line.Visible = true;
                    }
                    else if (lbl_InvHeader.Text == "Credit Note" || lbl_InvHeader.Text == "Debit Note")
                    {
                        if (lbl_InvHeader.Text == "Credit Note")
                        {
                            txtto.ToolTip = "Bill From";
                            txtsupplyto.ToolTip = "Supply From";
                            Label8.Text = "Bill From";
                            Label9.Text = "Supply From";
                        }
                        else if (lbl_InvHeader.Text == "Debit Note")
                        {
                            txtto.ToolTip = "Bill To";
                            txtsupplyto.ToolTip = "Supply To";
                            Label8.Text = "Bill To";
                            Label9.Text = "Supply To";
                        }
                        homelbl.Visible = false;
                        txtVendorref.Visible = true;
                        Label21.Visible = true;
                        Label22.Visible = true;
                        txtVendorRefnodate.Visible = true;
                    }
                    else
                    {
                        txtto.ToolTip = "Bill To";
                        txtsupplyto.ToolTip = "Supply To";
                        Label8.Text = "Bill To";
                        Label9.Text = "Supply To";
                        //txtto.Attributes["Placeholder"] = "Bill To";
                        //txtsupplyto.Attributes["Placeholder"] = "Supply To";
                        //lbllVenRefno.Visible = false;
                        txtVendorref.Visible = true;
                        txtVendorRefnodate.Visible = true;
                        Label21.Visible = true;
                        Label22.Visible = true;

                        Label21.Text = "Customer Ref #";
                        txtVendorref.ToolTip = "Customer Ref Number";

                        Label22.Text = "Customer Ref Date";
                        txtVendorRefnodate.ToolTip = "Date";
                    }

                    //txtto.Attributes.Add("onblur", "javascript:if (!confirm('Data has Changed. Click OK To Continue')) return false;");
                    if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI" ||
                        Session["StrTranType"].ToString() == "BT" || Session["StrTranType"].ToString() == "CH")
                    {
                        Session["HeadTranType"] = Session["StrTranType"].ToString();
                    }
                    if (Session["HeadTranType"] != null && Session["HeadTranType"].ToString() != "")
                    {
                        Hid_HeadTrantype.Value = Session["HeadTranType"].ToString();
                        //Session["HeadTranType"] = "";
                    }
                    else
                    {
                        Hid_HeadTrantype.Value = Session["StrTranType"].ToString();
                    }
                    if (Hid_HeadTrantype.Value != "FA" && Hid_HeadTrantype.Value != "FC" && Hid_HeadTrantype.Value != "AC")
                    {
                        if (Session["StrTranType"].ToString() == "FE")
                        {
                            lblHead.InnerText = "Ocean Exports";
                            homelbl.Visible = true;
                        }
                        else if (Session["StrTranType"].ToString() == "FI")
                        {
                            lblHead.InnerText = "Ocean Imports";
                            homelbl.Visible = true;
                        }
                        else if (Session["StrTranType"].ToString() == "AE")
                        {
                            lblHead.InnerText = "Air Exports";
                            homelbl.Visible = true;
                        }
                        else if (Session["StrTranType"].ToString() == "AI")
                        {
                            lblHead.InnerText = "Air Imports";
                            homelbl.Visible = true;
                        }
                        else if (Session["StrTranType"].ToString() == "CH")
                        {
                            lblHead.InnerText = "Custom House Agent";
                        }
                    }
                    else if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC")
                    {
                        homelbl.Visible = false;
                        lblHead.InnerText = "Financial Accounts";
                        lblAcc.InnerText = "Vouchers";
                        txtvouyear.Enabled = false;
                        txtdate.Enabled = false;
                    }
                    else if (Hid_HeadTrantype.Value == "AC")
                    {
                        homelbl.Visible = false;
                        lblHead.InnerText = "Operating Accounts";
                        lblAcc.InnerText = "Vouchers";
                    }

                    txtblno.Focus();

                    txtdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                    FillBill();
                    divisionid = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
                    branchid = hrempobj.GetBranchId(divisionid, Session["LoginBranchName"].ToString());
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        lbl_InvHeader.Text = Request.QueryString["type"].ToString();
                        HeaderLabel.InnerText = lbl_InvHeader.Text;
                        frmname = Request.QueryString["type"].ToString();
                        Session["Forminvoice"] = Request.QueryString["type"].ToString();
                    }
                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_InvHeader.Text = Request.QueryString["FormName"].ToString();
                        HeaderLabel.InnerText = lbl_InvHeader.Text;
                        frmname = Request.QueryString["FormName"].ToString();
                        Session["Forminvoice"] = Request.QueryString["FormName"].ToString();
                    }
                    strTranType = Session["StrTranType"].ToString();
                    txtblno.Focus();
                    cmddisable();
                    //  btncancel.Text = "Cancel";

                    btncancel.ToolTip = "Cancel";
                    btncancel1.Attributes["class"] = "btn ico-cancel";

                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        Session["StrTranTypeO"] = "OE";
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        Session["StrTranTypeO"] = "OI";
                    }
                    else
                    {
                        Session["StrTranTypeO"] = Session["StrTranType"].ToString();
                    }
                    VourText();

                    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd.DataBind();
                    GrdFA.DataSource = Utility.Fn_GetEmptyDataTable();
                    GrdFA.DataBind();
                    if (frmname == "Sales Invoice" || frmname == "InvoiceWoJ" || frmname == "Bill of Supply")
                    {
                        if (frmname == "InvoiceWoJ")
                        {
                            lblAcc.InnerText = "Utility";
                            chkmbl.Visible = false;
                            txtcreditapp1.Attributes["Class"] = "VendorRefIN";

                        }
                        else
                        {
                            chkmbl.Visible = true;
                        }
                        extype = "R";
                        //lblInvNo.Text = "Inv #";
                        //txtinv.Attributes.Add("placeholder", "Inv #");
                        if (frmname == "Bill of Supply")
                        {
                            Label3.Text = "BOS #";
                            txtinv.ToolTip = "BOS NUMBER";
                        }
                        else
                        {
                            Label3.Text = "Inv #";
                            txtinv.ToolTip = "INVOICE NUMBER";
                        }
                    }
                    else if (frmname == "Debit Note")
                    {
                        extype = "R";
                        //lblInvNo.Text = "DN #";
                        //txtinv.Attributes.Add("placeholder", "DN #");
                        Label3.Text = "DN #";
                        txtinv.ToolTip = "Debit Note NUMBER";
                    }
                    else if (frmname == "Credit Note")
                    {
                        extype = "C";
                        //lblInvNo.Text = "CN #"; 
                        //txtinv.Attributes.Add("placeholder", "CN #");
                        Label3.Text = "CN #";
                        txtinv.ToolTip = "Credit Note NUMBER";
                    }
                    else
                    {
                        extype = "C";
                        //lblInvNo.Text = "CN-Ops#";
                        //txtinv.Attributes.Add("placeholder", "CN-Ops#");
                        Label3.Text = "PI #";
                        txtinv.ToolTip = "Purchase Invoice #";
                    }
                    UserRights();

                    if (frmname == "Overseas Debit Note")
                    {
                        vname = "OSSI";
                    }
                    else if (frmname == "Overseas Credit Note")
                    {
                        vname = "OSPI";
                    }
                    else if (frmname == "Sales Invoice")
                    {
                        vname = "Invoices";
                    }
                    else if (frmname == "Purchase Invoice")
                    {
                        vname = "Purchase Invoice";
                    }
                    else if (frmname == "Debit Note")
                    {
                        vname = "Debit Note - Others";
                    }
                    else if (frmname == "Credit Note")
                    {
                        vname = "Credit Note - Others";
                    }
                    else if (frmname == "OSDNCN JV")
                    {
                        vname = "OSDNCNJV";
                    }
                    else
                    {
                        vname = frmname;
                    }

                    Session["vname"] = vname;
                    if (Request.QueryString.ToString().Contains("FAvouTYPE"))
                    {
                        ddl_voutype.SelectedValue = Request.QueryString["FAvouTYPE"].ToString();
                        ddl_voutype_SelectedIndexChanged(sender, e);
                        txtinv.Text = Request.QueryString["vouno"].ToString();
                        txtinv_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("COvouTYPE"))
                    {
                        ddl_voutype.SelectedValue = Request.QueryString["COvouTYPE"].ToString();
                        Session["LoginBranchid"] = Request.QueryString["PBranch_ID"].ToString();
                        branchid = Convert.ToInt32(Session["LoginBranchid"]);
                        ddl_voutype_SelectedIndexChanged(sender, e);
                        txtinv.Text = Request.QueryString["vouno"].ToString();
                        txtinv_TextChanged(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }

            }

        }

        protected void btn_uploadpopup_Click(object sender, EventArgs e)
        {
            if (txtinv.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_uploadpopup, typeof(Button), "Checklist", "alertify.alert('Kindly Enter the Reference # ');", true);
                txtinv.Focus();
                return;
            }


            string a = "";
            hf_updoc.Value = "Y";
            a = hf_updoc.Value.ToString();

            iframe_outstd.Attributes["src"] = "../ShipmentDetails/UploadDocument.aspx?&updoc=" + hf_updoc.Value;
            this.popup_uploaddoc.Show();


            //if (lbl_InvHeader.Text == "Credit Note - Operations")
            //{
            //    if (Session["str_ModuleName"].ToString() == "FA")
            //    {
            //        if (Session["StrTranType"].ToString() != null)
            //        {
            //            Session["UploadDocument"] = 1818;
            //            //Session["JobInfo"] = "Proforma CN-OPS";
            //        }
            //    }
            //    else if (Session["str_ModuleName"].ToString() == "FC")
            //    {
            //        if (Session["StrTranType"].ToString() != null)
            //        {
            //            Session["UploadDocument"] = 1814;
            //            //Session["JobInfo"] = "Proforma CN-OPS";
            //        }
            //    }
            //}

            //else if (lbl_InvHeader.Text == "Invoice")
            //{
            //    if (Session["str_ModuleName"].ToString() == "FA")
            //    {
            //        if (Session["StrTranType"].ToString() != null)
            //        {
            //            Session["UploadDocument"] = 1817;
            //            //Session["JobInfo"] = "Proforma CN-OPS";
            //        }
            //    }
            //    else if (Session["str_ModuleName"].ToString() == "FC")
            //    {
            //        if (Session["StrTranType"].ToString() != null)
            //        {
            //            Session["UploadDocument"] = 1813;
            //            //Session["JobInfo"] = "Proforma CN-OPS";
            //        }
            //    }
            //}


            if (txtinv.Text != "")
            {
                DataTable dt = new DataTable();
                // HdnJobNo.Value = "0";
                dt = appobj.view_invoicecnops(Convert.ToInt32(txtinv.Text), Convert.ToInt32(HdnJobNo.Value), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtvouyear.Text), ddl_voutype.SelectedItem.Text);
                ViewState["dt"] = dt;
                if (ViewState["dt"] != null)
                {
                    DataTable dt1 = (DataTable)ViewState["dt"];
                    for (int k = 0; k < dt1.Rows.Count; k++)
                    {
                        refno = dt1.Rows[k]["refno"].ToString();
                        vouno = dt1.Rows[k]["vouno"].ToString();
                    }
                }
            }
            Session["vouno"] = vouno;
            Session["txtjobno"] = HdnJobNo.Value;
            Session["hf_txtrefno"] = refno;
        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("type"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btnview, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    Boolean btn_delete;
                    // btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    str_FornName = Request.QueryString["FormName"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    Utility.Fn_CheckUserRights(str_Uiid, null, btnview, null);
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    DataView obj_dtview = new DataView(obj_Dtuser);
                    obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                    obj_Dtuser = obj_dtview.ToTable();
                    Boolean btn_delete;
                    //  btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }


        private void FillBill()
        {

            //cmbbill.Items.Add("Cash/Cheque");
            //cmbbill.Items.Add("Credit");
            //cmbbill.Items.Add("Internal");
            //cmbbill.Items.Add("Service Tax Exemption");


            cmbbill.Items.Clear();
            cmbbill.Items.Add("");
            cmbbill.Items.Add("Cash/Cheque");
            cmbbill.Items.Add("Credit");
            cmbbill.Items.Add("Internal");
            if (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
            {

            }
            else
            {
                cmbbill.Items.Add("ST/GST Exemption");
            }
        }

        private void FillBase()
        {
            if (strTranType == "FE" || strTranType == "FI")
            {
                //cmbbase.Items.Add("BL");
                //cmbbase.Items.Add("CBM");
                //cmbbase.Items.Add("MT");
            }
            else if (strTranType == "AE" || strTranType == "AI")
            {

            }
            else
            {

            }
        }

        private void cmddisable()
        {
            btncancel.Enabled = true;
        }

        private void VourText()
        {
            DateTime dateval = Convert.ToDateTime(Logobj.GetDate().ToShortDateString());
            if (dateval.Month < 4)
            {
                txtvouyear.Text = Convert.ToString(dateval.Year - 1);
            }
            else
            {
                txtvouyear.Text = Convert.ToString(dateval.Year);
            }
            if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC")
            {
                txtvouyear.Text = Session["logyear"].ToString();
            }
        }

        [WebMethod]
        public static List<string> GetBlNo(string prefix)
        {
            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            string strTranType = HttpContext.Current.Session["StrTranType"].ToString();
            DataAccess.ForwardingExports.BLDetailsWOJob FEBLWoJobj = new DataAccess.ForwardingExports.BLDetailsWOJob();
            
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            FEBLWoJobj.GetDataBase(Ccode);
            obj_da_sc.GetDataBase(Ccode);
            DataTable objDt = new DataTable();
            string str_bl = "";

            if (HttpContext.Current.Session["Forminvoice"].ToString() != "InvoiceWoJ")
            {
                if (strTranType == "FE" || strTranType == "FI")
                {
                    if (strTranType == "FE")
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.ForwardingExports.BLDetails obj_da_bldet = new DataAccess.ForwardingExports.BLDetails();
                            obj_da_bldet.GetDataBase(Ccode);
                            objDt = obj_da_bldet.GetLikeBLDetails(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "blno";
                        }
                        else
                        {
                            DataAccess.ForwardingExports.JobInfo obj_da_jinfo = new DataAccess.ForwardingExports.JobInfo();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetFEJobInfoMBLWOClosedJob(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mblno";
                        }
                    }
                    else
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.ForwardingImports.BLDetails obj_da_jinfo = new DataAccess.ForwardingImports.BLDetails();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetLikeIBL(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "blno";
                        }
                        else
                        {
                            DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetLikeMBLNoWOClosedJob(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mblno";
                        }
                    }
                }
                else if (strTranType == "AE" || strTranType == "AI")
                {
                    if (strTranType == "AE")
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.AirImportExports.AIEBLDetails obj_da_aibldet = new DataAccess.AirImportExports.AIEBLDetails();
                            obj_da_aibldet.GetDataBase(Ccode);
                            objDt = obj_da_aibldet.GetLikeAIEBLDetails(prefix, "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "hawblno";
                        }
                        else
                        {
                            DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                            obj_da_aijinfo.GetDataBase(Ccode);
                            objDt = obj_da_aijinfo.GetLikeAIEJobMBLNo(prefix, "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mawblno";
                        }
                    }
                    else
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.AirImportExports.AIEBLDetails obj_da_aibldet = new DataAccess.AirImportExports.AIEBLDetails();
                            obj_da_aibldet.GetDataBase(Ccode);
                            objDt = obj_da_aibldet.GetLikeAIEBLDetails(prefix, "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "hawblno";
                        }
                        else
                        {
                            DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                            obj_da_aijinfo.GetDataBase(Ccode);
                            objDt = obj_da_aijinfo.GetLikeAIEJobMBLNo(prefix, "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mawblno";
                        }
                    }
                }
                else
                {
                    DataAccess.CustomHousingAgent.JobInfo obj_da_jinfo = new DataAccess.CustomHousingAgent.JobInfo();
                    obj_da_jinfo.GetDataBase(Ccode);
                    objDt = obj_da_jinfo.GetLikeDocno(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                    str_bl = "docno";
                }
            }
            else
            {
                objDt = FEBLWoJobj.GetLikeBLDetailsWOJ(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                str_bl = "blno";
            }
            List<string> Bookingno = new List<string>();
            Bookingno = Utility.Fn_DatatableToList_Text(objDt, str_bl);
            return Bookingno;
        }

        [WebMethod]
        public static List<string> GetToCust(string prefix)
        {
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            customerobj.GetDataBase(Ccode);
            DataTable Dt = new DataTable();
            List<string> List_Result = new List<string>();
            Dt = customerobj.GetLikeIndianCustomer(prefix.ToUpper());
            HttpContext.Current.Session["CustomerDetails"] = Dt;
            List_Result = Utility.Fn_DatatableToList_int16Display(Dt, "customer", "customerid", "customername");
            return List_Result;
        }

        protected void txtblno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtblno.Text.Trim().ToUpper() != "")
                {
                    strTranType = Session["StrTranType"].ToString();
                    if (Request.QueryString.ToString().Contains("type"))
                    {
                        frmname = Request.QueryString["type"].ToString();
                    }
                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        frmname = Request.QueryString["FormName"].ToString();
                    }
                    if (strTranType == "FE" || strTranType == "FI")
                    {
                        if (chkmbl.Checked == true)
                        {
                            GetFEI();
                            // btncancel.Text = "Cancel";

                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";
                        }
                        else
                        {
                            GetFEI();
                            // btncancel.Text = "Cancel";

                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";
                        }
                    }
                    else if (strTranType == "AE" || strTranType == "AI")
                    {
                        if (chkmbl.Checked == true)
                        {
                            GetAEI();
                            // btncancel.Text = "Cancel";

                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";
                        }
                        else
                        {
                            GetAEI();
                            // btncancel.Text = "Cancel";

                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";
                        }
                    }
                    else
                    {
                        GetCHA();
                        // btncancel.Text = "Cancel";

                        btncancel.ToolTip = "Cancel";
                        btncancel1.Attributes["class"] = "btn ico-cancel";
                    }
                }

                if (txtblno.Text.Trim().ToUpper() != "")
                {
                    if (HdnJobNo.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), frmname, "alertify.alert('Invalid BL #');", true);
                        txtblno.Focus();
                        txtclear();
                    }
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void txtclear()
        {
            cmbbill.SelectedIndex = -1;
            txtblno.Text = "";
            HdnJobNo.Value = "";
            txtto.Text = "";
            txtinv.Text = "";
            txtvessel.Text = "";
            txtdes.Text = "";
            txtshipper.Text = "";
            txtconsignee.Text = "";
            txtnotify.Text = "";
            txtremarks.Text = "";
            txtagent.Text = "";
            txtmlo.Text = "";
            txtcnf.Text = "";
            txtaddress.Text = "";
            txtblno.Focus();
            VourText();
            chkmbl.Checked = false;
            txtTotal.Text = "";
            txtdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
            lstcon.Items.Clear();
            lstvol.Items.Clear();
            lstagnst.Items.Clear();
            // btncancel.Text = "Back";
            txt_trantype.Text = "";
            txtsupplyto.Text = "";
            txtsupplytoAddress.Text = "";
            //Session["HeadTranType"] = Hid_HeadTrantype.Value;

            btncancel.ToolTip = "Back";
            btncancel1.Attributes["class"] = "btn ico-back";
        }

        private void GetFEI()
        {
            try
            {
                //strTranType = Session["StrTranType"].ToString();
                //if (Request.QueryString.ToString().Contains("type"))
                //{
                //    frmname = Request.QueryString["type"].ToString();
                //}
                //if (Request.QueryString.ToString().Contains("FormName"))
                //{
                //    frmname = Request.QueryString["FormName"].ToString();
                //}
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
                if (strTranType == "FE" || strTranType == "OE")
                {
                    if (frmname != "InvoiceWoJ")
                    {
                        if (chkmbl.Checked == true)
                        {
                            lstvol.Items.Clear();
                            int val = FEJobobj.GetJobNo(txtblno.Text.ToUpper(), branchid, divisionid);
                            HdnJobNo.Value = val.ToString();
                            DtConDetails = INVOICEobj.GetMblContainerDtls(val, HdnJobNo.Value.ToString(), Session["StrTranType"].ToString(), branchid);
                            if (DtConDetails.Rows.Count > 0)
                            {
                                for (int i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString() + ", " + DtConDetails.Rows[i]["sizetype"].ToString());
                                }
                            }
                            lstcon.Items.Clear();
                            DtCon = INVOICEobj.GetHblNoOfContainers(val, HdnJobNo.Value.ToString(), Session["StrTranType"].ToString(), branchid);

                            if (DtCon.Rows.Count > 0)
                            {
                                for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtCon.Rows[i][0].ToString() + " X " + DtCon.Rows[i][1].ToString());
                                }
                            }

                            //volume = (DtConDetails.Rows[0][1].ToString());
                            //lstcon.Items.Add(volume + " cbm");
                            //wt = (DtConDetails.Rows[0][2].ToString());
                            //lstcon.Items.Add(wt + " Kgs");

                            DtCon = FEJobobj.GetFEJobInfo(val, branchid, divisionid);
                            if (DtCon.Rows.Count > 0)
                            {
                                vessel = DtCon.Rows[0][3].ToString();
                                voyage = DtCon.Rows[0][7].ToString();
                                eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString());
                                Hdnteta.Value = eta.ToString("dd/MM/yyyy");
                                //txtvessel.Text = "Job # " + HdnJobNo.Value + " " + "Vsl " + vessel + " " + voyage + " " + "Sailed on " + Hdnteta.Value;
                                txtvessel.Text =   HdnJobNo.Value  + " " + "Dt: " + Hdnteta.Value;
                                TextBox1.Text =     vessel    ;
                                txtmlo.Text = DtCon.Rows[0][6].ToString();
                                txtagent.Text = DtCon.Rows[0][5].ToString();
                                agent = DtCon.Rows[0][14].ToString();
                                //txtdes.Text = DtCon.Rows[0][4].ToString();
                                txtdes.Text = DtCon.Rows[0][1].ToString() + " / " + DtCon.Rows[0][2].ToString();
                                jobtype = DtCon.Rows[0][13].ToString();
                            }
                        }
                        else
                        {
                            lstvol.Items.Clear();
                            DtInfo = FEBLobj.GetBLDetails(txtblno.Text.ToUpper(), branchid, divisionid);
                            if (DtInfo.Rows.Count > 0)
                            {
                                HdnJobNo.Value = DtInfo.Rows[0][0].ToString();
                                int jonno = Convert.ToInt32(HdnJobNo.Value.ToString());
                                txtshipper.Text = DtInfo.Rows[0][4].ToString();
                                txtconsignee.Text = DtInfo.Rows[0][6].ToString();
                                txtnotify.Text = DtInfo.Rows[0][8].ToString();
                                txtcnf.Text = DtInfo.Rows[0][16].ToString();
                                DtCon = FEJobobj.GetFEJobInfo(jonno, branchid, divisionid);
                                if (DtCon.Rows.Count > 0)
                                {
                                    jobtype = DtCon.Rows[0][13].ToString();
                                    vessel = DtCon.Rows[0][3].ToString();
                                    voyage = DtCon.Rows[0][7].ToString();
                                    eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString());
                                    Hdnteta.Value = eta.ToString("dd/MM/yyyy");
                                    //txtvessel.Text = "Job # " + HdnJobNo.Value + " " + "Vsl " + vessel + " " + voyage + " " + "Sailed on " + Hdnteta.Value;
                                    txtvessel.Text = HdnJobNo.Value + " " + "Dt: " + Hdnteta.Value;
                                    TextBox1.Text = vessel;
                                    txtmlo.Text = DtCon.Rows[0][6].ToString();
                                    txtagent.Text = DtCon.Rows[0][5].ToString();
                                    agent = DtCon.Rows[0][14].ToString();
                                    //txtdes.Text = DtCon.Rows[0][4].ToString();
                                    txtdes.Text = DtCon.Rows[0][1].ToString() + " / " + DtCon.Rows[0][2].ToString();
                                    Dt = INVOICEobj.GetCreditOSAmount(txtblno.Text, branchid);
                                    if (Dt.Rows.Count > 0)
                                    {
                                        HdnCreditAmt.Value = Dt.Rows[0][0].ToString();
                                        HdnOSAmt.Value = Dt.Rows[0][1].ToString();
                                    }
                                }

                                DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text.ToUpper(), Session["StrTranType"].ToString(), branchid);
                                if (DtConDetails.Rows.Count > 0)
                                {
                                    for (int i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                    {
                                        lstvol.Items.Add(DtConDetails.Rows[i][0].ToString() + ", " + DtConDetails.Rows[i]["sizetype"].ToString());
                                    }

                                    lstcon.Items.Clear();
                                    int job = Convert.ToInt32(HdnJobNo.Value.ToString());
                                    DtInfo = INVOICEobj.GetHblNoOfContainers(job, txtblno.Text.ToUpper(), Session["StrTranType"].ToString(), branchid);
                                    if (DtInfo.Rows.Count > 0)
                                    {
                                        for (int i = 0; i <= DtInfo.Rows.Count - 1; i++)
                                        {
                                            lstvol.Items.Add((DtInfo.Rows[i][0].ToString() + " X " + (DtInfo.Rows[i][1].ToString())));
                                        }
                                    }

                                    volume = (DtConDetails.Rows[0][1].ToString());
                                    lstcon.Items.Add(volume + " cbm");
                                    wt = (DtConDetails.Rows[0][2].ToString());
                                    lstcon.Items.Add(wt + " Kgs");
                                }

                                //lstcon.Items.Clear();
                                //int job = Convert.ToInt32(HdnJobNo.Value.ToString());
                                //DtInfo = INVOICEobj.GetHblNoOfContainers(job, txtblno.Text.ToUpper(), strTranType, branchid);
                                //if (DtInfo.Rows.Count > 0)
                                //{
                                //    for (int i = 0; i <= DtInfo.Rows.Count - 1; i++)
                                //    {
                                //        lstcon.Items.Add((DtInfo.Rows[i][0].ToString() + " Container," + (DtInfo.Rows[i][1].ToString())));
                                //    }
                                //}

                            }
                        }
                    }
                    else
                    {
                        Dt = FEBLWoJobj.GetBLDetWOJob(txtblno.Text.ToUpper(), branchid, divisionid);
                        if (Dt.Rows.Count > 0)
                        {
                            HdnJobNo.Value = "0";
                            txtshipper.Text = Dt.Rows[0][3].ToString();
                            txtconsignee.Text = Dt.Rows[0][6].ToString();
                            txtnotify.Text = Dt.Rows[0][9].ToString();
                            txtcnf.Text = Dt.Rows[0][16].ToString();
                            txtvessel.Text = Dt.Rows[0][33].ToString();
                        }
                    }
                }
                else
                {
                    if (chkmbl.Checked == true)
                    {
                        lstvol.Items.Clear();
                        DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text.ToUpper(), Session["StrTranType"].ToString(), branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            HdnJobNo.Value = DtInfo.Rows[0][0].ToString();
                            vessel = DtInfo.Rows[0][3].ToString();
                            voyage = DtInfo.Rows[0][2].ToString();
                            eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                            Hdnteta.Value = eta.ToString("dd/MM/yyyy");
                            //txtvessel.Text = "Job # " + HdnJobNo.Value + " " + "Vsl " + vessel + " " + voyage + " " + "Sailed on " + Hdnteta.Value;
                            txtvessel.Text = HdnJobNo.Value + " " + "Dt: " + Hdnteta.Value;
                            TextBox1.Text = vessel;
                            txtmlo.Text = DtInfo.Rows[0][6].ToString();
                            txtagent.Text = DtInfo.Rows[0][5].ToString();
                            agent = DtInfo.Rows[0][7].ToString();
                            txtdes.Text = DtInfo.Rows[0][4].ToString();
                            //txtdes.Text = DtInfo.Rows[0][1].ToString() + " / " + DtCon.Rows[0][2].ToString();
                            jobtype = DtInfo.Rows[0][8].ToString();

                            DtCon = INVOICEobj.GetFIMblNContainers(HdnJobNo.Value, branchid);
                            if (DtCon.Rows.Count > 0)
                            {
                                for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtCon.Rows[i][0].ToString() + " X " + DtCon.Rows[i][1].ToString());
                                }
                            }

                            JobNumner = Convert.ToInt32(HdnJobNo.Value);
                            DtConDetails = INVOICEobj.GetMblContainerDtls(JobNumner, HdnJobNo.Value, Session["StrTranType"].ToString(), branchid);
                            if (DtConDetails.Rows.Count > 0)
                            {
                                for (int i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString() + ", " + DtConDetails.Rows[i]["sizetype"].ToString());
                                }
                            }

                            //volume = INVOICEobj.GetVolume(txtblno.Text, strTranType, branchid).ToString();
                            //lstcon.Items.Add(volume + " cbm");
                            //wt = INVOICEobj.GetWeight(txtblno.Text, strTranType, branchid).ToString();
                            //lstcon.Items.Add(wt + " Kgs");
                        }

                    }
                    else
                    {
                        lstvol.Items.Clear();
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), Session["StrTranType"].ToString(), branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            HdnJobNo.Value = DtInfo.Rows[0][0].ToString();
                            txtshipper.Text = DtInfo.Rows[0][4].ToString();
                            txtconsignee.Text = DtInfo.Rows[0][5].ToString();
                            txtnotify.Text = DtInfo.Rows[0][7].ToString();
                            vessel = DtInfo.Rows[0][3].ToString();
                            voyage = DtInfo.Rows[0][2].ToString();
                            eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                            Hdnteta.Value = eta.ToString("dd/MM/yyyy");
                            //txtvessel.Text = "Job # " + HdnJobNo.Value + " " + "Vsl " + vessel + " " + voyage + " " + "Sailed on " + Hdnteta.Value;
                            txtvessel.Text = HdnJobNo.Value + " " + "Dt: " + Hdnteta.Value;
                            TextBox1.Text = vessel;
                            txtmlo.Text = DtInfo.Rows[0][10].ToString();
                            txtagent.Text = DtInfo.Rows[0][9].ToString();
                            agent = DtInfo.Rows[0][10].ToString();
                            txtdes.Text = DtInfo.Rows[0][8].ToString();
                            jobtype = DtInfo.Rows[0][11].ToString();

                            Dt = INVOICEobj.GetCreditOSAmount(txtblno.Text.ToUpper(), branchid);
                            if (Dt.Rows.Count > 0)
                            {
                                HdnCreditAmt.Value = Dt.Rows[0][0].ToString();
                                HdnOSAmt.Value = Dt.Rows[0][1].ToString();
                            }
                        }
                    }

                    DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text.ToUpper(), Session["StrTranType"].ToString(), branchid);
                    if (DtConDetails.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                        {
                            lstvol.Items.Add(DtConDetails.Rows[i][0].ToString() + ", " + DtConDetails.Rows[i]["sizetype"].ToString());
                        }

                        DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(HdnJobNo.Value), txtblno.Text, strTranType, branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            for (int i = 0; i <= DtInfo.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtInfo.Rows[i][0].ToString() + " X " + DtInfo.Rows[i][1].ToString());
                            }
                        }

                        volume = INVOICEobj.GetVolume(txtblno.Text, Session["StrTranType"].ToString(), branchid).ToString();
                        lstcon.Items.Add(volume + " cbm");
                        wt = INVOICEobj.GetWeight(txtblno.Text, strTranType, branchid).ToString();
                        lstcon.Items.Add(wt + " Kgs");

                        



                        //lstcon.Items.Clear();
                        //DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(HdnJobNo.Value), txtblno.Text, strTranType, branchid);
                        //if (DtInfo.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i <= DtInfo.Rows.Count - 1; i++)
                        //    {
                        //        lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
                        //    }
                        //}
                    }
                }
                Disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void GetCHA()
        {
            try
            {
                //strTranType = Session["StrTranType"].ToString();
                if (Request.QueryString.ToString().Contains("type"))
                {
                    frmname = Request.QueryString["type"].ToString();
                }
                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    frmname = Request.QueryString["FormName"].ToString();
                }
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());

                string gross, chwt;
                Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), "CH", branchid);
                if (Dt.Rows.Count > 0)
                {
                    HdnJobNo.Value = Dt.Rows[0][0].ToString();
                    txtshipper.Text = Dt.Rows[0][3].ToString();
                    txtconsignee.Text = Dt.Rows[0][4].ToString();
                    txtnotify.Text = Dt.Rows[0][5].ToString();
                    eta = Convert.ToDateTime(Dt.Rows[0][1].ToString());
                    Hdnteta.Value = eta.ToString("dd/MM/yyyy");
                    txtvessel.Text = "Job # " + HdnJobNo.Value + " " + Dt.Rows[0][2].ToString() + " " + Hdnteta.Value;
                    txtmlo.Text = Dt.Rows[0][7].ToString();
                    txtagent.Text = Dt.Rows[0][8].ToString();
                    agent = Dt.Rows[0][9].ToString();
                    txtdes.Text = Dt.Rows[0][6].ToString();
                    jobtype = Dt.Rows[0][10].ToString();
                    jobtype = "0";

                    //gross = DtInfo.Rows[0][11].ToString();
                    //chwt = DtInfo.Rows[0][12].ToString();
                    //lstcon.Items.Add("Gross Wt : " + gross + " Kgs");
                    //lstcon.Items.Add("Charge Wt : " + chwt + " Kgs");

                }
                Disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void GetAEI()
        {
            try
            {
                //strTranType = Session["StrTranType"].ToString();
                if (Request.QueryString.ToString().Contains("type"))
                {
                    frmname = Request.QueryString["type"].ToString();
                }
                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    frmname = Request.QueryString["FormName"].ToString();
                }
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());

                string gross, chwt;
                if (chkmbl.Checked == true)
                {
                    lstvol.Items.Clear();
                    if (strTranType == "AE")
                    {
                        DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
                    }
                    if (DtInfo.Rows.Count > 0)
                    {
                        HdnJobNo.Value = DtInfo.Rows[0][0].ToString();
                        //txtvessel.Text = "Job # " + HdnJobNo.Value + " " + "Flight # " + DtInfo.Rows[0][2].ToString() + " " + "Flight Date " + Hdnteta.Value;

                        
                        txtvessel.Text = HdnJobNo.Value + " " + "Dt: " + Hdnteta.Value;
                        TextBox1.Text = DtInfo.Rows[0][2].ToString();
                        txtmlo.Text = DtInfo.Rows[0][4].ToString();
                        txtagent.Text = DtInfo.Rows[0][5].ToString();
                        agent = DtInfo.Rows[0][6].ToString();
                        eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                        Hdnteta.Value = eta.ToString("dd/MM/yyyy");
                        txtdes.Text = DtInfo.Rows[0][3].ToString();
                        gross = DtInfo.Rows[0][7].ToString();
                        chwt = DtInfo.Rows[0][8].ToString();
                    }

                }
                else
                {
                    lstvol.Items.Clear();
                    if (strTranType == "AE")
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
                    }

                    if (DtInfo.Rows.Count > 0)
                    {
                        HdnJobNo.Value = DtInfo.Rows[0][0].ToString();
                        txtshipper.Text = DtInfo.Rows[0][3].ToString();
                        txtconsignee.Text = DtInfo.Rows[0][4].ToString();
                        txtnotify.Text = DtInfo.Rows[0][5].ToString();
                        eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                        Hdnteta.Value = eta.ToString("dd/MM/yyyy");
                        txtcnf.Text = DtInfo.Rows[0][6].ToString();
                        //txtvessel.Text = "Job # " + HdnJobNo.Value + " " + "Flight # " + DtInfo.Rows[0][2].ToString() + " " + "Flight Date " + Hdnteta.Value;


                        txtvessel.Text = HdnJobNo.Value + " " + "Dt: " + Hdnteta.Value;
                        TextBox1.Text = DtInfo.Rows[0][2].ToString();
                        txtmlo.Text = DtInfo.Rows[0][8].ToString();
                        txtagent.Text = DtInfo.Rows[0][9].ToString();
                        agent = DtInfo.Rows[0][10].ToString();
                        txtdes.Text = DtInfo.Rows[0][7].ToString();
                        gross = DtInfo.Rows[0][11].ToString();
                        chwt = DtInfo.Rows[0][12].ToString();
                        lstcon.Items.Add("Gross Wt : " + gross + " Kgs");
                        lstcon.Items.Add("Charge Wt : " + chwt + " Kgs");
                    }
                }
                Disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        private void Disable()
        {
            if (chkmbl.Checked == true)
            {
                txtshipper.Enabled = false;
                txtconsignee.Enabled = false;
                txtnotify.Enabled = false;
                txtcnf.Enabled = false;
            }
            else
            {
                txtshipper.Enabled = true;
                txtconsignee.Enabled = true;
                txtnotify.Enabled = true;
                txtcnf.Enabled = true;
            }
        }

        protected void cmbbill_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //strTranType = Session["StrTranType"].ToString();
                if (Request.QueryString.ToString().Contains("type"))
                {
                    frmname = Request.QueryString["type"].ToString();
                }
                if (Request.QueryString.ToString().Contains("FormName"))
                {
                    frmname = Request.QueryString["FormName"].ToString();
                }
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
                //DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
                DataTable DtDetails = new DataTable();
                string bookingno;
                int intcustomerid4DO;

                if (frmname == "Sales Invoice" || frmname == "Bill of Supply")
                {
                    if (cmbbill.SelectedValue == "Credit")
                    {
                        txtcreditapp.Text = "";
                        txtcreditapp.Enabled = true;
                        bookingno = FIBLobj.GetBookinkNo(txtblno.Text.ToUpper(), branchid, divisionid);
                        DtDetails = FEBLobj.GetBookingDt(bookingno, branchid, divisionid);
                        if (DtDetails.Rows.Count > 0)
                        {
                            intcustomerid4DO = Convert.ToInt32(DtDetails.Rows[0][13].ToString());
                        }
                        txtcreditapp.Text = "Not Updated";

                    }
                    else
                    {
                        txtcreditapp.Text = "";
                        txtcreditapp.Enabled = false;
                    }

                }
                else
                {
                    txtcreditapp.Text = "";
                    txtcreditapp.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }


        protected void txtinv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Voucher Type');", true);
                    ddl_voutype.Focus();
                    return;
                }
                lstagnst.Items.Clear();
                lstcon.Items.Clear();
                lstvol.Items.Clear();

                DataTable obj_dt = new DataTable();
                DataTable obj_dttemp = new DataTable();
                strTranType = Session["StrTranTypeO"].ToString();
               
                //if (Request.QueryString.ToString().Contains("type"))
                //{
                //    frmname = Request.QueryString["type"].ToString();
                //}
                //if (Request.QueryString.ToString().Contains("FormName"))
                //{
                //    frmname = Request.QueryString["FormName"].ToString();
                //}
                frmname = ddl_voutype.SelectedItem.Text;

                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
                //frmname = Request.QueryString["type"].ToString();
                if(strTranType=="CO")
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), "", Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(txtvouyear.Text), branchid);
                    if (DtSHead.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), frmname, "alertify.alert('Invalid Voucher #');", true);
                        txtinv.Focus();
                        return;
                    }
                    if (DtSHead.Rows[0]["trantype"].ToString() == "OE")
                    {
                        Session["StrTranType"] = "FE";
                        Session["StrTranTypeO"] = "OE";
                    }
                    else if (DtSHead.Rows[0]["trantype"].ToString() == "OI")
                    {
                        Session["StrTranType"] = "FI";
                        Session["StrTranTypeO"] = "OI";
                    }
                    else
                    {
                        Session["StrTranType"] = DtSHead.Rows[0]["trantype"].ToString();
                        Session["StrTranTypeO"] = DtSHead.Rows[0]["trantype"].ToString();
                    }
                }
                else
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(txtvouyear.Text), branchid);
                    if (DtSHead.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), frmname, "alertify.alert('Invalid Voucher #');", true);
                        txtinv.Focus();
                        return;
                    }
                    if (DtSHead.Rows[0]["trantype"].ToString() == "OE")
                    {
                        Session["StrTranType"] = "FE";
                        Session["StrTranTypeO"] = "OE";
                    }
                    else if (DtSHead.Rows[0]["trantype"].ToString() == "OI")
                    {
                        Session["StrTranType"] = "FI";
                        Session["StrTranTypeO"] = "OI";
                    }
                    else
                    {
                        Session["StrTranType"] = DtSHead.Rows[0]["trantype"].ToString();
                        Session["StrTranTypeO"] = DtSHead.Rows[0]["trantype"].ToString();
                    }
                }
                if (DtSHead.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), frmname, "alertify.alert('Invalid Voucher #');", true);
                    txtinv.Focus();
                    return;
                }
                //Session["StrTranType"] = DtSHead.Rows[0]["trantype"].ToString();
                //strTranType = Session["StrTranType"].ToString();
                //strTranType = DtSHead.Rows[0]["trantype"].ToString();
                if (Hid_HeadTrantype.Value != "FA" && Hid_HeadTrantype.Value != "FC" && Hid_HeadTrantype.Value != "AC")
                {
                    homelbl.Visible = true;

                    if (Hid_HeadTrantype.Value == "FE")
                    {
                        lblHead.InnerText = "Ocean Exports";
                    }
                    else if (Hid_HeadTrantype.Value == "FI")
                    {
                        lblHead.InnerText = "Ocean Imports";
                    }
                    else if (Hid_HeadTrantype.Value == "AE")
                    {
                        lblHead.InnerText = "Air Exports";
                    }
                    else if (Hid_HeadTrantype.Value == "AI")
                    {
                        lblHead.InnerText = "Air Imports";
                    }
                    else if (Hid_HeadTrantype.Value == "CH")
                    {
                        lblHead.InnerText = "Custom House Agent";
                    }

                    strTranType = DtSHead.Rows[0]["trantype"].ToString();
                    if (strTranType == "OE")
                    {
                        txt_trantype.Text = "Ocean Exports";
                    }
                    else if (strTranType == "OI")
                    {
                        txt_trantype.Text = "Ocean Imports";
                    }
                    else if (strTranType == "AE")
                    {
                        txt_trantype.Text = "Air Exports";
                    }
                    else if (strTranType == "AI")
                    {
                        txt_trantype.Text = "Air Imports";
                    }
                    else if (strTranType == "CH")
                    {
                        txt_trantype.Text = "Custom House Agent";
                    }

                    if (Session["StrTranType"].ToString() != "CO")
                    {
                        strTranType = Session["StrTranTypeO"].ToString();
                    }

                }
                else if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC" || Hid_HeadTrantype.Value == "AC")
                {
                    strTranType = DtSHead.Rows[0]["trantype"].ToString();

                    Session["StrTranType"] = strTranType;

                    if (strTranType == "FE" || strTranType == "OE")
                    {
                        txt_trantype.Text = "Ocean Exports";
                        Session["StrTranType"] = "FE";
                    }
                    else if (strTranType == "FI" || strTranType == "OI")
                    {
                        txt_trantype.Text = "Ocean Imports";
                        Session["StrTranType"] = "FI";
                    }
                    else if (strTranType == "AE")
                    {
                        txt_trantype.Text = "Air Exports";
                    }
                    else if (strTranType == "AI")
                    {
                        txt_trantype.Text = "Air Imports";
                        Session["StrTranType"] = strTranType;
                    }
                    else if (strTranType == "CH")
                    {
                        txt_trantype.Text = "Custom House Agent";
                        Session["StrTranType"] = strTranType;
                    }
                }

                hid_Trantype.Value = strTranType;
                Session["StrTranTypeO"] = hid_Trantype.Value;
                //if (hid_Trantype.Value == "FE")
                //{
                //    Session["StrTranTypeO"] = "OE";
                //}
                //else if (hid_Trantype.Value == "FI")
                //{
                //    Session["StrTranTypeO"] = "OI";
                //}
                //else
                //{
                //    Session["StrTranTypeO"] = Session["StrTranType"].ToString();
                //}
                str_dispyear = (txtvouyear.Text.ToString()).Substring(2, 2);
                int dy = Convert.ToInt32(str_dispyear) + 1; ;
                string dy1 = Convert.ToString(dy);
                FADbName = "FA" + str_dispyear + dy1;



                //if (txtinv.Text.ToString() != "")
                //{
                //    if (frmname == "OS DN" || frmname == "OS CN" || frmname == "OSPI" || frmname == "OSSI" || frmname == "OSDNCN JV" || frmname == "OSDNCNJV")
                //    {
                //        //getosdncndetails();
                //    }
                //    else
                //    {
                //        getdetails();
                //    }

                //    //HORM = false;
                //    //modulename();
                //}

                if (txtinv.Text != "")
                {
                    chkmbl.Checked = false;

                    if (frmname == "Sales Invoice" || frmname == "Sales Invoice OC" || frmname == "Debit Note" || frmname == "Credit Note" || frmname == "InvoiceWoJ" || frmname == "Bill of Supply" || frmname == "Bill of Supply OC")
                    {
                        DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(txtvouyear.Text), branchid);
                        //if (frmname == "Sales Invoice")
                        //{
                        //    vtype = "I";
                        //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 1, Convert.ToInt32(txtvouyear.Text), branchid);
                        //}
                        //else if (frmname == "InvoiceWoJ")
                        //{
                        //    vtype = "I";
                        //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 1, Convert.ToInt32(txtvouyear.Text), branchid);
                        //}
                        //else if (frmname == "Debit Note")
                        //{
                        //    vtype = "V";
                        //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 7, Convert.ToInt32(txtvouyear.Text), branchid);
                        //}
                        //else if (frmname == "Credit Note")
                        //{
                        //    vtype = "E";
                        //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 8, Convert.ToInt32(txtvouyear.Text), branchid);
                        //}
                        //else if (frmname == "Bill of Supply")
                        //{
                        //    vtype = "B";
                        //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 20, Convert.ToInt32(txtvouyear.Text), branchid);
                        //    // lbl_against.Text = INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "B");
                        //}
                        if (DtSHead.Rows.Count > 0)
                        {
                            HdnJobNo.Value = DtSHead.Rows[0][3].ToString();
                            custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                            intcustid = custid;
                            HdnCustid.Value = intcustid.ToString();
                            txtto.Text = customerobj.GetCustomername(custid);

                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyTo"].ToString()))
                            {
                                supplytoid = Convert.ToInt32(DtSHead.Rows[0]["SupplyTo"].ToString());
                                intsupplytoid = supplytoid;
                                txtsupplyto.Text = customerobj.GetCustomername(supplytoid);
                                citysupplyid = customerobj.GetCustlocation(supplytoid);
                                txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                            }
                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["preparedbyname"].ToString()))
                            {
                                lbl_txt.Visible = true;
                                lbl_prepare.Text = DtSHead.Rows[0]["preparedbyname"].ToString();
                            }

                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["approvedbyname"].ToString()))
                            {
                                lbl_txt.Visible = true;
                                lbl_appr.Visible = true;
                                lbl_Approve.Text = DtSHead.Rows[0]["approvedbyname"].ToString();
                            }



                            city = customerobj.GetCustlocation(custid);
                            cityid = portobj.GetNPortid(city);
                            txtblno.Text = DtSHead.Rows[0][5].ToString();
                            approvedby = Convert.ToInt32(DtSHead.Rows[0][7].ToString());
                            hid_approvedby.Value = approvedby.ToString();
                            txtremarks.Text = DtSHead.Rows[0]["remarks"].ToString();
                            billtype = DtSHead.Rows[0][12].ToString();
                            fatransfer = DtSHead.Rows[0][13].ToString();
                            voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                            txtdate.Text = voudate.ToString("dd/MM/yyyy");
                            bill = INVOICEobj.GetBillType(Convert.ToChar(billtype));
                            txtVendorRefnodate.Text = DtSHead.Rows[0]["vendorrefdate"].ToString();
                            txtVendorref.Text = DtSHead.Rows[0]["vendorrefno"].ToString();

                            cmbbill.Items.Clear();
                            cmbbill.Items.Add("");
                            cmbbill.Items.Add("Cash/Cheque");
                            cmbbill.Items.Add("Credit");
                            cmbbill.Items.Add("Internal");
                            if (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                            {
                                if (bill == "Cash/Cheque")
                                {
                                    cmbbill.SelectedIndex = 1;
                                }
                                else if (bill == "Credit")
                                {
                                    cmbbill.SelectedIndex = 2;
                                }

                                else if (bill == "Internal")
                                {
                                    cmbbill.SelectedIndex = 3;
                                }
                                else
                                {
                                    cmbbill.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                cmbbill.Items.Add("ST/GST Exemption");
                                if (bill == "Cash/Cheque")
                                {
                                    cmbbill.SelectedIndex = 1;
                                }
                                else if (bill == "Credit")
                                {
                                    cmbbill.SelectedIndex = 2;
                                }
                                else if (bill == "Internal")
                                {
                                    cmbbill.SelectedIndex = 3;
                                }
                                else if (bill == "ST/GST Exemption")
                                {
                                    cmbbill.SelectedIndex = 4;
                                }
                                else
                                {
                                    cmbbill.SelectedIndex = 0;
                                }
                            }

                            txtaddress.Text = customerobj.GetCustomerAddress(txtto.Text.Trim(), "C", city);

                            if (frmname == "Credit Note")
                            {
                                if (DtSHead.Rows[0]["vendorrefno"] != System.DBNull.Value)
                                {
                                    txtVendorref.Text = DtSHead.Rows[0]["vendorrefno"].ToString();
                                }
                                else
                                {
                                    txtVendorref.Text = "";
                                }
                                if (!string.IsNullOrEmpty(DtSHead.Rows[0]["vendorrefdate"].ToString()))
                                {
                                    txtVendorRefnodate.Text = DtSHead.Rows[0]["vendorrefdate"].ToString();
                                }
                                else
                                {
                                    txtVendorRefnodate.Text = "";
                                }
                            }

                            if (strTranType == "OE" || strTranType == "OI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    hdnblno.Value = Dt.Rows[i][0].ToString();
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetFEI();
                            }
                            else if (strTranType == "AE" || strTranType == "AI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    hdnblno.Value = Dt.Rows[i][0].ToString();
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetAEI();
                            }
                            else
                            {
                                GetCHA();
                            }

                            GrdLoad(vtype);
                            // btncancel.Text = "Cancel";

                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";

                            if (Convert.ToInt32(txtvouyear.Text) > 2011)
                            {
                                getdetails();
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sales Invoice", "alertify.alert('Invalid Invoice Number');", true);
                            txtinv.Text = "";
                            txtclear();
                            grd.DataSource = Utility.Fn_GetEmptyDataTable();
                            grd.DataBind();
                            GrdFA.DataSource = Utility.Fn_GetEmptyDataTable();
                            GrdFA.DataBind();
                            //  btncancel.Text = "Back";

                            btncancel.ToolTip = "Back";
                            btncancel1.Attributes["class"] = "btn ico-back";
                        }
                    }
                    else
                    {
                        DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(txtvouyear.Text), branchid);

                        //  DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 2, Convert.ToInt32(txtvouyear.Text), branchid);
                        if (DtSHead.Rows.Count > 0)
                        {
                            HdnJobNo.Value = DtSHead.Rows[0][3].ToString();
                            custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                            intcustid = custid;
                            txtto.Text = customerobj.GetCustomername(custid);


                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyTo"].ToString()))
                            {
                                supplytoid = Convert.ToInt32(DtSHead.Rows[0]["SupplyTo"].ToString());
                                intsupplytoid = supplytoid;
                                txtsupplyto.Text = customerobj.GetCustomername(supplytoid);
                                citysupplyid = customerobj.GetCustlocation(supplytoid);
                                txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                            }


                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["preparedbyname"].ToString()))
                            {
                                lbl_txt.Visible = true;
                                lbl_prepare.Text = DtSHead.Rows[0]["preparedbyname"].ToString();
                            }

                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["approvedbyname"].ToString()))
                            {
                                lbl_txt.Visible = true;
                                lbl_appr.Visible = true;
                                lbl_Approve.Text = DtSHead.Rows[0]["approvedbyname"].ToString();
                            }
                            city = customerobj.GetCustlocation(custid);
                            cityid = portobj.GetNPortid(city);
                            txtblno.Text = DtSHead.Rows[0][5].ToString();
                            approvedby = Convert.ToInt32(DtSHead.Rows[0][7].ToString());
                            txtremarks.Text = DtSHead.Rows[0]["remarks"].ToString();
                            billtype = DtSHead.Rows[0][12].ToString();
                            fatransfer = DtSHead.Rows[0][13].ToString();
                            voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                            txtdate.Text = voudate.ToString("dd/MM/yyyy");
                            bill = INVOICEobj.GetBillType(Convert.ToChar(billtype));
                            txtVendorRefnodate.Text = DtSHead.Rows[0]["vendorrefdate"].ToString();
                            txtVendorref.Text = DtSHead.Rows[0]["vendorrefno"].ToString();
                            if (Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                            {
                                if (bill == "Cash/Cheque")
                                {
                                    cmbbill.SelectedIndex = 1;
                                }
                                else if (bill == "Credit")
                                {
                                    cmbbill.SelectedIndex = 2;
                                }

                                else if (bill == "Internal")
                                {
                                    cmbbill.SelectedIndex = 3;
                                }
                                else
                                {
                                    cmbbill.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                if (bill == "Cash/Cheque")
                                {
                                    cmbbill.SelectedIndex = 1;
                                }
                                else if (bill == "Credit")
                                {
                                    cmbbill.SelectedIndex = 2;
                                }
                                else if (bill == "Internal")
                                {
                                    cmbbill.SelectedIndex = 3;
                                }
                                else if (bill == "ST/GST Exemption")
                                {
                                    cmbbill.SelectedIndex = 4;
                                }
                                else
                                {
                                    cmbbill.SelectedIndex = 0;
                                }
                            }
                            txtaddress.Text = customerobj.GetCustomerAddress(txtto.Text.Trim(), "C", city);

                            if (frmname == "Purchase Invoice" || frmname == "PaymentAdvise" || frmname == "Purchase Invoice OC")
                            {
                                txtVendorref.Text = DtSHead.Rows[0]["vendorrefno"].ToString();

                                if (!string.IsNullOrEmpty(DtSHead.Rows[0]["vendorrefdate"].ToString()))
                                {
                                    txtVendorRefnodate.Text = DtSHead.Rows[0]["vendorrefdate"].ToString();
                                }
                                else
                                {
                                    txtVendorRefnodate.Text = "";
                                }
                            }

                            if (strTranType == "OE" || strTranType == "OI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    hdnblno.Value = Dt.Rows[i][0].ToString();
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetFEI();
                            }
                            else if (strTranType == "AE" || strTranType == "AI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    hdnblno.Value = Dt.Rows[i][0].ToString();
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetAEI();
                            }
                            else
                            {
                                GetCHA();
                            }


                            //btnsave.Text = "Update";
                            GrdLoad("P");
                            // btncancel.Text = "Cancel";


                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";

                            if (Convert.ToInt32(txtvouyear.Text) > 2011)
                            {
                                getdetails();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sales Invoice", "alertify.alert('Invalid PI Number');", true);
                            txtinv.Text = "";
                            grd.DataSource = Utility.Fn_GetEmptyDataTable();
                            grd.DataBind();
                            GrdFA.DataSource = Utility.Fn_GetEmptyDataTable();
                            GrdFA.DataBind();
                            // btncancel.Text = "&Back";

                            btncancel.ToolTip = "Back";
                            btncancel1.Attributes["class"] = "btn ico-back";
                            txtclear();
                        }

                    }

                    if (frmname == "Sales Invoice" || frmname == "Purchase Invoice")
                    {
                        if (grd.Rows.Count == 0)
                        {
                            if (chkmbl.Checked == false)
                            {
                                //  btnfill.Enabled = True
                                //btnfill.Enabled = True
                            }
                            else
                            {
                                //   btnfill.Enabled = False
                                //btnfill.Enabled = False
                            }
                        }
                        else
                        {
                            //  btnfill.Enabled = False
                            //btnfill.Enabled = False
                        }
                    }

                }

                txtTotal.Text = "0";
                double amt = 0.0;
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    amt += (Convert.ToDouble(grd.Rows[i].Cells[8].Text));


                }
                txtTotal.Text = amt.ToString("#,0.00");
                UserRights();

                /*if (txtinv.Text.ToString() != "")
                {
                    if (frmname == "OS DN" || frmname == "OS CN" || frmname == "OSPI" || frmname == "OSSI" || frmname == "OSDNCN JV" || frmname == "OSDNCNJV")
                    {
                        //getosdncndetails();
                    }
                    else
                    {
                        getdetails();
                    }

                    //HORM = false;
                    //modulename();
                }*/


                //Session["HeadTranType"] = Hid_HeadTrantype.Value;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void GrdLoad(String voutype)
        {
            try
            {
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());


                DtInfo = INVOICEobj.GetLVDetails(Convert.ToInt32(txtinv.Text), Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(txtvouyear.Text), branchid);
                //}
                //else if (voutype == "V")
                //{
                //    DtInfo = INVOICEobj.GetInvoiceDetails(Convert.ToInt32(txtinv.Text), "V", Convert.ToInt32(txtvouyear.Text), branchid);
                //}
                //else if (voutype == "E")
                //{
                //    DtInfo = INVOICEobj.GetInvoiceDetails(Convert.ToInt32(txtinv.Text), "E", Convert.ToInt32(txtvouyear.Text), branchid);
                //}
                //else if (voutype == "B")
                //{
                //    DtInfo = INVOICEobj.GetInvoiceDetails(Convert.ToInt32(txtinv.Text), "B", Convert.ToInt32(txtvouyear.Text), branchid);
                //}
                //else
                //{
                //    DtInfo = INVOICEobj.GetPADetails(Convert.ToInt32(txtinv.Text), Convert.ToInt32(txtvouyear.Text), branchid);
                //}
                grd.DataSource = DtInfo;
                grd.DataBind();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txtvouyear_TextChanged(object sender, EventArgs e)
        {
            try
            {

                strTranType = Session["StrTranTypeO"].ToString();
                //if (Request.QueryString.ToString().Contains("type"))
                //{
                //    frmname = Request.QueryString["type"].ToString();
                //}
                //if (Request.QueryString.ToString().Contains("FormName"))
                //{
                //    frmname = Request.QueryString["FormName"].ToString();
                //}
                frmname = ddl_voutype.SelectedItem.Text;
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());

                if (txtinv.Text.Trim() != "" && txtvouyear.Text.Trim() != "")
                {
                    if (frmname == "Sales Invoice" || frmname == "DNHead" || frmname == "CNHead" || frmname == "InvoiceWoJ" || frmname == "Bill of Supply")
                    {
                        if (frmname == "Sales Invoice")
                        {
                            vtype = "I";
                            DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 1, Convert.ToInt32(txtvouyear.Text), branchid);
                        }
                        else if (frmname == "InvoiceWoJ")
                        {
                            vtype = "I";
                            DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 1, Convert.ToInt32(txtvouyear.Text), branchid);
                        }
                        else if (frmname == "DNHead")
                        {
                            vtype = "V";
                            DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 7, Convert.ToInt32(txtvouyear.Text), branchid);
                        }
                        else if (frmname == "CNHead")
                        {
                            vtype = "E";
                            DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 8, Convert.ToInt32(txtvouyear.Text), branchid);
                        }
                        else if (frmname == "Bill of Supply")
                        {
                            vtype = "B";
                            DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 20, Convert.ToInt32(txtvouyear.Text), branchid);
                        }
                        if (DtSHead.Rows.Count > 0)
                        {
                            HdnJobNo.Value = DtSHead.Rows[0][3].ToString();
                            custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                            intcustid = custid;
                            txtto.Text = customerobj.GetCustomername(custid);
                            city = customerobj.GetCustlocation(custid);
                            cityid = portobj.GetNPortid(city);
                            txtblno.Text = DtSHead.Rows[0][5].ToString();
                            approvedby = Convert.ToInt32(DtSHead.Rows[0][7].ToString());
                            txtremarks.Text = DtSHead.Rows[0]["remarks"].ToString();
                            billtype = DtSHead.Rows[0][12].ToString();
                            fatransfer = DtSHead.Rows[0][13].ToString();
                            voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                            txtdate.Text = voudate.ToString("dd/MM/yyyy");
                            cmbbill.SelectedValue = INVOICEobj.GetBillType(Convert.ToChar(billtype));
                            txtaddress.Text = customerobj.GetCustomerAddress(txtto.Text.Trim(), "C", city);
                            if (strTranType == "OE" || strTranType == "OI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetFEI();
                            }
                            else if (strTranType == "AE" || strTranType == "AI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetAEI();
                            }
                            else
                            {
                                GetCHA();
                            }

                            GrdLoad(vtype);
                            // btncancel.Text = "Cancel";

                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sales Invoice", "alertify.alert('Invalid Invoice Number');", true);
                            txtinv.Text = "";
                            txtclear();
                            // btncancel.Text = "Back";

                            btncancel.ToolTip = "Back";
                            btncancel1.Attributes["class"] = "btn ico-back";
                        }
                    }
                    else
                    {
                        DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 2, Convert.ToInt32(txtvouyear.Text), branchid);
                        if (DtSHead.Rows.Count > 0)
                        {
                            HdnJobNo.Value = DtSHead.Rows[0][3].ToString();
                            custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                            intcustid = custid;
                            txtto.Text = customerobj.GetCustomername(custid);
                            city = customerobj.GetCustlocation(custid);
                            cityid = portobj.GetNPortid(city);
                            txtblno.Text = DtSHead.Rows[0][5].ToString();
                            approvedby = Convert.ToInt32(DtSHead.Rows[0][7].ToString());
                            txtremarks.Text = DtSHead.Rows[0]["remarks"].ToString();
                            billtype = DtSHead.Rows[0][12].ToString();
                            fatransfer = DtSHead.Rows[0][13].ToString();
                            voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                            txtdate.Text = voudate.ToString("dd/MM/yyyy");
                            cmbbill.SelectedValue = INVOICEobj.GetBillType(Convert.ToChar(billtype));
                            txtaddress.Text = customerobj.GetCustomerAddress(txtto.Text.Trim(), "C", city);

                            if (strTranType == "OE" || strTranType == "OI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetFEI();
                            }
                            else if (strTranType == "AE" || strTranType == "AI")
                            {
                                Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(HdnJobNo.Value), strTranType, branchid);
                                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    blno = Dt.Rows[i][0].ToString();
                                    if (blno == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                    }
                                }
                                GetAEI();
                            }
                            else
                            {
                                GetCHA();
                            }

                            //btnsave.Text = "Update";
                            GrdLoad("P");
                            //  btncancel.Text = "Cancel";

                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sales Invoice", "alertify.alert('Invalid PI Number');", true);
                            txtinv.Text = "";
                            //  btncancel.Text = "&Back";

                            btncancel.ToolTip = "Back";
                            btncancel1.Attributes["class"] = "btn ico-back";
                            txtclear();
                        }
                    }


                    if (frmname == "Sales Invoice" || frmname == "Purchase Invoice")
                    {
                        if (grd.Rows.Count == 0)
                        {
                            if (chkmbl.Checked == false)
                            {
                                //  btnfill.Enabled = True
                                //btnfill.Enabled = True
                            }
                            else
                            {
                                //   btnfill.Enabled = False
                                //btnfill.Enabled = False
                            }
                        }
                        else
                        {
                            //  btnfill.Enabled = False
                            //btnfill.Enabled = False
                        }
                    }
                }

                txtTotal.Text = "0";
                double amt1 = 0.0;
                for (int i = 0; i <= grd.Rows.Count - 1; i++)
                {
                    amt1 += (Convert.ToDouble(grd.Rows[i].Cells[8].Text));


                }
                txtTotal.Text = amt1.ToString("#,0.00");
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            DataTable dtnew = (DataTable)Session["CustomerDetails"];
            DataTable dtLi = new DataTable();
            DataView data1 = dtnew.DefaultView;
            data1.RowFilter = "customername = '" + txtto.Text + "' ";
            dtLi = data1.ToTable();

            if (txtto.Text != "")
            {
                intcustid = Convert.ToInt32(dtLi.Rows[0]["customerid"].ToString());
                cityid = Convert.ToInt32(dtLi.Rows[0]["city"].ToString());
                txtto.Text = dtLi.Rows[0]["customername"].ToString();
                txtaddress.Text = dtLi.Rows[0]["address"].ToString();
            }

            strTranType = Session["StrTranType"].ToString();
            //if (Request.QueryString.ToString().Contains("type"))
            //{
            //    frmname = Request.QueryString["type"].ToString();
            //}
            //if (Request.QueryString.ToString().Contains("FormName"))
            //{
            //    frmname = Request.QueryString["FormName"].ToString();
            //}
            frmname = ddl_voutype.SelectedItem.Text;
            branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
            divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());

            if (txtto.Text != "")
            {
                if (returnval == true)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Sales Invoice", "alertify.alert('Select Correct Customer Name');", true);
                    txtto.Text = "";
                    txtto.Focus();
                }
            }

            if (txtinv.Text == "")
            {
                if (txtto.Text == "")
                {
                    txtaddress.Text = "";
                }
                else
                {
                    if (frmname == "Sales Invoice" || frmname == "DNHead" || frmname == "CNHead" || frmname == "Bill of Supply")
                    {

                        DtSHead = INVOICEobj.CheckLVCustblno(txtblno.Text, intcustid, strTranType, Convert.ToInt32(ddl_voutype.SelectedValue), branchid, Convert.ToInt32(txtvouyear.Text), 'N');


                        if (DtSHead.Rows.Count > 0)
                        {
                            blno = DtSHead.Rows[0][5].ToString();
                            custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                            intcustid = custid;
                            cust = customerobj.GetCustomername(custid);
                            if (txtblno.Text == blno && txtto.Text == cust)
                            {
                                //    string msg;
                                //    if(frmname  == "Sales Invoice")
                                //    {
                                //         msg = "Do U Want Add One More Invoice";
                                //    }
                                //    else
                                //    {
                                //        msg = "Do U Want Add One More Payment Advise";
                                //    }

                                //}

                                txtinv.Text = DtSHead.Rows[0][0].ToString();
                                txtremarks.Text = DtSHead.Rows[0][10].ToString();
                                billtype = DtSHead.Rows[0][12].ToString();
                                fatransfer = DtSHead.Rows[0][13].ToString();
                                voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                                txtdate.Text = voudate.ToString("dd/MM/yyyy");
                                cmbbill.SelectedValue = INVOICEobj.GetBillType(Convert.ToChar(billtype));
                                if (frmname == "Sales Invoice" || frmname == "Bill of Supply")
                                {
                                    GrdLoad("I");
                                }
                                else if (frmname == "DNHead")
                                {
                                    GrdLoad("V");
                                }
                                else if (frmname == "CNHead")
                                {
                                    GrdLoad("E");
                                }
                                else
                                {
                                    GrdLoad("P");
                                }
                            }
                        }
                        else
                        {
                            txtinv.Text = "";
                            txtremarks.Text = "";
                        }

                    }
                    else
                    {
                        DtSHead = INVOICEobj.CheckLVCustblno(txtblno.Text, intcustid, strTranType, Convert.ToInt32(ddl_voutype.SelectedValue), branchid, Convert.ToInt32(txtvouyear.Text), 'N');
                        if (DtSHead.Rows.Count > 0)
                        {
                            blno = DtSHead.Rows[0][5].ToString();
                            custid = Convert.ToInt32(DtSHead.Rows[0][4].ToString());
                            intcustid = custid;
                            cust = customerobj.GetCustomername(custid);
                            if (txtblno.Text == blno && txtto.Text == cust)
                            {
                                txtinv.Text = DtSHead.Rows[0][0].ToString();
                                txtremarks.Text = DtSHead.Rows[0][10].ToString();
                                billtype = DtSHead.Rows[0][12].ToString();
                                fatransfer = DtSHead.Rows[0][13].ToString();
                                voudate = Convert.ToDateTime(DtSHead.Rows[0][1].ToString());
                                txtdate.Text = voudate.ToString("dd/MM/yyyy");
                                cmbbill.SelectedValue = INVOICEobj.GetBillType(Convert.ToChar(billtype));

                                if (frmname == "Sales Invoice" || frmname == "Bill of Supply")
                                {
                                    GrdLoad("I");
                                }
                                else if (frmname == "DNHead")
                                {
                                    GrdLoad("V");
                                }
                                else if (frmname == "CNHead")
                                {
                                    GrdLoad("E");
                                }
                                else
                                {
                                    GrdLoad("P");
                                }
                            }
                        }
                        else
                        {
                            txtinv.Text = "";
                            txtremarks.Text = "";
                        }

                    }

                }
            }
            UserRights();
        }

        private void CheckCustomer()
        {
            if (txtto.Text != "")
            {
                customerid = customerobj.GetCustomerid(txtto.Text.ToUpper());
                if (customerid == 0)
                {
                    returnval = true;
                }
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            if (btncancel.ToolTip == "Cancel")
            {
                lbl_appr.Visible = false;
                lbl_txt.Visible = false;
                txtEnable();
                txtclear();
                //   btncancel.Text = "Back";

                btncancel.ToolTip = "Back";
                btncancel1.Attributes["class"] = "btn ico-back";
                btncancel.Text = "Back";
                txtTotal.Text = "";
                txtdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
                fatransfer = "";
                txtcreditapp.Text = "";
                txtcreditapp.Enabled = true;
                VourText();
                grd.DataSource = Utility.Fn_GetEmptyDataTable();
                grd.DataBind();
                GrdFA.DataSource = Utility.Fn_GetEmptyDataTable();
                GrdFA.DataBind();
                txt_trantype.Text = "";
                txtsupplyto.Text = "";
                txtsupplytoAddress.Text = "";
                UserRights();
                ddl_voutype.SelectedValue = "0";
            }

            else
            {
                // this.Response.End();

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI")
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

        private void txtEnable()
        {
            //cmbbill.Enabled = true;
            txtblno.Enabled = true;
            txtto.Enabled = true;
            txtinv.Enabled = true;
            txtvouyear.Enabled = true;
            txtvessel.Enabled = true;
            txtdes.Enabled = true;
            txtshipper.Enabled = true;
            txtconsignee.Enabled = true;
            txtnotify.Enabled = true;
            txtremarks.Enabled = true;
            txtagent.Enabled = true;
            txtmlo.Enabled = true;
            txtcnf.Enabled = true;
            lstvol.Enabled = true;
            lstcon.Enabled = true;
        }

        public void txtDisableNew()
        {
            cmbbill.Enabled = false;
            txtblno.Enabled = false;
            txtto.Enabled = false;
            txtinv.Enabled = false;
            txtvouyear.Enabled = false;
            txtvessel.Enabled = false;
            txtdes.Enabled = false;
            txtshipper.Enabled = false;
            txtconsignee.Enabled = false;
            txtnotify.Enabled = false;
            txtremarks.Enabled = false;
            txtagent.Enabled = false;
            txtmlo.Enabled = false;
            txtcnf.Enabled = false;
            lstvol.Enabled = false;
            lstcon.Enabled = false;
        }

        protected void chkmbl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmbl.Checked == true)
            {
                Session["mblchk"] = "true";
            }
            else
            {
                Session["mblchk"] = "false";
            }
        }

        /*protected void btnview_Click(object sender, EventArgs e)
        {
            string containernos = "";
            int i;
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            string bltype;
            if (chkmbl.Checked == true)
            {
                bltype = "M";
            }
            else
            {
                bltype = "H";
            }
            DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            string trantype = Session["StrTranType"].ToString();

            if (Session["StrTranType"].ToString() == "FE" | Session["StrTranType"].ToString() == "FI")
            {
                if (lstvol.Items.Count > 0)
                {
                    containernos = lstvol.Items[0].ToString();
                }
                if (chkmbl.Checked == true)
                {
                    for (i = 1; i <= lstvol.Items.Count - 1; i++)
                    {
                        containernos = containernos + " / " + lstvol.Items[i].ToString();
                    }
                }
                else
                {
                    for (i = 1; i <= lstvol.Items.Count - 3; i++)
                    {
                        containernos = containernos + " / " + lstvol.Items[i].ToString();
                    }
                }
            }
            
            if (lbl_InvHeader.Text == "InvoiceWoJ")
            {
                if (txtinv.Text != "")
                {
                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        str_RptName = "FEInvoiceWOJ.rpt";
                        str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text;
                        str_sp = "Lcurr=INR";
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                }
            }
            else
            {
                if (chkmbl.Checked == false)
                {
                    if (lbl_InvHeader.Text == "Sales Invoice")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "InvoiceRegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\"";
                            str_sp = "Title=INVOICE REGISTER ";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                str_RptName = "FEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                               // str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                str_RptName = "FIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                str_RptName = "AEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                //str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;

                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                str_RptName = "AIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                //str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                //str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }

                        }
                    }
                    else
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "PARegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\"";
                            str_sf = "{PAHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {PAHead.vouyear}=" + txtvouyear.Text + " and {PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\"";
                            str_sp = "Title=CREDIT NOTE OPERATIONS REGISTER";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                               
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FEPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + "and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FIPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + "and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AEPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                               
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AIPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "CH")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                }
                else
                {
                    if (lbl_InvHeader.Text == "Invoice")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "InvoiceRegister.rpt";
                            str_sp = "INVOICE REGISTER";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}='" + Session["StrTranType"].ToString();
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                str_RptName = "FEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                str_RptName = "FIMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                str_RptName = "AEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                str_RptName = "AIMInvoice.rpt";
                                str_sp = "Lcurr=INR";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "PARegister.rpt";
                            str_sp = "Title=CREDIT NOTE OPERATIONS REGISTER";
                            str_sf = "{PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text + "' and {PAHead.trantype}='" + Session["StrTranType"].ToString() + "'";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (Session["StrTranType"].ToString() == "FE")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FEMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "FI")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FIMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "AE")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AEMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;

                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }

                            else if (Session["StrTranType"].ToString() == "AI")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AIMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (Session["StrTranType"].ToString() == "CH")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + Session["StrTranType"].ToString() + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                //str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;

                                str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    if (lbl_InvHeader.Text == "Invoice")
                    {
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 22, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " InvHVew");
                                break;
                            case "FI":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 23, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " InvHVew");
                                break;
                            case "AE":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 24, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " InvHVew");
                                break;
                            case "AI":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 25, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " InvHVew");
                                break;
                            case "CH":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 26, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " InvHVew");
                                break;
                        }
                    }

                    else
                    {
                        switch (Session["StrTranType"].ToString())
                        {
                            case "FE":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 27, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " PAHVew");
                                break;
                            case "FI":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 28, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " PAHVew");
                                break;
                            case "AE":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 29, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " PAHVew");
                                break;
                            case "AI":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 30, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " PAHVew");
                                break;
                            case "CH":
                                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 31, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranType"].ToString() + " PAHVew");
                                break;
                        }
                    }
                }
            }
            UserRights();
        }*/


        //GST

        protected void btnview_Click(object sender, EventArgs e)
        {

            DateTime get_date, GST_date;
            get_date = Convert.ToDateTime(Utility.fn_ConvertDate(txtdate.Text));
            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            string containernos = "";
            int i;
            string str_RptName = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "", header = "";
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            string bltype;
            if (chkmbl.Checked == true)
            {
                bltype = "M";
            }
            else
            {
                bltype = "H";
            }
            int countryid = obj_UP.Get_countrycode(Session["LoginBranchName"].ToString());

            //DataAccess.LogDetails obj_da_Logobj = new DataAccess.LogDetails();
            //string trantype = Session["StrTranType"].ToString();
            string trantype = Session["StrTranTypeO"].ToString();
            strTranType = Session["StrTranTypeO"].ToString();
            if (Session["StrTranTypeO"] == "AC")
            {
                strTranType = hid_Trantype.Value;
            }
            if (strTranType == "OE" | strTranType == "OI")
            {
                if (lstvol.Items.Count > 0)
                {
                    containernos = lstvol.Items[0].ToString();
                }
                if (chkmbl.Checked == true)
                {
                    for (i = 1; i <= lstvol.Items.Count - 1; i++)
                    {
                        containernos = containernos + " / " + lstvol.Items[i].ToString();
                    }
                }
                else
                {
                    for (i = 1; i <= lstvol.Items.Count - 3; i++)
                    {
                        containernos = containernos + " / " + lstvol.Items[i].ToString();
                    }
                }
            }
            lbl_InvHeader.Text = ddl_voutype.SelectedItem.Text;
            if (lbl_InvHeader.Text == "InvoiceWoJ")
            {
                if (txtinv.Text != "")
                {
                    if (strTranType == "OE")
                    {
                        str_RptName = "FEInvoiceWOJ.rpt";
                        str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text;
                        str_sp = "Lcurr=INR";
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                }
            }
            else
            {
                if (chkmbl.Checked == false)
                {
                    if (lbl_InvHeader.Text == "Sales Invoice")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "InvoiceRegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + strTranType + "\"";
                            str_sp = "Title=INVOICE REGISTER ";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;


                                if (get_date >= GST_date)
                                {

                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["str_sfs"] = str_sf;
                                    Session["str_sp"] = str_sp;
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }


                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                    }

                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else  if (lbl_InvHeader.Text == "Sales Invoice OC")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "InvoiceRegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + strTranType + "\"";
                            str_sp = "Title=INVOICE REGISTER ";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;


                                if (get_date >= GST_date)
                                {

                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["str_sfs"] = str_sf;
                                    Session["str_sp"] = str_sp;
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script += "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }


                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                    }

                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Bill of Supply")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "BOSRegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + strTranType + "\"";
                            str_sp = "Title=Bill of Supply REGISTER ";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;


                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["str_sfs"] = str_sf;
                                    Session["str_sp"] = str_sp;
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Bill of Supply OC")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "BOSRegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + strTranType + "\"";
                            str_sp = "Title=Bill of Supply REGISTER ";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;


                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["str_sfs"] = str_sf;
                                    Session["str_sp"] = str_sp;
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + "and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Title=INVOICE REGISTER " + containernos;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    if (lbl_InvHeader.Text == "Debit Note" || lbl_InvHeader.Text == "Debit Note - Others")
                    {
                        header = "DN";
                        if (txtinv.Text == "")
                        {
                            str_RptName = "OthDNRegister.rpt";
                            Session["str_sp"] = "Title=Debit Note Register";
                            Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text;

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                            //-------------------------------------------------------------

                            str_RptName = "OthDNRegisterNew.rpt";
                            Session["str_sp"] = "Title=Debit Note Raised After Job Closing";
                            Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNHead.dndate} > {RPTJobDetails.closeddate}";

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FEDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                       str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "OI" || strTranType == "FC")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FIDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    //Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }



                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AEDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";

                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    //Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }

                                str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AIDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";

                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {

                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHADN.rpt";

                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                    }
                    if (lbl_InvHeader.Text == "Credit Note" || lbl_InvHeader.Text == "Credit Note - Others")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "OthCNRegister.rpt";
                            Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text;
                            Session["str_sp"] = "Title=Credit Note Register";

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                            str_RptName = "OthCNRegisterNew.rpt";
                            Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + "and {CNHead.cndate} > {RPTJobDetails.closeddate}";
                            Session["str_sp"] = "Title=Credit Note Raised After Job Closing";

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                        }
                        else
                        {
                            header = "CN";
                            if (strTranType == "OE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FECNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FECN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FICNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FICN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AECNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AECN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AICNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AICN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHACN.rpt";
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                    }

                    else if (lbl_InvHeader.Text=="Purchase Invoice")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "PARegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + strTranType + "\"";
                            str_sf = "{PAHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {PAHead.vouyear}=" + txtvouyear.Text + " and {PAHead.trantype}=\"" + strTranType + "\"";
                            str_sp = "Title=CREDIT NOTE OPERATIONS REGISTER";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;

                        }
                        else
                        {
                            if (strTranType == "OE")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FEPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + "and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }


                                    //   str_Scripczxt = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FIPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + "and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AEPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AIPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Purchase Invoice OC")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "PARegister.rpt";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}=\"" + strTranType + "\"";
                            str_sf = "{PAHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {PAHead.vouyear}=" + txtvouyear.Text + " and {PAHead.trantype}=\"" + strTranType + "\"";
                            str_sp = "Title=CREDIT NOTE OPERATIONS REGISTER";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;

                        }
                        else
                        {
                            if (strTranType == "OE")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FEPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + "and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + "and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }


                                    //   str_Scripczxt = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FIPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + "and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AEPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {

                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AIPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                }
                else
                {
                    if (lbl_InvHeader.Text == "Sales Invoice")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "InvoiceRegister.rpt";
                            str_sp = "INVOICE REGISTER";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}='" + strTranType;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIMInvoice.rpt";
                                str_sp = "Lcurr=INR";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&voutype=1" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    if (lbl_InvHeader.Text == "Sales Invoice OC")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "InvoiceRegister.rpt";
                            str_sp = "INVOICE REGISTER";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}='" + strTranType;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIMInvoice.rpt";
                                str_sp = "Lcurr=INR";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice FC" + "&voutype=22" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Bill of Supply")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "BOSRegister.rpt";
                            str_sp = "Bill of Supply REGISTER";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}='" + strTranType;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIMInvoice.rpt";
                                str_sp = "Lcurr=INR";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&voutype=20" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Bill of Supply OC")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "BOSRegister.rpt";
                            str_sp = "Bill of Supply REGISTER";
                            str_sf = "{InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text + " and {InvoiceHead.trantype}='" + strTranType;
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                str_RptName = "FEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                str_RptName = "FIMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR~container=" + containernos;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                str_RptName = "AEMInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                str_RptName = "AIMInvoice.rpt";
                                str_sp = "Lcurr=INR";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        //  str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";


                                        str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {


                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHInvoice.rpt";
                                str_sf = "{InvoiceHead.trantype}=\"" + strTranType + "\" and {InvoiceHead.invoiceno}=" + txtinv.Text + " and {InvoiceHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Bill of Supply FC" + "&voutype=24" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Debit Note" || lbl_InvHeader.Text == "Debit Note - Others")
                    {
                        header = "DN";
                        if (txtinv.Text == "")
                        {
                            str_RptName = "OthDNRegister.rpt";
                            Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text;
                            Session["str_sp"] = "Title=Debit Note Register";

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);


                            str_RptName = "OthDNRegisterNew.rpt";
                            Session["str_sfs"] = "{DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + "and {DNHead.dndate} > {RPTJobDetails.closeddate}";
                            Session["str_sp"] = "Title=Debit Note Raised After Job Closing";

                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FEMDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEMDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "OI" || strTranType == "FC")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FIMDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIMDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AEMDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEMDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AIMDNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIMDN.rpt";
                                }
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHDN.rpt";
                                Session["str_sfs"] = "{DNHead.trantype}='" + strTranType + "' and {DNHead.dnno}=" + txtinv.Text + " and {DNHead.branchid}=" + BranchID + " and {DNHead.vouyear}=" + txtvouyear.Text + " and {DNDetails.branchid}=" + BranchID + " and {DNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=7" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Credit Note" || lbl_InvHeader.Text == "Credit Note - Others")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "OthCNRegister.rpt";
                            Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text;
                            Session["str_sp"] = "Title=Credit Note Register";
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);

                            str_RptName = "OthCNRegisterNew.rpt";
                            Session["str_sfs"] = "{CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + "and {CNHead.cndate} > {RPTJobDetails.closeddate}";
                            Session["str_sp"] = "Title=Credit Note Raised After Job Closing";
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                        }
                        else
                        {
                            header = "CN";
                            if (strTranType == "OE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FEMCNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEMCN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "FIMCNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIMCN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR~container=" + containernos;
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AEMCNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEMCN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                if (customerobj.GetCustomerType(custid) == "P")
                                {
                                    agent = "P";
                                    str_RptName = "AIMCNAgent.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIMCN.rpt";
                                }
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                str_RptName = "CHACN.rpt";
                                Session["str_sfs"] = "{CNHead.trantype}='" + strTranType + "' and {CNHead.cnno}=" + txtinv.Text + " and {CNHead.branchid}=" + BranchID + " and {CNHead.vouyear}=" + txtvouyear.Text + " and {CNDetails.branchid}=" + BranchID + " and {CNDetails.vouyear}=" + txtvouyear.Text;
                                Session["str_sp"] = "Lcurr=INR";
                                if (get_date >= GST_date)
                                {
                                    str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&total=" + 0 + "&trantype=" + strTranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&customertype=" + agent + "&branchid=" + hf_LogBr_ID.Value + "&voutype=8" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), str_Script, true);
                            }
                        }
                    }
                    else if(lbl_InvHeader.Text=="Purchase Invoice")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "PARegister.rpt";
                            str_sp = "Title=CREDIT NOTE OPERATIONS REGISTER";
                            str_sf = "{PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text + "' and {PAHead.trantype}='" + strTranType + "'";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FEMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FIMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AEMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AIMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&voutype=2" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                    else if (lbl_InvHeader.Text == "Purchase Invoice OC")
                    {
                        if (txtinv.Text == "")
                        {
                            str_RptName = "PARegister.rpt";
                            str_sp = "Title=CREDIT NOTE OPERATIONS REGISTER";
                            str_sf = "{PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text + "' and {PAHead.trantype}='" + strTranType + "'";
                            str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Shipment Details", str_Script, true);
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else
                        {
                            if (strTranType == "OE")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FEMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FEMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "OI")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "FIMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "FIMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AE")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AEMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AEMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //  str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "AI")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "AIMPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "AIMPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    //str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                            else if (strTranType == "CH")
                            {
                                if (hid_approvedby.Value != "0")
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                else
                                {
                                    str_RptName = "CHAPA.rpt";
                                }
                                str_sf = "{PAHead.trantype}=\"" + strTranType + "\" and {PAHead.pano}=" + txtinv.Text + " and {PAHead.branchid}=" + Session["LoginBranchid"].ToString() + " and {PAHead.vouyear}=" + txtvouyear.Text;
                                str_sp = "Lcurr=INR";
                                Session["str_sfs"] = str_sf;
                                Session["str_sp"] = str_sp;
                                if (get_date >= GST_date && txtinv.Text != "")
                                {
                                    if( (countryid == 1102)||(countryid == 102))
                                    {
                                        // str_Script += "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "Invoice" + "&" + this.Page.ClientQueryString + "','','');";

                                        str_Script = "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA FC" + "&voutype=23" + "&" + this.Page.ClientQueryString + "','','');";
                                    }
                                    else
                                    {
                                        str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";

                                    }
                                    // str_Script = "window.open('../Reportasp/Invoicerpt.aspx?Invoiceno=" + txtinv.Text + "&vouyear=" + txtvouyear.Text + "&trantype=" + strTranType + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + "PA" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Quotation", str_Script, true);
                            }
                        }
                    }
                }
            }

            if (lbl_InvHeader.Text == "Sales Invoice")
            {
                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10001, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "Inv # -" + txtinv.Text + "/ Year-" + txtvouyear.Text + "/ " + strTranType + " /Viewed");
            }
            else if (lbl_InvHeader.Text == "Purchase Invoice")
            {
                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10002, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "PA # -" + txtinv.Text + "/ Year-" + txtvouyear.Text + "/ " + strTranType + " /Viewed");
            }
            else if (lbl_InvHeader.Text == "Bill of Supply")
            {
                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10003, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "BOS # -" + txtinv.Text + "/ Year-" + txtvouyear.Text + "/ " + strTranType + " /Viewed");
            }
            else if (lbl_InvHeader.Text == "Debit Note")
            {
                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10008, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "DN # -" + txtinv.Text + "/ Year-" + txtvouyear.Text + "/ " + strTranType + " /Viewed");
            }
            else if (lbl_InvHeader.Text == "Credit Note")
            {
                obj_da_Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10009, 3, Convert.ToInt32(Session["LoginBranchid"].ToString()), "CN # -" + txtinv.Text + "/ Year-" + txtvouyear.Text + "/ " + strTranType + " /Viewed");
            }

            UserRights();
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
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            /*if (lbl_InvHeader.Text == "Invoice")
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1013, "Inv", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1020, "Inv", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1027, "Inv", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1034, "Inv", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1041, "Inv", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
            }
            else if (lbl_InvHeader.Text == "Purchase Invoice")
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1014, "PA", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1021, "PA", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1028, "PA", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1035, "PA", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1042, "PA", txtinv.Text, txtinv.Text, Session["StrTranType"].ToString());
                }
            }*/
            strTranType = hid_Trantype.Value;
            int Vyear = 0;
            if (txtvouyear.Text != null || txtvouyear.Text != "")
            {
                Vyear = Convert.ToInt32(txtvouyear.Text);
            }

            if (lbl_InvHeader.Text == "Invoice")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10001, "Inv", txtinv.Text, txtinv.Text, strTranType, Vyear);
            }
            else if (lbl_InvHeader.Text == "Purchase Invoice")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10002, "PA", txtinv.Text, txtinv.Text, strTranType, Vyear);
            }
            else if (lbl_InvHeader.Text == "Bill of Supply")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10003, "BOS", txtinv.Text, txtinv.Text, strTranType, Vyear);
            }
            else if (lbl_InvHeader.Text == "Debit Note")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10008, "DN", txtinv.Text, txtinv.Text, strTranType, Vyear);
            }
            else if (lbl_InvHeader.Text == "Credit Note")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 10009, "CN", txtinv.Text, txtinv.Text, strTranType, Vyear);
            }

            if (txtinv.Text != "")
            {
                JobInput.Text = txtinv.Text;
                if (lbl_InvHeader.Text == "Sales Invoice")
                {
                    lbl_no.InnerText = "Invoice # : ";
                }
                else if (lbl_InvHeader.Text == "Purchase Invoice")
                {
                    lbl_no.InnerText = "Purchase Invoice # : ";
                }
                else if (lbl_InvHeader.Text == "Debit Note")
                {
                    lbl_no.InnerText = "Debit Note # : ";
                }
                else if (lbl_InvHeader.Text == "Credit Note")
                {
                    lbl_no.InnerText = "Credit Note # : ";
                }
            }
            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }

        protected void GrdFA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (frmname == "OS DN")
                {
                    if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;

                    }
                    else if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                        e.Row.Cells[2].Text = "";
                    }
                }
                else if (frmname == "OS CN")
                {
                    if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                    }
                    else if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                    }
                }
                else if (frmname == "OSDNCNJV" || frmname == "OSDNCN JV")
                {
                    if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                    }
                    else if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                    }
                }
                else
                {
                    if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Cr")
                    {
                        e.Row.Cells[1].Text = "";
                        e.Row.Cells[2].Text = e.Row.Cells[2].Text;
                    }
                    else if (GrdFA.DataKeys[e.Row.RowIndex].Values["LedgerType"].ToString() == "Dr")
                    {
                        e.Row.Cells[2].Text = "";
                        e.Row.Cells[1].Text = e.Row.Cells[1].Text;
                    }
                }
            }
        }

        //public void getosdncndetails()
        //{
        //    voutypeid = FAobj.Selvoutypeid(Session["vname"].ToString(), FADbName);
        //    int logcorid = 0;
        //    logcorid = hrempobj.GetBranchId(divisionid, "CORPORATE");
        //    osvtype = hf_OSV_Type.Value.ToString().Trim();

        //    if (osvtype != "" && osvtype != null)
        //    {
        //        dtfa = FAobj.SelFAVoucher4OSVou(Convert.ToInt32(txtinv.Text), logcorid, divisionid, voutypeid, Convert.ToInt32(txtvouyear.Text), FADbName, branchid, osvtype);
        //    }
        //    else if (PBranch_ID == 0 || LView_Flag == true)
        //    {
        //        dtfa = FAobj.SelFAVoucher(Convert.ToInt32(txtinv.Text), branchid, divisionid, voutypeid, Convert.ToInt32(txtvouyear.Text), FADbName);
        //    }
        //    else
        //    {
        //        dtfa = FAobj.SelFAVoucher4BP(Convert.ToInt32(txtinv.Text), logcorid, divisionid, voutypeid, Convert.ToInt32(txtvouyear.Text), FADbName, branchid);
        //    }

        //    if (dtfa.Rows.Count > 0)
        //    {
        //        Hid_trantype.Value = dtfa.Rows[0]["trantype"].ToString();
        //        strTranType = Hid_trantype.Value;

        //        txtjobno.Text = dtfa.Rows[0]["jobno"].ToString();

        //        if (dtfa.Rows.Count > 0)
        //        {
        //            if (Session["vname"].ToString() == "OSSI")
        //            {
        //                DataRow dr_temp = dtfa.NewRow();
        //                dr_temp["ledgername"] = "Total";
        //                //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
        //                //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
        //                dtfa.Rows.Add(dr_temp);
        //                grd.DataSource = dtfa;
        //                grd.DataBind();
        //                if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
        //                {
        //                    grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
        //                }
        //                if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
        //                {
        //                    grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
        //                }

        //                //grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
        //                //grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
        //            }
        //            else if (Session["vname"].ToString() == "OSPI")
        //            {
        //                DataRow dr_temp = dtfa.NewRow();
        //                dr_temp["ledgername"] = "Total";
        //                //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
        //                //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
        //                dtfa.Rows.Add(dr_temp);
        //                grd.DataSource = dtfa;
        //                grd.DataBind();
        //                if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
        //                {
        //                    grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
        //                }
        //                if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
        //                {
        //                    grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
        //                }
        //                //grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
        //                // grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
        //            }
        //            else if (Session["vname"].ToString() == "OSDNCNJV" || Session["vname"].ToString() == "OSDNCN JV")
        //            {
        //                DataRow dr_temp = dtfa.NewRow();
        //                dr_temp["ledgername"] = "Total";
        //                //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'");
        //                //dr_temp["ledgeramount"] = dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'");
        //                dtfa.Rows.Add(dr_temp);
        //                grd.DataSource = dtfa;
        //                grd.DataBind();
        //                if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
        //                {
        //                    grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
        //                }
        //                if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
        //                {
        //                    grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
        //                }

        //                //grd.Rows[grd.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
        //                // grd.Rows[grd.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Please Enter the valid Voucher #');", true);
        //        Clear();
        //        DataTable dtEmpty = new DataTable();
        //        grd.DataSource = dtEmpty;
        //        grd.DataBind();
        //        return;
        //    }

        //    DataSet ds = new DataSet();
        //    ds = OSDNCN.RptOSDNCNFromJobNo(strTranType, Convert.ToInt32(txtjobno.Text), branchid);
        //    if (ds.Tables[1].Rows.Count > 0)
        //    {

        //    }
        //    else
        //    {
        //        if (ds.Tables[2].Rows.Count > 0)
        //        {

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Voucher Not Raised in this Job');", true);
        //            return;
        //        }
        //    }

        //    dt = ds.Tables[0];
        //    if (dt.Rows.Count != 0)
        //    {
        //        txtblno.Text = Convert.ToString(dt.Rows[0][7].ToString());

        //        if (strTranType == "FE" || strTranType == "FI" || strTranType == "FC")
        //        {
        //            txtvessel.Text = dt.Rows[0][5].ToString() + "  /  " + dt.Rows[0][6].ToString();
        //            HORM = true;
        //            object Obj_boolvalue = HORM;
        //            int Bool_Value = Convert.ToInt32(Obj_boolvalue);
        //            hid_BoolValue.Value = Bool_Value.ToString();
        //            getFEI();
        //        }
        //        else
        //        {
        //            txtvessel.Text = dt.Rows[0][5].ToString() + "  /  " + dt.Rows[0][6].ToString();
        //            HORM = true;
        //            object Obj_boolvalue = HORM;
        //            int Bool_Value = Convert.ToInt32(Obj_boolvalue);
        //            hid_BoolValue.Value = Bool_Value.ToString();
        //            getAEI();
        //        }
        //    }

        //    DataTable dtd = new DataTable();
        //    if (frmname == "OSDNCNJV" || frmname == "OSDNCN JV")
        //    {
        //        if (Convert.ToInt32(Session["LoginBranchid"]) == logcorid)
        //        {
        //            dtd = FAobj.SelFAVouHead4All(Convert.ToInt32(txtinv.Text), Convert.ToInt32(txtvouyear.Text), voutypeid, branchid, logcorid, FADbName);
        //        }
        //        else
        //        {
        //            dtd = FAobj.SelFAVouHead4All(Convert.ToInt32(txtinv.Text), Convert.ToInt32(txtvouyear.Text), voutypeid, branchid, 0, FADbName);
        //        }

        //        if (dtd.Rows.Count > 0)
        //        {
        //            //voudate = Convert.ToDateTime(Utility.fn_ConvertDate((dtd.Rows[0]["voudate"]).ToString()));
        //            voudate = Convert.ToDateTime(((dtd.Rows[0]["voudate"]).ToString()));
        //            txtremarks.Text = Convert.ToString(dtd.Rows[0]["narration"]);
        //            txtvoudate.Text = dtd.Rows[0]["fdate"].ToString() + " / " + voudate.DayOfWeek;
        //        }
        //    }
        //    else
        //    {
        //        dtd = OSDNCN.GetOSDCNDtls(Convert.ToInt32(txtjobno.Text), strTranType, Session["vname"].ToString(), branchid);
        //        if (dtd.Rows.Count > 0)
        //        {
        //            voudate = Convert.ToDateTime((dtd.Rows[0][1]).ToString());
        //            txtremarks.Text = Convert.ToString(dtd.Rows[0][5].ToString());
        //            txtvoudate.Text = dtd.Rows[0]["fdate"].ToString() + " / " + voudate.DayOfWeek;

        //            if (!string.IsNullOrEmpty(dtd.Rows[0]["preparedbyname"].ToString()))
        //            {
        //                lbl_txt.Visible = true;
        //                lbl_prepare.Text = dtd.Rows[0]["preparedbyname"].ToString();
        //            }

        //            if (!string.IsNullOrEmpty(dtd.Rows[0]["approvedbyname"].ToString()))
        //            {
        //                lbl_txt.Visible = true;
        //                lbl_Approve.Text = dtd.Rows[0]["approvedbyname"].ToString();
        //            }
        //        }
        //    }
        //}

        public void getdetails()
        {
            frmname = ddl_voutype.SelectedItem.Text;
            if (frmname == "Sales Invoice" || frmname == "Bill of Supply" || frmname == "Debit Note" || frmname == "InvoiceWoJ" || frmname == "Proforma Invoices" || frmname == "Extentions" || frmname == "FinalBills" || frmname == "Receipt - Bank")//temporary == "c - Bank"
            {
                string voutype = "";
                if (frmname == "Bill of Supply")
                {
                    voutype = "BOS";
                    vname = Session["vname"].ToString();
                }
                else
                {
                    voutype = Session["vname"].ToString();
                    vname = Session["vname"].ToString();
                }
                voutypeid = FAobj.Selvoutypeid(voutype, FADbName);
                int logcorid = 0;
                logcorid = hrempobj.GetBranchId(divisionid, "CORPORATE");

                //if (osvtype != "" && osvtype != null)
                //{
                //    dtfa = FAobj.SelFAVoucher4OSVou(Convert.ToInt32(txtinv.Text), logcorid, divisionid, voutypeid, Convert.ToInt32(txtvouyear.Text), FADbName, branchid, osvtype);
                //}
                //else
                //{
                //    if (PBranch_ID == 0 || LView_Flag == true)
                //    {
                dtfa = FAobj.SelFAVoucher(Convert.ToInt32(txtinv.Text), branchid, divisionid, voutypeid, Convert.ToInt32(txtvouyear.Text), FADbName);
                //    }
                //    else
                //    {
                //        dtfa = FAobj.SelFAVoucher4BP(Convert.ToInt32(txtinv.Text), logcorid, divisionid, voutypeid, Convert.ToInt32(txtvouyear.Text), FADbName, branchid);
                //    }
                //}

                if (dtfa.Rows.Count > 0)
                {
                    strTranType = dtfa.Rows[0]["trantype"].ToString();
                    //txtjobno.Text = dtfa.Rows[0]["jobno"].ToString();
                    if (grd.Rows.Count > 0)
                    {
                        for (i = 0; i <= grd.Rows.Count - 1; i++)
                        {
                            //grd.Rows.Remove(grd.Rows(0));
                        }
                    }

                    DataRow dr_temp = dtfa.NewRow();
                    dr_temp["ledgername"] = "Total";

                    dtfa.Rows.Add(dr_temp);
                    GrdFA.DataSource = dtfa;
                    GrdFA.DataBind();

                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                    {
                        GrdFA.Rows[GrdFA.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                    }
                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                    {
                        GrdFA.Rows[GrdFA.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    }
                }


                if (frmname == "Sales Invoice")
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 1, Convert.ToInt32(txtvouyear.Text), branchid);
                }
                else if (frmname == "Bill of Supply")
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 20, Convert.ToInt32(txtvouyear.Text), branchid);
                }
                else if (frmname == "InvoiceWoJ")
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 1, Convert.ToInt32(txtvouyear.Text), branchid);
                }
                else if (frmname == "Debit Note")
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, 7, Convert.ToInt32(txtvouyear.Text), branchid);
                }
                //else if (frmname == "Proforma Invoices")
                //{
                //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, "Proforma Invoices", Convert.ToInt32(txtvouyear.Text), branchid);
                //}
                //else if (frmname == "Extentions")
                //{
                //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, "Extentions", Convert.ToInt32(txtvouyear.Text), branchid);
                //}
                //else if (frmname == "FinalBills")
                //{
                //    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), strTranType, "FinalBills", Convert.ToInt32(txtvouyear.Text), branchid);
                //}

                lstagnst.Items.Clear();

                i = DtSHead.Rows.Count;
                if (i > 0)
                {
                    DataTable Against = new DataTable();
                    if (vname == "Invoices")
                    {
                        if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "I") != "0")
                        {
                            Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "I");
                            for (int x = 0; x <= Against.Rows.Count - 1; x++)
                            {
                                lstagnst.Items.Add(Against.Rows[x][0].ToString());
                            }
                        }
                    }
                    else if (vname == "Debit Note" || vname == "Debit Note - Others")
                    {
                        if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "V") != "0")
                        {
                            Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "V");
                            for (int x = 0; x <= Against.Rows.Count - 1; x++)
                            {
                                lstagnst.Items.Add(Against.Rows[x][0].ToString());
                            }
                        }
                    }
                    else if (vname == "Bill of Supply")
                    {
                        if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "B") != "0")
                        {
                            Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "B");
                            for (int x = 0; x <= Against.Rows.Count - 1; x++)
                            {
                                lstagnst.Items.Add(Against.Rows[x][0].ToString());
                            }
                        }
                    }
                }
            }
            else if (frmname == "Purchase Invoice" || frmname == "Credit Note")
            {
                voutypeid = FAobj.Selvoutypeid(Session["vname"].ToString(), FADbName);
                vname = Session["vname"].ToString();
                //if (PBranch_ID == 0 || LView_Flag == true)
                //{
                dtfa = FAobj.SelFAVoucher(Convert.ToInt32(txtinv.Text), branchid, divisionid, voutypeid, Convert.ToInt32(txtvouyear.Text), FADbName);
                //}
                //else
                //{
                //    int logcorid = 0;
                //    logcorid = hrempobj.GetBranchId(Div_Id, "CORPORATE");
                //    dtfa = FAobj.SelFAVoucher4BP(Convert.ToInt32(txtinv.Text), logcorid, Div_Id, voutypeid, Vou_Year, FADbName, BranchID);
                //}

                if (dtfa.Rows.Count > 0)
                {
                    strTranType = dtfa.Rows[0]["trantype"].ToString();
                    //txtjobno.Text = dtfa.Rows[0]["jobno"].ToString();
                    if (grd.Rows.Count > 0)
                    {
                        for (i = 0; i <= grd.Rows.Count - 1; i++)
                        {
                            //grd.Rows.Remove(grd.Rows(0));
                        }
                    }

                    DataRow dr_temp = dtfa.NewRow();
                    dr_temp["ledgername"] = "Total";

                    dtfa.Rows.Add(dr_temp);
                    GrdFA.DataSource = dtfa;
                    GrdFA.DataBind();
                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'").ToString()))
                    {
                        GrdFA.Rows[GrdFA.Rows.Count - 1].Cells[1].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Dr'")).ToString("#,0.00");
                    }
                    if (!string.IsNullOrEmpty(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'").ToString()))
                    {
                        GrdFA.Rows[GrdFA.Rows.Count - 1].Cells[2].Text = Convert.ToDouble(dtfa.Compute("sum(ledgeramount)", "ledgertype='Cr'")).ToString("#,0.00");
                    }

                }

                if (frmname == "Credit Note" || frmname == "Credit Note - Others")
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), Session["StrTranTypeO"].ToString(), 8, Convert.ToInt32(txtvouyear.Text), branchid);
                }
                else if (frmname == "Debit Note" || frmname == "Debit Note - Others")
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), Session["StrTranTypeO"].ToString(), 7, Convert.ToInt32(txtvouyear.Text), branchid);
                }
                else
                {
                    DtSHead = INVOICEobj.ShowLVHead(Convert.ToInt32(txtinv.Text), Session["StrTranTypeO"].ToString(), 2, Convert.ToInt32(txtvouyear.Text), branchid);
                }

                i = DtSHead.Rows.Count;
                if (i > 0)
                {
                    DataTable Against = new DataTable();
                    if (vname == "Credit Note" || vname == "Credit Note - Others")
                    {
                        if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "E") != "0")
                        {
                            Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "E");
                            for (int x = 0; x <= Against.Rows.Count - 1; x++)
                            {
                                lstagnst.Items.Add(Against.Rows[x][0].ToString());
                            }
                        }
                    }
                    else if (vname == "Purchase Invoice")
                    {
                        if (INVOICEobj.GetVoucherAgainstRcptPay(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "P") != "0")
                        {
                            Against = INVOICEobj.GetVoucherAgainstRcptPayNEW(Convert.ToInt32(txtinv.Text), branchid, Convert.ToInt32(txtvouyear.Text), "P");
                            for (int x = 0; x <= Against.Rows.Count - 1; x++)
                            {
                                lstagnst.Items.Add(Against.Rows[x][0].ToString());
                            }
                        }
                    }

                }
            }

        }

        protected void grd_PreRender(object sender, EventArgs e)
        {
            if (grd.Rows.Count > 0)
            {
                grd.UseAccessibleHeader = true;
                grd.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void GrdFA_PreRender(object sender, EventArgs e)
        {
            if (GrdFA.Rows.Count > 0)
            {
                GrdFA.UseAccessibleHeader = true;
                GrdFA.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ddl_voutype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddltype"] = ddl_voutype.SelectedItem.Text;
            Session["ddltypeid"] = ddl_voutype.SelectedValue;
            lbl_InvHeader.Text = ddl_voutype.SelectedItem.Text;
            frmname = ddl_voutype.SelectedItem.Text;
            if (ddl_voutype.SelectedItem.Text == "Purchase Invoice" || ddl_voutype.SelectedItem.Text == "Purchase Invoice OC")
            {
                txtto.ToolTip = "Bill From";
                txtsupplyto.ToolTip = "Supply From";
                Label8.Text = "Bill From";
                Label9.Text = "Supply From";
                //txtto.Attributes["Placeholder"] = "Bill From";
                //txtsupplyto.Attributes["Placeholder"] = "Supply From";
                //lbllVenRefno.Visible = true;
                txtVendorref.Visible = true;
                Label21.Visible = true;
                Label22.Visible = true;
                txtVendorRefnodate.Visible = true;
                //line.Visible = true;
            }
            else if (ddl_voutype.SelectedItem.Text == "Credit Note" || ddl_voutype.Text == "Debit Note")
            {
                if (ddl_voutype.Text == "Credit Note")
                {
                    txtto.ToolTip = "Bill From";
                    txtsupplyto.ToolTip = "Supply From";
                    Label8.Text = "Bill From";
                    Label9.Text = "Supply From";
                }
                else if (ddl_voutype.Text == "Debit Note")
                {
                    txtto.ToolTip = "Bill To";
                    txtsupplyto.ToolTip = "Supply To";
                    Label8.Text = "Bill To";
                    Label9.Text = "Supply To";
                }
                homelbl.Visible = false;
                txtVendorref.Visible = true;
                Label21.Visible = true;
                Label22.Visible = true;
                txtVendorRefnodate.Visible = true;
            }
            else if (ddl_voutype.SelectedItem.Text == "Sales Invoice" || ddl_voutype.SelectedItem.Text == "Sales Invoice OC" || ddl_voutype.SelectedItem.Text == "Bill of Supply" || ddl_voutype.SelectedItem.Text == "Bill of Supply OC")
            {
                txtto.ToolTip = "Bill To";
                txtsupplyto.ToolTip = "Supply To";
                Label8.Text = "Bill To";
                Label9.Text = "Supply To";
                //txtto.Attributes["Placeholder"] = "Bill To";
                //txtsupplyto.Attributes["Placeholder"] = "Supply To";
                //lbllVenRefno.Visible = false;
                txtVendorref.Visible = true;
                txtVendorRefnodate.Visible = true;
                Label21.Visible = true;
                Label22.Visible = true;

                Label21.Text = "Customer Ref #";
                txtVendorref.ToolTip = "Customer Ref Number";

                Label22.Text = "Customer Ref Date";
                txtVendorRefnodate.ToolTip = "Date";
            }
            if (Session["StrTranType"].ToString() == "FE" || Session["StrTranType"].ToString() == "FI" || Session["StrTranType"].ToString() == "AE" || Session["StrTranType"].ToString() == "AI" ||
                        Session["StrTranType"].ToString() == "BT" || Session["StrTranType"].ToString() == "CH")
            {
                Session["HeadTranType"] = Session["StrTranType"].ToString();
            }
            if (Session["HeadTranType"] != null && Session["HeadTranType"].ToString() != "")
            {
                Hid_HeadTrantype.Value = Session["HeadTranType"].ToString();
                //Session["HeadTranType"] = "";
            }
            else
            {
                Hid_HeadTrantype.Value = Session["StrTranType"].ToString();
            }
            if (Hid_HeadTrantype.Value != "FA" && Hid_HeadTrantype.Value != "FC" && Hid_HeadTrantype.Value != "AC")
            {
                if (Session["StrTranType"].ToString() == "FE")
                {
                    lblHead.InnerText = "Ocean Exports";
                    homelbl.Visible = true;
                }
                else if (Session["StrTranType"].ToString() == "FI")
                {
                    lblHead.InnerText = "Ocean Imports";
                    homelbl.Visible = true;
                }
                else if (Session["StrTranType"].ToString() == "AE")
                {
                    lblHead.InnerText = "Air Exports";
                    homelbl.Visible = true;
                }
                else if (Session["StrTranType"].ToString() == "AI")
                {
                    lblHead.InnerText = "Air Imports";
                    homelbl.Visible = true;
                }
                else if (Session["StrTranType"].ToString() == "CH")
                {
                    lblHead.InnerText = "Custom House Agent";
                }
            }
            else if (Hid_HeadTrantype.Value == "FA" || Hid_HeadTrantype.Value == "FC")
            {
                homelbl.Visible = false;
                lblHead.InnerText = "Financial Accounts";
                lblAcc.InnerText = "Vouchers";
                txtvouyear.Enabled = false;
                txtdate.Enabled = false;
            }
            else if (Hid_HeadTrantype.Value == "AC")
            {
                homelbl.Visible = false;
                lblHead.InnerText = "Operating Accounts";
                lblAcc.InnerText = "Vouchers";
            }

            txtblno.Focus();

            txtdate.Text = Logobj.GetDate().ToString("dd/MM/yyyy");
            FillBill();
            divisionid = hrempobj.GetDivisionId(Session["LoginDivisionName"].ToString());
            branchid = hrempobj.GetBranchId(divisionid, Session["LoginBranchName"].ToString());
            if (Request.QueryString.ToString().Contains("type"))
            {
                lbl_InvHeader.Text = Request.QueryString["type"].ToString();
                HeaderLabel.InnerText = lbl_InvHeader.Text;
                //frmname = Request.QueryString["type"].ToString();
                Session["Forminvoice"] = Request.QueryString["type"].ToString();
            }
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                lbl_InvHeader.Text = Request.QueryString["FormName"].ToString();
                HeaderLabel.InnerText = lbl_InvHeader.Text;
                // frmname = Request.QueryString["FormName"].ToString();
                Session["Forminvoice"] = Request.QueryString["FormName"].ToString();
            }
            strTranType = Session["StrTranType"].ToString();
            txtblno.Focus();
            cmddisable();
            //  btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";


            VourText();

            grd.DataSource = Utility.Fn_GetEmptyDataTable();
            grd.DataBind();
            GrdFA.DataSource = Utility.Fn_GetEmptyDataTable();
            GrdFA.DataBind();
            if (frmname == "Sales Invoice" || frmname == "InvoiceWoJ" || frmname == "Bill of Supply" || frmname == "Sales Invoice OC" || frmname == "Bill of Supply OC")
            {
                if (frmname == "InvoiceWoJ")
                {
                    lblAcc.InnerText = "Utility";
                    chkmbl.Visible = false;
                    txtcreditapp1.Attributes["Class"] = "VendorRefIN";

                }
                else
                {
                    chkmbl.Visible = true;
                }
                extype = "R";
                //lblInvNo.Text = "Inv #";
                //txtinv.Attributes.Add("placeholder", "Inv #");
                if (frmname == "Bill of Supply" || frmname == "Bill of Supply OC")
                {
                    Label3.Text = "BOS #";
                    txtinv.ToolTip = "BOS NUMBER";
                }
                else
                {
                    Label3.Text = "Inv #";
                    txtinv.ToolTip = "INVOICE NUMBER";
                }
            }
            else if (frmname == "Debit Note")
            {
                extype = "R";
                //lblInvNo.Text = "DN #";
                //txtinv.Attributes.Add("placeholder", "DN #");
                Label3.Text = "DN #";
                txtinv.ToolTip = "Debit Note NUMBER";
            }
            else if (frmname == "Credit Note")
            {
                extype = "C";
                //lblInvNo.Text = "CN #"; 
                //txtinv.Attributes.Add("placeholder", "CN #");
                Label3.Text = "CN #";
                txtinv.ToolTip = "Credit Note NUMBER";
            }
            else if (frmname == "Purchase Invoice" || frmname == "Purchase Invoice OC")
            {
                extype = "C";
                //lblInvNo.Text = "CN-Ops#";
                //txtinv.Attributes.Add("placeholder", "CN-Ops#");
                Label3.Text = "PI #";
                txtinv.ToolTip = "Purchase Invoice #";
            }
            UserRights();

            if (frmname == "Overseas Debit Note")
            {
                vname = "OSSI";
            }
            else if (frmname == "Overseas Credit Note")
            {
                vname = "OSPI";
            }
            else if (frmname == "Sales Invoice")
            {
                vname = "Invoices";
            }

            else if (frmname == "Purchase Invoice")
            {
                vname = "Purchase Invoice";
            }
            else if (frmname == "Purchase Invoice OC")
            {
                vname = "Purchase Invoice OC";
            }
            else if (frmname == "Debit Note")
            {
                vname = "Debit Note - Others";
            }
            else if (frmname == "Credit Note")
            {
                vname = "Credit Note - Others";
            }
            else if (frmname == "OSDNCN JV")
            {
                vname = "OSDNCNJV";
            }
            else
            {
                vname = frmname;
            }

            Session["vname"] = vname;
        }


    }
}