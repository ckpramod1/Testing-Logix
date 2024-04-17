using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Globalization;
using System.Drawing;

namespace logix.FAForm
{
    public partial class ProfomaInvoice : System.Web.UI.Page
    {
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        DataAccess.ForwardingExports.JobInfo FEJobobj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.ForwardingExports.BLDetails FEBLobj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.ForwardingExports.AmendBL Amendobj = new DataAccess.ForwardingExports.AmendBL();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
        DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
        DataAccess.ForwardingImports.BLDetails FIBLobj = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.BLPrinting obj_da_FEBL = new DataAccess.ForwardingExports.BLPrinting();
        DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
        DataTable dt = new DataTable();
        DataTable dtbase = new DataTable();
        DataTable DtConDetails = new DataTable();
        DataTable DtCon = new DataTable();
        DataTable DtInfo = new DataTable();
        DataTable Dt = new DataTable();
        DataTable dtcheck = new DataTable();
        DataTable DtSHead = new DataTable();
        DataTable dtref = new DataTable();
        DataTable dtchargedel = new DataTable();
        string type, strTranType, vessel, voyage, agent, jobtype, volume, wt, fatransfers, strcharge;
        int divisionid, branchid;
        DateTime eta;
        int i;
        Boolean blnerr, bolcuststat;
        int Refno, chargename;
        string fd; string str_FornName = "", str_Uiid = "";
        Double amount, strvolume, doublevolume, strntweight, strchgweight, strgrosswght, sizecount, famount, currexrate;
        DataAccess.Accounts.Invoice obj_da_inv = new DataAccess.Accounts.Invoice();
        DataTable obj_dt_head = new DataTable();
        string bill; int billno; char billtype; DateTime voudate;


     
        DataTable dtnew1 = new DataTable();
        DataAccess.Masters.MasterBranch obj_branchd = new DataAccess.Masters.MasterBranch();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtto);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtref);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            if (Session["Loginyear"].ToString() == Session["Vouyear"].ToString())
            {

            }
            else
            {
                btn_save1.Visible = false;
            }
            if (Session["LoginDivisionId"] != null)
            {
                divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            }
            if (Session["LoginBranchid"] != null)
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }

            //if (Request.QueryString.ToString().Contains("trantype"))
            //{
            //    Session["StrTranTypenew"] = Request.QueryString["trantype"].ToString();
            //}
            if (Session["LoginBranchid"].ToString() == "86")
            {
                Session["StrTranTypenew"] = "WH";
            }
            else if (Session["LoginBranchid"].ToString() == "66")
            {
                Session["StrTranTypenew"] = "LT";
            }
            else
            {
                Session["StrTranTypenew"] = "CT";
            }

            if (Session["StrTranTypenew"] != null)
            {

                if (Session["LoginBranchid"].ToString() == "86")
                {
                    Session["StrTranTypenew"] = "WH";
                }
                else if (Session["LoginBranchid"].ToString() == "66")
                {
                    Session["StrTranTypenew"] = "LT";
                }
                else
                {
                    Session["StrTranTypenew"] = "CT";
                }
                strTranType = Session["StrTranTypenew"].ToString();


            }

            grd.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");



            dtnew1 = obj_branchd.GetBranchGST(divisionid, branchid);
            if (dtnew1.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('Please update GST # to proceed with generation of voucher(s)');", true);
                btnsave.Enabled = false;
                btnsave.ForeColor = System.Drawing.Color.Gray;
                // btnsave.ForeColor = System.Drawing.Color.White;

            }
            else
            {
                btnsave.Enabled = true;
                btnsave.ForeColor = System.Drawing.Color.White;
            }

            if (!this.IsPostBack)
            {
                try
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    btndelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";
                    txtblno.Focus();
                    ShowNoResultFound(dt, grd);

                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_Header.Text = Request.QueryString["FormName"].ToString();
                    }


                    txtex.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EX-Rate')");
                    txtrate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    /*To Be Commanded */
                    //lbl_Header.Text = "Profoma Invoice";

                    //divisionid = 1;
                    //branchid = 1;
                    //Session["StrTranTypenew"] = "FE";
                    //strTranType = "FE";
                    /*To Be Commanded */
                    txtamount.Enabled = true;
                    if (strTranType == "CH")
                    {
                        txtblno.Attributes.Add("placeholder", "DOC#");
                        txtblno.ToolTip = "DOC Number";
                    }
                    if (lbl_Header.Text == "Profoma Credit Note - Operations")
                    {
                        type = "Profoma Payment Advise";
                        hf_strtype.Value = type;
                        txtCreditDays.Visible = true;
                        txtVendorRefno.Visible = true;
                        txtVendorRefnodate.Visible = true;
                        txtcreditapp1.Visible = false;
                        txtto.ToolTip = "Bill From";
                        txtsupplyto.ToolTip = "Supply From";
                        txtto.Attributes["Placeholder"] = "Bill From";
                        txtsupplyto.Attributes["Placeholder"] = "Supply From";
                    }
                    else if (lbl_Header.Text == "Proforma Invoice")
                    {
                        txtto.ToolTip = "Bill To";
                        txtsupplyto.ToolTip = "Supply To";
                        txtto.Attributes["Placeholder"] = "Bill To";
                        txtsupplyto.Attributes["Placeholder"] = "Supply To";
                        hd_exrate.Value = "R";
                        type = "Profoma Invoice";
                        lbl_Header.Text = type;
                        hf_strtype.Value = type;
                        txtCreditDays.Visible = false;
                        txtVendorRefno.Visible = false;
                        txtVendorRefnodate.Visible = false;
                        txtcreditapp1.Visible = true;
                    }
                    headerlabel.InnerText = lbl_Header.Text;
                    FillOnPageLoad();
                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Yellow;
                    btndelete.Click += btndelete_Click;
                    btndelete.OnClientClick = @"return getConfirmationValue();";
                    // txtref.Focus();

                    UserRights();

                    if (Session["StrTranTypenew"].ToString() == "CT")
                    {

                    }



                }
                catch (Exception ex)
                {
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
                }


            }
            else if (Page.IsPostBack)
            {
                WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
                int indx = wcICausedPostBack.TabIndex;
                var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
                           where control.TabIndex > indx
                           select control;
                ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
            }

        }

        protected Control GetControlThatCausedPostBack(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        protected void UserRights()
        {
            if (Request.QueryString.ToString().Contains("FormName"))
            {
                if (Session["LoginDivisionId"] != null)
                {
                    divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                }
                if (Session["LoginBranchid"] != null)
                {
                    branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                }

                Boolean btn_delete;
                str_FornName = Request.QueryString["FormName"].ToString();
                str_Uiid = Request.QueryString["uiid"].ToString();
                dtnew1 = obj_branchd.GetBranchGST(divisionid, branchid);
                if (dtnew1.Rows.Count > 0)
                {

                    Utility.Fn_CheckUserRights(str_Uiid, null, btnview, btndelete);
                }
                else
                {
                    Utility.Fn_CheckUserRights(str_Uiid, btnsave, btnview, btndelete);
                }
                DataTable obj_Dtuser = new DataTable();
                obj_Dtuser = (DataTable)Session["dt_UserRights"];
                DataView obj_dtview = new DataView(obj_Dtuser);
                obj_dtview.RowFilter = "uiid=" + str_Uiid + " and submenuname='" + str_FornName + "'";
                obj_Dtuser = obj_dtview.ToTable();
                //  btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


            }
        }

       

        [WebMethod]
        public static List<string> GetToCust(string prefix)
        {
            DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
            DataTable Dt = new DataTable();
            List<string> custname = new List<string>();

            string a = HttpContext.Current.Session["cmbbill"].ToString();
            if (HttpContext.Current.Session["cmbbill"].ToString() == "Internal")
            {

                Dt = customerobj.GetLikeCustomerproforma(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
            }
            else
            {
                Dt = customerobj.GetLikeIndianCustomer(prefix);

            }
            custname = Utility.Fn_TableToList_Cust1(Dt, "customer", "customerid", "address");
            return custname;
        }

        [WebMethod]
        public static List<string> GetCharges(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeChargesName(prefix);
            List_Result = Utility.Fn_TableToList(dtCharge, "chargename", "chargeid");
            return List_Result;
        }


        [WebMethod]
        public static List<string> GetLikeCurrency(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeCurrency(prefix);
            List_Result = Utility.Fn_TableToList(dtCharge, "currency", "currency");
            return List_Result;
        }




        public void FillOnPageLoad()
        {
            try
            {

                dtdate.Text = Logobj.GetDate().ToShortDateString();
                dtdate.Text = Utility.fn_ConvertDate(dtdate.Text);
                cmbbill.Items.Clear();
                cmbbill.Items.Add("");
                cmbbill.Items.Add("Cash/Cheque");
                cmbbill.Items.Add("Credit");
                cmbbill.Items.Add("Internal");
                if (Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                {

                }
                else
                {
                    cmbbill.Items.Add("ST/GST Exemption");
                }

                strTranType = Session["StrTranTypenew"].ToString();
                if (strTranType == "CT" || strTranType == "FI" || strTranType == "WH" || strTranType == "LT")
                {
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("DOC");
                    //cmbbase.Items.Add("CBM");
                    //cmbbase.Items.Add("MT");
                    //txtvessel.Attributes.Add("placeholder", "Vsl and Voy");
                    //txtagent.Attributes.Add("placeholder", "Principal");
                    //txtmlo.Attributes.Add("placeholder", "Customer");
                    //txtcnf.Attributes.Add("placeholder", "CNF");
                    //if (strTranType == "CT")
                    //{
                    //    cmbbase.Items.Add("SB");
                    //}
                    //dtbase = INVOICEobj.BaseFill();
                    //for (i = 0; i <= dtbase.Rows.Count - 1; i++)
                    //{
                    //    cmbbase.Items.Add(dtbase.Rows[i]["conttype"].ToString());
                    //}
                }
                //else if (strTranType == "AE" || strTranType == "AI")
                //{
                //    cmbbase.Items.Add("");
                //    cmbbase.Items.Add("HWBL");
                //    cmbbase.Items.Add("Kgs");
                //    //Label8.Text = "Job Details";
                //    //Label12.Text = "AirLine";
                //    //Label14.Text = "Agent";
                //    //Label16.Text = "Notify Party 2";
                //    //txtvessel.Attributes.Add("placeholder", "Job Details");
                //    txtagent.Attributes.Add("placeholder", "AirLine");
                //    txtmlo.Attributes.Add("placeholder", "Agent");
                //    txtcnf.Attributes.Add("placeholder", "Notify Party 2");
                //    txtagent.ToolTip = "AirLine";
                //    txtmlo.ToolTip = "Agent";
                //    txtcnf.ToolTip = "Notify Party 2";
                //}
                //else if (strTranType == "CH")
                //{

                //    chkmbl.Visible = false;
                //    chkmbl.Enabled = false;
                //    cmbbase.Items.Add("");
                //    cmbbase.Items.Add("DOC");
                //    cmbbase.Items.Add("Kgs");
                //    cmbbase.Items.Add("Volume");
                //}
                //else
                //{
                //    chkmbl.Visible = false;
                //    cmbbase.Items.Add("");
                //    cmbbase.Items.Add("DOC");
                //    cmbbase.Items.Add("Kgs");
                //    cmbbase.Items.Add("Volume");
                //    //Label8.Text = "Vsl and Voy";
                //    //Label12.Text = "Principal";
                //    //Label13.Text = "Customer";
                //    //Label16.Enabled = false;
                //    txtvessel.Attributes.Add("placeholder", "Vsl and Voy");
                //    txtagent.Attributes.Add("placeholder", "Principal");
                //    txtmlo.Attributes.Add("placeholder", "Customer");
                //    txtcnf.Attributes.Add("placeholder", "CNF");
                //    txtvessel.ToolTip = "Vsl and Voy";
                //    txtagent.ToolTip = "Principal";
                //    txtmlo.ToolTip = "Customer";
                //    txtcnf.ToolTip = "CNF";
                //    //txtconsignee.Attributes.Add("placeholder", "Consignee");
                //    txtcnf.Enabled = false;
                //}
                btnadd.Enabled = false;
                btnadd.ForeColor = System.Drawing.Color.Gold;
                if (Logobj.GetDate().Month < 4)
                {
                    txtvouyear.Text = (Logobj.GetDate().Year - 1).ToString();
                }
                else
                {
                    txtvouyear.Text = Logobj.GetDate().Year.ToString();
                }
                Session["mblchk"] = "false";
                Session["cmbbill"] = "Select";
                //btnadd.Enabled = true;
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
        }


        private void ShowNoResultFound(DataTable source, GridView gv)
        {
            if (source.Columns.Count == 0)
            {
                gv.DataSource = null;
                gv.DataBind();
                source.Columns.Add("CHARge");
                source.Columns.Add("curr");
                source.Columns.Add("rate");
                source.Columns.Add("exrate");
                source.Columns.Add("bASe");
                source.Columns.Add("amount");
                source.Columns.Add("chargeid");

                //source.Rows.Add(source.NewRow());
                gv.DataSource = source;
                gv.DataBind();
                //int columnsCount = gv.Columns.Count;
                //gv.Rows[0].Cells.Clear();
            }
        }
        //public void getFEI()
        //{
        //    try
        //    {
        //        useit();
        //        if (strTranType == "CT")
        //        {
        //            txtblno.Text = txtblno.Text.ToUpper();

        //            if (chkmbl.Checked == true)
        //            {
        //                lstvol.Items.Clear();
        //                txtjobno.Value = FEJobobj.GetJobNo(txtblno.Text.ToUpper(), branchid, divisionid).ToString();
        //                DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
        //                if (DtConDetails.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i <= DtConDetails.Rows.Count - 1; i++)
        //                    {
        //                        lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                    }
        //                }
        //                lstcon.Items.Clear();
        //                DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
        //                if (DtCon.Rows.Count > 0)
        //                {
        //                    for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
        //                    {
        //                        lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
        //                    }
        //                }
        //                DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Value), branchid, divisionid);
        //                if (DtCon.Rows.Count > 0)
        //                {
        //                    vessel = DtCon.Rows[0][3].ToString();
        //                    voyage = DtCon.Rows[0][7].ToString();
        //                    eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString());
        //                    hid_mloid.Value = DtCon.Rows[0]["mloid"].ToString();
        //                    txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
        //                    txtmlo.Text = DtCon.Rows[0][6].ToString();

        //                    txtagent.Text = DtCon.Rows[0][5].ToString();
        //                    agent = DtCon.Rows[0][14].ToString();
        //                    txtdes.Text = DtCon.Rows[0][4].ToString();
        //                    jobtype = DtCon.Rows[0][13].ToString();
        //                }

        //            }
        //            else
        //            {
        //                lstvol.Items.Clear();
        //                DtInfo = FEBLobj.GetBLDetails(txtblno.Text.ToUpper(), branchid, divisionid);
        //                if (DtInfo.Rows.Count > 0)
        //                {
        //                    txtjobno.Value = DtInfo.Rows[0][0].ToString();
        //                    txtshipper.Text = DtInfo.Rows[0][4].ToString();
        //                    txtconsignee.Text = DtInfo.Rows[0][6].ToString();
        //                    hid_cosigneeid.Value = DtInfo.Rows[0]["consigneeid"].ToString();
        //                    txtnotify.Text = DtInfo.Rows[0][8].ToString();
        //                    txtcnf.Text = DtInfo.Rows[0][16].ToString();
        //                    DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Value), branchid, divisionid);
        //                    if (DtCon.Rows.Count > 0)
        //                    {
        //                        jobtype = DtCon.Rows[0][13].ToString();
        //                        vessel = DtCon.Rows[0][3].ToString();
        //                        voyage = DtCon.Rows[0][7].ToString();
        //                        eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString()).Date;
        //                        hid_mloid.Value = DtCon.Rows[0]["mloid"].ToString();
        //                        txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
        //                        txtmlo.Text = DtCon.Rows[0][6].ToString();
        //                        txtagent.Text = DtCon.Rows[0][5].ToString();
        //                        jobtype = DtCon.Rows[0][13].ToString();
        //                        txtdes.Text = DtCon.Rows[0][4].ToString();
        //                        Dt = INVOICEobj.GetCreditOSAmount(txtblno.Text, branchid);
        //                        if (Dt.Rows.Count > 0)
        //                        {
        //                            //txtCreditAmt.Text = Dt.Rows(0).Item(0).ToString
        //                            //txtOSAmt.Text = Dt.Rows(0).Item(1).ToString
        //                        }
        //                    }
        //                    DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, branchid);
        //                    if (DtConDetails.Rows.Count > 0)
        //                    {
        //                        for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
        //                        {
        //                            lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                        }
        //                        volume = DtConDetails.Rows[0][1].ToString();
        //                        lstvol.Items.Add(volume + " cbm");
        //                        wt = DtConDetails.Rows[0][2].ToString();
        //                        lstvol.Items.Add(wt + " Kgs");
        //                    }
        //                    lstcon.Items.Clear();
        //                    DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, strTranType, branchid);
        //                    if (DtInfo.Rows.Count > 0)
        //                    {
        //                        for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
        //                        {
        //                            lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
        //                        }
        //                    }

        //                }
        //            }
        //        }

        //       /* else
        //        {
        //            if (chkmbl.Checked == true)
        //            {
        //                lstvol.Items.Clear();
        //                DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text, strTranType, branchid);
        //                if (DtInfo.Rows.Count > 0)
        //                {
        //                    txtjobno.Value = DtInfo.Rows[0][0].ToString();
        //                    vessel = DtInfo.Rows[0][3].ToString();
        //                    voyage = DtInfo.Rows[0][2].ToString();
        //                    eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
        //                    txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
        //                    txtmlo.Text = DtInfo.Rows[0][6].ToString();
        //                    agent = DtInfo.Rows[0][7].ToString();
        //                    jobtype = DtInfo.Rows[0][8].ToString();
        //                    txtagent.Text = DtInfo.Rows[0][5].ToString();
        //                    txtdes.Text = DtInfo.Rows[0][4].ToString();
        //                    DtCon = INVOICEobj.GetFIMblNContainers(txtjobno.Value, branchid);
        //                    if (DtCon.Rows.Count > 0)
        //                    {
        //                        for (i = 0; i <= DtCon.Rows.Count - 1; i++)
        //                        {
        //                            lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());

        //                        }
        //                    }
        //                    DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
        //                    if (DtConDetails.Rows.Count > 0)
        //                    {
        //                        for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
        //                        {
        //                            lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                        }
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                lstvol.Items.Clear();
        //                DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, strTranType, branchid);
        //                if (DtInfo.Rows.Count > 0)
        //                {
        //                    txtjobno.Value = DtInfo.Rows[0][0].ToString();
        //                    txtshipper.Text = DtInfo.Rows[0][4].ToString();
        //                    txtconsignee.Text = DtInfo.Rows[0][5].ToString();
        //                    txtnotify.Text = DtInfo.Rows[0][6].ToString();
        //                    hid_cosigneeid.Value = DtInfo.Rows[0]["consigneeid"].ToString();
        //                    vessel = DtInfo.Rows[0][3].ToString();
        //                    voyage = DtInfo.Rows[0][2].ToString();
        //                    eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());

        //                    txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
        //                    txtmlo.Text = DtInfo.Rows[0][9].ToString();
        //                    agent = DtInfo.Rows[0][10].ToString();
        //                    jobtype = DtInfo.Rows[0][11].ToString();
        //                    txtagent.Text = DtInfo.Rows[0][8].ToString();

        //                    txtdes.Text = DtInfo.Rows[0][7].ToString();
        //                    Dt = INVOICEobj.GetCreditOSAmount(txtblno.Text, branchid);
        //                    if (Dt.Rows.Count > 0)
        //                    {
        //                        // txtCreditAmt.Text = Dt.Rows(0).Item(0).ToString
        //                        // txtOSAmt.Text = Dt.Rows(0).Item(1).ToString
        //                    }

        //                }

        //            }


        //            DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, branchid);
        //            if (DtConDetails.Rows.Count > 0)
        //            {
        //                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
        //                {
        //                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                }
        //                volume = INVOICEobj.GetVolume(txtblno.Text, strTranType, branchid).ToString();
        //                lstvol.Items.Add(volume + " cbm");
        //                wt = INVOICEobj.GetWeight(txtblno.Text, strTranType, branchid).ToString();
        //                lstvol.Items.Add(wt + " Kgs");
        //                lstcon.Items.Clear();
        //                DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, strTranType, branchid);
        //                if (DtInfo.Rows.Count > 0)
        //                {
        //                    for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
        //                    {
        //                        lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
        //                    }
        //                }

        //            }
        //        }
        //        */
        //        disable();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

        //    }

        //}

        //public void getAEI()
        //{
        //    try
        //    {
        //        useit();
        //        string gross, chwt;
        //        if (chkmbl.Checked == true)
        //        {
        //            if (strTranType == "AE")
        //            {
        //                DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
        //            }
        //            else
        //            {
        //                DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
        //            }
        //            if (DtInfo.Rows.Count > 0)
        //            {
        //                txtjobno.Value = DtInfo.Rows[0][0].ToString();
        //                eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
        //                txtvessel.Text = txtjobno.Value + "/" + DtInfo.Rows[0][2].ToString() + "/" + eta.ToShortDateString();
        //                txtmlo.Text = DtInfo.Rows[0][5].ToString();
        //                txtagent.Text = DtInfo.Rows[0][4].ToString();
        //                agent = DtInfo.Rows[0][6].ToString();
        //                txtdes.Text = DtInfo.Rows[0][3].ToString();
        //                gross = DtInfo.Rows[0][7].ToString();
        //                chwt = DtInfo.Rows[0][8].ToString();
        //            }
        //        }
        //        else
        //        {
        //            lstvol.Items.Clear();
        //            if (strTranType == "AE")
        //            {
        //                DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
        //            }
        //            else
        //            {
        //                DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), strTranType, branchid);
        //            }
        //            if (DtInfo.Rows.Count > 0)
        //            {
        //                txtjobno.Value = DtInfo.Rows[0][0].ToString();
        //                txtshipper.Text = DtInfo.Rows[0][3].ToString();
        //                txtconsignee.Text = DtInfo.Rows[0][4].ToString();
        //                txtnotify.Text = DtInfo.Rows[0][5].ToString();
        //                eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
        //                hid_cosigneeid.Value = DtInfo.Rows[0]["consigneeid"].ToString();
        //                txtcnf.Text = DtInfo.Rows[0][6].ToString();
        //                txtvessel.Text = txtjobno.Value + "/" + DtInfo.Rows[0][2].ToString() + "/" + eta.ToShortDateString();
        //                txtmlo.Text = DtInfo.Rows[0][9].ToString();
        //                hid_mloid.Value = DtInfo.Rows[0]["airlineid"].ToString();
        //                txtagent.Text = DtInfo.Rows[0][8].ToString();
        //                agent = DtInfo.Rows[0][10].ToString();
        //                gross = DtInfo.Rows[0][11].ToString();
        //                chwt = DtInfo.Rows[0][12].ToString();
        //                txtdes.Text = DtInfo.Rows[0][7].ToString();
        //                lstvol.Items.Add("Gross Wt : " + gross + " Kgs");
        //                lstvol.Items.Add("Charge Wt : " + chwt + " Kgs");
        //            }
        //        }
        //        disable();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}
        //public void getCHA()
        //{

        //    try
        //    {
        //        useit();
        //        Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), "CH", branchid);
        //        if (Dt.Rows.Count > 0)
        //        {
        //            txtjobno.Value = Dt.Rows[0][0].ToString();
        //            txtshipper.Text = Dt.Rows[0][3].ToString();
        //            txtconsignee.Text = Dt.Rows[0][4].ToString();
        //            txtnotify.Text = Dt.Rows[0][5].ToString();
        //            eta = Convert.ToDateTime(Dt.Rows[0][1].ToString());
        //            txtvessel.Text = txtjobno.Value + "/" + Dt.Rows[0][2].ToString() + "/" + eta.ToShortDateString();
        //            txtmlo.Text = Dt.Rows[0][8].ToString();
        //            txtagent.Text = Dt.Rows[0][7].ToString();
        //            agent = Dt.Rows[0][9].ToString();
        //            txtdes.Text = Dt.Rows[0][6].ToString();
        //            jobtype = Dt.Rows[0][10].ToString();
        //            jobtype = "0";

        //        }
        //        disable();
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}

        public void disable()
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

        /* protected void txtblno_TextChanged(object sender, EventArgs e)
         {
             try
             {
                 DataTable dtsupply = new DataTable();
                 DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                 DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                 DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
                 DataTable obj_dt = new DataTable();
                 string str_booking = "";
                 string str_BL = "";
                 if (txtblno.Text.ToUpper() != "")
                 {

                     /*DataTable dtsupply = new DataTable();

                     dtsupply = INVOICEobj.GetspGst4supplyto(txtblno.Text);

                     if (dtsupply.Rows.Count>0)
                     {
                         txtsupplyto.Text = dtsupply.Rows[0]["customername"].ToString();
                         hid_SupplyTo.Value = dtsupply.Rows[0]["customerid"].ToString();
                        // txtsupplyto_TextChanged(sender,e);
                         string citysupplyid;
                         int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                         if (txtsupplyto.Text != "")
                         {
                            // int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                             citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                             txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                         }
                     }*/





        /* else
         {
             if (hdncustid.Value!="")
             {
                 hid_SupplyTo.Value = hdncustid.Value;
                 txtto_TextChanged(sender, e);
             }
                      
                       
         }

        if (Session["StrTranTypenew"].ToString() == "FE" || Session["StrTranTypenew"].ToString() == "FI")
        {
            if (chkmbl.Checked == true)
            {
                getFEI();
                btnview.Enabled = true;
                btnview.ForeColor = System.Drawing.Color.White;
                // txtto.Focus();
                chkmbl.Focus();
            }
            else
            {
                getFEI();
                btnview.Enabled = true;
                btnview.ForeColor = System.Drawing.Color.White;
                // txtto.Focus();
                chkmbl.Focus();
            }
        }
        else if (Session["StrTranTypenew"].ToString() == "AE" || Session["StrTranTypenew"].ToString() == "AI")
        {
            if (chkmbl.Checked == true)
            {
                getAEI();
                btnview.Enabled = true;
                btnview.ForeColor = System.Drawing.Color.White;
                //  txtto.Focus();
                chkmbl.Focus();
            }
            else
            {
                getAEI();
                btnview.Enabled = true;
                btnview.ForeColor = System.Drawing.Color.White;
                // txtto.Focus();
                chkmbl.Focus();
            }
        }
        else
        {
            getCHA();
            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;
            //txtto.Focus();
            chkmbl.Focus();
        }


        if (Session["StrTranTypenew"] != null)
        {

            obj_dt = obj_da_BL.ShowBLDetails(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (obj_dt.Rows.Count > 0)
            {
                str_BL = obj_dt.Rows[0]["splitbl"].ToString();

            }
            str_booking = obj_da_FIBL.GetBookinkNo(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            if (str_booking == "0" && Session["StrTranTypenew"].ToString() == "FI")
            {
                str_booking = obj_da_FIBL.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
            }

            if (str_booking != "0")
            {
                dtsupply = obj_da_FEBL.GetBookingDt(str_booking, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                if (dtsupply.Rows.Count > 0)
                {
                    hid_SupplyTo.Value = dtsupply.Rows[0]["customerid"].ToString();
                    if (hid_SupplyTo.Value != "")
                    {
                        txtsupplyto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                        string citysupplyid;
                        if (txtsupplyto.Text != "")
                        {

                            citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                            txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                        }
                    }
                }
            }
            else
            {
                hid_SupplyTo.Value = hid_cosigneeid.Value;
                if (hid_SupplyTo.Value != "")
                {
                    txtsupplyto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                    string citysupplyid;
                    if (txtsupplyto.Text != "")
                    {

                        citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                        txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                    }
                }
            }

        }


        btncancel.Text = "Cancel";

        if (txtblno.Text.Trim().ToUpper() != "")
        {
            if (txtjobno.Value == "0" || txtjobno.Value == "")
            {

                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid BL #');", true);
                //  txtblno.Focus();
                chkmbl.Focus();
                txtclear();
                chargetxtclear();
                return;

            }
            else
            {
                if (txtCreditDays.Text == "")
                {
                    txtCreditDays.Text = "7";
                }
            }
        }
    }
    UserRights();

}
catch (Exception ex)
{
    string message = ex.Message.ToString();
    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
}
btncancel.Text = "Cancel";
}
*/


        public void txtclear()
        {
            if (Session["Loginyear"].ToString() == Session["Vouyear"].ToString())
            {

            }
            else
            {
                btn_save1.Visible = false;
            }
            cmbbill.SelectedIndex = 0;
            txtblno.Text = "";
            txtjobno.Value = "0";
            txtto.Text = "";
            txtref.Text = "";
            txtvessel.Text = "";
            txtdes.Text = "";
            txtshipper.Text = "";
            txtconsignee.Text = "";
            txtnotify.Text = "";
            txtremarks.Text = "";
            txtagent.Text = "";
            txtmlo.Text = "";
            txtcnf.Text = "";
            txtcharge.Text = "";
            txtcurr.Text = "";
            txtrate.Text = "";
            txtex.Text = "";
            cmbbase.SelectedIndex = 0;
            txtamount.Text = "";
            txtaddress.Text = "";
            txtsupplyto.Text = "";
            txtsupplytoAddress.Text = "";
            lstvol.Items.Clear();
            lstcon.Items.Clear();
            grd.DataSource = null;
            grd.DataBind();
            txtblno.Focus();
            chkmbl.Checked = false;
            btnsave.Visible = true;

            btnadd.Visible = true;
            grd.Enabled = true;
            txtTotal.Text = "";
            hdnblno.Value = "0";
            hdncustid.Value = "0";
            hdncityid.Value = "0";

            hid_SupplyTo.Value = "0";
            hid_SupplyToadd.Value = "0";
            btnsave.Enabled = true;
            btnsave.ForeColor = System.Drawing.Color.White;
            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;
            UserRights();
        }


        public void txtclear4refno()
        {
            cmbbill.SelectedIndex = -1;
            txtblno.Text = "";
            txtjobno.Value = "0";
            txtto.Text = "";

            txtvessel.Text = "";
            txtdes.Text = "";
            txtshipper.Text = "";
            txtconsignee.Text = "";
            txtnotify.Text = "";
            txtremarks.Text = "";
            txtagent.Text = "";
            txtmlo.Text = "";
            txtcnf.Text = "";
            txtcharge.Text = "";
            txtcurr.Text = "";
            txtrate.Text = "";
            txtex.Text = "";
            cmbbase.SelectedIndex = -1;
            txtamount.Text = "";
            txtaddress.Text = "";
            txtsupplytoAddress.Text = "";
            lstvol.Items.Clear();
            lstcon.Items.Clear();
            grd.DataSource = null;
            grd.DataBind();
            txtblno.Focus();
            chkmbl.Checked = false;
            btnsave.Visible = true;
            btnsave.ForeColor = System.Drawing.Color.White;
            btnadd.Visible = true;
            btnadd.ForeColor = System.Drawing.Color.White;
            grd.Enabled = true;
            txtTotal.Text = "";
            hdnblno.Value = "0";
            hdncustid.Value = "0";
            hdncityid.Value = "0";
            hid_SupplyTo.Value = "0";
            hid_SupplyToadd.Value = "0";
            txtVendorRefnodate.Text = "";
            UserRights();
        }
        public void chargetxtclear()
        {
            txtcharge.Text = "";
            txtcurr.Text = "";
            txtrate.Text = "";
            txtex.Text = "";

            cmbbase.SelectedIndex = -1;
            txtamount.Text = "";
            btnadd.ToolTip = "Add";
            btn_add1.Attributes["class"] = "btn btn-add1";
            txtcharge.Enabled = true;
            cmbbase.Enabled = true;
        }
        public void txtDisable()
        {
            cmbbill.Enabled = false;
            txtblno.Enabled = false;
            txtto.Enabled = false;
            txtref.Enabled = false;
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
            txtaddress.Enabled = false;
            txtsupplytoAddress.Enabled = false;
        }

        public void txtEnable()
        {
            cmbbill.Enabled = true;
            txtblno.Enabled = true;
            txtto.Enabled = true;
            txtref.Enabled = true;
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
            txtaddress.Enabled = true;
            txtsupplytoAddress.Enabled = true;
        }
        public void CheckData()
        {
            if (txtblno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the  BL Number');", true);
                txtblno.Focus();
                blnerr = true;
                return;
            }

            if (txtto.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer Name cannot be blank');", true);

                txtto.Focus();
                blnerr = true;
                return;
            }

            else
            {
                int cust = 0;
                //cust = customerobj.GetCustomerid(txtto.Text);
                cust = Convert.ToInt32(hdncustid.Value);
                if (hdncustid.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Customer cannot be blank');", true);

                    txtto.Focus();
                    blnerr = true;
                    return;
                }

                if (hid_SupplyTo.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('SupplyTo Customer cannot be blank');", true);

                    txtsupplyto.Focus();
                    blnerr = true;
                    return;
                }
            }
            //Bhuvana
            if (cmbbill.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bill type cannot be blank');", true);

                cmbbill.Focus();
                blnerr = true;
                return;
            }

            if (chkmbl.Checked == true)
            {
                if (cmbbill.Text == "Profit Share")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Profit Share should not be Used for MBL#');", true);

                    cmbbill.Focus();
                    blnerr = true;
                    return;
                }
            }
        }

        protected void cmbbill_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtblno.Text != "")
            {
                Session["cmbbill"] = cmbbill.SelectedItem.Text;
            }

            try
            {
                strTranType = Session["StrTranTypenew"].ToString();
                // frmname = Request.QueryString["type"].ToString();
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
                DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
                DataTable DtDetails = new DataTable();
                string bookingno;
                int intcustomerid4DO;

                if (lbl_Header.Text == "Profoma Invoice")
                {
                    if (cmbbill.SelectedValue == "Credit")
                    {
                        txtcreditapp1.Text = "";
                        txtcreditapp1.Enabled = true;
                        bookingno = FIBLobj.GetBookinkNo(txtblno.Text.ToUpper(), branchid, divisionid);
                        DtDetails = FEBLobj.GetBookingDt(bookingno, branchid, divisionid);
                        if (DtDetails.Rows.Count > 0)
                        {
                            intcustomerid4DO = Convert.ToInt32(DtDetails.Rows[0][13].ToString());
                        }
                        txtcreditapp1.Text = "Not Updated";

                    }
                    else
                    {
                        txtcreditapp1.Text = "";
                        txtcreditapp1.Enabled = false;
                    }

                }
                else
                {
                    txtcreditapp1.Text = "";
                    txtcreditapp1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string a = hdncityid.Value;
                int cityid; string address;
                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranTypenew"].ToString();
                int int_custid = Convert.ToInt32(hdncustid.Value);
                DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                if (txtto.Text != "")
                {
                    int_custid = Convert.ToInt32(hdncustid.Value);
                    DataTable dt_list = new DataTable();
                    /*dt_list = (DataTable)Session["Cust_Dt"];
                     if (dt_list !=null && int_custid !=0)
                     {
                         cityid = Convert.ToInt32(dt_list.Rows[0]["city"].ToString());
                         address = dt_list.Rows[0]["address"].ToString();
                         txtaddress.Text = "";
                         txtaddress.Text = address;
                         cmbbill.Focus();
                        grdfill();
                     }
                     else if(int_custid == 0)
                     {
                         ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alertify.alert('Select Correct Customer Name');", true);
                         txtto.Text = "";
                         txtto.Focus();
                         return;
                     }*/

                    if (int_custid != 0)
                    {
                        //if (lbl_Header.Text != "Profoma Credit Note - Operations")
                        //{
                        dt_list = customerobj.GetIndianCustomergst(int_custid);
                        if (dt_list.Rows.Count > 0)
                        {
                            if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    txtaddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                    ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                }
                                else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                {
                                    txtaddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                    ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                }
                                else if (dt_list.Rows[0]["UnRegistered"].ToString() == "N" && !string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()) && !string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  OR  Select UnRegistered  Master Customer');", true);
                                }


                                //ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            }
                            else
                            {
                                txtaddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            return;
                        }

                        //}
                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('Select Correct Customer Name');", true);
                        txtto.Text = "";
                        txtto.Focus();
                        return;
                    }

                    if (Session["mblchk"] != null)
                    {
                        if (Session["mblchk"].ToString() == "true")
                        {
                            if (hid_mloid.Value != "")
                            {
                                hid_SupplyTo.Value = hid_mloid.Value;
                                txtsupplyto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                                //  txtsupplyto.Text = txtto.Text;
                                txtsupplyto_TextChanged(sender, e);
                            }





                            //else
                            //{
                            //    hid_SupplyTo.Value = hdncustid.Value;
                            //}


                        }
                    }
                }

                if (txtref.Text == "")
                {
                    DataAccess.Accounts.ProfomaInvoice obj_da_head = new DataAccess.Accounts.ProfomaInvoice();


                    string str_blno, str_custname; int custid;
                    obj_dt_head = obj_da_head.CheckProinvCustblno(txtblno.Text, int_custid, str_TranType, int_branchid, Convert.ToInt32(txtvouyear.Text), hf_strtype.Value);
                    if (obj_dt_head.Rows.Count > 0)
                    {
                        str_blno = obj_dt_head.Rows[0][5].ToString();
                        custid = Convert.ToInt32(obj_dt_head.Rows[0][4].ToString());
                        cstid.Value = custid.ToString();
                        str_custname = obj_da_mc.GetCustomername(custid);
                        if (txtblno.Text == str_blno && txtto.Text == str_custname)
                        {

                            ViewState["obj_dt_head"] = obj_dt_head;
                            pnlConfirm.Attributes["class"] = "popupconfirmnew";

                            popupconfirmnew.Show();

                            return;
                        }
                        else
                        {
                            //btnsave.Text = "Save";
                            btnsave.ToolTip = "Save";
                            btn_save1.Attributes["class"] = "btn ico-save";
                        }
                    }

                    else
                    {
                        if (int_custid != 0)
                        {
                            DataAccess.Corporate obj_da_corpobj = new DataAccess.Corporate();
                            if (obj_da_corpobj.GetGroupID(int_custid, int_divisionid) != 0)
                            {
                                if (obj_da_mc.CheckCreditAmount(int_custid, int_branchid, int_divisionid) > 0)
                                {
                                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alertify.alert('" + obj_da_mc.GetCustomername(int_custid) + " has already reached the credit limit rupees " + obj_da_mc.GetCreditAmount(int_custid, int_divisionid) + "');", true);
                                }
                            }
                        }

                        grd.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd.DataBind();
                        txtref.Text = "";
                        txtremarks.Text = "";
                    }
                } UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (btncancel.ToolTip == "Cancel")
                {
                    lbl_appr.Visible = false;
                    lbl_txt.Visible = false;
                    txtclear();
                    txtEnable();
                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Gray;
                    btnsave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    //btncancel.Text = "Back";
                    btncancel.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                    txtblno.Focus();
                    btnadd.ToolTip = "Add";
                    btn_add1.Attributes["class"] = "btn btn-add1";
                    txtcharge.Enabled = true;
                    txtTotal.Text = "";
                    grd.Enabled = true;
                    txtVendorRefno.Text = "";
                    txtCreditDays.Text = "";
                    hdnfatransfer.Value = "0";
                    txtVendorRefnodate.Text = "";

                    txtsupplyto.Text = "";


                    dtdate.Text = Logobj.GetDate().ToShortDateString();
                    dtdate.Text = Utility.fn_ConvertDate(dtdate.Text);

                    //FillOnPageLoad();
                    dt = new DataTable();
                    ShowNoResultFound(dt, grd);
                    // btnview.Enabled = false;
                    //btnview.ForeColor = System.Drawing.Color.Gray;
                    // Session["LoginEmpId"] = Session["LoginEmpId"].ToString();

                    if (Session["LoginDivisionId"] != null)
                    {
                        divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    }
                    if (Session["LoginBranchid"] != null)
                    {
                        branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    }

                    dtnew1 = obj_branchd.GetBranchGST(divisionid, branchid);
                    if (dtnew1.Rows.Count > 0)
                    {
                        btnsave.Enabled = false;
                        btnsave.ForeColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        btnsave.Enabled = true;
                        btnsave.ForeColor = System.Drawing.Color.White;
                    }


                }
                else
                {
                  //  this.Response.End();

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
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                useit();
                Session["LoginEmpId"] = Session["LoginEmpId"].ToString();
                int empid = Convert.ToInt32(Session["LoginEmpId"]);
                /* if (txtblno.Text.Trim().ToUpper() != "")
                 {
                     if (chkmbl.Checked == false)
                     {
                         Dt = new DataTable();
                         Dt = Amendobj.GetBLno(strTranType, txtblno.Text.Trim().ToUpper(), branchid, divisionid);
                         if (Dt.Rows.Count == 0)
                         {
                             ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid BL #');", true);
                             txtblno.Focus();

                             return;
                         }

                     }
                     else
                     {
                         Dt = new DataTable();
                         Dt = Amendobj.GetMBLno(strTranType, txtblno.Text.Trim().ToUpper(), branchid, divisionid);
                         if (Dt.Rows.Count == 0)
                         {
                             ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid BL #');", true);
                             txtblno.Focus();

                             return;
                         }
                     }
                 }*/

                if (txtCreditDays.Text == "")
                {
                    txtCreditDays.Text = "0";
                }

                CheckData();
                if (lbl_Header.Text == "Profoma Credit Note - Operations")
                {
                    if (txtVendorRefno.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the  VendorRefno');", true);
                        txtVendorRefno.Focus();
                        blnerr = true;
                        return;
                    }
                    if (txtVendorRefnodate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the  VendorRef Deate');", true);
                        txtVendorRefnodate.Focus();
                        blnerr = true;
                        return;
                    }
                }

                if (blnerr == true)
                {
                    blnerr = false;
                    return;
                }

                if (lbl_Header.Text == "Profoma Invoice")
                {
                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
                        bolcuststat = false;
                        return;
                    }
                    else
                    {
                        ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                        if (bolcuststat == true)
                        {
                            bolcuststat = false;
                            return;
                        }

                    }
                }
                else
                {
                    if (txtsupplyto.Text == "")
                    {
                        hid_SupplyTo.Value = hdncustid.Value;

                        txtsupplyto.Text = txtto.Text;
                        txtsupplyto_TextChanged(sender, e);
                    }
                }

                if (hid_SupplyTo.Value == "0" || hid_SupplyTo.Value == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From');", true);
                    return;
                }
                try
                {
                    if (btnsave.ToolTip == "Save")
                    {
                        if (txtref.Text != "")
                        {
                            return;
                        }

                        //if (lbl_Header.Text!= "Profoma Credit Note - Operations")
                        //{
                        //    if (txtsupplyto.Text != "")
                        //    {
                        //        int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                        //        DataTable dt_list = new DataTable();
                        //        dt_list = customerobj.GetIndianCustomergstadd(int_custid);
                        //        if (dt_list.Rows.Count > 0)
                        //        {
                        //            if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                        //            {

                        //            }
                        //            else
                        //            {
                        //                ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('State Name not Updated in Master Kindly update Master Customer " + txtsupplyto.Text + " SupplyTo');", true);
                        //                return;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('State Name not Updated in Master Kindly update Master Customer " + txtsupplyto.Text + " SupplyTo');", true);
                        //            return;
                        //        }

                        //    }
                        //}

                        if (cmbbill.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Bill Type');", true);
                            return;
                        }

                        //if ((INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjobno.Value), branchid)) == 1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtjobno.Value + " has been Closed Already...You Can not create a Voucher');", true);
                        //    return;

                        //}

                        txtjobno.Value = "0";
                        //dtdate.Text = Utility.fn_ConvertDate(dtdate.Text).ToString();

                        if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            Refno = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), strTranType, Convert.ToInt32(txtjobno.Value), Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), type, txtVendorRefno.Text, Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                        }
                        else
                        {
                            Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), strTranType, Convert.ToInt32(txtjobno.Value), Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), type, txtVendorRefno.Text, Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value));
                        }
                        txtref.Text = Refno.ToString();
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            switch (Session["StrTranTypenew"].ToString())
                            {
                                case "CT":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1811, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno + "CT");
                                    break;
                                case "WH":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1815, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno + "WH");
                                    break;
                            }
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            switch (Session["StrTranTypenew"].ToString())
                            {
                                case "CT":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1812, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno + "CT");
                                    break;
                                case "WH":
                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1816, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno + "WH");
                                    break;
                            }
                        }
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Ref # " + txtref.Text + " saved ');", true);
                        btnsave.Enabled = false;
                        //btnsave.Text = "Update";
                        btnsave.ToolTip = "Update";
                        btn_save1.Attributes["class"] = "btn btn-update1";
                        btnadd.Enabled = true;
                        btnsave.ForeColor = System.Drawing.Color.Gray;
                        btnadd.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {


                        if (cmbbill.SelectedIndex == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Bill Type');", true);
                            return;
                        }
                        dtcheck = new DataTable();
                        dtcheck = INVOICEobj.GetCheckApprovedProfoma(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), strTranType, type, "HeadUpdate");
                        if (dtcheck.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Update Denied, Already Approved for Ref# " + txtref.Text + "');", true);
                            return;
                        }
                        else
                        {
                            if (Convert.ToInt32(hdncustid.Value) != 0)
                            {

                                if (lbl_Header.Text == "Profoma Credit Note - Operations")
                                {
                                    ProINVobj.UpdateProHeadnew(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtremarks.Text.Trim(), cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, txtVendorRefno.Text.Trim(), Convert.ToInt32(txtCreditDays.Text), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                                }
                                else
                                {
                                    ProINVobj.UpdateProHead(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtremarks.Text.Trim(), cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, txtVendorRefno.Text.Trim(), Convert.ToInt32(txtCreditDays.Text), Convert.ToInt32(hid_SupplyTo.Value));
                                }


                                if (hid_SupplyTonew.Value != hid_SupplyTo.Value)
                                {

                                    ProINVobj.UpdChargesGST4OldVou(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), type);
                                    hid_SupplyTonew.Value = hid_SupplyTo.Value;


                                }
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated for Ref# " + txtref.Text + "');", true);
                                return;
                                // btnadd.Enabled = true;
                                // btnadd.ForeColor = System.Drawing.Color.White;
                            }
                        }
                    }
                    txtDisable();
                    btnadd.Enabled = true;
                    btnadd.ForeColor = System.Drawing.Color.White;
                    txtcharge.Focus();
                    //dtdate.Text = Utility.fn_ConvertDate(dtdate.Text).ToString();
                    UserRights();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }
        }

        public void ChkCustStateName(int custid, string custname)
        {
            if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
            {
                if (custname != "" && custid > 0)
                {

                    //int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    DataTable dt_list = new DataTable();
                    dt_list = customerobj.GetIndianCustomergstadd(custid);
                    if (dt_list.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                        bolcuststat = true;
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Kindly update SUPPLY TO Name " + custname + "');", true);
                    bolcuststat = true;
                    return;
                }
            }
        }

        public void grdfill()
        {
            grd.DataSource = null;
            grd.DataBind();
            useit();
            if (lbl_Header.Text == "Profoma Credit Note - Operations")
            {
                type = "Profoma Payment Advise";
                hf_strtype.Value = type;
            }
            else
            {
                type = lbl_Header.Text;
                hf_strtype.Value = type;
            }
            DtInfo = new DataTable();
            DtInfo = ProINVobj.GetProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, type);
            grd.DataSource = DtInfo;
            grd.DataBind();

            txtTotal.Text = "";
            double tot = 0, tot1 = 0;
            for (i = 0; i <= grd.Rows.Count - 1; i++)
            {
                tot1 = Convert.ToDouble(grd.Rows[i].Cells[7].Text);
                tot = tot + tot1;
            }
            txtTotal.Text = tot.ToString("#,0.00");


        }

        public void useit()
        {
            try
            {
                strTranType = Session["StrTranTypenew"].ToString();
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                //type = Request.QueryString["type"].ToString();
                if (lbl_Header.Text == "Profoma Credit Note - Operations")
                {
                    type = "Profoma Payment Advise";
                    hf_strtype.Value = type;
                }
                else
                {
                    type = lbl_Header.Text;
                    hf_strtype.Value = type;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtref_TextChanged(object sender, EventArgs e)
        {
            try
            {
                useit();
                //   DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                if (lbl_Header.Text == "Profoma Credit Note - Operations" && strTranType == "AE")
                {
                    type = "Profoma Payment Advise";
                    hf_strtype.Value = type;
                }
                else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                {
                    type = "Profoma Payment Advise";
                    hf_strtype.Value = type;
                }
                else
                {
                    type = lbl_Header.Text;
                    hf_strtype.Value = type;
                }
                txtclear4refno();
                DtSHead = ProINVobj.SelProInvHead(Convert.ToInt32(txtref.Text), strTranType, Convert.ToInt32(txtvouyear.Text), branchid, type);
                if (DtSHead.Rows.Count > 0)
                {
                    btn_save1.Visible = true;
                    // txtjobno.Value = DtSHead.Rows[0]["jobno"].ToString();
                    hdncustid.Value = DtSHead.Rows[0]["customerid"].ToString();
                    txtto.Text = DtSHead.Rows[0]["customername"].ToString();
                    txtblno.Text = DtSHead.Rows[0]["blno"].ToString();
                    //Session["LoginEmpId"] = DtSHead.Rows[0]["approvedby"].ToString();
                    txtremarks.Text = DtSHead.Rows[0]["remarks"].ToString();
                    //cmbbill.SelectedValue = DtSHead.Rows[0]["billtype"].ToString();
                    hdnfatransfer.Value = DtSHead.Rows[0]["fatransfer"].ToString();
                    dtdate.Text = DtSHead.Rows[0][1].ToString();
                    txtaddress.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hdncustid.Value));

                    /*  DataTable dt_list = new DataTable();

                      if (lbl_Header.Text != "Profoma Credit Note - Operations")
                      {
                          dt_list = customerobj.GetIndianCustomergst(Convert.ToInt32(hdncustid.Value));
                          if (dt_list.Rows.Count > 0)
                          {
                              if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                              {
                                  if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                  {
                                      txtaddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                      ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                  }
                                  else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                  {
                                      txtaddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                      ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                  }

                          
                                  ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno# OR STATENAME Master Customer');", true);
                              }
                              else
                              {
                                  txtaddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                              }
                          }
                          else
                          {
                              ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno# OR STATENAME Master Customer');", true);
                              return;
                          }
                   
                      }*/
                    if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyTo"].ToString()))
                    {
                        hid_SupplyTo.Value = DtSHead.Rows[0]["SupplyTo"].ToString();
                        hid_SupplyTonew.Value = DtSHead.Rows[0]["SupplyTo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyToName"].ToString()))
                    {
                        txtsupplyto.Text = DtSHead.Rows[0]["SupplyToName"].ToString();
                        // txtsupplytoAddress.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hid_SupplyTo.Value));


                        string citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
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

                    /*DataTable dt_listnew = new DataTable();

                    if (lbl_Header.Text != "Profoma Credit Note - Operations")
                    {
                        dt_listnew = customerobj.GetIndianCustomergst(Convert.ToInt32(hid_SupplyTo.Value));
                        if (dt_listnew.Rows.Count > 0)
                        {
                            if (string.IsNullOrEmpty(dt_listnew.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_listnew.Rows[0]["uinno"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(dt_listnew.Rows[0]["gstin"].ToString()))
                                {
                                    txtsupplytoAddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                    ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                }
                                else if (!string.IsNullOrEmpty(dt_listnew.Rows[0]["uinno"].ToString()))
                                {
                                    txtsupplytoAddress.Text += System.Environment.NewLine + "UIN #:" + dt_listnew.Rows[0]["uinno"].ToString();

                                    ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                }


                                ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno# OR STATENAME Master Customer');", true);
                            }
                            else
                            {
                                txtsupplytoAddress.Text += System.Environment.NewLine + dt_listnew.Rows[0]["Column1"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txtref, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno# OR STATENAME Master Customer');", true);
                            return;
                        }

                    }*/
                    string bill = DtSHead.Rows[0]["billtype"].ToString();
                    cmbbill.Items.Clear();
                    cmbbill.Items.Add("");
                    cmbbill.Items.Add("Cash/Cheque");
                    cmbbill.Items.Add("Credit");
                    cmbbill.Items.Add("Internal");

                    if (Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
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
                        else if (bill == "--BILLTYPE--")
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
                        else if (bill == "--BILLTYPE--")
                        {
                            cmbbill.SelectedIndex = 0;
                        }
                    }


                    if (type == "Profoma Payment Advise" || type == "Profoma Credit Note - Operations")
                    {
                        if (DtSHead.Rows[0]["vendorrefno"] != System.DBNull.Value)
                        {
                            txtVendorRefno.Text = DtSHead.Rows[0]["vendorrefno"].ToString();
                        }
                        else
                        {
                            txtVendorRefno.Text = "";
                        }

                        txtCreditDays.Text = DtSHead.Rows[0]["creditdays"].ToString();
                        if (DtSHead.Rows[0]["vendorrefdate"] != System.DBNull.Value)
                        {
                            txtVendorRefnodate.Text = DtSHead.Rows[0]["vendorrefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                    }
                    else
                    {
                        txtVendorRefno.Text = "";
                        txtCreditDays.Text = "";
                        txtVendorRefnodate.Text = "";
                    }
                    if (strTranType == "CT" || strTranType == "WH")
                    {
                        if (txtblno.Text != "")
                        {
                            Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Value), strTranType, branchid);
                            if (dt.Rows.Count > 0)
                            {
                                for (i = 0; i <= Dt.Rows.Count - 1; i++)
                                {
                                    hdnblno.Value = Dt.Rows[i][0].ToString();
                                    if (hdnblno.Value == txtblno.Text)
                                    {
                                        chkmbl.Checked = true;
                                        continue;

                                    }
                                    else
                                    {
                                        chkmbl.Checked = false;
                                    }

                                }
                            }
                            // getFEI();
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                        }

                    }
                    /* else if (strTranType == "AE" || strTranType == "AI")
                     {
                         if (txtblno.Text != "")
                         {
                             Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Value), strTranType, branchid);
                             for (i = 0; i <= Dt.Rows.Count - 1; i++)
                             {
                                 hdnblno.Value = Dt.Rows[i][0].ToString();
                                 if (hdnblno.Value == txtblno.Text)
                                 {
                                     chkmbl.Checked = true;
                                     continue;
                                 }
                                 else
                                 {
                                     chkmbl.Checked = false;

                                 }
                             }
                             getAEI();
                             btnview.Enabled = true;
                             btnview.ForeColor = System.Drawing.Color.White;
                         }
                         else
                         {
                             if (txtblno.Text != "")
                             {
                                 getCHA();
                                 btnview.Enabled = true;
                                 btnview.ForeColor = System.Drawing.Color.White;
                             }
                         }
                     }*/
                    grdfill();
                    txtTotal.Text = "";
                    double tot = 0, tot1 = 0;
                    for (i = 0; i <= grd.Rows.Count - 1; i++)
                    {
                        tot1 = Convert.ToDouble(grd.Rows[i].Cells[7].Text);
                        tot = tot + tot1;
                    }
                    txtTotal.Text = tot.ToString("#,0.00");
                    btnsave.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn btn-update1";
                    btncancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";
                    txtcharge.Enabled = true;
                    txtcharge.Focus();
                    btnview.Enabled = true;
                    btnview.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    /*if(type == "Profoma Invoice")
                    {
                        dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Profoma Invoice");
                        if(dtref .Rows.Count >0)
                        {
                            ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transferred');", true);
                            txtref.Focus();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('No Values Found');", true);
                            txtref.Focus();
                        }
                    }
                    else
                    {
                        dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Invalid Refno");
                        txtref.Focus();
                    }*/
                    if (type == "Profoma Invoice")
                    {
                        dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Profoma Invoice");
                    }

                    else
                    {
                        dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Profoma Payment Advise");
                    }
                    if (dtref.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transferred');", true);
                        txtref.Text = "";
                        txtref.Focus();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Refno');", true);
                        txtref.Text = "";
                        txtref.Focus();
                    }

                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtref.Text = "";
                txtref.Focus();
            }
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            //popupconfirm.Show();
            try
            {
                if (txtcharge.Text != "")
                {
                    useit();

                    DataTable dtgst = new DataTable();
                    dtgst = Logobj.GetGSTDts();
                    if (dtgst.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dtgst.Rows[0]["GSTDate"].ToString()))
                        {
                            hid_gstdate.Value = Convert.ToDateTime(dtgst.Rows[0]["GSTDate"].ToString()).ToString();


                        }


                    }

                    // DateTime dtgetdate = Convert.ToDateTime(dtdate.Text);
                    string a = type;
                    if (lbl_Header.Text == "Profoma Credit Note - Operations")
                    {
                        type = "Profoma Payment Advise";
                        hf_strtype.Value = type;
                    }
                    else
                    {
                        type = lbl_Header.Text;
                        hf_strtype.Value = type;
                    }
                    //hdnChargid.Value = chargeobj.GetChargeid(txtcharge.Text).ToString();
                    if (hdnChargid.Value == "0" || hdnChargid.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('InValid Charge Name');", true);
                        txtcharge.Focus();
                        return;
                    }
                    if (chargeobj.GetCurrID(txtcurr.Text.Trim()) == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('InValid Currency Name');", true);
                        txtcurr.Focus();
                        return;
                    }
                    if (cmbbase.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('select Base');", true);
                        txtcurr.Focus();
                        return;
                    }


                    strcharge = txtcharge.Text;
                    if (strcharge.Length >= 5)
                    {
                        if (strcharge.Substring(0, 5) == "ST on" || strcharge.Substring(0, 5) == "EduCe" || strcharge.Substring(0, 5) == "Highe")
                        {
                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cannot Access the Charge');", true);
                            txtcharge.Focus();
                            return;
                        }
                    }
                    cmbbase_SelectedIndexChanged(sender, e);

                    dtchargedel = INVOICEobj.GetCheckApprovedProfoma(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), "", type, "Charge");
                    if (dtchargedel.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charges Cannot Delete After Approved');", true);
                        return;
                    }
                    if ((INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjobno.Value), branchid)) == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtjobno.Value + " has Closed Already...You Can not create a Voucher');", true);
                        return;

                    }
                    try
                    {
                        if (txtamount.Text != "0" && hdnUnit.Value != "")
                        {
                            if (lbl_Header.Text == "Profoma Invoice")
                            {
                                ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                                if (bolcuststat == true)
                                {
                                    bolcuststat = false;
                                    return;
                                }
                            }
                            else
                            {

                                if (txtsupplyto.Text == "")
                                {
                                    hid_SupplyTo.Value = hdncustid.Value;
                                    txtsupplyto.Text = txtto.Text;
                                    txtsupplyto_TextChanged(sender, e);
                                }

                            }

                            if (btnadd.ToolTip == "Add")
                            {
                                if (txtref.Text == "")
                                {
                                    return;
                                }


                                //    if (lbl_Header.Text != "Profoma Credit Note - Operations")
                                //    {
                                //    if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(hid_gstdate.Value))
                                //    {
                                //    if (txtto.Text != "")
                                //    {
                                //        int int_custid = Convert.ToInt32(hdncustid.Value);
                                //        DataTable dt_list = new DataTable();
                                //        dt_list = customerobj.GetIndianCustomergstadd(int_custid);
                                //        if (dt_list.Rows.Count>0)
                                //        {
                                //            if (!string.IsNullOrEmpty(dt_list.Rows[0]["stateid"].ToString()))
                                //            {

                                //            }
                                //            else
                                //            {
                                //                ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('State Name not Updated in Master Kindly update Master Customer ');", true);
                                //                return;
                                //            }
                                //        }
                                //        else
                                //        {
                                //            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('State Name not Updated in Master Kindly update Master Customer');", true);
                                //            return;
                                //        }

                                //    }
                                //  }
                                //}
                                dtcheck = ProINVobj.CheckchrgInvPro(Convert.ToInt32(txtref.Text), cmbbase.Text, Convert.ToInt32(hdnChargid.Value), Convert.ToInt32(txtvouyear.Text), branchid, type);
                                if (dtcheck.Rows.Count > 0)
                                {

                                    chargename = 1;
                                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charges Name Already Exists...');", true);
                                    txtcharge.Focus();
                                    return;
                                }
                                else
                                {
                                    chargename = 0;
                                    if (txtcharge.Text != "" && txtrate.Text != "" && txtex.Text != "" && txtcurr.Text != "" && cmbbase.Text != "" && txtamount.Text != "")
                                    {





                                        if (type == "Profoma Payment Advise")
                                        {
                                            if (cmbbill.Text != "Internal")
                                            {
                                                double stper;
                                                stper = chargeobj.CheckChargeST(Convert.ToInt32(hdnChargid.Value));
                                                if (stper == 0)
                                                {

                                                    ProINVobj.InsertProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedItem.Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedItem.Text, strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));



                                                }
                                                else
                                                {
                                                    this.PopUpService.Show();
                                                    return;
                                                }

                                            }
                                            else
                                            {


                                                ProINVobj.InsertProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.Text, strTranType, type, "Y", Convert.ToDouble(hdnUnit.Value));

                                            }

                                        }
                                        else
                                        {

                                            ProINVobj.InsertProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.Text, strTranType, type, "Y", Convert.ToDouble(hdnUnit.Value));

                                        }
                                        switch (Session["StrTranTypenew"].ToString())
                                        {
                                            case "CT":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1811, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "CT");
                                                break;
                                            case "WH":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1815, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "WH");
                                                break;

                                        }
                                        grdfill();
                                        txtcharge.Focus();

                                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charges Details Saved...');", true);
                                        //txtcharge.Text = ""; txtcurr.Text = ""; txtrate.Text = ""; txtex.Text = ""; txtamount.Text = ""; cmbbase.SelectedIndex = 0;
                                    }
                                }

                            }

                            else
                            {
                                if (txtcharge.Text != "" && txtrate.Text != "" && txtex.Text != "" && txtcurr.Text != "" && cmbbase.Text != "" && txtamount.Text != "")
                                {
                                    if (strTranType == "CH")
                                    {
                                        Dt = new DataTable();
                                        Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text, "CH", branchid);
                                        if (Dt.Rows.Count > 0)
                                        {
                                            jobtype = Dt.Rows[0][10].ToString();
                                        }
                                    }

                                    ProINVobj.UpdateProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), hid_cmbase.Value, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, Convert.ToDouble(hdnUnit.Value));

                                    switch (Session["StrTranTypenew"].ToString())
                                    {
                                        case "CT":
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1812, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "CT");
                                            break;
                                        case "WH":
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1816, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "WH");
                                            break;
                                        //case "FI":
                                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 779, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                        //    break;
                                        //case "AE":
                                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 390, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                        //    break;
                                        //case "AI":
                                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 391, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                        //    break;
                                        //case "CH":
                                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 392, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                        //    break;
                                    }
                                    grdfill();
                                    txtcharge.Focus();
                                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charges Details Updated ...');", true);
                                    //txtcharge.Text = ""; txtcurr.Text = ""; txtrate.Text = ""; txtex.Text = ""; txtamount.Text = ""; cmbbase.SelectedIndex = 0;
                                }
                            }
                        } grdfill();
                        chargetxtclear();
                        btnadd.ToolTip = "Add";
                        btn_add1.Attributes["class"] = "btn btn-add1";
                        txtcharge.Enabled = true;
                        btnadd.Enabled = false;
                        btnadd.ForeColor = System.Drawing.Color.Gray;
                        txtcharge.Focus();
                        UserRights();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
                    }





                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtcharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

                int chargeid = chargeobj.GetChargeid(txtcharge.Text.Trim().ToUpper());
                if (chargeid != 0)
                {
                    txtcurr.Focus();
                }
                else
                {
                    txtcharge.Text = "";
                    txtcharge.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Charges');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }
        public void CheckChargeBase()
        {
            useit();
            if (txtref.Text == "")
            {
                return;
            }
            if (txtcharge.Text != "")
            {
                dtcheck = ProINVobj.CheckchrgInvPro(Convert.ToInt32(txtref.Text), cmbbase.Text, Convert.ToInt32(hdnChargid.Value), Convert.ToInt32(txtvouyear.Text), branchid, type);
                if (dtcheck.Rows.Count > 0)
                {
                    chargename = 1;
                }
                else
                {
                    chargename = 0;
                }
            }
        }


        protected void btnok_Click(object sender, EventArgs e)
        {
            useit();
            //ProINVobj.InsertProInvoiceDetails(Convert.ToInt32(txtref.Text),Convert .ToInt32(hdnChargid.Value), txtcurr.Text,Convert.ToDouble (txtrate.Text),Convert.ToDouble ( txtex.Text), cmbbase.SelectedItem .Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32 (txtvouyear.Text), cmbbill.Text, strTranType, type, "Y", Convert.ToDouble (hdnUnit .Value));
            txtref.Text = "";
            txtremarks.Text = "";
            hid_SupplyTo.Value = hdncustid.Value;
            this.popupconfirmnew.Hide();
            //grdfill();
            //btnsave.Text = "Save";
            btnsave.ToolTip = "Save";
            btn_save1.Attributes["class"] = "btn ico-save";
            return;
            btnadd.Enabled = false;
            btnadd.ForeColor = System.Drawing.Color.Gray;
            UserRights();
        }

        protected void grd_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (hdnfatransfer .Value != "" )
            //{
            //    return;
            //}

            if (grd.Rows.Count > 0)
            {
                int index = grd.SelectedRow.RowIndex;
                //Session[index] = grd.SelectedRow.RowIndex;
                //Bhuvana
                strcharge = grd.SelectedRow.Cells[0].Text;

                if (strcharge.Length >= 5)
                {
                    if (strcharge.Length > 5)
                    {
                        if (strcharge.Substring(0, 6) == "Swachh" || strcharge.Substring(0, 6) == "KRISHI")
                        {
                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cannot Access the Charge');", true);
                            txtcharge.Focus();
                            return;
                        }
                    }
                    if (strcharge.Substring(0, 5) == "ST on" || strcharge.Substring(0, 5) == "EduCe" || strcharge.Substring(0, 5) == "Highe" || strcharge.Substring(0, 5) == "ROUND")
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Cannot Access the Charge');", true);
                        txtcharge.Focus();
                        return;
                    }
                }

                btnadd.ToolTip = "Upd";
                btn_add1.Attributes["class"] = "btn btn-upd1";
                txtcharge.Text = Server.HtmlDecode(grd.SelectedRow.Cells[0].Text);
                txtcurr.Text = grd.SelectedRow.Cells[1].Text;
                txtrate.Text = grd.SelectedRow.Cells[2].Text;
                txtrate.Text = String.Format("{0:F2}", txtrate.Text);
                txtex.Text = grd.SelectedRow.Cells[3].Text;
                txtex.Text = String.Format("{0:F2}", txtex.Text);
                cmbbase.SelectedValue = grd.SelectedRow.Cells[4].Text;
                hid_cmbase.Value = grd.SelectedRow.Cells[4].Text;
                //double gsta = Convert.ToDouble(grd.SelectedRow.Cells[5].Text);
                //txtamount.Text = grd.SelectedRow.Cells[6].Text ;
                //double gstamt= Convert.ToDouble( txtamount.Text);
                // double gasttot = gstamt - gsta;
                // txtamount.Text = String.Format("{0:F2}", gasttot);
                txtamount.Text = grd.SelectedRow.Cells[5].Text;
                txtamount.Text = String.Format("{0:F2}", txtamount.Text);
                txtcharge.Enabled = false;
                hdnChargid.Value = grd.SelectedRow.Cells[8].Text;
                txtcharge.Enabled = false;
                txtcharge.BackColor = Color.White;
                txtcharge.ForeColor = Color.Black;
                btnadd.Enabled = true;
                btnadd.ForeColor = System.Drawing.Color.White;
                txtcurr.Focus();
                txtDisable();
            } UserRights();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
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
                string charge = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CHARge"));
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }





        /*public double CheckBase(string strbase, double rate, double exrate)
        {
            useit();
            if (cmbbase.Text.ToUpper() == "BL".ToUpper() || cmbbase.Text.ToUpper() == "HWBL".ToUpper() || cmbbase.Text.ToUpper() == "DOC".ToUpper())
            {
                amount = rate * exrate;
                hdnUnit.Value = "1";
            }
            //---------------------------------------------------------------

            else if (cmbbase.Text.ToUpper() == "CBM".ToUpper() || cmbbase.Text.ToUpper() == "MT".ToUpper())
            {
                if (cmbbase.Text.ToUpper() == "CBM".ToUpper())
                {
                    if (strTranType == "CT")
                    {
                        if (chkmbl.Checked == false)
                        {
                            if (type == "InvoiceWoJ")
                            {
                                strvolume = INVOICEobj.GetVolume(txtblno.Text, "Wo", branchid);
                                amount = rate * exrate * strvolume;
                            }
                            else
                            {
                                strvolume = INVOICEobj.GetVolume(txtblno.Text, strTranType, branchid);
                                amount = rate * exrate * strvolume;
                                doublevolume = strvolume;
                                hdnUnit.Value = doublevolume.ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                            }
                        }
                        else
                        {
                            strvolume = INVOICEobj.GetSumofVolume(txtjobno.Value, strTranType, branchid);
                            amount = rate * exrate * strvolume;
                            doublevolume = strvolume;
                            hdnUnit.Value = doublevolume.ToString();
                            fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                        }
                    }

                    //--------------------------------------------------------------------------
                    else
                    {
                        if (chkmbl.Checked == false)
                        {
                            strvolume = INVOICEobj.GetVolume(txtblno.Text, strTranType, branchid);
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
                            fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                        }
                        else
                        {
                            strvolume = INVOICEobj.GetSumofVolume(txtjobno.Value, strTranType, branchid);
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
                            fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                        }
                    }
                }
                //--------------------------------------------------------------------------

                else
                {
                    if (cmbbase.Text.ToUpper() == "MT".ToUpper())
                    {
                        if (strTranType == "CT")
                        {
                            if (chkmbl.Checked == false)
                            {
                                if (type == "InvoiceWoJ")
                                {
                                    strntweight = INVOICEobj.GetWeight(txtblno.Text, "Wo", branchid);
                                    amount = rate * exrate * (strntweight / 1000);
                                }
                                else
                                {
                                    strntweight = INVOICEobj.GetWeight(txtblno.Text, strTranType, branchid);
                                    amount = rate * exrate * (strntweight / 1000);
                                    doublevolume = strntweight;
                                    hdnUnit.Value = (strntweight / 1000).ToString();
                                    fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                                }

                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeight(txtjobno.Value, strTranType, branchid);
                                amount = rate * exrate * (strntweight / 1000);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight / 1000).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                            }
                        }
                        else
                        {
                            if (chkmbl.Checked == false)
                            {
                                strntweight = INVOICEobj.GetWeight(txtblno.Text, strTranType, branchid);
                                amount = rate * exrate * (strntweight / 1000);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight / 1000).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeight(txtjobno.Value, strTranType, branchid);
                                amount = rate * exrate * (strntweight / 1000);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight / 1000).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                            }

                        }
                    }
                }
            }
            else if (cmbbase.Text.ToUpper() == "Kgs".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (chkmbl.Checked == true)
                    {
                        strchgweight = INVOICEobj.GetSumofChargeWght(Convert.ToInt32(txtjobno.Value), strTranType, branchid);
                        amount = rate * exrate * strchgweight;
                        doublevolume = strchgweight;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                    }
                    else
                    {
                        strchgweight = INVOICEobj.GetChargeWeight(txtblno.Text, strTranType, branchid);
                        amount = rate * exrate * strchgweight;
                        doublevolume = strchgweight;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                    }
                }
                else
                {
                    strgrosswght = INVOICEobj.GetGrossWeight(txtblno.Text, branchid);
                    amount = rate * exrate * strgrosswght;
                    hdnUnit.Value = strgrosswght.ToString();
                }
            }
            else if (cmbbase.Text.ToUpper() == "SB".ToUpper())
            {
                if (strTranType == "CT")
                {
                    if (chkmbl.Checked == true)
                    {
                        sizecount = INVOICEobj.GetSBillCount(txtblno.Text, Convert.ToInt32(txtjobno.Value), "MBL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                    }
                    else
                    {
                        sizecount = INVOICEobj.GetSBillCount(txtblno.Text, Convert.ToInt32(txtjobno.Value), "BL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                    }
                }
            }
            else if (cmbbase.Text.ToUpper() == "Volume".ToUpper())
            {
                strgrosswght = INVOICEobj.GetVolumeQty(txtblno.Text, branchid);
                amount = rate * exrate * strgrosswght;
                hdnUnit.Value = strgrosswght.ToString();
            }
            else
            {
                string chargebase;
                chargebase = cmbbase.Text;
                if (chkmbl.Checked == false)
                {
                    if (strTranType == "CT")
                    {
                        sizecount = INVOICEobj.GetBaseCount(txtblno.Text, chargebase, strTranType, "BL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                    }
                    else
                    {
                        sizecount = INVOICEobj.GetBaseCount(txtblno.Text, chargebase, strTranType, "BL", branchid);
                        amount = rate * exrate * sizecount;
                        doublevolume = sizecount;
                        hdnUnit.Value = doublevolume.ToString();
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                    }
                }
                else
                {
                    sizecount = INVOICEobj.GetBaseCount(txtjobno.Value, chargebase, strTranType, "MBL", branchid);
                    amount = rate * exrate * sizecount;
                    doublevolume = sizecount;
                    hdnUnit.Value = doublevolume.ToString();
                    fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                }
            }
            return amount;
        }

        */
        protected void cmbbase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtref.Text == "")
            {
                return;
            }
            if (cmbbase.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Any Of One of Base...');", true);
                return;
            }


            if (cmbbase.Text != "" && txtcharge.Text != "" && txtcurr.Text != "" && txtrate.Text != "")
            {
                string strbase = cmbbase.Text;
                famount = CheckBase(strbase, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text));
                txtamount.Text = famount.ToString();
                txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                btnadd.Enabled = true;
                btnadd.ForeColor = System.Drawing.Color.White;
                btnadd.Focus();
            }
            UserRights();
        }


        public double CheckBase(string strbase, double rate, double exrate)
        {
            double amount = 0;
            hdnUnit.Value = "1";
            if (Session["StrTranTypenew"] == "LT")
            {
                DataTable dt1 = new DataTable();
                DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
                dt1 = custobj.Getinvcountfrmcusid(Convert.ToInt32(hdncustid.Value));
                if (cmbbase.Text.ToUpper() == "DOC".ToUpper())
                {
                    amount = rate * exrate * Convert.ToInt32(dt1.Rows[0]["noofuser"]);
                }
            }
            else
            {
                if (cmbbase.Text.ToUpper() == "DOC".ToUpper())
                {
                    amount = rate * exrate;
                }
            }
            return amount;
        }
        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                useit();
                if (txtcharge.Text.Trim() == "")
                {
                    return;
                }

                DataTable dtchargedel = new DataTable();
                int index = 0;
                index = grd.Rows.Count;

                dtchargedel = INVOICEobj.GetCheckApprovedProfoma(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), "", type, "Charge");
                if (dtchargedel.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Charge Already Approved. Cannot Be Delete..", true);
                    return;
                }
                if (hfWasConfirmed.Value == "true")
                {
                    if (grd.Rows.Count > 0)
                    {
                        if (txtcharge.Text == "" && txtcurr.Text == "" && cmbbase.Text == "" && txtrate.Text == "" && txtex.Text == "" && txtamount.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Kindly Select The Charges.", true);
                            return;
                        }
                        else
                        {
                            //  hdnChargid.Value = chargeobj.GetChargeid(txtcharge.Text).ToString();
                            //hdnChargid.Value = chargeobj.SPChargeidCNamewithblock(txtcharge.Text).ToString();

                            if (hdnChargid.Value == "")
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Invalid Charge Name.", true);
                                txtcharge.Focus();
                                return;
                            }
                        }
                    }

                    if (strTranType == "CH")
                    {
                        Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text, "CHA", branchid);
                        if (Dt.Rows.Count != 0)
                        {
                            jobtype = Dt.Rows[0][10].ToString();
                        }
                    }
                    ProINVobj.DelProinvDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), cmbbase.SelectedItem.Text, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type);
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted.", true);
                    grdfill();

                    if (grd.Rows.Count == 0 || index < 1)
                    {
                        txtclear();
                        txtEnable();
                    }

                    chargetxtclear();

                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        switch (Session["StrTranTypenew"].ToString())
                        {
                            case "CT":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1811, 3, Convert.ToInt32(Session["LoginBranchid"]), "Del" + Session["StrTranTypenew"].ToString() + Refno + "CT");
                                break;
                            case "WH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1815, 3, Convert.ToInt32(Session["LoginBranchid"]), "Del" + Session["StrTranTypenew"].ToString() + Refno + "WH");
                                break;
                        }
                    }
                    else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                    {
                        switch (Session["StrTranTypenew"].ToString())
                        {
                            case "CT":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1812, 3, Convert.ToInt32(Session["LoginBranchid"]), "Del" + Session["StrTranTypenew"].ToString() + Refno + "CT");
                                break;
                            case "WH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1816, 3, Convert.ToInt32(Session["LoginBranchid"]), "Del" + Session["StrTranTypenew"].ToString() + Refno + "WH");
                                break;
                        }
                    }

                }
                UserRights();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime get_date, GST_date;

                get_date = Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text));
                GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());

                string bltype = "", header = "";
                if (chkmbl.Checked == true)
                {
                    bltype = "M";
                }
                else
                {
                    bltype = "H";
                }
                string str_sp = "", str_sf = "", str_RptName = "", str_Script = "";

                if (Session["StrTranTypenew"].ToString() == "LT")
                {
                    string header1 = "Invoice";
                    str_Script = "window.open('../Reportasp/Invoicerpt1.aspx?Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&customerid=" + hdncustid.Value + "&trantype=" + "LT" + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header1 + "&ltinvoice=" + "LTinvoice" + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Invoice", str_Script, true);
                }

                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranTypenew"].ToString();

                string Str_Container = "";
                if (str_TranType == "CT" || str_TranType == "WH")
                {
                    if (lstvol.Items.Count > 0)
                    {
                        Str_Container = lstvol.Items[0].ToString();
                    }
                    if (chkmbl.Checked == true)
                    {
                        var strcontainer = lstvol.Items.Cast<ListItem>().Select(row => row);
                        Str_Container = string.Join("/", strcontainer);
                    }
                    else
                    {
                        var strcontainer = lstvol.Items.Cast<ListItem>().Select(row => row).Take(lstvol.Items.Count - 2);
                        Str_Container = string.Join("/", strcontainer);
                    }
                }
                if (txtref.Text.TrimEnd().Length > 0)
                {
                    if (str_TranType == "CH")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            str_RptName = "CHProInvoice.rpt";
                            str_sf = "{ProInvoiceHead.trantype}=\"" + str_TranType + "\"  and {ProInvoiceHead.refno}=" + txtref.Text + " and {ProInvoiceHead.branchid}=" + int_branchid + " and {ProInvoiceHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            str_RptName = "CHAProPA.rpt";
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txtref.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            str_RptName = "CHAProDN.rpt";
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txtref.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            str_RptName = "CHAProCN.rpt";
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txtref.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                        }
                        Session["str_sfs"] = str_sf;
                        Session["str_sp"] = str_sp;
                    }
                    else if (str_TranType == "FI")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FIProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txtref.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProPA.rpt";
                                str_sp = "Lcurr=" + Str_Container;
                            }
                            else
                            {
                                str_RptName = "FIProPA.rpt";
                                str_sp = "";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txtref.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "FIProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txtref.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FIMProCN.rpt";
                                str_sp = "Lcurr=INR~container=" + Str_Container;
                            }
                            else
                            {
                                str_RptName = "FIProCN.rpt";
                                str_sp = "container=" + Str_Container;
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txtref.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txtvouyear.Text;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else if (str_TranType == "CT" || str_TranType == "WH")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txtref.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProPA.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProPA.rpt";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txtref.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txtref.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "FEMProCN.rpt";
                            }
                            else
                            {
                                str_RptName = "FEProCN.rpt";
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txtref.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR~container=" + Str_Container;
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else if (str_TranType == "AI")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txtref.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProPA.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProPA.rpt";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txtref.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txtref.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AIMProCN.rpt";
                            }
                            else
                            {
                                str_RptName = "AIProCN.rpt";
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txtref.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    else if (str_TranType == "AE")
                    {
                        if (lbl_Header.Text == "Profoma Invoice")
                        {
                            header = "Invoice";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProInvoice.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProInvoice.rpt";
                            }
                            str_sf = "{InvoiceHead.trantype}=\"" + str_TranType + "\"  and {InvoiceHead.refno}=" + txtref.Text + " and {InvoiceHead.branchid}=" + int_branchid + " and {InvoiceHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            header = "PA";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProPA.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProPA.rpt";
                            }
                            str_sf = "{PAHead.trantype}=\"" + str_TranType + "\"  and {PAHead.refno}=" + txtref.Text + " and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Debit Note")
                        {
                            header = "DN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProDN.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProDN.rpt";
                            }
                            str_sf = "{DNHead.trantype}=\"" + str_TranType + "\"  and {DNHead.refno}=" + txtref.Text + " and {DNHead.branchid}=" + int_branchid + " and {DNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                        else if (lbl_Header.Text == "Profoma Credit Note")
                        {
                            header = "CN";
                            if (chkmbl.Checked == true)
                            {
                                str_RptName = "AEMProCN.rpt";
                            }
                            else
                            {
                                str_RptName = "AEProCN.rpt";
                            }
                            str_sf = "{CNHead.trantype}=\"" + str_TranType + "\"  and {CNHead.refno}=" + txtref.Text + " and {CNHead.branchid}=" + int_branchid + " and {CNHead.vouyear}=" + txtvouyear.Text;
                            str_sp = "Lcurr=INR";
                            Session["str_sfs"] = str_sf;
                            Session["str_sp"] = str_sp;
                        }
                    }
                    if (str_RptName.Length > 0)
                    {
                        if (get_date >= GST_date)
                        {
                            str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&trantype=" + str_TranType + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Invoice", str_Script, true);
                    }
                }
                else
                {
                    if (str_TranType != "CH")
                    {
                        if (txtref.Text.TrimEnd().Length == 0 && lbl_Header.Text == "Profoma Credit Note - Operations")
                        {
                            str_RptName = "Pro PA Register.rpt";
                            str_sp = "Title=PROFORMA CREDIT NOTE - OPERATIONS REGISTER FOR VOUYEAR " + txtvouyear.Text;
                            str_sf = "{ACProPAHead.trantype}=\"" + str_TranType + "\" and {ACProPAHead.branchid}=" + int_branchid + " and {ACProPAHead.vouyear}=" + txtvouyear.Text;
                        }
                        else
                        {
                            str_RptName = "ProInvRegister.rpt";
                            str_sp = "Title=PROFORMA INVOICE REGISTER FOR VOUYEAR " + txtvouyear.Text;
                            str_sf = "{ACProInvoiceHead.trantype}=\"" + str_TranType + "\" and {ACProInvoiceHead.branchid}=" + int_branchid + " and {ACProInvoiceHead.vouyear}=" + txtvouyear.Text;
                        }
                    }
                    else if (str_TranType == "CH" && lbl_Header.Text == "Profoma Credit Note - Operations")
                    {
                        header = "PA";
                        str_RptName = "CHAProPA.rpt";
                        str_sf = "{PAHead.trantype}=\"" + str_TranType + "\" and {PAHead.branchid}=" + int_branchid + " and {PAHead.vouyear}=" + txtvouyear.Text;
                        str_sp = "Lcurr=INR";
                    }
                    else if (str_TranType == "CH" && lbl_Header.Text == "Profoma Invoice")
                    {
                        str_RptName = "ProInvRegister.rpt";
                        str_sp = "Title=PROFORMA INVOICE REGISTER FOR VOUYEAR " + txtvouyear.Text;
                        str_sf = "{ACProInvoiceHead.trantype}=\"" + str_TranType + "\" and {ACProInvoiceHead.branchid}=" + int_branchid + " and {ACProInvoiceHead.vouyear}=" + txtvouyear.Text;
                    }
                    if (str_RptName.Length > 0)
                    {
                        if (get_date >= GST_date && txtref.Text != "")
                        {
                            str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&blno=" + txtblno.Text + "&trantype=" + str_TranType + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        else
                        {
                            str_Script = "window.open('../Tools/ReportViewFA.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        }
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Invoice", str_Script, true);
                    }
                    Session["str_sfs"] = str_sf;
                    Session["str_sp"] = str_sp;
                }
                if (lbl_Header.Text == "Profoma Invoice")
                {
                    switch (Session["StrTranTypenew"].ToString())
                    {
                        case "CT":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1811, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                            break;
                        case "WH":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1815, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                            break;
                        //case "FI":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                        //case "AE":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                        //case "AI":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                        //case "CH":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                    }
                }
                else if (lbl_Header.Text == "Profoma Credit Note - Operations")
                {
                    switch (Session["StrTranTypenew"].ToString())
                    {
                        case "CT":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1812, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                            break;
                        case "WH":
                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1816, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                            break;
                        //case "FI":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1021, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                        //case "AE":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1028, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                        //case "AI":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1035, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                        //case "CH":
                        //    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1042, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        //    break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }


        /*   protected void txtrate_TextChanged(object sender, EventArgs e)
           {
               try
               {
                  string dtime= Convert.ToDateTime(Logobj.GetDate().ToShortDateString()).ToString("dd/MM/yyyy");
            
               if(txtrate.Text !="")
               {
                   useit();
                
                   if(txtcharge.Text !="" && txtcurr.Text !="")
                   {
                       if(txtcurr.Text.ToUpper() !="INR")
                       {
                           int jobno = Convert.ToInt32(txtjobno.Value);
                           txtex.Text = INVOICEobj.GetCheckInvExrate(jobno, strTranType, branchid, txtcurr.Text.ToUpper()).ToString();
                           if (txtex.Text == "0")
                           {
                               txtex.Text = INVOICEobj.GetExRate(txtcurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(dtime)), "R").ToString();
                           }
                       }else
                       {
                           txtex.Text = INVOICEobj.GetExRate(txtcurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(dtime)), "R").ToString();
                           cmbbase.Focus();
                       }
                   }
                   if (txtex.Text == "0")
                   {
                           ScriptManager.RegisterStartupScript(txtcurr, typeof(System.Web.UI.WebControls.TextBox), "logix", "alertify.alert('Ex. Rate Not Available');", true);
                           txtrate.Focus();
                           txtrate.Text = "";
                           txtex.Text = "";
                           return;
                   }
                   if (cmbbase.SelectedIndex != 0 && txtcharge.Text != "" && txtcurr.Text != "" && txtrate.Text != "")
                   {
                       string strbase = cmbbase.Text;
                       famount = CheckBase(strbase, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text));
                       txtamount.Text = famount.ToString();
                       txtamount.Text = Convert.ToDecimal(txtamount.Text).ToString("0.00");
                       btnadd.Enabled = true;
                       btnadd.ForeColor = System.Drawing.Color.White;
                   }

               }
               UserRights();
             }
             catch (Exception ex)
               {
                   string message = ex.Message.ToString();
                   ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
               }

           }*/

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            try
            {
                useit();

                //if (lbl_Header.Text == "Proforma Invoice")
                //{
                ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                if (bolcuststat == true)
                {
                    bolcuststat = false;
                    return;
                }
                //}

                ProINVobj.InsertProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedValue.ToString(), Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedValue.ToString(), strTranType, type, "Y", Convert.ToDouble(hdnUnit.Value));
                grdfill();
                this.PopUpService.Hide();
                chargetxtclear();
                UserRights();
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
                useit();
                ProINVobj.InsertProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedValue.ToString(), Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedValue.ToString(), strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));
                grdfill();
                this.PopUpService.Hide();
                chargetxtclear();
                UserRights();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + ex.Message.ToString() + " " + trace.GetFrame(0).GetFileLineNumber() + "');", true);
            }

        }

        protected void txtcurr_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranTypenew"].ToString();
                int currid = chargeobj.GetCurrID(txtcurr.Text.Trim().ToUpper());
                if (currid != 0)
                {
                    if (txtcharge.Text != "" && txtcurr.Text != "")
                    {
                        if (txtcurr.Text.ToUpper() != "INR")
                        {
                            txtex.Text = INVOICEobj.GetCheckInvExrate(Convert.ToInt32(txtjobno.Value), str_TranType, int_branchid, txtcurr.Text).ToString();
                            if (txtex.Text == "0")
                            {
                                txtex.Text = INVOICEobj.GetExRate(txtcurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();

                                txtrate.Focus();
                                txtrate.Text = "";
                                //txtex .Text="";
                                return;
                            }
                            //else
                            //{

                            //    txtex.Text = INVOICEobj.GetExRate(txtcurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), "R").ToString();       
                            //}

                            if (txtex.Text == "0")
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Ex. Rate Not Available .", true);
                                txtex.Focus();
                                txtex.Text = "";
                                return;
                            }

                        }
                        else
                        {

                            txtex.Text = INVOICEobj.GetExRate(txtcurr.Text.ToUpper(), Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                            txtex.Focus();
                        }

                    }
                    //txtrate.Focus();    
                }
                else
                {
                    txtcurr.Text = "";
                    txtcurr.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Currency');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void grd_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            grdfill();
        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            useit();
            //ProINVobj.InsertProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedItem .Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.Text, strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));
            if (ViewState["obj_dt_head"] != null)
            {
                obj_dt_head = ViewState["obj_dt_head"] as DataTable;
                txtref.Text = obj_dt_head.Rows[0][0].ToString();
                txtremarks.Text = obj_dt_head.Rows[0][7].ToString();
                billtype = Convert.ToChar(obj_dt_head.Rows[0][9].ToString());
                voudate = Convert.ToDateTime(obj_dt_head.Rows[0][1].ToString());
                dtdate.Text = Convert.ToDateTime(voudate).ToString();
                dtdate.Text = Utility.fn_ConvertDate(dtdate.Text);
                bill = obj_da_inv.GetBillType(billtype);
                cmbbill.Items.Clear();
                cmbbill.Items.Add("");
                cmbbill.Items.Add("Cash/Cheque");
                cmbbill.Items.Add("Credit");
                cmbbill.Items.Add("Internal");

                if (Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
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


                //bill = Convert.ToInt32(billtype);
                //cmbbill.SelectedIndex = bill;
                DataTable obj_dt_info = new DataTable();
                //obj_dt_info = obj_da_head.GetProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), int_branchid, hf_strtype.Value);

                //if(obj_dt_info.Rows.Count > 0)
                //{
                //    DataRow dr_temp = obj_dt_info.NewRow();
                //    dr_temp["charge"] = "";
                //    dr_temp["curr"] = "";
                //    dr_temp["rate"] = "";
                //    dr_temp["exRate"] = "";
                //    dr_temp["base"] = "Total";
                //    dr_temp["amount"] = obj_dt_info.Compute("sum(amount)", "");
                //    dr_temp["chargeid"] = "";
                //    obj_dt_info.Rows.Add(dr_temp);

                //    grd.DataSource = obj_dt_info;
                //    grd.DataBind();
                //}

                //grdfill();
                btnsave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn btn-update1";
                btnadd.Enabled = true;
                btnadd.ForeColor = System.Drawing.Color.White;
            }
            this.popupconfirmnew.Hide();
            grdfill();

        }

        //protected void bgyhtdf_Click(object sender, EventArgs e)
        //{
        //    ModelPOPForKeyPerson.Show();
        //}


        protected void txtrate_TextChanged(object sender, EventArgs e)
        {


            if (txtref.Text == "")
            {
                return;
            }
            else
            {
                if (txtcharge.Text != "" && txtcurr.Text != "" && txtrate.Text != "" && cmbbase.SelectedValue != "")
                {
                    cmbbase_SelectedIndexChanged(sender, e);

                }
            }



        }

        protected void txtex_TextChanged(object sender, EventArgs e)
        {
            DataAccess.UserPermission userobj = new DataAccess.UserPermission();
            string script = "";
            if (txtref.Text == "")
            {
                return;
            }
            if (txtex.Text != "")
            {
                if (lbl_Header.Text == "Profoma Invoice")
                {
                    Dt = userobj.GetBtnPermission(Convert.ToInt32(Session["LoginEmpId"]), branchid, 287);
                    if (Dt.Rows.Count > 0)
                    {
                        currexrate = INVOICEobj.GetCheckInvExrate(Convert.ToInt32(txtjobno.Value), strTranType, branchid, txtcurr.Text);
                        script = "Less than PA Exrate Not Allowed";
                        if (currexrate == 0)
                        {
                            currexrate = INVOICEobj.GetExRate(txtcurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), hd_exrate.Value, Convert.ToInt32(Session["LoginDivisionId"]));
                            script = "Less than Current Exrate Not Allowed";
                        }

                        if (Convert.ToDouble(txtex.Text) < currexrate)
                        {
                            txtex.Text = INVOICEobj.GetExRate(txtcurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), hd_exrate.Value, Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                            txtex.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + script + "');", true);

                            return;
                        }

                    }
                    else
                    {
                        currexrate = INVOICEobj.GetExRate(txtcurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), hd_exrate.Value, Convert.ToInt32(Session["LoginDivisionId"]));
                        if (Convert.ToDouble(txtex.Text) < currexrate)
                        {
                            txtex.Text = INVOICEobj.GetExRate(txtcurr.Text, Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), hd_exrate.Value, Convert.ToInt32(Session["LoginDivisionId"])).ToString();
                            txtex.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Less than Current Exrate Not Allowed');", true);
                            return;
                        }
                    }
                }
            }
            cmbbase_SelectedIndexChanged(sender, e);
        }

        protected void txtsupplyto_TextChanged(object sender, EventArgs e)
        {
            try
            {



                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranTypenew"].ToString();
                string citysupplyid;
                int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                if (txtsupplyto.Text != "")
                {
                    int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                    txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                    DataTable dt_list = new DataTable();


                    if (int_custid != 0)
                    {
                        //if (lbl_Header.Text != "Profoma Credit Note - Operations")
                        //{


                        dt_list = customerobj.GetIndianCustomergst(int_custid);
                        if (dt_list.Rows.Count > 0)
                        {
                            if ((string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) && string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString())) && (dt_list.Rows[0]["UnRegistered"].ToString() == "N" || string.IsNullOrEmpty(dt_list.Rows[0]["UnRegistered"].ToString())))
                            {
                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    txtsupplytoAddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                }
                                else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                {
                                    txtsupplytoAddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                }
                                else if (dt_list.Rows[0]["UnRegistered"].ToString() == "N" && dt_list.Rows[0]["uinno"].ToString() == "" && dt_list.Rows[0]["gstin"].ToString() == "")
                                {
                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  OR  Select UnRegistered  Master Customer');", true);
                                }


                                //ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            }
                            else
                            {
                                txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            return;
                        }

                        /*  dt_list = customerobj.GetIndianCustomergst(int_custid);
                          if (dt_list.Rows.Count > 0)
                          {
                              if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                              {
                                  if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                  {
                                      txtsupplytoAddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                      ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                  }
                                  else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                  {
                                      txtsupplytoAddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                      ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                  }


                                  ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                              }
                              else
                              {
                                  txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                              }
                          }
                          else
                          {
                              ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                              return;
                          }*/

                        //}
                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alertify.alert('Select Correct Customer Name');", true);
                        txtsupplyto.Text = "";
                        txtsupplyto.Focus();
                        return;
                    }


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }



    }

}