using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Globalization;
using System.Drawing;



namespace logix.FAForms
{
    public partial class PerformaOsVouchers_Afterjobclose : System.Web.UI.Page
    {
        DateTime GST_date;
        DateTime get_date;
        int jobno = 0;
        int chargename, cbase;
        double amt = 0, amt1 = 0;
        string t;
        string chk = "";
        //string str_booking = "";
        DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
        Boolean bolcuststat;
        DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.Masters.MasterCustomer CustomerObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.JobInfo FEJobObj = new DataAccess.ForwardingExports.JobInfo();
        DataAccess.ForwardingImports.JobInfo FIJobObj = new DataAccess.ForwardingImports.JobInfo();
        DataAccess.ForwardingExports.BLDetails FEBLObj = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.AirImportExports.AIEJobInfo AIEJobObj = new DataAccess.AirImportExports.AIEJobInfo();
        DataAccess.AirImportExports.AIEBLDetails AEBLObj = new DataAccess.AirImportExports.AIEBLDetails();
        DataTable obj_dt = new DataTable();
        DataAccess.Accounts.DCAdvise DebitObj = new DataAccess.Accounts.DCAdvise();
        DataTable DtBLNO = new DataTable();
        DataAccess.Accounts.OSDNCN OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        string famount, strcharge, strbase;
        string strTranType, type, extype, mblno, blno;
        Double douvolume, amount, volume, wt;
        // string curr;
        DataTable dtsupply = new DataTable();
        DataAccess.Masters.MasterCustomer obj_da_Customer = new DataAccess.Masters.MasterCustomer();
        DateTime etd;
        string str_BL = "";
        DataAccess.ForwardingImports.BLDetails obj_da_FIBL = new DataAccess.ForwardingImports.BLDetails();
        int i, j, fd, jobtype, sizecount, vouno, intsalesperson;
        int divisionid, branchid, vouyear, intagent;
        //  bool blrr;
        DataTable DtNew = new DataTable();
        int index, cnno;
        DataTable Dt = new DataTable();
        DataTable Dt1 = new DataTable();
        //   int num = 0;
        double damt, camt;
        DataSet dtDeelete = new DataSet();
        // double debittotal = 0, credittotal = 0, total = 0;
        DateTime Dtdate, jobdate, voudate;
        DataTable dt = new DataTable();
        string str_Uiid = "", str_FornName, damount, camount, strblno, activity;
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.Invoice INVOICEobj = new DataAccess.Accounts.Invoice();
        DataAccess.Marketing.Booking bookingobj = new DataAccess.Marketing.Booking();
        DataTable DtConDetails = new DataTable();
        DataTable DtCon = new DataTable();
        DataTable dtOSDN = new DataTable();
        DataTable dtOSCN = new DataTable();
        DataSet DtVal = new DataSet();
        DataTable dtOSDNPro = new DataTable();
        DataTable dtOSCNPro = new DataTable();

        double Toatlnew = 0;
        string str_sp = "", str_sp1 = "";
        string str_sf = "", str_sf1 = "";
        string str_Script = ""; string str_Script1 = "", str_Script2 = "";
        string str_RptName = ""; string str_RptName1 = "";
        //string str_frmname1 = "";
        //string str_frmname = "";

        string str_frmname = "", strchgtruck, strchgpallet;
        DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();



        DataTable dtnew = new DataTable();
        DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();


        Double currexrate;

        DateTime Dtdatenew;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);


            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnAdd);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btnback);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtJobno);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtJobno);
            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }

            GST_date = Convert.ToDateTime(Session["hid_gstdate"].ToString());
            if (ddlTypes.SelectedValue == "5")
            {
                txtVendorRefnodate.Enabled = false;
            }
            else
            {
                txtVendorRefnodate.Enabled = true;
            }
            if (ddl_product.SelectedValue == "FE")
            {
                Session["StrTranTypeO"] = "OE";
            }
            else if (ddl_product.SelectedValue == "FI")
            {
                Session["StrTranTypeO"] = "OI";
            }
            else
            {
                Session["StrTranTypeO"] = ddl_product.SelectedValue;
            }
            if (!IsPostBack)
            {
                grd_prodetails.DataSource = Utility.Fn_GetEmptyDataTable();
                grd_prodetails.DataBind();
                Grd_Details.DataSource = Utility.Fn_GetEmptyDataTable();
                Grd_Details.DataBind();
                txtJobno.Focus();
                txtyear.Text = Convert.ToInt32(Session["Vouyear"]).ToString();
                vouyear = Convert.ToInt32(Session["Vouyear"]);
                grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                grdcredit.DataBind();
                grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                grddebit.DataBind();
                btnback.Text = "Cancel";
               // Data_Bind();
                txtJobno.Focus();
                btnprint.Enabled = true;
                chk_GstApp.Checked = true;
                // chk_GstApp.Enabled = true;
                txtexrate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Exrate')");
                txtrate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                if (ddl_product.SelectedValue == "FE")
                {
                    headerlable1.InnerText = "OceanExports";
                }
                else if (ddl_product.SelectedValue== "FI")
                {
                    headerlable1.InnerText = "OceanImports";
                }
                else if (ddl_product.SelectedValue  == "AE")
                {
                    headerlable1.InnerText = "AirExports";
                }
                else if (ddl_product.SelectedValue  == "AI")
                {
                    headerlable1.InnerText = "AirImports";
                }
                else if (ddl_product.SelectedValue  == "CH")
                {
                    headerlable1.InnerText = "CHA";
                }

                if (Request.QueryString.ToString().Contains("app3"))
                {
                    ddlTypes.SelectedValue = "5";
                    ddlTypes_SelectedIndexChanged(sender, e);
                    txtJobno.Text = Request.QueryString["jobno"].ToString();
                    hf_branchid.Value = Session["LoginBranchid"].ToString();
                    hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                    txtJobno_TextChanged1(sender, e);
                }
                if (Request.QueryString.ToString().Contains("appFI3"))
                {
                    ddlTypes.SelectedValue = "5";
                    txtJobno.Text = Request.QueryString["jobno"].ToString();
                    ddlTypes_SelectedIndexChanged(sender, e);
                    hf_branchid.Value = Session["LoginBranchid"].ToString();
                    hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                    txtJobno_TextChanged1(sender, e);
                }
                if (Request.QueryString.ToString().Contains("appAE3"))
                {
                    ddlTypes.SelectedValue = "5";
                    txtJobno.Text = Request.QueryString["jobno"].ToString();
                    ddlTypes_SelectedIndexChanged(sender, e);
                    hf_branchid.Value = Session["LoginBranchid"].ToString();
                    hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                    txtJobno_TextChanged1(sender, e);
                }
                if (Request.QueryString.ToString().Contains("appAI3"))
                {
                    ddlTypes.SelectedValue = "5"; 
                    txtJobno.Text = Request.QueryString["jobno"].ToString();
                    ddlTypes_SelectedIndexChanged(sender, e);
                    hf_branchid.Value = Session["LoginBranchid"].ToString();
                    hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                    txtJobno_TextChanged1(sender, e);
                }
                if (Request.QueryString.ToString().Contains("jobnonew1"))
                {
                    txtJobno.Text = Request.QueryString["jobnonew1"].ToString();
                    hf_branchid.Value = Session["LoginBranchid"].ToString();
                    hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                    txtJobno_TextChanged1(sender, e);
                }
                if (ddl_product.SelectedValue == "FE")
                {
                    Session["StrTranTypeO"] = "OE";
                }
                else if (ddl_product.SelectedValue == "FI")
                {
                    Session["StrTranTypeO"] = "OI";
                }
                else
                {
                    Session["StrTranTypeO"] = ddl_product.SelectedValue;
                }
                if (Request.QueryString.ToString().Contains("voutype"))
                {
                    ddlTypes.SelectedValue = Request.QueryString["voutype"].ToString();
                    ddlTypes_SelectedIndexChanged(sender, e);
                    txtdcn.Text = Request.QueryString["1refno"].ToString();
                    hf_branchid.Value = Session["LoginBranchid"].ToString();
                    //txtblno.Text = Request.QueryString["mblno"].ToString();
                    txtdcn_TextChanged(sender, e);
                    //chkmbl.Checked = true;
                    //chkmbl_CheckedChanged(sender, e);
                    //txtblno_TextChanged(sender, e);
                }
                if (Request.QueryString.ToString().Contains("rptvtype"))
                {
                    ddlTypes.SelectedValue = Request.QueryString["rptvtype"].ToString();
                    ddlTypes_SelectedIndexChanged(sender, e);
                    txtdcn.Text = Request.QueryString["rptrefno"].ToString();
                    hf_branchid.Value = Session["LoginBranchid"].ToString();

                    txtdcn_TextChanged(sender, e);
                    btnprint_Click(sender, e);
                    Response.Redirect("../Reportasp/OverseasVouchersrpt.aspx?" + Session["OSstring"].ToString());

                    //chkmbl.Checked = true;
                    //chkmbl_CheckedChanged(sender, e);
                    //txtblno_TextChanged(sender, e);
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
            hf_branchid.Value = Session["LoginBranchid"].ToString();
            hf_divisionid.Value = Session["LoginDivisionId"].ToString();
            btnprint.Enabled = true;
            btnprint.ForeColor = System.Drawing.Color.White;
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


        public void Data_Bind()
        {
            strTranType = ddl_product.SelectedValue;
           // strTranType = ddl_product.SelectedValue;
            if (strTranType == "FE" || strTranType == "FI")
            {
                cmbbase.Items.Add("");
                cmbbase.Items.Add("BL");
                cmbbase.Items.Add("CBM");
                cmbbase.Items.Add("MT");
                cmbbase.Items.Add("W/M");
                Dt = INVOICEobj.BaseFill();
                for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    cmbbase.Items.Add(Dt.Rows[i]["conttype"].ToString());
                }

            }
            else if (strTranType == "AE" || strTranType == "AI")
            {
                cmbbase.Items.Add("");
                cmbbase.Items.Add("HAWB");
                cmbbase.Items.Add("KGS");
                cmbbase.Items.Add("PERTRUCK");
                cmbbase.Items.Add("COTTON/PALLET");

                //cmbbase.Items.Add("FLAT RATE");
                //cmbbase.Items.Add("PER KG");
            }
            else if (strTranType == "CH")
            {
                cmbbase.Items.Add("");
                cmbbase.Items.Add("DOC");
                cmbbase.Items.Add("Kgs");
                cmbbase.Items.Add("Volume");


                //cmbbase.Items.Add("FLAT RATE");
                //cmbbase.Items.Add("PER KG");
            }

            else
            {
                cmbbase.Items.Add("");
                cmbbase.Items.Add("DOC");
                cmbbase.Items.Add("Kgs");
            }
        }

        protected void UserRights()
        {
            try
            {
                if (Request.QueryString.ToString().Contains("voutype"))
                {
                }
                else
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
                        btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


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
        public static List<string> Getcharges(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeChargesName(prefix.Trim().ToUpper());
            List_Result = Utility.Fn_TableToList(dtCharge, "chargename", "chargeid");
            return List_Result;

        }

        [WebMethod]
        public static List<string> GetLikeCurrency(string prefix)
        {
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCharges obj_da_charge = new DataAccess.Masters.MasterCharges();
            List<string> charge = new List<string>();
            obj_dt = obj_da_charge.GetLikeCurrency(prefix.Trim().ToUpper());
            charge = Utility.Fn_DatatableToList_string(obj_dt, "currency", "currency");
            return charge;
        }

        protected void txtrate_TextChanged(object sender, EventArgs e)
        {
            if (txtrate.Text != "" && txtcharge.Text != "" && txtcurr.Text != "")
            {
                if (txtrate.Text.Trim() == "0")
                {
                    ScriptManager.RegisterStartupScript(btnprint, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Rate should not be Zero');", true);
                    txtrate.Text = "";
                    txtrate.Focus();
                    return;
                }
                famount = CheckBase(cmbbase.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text)).ToString();
                txtamount.Text = Convert.ToDecimal(famount).ToString("#,0.00");
                cmbbase.Focus();
                if (cmbbase.Text != "" && txtcurr.Text != "" && txtcharge.Text != "" && txtrate.Text != "")
                {
                    famount = CheckBase(cmbbase.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text)).ToString();
                    txtamount.Text = Convert.ToDecimal(famount).ToString("#,0.00");
                    btnprint.Focus();
                    UserRights();
                }
            }
        }

        protected void txtcharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

                int chargeid = chargeobj.GetChargeid(txtcharge.Text.Trim().ToUpper());
                if (chargeid != 0 && hdnChargid.Value != "0")
                {
                    //txtcurr.Focus();
                    txtcurr.Text = "USD";
                    txtcurr_TextChanged(sender, e);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Charges');", true);
                    txtcharge.Text = "";
                    txtcharge.Focus();
                    //blrr = true;
                    return;

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void cmbbase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbase.Text != "" && txtcurr.Text != "" && txtcharge.Text != "" && txtrate.Text != "")
            {
                famount = CheckBase(cmbbase.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text)).ToString();
                txtamount.Text = Convert.ToDecimal(famount).ToString("#,0.00");
                btnprint.Focus();
                UserRights();
            }
            if (cmbbase.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnprint, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Correct Base');", true);
                cmbbase.Focus();
                //blrr = true;
                return;
            }
        }

        /* public double CheckBase(string strbase, double rate, double exrate)
         {
             strTranType = ddl_product.SelectedValue;
             DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));
             if (DtBLNO.Rows.Count > 0)
             {
                 mblno = DtBLNO.Rows[0][0].ToString();
             }
             if (strbase == "BL" || strbase == "HWBL" || strbase == "DOC")
             {
                 if (cmbbl.Text == mblno)
                 {
                     fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                 }
                 else
                 {
                     fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                 }
                 douvolume = 1;
                 amount = rate * exrate;
                 //---------------------------------------------

             }
             else if (strbase == "CBM" || strbase == "MT")
             {
                 if (strbase == "CBM")
                 {
                     if (strTranType == "FE")
                     {
                         if (cmbbl.SelectedItem.ToString() == mblno)
                         {
                             volume = INVOICEobj.GetSumofVolume(txtJobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                             douvolume = volume;
                             fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                             amount = rate * exrate * volume;
                         }
                         else
                         {
                             volume = INVOICEobj.GetVolume(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                             fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                             douvolume = volume;
                             amount = rate * exrate * volume;
                         }
                     }
                     else
                     {
                         if (cmbbl.SelectedItem.ToString() == mblno)
                         {
                             volume = INVOICEobj.GetSumofVolume(txtJobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                             if (volume < 1)
                             {
                                 amount = rate * exrate * 1;
                                 douvolume = 1;
                             }
                             else
                             {
                                 amount = rate * exrate * volume;
                                 douvolume = volume;
                             }
                             fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                         }
                         else
                         {
                             volume = INVOICEobj.GetVolume(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                             if (volume < 1)
                             {
                                 amount = rate * exrate * 1;
                                 douvolume = 1;
                             }
                             else
                             {
                                 amount = rate * exrate * volume;
                                 douvolume = volume;
                             }
                             fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                         }
                     }
                 }
                 else
                 {
                     if (strbase == "MT")
                     {
                         if (strTranType == "FE" || strTranType == "FI")
                         {
                             if (cmbbl.Text == mblno)
                             {
                                 wt = INVOICEobj.GetSumofWeight(txtJobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                 amount = rate * exrate * (wt / 1000);
                                 douvolume = wt;
                                 fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                             }
                             else
                             {
                                 wt = INVOICEobj.GetWeight(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                 amount = rate * exrate * (wt / 1000);
                                 douvolume = wt;
                                 fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                             }
                         }

                     }
                 }

             }
             //---------------------------------------------------------------------------------------------------------
             else if (strbase == "Kgs" || strbase == "KGS")
             {
                 if (strTranType == "AE" || strTranType == "AI")
                 {
                     if (cmbbl.Text == mblno)
                     {
                         wt = INVOICEobj.GetSumofChargeWght(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                         amount = rate * exrate * wt;
                         douvolume = wt;
                         fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                     }
                     else
                     {
                         wt = INVOICEobj.GetChargeWeight(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                         amount = rate * exrate * wt;
                         douvolume = wt;
                         fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                     }

                 }
                 else
                 {
                     wt = INVOICEobj.GetGrossWeight(cmbbl.Text, Convert.ToInt32(Session["LoginBranchid"]));
                     amount = rate * exrate * wt;
                     douvolume = wt;
                 }
             }
             else if (strbase == "SI")
             {
                 DataAccess.Accounts.Invoice objinv = new DataAccess.Accounts.Invoice();
                 DataTable dtn = new DataTable();
                 dtn = objinv.CheckIPDCWBLShipperinvoiceget(cmbbl.SelectedItem.Text, ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));
                 int shiperinv = dtn.Rows.Count;
                 amount = rate * exrate * Convert.ToInt32(shiperinv);
                 douvolume = shiperinv;
             }
             else if (strbase == "PKG")
             {
                 //DataAccess.Accounts.Invoice objinv = new DataAccess.Accounts.Invoice();
                 //DataTable dtn = new DataTable();
                 //dtn = objinv.CheckIPDCWBLShipperinvoiceget(cmbbl.SelectedItem.Text, ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));
                 //int shiperinv = dtn.Rows.Count;
                 amount = rate * exrate * Convert.ToInt32(Session["noofpks"]);
                 douvolume = Convert.ToInt32(Session["noofpks"]);
             }

             //---------------------------------------------------------------------------------------------------------

             else
             {
                 DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                 if (DtBLNO.Rows.Count > 0)
                 {
                     mblno = DtBLNO.Rows[0][0].ToString();
                 }
                 if (cmbbl.Text != mblno)
                 {
                     sizecount = INVOICEobj.GetBaseCount(cmbbl.Text, strbase, strTranType, "BL", Convert.ToInt32(Session["LoginBranchid"]));
                     amount = rate * exrate * sizecount;
                     douvolume = sizecount;
                     fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                 }

                 else
                 {
                     sizecount = INVOICEobj.GetBaseCount(txtJobno.Text, strbase, strTranType, "MBL", Convert.ToInt32(Session["LoginBranchid"]));
                     amount = rate * exrate * sizecount;
                     douvolume = sizecount;
                     fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                 }
             }

             hid_douvolume.Value = douvolume.ToString();
             hid_fd.Value = fd.ToString();
             return amount;
         }
         */

        public double CheckBase(string strbase, double rate, double exrate)
        {
            strTranType = ddl_product.SelectedValue;
            double strgrosswght;
            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            if (strbase == "BL" || strbase == "HWBL" || strbase == "DOC" || strbase == "FLAT RATE" || strbase == "HAWB")
            {
                if (cmbbl.Text == mblno)
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
                else
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }
                douvolume = 1;
                amount = rate * exrate;
                //---------------------------------------------

            }
            else if (cmbbase.Text.ToUpper() == "Volume".ToUpper())
            {
                strgrosswght = INVOICEobj.GetVolumeQty(cmbbl.Text, branchid);
                amount = rate * exrate * strgrosswght;
                douvolume = strgrosswght;


            }
            else if (strbase.ToString() == "COTTON/PALLET".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (cmbbl.Text.ToUpper() == mblno)
                    {
                        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        Double strchgpallet1 = INVOICEobj.Getchargepalletmbl(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * Convert.ToDouble(strchgpallet1);
                        douvolume = Convert.ToDouble(strchgpallet);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        //fd = Convert.ToInt32(strchgpallet1);
                        //  hdnUnit.Value = strchgpallet.ToString();
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }
                    else
                    {
                        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgpallet = INVOICEobj.Getchargepallet(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgpallet);
                        douvolume = Convert.ToDouble(strchgpallet);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }
            }

            else if (strbase.ToString() == "PERTRUCK".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (cmbbl.Text.ToUpper() == mblno)
                    {
                        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        double strchgtruck1 = INVOICEobj.Getchargetrucknew(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * Convert.ToDouble(strchgtruck1);
                        douvolume = Convert.ToDouble(strchgtruck1);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }
                    else
                    {
                        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgtruck = INVOICEobj.Getchargetruck(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgtruck);
                        douvolume = Convert.ToDouble(strchgtruck);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }

                }
            }
            else if (strbase == "CBM" || strbase == "MT")
            {
                if (strbase == "CBM")
                {
                    if (strTranType == "FE")
                    {
                        if (cmbbl.SelectedItem.ToString() == mblno)
                        {
                            volume = INVOICEobj.GetSumofVolume(txtJobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            douvolume = volume;
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            amount = rate * exrate * volume;
                        }
                        else
                        {
                            volume = INVOICEobj.GetVolume(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                            douvolume = volume;
                            amount = rate * exrate * volume;
                        }
                    }
                    else
                    {
                        if (cmbbl.SelectedItem.ToString() == mblno)
                        {
                            volume = INVOICEobj.GetSumofVolume(txtJobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            if (volume < 1)
                            {
                                amount = rate * exrate * 1;
                                douvolume = 1;
                            }
                            else
                            {
                                amount = rate * exrate * volume;
                                douvolume = volume;
                            }
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        }
                        else
                        {
                            volume = INVOICEobj.GetVolume(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            if (volume < 1)
                            {
                                amount = rate * exrate * 1;
                                douvolume = 1;
                            }
                            else
                            {
                                amount = rate * exrate * volume;
                                douvolume = volume;
                            }
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                        }
                    }
                }
                else
                {
                    if (strbase == "MT")
                    {
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            if (cmbbl.Text == mblno)
                            {
                                // wt = INVOICEobj.GetSumofWeight(txtJobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                // amount = rate * exrate * (wt / 1000);
                                wt = INVOICEobj.GetSumofWeightnew(txtJobno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            }
                            else
                            {
                                //wt = INVOICEobj.GetWeight(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                //amount = rate * exrate * (wt / 1000);


                                wt = INVOICEobj.GetWeightnew(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                            }
                        }

                    }
                }

            }
            //---------------------------------------------------------------------------------------------------------
            else if (strbase.ToUpper() == "Kgs" || strbase == "PER KG" || strbase.ToString() == "Kgs".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (cmbbl.Text == mblno)
                    {
                        wt = INVOICEobj.GetSumofChargeWght(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                    }
                    else
                    {
                        wt = INVOICEobj.GetChargeWeight(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }
                else
                {
                    wt = INVOICEobj.GetGrossWeight(cmbbl.Text, Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * wt;
                    douvolume = wt;
                }
            }
            else if (cmbbase.Text.ToUpper() == "W/M".ToUpper()) // added on 04Feb2023 // nambi
            {
                Double strvolume, doublevolume, strntweight;

                double cbmAmt = 0;
                double mtAmt = 0;


                strvolume = INVOICEobj.GetVolume(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                cbmAmt = rate * exrate * strvolume;

                strntweight = INVOICEobj.GetWeightnew(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                mtAmt = rate * exrate * (strntweight);

                if (cbmAmt < mtAmt)
                {
                    //FBase = "MT";
                    amount = mtAmt;
                    doublevolume = (strntweight);
                    douvolume = doublevolume;
                    //hdnUnit.Value = doublevolume.ToString();
                }
                else
                {
                    if (strbase.ToUpper() == "W/M")
                    {
                        //FBase = "W/M";
                        amount = cbmAmt;
                        doublevolume = strvolume;
                        douvolume = doublevolume;
                        //hdnUnit.Value = doublevolume.ToString();
                    }
                    else
                    {
                        //FBase = "CBM";
                        amount = cbmAmt;
                        doublevolume = strvolume;
                        douvolume = doublevolume;
                        //hdnUnit.Value = doublevolume.ToString();
                    }
                }

                //strvolume = INVOICEobj.GetSumofVolume(txtjobno.Value, strTranType, branchid);
                //amount = rate * exrate * strvolume;
                //doublevolume = strvolume;
                //hdnUnit.Value = doublevolume.ToString();
            }

            //---------------------------------------------------------------------------------------------------------

            else
            {
                DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                if (DtBLNO.Rows.Count > 0)
                {
                    mblno = DtBLNO.Rows[0][0].ToString();
                }
                if (cmbbl.Text != mblno)
                {
                    sizecount = INVOICEobj.GetBaseCount(cmbbl.Text, strbase, strTranType, "BL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount;
                    douvolume = sizecount;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }

                else
                {
                    sizecount = INVOICEobj.GetBaseCount(txtJobno.Text, strbase, strTranType, "MBL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount;
                    douvolume = sizecount;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
            }

            hid_douvolume.Value = douvolume.ToString();
            hid_fd.Value = fd.ToString();
            return amount;
        }

        protected void txtcurr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                int currid = chargeobj.GetCurrID(txtcurr.Text.Trim().ToUpper());
                if (currid != 0 && hdncurrid.Value != "0")
                {
                    Dtdate = Convert.ToDateTime(logobj.GetDate().ToShortDateString());
                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {
                        extype = "R";
                    }
                    else
                    {
                        extype = "C";
                    }
                    if (txtcurr.Text.Trim().ToUpper() == "INR")
                    {
                        ScriptManager.RegisterStartupScript(btnprint, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Currency INR Not Accepted');", true);
                        txtcurr.Text = "";
                        txtcurr.Focus();
                        //blrr = true;
                        return;
                    }
                    if (txtcurr.Text.Trim() != "")
                    {

                        txtcurr.Text = txtcurr.Text.ToUpper();
                        txtexrate.Text = (INVOICEobj.GetOSExRate(txtcurr.Text, Dtdate, extype, Convert.ToInt32(Session["LoginDivisionId"]))).ToString();
                        if (txtexrate.Text == "0" || txtexrate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btnprint, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Ex. Rate Not Available');", true);
                            txtcurr.Text = "";
                            txtexrate.Text = "";
                            txtcurr.Focus();
                            //blrr = true;
                            return;
                        }
                    }
                    else
                    {
                        txtrate.Focus();
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Enter the Valid Currency');", true);
                    txtcurr.Text = "";
                    txtcurr.Focus();
                    //blrr = true;
                    return;

                }


            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }





        public void GrdLoadNew(string refno)
        {


            strTranType = ddl_product.SelectedValue;
            DataTable dtnew = new DataTable();
            double fcamt = 0;
            txttotal.Text = "";
            DataSet ds = new DataSet();
            DataTable dtdc = new DataTable();
            DataTable dtcc = new DataTable();
            double amtnew = 0;
            if (hid_debitDnno.Value != "" && hid_debitDnno.Value != "0")
            {
                dtdc = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), 5, Convert.ToInt32(hid_debitDnno.Value), Convert.ToInt32(hid_intagent.Value));
            }
            else if (hid_creditDnno.Value != "" && hid_creditDnno.Value != "0")
            {
                dtnew = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), 6, Convert.ToInt32(hid_creditDnno.Value), Convert.ToInt32(hid_intagent.Value));
            }


            double amt = 0, amt1 = 1;

            if (dtdc.Rows.Count > 0)
            {
                double Total = 0;
                DataTable dtempty = new DataTable();
                dtempty.Columns.Add("blno", typeof(string));
                dtempty.Columns.Add("chargename", typeof(string));
                dtempty.Columns.Add("curr", typeof(string));
                dtempty.Columns.Add("rate", typeof(string));
                dtempty.Columns.Add("exrate", typeof(string));
                dtempty.Columns.Add("bASe", typeof(string));
                dtempty.Columns.Add("withoutgstAmt", typeof(string));
                dtempty.Columns.Add("stgst", typeof(string));
                dtempty.Columns.Add("amount", typeof(string));
                dtempty.Columns.Add("chargeid", typeof(int));
                dtempty.Columns.Add("GSTCHK", typeof(string));
                dtempty.Columns.Add("provouno", typeof(string));
                dtempty.Columns.Add("vouno", typeof(string));
                dtempty.Columns.Add("vouyear", typeof(string));
                dtempty.Columns.Add("fcamt", typeof(string));
                DataRow dr = dtempty.NewRow();

                if (dtdc.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                    {
                        dr = dtempty.NewRow();
                        dtempty.Rows.Add(dr);
                        dr[0] = dtdc.Rows[i]["blno"].ToString();
                        dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                        dr[2] = dtdc.Rows[i]["curr"].ToString();
                        dr[3] = dtdc.Rows[i]["rate"].ToString();
                        dr[4] = dtdc.Rows[i]["exrate"].ToString();
                        dr[5] = dtdc.Rows[i]["bAse"].ToString();
                        if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                        {
                            amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                            dr[6] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[6] = "0.00";
                        }
                        if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                        {
                            amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                            dr[7] = amt1.ToString("#0.00");
                        }
                        else
                        {
                            dr[7] = "0.00";
                        }
                        if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                        {
                            amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                            dr[8] = amt1.ToString("#0.00");
                        }
                        else
                        {
                            dr[8] = "0.00";
                        }


                        dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                        dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                        dr[11] = dtdc.Rows[i]["provouno"].ToString();
                        if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                        {
                            chk_GstApp.Checked = true;
                            //chk_GstApp.Enabled = false;
                        }
                        dr[12] = dtdc.Rows[i]["dnno"].ToString();
                        dr[13] = dtdc.Rows[i]["vouyear"].ToString();
                        Total = Total + double.Parse(dr[8].ToString());

                        if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                        {
                            dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                            fcamt = fcamt + Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString());
                        }
                        else
                        {
                            fcamt = fcamt + 0;
                        }

                    }
                }
                txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                grddebit.DataSource = dtempty;
                grddebit.DataBind();
            }
            fcamt = 0;

            if (dtnew.Rows.Count > 0)
            {
                double Total = 0;
                DataTable dtempty1 = new DataTable();
                dtempty1.Columns.Add("blno", typeof(string));
                dtempty1.Columns.Add("chargename", typeof(string));
                dtempty1.Columns.Add("curr", typeof(string));
                dtempty1.Columns.Add("rate", typeof(string));
                dtempty1.Columns.Add("exrate", typeof(string));
                dtempty1.Columns.Add("bASe", typeof(string));
                dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                dtempty1.Columns.Add("stgst", typeof(string));
                dtempty1.Columns.Add("amount", typeof(string));
                dtempty1.Columns.Add("chargeid", typeof(int));
                dtempty1.Columns.Add("GSTCHK", typeof(string));
                dtempty1.Columns.Add("provouno", typeof(string));
                dtempty1.Columns.Add("vouno", typeof(string));
                dtempty1.Columns.Add("vouyear", typeof(string));
                dtempty1.Columns.Add("fcamt", typeof(string));
                DataRow dr = dtempty1.NewRow();

                if (dtnew.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                    {
                        dr = dtempty1.NewRow();
                        dtempty1.Rows.Add(dr);
                        dr[0] = dtnew.Rows[i]["blno"].ToString();
                        dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                        dr[2] = dtnew.Rows[i]["curr"].ToString();
                        dr[3] = dtnew.Rows[i]["rate"].ToString();
                        dr[4] = dtnew.Rows[i]["exrate"].ToString();
                        dr[5] = dtnew.Rows[i]["bAse"].ToString();

                        if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                        {
                            amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                            dr[6] = amt.ToString("#0.00");
                        }
                        else
                        {
                            dr[6] = "0.00";
                        }
                        if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                        {
                            amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                            dr[7] = amt1.ToString("#0.00");
                        }
                        else
                        {
                            dr[7] = "0.00";
                        }
                        if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                        {
                            amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                            dr[8] = amt1.ToString("#0.00");
                        }
                        else
                        {
                            dr[8] = "0.00";
                        }
                        dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                        dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();

                        dr[11] = dtnew.Rows[i]["provouno"].ToString();
                        if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                        {
                            chk_GstApp.Checked = true;
                            //chk_GstApp.Enabled = false;
                        }
                        dr[12] = dtnew.Rows[i]["cnno"].ToString();
                        dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                        if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                        {
                            dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                            fcamt = fcamt + Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString());
                        }
                        else
                        {
                            fcamt = fcamt + 0;
                        }
                        Total = Total + double.Parse(dr[8].ToString());
                    }
                }
                txt_FcCramt.Text = fcamt.ToString("#0.00");
                grdcredit.DataSource = dtempty1;
                grdcredit.DataBind();
            }
            //grdcredit.DataSource = dtcc;
            //grdcredit.DataBind();

            //if (ddlDebiteOrCredite.SelectedValue == "DebitAdvise")
            //{
            //    for (i = 0; i < dtdc.Rows.Count - 1; i++)
            //    {
            //        grddebit.Rows[i].Cells[0].Text = dtdc.Rows[i][0].ToString();
            //        grddebit.Rows[i].Cells[1].Text = dtdc.Rows[i][1].ToString();
            //        grddebit.Rows[i].Cells[2].Text = dtdc.Rows[i][2].ToString();
            //        grddebit.Rows[i].Cells[3].Text = dtdc.Rows[i][3].ToString();
            //        grddebit.Rows[i].Cells[4].Text = dtdc.Rows[i][4].ToString();
            //        grddebit.Rows[i].Cells[5].Text = dtdc.Rows[i][5].ToString();
            //        grddebit.Rows[i].Cells[6].Text = dtdc.Rows[i][6].ToString();
            //    }
            //}
            //else
            //{
            //    for (i = 0; i < dtcc.Rows.Count - 1; i++)
            //    {
            //        grdcredit.Rows[i].Cells[0].Text = Dt.Rows[i][0].ToString();
            //        grdcredit.Rows[i].Cells[1].Text = Dt.Rows[i][1].ToString();
            //        grdcredit.Rows[i].Cells[2].Text = Dt.Rows[i][2].ToString();
            //        grdcredit.Rows[i].Cells[3].Text = Dt.Rows[i][3].ToString();
            //        grdcredit.Rows[i].Cells[4].Text = Dt.Rows[i][4].ToString();
            //        grdcredit.Rows[i].Cells[5].Text = Dt.Rows[i][5].ToString();
            //        grdcredit.Rows[i].Cells[6].Text = Dt.Rows[i][6].ToString();
            //    }
            //}
            double tot = 0, tot1 = 0;
            for (i = 0; i <= grddebit.Rows.Count - 1; i++)
            {
                tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                tot = tot + tot1;
            }
            txtDebit.Text = tot.ToString("#,0.00");
            for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
            {
                amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                amtnew = amtnew + amt1;
            }

            txtCredit.Text = amtnew.ToString("#,0.00");

            if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
            {
                Toatlnew = tot - amtnew;
                if (Toatlnew < 0)
                {
                    lblGross.Text = "Payable to Agent:";
                    txttotal.Text = Toatlnew.ToString("#0.00");
                }
                else
                {
                    lblGross.Text = "Receivable from Agent:";
                    txttotal.Text = Toatlnew.ToString("#0.00");

                }
            }
            else
            {
                if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                {
                    txttotal.Text = txtCredit.Text;
                }
                else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                {
                    txttotal.Text = txtDebit.Text;
                }
            }


        }










        public void GrdLoad(string voutype)
        {


            //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            //grddebit.DataBind();

            //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            //grdcredit.DataBind();
            //if (ddlDebiteOrCredite.SelectedValue == "DebitAdvise")
            //{
            //    Dt = DAdvise.GetDCChargeFornew(cmbbl.Text, strTranType, "DebitAdvise", Convert.ToInt32(Session["LoginBranchid"]));
            //    grddebit.DataSource = Dt;
            //    grddebit.DataBind();
            //}
            //else
            //{
            //    Dt = DAdvise.GetDCChargeFornew(cmbbl.Text, strTranType, "CreditAdvise", Convert.ToInt32(Session["LoginBranchid"]));
            //    grdcredit.DataSource = Dt;
            //    grdcredit.DataBind();
            //}
            double fcamt = 0;
            strTranType = ddl_product.SelectedValue;
            txttotal.Text = "";
            DataSet ds = new DataSet();
            DataTable dtdc = new DataTable();
            DataTable dtcc = new DataTable();
            double amtnew = 0;

            if (ddlTypes.SelectedValue == "0")
            {
                if (txtdcn.Text == "")
                {
                    if (hid_MoreOne.Value == "Yes")
                    {

                        ds = OSDNCN.RptOSDNCNProForGrdOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), hid_MoreOne.Value);
                    }
                    else
                    {
                        ds = OSDNCN.RptOSDNCNProForGrdOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value), "NO");
                    }
                }
                else
                {

                    ds = OSDNCN.RptOSDNCNProFromJobNoForGridOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value));


                }
                if (ds.Tables.Count > 0)
                {

                    double amt = 0, amt1 = 1;
                    dtdc = ds.Tables[1];
                    if (dtdc.Rows.Count > 0)
                    {
                        double Total = 0;
                        DataTable dtempty = new DataTable();
                        dtempty.Columns.Add("blno", typeof(string));
                        dtempty.Columns.Add("chargename", typeof(string));
                        dtempty.Columns.Add("curr", typeof(string));
                        dtempty.Columns.Add("rate", typeof(string));
                        dtempty.Columns.Add("exrate", typeof(string));
                        dtempty.Columns.Add("bASe", typeof(string));
                        dtempty.Columns.Add("withoutgstAmt", typeof(string));
                        dtempty.Columns.Add("stgst", typeof(string));
                        dtempty.Columns.Add("amount", typeof(string));
                        dtempty.Columns.Add("chargeid", typeof(int));
                        dtempty.Columns.Add("GSTCHK", typeof(string));
                        dtempty.Columns.Add("provouno", typeof(string));
                        dtempty.Columns.Add("vouno", typeof(string));
                        dtempty.Columns.Add("vouyear", typeof(string));
                        dtempty.Columns.Add("fcamt", typeof(string));
                        DataRow dr = dtempty.NewRow();

                        if (dtdc.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                            {
                                dr = dtempty.NewRow();
                                dtempty.Rows.Add(dr);
                                dr[0] = dtdc.Rows[i]["blno"].ToString();
                                dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                                dr[2] = dtdc.Rows[i]["curr"].ToString();
                                dr[3] = dtdc.Rows[i]["rate"].ToString();
                                dr[4] = dtdc.Rows[i]["exrate"].ToString();
                                dr[5] = dtdc.Rows[i]["bAse"].ToString();
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                                {
                                    amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                                    dr[6] = amt.ToString("#0.00");
                                }
                                else
                                {
                                    dr[6] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                                    dr[7] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[7] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                                    dr[8] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[8] = "0.00";
                                }


                                dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                                dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                                dr[11] = dtdc.Rows[i]["provouno"].ToString();
                                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                {
                                    chk_GstApp.Checked = true;
                                    //chk_GstApp.Enabled = false;
                                }
                                dr[12] = dtdc.Rows[i]["vouno"].ToString();
                                dr[13] = dtdc.Rows[i]["vouyear"].ToString();
                                Total = Total + double.Parse(dr[8].ToString());

                                if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                                {
                                    dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                                    fcamt = fcamt + Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString());
                                }
                                else
                                {
                                    fcamt = fcamt + 0;
                                }
                            }
                        }
                        txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                        grddebit.DataSource = dtempty;
                        grddebit.DataBind();
                    }

                    DataTable dtnew = new DataTable();
                    dtnew = ds.Tables[2];
                    if (dtnew.Rows.Count > 0)
                    {
                        double Total = 0;
                        DataTable dtempty1 = new DataTable();
                        dtempty1.Columns.Add("blno", typeof(string));
                        dtempty1.Columns.Add("chargename", typeof(string));
                        dtempty1.Columns.Add("curr", typeof(string));
                        dtempty1.Columns.Add("rate", typeof(string));
                        dtempty1.Columns.Add("exrate", typeof(string));
                        dtempty1.Columns.Add("bASe", typeof(string));
                        dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                        dtempty1.Columns.Add("stgst", typeof(string));
                        dtempty1.Columns.Add("amount", typeof(string));
                        dtempty1.Columns.Add("chargeid", typeof(int));
                        dtempty1.Columns.Add("GSTCHK", typeof(string));
                        dtempty1.Columns.Add("provouno", typeof(string));
                        dtempty1.Columns.Add("vouno", typeof(string));
                        dtempty1.Columns.Add("vouyear", typeof(string));
                        dtempty1.Columns.Add("fcamt", typeof(string));
                        DataRow dr = dtempty1.NewRow();

                        if (dtnew.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                            {
                                dr = dtempty1.NewRow();
                                dtempty1.Rows.Add(dr);
                                dr[0] = dtnew.Rows[i]["blno"].ToString();
                                dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                                dr[2] = dtnew.Rows[i]["curr"].ToString();
                                dr[3] = dtnew.Rows[i]["rate"].ToString();
                                dr[4] = dtnew.Rows[i]["exrate"].ToString();
                                dr[5] = dtnew.Rows[i]["bAse"].ToString();

                                if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                                {
                                    amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                                    dr[6] = amt.ToString("#0.00");
                                }
                                else
                                {
                                    dr[6] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                                    dr[7] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[7] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                                    dr[8] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[8] = "0.00";
                                }
                                dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                                dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();

                                dr[11] = dtnew.Rows[i]["provouno"].ToString();
                                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                {
                                    chk_GstApp.Checked = true;
                                    //chk_GstApp.Enabled = false;
                                }
                                dr[12] = dtnew.Rows[i]["vouno"].ToString();
                                dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                                Total = Total + double.Parse(dr[8].ToString());
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                                {
                                    dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                                    fcamt = fcamt + Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString());
                                }
                                else
                                {
                                    fcamt = fcamt + 0;
                                }
                            }
                        }
                        txt_FcCramt.Text = fcamt.ToString("#0.00");
                        grdcredit.DataSource = dtempty1;
                        grdcredit.DataBind();
                    }

                }

                double tot = 0, tot1 = 0;
                for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                {
                    tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                    tot = tot + tot1;
                }
                txtDebit.Text = tot.ToString("#,0.00");
                for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                {
                    amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                    amtnew = amtnew + amt1;
                }

                txtCredit.Text = amtnew.ToString("#,0.00");

                if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                {
                    Toatlnew = tot - amtnew;
                    if (Toatlnew < 0)
                    {
                        lblGross.Text = "Payable to Agent:";
                        txttotal.Text = Toatlnew.ToString("#0.00");
                    }
                    else
                    {
                        lblGross.Text = "Receivable from Agent:";
                        txttotal.Text = Toatlnew.ToString("#0.00");

                    }
                }
                else
                {
                    if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                    {
                        txttotal.Text = txtCredit.Text;
                    }
                    else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                    {
                        txttotal.Text = txtDebit.Text;
                    }
                }
            }
            else
            {
                if (ddlTypes.SelectedValue == "5")
                {
                    if (txtdcn.Text == "")
                    {
                        dtdc = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), 0, Convert.ToInt32(hid_intagent.Value));

                    }
                    else
                    {

                        dtdc = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txtdcn.Text), Convert.ToInt32(hid_intagent.Value));
                    }




                    if (dtdc.Rows.Count > 0)
                    {
                        double Total = 0;
                        DataTable dtempty = new DataTable();
                        dtempty.Columns.Add("blno", typeof(string));
                        dtempty.Columns.Add("chargename", typeof(string));
                        dtempty.Columns.Add("curr", typeof(string));
                        dtempty.Columns.Add("rate", typeof(string));
                        dtempty.Columns.Add("exrate", typeof(string));
                        dtempty.Columns.Add("bASe", typeof(string));
                        dtempty.Columns.Add("withoutgstAmt", typeof(string));
                        dtempty.Columns.Add("stgst", typeof(string));
                        dtempty.Columns.Add("amount", typeof(string));
                        dtempty.Columns.Add("chargeid", typeof(int));
                        dtempty.Columns.Add("GSTCHK", typeof(string));
                        //  dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                        dtempty.Columns.Add("provouno", typeof(string));
                        dtempty.Columns.Add("vouno", typeof(string));
                        dtempty.Columns.Add("vouyear", typeof(string));
                        dtempty.Columns.Add("fcamt", typeof(string));
                        DataRow dr = dtempty.NewRow();

                        if (dtdc.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                            {
                                dr = dtempty.NewRow();
                                dtempty.Rows.Add(dr);
                                dr[0] = dtdc.Rows[i]["blno"].ToString();
                                dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                                dr[2] = dtdc.Rows[i]["curr"].ToString();
                                dr[3] = dtdc.Rows[i]["rate"].ToString();
                                dr[4] = dtdc.Rows[i]["exrate"].ToString();
                                dr[5] = dtdc.Rows[i]["bAse"].ToString();

                                if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                                {
                                    amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                                    dr[6] = amt.ToString("#0.00");
                                }
                                else
                                {
                                    dr[6] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                                    dr[7] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[7] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                                    dr[8] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[8] = "0.00";
                                }
                                dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                                dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                                dr[11] = dtdc.Rows[i]["provouno"].ToString();
                                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                {
                                    chk_GstApp.Checked = true;
                                    //chk_GstApp.Enabled = false;
                                }
                                dr[12] = dtdc.Rows[i]["vouno"].ToString();
                                dr[13] = dtdc.Rows[i]["vouyear"].ToString();
                                Total = Total + double.Parse(dr[8].ToString());
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                                {
                                    dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                                    fcamt = fcamt + Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString());
                                }
                                else
                                {
                                    fcamt = fcamt + 0;
                                }
                            }
                        }
                        txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                        grddebit.DataSource = dtempty;
                        grddebit.DataBind();
                    }


                }
                else
                {
                    DataTable dtnew = new DataTable();
                    if (txtdcn.Text == "")
                    {
                        dtnew = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), 0, Convert.ToInt32(hid_intagent.Value));

                    }
                    else
                    {

                        dtnew = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txtdcn.Text), Convert.ToInt32(hid_intagent.Value));
                    }


                    if (dtnew.Rows.Count > 0)
                    {
                        double Total = 0;
                        DataTable dtempty1 = new DataTable();
                        dtempty1.Columns.Add("blno", typeof(string));
                        dtempty1.Columns.Add("chargename", typeof(string));
                        dtempty1.Columns.Add("curr", typeof(string));
                        dtempty1.Columns.Add("rate", typeof(string));
                        dtempty1.Columns.Add("exrate", typeof(string));
                        dtempty1.Columns.Add("bASe", typeof(string));
                        dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                        dtempty1.Columns.Add("stgst", typeof(string));
                        dtempty1.Columns.Add("amount", typeof(string));
                        dtempty1.Columns.Add("chargeid", typeof(int));
                        dtempty1.Columns.Add("GSTCHK", typeof(string));
                        dtempty1.Columns.Add("provouno", typeof(string));
                        dtempty1.Columns.Add("vouno", typeof(string));
                        dtempty1.Columns.Add("vouyear", typeof(string));
                        dtempty1.Columns.Add("fcamt", typeof(string));
                        DataRow dr = dtempty1.NewRow();

                        if (dtnew.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                            {
                                dr = dtempty1.NewRow();
                                dtempty1.Rows.Add(dr);
                                dr[0] = dtnew.Rows[i]["blno"].ToString();
                                dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                                dr[2] = dtnew.Rows[i]["curr"].ToString();
                                dr[3] = dtnew.Rows[i]["rate"].ToString();
                                dr[4] = dtnew.Rows[i]["exrate"].ToString();
                                dr[5] = dtnew.Rows[i]["bAse"].ToString();

                                if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                                {
                                    amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                                    dr[6] = amt.ToString("#0.00");
                                }
                                else
                                {
                                    dr[6] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                                    dr[7] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[7] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                                    dr[8] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[8] = "0.00";
                                }
                                dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                                dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();

                                dr[11] = dtnew.Rows[i]["provouno"].ToString();
                                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                {
                                    chk_GstApp.Checked = true;
                                    // chk_GstApp.Enabled = false;
                                }
                                dr[12] = dtnew.Rows[i]["vouno"].ToString();
                                dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                                Total = Total + double.Parse(dr[8].ToString());
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                                {
                                    dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                                    fcamt = fcamt + Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString());
                                }
                                else
                                {
                                    fcamt = fcamt + 0;
                                }
                            }
                        }
                        txt_FcCramt.Text = fcamt.ToString("#0.00");
                        grdcredit.DataSource = dtempty1;
                        grdcredit.DataBind();
                    }

                    double tot = 0, tot1 = 0;
                    for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                    {
                        tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                        tot = tot + tot1;
                    }
                    txtDebit.Text = tot.ToString("#,0.00");
                    for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                    {
                        amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                        amtnew = amtnew + amt1;
                    }
                    txtCredit.Text = amtnew.ToString("#,0.00");

                    if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                    {
                        Toatlnew = tot - amtnew;
                        if (Toatlnew < 0)
                        {
                            lblGross.Text = "Payable to Agent:";
                            txttotal.Text = Toatlnew.ToString("#0.00");
                        }
                        else
                        {
                            lblGross.Text = "Receivable from Agent:";
                            txttotal.Text = Toatlnew.ToString("#0.00");

                        }
                    }
                    else
                    {
                        if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                        {
                            txttotal.Text = txtCredit.Text;
                        }
                        else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                        {
                            txttotal.Text = txtDebit.Text;
                        }
                    }



                }
            }


        }
        public void txtchargeclear()
        {
            txtcurr.Text = "";
            txtcharge.Text = "";
            txtexrate.Text = "";
            txtrate.Text = "";
            cmbbase.SelectedIndex = -1;
            txtamount.Text = "";
        }

        /* public void getAEIDebit()
         {
             strTranType = ddl_product.SelectedValue;
             if (ddlDebiteOrCredite.SelectedValue == "DebitAdvise" || ddlDebiteOrCredite.SelectedValue == "CreditAdvise")
             {

                 Dt = DAdvise.GetDCAdviseOSV(Convert.ToInt32(txtJobno.Text), strTranType, ddlDebiteOrCredite.SelectedValue);
                 string t;
                 if (ddlDebiteOrCredite.SelectedValue == "DebitAdvise")
                 {
                     t = "D";
                 }
                 else
                 {
                     t = "C";
                 }
                 if (Dt.Rows.Count > 0)
                 {
                     for (i = 0; i <= Dt.Rows.Count - 1; i++)
                     {
                         blno = Dt.Rows[i][2].ToString();
                         if (strTranType == "AE" || strTranType == "AI")
                         {
                             if (cmbbl.SelectedItem.ToString() == blno)
                             {
                                 txtremarks.Text = DAdvise.GetDCAdviseRemarksOSV(blno, t, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                 if (txtremarks.Text.Trim() == "0")
                                 {
                                     txtremarks.Text = "";
                                 }
                                 // txtchargeclear();
                                 // GrdLoad(ddlDebiteOrCredite.SelectedValue);
                                 break;
                             }
                             else
                             {
                                 //txtchargeclear();
                                 //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                                 //grddebit.DataBind();

                                 //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                                 //grdcredit.DataBind();
                             }
                         }
                     }
                 }
             }

             if (cmbbl.SelectedItem.ToString() == mblno)
             {
                 FGetNoofContAEAI(txtJobno.Text, txtJobno.Text);
             }
             else
             {
                 FGetNoofContAEAI(txtJobno.Text, cmbbl.Text);
             }


          

         }

         */


        public void getAEIDebit()
        {
            strTranType = ddl_product.SelectedValue;
            if (ddlDebiteOrCredite.SelectedValue == "5" || ddlDebiteOrCredite.SelectedValue == "6")
            {

                Dt = DAdvise.GetDCAdviseOSV(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue));
                string t;
                if (ddlDebiteOrCredite.SelectedValue == "5")
                {
                    t = "D";
                }
                else
                {
                    t = "C";
                }
                if (Dt.Rows.Count > 0)
                {
                    for (i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        blno = Dt.Rows[i][2].ToString();
                        if (strTranType == "AE" || strTranType == "AI")
                        {
                            if (cmbbl.SelectedItem.ToString() == blno)
                            {
                                txtremarks.Text = DAdvise.GetDCAdviseRemarksOSV(blno, t, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                if (txtremarks.Text.Trim() == "0")
                                {
                                    txtremarks.Text = "";
                                }
                                // txtchargeclear();
                                // GrdLoad(ddlDebiteOrCredite.SelectedValue);
                                break;
                            }
                            else
                            {
                                //txtchargeclear();
                                //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                                //grddebit.DataBind();

                                //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                                //grdcredit.DataBind();
                            }
                        }
                    }
                }
            }
        }


        public void getCHDebit()
        {
            strTranType = ddl_product.SelectedValue;
            if (ddlDebiteOrCredite.SelectedValue == "5" || ddlDebiteOrCredite.SelectedValue == "6")
            {

                Dt = DAdvise.GetDCAdviseOSV(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue));
                string t;
                if (ddlDebiteOrCredite.SelectedValue == "5")
                {
                    t = "D";
                }
                else
                {
                    t = "C";
                }
                if (Dt.Rows.Count > 0)
                {
                    for (i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        blno = Dt.Rows[i][2].ToString();
                        if (strTranType == "CH")
                        {
                            if (cmbbl.SelectedItem.ToString() == blno)
                            {
                                txtremarks.Text = DAdvise.GetDCAdviseRemarksOSV(blno, t, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                if (txtremarks.Text.Trim() == "0")
                                {
                                    txtremarks.Text = "";
                                }
                                // txtchargeclear();
                                // GrdLoad(ddlDebiteOrCredite.SelectedValue);
                                break;
                            }
                            else
                            {
                                //txtchargeclear();
                                //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                                //grddebit.DataBind();

                                //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                                //grdcredit.DataBind();
                            }
                        }
                    }
                }
            }
        }


        public void checkOSDCN()
        {

            if (txtJobno.Text != "")
            {
                dtOSDN = DAdvise.SelDepCre4OSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), branchid, 5);
                dtOSCN = DAdvise.SelDepCre4OSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), branchid, 6);
                if (dtOSDN.Rows.Count > 0 || dtOSCN.Rows.Count > 0)
                {
                    //btnsave.Enabled = false;
                    // btnsave.ForeColor = System.Drawing.Color.Gray;
                    // btndelete.Enabled = false;
                    //  grd.Enabled = false;
                    //grd.RowDataBound
                    // btndelete.Enabled = false;
                    //btndelete.ForeColor = System.Drawing.Color.Gray;
                }
                else
                {
                    // grd.Enabled = true;
                    //btndelete.Enabled = true;
                    // btndelete.ForeColor = System.Drawing.Color.White;
                }
            }
        }
        public void getFDebit()
        {
            string blno;
            strTranType = ddl_product.SelectedValue;
            // type = Request.QueryString["type"].ToString();
            if (ddlDebiteOrCredite.SelectedValue == "5" || ddlDebiteOrCredite.SelectedValue == "6")
            {
                string t;
                if (ddlDebiteOrCredite.SelectedValue == "5")
                {
                    t = "D";
                }
                else
                {
                    t = "C";
                }
                Dt = DAdvise.GetDCAdviseOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue));
                if (Dt.Rows.Count > 0)
                {
                    for (i = 0; i <= Dt.Rows.Count - 1; i++)
                    {
                        blno = Dt.Rows[i][2].ToString();
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            if (cmbbl.SelectedItem.ToString() == blno)
                            {
                                txtremarks.Text = DAdvise.GetDCAdviseRemarksOSV(blno, t, Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"])).ToString();

                                if (txtremarks.Text.Trim() == "0")
                                {
                                    txtremarks.Text = "";
                                }
                                //txtchargeclear();
                                //GrdLoad(ddlDebiteOrCredite.SelectedValue);
                                //break;
                            }
                            else
                            {
                                //txtchargeclear();
                                //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                                //grdcredit.DataBind();

                                //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                                //grddebit.DataBind();
                            }
                        }
                    }
                }
            }

            if (cmbbl.SelectedItem.ToString() == mblno)
            {
                FGetNoofCont(txtJobno.Text, txtJobno.Text);
            }
            else
            {
                FGetNoofCont(txtJobno.Text, cmbbl.Text);
            }

        }


        public void FGetNoofCont(string jobno, string blno)
        {
            lstcon.Items.Clear();
            float volume, wt;
            strTranType = ddl_product.SelectedValue;
            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(jobno), blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
            if (DtCon.Rows.Count > 0)
            {
                for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                {
                    lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());
                }
            }

            if (cmbbl.SelectedItem.ToString() == mblno)
            {
                DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(jobno), jobno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                {
                    lstcon.Items.Add(DtConDetails.Rows[i][0].ToString());
                }
            }
            else
            {
                DtConDetails = INVOICEobj.GetHBLContainerDtls(blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                {
                    lstcon.Items.Add(DtConDetails.Rows[i][0].ToString());
                }

                volume = INVOICEobj.GetVolume(blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                lstcon.Items.Add(volume + " cbm");
                wt = INVOICEobj.GetWeight(blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                lstcon.Items.Add(wt + " Kgs");
            }




        }


        /*public void FGetNoofContAEAI(string jobno, string blno)
        {
            lstcon.Items.Clear();
            double wt = 0.0, gwt = 0.0, noofpks = 0.0;
            strTranType = ddl_product.SelectedValue;
            DataTable dt_new = new DataTable();
            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            if (cmbbl.SelectedItem.ToString() == mblno)
            {
                //Dt = DAdvise.GetDCAdviseOSV(Convert.ToInt32(txtJobno.Text), strTranType, ddlDebiteOrCredite.SelectedValue);
                //if (Dt.Rows.Count > 0)
                //{
                //    for (i = 0; i <= Dt.Rows.Count - 1; i++)
                //    {
                //        blno = Dt.Rows[i][2].ToString();
                //    }
                //}
                //wt = INVOICEobj.GetWeightAE(blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));


                dt_new = AEBLObj.ShowAIEInfoQuerynew(Convert.ToInt32(txtJobno.Text), "SAMPLE", "JOB", 0, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()), ddl_product.SelectedValue);
                 if (dt_new.Rows.Count > 0)
                 {
                     for (i = 0; i < dt_new.Rows.Count; i++)
                     {

                         wt = wt + Convert.ToDouble(dt_new.Rows[i]["volume"].ToString());
                         gwt = gwt + Convert.ToDouble(dt_new.Rows[i]["grosswt"].ToString());
                         noofpks = noofpks + Convert.ToDouble(dt_new.Rows[i]["noofpkgs"].ToString());
                         Session["noofpks"] = noofpks;
                     }


                 }
                                 
                 lstcon.Items.Add("Gross Weight " + gwt + " Kgs");
                 lstcon.Items.Add("Charges Weight " + wt + " Kgs");
                 lstcon.Items.Add("No.of Pkg " + noofpks + " Kgs");

            }
            else
            {                          
               
                wt = INVOICEobj.GetWeightAE(blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                gwt = INVOICEobj.GetWeightAEgrosswt(blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                noofpks = INVOICEobj.GetWeightAEgrossPKG(blno, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                Session["noofpks"] = noofpks;             
                lstcon.Items.Add("Gross Weight "+gwt + " Kgs");
                lstcon.Items.Add("Charge Weight " + wt + " Kgs");
                lstcon.Items.Add("No.of Pkg " + noofpks + " Kgs");
            }




        }
        */

        protected void cmbbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Inco = "";
            DataTable dtnew = new DataTable();
            lstcon.Items.Clear();
            //lstvol.Items.Clear();
            strTranType = ddl_product.SelectedValue;
            //  int salesid;
            cmbbl.Items.Add("");
            // string shiprefno = "", usblno = "";

            if (cmbbl.SelectedIndex != 0)
            {
                DataAccess.Accounts.ProfomaInvoice ProINVobj = new DataAccess.Accounts.ProfomaInvoice();
                DataTable dtcheck = new DataTable();
                dtcheck = ProINVobj.CheckProfomainvoiceOSV(cmbbl.SelectedItem.Text, Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchId"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue));
                //if (dtcheck.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('There are vouchers to be approved which are pending for 7 days.  Hence request you to approve the same to create new voucher(s)');", true);
                //    clearall();
                //    return;
                //}
                DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginDivisionId"]));
                if (DtBLNO.Rows.Count > 0)
                {
                    mblno = DtBLNO.Rows[0][0].ToString();
                }
                if (strTranType == "FE" || strTranType == "FI")
                {
                    getFDebit();
                    if (strTranType == "FE") //  if(strTranType == "FE" &&hid_jobtype.Value=="3")
                    {
                        /* shiprefno = FEBLObj.GetBookinkNo(cmbbl.SelectedItem.ToString(), int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
                         if (shiprefno != "0")
                         {
                             usblno = shiprefno.Remove(4, 4);
                         }
                         else
                         {
                             usblno = "";
                         }
                     
                         if (cmbbl.SelectedItem.ToString() != shiprefno)
                         {
                             ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtJobno.Text + " is assigned for FCL and also DIrect BL #. You cannot raise Voucher');", true);
                             btnview.Enabled = false;
                             btnview.ForeColor = System.Drawing.Color.Gray;
                             btnAdd.Enabled = false;
                             btnAdd.ForeColor = System.Drawing.Color.Gray;
                         }
                         else if (cmbbl.SelectedItem.ToString() != usblno && cmbbl.SelectedItem.ToString().Length==10)
                         {
                             ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtJobno.Text + " is assigned for FCL and also DIrect BL #. You cannot raise Voucher');", true);
                             btnview.Enabled = false;
                             btnview.ForeColor = System.Drawing.Color.Gray;
                             btnAdd.Enabled = false;
                             btnAdd.ForeColor = System.Drawing.Color.Gray;
                         }
                         else
                         {
                             btnview.Enabled = true;
                             btnview.ForeColor = System.Drawing.Color.White;
                             btnAdd.Enabled = true;
                             btnAdd.ForeColor = System.Drawing.Color.White;
                         }*/


                        string type;
                        type = DAdvise.getproosdenjobtype(cmbbl.SelectedItem.ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                        if (type == "Y")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You cannot raise Overseas Debit / Credit Note for FCL Nomination / LCL Freehand shipment');", true);
                            btnview.Enabled = false;
                            btnview.ForeColor = System.Drawing.Color.Gray;
                            btnAdd.Enabled = false;
                            btnAdd.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                            btnAdd.Enabled = true;
                            btnAdd.ForeColor = System.Drawing.Color.White;


                            //else
                            //{
                            //    chk_GstApp.Checked = false;
                            //    chk_GstApp.Enabled = true;
                            //}
                        }


                    }

                }
                else if (strTranType == "AE" || strTranType == "AI")
                {
                    getAEIDebit();
                }

                else if (strTranType == "CH")
                {
                    getCHDebit();
                }

                dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);

                if (dtnew.Rows.Count > 0)
                {
                    if (Inco != "EXW")
                    {

                    }
                    else
                    {
                        chk_GstApp.Checked = true;
                        //  chk_GstApp.Enabled = false;
                    }
                }


            }

            btnback.Enabled = true;
            btnback.ForeColor = System.Drawing.Color.White;
            txtcharge.Focus();
            btnback.Text = "Cancel";
            //txttotal.Text = "";
            //double tot = 0, tot1 = 0;
            //for (i = 0; i <= grddebit.Rows.Count - 1; i++)
            //{
            //    tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);
            //    tot = tot + tot1;
            //}
            //txtDebit.Text = tot.ToString("#,0.00");
            //for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
            //{
            //    amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);
            //    amt = amt + amt1;
            //}
            //txtCredit.Text = amt.ToString("#,0.00");

            //if (txtCredit.Text != "" && txtCredit.Text == "0.00" && txtDebit.Text != "" && txtDebit.Text!="0.00")
            //{
            //    Toatlnew = tot - amt;
            //    if (Toatlnew<0)
            //    {
            //        lblGross.Text = "Payable Agent:";
            //        txttotal.Text = Toatlnew.ToString("#0.00");
            //    }
            //    else
            //    {
            //        lblGross.Text = "Receiable Agent:";
            //        txttotal.Text = Toatlnew.ToString("#0.00");

            //    }
            //}


            //fatran = Convert.ToInt32(DAdvise.CheckOSDCNFATrans(Convert.ToInt32(txtJobno.Text), "D", strTranType, branchid));
            //UserRights();
            //if (fatran == 0)
            //{
            //    fatran = Convert.ToInt32(DAdvise.CheckOSDCNFATrans(Convert.ToInt32(txtJobno.Text), "C", strTranType, branchid));
            //    if (fatran == 1)
            //    {

            //        btnprint.Enabled = false;
            //        btnprint.ForeColor = System.Drawing.Color.Gray;
            //    }
            //    else
            //    {
            //        btnprint.Enabled = true;
            //        btnprint.ForeColor = System.Drawing.Color.White;
            //    }
            //}
            //else
            //{
            //    btnprint.Enabled = false;
            //    btnprint.ForeColor = System.Drawing.Color.Gray;
            //}

            //checkOSDCN();
        }

        protected void txtJobno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hid_MoreOne.Value = "";
                //txt_Agent.ReadOnly = false;
                //txtsupplyto.ReadOnly = false;
                txt_Agent.Text = "";
                double fcamt = 0;
                hid_yes.Value = "0";
                hid_No.Value = "0";
                hid_debitDnno.Value = "0";
                hid_DebitCredit.Value = "0";
                hid_creditDnno.Value = "0";
                double amtnew = 0;
                strTranType = ddl_product.SelectedValue;
                // debittotal = 0;
                //credittotal = 0;
                // total = 0.0;
                DataSet ds = new DataSet();
                //lbl.Text = "";


                if (INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"])) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job is Open, You Can not Create a Voucher in this form');", true);
                    txtclear();
                    txtJobno.Focus();
                    return;

                }


                if (txtdcn.Text == "")
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewEmptyOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }
                else
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }

                if (ds.Tables.Count > 0)
                {
                     
                    Dt = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                    if (strTranType == "FE" || strTranType == "FI")
                    {
                        cmbbl.Items.Clear();
                        if (Dt.Rows.Count > 0)
                        {

                            cmbbl.Items.Add("");
                            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            {
                                cmbbl.Items.Add(Dt.Rows[i]["blno"].ToString());
                            }
                            cmbbl.Items.Add(Dt.Rows[0]["mblno"].ToString());

                        }
                    }
                    if (strTranType == "AE" || strTranType == "AI")
                    {
                        if (Dt.Rows.Count > 0)
                        {

                            cmbbl.Items.Add("");
                            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            {
                                cmbbl.Items.Add(Dt.Rows[i]["hawblno"].ToString());
                            }
                            cmbbl.Items.Add(Dt.Rows[0]["mawblno"].ToString());

                        }
                    }

                    if (strTranType == "CH")
                    {
                        if (Dt.Rows.Count > 0)
                        {

                            cmbbl.Items.Add("");
                            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            {
                                cmbbl.Items.Add(Dt.Rows[i]["docno"].ToString());
                            }
                            cmbbl.Items.Add(Dt.Rows[0]["mdocno"].ToString());

                        }


                    }


                    //dtOSDN = DAdvise.SelDepCre4OSDN(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                    //dtOSCN = DAdvise.SelDepCre4OSCN(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));


                    //dtOSDNPro = DAdvise.SelDepCre4ProOSDN(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                    // dtOSCNPro = DAdvise.SelDepCre4ProOSCN(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));

                    //if (dtOSDN.Rows.Count == 1 && dtOSCN.Rows.Count == 1)
                    //{
                    //    lbl_pop.Text = "OSSI #" + dtOSDN.Rows[0][0].ToString() + " and  OSCN #" + dtOSCN.Rows[0][0].ToString() + "  has been already rasied this agent " + dtOSDN.Rows[0][1].ToString() + "...Do you want to raise  for another agent";
                    //    pop_upforAgent.Show();
                    //    return;
                    //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already raised the OSDN #" + dtOSDN.Rows[0][0].ToString() + " and  OSCN #" + dtOSCN.Rows[0][0].ToString() + " ');", true);
                    //    //txtclear();
                    //    //txtJobno.Focus();
                    //    //return;
                    //}
                    //else if (dtOSDN.Rows.Count == 1)
                    //{
                    //    lbl_pop.Text = "OSSI #" + dtOSDN.Rows[0][0].ToString() + " has been already rasied this agent " + dtOSDN.Rows[0][1].ToString() + "...Do you want to raise  for another agent";
                    //    pop_upforAgent.Show();
                    //    return;
                    //}
                    //else if (dtOSCN.Rows.Count == 1)
                    //{
                    //    lbl_pop.Text = "OSPI #" + dtOSCN.Rows[0][0].ToString() + " has been already rasied this agent " + dtOSCN.Rows[0][1].ToString() + "...Do you want to raise  for another agent";
                    //    pop_upforAgent.Show();
                    //    return;
                    //}
                    DtVal = DAdvise.SPGetDtls4osdcnForAgentOSV(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), strTranType);
                    Grd_Details.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Details.DataBind();
                    grd_prodetails.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd_prodetails.DataBind();
                    if (DtVal.Tables.Count > 0)
                    {
                        dtOSDNPro = DtVal.Tables[0];
                        dtOSCNPro = DtVal.Tables[1];
                        dtOSDN = DtVal.Tables[3];
                        dtOSCN = DtVal.Tables[2];

                    }


                    if (dtOSDN.Rows.Count > 0 && dtOSCN.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();

                        dt.Columns.Add("dnno");
                        dt.Columns.Add("jobno");
                        dt.Columns.Add("agent");
                        dt.Columns.Add("amount");
                        dt.Columns.Add("debitcredit");
                        DataRow dr = dt.NewRow();
                        dr = dt.NewRow();
                        dr["dnno"] = "DebitNote";
                        dt.Rows.Add(dr);
                        for (int i = 0; i <= dtOSDN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSDN.Rows[i]["dnno"].ToString();
                            dt.Rows[count]["jobno"] = dtOSDN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSDN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSDN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSSI";

                        }

                        dr = dt.NewRow();
                        dr["dnno"] = "CreditNote";
                        dt.Rows.Add(dr);
                        for (int i = 0; i <= dtOSCN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSCN.Rows[i]["dnno"].ToString();
                            dt.Rows[count]["jobno"] = dtOSCN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSCN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSCN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSPI";
                        }

                        Grd_Details.DataSource = dt;
                        Grd_Details.DataBind();


                        if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }

                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSDNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }
                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();



                        }

                        else if (dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();



                        }

                        popup_Grd.Show();
                        return;

                    }
                    if (dtOSDN.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();

                        dt.Columns.Add("dnno");
                        dt.Columns.Add("jobno");
                        dt.Columns.Add("agent");
                        dt.Columns.Add("amount");
                        dt.Columns.Add("debitcredit");
                        DataRow dr = dt.NewRow();
                        dr = dt.NewRow();
                        dr["dnno"] = "DebitNote";
                        dt.Rows.Add(dr);
                        for (int i = 0; i <= dtOSDN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSDN.Rows[i][0].ToString();
                            dt.Rows[count]["jobno"] = dtOSDN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSDN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSDN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSSI";


                        }


                        Grd_Details.DataSource = dt;
                        Grd_Details.DataBind();


                        if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }

                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSDNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }
                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }



                        popup_Grd.Show();
                        return;

                    }


                    if (dtOSCN.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();

                        dt.Columns.Add("dnno");
                        dt.Columns.Add("jobno");
                        dt.Columns.Add("agent");
                        dt.Columns.Add("debitcredit");
                        dt.Columns.Add("amount");
                        DataRow dr = dt.NewRow();
                        dr = dt.NewRow();
                        dr["dnno"] = "CreditNote";
                        dt.Rows.Add(dr);

                        for (int i = 0; i <= dtOSCN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSCN.Rows[i][0].ToString();
                            dt.Rows[count]["jobno"] = dtOSCN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSCN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSCN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSPI";


                        }

                        Grd_Details.DataSource = dt;
                        Grd_Details.DataBind();


                        if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }

                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSDNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();//customername
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }
                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();//customername
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }



                        popup_Grd.Show();
                        return;

                    }




                    if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();

                        dt1.Columns.Add("dnno");
                        dt1.Columns.Add("jobno");
                        dt1.Columns.Add("agent");
                        dt1.Columns.Add("amount");
                        dt1.Columns.Add("debitcredit");
                        DataRow dr1 = dt1.NewRow();
                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro DebitNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                            dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                            dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSSI";

                        }

                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro CreditNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                            dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                            dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSPI";
                        }


                        grd_prodetails.DataSource = dt1;
                        grd_prodetails.DataBind();
                        popup_Grd.Show();
                        return;

                    }

                    if (dtOSDNPro.Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();

                        dt1.Columns.Add("dnno");
                        dt1.Columns.Add("jobno");
                        dt1.Columns.Add("agent");
                        dt1.Columns.Add("amount");
                        dt1.Columns.Add("debitcredit");
                        DataRow dr1 = dt1.NewRow();
                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro DebitNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                            dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();//customername
                            dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSSI";

                        }
                        grd_prodetails.DataSource = dt1;
                        grd_prodetails.DataBind();
                        popup_Grd.Show();
                        return;

                    }

                    if (dtOSCNPro.Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();

                        dt1.Columns.Add("dnno");
                        dt1.Columns.Add("jobno");
                        dt1.Columns.Add("agent");
                        dt1.Columns.Add("amount");
                        dt1.Columns.Add("debitcredit");
                        DataRow dr1 = dt1.NewRow();
                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro CreditNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();//customername
                            dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                            dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSPI";
                        }


                        grd_prodetails.DataSource = dt1;
                        grd_prodetails.DataBind();
                        popup_Grd.Show();
                        return;

                    }





                    //else if (dtOSDN.Rows.Count > 0 || dtOSCN.Rows.Count > 0)
                    //{
                    //    if (dtOSDN.Rows.Count > 0)
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already raised the OSDN #" + dtOSDN.Rows[0][0].ToString() + "');", true);
                    //    }
                    //    if (dtOSCN.Rows.Count > 0)
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already raised the OSCN #" + dtOSCN.Rows[0][0].ToString() + "');", true);
                    //    }
                    //    //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already raised the OSCN #" + dtOSCN.Rows[0][0].ToString() + "');", true);
                    //    //txtclear();
                    //    //txtJobno.Focus();
                    //    //return;
                    //}


                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            jobno = Convert.ToInt32(dt.Rows[0][4].ToString());
                            //if (strTranType == "FE")
                            //{
                            //    hid_jobtype.Value = dt.Rows[0]["jobtype"].ToString();
                            //    if (hid_jobtype.Value == "2")
                            //    {


                            //        btnview.Enabled = false;
                            //        btnview.ForeColor = System.Drawing.Color.Gray;
                            //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtJobno.Text + " is assigned for Co-Load. You cannot raise Voucher');", true);

                            //    }
                            //    else
                            //    {
                            //        btnview.Enabled = true;
                            //        btnview.ForeColor = System.Drawing.Color.White;
                            //    }
                            //}
                            // txtcustomer.Text = dt.Rows[0][0].ToString() + Environment.NewLine + dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                            txtcustomer.Text = dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                            txt_Agent.Text = dt.Rows[0][0].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt.Rows[0]["agentid"].ToString();
                                hid_intagent.Value = dt.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }


                            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginDivisionId"]));
                            if (DtBLNO.Rows.Count > 0)
                            {
                                mblno = DtBLNO.Rows[0][0].ToString();
                            }


                            double amt = 0, amt1 = 0;
                            DataTable dtdc = new DataTable();
                            // dtdc = ds.Tables[1];
                            //grddebit.DataSource = dtdc;
                            //grddebit.DataBind();
                            DataTable dtnew = new DataTable();
                            DataTable dtcc = new DataTable();
                            //dtcc = ds.Tables[2];
                            //grdcredit.DataSource = dtcc;
                            //grdcredit.DataBind();

                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                dtdc = ds.Tables[1];
                            }
                            else
                            {

                            }
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                dtnew = ds.Tables[2];
                            }


                            DataTable dtnew1 = new DataTable();
                            DataTable dtcc1 = new DataTable();
                            dtnew1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, 5, Convert.ToInt32(hf_branchid.Value));
                            dtcc1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, 6, Convert.ToInt32(hf_branchid.Value));

                            if (dtnew1.Rows.Count > 0)
                            {
                                int n = 0;
                                n = Convert.ToInt32(dtnew1.Rows[0][0].ToString());

                                if (n != 0)
                                {
                                    txtdcn.Text = n.ToString();
                                    //this.PopUpService.Show();
                                    //return;
                                }

                            }
                            if (dtcc1.Rows.Count > 0)
                            {
                                int n = 0;
                                n = Convert.ToInt32(dtcc1.Rows[0][0].ToString());
                                if (n != 0)
                                {
                                    txtdcn.Text = n.ToString();
                                    //this.PopUpService.Show();
                                    //return;
                                }
                            }

                            if (dtdc.Rows.Count == 0 && dtnew.Rows.Count == 0)
                            {
                                // ddlTypes.Enabled = false;
                            }
                            else
                            {
                                ddlTypes.Enabled = true;
                            }

                            //if (dtdc.Rows.Count > 0 || dtnew.Rows.Count > 0)
                            //{

                            //}
                            if (dtdc.Rows.Count > 0)
                            {
                                double Total = 0;
                                DataTable dtempty = new DataTable();
                                dtempty.Columns.Add("blno", typeof(string));
                                dtempty.Columns.Add("chargename", typeof(string));
                                dtempty.Columns.Add("curr", typeof(string));
                                dtempty.Columns.Add("rate", typeof(string));
                                dtempty.Columns.Add("exrate", typeof(string));
                                dtempty.Columns.Add("bASe", typeof(string));
                                dtempty.Columns.Add("withoutgstAmt", typeof(string));
                                dtempty.Columns.Add("stgst", typeof(string));
                                dtempty.Columns.Add("amount", typeof(string));
                                dtempty.Columns.Add("chargeid", typeof(int));
                                dtempty.Columns.Add("GSTCHK", typeof(string));
                                dtempty.Columns.Add("provouno", typeof(string));
                                dtempty.Columns.Add("vouno", typeof(string));
                                dtempty.Columns.Add("vouyear", typeof(string));
                                dtempty.Columns.Add("fcamt", typeof(string));
                                DataRow dr = dtempty.NewRow();

                                if (dtdc.Rows.Count > 0)
                                {
                                    for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                                    {
                                        dr = dtempty.NewRow();
                                        dtempty.Rows.Add(dr);
                                        dr[0] = dtdc.Rows[i]["blno"].ToString();
                                        dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                                        dr[2] = dtdc.Rows[i]["curr"].ToString();
                                        dr[3] = dtdc.Rows[i]["rate"].ToString();
                                        dr[4] = dtdc.Rows[i]["exrate"].ToString();
                                        dr[5] = dtdc.Rows[i]["bAse"].ToString();

                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                                        {
                                            amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                                            dr[6] = amt.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[6] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                                            dr[7] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[7] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                                            dr[8] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[8] = "0.00";
                                        }
                                        dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                                        dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                                        dr[11] = dtdc.Rows[i]["provouno"].ToString();
                                        if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                        {
                                            chk_GstApp.Checked = true;
                                            //  chk_GstApp.Enabled = false;
                                        }
                                        else
                                        {
                                            chk_GstApp.Checked = true;
                                            //chk_GstApp.Enabled = false;
                                        }
                                        dr[12] = dtdc.Rows[i]["dnno"].ToString();
                                        dr[13] = dtdc.Rows[i]["vouyear"].ToString();

                                        Total = Total + double.Parse(dr[8].ToString());
                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                                            fcamt = fcamt + (Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString()));
                                        }
                                        else
                                        {
                                            fcamt = fcamt + 0;
                                        }
                                    }
                                }
                                txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                                grddebit.DataSource = dtempty;
                                grddebit.DataBind();
                            }



                            dtnew = ds.Tables[2];
                            if (dtnew.Rows.Count > 0)
                            {
                                double Total = 0;
                                DataTable dtempty1 = new DataTable();
                                dtempty1.Columns.Add("blno", typeof(string));
                                dtempty1.Columns.Add("chargename", typeof(string));
                                dtempty1.Columns.Add("curr", typeof(string));
                                dtempty1.Columns.Add("rate", typeof(string));
                                dtempty1.Columns.Add("exrate", typeof(string));
                                dtempty1.Columns.Add("bASe", typeof(string));
                                dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                                dtempty1.Columns.Add("stgst", typeof(string));
                                dtempty1.Columns.Add("amount", typeof(string));
                                dtempty1.Columns.Add("chargeid", typeof(int));
                                dtempty1.Columns.Add("GSTCHK", typeof(string));

                                dtempty1.Columns.Add("provouno", typeof(string));
                                dtempty1.Columns.Add("vouno", typeof(string));
                                dtempty1.Columns.Add("vouyear", typeof(string));
                                dtempty1.Columns.Add("fcamt", typeof(string));
                                DataRow dr = dtempty1.NewRow();

                                if (dtnew.Rows.Count > 0)
                                {
                                    for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                                    {
                                        dr = dtempty1.NewRow();
                                        dtempty1.Rows.Add(dr);
                                        dr[0] = dtnew.Rows[i]["blno"].ToString();
                                        dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                                        dr[2] = dtnew.Rows[i]["curr"].ToString();
                                        dr[3] = dtnew.Rows[i]["rate"].ToString();
                                        dr[4] = dtnew.Rows[i]["exrate"].ToString();
                                        dr[5] = dtnew.Rows[i]["bAse"].ToString();

                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                                        {
                                            amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                                            dr[6] = amt.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[6] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                                            dr[7] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[7] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                                            dr[8] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[8] = "0.00";
                                        }
                                        dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                                        dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();
                                        dr[11] = dtnew.Rows[i]["provouno"].ToString();
                                        if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                        {
                                            chk_GstApp.Checked = true;
                                            // chk_GstApp.Enabled = false;
                                        }
                                        else
                                        {
                                            chk_GstApp.Checked = true;
                                            // chk_GstApp.Enabled = false;
                                        }
                                        dr[12] = dtnew.Rows[i]["cnno"].ToString();
                                        dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                                        Total = Total + double.Parse(dr[8].ToString());

                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                                            fcamt = fcamt + (Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString()));
                                        }
                                        else
                                        {
                                            fcamt = fcamt + 0;
                                        }
                                    }
                                }

                                txt_FcCramt.Text = fcamt.ToString("#0.00");

                                grdcredit.DataSource = dtempty1;
                                grdcredit.DataBind();
                            }

                            double tot = 0, tot1 = 0;
                            for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                                tot = tot + tot1;
                            }
                            txtDebit.Text = tot.ToString("#,0.00");
                            for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                            {
                                amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                                amtnew = amtnew + amt1;
                            }
                            txtCredit.Text = amtnew.ToString("#,0.00");

                            if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                            {
                                Toatlnew = tot - amtnew;
                                if (Toatlnew < 0)
                                {
                                    lblGross.Text = "Payable to Agent:";
                                    txttotal.Text = Toatlnew.ToString("#0.00");
                                }
                                else
                                {
                                    lblGross.Text = "Receivable from Agent:";
                                    txttotal.Text = Toatlnew.ToString("#0.00");

                                }
                            }
                            else
                            {
                                if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                                {
                                    txttotal.Text = txtCredit.Text;
                                }
                                else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                                {
                                    txttotal.Text = txtDebit.Text;
                                }
                            }
                            btnback.Text = "Cancel";
                        }
                        else
                        {
                            txtclear();
                            return;
                        }

                    }


                    //    if (grddebit.Rows.Count != 0)
                    //    {
                    //        for (i = 0; i < grddebit.Rows.Count; i++)
                    //        {
                    //            debittotal = debittotal + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);
                    //        }
                    //    }
                    //    if (grdcredit.Rows.Count != 0)
                    //    {
                    //        for (i = 0; i < grdcredit.Rows.Count; i++)
                    //        {
                    //            credittotal = credittotal + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);
                    //        }
                    //    }



                    //    if ((grddebit.Rows.Count > 0) && (grdcredit.Rows.Count == 0))
                    //    {
                    //        for (i = 0; i < grddebit.Rows.Count; i++)
                    //        {
                    //            //debittotal = debittotal + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);
                    //            total = total + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);

                    //        }
                    //    }
                    //    else if ((grdcredit.Rows.Count > 0) && (grddebit.Rows.Count == 0))
                    //    {
                    //        for (i = 0; i < grdcredit.Rows.Count; i++)
                    //        {
                    //            // credittotal = credittotal + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);
                    //            total = total + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);

                    //        }
                    //    }

                    //    total = System.Convert.ToDouble(debittotal) - System.Convert.ToDouble(credittotal);
                    //    txttotal.Text = String.Format("{0:F2}", total);

                    DataTable dtd1 = new DataTable();
                    DataTable dtd = new DataTable();
                    dtd = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, 5, Convert.ToInt32(hf_branchid.Value));
                    dtd1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, 6, Convert.ToInt32(hf_branchid.Value));
                    if (dtd.Rows.Count > 0)
                    {
                        lbl.Text = "Debit Note";
                        hid_debitDnno.Value = dtd.Rows[0][0].ToString();
                    }
                    else
                    {
                        dtd = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, 6, Convert.ToInt32(hf_branchid.Value));
                        if (dtd.Rows.Count > 0)
                        {
                            lbl.Text = "Credit Note";
                            //hidCRRefno
                        }

                    }
                    if (dtd1.Rows.Count > 0)
                    {
                        hid_creditDnno.Value = dtd1.Rows[0][0].ToString();

                    }
                    if (dtd.Rows.Count > 0)
                    {
                        txtdcn.Text = dtd.Rows[0][0].ToString();
                        txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                        txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();

                        if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                            //txtVendorRefnodate.Text = Convert.ToDateTime(dtd.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");//hide on 14Feb2023 //nambi
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        if (dtd.Rows[0]["fatransfer"].ToString() == "")
                        {
                            btnview.Text = "Save";
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            btnview.Enabled = false;
                            btnview.ForeColor = System.Drawing.Color.Gray;
                        }
                    }
                    else
                    {
                        btnview.Text = "Save";
                        btnview.Enabled = true;
                        btnview.ForeColor = System.Drawing.Color.White;
                        txtdcn.Text = "";
                    }
                    btnback.Text = "Cancel";
                    btnprint.Enabled = true;


                    if (btnview.Text == "Save" && hid_jobtype.Value == "2")
                    {
                        btnview.Enabled = false;
                        btnview.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transferred');", true);
                    txtclear();
                    txtJobno.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtclear();
                txtJobno.Focus();
            }

        }
        public void txtclear()
        {
            if (logobj.GetDate().Month < 4)
            {
                txtyear.Text = (logobj.GetDate().Year - 1).ToString();
            }
            else
            {
                txtyear.Text = (logobj.GetDate().Year).ToString();
            }
            lbl.Text = "";
            txtcustomer.Text = "";
            txtshipment.Text = "";
            txttotal.Text = "";
            txtJobno.Text = "";
            txtdcn.Text = "";

            grddebit.DataSource = null;
            grddebit.DataBind();

            grdcredit.DataSource = null;
            grdcredit.DataBind();
            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;

            grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            grdcredit.DataBind();
            grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            grddebit.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (ddlTypes.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the voucher type');", true);
                    return;
                }
                DataTable dtnew = new DataTable();
                string Inco = "";
                strTranType = ddl_product.SelectedValue;
                DataTable DtOSDNCNst = new DataTable();
                if (btnAdd.Text == "Update")
                {
                    cmbbase_SelectedIndexChanged(sender, e);
                }

                if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
                {
                    douvolume = Convert.ToDouble(hid_douvolume.Value);
                }
                else
                {
                    douvolume = 0;
                }


                if (string.IsNullOrEmpty(hid_fd.Value) != true)
                {
                    fd = Convert.ToInt32(hid_fd.Value);
                }
                else
                {
                    fd = 0;
                }
                int Ctype = 0;
                string FOSCNDNtype = "";
                string portname = "";
                DataTable DtCtype = new DataTable();
                DataTable DtCHeckNew = new DataTable();
                int stateid = 0;
                DtCHeckNew = OSDNCN.GetCheckcloseUnclose(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), strTranType);
                //if (DtCHeckNew.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has been already closed.So you cannot add Charges');", true);
                //    return;
                //}







                if (hid_No.Value == "NO")
                {
                    Ctype = Convert.ToInt32(ddlDebiteOrCredite.SelectedValue);
                    DtCtype = OSDNCN.GetAppDetails4OSV(Ctype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString());

                    if (DtCtype.Rows.Count > 0)
                    {
                        FOSCNDNtype = DtCtype.Rows[0][0].ToString();

                        if (FOSCNDNtype == "No")
                        {

                            if (Ctype == 5)
                            {
                                btnAdd.Enabled = false;
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already OSDN Raised For this job.Kindly create one more Voucher for this job');", true);

                                if (ddlTypes.SelectedValue != "0")
                                {
                                    txtdcn.Focus();
                                }
                                else
                                {
                                    txtJobno.Focus();
                                }
                                return;
                            }
                            else
                            {
                                btnAdd.Enabled = false;
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already OSCN Raised For this job.Kindly create one more Voucher for this job');", true);
                                if (ddlTypes.SelectedValue != "0")
                                {
                                    txtdcn.Focus();
                                }
                                else
                                {
                                    txtJobno.Focus();
                                }
                                return;
                            }

                        }
                    }
                }

                if (cmbbl.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Base');", true);
                    cmbbl.Focus();
                    return;
                }

                if (cmbbase.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                    return;
                }

                if (cmbbase.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                    return;
                }
                DtOSDNCNst = OSDNCN.GetstateidcheckwithOSDNCN(Convert.ToInt32(Session["LoginBranchId"].ToString()), cmbbl.Text, Convert.ToInt32(txtJobno.Text), strTranType);
                if (DtOSDNCNst.Rows.Count > 0)
                {
                    stateid = Convert.ToInt32(DtOSDNCNst.Rows[0]["stateid"].ToString());
                    portname = DtOSDNCNst.Rows[0]["portname"].ToString();
                    if (stateid == 0)
                    {
                        //   StrScript += "This Ref no:" + int_Refno + "do not have State Id for the Port name : " + portname + ",.Kindly update the Masterport";
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('This Job no:" + Convert.ToInt32(txtJobno.Text) + " for MBL/BL # :" + cmbbl.Text + " do not have State Id for the Port name : " + portname + ",.Kindly update the Masterport');", true);

                        return;
                        //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('You have no rights to approve Voucher # " + int_Refno + " prepared by you');", true);

                    }
                }
                DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

                //if (ddlDebiteOrCredite.SelectedValue == "CreditAdvise")
                //{
                double stper;
                stper = chargeobj.CheckChargeST(Convert.ToInt32(hdnChargid.Value));
                if (stper > 0)
                {
                    this.model_Servicetax.Show();
                    return;
                }
                // }


                if (btnAdd.Text == "Add")
                {


                    if (ddlDebiteOrCredite.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                        ddlDebiteOrCredite.Focus();
                        return;
                    }
                    if (cmbbl.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                        cmbbl.Focus();
                        return;
                    }
                    if (cmbbase.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                        return;
                    }
                    if (txt_Agent.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Agent cannot be blank');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }
                    //else
                    //{
                    if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }

                    //}
                    DataTable DtAgent = new DataTable();
                    DtAgent = OSDNCN.CheckForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(hid_intagent.Value));
                    if (DtAgent.Rows.Count > 0)
                    {
                        if (ddlDebiteOrCredite.SelectedValue == "5")
                        {
                            if (hid_MoreOne.Value != "Yes")
                            {
                                if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                                {


                                }
                                else
                                {
                                    lbl_addMorAgent.Text = "Already Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " has been raised for this Agent   " + DtAgent.Rows[0][1].ToString() + ".. Do you want to add are one more voucher";
                                    this.popup_MoreAgent.Show();
                                    // ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                    return;
                                }

                            }

                        }

                        else if (ddlDebiteOrCredite.SelectedValue == "6")
                        {
                            if (hid_MoreOne.Value != "Yes")
                            {
                                if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                                {
                                }
                                else
                                {
                                    lbl_addMorAgent.Text = "Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " has been raised for this Agent " + DtAgent.Rows[0][1].ToString() + "..Do you want to add are one more voucher";
                                    this.popup_MoreAgent.Show();
                                    // ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                    return;
                                }
                            }

                        }

                    }
                    //OSDNCN
                    CheckChargeBase();
                    if (chargename > 0 && cbase > 0)
                    {
                        GrdLoad(ddlDebiteOrCredite.SelectedValue);
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exist');", true);
                        cmbbase.Focus();
                        return;

                    }
                    //txt_Agent.ReadOnly = true;
                    //txtsupplyto.ReadOnly = true;



                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
                        bolcuststat = false;
                        return;
                    }
                    else
                    {
                        // str_booking = obj_da_FIBL.GetBookinkNo(cmbbl.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                        if (dtnew.Rows.Count > 0)
                        {
                            Inco = dtnew.Rows[0][0].ToString();
                        }
                        if (Inco != "EXW")
                        {
                            // return;
                        }
                        else
                        {
                            //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                            //if (bolcuststat == true)
                            //{
                            //    bolcuststat = false;
                            //    return;
                            //}
                        }

                    }
                    //}

                    if (grdcredit.Rows.Count > 0)
                    {
                        if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }


                    }

                    if (grddebit.Rows.Count > 0)
                    {

                        if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }

                    }

                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }



                    if (Inco != "EXW")
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk_GstApp.Checked = true;
                            // chk_GstApp.Enabled = false;
                            DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value));
                        }
                        else
                        {
                            DAdvise.InsDCAdviseForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_intagent.Value));

                        }
                    }

                    else
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk = "Y";
                        }
                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = false;
                        DAdvise.InsDCAdviseForGstOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value));
                        //
                    }

                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {

                        if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                        {
                            DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_debitDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue));
                        }

                    }
                    else
                    {
                        if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                        {
                            DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_creditDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue));
                        }
                    }


                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved');", true);
                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text);
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text);
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text);
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text);
                            break;
                        case "CH":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text);
                            break;
                    }

                    //chargetxtclear();
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    Clear_Fin();
                    //chk_GstApp.Enabled = true;
                    // chk_GstApp.Checked = false;
                    btnprint.Enabled = true;

                }
                else if (btnAdd.Text == "Update")
                {
                    if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }
                    if (hid_SupplyTo.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txtsupplyto.Focus();
                        return;
                    }

                    dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                    if (dtnew.Rows.Count > 0)
                    {
                        Inco = dtnew.Rows[0][0].ToString();
                    }
                    if (Inco != "EXW")
                    {
                        // return;
                    }
                    else
                    {
                        //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                        //if (bolcuststat == true)
                        //{
                        //    bolcuststat = false;
                        //    return;
                        // }
                    }
                    if (ddlDebiteOrCredite.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                        ddlDebiteOrCredite.Focus();
                        return;
                    }
                    if (cmbbl.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                        cmbbl.Focus();
                        return;
                    }
                    if (cmbbase.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                        return;
                    }

                    DataTable DtAgent = new DataTable();
                    DtAgent = OSDNCN.CheckForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(hid_intagent.Value));
                    if (DtAgent.Rows.Count > 0)
                    {
                        if (ddlDebiteOrCredite.SelectedValue == "5")
                        {
                            if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already  Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                return;
                            }
                        }
                        else if (ddlDebiteOrCredite.SelectedValue == "6")
                        {
                            if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                            {
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                return;
                            }

                        }

                    }
                    //txt_Agent.ReadOnly = true;
                    //txtsupplyto.ReadOnly = true;
                    index = Convert.ToInt32(Session["index"]);
                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {
                        strbase = grddebit.Rows[index].Cells[6].Text;
                    }
                    else if (ddlDebiteOrCredite.SelectedValue == "6")
                    {
                        strbase = grdcredit.Rows[index].Cells[6].Text;
                    }
                    //  index = grd.SelectedRow.RowIndex;
                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }



                    if (grdcredit.Rows.Count > 0)
                    {
                        if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }


                    }

                    if (grddebit.Rows.Count > 0)
                    {

                        if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }

                    }
                    if (Inco != "EXW")
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk_GstApp.Checked = true;
                            //   chk_GstApp.Enabled = false;
                            if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                            {
                                DAdvise.UpdDCAdviseForGstForNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value));
                            }
                            else
                            {
                                DAdvise.UpdDCAdviseForGstForagentOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value));
                            }

                        }
                        else
                        {

                            if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                            {
                                DAdvise.UpdDCAdviseForNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value));

                            }
                            else
                            {
                                DAdvise.UpdDCAdviseNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_intagent.Value));

                            }
                        }
                    }
                    else
                    {

                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = false;
                        if (chk_GstApp.Checked == true)
                        {
                            chk = "Y";
                        }
                        if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                        {
                            DAdvise.UpdDCAdviseForGstForNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value));
                        }
                        else
                        {
                            DAdvise.UpdDCAdviseForGstForagentOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value));
                        }

                    }

                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);


                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString() + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text); ;
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString() + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text); ;
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString() + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text); ;
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString() + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text); ;
                            break;
                        case "CH":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString() + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/" + txtcurr.Text + "/" + txtrate.Text + "/" + txtamount.Text);
                            break;
                    }

                    //chargetxtclear();
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    Clear_Fin();
                    btnAdd.Text = "Add";
                    btnprint.Enabled = true;
                    txtcharge.Enabled = true;
                    //  chk_GstApp.Enabled = true;
                    //chk_GstApp.Checked = false;
                    txtcharge.ForeColor = Color.Black;
                    cmbbase.Enabled = true;
                    cmbbase.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }
        public void Clear_Fin()
        {
            txtcharge.Text = "";
            txtcurr.Text = "";
            txtexrate.Text = "";
            txtrate.Text = "";
            cmbbase.SelectedIndex = 0;
            // txtamount.Text = "";
            txtamount.Text = "";
            txtremarks.Text = "";
            //if (txtdcn.Text == "")
            //{
            //    ddlDebiteOrCredite.SelectedIndex = 0;
            //}
            //else
            //{

            //}

            cmbbl.SelectedIndex = 0;

        }

        public void CheckChargeBase()
        {
            //   strTranType = Request.QueryString["type"].ToString();
            // type = Request.QueryString["type"].ToString();

            if (txtcharge.Text != "")
            {
                if (ddlDebiteOrCredite.SelectedValue == "5")
                {
                    chargename = DAdvise.GetDCChargescountAgentOSV(cmbbl.Text, Convert.ToInt32(hdnChargid.Value), 5, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value));
                    cbase = DAdvise.GetDCBasecountAgentOSV(cmbbl.Text, cmbbase.Text, Convert.ToInt32(hdnChargid.Value), 5, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value));
                }
                else
                {
                    chargename = DAdvise.GetDCChargescountAgentOSV(cmbbl.Text, Convert.ToInt32(hdnChargid.Value), 6, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value));
                    cbase = DAdvise.GetDCBasecountAgentOSV(cmbbl.Text, cmbbase.Text, Convert.ToInt32(hdnChargid.Value), 6, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_intagent.Value));
                }
            }
        }

        protected void grddebit_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grddebit, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }




        protected void grddebit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int refno;
            hid_DebitCredit.Value = "0";
            string chknew = "";
            int debnonew = 0;
            string vou = "";
            int debno = 0;
            if (grddebit.Rows.Count > 0)
            {

                strTranType = ddl_product.SelectedValue;
                if (hid_confirm.Value.ToString() == "")
                {
                    index = grddebit.SelectedRow.RowIndex;
                    Session["index"] = index;
                    txtcharge.Text = grddebit.Rows[index].Cells[2].Text;
                    txtcurr.Text = grddebit.Rows[index].Cells[3].Text;
                    txtexrate.Text = grddebit.Rows[index].Cells[5].Text;
                    txtrate.Text = grddebit.Rows[index].Cells[4].Text;
                    cmbbase.Text = grddebit.Rows[index].Cells[6].Text;
                    txtamount.Text = grddebit.Rows[index].Cells[9].Text;
                    ddlDebiteOrCredite.SelectedValue = "5";
                    cmbbl.Text = grddebit.Rows[index].Cells[1].Text;
                    hdnChargid.Value = grddebit.Rows[index].Cells[10].Text;
                    if (string.IsNullOrEmpty(grddebit.Rows[index].Cells[12].Text) != true)
                    {
                        hid_DebitCredit.Value = grddebit.Rows[index].Cells[12].Text;
                        debno = Convert.ToInt32(grddebit.Rows[index].Cells[12].Text);
                        for (int i = 0; i <= grddebit.Rows.Count - 1; i++)
                        {

                            if (string.IsNullOrEmpty(grddebit.Rows[i].Cells[12].Text) != true)
                            {
                                debnonew = Convert.ToInt32(grddebit.Rows[i].Cells[12].Text);
                                if (debno == debnonew)
                                {
                                    chknew = grddebit.Rows[i].Cells[11].Text;
                                    if (chknew == "Y")
                                    {
                                        chk_GstApp.Checked = true;
                                        //  chk_GstApp.Enabled = false;
                                    }
                                }
                            }

                        }
                    }
                    if (chknew != "Y")
                    {
                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = true;
                    }
                    //else
                    //{
                    //    chk_GstApp.Checked = false;
                    //    chk_GstApp.Enabled = true;

                    //}
                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {
                        vou = "D";
                    }

                    txtremarks.Text = DAdvise.GetDCAdviseRemarksOSV(cmbbl.Text, vou, Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                    if (txtremarks.Text.Trim() == "0")
                    {
                        txtremarks.Text = "";
                    }
                    DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));


                    if (DtBLNO.Rows.Count > 0)
                    {
                        mblno = DtBLNO.Rows[0][0].ToString();
                    }

                    if (cmbbl.SelectedItem.ToString() == mblno)
                    {
                        FGetNoofCont(txtJobno.Text, txtJobno.Text);
                    }
                    else
                    {
                        FGetNoofCont(txtJobno.Text, cmbbl.Text);
                    }

                    cmbbl_SelectedIndexChanged(sender, e);
                    btnAdd.Text = "Update";
                    btnprint.Enabled = true;

                }
                if (hid_confirm.Value.ToString() == "N")
                {
                    hid_confirm.Value = "";
                    return;
                }
                else if (hid_confirm.Value.ToString() == "Y")
                {
                    index = grddebit.SelectedRow.RowIndex;
                    ddlDebiteOrCredite.SelectedValue = "5";
                    if (grddebit.Rows[index].Cells[12].Text != "")
                    {
                        refno = Convert.ToInt32(grddebit.Rows[index].Cells[12].Text);
                    }
                    else
                    {
                        refno = 0;
                    }
                    DAdvise.DelDebitCreditOSV(grddebit.Rows[index].Cells[1].Text, Convert.ToInt32(grddebit.Rows[index].Cells[10].Text), grddebit.Rows[index].Cells[6].Text, 5, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), refno);


                    switch (strTranType)
                    {
                        case "FE":

                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grddebit.Rows[index].Cells[1].Text + "/" + grddebit.Rows[index].Cells[2].Text + "/" + grddebit.Rows[index].Cells[12].Text + "/" + grddebit.Rows[index].Cells[13].Text);
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grddebit.Rows[index].Cells[1].Text + "/" + grddebit.Rows[index].Cells[2].Text + "/" + grddebit.Rows[index].Cells[12].Text + "/" + grddebit.Rows[index].Cells[13].Text);
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grddebit.Rows[index].Cells[1].Text + "/" + grddebit.Rows[index].Cells[2].Text + "/" + grddebit.Rows[index].Cells[12].Text + "/" + grddebit.Rows[index].Cells[13].Text);
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grddebit.Rows[index].Cells[1].Text + "/" + grddebit.Rows[index].Cells[2].Text + "/" + grddebit.Rows[index].Cells[12].Text + "/" + grddebit.Rows[index].Cells[13].Text);
                            break;

                        case "CH":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grddebit.Rows[index].Cells[1].Text + "/" + grddebit.Rows[index].Cells[2].Text + "/" + grddebit.Rows[index].Cells[12].Text + "/" + grddebit.Rows[index].Cells[13].Text);
                            break;
                    }


                    grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                    grddebit.DataBind();
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    if (grddebit.Rows.Count == 0)
                    {
                        hid_debitDnno.Value = "0";
                    }

                    Clear_Fin();
                    hid_confirm.Value = "";
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Deleted.');", true);
                    //clearall();
                }


            }


        }

        protected void grdcredit_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdcredit, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void grdcredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int refno;
                hid_DebitCredit.Value = "0";
                int debno = 0;
                int debnonew = 0;
                string chknew = "";
                string vou = "";
                if (grdcredit.Rows.Count > 0)
                {
                    strTranType = ddl_product.SelectedValue;
                    if (hid_confirm.Value.ToString() == "")
                    {
                        index = grdcredit.SelectedRow.RowIndex;
                        Session["index"] = index;
                        txtcharge.Text = grdcredit.Rows[index].Cells[2].Text;
                        txtcurr.Text = grdcredit.Rows[index].Cells[3].Text;
                        txtexrate.Text = grdcredit.Rows[index].Cells[5].Text;

                        txtrate.Text = grdcredit.Rows[index].Cells[4].Text;
                        cmbbase.Text = grdcredit.Rows[index].Cells[6].Text;
                        txtamount.Text = grdcredit.Rows[index].Cells[9].Text;
                        ddlDebiteOrCredite.SelectedValue = "6";
                        cmbbl.Text = grdcredit.Rows[index].Cells[1].Text;
                        hdnChargid.Value = grdcredit.Rows[index].Cells[10].Text;
                        chknew = grdcredit.Rows[index].Cells[11].Text;
                        //if (chknew == "Y")
                        //{
                        //    chk_GstApp.Checked = true;
                        //    chk_GstApp.Enabled = false;
                        //}
                        if (string.IsNullOrEmpty(grdcredit.Rows[index].Cells[12].Text) != true)
                        {
                            hid_DebitCredit.Value = grdcredit.Rows[index].Cells[12].Text;
                            debno = Convert.ToInt32(grdcredit.Rows[index].Cells[12].Text);
                            for (int i = 0; i <= grdcredit.Rows.Count - 1; i++)
                            {

                                if (string.IsNullOrEmpty(grdcredit.Rows[i].Cells[12].Text) != true)
                                {
                                    debnonew = Convert.ToInt32(grdcredit.Rows[i].Cells[12].Text);
                                    if (debno == debnonew)
                                    {
                                        chknew = grdcredit.Rows[i].Cells[11].Text;
                                        if (chknew == "Y")
                                        {
                                            chk_GstApp.Checked = true;
                                            //chk_GstApp.Enabled = false;
                                        }


                                    }

                                }

                            }
                        }
                        if (chknew != "Y")
                        {
                            chk_GstApp.Checked = true;
                            //  chk_GstApp.Enabled = true;
                        }
                        //else
                        //{
                        //    chk_GstApp.Checked = false;
                        //    chk_GstApp.Enabled = true;

                        //}
                        if (ddlDebiteOrCredite.SelectedValue == "6")
                        {
                            vou = "C";
                        }

                        txtremarks.Text = DAdvise.GetDCAdviseRemarksOSV(cmbbl.Text, vou, Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]));
                        if (txtremarks.Text.Trim() == "0")
                        {
                            txtremarks.Text = "";
                        }

                        DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), ddl_product.SelectedValue, Convert.ToInt32(Session["LoginDivisionId"]));
                        if (DtBLNO.Rows.Count > 0)
                        {
                            mblno = DtBLNO.Rows[0][0].ToString();
                        }
                        if (cmbbl.SelectedItem.ToString() == mblno)
                        {
                            FGetNoofCont(txtJobno.Text, txtJobno.Text);
                        }
                        else
                        {
                            FGetNoofCont(txtJobno.Text, cmbbl.Text);
                        }
                        cmbbl_SelectedIndexChanged(sender, e);
                        btnAdd.Text = "Update";
                        btnprint.Enabled = true;
                    }


                    if (hid_confirm.Value.ToString() == "N")
                    {
                        hid_confirm.Value = "";
                        return;
                    }

                    else if (hid_confirm.Value.ToString() == "Y")
                    {
                        index = grdcredit.SelectedRow.RowIndex;

                        ddlDebiteOrCredite.SelectedValue = "6";
                        if (grdcredit.Rows[index].Cells[12].Text != "")
                        {
                            refno = Convert.ToInt32(grdcredit.Rows[index].Cells[12].Text);
                        }
                        else
                        {
                            refno = 0;
                        }
                        DAdvise.DelDebitCreditOSV(grdcredit.Rows[index].Cells[1].Text, Convert.ToInt32(grdcredit.Rows[index].Cells[10].Text), grdcredit.Rows[index].Cells[6].Text, 6, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), refno);
                        switch (strTranType)
                        {
                            case "FE":
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grdcredit.Rows[index].Cells[1].Text + "/" + grdcredit.Rows[index].Cells[2].Text + "/" + grdcredit.Rows[index].Cells[12].Text + "/" + grdcredit.Rows[index].Cells[13].Text);
                                break;
                            case "FI":
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grdcredit.Rows[index].Cells[1].Text + "/" + grdcredit.Rows[index].Cells[2].Text + "/" + grdcredit.Rows[index].Cells[12].Text + "/" + grdcredit.Rows[index].Cells[13].Text);
                                break;
                            case "AE":
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grdcredit.Rows[index].Cells[1].Text + "/" + grdcredit.Rows[index].Cells[2].Text + "/" + grdcredit.Rows[index].Cells[12].Text + "/" + grdcredit.Rows[index].Cells[13].Text);
                                break;
                            case "AI":
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grdcredit.Rows[index].Cells[1].Text + "/" + grdcredit.Rows[index].Cells[2].Text + "/" + grdcredit.Rows[index].Cells[12].Text + "/" + grdcredit.Rows[index].Cells[13].Text);
                                break;
                            case "CH":
                                logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString() + Convert.ToString(txtJobno.Text) + "/" + lbl.Text + "/" + grdcredit.Rows[index].Cells[1].Text + "/" + grdcredit.Rows[index].Cells[2].Text + "/" + grdcredit.Rows[index].Cells[12].Text + "/" + grdcredit.Rows[index].Cells[13].Text);
                                break;
                        }
                        grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdcredit.DataBind();
                        GrdLoad(ddlDebiteOrCredite.SelectedValue);
                        if (grdcredit.Rows.Count == 0)
                        {
                            hid_creditDnno.Value = "0";
                        }
                        Clear_Fin();
                        hid_confirm.Value = "";
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Deleted.');", true);
                        // clearall();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        public void clr()
        {
            txt_Agent.Text = "";
            hid_yes.Value = "0";
            hid_No.Value = "0";
            //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            //grdcredit.DataBind();
            //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            //grddebit.DataBind();
            txtrate.Text = "";
            txtremarks.Text = "";
            txtshipment.Text = "";
            txtcustomer.Text = "";
            txtdcn.Text = "";
            txtexrate.Text = "";
            txtDebit.Text = "";
            txtCredit.Text = "";
            txttotal.Text = "";
            ddlDebiteOrCredite.SelectedValue = "0";
            cmbbl.Items.Clear();
            cmbbl.Items.Add("");
            //  cmbbl.SelectedIndex = 0;
            cmbbase.SelectedIndex = 0;
            txtcharge.Text = "";
            //txtyear.Text = Convert.ToInt32(Session["Vouyear"]).ToString();
            txtcurr.Text = "";
            btnAdd.Text = "Add";
            btnprint.Text = "View";
            btnview.Text = "Print";
            btnback.Text = "Back";
            txtJobno.Focus();
            lstcon.Items.Clear();
            txtJobno.Text = "";
            txtamount.Text = "";
            lblGross.Text = "Grand Total:";
            txtclear();
            btnprint.Enabled = true;
            txtVendorRefno.Text = "";
            txtVendorRefnodate.Text = "";
            txtsupplyto.Text = "";
            hid_SupplyTo.Value = "0";
            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;
            btnAdd.Enabled = true;
            btnAdd.ForeColor = System.Drawing.Color.White;
            chk_GstApp.Checked = true;
            //chk_GstApp.Enabled = true;
            hid_DebitCredit.Value = "0";
            hid_creditDnno.Value = "0";
            hid_debitDnno.Value = "0";
            ddlTypes.SelectedValue = "0";
            txt_FcCramt.Text = "";
            txtDebit.Text = "";
            hid_intagent.Value = "0";
            grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            grddebit.DataBind();
            grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            grdcredit.DataBind();

        }
        protected void clearall()
        {
            hid_MoreOne.Value = "";
            //txt_Agent.ReadOnly = false;
            //txtsupplyto.ReadOnly = false;
            txt_Agent.Text = "";
            hid_yes.Value = "0";
            hid_No.Value = "0";
            //grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            //grdcredit.DataBind();
            //grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            //grddebit.DataBind();
            txt_FcDebitamt.Text = "";
            txtrate.Text = "";
            txtremarks.Text = "";
            txtshipment.Text = "";
            txtcustomer.Text = "";
            txtdcn.Text = "";
            txtexrate.Text = "";
            txtDebit.Text = "";
            txtCredit.Text = "";
            txttotal.Text = "";
            ddlDebiteOrCredite.SelectedValue = "0";
            cmbbl.Items.Clear();
            cmbbl.Items.Add("");
            //  cmbbl.SelectedIndex = 0;
            cmbbase.SelectedIndex = 0;
            txtcharge.Text = "";
            //txtyear.Text = Convert.ToInt32(Session["Vouyear"]).ToString();
            txtcurr.Text = "";
            btnAdd.Text = "Add";
            btnprint.Text = "View";
            btnview.Text = "Print";
            btnback.Text = "Back";
            txtJobno.Focus();
            lstcon.Items.Clear();
            txtJobno.Text = "";
            txtamount.Text = "";
            lblGross.Text = "Grand Total:";
            txtclear();
            btnprint.Enabled = true;
            txtVendorRefno.Text = "";
            txtVendorRefnodate.Text = "";
            txtsupplyto.Text = "";
            hid_SupplyTo.Value = "0";
            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;
            btnAdd.Enabled = true;
            btnAdd.ForeColor = System.Drawing.Color.White;
            chk_GstApp.Checked = true;
            //chk_GstApp.Enabled = true;
            hid_DebitCredit.Value = "0";
            hid_creditDnno.Value = "0";
            hid_debitDnno.Value = "0";
            ddlTypes.SelectedValue = "0";
            txt_FcCramt.Text = "";
            txtDebit.Text = "";
            hid_intagent.Value = "0";
            grd_prodetails.DataSource = Utility.Fn_GetEmptyDataTable();
            grd_prodetails.DataBind();
            Grd_Details.DataSource = Utility.Fn_GetEmptyDataTable();
            Grd_Details.DataBind();
            if (txtdcn.Text != "")
            {
                ddlDebiteOrCredite.Enabled = false;
            }
            else
            {
                ddlDebiteOrCredite.Enabled = true;
            }
            txtsupplyto.Text = "";
            txtJobno.Text = "";
            ddl_product.SelectedValue = "0";
        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            if (btnback.Text == "Cancel")
            {
                clearall();
                ddlTypes.Enabled = true;
            }
            else
            {
                // this.Response.End();
                if (Session["Incomenotbooked"] != null)
                {
                    Session["Incomenotbooked"] = null;
                    Response.Redirect("../Sales/IncomeNotbooked.aspx");
                }

                if (Session["home"] != null)
                {
                    if (Session["home"].ToString() == "OPS&DOC")
                    {
                        if (Session["StrTranType"] != null)
                        {
                            if (ddl_product.SelectedValue == "FE")
                            {
                                // headerlable1.InnerText = "OceanExports";
                                if (Request.QueryString.ToString().Contains("app3"))
                                {
                                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                }
                            }
                            else if (ddl_product.SelectedValue == "FI")
                            {
                                if (Request.QueryString.ToString().Contains("appFI3"))
                                {
                                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                }
                            }
                            else if (ddl_product.SelectedValue == "AE")
                            {
                                if (Request.QueryString.ToString().Contains("appAE3"))
                                {
                                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                }
                            }
                            else if (ddl_product.SelectedValue == "AI")
                            {
                                if (Request.QueryString.ToString().Contains("appAI3"))
                                {
                                    Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                }
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
                else
                {
                    this.Response.End();
                }
            }
        }


        protected void btnprint_Click(object sender, EventArgs e)
        {

            DataTable DTRetve = new DataTable();
            string Vouch1 = "", Vouch2 = "";
            int Ref1 = 0, Ref2 = 0;
            if (txtJobno.Text == "")
            {
                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # cannot be blank');", true);
                txtJobno.Focus();
                return;
            }

            Session["str_sfs"] = ""; Session["str_sfs1"] = ""; Session["str_sfs2"] = "";
            Session["str_sp"] = ""; Session["str_sp1"] = ""; Session["str_sp2"] = "";
            DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            strTranType = ddl_product.SelectedValue;
            //   GST_date = Convert.ToDateTime("12/10/2017");
            //**** Temporary i have passed value in str_trantype in "FE" **********//
            // string sp = null;
            string Fcurr = "";
            string Fcurr1 = "";
            //string vou = "";
            DateTime get_date;
            //if (lbl.Text == "Debit Note")
            //{
            //    vou = "OSSI";
            //}
            //else
            //{
            //    vou = "OSPI";
            //}
            //if (vou == "OSSI")
            //{
            Fcurr = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value));
            //}
            // else
            //{
            Fcurr1 = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value));
            // }
            str_sp = "FCurr=" + Fcurr;
            str_sp1 = "FCurr=" + Fcurr1;
            if (!string.IsNullOrEmpty(txtdcn.Text))
            {
                // DTRetve = DAdvise.getCheckosdncnrprOSV(Convert.ToString(strTranType), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                DTRetve = DAdvise.getCheckosdncnrpr4refnoOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtdcn.Text));



                if (DTRetve.Rows.Count > 0)
                {

                    if (strTranType == "FE")
                    {
                        DataView dt_check = DTRetve.DefaultView;
                        dt_check.RowFilter = "type = 'OSSI'";
                        DataTable dtNew_check = dt_check.ToTable();
                        if (dtNew_check.Rows.Count > 0)
                        {

                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                            {
                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Ref1);

                                str_sp = "FCurr=" + Fcurr;
                                str_RptName = "FEProOSDN.rpt";
                                str_sf = "{OSDN.trantype}=\"" + Session["StrTranTypeO"].ToString() + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                //str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }

                        DataView dt_check1 = DTRetve.DefaultView;
                        dt_check1.RowFilter = "type = 'OSPI'";
                        DataTable dtNew_check1 = dt_check1.ToTable();
                        if (dtNew_check1.Rows.Count > 0)
                        {
                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                            for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                            {
                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Ref2);

                                str_sp1 = "FCurr=" + Fcurr;
                                str_RptName = "FEProOSCN.rpt";
                                str_sf = "{OSCN.trantype}=\"" + Session["StrTranTypeO"].ToString() + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                //str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";

                                }
                                else
                                {
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }
                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                    }
                    else if (strTranType == "FI")
                    {
                        DataView dt_check = DTRetve.DefaultView;
                        dt_check.RowFilter = "type = 'OSSI'";
                        DataTable dtNew_check = dt_check.ToTable();
                        // DataTable dtNew_check =new DataTable();
                        //dtNew_check = DAdvise.getCheckosdncnrpr4refno(Convert.ToString(strTranType), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtdcn.Text));

                        if (dtNew_check.Rows.Count > 0)
                        {

                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                            {
                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Ref1);

                                str_sp = "FCurr=" + Fcurr;
                                str_RptName = "FIProOSDN.rpt";
                                str_sf = "{OSDN.trantype}=\"" + Session["StrTranTypeO"].ToString() + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;

                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";

                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }

                        DataView dt_check1 = DTRetve.DefaultView;
                        dt_check1.RowFilter = "type = 'OSPI'";
                        DataTable dtNew_check1 = dt_check1.ToTable();
                        if (dtNew_check1.Rows.Count > 0)
                        {
                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                            for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                            {
                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Ref2);

                                str_sp1 = "FCurr=" + Fcurr;
                                str_RptName = "FIProOSCN.rpt";
                                str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                if (get_date >= GST_date)
                                {

                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";

                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }
                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                    }
                    if (strTranType == "AE")
                    {
                        DataView dt_check = DTRetve.DefaultView;
                        dt_check.RowFilter = "type = 'OSSI'";
                        DataTable dtNew_check = dt_check.ToTable();
                        if (dtNew_check.Rows.Count > 0)
                        {

                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                            {
                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType), 5, Convert.ToInt32(hf_branchid.Value), Ref1);

                                str_sp = "FCurr=" + Fcurr;
                                str_RptName = "AEProOSDN.rpt";
                                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";

                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }

                        DataView dt_check1 = DTRetve.DefaultView;
                        dt_check1.RowFilter = "type = 'OSPI'";
                        DataTable dtNew_check1 = dt_check1.ToTable();
                        if (dtNew_check1.Rows.Count > 0)
                        {
                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                            for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                            {
                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType), 6, Convert.ToInt32(hf_branchid.Value), Ref2);

                                str_sp1 = "FCurr=" + Fcurr;
                                str_RptName = "AEProOSCN.rpt";
                                str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";

                                }
                                else
                                {
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }
                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                    }
                    if (strTranType == "AI")
                    {
                        DataView dt_check = DTRetve.DefaultView;
                        dt_check.RowFilter = "type = 'OSSI'";
                        DataTable dtNew_check = dt_check.ToTable();
                        if (dtNew_check.Rows.Count > 0)
                        {

                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                            {
                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType), 5, Convert.ToInt32(hf_branchid.Value), Ref1);
                                str_sp = "FCurr=" + Fcurr;
                                str_RptName = "AIProOSDN.rpt";
                                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";

                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }

                        DataView dt_check1 = DTRetve.DefaultView;
                        dt_check1.RowFilter = "type = 'OSPI'";
                        DataTable dtNew_check1 = dt_check1.ToTable();
                        if (dtNew_check1.Rows.Count > 0)
                        {
                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                            for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                            {
                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType), 6, Convert.ToInt32(hf_branchid.Value), Ref2);
                                str_sp1 = "FCurr=" + Fcurr;
                                str_RptName = "AIProOSCN.rpt";
                                str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                    Session["OSstring"] = "refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";

                                }
                                else
                                {
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }
                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                    }

                    if (strTranType == "CH")
                    {
                        DataView dt_check = DTRetve.DefaultView;
                        dt_check.RowFilter = "type = 'OSSI'";
                        DataTable dtNew_check = dt_check.ToTable();
                        if (dtNew_check.Rows.Count > 0)
                        {

                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                            {
                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType), 5, Convert.ToInt32(hf_branchid.Value), Ref1);
                                str_sp = "FCurr=" + Fcurr;
                                str_RptName = "AIProOSDN.rpt";
                                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }

                        DataView dt_check1 = DTRetve.DefaultView;
                        dt_check1.RowFilter = "type = 'OSPI'";
                        DataTable dtNew_check1 = dt_check1.ToTable();
                        if (dtNew_check1.Rows.Count > 0)
                        {
                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                            for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                            {
                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType), 6, Convert.ToInt32(hf_branchid.Value), Ref2);
                                str_sp1 = "FCurr=" + Fcurr;
                                str_RptName = "AIProOSCN.rpt";
                                str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                if (get_date >= GST_date)
                                {
                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                }
                                else
                                {
                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                }
                            }

                        }
                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                    }





                }
            }



            else if (string.IsNullOrEmpty(txtdcn.Text) & string.IsNullOrEmpty(txtJobno.Text))
            {
                str_RptName = "Pro OSDN Register.rpt";
                str_sp = "Title=PROFORMA OSDN REGISTER ";
                str_sf = "{ACOSDNPro.trantype}=\"" + Convert.ToString(strTranType) + "\" and {ACOSDNPro.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {ACOSDNPro.vouyear}=" + txtyear.Text;
                str_Script1 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;

                str_RptName1 = "Pro OSCN Register.rpt";

                str_sp1 = "Title^PROFORMA OSCN REGISTER ";
                str_sf1 = "{ACOSCNPro.trantype}='" + Convert.ToString(strTranType) + "' and {ACOSCNPro.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {ACOSCNPro.vouyear}=" + txtyear.Text;

                str_Script2 = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf1 + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName1 + "&" + this.Page.ClientQueryString + "','','');";
                str_Script = str_Script1 + ";" + str_Script2;
                ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                Session["str_sfs1"] = str_sf1;
                Session["str_sp1"] = str_sp1;
            }
        }

        public void InsCostDts()
        {
            strTranType = ddl_product.SelectedValue;
            branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            jobno = Convert.ToInt32(txtJobno.Text);
            string strcharge = "";
            if (damt > camt)
            {

                Dt1 = OSDNCN.GetOSDCNDtlsOSV(jobno, Session["StrTranTypeO"].ToString(), 5, branchid);
                if (Dt1.Rows.Count > 0)
                {
                    vouno = Convert.ToInt32(Dt1.Rows[0][0].ToString());
                    voudate = Convert.ToDateTime(Dt1.Rows[0][1].ToString());
                    intsalesperson = Convert.ToInt32(Dt1.Rows[0][6].ToString());
                }
                Dt = DebitObj.GetDCAdviseOSV(jobno, Session["StrTranTypeO"].ToString(), 5);
                if (Dt.Rows.Count > 0)
                {
                    strblno = Dt.Rows[0][2].ToString();
                    strcharge = Dt.Rows[0][3].ToString();
                    strbase = Dt.Rows[0][7].ToString();
                }


            }

            else
            {

                Dt1 = OSDNCN.GetOSDCNDtlsOSV(jobno, Session["StrTranTypeO"].ToString(), 6, branchid);
                if (Dt1.Rows.Count > 0)
                {
                    vouno = Convert.ToInt32(Dt1.Rows[0][0].ToString());
                    voudate = Convert.ToDateTime(Dt1.Rows[0][1].ToString());
                    intsalesperson = Convert.ToInt32(Dt1.Rows[0][6].ToString());
                }
                Dt = DebitObj.GetDCAdviseOSV(jobno, Session["StrTranTypeO"].ToString(), 6);
                if (Dt.Rows.Count > 0)
                {
                    strblno = Dt.Rows[0][2].ToString();
                    strcharge = Dt.Rows[0][3].ToString();
                    strbase = Dt.Rows[0][7].ToString();
                }


            }

            if (strTranType == "FE")
            {
                Dt1 = FEJobObj.GetFEJobInfo(jobno, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));
                if (Dt1.Rows.Count > 0)
                {
                    jobtype = Convert.ToInt32(Dt1.Rows[0][13].ToString());
                    jobdate = Convert.ToDateTime(Dt1.Rows[0][8].ToString());
                }
                Dt = FEBLObj.GetBLDetails(strblno, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));

                if (Dt.Rows.Count > 0)
                {
                    activity = Dt.Rows[0][34].ToString();
                }
                else
                {
                    activity = "N";
                }
            }
            else if (strTranType == "FI")
            {
                Dt1 = FIJobObj.ShowJobDetails(jobno, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));
                if (Dt1.Rows.Count > 0)
                {
                    jobtype = Convert.ToInt32(Dt1.Rows[0]["jobtype"].ToString());
                    jobdate = Convert.ToDateTime(Dt1.Rows[0]["eta"].ToString());
                }
                Dt = FEBLObj.GetBLDetails(strblno, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));

                if (Dt.Rows.Count > 0)
                {
                    activity = Dt.Rows[0][31].ToString();
                }
                else
                {
                    activity = "N";
                }

            }

            else if (strTranType == "AE" && strTranType == "AI")
            {
                Dt = AIEJobObj.GetAIEDetail(jobno, strTranType, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));
                if (Dt.Rows.Count > 0)
                {
                    jobdate = Convert.ToDateTime(Dt.Rows[0][7].ToString());

                }
                Dt1 = AEBLObj.GetAIEDetail(strblno, strTranType, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));
                if (Dt1.Rows.Count > 0)
                {
                    activity = Dt.Rows[0]["nomination"].ToString();
                }
                else
                {
                    activity = "N";
                }

            }
            else
            {
                activity = "U";
            }
            intsalesperson = OSDNCN.GetSalesID(strblno, Convert.ToInt32(hf_branchid.Value));
            //Getagentid();



        }
        public void Getagentid()
        {
            strTranType = ddl_product.SelectedValue;
            jobno = Convert.ToInt32(txtJobno.Text);
            if (strTranType == "FE" || strTranType == "FI")
            {
                if (strTranType == "FE")
                {
                    Dt = FEJobObj.GetFEJobInfo(jobno, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));
                    if (Dt.Rows.Count > 0)
                    {
                        intagent = Convert.ToInt32(Dt.Rows[0][14].ToString());
                    }
                }
                else
                {
                    Dt = FIJobObj.ShowJobDetails(jobno, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));
                    if (Dt.Rows.Count > 0)
                    {
                        intagent = Convert.ToInt32(Dt.Rows[0][3].ToString());
                    }
                }
            }
            else if (strTranType == "AE" || strTranType == "AI")
            {

                Dt = AIEJobObj.GetAIEDetail(jobno, strTranType, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(hf_divisionid.Value));
                if (Dt.Rows.Count > 0)
                {
                    intagent = Convert.ToInt32(Dt.Rows[0][8].ToString());
                }


            }
            hid_intagent.Value = intagent.ToString();
        }




        protected void txtexrate_TextChanged(object sender, EventArgs e)
        {

            DataAccess.UserPermission userobj = new DataAccess.UserPermission();

            Dtdatenew = Convert.ToDateTime(logobj.GetDate().ToShortDateString());
            if (txtexrate.Text == "")
            {
                return;
            }
            if (txtexrate.Text != "")
            {


                currexrate = INVOICEobj.GetExRate(txtcurr.Text, Dtdatenew, "R", Convert.ToInt32(Session["LoginDivisionId"]));  //Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text))
                if (Convert.ToDouble(txtexrate.Text) < currexrate)
                {
                    txtexrate.Text = INVOICEobj.GetExRate(txtcurr.Text, Dtdatenew, "R", Convert.ToInt32(Session["LoginDivisionId"])).ToString();  //Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text))
                    txtexrate.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Less than Current Exrate Not Allowed');", true);
                    return;
                }

            }



            if (cmbbase.Text != "" && txtcurr.Text != "" && txtcharge.Text != "" && txtrate.Text != "")
            {
                famount = CheckBase(cmbbase.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text)).ToString();
                txtamount.Text = Convert.ToDecimal(famount).ToString("#,0.00");
                btnprint.Focus();
                UserRights();
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
                    dt_list = CustomerObj.GetIndianCustomergstadd(custid);
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
        protected void txtsupplyto_TextChanged(object sender, EventArgs e)
        {
            try
            {



                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = ddl_product.SelectedValue;
                string citysupplyid;
                int int_custid = Convert.ToInt32(hid_SupplyTo.Value);

                if (txtsupplyto.Text != "")
                {
                    int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    citysupplyid = CustomerObj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                    // txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                    DataTable dt_list = new DataTable();


                    if (int_custid != 0)
                    {

                        dt_list = CustomerObj.GetIndianCustomergst(int_custid);
                        if (dt_list.Rows.Count > 0)
                        {
                            if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    // txtsupplytoAddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update  Uinno#  Master Customer);", true);
                                }
                                else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                {
                                    //   txtsupplytoAddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin# Master Customer');", true);
                                }


                                ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            }
                            else
                            {
                                //txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            return;
                        }

                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txtsupplyto, typeof(System.Web.UI.WebControls.Button), "DataFound", "alertify.alert('Select Correct Customer Name');", true);
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

        protected void btnview_Click(object sender, EventArgs e)
        {
            try
            {
                hid_MoreOne.Value = "";
                string Voucher = "";
                int refnonew = 0;
                int crefnonew = 0;
                // int out1 = 0, out2 = 0;
                int refno = 0;
                int cnrefno = 0;
                DateTime dtdate;
                DataTable dtnew = new DataTable();
                // string voutype = "";

                // string Inco = "";
                Session["str_sfs"] = ""; Session["str_sfs1"] = ""; Session["str_sfs2"] = "";
                Session["str_sp"] = ""; Session["str_sp1"] = ""; Session["str_sp2"] = "";
                double actual = 0;
                DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
                DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();

                DataTable Dt = new DataTable();
                int int_djobno;
                int int_cjobno; string str_intdnno = "";
                strTranType = ddl_product.SelectedValue;



                if (txtJobno.Text.ToString() == "")
                {
                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Enter the Job #');", true);
                    return;
                }
                else
                {
                    DataTable DtCHeckNew = new DataTable();
                    DtCHeckNew = OSDNCN.GetCheckcloseUnclose(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), strTranType);
                    //if (DtCHeckNew.Rows.Count > 0)
                    //{
                    //    Clear_Fin();
                    //    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has been already closed.So you cannot add Charges');", true);
                    //    return;
                    //}

                    if (chk_GstApp.Checked == true)
                    {
                        // check = "Y";
                    }
                    else
                    {
                        // check = "N";
                    }

                    if (btnview.Text == "Save")
                    {

                        if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                        {

                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                            bolcuststat = false;
                            txt_Agent.Focus();
                            return;
                        }

                        if (hid_SupplyTo.Value == "0" || hid_SupplyTo.Value == "")
                        {

                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                            bolcuststat = false;
                            txtsupplyto.Focus();
                            return;
                        }


                        dtnew = cus.getcustomerblk(Convert.ToInt32(hid_intagent.Value));
                        if (dtnew.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txt_Agent.Text + " status is Hold please discuss with Finance team ');", true);
                            txt_Agent.Text = "";
                            txt_Agent.Focus();
                            return;
                        }

                        dtnew = cus.getcustomerblk(Convert.ToInt32(hid_SupplyTo.Value));
                        if (dtnew.Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txtsupplyto.Text + " status is Hold please discuss with Finance team ');", true);
                            txtsupplyto.Text = "";
                            txtsupplyto.Focus();
                            return;
                        }





                        if (txtVendorRefno.Text.Trim() == "")
                        {
                            txtVendorRefno.Text = " ";

                        }
                        if (ddlTypes.SelectedValue == "OSPI")
                        {
                            if (txtVendorRefnodate.Text.Trim() == "")
                            {


                                txtVendorRefnodate.Text = Logobj.GetDate().ToShortDateString();
                                txtVendorRefnodate.Text = Utility.fn_ConvertDate(txtVendorRefnodate.Text);

                            }


                        }
                        else
                        {
                            if (txtVendorRefnodate.Text.Trim() == "")
                            {


                                txtVendorRefnodate.Text = Logobj.GetDate().ToShortDateString();
                                txtVendorRefnodate.Text = Utility.fn_ConvertDate(txtVendorRefnodate.Text);

                            }

                        }
                        if (txtsupplyto.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(btnview, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
                            bolcuststat = false;
                            return;
                        }
                        else
                        {



                        }
                        double amt1 = 0;
                        double amt2 = 0;
                        if (grddebit.Rows.Count > 0)
                        {
                            for (int i = 0; i <= grddebit.Rows.Count - 1; i++)
                            {
                                amt1 = amt1 + Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                            }
                        }
                        if (grdcredit.Rows.Count > 0)
                        {
                            for (int i = 0; i <= grdcredit.Rows.Count - 1; i++)
                            {
                                amt2 = amt2 + Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                            }
                        }

                        actual = amt1 + amt2;

                        intagent = Convert.ToInt32(hid_intagent.Value);

                        if (hid_intagent.Value != hid_agentold.Value)
                        {
                            if (txtdcn.Text != "")
                            {
                                da_obj_OSDNCN.UpdateOSDCNagentOSV(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString(), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(hid_SupplyTo.Value), Convert.ToInt32(txtdcn.Text), Convert.ToInt32(hid_intagent.Value));


                            }
                        }


                        if (txtdcn.Text != "")
                        {

                            da_obj_OSDNCN.UpdateOSDCNagentnewOSV(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString(), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txtdcn.Text), txt_origin.Text);




                        }

                        if (strTranType == "FI")
                        {
                            if (da_obj_logobj.GetDate().Month < 4)
                            {
                                vouyear = da_obj_logobj.GetDate().Year - 1;
                            }
                            else
                            {
                                vouyear = da_obj_logobj.GetDate().Year;
                            }
                            dtdate = da_obj_logobj.GetDate();
                            hf_jobno.Value = txtJobno.Text;



                            DataTable dtNewCount = new DataTable();
                            dtNewCount = da_obj_OSDNCN.GetOSNDCSumAmntmultipleNewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value));

                            if (dtNewCount.Rows.Count > 0)
                            {
                                for (int i = 0; i <= dtNewCount.Rows.Count - 1; i++)
                                {


                                    if (dtNewCount.Rows[i][2].ToString() == "Debit")
                                    {
                                        Voucher = "Debit";
                                        damount = dtNewCount.Rows[i][0].ToString();
                                        refnonew = Convert.ToInt32(dtNewCount.Rows[i][1].ToString());
                                    }

                                    if (dtNewCount.Rows[i][2].ToString() == "Credit")
                                    {
                                        Voucher = "Credit";
                                        camount = dtNewCount.Rows[i][0].ToString();
                                        crefnonew = Convert.ToInt32(dtNewCount.Rows[i][1].ToString());
                                    }

                                    int_djobno = da_obj_OSDNCN.GetOSDCNProJobCountOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    int_cjobno = da_obj_OSDNCN.GetOSDCNProJobCountOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    damt = Convert.ToDouble(damount);
                                    camt = Convert.ToDouble(camount);

                                    amount = damt;
                                    if (damt > 0)
                                    {
                                        if (int_djobno > 0)
                                        {
                                            if (Voucher == "Debit")
                                            {


                                                DataTable dt_Dt = new DataTable();

                                                dt_Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"]));

                                                if (grddebit.Rows.Count > 0)
                                                {

                                                    for (int j = 0; j <= grddebit.Rows.Count - 1; j++)
                                                    {

                                                        if (string.IsNullOrEmpty(grddebit.Rows[j].Cells[12].Text) != true)
                                                        {
                                                            // add ref no

                                                            if (refnonew == Convert.ToInt32(grddebit.Rows[j].Cells[12].Text))
                                                            {
                                                                da_obj_OSDNCN.UpdateOSDCNProGstOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToDouble(amount), Convert.ToDateTime(dtdate), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), Convert.ToInt32(intagent));

                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), txtremarks.Text);
                                                                //Edited

                                                                hid_debitDnno.Value = refnonew.ToString();
                                                                txtdcn.Text = grddebit.Rows[j].Cells[12].Text;
                                                            }

                                                            //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro Debit Note Updated " + "DNNo" + "=" + txtdcn.Text + "');", true);
                                                        }
                                                        else
                                                        {
                                                            if (refnonew == 0 && grddebit.Rows[j].Cells[12].Text == "")
                                                            {
                                                                // get idenety field
                                                                refno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount), Convert.ToInt32(hf_jobno.Value),
                                                                    Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear),
                                                                    txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue));
                                                                ProINVobj.UpdAfterjobclose(refno, Convert.ToInt32(Session["LoginBranchid"]), 5, "Proforma");
                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), refno, txtremarks.Text);
                                                                //Edited

                                                                //  str_intdnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                                //DAdvise.InsForAcdebiteadviseDtls(Convert.ToInt32(refno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                                //debit grd load
                                                                txtdcn.Text = refno.ToString();
                                                                hid_debitDnno.Value = refno.ToString();
                                                                GrdLoadNew(hid_debitDnno.Value);
                                                            }
                                                        }
                                                    }
                                                }
                                                if (refno != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Updated " + "DNNo" + "=" + refno + "');", true);
                                                }
                                                if (refnonew != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Updated " + "DNNo" + "=" + refnonew + "');", true);
                                                }


                                                //voutype = "OSSI";
                                                InsCostDts();
                                            }
                                        }
                                        else
                                        {
                                            if (Voucher == "Debit")
                                            {
                                                refno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 5);
                                                ProINVobj.UpdAfterjobclose(refno, Convert.ToInt32(Session["LoginBranchid"]), 5, "Proforma");
                                                //Edited
                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), refno, txtremarks.Text);
                                                //Edited

                                                txtdcn.Text = refno.ToString();

                                                // str_intdnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                //   DAdvise.InsForAcdebiteadviseDtls(Convert.ToInt32(refno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert(' Pro Debit Note Saved " + "Ref No" + "=" + refno + "');", true);
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert(' Pro OSDN Saved " + "Ref No" + "=" + refno + "')", true);
                                                lbl.Text = "Debit Note";
                                                hid_debitDnno.Value = refno.ToString();
                                                GrdLoadNew(hid_debitDnno.Value);
                                                //voutype = "OSSI";
                                                InsCostDts();
                                                //  da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);


                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "FI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "AE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "AI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "CH":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                }

                                            }
                                        }
                                    }

                                    if (camt > 0)
                                    {
                                        amount = camt;
                                        if (int_cjobno > 0)
                                        {
                                            if (Voucher == "Credit")
                                            {
                                                //intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));

                                                Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), 6, Convert.ToInt32(Session["LoginBranchid"]));

                                                // da_obj_OSDNCN.UpdateOSDCNProGstOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToDouble(amount), Convert.ToDateTime(dtdate), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value));
                                                if (grdcredit.Rows.Count > 0)
                                                {
                                                    for (int j = 0; j <= grdcredit.Rows.Count - 1; j++)
                                                    {
                                                        if (string.IsNullOrEmpty(grdcredit.Rows[j].Cells[12].Text) != true)
                                                        {

                                                            if (crefnonew == Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text))
                                                            {
                                                                da_obj_OSDNCN.UpdateOSDCNProGstOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToDouble(amount), Convert.ToDateTime(dtdate), 
                                                                    Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString(), 6,
                                                                    Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value),
                                                                    Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), Convert.ToInt32(intagent));
                                                                ProINVobj.UpdAfterjobclose(Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text), Convert.ToInt32(Session["LoginBranchid"]), 6, "Proforma");
                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text), txtremarks.Text);
                                                                //Edited

                                                                txtdcn.Text = grdcredit.Rows[j].Cells[12].Text;
                                                                hid_creditDnno.Value = crefnonew.ToString();
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (crefnonew == 0 && grdcredit.Rows[j].Cells[12].Text == "")
                                                            {

                                                                cnrefno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 6);
                                                                ProINVobj.UpdAfterjobclose(cnrefno, Convert.ToInt32(Session["LoginBranchid"]), 6, "Proforma");
                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), cnrefno, txtremarks.Text);
                                                                //Edited

                                                                //intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));
                                                                //DAdvise.InsForAcCrediteadviseDtls(Convert.ToInt32(cnrefno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                                txtdcn.Text = cnrefno.ToString();
                                                                hid_creditDnno.Value = cnrefno.ToString();
                                                                GrdLoadNew(hid_creditDnno.Value);



                                                            }
                                                        }
                                                    }
                                                }
                                                if (crefnonew != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Updated " + "Ref No" + "=" + crefnonew + "');", true);
                                                }
                                                if (cnrefno != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Updated " + "Ref No" + "=" + cnrefno + "');", true);
                                                }

                                                lbl.Text = "Credit Note";
                                                // txtdcn.Text = intcnno.ToString();
                                                //voutype = "OSPI";
                                                InsCostDts();
                                                //  da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":

                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "FI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "AE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "AI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "CH":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            if (Voucher == "Credit")
                                            {

                                                cnrefno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 6);


                                                //Edited
                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), cnrefno, txtremarks.Text);
                                                //Edited

                                                // intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));
                                                // DAdvise.InsForAcCrediteadviseDtls(Convert.ToInt32(cnrefno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                txtdcn.Text = cnrefno.ToString();
                                                hid_creditDnno.Value = cnrefno.ToString();
                                                //ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro Credit Note Saved " + "Ref No" + "=" + cnrefno + "');", true);
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Pro OSCN Saved " + "Ref No" + "=" + cnrefno + "')", true);


                                                lbl.Text = "Credit Note";

                                                // voutype = "OSPI";
                                                InsCostDts();
                                                GrdLoadNew(hid_creditDnno.Value);
                                                //da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":

                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "FI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "AE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "AI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "CH":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                }

                                            }
                                        }

                                    }
                                    int deb = 0;
                                    int cre = 0;
                                    DataTable dt1 = new DataTable();
                                    DataTable dt2 = new DataTable();
                                    //  string arun = "";
                                    dtDeelete = DAdvise.GetCheckosdncndeleteOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    if (dtDeelete.Tables.Count > 0)
                                    {
                                        dt1 = dtDeelete.Tables[0];
                                        deb = Convert.ToInt32(dt1.Rows[0][0].ToString());
                                        dt2 = dtDeelete.Tables[1];
                                        cre = Convert.ToInt32(dt2.Rows[0][0].ToString());
                                    }


                                    if (deb == 0)
                                    {
                                        Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"]));
                                        if (Dt.Rows.Count != 0)
                                        {
                                            cnno = Convert.ToInt32(Dt.Rows[0]["refno"].ToString());
                                        }
                                        da_obj_OSDNCN.DelOSDCNPronewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value), cnno);
                                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Deleted');", true);
                                        // da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value));
                                        switch (ddl_product.SelectedValue)
                                        {
                                            case "FE":

                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "FI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "CH":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                        }
                                    }
                                    else if (cre == 0)
                                    {
                                        Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(Session["LoginBranchid"]));
                                        if (Dt.Rows.Count != 0)
                                        {
                                            cnno = Convert.ToInt32(Dt.Rows[0]["refno"].ToString());
                                        }
                                        da_obj_OSDNCN.DelOSDCNPronewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value), cnno);
                                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Deleted');", true);
                                        // da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value));

                                        switch (ddl_product.SelectedValue)
                                        {
                                            case "FE":

                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "FI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "CH":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                        }
                                    }

                                    //}
                                }

                                DataTable DTRetve = new DataTable();
                                string Vouch1 = "", Vouch2 = "";
                                int Ref2 = 0, Ref1 = 0;
                                string Fcurr = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value));

                                string Fcurr1 = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value));
                                str_sp = "FCurr=" + Fcurr;
                                str_sp1 = "FCurr=" + Fcurr1;

                                if (!string.IsNullOrEmpty(txtdcn.Text))
                                {
                                    DTRetve = DAdvise.getCheckosdncnrprOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));


                                    if (DTRetve.Rows.Count > 0)
                                    {
                                        if (strTranType == "FI")
                                        {

                                            DataView dt_check = DTRetve.DefaultView;
                                            dt_check.RowFilter = "type = 'OSSI'";
                                            DataTable dtNew_check = dt_check.ToTable();
                                            if (dtNew_check.Rows.Count > 0)
                                            {

                                                for (int i = 0; i < dtNew_check.Rows.Count; i++)
                                                {
                                                    Vouch1 = dtNew_check.Rows[i][1].ToString();
                                                    Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                                    get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                                    Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Ref1);

                                                    str_sp = "FCurr=" + Fcurr;
                                                    str_RptName = "FIProOSDN.rpt";
                                                    str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                                    // str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                                    if (get_date >= GST_date)
                                                    {
                                                        str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                                    }
                                                    else
                                                    {
                                                        str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                    }

                                                }

                                            }

                                            DataView dt_check1 = DTRetve.DefaultView;
                                            dt_check1.RowFilter = "type = 'OSPI'";
                                            DataTable dtNew_check1 = dt_check1.ToTable();
                                            if (dtNew_check1.Rows.Count > 0)
                                            {
                                                //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                                                //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                                                for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                                                {
                                                    Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                                    Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                                    get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                                    Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Ref2);

                                                    str_sp1 = "FCurr=" + Fcurr;
                                                    str_RptName = "FIProOSCN.rpt";
                                                    str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                                    //str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                    if (get_date >= GST_date)
                                                    {
                                                        str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + strTranType + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                                    }
                                                    else
                                                    {
                                                        str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                    }

                                                }

                                            }
                                            ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                                        }
                                    }

                                }




                            }

                        }

                        else if (strTranType == "FE")
                        {
                            if (da_obj_logobj.GetDate().Month < 4)
                            {
                                vouyear = da_obj_logobj.GetDate().Year - 1;
                            }
                            else
                            {
                                vouyear = da_obj_logobj.GetDate().Year;
                            }
                            dtdate = da_obj_logobj.GetDate();
                            hf_jobno.Value = txtJobno.Text;


                            DataTable dtNewCount = new DataTable();
                            dtNewCount = da_obj_OSDNCN.GetOSNDCSumAmntmultipleNewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value));

                            if (dtNewCount.Rows.Count > 0)
                            {
                                for (int i = 0; i <= dtNewCount.Rows.Count - 1; i++)
                                {

                                    if (dtNewCount.Rows[i][2].ToString() == "Debit")
                                    {
                                        Voucher = "Debit";

                                        damount = dtNewCount.Rows[i][0].ToString();
                                        refnonew = Convert.ToInt32(dtNewCount.Rows[i][1].ToString());
                                    }

                                    if (dtNewCount.Rows[i][2].ToString() == "Credit")
                                    {
                                        Voucher = "Credit";
                                        camount = dtNewCount.Rows[i][0].ToString();
                                        crefnonew = Convert.ToInt32(dtNewCount.Rows[i][1].ToString());
                                    }



                                    int_djobno = da_obj_OSDNCN.GetOSDCNProJobCountOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    int_cjobno = da_obj_OSDNCN.GetOSDCNProJobCountOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    //if (damount == "0" && camount == "0")
                                    //{
                                    //    da_obj_OSDNCN.DelOSDCNPro(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    //    da_obj_OSDNCN.DelOSDCNPro(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    //    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Both Pro Debit and Pro Credit Amount BLANK #');", true);

                                    //}
                                    //else if (damount == camount)
                                    //{
                                    //    da_obj_OSDNCN.DelOSDCNPro(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    //    da_obj_OSDNCN.DelOSDCNPro(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    //    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Both Pro Debit and Pro Credit Amount Same');", true);
                                    //}
                                    //else
                                    //{
                                    damt = Convert.ToDouble(damount);
                                    camt = Convert.ToDouble(camount);

                                    amount = damt;
                                    if (damt > 0)
                                    {
                                        if (int_djobno > 0)
                                        {
                                            if (Voucher == "Debit")
                                            {
                                                DataTable dt_Dt = new DataTable();
                                                //hf_intdnno.Value = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                // str_intdnno = hf_intdnno.Value;

                                                if (grddebit.Rows.Count > 0)
                                                {

                                                    for (int j = 0; j <= grddebit.Rows.Count - 1; j++)
                                                    {

                                                        if (string.IsNullOrEmpty(grddebit.Rows[j].Cells[12].Text) != true)
                                                        {

                                                            if (refnonew == Convert.ToInt32(grddebit.Rows[j].Cells[12].Text))
                                                            {
                                                                da_obj_OSDNCN.UpdateOSDCNProGstOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToDouble(amount), Convert.ToDateTime(dtdate), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), Convert.ToInt32(intagent));
                                                                ProINVobj.UpdAfterjobclose(Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), Convert.ToInt32(Session["LoginBranchid"]), 5, "Proforma");
                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), txtremarks.Text);
                                                                //Edited

                                                                txtdcn.Text = grddebit.Rows[j].Cells[12].Text;
                                                                hid_debitDnno.Value = refnonew.ToString();
                                                            }


                                                        }
                                                        else
                                                        {
                                                            if (refnonew == 0 && grddebit.Rows[j].Cells[12].Text == "")
                                                            {
                                                                refno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 5);
                                                                ProINVobj.UpdAfterjobclose(refno, Convert.ToInt32(Session["LoginBranchid"]), 5, "Proforma");
                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), refno, txtremarks.Text);
                                                                //Edited

                                                                // str_intdnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                                // DAdvise.InsForAcdebiteadviseDtls(Convert.ToInt32(refno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                                txtdcn.Text = refno.ToString();
                                                                hid_debitDnno.Value = refno.ToString();
                                                                GrdLoadNew(hid_debitDnno.Value);
                                                            }
                                                        }
                                                    }
                                                }
                                                dt_Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"]));


                                                if (refnonew != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Updated " + "DNNo" + "=" + refnonew + "');", true);
                                                }
                                                if (refno != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Updated " + "DNNo" + "=" + refno + "');", true);
                                                }

                                                // txtdcn.Text = str_intdnno;
                                                //voutype = "OSSI";
                                                InsCostDts();
                                            }
                                        }
                                        else
                                        {
                                            if (Voucher == "Debit")
                                            {
                                                refno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 5);
                                                ProINVobj.UpdAfterjobclose(refno, Convert.ToInt32(Session["LoginBranchid"]), 5, "Proforma");
                                                //Edited
                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), refno, txtremarks.Text);
                                                //Edited

                                                //  str_intdnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                // DAdvise.InsForAcdebiteadviseDtls(Convert.ToInt32(refno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                txtdcn.Text = refno.ToString();
                                                hid_debitDnno.Value = refno.ToString();
                                                // ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert(' Pro Debit Note Saved " + "Ref No" + "=" + refno + "');", true);
                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert(' Pro OSDN Saved " + "Ref No" + "=" + refno + "')", true);


                                                lbl.Text = "Debit Note";
                                                GrdLoadNew(hid_debitDnno.Value);
                                                // txtdcn.Text = str_intdnno;
                                                //voutype = "OSSI";
                                                InsCostDts();
                                                //   da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                        break;
                                                    case "FI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                        break;
                                                    case "AE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                        break;
                                                    case "AI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                        break;
                                                    case "CH":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                        break;
                                                }

                                            }
                                        }
                                    }

                                    if (camt > 0)
                                    {
                                        amount = camt;
                                        if (int_cjobno > 0)
                                        {
                                            if (Voucher == "Credit")
                                            {
                                                // intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));

                                                // Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));


                                                if (grdcredit.Rows.Count > 0)
                                                {
                                                    for (int j = 0; j <= grdcredit.Rows.Count - 1; j++)
                                                    {
                                                        if (string.IsNullOrEmpty(grdcredit.Rows[j].Cells[12].Text) != true)
                                                        {

                                                            if (crefnonew == Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text))
                                                            {
                                                                da_obj_OSDNCN.UpdateOSDCNProGstOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToDouble(amount), Convert.ToDateTime(dtdate), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), Convert.ToInt32(intagent));
                                                                ProINVobj.UpdAfterjobclose(Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), "Proforma");
                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text), txtremarks.Text);
                                                                //Edited

                                                                txtdcn.Text = grdcredit.Rows[j].Cells[12].Text;
                                                                hid_creditDnno.Value = crefnonew.ToString();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (crefnonew == 0 && grdcredit.Rows[j].Cells[12].Text == "")
                                                            {
                                                                cnrefno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 6);
                                                                ProINVobj.UpdAfterjobclose(cnrefno, Convert.ToInt32(Session["LoginBranchid"]), 6, "Proforma");


                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), cnrefno, txtremarks.Text);
                                                                //Edited

                                                                // intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));
                                                                // DAdvise.InsForAcCrediteadviseDtls(Convert.ToInt32(cnrefno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                                txtdcn.Text = cnrefno.ToString();
                                                                hid_creditDnno.Value = cnrefno.ToString();
                                                                GrdLoadNew(hid_creditDnno.Value);
                                                            }
                                                        }
                                                    }
                                                }
                                                if (crefnonew != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Updated " + "Ref No" + "=" + crefnonew + "');", true);
                                                }
                                                if (cnrefno != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Updated " + "Ref No" + "=" + cnrefno + "');", true);
                                                }

                                                lbl.Text = "Credit Note";
                                                // txtdcn.Text = intcnno.ToString();
                                                //voutype = "OSPI";
                                                InsCostDts();
                                                // da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);

                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "FI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "AE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "AI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                    case "CH":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                                        break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Voucher == "Credit")
                                            {
                                                cnrefno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 6);
                                                ProINVobj.UpdAfterjobclose(cnrefno, Convert.ToInt32(Session["LoginBranchid"]), 6, "Proforma");

                                                //Edited
                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), cnrefno, txtremarks.Text);
                                                //Edited

                                                // intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));
                                                // DAdvise.InsForAcCrediteadviseDtls(Convert.ToInt32(cnrefno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                txtdcn.Text = cnrefno.ToString();
                                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Saved " + "Ref No" + "=" + cnrefno + "');", true);

                                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "alertify.alert('Pro OSCN Saved " + "Ref No" + "=" + cnrefno + "')", true);


                                                lbl.Text = "Credit Note";
                                                hid_creditDnno.Value = cnrefno.ToString();
                                                //voutype = "OSPI";
                                                InsCostDts();
                                                GrdLoadNew(hid_creditDnno.Value);
                                                // da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":

                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "FI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "AE":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "AI":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                    case "CH":
                                                        da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    int deb = 0;
                                    int cre = 0;
                                    DataTable dt1 = new DataTable();
                                    DataTable dt2 = new DataTable();
                                    // string arun = "";
                                    dtDeelete = DAdvise.GetCheckosdncndeleteOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    if (dtDeelete.Tables.Count > 0)
                                    {
                                        dt1 = dtDeelete.Tables[0];
                                        deb = Convert.ToInt32(dt1.Rows[0][0].ToString());
                                        dt2 = dtDeelete.Tables[1];
                                        cre = Convert.ToInt32(dt2.Rows[0][0].ToString());
                                    }
                                    if (deb == 0)
                                    {
                                        Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"]));
                                        if (Dt.Rows.Count != 0)
                                        {
                                            cnno = Convert.ToInt32(Dt.Rows[0]["refno"].ToString());
                                        }
                                        da_obj_OSDNCN.DelOSDCNPronewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value), cnno);
                                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Deleted');", true);
                                        //   da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value));
                                        switch (ddl_product.SelectedValue)
                                        {
                                            case "FE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "FI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "CH":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                        }
                                    }
                                    else if (cre == 0)
                                    {
                                        Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(Session["LoginBranchid"]));
                                        if (Dt.Rows.Count != 0)
                                        {
                                            cnno = Convert.ToInt32(Dt.Rows[0]["refno"].ToString());
                                        }
                                        da_obj_OSDNCN.DelOSDCNPronewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value), cnno);
                                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Deleted');", true);
                                        // da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value));

                                        switch (ddl_product.SelectedValue)
                                        {
                                            case "FE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "FI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "CH":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                        }
                                    }

                                    //}
                                }

                            }
                            // ;
                            DataTable DTRetve = new DataTable();
                            string Vouch1 = "", Vouch2 = "";
                            int Ref2 = 0, Ref1 = 0;
                            string Fcurr = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value));

                            string Fcurr1 = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value));
                            str_sp = "FCurr=" + Fcurr;
                            str_sp1 = "FCurr=" + Fcurr1;

                            if (!string.IsNullOrEmpty(txtdcn.Text))
                            {
                                DTRetve = DAdvise.getCheckosdncnrprOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));


                                if (DTRetve.Rows.Count > 0)
                                {

                                    if (strTranType == "FE")
                                    {
                                        DataView dt_check = DTRetve.DefaultView;
                                        dt_check.RowFilter = "type = 'OSSI'";
                                        DataTable dtNew_check = dt_check.ToTable();
                                        if (dtNew_check.Rows.Count > 0)
                                        {

                                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                                            {

                                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Ref1);

                                                str_sp = "FCurr=" + Fcurr;
                                                str_RptName = "FEProOSDN.rpt";
                                                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                                //str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                                if (get_date >= GST_date)
                                                {
                                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                                }
                                                else
                                                {
                                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                }

                                            }

                                        }

                                        DataView dt_check1 = DTRetve.DefaultView;
                                        dt_check1.RowFilter = "type = 'OSPI'";
                                        DataTable dtNew_check1 = dt_check1.ToTable();
                                        if (dtNew_check1.Rows.Count > 0)
                                        {
                                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                                            for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                                            {

                                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Ref2);

                                                str_sp1 = "FCurr=" + Fcurr;
                                                str_RptName = "FEProOSCN.rpt";
                                                str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                                //str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                if (get_date >= GST_date)
                                                {
                                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                                }
                                                else
                                                {
                                                    str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                }

                                            }

                                        }
                                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                                    }
                                }
                            }
                            GrdLoad(ddlDebiteOrCredite.SelectedValue);
                        }

                        else
                        {
                            if (da_obj_logobj.GetDate().Month < 4)
                            {
                                vouyear = da_obj_logobj.GetDate().Year - 1;
                            }
                            else
                            {
                                vouyear = da_obj_logobj.GetDate().Year;
                            }
                            dtdate = da_obj_logobj.GetDate();
                            hf_jobno.Value = txtJobno.Text;


                            DataTable dtNewCount = new DataTable();
                            dtNewCount = da_obj_OSDNCN.GetOSNDCSumAmntmultipleNewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value));

                            if (dtNewCount.Rows.Count > 0)
                            {
                                for (int i = 0; i <= dtNewCount.Rows.Count - 1; i++)
                                {


                                    if (dtNewCount.Rows[i][2].ToString() == "Debit")
                                    {
                                        Voucher = "Debit";
                                        damount = dtNewCount.Rows[i][0].ToString();
                                        refnonew = Convert.ToInt32(dtNewCount.Rows[i][1].ToString());
                                    }

                                    if (dtNewCount.Rows[i][2].ToString() == "Credit")
                                    {
                                        Voucher = "Credit";
                                        camount = dtNewCount.Rows[i][0].ToString();
                                        crefnonew = Convert.ToInt32(dtNewCount.Rows[i][1].ToString());
                                    }

                                    int_djobno = da_obj_OSDNCN.GetOSDCNProJobCountOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"].ToString()));
                                    int_cjobno = da_obj_OSDNCN.GetOSDCNProJobCountOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    damt = Convert.ToDouble(damount);
                                    camt = Convert.ToDouble(camount);

                                    amount = damt;
                                    if (damt > 0)
                                    {
                                        if (int_djobno > 0)
                                        {
                                            if (Voucher == "Debit")
                                            {
                                                DataTable dt_Dt = new DataTable();
                                                // hf_intdnno.Value = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                // str_intdnno = hf_intdnno.Value;
                                                dt_Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"]));


                                                if (grddebit.Rows.Count > 0)
                                                {
                                                    for (int j = 0; j <= grddebit.Rows.Count - 1; j++)
                                                    {
                                                        if (string.IsNullOrEmpty(grddebit.Rows[j].Cells[12].Text) != true)
                                                        {
                                                            if (refnonew == Convert.ToInt32(grddebit.Rows[j].Cells[12].Text))
                                                            {
                                                                da_obj_OSDNCN.UpdateOSDCNProGstOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToDouble(amount), Convert.ToDateTime(dtdate),
                                                                    Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(),
                                                                    actual, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()),
                                                                    Convert.ToInt32(intagent));

                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(grddebit.Rows[j].Cells[12].Text), txtremarks.Text);
                                                                //Edited

                                                                txtdcn.Text = grddebit.Rows[j].Cells[12].Text;
                                                                hid_debitDnno.Value = refnonew.ToString();
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (refnonew == 0 && grddebit.Rows[j].Cells[12].Text == "")
                                                            {
                                                                refno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 5);

                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), refno, txtremarks.Text);
                                                                //Edited

                                                                // str_intdnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                                //DAdvise.InsForAcdebiteadviseDtls(Convert.ToInt32(refno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));

                                                                hid_debitDnno.Value = refno.ToString();
                                                                txtdcn.Text = refno.ToString();
                                                                GrdLoadNew(hid_debitDnno.Value);
                                                            }
                                                        }
                                                    }
                                                }


                                                if (refnonew != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Updated " + "DNNo" + "=" + refnonew + "');", true);
                                                }
                                                if (refno != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Updated " + "DNNo" + "=" + refno + "');", true);
                                                }


                                                if (strTranType == "AE")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                else if (strTranType == "AI")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                else if (strTranType == "CH")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                //txtdcn.Text = str_intdnno;
                                                //voutype = "OSSI";
                                                InsCostDts();
                                            }
                                        }
                                        else
                                        {
                                            if (Voucher == "Debit")
                                            {
                                                refno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent), Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 5);

                                                //Edited
                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), refno, txtremarks.Text);
                                                //Edited

                                                //  str_intdnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSSI", Convert.ToInt32(Session["LoginBranchid"])).ToString();
                                                // DAdvise.InsForAcdebiteadviseDtls(Convert.ToInt32(refno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                txtdcn.Text = refno.ToString();
                                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert(' Pro OSDN Saved " + "Ref No" + "=" + refnonew + "');", true);
                                                lbl.Text = "Debit Note";
                                                hid_debitDnno.Value = refno.ToString();
                                                GrdLoadNew(hid_debitDnno.Value);
                                                //voutype = "OSSI";
                                                InsCostDts();
                                                if (strTranType == "AE")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                else if (strTranType == "AI")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }

                                                else if (strTranType == "CH")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }// da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                            }
                                        }
                                    }

                                    if (camt > 0)
                                    {
                                        amount = camt;
                                        if (int_cjobno > 0)
                                        {
                                            if (Voucher == "Credit")
                                            {
                                                //intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));

                                                Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), 6, Convert.ToInt32(Session["LoginBranchid"]));

                                                if (grdcredit.Rows.Count > 0)
                                                {
                                                    for (int j = 0; j <= grdcredit.Rows.Count - 1; j++)
                                                    {

                                                        if (string.IsNullOrEmpty(grdcredit.Rows[j].Cells[12].Text) != true)
                                                        {
                                                            if (crefnonew == Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text))
                                                            {
                                                                da_obj_OSDNCN.UpdateOSDCNProGstOSV(Convert.ToInt32(hf_jobno.Value), Convert.ToDouble(amount), Convert.ToDateTime(dtdate), Convert.ToInt32(Session["LoginBranchid"]),
                                                                    Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual, Convert.ToInt32(hid_SupplyTo.Value), Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), Convert.ToInt32(intagent));

                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), Convert.ToInt32(grdcredit.Rows[j].Cells[12].Text), txtremarks.Text);
                                                                //Edited

                                                                txtdcn.Text = grdcredit.Rows[j].Cells[12].Text;
                                                                hid_creditDnno.Value = crefnonew.ToString();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (crefnonew == 0 && grdcredit.Rows[j].Cells[12].Text == "")
                                                            {
                                                                cnrefno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 6);

                                                                //Edited
                                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), cnrefno, txtremarks.Text);
                                                                //Edited

                                                                // intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));
                                                                //DAdvise.InsForAcCrediteadviseDtls(Convert.ToInt32(cnrefno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                                txtdcn.Text = cnrefno.ToString();
                                                                hid_creditDnno.Value = cnrefno.ToString();
                                                                GrdLoadNew(hid_creditDnno.Value);
                                                            }
                                                        }

                                                    }
                                                }

                                                if (crefnonew != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Updated " + "Ref No" + "=" + crefnonew + "');", true);

                                                }
                                                if (cnrefno != 0)
                                                {
                                                    ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Updated " + "Ref No" + "=" + cnrefno + "');", true);
                                                }



                                                lbl.Text = "Credit Note";
                                                //  txtdcn.Text = intcnno.ToString();
                                                //voutype = "OSPI";
                                                if (strTranType == "AE")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                else if (strTranType == "AI")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                else if (strTranType == "CH")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                InsCostDts();
                                            } // da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + ddlDebiteOrCredite.SelectedValue);
                                        }
                                        else
                                        {
                                            if (Voucher == "Credit")
                                            {
                                                cnrefno = da_obj_OSDNCN.InsertOSDNCNProForGstOSV(Convert.ToDateTime(dtdate), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                                    Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(intagent),
                                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(vouyear), txtVendorRefno.Text.ToUpper(), actual,
                                                    Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), 6);

                                                //Edited
                                                da_obj_OSDNCN.InsertOSDNProForGst_remarksOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(hf_jobno.Value), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(vouyear), cnrefno, txtremarks.Text);
                                                //Edited

                                                // intcnno = da_obj_OSDNCN.GetOSDCNPronumber(Convert.ToInt32(hf_jobno.Value), Convert.ToString(strTranType), "OSPI", Convert.ToInt32(Session["LoginBranchid"]));
                                                // DAdvise.InsForAcCrediteadviseDtls(Convert.ToInt32(cnrefno), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType));
                                                txtdcn.Text = cnrefno.ToString();
                                                ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Saved " + "Ref No" + "=" + crefnonew + "');", true);
                                                lbl.Text = "Credit Note";
                                                hid_creditDnno.Value = cnrefno.ToString();
                                                //voutype = "OSPI";
                                                GrdLoadNew(hid_creditDnno.Value);
                                                InsCostDts();
                                                if (strTranType == "AE")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                else if (strTranType == "AI")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                else if (strTranType == "CH")
                                                {
                                                    da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);
                                                }
                                                //   da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value) + "/" + lbl.Text);

                                            }

                                        }
                                    }
                                    int deb = 0;
                                    int cre = 0;
                                    DataTable dt1 = new DataTable();
                                    DataTable dt2 = new DataTable();
                                    // string arun = "";
                                    dtDeelete = DAdvise.GetCheckosdncndeleteOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()));

                                    if (dtDeelete.Tables.Count > 0)
                                    {
                                        dt1 = dtDeelete.Tables[0];
                                        deb = Convert.ToInt32(dt1.Rows[0][0].ToString());
                                        dt2 = dtDeelete.Tables[1];
                                        cre = Convert.ToInt32(dt2.Rows[0][0].ToString());
                                    }


                                    if (deb == 0)
                                    {
                                        Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(Session["LoginBranchid"]));
                                        if (Dt.Rows.Count != 0)
                                        {
                                            cnno = Convert.ToInt32(Dt.Rows[0]["refno"].ToString());
                                        }
                                        da_obj_OSDNCN.DelOSDCNPronewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value), cnno);
                                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSDN Deleted');", true);
                                        //da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value));

                                        switch (ddl_product.SelectedValue)
                                        {
                                            case "FE":

                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "FI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "CH":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                        }
                                    }
                                    else if (cre == 0)
                                    {
                                        Dt = da_obj_OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(Session["LoginBranchid"]));
                                        if (Dt.Rows.Count != 0)
                                        {
                                            cnno = Convert.ToInt32(Dt.Rows[0]["refno"].ToString());
                                        }
                                        da_obj_OSDNCN.DelOSDCNPronewOSV(Convert.ToInt32(hf_jobno.Value), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(vouyear), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(hid_intagent.Value), cnno);
                                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DataFound", "alertify.alert('Pro OSCN Deleted');", true);
                                        //da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToString(hf_jobno.Value));

                                        switch (ddl_product.SelectedValue)
                                        {
                                            case "FE":

                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1015, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "FI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1022, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AE":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1029, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "AI":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1036, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                            case "CH":
                                                da_obj_logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 1969, 4, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(hf_jobno.Value));
                                                break;
                                        }
                                    }
                                }
                            }



                            DataTable DTRetve = new DataTable();
                            string Vouch1 = "", Vouch2 = "";
                            int Ref2 = 0, Ref1 = 0;
                            string Fcurr = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value));

                            string Fcurr1 = da_obj_OSDNCN.GetCurrOSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value));
                            str_sp = "FCurr=" + Fcurr;
                            str_sp1 = "FCurr=" + Fcurr1;

                            if (!string.IsNullOrEmpty(txtdcn.Text))
                            {
                                DTRetve = DAdvise.getCheckosdncnrprOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                                if (DTRetve.Rows.Count > 0)
                                {
                                    if (strTranType == "AE")
                                    {

                                        DataView dt_check = DTRetve.DefaultView;
                                        dt_check.RowFilter = "type = 'OSSI'";
                                        DataTable dtNew_check = dt_check.ToTable();
                                        if (dtNew_check.Rows.Count > 0)
                                        {

                                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                                            {
                                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Ref1);

                                                str_sp = "FCurr=" + Fcurr;
                                                str_RptName = "AEProOSDN.rpt";
                                                str_sf = "{OSDN.trantype}=\"" + Session["StrTranTypeO"].ToString() + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                                //  str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                if (get_date >= GST_date)
                                                {
                                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                                }
                                                else
                                                {
                                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                }

                                            }

                                        }

                                        DataView dt_check1 = DTRetve.DefaultView;
                                        dt_check1.RowFilter = "type = 'OSPI'";
                                        DataTable dtNew_check1 = dt_check1.ToTable();
                                        if (dtNew_check1.Rows.Count > 0)
                                        {
                                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                                            for (int i = 0; i <= dtNew_check1.Rows.Count - 1; i++)
                                            {
                                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Convert.ToString(strTranType), 6, Convert.ToInt32(hf_branchid.Value), Ref2);

                                                str_sp1 = "FCurr=" + Fcurr;
                                                str_RptName = "AEProOSCN.rpt";
                                                str_sf = "{OSCN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                                // str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                if (get_date >= GST_date)
                                                {
                                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                                }
                                                else
                                                {
                                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                }

                                            }
                                        }
                                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                                    }
                                    else
                                    {
                                        DataView dt_check = DTRetve.DefaultView;
                                        dt_check.RowFilter = "type = 'OSSI'";
                                        DataTable dtNew_check = dt_check.ToTable();
                                        if (dtNew_check.Rows.Count > 0)
                                        {

                                            for (int i = 0; i < dtNew_check.Rows.Count; i++)
                                            {
                                                Vouch1 = dtNew_check.Rows[i][1].ToString();
                                                Ref1 = Convert.ToInt32(dtNew_check.Rows[i][0].ToString());
                                                get_date = Convert.ToDateTime(dtNew_check.Rows[i][2].ToString());
                                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Ref1);

                                                str_sp = "FCurr=" + Fcurr;
                                                str_RptName = "AIProOSDN.rpt";
                                                str_sf = "{OSDN.trantype}=\"" + Convert.ToString(strTranType) + "\" and {OSDN.refno}=" + Ref1 + " and {OSDN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSDN.vouyear}=" + txtyear.Text;
                                                //str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                if (get_date >= GST_date)
                                                {
                                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref1 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSSI" + "&" + this.Page.ClientQueryString + "','','');";
                                                }
                                                else
                                                {
                                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                }
                                            }
                                        }

                                        DataView dt_check1 = DTRetve.DefaultView;
                                        dt_check1.RowFilter = "type = 'OSPI'";
                                        DataTable dtNew_check1 = dt_check1.ToTable();
                                        if (dtNew_check1.Rows.Count > 0)
                                        {
                                            //Vouch2 = dtNew_check1.Rows[0][1].ToString();
                                            //Ref2 = Convert.ToInt32(dtNew_check1.Rows[0][0].ToString());
                                            for (int i = 0; i < dtNew_check1.Rows.Count; i++)
                                            {
                                                Vouch2 = dtNew_check1.Rows[i][1].ToString();
                                                Ref2 = Convert.ToInt32(dtNew_check1.Rows[i][0].ToString());
                                                get_date = Convert.ToDateTime(dtNew_check1.Rows[i][2].ToString());
                                                Fcurr = da_obj_OSDNCN.GetCurrOSDCNcurrentyOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Ref2);

                                                str_sp1 = "FCurr=" + Fcurr;
                                                str_RptName = "AIProOSCN.rpt";
                                                str_sf = "{OSCN.trantype}=\"" + Session["StrTranTypeO"].ToString() + "\" and {OSCN.refno}=" + Ref2 + " and {OSCN.branchid}=" + Convert.ToInt32(Session["LoginBranchid"]) + " and {OSCN.vouyear}=" + txtyear.Text;
                                                //  str_Script = str_Script + "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp1 + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";

                                                if (get_date >= GST_date)
                                                {
                                                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + Ref2 + "&vouyear=" + txtyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtJobno.Text + "&bltype=" + "ProOSPI" + "&" + this.Page.ClientQueryString + "','','');";
                                                }
                                                else
                                                {
                                                    str_Script += "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                                                }

                                            }

                                        }
                                        ScriptManager.RegisterStartupScript(btnprint, typeof(Button), "Shipment Details", str_Script, true);
                                    }
                                }


                            }

                        }

                    }

                }



            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            ddlTypes.Enabled = true;
            btnprint.Enabled = true;
            btnprint.ForeColor = System.Drawing.Color.White;
            UserRights();
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            double fcamt = 0;
            hid_No.Value = "NO";
            double amtnew = 0;
            strTranType = ddl_product.SelectedValue;
            // debittotal = 0;
            // credittotal = 0;
            //  total = 0.0;
            DataSet ds = new DataSet();
            //lbl.Text = "";
            DataTable dtdc = new DataTable();
            DataTable dtnew = new DataTable();


            if (ddlTypes.SelectedValue == "0")
            {
                if (txtdcn.Text == "")
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewEmptyOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }
                else
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    dtdc = ds.Tables[1];
                }

                if (dtdc.Rows.Count > 0)
                {
                    double Total = 0;
                    DataTable dtempty = new DataTable();
                    dtempty.Columns.Add("blno", typeof(string));
                    dtempty.Columns.Add("chargename", typeof(string));
                    dtempty.Columns.Add("curr", typeof(string));
                    dtempty.Columns.Add("rate", typeof(string));
                    dtempty.Columns.Add("exrate", typeof(string));
                    dtempty.Columns.Add("bASe", typeof(string));
                    dtempty.Columns.Add("withoutgstAmt", typeof(string));
                    dtempty.Columns.Add("stgst", typeof(string));
                    dtempty.Columns.Add("amount", typeof(string));
                    dtempty.Columns.Add("chargeid", typeof(int));
                    dtempty.Columns.Add("GSTCHK", typeof(string));
                    // dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                    dtempty.Columns.Add("provouno", typeof(string));
                    dtempty.Columns.Add("vouno", typeof(string));
                    dtempty.Columns.Add("vouyear", typeof(string));
                    dtempty.Columns.Add("fcamt", typeof(string));
                    DataRow dr = dtempty.NewRow();

                    if (dtdc.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                        {
                            dr = dtempty.NewRow();
                            dtempty.Rows.Add(dr);
                            dr[0] = dtdc.Rows[i]["blno"].ToString();
                            dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                            dr[2] = dtdc.Rows[i]["curr"].ToString();
                            dr[3] = dtdc.Rows[i]["rate"].ToString();
                            dr[4] = dtdc.Rows[i]["exrate"].ToString();
                            dr[5] = dtdc.Rows[i]["bAse"].ToString();

                            if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                            {
                                amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                                dr[6] = amt.ToString("#0.00");
                            }
                            else
                            {
                                dr[6] = "0.00";
                            }
                            if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                            {
                                amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                                dr[7] = amt1.ToString("#0.00");
                            }
                            else
                            {
                                dr[7] = "0.00";
                            }
                            if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                            {
                                amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                                dr[8] = amt1.ToString("#0.00");
                            }
                            else
                            {
                                dr[8] = "0.00";
                            }
                            dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                            dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                            dr[11] = dtdc.Rows[i]["provouno"].ToString();
                            if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                            {
                                chk_GstApp.Checked = true;
                                // chk_GstApp.Enabled = false;
                            }

                            dr[12] = dtdc.Rows[i]["vouno"].ToString();
                            dr[13] = dtdc.Rows[i]["vouyear"].ToString();
                            Total = Total + double.Parse(dr[8].ToString());

                            if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                            {
                                dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                                fcamt = fcamt + Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString());
                            }
                            else
                            {
                                fcamt = fcamt + 0;
                            }
                        }
                    }
                    txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                    grddebit.DataSource = dtempty;
                    grddebit.DataBind();
                }

                fcamt = 0;
                if (ds.Tables[2].Rows.Count > 0)
                {
                    dtnew = ds.Tables[2];
                }

                if (dtnew.Rows.Count > 0)
                {
                    double Total = 0;
                    DataTable dtempty1 = new DataTable();
                    dtempty1.Columns.Add("blno", typeof(string));
                    dtempty1.Columns.Add("chargename", typeof(string));
                    dtempty1.Columns.Add("curr", typeof(string));
                    dtempty1.Columns.Add("rate", typeof(string));
                    dtempty1.Columns.Add("exrate", typeof(string));
                    dtempty1.Columns.Add("bASe", typeof(string));
                    dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                    dtempty1.Columns.Add("stgst", typeof(string));
                    dtempty1.Columns.Add("amount", typeof(string));
                    dtempty1.Columns.Add("chargeid", typeof(int));
                    dtempty1.Columns.Add("GSTCHK", typeof(string));
                    dtempty1.Columns.Add("provouno", typeof(string));
                    dtempty1.Columns.Add("vouno", typeof(string));
                    dtempty1.Columns.Add("vouyear", typeof(string));
                    dtempty1.Columns.Add("fcamt", typeof(string));
                    DataRow dr = dtempty1.NewRow();

                    if (dtnew.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                        {
                            dr = dtempty1.NewRow();
                            dtempty1.Rows.Add(dr);
                            dr[0] = dtnew.Rows[i]["blno"].ToString();
                            dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                            dr[2] = dtnew.Rows[i]["curr"].ToString();
                            dr[3] = dtnew.Rows[i]["rate"].ToString();
                            dr[4] = dtnew.Rows[i]["exrate"].ToString();
                            dr[5] = dtnew.Rows[i]["bAse"].ToString();

                            if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                            {
                                amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                                dr[6] = amt.ToString("#0.00");
                            }
                            else
                            {
                                dr[6] = "0.00";
                            }
                            if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                            {
                                amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                                dr[7] = amt1.ToString("#0.00");
                            }
                            else
                            {
                                dr[7] = "0.00";
                            }
                            if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                            {
                                amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                                dr[8] = amt1.ToString("#0.00");
                            }
                            else
                            {
                                dr[8] = "0.00";
                            }
                            dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                            dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();

                            dr[11] = dtnew.Rows[i]["provouno"].ToString();
                            if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                            {
                                chk_GstApp.Checked = true;
                                // chk_GstApp.Enabled = false;
                            }
                            dr[12] = dtnew.Rows[i]["vouno"].ToString();
                            dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                            Total = Total + double.Parse(dr[8].ToString());

                            if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                            {
                                dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                                fcamt = fcamt + Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString());
                            }
                            else
                            {
                                fcamt = fcamt + 0;
                            }
                        }
                    }
                    txt_FcCramt.Text = fcamt.ToString("#0.00");
                    grdcredit.DataSource = dtempty1;
                    grdcredit.DataBind();
                }

                DataTable dtd = new DataTable();

                dtd = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value));

                if (dtd.Rows.Count > 0)
                {
                    lbl.Text = "Debit Note";
                    txtdcn.Text = dtd.Rows[0][0].ToString();

                    if (dtd.Rows.Count == 1)
                    {
                        hid_debitDnno.Value = dtd.Rows[0][0].ToString();
                    }
                    else
                    {
                        hid_debitDnno.Value = "0";
                    }

                    txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                    txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();


                    if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                    {
                        txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                        // txtVendorRefnodate.Text = Convert.ToDateTime(dtd.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");//hide on 14Feb2023 //nambi
                    }
                    else
                    {
                        txtVendorRefnodate.Text = "";
                    }
                    if (dtd.Rows[0]["fatransfer"].ToString() == "")
                    {
                        btnview.Text = "Save";
                        btnview.Enabled = true;
                        btnview.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        btnview.Enabled = false;
                        btnview.ForeColor = System.Drawing.Color.Gray;
                    }
                }

                dtd = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value));
                if (dtd.Rows.Count > 0)
                {
                    lbl.Text = "Credit Note";
                    txtdcn.Text = dtd.Rows[0][0].ToString();

                    if (dtd.Rows.Count == 1)
                    {
                        hid_creditDnno.Value = dtd.Rows[0][0].ToString();
                    }
                    else
                    {
                        hid_creditDnno.Value = "0";
                    }

                    txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                    txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();

                    if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                    {
                        txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                        // txtVendorRefnodate.Text = Convert.ToDateTime(dtd.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");//hide on 14Feb2023 //nambi
                    }
                    else
                    {
                        txtVendorRefnodate.Text = "";
                    }

                    if (dtd.Rows[0]["fatransfer"].ToString() == "")
                    {
                        btnview.Text = "Save";
                        btnview.Enabled = true;
                        btnview.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        btnview.Enabled = false;
                        btnview.ForeColor = System.Drawing.Color.Gray;
                    }
                }
                double tot = 0, tot1 = 0;
                for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                {
                    tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                    tot = tot + tot1;
                }

                txtDebit.Text = tot.ToString("#,0.00");
                for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                {
                    amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                    amtnew = amtnew + amt1;
                }
                txtCredit.Text = amtnew.ToString("#,0.00");

                if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                {
                    Toatlnew = tot - amtnew;
                    if (Toatlnew < 0)
                    {
                        lblGross.Text = "Payable to Agent:";
                        txttotal.Text = Toatlnew.ToString("#0.00");
                    }
                    else
                    {
                        lblGross.Text = "Receivable from Agent:";
                        txttotal.Text = Toatlnew.ToString("#0.00");

                    }
                }
                else
                {
                    if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                    {
                        txttotal.Text = txtCredit.Text;
                    }
                    else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                    {
                        txttotal.Text = txtDebit.Text;
                    }
                }

                if (hid_debitDnno.Value == "")
                {
                    hid_debitDnno.Value = "0";
                }

                if (hid_creditDnno.Value == "")
                {
                    hid_creditDnno.Value = "0";
                }

                if (Convert.ToInt32(hid_debitDnno.Value) > 0 || Convert.ToInt32(hid_creditDnno.Value) > 0)
                {
                    if (Convert.ToInt32(hid_debitDnno.Value) > 0 && Convert.ToInt32(hid_creditDnno.Value) > 0)
                    {
                        lbl.Text = "Debit / Credit Note";
                    }
                    else if (Convert.ToInt32(hid_debitDnno.Value) > 0)
                    {
                        lbl.Text = "Debit Note";
                    }
                    else if (Convert.ToInt32(hid_creditDnno.Value) > 0)
                    {
                        lbl.Text = "Credit Note";
                    }
                    //}
                }
                else
                {
                    btnview.Text = "Save";
                    btnview.Enabled = true;
                    btnview.ForeColor = System.Drawing.Color.White;
                    /// txtdcn.Text = "";
                }
                btnback.Text = "Cancel";
                btnprint.Enabled = true;


                if (btnview.Text == "Save" && hid_jobtype.Value == "2")
                {
                    btnview.Enabled = false;
                    btnview.ForeColor = System.Drawing.Color.Gray;
                }
            }
            else
            {
                fcamt = 0;
                if (ddlTypes.SelectedValue == "OSSI")
                {
                    dtdc = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txtdcn.Text), Convert.ToInt32(hid_intagent.Value));

                    if (dtdc.Rows.Count > 0)
                    {
                        double Total = 0;
                        DataTable dtempty = new DataTable();
                        dtempty.Columns.Add("blno", typeof(string));
                        dtempty.Columns.Add("chargename", typeof(string));
                        dtempty.Columns.Add("curr", typeof(string));
                        dtempty.Columns.Add("rate", typeof(string));
                        dtempty.Columns.Add("exrate", typeof(string));
                        dtempty.Columns.Add("bASe", typeof(string));
                        dtempty.Columns.Add("withoutgstAmt", typeof(string));
                        dtempty.Columns.Add("stgst", typeof(string));
                        dtempty.Columns.Add("amount", typeof(string));
                        dtempty.Columns.Add("chargeid", typeof(int));
                        dtempty.Columns.Add("GSTCHK", typeof(string));
                        dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                        dtempty.Columns.Add("provouno", typeof(string));
                        dtempty.Columns.Add("vouno", typeof(string));
                        dtempty.Columns.Add("vouyear", typeof(string));
                        dtempty.Columns.Add("fcamt", typeof(string));
                        DataRow dr = dtempty.NewRow();

                        if (dtdc.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                            {
                                dr = dtempty.NewRow();
                                dtempty.Rows.Add(dr);
                                dr[0] = dtdc.Rows[i]["blno"].ToString();
                                dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                                dr[2] = dtdc.Rows[i]["curr"].ToString();
                                dr[3] = dtdc.Rows[i]["rate"].ToString();
                                dr[4] = dtdc.Rows[i]["exrate"].ToString();
                                dr[5] = dtdc.Rows[i]["bAse"].ToString();

                                if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                                {
                                    amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                                    dr[6] = amt.ToString("#0.00");
                                }
                                else
                                {
                                    dr[6] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                                    dr[7] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[7] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                                    dr[8] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[8] = "0.00";
                                }
                                dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                                dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                                dr[11] = dtdc.Rows[i]["provouno"].ToString();
                                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                {
                                    chk_GstApp.Checked = true;
                                    // chk_GstApp.Enabled = false;
                                }
                                dr[12] = dtdc.Rows[i]["vouno"].ToString();
                                dr[13] = dtdc.Rows[i]["vouyear"].ToString();
                                Total = Total + double.Parse(dr[8].ToString());

                                if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                                {
                                    dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                                    fcamt = fcamt + Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString());
                                }
                                else
                                {
                                    fcamt = fcamt + 0;
                                }
                            }
                        }
                        txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                        grddebit.DataSource = dtempty;
                        grddebit.DataBind();
                    }
                    DataTable dtd = new DataTable();

                    dtd = OSDNCN.GetOSDCNProDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), strTranType, 5, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtdcn.Text));

                    if (dtd.Rows.Count > 0)
                    {
                        lbl.Text = "Debit Note";
                        txtdcn.Text = dtd.Rows[0][0].ToString();

                        if (dtd.Rows.Count == 1)
                        {
                            hid_debitDnno.Value = dtd.Rows[0][0].ToString();
                        }
                        else
                        {
                            hid_debitDnno.Value = "0";
                        }

                        txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                        txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();

                        if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                            //txtVendorRefnodate.Text = Convert.ToDateTime(dtd.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");//hide on 14Feb2023 //nambi
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        if (dtd.Rows[0]["fatransfer"].ToString() == "")
                        {
                            btnview.Text = "Save";
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            btnview.Enabled = false;
                            btnview.ForeColor = System.Drawing.Color.Gray;
                        }
                        grdcredit.DataSource = new DataTable();
                        grdcredit.DataBind();

                    }
                }
                else
                {
                    fcamt = 0;
                    dtnew = OSDNCN.RptOSDNCNProFromJobNoForNewForParticularRefOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txtdcn.Text), Convert.ToInt32(hid_intagent.Value));

                    if (dtnew.Rows.Count > 0)
                    {
                        double Total = 0;
                        DataTable dtempty1 = new DataTable();
                        dtempty1.Columns.Add("blno", typeof(string));
                        dtempty1.Columns.Add("chargename", typeof(string));
                        dtempty1.Columns.Add("curr", typeof(string));
                        dtempty1.Columns.Add("rate", typeof(string));
                        dtempty1.Columns.Add("exrate", typeof(string));
                        dtempty1.Columns.Add("bASe", typeof(string));
                        dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                        dtempty1.Columns.Add("stgst", typeof(string));
                        dtempty1.Columns.Add("amount", typeof(string));
                        dtempty1.Columns.Add("chargeid", typeof(int));
                        dtempty1.Columns.Add("GSTCHK", typeof(string));
                        dtempty1.Columns.Add("provouno", typeof(string));
                        dtempty1.Columns.Add("vouno", typeof(string));
                        dtempty1.Columns.Add("vouyear", typeof(string));
                        dtempty1.Columns.Add("fcamt", typeof(string));
                        DataRow dr = dtempty1.NewRow();

                        if (dtnew.Rows.Count > 0)
                        {
                            for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                            {
                                dr = dtempty1.NewRow();
                                dtempty1.Rows.Add(dr);
                                dr[0] = dtnew.Rows[i]["blno"].ToString();
                                dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                                dr[2] = dtnew.Rows[i]["curr"].ToString();
                                dr[3] = dtnew.Rows[i]["rate"].ToString();
                                dr[4] = dtnew.Rows[i]["exrate"].ToString();
                                dr[5] = dtnew.Rows[i]["bAse"].ToString();

                                if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                                {
                                    amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                                    dr[6] = amt.ToString("#0.00");
                                }
                                else
                                {
                                    dr[6] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                                    dr[7] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[7] = "0.00";
                                }
                                if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                                {
                                    amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                                    dr[8] = amt1.ToString("#0.00");
                                }
                                else
                                {
                                    dr[8] = "0.00";
                                }
                                dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                                dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();

                                dr[11] = dtnew.Rows[i]["provouno"].ToString();
                                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                {
                                    chk_GstApp.Checked = true;
                                    //  chk_GstApp.Enabled = false;
                                }
                                dr[12] = dtnew.Rows[i]["vouno"].ToString();
                                dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                                Total = Total + double.Parse(dr[8].ToString());



                                if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                                {
                                    dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                                    fcamt = fcamt + Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString());
                                }
                                else
                                {
                                    fcamt = fcamt + 0;
                                }
                            }
                        }
                        txt_FcCramt.Text = fcamt.ToString("#0.00");
                        grdcredit.DataSource = dtempty1;
                        grdcredit.DataBind();
                    }
                    DataTable dtd = new DataTable();
                    dtd = OSDNCN.GetOSDCNProDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtdcn.Text));
                    if (dtd.Rows.Count > 0)
                    {
                        lbl.Text = "Credit Note";
                        txtdcn.Text = dtd.Rows[0][0].ToString();

                        if (dtd.Rows.Count == 1)
                        {
                            hid_creditDnno.Value = dtd.Rows[0][0].ToString();
                        }
                        else
                        {
                            hid_creditDnno.Value = "0";
                        }

                        txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                        txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();


                        if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                            //txtVendorRefnodate.Text = Convert.ToDateTime(dtd.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        if (dtd.Rows[0]["fatransfer"].ToString() == "")
                        {
                            btnview.Text = "Save";
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            btnview.Enabled = false;
                            btnview.ForeColor = System.Drawing.Color.Gray;
                        }

                    }
                    grddebit.DataSource = new DataTable();
                    grddebit.DataBind();

                }
                double tot = 0, tot1 = 0;
                for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                {
                    tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                    tot = tot + tot1;
                }
                txtDebit.Text = tot.ToString("#,0.00");
                for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                {
                    amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                    amtnew = amtnew + amt1;
                }
                txtCredit.Text = amtnew.ToString("#,0.00");

                if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                {
                    Toatlnew = tot - amtnew;
                    if (Toatlnew < 0)
                    {
                        lblGross.Text = "Payable to Agent:";
                        txttotal.Text = Toatlnew.ToString("#0.00");
                    }
                    else
                    {
                        lblGross.Text = "Receivable from Agent:";
                        txttotal.Text = Toatlnew.ToString("#0.00");

                    }
                }
                else
                {
                    if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                    {
                        txttotal.Text = txtCredit.Text;
                    }
                    else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                    {
                        txttotal.Text = txtDebit.Text;
                    }
                }
                if (hid_debitDnno.Value == "")
                {
                    hid_debitDnno.Value = "0";
                }

                if (hid_creditDnno.Value == "")
                {
                    hid_creditDnno.Value = "0";
                }

                if (Convert.ToInt32(hid_debitDnno.Value) > 0 || Convert.ToInt32(hid_creditDnno.Value) > 0)
                {
                    if (Convert.ToInt32(hid_debitDnno.Value) > 0 && Convert.ToInt32(hid_creditDnno.Value) > 0)
                    {
                        lbl.Text = "Debit / Credit Note";
                    }
                    else if (Convert.ToInt32(hid_debitDnno.Value) > 0)
                    {
                        lbl.Text = "Debit Note";
                    }
                    else if (Convert.ToInt32(hid_creditDnno.Value) > 0)
                    {
                        lbl.Text = "Credit Note";
                    }
                    //}
                }
                else
                {
                    btnview.Text = "Save";
                    btnview.Enabled = true;
                    btnview.ForeColor = System.Drawing.Color.White;
                    /// txtdcn.Text = "";
                }
                btnback.Text = "Cancel";
                btnprint.Enabled = true;


                if (btnview.Text == "Save" && hid_jobtype.Value == "2")
                {
                    btnview.Enabled = false;
                    btnview.ForeColor = System.Drawing.Color.Gray;
                }
            }




        }

        protected void btn_yes_Click(object sender, EventArgs e)
        {


            //if (ddlTypes.SelectedValue == "0")
            //{
            hid_yes.Value = "YES";
            ddlTypes.SelectedValue = "0";
            hid_creditDnno.Value = "0";
            hid_debitDnno.Value = "0";
            txtremarks.Text = "";
            // chk_GstApp.Enabled = true;
            txtVendorRefno.Text = "";
            txtdcn.Text = "";
            //  txtyear.Text = "";
            grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
            grdcredit.DataBind();
            grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
            grddebit.DataBind();
            btnback.Text = "Cancel";
            txtdcn.Text = "";
            btnview.Text = "Save";
            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;


        }

        protected void txtdcn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtdcn.Text = "";
                    return;
                }
                if (ddlTypes.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the voucher type');", true);
                    return;
                }
                hid_MoreOne.Value = "";
                hid_yes.Value = "0";
                hid_No.Value = "0";
                hid_debitDnno.Value = "0";
                hid_DebitCredit.Value = "0";
                hid_creditDnno.Value = "0";
                hid_agentold.Value = "0";
                hid_supplytoold.Value = "0";
                double amtnew = 0;
                strTranType = ddl_product.SelectedValue;
                // debittotal = 0;
                //  credittotal = 0;
                //total = 0.0;
                DataSet ds = new DataSet();
                //lbl.Text = "";
                double fcamt = 0;

                //if (ddlTypes.SelectedValue == "5")
                //{
                //    ddlDebiteOrCredite.SelectedValue = "5";
                //}
                //else if (ddlTypes.SelectedValue == "6")
                //{
                //    ddlDebiteOrCredite.SelectedValue = "6";
                //}
                //if (txtdcn.Text != "")
                //{
                //    ddlDebiteOrCredite.Enabled = false;
                //}
                //else
                //{
                //    ddlDebiteOrCredite.Enabled = true;
                //}

                //if (ddlTypes.SelectedValue == "0")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DataFound", "alertify.alert('Type Cannot be blank');", true);
                //    ddlTypes.Focus();
                //    return;

                //}


                if (txtdcn.Text == "")
                {
                    clr();
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "DataFound", "alertify.alert('Ref # cannot be blank');", true);
                    txtdcn.Focus();
                    return;

                }


                //if (txtdcn.Text == "")
                //{
                //    ds = OSDNCN.RptOSDNCNProFromJobNoForNewEmptyOSV(strTranType, Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                //}
                //else
                //{
                if (txtJobno.Text == "")
                {
                    txtJobno.Text = "0";
                }
                ds = OSDNCN.GetOsDnDetailsForRefnojobnonewOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtdcn.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlTypes.SelectedValue), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(txtdcn.Text));
                //}

                if (ds.Tables.Count > 0)
                {
                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //}
                    //else
                    //{
                    //    if (ds.Tables[2].Rows.Count > 0)
                    //    {
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Voucher Not Raised in this Job');", true);
                    //        txtclear();
                    //        return;
                    //    }
                    //  }

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }

                    if (dt.Rows.Count > 0)
                    {
                        jobno = Convert.ToInt32(dt.Rows[0][4].ToString());
                        txtJobno.Text = jobno.ToString();
                        Dt = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Invalid Ref #');", true);
                        txtdcn.Text = "";
                        txtdcn.Focus();
                        return;
                    }

                    if (strTranType == "FE" || strTranType == "FI")
                    {
                        //cmbbl.Items.Clear();
                        if (Dt.Rows.Count > 0)
                        {
                            cmbbl.Items.Clear();
                            cmbbl.Items.Add("");
                            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            {
                                cmbbl.Items.Add(Dt.Rows[i]["blno"].ToString());
                            }
                            cmbbl.Items.Add(Dt.Rows[0]["mblno"].ToString());

                        }
                    }
                    if (strTranType == "AE" || strTranType == "AI")
                    {
                        if (Dt.Rows.Count > 0)
                        {
                            cmbbl.Items.Clear();
                            cmbbl.Items.Add("");
                            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            {
                                cmbbl.Items.Add(Dt.Rows[i]["hawblno"].ToString());
                            }
                            cmbbl.Items.Add(Dt.Rows[0]["mawblno"].ToString());

                        }
                    }



                    dtOSDN = DAdvise.SelDepCre4OSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), 5);
                    dtOSCN = DAdvise.SelDepCre4OSDCNOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), 6);
                    if (dtOSDN.Rows.Count > 0 && dtOSCN.Rows.Count > 0)
                    {
                        if (ddlTypes.SelectedValue == "OSSI" || ddlTypes.SelectedValue == "OSPI")
                        {
                            // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already raised the OSDN #" + dtOSDN.Rows[0][0].ToString() + " and OSCN #" + dtOSCN.Rows[0][0].ToString() + "');", true);
                            //txtclear();
                            //txtJobno.Focus();
                            //return;

                        }

                    }
                    else if (dtOSDN.Rows.Count > 0 || dtOSCN.Rows.Count > 0)
                    {
                        if (ddlTypes.SelectedValue == "OSSI")
                        {
                            if (dtOSDN.Rows.Count > 0)
                            {
                                // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already raised the OSDN #" + dtOSDN.Rows[0][0].ToString() + "');", true);
                            }
                        }
                        else
                        {
                            if (dtOSCN.Rows.Count > 0)
                            {
                                // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already raised the OSCN #" + dtOSCN.Rows[0][0].ToString() + "');", true);
                            }
                        }



                    }

                    if (ds.Tables.Count > 0)
                    {


                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dt = ds.Tables[0];
                        }
                        if (dt.Rows.Count > 0)
                        {
                            jobno = Convert.ToInt32(dt.Rows[0][4].ToString());

                            //if (strTranType == "FE")
                            //{
                            //    hid_jobtype.Value = dt.Rows[0]["jobtype"].ToString();
                            //    if (hid_jobtype.Value == "2")
                            //    {


                            //        btnview.Enabled = false;
                            //        btnview.ForeColor = System.Drawing.Color.Gray;
                            //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtJobno.Text + " is assigned for Co-Load. You cannot raise Voucher');", true);

                            //    }
                            //    else
                            //    {
                            //        btnview.Enabled = true;
                            //        btnview.ForeColor = System.Drawing.Color.White;
                            //    }
                            //}
                            // txtcustomer.Text = dt.Rows[0][0].ToString() + Environment.NewLine + dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                            //agentid
                            txt_Agent.Text = dt.Rows[0][0].ToString();
                            if (string.IsNullOrEmpty(dt.Rows[0]["originname"].ToString()) != true)
                            {
                                txt_origin.Text = dt.Rows[0]["originname"].ToString();
                            }
                            if (string.IsNullOrEmpty(dt.Rows[0]["agentid"].ToString()) != true)
                            {
                                // hid_SupplyTo.Value = dt.Rows[0]["agentid"].ToString();
                                hid_intagent.Value = dt.Rows[0]["agentid"].ToString();
                                txtcustomer.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hid_intagent.Value));

                                hid_agentold.Value = hid_intagent.Value;

                            }
                            if (string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                txtsupplyto.Text = customerobj.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                                // hid_intagent.Value = dt.Rows[0]["agentid"].ToString();
                                hid_supplytoold.Value = hid_SupplyTo.Value;
                            }



                            //  txtsupplyto.Text = dt.Rows[0][0].ToString();
                            //txt_Agent.ReadOnly = true;
                            //txtsupplyto.ReadOnly = true;
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }


                            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginDivisionId"]));
                            if (DtBLNO.Rows.Count > 0)
                            {
                                mblno = DtBLNO.Rows[0][0].ToString();
                            }


                            double amt = 0, amt1 = 0;
                            DataTable dtdc = new DataTable();
                            // dtdc = ds.Tables[1];
                            //grddebit.DataSource = dtdc;
                            //grddebit.DataBind();
                            DataTable dtnew = new DataTable();
                            DataTable dtcc = new DataTable();
                            //dtcc = ds.Tables[2];
                            //grdcredit.DataSource = dtcc;
                            //grdcredit.DataBind();

                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                dtdc = ds.Tables[1];
                            }

                            // dtnew = ds.Tables[2];
                            DataTable dtnew1 = new DataTable();
                            DataTable dtcc1 = new DataTable();

                            if (ddlTypes.SelectedValue == "5")
                            {
                                dtnew1 = OSDNCN.GetOSDCNProDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtdcn.Text));
                            }
                            else
                            {
                                dtcc1 = OSDNCN.GetOSDCNProDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtdcn.Text));
                            }
                            if (dtnew1.Rows.Count > 0)
                            {
                                int n = 0;
                                n = Convert.ToInt32(dtnew1.Rows[0][0].ToString());

                                if (n != 0)
                                {
                                    txtdcn.Text = n.ToString();
                                    //this.PopUpService.Show();
                                    //return;
                                }

                            }
                            if (dtcc1.Rows.Count > 0)
                            {
                                int n = 0;
                                n = Convert.ToInt32(dtcc1.Rows[0][0].ToString());
                                if (n != 0)
                                {
                                    txtdcn.Text = n.ToString();
                                    //this.PopUpService.Show();
                                    //return;
                                }
                            }

                            //if (dtdc.Rows.Count > 0 || dtnew.Rows.Count > 0)
                            //{

                            //}

                            if (ddlTypes.SelectedValue == "5")
                            {
                                if (dtdc.Rows.Count > 0)
                                {
                                    double Total = 0;
                                    DataTable dtempty = new DataTable();
                                    dtempty.Columns.Add("blno", typeof(string));
                                    dtempty.Columns.Add("chargename", typeof(string));
                                    dtempty.Columns.Add("curr", typeof(string));
                                    dtempty.Columns.Add("rate", typeof(string));
                                    dtempty.Columns.Add("exrate", typeof(string));
                                    dtempty.Columns.Add("bASe", typeof(string));
                                    dtempty.Columns.Add("withoutgstAmt", typeof(string));
                                    dtempty.Columns.Add("stgst", typeof(string));
                                    dtempty.Columns.Add("amount", typeof(string));
                                    dtempty.Columns.Add("chargeid", typeof(int));
                                    dtempty.Columns.Add("GSTCHK", typeof(string));
                                    dtempty.Columns.Add("provouno", typeof(string));
                                    dtempty.Columns.Add("vouno", typeof(string));
                                    dtempty.Columns.Add("vouyear", typeof(string));
                                    dtempty.Columns.Add("fcamt", typeof(string));
                                    DataRow dr = dtempty.NewRow();

                                    if (dtdc.Rows.Count > 0)
                                    {
                                        for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                                        {
                                            dr = dtempty.NewRow();
                                            dtempty.Rows.Add(dr);
                                            dr[0] = dtdc.Rows[i]["blno"].ToString();
                                            dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                                            dr[2] = dtdc.Rows[i]["curr"].ToString();
                                            dr[3] = dtdc.Rows[i]["rate"].ToString();
                                            dr[4] = dtdc.Rows[i]["exrate"].ToString();
                                            dr[5] = dtdc.Rows[i]["bAse"].ToString();

                                            if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                                            {
                                                amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                                                dr[6] = amt.ToString("#0.00");
                                            }
                                            else
                                            {
                                                dr[6] = "0.00";
                                            }
                                            if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                                            {
                                                amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                                                dr[7] = amt1.ToString("#0.00");
                                            }
                                            else
                                            {
                                                dr[7] = "0.00";
                                            }
                                            if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                                            {
                                                amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                                                dr[8] = amt1.ToString("#0.00");
                                            }
                                            else
                                            {
                                                dr[8] = "0.00";
                                            }
                                            dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                                            dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                                            dr[11] = dtdc.Rows[i]["provouno"].ToString();
                                            if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                            {
                                                chk_GstApp.Checked = true;
                                                // chk_GstApp.Enabled = false;
                                            }
                                            dr[12] = dtdc.Rows[i]["vouno"].ToString();
                                            dr[13] = dtdc.Rows[i]["vouyear"].ToString();
                                            Total = Total + double.Parse(dr[8].ToString());

                                            if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                                            {
                                                dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                                                fcamt = fcamt + Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString());
                                            }
                                            else
                                            {
                                                fcamt = fcamt + 0;
                                            }
                                        }
                                    }
                                    txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                                    grddebit.DataSource = dtempty;
                                    grddebit.DataBind();
                                }
                            }
                            else
                            {

                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    dtnew = ds.Tables[1];
                                }

                                if (dtnew.Rows.Count > 0)
                                {
                                    double Total = 0;
                                    DataTable dtempty1 = new DataTable();
                                    dtempty1.Columns.Add("blno", typeof(string));
                                    dtempty1.Columns.Add("chargename", typeof(string));
                                    dtempty1.Columns.Add("curr", typeof(string));
                                    dtempty1.Columns.Add("rate", typeof(string));
                                    dtempty1.Columns.Add("exrate", typeof(string));
                                    dtempty1.Columns.Add("bASe", typeof(string));
                                    dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                                    dtempty1.Columns.Add("stgst", typeof(string));
                                    dtempty1.Columns.Add("amount", typeof(string));
                                    dtempty1.Columns.Add("chargeid", typeof(int));
                                    dtempty1.Columns.Add("GSTCHK", typeof(string));

                                    dtempty1.Columns.Add("provouno", typeof(string));
                                    dtempty1.Columns.Add("vouno", typeof(string));
                                    dtempty1.Columns.Add("vouyear", typeof(string));
                                    dtempty1.Columns.Add("fcamt", typeof(string));
                                    DataRow dr = dtempty1.NewRow();

                                    if (dtnew.Rows.Count > 0)
                                    {
                                        for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                                        {
                                            dr = dtempty1.NewRow();
                                            dtempty1.Rows.Add(dr);
                                            dr[0] = dtnew.Rows[i]["blno"].ToString();
                                            dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                                            dr[2] = dtnew.Rows[i]["curr"].ToString();
                                            dr[3] = dtnew.Rows[i]["rate"].ToString();
                                            dr[4] = dtnew.Rows[i]["exrate"].ToString();
                                            dr[5] = dtnew.Rows[i]["bAse"].ToString();

                                            if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                                            {
                                                amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                                                dr[6] = amt.ToString("#0.00");
                                            }
                                            else
                                            {
                                                dr[6] = "0.00";
                                            }
                                            if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                                            {
                                                amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                                                dr[7] = amt1.ToString("#0.00");
                                            }
                                            else
                                            {
                                                dr[7] = "0.00";
                                            }
                                            if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                                            {
                                                amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                                                dr[8] = amt1.ToString("#0.00");
                                            }
                                            else
                                            {
                                                dr[8] = "0.00";
                                            }
                                            dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                                            dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();
                                            dr[11] = dtnew.Rows[i]["provouno"].ToString();
                                            if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                            {
                                                chk_GstApp.Checked = true;
                                                //chk_GstApp.Enabled = false;
                                            }
                                            dr[12] = dtnew.Rows[i]["vouno"].ToString();
                                            dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                                            Total = Total + double.Parse(dr[8].ToString());
                                            if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                                            {
                                                dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                                                fcamt = fcamt + Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString());
                                            }
                                            else
                                            {
                                                fcamt = fcamt + 0;
                                            }
                                        }
                                    }
                                    txt_FcCramt.Text = fcamt.ToString("#0.00");
                                    grdcredit.DataSource = dtempty1;
                                    grdcredit.DataBind();
                                }
                            }

                            double tot = 0, tot1 = 0;
                            for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                                tot = tot + tot1;
                            }
                            txtDebit.Text = tot.ToString("#,0.00");
                            for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                            {
                                amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                                amtnew = amtnew + amt1;
                            }
                            txtCredit.Text = amtnew.ToString("#,0.00");

                            if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                            {
                                Toatlnew = tot - amtnew;
                                if (Toatlnew < 0)
                                {
                                    lblGross.Text = "Payable to Agent:";
                                    txttotal.Text = Toatlnew.ToString("#0.00");
                                }
                                else
                                {
                                    lblGross.Text = "Receivable from Agent:";
                                    txttotal.Text = Toatlnew.ToString("#0.00");

                                }
                            }
                            else
                            {
                                if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                                {
                                    txttotal.Text = txtCredit.Text;
                                }
                                else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                                {
                                    txttotal.Text = txtDebit.Text;
                                }
                            }
                            btnback.Text = "Cancel";
                        }
                        else
                        {
                            txtclear();
                            return;
                        }

                    }




                    DataTable dtd1 = new DataTable();
                    DataTable dtd = new DataTable();

                    if (ddlTypes.SelectedValue == "5")
                    {
                        dtd = OSDNCN.GetOSDCNProDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtdcn.Text));
                        //  dtd1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, "OSPI", Convert.ToInt32(hf_branchid.Value));
                        if (dtd.Rows.Count > 0)
                        {
                            lbl.Text = "Debit Note";
                            hid_debitDnno.Value = dtd.Rows[0][0].ToString();
                        }
                        else
                        {


                        }

                        if (dtd.Rows.Count > 0)
                        {
                            txtdcn.Text = dtd.Rows[0][0].ToString();
                            txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                            txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();

                            if (!String.IsNullOrEmpty(dtd.Rows[0]["remarks"].ToString()))
                            {
                                txtremarks.Text = dtd.Rows[0]["remarks"].ToString();
                            }
                            else
                            {
                                txtremarks.Text = "";
                            }

                            if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                            {

                                txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                                //txtVendorRefnodate.Text = Convert.ToDateTime(dtd.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy");//hide on 14Feb2023 //nambi

                            }
                            else
                            {

                                txtVendorRefnodate.Text = "";
                            }
                            if (dtd.Rows[0]["fatransfer"].ToString() == "")
                            {
                                btnview.Text = "Save";
                                btnview.Enabled = true;
                                btnview.ForeColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                btnview.Enabled = false;
                                btnview.ForeColor = System.Drawing.Color.Gray;
                            }
                        }
                        else
                        {
                            btnview.Text = "Save";
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                            txtdcn.Text = "";
                        }
                        btnback.Text = "Cancel";
                        btnprint.Enabled = true;


                        if (btnview.Text == "Save" && hid_jobtype.Value == "2")
                        {
                            btnview.Enabled = false;
                            btnview.ForeColor = System.Drawing.Color.Gray;
                        }
                    }
                    else
                    {
                        // dtd = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, "OSSI", Convert.ToInt32(hf_branchid.Value));
                        dtd1 = OSDNCN.GetOSDCNProDtlsForNewOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value), Convert.ToInt32(txtdcn.Text));

                        if (dtd1.Rows.Count > 0)
                        {
                            hid_creditDnno.Value = dtd1.Rows[0][0].ToString();
                        }
                        if (dtd1.Rows.Count > 0)
                        {
                            txtdcn.Text = dtd1.Rows[0][0].ToString();
                            txtyear.Text = dtd1.Rows[0]["vouyear"].ToString();
                            txtVendorRefno.Text = dtd1.Rows[0]["vendorrefno"].ToString();

                            if (!String.IsNullOrEmpty(dtd1.Rows[0]["remarks"].ToString()))
                            {
                                txtremarks.Text = dtd1.Rows[0]["remarks"].ToString();
                            }
                            else
                            {
                                txtremarks.Text = "";
                            }

                            if (DBNull.Value.Equals(dtd1.Rows[0]["vendorRefdate"]) == false)
                            {
                                txtVendorRefnodate.Text = dtd1.Rows[0]["vendorrefdate"].ToString();
                                //txtVendorRefnodate.Text = Convert.ToDateTime(dtd1.Rows[0]["vendorrefdate"].ToString()).ToString("dd/MM/yyyy"); //hide on 14Feb2023 //nambi 4 date issue
                            }
                            else
                            {
                                txtVendorRefnodate.Text = "";
                            }
                            if (dtd1.Rows[0]["fatransfer"].ToString() == "")
                            {
                                btnview.Text = "Save";
                                btnview.Enabled = true;
                                btnview.ForeColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                btnview.Enabled = false;
                                btnview.ForeColor = System.Drawing.Color.Gray;
                            }
                        }
                        else
                        {
                            btnview.Text = "Save";
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                            txtdcn.Text = "";
                        }
                        btnback.Text = "Cancel";
                        btnprint.Enabled = true;


                        if (btnview.Text == "Save" && hid_jobtype.Value == "2")
                        {
                            btnview.Enabled = false;
                            btnview.ForeColor = System.Drawing.Color.Gray;
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transferred');", true);
                    txtclear();
                    txtdcn.Focus();
                    ddlTypes.SelectedValue = "0";
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtclear();
                txtJobno.Focus();
            }
        }
        protected void btn_debitadvise_Click(object sender, EventArgs e)
        {
            DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            string str_RptName = "";
            // string str_Frmname = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            if (grddebit.Rows.Count > 0)
            {


                if (ddl_product.SelectedValue == "AE")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {
                        //str_Frmname = "DebitAdvise";
                        str_RptName = "AEDebitAdvise.rpt";
                        str_sf = "{DebitAdvise.jobno}=" + txtJobno.Text.ToString() + " and {DebitAdvise.trantype}=\"" + ddl_product.SelectedValue + "\" and {DebitAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DebitAdvise", str_Script, true);
                    }
                }
                else if (ddl_product.SelectedValue == "AI")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {
                        //str_Frmname = "DebitAdvise";
                        str_RptName = "AIDebitAdvise.rpt";
                        str_sf = "{DebitAdvise.jobno}=" + txtJobno.Text.ToString() + " and {DebitAdvise.trantype}=\"" + ddl_product.SelectedValue + "\" and {DebitAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DebitAdvise", str_Script, true);
                    }
                }
                else if (ddl_product.SelectedValue == "FE")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {
                        //str_Frmname = "DebitAdvise";
                        str_RptName = "FEDebitAdvise.rpt";
                        str_sf = "{DebitAdvise.jobno}=" + txtJobno.Text.ToString() + " and {DebitAdvise.trantype}=\"" + ddl_product.SelectedValue + "\" and {DebitAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DebitAdvise", str_Script, true);
                    }
                }
                else if (ddl_product.SelectedValue == "FI")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {
                        //str_Frmname = "DebitAdvise";
                        str_RptName = "FIDebitAdvise.rpt";
                        str_sf = "{DebitAdvise.jobno}=" + txtJobno.Text + " and {DebitAdvise.trantype}=\"" + ddl_product.SelectedValue + "\" and {DebitAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "DebitAdvise", str_Script, true);
                    }
                }
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;

                switch (ddl_product.SelectedValue)
                {
                    case "FE":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " DAView");
                        break;

                    case "FI":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " DAView");
                        break;
                    case "AE":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " DAView");
                        break;
                    case "AI":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " DAView");
                        break;
                    case "CH":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " DAView");
                        break;
                }

            }

        }

        protected void btn_creditadvise_Click(object sender, EventArgs e)
        {
            DataAccess.LogDetails obj_da_log = new DataAccess.LogDetails();
            string str_RptName = "";
            // string str_Frmname = "";
            string str_sp = "";
            string str_sf = "";
            string str_Script = "";
            if (grdcredit.Rows.Count > 0)
            {

                if (ddl_product.SelectedValue == "AE")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {
                        // str_Frmname = "Credit Advise";
                        str_RptName = "AECreditAdvise.rpt";
                        str_sf = "{CreditAdvise.jobno}=" + txtJobno.Text + " and {CreditAdvise.trantype}=\"" + ddl_product.SelectedValue + "\"and {CreditAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Credit Advise", str_Script, true);
                    }
                }
                else if (ddl_product.SelectedValue == "AI")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {
                        // str_Frmname = "Credit Advise";
                        str_RptName = "AICreditAdvise.rpt";
                        str_sf = "{CreditAdvise.jobno}=" + txtJobno.Text + " and {CreditAdvise.trantype}=\"" + ddl_product.SelectedValue + "\" and {CreditAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Credit Advise", str_Script, true);
                    }
                }
                else if (ddl_product.SelectedValue == "FE")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {
                        //str_Frmname = "Credit Advise";
                        str_RptName = "FECreditAdvise.rpt";
                        str_sf = "{CreditAdvise.jobno}=" + txtJobno.Text + " and {CreditAdvise.trantype}=\"" + ddl_product.SelectedValue + "\" and {CreditAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Credit Advise", str_Script, true);
                    }
                }
                else if (ddl_product.SelectedValue == "FI")
                {
                    if (txtJobno.Text == "")
                    {
                    }
                    else
                    {

                        str_RptName = "FICreditAdvise.rpt";
                        str_sf = "{CreditAdvise.jobno}=" + txtJobno.Text.ToString() + " and {CreditAdvise.trantype}=\"" + ddl_product.SelectedValue + "\" and {CreditAdvise.branchid}=" + Session["LoginBranchid"].ToString();
                        
                        str_Script = "window.open('../Tools/ReportView.aspx?SFormula=" + str_sf + "&Parameter=" + str_sp + "&RFName=" + str_RptName + "&" + this.Page.ClientQueryString + "','','');";
                        ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Credit Advise", str_Script, true);
                    }
                }
                Session["str_sfs"] = str_sf;
                Session["str_sp"] = str_sp;

                switch (ddl_product.SelectedValue)
                {
                    case "FE":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " CAView");
                        break;
                    case "FI":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " CAView");
                        break;
                    case "AE":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " CAView");
                        break;
                    case "AI":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " CAView");
                        break;
                    case "CH":
                        obj_da_log.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + " CAView");
                        break;
                }

            }


        }


        protected void btn_No_1_Click(object sender, EventArgs e)
        {
            int jobno = Convert.ToInt32(txtJobno.Text);
            Response.Redirect("../Accounts/OSDCN.aspx?typejobno=" + jobno);
        }

        protected void btn_Yes_1_Click(object sender, EventArgs e)
        {
            double fcamt = 0;
            hid_yes.Value = "0";
            hid_No.Value = "0";
            hid_debitDnno.Value = "0";
            hid_DebitCredit.Value = "0";
            hid_creditDnno.Value = "0";
            double amtnew = 0;
            strTranType = ddl_product.SelectedValue;
            // debittotal = 0;
            // credittotal = 0;
            // total = 0.0;
            DataSet ds = new DataSet();
            //lbl.Text = "";
            txtdcn.Text = "";
            if (txtdcn.Text == "")
            {
                ds = OSDNCN.RptOSDNCNProFromJobNoForNewEmptyOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
            }
            else
            {
                ds = OSDNCN.RptOSDNCNProFromJobNoForNewOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
            }
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    jobno = Convert.ToInt32(dt.Rows[0][4].ToString());
                    //if (strTranType == "FE")
                    //{
                    //    hid_jobtype.Value = dt.Rows[0]["jobtype"].ToString();
                    //    if (hid_jobtype.Value == "2")
                    //    {


                    //        btnview.Enabled = false;
                    //        btnview.ForeColor = System.Drawing.Color.Gray;
                    //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtJobno.Text + " is assigned for Co-Load. You cannot raise Voucher');", true);

                    //    }
                    //    else
                    //    {
                    //        btnview.Enabled = true;
                    //        btnview.ForeColor = System.Drawing.Color.White;
                    //    }
                    //}
                    // txtcustomer.Text = dt.Rows[0][0].ToString() + Environment.NewLine + dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                    txtcustomer.Text = dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                    //txt_Agent.Text = dt.Rows[0][0].ToString();
                    ////agentid
                    //if (string.IsNullOrEmpty(dt.Rows[0]["agentid"].ToString()) != true)
                    //{
                    //    hid_SupplyTo.Value = dt.Rows[0]["agentid"].ToString();
                    //    hid_intagent.Value = dt.Rows[0]["agentid"].ToString();
                    //}
                    //txtsupplyto.Text = dt.Rows[0][0].ToString();
                    if (strTranType == "FE" || strTranType == "FI")
                    {
                        txtshipment.Text = "Vessel / Voyage  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                        //{
                        //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                        //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                        //}

                    }
                    else
                    {
                        txtshipment.Text = "Flight # / Date  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                        //{
                        //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                        //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                        //}

                    }


                    //    DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginDivisionId"]));
                    //    if (DtBLNO.Rows.Count > 0)
                    //    {
                    //        mblno = DtBLNO.Rows[0][0].ToString();
                    //    }


                    //    double amt = 0, amt1 = 0, amt2 = 0;
                    //    DataTable dtdc = new DataTable();
                    //    // dtdc = ds.Tables[1];
                    //    //grddebit.DataSource = dtdc;
                    //    //grddebit.DataBind();
                    //    DataTable dtnew = new DataTable();
                    //    DataTable dtcc = new DataTable();
                    //    //dtcc = ds.Tables[2];
                    //    //grdcredit.DataSource = dtcc;
                    //    //grdcredit.DataBind();

                    //    if (ds.Tables[1].Rows.Count > 0)
                    //    {
                    //        dtdc = ds.Tables[1];
                    //    }
                    //    else
                    //    {

                    //    }
                    //    if (ds.Tables[2].Rows.Count > 0)
                    //    {
                    //        dtnew = ds.Tables[2];
                    //    }


                    //    DataTable dtnew1 = new DataTable();
                    //    DataTable dtcc1 = new DataTable();
                    //    dtnew1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, "OSSI", Convert.ToInt32(hf_branchid.Value));
                    //    dtcc1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, "OSPI", Convert.ToInt32(hf_branchid.Value));

                    //    if (dtnew1.Rows.Count > 0)
                    //    {
                    //        int n = 0;
                    //        n = Convert.ToInt32(dtnew1.Rows[0][0].ToString());

                    //        if (n != 0)
                    //        {
                    //            // txtdcn.Text = n.ToString();
                    //            // this.PopUpService.Show();
                    //            //return;
                    //        }

                    //    }
                    //    if (dtcc1.Rows.Count > 0)
                    //    {
                    //        int n = 0;
                    //        n = Convert.ToInt32(dtcc1.Rows[0][0].ToString());
                    //        if (n != 0)
                    //        {
                    //            //txtdcn.Text = n.ToString();
                    //            //this.PopUpService.Show();
                    //            //return;
                    //        }
                    //    }

                    //    //if (dtdc.Rows.Count > 0 || dtnew.Rows.Count > 0)
                    //    //{

                    //    //}
                    //    if (dtdc.Rows.Count > 0)
                    //    {
                    //        double Total = 0;
                    //        DataTable dtempty = new DataTable();
                    //        dtempty.Columns.Add("blno", typeof(string));
                    //        dtempty.Columns.Add("chargename", typeof(string));
                    //        dtempty.Columns.Add("curr", typeof(string));
                    //        dtempty.Columns.Add("rate", typeof(string));
                    //        dtempty.Columns.Add("exrate", typeof(string));
                    //        dtempty.Columns.Add("bASe", typeof(string));
                    //        dtempty.Columns.Add("withoutgstAmt", typeof(string));
                    //        dtempty.Columns.Add("stgst", typeof(string));
                    //        dtempty.Columns.Add("amount", typeof(string));
                    //        dtempty.Columns.Add("chargeid", typeof(int));
                    //        dtempty.Columns.Add("GSTCHK", typeof(string));
                    //        dtempty.Columns.Add("prodn", typeof(string));
                    //        dtempty.Columns.Add("dnno", typeof(string));
                    //        dtempty.Columns.Add("vouyear", typeof(string));
                    //        dtempty.Columns.Add("fcamt", typeof(string));
                    //        DataRow dr = dtempty.NewRow();

                    //        if (dtdc.Rows.Count > 0)
                    //        {
                    //            for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                    //            {
                    //                dr = dtempty.NewRow();
                    //                dtempty.Rows.Add(dr);
                    //                dr[0] = dtdc.Rows[i]["blno"].ToString();
                    //                dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                    //                dr[2] = dtdc.Rows[i]["curr"].ToString();
                    //                dr[3] = dtdc.Rows[i]["rate"].ToString();
                    //                dr[4] = dtdc.Rows[i]["exrate"].ToString();
                    //                dr[5] = dtdc.Rows[i]["bAse"].ToString();

                    //                if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                    //                {
                    //                    amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                    //                    dr[6] = amt.ToString("#0.00");
                    //                }
                    //                else
                    //                {
                    //                    dr[6] = "0.00";
                    //                }
                    //                if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                    //                {
                    //                    amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                    //                    dr[7] = amt1.ToString("#0.00");
                    //                }
                    //                else
                    //                {
                    //                    dr[7] = "0.00";
                    //                }
                    //                if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                    //                {
                    //                    amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                    //                    dr[8] = amt1.ToString("#0.00");
                    //                }
                    //                else
                    //                {
                    //                    dr[8] = "0.00";
                    //                }
                    //                dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                    //                dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                    //                dr[11] = dtdc.Rows[i]["prodn"].ToString();
                    //                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                    //                {
                    //                    chk_GstApp.Checked = true;
                    //                    //  chk_GstApp.Enabled = false;
                    //                }
                    //                else
                    //                {
                    //                    chk_GstApp.Checked = true;
                    //                    //chk_GstApp.Enabled = false;
                    //                }
                    //                dr[12] = dtdc.Rows[i]["dnno"].ToString();
                    //                dr[13] = dtdc.Rows[i]["vouyear"].ToString();

                    //                Total = Total + double.Parse(dr[8].ToString());
                    //                if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                    //                {
                    //                    dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                    //                    fcamt = fcamt + (Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString()));
                    //                }
                    //                else
                    //                {
                    //                    fcamt = fcamt + 0;
                    //                }
                    //            }
                    //        }
                    //        txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                    //        grddebit.DataSource = dtempty;
                    //        grddebit.DataBind();
                    //    }



                    //    dtnew = ds.Tables[2];
                    //    if (dtnew.Rows.Count > 0)
                    //    {
                    //        double Total = 0;
                    //        DataTable dtempty1 = new DataTable();
                    //        dtempty1.Columns.Add("blno", typeof(string));
                    //        dtempty1.Columns.Add("chargename", typeof(string));
                    //        dtempty1.Columns.Add("curr", typeof(string));
                    //        dtempty1.Columns.Add("rate", typeof(string));
                    //        dtempty1.Columns.Add("exrate", typeof(string));
                    //        dtempty1.Columns.Add("bASe", typeof(string));
                    //        dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                    //        dtempty1.Columns.Add("stgst", typeof(string));
                    //        dtempty1.Columns.Add("amount", typeof(string));
                    //        dtempty1.Columns.Add("chargeid", typeof(int));
                    //        dtempty1.Columns.Add("GSTCHK", typeof(string));

                    //        dtempty1.Columns.Add("procn", typeof(string));
                    //        dtempty1.Columns.Add("cnno", typeof(string));
                    //        dtempty1.Columns.Add("vouyear", typeof(string));
                    //        dtempty1.Columns.Add("fcamt", typeof(string));
                    //        DataRow dr = dtempty1.NewRow();

                    //        if (dtnew.Rows.Count > 0)
                    //        {
                    //            for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                    //            {
                    //                dr = dtempty1.NewRow();
                    //                dtempty1.Rows.Add(dr);
                    //                dr[0] = dtnew.Rows[i]["blno"].ToString();
                    //                dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                    //                dr[2] = dtnew.Rows[i]["curr"].ToString();
                    //                dr[3] = dtnew.Rows[i]["rate"].ToString();
                    //                dr[4] = dtnew.Rows[i]["exrate"].ToString();
                    //                dr[5] = dtnew.Rows[i]["bAse"].ToString();

                    //                if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                    //                {
                    //                    amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                    //                    dr[6] = amt.ToString("#0.00");
                    //                }
                    //                else
                    //                {
                    //                    dr[6] = "0.00";
                    //                }
                    //                if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                    //                {
                    //                    amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                    //                    dr[7] = amt1.ToString("#0.00");
                    //                }
                    //                else
                    //                {
                    //                    dr[7] = "0.00";
                    //                }
                    //                if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                    //                {
                    //                    amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                    //                    dr[8] = amt1.ToString("#0.00");
                    //                }
                    //                else
                    //                {
                    //                    dr[8] = "0.00";
                    //                }
                    //                dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                    //                dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();
                    //                dr[11] = dtnew.Rows[i]["procn"].ToString();
                    //                if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                    //                {
                    //                    chk_GstApp.Checked = true;
                    //                    // chk_GstApp.Enabled = false;
                    //                }
                    //                else
                    //                {
                    //                    chk_GstApp.Checked = true;
                    //                    // chk_GstApp.Enabled = false;
                    //                }
                    //                dr[12] = dtnew.Rows[i]["cnno"].ToString();
                    //                dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                    //                Total = Total + double.Parse(dr[8].ToString());

                    //                if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                    //                {
                    //                    dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                    //                    fcamt = fcamt + (Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString()));
                    //                }
                    //                else
                    //                {
                    //                    fcamt = fcamt + 0;
                    //                }
                    //            }
                    //        }

                    //        txt_FcCramt.Text = fcamt.ToString("#0.00");

                    //        grdcredit.DataSource = dtempty1;
                    //        grdcredit.DataBind();
                    //    }

                    //    double tot = 0, tot1 = 0;
                    //    for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                    //    {
                    //        tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[8].Text);
                    //        tot = tot + tot1;
                    //    }
                    //    txtDebit.Text = tot.ToString("#,0.00");
                    //    for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                    //    {
                    //        amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[8].Text);
                    //        amtnew = amtnew + amt1;
                    //    }
                    //    txtCredit.Text = amtnew.ToString("#,0.00");

                    //    if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                    //    {
                    //        Toatlnew = tot - amtnew;
                    //        if (Toatlnew < 0)
                    //        {
                    //            lblGross.Text = "Payable to Agent:";
                    //            txttotal.Text = Toatlnew.ToString("#0.00");
                    //        }
                    //        else
                    //        {
                    //            lblGross.Text = "Receivable from Agent:";
                    //            txttotal.Text = Toatlnew.ToString("#0.00");

                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                    //        {
                    //            txttotal.Text = txtCredit.Text;
                    //        }
                    //        else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                    //        {
                    //            txttotal.Text = txtDebit.Text;
                    //        }
                    //    }

                    //    btnback.Text = "Cancel";
                    //}
                    //else
                    //{
                    //    txtclear();
                    //    return;
                    //}


                    btnview.Text = "Save";
                    btnview.Enabled = true;
                    btnview.ForeColor = System.Drawing.Color.White;
                }


            }
        }

        protected void txt_Agent_TextChanged(object sender, EventArgs e)
        {
            if (txt_Agent.Text != "")
            {
                if (hid_intagent.Value == "" || hid_intagent.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "JobInfo", "alertify.alert('Invalid Agent');", true);
                    txt_Agent.Text = "";
                    txt_Agent.Focus();
                    return;
                }
                else
                {

                    dtnew = cus.getcustomerblk(Convert.ToInt32(hid_intagent.Value));
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('The customer " + txt_Agent.Text + " is under Hold!! please discuss with Finance Team ');", true);
                        txtsupplyto.Text = "";
                        txtsupplyto.Focus();
                        return;
                    }


                    txtsupplyto.Text = txt_Agent.Text;
                    hid_SupplyTo.Value = hid_intagent.Value;
                    txtcustomer.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hid_intagent.Value));



                }


            }
        }

        protected void btnAdd_OneOrMore_Click(object sender, EventArgs e)
        {
            try
            {
                btnview.Text = "Save";
                btnview.Enabled = true;
                btnview.ForeColor = System.Drawing.Color.White;
                txtdcn.Text = "";
                popup_Grd.Hide();
                hid_intagent.Value = "0";
                hid_SupplyTo.Value = "0";
                //  double fcamt = 0;
                hid_yes.Value = "0";
                hid_No.Value = "0";
                hid_debitDnno.Value = "0";
                hid_DebitCredit.Value = "0";
                hid_creditDnno.Value = "0";
                // double amtnew = 0;
                strTranType = ddl_product.SelectedValue;
                // debittotal = 0;
                //credittotal = 0;
                // total = 0.0;
                DataSet ds = new DataSet();
                //lbl.Text = "";
                txtdcn.Text = "";
                if (txtdcn.Text != "")
                {
                    ddlDebiteOrCredite.Enabled = false;
                }
                else
                {
                    ddlDebiteOrCredite.Enabled = true;

                }
                if (txtdcn.Text == "")
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewEmptyOSV(strTranType, Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }
                else
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        jobno = Convert.ToInt32(dt.Rows[0][4].ToString());
                        //txtcustomer.Text = dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                        txtcustomer.Text = "";
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            txtshipment.Text = "Vessel / Voyage  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();


                        }
                        else
                        {
                            txtshipment.Text = "Flight # / Date  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();


                        }
                    }
                }
                DataSet dts = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                dts = OSDNCN.GetOSDCNnotraisedOSV(strTranType, Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                dt1 = dts.Tables[0];
                dt2 = dts.Tables[1];
                if (dts.Tables.Count > 0)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        grdcredit.DataSource = dt1;
                        grdcredit.DataBind();
                    }
                    else
                    {

                        grdcredit.DataSource = Utility.Fn_GetEmptyDataTable();
                        grdcredit.DataBind();

                    }
                    if (dt2.Rows.Count > 0)
                    {
                        grddebit.DataSource = dt2;
                        grddebit.DataBind();
                    }
                    else
                    {
                        grddebit.DataSource = Utility.Fn_GetEmptyDataTable();
                        grddebit.DataBind();
                    }

                    if (dt1.Rows.Count == 0 && dt2.Rows.Count == 0)
                    {
                        //ddlTypes.Enabled = false;
                    }
                    else
                    {
                        ddlTypes.Enabled = true;
                    }

                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void Grd_Details_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Enabled = false;
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Details, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[0].Text != "CreditNote" && e.Row.Cells[0].Text != "DebitNote")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Details, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }
        }

        protected void Grd_Details_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Grd_Details.Rows.Count > 0)
            {
                int index = Grd_Details.SelectedRow.RowIndex;
                int jobno = Convert.ToInt32(Grd_Details.Rows[index].Cells[0].Text);
                int jobno1 = Convert.ToInt32(Grd_Details.Rows[index].Cells[1].Text);
                string typenew = Grd_Details.Rows[index].Cells[3].Text;
                // Response.Redirect("../Accounts/OSDCN.aspx?typejobno=" + jobno);
                Response.Redirect("../Accounts/OSDCN.aspx?typejobno=" + jobno + "&typenew=" + typenew + "&jobno1=" + jobno1);
            }

        }

        protected void grd_prodetails_RowDataBound(object sender, GridViewRowEventArgs e)
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

                e.Row.Enabled = false;
                e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_prodetails, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                if (e.Row.Cells[0].Text != "Pro CreditNote" && e.Row.Cells[0].Text != "Pro DebitNote")
                {
                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grd_prodetails, "Select$" + e.Row.RowIndex);
                    e.Row.Attributes["style"] = "cursor:pointer";
                }
            }

        }

        protected void grd_prodetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_prodetails.Rows.Count > 0)
            {
                string name = "";
                int index = grd_prodetails.SelectedRow.RowIndex;
                int jobno = Convert.ToInt32(grd_prodetails.Rows[index].Cells[0].Text);
                name = grd_prodetails.Rows[index].Cells[3].Text;
                txtdcn.Text = jobno.ToString();

                int jobno1 = Convert.ToInt32(grd_prodetails.Rows[index].Cells[1].Text);

                txtJobno.Text = jobno1.ToString();
                if (name == "OSSI")
                {
                    ddlTypes.SelectedValue = "5";

                }
                else if (name == "OSPI")
                {
                    ddlTypes.SelectedValue = "6";
                }
                ddlTypes_SelectedIndexChanged(sender, e);
                txtdcn_TextChanged(sender, e);
            }
        }

        protected void btn_MoreCust_Yes_Click(object sender, EventArgs e)
        {
            hid_MoreOne.Value = "Yes";
            this.popup_MoreAgent.Hide();
            DataTable dtnew = new DataTable();
            string Inco = "";
            strTranType = ddl_product.SelectedValue;

            if (btnAdd.Text == "Update")
            {
                cmbbase_SelectedIndexChanged(sender, e);
            }

            if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
            {
                douvolume = Convert.ToDouble(hid_douvolume.Value);
            }
            else
            {
                douvolume = 0;
            }


            if (string.IsNullOrEmpty(hid_fd.Value) != true)
            {
                fd = Convert.ToInt32(hid_fd.Value);
            }
            else
            {
                fd = 0;
            }
            int Ctype = 0;
            string FOSCNDNtype = "";
            DataTable DtCtype = new DataTable();
            if (hid_No.Value == "NO")
            {
                Ctype = Convert.ToInt32(ddlDebiteOrCredite.SelectedValue);
                DtCtype = OSDNCN.GetAppDetails4OSV(Ctype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtJobno.Text), strTranType);

                if (DtCtype.Rows.Count > 0)
                {
                    FOSCNDNtype = DtCtype.Rows[0][0].ToString();

                    if (FOSCNDNtype == "No")
                    {

                        if (Ctype == 5)
                        {
                            btnAdd.Enabled = false;
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already OSDN Raised For this job.Kindly create one more Voucher for this job');", true);

                            if (ddlTypes.SelectedValue != "0")
                            {
                                txtdcn.Focus();
                            }
                            else
                            {
                                txtJobno.Focus();
                            }
                            return;
                        }
                        else
                        {
                            btnAdd.Enabled = false;
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already OSCN Raised For this job.Kindly create one more Voucher for this job');", true);
                            if (ddlTypes.SelectedValue != "0")
                            {
                                txtdcn.Focus();
                            }
                            else
                            {
                                txtJobno.Focus();
                            }
                            return;
                        }

                    }
                }
            }
            string gst = "";
            if (hid_yesno.Value == "NO")
            {
                gst = "N";

            }
            else
            {
                gst = "Y";
            }
            if (btnAdd.Text == "Add")
            {


                if (ddlDebiteOrCredite.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                    ddlDebiteOrCredite.Focus();
                    return;
                }
                if (cmbbl.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                    cmbbl.Focus();
                    return;
                }
                if (cmbbase.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                    return;
                }
                if (txt_Agent.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Agent cannot be blank');", true);
                    bolcuststat = false;
                    txt_Agent.Focus();
                    return;
                }
                else
                {
                    if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }

                }
                //OSDNCN
                CheckChargeBase();
                if (chargename > 0 && cbase > 0)
                {
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exist');", true);
                    cmbbase.Focus();
                    return;

                }
                //txt_Agent.ReadOnly = true;
                //txtsupplyto.ReadOnly = true;



                if (txtsupplyto.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
                    bolcuststat = false;
                    return;
                }
                else
                {
                    // str_booking = obj_da_FIBL.GetBookinkNo(cmbbl.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                    dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                    if (dtnew.Rows.Count > 0)
                    {
                        Inco = dtnew.Rows[0][0].ToString();
                    }
                    if (Inco != "EXW")
                    {
                        // return;
                    }
                    else
                    {
                        //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                        //if (bolcuststat == true)
                        //{
                        //    bolcuststat = false;
                        //    return;
                        //}
                    }

                }
                //}

                if (grdcredit.Rows.Count > 0)
                {
                    if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                        txtcurr.Focus();
                        return;
                    }


                }

                if (grddebit.Rows.Count > 0)
                {

                    if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                        txtcurr.Focus();
                        return;
                    }

                }

                if (chk_GstApp.Checked == true)
                {
                    chk = "Y";
                }

                if (Inco != "EXW")
                {
                    if (chk_GstApp.Checked == true)
                    {
                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = false;
                        DAdvise.InsDCAdviseForGstservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), gst);
                    }
                    else
                    {
                        DAdvise.InsDCAdviseForAgentservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_intagent.Value), gst);

                    }
                }
                else
                {
                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }
                    chk_GstApp.Checked = true;
                    // chk_GstApp.Enabled = false;
                    DAdvise.InsDCAdviseForGstservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), gst);
                    //
                }

                if (ddlDebiteOrCredite.SelectedValue == "5")
                {

                    if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                    {
                        DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_debitDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), 5);
                    }

                }
                else
                {
                    if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                    {
                        DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_creditDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), 6);
                    }
                }


                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved');", true);
                switch (ddl_product.SelectedValue)
                {
                    case "FE":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "FI":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "AE":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "AI":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "CH":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                }



                GrdLoad(ddlDebiteOrCredite.SelectedValue);
                Clear_Fin();
                //chk_GstApp.Enabled = true;
                // chk_GstApp.Checked = false;
                btnprint.Enabled = true;

            }
            else if (btnAdd.Text == "Update")
            {
                dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                if (dtnew.Rows.Count > 0)
                {
                    Inco = dtnew.Rows[0][0].ToString();
                }
                if (Inco != "EXW")
                {
                    // return;
                }
                else
                {
                    //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                    //if (bolcuststat == true)
                    //{
                    //    bolcuststat = false;
                    //    return;
                    // }
                }
                if (ddlDebiteOrCredite.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                    ddlDebiteOrCredite.Focus();
                    return;
                }
                if (cmbbl.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                    cmbbl.Focus();
                    return;
                }
                if (cmbbase.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                    return;
                }

                DataTable DtAgent = new DataTable();
                DtAgent = OSDNCN.CheckForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(hid_intagent.Value));
                if (DtAgent.Rows.Count > 0)
                {
                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {
                        if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                        {

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already  Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                            return;
                        }
                    }
                    else if (ddlDebiteOrCredite.SelectedValue == "6")
                    {
                        if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                        {
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                            return;
                        }

                    }

                }
                //txt_Agent.ReadOnly = true;
                //txtsupplyto.ReadOnly = true;
                index = Convert.ToInt32(Session["index"]);
                if (ddlDebiteOrCredite.SelectedValue == "5")
                {
                    strbase = grddebit.Rows[index].Cells[6].Text;
                }
                else if (ddlDebiteOrCredite.SelectedValue == "6")
                {
                    strbase = grdcredit.Rows[index].Cells[6].Text;
                }
                //  index = grd.SelectedRow.RowIndex;
                if (chk_GstApp.Checked == true)
                {
                    chk = "Y";
                }



                if (grdcredit.Rows.Count > 0)
                {
                    if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                        txtcurr.Focus();
                        return;
                    }


                }

                if (grddebit.Rows.Count > 0)
                {

                    if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                        txtcurr.Focus();
                        return;
                    }

                }
                if (Inco != "EXW")
                {
                    if (chk_GstApp.Checked == true)
                    {
                        chk_GstApp.Checked = true;
                        //   chk_GstApp.Enabled = false;
                        if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                        {
                            DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value), gst);
                        }
                        else
                        {
                            DAdvise.UpdDCAdviseForGstservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), gst);
                        }

                    }
                    else
                    {

                        if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                        {
                            DAdvise.UpdDCAdviseForNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value));

                        }
                        else
                        {
                            DAdvise.UpdDCAdviseNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_intagent.Value));

                        }
                    }
                }
                else
                {

                    chk_GstApp.Checked = true;
                    // chk_GstApp.Enabled = false;
                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }
                    if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                    {
                        DAdvise.UpdDCAdviseForGstForNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value));
                    }
                    else
                    {
                        DAdvise.UpdDCAdviseForGstForagentOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value));
                    }

                }

                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);


                switch (ddl_product.SelectedValue)
                {
                    case "FE":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "FI":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "AE":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "AI":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                    case "CH":
                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                        break;
                }

                //switch (ddl_product.SelectedValue)
                //{
                //    case "FE":
                //        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 36, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                //        break;
                //    case "FI":
                //        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 37, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                //        break;
                //    case "AE":
                //        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 38, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                //        break;
                //    case "AI":
                //        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 39, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                //        break;
                //}
                //chargetxtclear();
                GrdLoad(ddlDebiteOrCredite.SelectedValue);
                Clear_Fin();
                btnAdd.Text = "Add";
                btnprint.Enabled = true;
                txtcharge.Enabled = true;
                //  chk_GstApp.Enabled = true;
                //chk_GstApp.Checked = false;
                txtcharge.ForeColor = Color.Black;
                cmbbase.Enabled = true;
                cmbbase.ForeColor = Color.Black;
            }
        }

        protected void btn_MoreCust_No_Click(object sender, EventArgs e)
        {
            return;
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
            switch (ddl_product.SelectedValue)
            {
                case "FE":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1015, "", cmbbl.Text, cmbbl.Text, ddl_product.SelectedValue);
                    break;
                case "FI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1022, "", cmbbl.Text, cmbbl.Text, ddl_product.SelectedValue);
                    break;
                case "AE":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1029, "", cmbbl.Text, cmbbl.Text, ddl_product.SelectedValue);
                    break;
                case "AI":
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1036, "", cmbbl.Text, cmbbl.Text, ddl_product.SelectedValue);
                    break;
            }
            if (cmbbl.Text != "")
            {
                JobInput.Text = cmbbl.Text;
            }

            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
            }
        }


        //protected void lnk_job_Click(object sender, EventArgs e)
        //{
        //    loadgrid();
        //}

        //protected void loadgrid()
        //{
        //    Grd_Job.Visible = true;
        //    //  Grd_Vessel.Visible = false;
        //    DataAccess.ForwardingExports.JobInfo obj_da_jobinfo = new DataAccess.ForwardingExports.JobInfo();
        //    DataTable obj_dt = new DataTable();
        //    obj_dt = obj_da_jobinfo.GetJobNoList(int.Parse(Session["LoginBranchid"].ToString()), int.Parse(Session["LoginDivisionId"].ToString()));
        //    if (obj_dt.Rows.Count <= 0)
        //    {
        //        ScriptManager.RegisterStartupScript(lnk_job, typeof(LinkButton), "JobInfo", "alertify.alert('Job Not Available');", true);
        //        return;
        //    }
        //    else
        //    {
        //        popup_Grd.Show();
        //        Grd_Job.DataSource = obj_dt;
        //        Grd_Job.DataBind();
        //        // txt_date1.Enabled = true;
        //    }
        //}
        //protected void Grd_Job_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            for (int i = 0; i < e.Row.Cells.Count; i++)
        //            {
        //                if (e.Row.Cells[i].Text == "&nbsp;")
        //                {
        //                    e.Row.Cells[i].Text = "";
        //                }
        //                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
        //            }
        //            Label lblCustomer = (Label)e.Row.FindControl("mlo");
        //            string tooltip = lblCustomer.Text;
        //            e.Row.Cells[8].Attributes.Add("title", tooltip);
        //            Label lblCustomer1 = (Label)e.Row.FindControl("vessel");
        //            string tooltip1 = lblCustomer1.Text;
        //            e.Row.Cells[2].Attributes.Add("title", tooltip1);

        //            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
        //            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

        //            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grd_Job, "Select$" + e.Row.RowIndex);
        //            e.Row.Attributes["style"] = "cursor:pointer";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }
        //}

        //protected void Grd_Job_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    int index = 0;
        //    index = Grd_Job.SelectedRow.RowIndex;
        //    Label lbl = (Label)Grd_Job.Rows[index].FindControl("Job");
        //    txtJobno.Text = lbl.Text;
        //    txtJobno_TextChanged(sender, e);

        //}


        protected void btn_serviceyes_Click(object sender, EventArgs e)
        {

            try
            {
                hid_yesno.Value = "Yes";

                DataTable dtnew = new DataTable();
                string Inco = "";
                strTranType = ddl_product.SelectedValue;

                if (btnAdd.Text == "Update")
                {
                    cmbbase_SelectedIndexChanged(sender, e);
                }

                if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
                {
                    douvolume = Convert.ToDouble(hid_douvolume.Value);
                }
                else
                {
                    douvolume = 0;
                }


                if (string.IsNullOrEmpty(hid_fd.Value) != true)
                {
                    fd = Convert.ToInt32(hid_fd.Value);
                }
                else
                {
                    fd = 0;
                }
                int Ctype = 0;
                string FOSCNDNtype = "";
                DataTable DtCtype = new DataTable();
                DataTable DtCHeckNew = new DataTable();
                DtCHeckNew = OSDNCN.GetCheckcloseUnclose(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), strTranType);
                //if (DtCHeckNew.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has been already closed.So you cannot add Charges');", true);
                //    return;
                //}
                if (hid_yesno.Value == "NO")
                {
                    Ctype = Convert.ToInt32(ddlDebiteOrCredite.SelectedValue);
                    DtCtype = OSDNCN.GetAppDetails4OSV(Ctype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString());

                    /*if (DtCtype.Rows.Count > 0)
                    {
                        FOSCNDNtype = DtCtype.Rows[0][0].ToString();

                        if (FOSCNDNtype == "No")
                        {

                            if (Ctype == "OSSI")
                            {
                                btnAdd.Enabled = false;
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already OSDN Raised For this job.Kindly create one more Voucher for this job');", true);

                                if (ddlTypes.SelectedValue != "0")
                                {
                                    txtdcn.Focus();
                                }
                                else
                                {
                                    txtJobno.Focus();
                                }
                                return;
                            }
                            else
                            {
                                btnAdd.Enabled = false;
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already OSCN Raised For this job.Kindly create one more Voucher for this job');", true);
                                if (ddlTypes.SelectedValue != "0")
                                {
                                    txtdcn.Focus();
                                }
                                else
                                {
                                    txtJobno.Focus();
                                }
                                return;
                            }

                        }
                    }*/
                }

                if (btnAdd.Text == "Add")
                {


                    if (ddlDebiteOrCredite.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                        ddlDebiteOrCredite.Focus();
                        return;
                    }
                    if (cmbbl.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                        cmbbl.Focus();
                        return;
                    }
                    if (cmbbase.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                        return;
                    }
                    if (txt_Agent.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Agent cannot be blank');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }
                    //else
                    //{
                    if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }

                    //}
                    DataTable DtAgent = new DataTable();
                    DtAgent = OSDNCN.CheckForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(hid_intagent.Value));
                    if (DtAgent.Rows.Count > 0)
                    {
                        if (ddlDebiteOrCredite.SelectedValue == "5")
                        {
                            if (hid_MoreOne.Value != "Yes")
                            {
                                if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                                {

                                }
                                else
                                {
                                    lbl_addMorAgent.Text = "Already Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " has been raised for this Agent   " + DtAgent.Rows[0][1].ToString() + ".. Do you want to add are one more voucher";
                                    this.popup_MoreAgent.Show();
                                    // ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                    return;
                                }

                            }

                        }
                        else if (ddlDebiteOrCredite.SelectedValue == "6")
                        {
                            if (hid_MoreOne.Value != "Yes")
                            {
                                if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                                {
                                }
                                else
                                {
                                    lbl_addMorAgent.Text = "Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " has been raised for this Agent " + DtAgent.Rows[0][1].ToString() + "..Do you want to add are one more voucher";
                                    this.popup_MoreAgent.Show();
                                    // ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                    return;
                                }
                            }

                        }

                    }
                    //OSDNCN
                    CheckChargeBase();
                    if (chargename > 0 && cbase > 0)
                    {
                        GrdLoad(ddlDebiteOrCredite.SelectedValue);
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exist');", true);
                        cmbbase.Focus();
                        return;

                    }
                    //txt_Agent.ReadOnly = true;
                    //txtsupplyto.ReadOnly = true;



                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
                        bolcuststat = false;
                        return;
                    }
                    else
                    {
                        // str_booking = obj_da_FIBL.GetBookinkNo(cmbbl.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                        if (dtnew.Rows.Count > 0)
                        {
                            Inco = dtnew.Rows[0][0].ToString();
                        }
                        if (Inco != "EXW")
                        {
                            // return;
                        }
                        else
                        {
                            //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                            //if (bolcuststat == true)
                            //{
                            //    bolcuststat = false;
                            //    return;
                            //}
                        }

                    }
                    //}

                    if (grdcredit.Rows.Count > 0)
                    {
                        if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }


                    }

                    if (grddebit.Rows.Count > 0)
                    {

                        if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }

                    } DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

                    //if (ddlDebiteOrCredite.SelectedValue == "CreditAdvise")
                    //{
                    //    double stper;
                    //    stper = chargeobj.CheckChargeST(Convert.ToInt32(hdnChargid.Value));
                    //    if (stper > 0)
                    //    {
                    //        this.model_Servicetax.Show();
                    //        return;
                    //    }
                    //}


                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }


                    if (Inco != "EXW")
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk_GstApp.Checked = true;
                            // chk_GstApp.Enabled = false;
                            DAdvise.InsDCAdviseForGstservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "Y");
                        }
                        else
                        {
                            DAdvise.InsDCAdviseForAgentservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_intagent.Value), "Y");

                        }
                    }
                    else
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk = "Y";
                        }
                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = false;
                        DAdvise.InsDCAdviseForGstservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "Y");
                        //
                    }

                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {

                        if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                        {
                            DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_debitDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), 5);
                        }

                    }
                    else
                    {
                        if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                        {
                            DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_creditDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), 6);
                        }
                    }


                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved');", true);
                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "CH":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                    }

                    //chargetxtclear();
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    Clear_Fin();
                    //chk_GstApp.Enabled = true;
                    // chk_GstApp.Checked = false;
                    btnprint.Enabled = true;

                }
                else if (btnAdd.Text == "Update")
                {
                    if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }
                    if (hid_SupplyTo.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txtsupplyto.Focus();
                        return;
                    }

                    dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                    if (dtnew.Rows.Count > 0)
                    {
                        Inco = dtnew.Rows[0][0].ToString();
                    }
                    if (Inco != "EXW")
                    {
                        // return;
                    }
                    else
                    {
                        //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                        //if (bolcuststat == true)
                        //{
                        //    bolcuststat = false;
                        //    return;
                        // }
                    }
                    if (ddlDebiteOrCredite.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                        ddlDebiteOrCredite.Focus();
                        return;
                    }
                    if (cmbbl.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                        cmbbl.Focus();
                        return;
                    }
                    if (cmbbase.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                        return;
                    }

                    DataTable DtAgent = new DataTable();
                    DtAgent = OSDNCN.CheckForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(hid_intagent.Value));
                    if (DtAgent.Rows.Count > 0)
                    {
                        if (ddlDebiteOrCredite.SelectedValue == "5")
                        {
                            if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already  Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                return;
                            }
                        }
                        else if (ddlDebiteOrCredite.SelectedValue == "6")
                        {
                            if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                            {
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                return;
                            }

                        }

                    }
                    //txt_Agent.ReadOnly = true;
                    //txtsupplyto.ReadOnly = true;
                    index = Convert.ToInt32(Session["index"]);
                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {
                        strbase = grddebit.Rows[index].Cells[6].Text;
                    }
                    else if (ddlDebiteOrCredite.SelectedValue == "6")
                    {
                        strbase = grdcredit.Rows[index].Cells[6].Text;
                    }
                    //  index = grd.SelectedRow.RowIndex;
                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }



                    if (grdcredit.Rows.Count > 0)
                    {
                        if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }


                    }

                    if (grddebit.Rows.Count > 0)
                    {

                        if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }

                    }
                    if (Inco != "EXW")
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk_GstApp.Checked = true;
                            //   chk_GstApp.Enabled = false;
                            if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                            {
                                DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value), "Y");
                            }
                            else
                            {
                                DAdvise.UpdDCAdviseForGstservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "Y");
                            }

                        }
                        else
                        {

                            if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                            {
                                DAdvise.UpdDCAdviseForNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value));

                            }
                            else
                            {
                                DAdvise.UpdDCAdviseNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_intagent.Value));

                            }
                        }
                    }
                    else
                    {

                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = false;
                        if (chk_GstApp.Checked == true)
                        {
                            chk = "Y";
                        }
                        if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                        {
                            DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value), "Y");
                        }
                        else
                        {
                            DAdvise.UpdDCAdviseForGstservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "Y");
                        }

                    }

                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);


                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "CH":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                    }

                    //chargetxtclear();
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    Clear_Fin();
                    btnAdd.Text = "Add";
                    btnprint.Enabled = true;
                    txtcharge.Enabled = true;
                    //  chk_GstApp.Enabled = true;
                    //chk_GstApp.Checked = false;
                    txtcharge.ForeColor = Color.Black;
                    cmbbase.Enabled = true;
                    cmbbase.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_serviceno_Click(object sender, EventArgs e)
        {
            try
            {
                hid_yesno.Value = "NO";

                DataTable dtnew = new DataTable();
                string Inco = "";
                strTranType = ddl_product.SelectedValue;

                if (btnAdd.Text == "Update")
                {
                    cmbbase_SelectedIndexChanged(sender, e);
                }

                if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
                {
                    douvolume = Convert.ToDouble(hid_douvolume.Value);
                }
                else
                {
                    douvolume = 0;
                }


                if (string.IsNullOrEmpty(hid_fd.Value) != true)
                {
                    fd = Convert.ToInt32(hid_fd.Value);
                }
                else
                {
                    fd = 0;
                }
                int Ctype = 0;
                string FOSCNDNtype = "";
                DataTable DtCtype = new DataTable();
                DataTable DtCHeckNew = new DataTable();
                DtCHeckNew = OSDNCN.GetCheckcloseUnclose(Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), strTranType);
                //if (DtCHeckNew.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has been already closed.So you cannot add Charges');", true);
                //    return;
                //}
                if (hid_yesno.Value == "NO")
                {
                    Ctype = Convert.ToInt32(ddlDebiteOrCredite.SelectedValue);
                    DtCtype = OSDNCN.GetAppDetails4OSV(Ctype, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString());


                }

                if (btnAdd.Text == "Add")
                {


                    if (ddlDebiteOrCredite.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                        ddlDebiteOrCredite.Focus();
                        return;
                    }
                    if (cmbbl.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                        cmbbl.Focus();
                        return;
                    }
                    if (cmbbase.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                        return;
                    }
                    if (txt_Agent.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Agent cannot be blank');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }
                    //else
                    //{
                    if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }

                    //}
                    DataTable DtAgent = new DataTable();
                    DtAgent = OSDNCN.CheckForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(hid_intagent.Value));
                    if (DtAgent.Rows.Count > 0)
                    {
                        if (ddlDebiteOrCredite.SelectedValue == "5")
                        {
                            if (hid_MoreOne.Value != "Yes")
                            {
                                if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                                {

                                }
                                else
                                {
                                    lbl_addMorAgent.Text = "Already Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " has been raised for this Agent   " + DtAgent.Rows[0][1].ToString() + ".. Do you want to add are one more voucher";
                                    this.popup_MoreAgent.Show();
                                    // ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                    return;
                                }

                            }

                        }
                        else if (ddlDebiteOrCredite.SelectedValue == "6")
                        {
                            if (hid_MoreOne.Value != "Yes")
                            {
                                if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                                {
                                }
                                else
                                {
                                    lbl_addMorAgent.Text = "Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " has been raised for this Agent " + DtAgent.Rows[0][1].ToString() + "..Do you want to add are one more voucher";
                                    this.popup_MoreAgent.Show();
                                    // ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                    return;
                                }
                            }

                        }

                    }
                    //OSDNCN
                    CheckChargeBase();
                    if (chargename > 0 && cbase > 0)
                    {
                        GrdLoad(ddlDebiteOrCredite.SelectedValue);
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Exist');", true);
                        cmbbase.Focus();
                        return;

                    }
                    //txt_Agent.ReadOnly = true;
                    //txtsupplyto.ReadOnly = true;



                    if (txtsupplyto.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From ');", true);
                        bolcuststat = false;
                        return;
                    }
                    else
                    {
                        // str_booking = obj_da_FIBL.GetBookinkNo(cmbbl.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                        dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                        if (dtnew.Rows.Count > 0)
                        {
                            Inco = dtnew.Rows[0][0].ToString();
                        }
                        if (Inco != "EXW")
                        {
                            // return;
                        }
                        else
                        {
                            //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                            //if (bolcuststat == true)
                            //{
                            //    bolcuststat = false;
                            //    return;
                            //}
                        }

                    }
                    //}

                    if (grdcredit.Rows.Count > 0)
                    {
                        if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }


                    }

                    if (grddebit.Rows.Count > 0)
                    {

                        if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }

                    } DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

                    //if (ddlDebiteOrCredite.SelectedValue == "CreditAdvise")
                    //{
                    //    double stper;
                    //    stper = chargeobj.CheckChargeST(Convert.ToInt32(hdnChargid.Value));
                    //    if (stper > 0)
                    //    {
                    //        this.model_Servicetax.Show();
                    //        return;
                    //    }
                    //}


                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }


                    if (Inco != "EXW")
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk_GstApp.Checked = true;
                            // chk_GstApp.Enabled = false;
                            DAdvise.InsDCAdviseForGstservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "N");
                        }
                        else
                        {
                            DAdvise.InsDCAdviseForAgentservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_intagent.Value), "N");

                        }
                    }
                    else
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk = "Y";
                        }
                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = false;
                        DAdvise.InsDCAdviseForGstservisetaxOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "N");
                        //
                    }

                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {

                        if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                        {
                            DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_debitDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), 5);
                        }

                    }
                    else
                    {
                        if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                        {
                            DAdvise.InsForAcdebitcrediteadviseDtlsOSV(Convert.ToInt32(hid_creditDnno.Value), Convert.ToInt32(txtyear.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(hid_intagent.Value), 6);
                        }
                    }


                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved');", true);
                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "CH":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                    }

                    //chargetxtclear();
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    Clear_Fin();
                    //chk_GstApp.Enabled = true;
                    // chk_GstApp.Checked = false;
                    btnprint.Enabled = true;

                }
                else if (btnAdd.Text == "Update")
                {
                    if (hid_intagent.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txt_Agent.Focus();
                        return;
                    }
                    if (hid_SupplyTo.Value == "0" || hid_intagent.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Agent');", true);
                        bolcuststat = false;
                        txtsupplyto.Focus();
                        return;
                    }

                    dtnew = OSDNCN.GetIncoTemsVal(cmbbl.SelectedItem.Text);
                    if (dtnew.Rows.Count > 0)
                    {
                        Inco = dtnew.Rows[0][0].ToString();
                    }
                    if (Inco != "EXW")
                    {
                        // return;
                    }
                    else
                    {
                        //ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                        //if (bolcuststat == true)
                        //{
                        //    bolcuststat = false;
                        //    return;
                        // }
                    }
                    if (ddlDebiteOrCredite.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Receivable/Payable');", true);
                        ddlDebiteOrCredite.Focus();
                        return;
                    }
                    if (cmbbl.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select BlNumber');", true);
                        cmbbl.Focus();
                        return;
                    }
                    if (cmbbase.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Base Cannot Be Blank');", true);
                        return;
                    }

                    DataTable DtAgent = new DataTable();
                    DtAgent = OSDNCN.CheckForAgentOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(hid_intagent.Value));
                    if (DtAgent.Rows.Count > 0)
                    {
                        if (ddlDebiteOrCredite.SelectedValue == "5")
                        {
                            if (hid_debitDnno.Value != "0" && hid_debitDnno.Value != "")
                            {

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already  Pro OSDN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                return;
                            }
                        }
                        else if (ddlDebiteOrCredite.SelectedValue == "6")
                        {
                            if (hid_creditDnno.Value != "0" && hid_creditDnno.Value != "")
                            {
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Pro OSCN #" + DtAgent.Rows[0][0].ToString() + " hase been raise this job and " + DtAgent.Rows[0][1].ToString() + " ');", true);
                                return;
                            }

                        }

                    }
                    //txt_Agent.ReadOnly = true;
                    //txtsupplyto.ReadOnly = true;
                    index = Convert.ToInt32(Session["index"]);
                    if (ddlDebiteOrCredite.SelectedValue == "5")
                    {
                        strbase = grddebit.Rows[index].Cells[6].Text;
                    }
                    else if (ddlDebiteOrCredite.SelectedValue == "6")
                    {
                        strbase = grdcredit.Rows[index].Cells[6].Text;
                    }
                    //  index = grd.SelectedRow.RowIndex;
                    if (chk_GstApp.Checked == true)
                    {
                        chk = "Y";
                    }



                    if (grdcredit.Rows.Count > 0)
                    {
                        if (grdcredit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }


                    }

                    if (grddebit.Rows.Count > 0)
                    {

                        if (grddebit.Rows[0].Cells[3].Text != txtcurr.Text)
                        {
                            ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different Currency cannot be Accepted');", true);
                            txtcurr.Focus();
                            return;
                        }

                    }
                    if (Inco != "EXW")
                    {
                        if (chk_GstApp.Checked == true)
                        {
                            chk_GstApp.Checked = true;
                            //   chk_GstApp.Enabled = false;
                            if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                            {
                                DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value), "N");
                            }
                            else
                            {
                                DAdvise.UpdDCAdviseForGstservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "N");
                            }

                        }
                        else
                        {

                            if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                            {
                                DAdvise.UpdDCAdviseForNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value));

                            }
                            else
                            {
                                DAdvise.UpdDCAdviseNewOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_intagent.Value));

                            }
                        }
                    }
                    else
                    {

                        chk_GstApp.Checked = true;
                        // chk_GstApp.Enabled = false;
                        if (chk_GstApp.Checked == true)
                        {
                            chk = "Y";
                        }
                        if (hid_DebitCredit.Value != "0" && hid_DebitCredit.Value != "")
                        {
                            DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_DebitCredit.Value), Convert.ToInt32(hid_intagent.Value), "N");
                        }
                        else
                        {
                            DAdvise.UpdDCAdviseForGstservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtexrate.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddlDebiteOrCredite.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), chk, Convert.ToInt32(hid_intagent.Value), "N");
                        }

                    }

                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated');", true);


                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1015, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1022, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1029, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1036, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                        case "CH":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1969, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                            break;
                    }

                    //chargetxtclear();
                    GrdLoad(ddlDebiteOrCredite.SelectedValue);
                    Clear_Fin();
                    btnAdd.Text = "Add";
                    btnprint.Enabled = true;
                    txtcharge.Enabled = true;
                    //  chk_GstApp.Enabled = true;
                    //chk_GstApp.Checked = false;
                    txtcharge.ForeColor = Color.Black;
                    cmbbase.Enabled = true;
                    cmbbase.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
        }

        protected void grddebit_PreRender(object sender, EventArgs e)
        {
            if (grddebit.Rows.Count > 0)
            {
                grddebit.UseAccessibleHeader = true;
                grddebit.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void grdcredit_PreRender(object sender, EventArgs e)
        {
            if (grdcredit.Rows.Count > 0)
            {
                grdcredit.UseAccessibleHeader = true;
                grdcredit.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void txtJobno_TextChanged1(object sender, EventArgs e)
        {

            try
            {

                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtJobno.Text = "";
                    return;
                }
                //   ddlTypes.Enabled = false;
                if (ddlTypes.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(btnAdd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the voucher type');", true);
                    return;
                }
                double fcamt = 0;
                hid_yes.Value = "0";
                hid_No.Value = "0";
                hid_debitDnno.Value = "0";
                hid_DebitCredit.Value = "0";
                hid_creditDnno.Value = "0";
                double amtnew = 0;
                strTranType = ddl_product.SelectedValue;
                //debittotal = 0;
                //credittotal = 0;
                //total = 0.0;
                DataSet ds = new DataSet();
                //lbl.Text = "";


                if (INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"])) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job is Open, You Can not Create a Voucher in this form');", true);
                    txtclear();
                    txtJobno.Focus();
                    return;

                }
                DAdvise.DelDebitCreditnewlyOSV(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString());

                if (txtdcn.Text == "")
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewEmptyOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }
                else
                {
                    ds = OSDNCN.RptOSDNCNProFromJobNoForNewOSV(Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtJobno.Text), Convert.ToInt32(Session["LoginBranchid"]));
                }




                if (ds.Tables.Count > 0)
                {
                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //}
                    //else
                    //{
                    //    if (ds.Tables[2].Rows.Count > 0)
                    //    {
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Voucher Not Raised in this Job');", true);
                    //        txtclear();
                    //        return;
                    //    }
                    //  }
                    Dt = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                    if (strTranType == "FE" || strTranType == "FI")
                    {
                        cmbbl.Items.Clear();
                        if (Dt.Rows.Count > 0)
                        {
                            cmbbl.Items.Add("");
                            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            {
                                cmbbl.Items.Add(Dt.Rows[i]["blno"].ToString());
                            }
                            cmbbl.Items.Add(Dt.Rows[0]["mblno"].ToString());
                        }
                    }
                    if (strTranType == "AE" || strTranType == "AI")
                    {
                        if (Dt.Rows.Count > 0)
                        {
                            cmbbl.Items.Add("");
                            for (int i = 0; i <= Dt.Rows.Count - 1; i++)
                            {
                                cmbbl.Items.Add(Dt.Rows[i]["hawblno"].ToString());
                            }
                            cmbbl.Items.Add(Dt.Rows[0]["mawblno"].ToString());
                        }
                    }




                    DtVal = DAdvise.SPGetDtls4osdcnForAgentOSV(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString());
                    Grd_Details.DataSource = Utility.Fn_GetEmptyDataTable();
                    Grd_Details.DataBind();
                    grd_prodetails.DataSource = Utility.Fn_GetEmptyDataTable();
                    grd_prodetails.DataBind();
                    if (DtVal.Tables.Count > 0)
                    {
                        dtOSDNPro = DtVal.Tables[0];
                        dtOSCNPro = DtVal.Tables[1];
                        dtOSDN = DtVal.Tables[3];
                        dtOSCN = DtVal.Tables[2];

                    }


                    if (dtOSDN.Rows.Count > 0 && dtOSCN.Rows.Count > 0)
                    {
                        DataTable dt1suppl = new DataTable();
                        dt1suppl = ds.Tables[0];
                        if (dt1suppl.Rows.Count > 0)
                        {


                            txtcustomer.Text = dt1suppl.Rows[0][0].ToString() + Environment.NewLine + dt1suppl.Rows[0][1].ToString() + Environment.NewLine + dt1suppl.Rows[0][2].ToString() + Environment.NewLine + dt1suppl.Rows[0][3].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt1suppl.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt1suppl.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt1suppl.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                        }


                        DataTable dt = new DataTable();

                        dt.Columns.Add("dnno");
                        dt.Columns.Add("jobno");
                        dt.Columns.Add("agent");
                        dt.Columns.Add("amount");
                        dt.Columns.Add("debitcredit");
                        DataRow dr = dt.NewRow();
                        dr = dt.NewRow();
                        dr["dnno"] = "DebitNote";
                        dt.Rows.Add(dr);
                        for (int i = 0; i <= dtOSDN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSDN.Rows[i]["dnno"].ToString();
                            dt.Rows[count]["jobno"] = dtOSDN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSDN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSDN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSSI";

                        }

                        dr = dt.NewRow();
                        dr["dnno"] = "CreditNote";
                        dt.Rows.Add(dr);
                        for (int i = 0; i <= dtOSCN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSCN.Rows[i]["dnno"].ToString();
                            dt.Rows[count]["jobno"] = dtOSCN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSCN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSCN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSPI";
                        }

                        Grd_Details.DataSource = dt;
                        Grd_Details.DataBind();


                        if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }

                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSDNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }
                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();



                        }

                        else if (dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();



                        }

                        popup_Grd.Show();
                        return;

                    }
                    if (dtOSDN.Rows.Count > 0)
                    {

                        DataTable dt1suppl = new DataTable();
                        dt1suppl = ds.Tables[0];
                        if (dt1suppl.Rows.Count > 0)
                        {


                            txtcustomer.Text = dt1suppl.Rows[0][0].ToString() + Environment.NewLine + dt1suppl.Rows[0][1].ToString() + Environment.NewLine + dt1suppl.Rows[0][2].ToString() + Environment.NewLine + dt1suppl.Rows[0][3].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt1suppl.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt1suppl.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt1suppl.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                        }



                        DataTable dt = new DataTable();

                        dt.Columns.Add("dnno");
                        dt.Columns.Add("jobno");
                        dt.Columns.Add("agent");
                        dt.Columns.Add("amount");
                        dt.Columns.Add("debitcredit");
                        DataRow dr = dt.NewRow();
                        dr = dt.NewRow();
                        dr["dnno"] = "DebitNote";
                        dt.Rows.Add(dr);
                        for (int i = 0; i <= dtOSDN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSDN.Rows[i][0].ToString();
                            dt.Rows[count]["jobno"] = dtOSDN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSDN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSDN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSSI";


                        }


                        Grd_Details.DataSource = dt;
                        Grd_Details.DataBind();


                        if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }

                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSDNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }
                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }



                        popup_Grd.Show();
                        return;

                    }


                    if (dtOSCN.Rows.Count > 0)
                    {
                        DataTable dt1suppl = new DataTable();
                        dt1suppl = ds.Tables[0];
                        if (dt1suppl.Rows.Count > 0)
                        {


                            txtcustomer.Text = dt1suppl.Rows[0][0].ToString() + Environment.NewLine + dt1suppl.Rows[0][1].ToString() + Environment.NewLine + dt1suppl.Rows[0][2].ToString() + Environment.NewLine + dt1suppl.Rows[0][3].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt1suppl.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt1suppl.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt1suppl.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                        }



                        DataTable dt = new DataTable();

                        dt.Columns.Add("dnno");
                        dt.Columns.Add("jobno");
                        dt.Columns.Add("agent");
                        dt.Columns.Add("debitcredit");
                        dt.Columns.Add("amount");
                        DataRow dr = dt.NewRow();
                        dr = dt.NewRow();
                        dr["dnno"] = "CreditNote";
                        dt.Rows.Add(dr);

                        for (int i = 0; i <= dtOSCN.Rows.Count - 1; i++)
                        {
                            int count = dt.Rows.Count;
                            dr = dt.NewRow();
                            dt.Rows.Add();
                            dt.Rows[count]["dnno"] = dtOSCN.Rows[i][0].ToString();
                            dt.Rows[count]["jobno"] = dtOSCN.Rows[i]["jobno"].ToString();
                            dt.Rows[count]["agent"] = dtOSCN.Rows[i]["customername"].ToString();
                            dt.Rows[count]["amount"] = dtOSCN.Rows[i]["amount"].ToString();
                            dt.Rows[count]["debitcredit"] = "OSPI";


                        }

                        Grd_Details.DataSource = dt;
                        Grd_Details.DataBind();


                        if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }

                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSDNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro DebitNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                                dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();//customername
                                dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSSI";

                            }
                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }

                        else if (dtOSCNPro.Rows.Count > 0)
                        {

                            DataTable dt1 = new DataTable();

                            dt1.Columns.Add("dnno");
                            dt1.Columns.Add("jobno");
                            dt1.Columns.Add("agent");
                            dt1.Columns.Add("amount");
                            dt1.Columns.Add("debitcredit");
                            DataRow dr1 = dt1.NewRow();
                            dr1 = dt1.NewRow();
                            dr1["dnno"] = "Pro CreditNote";
                            dt1.Rows.Add(dr1);
                            for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                            {
                                int count = dt1.Rows.Count;
                                dr1 = dt1.NewRow();
                                dt1.Rows.Add();
                                dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                                dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();//customername
                                dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                                dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                                dt1.Rows[count]["debitcredit"] = "OSPI";
                            }


                            grd_prodetails.DataSource = dt1;
                            grd_prodetails.DataBind();


                        }



                        popup_Grd.Show();
                        return;

                    }




                    if (dtOSDNPro.Rows.Count > 0 && dtOSCNPro.Rows.Count > 0)
                    {
                        DataTable dt1suppl = new DataTable();
                        dt1suppl = ds.Tables[0];
                        if (dt1suppl.Rows.Count > 0)
                        {


                            txtcustomer.Text = dt1suppl.Rows[0][0].ToString() + Environment.NewLine + dt1suppl.Rows[0][1].ToString() + Environment.NewLine + dt1suppl.Rows[0][2].ToString() + Environment.NewLine + dt1suppl.Rows[0][3].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt1suppl.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt1suppl.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt1suppl.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                        }




                        DataTable dt1 = new DataTable();

                        dt1.Columns.Add("dnno");
                        dt1.Columns.Add("jobno");
                        dt1.Columns.Add("agent");
                        dt1.Columns.Add("amount");
                        dt1.Columns.Add("debitcredit");
                        DataRow dr1 = dt1.NewRow();
                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro DebitNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                            dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();
                            dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSSI";

                        }

                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro CreditNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();
                            dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                            dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSPI";
                        }


                        grd_prodetails.DataSource = dt1;
                        grd_prodetails.DataBind();
                        popup_Grd.Show();
                        return;

                    }

                    if (dtOSDNPro.Rows.Count > 0)
                    {
                        DataTable dt1suppl = new DataTable();
                        dt1suppl = ds.Tables[0];
                        if (dt1suppl.Rows.Count > 0)
                        {


                            txtcustomer.Text = dt1suppl.Rows[0][0].ToString() + Environment.NewLine + dt1suppl.Rows[0][1].ToString() + Environment.NewLine + dt1suppl.Rows[0][2].ToString() + Environment.NewLine + dt1suppl.Rows[0][3].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt1suppl.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt1suppl.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt1suppl.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                        }



                        DataTable dt1 = new DataTable();

                        dt1.Columns.Add("dnno");
                        dt1.Columns.Add("jobno");
                        dt1.Columns.Add("agent");
                        dt1.Columns.Add("amount");
                        dt1.Columns.Add("debitcredit");
                        DataRow dr1 = dt1.NewRow();
                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro DebitNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSDNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSDNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSDNPro.Rows[i]["jobno"].ToString();
                            dt1.Rows[count]["agent"] = dtOSDNPro.Rows[i]["customername"].ToString();//customername
                            dt1.Rows[count]["amount"] = dtOSDNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSSI";

                        }
                        grd_prodetails.DataSource = dt1;
                        grd_prodetails.DataBind();
                        popup_Grd.Show();
                        return;

                    }

                    if (dtOSCNPro.Rows.Count > 0)
                    {

                        DataTable dt1suppl = new DataTable();
                        dt1suppl = ds.Tables[0];
                        if (dt1suppl.Rows.Count > 0)
                        {


                            txtcustomer.Text = dt1suppl.Rows[0][0].ToString() + Environment.NewLine + dt1suppl.Rows[0][1].ToString() + Environment.NewLine + dt1suppl.Rows[0][2].ToString() + Environment.NewLine + dt1suppl.Rows[0][3].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt1suppl.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt1suppl.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt1suppl.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt1suppl.Rows[0][5].ToString().Trim() + "  /  " + dt1suppl.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt1suppl.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt1suppl.Rows[0][8].ToString() + "  /  " + dt1suppl.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                        }



                        DataTable dt1 = new DataTable();

                        dt1.Columns.Add("dnno");
                        dt1.Columns.Add("jobno");
                        dt1.Columns.Add("agent");
                        dt1.Columns.Add("amount");
                        dt1.Columns.Add("debitcredit");
                        DataRow dr1 = dt1.NewRow();
                        dr1 = dt1.NewRow();
                        dr1["dnno"] = "Pro CreditNote";
                        dt1.Rows.Add(dr1);
                        for (int i = 0; i <= dtOSCNPro.Rows.Count - 1; i++)
                        {
                            int count = dt1.Rows.Count;
                            dr1 = dt1.NewRow();
                            dt1.Rows.Add();
                            dt1.Rows[count]["dnno"] = dtOSCNPro.Rows[i]["dnno"].ToString();
                            dt1.Rows[count]["jobno"] = dtOSCNPro.Rows[i]["jobno"].ToString();//customername
                            dt1.Rows[count]["agent"] = dtOSCNPro.Rows[i]["customername"].ToString();
                            dt1.Rows[count]["amount"] = dtOSCNPro.Rows[i]["amount"].ToString();
                            dt1.Rows[count]["debitcredit"] = "OSPI";
                        }


                        grd_prodetails.DataSource = dt1;
                        grd_prodetails.DataBind();
                        popup_Grd.Show();
                        return;

                    }















                    //End








                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            jobno = Convert.ToInt32(dt.Rows[0][4].ToString());
                            //if (strTranType == "FE")
                            //{
                            //    hid_jobtype.Value = dt.Rows[0]["jobtype"].ToString();
                            //    if (hid_jobtype.Value == "2")
                            //    {


                            //        btnview.Enabled = false;
                            //        btnview.ForeColor = System.Drawing.Color.Gray;
                            //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtJobno.Text + " is assigned for Co-Load. You cannot raise Voucher');", true);

                            //    }
                            //    else
                            //    {
                            //        btnview.Enabled = true;
                            //        btnview.ForeColor = System.Drawing.Color.White;
                            //    }
                            //}
                            txtcustomer.Text = dt.Rows[0][0].ToString() + Environment.NewLine + dt.Rows[0][1].ToString() + Environment.NewLine + dt.Rows[0][2].ToString() + Environment.NewLine + dt.Rows[0][3].ToString();
                            //agentid
                            if (string.IsNullOrEmpty(dt.Rows[0]["agentid"].ToString()) != true)
                            {
                                hid_SupplyTo.Value = dt.Rows[0]["agentid"].ToString();
                            }
                            txtsupplyto.Text = dt.Rows[0][0].ToString();
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                txtshipment.Text = "Vessel / Voyage  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }
                            else
                            {
                                txtshipment.Text = "Flight # / Date  :  " + dt.Rows[0][5].ToString().Trim() + "  /  " + dt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dt.Rows[0][8].ToString() + "  /  " + dt.Rows[0][9].ToString();
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["SupplyTo"].ToString()))
                                //{
                                //    hid_SupplyTo.Value = dt.Rows[0]["SupplyTo"].ToString();
                                //    txtsupplyto.Text = obj_da_Customer.GetCustomername(int.Parse(hid_SupplyTo.Value.ToString()));
                                //}

                            }


                            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtJobno.Text), strTranType, Convert.ToInt32(Session["LoginDivisionId"]));
                            if (DtBLNO.Rows.Count > 0)
                            {
                                mblno = DtBLNO.Rows[0][0].ToString();
                            }


                            double amt = 0, amt1 = 0, amt2 = 0;
                            DataTable dtdc = new DataTable();
                            // dtdc = ds.Tables[1];
                            //grddebit.DataSource = dtdc;
                            //grddebit.DataBind();
                            DataTable dtnew = new DataTable();
                            DataTable dtcc = new DataTable();
                            //dtcc = ds.Tables[2];
                            //grdcredit.DataSource = dtcc;
                            //grdcredit.DataBind();

                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                dtdc = ds.Tables[1];
                            }
                            else
                            {

                            }
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                dtnew = ds.Tables[2];
                            }


                            DataTable dtnew1 = new DataTable();
                            DataTable dtcc1 = new DataTable();
                            dtnew1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, 5, Convert.ToInt32(hf_branchid.Value));
                            dtcc1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), strTranType, 6, Convert.ToInt32(hf_branchid.Value));

                            if (dtnew1.Rows.Count > 0)
                            {
                                int n = 0;
                                n = Convert.ToInt32(dtnew1.Rows[0][0].ToString());


                                if (!string.IsNullOrEmpty(dtnew1.Rows[0]["remarks"].ToString()))
                                {
                                    txtremarks.Text = dtnew1.Rows[0]["remarks"].ToString();
                                }
                                if (dtnew1.Columns.Contains("preparedbyname"))
                                {
                                    if (!string.IsNullOrEmpty(dtnew1.Rows[0]["preparedbyname"].ToString()))
                                    {
                                        //lbl_txt.Visible = true;
                                        //lbl_prepare.Text = dtnew1.Rows[0]["preparedbyname"].ToString();
                                    }
                                }
                                if (dtnew1.Columns.Contains("approvedbyname"))
                                {
                                    if (!string.IsNullOrEmpty(dtnew1.Rows[0]["approvedbyname"].ToString()))
                                    {
                                        //lbl_txt.Visible = true;
                                        //lbl_appr.Visible = true;
                                        //lbl_Approve.Text = dtnew1.Rows[0]["approvedbyname"].ToString();
                                    }
                                }
                                if (n != 0)
                                {
                                    txtdcn.Text = n.ToString();
                                    this.PopUpService.Show();
                                    return;
                                }

                            }
                            if (dtcc1.Rows.Count > 0)
                            {
                                int n = 0;
                                n = Convert.ToInt32(dtcc1.Rows[0][0].ToString());
                                if (!string.IsNullOrEmpty(dtcc1.Rows[0]["remarks"].ToString()))
                                {
                                    txtremarks.Text = dtcc1.Rows[0]["remarks"].ToString();
                                }

                                if (dtcc1.Columns.Contains("preparedbyname"))
                                {
                                    if (!string.IsNullOrEmpty(dtcc1.Rows[0]["preparedbyname"].ToString()))
                                    {
                                        //lbl_txt.Visible = true;
                                        //lbl_prepare.Text = dtcc1.Rows[0]["preparedbyname"].ToString();
                                    }
                                }
                                if (dtcc1.Columns.Contains("approvedbyname"))
                                {

                                    if (!string.IsNullOrEmpty(dtcc1.Rows[0]["approvedbyname"].ToString()))
                                    {
                                        //lbl_txt.Visible = true;
                                        //lbl_appr.Visible = true;
                                        //lbl_Approve.Text = dtcc1.Rows[0]["approvedbyname"].ToString();
                                    }
                                }
                                if (n != 0)
                                {
                                    txtdcn.Text = n.ToString();
                                    this.PopUpService.Show();
                                    return;
                                }
                            }

                            //if (dtdc.Rows.Count > 0 || dtnew.Rows.Count > 0)
                            //{

                            //}
                            if (dtdc.Rows.Count > 0)
                            {
                                double Total = 0;
                                DataTable dtempty = new DataTable();
                                dtempty.Columns.Add("blno", typeof(string));
                                dtempty.Columns.Add("chargename", typeof(string));
                                dtempty.Columns.Add("curr", typeof(string));
                                dtempty.Columns.Add("rate", typeof(string));
                                dtempty.Columns.Add("exrate", typeof(string));
                                dtempty.Columns.Add("bASe", typeof(string));
                                dtempty.Columns.Add("withoutgstAmt", typeof(string));
                                dtempty.Columns.Add("stgst", typeof(string));
                                dtempty.Columns.Add("amount", typeof(string));
                                dtempty.Columns.Add("chargeid", typeof(int));
                                dtempty.Columns.Add("GSTCHK", typeof(string));
                                dtempty.Columns.Add("provouno", typeof(string));
                                dtempty.Columns.Add("vouno", typeof(string));
                                dtempty.Columns.Add("vouyear", typeof(string));
                                dtempty.Columns.Add("fcamt", typeof(string));
                                DataRow dr = dtempty.NewRow();

                                if (dtdc.Rows.Count > 0)
                                {
                                    for (int i = 0; i <= dtdc.Rows.Count - 1; i++)
                                    {
                                        dr = dtempty.NewRow();
                                        dtempty.Rows.Add(dr);
                                        dr[0] = dtdc.Rows[i]["blno"].ToString();
                                        dr[1] = dtdc.Rows[i]["CHARgename"].ToString();
                                        dr[2] = dtdc.Rows[i]["curr"].ToString();
                                        dr[3] = dtdc.Rows[i]["rate"].ToString();
                                        dr[4] = dtdc.Rows[i]["exrate"].ToString();
                                        dr[5] = dtdc.Rows[i]["bAse"].ToString();

                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["withoutgstAmt"].ToString()) != true)
                                        {
                                            amt = Convert.ToDouble(dtdc.Rows[i]["withoutgstAmt"].ToString());
                                            dr[6] = amt.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[6] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["stgst"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc.Rows[i]["stgst"].ToString());
                                            dr[7] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[7] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["amount"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtdc.Rows[i]["amount"].ToString());
                                            dr[8] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[8] = "0.00";
                                        }
                                        dr[9] = dtdc.Rows[i]["chargeid"].ToString();
                                        dr[10] = dtdc.Rows[i]["GSTCHK"].ToString();

                                        dr[11] = dtdc.Rows[i]["provouno"].ToString();
                                        if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                        {
                                            chk_GstApp.Checked = true;
                                            //  chk_GstApp.Enabled = false;
                                        }
                                        else
                                        {
                                            chk_GstApp.Checked = true;
                                            //chk_GstApp.Enabled = false;
                                        }
                                        dr[12] = dtdc.Rows[i]["vouno"].ToString();
                                        dr[13] = dtdc.Rows[i]["vouyear"].ToString();

                                        Total = Total + double.Parse(dr[8].ToString());
                                        if (string.IsNullOrEmpty(dtdc.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            dr[14] = dtdc.Rows[i]["fcamt"].ToString();
                                            fcamt = fcamt + (Convert.ToDouble(dtdc.Rows[i]["fcamt"].ToString()));
                                        }
                                        else
                                        {
                                            fcamt = fcamt + 0;
                                        }
                                    }
                                }
                                txt_FcDebitamt.Text = fcamt.ToString("#0.00");
                                grddebit.DataSource = dtempty;
                                grddebit.DataBind();
                            }



                            dtnew = ds.Tables[2];
                            if (dtnew.Rows.Count > 0)
                            {
                                double Total = 0;
                                DataTable dtempty1 = new DataTable();
                                dtempty1.Columns.Add("blno", typeof(string));
                                dtempty1.Columns.Add("chargename", typeof(string));
                                dtempty1.Columns.Add("curr", typeof(string));
                                dtempty1.Columns.Add("rate", typeof(string));
                                dtempty1.Columns.Add("exrate", typeof(string));
                                dtempty1.Columns.Add("bASe", typeof(string));
                                dtempty1.Columns.Add("withoutgstAmt", typeof(string));
                                dtempty1.Columns.Add("stgst", typeof(string));
                                dtempty1.Columns.Add("amount", typeof(string));
                                dtempty1.Columns.Add("chargeid", typeof(int));
                                dtempty1.Columns.Add("GSTCHK", typeof(string));

                                dtempty1.Columns.Add("provouno", typeof(string));
                                dtempty1.Columns.Add("vouno", typeof(string));
                                dtempty1.Columns.Add("vouyear", typeof(string));
                                dtempty1.Columns.Add("fcamt", typeof(string));
                                DataRow dr = dtempty1.NewRow();

                                if (dtnew.Rows.Count > 0)
                                {
                                    for (int i = 0; i <= dtnew.Rows.Count - 1; i++)
                                    {
                                        dr = dtempty1.NewRow();
                                        dtempty1.Rows.Add(dr);
                                        dr[0] = dtnew.Rows[i]["blno"].ToString();
                                        dr[1] = dtnew.Rows[i]["CHARgename"].ToString();
                                        dr[2] = dtnew.Rows[i]["curr"].ToString();
                                        dr[3] = dtnew.Rows[i]["rate"].ToString();
                                        dr[4] = dtnew.Rows[i]["exrate"].ToString();
                                        dr[5] = dtnew.Rows[i]["bAse"].ToString();

                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["withoutgstAmt"].ToString()) != true)
                                        {
                                            amt = Convert.ToDouble(dtnew.Rows[i]["withoutgstAmt"].ToString());
                                            dr[6] = amt.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[6] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["stgst"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew.Rows[i]["stgst"].ToString());
                                            dr[7] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[7] = "0.00";
                                        }
                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["amount"].ToString()) != true)
                                        {
                                            amt1 = Convert.ToDouble(dtnew.Rows[i]["amount"].ToString());
                                            dr[8] = amt1.ToString("#0.00");
                                        }
                                        else
                                        {
                                            dr[8] = "0.00";
                                        }
                                        dr[9] = dtnew.Rows[i]["chargeid"].ToString();
                                        dr[10] = dtnew.Rows[i]["GSTCHK"].ToString();
                                        dr[11] = dtnew.Rows[i]["provouno"].ToString();
                                        if (dr[10].ToString() == "Y" && dr[11].ToString() != "")
                                        {
                                            chk_GstApp.Checked = true;
                                            // chk_GstApp.Enabled = false;
                                        }
                                        else
                                        {
                                            chk_GstApp.Checked = true;
                                            // chk_GstApp.Enabled = false;
                                        }
                                        dr[12] = dtnew.Rows[i]["vouno"].ToString();
                                        dr[13] = dtnew.Rows[i]["vouyear"].ToString();
                                        Total = Total + double.Parse(dr[8].ToString());

                                        if (string.IsNullOrEmpty(dtnew.Rows[i]["fcamt"].ToString()) != true)
                                        {
                                            dr[14] = dtnew.Rows[i]["fcamt"].ToString();
                                            fcamt = fcamt + (Convert.ToDouble(dtnew.Rows[i]["fcamt"].ToString()));
                                        }
                                        else
                                        {
                                            fcamt = fcamt + 0;
                                        }
                                    }
                                }

                                txt_FcCramt.Text = fcamt.ToString("#0.00");

                                grdcredit.DataSource = dtempty1;
                                grdcredit.DataBind();
                            }

                            double tot = 0, tot1 = 0;
                            for (i = 0; i <= grddebit.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(grddebit.Rows[i].Cells[9].Text);
                                tot = tot + tot1;
                            }
                            txtDebit.Text = tot.ToString("#,0.00");
                            for (i = 0; i <= grdcredit.Rows.Count - 1; i++)
                            {
                                amt1 = Convert.ToDouble(grdcredit.Rows[i].Cells[9].Text);
                                amtnew = amtnew + amt1;
                            }
                            txtCredit.Text = amtnew.ToString("#,0.00");

                            if (txtCredit.Text != "" && txtCredit.Text != "0.00" && txtDebit.Text != "" && txtDebit.Text != "0.00")
                            {
                                Toatlnew = tot - amtnew;
                                if (Toatlnew < 0)
                                {
                                    lblGross.Text = "Payable to Agent:";
                                    txttotal.Text = Toatlnew.ToString("#0.00");
                                }
                                else
                                {
                                    lblGross.Text = "Receivable from Agent:";
                                    txttotal.Text = Toatlnew.ToString("#0.00");

                                }
                            }
                            else
                            {
                                if (txtCredit.Text != "" && txtCredit.Text != "0.00")
                                {
                                    txttotal.Text = txtCredit.Text;
                                }
                                else if (txtDebit.Text != "" && txtDebit.Text != "0.00")
                                {
                                    txttotal.Text = txtDebit.Text;
                                }
                            }
                            //   btnback.Text = "Cancel";

                            btnback.ToolTip = "Cancel";
                            btnback.Attributes["class"] = "btn ico-cancel";
                        }
                        else
                        {
                            txtclear();
                            return;
                        }

                    }


                    //    if (grddebit.Rows.Count != 0)
                    //    {
                    //        for (i = 0; i < grddebit.Rows.Count; i++)
                    //        {
                    //            debittotal = debittotal + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);
                    //        }
                    //    }
                    //    if (grdcredit.Rows.Count != 0)
                    //    {
                    //        for (i = 0; i < grdcredit.Rows.Count; i++)
                    //        {
                    //            credittotal = credittotal + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);
                    //        }
                    //    }



                    //    if ((grddebit.Rows.Count > 0) && (grdcredit.Rows.Count == 0))
                    //    {
                    //        for (i = 0; i < grddebit.Rows.Count; i++)
                    //        {
                    //            //debittotal = debittotal + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);
                    //            total = total + System.Convert.ToDouble(grddebit.Rows[i].Cells[6].Text);

                    //        }
                    //    }
                    //    else if ((grdcredit.Rows.Count > 0) && (grddebit.Rows.Count == 0))
                    //    {
                    //        for (i = 0; i < grdcredit.Rows.Count; i++)
                    //        {
                    //            // credittotal = credittotal + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);
                    //            total = total + System.Convert.ToDouble(grdcredit.Rows[i].Cells[6].Text);

                    //        }
                    //    }

                    //    total = System.Convert.ToDouble(debittotal) - System.Convert.ToDouble(credittotal);
                    //    txttotal.Text = String.Format("{0:F2}", total);

                    DataTable dtd1 = new DataTable();
                    DataTable dtd = new DataTable();
                    dtd = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 5, Convert.ToInt32(hf_branchid.Value));
                    dtd1 = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value));
                    if (dtd.Rows.Count > 0)
                    {
                        lbl.Text = "Debit Note";
                        hid_debitDnno.Value = dtd.Rows[0][0].ToString();
                    }
                    else
                    {
                        dtd = OSDNCN.GetOSDCNProDtlsOSV(Convert.ToInt32(txtJobno.Text), Session["StrTranTypeO"].ToString(), 6, Convert.ToInt32(hf_branchid.Value));
                        if (dtd.Rows.Count > 0)
                        {
                            lbl.Text = "Credit Note";
                            //hidCRRefno
                        }

                    }
                    if (dtd1.Rows.Count > 0)
                    {
                        hid_creditDnno.Value = dtd1.Rows[0][0].ToString();
                    }
                    if (dtd.Rows.Count > 0)
                    {
                        txtdcn.Text = dtd.Rows[0][0].ToString();
                        txtyear.Text = dtd.Rows[0]["vouyear"].ToString();
                        txtVendorRefno.Text = dtd.Rows[0]["vendorrefno"].ToString();
                        if (DBNull.Value.Equals(dtd.Rows[0]["vendorRefdate"]) == false)
                        {
                            txtVendorRefnodate.Text = dtd.Rows[0]["vendorrefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        if (dtd.Rows[0]["fatransfer"].ToString() == "")
                        {
                            btnview.Text = "Save";
                            btnview.ToolTip = "Save";
                            //btnview.Attributes["class"] = "btn ico-save";
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            btnview.Enabled = false;
                            btnview.ForeColor = System.Drawing.Color.Gray;
                        }
                    }
                    else
                    {

                        btnview.Text = "Save";
                        btnview.ToolTip = "Save";
                        btnview.Attributes["class"] = "btn ico-save";
                        btnview.Enabled = true;
                        btnview.ForeColor = System.Drawing.Color.White;
                        txtdcn.Text = "";
                    }
                    //  btnback.Text = "Cancel";


                    btnback.ToolTip = "Cancel";
                    btnback.Attributes["class"] = "btn ico-cancel";
                    btnprint.Enabled = true;


                    if (btnview.ToolTip == "Save" && hid_jobtype.Value == "2")
                    {
                        btnview.Enabled = false;
                        btnview.ForeColor = System.Drawing.Color.Gray;
                    }


                    if (Session["LoginDivisionId"] != null)
                    {
                        divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                    }
                    if (Session["LoginBranchid"] != null)
                    {
                        branchid = Convert.ToInt32(Session["LoginBranchid"]);
                    }
                    DataTable dtnew2 = new DataTable();
                    DataAccess.Masters.MasterBranch obj_branchd = new DataAccess.Masters.MasterBranch();

                    dtnew2 = obj_branchd.GetBranchGST(divisionid, branchid);
                    if (dtnew2.Rows.Count > 0)
                    {

                        btnview.Enabled = false;
                        btnview.ForeColor = System.Drawing.Color.Gray;
                        // btnsave.ForeColor = System.Drawing.Color.White;

                    }




                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transferred');", true);
                    txtclear();
                    txtJobno.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtclear();
                txtJobno.Focus();
            }


        }

        protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlTypes.SelectedValue == "0")
            //{

            //    btnAdd.Enabled = true;
            //}
            //else
            //{
            //    btnAdd.Enabled = false;
            //}
            if (ddlTypes.SelectedValue != "0")
            {
                ddlDebiteOrCredite.SelectedValue = ddlTypes.SelectedValue;
                ddlDebiteOrCredite.Enabled = false;
            }
            if (ddlDebiteOrCredite.SelectedValue == "5")
            {
                creditgrd.Visible = false;
                debitgrd.Visible = true;
            }
            else
            {
                debitgrd.Visible = false;
                creditgrd.Visible = true;
            }

        }

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data_Bind();
        }


        //protected void lnk_job_Click(object sender, EventArgs e)
        //{
        //    loadgrid();
        //}

    }
}

