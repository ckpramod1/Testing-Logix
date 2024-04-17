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

namespace logix.FAForms
{
    public partial class ProfomaInvoicenew : System.Web.UI.Page
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
        DataAccess.BondedTrucking.BTInvoice BTINVOICEobj = new DataAccess.BondedTrucking.BTInvoice();
        DataTable dtnew1 = new DataTable();
        DataAccess.Masters.MasterBranch obj_branchd = new DataAccess.Masters.MasterBranch();

        DataTable dtnew = new DataTable();
        DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtto);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtref);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/','_top');", true);
            }
            //else if (Session["StrTranTypenew"] == null)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('"+ Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            //}
           if (Session["LoginDivisionId"] != null)
            {
                divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            }
            if (Session["LoginBranchid"] != null)
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            }


            if (Session["Loginyear"].ToString() == Session["Vouyear"].ToString())
            {

            }
            else
            {
                btn_save1.Visible = false;
            }

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


            if (ddl_product.SelectedItem.Text != "" && ddl_product.SelectedItem.Text != "0")
            {
                if (ddl_product.SelectedItem.Text == "Ocean Exports")
                {
                    Session["StrTranTypenew"] = "FE";

                }
                else if (ddl_product.SelectedItem.Text == "Ocean Imports")
                {
                    Session["StrTranTypenew"] = "FI";

                }
                else if (ddl_product.SelectedItem.Text == "Air Exports")
                {
                    Session["StrTranTypenew"] = "AE";

                }
                else if (ddl_product.SelectedItem.Text == "Air Imports")
                {
                    Session["StrTranTypenew"] = "AI";

                }

                else if (ddl_product.SelectedItem.Text == "Bonded Trucking")
                {
                    Session["StrTranTypenew"] = "BT";
                    // StrTranType = Session["StrTranTypenew"].ToString();
                }
                if (Session["StrTranTypenew"] != null)
                {
                    strTranType = Session["StrTranTypenew"].ToString();
                }
            }
            grd.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            if (!this.IsPostBack)
            {
                try
                {
                    lbnl_logyear.Text = Session["LYEAR"].ToString();
                    btndelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";
                    txtblno.Focus();
                    ShowNoResultFound(dt, grd);
                    string Str_Trantype = ddl_product.SelectedValue.ToString();
                    Session["StrTranTypenew"] = Str_Trantype;
                    if (Request.QueryString.ToString().Contains("FormName"))
                    {
                        lbl_Header.Text = Request.QueryString["FormName"].ToString();
                        if (lbl_Header.Text == "Proforma Invoices After Job closing")
                        {
                            headerlabel.InnerText = "Proforma Invoices After Job closing";
                            lbl_Header.Text = "Proforma Invoice";
                            chkmbl.Enabled = true;
                        }
                        if (lbl_Header.Text == "Profoma Purchase Invoice After Job closing")
                        {
                            headerlabel.InnerText = "Profoma Purchase Invoice After Job closing";
                           
                            lbl_Header.Text = "Profoma Purchase Invoice";
                            chkmbl.Enabled = true;
                        }

                    }

                    if (Session["StrTranTypenew"] != null)
                    {
                        ddl_product.Items.Add("");
                        if (Session["StrTranTypenew"].ToString() == "FE")
                        {
                            ddl_product.Items.Add("Ocean Exports");

                            ddl_product.SelectedValue = "FE";
                        }
                        else if (Session["StrTranTypenew"].ToString() == "FI")
                        {
                            ddl_product.Items.Add("Ocean Imports");
                            ddl_product.SelectedValue = "FI";

                        }
                        else if (Session["StrTranTypenew"].ToString() == "AE")
                        {
                            ddl_product.Items.Add("Air Exports");
                            ddl_product.SelectedValue = "AE";

                        }
                        else if (Session["StrTranTypenew"].ToString() == "AI")
                        {
                            ddl_product.Items.Add("Air Imports");
                            ddl_product.SelectedValue = "AI";
                        }
                        else if (Session["StrTranTypenew"].ToString() == "BT")
                        {
                            ddl_product.Items.Add("Bonded Trucking");
                            ddl_product.SelectedValue = "BT";
                        }
                        //else if (Session["StrTranTypenew"].ToString() == "CH")
                        //{
                        //    ddl_product.Items.Add("Custom House Agent");
                        //    ddl_product.SelectedValue = "CH";
                        //}
                        else
                        {
                            ddl_product.Items.Add("");
                            ddl_product.SelectedValue = "0";
                        }

                    }
                    else
                    {
                        ddl_product.Items.Add("");
                    }
                    if (Request.QueryString.ToString().Contains("app1"))
                    {
                        lbl_Header.Text = Request.QueryString["app1"].ToString();
                        txtblno.Text = Request.QueryString["mblno"].ToString();
                        chkmbl.Checked = true;
                        chkmbl_CheckedChanged(sender, e);
                        txtblno_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("app2"))
                    {
                        lbl_Header.Text = Request.QueryString["app2"].ToString();
                        txtblno.Text = Request.QueryString["mblno"].ToString();
                        chkmbl.Checked = true;
                        chkmbl_CheckedChanged(sender, e);
                        txtblno_TextChanged(sender, e);
                    }

                    if (Request.QueryString.ToString().Contains("appfbl"))
                    {
                        lbl_Header.Text = Request.QueryString["appfbl"].ToString();
                        txtblno.Text = Request.QueryString["feblno"].ToString();

                        txtblno_TextChanged(sender, e);
                    }

                    if (Request.QueryString.ToString().Contains("appaebll"))
                    {
                        lbl_Header.Text = Request.QueryString["appaebll"].ToString();
                        txtblno.Text = Request.QueryString["aeblno"].ToString();

                        txtblno_TextChanged(sender, e);
                    }

                    if (Request.QueryString.ToString().Contains("appfibl"))
                    {
                        lbl_Header.Text = Request.QueryString["appfibl"].ToString();
                        txtblno.Text = Request.QueryString["aeblno"].ToString();

                        txtblno_TextChanged(sender, e);
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
                        //txtblno.Attributes.Add("placeholder", "DOC#");
                        lblblno.Text = "DOC#";
                        txtblno.ToolTip = "DOC Number";
                    }
                    if (lbl_Header.Text == "Profoma Purchase Invoice")
                    {
                        type = "Profoma Payment Advise";
                        hf_strtype.Value = type;
                        txtCreditDays.Visible = true;
                        txtVendorRefno.Visible = true;
                        txtVendorRefnodate.Visible = true;
                        txtcreditapp1.Visible = false;
                        lblcreditapp1.Visible = false;
                        txtto.ToolTip = "Bill From";
                        txtsupplyto.ToolTip = "Supply From";
                        //txtto.Attributes["Placeholder"] = "Bill From";
                        //txtsupplyto.Attributes["Placeholder"] = "Supply From";

                        lblto.Text = "Bill From";
                        lblsupplyto.Text = "Supply From";

                        chkmbl.Enabled = true;
                    }
                    else if (lbl_Header.Text == "Proforma Invoice")
                    {
                        txtto.ToolTip = "Bill To";
                        txtsupplyto.ToolTip = "Supply To";
                        //txtto.Attributes["Placeholder"] = "Bill To";
                        //txtsupplyto.Attributes["Placeholder"] = "Supply To";


                        lblto.Text = "Bill To";
                        lblsupplyto.Text = "Supply To";

                        hd_exrate.Value = "R";
                        type = "Profoma Invoice";
                        lbl_Header.Text = type;
                        hf_strtype.Value = type;
                        txtCreditDays.Visible = false;
                        lblCreditDays.Visible = false;

                        txtVendorRefno.Visible = true;
                        txtVendorRefnodate.Visible = true;
                        txtcreditapp1.Visible = true;

                        chkmbl.Enabled = true;
                    }
                   // headerlabel.InnerText = lbl_Header.Text;
                    FillOnPageLoad();
                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Yellow;
                    btndelete.Click += btndelete_Click;
                    btndelete.OnClientClick = @"return getConfirmationValue();";
                    // txtref.Focus();

                    UserRights();
                    if (Session["StrTranTypenew"] != null)
                    {
                        if (Session["StrTranTypenew"].ToString() == "FE")
                        {
                            //homelbl.Visible = true;
                            //headerlable1.InnerText = "OceanExports";
                            if (lbl_Header.Text == "Proforma Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                            else if (lbl_Header.Text == "Profoma Purchase Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                        }
                        else if (Session["StrTranTypenew"].ToString() == "FI")
                        {
                            //homelbl.Visible = true;
                            //headerlable1.InnerText = "OceanImports";
                            if (lbl_Header.Text == "Proforma Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                            else if (lbl_Header.Text == "Profoma Purchase Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                        }
                        else if (Session["StrTranTypenew"].ToString() == "AE")
                        {
                            //homelbl.Visible = true;
                            //headerlable1.InnerText = "AirExports";
                            if (lbl_Header.Text == "Profoma Purchase Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                            else if (lbl_Header.Text == "Proforma Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                        }
                        else if (Session["StrTranTypenew"].ToString() == "AI")
                        {
                            //homelbl.Visible = true;
                            //headerlable1.InnerText = "AirImports";
                            if (lbl_Header.Text == "Profoma Purchase Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                            else if (lbl_Header.Text == "Proforma Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                            }
                        }
                        else if (Session["StrTranTypenew"].ToString() == "CH")
                        {
                            //headerlable1.InnerText = "Custom House Agent";

                            /* if (lbl_Header.Text == "Profoma Purchase Invoice")
                             {
                                 menulabel.InnerText = "Accounts";
                                 txtVendorRef.Attributes["class"] = "VendorRef1";
                             }
                             else if (lbl_Header.Text == "Profoma Invoice")
                             {
                                 txtcredit.Attributes["class"] = "VendorRefN1";
                                 menulabel.InnerText = "Accounts";
                       
                       
                             }
                             else if(lbl_Header.Text == "Profoma Invoice" && txtblno.ToolTip == "DOC Number")
                             {
                                 txtcredit.Attributes["class"] = "VendorRefN2";
                                 txtVendorRef.Attributes["class"] = "VendorRef2";
                                 txtCreditDays1.Attributes["class"] = "CreditDays1";
                                 menulabel.InnerText = "Utility";

                             }*/
                            if (lbl_Header.Text == "Profoma Purchase Invoice")
                            {
                                menulabel.InnerText = "Accounts";
                                txtVendorRef.Attributes["class"] = "VendorRef1";
                                chkmbl.Enabled = true;
                            }
                            else if (lbl_Header.Text == "Profoma Invoice")
                            {

                                txtcredit.Attributes["class"] = "VendorRefN1";
                                string str_FornName = "";
                                if (Request.QueryString.ToString().Contains("FormName"))
                                {
                                    str_FornName = Request.QueryString["FormName"].ToString();
                                }
                                if (str_FornName == "Purchase Invoice After Job closing")
                                {
                                    str_FornName = "Purchase Invoice";
                                }
                                if (str_FornName == "Invoice After Job closing")
                                {
                                    str_FornName = "Invoice";
                                }

                                if (str_FornName.ToString() == "Proforma Invoice")
                                {
                                    menulabel.InnerText = "Accounts";
                                   
                                    txtcredit.Attributes["class"] = "VendorRefN2";
                                    txtVendorRef.Attributes["class"] = "VendorRef2";
                                    txtVendorRefnodate1.Attributes["class"] = "VendorRef2";
                                    txtCreditDays1.Attributes["class"] = "CreditDays1";

                              
                                }
                                else
                                {
                                    txtcredit.Attributes["class"] = "VendorRefN2";
                                    txtVendorRef.Attributes["class"] = "VendorRef2";
                                    txtVendorRefnodate1.Attributes["class"] = "VendorRef2";
                                    txtCreditDays1.Attributes["class"] = "CreditDays1";

                                    menulabel.InnerText = "Utility";

                                }
                                chkmbl.Enabled = true;
                            }
                        }
                    }


                    if (lbl_Header.Text == "Proforma Invoice" || lbl_Header.Text == "Profoma Invoice")
                    {
                        chkmbl.Enabled = true;
                    }
                    else
                    {
                        chkmbl.Enabled = true;
                    }


                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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

                if (str_FornName == "Purchase Invoice After Job closing")
                {
                    str_FornName = "Purchase Invoice";
                }
                if (str_FornName == "Invoice After Job closing")
                {
                    str_FornName = "Invoice";
                }
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
                btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


            }
        }

        [WebMethod]
        public static List<string> GetBLno(string prefix)
        {

            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            string strTranType = "";

            if (HttpContext.Current.Session["StrTranTypenew"] != null)
            {
                strTranType = HttpContext.Current.Session["StrTranTypenew"].ToString();
            }
            DataTable objDt = new DataTable();
            string str_bl = "";

            if (strTranType == "FE" || strTranType == "FI")
            {
                if (strTranType == "FE")
                {
                    if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                    {
                        DataAccess.ForwardingExports.BLDetails obj_da_bldet = new DataAccess.ForwardingExports.BLDetails();
                        objDt = obj_da_bldet.GetLikeBLDetailsnew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        str_bl = "blno";
                    }
                    else
                    {
                        DataAccess.ForwardingExports.JobInfo obj_da_jinfo = new DataAccess.ForwardingExports.JobInfo();
                        objDt = obj_da_jinfo.GetFEJobInfoMBLWOClosedJobnew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        str_bl = "mblno";
                    }
                }
                else
                {
                    if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                    {
                        DataAccess.ForwardingImports.BLDetails obj_da_jinfo = new DataAccess.ForwardingImports.BLDetails();
                        objDt = obj_da_jinfo.GetLikeIBL(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        str_bl = "blno";
                    }
                    else
                    {
                        DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
                        objDt = obj_da_jinfo.GetLikeMBLNoWOClosedJobnew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
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
                        objDt = obj_da_aibldet.GetLikeAIEBLDetailsnew(prefix.ToUpper(), "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        str_bl = "hawblno";
                    }
                    else
                    {
                        DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                        objDt = obj_da_aijinfo.GetLikeAIEJobMBLNonew(prefix.ToUpper(), "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        str_bl = "mawblno";
                    }
                }
                else
                {
                    if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                    {
                        DataAccess.AirImportExports.AIEBLDetails obj_da_aibldet = new DataAccess.AirImportExports.AIEBLDetails();
                        objDt = obj_da_aibldet.GetLikeAIEBLDetailsnew(prefix.ToUpper(), "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        str_bl = "hawblno";
                    }
                    else
                    {
                        DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                        objDt = obj_da_aijinfo.GetLikeAIEJobMBLNonew(prefix.ToUpper(), "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                        str_bl = "mawblno";
                    }
                }
            }
            else if (strTranType == "CH")
            {
                DataAccess.CustomHousingAgent.JobInfo obj_da_jinfo = new DataAccess.CustomHousingAgent.JobInfo();
                objDt = obj_da_jinfo.GetLikeDocnonew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                str_bl = "docno";
            }
            else if (strTranType == "BT")
            {
                DataAccess.BondedTrucking.BTJobInfo obj_da_jinfo = new DataAccess.BondedTrucking.BTJobInfo();
                objDt = obj_da_jinfo.GetLikeBTSBNoAfterJobclose(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                str_bl = "sbno";
            }

            List<string> Bookingno = new List<string>();
            Bookingno = Utility.Fn_DatatableToList_Text(objDt, str_bl);
            return Bookingno;


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

        protected void getBT()
        {
            DataAccess.BondedTrucking.BTJobInfo BTJobInfoobj = new DataAccess.BondedTrucking.BTJobInfo();
            DataTable Dt2 = new DataTable();
            divisionid = int.Parse(Session["LoginDivisionId"].ToString());
            branchid = int.Parse(Session["LoginBranchid"].ToString());

            Dt2 = BTJobInfoobj.GetBTJobInfoFSBNo(txtblno.Text.Trim(), branchid, divisionid);
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            if (Dt2.Rows.Count > 0)
            {
                txtvessel.Text = Dt2.Rows[0]["jobno"].ToString();
                txtdes.Text = Dt2.Rows[0]["toport"].ToString();
                txtjobno.Value = Dt2.Rows[0]["jobno"].ToString();
                txtshipper.Text = Dt2.Rows[0]["etd"].ToString();
                txtagent.Text = Dt2.Rows[0]["eta"].ToString();
                //txtto.Text = Dt2.Rows[0]["customername"].ToString();
                hf_custid.Value = Dt2.Rows[0]["customer"].ToString();
                //if (hdncustid.Value !="")
                //{
                //    txtto_TextChanged(sender, e);
                //}
                txtto.Focus();

            }
        }




        public void FillOnPageLoad()
        {
            try
            {
                //if (ddl_product.SelectedIndex == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                //    ddl_product.Focus();
                //    return;
                //}
                strTranType = ddl_product.SelectedValue.ToString();
                Session["StrTranTypenew"] = strTranType;

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
                if (Session["StrTranTypenew"] != null)
                {
                    strTranType = Session["StrTranTypenew"].ToString();
                }


                if (strTranType == "FE" || strTranType == "FI")
                {
                    chkmbl.Visible = true;
                    chkmbl.Enabled = true;
                    cmbbase.Items.Clear();
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("BL");
                    cmbbase.Items.Add("CBM");
                    cmbbase.Items.Add("MT");
                    //txtvessel.Attributes.Add("placeholder", "Vsl and Voy");
                    //txtagent.Attributes.Add("placeholder", "Principal");
                    //txtmlo.Attributes.Add("placeholder", "Customer");
                    //txtcnf.Attributes.Add("placeholder", "CNF");
                    if (strTranType == "FE")
                    {
                        cmbbase.Items.Add("SB");
                    }
                    dtbase = INVOICEobj.BaseFill();
                    for (i = 0; i <= dtbase.Rows.Count - 1; i++)
                    {
                        cmbbase.Items.Add(dtbase.Rows[i]["conttype"].ToString());
                    }

                    if (lbl_Header.Text == "Proforma Invoice" || lbl_Header.Text == "Profoma Invoice")
                    {
                        chkmbl.Enabled = true;
                    }
                    else
                    {
                        chkmbl.Enabled = true;
                    }
                }
                else if (strTranType == "AE" || strTranType == "AI")
                {
                    chkmbl.Visible = true;
                    chkmbl.Enabled = true;
                    cmbbase.Items.Clear();
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("HAWB");
                    cmbbase.Items.Add("KGS");
                    cmbbase.Items.Add("PERTRUCK");
                    cmbbase.Items.Add("COTTON/PALLET");
                    //Label8.Text = "Job Details";
                    //Label12.Text = "AirLine";
                    //Label14.Text = "Agent";
                    //Label16.Text = "Notify Party 2";
                    //txtvessel.Attributes.Add("placeholder", "Job Details");
                    //txtagent.Attributes.Add("placeholder", "AirLine");
                    //txtmlo.Attributes.Add("placeholder", "Agent");
                    //txtcnf.Attributes.Add("placeholder", "Notify Party 2");

                    lblagent.Text = "AirLine";
                    lblmlo.Text = "Agent";
                    lblcnf.Text = "Notify Party 2";
                    txtagent.ToolTip = "AirLine";
                    txtmlo.ToolTip = "Agent";
                    txtcnf.ToolTip = "Notify Party 2";
                    if (lbl_Header.Text == "Proforma Invoice" || lbl_Header.Text == "Profoma Invoice")
                    {
                        chkmbl.Enabled = true;
                    }
                    else
                    {
                        chkmbl.Enabled = true;
                    }
                }
                else if (strTranType == "CH")
                {
                    cmbbase.Items.Clear();
                    chkmbl.Visible = false;
                    chkmbl.Enabled = true;
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("DOC");
                    cmbbase.Items.Add("Kgs");
                    cmbbase.Items.Add("Volume");
                }
                else if (strTranType == "BT")
                {
                    txtvessel.ToolTip = "JOB #";
                    //txtvessel.Attributes.Add("placeholder", "JOB #");
                    lblvessel.Text = "JOB#";
                    txtshipper.ToolTip = "ETD";
                    //txtshipper.Attributes.Add("placeholder", "ETD");
                    lblshipper.Text = "ETD";
                    txtagent.ToolTip = "ETA";
                    //txtagent.Attributes.Add("placeholder", "ETA");
                    lblagent.Text = "ETA";
                    chkmbl.Enabled = true;
                    cmbbase.Items.Clear();
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("CBM");
                    cmbbase.Items.Add("Kgs");
                    cmbbase.Items.Add("Truck");
                    
                }
                else
                {
                    chkmbl.Visible = true;
                    chkmbl.Enabled = true;


                    if (lbl_Header.Text == "Proforma Invoice" || lbl_Header.Text == "Profoma Invoice")
                    {
                        chkmbl.Enabled = true;
                    }
                    else
                    {
                        chkmbl.Enabled = true;
                    }
                    cmbbase.Items.Clear();
                    //chkmbl.Visible = false;
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("DOC");
                    cmbbase.Items.Add("Kgs");
                    cmbbase.Items.Add("Volume");
                    //Label8.Text = "Vsl and Voy";
                    //Label12.Text = "Principal";
                    //Label13.Text = "Customer";
                    //Label16.Enabled = false;
                    //txtvessel.Attributes.Add("placeholder", "Vsl and Voy");
                    //txtagent.Attributes.Add("placeholder", "Principal");
                    //txtmlo.Attributes.Add("placeholder", "Customer");
                    //txtcnf.Attributes.Add("placeholder", "CNF");

                    lblvessel.Text = "Vsl and Voy";
                    lblagent.Text = "Principal";
                    lblmlo.Text = "Customer";
                    lblcnf.Text = "CNF";

                    txtvessel.ToolTip = "Vsl and Voy";
                    txtagent.ToolTip = "Principal";
                    txtmlo.ToolTip = "Customer";
                    txtcnf.ToolTip = "CNF";
                    //txtconsignee.Attributes.Add("placeholder", "Consignee");
                    txtcnf.Enabled = false;
                }
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
        public void getFEI()
        {
            try
            {
                useit();
                if (strTranType == "FE")
                {
                    txtblno.Text = txtblno.Text.ToUpper();

                    if (chkmbl.Checked == true)
                    {
                        lstvol.Items.Clear();
                        txtjobno.Value = FEJobobj.GetJobNo(txtblno.Text.ToUpper(), branchid, divisionid).ToString();
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
                        if (DtConDetails.Rows.Count > 0)
                        {
                            for (int i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                            }
                        }
                        lstcon.Items.Clear();
                        DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
                        if (DtCon.Rows.Count > 0)
                        {
                            for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
                            }
                        }
                        DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Value), branchid, divisionid);
                        if (DtCon.Rows.Count > 0)
                        {
                            vessel = DtCon.Rows[0][3].ToString();
                            voyage = DtCon.Rows[0][7].ToString();
                            eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString());
                            hid_mloid.Value = DtCon.Rows[0]["mloid"].ToString();
                            txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
                            txtmlo.Text = DtCon.Rows[0][6].ToString();

                            txtagent.Text = DtCon.Rows[0][5].ToString();
                            agent = DtCon.Rows[0][14].ToString();
                            txtdes.Text = DtCon.Rows[0][4].ToString();
                            jobtype = DtCon.Rows[0][13].ToString();
                        }

                    }
                    else
                    {
                        lstvol.Items.Clear();
                        DtInfo = FEBLobj.GetBLDetails(txtblno.Text.ToUpper(), branchid, divisionid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            txtjobno.Value = DtInfo.Rows[0][0].ToString();
                            txtshipper.Text = DtInfo.Rows[0][4].ToString();
                            txtconsignee.Text = DtInfo.Rows[0][6].ToString();
                            hid_cosigneeid.Value = DtInfo.Rows[0]["consigneeid"].ToString();
                            txtnotify.Text = DtInfo.Rows[0][8].ToString();
                            txtcnf.Text = DtInfo.Rows[0][16].ToString();
                            DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Value), branchid, divisionid);
                            if (DtCon.Rows.Count > 0)
                            {
                                jobtype = DtCon.Rows[0][13].ToString();
                                vessel = DtCon.Rows[0][3].ToString();
                                voyage = DtCon.Rows[0][7].ToString();
                                eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString()).Date;
                                hid_mloid.Value = DtCon.Rows[0]["mloid"].ToString();
                                txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
                                txtmlo.Text = DtCon.Rows[0][6].ToString();
                                txtagent.Text = DtCon.Rows[0][5].ToString();
                                jobtype = DtCon.Rows[0][13].ToString();
                                txtdes.Text = DtCon.Rows[0][4].ToString();
                                Dt = INVOICEobj.GetCreditOSAmount(txtblno.Text, branchid);
                                if (Dt.Rows.Count > 0)
                                {
                                    //txtCreditAmt.Text = Dt.Rows(0).Item(0).ToString
                                    //txtOSAmt.Text = Dt.Rows(0).Item(1).ToString
                                }
                            }
                            DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, branchid);
                            if (DtConDetails.Rows.Count > 0)
                            {
                                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                                }
                                volume = DtConDetails.Rows[0][1].ToString();
                                lstvol.Items.Add(volume + " cbm");
                                wt = DtConDetails.Rows[0][2].ToString();
                                lstvol.Items.Add(wt + " Kgs");
                            }
                            lstcon.Items.Clear();
                            DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, strTranType, branchid);
                            if (DtInfo.Rows.Count > 0)
                            {
                                for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
                                {
                                    lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
                                }
                            }

                        }
                    }
                }

                else
                {
                    if (chkmbl.Checked == true)
                    {
                        lstvol.Items.Clear();
                        DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text, strTranType, branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            txtjobno.Value = DtInfo.Rows[0][0].ToString();
                            vessel = DtInfo.Rows[0][3].ToString();
                            voyage = DtInfo.Rows[0][2].ToString();
                            eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                            txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
                            txtmlo.Text = DtInfo.Rows[0][6].ToString();
                            agent = DtInfo.Rows[0][7].ToString();
                            jobtype = DtInfo.Rows[0][8].ToString();
                            txtagent.Text = DtInfo.Rows[0][5].ToString();
                            txtdes.Text = DtInfo.Rows[0][4].ToString();
                            DtCon = INVOICEobj.GetFIMblNContainers(txtjobno.Value, branchid);
                            if (DtCon.Rows.Count > 0)
                            {
                                for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                                {
                                    lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());

                                }
                            }
                            DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
                            if (DtConDetails.Rows.Count > 0)
                            {
                                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                                }
                            }

                        }
                    }
                    else
                    {
                        lstvol.Items.Clear();
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, strTranType, branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            txtjobno.Value = DtInfo.Rows[0][0].ToString();
                            txtshipper.Text = DtInfo.Rows[0][4].ToString();
                            txtconsignee.Text = DtInfo.Rows[0][5].ToString();
                            txtnotify.Text = DtInfo.Rows[0][6].ToString();
                            hid_cosigneeid.Value = DtInfo.Rows[0]["consigneeid"].ToString();
                            vessel = DtInfo.Rows[0][3].ToString();
                            voyage = DtInfo.Rows[0][2].ToString();
                            eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());

                            txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
                            txtmlo.Text = DtInfo.Rows[0][9].ToString();
                            agent = DtInfo.Rows[0][10].ToString();
                            jobtype = DtInfo.Rows[0][11].ToString();
                            txtagent.Text = DtInfo.Rows[0][8].ToString();

                            txtdes.Text = DtInfo.Rows[0][7].ToString();
                            Dt = INVOICEobj.GetCreditOSAmount(txtblno.Text, branchid);
                            if (Dt.Rows.Count > 0)
                            {
                                // txtCreditAmt.Text = Dt.Rows(0).Item(0).ToString
                                // txtOSAmt.Text = Dt.Rows(0).Item(1).ToString
                            }

                        }

                    }


                    DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, branchid);
                    if (DtConDetails.Rows.Count > 0)
                    {
                        for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                        {
                            lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                        }
                        volume = INVOICEobj.GetVolume(txtblno.Text, strTranType, branchid).ToString();
                        lstvol.Items.Add(volume + " cbm");
                        wt = INVOICEobj.GetWeight(txtblno.Text, strTranType, branchid).ToString();
                        lstvol.Items.Add(wt + " Kgs");
                        lstcon.Items.Clear();
                        DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, strTranType, branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
                            }
                        }

                    }
                }
                disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }

        }

        public void getAEI()
        {
            try
            {
                useit();
                string gross, chwt;
                if (chkmbl.Checked == true)
                {
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
                        txtjobno.Value = DtInfo.Rows[0][0].ToString();
                        eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                        txtvessel.Text = txtjobno.Value + "/" + DtInfo.Rows[0][2].ToString() + "/" + eta.ToShortDateString();
                        txtmlo.Text = DtInfo.Rows[0][5].ToString();
                        txtagent.Text = DtInfo.Rows[0][4].ToString();
                        agent = DtInfo.Rows[0][6].ToString();
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
                        txtjobno.Value = DtInfo.Rows[0][0].ToString();
                        txtshipper.Text = DtInfo.Rows[0][3].ToString();
                        txtconsignee.Text = DtInfo.Rows[0][4].ToString();
                        txtnotify.Text = DtInfo.Rows[0][5].ToString();
                        eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                        hid_cosigneeid.Value = DtInfo.Rows[0]["consigneeid"].ToString();
                        txtcnf.Text = DtInfo.Rows[0][6].ToString();
                        txtvessel.Text = txtjobno.Value + "/" + DtInfo.Rows[0][2].ToString() + "/" + eta.ToShortDateString();
                        txtmlo.Text = DtInfo.Rows[0][9].ToString();
                        hid_mloid.Value = DtInfo.Rows[0]["airlineid"].ToString();
                        txtagent.Text = DtInfo.Rows[0][8].ToString();
                        agent = DtInfo.Rows[0][10].ToString();
                        gross = DtInfo.Rows[0][11].ToString();
                        chwt = DtInfo.Rows[0][12].ToString();
                        txtdes.Text = DtInfo.Rows[0][7].ToString();
                        lstvol.Items.Add("Gross Wt : " + gross + " Kgs");
                        lstvol.Items.Add("Charge Wt : " + chwt + " Kgs");
                    }
                }
                disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }
        public void getCHA()
        {

            try
            {
                useit();
                Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), "CH", branchid);
                if (Dt.Rows.Count > 0)
                {
                    txtjobno.Value = Dt.Rows[0][0].ToString();
                    txtshipper.Text = Dt.Rows[0][3].ToString();
                    txtconsignee.Text = Dt.Rows[0][4].ToString();
                    txtnotify.Text = Dt.Rows[0][5].ToString();
                    eta = Convert.ToDateTime(Dt.Rows[0][1].ToString());
                    txtvessel.Text = txtjobno.Value + "/" + Dt.Rows[0][2].ToString() + "/" + eta.ToShortDateString();
                    txtmlo.Text = Dt.Rows[0][8].ToString();
                    txtagent.Text = Dt.Rows[0][7].ToString();
                    agent = Dt.Rows[0][9].ToString();
                    txtdes.Text = Dt.Rows[0][6].ToString();
                    jobtype = Dt.Rows[0][10].ToString();
                    jobtype = "0";

                }
                disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

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

        protected void txtblno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                ddl_product.Enabled = false;
                DataAccess.Accounts.Invoice obj_da_Invoice = new DataAccess.Accounts.Invoice();
                DataTable dtacc = new DataTable();
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtref.Text = "";
                    return;
                }
                DataTable dtsupply = new DataTable();
                DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
                DataTable obj_dt = new DataTable();
                string str_booking = "";
                string str_BL = "";
               int int_Empid = int.Parse(Session["LoginEmpId"].ToString());
              int int_bid = int.Parse(Session["LoginBranchid"].ToString());
              dtacc = obj_da_Invoice.SelEmpDtls4Accnew(int_Empid, 0, int_bid, Session["StrTranTypenew"].ToString(), txtblno.Text);
              if (dtacc.Rows.Count > 0)
              {
                 /* if (dtacc.Rows[0]["closedjob"].ToString() == "0")
                  {
                      ScriptManager.RegisterStartupScript(txtblno, typeof(Button), "ChequeRequestApproval", "alertify.alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " is not closed. Kindly Create  Pro Invoice/PA in Operation Module');", true);
                      return;
                  }*/

                  if (Convert.ToInt32(dtacc.Rows[0]["closedjob"]) == 1)
                  {
                      if (Convert.ToInt32(dtacc.Rows[0]["deptid"]) == 2)
                      {

                      }
                      else
                      {
                          ScriptManager.RegisterStartupScript(txtblno, typeof(Button), "Profoma Debit Note", "alertify.alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + "." + "Accountant only can raise Pro Invoice/PA');", true);
                          txtblno.Text = "";
                          txtblno.Focus();
                          return;
                      }
                  }
                  else
                  {
                      ScriptManager.RegisterStartupScript(txtblno, typeof(Button), "Profoma Debit Note", "alertify.alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + "is not closed." + "Kindly Create  Pro Invoice/PA in Operation Module');", true);
                      txtblno.Text = "";
                      txtblno.Focus();
                      return;
                  }
              }
                if (txtblno.Text.ToUpper() != "")
                {

                    strTranType = ddl_product.SelectedValue.ToString();
                    Session["StrTranTypenew"] = strTranType;
                    if (Session["StrTranTypenew"] != null)
                    {
                        strTranType = Session["StrTranTypenew"].ToString();
                    }
                  
                    if (Session["StrTranTypenew"] != null)
                    {


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
                        else if (Session["StrTranTypenew"].ToString() == "CH")
                        {
                            getCHA();
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                            //txtto.Focus();
                            chkmbl.Focus();
                        }
                        else if (Session["StrTranTypenew"].ToString() == "BT")
                        {
                            getBT();
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                            //txtto.Focus();
                            chkmbl.Focus();
                        }

                    }

                    if (lbl_Header.Text == "Profoma Invoice")
                    {

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
                    }
                    else
                    {
                        if (hid_mloid.Value != "")
                        {
                            hid_SupplyTo.Value = hid_mloid.Value;
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
                    btncancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-cancel";

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
                if (Session["StrTranTypenew"].ToString() == "BT")
                {
                    txtto.Focus();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }
            btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
        }

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
            hdnUnit.Value = "";
            cmbbase.SelectedIndex = -1;
            txtamount.Text = "";
            btnadd.Text = "Add";
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
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                btncancel.Text = "Cancel";
                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                string a = hdncityid.Value;
                int cityid; string address;
                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string sezcus = "";
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtref.Text = "";
                    return;
                }

                string str_TranType = ddl_product.SelectedValue.ToString();
                // string str_TranType = Session["StrTranTypenew"].ToString();
                int int_custid = Convert.ToInt32(hdncustid.Value);
                DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                if (txtto.Text != "")
                {
                    int_custid = Convert.ToInt32(hdncustid.Value);
                    DataTable dt_list = new DataTable();

                    dtnew = cus.getcustomerblk(int_custid);
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txtto.Text + " status is Hold please discuss with Finance team ');", true);
                        txtto.Text = "";
                        txtto.Focus();
                        return;
                    }
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


                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        sezcus = customerobj.getsezcustid(int_custid);
                        if (sezcus == "Y")
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  Once again update the chargedetails because this sez customer');", true);
                            if (lbl_Header.Text == "Profoma Invoice")
                            {
                                switch (Session["StrTranTypenew"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                }
                            }
                        }

                    }



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
                                //if (hid_SupplyTo.Value )
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
                           btnsave.Text = "Save";
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

                    if (lbl_Header.Text == "Proforma Invoice" || lbl_Header.Text == "Profoma Invoice")
                    {
                        chkmbl.Enabled = true;
                    }
                    else
                    {
                        chkmbl.Enabled = true;
                    }

                    lbl_txt.Visible = false;
                    lbl_appr.Visible = false;
                    if (Session["LoginDivisionId"] != null)
                    {
                        divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    }
                    if (Session["LoginBranchid"] != null)
                    {
                        branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    }
                    ddl_product.Enabled = true;
                    txtclear();
                    txtEnable();
                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Gray;
                    btnsave.Text = "Save";
                    btnsave.ToolTip = "Save";
                    btn_save1.Attributes["class"] = "btn ico-save";
                    btncancel.Text = "Back";
                    btncancel.ToolTip = "Back";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                    txtblno.Focus();
                    btnadd.Text = "Add";
                    txtcharge.Enabled = true;
                    txtTotal.Text = "";
                    grd.Enabled = true;


                    txtVendorRefno.Text = "";
                    txtVendorRefnodate.Text = "";
                    txtCreditDays.Text = "";
                    hdnfatransfer.Value = "0";


                    txtsupplyto.Text = "";


                    dtdate.Text = Logobj.GetDate().ToShortDateString();
                    dtdate.Text = Utility.fn_ConvertDate(dtdate.Text);

                    //FillOnPageLoad();
                    dt = new DataTable();
                    ShowNoResultFound(dt, grd);
                    ddl_product.SelectedIndex = 0;
                    Session["StrTranTypenew"] = null;
                    // btnview.Enabled = false;
                    //btnview.ForeColor = System.Drawing.Color.Gray;
                    // Session["LoginEmpId"] = Session["LoginEmpId"].ToString();

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

                    if (lbl_Header.Text == "Proforma Invoice" || lbl_Header.Text == "Profoma Invoice")
                    {
                        chkmbl.Enabled = true;
                    }
                    else
                    {
                        chkmbl.Enabled = true;
                    }

                    //this.Response.End();
                    if (Session["StrTranTypenew"] != null)
                    {
                        if (Session["home"] != null)
                        {
                            if (Session["home"].ToString() == "OPS&DOC")
                            {
                                if (Session["StrTranTypenew"].ToString() == "FE")
                                {
                                    // headerlable1.InnerText = "OceanExports";
                                    if (Request.QueryString.ToString().Contains("app1"))
                                    {
                                        Response.Redirect("../ForwardExports/JobInfo.aspx");
                                    }
                                    else if (Request.QueryString.ToString().Contains("app2"))
                                    {
                                        Response.Redirect("../ForwardExports/JobInfo.aspx");
                                    }
                                    else if (Request.QueryString.ToString().Contains("appfbl"))
                                    {
                                        Response.Redirect("../ShipmentDetails/FEBLdetails.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                    }


                                }
                                else if (Session["StrTranTypenew"].ToString() == "FI")
                                {
                                    //Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                    if (Request.QueryString.ToString().Contains("app1"))
                                    {
                                        Response.Redirect("../FI/jobinfo.aspx");
                                    }
                                    else if (Request.QueryString.ToString().Contains("app2"))
                                    {
                                        Response.Redirect("../FI/jobinfo.aspx");
                                    }
                                    else if (Request.QueryString.ToString().Contains("appfibl"))
                                    {
                                        //  string fidirectbl = "Direct BL";
                                        string blid = Request.QueryString["lblid"].ToString();
                                        Response.Redirect("../FI/FIBL.aspx?fidirectbl=" + blid);
                                    }

                                    else
                                    {
                                        Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                    }
                                }
                                else if (Session["StrTranTypenew"].ToString() == "AE")
                                {
                                    //Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                    if (Request.QueryString.ToString().Contains("app1"))
                                    {
                                        // Response.Redirect("../FI/jobinfo.aspx");
                                        string AEbl = Request.QueryString["lblid"].ToString();
                                        Response.Redirect("../AE/AEJobinfo.aspx?AEbl=" + AEbl);
                                    }
                                    else if (Request.QueryString.ToString().Contains("app2"))
                                    {
                                        string AEbl = Request.QueryString["lblid"].ToString();
                                        Response.Redirect("../AE/AEJobinfo.aspx?AEbl=" + AEbl);
                                    }

                                    else if (Request.QueryString.ToString().Contains("appaebll"))
                                    {
                                        //  string fidirectbl = "Direct BL";
                                        string AEbl = Request.QueryString["lblid"].ToString();
                                        Response.Redirect("../AE/AEAWBDetails.aspx?AEbl=" + AEbl);
                                    }

                                    else
                                    {
                                        Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                    }
                                }
                                else if (Session["StrTranTypenew"].ToString() == "AI")
                                {
                                    //Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                    if (Request.QueryString.ToString().Contains("app1"))
                                    {
                                        // Response.Redirect("../FI/jobinfo.aspx");
                                        string AEbl = Request.QueryString["lblid"].ToString();
                                        Response.Redirect("../AE/AEJobinfo.aspx?AEbl=" + AEbl);
                                    }
                                    else if (Request.QueryString.ToString().Contains("app2"))
                                    {
                                        string lblid = Request.QueryString["lblid"].ToString();
                                        Response.Redirect("../AE/AEJobinfo.aspx?AEbl=" + lblid);
                                    }

                                    else if (Request.QueryString.ToString().Contains("appaebll"))
                                    {
                                        //  string fidirectbl = "Direct BL";
                                        string AEbl = Request.QueryString["lblid"].ToString();
                                        Response.Redirect("../AE/AEAWBDetails.aspx?AEbl=" + AEbl);
                                    }
                                    else
                                    {
                                        Response.Redirect("../Home/OEOpsAndDocs.aspx");
                                    }
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
            btncancel.ToolTip = "Cancel";
            string sezcus = "";
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }
            if (txtvouyear.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Enter Vouyear');", true);
                txtvouyear.Text = "";
                return;
            }
            Session["StrTranTypenew"] = ddl_product.SelectedValue.ToString();
            useit();
            Session["LoginEmpId"] = Session["LoginEmpId"].ToString();
            int empid = Convert.ToInt32(Session["LoginEmpId"]);
            if (txtblno.Text.Trim().ToUpper() != "")
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
            }

            if (txtCreditDays.Text == "")
            {
                txtCreditDays.Text = "0";
            }

            CheckData();
            if (lbl_Header.Text == "Profoma Purchase Invoice")
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
            else
            {
                if (txtVendorRefnodate.Text == "")
                {
                    txtVendorRefnodate.Text = Logobj.GetDate().ToShortDateString();
                    txtVendorRefnodate.Text = Utility.fn_ConvertDate(txtVendorRefnodate.Text);
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

            //raj
            DataTable obj_dt = new DataTable();
            DataAccess.Accounts.DCAdvise obj_da_DC = new DataAccess.Accounts.DCAdvise();
          
     


            obj_dt = obj_da_DC.FillBLNo(Convert.ToInt32(txtjobno.Value), Session["StrTranTypenew"].ToString(), Convert.ToInt32(Session["LoginBranchid"].ToString()));
            if (obj_dt.Rows.Count == 0)
            {


                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Atleast One HBL Should Exists before Closing for the Job # " + Convert.ToInt32(txtjobno.Value) + "');", true);
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


                    //Dinesh
                    /*if ((INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjobno.Value), branchid)) == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtjobno.Value + " has been Closed Already...You Can not create a Voucher');", true);
                        return;

                    }*/

                    //     dtdate.Text = Utility.fn_ConvertDate(dtdate.Text).ToString();
                    //if (lbl_Header.Text == "Profoma Credit Note - Operations")
                    //{
                    //    Refno = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), strTranType, Convert.ToInt32(txtjobno.Value), Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), type, txtVendorRefno.Text, Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                    //}
                    //else
                    //{
                    //    Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), strTranType, Convert.ToInt32(txtjobno.Value), Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), type, txtVendorRefno.Text, Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value));
                    //}

                    Refno = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), strTranType, Convert.ToInt32(txtjobno.Value), Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), type, txtVendorRefno.Text, Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                   


                    txtref.Text = Refno.ToString();
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        switch (Session["StrTranTypenew"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "CH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                        }
                    }
                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
                    {
                        switch (Session["StrTranTypenew"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                            case "CH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/Sav");
                                break;
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Ref # " + txtref.Text + " saved ');", true);
                    btnsave.Enabled = false;
                    btnsave.Text = "Update";
                    btnsave.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";

                    btnadd.Enabled = true;
                    btnsave.ForeColor = System.Drawing.Color.Gray;
                    btnadd.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    //dtdate.Text = Logobj.GetDate().ToShortDateString();
                    //dtdate.Text = Utility.fn_ConvertDate(dtdate.Text);


                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        sezcus = customerobj.getsezcustid(Convert.ToInt32(hdncustid.Value));
                        if (sezcus == "Y")
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  Once again update the chargedetails because this sez customer');", true);
                            if (lbl_Header.Text == "Profoma Invoice")
                            {
                                switch (Session["StrTranTypenew"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                }
                            }
                        }

                    }

                    if (cmbbill.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Bill Type');", true);
                        return;
                    }
                    dtcheck = new DataTable();
                    /* dtcheck = INVOICEobj.GetCheckApprovedProfoma(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), strTranType, type, "HeadUpdate");
                     if (dtcheck.Rows.Count > 0)
                     {
                         ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Update Denied, Already Approved for Ref# " + txtref.Text + "');", true);
                         return;
                     }
                     else
                     {*/
                    if (Convert.ToInt32(hdncustid.Value) != 0)
                    {
                        //if (lbl_Header.Text == "Profoma Credit Note - Operations")
                        //{
                            ProINVobj.UpdateProHeadnew(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtremarks.Text.Trim(), cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, txtVendorRefno.Text.Trim(), Convert.ToInt32(txtCreditDays.Text), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                        //}
                        //else
                        //{
                        //    ProINVobj.UpdateProHead(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtremarks.Text.Trim(), cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, txtVendorRefno.Text.Trim(), Convert.ToInt32(txtCreditDays.Text), Convert.ToInt32(hid_SupplyTo.Value));
                        //}
                        if (hid_SupplyTonew.Value != hid_SupplyTo.Value)
                        {

                            ProINVobj.UpdChargesGST4OldVou(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), type);
                            hid_SupplyTonew.Value = hid_SupplyTo.Value;


                        }
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated for Ref# " + txtref.Text + "');", true);
                        // return;
                        // btnadd.Enabled = true;
                        // btnadd.ForeColor = System.Drawing.Color.White;
                    }
                    // }


                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        switch (Session["StrTranTypenew"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "CH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                        }
                    }
                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
                    {
                        switch (Session["StrTranTypenew"].ToString())
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                            case "CH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text  + "/UPD");
                                break;
                        }
                    }
                }
                txtDisable();
                btnadd.Enabled = true;
                btnadd.ForeColor = System.Drawing.Color.White;
                txtcharge.Focus();
                // dtdate.Text = Utility.fn_ConvertDate(dtdate.Text).ToString();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
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
                    if (dt_list.Rows.Count == 0 && Convert.ToInt32(Session["LoginDivisionId"]) == 1)
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
            if (lbl_Header.Text == "Profoma Purchase Invoice")
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
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtref.Text = "";
                    return;
                }
                Session["StrTranTypenew"] = ddl_product.SelectedValue.ToString();
                if (Session["StrTranTypenew"] != null)
                {
                    strTranType = Session["StrTranTypenew"].ToString();
                }
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                //type = Request.QueryString["type"].ToString();
                if (lbl_Header.Text == "Profoma Purchase Invoice")
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
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-back";
        }

        protected void txtref_TextChanged(object sender, EventArgs e)
        {
            try
            {
                useit();
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtref.Text = "";
                    return;
                }

                strTranType = ddl_product.SelectedValue.ToString();
                //   DataAccess.Masters.MasterCustomer customerobj = new DataAccess.Masters.MasterCustomer();

                if (lbl_Header.Text == "Profoma Purchase Invoice" && strTranType == "AE")
                {
                    type = "Profoma Payment Advise";
                    hf_strtype.Value = type;
                }
                else if (lbl_Header.Text == "Profoma Purchase Invoice")
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


                DtSHead = ProINVobj.SelProInvHeadnew(Convert.ToInt32(txtref.Text), strTranType, Convert.ToInt32(txtvouyear.Text), branchid, type);
                if (DtSHead.Rows.Count > 0)
                {
                    btn_save1.Visible = true;
                    txtjobno.Value = DtSHead.Rows[0]["jobno"].ToString();
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


                    if (type == "Profoma Payment Advise" || type == "Profoma Purchase Invoice")
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

                        if (DtSHead.Rows[0]["vendorrefno"] != System.DBNull.Value)
                        {
                            txtVendorRefno.Text = DtSHead.Rows[0]["vendorrefno"].ToString();
                        }
                        else
                        {
                            txtVendorRefno.Text = "";
                        }
                       // txtCreditDays.Text = DtSHead.Rows[0]["creditdays"].ToString();

                        if (DtSHead.Rows[0]["vendorrefdate"] != System.DBNull.Value)
                        {
                            txtVendorRefnodate.Text = DtSHead.Rows[0]["vendorrefdate"].ToString();
                        }
                        else
                        {
                            txtVendorRefnodate.Text = "";
                        }
                        txtCreditDays.Text = "";
                        
                    }
                    if (strTranType == "FE" || strTranType == "FI")
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
                            getFEI();
                            btnview.Enabled = true;
                            btnview.ForeColor = System.Drawing.Color.White;
                        }

                    }
                    else if (strTranType == "AE" || strTranType == "AI")
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

                    }
                    else if (strTranType == "BT")
                    {
                        getBT();
                        btnview.Enabled = true;
                        btnview.ForeColor = System.Drawing.Color.White;
                        chkmbl.Focus();
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
                    grdfill();
                    txtTotal.Text = "";
                    double tot = 0, tot1 = 0;
                    for (i = 0; i <= grd.Rows.Count - 1; i++)
                    {
                        tot1 = Convert.ToDouble(grd.Rows[i].Cells[7].Text);
                        tot = tot + tot1;
                    }
                    txtTotal.Text = tot.ToString("#,0.00");
                    btnsave.Text = "Update";
                    btnsave.ToolTip = "Update";
                    btn_save1.Attributes["class"] = "btn ico-update";
                    btncancel.ToolTip = "Cancel";
                    btn_cancel1.Attributes["class"] = "btn ico-back";
                    txtcharge.Enabled = true;
                    txtcharge.Focus();
                    btnview.Enabled = true;
                    btnview.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Refno');", true);
                    txtref.Text = "";
                    txtref.Focus();
                  

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
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }

            int count = 0;
            strTranType = ddl_product.SelectedValue.ToString();
            Session["StrTranTypenew"] = ddl_product.SelectedValue.ToString();
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
                    if (lbl_Header.Text == "Profoma Purchase Invoice")
                    {
                        type = "Profoma Payment Advise";
                        hf_strtype.Value = type;
                    }
                    else
                    {
                        type = lbl_Header.Text;
                        hf_strtype.Value = type;
                    }
                    hdnChargid.Value = chargeobj.GetChargeid(txtcharge.Text).ToString();
                    if (hdnChargid.Value == "0")
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
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('select base');", true);
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
                    //Dinesh

                    /* dtchargedel = INVOICEobj.GetCheckApprovedProfoma(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), "", type, "Charge");
                     if (dtchargedel.Rows.Count > 0)
                     {
                         ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charges Cannot Delete After Approved');", true);
                         return;
                     }*/



                    /*if ((INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjobno.Value), branchid)) == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtjobno.Value + " has been Closed Already...You Can not create a Voucher');", true);
                        return;

                    }*/
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

                            //for (i = 0; i <= grd.Rows.Count - 1; i++)
                            //{

                            //    if (grd.Rows[i].Cells[1].Text.ToUpper() == txtcurr.Text.ToUpper())
                            //    {
                            //        //if (grd.Rows[i].Cells[3].Text != txtex.Text)
                            //        if (Convert.ToDouble(grd.Rows[i].Cells[3].Text) != Convert.ToDouble(txtex.Text))
                            //        {
                            //            //ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Exrate Different kindly check with  " + txtcharge.Text + " .');", true);
                            //            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different  Exrate is not allowed for same Currency,Kindly check Exrate for :" + txtcurr.Text + ");", true);
                            //            txtex.Focus();
                            //            return;
                            //        }

                            //    }
                            //}

                            for (i = 0; i <= grd.Rows.Count - 1; i++)
                            {
                                if (grd.Rows[i].Cells[1].Text.ToUpper() == txtcurr.Text.ToUpper())
                                {
                                    count = count + 1;

                                }
                            }
                            for (i = 0; i <= grd.Rows.Count - 1; i++)
                            {

                                if (grd.Rows[i].Cells[1].Text.ToUpper() == txtcurr.Text.ToUpper())
                                {

                                    if (count >= 1)
                                    {
                                        //if (grd.Rows[i].Cells[4].Text != txtex.Text)
                                        if ((Convert.ToDouble(grd.Rows[i].Cells[3].Text)) != (Convert.ToDouble(txtex.Text)))
                                        {
                                            //ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Exrate Different kindly check with  " + txtcharge.Text + " .');", true);

                                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different  Exrate is not allowed for same Currency,Kindly check Exrate for " + txtcurr.Text + ".');", true);
                                            txtex.Focus();
                                            return;
                                        }
                                    }

                                }
                            }


                            if (btnadd.Text == "Add")
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

                                                    ProINVobj.InsertProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedItem.Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedItem.Text, strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));



                                                }
                                                else
                                                {
                                                    this.PopUpService.Show();
                                                    return;
                                                }

                                            }
                                            else
                                            {


                                                ProINVobj.InsertProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.Text, strTranType, type, "Y", Convert.ToDouble(hdnUnit.Value));

                                            }

                                        }
                                        else
                                        {

                                            ProINVobj.InsertProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.Text, strTranType, type, "Y", Convert.ToDouble(hdnUnit.Value));

                                        }


                                        if (lbl_Header.Text == "Profoma Invoice")
                                        {
                                            switch (Session["StrTranTypenew"].ToString())
                                            {
                                                case "FE":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text  + "/Add");
                                                    break;
                                                case "FI":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                    break;
                                                case "AE":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                    break;
                                                case "AI":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                    break;
                                                case "CH":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                    break;
                                            }
                                        }
                                        else if (lbl_Header.Text == "Profoma Purchase Invoice")
                                        {
                                            switch (Session["StrTranTypenew"].ToString())
                                            {
                                                case "FE":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                    break;
                                                case "FI":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                    break;
                                                case "AE":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text  + "/Add");
                                                    break;
                                                case "AI":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text  + "/Add");
                                                    break;
                                                case "CH":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                    break;
                                            }

                                        }
                                        /* switch (Session["StrTranTypenew"].ToString())
                                         {
                                             case "FE":
                                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 388, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                 break;
                                             case "FI":
                                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 779, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                 break;
                                             case "AE":
                                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 390, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                 break;
                                             case "AI":
                                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 391, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                 break;
                                             case "CH":
                                                 Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 392, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                 break;
                                         }*/
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

                                    ProINVobj.UpdateProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), hid_cmbase.Value, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, Convert.ToDouble(hdnUnit.Value));



                                    if (lbl_Header.Text == "Profoma Invoice")
                                    {
                                        switch (Session["StrTranTypenew"].ToString())
                                        {
                                            case "FE":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                            case "FI":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text  + "/UPD");
                                                break;
                                            case "AE":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                            case "AI":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text  + "/UPD");
                                                break;
                                            case "CH":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                        }
                                    }
                                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
                                    {
                                        switch (Session["StrTranTypenew"].ToString())
                                        {
                                            case "FE":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                            case "FI":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                            case "AE":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                            case "AI":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                            case "CH":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                break;
                                        }
                                    }

                                    /*switch (Session["StrTranTypenew"].ToString())
                                    {
                                        case "FE":
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 388, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                            break;
                                        case "FI":
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 779, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                            break;
                                        case "AE":
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 390, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                            break;
                                        case "AI":
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 391, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                            break;
                                        case "CH":
                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 392, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                            break;
                                    }*/
                                    grdfill();
                                    txtcharge.Focus();
                                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charges Details Updated ...');", true);
                                    //txtcharge.Text = ""; txtcurr.Text = ""; txtrate.Text = ""; txtex.Text = ""; txtamount.Text = ""; cmbbase.SelectedIndex = 0;
                                }
                            }
                        } grdfill();
                        chargetxtclear();
                        btnadd.Text = "Add";
                        txtcharge.Enabled = true;
                        btnadd.Enabled = false;
                        btnadd.ForeColor = System.Drawing.Color.Gray;
                        txtcharge.Focus();
                        UserRights();
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

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
            btncancel.Text = "Cancel";
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
            //ProINVobj.InsertProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text),Convert .ToInt32(hdnChargid.Value), txtcurr.Text,Convert.ToDouble (txtrate.Text),Convert.ToDouble ( txtex.Text), cmbbase.SelectedItem .Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32 (txtvouyear.Text), cmbbill.Text, strTranType, type, "Y", Convert.ToDouble (hdnUnit .Value));
            txtref.Text = "";
            txtremarks.Text = "";
            //hid_SupplyTo.Value = hdncustid.Value;
            if (hid_SupplyTo.Value != "" && hid_SupplyTo.Value != "0")
            {
                hid_SupplyTo.Value = hid_SupplyTo.Value;
            }
            else
            {
                hid_SupplyTo.Value = hdncustid.Value;
            }
            this.popupconfirmnew.Hide();
            //grdfill();
            btnsave.Text = "Save";
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

                btnadd.Text = "Upd";
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





        public double CheckBase(string strbase, double rate, double exrate)
        {
            //if (ddl_product.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
            //    ddl_product.Focus();
            //    return;
            //}
            //strTranType = ddl_product.SelectedValue.ToString();
            useit();
            if (ddl_product.SelectedValue == "BT")
            {
                if (cmbbase.Text.ToUpper() == "Truck".ToUpper())
                {
                    amount = rate * exrate;
                    hdnUnit.Value = "1";
                }
                else if (cmbbase.Text.ToUpper() == "CBM".ToUpper() || cmbbase.Text.ToUpper() == "KGS".ToUpper())
                {
                    if (cmbbase.Text.ToUpper() == "CBM".ToUpper())
                    {
                        //strvolume = BTINVOICEobj.GetVolumeFSBNo()
                        strvolume = BTINVOICEobj.GetVolumeFSBNo(txtblno.Text, Convert.ToInt32(hf_custid.Value), branchid, divisionid, Convert.ToInt32(txtjobno.Value));
                        amount = rate * exrate * strvolume;
                        hdnUnit.Value = strvolume.ToString();
                    }
                    else
                    {
                        strvolume = BTINVOICEobj.GetWeightFSBNo(txtblno.Text, Convert.ToInt32(hf_custid.Value), branchid, divisionid, Convert.ToInt32(txtjobno.Value));
                        if (strvolume < 1)
                        {
                            amount = rate * exrate * 1;
                            hdnUnit.Value = "1";
                        }
                        else
                        {
                            amount = rate * exrate * strvolume;
                            hdnUnit.Value = strvolume.ToString();
                        }
                    }
                }
            }
            else if (cmbbase.Text.ToUpper() == "BL".ToUpper() || cmbbase.Text.ToUpper() == "HWBL".ToUpper() || cmbbase.Text.ToUpper() == "DOC".ToUpper() || cmbbase.Text.ToUpper() == "HAWB".ToUpper())
            {
                amount = rate * exrate;
                hdnUnit.Value = "1";
            }
            //---------------------------------------------------------------
                else if (strbase.ToString() == "COTTON/PALLET".ToUpper())
                {
                    string strchgpallet;
                    if (strTranType == "AE" || strTranType == "AI")
                    {
                        if (chkmbl.Checked == false)
                        {
                            DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                            DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                            strchgpallet = INVOICEobj.Getchargepallet(cmbbase.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                            amount = rate * exrate * Convert.ToDouble(strchgpallet);
                            doublevolume = Convert.ToDouble(strchgpallet);
                            fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                            hdnUnit.Value = doublevolume.ToString();
                            //   unit = strchgweight.ToString();
                            // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                        }
                        else
                        {
                            DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                            DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                           // strchgpallet = INVOICEobj.Getchargepallet(cmbbase.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                            Double strchgpallet1 = INVOICEobj.Getchargepalletmbl(Convert.ToInt32(txtjobno.Value), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            amount = rate * exrate * Convert.ToDouble(strchgpallet1);
                            doublevolume = Convert.ToDouble(strchgpallet1);
                            fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                            hdnUnit.Value = doublevolume.ToString();
                        }

                    }
                }


            else if (strbase.ToString() == "PERTRUCK".ToUpper())
            {
                string strchgtruck;
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (chkmbl.Checked == false)
                    {
                        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgtruck = INVOICEobj.Getchargetruck(cmbbase.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgtruck);
                        doublevolume = Convert.ToDouble(strchgtruck);
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                        hdnUnit.Value = doublevolume.ToString();
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }
                    else
                    {
                        DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                      //  strchgtruck = INVOICEobj.Getchargetruck(cmbbase.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        Double strchgtruck1 = INVOICEobj.Getchargetrucknew(Convert.ToInt32(txtjobno.Value), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * Convert.ToDouble(strchgtruck1);
                        doublevolume = Convert.ToDouble(strchgtruck1);
                        fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                        hdnUnit.Value = doublevolume.ToString();
                    }

                }
            }


            else if (cmbbase.Text.ToUpper() == "CBM".ToUpper() || cmbbase.Text.ToUpper() == "MT".ToUpper())
            {
                if (cmbbase.Text.ToUpper() == "CBM".ToUpper())
                {
                    if (strTranType == "FE")
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
                        if (strTranType == "FE")
                        {
                            if (chkmbl.Checked == false)
                            {
                                if (type == "InvoiceWoJ")
                                {
                                    strntweight = INVOICEobj.GetWeightnew(txtblno.Text, "Wo", branchid);
                                   // amount = rate * exrate * (strntweight / 1000);
                                    amount = rate * exrate * (strntweight);
                                }
                                else
                                {
                                    strntweight = INVOICEobj.GetWeightnew(txtblno.Text, strTranType, branchid);
                                   // amount = rate * exrate * (strntweight / 1000);
                                    amount = rate * exrate * (strntweight);
                                    doublevolume = strntweight;
                                   // hdnUnit.Value = (strntweight / 1000).ToString();
                                    hdnUnit.Value = (strntweight).ToString();
                                    fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                                }

                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeightnew(txtjobno.Value, strTranType, branchid);
                              //  amount = rate * exrate * (strntweight / 1000);
                                amount = rate * exrate * (strntweight);
                                doublevolume = strntweight;
                               // hdnUnit.Value = (strntweight / 1000).ToString();
                                hdnUnit.Value = (strntweight).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                            }
                        }
                        else
                        {
                            if (chkmbl.Checked == false)
                            {
                                strntweight = INVOICEobj.GetWeightnew(txtblno.Text, strTranType, branchid);
                                //amount = rate * exrate * (strntweight / 1000);
                                amount = rate * exrate * (strntweight );
                                doublevolume = strntweight;
                               // hdnUnit.Value = (strntweight / 1000).ToString();
                                hdnUnit.Value = (strntweight).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeightnew(txtjobno.Value, strTranType, branchid);
                              //  amount = rate * exrate * (strntweight / 1000);
                                amount = rate * exrate * (strntweight);
                                doublevolume = strntweight;
                             //   hdnUnit.Value = (strntweight / 1000).ToString();
                                hdnUnit.Value = (strntweight).ToString();
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
                if (strTranType == "FE")
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
                    if (strTranType == "FE")
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


        protected void cmbbase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }
            strTranType = ddl_product.SelectedValue.ToString();
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

        protected void btndelete_Click(object sender, EventArgs e)
        {
            btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btn_cancel1.Attributes["class"] = "btn ico-cancel";
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }
            if (txtvouyear.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Enter Vouyear');", true);
                txtvouyear.Text = "";
                return;
            }
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

                //dtchargedel = INVOICEobj.GetCheckApprovedProfoma(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), "", type, "Charge");
                //if (dtchargedel.Rows.Count > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Charge Already Approved. Cannot Be Delete..", true);
                //    return;
                //}
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
                    ProINVobj.DelProinvDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), cmbbase.SelectedItem.Text, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type);
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted.", true);
                    grdfill();

                    if (grd.Rows.Count == 0 || index < 1)
                    {
                        txtclear();
                        txtEnable();
                    }

                    chargetxtclear();
                    //txtTotal.Text = "";
                    //double tot = 0, tot1 = 0;
                    //for (i = 0; i <= grd.Rows.Count - 1; i++)
                    //{
                    //    tot1 = Convert.ToDouble(grd.Rows[i].Cells[6].Text);
                    //    tot = tot + tot1;
                    //}
                    //txtTotal.Text = tot.ToString("#,0.00");

                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btnview_Click(object sender, EventArgs e)
        {

            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                return;
            }
            if (txtvouyear.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Enter Vouyear');", true);
                txtvouyear.Text = "";
                return;
            }
            Session["StrTranTypenew"] = ddl_product.SelectedValue.ToString();
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
            int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
            int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
            string str_TranType = Session["StrTranTypenew"].ToString();

            string Str_Container = "";
            if (str_TranType == "FE" || str_TranType == "FI")
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
                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
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
                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
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
                else if (str_TranType == "FE")
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
                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
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
                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
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
                    else if (lbl_Header.Text == "Profoma Purchase Invoice")
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
                        str_Script = "window.open('../Reportasp/InvoicerptFA.aspx?Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&trantype=" + str_TranType + "&" + this.Page.ClientQueryString + "','','');";
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
                    if (txtref.Text.TrimEnd().Length == 0 && lbl_Header.Text == "Profoma Purchase Invoice")
                    {
                        str_RptName = "Pro PA Register.rpt";
                        str_sp = "Title=PROFORMA Purchase Invoice REGISTER FOR VOUYEAR " + txtvouyear.Text;
                        str_sf = "{ACProPAHead.trantype}=\"" + str_TranType + "\" and {ACProPAHead.branchid}=" + int_branchid + " and {ACProPAHead.vouyear}=" + txtvouyear.Text;
                    }
                    else
                    {
                        str_RptName = "ProInvRegister.rpt";
                        str_sp = "Title=PROFORMA INVOICE REGISTER FOR VOUYEAR " + txtvouyear.Text;
                        str_sf = "{ACProInvoiceHead.trantype}=\"" + str_TranType + "\" and {ACProInvoiceHead.branchid}=" + int_branchid + " and {ACProInvoiceHead.vouyear}=" + txtvouyear.Text;
                    }
                }
                else if (str_TranType == "CH" && lbl_Header.Text == "Profoma Purchase Invoice")
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
                    case "FE":
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "FI":
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "AE":
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "AI":
                       // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "CH":
                       // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                }
            }
            else if (lbl_Header.Text == "Profoma Purchase Invoice")
            {
                switch (Session["StrTranTypenew"].ToString())
                {
                    case "FE":
                       // Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "FI":
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "AE":
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "AI":
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                    case "CH":
                        //Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1826, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + Refno);
                        break;
                }
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
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    return;
                }
                strTranType = ddl_product.SelectedValue.ToString();

                //if (lbl_Header.Text == "Proforma Invoice")
                //{
                ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                if (bolcuststat == true)
                {
                    bolcuststat = false;
                    return;
                }
                //}

                ProINVobj.InsertProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedValue.ToString(), Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedValue.ToString(), strTranType, type, "Y", Convert.ToDouble(hdnUnit.Value));
                grdfill();
                this.PopUpService.Hide();
                chargetxtclear();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            try
            {
                useit();
                ProINVobj.InsertProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedValue.ToString(), Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedValue.ToString(), strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));
                grdfill();
                this.PopUpService.Hide();
                chargetxtclear();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }

        }

        protected void txtcurr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtcurr.Text = "";
                    return;
                }
                string str_TranType = ddl_product.SelectedValue.ToString();

                DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());

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
            //ProINVobj.InsertProInvoiceDetailsNEW(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedItem .Text, Convert.ToDouble(txtamount.Text), branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.Text, strTranType, type, "N", Convert.ToDouble(hdnUnit.Value));
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
                btnsave.Text = "Update";
                btnsave.ToolTip = "Update";
                btn_save1.Attributes["class"] = "btn ico-update";
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

            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                txtex.Text = "";
                return;
            }
            strTranType = ddl_product.SelectedValue.ToString();
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

                btncancel.ToolTip = "Cancel";
                btn_cancel1.Attributes["class"] = "btn ico-cancel";
                string sezcus = "";
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

                    dtnew = cus.getcustomerblk(int_custid);
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txtsupplyto.Text + " status is Hold please discuss with Finance team ');", true);
                        txtsupplyto.Text = "";
                        txtsupplyto.Focus();
                        return;
                    }
                    if (lbl_Header.Text == "Profoma Invoice")
                    {
                        sezcus = customerobj.getsezcustid(int_custid);
                        if (sezcus == "Y")
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  Once again update the chargedetails because this sez customer');", true);
                            if (lbl_Header.Text == "Profoma Invoice")
                            {
                                switch (Session["StrTranTypenew"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1825, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypenew"].ToString() + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                }
                            }
                        }

                    }



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

        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOnPageLoad();
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
            DataAccess.LogDetails Logobj = new DataAccess.LogDetails();
            lbl_no.InnerText = lbl_Header.Text;

            if (lbl_Header.Text == "Proforma Invoice")
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1825, "", "", "", Session["StrTranType"].ToString());
            }
            else
            {
                obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1826, "", "", "", Session["StrTranType"].ToString());
            }


            if (obj_dtlogdetails.Rows.Count >= 0)
            {
                ModalPopupExtenderlog.Show();
                GridViewlog.DataSource = obj_dtlogdetails;
                GridViewlog.DataBind();
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




    }
}