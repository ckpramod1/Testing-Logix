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
using DataAccess.Accounts;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Vml;

namespace logix.Accounts
{
    public partial class ProOSV : System.Web.UI.Page
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
        DataAccess.Accounts.DCAdvise DAdvise = new DataAccess.Accounts.DCAdvise();
        DataAccess.Masters.MasterBranch obj_branchd = new DataAccess.Masters.MasterBranch();
        DataAccess.Accounts.OSDNCN OSDNCN = new DataAccess.Accounts.OSDNCN();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();
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
        string type, strTranType, vessel, voyage, agent, jobtype, fatransfers, strcharge, strchgtruck, strchgpallet;
        int divisionid, branchid;
        DateTime eta;
        int i; int cbase = 0;
        Boolean blnerr, bolcuststat;
        int Refno, chargename;
        string str_FornName = "", str_Uiid = "";
        Double amount, strvolume, strntweight, strchgweight, strgrosswght, sizecount, famount, currexrate;
        DataAccess.Accounts.Invoice obj_da_inv = new DataAccess.Accounts.Invoice();
        DataTable obj_dt_head = new DataTable();
        string bill; int billno; char billtype; DateTime voudate;
        DataTable dtnew1 = new DataTable();

        int fd = 0;
        double douvolume = 0, volume = 0, wt = 0;
        DataTable dtnew = new DataTable();
        DataAccess.Masters.MasterCustomer cus = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();
        DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
        DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
        DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
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
                obj_da_FEBL.GetDataBase(Ccode);
                obj_da_FIBL.GetDataBase(Ccode);
                DAdvise.GetDataBase(Ccode);
                obj_branchd.GetDataBase(Ccode);
                OSDNCN.GetDataBase(Ccode);
                logobj.GetDataBase(Ccode);
                obj_da_mc.GetDataBase(Ccode);
                obj_UP.GetDataBase(Ccode);


                da_obj_OSDNCN.GetDataBase(Ccode);
                userobj.GetDataBase(Ccode);
                da_obj_logobj.GetDataBase(Ccode);
                userobj.GetDataBase(Ccode);
                //objosdncn.GetDataBase(Ccode);
                //da_obj_jobinfo.GetDataBase(Ccode);
                //masterObj.GetDataBase(Ccode);
                //objnewdoc.GetDataBase(Ccode);
                //objnew.GetDataBase(Ccode);


            }

            Session["str_sfs"] = "";
            Session["str_sp"] = "";
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(btncancel);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtto);
            ((ScriptManager)Master.FindControl("ScriptManager1")).RegisterPostBackControl(txtref);

            if (Session["LoginUserName"] == null || Session["LoginEmpId"] == null || Session["LoginDivisionId"] == null || Session["LoginBranchid"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/','_top');", true);
            }
            else if (Session["StrTranType"] == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "Master", "alertify.alert('Session TimeOut');window.open('" + Session["Site"].ToString() + "/FormMain.aspx','_top');", true);
            }
            if (Session["LoginDivisionId"] != null)
            {
                divisionid = Convert.ToInt32(Session["LoginDivisionId"]);
            }
            if (Session["LoginBranchid"] != null)
            {
                branchid = Convert.ToInt32(Session["LoginBranchid"]);
            }
            if (Session["StrTranType"] != null)
            {
                // strTranType = Session["StrTranType"].ToString();

            }
            //if (Session["StrTranType"].ToString() == "FE")
            //{
            //    Session["StrTranTypeO"] = "OE";
            //}
            //else if (Session["StrTranType"].ToString() == "FI")
            //{
            //    Session["StrTranTypeO"] = "OI";
            //}
            //else
            //{
            //    Session["StrTranTypeO"] = Session["StrTranType"].ToString();
            //}
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
                    btndelete.Attributes["onClick"] = "return confirm('Are you sure you want to delete this Details?');";
                    txtjob.Focus();
                    ShowNoResultFound(dt, grd);
                    txtex.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'EX-Rate')");
                    txtrate.Attributes.Add("onkeypress", "return validateFloatKeyPress(this,event,'Rate')");
                    UserRights();
                    UserRights4process();
                    txtamount.Enabled = true;
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

                    headerlabel.InnerText = ddl_voutype.SelectedItem.Text;
                    FillOnPageLoad();
                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Yellow;
                    btndelete.Click += btndelete_Click;
                    btndelete.OnClientClick = @"return getConfirmationValue();";
                    // txtref.Focus();

                    UserRights();
                    UserRights4process();
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



                        txtVendorRefnodate.Text = Logobj.GetDate().ToShortDateString();
                        txtVendorRefnodate.Text = Utility.fn_ConvertDate(txtVendorRefnodate.Text);


                    }
                    if (Request.QueryString.ToString().Contains("app3"))
                    {
                        ddl_voutype.SelectedValue = "5";
                        // ddl_voutype_SelectedIndexChanged(sender, e);
                        txtjob.Text = Request.QueryString["jobno"].ToString();
                        hf_branchid.Value = Session["LoginBranchid"].ToString();
                        hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                        txtjob_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("appFI3"))
                    {
                        ddl_voutype.SelectedValue = "5";
                        txtjob.Text = Request.QueryString["jobno"].ToString();
                        //   ddl_voutype_SelectedIndexChanged(sender, e);
                        hf_branchid.Value = Session["LoginBranchid"].ToString();
                        hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                        txtjob_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("appAE3"))
                    {
                        ddl_voutype.SelectedValue = "5";
                        txtjob.Text = Request.QueryString["jobno"].ToString();
                        //  ddl_voutype_SelectedIndexChanged(sender, e);
                        hf_branchid.Value = Session["LoginBranchid"].ToString();
                        hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                        txtjob_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("appAI3"))
                    {
                        ddl_voutype.SelectedValue = "5";
                        txtjob.Text = Request.QueryString["jobno"].ToString();
                        //   ddl_voutype_SelectedIndexChanged(sender, e);
                        hf_branchid.Value = Session["LoginBranchid"].ToString();
                        hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                        txtjob_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("jobnonew1"))
                    {
                        txtjob.Text = Request.QueryString["jobnonew1"].ToString();
                        hf_branchid.Value = Session["LoginBranchid"].ToString();
                        hf_divisionid.Value = Session["LoginDivisionId"].ToString();
                        txtjob_TextChanged(sender, e);
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
                    if (Request.QueryString.ToString().Contains("voutype"))
                    {
                        ddl_voutype.SelectedValue = Request.QueryString["voutype"].ToString();
                        Dropdownlist1_SelectedIndexChanged(sender, e);
                        txtref.Text = Request.QueryString["1refno"].ToString();
                        hf_branchid.Value = Session["LoginBranchid"].ToString();
                        //txtblno.Text = Request.QueryString["mblno"].ToString();
                        txtref_TextChanged(sender, e);
                        //chkmbl.Checked = true;
                        //chkmbl_CheckedChanged(sender, e);
                        //txtblno_TextChanged(sender, e);
                    }
                    if (Request.QueryString.ToString().Contains("rptvtype"))
                    {
                        ddl_voutype.SelectedValue = Request.QueryString["rptvtype"].ToString();
                        //  ddl_voutype_SelectedIndexChanged(sender, e);
                        txtref.Text = Request.QueryString["rptrefno"].ToString();
                        hf_branchid.Value = Session["LoginBranchid"].ToString();

                        txtref_TextChanged(sender, e);
                        btnview_Click(sender, e);
                        Response.Redirect("../Reportasp/OverseasVouchersrpt.aspx?" + Session["OSstring"].ToString(), false);

                        //chkmbl.Checked = true;
                        //chkmbl_CheckedChanged(sender, e);
                        //txtblno_TextChanged(sender, e);
                    }

                    btncancel.ToolTip = "Back";
                    btncancel1.Attributes["class"] = "btn ico-back";

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
                }
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
                    if (dtr.Rows[i]["uicaption"].ToString() == "Proforma OSSI")
                    {
                        ddl_voutype.Items.Add(new ListItem("Proforma OSSI", "5"));

                    }
                    if (dtr.Rows[i]["uicaption"].ToString() == "Proforma OSPI")
                    {
                        ddl_voutype.Items.Add(new ListItem("Proforma OSPI", "6"));

                    }

                   

                }

            }
            if (ddl_voutype.Items.Count == 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "Checklist", "alertify.alert('You have no Rights For Proforma Creation');", true);
                txtref.Focus();
                return;
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
            DataTable objDt = new DataTable();
            string str_bl = "";

            if (strTranType == "FE" || strTranType == "FI")
            {
                if (strTranType == "FE")
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
            else if (strTranType == "AE" || strTranType == "AI")
            {
                if (strTranType == "AE")
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
            dtCharge = chargeobj.GetLikeCurrency4OS(prefix, Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
            List_Result = Utility.Fn_TableToList(dtCharge, "currency", "currency");
            return List_Result;
        }

        [WebMethod]
        public static List<string> GetCustomer_DNCN(string prefix, string ChkType)
        {

            List<string> List_Result = new List<string>();
            DataTable obj_dt = new DataTable();
            DataAccess.Masters.MasterCustomer da_obj_Customer = new DataAccess.Masters.MasterCustomer();

            string Ccode = HttpContext.Current.Session["Ccode"].ToString();
            da_obj_Customer.GetDataBase(Ccode);
            obj_dt = da_obj_Customer.GetLikeCustomertype4OSSIPI(prefix.ToUpper(), Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString()));
            List_Result = Utility.Fn_DatatableToList_int32(obj_dt, "customer", "customerid");

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
                cmbbase.Items.Clear();
                if (Convert.ToDateTime(Utility.fn_ConvertDate(dtdate.Text)) >= Convert.ToDateTime(Session["hid_gstdate"].ToString()))
                {

                }
                else
                {
                    cmbbill.Items.Add("ST/GST Exemption");
                }

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

        protected void btn_uploadpopup_Click(object sender, EventArgs e)
        {
            if (txtref.Text == "")
            {
                ScriptManager.RegisterStartupScript(btn_uploadpopup, typeof(Button), "Checklist", "alertify.alert('Kindly Enter the Reference # ');", true);
                txtref.Focus();
                return;
            }

            string a = "";
            hf_updoc.Value = "Y";
            a = hf_updoc.Value.ToString();
            iframe_outstd.Attributes["src"] = "../ShipmentDetails/UploadDocument.aspx?&a=" + hf_updoc.Value;
            this.popup_uploaddoc.Show();

            Session["txtjobno"] = txtjobno.Value;
            Session["hf_txtrefno"] = txtref.Text;
            Session["vouno"] = null;
        }

        //public void getFEI()
        //{
        //    try
        //    {
        //        useit();
        //        if (strTranType == "FE")
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
        //                        cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                    }
        //                    Session["DtConDetails"] = DtConDetails;
        //                }
        //                //lstcon.Items.Clear();
        //                //DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
        //                //if (DtCon.Rows.Count > 0)
        //                //{
        //                //    for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
        //                //    {
        //                //        lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
        //                //        cmbbase.Items.Add(DtCon.Rows[i][1].ToString());
        //                //    }
        //                //}

        //                DtCon = FEJobobj.GetFEJobInfo(Convert.ToInt32(txtjobno.Value), branchid, divisionid);
        //                if (DtCon.Rows.Count > 0)
        //                {
        //                    vessel = DtCon.Rows[0][3].ToString();
        //                    voyage = DtCon.Rows[0][7].ToString();
        //                    eta = Convert.ToDateTime(DtCon.Rows[0][9].ToString());
        //                    hid_mloid.Value = DtCon.Rows[0]["mloid"].ToString();
        //                    txtvessel.Text = txtjobno.Value + "/" + vessel + "/" + voyage + "/" + eta.ToShortDateString();
        //                    lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();

        //                    txtmlo.Text = DtCon.Rows[0][6].ToString();

        //                    txtagent.Text = DtCon.Rows[0][5].ToString();
        //                    agent = DtCon.Rows[0][14].ToString();
        //                    txtdes.Text = DtCon.Rows[0][4].ToString();
        //                    jobtype = DtCon.Rows[0][13].ToString();
        //                }
        //                lstcon.Items.Clear();
        //                DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
        //                if (DtCon.Rows.Count > 0)
        //                {
        //                    lstcon.Items.Add(lbljobDtls.Text);
        //                    for (int i = 0; i <= DtCon.Rows.Count - 1; i++)
        //                    {
        //                        lstcon.Items.Add(DtCon.Rows[i][1].ToString() + " Container," + DtCon.Rows[i][0].ToString());
        //                        cmbbase.Items.Add(DtCon.Rows[i][1].ToString());
        //                    }
        //                }

        //                string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
        //                txtAllDetails.Text = AllDetails;

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
        //                        lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();
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

        //                    string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
        //                    txtAllDetails.Text = AllDetails;

        //                    DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, branchid);
        //                    if (DtConDetails.Rows.Count > 0)
        //                    {
        //                        for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
        //                        {
        //                            lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                            cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                        }
        //                        Session["DtConDetails"] = DtConDetails;
        //                        volume = DtConDetails.Rows[0][1].ToString();
        //                        lstvol.Items.Add(volume + " cbm");
        //                        wt = DtConDetails.Rows[0][2].ToString();
        //                        lstvol.Items.Add(wt + " Kgs");
        //                    }
        //                    lstcon.Items.Clear();
        //                    DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, strTranType, branchid);
        //                    if (DtInfo.Rows.Count > 0)
        //                    {
        //                        lstcon.Items.Add(lbljobDtls.Text);
        //                        for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
        //                        {
        //                            lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
        //                            cmbbase.Items.Add(DtInfo.Rows[i][1].ToString());
        //                        }
        //                    }

        //                }
        //            }
        //        }

        //        else
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
        //                    lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();

        //                    txtmlo.Text = DtInfo.Rows[0][6].ToString();
        //                    agent = DtInfo.Rows[0][7].ToString();
        //                    jobtype = DtInfo.Rows[0][8].ToString();
        //                    txtagent.Text = DtInfo.Rows[0][5].ToString();
        //                    txtdes.Text = DtInfo.Rows[0][4].ToString();
        //                    DtCon = INVOICEobj.GetFIMblNContainers(txtjobno.Value, branchid);
        //                    if (DtCon.Rows.Count > 0)
        //                    {
        //                        lstcon.Items.Add(lbljobDtls.Text);

        //                        for (i = 0; i <= DtCon.Rows.Count - 1; i++)
        //                        {
        //                            lstcon.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());
        //                            cmbbase.Items.Add(DtCon.Rows[i][0].ToString());

        //                        }
        //                    }
        //                    DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjobno.Value), txtjobno.Value, strTranType, branchid);
        //                    if (DtConDetails.Rows.Count > 0)
        //                    {
        //                        for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
        //                        {
        //                            lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                            cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
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
        //                    lbljobDtls.Text = txtjobno.Value + " / " + vessel + " / " + voyage + " / " + eta.ToShortDateString();

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
        //                string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
        //                txtAllDetails.Text = AllDetails;

        //            }


        //            DtConDetails = INVOICEobj.GetHBLContainerDtls(txtblno.Text, strTranType, branchid);
        //            if (DtConDetails.Rows.Count > 0)
        //            {
        //                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
        //                {
        //                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                    cmbbase.Items.Add(DtConDetails.Rows[i][0].ToString());
        //                }
        //                Session["DtConDetails"] = DtConDetails;
        //                volume = INVOICEobj.GetVolume(txtblno.Text, strTranType, branchid).ToString();
        //                lstvol.Items.Add(volume + " cbm");
        //                wt = INVOICEobj.GetWeight(txtblno.Text, strTranType, branchid).ToString();
        //                lstvol.Items.Add(wt + " Kgs");
        //                lstcon.Items.Clear();
        //                DtInfo = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjobno.Value), txtblno.Text, strTranType, branchid);
        //                if (DtInfo.Rows.Count > 0)
        //                {
        //                    lstcon.Items.Add(lbljobDtls.Text);

        //                    for (i = 0; i <= DtInfo.Rows.Count - 1; i++)
        //                    {
        //                        lstcon.Items.Add(DtInfo.Rows[i][0].ToString() + " Container," + DtInfo.Rows[i][1].ToString());
        //                        cmbbase.Items.Add(DtInfo.Rows[i][1].ToString());
        //                    }
        //                }

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
        //                lbljobDtls.Text = txtjobno.Value + " / " + DtInfo.Rows[0][2].ToString() + " / " + eta.ToShortDateString();
        //                txtmlo.Text = DtInfo.Rows[0][5].ToString();
        //                txtagent.Text = DtInfo.Rows[0][4].ToString();
        //                agent = DtInfo.Rows[0][6].ToString();
        //                txtdes.Text = DtInfo.Rows[0][3].ToString();
        //                gross = DtInfo.Rows[0][7].ToString();
        //                chwt = DtInfo.Rows[0][8].ToString();
        //            }
        //            string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
        //            txtAllDetails.Text = AllDetails;

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
        //                lbljobDtls.Text = txtjobno.Value + " / " + DtInfo.Rows[0][2].ToString() + " / " + eta.ToShortDateString();
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
        //            string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
        //            txtAllDetails.Text = AllDetails;

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
        //            lbljobDtls.Text = txtjobno.Value + " / " + Dt.Rows[0][2].ToString() + " / " + eta.ToShortDateString();
        //            txtmlo.Text = Dt.Rows[0][8].ToString();
        //            txtagent.Text = Dt.Rows[0][7].ToString();
        //            agent = Dt.Rows[0][9].ToString();
        //            txtdes.Text = Dt.Rows[0][6].ToString();
        //            jobtype = Dt.Rows[0][10].ToString();
        //            jobtype = "0";

        //        }
        //        string AllDetails = "Shipper : " + txtshipper.Text + System.Environment.NewLine + "Consignee : " + txtconsignee.Text + System.Environment.NewLine + "Notify Party : " + txtnotify.Text + System.Environment.NewLine + "Agent : " + txtagent.Text + System.Environment.NewLine + "MLO : " + txtmlo.Text + System.Environment.NewLine + "CNF : " + txtcnf.Text;
        //        txtAllDetails.Text = AllDetails;

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

        protected void cmbbl_SelectedIndexChanged(object sender, EventArgs e)
        {

            lstvol.Items.Clear();
            float volume, wt;
            string mblno = "";
            strTranType = Session["StrTranTypeFA"].ToString();
            DataTable DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtjob.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            DtCon = INVOICEobj.GetHblNoOfContainers(Convert.ToInt32(txtjob.Text), cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
            if (DtCon.Rows.Count > 0)
            {
                for (i = 0; i <= DtCon.Rows.Count - 1; i++)
                {
                    lstvol.Items.Add(DtCon.Rows[i][0].ToString() + " Container," + DtCon.Rows[i][1].ToString());
                }
            }

            if (cmbbl.SelectedItem.ToString() == mblno)
            {
                DtConDetails = INVOICEobj.GetMblContainerDtls(Convert.ToInt32(txtjob.Text), txtjob.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                {
                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                }
            }
            else
            {
                DtConDetails = INVOICEobj.GetHBLContainerDtls(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                for (i = 0; i <= DtConDetails.Rows.Count - 1; i++)
                {
                    lstvol.Items.Add(DtConDetails.Rows[i][0].ToString());
                }

                volume = INVOICEobj.GetVolume(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                lstvol.Items.Add(volume + " cbm");
                wt = INVOICEobj.GetWeight(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                lstvol.Items.Add(wt + " Kgs");
            }

        }


        public void txtclear()
        {
            cmbbill.SelectedIndex = 0;
            cmbbl.SelectedIndex = 0;
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
            lstcon.Text = "";
            grd.DataSource = null;
            grd.DataBind();
            txtjob.Text = "";
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
            cmbbl.SelectedItem.Text = "";
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
            lstcon.Text = "";
            grd.DataSource = null;
            grd.DataBind();

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
            cmbbl.SelectedIndex = -1;
            btnadd.ToolTip = "Add";
            btnadd1.Attributes["class"] = "btn ico-add";
            txtcharge.Enabled = true;
            cmbbase.Enabled = true;
        }
        public void txtDisable()
        {
            cmbbill.Enabled = false;
            // cmbbl.SelectedItem.Text = "";
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
            //if (cmbbill.SelectedIndex == 0)
            //{
            //    ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Bill type cannot be blank');", true);

            //    cmbbill.Focus();
            //    blnerr = true;
            //    return;
            //}

            //if (chkmbl.Checked == true)
            //{
            //    if (cmbbill.Text == "Profit Share")
            //    {
            //        ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Profit Share should not be Used for MBL#');", true);

            //        cmbbill.Focus();
            //        blnerr = true;
            //        return;
            //    }
            //}
        }

        //protected void cmbbill_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (txtblno.Text != "")
        //    {
        //        Session["cmbbill"] = cmbbill.SelectedItem.Text;
        //    }

        //    try
        //    {
        //        strTranType = Session["StrTranType"].ToString();
        //        // frmname = Request.QueryString["type"].ToString();
        //        branchid = Convert.ToInt32(HttpContext.Current.Session["LoginBranchid"].ToString());
        //        divisionid = Convert.ToInt32(HttpContext.Current.Session["LoginDivisionId"].ToString());
        //        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        //        DataTable DtDetails = new DataTable();
        //        string bookingno;
        //        int intcustomerid4DO;

        //        if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
        //        {
        //            if (cmbbill.SelectedValue == "Credit")
        //            {
        //                txtcreditapp1.Text = "";
        //                txtcreditapp1.Enabled = true;
        //                bookingno = FIBLobj.GetBookinkNo(txtblno.Text.ToUpper(), branchid, divisionid);
        //                DtDetails = FEBLobj.GetBookingDt(bookingno, branchid, divisionid);
        //                if (DtDetails.Rows.Count > 0)
        //                {
        //                    intcustomerid4DO = Convert.ToInt32(DtDetails.Rows[0][13].ToString());
        //                }
        //                txtcreditapp1.Text = "Not Updated";

        //            }
        //            else
        //            {
        //                txtcreditapp1.Text = "";
        //                txtcreditapp1.Enabled = false;
        //            }

        //        }
        //        else
        //        {
        //            txtcreditapp1.Text = "";
        //            txtcreditapp1.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message.ToString();
        //        ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
        //    }

        //}

        protected void txtto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string a = hdncityid.Value;
                int cityid; string address;
                int int_divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = Session["StrTranTypeFA"].ToString();
                int int_custid = Convert.ToInt32(hdncustid.Value);
                string sezcus = "";
               // DataAccess.Masters.MasterCustomer obj_da_mc = new DataAccess.Masters.MasterCustomer();

                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Voucher Type');", true);
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

                    if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                    {
                        sezcus = customerobj.getsezcustid(int_custid);
                        if (sezcus == "Y")
                        {
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  Once again update the chargedetails because this sez customer');", true);
                            if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                            {
                                switch (Session["StrTranTypeFA"].ToString())
                                {
                                    case "FE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeFA"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "FI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeFA"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AE":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeFA"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "AI":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeFA"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                    case "CH":
                                        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 2, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranTypeFA"].ToString() + "customername :" + txtto.Text + "SEZ:" + sezcus + "/changed");
                                        break;
                                }
                            }
                        }

                    }

                    //DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
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
                        ScriptManager.RegisterStartupScript(txtto, typeof(Button), "DataFound", "alertify.alert('Customer name or Bill from  cannot be Blank')", true);
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
                    //DataAccess.Accounts.ProfomaInvoice obj_da_head = new DataAccess.Accounts.ProfomaInvoice();


                    //string str_blno, str_custname; int custid;
                    //obj_dt_head = obj_da_head.CheckProinvCustblno(txtblno.Text, int_custid, str_TranType, int_branchid, Convert.ToInt32(txtvouyear.Text), hf_strtype.Value);
                    //if (obj_dt_head.Rows.Count > 0)
                    //{
                    //    str_blno = obj_dt_head.Rows[0][5].ToString();
                    //    custid = Convert.ToInt32(obj_dt_head.Rows[0][4].ToString());
                    //    cstid.Value = custid.ToString();
                    //    str_custname = obj_da_mc.GetCustomername(custid);
                    //    if (txtblno.Text == str_blno && txtto.Text == str_custname)
                    //    {

                    //        ViewState["obj_dt_head"] = obj_dt_head;
                    //        pnlConfirm.Attributes["class"] = "popupconfirmnew";

                    //        popupconfirmnew.Show();

                    //        return;
                    //    }
                    //    else
                    //    {
                    //        //btnsave.Text = "Save";

                    //        btnsave.ToolTip = "Save";
                    //        btnsave1.Attributes["class"] = "btn ico-save";
                    //    }
                    // }

                    //else
                    //{
                    //    if (int_custid != 0)
                    //    {
                    //        DataAccess.Corporate obj_da_corpobj = new DataAccess.Corporate();
                    //        if (obj_da_corpobj.GetGroupID(int_custid, int_divisionid) != 0)
                    //        {
                    //            if (obj_da_mc.CheckCreditAmount(int_custid, int_branchid, int_divisionid) > 0)
                    //            {
                    //                ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alertify.alert('" + obj_da_mc.GetCustomername(int_custid) + " has already reached the credit limit rupees " + obj_da_mc.GetCreditAmount(int_custid, int_divisionid) + "');", true);
                    //            }
                    //        }
                    //    }

                    //    grd.DataSource = Utility.Fn_GetEmptyDataTable();
                    //    grd.DataBind();
                    //    txtref.Text = "";
                    //    txtremarks.Text = "";
                    //}
                }
                UserRights();
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
                    if (Session["LoginDivisionId"] != null)
                    {
                        divisionid = Convert.ToInt32(Session["LoginDivisionId"].ToString());
                    }
                    if (Session["LoginBranchid"] != null)
                    {
                        branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                    }

                    Label8.Text = "Vendor Ref #";
                    Label9.Text = "Vendor Ref Date";

                    txtclear();
                    txtEnable();
                    btnadd.Enabled = false;
                    btnadd.ForeColor = System.Drawing.Color.Gray;
                    btnsave.Text = "Save";

                    btnsave.ToolTip = "Save";
                    btnsave1.Attributes["class"] = "btn ico-save";
                    btnsave.Text = "Save";
                   // //btncancel.Text = "Back";

                    btncancel.ToolTip = "Back";
                    btncancel1.Attributes["class"] = "btn ico-back";
                    //  txtblno.Focus();
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
            }


        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            //DataAccess.LogDetails da_obj_logobj = new DataAccess.LogDetails();
            //DataAccess.Accounts.OSDNCN da_obj_OSDNCN = new DataAccess.Accounts.OSDNCN();
            int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
            DataTable dtacc = new DataTable();

            useit();
            Session["LoginEmpId"] = Session["LoginEmpId"].ToString();
            int empid = Convert.ToInt32(Session["LoginEmpId"]);
            if (ddl_voutype.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Voucher Type');", true);
                ddl_voutype.Focus();
                return;
            }
            DataTable dtgst;
            //dtgst = ProINVobj.Checksamegst4Proforma(branchid, Convert.ToInt32(hdncustid.Value));
            //if (dtgst.Rows.Count > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Branch and customer GST should not co-exists!!');", true);
            //    txtto.Focus();
            //    return;
            //}

            //if (txtCreditDays.Text == "")
            //{
            //    txtCreditDays.Text = "0";
            //}
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                txtjob.Text = "";
                return;
            }
            CheckData();
            strTranType = ddl_product.SelectedValue;


            if (txtVendorRefno.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter the  VendorRefno');", true);
                txtVendorRefno.Focus();
                blnerr = true;
                return;
            }

            if (txtVendorRefnodate.Text == "")
            {


                ScriptManager.RegisterStartupScript(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the  VendorRef Date');", true);
                txtVendorRefnodate.Focus();
                blnerr = true;
                return;
            }
            //if (txtVendorRefno.Text.Trim() != "")
            //{
            //    DataTable dtacc1 = new DataTable();
            //    dtacc1 = ProINVobj.Checkvenrefno(txtVendorRefno.Text);
            //    if (dtacc1.Rows.Count > 0)
            //    {
            //        ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alertify.alert('Vendor Ref # Already Exists..');", true);
            //        txtVendorRefno.Focus();
            //        return;
            //    }
            //}



            if (blnerr == true)
            {
                blnerr = false;
                return;
            }




            if (hid_SupplyTo.Value == "0" || hid_SupplyTo.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Enter Supply From');", true);
                return;
            }
            try
            {

                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Voucher Type');", true);
                    ddl_voutype.Focus();
                    return;
                }

                if ((INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjob.Text), branchid)) == 1 && Session["StrTranType"].ToString() != "AC")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtjobno.Value + " has Closed Already...You Can not create a Voucher');", true);
                    return;

                }
                if ((INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjob.Text), branchid)) == 0 && Session["StrTranType"].ToString() == "AC")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job # " + txtjobno.Value + " is still open...You Can not create a Voucher here');", true);
                    return;

                }
                if (btnsave.ToolTip == "Save")
                {
                    if (txtref.Text != "")
                    {
                        return;
                    }





                    Refno = da_obj_OSDNCN.InsproOSvouchershead(Convert.ToDateTime(Utility.fn_ConvertDatetime(dtdate.Text)), Session["StrTranTypeO"].ToString(), Convert.ToDouble(amount),
                                            Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hdncustid.Value),
                                            Convert.ToInt32(Session["LoginEmpId"].ToString()), Convert.ToInt32(txtvouyear.Text), txtVendorRefno.Text.ToUpper(), 0,
                                            Convert.ToInt32(hid_SupplyTo.Value), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()), Convert.ToInt32(ddl_voutype.SelectedValue), txtremarks.Text, txtdes.Text);


                    txtref.Text = Refno.ToString();

                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Ref # " + txtref.Text + " Generated.Kindly insert charge details.. ');", true);

                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10085, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ SAVE");
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10091, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ SAVE");
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10092, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ SAVE");
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10093, 1, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ SAVE");
                            break;

                    }



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

                    dtcheck = new DataTable();
                    dtcheck = INVOICEobj.GetCheckApprovedProfomaLV(Convert.ToInt32(txtref.Text), branchid, Convert.ToInt32(txtvouyear.Text), strTranType, Convert.ToInt32(ddl_voutype.SelectedValue), "HeadUpdate");
                    if (dtcheck.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Update Denied, Already Approved for Ref# " + txtref.Text + "');", true);
                        return;
                    }
                    else
                    {
                        if (Convert.ToInt32(hdncustid.Value) != 0)
                        {
                            da_obj_OSDNCN.UpdOSVhead(Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"].ToString()), Session["StrTranTypeO"].ToString(),
                                Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(hid_SupplyTo.Value), Convert.ToInt32(txtref.Text), Convert.ToInt32(hdncustid.Value), txtVendorRefno.Text.ToUpper(), DateTime.Parse(Utility.fn_ConvertDatetime(txtVendorRefnodate.Text).ToString()));


                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated for Ref# " + txtref.Text + "');", true);
                            switch (ddl_product.SelectedValue)
                            {
                                case "FE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10085, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ UPD");
                                    break;
                                case "FI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10091, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ UPD");
                                    break;
                                case "AE":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10092, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ UPD");
                                    break;
                                case "AI":
                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"].ToString()), 10093, 2, Convert.ToInt32(Session["LoginBranchid"].ToString()), ddl_product.SelectedValue + Convert.ToString(txtjob.Text) + "/" + lbl.Text + "/ UPD");
                                    break;

                            }
                        }
                    }

                }
                txtDisable();
                btnadd.Enabled = true;
                btnadd.ForeColor = System.Drawing.Color.White;
                txtcharge.Focus();

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

            DtInfo = new DataTable();
            DtInfo = OSDNCN.GetOSVdetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(ddl_voutype.SelectedValue), branchid);
            grd.DataSource = DtInfo;
            grd.DataBind();

            txtTotal.Text = "";
            double tot = 0, tot1 = 0;

            for (i = 0; i <= grd.Rows.Count - 1; i++)
            {
                if (grd.Rows[i].Cells[9].Text == "")
                {
                    grd.Rows[i].Cells[9].Text = "0";
                }

                tot1 = Convert.ToDouble(grd.Rows[i].Cells[9].Text);
                tot = tot + tot1;
            }
            txtTotal.Text = tot.ToString("#,0.00");


        }

        public void useit()
        {
            try
            {
                strTranType = ddl_product.SelectedValue;
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
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);

            }
            //btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtref_TextChanged(object sender, EventArgs e)
        {
            try
            {
                useit();
                //if (ddl_voutype.SelectedItem.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Voucher Type');", true);
                //    ddl_voutype.Focus();
                //    return;
                //}


                type = ddl_voutype.SelectedItem.Text;
                hf_strtype.Value = type;

                txtclear4refno();
                if (txtref.Text != "")
                {
                    int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                    DataTable dtacc = new DataTable();
                    DtSHead = OSDNCN.GetOSVhead(Convert.ToInt32(txtref.Text), Convert.ToInt32(ddl_voutype.SelectedValue), branchid, Session["StrTranTypeO"].ToString());

                    if (DtSHead.Rows.Count > 0)
                    {
                        ddl_voutype.SelectedValue= DtSHead.Rows[0]["voutype"].ToString();
                        txtjobno.Value = DtSHead.Rows[0]["jobno"].ToString();
                        txtjob.Text = DtSHead.Rows[0]["jobno"].ToString();
                        hdncustid.Value = DtSHead.Rows[0]["customer"].ToString();
                        txtto.Text = DtSHead.Rows[0]["customername"].ToString();
                        txtremarks.Text = DtSHead.Rows[0]["remarks"].ToString();
                        txtdes.Text = DtSHead.Rows[0]["originname"].ToString();
                        if (INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 1 && Session["StrTranType"].ToString() != "AC")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has Closed Already You Can not Modify the Voucher here');", true);
                            txtclear();
                            txtjob.Focus();
                            return;

                        }
                        if (INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 0 && Session["StrTranType"].ToString() == "AC")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job is still open , You Can not Modify the Voucher here..');", true);
                            txtclear();
                            txtjob.Focus();
                            return;

                        }



                        hdnfatransfer.Value = DtSHead.Rows[0]["fatransfer"].ToString();
                        dtdate.Text = DtSHead.Rows[0]["voudate"].ToString();
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
                        DataTable dtt = OSDNCN.SPGetOSVjobdetails(Convert.ToInt32(txtjob.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        if (dtt.Rows.Count > 0)
                        {
                            if (strTranType == "FE" || strTranType == "FI")
                            {
                                lstcon.Text = "Vessel / Voyage  :  " + dtt.Rows[0][5].ToString().Trim() + "  /  " + dtt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dtt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dtt.Rows[0][8].ToString() + "  /  " + dtt.Rows[0][9].ToString();


                            }
                            else
                            {
                                lstcon.Text = "Flight # / Date  :  " + dtt.Rows[0][5].ToString().Trim() + "  /  " + dtt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dtt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dtt.Rows[0][8].ToString() + "  /  " + dtt.Rows[0][9].ToString();


                            }

                            Dt = DAdvise.FillBLNo(Convert.ToInt32(txtjob.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));

                            if (strTranType == "FE" || strTranType == "FI")
                            {

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

                            grdfill();
                            txtTotal.Text = "";
                            double tot = 0, tot1 = 0;
                            for (i = 0; i <= grd.Rows.Count - 1; i++)
                            {
                                tot1 = Convert.ToDouble(grd.Rows[i].Cells[9].Text);
                                tot = tot + tot1;
                            }
                            txtTotal.Text = tot.ToString("#,0.00");
                            btnsave.Text = "Update";
                            //btncancel.Text = "Cancel";


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
                    }
                    else
                    {

                        dtref = INVOICEobj.Checkrefid4ProLV(Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text), branchid, Convert.ToInt32(ddl_voutype.SelectedValue));
                        if (dtref.Rows.Count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Already Transferred');", true);
                            txtref.Text = "";
                            txtref.Focus();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(btnsave, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Invalid Ref #');", true);
                            txtref.Text = "";
                            txtref.Focus();
                        }

                    }



                    UserRights();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('" + message + "');", true);
                txtref.Text = "";
                txtref.Focus();
            }
            //btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
        }

        protected void txtjob_TextChanged(object sender, EventArgs e)
        {
            if (ddl_product.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alert('Please Select the Product Type');", true);
                ddl_product.Focus();
                txtjob.Text = "";
                return;
            }
            if (ddl_voutype.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly select the voucher type');", true);
                return;
            }
            if (INVOICEobj.CheckClosedJobs(ddl_product.SelectedValue, Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 1 && Session["StrTranType"].ToString() != "AC")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has Closed Already You Can not Create a Voucher');", true);
                txtclear();
                txtjob.Focus();
                return;

            }
            else if (INVOICEobj.CheckClosedJobs(ddl_product.SelectedValue, Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 0 && Session["StrTranType"].ToString() == "AC")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job is still Open. You Can not Create a Voucher Here..');", true);
                txtclear();
                txtjob.Focus();
                return;

            }
            strTranType = ddl_product.SelectedValue;

            Dt = DAdvise.FillBLNo(Convert.ToInt32(txtjob.Text), ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));
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

            DataTable dtt = OSDNCN.SPGetOSVjobdetails(Convert.ToInt32(txtjob.Text), ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));
            if (dtt.Rows.Count > 0)
            {


                hid_SupplyTo.Value = dtt.Rows[0]["agentid"].ToString();
                txtsupplyto.Text = dtt.Rows[0]["customername"].ToString();
                string citysupplyid = customerobj.GetCustlocation(Convert.ToInt32(hid_SupplyTo.Value));
                txtsupplytoAddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                txtaddress.Text = customerobj.GetCustomerAddress(txtsupplyto.Text.Trim(), "C", citysupplyid);
                txtto.Text = txtsupplyto.Text;
                hdncustid.Value = dtt.Rows[0]["agentid"].ToString();
                if (strTranType == "FE" || strTranType == "FI")
                {
                    lstcon.Text = "Vessel / Voyage  :  " + dtt.Rows[0][5].ToString().Trim() + "  /  " + dtt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dtt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dtt.Rows[0][8].ToString() + "  /  " + dtt.Rows[0][9].ToString();


                }
                else
                {
                    lstcon.Text = "Flight # / Date  :  " + dtt.Rows[0][5].ToString().Trim() + "  /  " + dtt.Rows[0][6].ToString() + Environment.NewLine + "MBL #  :  " + dtt.Rows[0][7].ToString() + Environment.NewLine + "PoL/PoD  :  " + dtt.Rows[0][8].ToString() + "  /  " + dtt.Rows[0][9].ToString();


                }
            }
            DataTable dtOSDN = new DataTable();
            DataTable dtOSCN = new DataTable();
            DataSet DtVal = new DataSet();
            DataTable dtOSDNPro = new DataTable();
            DataTable dtOSCNPro = new DataTable();
            DtVal = DAdvise.SPGetDtls4osdcnForAgentOSV(Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString());
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
                Response.Redirect("../Accounts/OSVouchers.aspx?Tjobno=" + jobno + "&Tnew=" + ddl_voutype.SelectedValue + "&jobno1=" + jobno1);
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
        protected void btnAdd_OneOrMore_Click(object sender, EventArgs e)
        {
            popup_Grd.Hide();
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

        protected void grd_prodetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grd_prodetails.Rows.Count > 0)
            {
                string name = "";
                int index = grd_prodetails.SelectedRow.RowIndex;
                int jobno = Convert.ToInt32(grd_prodetails.Rows[index].Cells[0].Text);
                name = grd_prodetails.Rows[index].Cells[3].Text;
                txtref.Text = jobno.ToString();

                int jobno1 = Convert.ToInt32(grd_prodetails.Rows[index].Cells[1].Text);

                txtjob.Text = jobno1.ToString();
                if (name == "OSSI")
                {
                    ddl_voutype.SelectedValue = "5";

                }
                else if (name == "OSPI")
                {
                    ddl_voutype.SelectedValue = "6";
                }
                Dropdownlist1_SelectedIndexChanged(sender, e);
                txtref_TextChanged(sender, e);
            }
        }


        protected void btnadd_Click(object sender, EventArgs e)
        {
            
            try
            {
                int count = 0;
                int int_Empid = Convert.ToInt32(Session["LoginEmpId"].ToString());
                DataTable dtacc = new DataTable();

                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Voucher Type');", true);
                    ddl_voutype.Focus();
                    return;
                }
                strTranType = ddl_product.SelectedValue;
                 DataTable DtCHeckNew = new DataTable();
               
                DtCHeckNew = OSDNCN.GetCheckcloseUnclose(Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchId"].ToString()), strTranType);
                if (DtCHeckNew.Rows.Count > 0 && Session["StrTranType"].ToString() != "AC")
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has been already closed.So you cannot add Charges');", true);
                    return;
                }
                if (DtCHeckNew.Rows.Count == 0 && Session["StrTranType"].ToString() == "AC")
                {
                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job is still open.So you cannot add Charges here.');", true);
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
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Select Base ');", true);
                        txtcurr.Focus();
                        return;
                    }
                    if (cmbbl.SelectedItem.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Please Select Base');", true);
                        cmbbl.Focus();
                        return;
                    }
                    cmbbase_SelectedIndexChanged(sender, e);

                     
                    try
                    {
                        if (txtamount.Text != "0")
                        {



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
                                            //ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Exrate Different kindly check with  " + txtcharge.Text + " .');", true);

                                            ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Different  Exrate is not allowed for same Currency,Kindly check Exrate for " + txtcurr.Text + ".');", true);
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




                                CheckChargeBase();
                                if (chargename > 0 && cbase > 0)
                                {
                                    //GrdLoad(ddlDebiteOrCredite.SelectedValue);
                                    ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charge Already Exists');", true);
                                    cmbbase.Focus();
                                    return;

                                }

                                else
                                {
                                    chargename = 0;
                                    if (txtcharge.Text != "" && txtrate.Text != "" && txtex.Text != "" && txtcurr.Text != "" && cmbbase.Text != "" && txtamount.Text != "")
                                    {

                                        DataTable dtch = DAdvise.CheckgstforOSV(Convert.ToInt32(hdnChargid.Value));
                                        if (dtch.Rows.Count == 0)
                                        {
                                            this.PopUpService.Show();
                                            return;
                                        }
                                        else
                                        {
                                            useit();
                                            if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
                                            {
                                                douvolume = Convert.ToDouble(hid_douvolume.Value);
                                            }
                                            else
                                            {
                                                douvolume = 0;
                                            }
                                            if (douvolume == 0)
                                            {
                                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount is calculated as 0 ,Base Unit details not calculated properly,Kindly select the BL/MBL again..);", true);
                                                return;
                                            }

                                            if (string.IsNullOrEmpty(hid_fd.Value) != true)
                                            {
                                                fd = Convert.ToInt32(hid_fd.Value);
                                            }
                                            else
                                            {
                                                fd = 0;
                                            }
                                            if (btnadd.ToolTip == "Add")
                                            {
                                                DAdvise.InsOSVdetails(Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), cmbbl.SelectedItem.Text,
                                                    Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text),
                                                    cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddl_voutype.SelectedValue),
                                                    Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value),
                                                    "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text));
                                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved.. ');", true);


                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                        break;
                                                    case "FI":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                        break;
                                                    case "AE":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                        break;
                                                    case "AI":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                        break;

                                                }

                                            }
                                            else
                                            {

                                                int ind = Convert.ToInt32(Session["index"]);
                                                string strbase = grd.Rows[ind].Cells[6].Text;
                                                DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text),
                                                    cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value), strbase,
                                                    Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(),
                                                    Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y",
                                                    Convert.ToInt32(txtref.Text), Convert.ToInt32(hid_SupplyTo.Value), "N");
                                                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated for Ref# " + txtref.Text + "');", true);
                                                switch (ddl_product.SelectedValue)
                                                {
                                                    case "FE":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                        break;
                                                    case "FI":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                        break;
                                                    case "AE":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                        break;
                                                    case "AI":
                                                        logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                        break;

                                                }
                                            }
                                            grdfill();
                                            // this.PopUpService.Hide();
                                            chargetxtclear();
                                            UserRights();
                                        }
                                    }
                                    /////////////////



                                    //grdfill();
                                    //txtcharge.Focus();

                                    //ScriptManager.RegisterStartupScript(btnadd, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Charges Details Saved...');", true);
                                    //txtcharge.Text = ""; txtcurr.Text = ""; txtrate.Text = ""; txtex.Text = ""; txtamount.Text = ""; cmbbase.SelectedIndex = 0;

                                }

                            }

                            else
                            {
                                if (txtcharge.Text != "" && txtrate.Text != "" && txtex.Text != "" && txtcurr.Text != "" && cmbbase.Text != "" && txtamount.Text != "")
                                {
                                    DataTable dtch = DAdvise.CheckgstforOSV(Convert.ToInt32(hdnChargid.Value));
                                    if (dtch.Rows.Count == 0)
                                    {
                                        this.PopUpService.Show();
                                        return;
                                    }
                                    else
                                    {
                                        useit();
                                        if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
                                        {
                                            douvolume = Convert.ToDouble(hid_douvolume.Value);
                                        }
                                        else
                                        {
                                            douvolume = 0;
                                        }
                                        if (douvolume == 0)
                                        {
                                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount is calculated as 0 ,Base Unit details not calculated properly,Kindly select the BL/MBL again..);", true);
                                            return;
                                        }

                                        if (string.IsNullOrEmpty(hid_fd.Value) != true)
                                        {
                                            fd = Convert.ToInt32(hid_fd.Value);
                                        }
                                        else
                                        {
                                            fd = 0;
                                        }
                                        if (btnadd.ToolTip == "Add")
                                        {
                                            DAdvise.InsOSVdetails(Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), cmbbl.SelectedItem.Text,
                                                Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text),
                                                cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddl_voutype.SelectedValue),
                                                Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value),
                                                "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text));
                                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved.. ');", true);


                                            switch (ddl_product.SelectedValue)
                                            {
                                                case "FE":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                    break;
                                                case "FI":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                    break;
                                                case "AE":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                    break;
                                                case "AI":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                                                    break;

                                            }

                                        }
                                        else
                                        {

                                            int ind = Convert.ToInt32(Session["index"]);
                                            string strbase = grd.Rows[ind].Cells[6].Text;
                                            DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text),
                                                cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value), strbase,
                                                Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(),
                                                Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y",
                                                Convert.ToInt32(txtref.Text), Convert.ToInt32(hid_SupplyTo.Value), "N");
                                            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated for Ref# " + txtref.Text + "');", true);
                                            switch (ddl_product.SelectedValue)
                                            {
                                                case "FE":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                    break;
                                                case "FI":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                    break;
                                                case "AE":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                    break;
                                                case "AI":
                                                    logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                                                    break;

                                            }
                                        }
                                        grdfill();
                                        // this.PopUpService.Hide();
                                        chargetxtclear();
                                        UserRights();
                                    }
                                }
                            }
                        }

                        
                           
                        
                        //grdfill();
                        //chargetxtclear();
                        // btnadd.Text = "Add";


                        //btnadd.ToolTip = "Add";
                        //btnadd1.Attributes["class"] = "btn ico-add";
                        //txtcharge.Enabled = true;
                        //btnadd.Enabled = false;
                        //btnadd.ForeColor = System.Drawing.Color.Gray;
                        //txtcharge.Focus();
                        //UserRights();
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
            //btncancel.Text = "Cancel";
            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";

        }
        public void CheckChargeBase()
        {
            //   strTranType = Request.QueryString["type"].ToString();
            // type = Request.QueryString["type"].ToString();

            if (txtcharge.Text != "")
            {
                if (ddl_voutype.SelectedValue == "5")
                {
                    chargename = DAdvise.GetDCChargescountAgentOSV(cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value), 5, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_SupplyTo.Value));
                    cbase = DAdvise.GetDCBasecountAgentOSV(cmbbl.SelectedItem.Text, cmbbase.Text, Convert.ToInt32(hdnChargid.Value), 5, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_SupplyTo.Value));
                }
                else
                {
                    chargename = DAdvise.GetDCChargescountAgentOSV(cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value), 6, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_SupplyTo.Value));
                    cbase = DAdvise.GetDCBasecountAgentOSV(cmbbl.SelectedItem.Text, cmbbase.Text, Convert.ToInt32(hdnChargid.Value), 6, Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(hid_SupplyTo.Value));
                }
            }
        }
protected void txtcharge_TextChanged(object sender, EventArgs e)
        {
            try
            {
              //  DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();

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
            //btncancel.Text = "Cancel";

            btncancel.ToolTip = "Cancel";
            btncancel1.Attributes["class"] = "btn ico-cancel";
        }
        //public void CheckChargeBase()
        //{
        //    useit();
        //    if (txtref.Text == "")
        //    {
        //        return;
        //    }
        //    if (txtcharge.Text != "")
        //    {
        //        dtcheck = ProINVobj.CheckchrgInvProLV(Convert.ToInt32(txtref.Text), cmbbase.Text, Convert.ToInt32(hdnChargid.Value), Convert.ToInt32(txtvouyear.Text), branchid, Convert.ToInt32(ddl_voutype.SelectedValue));
        //        if (dtcheck.Rows.Count > 0)
        //        {
        //            chargename = 1;
        //        }
        //        else
        //        {
        //            chargename = 0;
        //        }
        //    }
        //}


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

                //btnadd.Text = "Upd";



                btnadd.ToolTip = "Upd";
                btnadd.Text = "Update";
                btnadd1.Attributes["class"] = "btn ico-update";

                cmbbl.Text= grd.SelectedRow.Cells[1].Text;
                txtcharge.Text = Server.HtmlDecode(grd.SelectedRow.Cells[2].Text);
                txtcurr.Text = grd.SelectedRow.Cells[3].Text;
                txtrate.Text = grd.SelectedRow.Cells[4].Text;
                txtrate.Text = String.Format("{0:F2}", txtrate.Text);
                txtex.Text = grd.SelectedRow.Cells[5].Text;
                txtex.Text = String.Format("{0:F2}", txtex.Text);
                cmbbase.SelectedValue = grd.SelectedRow.Cells[6].Text;
                hid_cmbase.Value = grd.SelectedRow.Cells[6].Text;
                //double gsta = Convert.ToDouble(grd.SelectedRow.Cells[5].Text);
                //txtamount.Text = grd.SelectedRow.Cells[6].Text ;
                //double gstamt= Convert.ToDouble( txtamount.Text);
                // double gasttot = gstamt - gsta;
                // txtamount.Text = String.Format("{0:F2}", gasttot);
                txtamount.Text = grd.SelectedRow.Cells[7].Text;
                txtamount.Text = String.Format("{0:F2}", txtamount.Text);
                txtcharge.Enabled = false;
                hdnChargid.Value = grd.SelectedRow.Cells[10].Text;
                txtcharge.Enabled = false;
                cmbbl_SelectedIndexChanged(sender, e);
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
            DataTable DtBLNO;
            string mblno = "";
            strTranType = ddl_product.SelectedValue;
            double strgrosswght;
            int fd=0;
            double douvolume=0, volume=0, wt=0;
            DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtjob.Text), ddl_product.SelectedValue, Convert.ToInt32(Session["LoginBranchid"]));
            if (DtBLNO.Rows.Count > 0)
            {
                mblno = DtBLNO.Rows[0][0].ToString();
            }
            if (strbase == "BL" || strbase == "HWBL" || strbase == "DOC" || strbase == "FLAT RATE" || strbase == "HAWB")
            {
                if (cmbbl.SelectedItem.Text == mblno)
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
                else
                {
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }
                douvolume = 1;
                amount = rate * exrate;
                //---------------------------------------------

            }
            else if (cmbbase.Text.ToUpper() == "Volume".ToUpper())
            {
                strgrosswght = INVOICEobj.GetVolumeQty(cmbbl.SelectedItem.Text, branchid);
                amount = rate * exrate * strgrosswght;
                douvolume = strgrosswght;


            }
            else if (strbase.ToString() == "COTTON/PALLET".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (cmbbl.SelectedItem.Text.ToUpper() == mblno)
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        Double strchgpallet1 = INVOICEobj.Getchargepalletmbl(Convert.ToInt32(txtjob.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * Convert.ToDouble(strchgpallet1);
                        douvolume = Convert.ToDouble(strchgpallet);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        //fd = Convert.ToInt32(strchgpallet1);
                        //  hdnUnit.Value = strchgpallet.ToString();
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }
                    else
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgpallet = INVOICEobj.Getchargepallet(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgpallet);
                        douvolume = Convert.ToDouble(strchgpallet);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }
            }

            else if (strbase.ToString() == "PERTRUCK".ToUpper())
            {
                if (strTranType == "AE" || strTranType == "AI")
                {
                    if (cmbbl.SelectedItem.Text.ToUpper() == mblno)
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        double strchgtruck1 = INVOICEobj.Getchargetrucknew(Convert.ToInt32(txtjob.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * Convert.ToDouble(strchgtruck1);
                        douvolume = Convert.ToDouble(strchgtruck1);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        //   unit = strchgweight.ToString();
                        // fd = DCAdviseObj.GetFDFromBLNO(txt_ablno.Text, str_trantype, Convert.ToInt32(Session["LoginBranchid"]), "H");
                    }
                    else
                    {
                        //DataAccess.Accounts.DCAdvise DCAdviseObj = new DataAccess.Accounts.DCAdvise();
                        //DataAccess.Accounts.Invoice da_obj_INVOICEobj = new DataAccess.Accounts.Invoice();
                        strchgtruck = INVOICEobj.Getchargetruck(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"])).ToString();
                        amount = rate * exrate * Convert.ToDouble(strchgtruck);
                        douvolume = Convert.ToDouble(strchgtruck);
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text.ToUpper(), strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
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
                            volume = INVOICEobj.GetSumofVolume(txtjob.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            douvolume = volume;
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            amount = rate * exrate * volume;
                        }
                        else
                        {
                            volume = INVOICEobj.GetVolume(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                            douvolume = volume;
                            amount = rate * exrate * volume;
                        }
                    }
                    else
                    {
                        if (cmbbl.SelectedItem.ToString() == mblno)
                        {
                            volume = INVOICEobj.GetSumofVolume(txtjob.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
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
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                        }
                        else
                        {
                            volume = INVOICEobj.GetVolume(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
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
                            fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                        }
                    }
                }
                else
                {
                    if (strbase == "MT")
                    {
                        if (strTranType == "FE" || strTranType == "FI")
                        {
                            if (cmbbl.SelectedItem.Text == mblno)
                            {
                                // wt = INVOICEobj.GetSumofWeight(txtjob.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                // amount = rate * exrate * (wt / 1000);
                                wt = INVOICEobj.GetSumofWeightnew(txtjob.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                            }
                            else
                            {
                                //wt = INVOICEobj.GetWeight(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                //amount = rate * exrate * (wt / 1000);


                                wt = INVOICEobj.GetWeightnew(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                                amount = rate * exrate * (wt);
                                douvolume = wt;
                                fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
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
                    if (cmbbl.SelectedItem.Text == mblno)
                    {
                        wt = INVOICEobj.GetSumofChargeWght(Convert.ToInt32(txtjob.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                    }
                    else
                    {
                        wt = INVOICEobj.GetChargeWeight(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                        amount = rate * exrate * wt;
                        douvolume = wt;
                        fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                    }

                }
                else
                {
                    wt = INVOICEobj.GetGrossWeight(cmbbl.SelectedItem.Text, Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * wt;
                    douvolume = wt;
                }
            }
            else if (cmbbase.Text.ToUpper() == "W/M".ToUpper()) // added on 04Feb2023 // nambi
            {
                Double strvolume, doublevolume, strntweight;

                double cbmAmt = 0;
                double mtAmt = 0;


                strvolume = INVOICEobj.GetVolume(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchId"].ToString()));
                cbmAmt = rate * exrate * strvolume;

                strntweight = INVOICEobj.GetWeightnew(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchId"].ToString()));
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
                DtBLNO = DAdvise.FillBLNo(Convert.ToInt32(txtjob.Text), strTranType, Convert.ToInt32(Session["LoginBranchid"]));
                if (DtBLNO.Rows.Count > 0)
                {
                    mblno = DtBLNO.Rows[0][0].ToString();
                }
                if (cmbbl.SelectedItem.Text != mblno)
                {
                    sizecount = INVOICEobj.GetBaseCount(cmbbl.SelectedItem.Text, strbase, strTranType, "BL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount;
                    douvolume = sizecount;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "H"));
                }

                else
                {
                    sizecount = INVOICEobj.GetBaseCount(txtjob.Text, strbase, strTranType, "MBL", Convert.ToInt32(Session["LoginBranchid"]));
                    amount = rate * exrate * sizecount;
                    douvolume = sizecount;
                    fd = Convert.ToInt32(DAdvise.GetFDFromBLNO(cmbbl.SelectedItem.Text, strTranType, Convert.ToInt32(Session["LoginBranchid"]), "M"));
                }
            }

            hid_douvolume.Value = douvolume.ToString();
            hid_fd.Value = fd.ToString();
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
            try
            {
                useit();
                if (ddl_voutype.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Kindly Select Voucher Type');", true);
                    ddl_voutype.Focus();
                    return;
                }
                if (txtcharge.Text.Trim() == "")
                {
                    return;
                }
                if (INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 1 && Session["StrTranType"].ToString() != "AC")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job has Closed Already You Can not Modify the Voucher here');", true);
                    txtclear();
                    txtjob.Focus();
                    return;

                }
                if (INVOICEobj.CheckClosedJobs(strTranType, Convert.ToInt32(txtjob.Text), Convert.ToInt32(Session["LoginBranchid"])) == 0 && Session["StrTranType"].ToString() == "AC")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Job is still open , You Can not Modify the Voucher here..');", true);
                    txtclear();
                    txtjob.Focus();
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

                    //if (strTranType == "CH")
                    //{
                    //    Dt = INVOICEobj.GetHblInvoiceHead(txtblno.Text, "CHA", branchid);
                    //    if (Dt.Rows.Count != 0)
                    //    {
                    //        jobtype = Dt.Rows[0][10].ToString();
                    //    }
                    //}
                    //  ProINVobj.DelProLVDetails(Convert.ToInt32(txtref.Text), Convert.ToInt32(hdnChargid.Value), cmbbase.SelectedItem.Text, Convert.ToInt32(txtvouyear.Text), branchid, strTranType, Convert.ToInt32(ddl_voutype.SelectedValue));

                    DAdvise.DelDebitCreditOSV(cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value),
                        cmbbase.Text, Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), Convert.ToInt32(txtref.Text));



                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "Details Deleted.", true);
                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ DEL");
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ DEL");
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ DEL");
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 3, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ DEL");
                            break;

                    }
                    //if (ddl_voutype.SelectedItem.Text == "Proforma Sales Invoice")
                    //{
                    //    switch (Session["StrTranType"].ToString())
                    //    {
                    //        case "FE":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "FI":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "AE":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "AI":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "CH":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //    }
                    //}
                    //else if (ddl_voutype.SelectedItem.Text == "Proforma Purchase Invoice")
                    //{
                    //    switch (Session["StrTranType"].ToString())
                    //    {
                    //        case "FE":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1014, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "FI":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1021, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "AE":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1028, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "AI":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1035, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //        case "CH":
                    //            Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1042, 4, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + txtref.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/DEL");
                    //            break;
                    //    }
                    //}

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
          //  DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
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
            if (ddl_voutype.SelectedItem.Text == "Proforma OSSI")
            {
                header = "ProOSSI";
            }
            else if (ddl_voutype.SelectedItem.Text == "Proforma OSPI")
            {
                header = "ProOSPI";
            }
             

            if (txtref.Text.TrimEnd().Length > 0)
            {
                if( (countryid == 1102)||(countryid == 102))
                {
                    str_Script += "window.open('../Reportasp/OverseasVouchersrpt.aspx?refno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtjob.Text + "&bltype=" + header + "&" + this.Page.ClientQueryString + "','','');";
                    Session["OSstring"] = "refno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&tran=" + Session["StrTranTypeO"].ToString() + "&jobno=" + txtjob.Text + "&bltype=" + header + "&" + this.Page.ClientQueryString + "','','');";
                }
                else
                {
                   // str_Script = "window.open('../Reportasp/InvoiceReportOthcntry.aspx?Invoiceno=" + txtref.Text + "&vouyear=" + txtvouyear.Text + "&total=" + txtTotal.Text + "&blno=" + txtblno.Text.Replace("#", "") + "&bltype=" + bltype + "&header=" + header + "&Profoma=" + "Profoma" + "&voutype=" + ddl_voutype.SelectedValue + "&" + this.Page.ClientQueryString + "','','');";
                }
            }
            ScriptManager.RegisterStartupScript(btnview, typeof(Button), "Invoice", str_Script, true);

            

            //switch (Session["StrTranType"].ToString())
            //{
            //    case "FE":
            //        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1013, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + Refno + " - " + ddl_voutype.SelectedItem.Text);
            //        break;
            //    case "FI":
            //        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1020, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + Refno + " - " + ddl_voutype.SelectedItem.Text);
            //        break;
            //    case "AE":
            //        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1027, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + Refno + " - " + ddl_voutype.SelectedItem.Text);
            //        break;
            //    case "AI":
            //        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1034, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + Refno + " - " + ddl_voutype.SelectedItem.Text);
            //        break;
            //    case "CH":
            //        Logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 1041, 3, Convert.ToInt32(Session["LoginBranchid"]), Session["StrTranType"].ToString() + Refno + " - " + ddl_voutype.SelectedItem.Text);
            //        break;
            //}


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

                //if (ddl_voutype.SelectedItem.Text == "Proforma Invoice")
                //{
               // ChkCustStateName(Convert.ToInt32(hid_SupplyTo.Value), txtsupplyto.Text);
                if (bolcuststat == true)
                {
                    bolcuststat = false;
                    return;
                }
                if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
                {
                    douvolume = Convert.ToDouble(hid_douvolume.Value);
                }
                else
                {
                    douvolume = 0;
                }
                if (douvolume == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount is calculated as 0 ,Base Unit details not calculated properly,Kindly select the BL/MBL again..);", true);
                    return;
                }

                if (string.IsNullOrEmpty(hid_fd.Value) != true)
                {
                    fd = Convert.ToInt32(hid_fd.Value);
                }
                else
                {
                    fd = 0;
                }
                //}
                if (btnadd.ToolTip == "Add")
                {
                    DAdvise.InsOSVdetails(Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value),
                        txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text, Convert.ToDouble(txtamount.Text), 
                        Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd,
                        douvolume, Convert.ToInt32(hid_SupplyTo.Value),"Y", Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text));
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved..);", true);
                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD WITHGST");
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD WITHGST");
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD WITHGST");
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD WITHGST");
                            break;

                    }


                   
                }
                else
                {
                    int ind = Convert.ToInt32(Session["index"]);
                   string strbase = grd.Rows[ind].Cells[6].Text;



                    DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text), cmbbase.Text,
                        Convert.ToDouble(txtamount.Text), cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value), strbase, Convert.ToInt32(ddl_voutype.SelectedValue),
                        Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(),
                        fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y", Convert.ToInt32(txtref.Text), Convert.ToInt32(hid_SupplyTo.Value), "Y");
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated for Ref# " + txtref.Text + "');", true);
                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD WITHGST");
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD WITHGST");
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD WITHGST");
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD WITHGST");
                            break;

                    }
                }
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
                if (string.IsNullOrEmpty(hid_douvolume.Value) != true)
                {
                    douvolume = Convert.ToDouble(hid_douvolume.Value);
                }
                else
                {
                    douvolume = 0;
                }
                if (douvolume == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Amount is calculated as 0 ,Base Unit details not calculated properly,Kindly select the BL/MBL again..);", true);
                    return;
                }

                if (string.IsNullOrEmpty(hid_fd.Value) != true)
                {
                    fd = Convert.ToInt32(hid_fd.Value);
                }
                else
                {
                    fd = 0;
                }
                if (btnadd.ToolTip == "Add")
                {
                    DAdvise.InsOSVdetails(Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), cmbbl.SelectedItem.Text,
                        Convert.ToInt32(hdnChargid.Value), txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text),
                        cmbbase.Text, Convert.ToDouble(txtamount.Text), Convert.ToInt32(ddl_voutype.SelectedValue),
                        Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value),
                        "Y", Convert.ToInt32(hid_SupplyTo.Value), "N", Convert.ToInt32(txtref.Text), Convert.ToInt32(txtvouyear.Text));
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Saved.. ');", true);


                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST");
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST"); 
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093, 1, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ ADD NOGST"); 
                            break;
                        
                    }

                }
                else
                {

                    int ind = Convert.ToInt32(Session["index"]);
                    string strbase = grd.Rows[ind].Cells[6].Text;
                    DAdvise.UpdDCAdviseForGstForNewservisetaxOSV(txtcurr.Text, Convert.ToDouble(txtrate.Text), Convert.ToDouble(txtex.Text),
                        cmbbase.Text, Convert.ToDouble(txtamount.Text), cmbbl.SelectedItem.Text, Convert.ToInt32(hdnChargid.Value), strbase,
                        Convert.ToInt32(ddl_voutype.SelectedValue), Convert.ToInt32(Session["LoginBranchid"]), txtremarks.Text.ToUpper(),
                        Convert.ToInt32(txtjob.Text), Session["StrTranTypeO"].ToString(), fd, douvolume, Convert.ToInt32(hid_SupplyTo.Value), "Y",
                        Convert.ToInt32(txtref.Text), Convert.ToInt32(hid_SupplyTo.Value), "N");
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.WebControls.Button), "logix", "alertify.alert('Details Updated for Ref# " + txtref.Text + "');", true);
                    switch (ddl_product.SelectedValue)
                    {
                        case "FE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10085, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                            break;
                        case "FI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10091, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                            break;
                        case "AE":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10092, 2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                            break;
                        case "AI":
                            logobj.InsLogDetail(Convert.ToInt32(Session["LoginEmpId"]), 10093,2, Convert.ToInt32(Session["LoginBranchid"]), ddl_product.SelectedValue + cmbbl.Text + "/" + Convert.ToInt32(hdnChargid.Value) + "/ UPD NOGST");
                            break;

                    }
                }
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
// DataAccess.Masters.MasterCharges chargeobj = new DataAccess.Masters.MasterCharges();
                int int_branchid = Convert.ToInt32(Session["LoginBranchid"].ToString());
                string str_TranType = ddl_product.SelectedValue;
                int currid = chargeobj.GetCurrID(txtcurr.Text.Trim().ToUpper());
                if (currid != 0)
                {
                    if (txtcharge.Text != "" && txtcurr.Text != "")
                    {
                        if (txtcurr.Text.ToUpper() != "INR")
                        {
                            txtex.Text = INVOICEobj.GetCheckInvExrate(Convert.ToInt32(txtjob.Text), str_TranType, int_branchid, txtcurr.Text).ToString();
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
           // DataAccess.UserPermission userobj = new DataAccess.UserPermission();
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
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "logix", "alertify.alert('This customer " + txtsupplyto.Text + " status is Hold please discuss with Finance team ');", true);
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
                            ScriptManager.RegisterStartupScript(txtsupplyto, typeof(Button), "DataFound", "alertify.alert('please  Once again update the chargedetails');", true);
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

                  //  DataAccess.UserPermission obj_UP = new DataAccess.UserPermission();
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
            if (ddl_voutype.SelectedItem.Text == "Proforma OSSI" )
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
            else if (ddl_voutype.SelectedItem.Text == "Proforma OSPI")
            {
                txtto.ToolTip = "Bill To";
                txtsupplyto.ToolTip = "Supply To";
                //txtto.Attributes["Placeholder"] = "Bill To";
                Amendexrate.Visible = false;
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
                    ScriptManager.RegisterStartupScript(btnsave, typeof(Button), "DataFound", "alertify.alert('Vendor Ref # Already Exists..');", true);

                    txtVendorRefno.Focus();

                    return;
                }
            }
        }
        protected void Amendexrate_Click(object sender, EventArgs e)
        {
            if (txtref.Text != "" && cmbbl.SelectedItem.Text!="")
            {
                iframe1.Attributes["src"] = "../ForwardExports/AmendExRate.aspx?INjobno=" + txtjobno.Value + "&refno=" + txtref.Text + "&blno=" + cmbbl.SelectedItem.Text+"&invou="+ddl_voutype.SelectedValue;
                pop_up.Show();

            }
            else
            {
                if (txtref.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Ref # cannot be Empty!');", true);
                    txtref.Focus();
                }
                if (cmbbl.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.WebControls.TextBox), "logix", "alert('Kindly select BL!');", true);
                    txtref.Focus();
                }


            }
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

    }

}