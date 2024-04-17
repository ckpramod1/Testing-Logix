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

namespace logix.Accounts
{
    public partial class ProformaLV : System.Web.UI.Page
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

        DataAccess.Masters.MasterBranch obj_branchd = new DataAccess.Masters.MasterBranch();
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
        string type, strTranType, vessel, voyage, agent, jobtype, volume, wt, fatransfers, strcharge, strchgtruck, strchgpallet;
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

        DataTable dtnew = new DataTable();
        DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();

        DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
        DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
        DataAccess.ForwardingExports.BLDetails obj_da_FEBL2 = new DataAccess.ForwardingExports.BLDetails();
        DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.Accounts.ProfomaInvoice obj_da_head = new DataAccess.Accounts.ProfomaInvoice();
        DataAccess.Corporate obj_da_corpobj = new DataAccess.Corporate();
        DataAccess.UserPermission userobj = new DataAccess.UserPermission();
      


        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SpanTagMoveInputBottom();MuiTextField();", true);

            string Ccode = Convert.ToString(Session["Ccode"]);

            if (Ccode != "")
            {

                Logobj.GetDataBase(Ccode);
                FEJobobj.GetDataBase(Ccode);
                INVOICEobj.GetDataBase(Ccode);
                FEBLobj.GetDataBase(Ccode);
                Amendobj.GetDataBase(Ccode);
                customerobj.GetDataBase(Ccode);
                ProINVobj.GetDataBase(Ccode);

                DCAdviseObj.GetDataBase(Ccode);
                chargeobj.GetDataBase(Ccode);
                FIBLobj.GetDataBase(Ccode);
                obj_da_mc.GetDataBase(Ccode);
                obj_da_FIBL.GetDataBase(Ccode);
                obj_branchd.GetDataBase(Ccode);
                obj_da_inv.GetDataBase(Ccode);

                cus.GetDataBase(Ccode);
                obj_da_FEBL2.GetDataBase(Ccode);
                obj_inv.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);
                obj_da_head.GetDataBase(Ccode);
                obj_da_corpobj.GetDataBase(Ccode);

                userobj.GetDataBase(Ccode);

            }

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtto);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtref);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Session["LoginDivisionId"] != null)
            {
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            }
            if (Session["LoginBranchid"] != null)
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
            }
            //if (Session["StrTranType"] != null)
            //{
            //    strTranType = ddl_product.SelectedValue;

            //}
            if (Session["StrTranType"] != null)
            {
                // Session["StrTranTypeFA"] = Session["StrTranType"].ToString();

            }

            if (ddl_product.SelectedValue == "FE")
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
            grd.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            dtnew1 = obj_branchd.GetBranchGST(divisionid, branchid);
            if (dtnew1.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('Please update GST # to proceed with generation of voucher(s)');", true);
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
                    //if (Session["StrTranType"] != null)
                    //{
                    //    Session["StrTranTypeFA"] = Session["StrTranType"].ToString();
                    //    //  strTranType = Session["StrTranType"].ToString();

                    //}
                    if (Session["StrTranType"].ToString() == "AC")
                    {
                        ddl_product.Enabled = true;
                    }
                    else
                    {
                        ddl_product.SelectedValue = Session["StrTranType"].ToString();
                        ddl_product.Enabled = false;
                        strTranType = Session["StrTranType"].ToString();
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
                    }
                    UserRights();
                    UserRights4process();
                    btndelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";
                    txtblno.Focus();
                    ShowNoResultFound(dt, grd);
                    FillOnPageLoad();
                    //if (Request.QueryString.ToString().Contains("type"))
                    //{
                    //    if (Request.QueryString["type"].ToString() == "Profoma Credit Note - Operations")
                    //    {
                    //        lbl_Header.Text = "Proforma Purchase Invoice";
                    //    }
                    //    else
                    //    {
                    //        lbl_Header.Text = Request.QueryString["type"].ToString();
                    //    }
                    //}
                    if (Request.QueryString.ToString().Contains("1voutype"))
                    {
                        
                        ddl_voutype.SelectedValue = Request.QueryString["1voutype"].ToString();
                        txtref.Text = Request.QueryString["refno"].ToString();
                        txtvouyear.Text = Request.QueryString["1vouyear"].ToString();
                        //txtblno.Text = Request.QueryString["mblno"].ToString();
                        txtref_TextChanged(sender, e);
                        //chkmbl.Checked = true;
                        //chkmbl_CheckedChanged(sender, e);
                        //txtblno_TextChanged(sender, e);
                       
                    }
                    if (Request.QueryString.ToString().Contains("rptvoutype"))
                    {
                        ddl_voutype.SelectedValue = Request.QueryString["rptvoutype"].ToString();

                        txtref.Text = Request.QueryString["rptrefno"].ToString();
                        txtvouyear.Text = Request.QueryString["rptvouyear"].ToString();
                        //txtblno.Text = Request.QueryString["mblno"].ToString();
                        txtref_TextChanged(sender, e);
                        btnview_Click(sender, e);
                        Response.Redirect("../Reportasp/LVReport.aspx?" + Session["string"].ToString());
                        
                        //chkmbl.Checked = true;
                        //chkmbl_CheckedChanged(sender, e);
                        //txtblno_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("app1"))
                    {
                        //if (Request.QueryString["app1"].ToString() == "Proforma Sales Invoice")
                        //{
                        //    ddl_voutype.SelectedValue = "1";
                        //}

                        //int cnt = ddl_voutype.Items.Count;
                        //for (int i = 0; ddl_voutype.Items.Count > 0; i++)
                        //{

                        //}

                        ddl_voutype.SelectedValue = Request.QueryString["app1"].ToString();
                        Dropdownlist1_SelectedIndexChanged(sender, e);
                        txtblno.Text = Request.QueryString["mblno"].ToString();
                        chkmbl.Checked = true;
                        chkmbl_CheckedChanged(sender, e);
                        txtblno_TextChanged(sender, e);
                        ////lbl_Header.Text = Request.QueryString["app1"].ToString();
                        //txtblno.Text = Request.QueryString["mblno"].ToString();
                        //chkmbl.Checked = true;
                        //chkmbl_CheckedChanged(sender, e);
                        //txtblno_TextChanged(sender, e);
                       
                    }

                    if (Request.QueryString.ToString().Contains("app2"))
                    {
                        ddl_voutype.SelectedValue = Request.QueryString["app2"].ToString();
                        Dropdownlist1_SelectedIndexChanged(sender, e);
                        txtblno.Text = Request.QueryString["mblno"].ToString();
                        chkmbl.Checked = true;
                        chkmbl_CheckedChanged(sender, e);
                        txtblno_TextChanged(sender, e);
                        
                    }

                    if (Request.QueryString.ToString().Contains("appfbl"))
                    {
                        ddl_voutype.SelectedItem.Text = Request.QueryString["appfbl"].ToString();
                        Dropdownlist1_SelectedIndexChanged(sender, e);
                        txtblno.Text = Request.QueryString["feblno"].ToString();

                        txtblno_TextChanged(sender, e);
                       
                    }

                    if (Request.QueryString.ToString().Contains("appaebll"))
                    {
                        ddl_voutype.SelectedItem.Text = Request.QueryString["appaebll"].ToString();
                        Dropdownlist1_SelectedIndexChanged(sender, e);
                        txtblno.Text = Request.QueryString["aeblno"].ToString();

                        txtblno_TextChanged(sender, e);
                    }

                    if (Request.QueryString.ToString().Contains("appfibl"))
                    {
                        ddl_voutype.SelectedValue = Request.QueryString["appfibl"].ToString();
                        Dropdownlist1_SelectedIndexChanged(sender, e);
                        txtblno.Text = Request.QueryString["fiblno"].ToString();

                        txtblno_TextChanged(sender, e);
                       
                    }

                    txtex.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EX-Rate')");
                    txtrate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    /*To Be Commanded */
                    //lbl_Header.Text = "Proforma Sales Invoice";

                    //divisionid = 1;
                    //branchid = 1;
                    //Session["StrTranType"] = "FE";
                    //strTranType = "FE";
                    /*To Be Commanded */
                    txtamount.Enabled = true;
                    if (strTranType == "CH")
                    {
                        //txtblno.Attributes.Add("placeholder", "DOC#");
                        Label5.Text = "DOC #";
                        txtblno.ToolTip = "DOC Number";
                    }
                    if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice" || ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice OC")
                    {
                        type = "Profoma Purchase Invoice";
                        hf_strtype.Value = type;
                        Label33.Visible = true;
                        Label33.Text = "CreditDays";
                        txtCreditDays.Visible = true;
                        txtVendorRefno.Visible = true;
                        txtVendorRefnodate.Visible = true;
                        Label7.Visible = false;
                        txtcreditapp1.Visible = false;
                        txtto.ToolTip = "Bill From";
                        txtsupplyto.ToolTip = "Supply From";
                        //txtto.Attributes["Placeholder"] = "Bill From";
                        //txtsupplyto.Attributes["Placeholder"] = "Supply From";
                        Label11.Text = "Bill From";
                        Label12.Text = "Supply From";
                        txtVendorRefnodate1.Attributes["class"] = "VendorRef2";
                        chkmbl.Enabled = true;
                        Label8.Text = "Vendor Ref #";
                        Label9.Text = "Vendor Ref Date";

                    }
                    else if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice" || ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice OC")
                    {
                        txtto.ToolTip = "Bill To";
                        txtsupplyto.ToolTip = "Supply To";
                        //txtto.Attributes["Placeholder"] = "Bill To";

                        //txtsupplyto.Attributes["Placeholder"] = "Supply To";
                        Label11.Text = "Bill To";
                        Label12.Text = "Supply To";
                        hd_exrate.Value = "R";
                        type = "Proforma Sales Invoice";
                        ddl_voutype.SelectedItem.Text = type;
                        hf_strtype.Value = type;
                        Label33.Visible = false;
                        txtCreditDays.Visible = false;
                        txtVendorRefno.Visible = true;
                        txtVendorRefnodate.Visible = true;
                        Label7.Visible = true;
                        txtcreditapp1.Visible = true;
                        chkmbl.Enabled = true;
                        Label8.Text = "Customer Ref #";
                        Label9.Text = "customer Ref Date";
                    }
                    headerlabel.InnerText = ddl_voutype.SelectedItem.Text;

                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Yellow;
                    btndelete.Click += btndelete_Click;
                    btndelete.OnClientClick = @"return getConfirmationValue();";
                    // txtref.Focus();

                  //  UserRights();

                    if (Session["StrTranType"].ToString() == "FE")
                    {
                        homelbl.Visible = true;
                        headerlable1.InnerText = "OceanExports";
                        //if (lbl_Header.Text == "Proforma Invoice")
                        //{
                        //    menulabel.InnerText = "Accounts";
                        //}
                        //else if (lbl_Header.Text == "Proforma Purchase Invoice")
                        //{
                        menulabel.InnerText = "Accounts";
                        //}
                    }
                    else if (Session["StrTranType"].ToString() == "FI")
                    {
                        homelbl.Visible = true;
                        headerlable1.InnerText = "OceanImports";
                        //if (lbl_Header.Text == "Proforma Invoice")
                        //{
                        //    menulabel.InnerText = "Accounts";
                        //}
                        //else if (lbl_Header.Text == "Proforma Purchase Invoice")
                        //{
                        menulabel.InnerText = "Accounts";
                        //}
                    }
                    else if (Session["StrTranType"].ToString() == "AE")
                    {
                        homelbl.Visible = true;
                        headerlable1.InnerText = "AirExports";
                        //if (lbl_Header.Text == "Proforma Purchase Invoice")
                        //{
                        //    menulabel.InnerText = "Accounts";
                        //}
                        //else if (lbl_Header.Text == "Proforma Invoice")
                        //{
                        menulabel.InnerText = "Accounts";
                        //}
                    }
                    else if (Session["StrTranType"].ToString() == "AI")
                    {
                        homelbl.Visible = true;
                        headerlable1.InnerText = "AirImports";
                        //if (lbl_Header.Text == "Proforma Purchase Invoice")
                        //{
                        //    menulabel.InnerText = "Accounts";
                        //}
                        //else if (lbl_Header.Text == "Proforma Invoice")
                        //{
                        menulabel.InnerText = "Accounts";
                        //}
                    }
                    else if (Session["StrTranType"].ToString() == "CH")
                    {
                        headerlable1.InnerText = "Custom House Agent";

                        /* if (lbl_Header.Text == "Proforma Purchase Invoice")
                         {
                             menulabel.InnerText = "Accounts";
                             txtVendorRef.Attributes["class"] = "VendorRef1";
                         }
                         else if (lbl_Header.Text == "Proforma Sales Invoice")
                         {
                             txtcredit.Attributes["class"] = "VendorRefN1";
                             menulabel.InnerText = "Accounts";
                       
                       
                         }
                         else if(lbl_Header.Text == "Proforma Sales Invoice" && txtblno.ToolTip == "DOC Number")
                         {
                             txtcredit.Attributes["class"] = "VendorRefN2";
                             txtVendorRef.Attributes["class"] = "VendorRef2";
                             txtCreditDays1.Attributes["class"] = "CreditDays1";
                             menulabel.InnerText = "Utility";

                         }*/
                        if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                        {
                            menulabel.InnerText = "Accounts";
                            txtVendorRef.Attributes["class"] = "VendorRef1";
                            chkmbl.Enabled = true;
                        }
                        else if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                        {

                            txtcredit.Attributes["class"] = "VendorRefN1";
                            if (Request.QueryString["type"].ToString() == "Proforma Invoice")
                            {
                                menulabel.InnerText = "Accounts";
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

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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
        protected void ddl_product_SelectedIndexChanged(object sender, EventArgs e)
        {

            FillOnPageLoad();

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
        }
        protected void UserRights()
        {
            if (Request.QueryString.ToString().Contains("type"))
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
                if (Request.QueryString.ToString().Contains("uiid"))
                {
                    str_FornName = Request.QueryString["type"].ToString();
                    str_Uiid = Request.QueryString["uiid"].ToString();
                    hid_uiid.Value = str_Uiid;
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
                    //DataTable dtr;
                    //dtr = (DataTable)Session["dt_UserRights"];
                    //if (dtr.Rows.Count>0)
                    //{
                    //    ddl_voutype.Items.Clear();
                    //    ddl_voutype.Items.Add("");
                    //    for (int i=0;i<dtr.Rows.Count;i++)
                    //    {
                    //        if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Invoice")
                    //        {
                    //            ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice", "1"));
                              
                    //        }
                    //        if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Purchase Invoice")
                    //        {
                    //            ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice","2"));
                              
                    //        }

                    //        if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Sales Invoice OC")
                    //        {
                    //            ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice OC", "22"));
                    //        }
                    //        if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Purchase Invoice OC")
                    //        {
                    //            ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice OC", "23"));
                                
                    //        }

                    //    }
                        //if(ddl_voutype.Items.Count == 1) 
                        //{
                           
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(btn_uploadpopup, typeof(Button), "logix", "alert('You have no Rights for Proforma Creation');", true);
                        //    return;
                        //}
                        
                   // }
                }
                //else
                //{
                //    ddl_voutype.Items.Clear();
                //    ddl_voutype.Items.Add("");
                //    ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice", "1"));
                //    ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice", "2"));
                //    ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice OC", "22"));
                //    ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice OC", "23"));

                //}
                //  btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


            }
        }

        protected void UserRights4process()
        {
            
                
                
                     
                    DataTable obj_Dtuser = new DataTable();
                    obj_Dtuser = (DataTable)Session["dt_UserRights"];
                    
                    DataTable dtr;
                    dtr = (DataTable)Session["dt_UserRights"];
                    if (dtr.Rows.Count > 0)
                    {
                        ddl_voutype.Items.Clear();
                        ddl_voutype.Items.Add("");
                        for (int i = 0; i < dtr.Rows.Count; i++)
                        {
                            if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Invoice" || dtr.Rows[i]["uicaption"].ToString() == "Proforma Invoices After Job closing")
                            {
                                ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice", "1"));

                            }
                            if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Purchase Invoice" ||dtr.Rows[i]["uicaption"].ToString() == "Profoma Purchase Invoice After Job closing")
                            {
                                ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice", "2"));

                            }

                            if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Sales Invoice OC" || dtr.Rows[i]["uicaption"].ToString() == "Proforma Sales Invoices OC After Job closing")
                    {
                                ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice OC", "22"));
                            }
                            if (dtr.Rows[i]["uicaption"].ToString() == "Proforma Purchase Invoice OC" || dtr.Rows[i]["uicaption"].ToString() == "Proforma Purchase Invoices OC After Job closing")
                            {
                                ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice OC", "23"));

                            }

                        }
                        
                    }
                //}
                //else
                //{
                //    ddl_voutype.Items.Clear();
                //    ddl_voutype.Items.Add("");
                //    ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice", "1"));
                //    ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice", "2"));
                //    ddl_voutype.Items.Add(new ListItem("Proforma Sales Invoice OC", "22"));
                //    ddl_voutype.Items.Add(new ListItem("Proforma Purchase Invoice OC", "23"));

                //}
                //  btn_delete = Boolean.Parse(obj_Dtuser.Rows[0]["btndelete"].ToString());


            
        }

        [WebMethod]
        public static List<string> GetBLno(string prefix)
        {

            DataAccess.ForwardingExports.StuffingConfirmation obj_da_sc = new DataAccess.ForwardingExports.StuffingConfirmation();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            obj_da_sc.GetDataBase(Ccode);
            string strTranType = HttpContext.Current.Session["StrTranType"].ToString();
            string strTranTypeFA = HttpContext.Current.Session["StrTranTypeFA"].ToString();
            DataTable objDt = new DataTable();
            string str_bl = "";
            if (strTranType == "AC")
            {
                if (strTranTypeFA == "FE" || strTranTypeFA == "FI")
                {
                    if (strTranTypeFA == "FE")
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.ForwardingExports.BLDetails obj_da_bldet = new DataAccess.ForwardingExports.BLDetails();
                            obj_da_bldet.GetDataBase(Ccode);
                            objDt = obj_da_bldet.GetLikeBLDetailsnew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "blno";
                        }
                        else
                        {
                            DataAccess.ForwardingExports.JobInfo obj_da_jinfo = new DataAccess.ForwardingExports.JobInfo();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetFEJobInfoMBLWOClosedJobnew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mblno";
                        }
                    }
                    else
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.ForwardingImports.BLDetails obj_da_jinfo = new DataAccess.ForwardingImports.BLDetails();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetLikeIBL(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "blno";
                        }
                        else
                        {
                            DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetLikeMBLNoWOClosedJobnew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mblno";
                        }
                    }
                }
                else if (strTranTypeFA == "AE" || strTranTypeFA == "AI")
                {
                    if (strTranTypeFA == "AE")
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.AirImportExports.AIEBLDetails obj_da_aibldet = new DataAccess.AirImportExports.AIEBLDetails();
                            obj_da_aibldet.GetDataBase(Ccode);
                            objDt = obj_da_aibldet.GetLikeAIEBLDetailsnew(prefix.ToUpper(), "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "hawblno";
                        }
                        else
                        {
                            DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                            obj_da_aijinfo.GetDataBase(Ccode);
                            objDt = obj_da_aijinfo.GetLikeAIEJobMBLNonew(prefix.ToUpper(), "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mawblno";
                        }
                    }
                    else
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.AirImportExports.AIEBLDetails obj_da_aibldet = new DataAccess.AirImportExports.AIEBLDetails();
                            obj_da_aibldet.GetDataBase(Ccode);
                            objDt = obj_da_aibldet.GetLikeAIEBLDetailsnew(prefix.ToUpper(), "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "hawblno";
                        }
                        else
                        {
                            DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                            obj_da_aijinfo.GetDataBase(Ccode);
                            objDt = obj_da_aijinfo.GetLikeAIEJobMBLNonew(prefix.ToUpper(), "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mawblno";
                        }
                    }
                }
                else if (strTranTypeFA == "CH")
                {
                    DataAccess.CustomHousingAgent.JobInfo obj_da_jinfo = new DataAccess.CustomHousingAgent.JobInfo();
                    obj_da_jinfo.GetDataBase(Ccode);
                    objDt = obj_da_jinfo.GetLikeDocnonew(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                    str_bl = "docno";
                }
                else if (strTranTypeFA == "BT")
                {
                    DataAccess.BondedTrucking.BTJobInfo obj_da_jinfo = new DataAccess.BondedTrucking.BTJobInfo();
                    obj_da_jinfo.GetDataBase(Ccode);
                    objDt = obj_da_jinfo.GetLikeBTSBNoAfterJobclose(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                    str_bl = "sbno";
                }
            }
            else
            {
                if (strTranTypeFA == "FE" || strTranTypeFA == "FI")
                {
                    if (strTranTypeFA == "FE")
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.ForwardingExports.BLDetails obj_da_bldet = new DataAccess.ForwardingExports.BLDetails();
                            obj_da_bldet.GetDataBase(Ccode);
                            objDt = obj_da_bldet.GetLikeBLDetails(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "blno";
                        }
                        else
                        {
                            DataAccess.ForwardingExports.JobInfo obj_da_jinfo = new DataAccess.ForwardingExports.JobInfo();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetFEJobInfoMBLWOClosedJob(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mblno";
                        }
                    }
                    else
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.ForwardingImports.BLDetails obj_da_jinfo = new DataAccess.ForwardingImports.BLDetails();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetLikeIBL(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "blno";
                        }
                        else
                        {
                            DataAccess.ForwardingImports.JobInfo obj_da_jinfo = new DataAccess.ForwardingImports.JobInfo();
                            obj_da_jinfo.GetDataBase(Ccode);
                            objDt = obj_da_jinfo.GetLikeMBLNoWOClosedJob(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mblno";
                        }
                    }
                }
                else if (strTranTypeFA == "AE" || strTranTypeFA == "AI")
                {
                    if (strTranTypeFA == "AE")
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.AirImportExports.AIEBLDetails obj_da_aibldet = new DataAccess.AirImportExports.AIEBLDetails();
                            obj_da_aibldet.GetDataBase(Ccode);
                            objDt = obj_da_aibldet.GetLikeAIEBLDetails(prefix.ToUpper(), "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "hawblno";
                        }
                        else
                        {
                            DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                            obj_da_aijinfo.GetDataBase(Ccode);
                            objDt = obj_da_aijinfo.GetLikeAIEJobMBLNo(prefix.ToUpper(), "AE", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mawblno";
                        }
                    }
                    else
                    {
                        if (HttpContext.Current.Session["mblchk"].ToString() == "false")
                        {
                            DataAccess.AirImportExports.AIEBLDetails obj_da_aibldet = new DataAccess.AirImportExports.AIEBLDetails();
                            obj_da_aibldet.GetDataBase(Ccode);
                            objDt = obj_da_aibldet.GetLikeAIEBLDetails(prefix.ToUpper(), "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "hawblno";
                        }
                        else
                        {
                            DataAccess.AirImportExports.AIEJobInfo obj_da_aijinfo = new DataAccess.AirImportExports.AIEJobInfo();
                            obj_da_aijinfo.GetDataBase(Ccode);
                            objDt = obj_da_aijinfo.GetLikeAIEJobMBLNo(prefix.ToUpper(), "AI", Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                            str_bl = "mawblno";
                        }
                    }
                }

                else
                {
                    DataAccess.CustomHousingAgent.JobInfo obj_da_jinfo = new DataAccess.CustomHousingAgent.JobInfo();
                    obj_da_jinfo.GetDataBase(Ccode);
                    objDt = obj_da_jinfo.GetLikeDocno(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()), Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                    str_bl = "docno";
                }

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
            List<string> custname = new List<string>();

            string a = HttpContext.Current.Session["cmbbill"].ToString();
            if (HttpContext.Current.Session["ddltype"].ToString() == "Proforma Sales Invoice OC" && HttpContext.Current.Session["ddltype"].ToString() == "Proforma Purchase Invoice OC")
            {
                if (HttpContext.Current.Session["cmbbill"].ToString() == "Internal")
                {

                    Dt = customerobj.GetLikeCustomerproformaFC(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    Dt = customerobj.GetLikeIndianCustomerFC(prefix);

                }
            }
            else
            {
                if (HttpContext.Current.Session["cmbbill"].ToString() == "Internal")
                {

                    Dt = customerobj.GetLikeCustomerproforma(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString()));
                }
                else
                {
                    Dt = customerobj.GetLikeIndianCustomer(prefix);

                }
            }
            custname = Utility.Fn_TableToList_Cust1(Dt, "customer", "customerid", "address");
            return custname;
        }

        [WebMethod]
        public static List<string> GetCharges(string prefix)
        {
            List<string> List_Result = new List<string>();
            DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chargeobj.GetDataBase(Ccode);
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
            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            chargeobj.GetDataBase(Ccode);
            DataTable dtCharge = new DataTable();
            dtCharge = chargeobj.GetLikeCurrency(prefix);
            List_Result = Utility.Fn_TableToList(dtCharge, "currency", "currency");
            return List_Result;
        }




        public void FillOnPageLoad()
        {
            try
            {
                strTranType = ddl_product.SelectedValue.ToString();
                Session["StrTranTypeFA"] = strTranType;
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
                cmbbase.Items.Clear();
                //  strTranType = Session["StrTranType"].ToString();
                if (strTranType == "FE" || strTranType == "FI")
                {
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("BL");
                    cmbbase.Items.Add("CBM");
                    cmbbase.Items.Add("MT");
                    cmbbase.Items.Add("W/M");
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

                    //Label8.Text = "Job Details";
                    //Label12.Text = "AirLine";
                    //Label14.Text = "Agent";
                    //Label16.Text = "Notify Party 2";
                    //txtvessel.Attributes.Add("placeholder", "Job Details");


                    //txtagent.Attributes.Add("placeholder", "AirLine");
                    // txtmlo.Attributes.Add("placeholder", "Agent");
                    //txtcnf.Attributes.Add("placeholder", "Notify Party 2");

                    lblAgent.Text = "AirLine";
                    //  lblvessel.Text = "Vsl and Voy";
                    lblmlo.Text = "Agent";
                    lblcnf1.Text = "Notify Party 2";

                    txtagent.ToolTip = "AirLine";
                    txtmlo.ToolTip = "Agent";
                    txtcnf.ToolTip = "Notify Party 2";
                }
                else if (strTranType == "CH")
                {

                    chkmbl.Visible = true;
                    chkmbl.Enabled = true;
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("DOC");
                    cmbbase.Items.Add("Kgs");
                    cmbbase.Items.Add("Volume");
                }
                else
                {
                    chkmbl.Visible = true;
                    cmbbase.Items.Add("");
                    cmbbase.Items.Add("DOC");
                    cmbbase.Items.Add("Kgs");
                    cmbbase.Items.Add("Volume");
                    //Label8.Text = "Vsl and Voy";
                    //Label12.Text = "Principal";
                    //Label13.Text = "Customer";
                    //Label16.Enabled = false;


                    /*txtvessel.Attributes.Add("placeholder", "Vsl and Voy");
                    txtagent.Attributes.Add("placeholder", "Principal");
                    txtmlo.Attributes.Add("placeholder", "Customer");
                    txtcnf.Attributes.Add("placeholder", "CNF");
                    */

                    lblAgent.Text = "Principal";
                    lblvessel.Text = "Vsl and Voy";
                    lblmlo.Text = "Customer";
                    lblcnf1.Text = "CNF";


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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);

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

        protected void btn_uploadpopup_Click(object sender, EventArgs e)
        {
            if (txtref.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_uploadpopup, typeof(Button), "Checklist", "alert('Kindly Enter the Reference # ');", true);
                txtref.Focus();
                return;
            }

            string a = "";
            hf_updoc.Value = "Y";
            a = hf_updoc.Value.ToString();
            iframe_outstd.Attributes["src"] = "../ShipmentDetails/UploadDocument.aspx?&updoc=" + hf_updoc.Value;
            this.popup_uploaddoc.Show();

            Session["txtjobno"] = txtjobno.Value;
            Session["hf_txtrefno"] = txtref.Text;
            Session["vouno"] = null;
        }

        public void getFEI()
        {
            try
            {
                useit();
                if (ddl_product.SelectedValue == "FE")
                {
                    txtblno.Text = txtblno.Text.ToUpper();

                    if (chkmbl.Checked == true)
                    {
                        lstvol.Items.Clear();
                        txtjobno.Value = FEJobobj.GetJobNo(txtblno.Text.ToUpper(), branchid, divisionid).ToString();
                        DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Value), txtjobno.Value, ddl_product.SelectedValue, branchid);
                        if (DtConDetails.Rows.Count > 0)
                        {
                            for (int i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                            {
                                lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                                cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
                            }
                            Session["DtConDetails"] = DtConDetails;
                        }
                        //lstcon.Items.Clear();
                        //DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
                        //if (DtCon.Rows.Count > 0)
                        //{
                        //    for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
                        //    {
                        //        lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
                        //        cmbbase.Items.Add(DtCon.Rows[i][1].ToString());
                        //    }
                        //}

                        DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Value), branchid, divisionid);
                        if (DtCon.Rows.Count > 0)
                        {
                            vessel = DtCon.Rows[0][3].ToString();
                            voyage = DtCon.Rows[0][7].ToString();
                            eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString());
                            hid_mloid.Value = DtCon.Rows[0]["mloid"].ToString();
                            txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
                            lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();

                            txtmlo.Text = DtCon.Rows[0][6].ToString();

                            txtagent.Text = DtCon.Rows[0][5].ToString();
                            agent = DtCon.Rows[0][14].ToString();
                            txtdes.Text = DtCon.Rows[0][4].ToString();
                            jobtype = DtCon.Rows[0][13].ToString();
                        }
                        lstcon.Items.Clear();
                        DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtjobno.Value, ddl_product.SelectedValue, branchid);
                        if (DtCon.Rows.Count > 0)
                        {
                            lstcon.Items.Add(lbljobDtls.Text);
                            for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
                                cmbbase.Items.Add(DtCon.Rows[i][1].ToString());
                            }
                        }

                        string AllDetails = "Shipper " + System.Environment.NewLine + txtshipper.Text + System.Environment.NewLine + "Consignee " + System.Environment.NewLine + txtconsignee.Text + System.Environment.NewLine + "Notify Party " + System.Environment.NewLine + txtnotify.Text + System.Environment.NewLine + "Agent " + System.Environment.NewLine + txtagent.Text + System.Environment.NewLine + "MLO " + System.Environment.NewLine + txtmlo.Text + System.Environment.NewLine + "C & F  " + System.Environment.NewLine + txtcnf.Text;
                        txtAllDetails.Text = AllDetails;

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
                                lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();
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

                            //  string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
                            string AllDetails = "Shipper " + System.Environment.NewLine + txtshipper.Text + System.Environment.NewLine + "Consignee " + System.Environment.NewLine + txtconsignee.Text + System.Environment.NewLine + "Notify Party " + System.Environment.NewLine + txtnotify.Text + System.Environment.NewLine + "Agent " + System.Environment.NewLine + txtagent.Text + System.Environment.NewLine + "MLO " + System.Environment.NewLine + txtmlo.Text + System.Environment.NewLine + "C & F  " + System.Environment.NewLine + txtcnf.Text;

                            txtAllDetails.Text = AllDetails;

                            DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, ddl_product.SelectedValue, branchid);
                            if (DtConDetails.Rows.Count > 0)
                            {
                                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                                    cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
                                }
                                Session["DtConDetails"] = DtConDetails;
                                volume = DtConDetails.Rows[0][1].ToString();
                                lstvol.Items.Add(volume + " cbm");
                                wt = DtConDetails.Rows[0][2].ToString();
                                lstvol.Items.Add(wt + " Kgs");
                            }
                            lstcon.Items.Clear();
                            DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, ddl_product.SelectedValue, branchid);
                            if (DtInfo.Rows.Count > 0)
                            {
                                lstcon.Items.Add(lbljobDtls.Text);
                                for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
                                {
                                    lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
                                    cmbbase.Items.Add(DtInfo.Rows[i][1].ToString());
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
                        DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text, ddl_product.SelectedValue, branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            txtjobno.Value = DtInfo.Rows[0][0].ToString();
                            vessel = DtInfo.Rows[0][3].ToString();
                            voyage = DtInfo.Rows[0][2].ToString();
                            eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                            txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
                            lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();

                            txtmlo.Text = DtInfo.Rows[0][6].ToString();
                            agent = DtInfo.Rows[0][7].ToString();
                            jobtype = DtInfo.Rows[0][8].ToString();
                            txtagent.Text = DtInfo.Rows[0][5].ToString();
                            txtdes.Text = DtInfo.Rows[0][4].ToString();
                            DtCon = INVOICEobj.GetFIMblNContainers(txtjobno.Value, branchid);
                            if (DtCon.Rows.Count > 0)
                            {
                                lstcon.Items.Add(lbljobDtls.Text);

                                for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                                {
                                    lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());
                                    cmbbase.Items.Add(DtCon.Rows[i][0].ToString());

                                }
                            }
                            DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Value), txtjobno.Value, ddl_product.SelectedValue, branchid);
                            if (DtConDetails.Rows.Count > 0)
                            {
                                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                                {
                                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                                    cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
                                }
                            }

                        }
                    }
                    else
                    {
                        lstvol.Items.Clear();
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text, ddl_product.SelectedValue, branchid);
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
                            lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();

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
                        // string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
                        string AllDetails = "Shipper " + System.Environment.NewLine + txtshipper.Text + System.Environment.NewLine + "Consignee " + System.Environment.NewLine + txtconsignee.Text + System.Environment.NewLine + "Notify Party " + System.Environment.NewLine + txtnotify.Text + System.Environment.NewLine + "Agent " + System.Environment.NewLine + txtagent.Text + System.Environment.NewLine + "MLO " + System.Environment.NewLine + txtmlo.Text + System.Environment.NewLine + "C & F  " + System.Environment.NewLine + txtcnf.Text;

                        txtAllDetails.Text = AllDetails;

                    }


                    DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, ddl_product.SelectedValue, branchid);
                    if (DtConDetails.Rows.Count > 0)
                    {
                        for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                        {
                            lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                            cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
                        }
                        Session["DtConDetails"] = DtConDetails;
                        volume = INVOICEobj.GetVolume(txtblno.Text, ddl_product.SelectedValue, branchid).ToString();
                        lstvol.Items.Add(volume + " cbm");
                        wt = INVOICEobj.GetWeight(txtblno.Text, ddl_product.SelectedValue, branchid).ToString();
                        lstvol.Items.Add(wt + " Kgs");
                        lstcon.Items.Clear();
                        DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, ddl_product.SelectedValue, branchid);
                        if (DtInfo.Rows.Count > 0)
                        {
                            lstcon.Items.Add(lbljobDtls.Text);

                            for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
                            {
                                lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
                                cmbbase.Items.Add(DtInfo.Rows[i][1].ToString());
                            }
                        }

                    }
                }
                disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);

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
                    if (ddl_product.SelectedValue == "AE")
                    {
                        DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text.ToUpper(), ddl_product.SelectedValue, branchid);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetMblInvoiceHead(txtblno.Text.ToUpper(), ddl_product.SelectedValue, branchid);
                    }
                    if (DtInfo.Rows.Count > 0)
                    {
                        txtjobno.Value = DtInfo.Rows[0][0].ToString();
                        eta = Convert.ToDateTime(DtInfo.Rows[0][1].ToString());
                        txtvessel.Text = txtjobno.Value + "/" + DtInfo.Rows[0][2].ToString() + "/" + eta.ToShortDateString();
                        lbljobDtls.Text = txtjobno.Value + " / " + DtInfo.Rows[0][2].ToString() + " / " + eta.ToShortDateString();
                        txtmlo.Text = DtInfo.Rows[0][5].ToString();
                        txtagent.Text = DtInfo.Rows[0][4].ToString();
                        agent = DtInfo.Rows[0][6].ToString();
                        txtdes.Text = DtInfo.Rows[0][3].ToString();
                        gross = DtInfo.Rows[0][7].ToString();
                        chwt = DtInfo.Rows[0][8].ToString();
                    }
                    // string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
                    string AllDetails = "Shipper " + System.Environment.NewLine + txtshipper.Text + System.Environment.NewLine + "Consignee " + System.Environment.NewLine + txtconsignee.Text + System.Environment.NewLine + "Notify Party " + System.Environment.NewLine + txtnotify.Text + System.Environment.NewLine + "Agent " + System.Environment.NewLine + txtagent.Text + System.Environment.NewLine + "MLO " + System.Environment.NewLine + txtmlo.Text + System.Environment.NewLine + "C & F  " + System.Environment.NewLine + txtcnf.Text;

                    txtAllDetails.Text = AllDetails;

                }
                else
                {
                    lstvol.Items.Clear();
                    if (ddl_product.SelectedValue == "AE")
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), ddl_product.SelectedValue, branchid);
                    }
                    else
                    {
                        DtInfo = INVOICEobj.GetHblInvoiceHead(txtblno.Text.ToUpper(), ddl_product.SelectedValue, branchid);
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
                        lbljobDtls.Text = txtjobno.Value + " / " + DtInfo.Rows[0][2].ToString() + " / " + eta.ToShortDateString();
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
                    // string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
                    string AllDetails = "Shipper " + System.Environment.NewLine + txtshipper.Text + System.Environment.NewLine + "Consignee " + System.Environment.NewLine + txtconsignee.Text + System.Environment.NewLine + "Notify Party " + System.Environment.NewLine + txtnotify.Text + System.Environment.NewLine + "Agent " + System.Environment.NewLine + txtagent.Text + System.Environment.NewLine + "MLO " + System.Environment.NewLine + txtmlo.Text + System.Environment.NewLine + "C & F  " + System.Environment.NewLine + txtcnf.Text;

                    txtAllDetails.Text = AllDetails;

                }
                disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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
                    lbljobDtls.Text = txtjobno.Value + " / " + Dt.Rows[0][2].ToString() + " / " + eta.ToShortDateString();
                    txtmlo.Text = Dt.Rows[0][8].ToString();
                    txtagent.Text = Dt.Rows[0][7].ToString();
                    agent = Dt.Rows[0][9].ToString();
                    txtdes.Text = Dt.Rows[0][6].ToString();
                    jobtype = Dt.Rows[0][10].ToString();
                    jobtype = "0";

                }
                //string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
                string AllDetails = "Shipper " + System.Environment.NewLine + txtshipper.Text + System.Environment.NewLine + "Consignee " + System.Environment.NewLine + txtconsignee.Text + System.Environment.NewLine + "Notify Party " + System.Environment.NewLine + txtnotify.Text + System.Environment.NewLine + "Agent " + System.Environment.NewLine + txtagent.Text + System.Environment.NewLine + "MLO " + System.Environment.NewLine + txtmlo.Text + System.Environment.NewLine + "C & F  " + System.Environment.NewLine + txtcnf.Text;

                txtAllDetails.Text = AllDetails;

                disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtblno.Text = "";
                    return;
                }
                DataTable dtsupply = new DataTable();
                //DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
                DataAccess.ForwardingExports.BLDetails obj_da_FEBL = new DataAccess.ForwardingExports.BLDetails();
                //DataAccess.ForwardingImports.BLDetails obj_da_BL = new DataAccess.ForwardingImports.BLDetails();
                DataTable obj_dt = new DataTable();
                string str_booking = "";
                string str_BL = "";

                string Ccode = HttpContext.Current.Session["Ccode"].ToString();
                obj_da_FEBL.GetDataBase(Ccode);


                string tran = ddl_product.SelectedValue;
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


                     }*/

                    if (tran == "FE" || tran == "FI")
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
                    else if (tran == "AE" || tran == "AI")
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
                    if ((INVOICEobj.CheckClosedJobs(tran, Convert.ToInt32(txtjobno.Value), branchid)) == 0 && Session["StrTranType"].ToString() == "AC")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job # " + txtjobno.Value + " is still Open...kindly create the Voucher from Ops and Docs Screen');", true);
                        txtclear();
                        return;

                    }
                    if ((INVOICEobj.CheckClosedJobs(tran, Convert.ToInt32(txtjobno.Value), branchid)) == 1 && Session["StrTranType"].ToString() != "AC")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job # " + txtjobno.Value + " is Closed...Cannot create vouchers in this Screen');", true);
                        txtclear();
                        return;

                    }
                    if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice" || ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice OC")
                    {

                        if (tran != null)
                        {
                          //  DataAccess.Accounts.Invoice obj_inv = new DataAccess.Accounts.Invoice();
                            DataTable dtref = obj_inv.Getcusrefnofromquot4rpt(Convert.ToInt32(Session["LoginBranchId"].ToString()), tran, txtblno.Text, "Profoma");
                            if (dtref.Rows.Count > 0)
                            {
                                txtVendorRefno.Text = dtref.Rows[0]["cuspono"].ToString().ToUpper();
                            }
                            obj_dt = obj_da_BL.ShowBLDetails(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            if (obj_dt.Rows.Count > 0)
                            {
                                str_BL = obj_dt.Rows[0]["splitbl"].ToString();

                            }
                            str_booking = obj_da_FIBL.GetBookinkNo(txtblno.Text, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            if (str_booking == "0" && tran == "FI")
                            {
                                str_booking = obj_da_FIBL.GetBookinkNo(str_BL, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                            }

                            if (str_booking != "0")
                            {
                                dtsupply = obj_da_FEBL.GetBookingDt(str_booking, Convert.ToInt32(Session["LoginBranchId"].ToString()), Convert.ToInt32(Session["LoginDivisionId"].ToString()));
                                if (dtsupply.Rows.Count > 0)
                                {
                                    hid_SupplyTo.Value = dtsupply.Rows[0]["customerid"].ToString();
                                    hdncustid.Value = hid_SupplyTo.Value;
                                    if (hid_SupplyTo.Value != "")
                                    {
                                        txtsupplyto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                                        txtto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hdncustid.Value ));
                                        string citysupplyid ;
                                        if (txtsupplyto.Text != "")
                                        {
                                            
                                            citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                                            txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                                            txtaddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                hid_SupplyTo.Value = hid_cosigneeid.Value;
                                hdncustid.Value = hid_SupplyTo.Value;
                                if (hid_SupplyTo.Value != "")
                                {
                                    txtsupplyto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                                    txtto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hdncustid.Value));
                                    string citysupplyid;
                                    if (txtsupplyto.Text != "")
                                    {

                                        citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                                        txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                                        txtaddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
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
                            hdncustid.Value = hid_SupplyTo.Value;
                            if (hid_SupplyTo.Value != "")
                            {
                                txtsupplyto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hid_SupplyTo.Value));
                                txtto.Text = obj_da_mc.GetCustomername(Convert.ToInt32(hdncustid.Value));
                                string citysupplyid;
                                if (txtsupplyto.Text != "")
                                {

                                    citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                                    txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                                    txtaddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                                }
                            }
                        }
                    }


                    btncancel.Text = "Cancel";

                    btncancel.ToolTip = "Cancel";
                    btncancel1.Attributes["class"] = "btn ico-cancel";

                    if (txtblno.Text.Trim().ToUpper() != "")
                    {
                        if (txtjobno.Value == "0" || txtjobno.Value == "")
                        {

                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Invalid BL #');", true);
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
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Select Voucher type..');", true);
                    return;
                }
                UserRights();
              //  UserRights4process();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
            btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
        }

        public void txtclear()
        {
            cmbbill.SelectedIndex = 0;
            txtblno.Text = "";
            txtjobno.Value = "0";
            txtto.Text = "";
            txtref.Text = "";
            txtvessel.Text = "";
            txtdes.Text = "";
            txtshipper.Text = "";
            txtAllDetails.Text = "";
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
            if (Session["Strtrantype"].ToString() == "AC")
            {
                ddl_product.SelectedValue = "0";
            }

            hid_SupplyTo.Value = "0";
            hid_SupplyToadd.Value = "0";
            btnsave.Enabled = true;
            btnsave.ForeColor = System.Drawing.Color.White;
            btnview.Enabled = true;
            btnview.ForeColor = System.Drawing.Color.White;
            UserRights();
            UserRights4process();
        }


        public void txtclear4refno()
        {
            cmbbill.SelectedIndex = -1;
            txtblno.Text = "";
            txtjobno.Value = "0";
            txtto.Text = "";
            txtAllDetails.Text = "";
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
            // btnadd.Text = "Add";
            btnsave.ToolTip = "Save";
            btnsave1.Attributes["class"] = "btn ico-save";
            btnadd.ToolTip = "Add";
            btnadd1.Attributes["class"] = "btn ico-add";
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
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter the  BL Number');", true);
                txtblno.Focus();
                blnerr = true;
                return;
            }

            if (txtto.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Customer Name cannot be blank');", true);

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
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Customer cannot be blank');", true);

                    txtto.Focus();
                    blnerr = true;
                    return;
                }

                if (hid_SupplyTo.Value == "0")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('SupplyTo Customer cannot be blank');", true);

                    txtsupplyto.Focus();
                    blnerr = true;
                    return;
                }
            }
            //Bhuvana
            if (cmbbill.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Bill type cannot be blank');", true);

                cmbbill.Focus();
                blnerr = true;
                return;
            }

            if (chkmbl.Checked == true)
            {
                if (cmbbill.Text == "Profit Share")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Profit Share should not be Used for MBL#');", true);

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
                strTranType = ddl_product.SelectedValue;
                // frmname = Request.QueryString["type"].ToString();
                branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
                divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
               // DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
                DataTable DtDetails = new DataTable();
                string bookingno;
                int intcustomerid4DO;

                if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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
                string str_TranType = Session["StrTranType"].ToString();
                int int_custid = Convert.ToInt32(hdncustid.Value);
                string sezcus = "";
              //  DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();

                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Select Voucher Type');", true);
                    ddl_voutype.Focus();
                    return;
                }



                if (txtto.Text != "")
                {
                    int_custid = Convert.ToInt32(hdncustid.Value);
                    DataTable dt_list = new DataTable();
                    txtsupplyto.Text = txtto.Text;
                    hid_SupplyTo.Value = hdncustid.Value;
                    dtnew = cus.getcustomerblk(int_custid);
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('This customer " + txtto.Text + " status is Hold please discuss with Finance team ');", true);
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
                         ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alert('Select Correct Customer Name');", true);
                         txtto.Text = "";
                         txtto.Focus();
                         return;
                     }*/

                    if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                    {
                        sezcus = customerobj.getsezcustid(int_custid);
                        if (sezcus == "Y")
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  Once again update the chargedetails because this sez customer');", true);
                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                }
                            }
                        }

                    }

                  //  DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
                    int countryid = obj_UP.Get_countrycode(Session["LoginBranchName"].ToString());

                    if (int_custid != 0 && (countryid == 1102 || countryid == 102))
                    //if (int_custid != 0)
                    {
                        //if (lbl_Header.Text != "Proforma Purchase Invoice")
                        //{
                        dt_list = customerobj.GetIndianCustomergst(int_custid);
                        if (dt_list.Rows.Count > 0)
                        {
                            if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    txtaddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                    ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('please  update  Uinno#  Master Customer);", true);
                                }
                                else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                {
                                    txtaddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                    ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('please  update Gstin# Master Customer');", true);
                                }
                                else if (dt_list.Rows[0]["UnRegistered"].ToString() == "N" && !string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()) && !string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  OR  Select UnRegistered  Master Customer');", true);
                                }


                                //ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            }
                            else
                            {
                                txtaddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            return;
                        }

                        //}
                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('Customer name or Bill from  cannot be Blank')", true);
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
                  //  DataAccess.Accounts.ProfomaInvoice obj_da_head = new DataAccess.Accounts.ProfomaInvoice();


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
                            btnsave1.Attributes["class"] = "btn ico-save";
                        }
                    }

                    else
                    {
                        if (int_custid != 0)
                        {
                          //  DataAccess.Corporate obj_da_corpobj = new DataAccess.Corporate();
                            if (obj_da_corpobj.GetGroupID(int_custid, int_divisionid) != 0)
                            {
                                if (obj_da_mc.CheckCreditAmount(int_custid, int_branchid, int_divisionid) > 0)
                                {
                                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alert('" + obj_da_mc.GetCustomername(int_custid) + " has already reached the credit limit rupees " + obj_da_mc.GetCreditAmount(int_custid, int_divisionid) + "');", true);
                                }
                            }
                        }

                        grd.DataSource = Utility.Fn_GetEmptyDataTable();
                        grd.DataBind();
                        txtref.Text = "";
                        txtremarks.Text = "";
                    }
                }
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (btncancel.ToolTip == "Cancel")
                {
                    Amendexrate.Visible = false;

                    lbl_appr.Visible = false;
                    lbl_txt.Visible = false;
                    if (Session["LoginDivisionId"] != null)
                    {
                        divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    }
                    if (Session["LoginBranchid"] != null)
                    {
                        branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    }
                    if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                    {
                        Label8.Text = "Vendor Ref #";
                        Label9.Text = "Vendor Ref Date";
                    }
                    else
                    {
                        Label8.Text = "Customer Ref #";
                        Label9.Text = "customer Ref Date";
                    }
                    txtclear();
                    txtEnable();
                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Gray;
                    btnsave.Text = "Save";

                    btnsave.ToolTip = "Save";
                    btnsave1.Attributes["class"] = "btn ico-save";
                    btnsave.Text = "Save";
                    btncancel.Text = "Back";

                    btncancel.ToolTip = "Back";
                    btncancel1.Attributes["class"] = "btn ico-back";
                    txtblno.Focus();
                    // btnadd.Text = "Add";


                    btnadd.ToolTip = "Add";
                    btnadd1.Attributes["class"] = "btn ico-add";



                    txtcharge.Enabled = true;
                    txtTotal.Text = "";
                    grd.Enabled = true;


                    txtVendorRefno.Text = "";
                    txtVendorRefnodate.Text = "";
                    txtCreditDays.Text = "";
                    hdnfatransfer.Value = "0";
                    ddl_voutype.SelectedValue = "0";

                    txtsupplyto.Text = "";


                    dtdate.Text = Logobj.GetDate().ToShortDateString();
                    dtdate.Text = Utility.fn_ConvertDate(dtdate.Text);

                    //FillOnPageLoad();
                    dt = new DataTable();
                    ShowNoResultFound(dt, grd);
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





                    if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                    {
                        chkmbl.Enabled = true;

                    }

                    else if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                    {
                        chkmbl.Enabled = true;
                    }

                }
                else
                {

                    if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                    {
                        chkmbl.Enabled = true;

                    }

                    else if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                    {
                        chkmbl.Enabled = true;
                    }

                    //this.Response.End();
                    if (Session["StrTranType"] != null)
                    {
                        if (Session["home"] != null)
                        {
                            if (Session["home"].ToString() == "OPS&DOC")
                            {
                                if (Session["StrTranType"].ToString() == "FE")
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
                                else if (Session["StrTranType"].ToString() == "FI")
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
                                else if (Session["StrTranType"].ToString() == "AE")
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
                                else if (Session["StrTranType"].ToString() == "AI")
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }


        }

        protected void btnsave_Click(object sender, EventArgs e)
        {


            int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            DataTable dtacc = new DataTable();
            string sezcus = "";
            useit();
            Session["LoginEmpId"] = Session["LoginEmpId"].ToString();
            int empid = Convert.ToInt32(Session["LoginEmpId"]);

            if (ddl_voutype.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Select Voucher Type');", true);
                ddl_voutype.Focus();
                return;
            }
            DataTable dtgst;
            dtgst = ProINVobj.Checksamegst4Proforma(branchid, Convert.ToInt32(hdncustid.Value));
            if (dtgst.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Branch and customer GST should not co-exists!!');", true);
                txtto.Focus();
                return;
            }
            strTranType = ddl_product.SelectedValue;
            if (txtblno.Text.Trim().ToUpper() != "")
            {
                if (chkmbl.Checked == false)
                {
                    Dt = new DataTable();
                    Dt = Amendobj.GetBLno(strTranType, txtblno.Text.Trim().ToUpper(), branchid, divisionid);
                    if (Dt.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Invalid BL #');", true);
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
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Invalid BL #');", true);
                        txtblno.Focus();

                        return;
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Invalid BL #');", true);
                txtblno.Focus();
                txtblno.Text = "";
                return;
            }

            if (txtCreditDays.Text == "")
            {
                txtCreditDays.Text = "0";
            }

            CheckData();

            if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice" || ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice OC")
            {

                if (txtVendorRefno.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter the  VendorRefno');", true);
                    txtVendorRefno.Focus();
                    blnerr = true;
                    return;
                }

                if (txtVendorRefnodate.Text == "")
                {


                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly select the  VendorRef Date');", true);
                    txtVendorRefnodate.Focus();
                    blnerr = true;
                    return;
                }
                if (txtVendorRefno.Text.Trim() != "")
                {
                    DataTable dtacc1 = new DataTable();
                    dtacc1 = ProINVobj.Checkvenrefno(txtVendorRefno.Text);
                    if (dtacc1.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alert('Vendor Ref # Already Exists..');", true);
                        txtVendorRefno.Focus();
                        return;
                    }
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

            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice" || ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice OC")
            {
                if (txtsupplyto.Text == "")
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From ');", true);
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
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Enter Supply From');", true);
                return;
            }
            try
            {

                dtacc = INVOICEobj.SelEmpDtls4Accnew(int_Empid, 0, branchid, strTranType, txtblno.Text);

                if (dtacc.Rows.Count > 0)
                {

                    if (dtacc.Rows[0]["closedjob"].ToString() == "1" && Session["StrTranType"].ToString() != "AC" && hid_acc.Value == "Y")
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " has closed. Corporate accountant only can Create the Pro Sales Invoice/PI');", true);
                        txtref.Text = "";
                        txtref.Focus();
                        return;
                    }
                    else
                    {

                        if (ddl_voutype.SelectedItem.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Select Voucher Type');", true);
                            ddl_voutype.Focus();
                            return;
                        }


                        if (btnsave.ToolTip == "Save")
                        {
                            if (txtref.Text != "")
                            {
                                return;
                            }

                            //if (lbl_Header.Text!= "Proforma Purchase Invoice")
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
                            //                ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('State Name not Updated in Master Kindly update Master Customer " + txtsupplyto.Text + " SupplyTo');", true);
                            //                return;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('State Name not Updated in Master Kindly update Master Customer " + txtsupplyto.Text + " SupplyTo');", true);
                            //            return;
                            //        }

                            //    }
                            //}

                            if (cmbbill.SelectedIndex == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Select Bill Type');", true);
                                return;
                            }

                            if ((INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjobno.Value), branchid)) == 1 && Session["StrTranType"].ToString()!= "AC" && hid_acc.Value == "Y")
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job # " + txtjobno.Value + " has Closed Already...You Can not create a Voucher');", true);
                                return;

                            }
                            //  dtdate.Text = Utility.fn_ConvertDate(dtdate.Text).ToString();
                            //if (lbl_Header.Text == "Proforma Purchase Invoice")
                            //{
                            //    Refno = ProINVobj.InsertProInvoiceHeadnew(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), strTranType, Convert.ToInt32(txtjobno.Value), Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), type, txtVendorRefno.Text, Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                            //}
                            //else
                            //{
                            //    Refno = ProINVobj.InsertProInvoiceHead(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), strTranType, Convert.ToInt32(txtjobno.Value), Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), type, txtVendorRefno.Text, Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value));
                            //}


                            Refno = ProINVobj.InsProLVhead(Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)), Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtjobno.Value),
                                    Convert.ToInt32(hdncustid.Value), txtblno.Text.ToUpper(), txtremarks.Text.Trim(), branchid, cmbbill.SelectedItem.Text,
                                    Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(ddl_voutype.SelectedValue), txtVendorRefno.Text,
                                    Convert.ToInt32(txtCreditDays.Text.Trim()), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));

                            txtref.Text = Refno.ToString();
                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                }
                            }
                            else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1014, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1021, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1028, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1035, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1042, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/Sav");
                                        break;
                                }
                            }
                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Ref # " + txtref.Text + " saved ');", true);
                            btnsave.Enabled = false;
                            btnsave.Text = "Update";

                            btnsave.ToolTip = "Update";
                            btnsave1.Attributes["class"] = "btn ico-update";
                            btnadd.Enabled = true;
                            btnsave.ForeColor = System.Drawing.Color.Gray;
                            btnadd.ForeColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            //dtdate.Text = Logobj.GetDate().ToShortDateString();
                            //dtdate.Text = Utility.fn_ConvertDate(dtdate.Text);


                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            {
                                sezcus = customerobj.getsezcustid(Convert.ToInt32(hdncustid.Value));
                                if (sezcus == "Y")
                                {
                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('Kindly Update the charge details once again ,Since it is a SEZ customer..');", true);
                                    if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                                    {
                                        switch (Session["StrTranType"].ToString())
                                        {
                                            case "FE":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                                break;
                                            case "FI":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                                break;
                                            case "AE":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                                break;
                                            case "AI":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                                break;
                                            case "CH":
                                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                                break;
                                        }
                                    }
                                }

                            }


                            if (cmbbill.SelectedIndex == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Select Bill Type');", true);
                                return;
                            }
                            dtcheck = new DataTable();
                            dtcheck = INVOICEobj.GetCheckApprovedProfomaLV(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), strTranType, Convert.ToInt32(ddl_voutype.SelectedValue), "HeadUpdate");
                            if (dtcheck.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Update Denied, Already Approved for Ref# " + txtref.Text + "');", true);
                                return;
                            }
                            else
                            {
                                if (Convert.ToInt32(hdncustid.Value) != 0)
                                {
                                    /*if (lbl_Header.Text == "Proforma Purchase Invoice")
                                    {
                                        ProINVobj.UpdateProHeadnew(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtremarks.Text.Trim(), cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, txtVendorRefno.Text.Trim(), Convert.ToInt32(txtCreditDays.Text), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                                    }
                                    else
                                    {
                                        ProINVobj.UpdateProHead(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtremarks.Text.Trim(), cmbbill.SelectedItem.Text, Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, txtVendorRefno.Text.Trim(), Convert.ToInt32(txtCreditDays.Text), Convert.ToInt32(hid_SupplyTo.Value));
                                    }*/

                                    ProINVobj.UpdateProLVHead(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtremarks.Text.Trim(), cmbbill.SelectedItem.Text,
                                        Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), branchid, Session["StrTranTypeO"].ToString(), Convert.ToInt32(ddl_voutype.SelectedValue), txtVendorRefno.Text.Trim(),
                                        Convert.ToInt32(txtCreditDays.Text), Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));
                                    if (hid_SupplyTonew.Value != hid_SupplyTo.Value)
                                    {

                                        ProINVobj.UpdChargesGST4OldVouLV(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(ddl_voutype.SelectedValue));
                                        hid_SupplyTonew.Value = hid_SupplyTo.Value;


                                    }
                                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Details Updated for Ref# " + txtref.Text + "');", true);
                                    // return;
                                    // btnadd.Enabled = true;
                                    // btnadd.ForeColor = System.Drawing.Color.White;
                                }
                            }


                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                }
                            }
                            else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                            {
                                switch (Session["StrTranType"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1014, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1021, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1028, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1035, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1042, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "Custname:" + txtto.Text + "Supplyto :" + txtsupplyto.Text + "/UPD");
                                        break;
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
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        /*
          public void ChkCustStateName(int custid, string custname)
         {
             if (Convert.ToDateTime(Logobj.GetDate().ToShortDateString()) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
             {
                 if (custname != "" && custid > 0)
                 {

                     //int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                     DataTable dt_list = new DataTable();
                     dt_list = customerobj.GetIndianCustomergstadd(custid);
                     /*if (dt_list.Rows.Count == 0)
                     {
                         ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                         bolcuststat = true;
                         return;
                     }
        
        
 


                     if (dt_list.Rows.Count > 0)
                     {
                         //if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                         //{

                         //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                         //    bolcuststat = true;
                         //    return;
                         //}

                         if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || dt_list.Rows[0]["UnRegistered"].ToString() == "Y")
                         {
                             if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) && dt_list.Rows[0]["UnRegistered"].ToString() == "Y")
                             {
                                 ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                                 bolcuststat = true;
                                 return;
                             }

                             if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                             {
                                 ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                                 bolcuststat = true;
                                 return;
                             }
                             else if (dt_list.Rows[0]["UnRegistered"].ToString() == "Y")
                             {

                             }

                         }
                       

                     }
                     else
                     {
                         ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                         bolcuststat = true;
                         return;
                     }

                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                     bolcuststat = true;
                     return;
                 }
             }
         }
         */


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
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('State Name not Updated in Master,Kindly update Master Customer " + custname + "');", true);
                        bolcuststat = true;
                        return;
                    }







                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "DataFound", "alert('Kindly update SUPPLY TO Name " + custname + "');", true);
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
            //if (lbl_Header.Text == "Proforma Purchase Invoice")
            //{
            //    type = "Profoma Payment Advise";
            //    hf_strtype.Value = type;
            //}
            //else
            //{
            //    type = lbl_Header.Text;
            //    hf_strtype.Value = type;
            //}
            DtInfo = new DataTable();
            DtInfo = ProINVobj.GetProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, Convert.ToInt32(ddl_voutype.SelectedValue));
            grd.DataSource = DtInfo;
            grd.DataBind();

            txtTotal.Text = "";
            double tot = 0, tot1 = 0;

            for (i = 0; i <= grd.Rows.Count - 1; i++)
            {
                if (grd.Rows[i].Cells[8].Text == "")
                {
                    grd.Rows[i].Cells[8].Text = "0";
                }

                tot1 = Convert.ToDouble(grd.Rows[i].Cells[8].Text);
                tot = tot + tot1;
            }
            txtTotal.Text = tot.ToString("#,0.00");


        }
        //public void Checkuiidrights()
        //{
        //    //DataAccess.UserPermission obj_UP = new //DataAccess.UserPermission();
        //    DataTable dtuser;
        //    dtuser = obj_UP.GetUserRights4Menu(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), str_Uiid);
        //    //if (str_Uiid!="")
        //    //{
        //    //    str_Uiid = Request.QueryString["uiid"].ToString();
        //    //}
        //    //else
        //    //{

        //    //}
        //    //  dtuser = obj_UP.GetUserRights4uiid(Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString(), str_Uiid);
        //}
        public void useit()
        {
            try
            {
                strTranType = Session["StrTranType"].ToString();
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
                //type = Request.QueryString["type"].ToString();
                if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                {
                    type = "Proforma Purchase Invoice";
                    hf_strtype.Value = type;
                }
                else
                {
                    type = ddl_voutype.SelectedItem.Text;
                    hf_strtype.Value = type;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);

            }
            btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtref_TextChanged(object sender, EventArgs e)
        {
            try
            {
                useit();
                //   //DataAccess.Masters.MasterCustomer customerobj = new //DataAccess.Masters.MasterCustomer();

                if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                {
                    type = "Profoma Purchase Invoice";
                    hf_strtype.Value = type;
                }
                else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice OC")
                {
                    type = "Profoma Purchase Invoice OC";
                    hf_strtype.Value = type;
                }
                else
                {
                    type = ddl_voutype.SelectedItem.Text;
                    hf_strtype.Value = type;
                }
                txtclear4refno();

                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                DataTable dtacc = new DataTable();
                DtSHead = ProINVobj.SelProLVHead(Convert.ToInt32(txtref.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtvouyear.Text), branchid, Convert.ToInt32(ddl_voutype.SelectedValue));
                string str_BLno = "";
                if (DtSHead.Rows.Count > 0)
                {
                    str_BLno = DtSHead.Rows[0]["blno"].ToString();
                }
               
                dtacc = INVOICEobj.SelEmpDtls4Accnew(int_Empid, 0, branchid, ddl_product.SelectedValue, str_BLno);

                if (dtacc.Rows.Count > 0)
                {

                    if (dtacc.Rows[0]["closedjob"].ToString() == "1" && Session["StrTranType"].ToString() == "AC" && hid_acc.Value == "Y")
                    {
                        ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " has been closed. Corporate accountant only can approve the Pro Invoice/PA');", true);
                        txtref.Text = "";
                        txtref.Focus();
                        return;
                    }
                    else
                    {


                        // DtSHead = ProINVobj.SelProInvHead(Convert.ToInt32(txtref.Text), strTranType, Convert.ToInt32(txtvouyear.Text), branchid, type);
                        if (DtSHead.Rows.Count > 0)
                        {
                            ddl_voutype.SelectedValue = DtSHead.Rows[0]["voutype"].ToString();

                            Dropdownlist1_SelectedIndexChanged(sender, e);
                            txtjobno.Value = DtSHead.Rows[0]["jobno"].ToString();
                            if ((INVOICEobj.CheckClosedJobs(ddl_product.SelectedValue, Convert.ToInt32(txtjobno.Value), branchid)) == 0 && Session["StrTranType"].ToString() == "AC")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job is still open , You Can not Modify the Voucher here');", true);
                                return;

                            }
                            if ((INVOICEobj.CheckClosedJobs(ddl_product.SelectedValue, Convert.ToInt32(txtjobno.Value), branchid)) == 1 && Session["StrTranType"].ToString() != "AC")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job has Closed Already You Can not Modify the Voucher here..');", true);
                                return;

                            }
                            hdncustid.Value = DtSHead.Rows[0]["customerid"].ToString();
                            txtto.Text = DtSHead.Rows[0]["customername"].ToString();
                            txtblno.Text = DtSHead.Rows[0]["blno"].ToString();

                            txtremarks.Text = DtSHead.Rows[0]["remarks"].ToString();

                            hdnfatransfer.Value = DtSHead.Rows[0]["fatransfer"].ToString();
                            dtdate.Text = DtSHead.Rows[0][1].ToString();
                            txtaddress.Text = customerobj.GetCustomerAddress(Convert.ToInt32(hdncustid.Value));


                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyTo"].ToString()))
                            {
                                hid_SupplyTo.Value = DtSHead.Rows[0]["SupplyTo"].ToString();
                                hid_SupplyTonew.Value = DtSHead.Rows[0]["SupplyTo"].ToString();
                            }
                            if (!string.IsNullOrEmpty(DtSHead.Rows[0]["SupplyToName"].ToString()))
                            {
                                txtsupplyto.Text = DtSHead.Rows[0]["SupplyToName"].ToString();



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


                            if (type == "Profoma Payment Advise" || type == "Proforma Purchase Invoice")
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
                                // txtVendorRefno.Text = "";
                                if (DtSHead.Rows[0]["vendorrefno"] != System.DBNull.Value)
                                {
                                    txtVendorRefno.Text = DtSHead.Rows[0]["vendorrefno"].ToString();
                                }
                                else
                                {
                                    txtVendorRefno.Text = "";
                                }
                                //txtCreditDays.Text = DtSHead.Rows[0]["creditdays"].ToString();

                                if (DtSHead.Rows[0]["vendorrefdate"] != System.DBNull.Value)
                                {
                                    txtVendorRefnodate.Text = DtSHead.Rows[0]["vendorrefdate"].ToString();
                                }
                                else
                                {
                                    txtVendorRefnodate.Text = "";
                                }

                                txtCreditDays.Text = "";
                                //  txtVendorRefnodate.Text = "";
                            }
                            if (ddl_product.SelectedValue == "FE" || ddl_product.SelectedValue == "FI")
                            {
                                if (txtblno.Text != "")
                                {
                                    Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Value), ddl_product.SelectedValue, branchid);

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
                            else if (ddl_product.SelectedValue == "AE" || ddl_product.SelectedValue == "AI")
                            {
                                if (txtblno.Text != "")
                                {
                                    Dt = DCAdviseObj.FillIPBLNo(Convert.ToInt32(txtjobno.Value), ddl_product.SelectedValue, branchid);
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
                            }
                            grdfill();
                            txtTotal.Text = "";
                            double tot = 0, tot1 = 0;
                            for (i = 0; i <= grd.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(grd.Rows[i].Cells[8].Text);
                                tot = tot + tot1;
                            }
                            txtTotal.Text = tot.ToString("#,0.00");
                            btnsave.Text = "Update";
                            btncancel.Text = "Cancel";


                            btnsave.ToolTip = "Update";
                            btnsave1.Attributes["class"] = "btn ico-update";
                            btnsave.Text = "Update";
                            btncancel.ToolTip = "Cancel";
                            btncancel1.Attributes["class"] = "btn ico-cancel";
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
                                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Already Transferred');", true);
                                    txtref.Focus();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('No Values Found');", true);
                                    txtref.Focus();
                                }
                            }
                            else
                            {
                                dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Invalid Refno");
                                txtref.Focus();
                            }*/
                            //if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            //{
                            //    dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Profoma Invoice");
                            //}
                            //if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            //{
                            //    dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Profoma Invoice");
                            //}
                            //else
                            //{
                            //    dtref = INVOICEobj.Getrefid(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, "Profoma Payment Advise");
                            //}
                            dtref = INVOICEobj.Checkrefid4ProLV(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, Convert.ToInt32(ddl_voutype.SelectedValue));
                            if (dtref.Rows.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "Alertify.alert('Already Transferred');", true);
                                txtref.Text = "";
                                txtref.Focus();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "Alertify.alert('Invalid Refno');", true);
                                txtref.Text = "";
                                txtref.Focus();
                            }

                        }
                        //}
                        //}


                        UserRights();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
                txtref.Text = "";
                txtref.Focus();
            }
            btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void Amendexrate_Click(object sender, EventArgs e)
        {
            //DataAccess.UserPermission obj_UP = new //DataAccess.UserPermission();
            DataTable dtuser;
            if (ddl_product.SelectedValue == "FE")
            {
                dtuser = obj_UP.GetFormwiseuserRights(371, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FE");
                if (dtuser.Rows.Count > 0)
                {
                    if (txtref.Text != "")
                    {
                        iframe1.Attributes["src"] = "../ForwardExports/AmendExRate.aspx?INjobno=" + txtjobno.Value + "&refno=" + txtref.Text + "&blno=" + txtblno.Text + "&invou=" + ddl_voutype.SelectedValue;
                        pop_up.Show();

                    }
                    else
                    {
                        if (txtref.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Ref # cannot be Empty!');", true);
                            txtref.Focus();
                        }


                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            else if (ddl_product.SelectedValue == "FI")
            {
                dtuser = obj_UP.GetFormwiseuserRights(372, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), "FI");
                if (dtuser.Rows.Count > 0)
                {
                    if (txtref.Text != "")
                    {
                        iframe1.Attributes["src"] = "../ForwardExports/AmendExRate.aspx?INjobno=" + txtjobno.Value + "&refno=" + txtref.Text + "&blno=" + txtblno.Text + "&invou=" + ddl_voutype.SelectedValue;
                        pop_up.Show();

                    }
                    else
                    {
                        if (txtref.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Ref # cannot be Empty!');", true);
                            txtref.Focus();
                        }


                    }

                }
                else
                {
                    string message = "No Rights";
                    ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

                }
            }
            //if (Session["StrTranType"].ToString() == "AI")
            //{
            //    dtuser = obj_UP.GetFormwiseuserRights(96, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            //    if (dtuser.Rows.Count > 0)
            //    {
            //        if (txtref.Text != "")
            //        {
            //            iframe1.Attributes["src"] = "../ForwardExports/AmendExRate.aspx?INjobno=" + txtjobno.Value + "&refno=" + txtref.Text + "&blno=" + txtblno.Text + "&invou=" + ddl_voutype.SelectedValue;
            //            pop_up.Show();

            //        }
            //        else
            //        {
            //            if (txtref.Text == "")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Ref # cannot be Empty!');", true);
            //                txtref.Focus();
            //            }


            //        }

            //    }
            //    else
            //    {
            //        string message = "No Rights";
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

            //    }
            //}
            //if (Session["StrTranType"].ToString() == "AE")
            //{
            //    dtuser = obj_UP.GetFormwiseuserRights(95, Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString());
            //    if (dtuser.Rows.Count > 0)
            //    {
            //        if (txtref.Text != "")
            //        {
            //            iframe1.Attributes["src"] = "../ForwardExports/AmendExRate.aspx?INjobno=" + txtjobno.Value + "&refno=" + txtref.Text + "&blno=" + txtblno.Text + "&invou=" + ddl_voutype.SelectedValue;
            //            pop_up.Show();

            //        }
            //        else
            //        {
            //            if (txtref.Text == "")
            //            {
            //                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Ref # cannot be Empty!');", true);
            //                txtref.Focus();
            //            }


            //        }

            //    }
            //    else
            //    {
            //        string message = "No Rights";
            //        ScriptManager.RegisterStartupScript(this.Page, typeof(System.Web.UI.WebControls.GridView), "logix", "alertify.alert('" + message + "');", true);

            //    }
            //}

           
        }

        protected void Close_voucher_Click(object sender, EventArgs e)
        {
            grdfill();
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            //popupconfirm.Show();
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtblno.Text = "";
                    return;
                }
                int count = 0;
                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                DataTable dtacc = new DataTable();

                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Select Voucher Type');", true);
                    ddl_voutype.Focus();
                    return;
                }
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
                    if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                    {
                        type = "Proforma Purchase Invoice";
                        hf_strtype.Value = type;
                    }
                    else
                    {
                        type = ddl_voutype.SelectedItem.Text;
                        hf_strtype.Value = type;
                    }
                    hdnChargid.Value = chargeobj.GetChargeid(txtcharge.Text).ToString();
                    if (hdnChargid.Value == "0")
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('InValid Charge Name');", true);
                        txtcharge.Focus();
                        return;
                    }
                    if (chargeobj.GetCurrID(txtcurr.Text.Trim()) == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('InValid Currency Name');", true);
                        txtcurr.Focus();
                        return;
                    }
                    if (cmbbase.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Select Base ');", true);
                        txtcurr.Focus();
                        return;
                    }


                    strcharge = txtcharge.Text;
                    if (strcharge.Length >= 5)
                    {
                        if (strcharge.Substring(0, 5) == "ST on" || strcharge.Substring(0, 5) == "EduCe" || strcharge.Substring(0, 5) == "Highe")
                        {
                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Cannot Access the Charge');", true);
                            txtcharge.Focus();
                            return;
                        }
                    }
                    cmbbase_SelectedIndexChanged(sender, e);

                    dtchargedel = INVOICEobj.GetCheckApprovedProfomaLV(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), "", Convert.ToInt32(ddl_voutype.SelectedValue), "Charge");
                    if (dtchargedel.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Charges Cannot Delete After Approved');", true);
                        return;
                    }
                    if ((INVOICEobj.CheckClosedJobs(ddl_product.SelectedValue, Convert.ToInt32(txtjobno.Value), branchid)) == 1 && Session["StrTranType"].ToString() != "AC")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job # " + txtjobno.Value + " has Closed Already...You Can not create a Voucher');", true);
                        return;

                    }
                    try
                    {
                        if (txtamount.Text != "0" && hdnUnit.Value != "")
                        {
                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
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

                            dtacc = INVOICEobj.SelEmpDtls4Accnew(int_Empid, 0, branchid, ddl_product.SelectedValue, txtblno.Text);

                            if (dtacc.Rows.Count > 0)
                            {

                                if (dtacc.Rows[0]["closedjob"].ToString() == "1" && Session["StrTranType"].ToString() != "AC" && hid_acc.Value == "Y")
                                {
                                    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Job # " + dtacc.Rows[0]["jobno"].ToString() + " has closed. Corporate accountant only can approve the Pro Invoice/PA');", true);
                                    txtref.Text = "";
                                    txtref.Focus();
                                    return;
                                }
                                else
                                {

                                    //for (i = 0; i <= grd.Rows.Count - 1; i++)
                                    //{

                                    //    if (grd.Rows[i].Cells[1].Text.ToUpper() == txtcurr.Text.ToUpper())
                                    //    {
                                    //        if (Convert.ToDouble(grd.Rows[i].Cells[3].Text) != Convert.ToDouble(txtex.Text))
                                    //        {
                                    //            //ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Exrate Different kindly check with  " + txtcharge.Text + " .');", true);
                                    //            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Different  Exrate is not allowed for same Currency,Kindly check Exrate for :" + txtcurr.Text + ");", true);
                                    //            txtex.Focus();
                                    //            return;
                                    //        }

                                    //    }
                                    //}



                                    for (i = 0; i <= grd.Rows.Count - 1; i++)
                                    {
                                        if (grd.Rows[i].Cells[2].Text.ToUpper() == txtcurr.Text.ToUpper())
                                        {
                                            count = count + 1;

                                        }
                                    }
                                    for (i = 0; i <= grd.Rows.Count - 1; i++)
                                    {

                                        if (grd.Rows[i].Cells[2].Text.ToUpper() == txtcurr.Text.ToUpper())
                                        {

                                            if (count >= 1)
                                            {
                                                //if (grd.Rows[i].Cells[4].Text != txtex.Text)
                                                if ((Convert.ToDouble(grd.Rows[i].Cells[4].Text)) != (Convert.ToDouble(txtex.Text)))
                                                {
                                                    //ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Exrate Different kindly check with  " + txtcharge.Text + " .');", true);

                                                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Different  Exrate is not allowed for same Currency,Kindly check Exrate for " + txtcurr.Text + ".');", true);
                                                    txtex.Focus();
                                                    return;
                                                }
                                            }

                                        }
                                    }


                                    if (btnadd.ToolTip == "Add")
                                    {
                                        if (txtref.Text == "")
                                        {
                                            return;
                                        }


                                        //    if (lbl_Header.Text != "Proforma Purchase Invoice")
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
                                        //                ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('State Name not Updated in Master Kindly update Master Customer ');", true);
                                        //                return;
                                        //            }
                                        //        }
                                        //        else
                                        //        {
                                        //            ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alert('State Name not Updated in Master Kindly update Master Customer');", true);
                                        //            return;
                                        //        }

                                        //    }
                                        //  }
                                        //}
                                        dtcheck = ProINVobj.CheckchrgInvProLV(Convert.ToInt32(txtref.Text), cmbbase.Text, Convert.ToInt32(hdnChargid.Value), Convert.ToInt32(txtvouyear.Text), branchid, Convert.ToInt32(ddl_voutype.SelectedValue));
                                        if (dtcheck.Rows.Count > 0)
                                        {

                                            chargename = 1;
                                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Charge Already Exists...');", true);
                                            txtcharge.Focus();
                                            return;
                                        }
                                        else
                                        {
                                            chargename = 0;
                                            if (txtcharge.Text != "" && txtrate.Text != "" && txtex.Text != "" && txtcurr.Text != "" && cmbbase.Text != "" && txtamount.Text != "")
                                            {





                                                if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                                                {
                                                    if (cmbbill.Text != "Internal")
                                                    {
                                                        double stper;
                                                        stper = chargeobj.CheckChargeST(Convert.ToInt32(hdnChargid.Value));
                                                        if (stper == 0)
                                                        {

                                                            ProINVobj.InsertProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(),
                                                                Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedItem.Text, Convert.ToDouble(txtamount.Text),
                                                                branchid, Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedItem.Text, ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue), "N", Convert.ToDouble(hdnUnit.Value));
                                                        }
                                                        else
                                                        {
                                                            this.PopUpService.Show();
                                                            return;
                                                        }

                                                    }
                                                    else
                                                    {


                                                        ProINVobj.InsertProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(),
                                                            Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), branchid,
                                                            Convert.ToInt32(txtvouyear.Text), cmbbill.Text, ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue), "Y", Convert.ToDouble(hdnUnit.Value));

                                                    }

                                                }
                                                else
                                                {

                                                    ProINVobj.InsertProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(),
                                                        Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), branchid,
                                                        Convert.ToInt32(txtvouyear.Text), cmbbill.Text, ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue), "Y", Convert.ToDouble(hdnUnit.Value));


                                                }


                                                if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                                                {
                                                    switch (ddl_product.SelectedValue)
                                                    {
                                                        case "FE":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "FI":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "AE":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "AI":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "CH":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                    }
                                                }
                                                else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                                                {
                                                    switch (ddl_product.SelectedValue)
                                                    {
                                                        case "FE":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1014, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "FI":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1021, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "AE":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1028, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "AI":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1035, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                        case "CH":
                                                            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1042, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/Add");
                                                            break;
                                                    }

                                                }
                                                /* switch (Session["StrTranType"].ToString())
                                                 {
                                                     case "FE":
                                                         Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 388, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                         break;
                                                     case "FI":
                                                         Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 779, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                         break;
                                                     case "AE":
                                                         Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 390, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                         break;
                                                     case "AI":
                                                         Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 391, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                         break;
                                                     case "CH":
                                                         Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 392, 1, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                         break;
                                                 }*/
                                                grdfill();
                                                txtcharge.Focus();

                                                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Charges Details Saved...');", true);
                                                //txtcharge.Text = ""; txtcurr.Text = ""; txtrate.Text = ""; txtex.Text = ""; txtamount.Text = ""; cmbbase.SelectedIndex = 0;
                                            }
                                        }

                                    }

                                    else
                                    {
                                        if (txtcharge.Text != "" && txtrate.Text != "" && txtex.Text != "" && txtcurr.Text != "" && cmbbase.Text != "" && txtamount.Text != "")
                                        {
                                            if (ddl_product.SelectedValue == "CH")
                                            {
                                                Dt = new DataTable();
                                                Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text, "CH", branchid);
                                                if (Dt.Rows.Count > 0)
                                                {
                                                    jobtype = Dt.Rows[0][10].ToString();
                                                }
                                            }
                                            if (hdnChargid.Value == "4559" || hdnChargid.Value == "4563")
                                            {
                                                this.PopUpService.Show();
                                                return;
                                            }
                                            else
                                            {
                                                ProINVobj.UpdateProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), hid_cmbase.Value, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToDouble(hdnUnit.Value));
                                            }
                                            // ProINVobj.UpdateProInvoiceDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), hid_cmbase.Value, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, type, Convert.ToDouble(hdnUnit.Value));



                                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                                            {
                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "FI":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "AE":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "AI":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "CH":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                }
                                            }
                                            else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                                            {
                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1014, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "FI":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1021, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "AE":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1028, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "AI":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1035, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                    case "CH":
                                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1042, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + " " + txtcharge.Text + " " + txtcurr.Text + " " + txtrate.Text + " " + txtex.Text + " " + cmbbase.Text + " " + txtamount.Text + "/UPD");
                                                        break;
                                                }
                                            }

                                            /*switch (Session["StrTranType"].ToString())
                                            {
                                                case "FE":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 388, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                    break;
                                                case "FI":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 779, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                    break;
                                                case "AE":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 390, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                    break;
                                                case "AI":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 391, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                    break;
                                                case "CH":
                                                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 392, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value));
                                                    break;
                                            }*/
                                            grdfill();
                                            txtcharge.Focus();
                                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Charges Details Updated ...');", true);
                                            //txtcharge.Text = ""; txtcurr.Text = ""; txtrate.Text = ""; txtex.Text = ""; txtamount.Text = ""; cmbbase.SelectedIndex = 0;
                                        }
                                    }

                                }
                            }
                        }
                        grdfill();
                        chargetxtclear();
                        // btnadd.Text = "Add";


                        btnadd.ToolTip = "Add";
                        btnadd1.Attributes["class"] = "btn ico-add";
                        txtcharge.Enabled = true;
                        btnadd.Enabled = false;
                        btnadd.ForeColor = System.Drawing.Color.Gray;
                        txtcharge.Focus();
                        UserRights();
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);

                    }





                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
            btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";

        }

        protected void txtcharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataAccess.Masters.MasterCharges chargeobj = new //DataAccess.Masters.MasterCharges();

                int chargeid = chargeobj.GetChargeid(txtcharge.Text.Trim().ToUpper());
                if (chargeid != 0)
                {
                    txtcurr.Focus();
                }
                else
                {
                    txtcharge.Text = "";
                    txtcharge.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Enter the Valid Charges');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
            btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
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
                dtcheck = ProINVobj.CheckchrgInvProLV(Convert.ToInt32(txtref.Text), cmbbase.Text, Convert.ToInt32(hdnChargid.Value), Convert.ToInt32(txtvouyear.Text), branchid, Convert.ToInt32(ddl_voutype.SelectedValue));
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
            // btnsave.Text = "Save";

            btnsave.ToolTip = "Save";
            btnsave1.Attributes["class"] = "btn ico-save";
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
                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Cannot Access the Charge');", true);
                            txtcharge.Focus();
                            return;
                        }
                    }
                    if (strcharge.Substring(0, 5) == "ST on" || strcharge.Substring(0, 5) == "EduCe" || strcharge.Substring(0, 5) == "Highe" || strcharge.Substring(0, 5) == "ROUND")
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Cannot Access the Charge');", true);
                        txtcharge.Focus();
                        return;
                    }
                }

                //btnadd.Text = "Upd";



                btnadd.ToolTip = "Upd";
                btnadd.Text = "Update";
                btnadd1.Attributes["class"] = "btn ico-update";


                txtcharge.Text = Server.HtmlDecode(grd.SelectedRow.Cells[1].Text);
                txtcurr.Text = grd.SelectedRow.Cells[2].Text;
                txtrate.Text = grd.SelectedRow.Cells[3].Text;
                txtrate.Text = String.Format("{0:F2}", txtrate.Text);
                txtex.Text = grd.SelectedRow.Cells[4].Text;
                txtex.Text = String.Format("{0:F2}", txtex.Text);
                cmbbase.SelectedValue = grd.SelectedRow.Cells[5].Text;
                hid_cmbase.Value = grd.SelectedRow.Cells[5].Text;
                //double gsta = Convert.ToDouble(grd.SelectedRow.Cells[5].Text);
                //txtamount.Text = grd.SelectedRow.Cells[6].Text ;
                //double gstamt= Convert.ToDouble( txtamount.Text);
                // double gasttot = gstamt - gsta;
                // txtamount.Text = String.Format("{0:F2}", gasttot);
                txtamount.Text = grd.SelectedRow.Cells[6].Text;
                txtamount.Text = String.Format("{0:F2}", txtamount.Text);
                txtcharge.Enabled = false;
                hdnChargid.Value = grd.SelectedRow.Cells[9].Text;
                txtcharge.Enabled = false;
                txtcharge.BackColor = Color.White;
                txtcharge.ForeColor = Color.Black;
                btnadd.Enabled = true;
                btnadd.ForeColor = System.Drawing.Color.White;
                txtcurr.Focus();
                txtDisable();
            }
            UserRights();
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
            useit();
            strTranType = ddl_product.SelectedValue;
            if (Session["DtConDetails"] != null)
            {
                DtConDetails = (DataTable)Session["DtConDetails"];
            }
            for (int x = 0; x < DtConDetails.Rows.Count; x++)
            {
                if (strbase == DtConDetails.Rows[x]["containerno"].ToString())
                {
                    amount = rate * exrate;
                    hdnUnit.Value = "1";
                    return (amount);

                }
            }
            if (cmbbase.Text.ToUpper() == "BL".ToUpper() || cmbbase.Text.ToUpper() == "HWBL".ToUpper() || cmbbase.Text.ToUpper() == "DOC".ToUpper() || cmbbase.Text.ToUpper() == "FLAT RATE".ToUpper() || cmbbase.Text.ToUpper() == "HAWB".ToUpper())
            {
                amount = rate * exrate;
                hdnUnit.Value = "1";
            }
            //---------------------------------------------------------------

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
                                    //amount = rate * exrate * (strntweight / 1000);


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
                                //amount = rate * exrate * (strntweight / 1000);
                                amount = rate * exrate * (strntweight);
                                doublevolume = strntweight;
                                //  hdnUnit.Value = (strntweight / 1000).ToString();

                                hdnUnit.Value = (strntweight).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                            }
                        }
                        else
                        {
                            if (chkmbl.Checked == false)
                            {
                                strntweight = INVOICEobj.GetWeightnew(txtblno.Text, strTranType, branchid);
                                // amount = rate * exrate * (strntweight / 1000);

                                amount = rate * exrate * (strntweight);
                                doublevolume = strntweight;
                                //  hdnUnit.Value = (strntweight / 1000).ToString();
                                hdnUnit.Value = (strntweight).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "H");
                            }
                            else
                            {
                                strntweight = INVOICEobj.GetSumofWeightnew(txtjobno.Value, strTranType, branchid);
                                amount = rate * exrate * (strntweight);
                                doublevolume = strntweight;
                                hdnUnit.Value = (strntweight).ToString();
                                fd = DCAdviseObj.GetFDFromBLNO(txtblno.Text, strTranType, branchid, "M");
                            }

                        }
                    }
                }
            }
            else if (cmbbase.Text.ToUpper() == "Kgs".ToUpper() || cmbbase.Text.ToUpper() == "PER KG".ToUpper())
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

            else if (cmbbase.Text.ToUpper() == "COTTON/PALLET".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    //DataAccess.Accounts.DCAdvise DCAdviseObj = new //DataAccess.Accounts.DCAdvise();
                    //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new //DataAccess.Accounts.Invoice();
                    if (chkmbl.Checked == false)
                    {
                        strchgpallet = INVOICEobj.Getchargepallet(txtblno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgpallet);
                        hdnUnit.Value = strchgpallet.ToString();
                    }
                    else
                    {
                        Double strchgpallet1 = INVOICEobj.Getchargepalletmbl(Convert.ToInt32(txtjobno.Value), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * Convert.ToDouble(strchgpallet1);
                        hdnUnit.Value = strchgpallet1.ToString();
                    }
                    //   unit = strchgweight.ToString();
                    // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");

                }
            }

            else if (cmbbase.Text.ToUpper() == "PERTRUCK".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    //DataAccess.Accounts.DCAdvise DCAdviseObj = new //DataAccess.Accounts.DCAdvise();
                    //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new //DataAccess.Accounts.Invoice();
                    if (chkmbl.Checked == false)
                    {
                        strchgtruck = INVOICEobj.Getchargetruck(txtblno.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgtruck);
                        hdnUnit.Value = strchgtruck.ToString();
                    }
                    else
                    {

                        Double strchgtruck1 = INVOICEobj.Getchargetrucknew(Convert.ToInt32(txtjobno.Value), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * Convert.ToDouble(strchgtruck1);
                        hdnUnit.Value = strchgtruck1.ToString();
                    }
                    //   unit = strchgweight.ToString();
                    // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");

                }
            }


            else if (cmbbase.Text.ToUpper() == "Volume".ToUpper())
            {
                strgrosswght = INVOICEobj.GetVolumeQty(txtblno.Text, branchid);
                amount = rate * exrate * strgrosswght;
                hdnUnit.Value = strgrosswght.ToString();
            }
            else if (cmbbase.Text.ToUpper() == "W/M".ToUpper()) // added on 02Feb2023 // nambi
            {

                double cbmAmt = 0;
                double mtAmt = 0;


                strvolume = INVOICEobj.GetVolume(txtblno.Text, strTranType, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                cbmAmt = rate * exrate * strvolume;

                strntweight = INVOICEobj.GetWeightnew(txtblno.Text, strTranType, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                mtAmt = rate * exrate * (strntweight);

                if (cbmAmt < mtAmt)
                {
                    //FBase = "MT";
                    amount = mtAmt;
                    doublevolume = (strntweight);
                    hdnUnit.Value = doublevolume.ToString();
                }
                else
                {
                    if (strbase.ToUpper() == "W/M")
                    {
                        //FBase = "W/M";
                        amount = cbmAmt;
                        doublevolume = strvolume;
                        hdnUnit.Value = doublevolume.ToString();
                    }
                    else
                    {
                        //FBase = "CBM";
                        amount = cbmAmt;
                        doublevolume = strvolume;
                        hdnUnit.Value = doublevolume.ToString();
                    }
                }

                //strvolume = INVOICEobj.GetSumofVolume(txtjobno.Value, strTranType, branchid);
                //amount = rate * exrate * strvolume;
                //doublevolume = strvolume;
                //hdnUnit.Value = doublevolume.ToString();
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
            if (txtref.Text == "")
            {
                return;
            }
            if (cmbbase.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Select Any Of One of Base...');", true);
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
            try
            {
                if (ddl_product.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('Please Select the Product Type');", true);
                    ddl_product.Focus();
                    txtblno.Text = "";
                    return;
                }
                useit();
                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Kindly Select Voucher Type');", true);
                    ddl_voutype.Focus();
                    return;
                }
                if (txtcharge.Text.Trim() == "")
                {
                    return;
                }

                DataTable dtchargedel = new DataTable();
                int index = 0;
                index = grd.Rows.Count;

                dtchargedel = INVOICEobj.GetCheckApprovedProfomaLV(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), "", Convert.ToInt32(ddl_voutype.SelectedValue), "Charge");
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

                    if (ddl_product.SelectedValue == "CH")
                    {
                        Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text, "CHA", branchid);
                        if (Dt.Rows.Count != 0)
                        {
                            jobtype = Dt.Rows[0][10].ToString();
                        }
                    }
                    ProINVobj.DelProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), cmbbase.SelectedItem.Text, Convert.ToInt32(txtvouyear.Text), branchid, ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue));
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted.", true);

                    if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                    {
                        switch (ddl_product.SelectedValue)
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "CH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                        }
                    }
                    else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                    {
                        switch (ddl_product.SelectedValue)
                        {
                            case "FE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1014, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "FI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1021, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "AE":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1028, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "AI":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1035, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                            case "CH":
                                Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1042, 4, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                                break;
                        }
                    }

                    grdfill();

                    if (grd.Rows.Count == 0 || index < 1)
                    {
                        txtclear();
                        txtEnable();
                    }
                    btnsave.ToolTip = "Save";
                    btnsave1.Attributes["class"] = "btn ico-save";
                    btnadd.ToolTip = "Add";
                    btnadd1.Attributes["class"] = "btn ico-add";
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }

        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            //DataAccess.UserPermission obj_UP = new //DataAccess.UserPermission();
            int countryid = obj_UP.Get_countrycode(Session["LoginBranchName"].ToString());
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
            string str_TranType = ddl_product.SelectedValue;

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
            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
            {
                header = "Invoice";
            }
            else if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice OC")
            {
                header = "Invoice FC";
            }
            else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
            {
                header = "PA";
            }
            else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice OC")
            {
                header = "PA FC";
            }

            if (txtref.Text.TrimEnd().Length > 0)
            {
                if ((countryid == 1102) || (countryid == 102))
                {
                    str_Script += "window.open('../Reportasp/LVReport.aspx?Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=" + ddl_voutype.SelectedValue + "&" + this.Page.ClientQueryString + "','','');";
                    Session["string"] = "Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=" + ddl_voutype.SelectedValue + "&" + this.Page.ClientQueryString + "','','');";
                }
                else
                {
                    str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=" + ddl_voutype.SelectedValue + "&" + this.Page.ClientQueryString + "','','');";
                }
            }
            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Invoice", str_Script, true);



            switch (ddl_product.SelectedValue)
            {
                case "FE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + Refno + " - " + ddl_voutype.SelectedItem.Text);
                    break;
                case "FI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + Refno + " - " + ddl_voutype.SelectedItem.Text);
                    break;
                case "AE":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + Refno + " - " + ddl_voutype.SelectedItem.Text);
                    break;
                case "AI":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + Refno + " - " + ddl_voutype.SelectedItem.Text);
                    break;
                case "CH":
                    Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + Refno + " - " + ddl_voutype.SelectedItem.Text);
                    break;
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
                           ScriptManager.RegisterStartupScript(txtcurr, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Ex. Rate Not Available');", true);
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
                   ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
               }

           }*/

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            try
            {
                useit();

                //if (ddl_voutype.SelectedItem.Text == "Proforma Invoice")
                //{
                ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                if (bolcuststat == true)
                {
                    bolcuststat = false;
                    return;
                }
                //}
                if (btnadd.ToolTip == "Add")
                {
                    ProINVobj.InsertProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedValue.ToString(), Convert.ToDouble(txtamount.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedValue.ToString(), ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue), "Y", Convert.ToDouble(hdnUnit.Value));
                }
                else
                {
                    ProINVobj.UpdateProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), hid_cmbase.Value, Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToDouble(hdnUnit.Value));
                }
                grdfill();
                this.PopUpService.Hide();
                chargetxtclear();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }

        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            try
            {
                useit();
                if (btnadd.ToolTip == "Add")
                {
                    ProINVobj.InsertProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.SelectedValue.ToString(), Convert.ToDouble(txtamount.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Convert.ToInt32(txtvouyear.Text), cmbbill.SelectedValue.ToString(), ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue), "N", Convert.ToDouble(hdnUnit.Value));

                }
                else
                {
                    ProINVobj.UpdateProLVDetailsertax(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), txtcurr.Text.ToUpper(), Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), hid_cmbase.Value, Convert.ToInt32(txtvouyear.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue, Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToDouble(hdnUnit.Value), "N");

                }
                grdfill();
                this.PopUpService.Hide();
                chargetxtclear();
                UserRights();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }

        }

        protected void txtcurr_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //DataAccess.Masters.MasterCharges chargeobj = new //DataAccess.Masters.MasterCharges();
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = ddl_product.SelectedValue;
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
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Enter the Valid Currency');", true);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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
                // btnsave.Text = "Update";

                btnsave.ToolTip = "Update";
                btnsave1.Attributes["class"] = "btn ico-update";
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
            //DataAccess.UserPermission userobj = new //DataAccess.UserPermission();
            string script = "";
            if (txtref.Text == "")
            {
                return;
            }
            if (txtex.Text != "")
            {
                if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
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
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + script + "');", true);

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
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('Less than Current Exrate Not Allowed');", true);
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
                string str_TranType = ddl_product.SelectedValue;
                string citysupplyid;
                int int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                string sezcus = "";
                if (txtsupplyto.Text != "")
                {
                    int_custid = Convert.ToInt32(hid_SupplyTo.Value);
                    citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                    txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);

                    dtnew = cus.getcustomerblk(int_custid);
                    if (dtnew.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('This customer " + txtsupplyto.Text + " status is Hold please discuss with Finance team ');", true);
                        txtsupplyto.Text = "";
                        txtsupplyto.Focus();
                        return;
                    }



                    DataTable dt_list = new DataTable();
                    if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                    {
                        sezcus = customerobj.getsezcustid(int_custid);
                        if (sezcus == "Y")
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  Once again update the chargedetails');", true);
                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            {
                                switch (ddl_product.SelectedValue)
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + "Supplyto :" + txtsupplyto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                }
                            }
                        }

                    }

                    //DataAccess.UserPermission obj_UP = new //DataAccess.UserPermission();
                    int countryid = obj_UP.Get_countrycode(Session["LoginBranchName"].ToString());

                    if (int_custid != 0 && (countryid == 1102 || countryid == 102))
                    {
                        //if (lbl_Header.Text != "Proforma Purchase Invoice")
                        //{


                        dt_list = customerobj.GetIndianCustomergst(int_custid);
                        if (dt_list.Rows.Count > 0)
                        {
                            if (string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()) || string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(dt_list.Rows[0]["gstin"].ToString()))
                                {
                                    txtsupplytoAddress.Text += System.Environment.NewLine + "GSTIN #:" + dt_list.Rows[0]["gstin"].ToString();

                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update  Uinno#  Master Customer);", true);
                                }
                                else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                {
                                    txtsupplytoAddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin# Master Customer');", true);
                                }
                                else if (dt_list.Rows[0]["UnRegistered"].ToString() == "N" && dt_list.Rows[0]["uinno"].ToString() == "" && dt_list.Rows[0]["gstin"].ToString() == "")
                                {
                                    ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  OR  Select UnRegistered  Master Customer');", true);
                                }


                                //ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                            }
                            else
                            {
                                txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
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

                                      ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update  Uinno#  Master Customer);", true);
                                  }
                                  else if (!string.IsNullOrEmpty(dt_list.Rows[0]["uinno"].ToString()))
                                  {
                                      txtsupplytoAddress.Text += System.Environment.NewLine + "UIN #:" + dt_list.Rows[0]["uinno"].ToString();

                                      ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin# Master Customer');", true);
                                  }


                                  ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                              }
                              else
                              {
                                  txtsupplytoAddress.Text += System.Environment.NewLine + dt_list.Rows[0]["Column1"].ToString();
                              }
                          }
                          else
                          {
                              ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alert('please  update Gstin#  OR Uinno#  Master Customer');", true);
                              return;
                          }*/

                        //}
                    }
                    else if (int_custid == 0)
                    {
                        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alert('Select Correct Customer Name');", true);
                        txtsupplyto.Text = "";
                        txtsupplyto.Focus();
                        return;
                    }


                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alert('" + message + "');", true);
            }
        }

        protected void loadgridlog()
        {
            GridViewlog.Visible = true;
            Panel2.Visible = true;
            DataTable obj_dtlogdetails = new DataTable();
            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
            {
                if (Session["StrTranType"] != null)
                {
                    if (ddl_product.SelectedValue == "FE")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1013, "ProInv", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "FI")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1020, "ProInv", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "AE")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1027, "ProInv", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "AI")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1034, "ProInv", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "CH")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1041, "ProInv", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1013, "ProInv", txtref.Text, txtref.Text, "");
                }
            }
            else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
            {
                if (Session["StrTranType"] != null)
                {
                    if (ddl_product.SelectedValue == "FE")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1014, "Propa", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "FI")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1021, "Propa", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "AE")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1028, "Propa", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "AI")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1035, "Propa", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                    else if (ddl_product.SelectedValue == "CH")
                    {
                        obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1042, "Propa", txtref.Text, txtref.Text, ddl_product.SelectedValue);
                    }
                }
                else
                {
                    obj_dtlogdetails = Logobj.InsTempGrpLogdtlsGet(Convert.ToInt32(Session["LoginEmpId"]), Convert.ToInt32(Session["LoginBranchid"]), 1014, "Propa", txtref.Text, txtref.Text, "");
                }

            }

            if (txtref.Text != "")
            {
                JobInput.Text = txtref.Text;
            }
            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
            {
                lbl_no.InnerText = "Proforma Sales Invoice #:";
            }
            else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
            {
                lbl_no.InnerText = "Proforma Purchase Invoice #:";
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

        protected void Dropdownlist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddltype"] = ddl_voutype.SelectedItem.Text;
            Session["ddltypeid"] = ddl_voutype.SelectedValue;
            if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice" || ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice OC")
            {
                type = ddl_voutype.SelectedItem.Text;
                Amendexrate.Visible = true;
                hf_strtype.Value = type;
                Label33.Visible = true;
                Label33.Text = "CreditDays";
                txtCreditDays.Visible = true;
                txtVendorRefno.Visible = true;
                txtVendorRefnodate.Visible = true;
                Label7.Visible = false;
                txtcreditapp1.Visible = false;
                txtto.ToolTip = "Bill From";
                txtsupplyto.ToolTip = "Supply From";
                //txtto.Attributes["Placeholder"] = "Bill From";
                //txtsupplyto.Attributes["Placeholder"] = "Supply From";
                Label11.Text = "Bill From";
                Label12.Text = "Supply From";
                txtVendorRefnodate1.Attributes["class"] = "VendorRef2";
                chkmbl.Enabled = true;
                Label8.Text = "Vendor Ref #";
                Label9.Text = "Vendor Ref Date";

            }
            else if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice" || ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice OC")
            {
                txtto.ToolTip = "Bill To";
                txtsupplyto.ToolTip = "Supply To";
                //txtto.Attributes["Placeholder"] = "Bill To";
                Amendexrate.Visible = true;
                //txtsupplyto.Attributes["Placeholder"] = "Supply To";
                Label11.Text = "Bill To";
                Label12.Text = "Supply To";
                hd_exrate.Value = "R";
                type = ddl_voutype.SelectedItem.Text;
                ddl_voutype.SelectedItem.Text = type;
                hf_strtype.Value = type;
                Label33.Visible = false;
                txtCreditDays.Visible = false;
                txtVendorRefno.Visible = true;
                txtVendorRefnodate.Visible = true;
                Label7.Visible = true;
                txtcreditapp1.Visible = true;
                chkmbl.Enabled = true;
                Label8.Text = "Customer Ref #";
                Label9.Text = "customer Ref Date";
            }
            headerlabel.InnerText = ddl_voutype.SelectedItem.Text;

        }

        protected void txtVendorRefno_TextChanged(object sender, EventArgs e)
        {
            if (ddl_voutype.SelectedValue == "2")
            {
                DataTable dtacc = new DataTable();
                dtacc = ProINVobj.Checkvenrefno(txtVendorRefno.Text);
                if (dtacc.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alert('Vendor Ref # Already Exists..');", true);

                    txtVendorRefno.Focus();

                    return;
                }
            }
        }


    }

}